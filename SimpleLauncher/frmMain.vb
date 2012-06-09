Imports System.IO
Imports System.Text
Imports System.Text.RegularExpressions


Public Class frmMain
    Public isLocked As Boolean = False

    Private dialog As New diaSettings
    'Private datFile As String = My.Application.Info.DirectoryPath.ToString() & "\Enid.dat"
    Private datFile As String = "C:\Users\Nick\Desktop\Enid.dat"

    Private tmpControl As MagicControl
    Private lastPoint As Point = New Point(-1, -1)

    Private Sub RenameToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RenameToolStripMenuItem.Click
        Dim control As New ToolStripMenuItem
        Dim strip As New ContextMenuStrip
        Dim activeButton As New Button

        control = sender
        strip = control.Owner
        activeButton = strip.SourceControl
        activeButton.Text = InputBox("Enter a name:" & vbCrLf & "'" & activeButton.Text & "'", "Choose Name", activeButton.Text)
    End Sub

    Private Sub RemoveToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RemoveToolStripMenuItem.Click
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

    Private Sub Button_Clicked(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim activeButton As New Button
        activeButton = sender

        If activeButton.Tag = "" Or dialog.OpenFileDialog1.FileName = "" Then Exit Sub

        Process.Start(dialog.OpenFileDialog1.FileName, Chr(34) & activeButton.Tag & Chr(34))
    End Sub

    Private Sub frmMain_DragEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles MyBase.DragEnter
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
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

                    newButton.ContextMenuStrip = ContextMenuStrip1
                    AddHandler newButton.Click, AddressOf Button_Clicked
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

    Private Sub ToolStripButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton3.Click
        dialog.ShowDialog()
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        If isLocked Then
            ToolStripButton1.Image = ImageList1.Images(0)
            isLocked = False
        Else
            ToolStripButton1.Image = ImageList1.Images(1)
            isLocked = True
        End If
    End Sub

    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click
        With My.Computer.FileSystem
            .WriteAllText(datFile, dialog.numCols.Value.ToString & vbCrLf, False)
            .WriteAllText(datFile, dialog.numRows.Value.ToString & vbCrLf, True)
            .WriteAllText(datFile, dialog.OpenFileDialog1.FileName & vbCrLf, True)

            On Error Resume Next
            For Each control As Button In Me.Controls
                .WriteAllText(datFile, control.Tag & "|" & control.Text & "|" & control.Location.X & "|" & control.Location.Y & vbCrLf, True)
            Next
        End With
    End Sub

    Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ToolStrip1.Items.Add(ToolStripButton1)
        ToolStrip1.Items.Add(New ToolStripSeparator)
        ToolStrip1.Items.Add(ToolStripButton2)
        ToolStrip1.Items.Add(New ToolStripSeparator)
        ToolStrip1.Items.Add(ToolStripButton3)

        ToolStripButton1.Image = ImageList1.Images(0)
        ToolStripButton2.Image = ImageList1.Images(3)
        ToolStripButton3.Image = ImageList1.Images(2)

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
                    dialog.OpenFileDialog1.FileName = line
                Case Else
                    If line = "" Then Exit Do
                    buffer = Split(line, "|")

                    Dim newButton As New Button
                    newButton.Location = New Point(buffer(2), buffer(3))
                    newButton.Tag = buffer(0)
                    newButton.Text = buffer(1)
                    AddHandler newButton.Click, AddressOf Button_Clicked
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
