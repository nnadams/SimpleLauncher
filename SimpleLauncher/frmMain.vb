Imports System.IO
Imports System.Text

Public Class frmMain
    Public isLocked As Boolean = False
    Public lastPoint As Point = New Point(-1, -1)
    Public tmpControl As MagicControl

    Private isLit As Boolean = True
    Private datFile As String = My.Application.Info.DirectoryPath.ToString() & "\Enid.dat"

    Public Sub Button_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        Dim activeButton As New Button
        activeButton = sender

        If isLocked And e.Button = Windows.Forms.MouseButtons.Left Then
            If activeButton.Tag = "" Then
                MsgBox("There was an error accessing data. Please remove and reimport this file.", MsgBoxStyle.Critical)
            ElseIf dialogSettings.openDialog.FileName = "" Then
                MsgBox("Please choose an application to launch with.", MsgBoxStyle.Exclamation)
            Else
                Process.Start(dialogSettings.openDialog.FileName, Chr(34) & activeButton.Tag & Chr(34))
            End If
        End If
    End Sub

    Private Sub csitemRename_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles csitemRename.Click
        Dim control As New ToolStripMenuItem
        Dim strip As New ContextMenuStrip
        Dim activeButton As New Button

        control = sender
        strip = control.Owner
        activeButton = strip.SourceControl

        Dim buffer As String = InputBox("Enter a name:" & vbCrLf & "'" & activeButton.Text & "'", "Choose Name", activeButton.Text)
        If buffer <> "" Then activeButton.Text = buffer
    End Sub

    Private Sub csitemRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles csitemRemove.Click
        Dim control As New ToolStripMenuItem
        Dim strip As New ContextMenuStrip
        Dim activeButton As New Button

        control = sender
        strip = control.Owner
        activeButton = strip.SourceControl
        If MsgBox("Really delete '" & activeButton.Text & "'?", MsgBoxStyle.YesNo, "Delete?") = MsgBoxResult.Yes Then
            Me.Controls.Remove(activeButton)
        End If
    End Sub

    Private Sub frmMain_DragEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles MyBase.DragEnter
        If e.Data.GetDataPresent(DataFormats.FileDrop) And dialogSettings.chkEnAuto.Checked = True Then
            e.Effect = DragDropEffects.Copy
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub

    Private Sub frmMain_DragDrop(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles MyBase.DragDrop
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            Dim filePaths As String() = CType(e.Data.GetData(DataFormats.FileDrop), String())

            If filePaths.Length > 100 Then
                MsgBox("Too many files at once.")
                Exit Sub
            End If

            For Each file As String In filePaths
                If My.Computer.FileSystem.FileExists(file) Then
                    Dim newButton As New Button
                    Dim buffer As String = RemovePath(file)
                    newButton.Text = buffer
                    newButton.ContextMenuStrip = csButtons

                    newButton.Location = GetNextFixedLocation(lastPoint, dialogSettings.numCols.Value, dialogSettings.numRows.Value, newButton.Width + 10, newButton.Height + 10)
                    lastPoint = newButton.Location
                    newButton.Tag = file
                    newButton.FlatStyle = FlatStyle.Popup
                    newButton.BackColor = Color.FromArgb(120, 120, 190)
                    newButton.ForeColor = Color.White

                    AddHandler newButton.MouseDown, AddressOf Button_MouseDown
                    Me.Controls.Add(newButton)
                    tmpControl = New MagicControl(newButton)
                Else
                    MsgBox("Skipping the adding of" & vbCrLf & "'" & file & "'" & vbCrLf & "because it could not be found!", MsgBoxStyle.Exclamation)
                End If
            Next file
        End If
    End Sub

    Private Sub tbtnSettings_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbtnSettings.Click
        dialogSettings.ShowDialog()
    End Sub

    Private Sub tbtnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbtnAdd.Click
        dialogAdd.ShowDialog()
    End Sub

    Private Sub tbtnLock_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbtnLock.Click
        If isLocked Then
            tbtnLock.Image = My.Resources.lock_open
            isLocked = False
        Else
            tbtnLock.Image = My.Resources.lock
            isLocked = True
        End If
    End Sub

    Private Sub tbtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbtnSave.Click
        Me.Cursor = Cursors.WaitCursor
        With My.Computer.FileSystem
            .WriteAllText(datFile, dialogSettings.numCols.Value.ToString & vbCrLf, False)
            .WriteAllText(datFile, dialogSettings.numRows.Value.ToString & vbCrLf, True)
            .WriteAllText(datFile, dialogSettings.chkEnAuto.Checked.ToString & vbCrLf, True)
            .WriteAllText(datFile, dialogSettings.openDialog.FileName & vbCrLf, True)

            On Error Resume Next
            For Each control As Button In Me.Controls
                .WriteAllText(datFile, control.Tag & "|" & _
                              control.Text & "|" & _
                              control.Location.X & "|" & _
                              control.Location.Y & "|" & _
                              control.Width & "|" & _
                              control.Height & vbCrLf, True)
            Next
        End With
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Not My.Computer.FileSystem.FileExists(datFile) Then Exit Sub

        Dim sreader As New StreamReader(datFile)
        Dim line As String
        Dim curline As Integer = 0
        Dim buffer() As String

        Do
            line = sreader.ReadLine()
            Select Case curline
                Case 0
                    dialogSettings.numCols.Value = CInt(line)
                Case 1
                    dialogSettings.numRows.Value = CInt(line)
                Case 2
                    If line = "True" Then dialogSettings.chkEnAuto.Checked = True
                Case 3
                    dialogSettings.openDialog.FileName = line
                Case Else
                    If line = "" Then Exit Do
                    buffer = Split(line, "|")

                    Dim newButton As New Button
                    newButton.Size = New Size(buffer(4), buffer(5))
                    newButton.Location = New Point(buffer(2), buffer(3))
                    newButton.Tag = buffer(0)
                    newButton.Text = buffer(1)
                    newButton.ContextMenuStrip = csButtons
                    newButton.FlatStyle = FlatStyle.Popup
                    newButton.BackColor = Color.FromArgb(120, 120, 190)
                    newButton.ForeColor = Color.White

                    AddHandler newButton.MouseDown, AddressOf Button_MouseDown
                    Me.Controls.Add(newButton)
                    tmpControl = New MagicControl(newButton)
                    lastPoint = newButton.Location
            End Select
            curline += 1
        Loop
    End Sub

    Private Sub frmMain_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If MsgBox("You will lose any unsaved data!" & vbCrLf & "Are you sure that you want to quit?", MsgBoxStyle.YesNo Or MsgBoxStyle.Information, "Enid") = MsgBoxResult.No Then
            e.Cancel = True
        Else
            e.Cancel = False
        End If
    End Sub

    Private Sub frmMain_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseClick
        If Me.Cursor <> Cursors.Cross Or e.Button <> Windows.Forms.MouseButtons.Left Then Exit Sub

        Dim newButton As New Button
        Dim curItem As ListViewItem

        If dialogList.lvChoosen.SelectedItems.Count = 0 Then
            curItem = dialogList.lvChoosen.Items(0)
        Else
            curItem = dialogList.lvChoosen.SelectedItems(0)
        End If

        newButton.Text = curItem.Text
        newButton.Tag = curItem.Tag
        newButton.Width = GetWidth(curItem.Text)
        newButton.Location = New Point(e.X - (newButton.Width / 2), e.Y - (newButton.Height / 2))
        newButton.ContextMenuStrip = csButtons
        newButton.FlatStyle = FlatStyle.Popup
        newButton.BackColor = Color.FromArgb(120, 120, 190)
        newButton.ForeColor = Color.White
        AddHandler newButton.MouseDown, AddressOf Button_MouseDown
        Me.Controls.Add(newButton)
        tmpControl = New MagicControl(newButton)

        dialogList.lvChoosen.Items.Remove(curItem)
        If dialogList.lvChoosen.Items.Count = 0 Then
            dialogList.Close()
            Me.Cursor = Cursors.Default
        Else
            dialogList.lvChoosen.Items(0).Selected = True
        End If
    End Sub

    Private Sub tbtnLight_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbtnLight.Click
        If isLit Then
            tsMain.BackgroundImage = My.Resources.background
            Me.BackColor = Color.FromArgb(255, 67, 78, 84)
            tbtnLight.Image = My.Resources.lightbulb_off
            isLit = False
        Else
            tsMain.BackgroundImage = Nothing
            Me.BackColor = Color.FromArgb(255, 240, 240, 240)
            tbtnLight.Image = My.Resources.lightbulb
            isLit = True
        End If
    End Sub
End Class
