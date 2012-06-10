Imports System.IO
Imports System.Text
Imports System.Text.RegularExpressions


Public Class frmMain
    Public isLocked As Boolean = False

    Private dialog As New diaSettings
    'Private datFile As String = My.Application.Info.DirectoryPath.ToString() & "\Enid.dat"
    Private datFile As String = "C:\Users\Nick\Desktop\Enid.dat" ' TODO: Remove for release!

    Private tmpControl As MagicControl
    Private lastPoint As Point = New Point(-1, -1)

    Private Sub csitemRename_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles csitemRename.Click
        Dim control As New ToolStripMenuItem
        Dim strip As New ContextMenuStrip
        Dim activeButton As New Button

        control = sender
        strip = control.Owner
        activeButton = strip.SourceControl
        activeButton.Text = InputBox("Enter a name:" & vbCrLf & "'" & activeButton.Text & "'", "Choose Name", activeButton.Text)
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

    Private Sub Button_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        If Not isLocked And e.Button = Windows.Forms.MouseButtons.Right Then
            csButtons.Show(sender, e.Location)
        ElseIf isLocked And e.Button = Windows.Forms.MouseButtons.Left Then
            Dim activeButton As New Button
            activeButton = sender

            If activeButton.Tag = "" Or dialog.openDialog.FileName = "" Then Exit Sub
            Process.Start(dialog.openDialog.FileName, Chr(34) & activeButton.Tag & Chr(34))
        End If
    End Sub

    Private Sub frmMain_DragEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles MyBase.DragEnter
        If e.Data.GetDataPresent(DataFormats.FileDrop) And dialog.chkEnAuto.Checked = True Then
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

            For Each fileLoc As String In filePaths
                If My.Computer.FileSystem.FileExists(fileLoc) Then
                    Dim newButton As New Button
                    Dim tmp As String = ""

                    newButton.Location = GetNextLocation(lastPoint, dialog.numCols.Value, dialog.numRows.Value, newButton.Width + 10, newButton.Height + 10)
                    lastPoint = newButton.Location
                    newButton.Tag = fileLoc

                    tmp = InputBox("Enter a name for:" & vbCrLf & "'" & fileLoc & "'", "Choose Name", "")
                    If tmp = "" Then tmp = RemovePath(fileLoc)
                    newButton.Text = tmp

                    newButton.ContextMenuStrip = csButtons
                    AddHandler newButton.MouseDown, AddressOf Button_MouseDown
                    Me.Controls.Add(newButton)
                    tmpControl = New MagicControl(newButton)
                Else
                    MsgBox("Skipping the adding of" & vbCrLf & "'" & fileLoc & "'" & vbCrLf & "because it could not be found!", MsgBoxStyle.Exclamation)
                End If
            Next fileLoc
        End If
    End Sub

    Private Function GetNextLocation(ByVal curLoc As Point, ByVal cols As Integer, ByVal rows As Integer, ByVal width As Integer, ByVal height As Integer)
        Dim x As Integer = curLoc.X
        Dim y As Integer = curLoc.Y

        If x = -1 And y = -1 Then
            Return New Point(0, 25)
        Else
            Return New Point((x + width) Mod (width * cols), IIf((x + width) = (width * cols), (y + height) Mod (height * rows), y))
        End If
    End Function

    Private Function RemovePath(ByVal Path As String)
        Path = Regex.Replace(Path, ".*\\", "")
        Return Path
    End Function

    Private Sub tbtnSettings_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbtnSettings.Click
        dialog.ShowDialog()
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
            .WriteAllText(datFile, dialog.numCols.Value.ToString & vbCrLf, False)
            .WriteAllText(datFile, dialog.numRows.Value.ToString & vbCrLf, True)
            .WriteAllText(datFile, dialog.chkEnAuto.Checked.ToString & vbCrLf, True)
            .WriteAllText(datFile, dialog.openDialog.FileName & vbCrLf, True)

            On Error Resume Next
            For Each control As Button In Me.Controls
                .WriteAllText(datFile, control.Tag & "|" & control.Text & "|" & control.Location.X & "|" & control.Location.Y & vbCrLf, True)
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
                    dialog.numCols.Value = CInt(line)
                Case 1
                    dialog.numRows.Value = CInt(line)
                Case 2
                    If line = "True" Then dialog.chkEnAuto.Checked = True
                Case 3
                    dialog.openDialog.FileName = line
                Case Else
                    If line = "" Then Exit Do
                    buffer = Split(line, "|")

                    Dim newButton As New Button
                    newButton.Location = New Point(buffer(2), buffer(3))
                    newButton.Tag = buffer(0)
                    newButton.Text = buffer(1)
                    AddHandler newButton.MouseDown, AddressOf Button_MouseDown
                    Me.Controls.Add(newButton)
                    tmpControl = New MagicControl(newButton)
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
End Class
