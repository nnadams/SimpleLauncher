Imports System.IO
Imports System.Text

Public Class frmMain
    Public tmpControl As MagicControl

    Private isFullScreen As Boolean = False
    Private datFile As String = My.Application.Info.DirectoryPath.ToString() & "\Enid.dat"

#Region "Toolbar"
    Private Sub tbtnSettings_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbtnSettings.Click
        dialogSettings.ShowDialog()
    End Sub

    Private Sub tbtnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbtnAdd.Click
        dialogAdd.ShowDialog()
    End Sub

    Private Sub tbtnLock_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbtnLock.Click
        If frmMainLocked Then
            tbtnLock.Image = My.Resources.lock_open
            frmMainLocked = False
        Else
            tbtnLock.Image = My.Resources.lock
            frmMainLocked = True
        End If
    End Sub

    Private Sub tbtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbtnSave.Click
        splitMain.Panel1.Cursor = Cursors.WaitCursor
        With My.Computer.FileSystem
            .WriteAllText(datFile, My.Application.Info.Version.Major & "." & My.Application.Info.Version.Minor & vbCrLf, False)
            .WriteAllText(datFile, dialogSettings.numCols.Value.ToString & "|" & dialogSettings.numRows.Value.ToString & vbCrLf, True)
            .WriteAllText(datFile, dialogSettings.chkEnAuto.Checked.ToString & vbCrLf, True)
            .WriteAllText(datFile, dialogSettings.openDialog.FileName & vbCrLf, True)
            .WriteAllText(datFile, lastPoint.X & "|" & lastPoint.Y & vbCrLf, True)
            .WriteAllText(datFile, lastSize.Width & "|" & lastSize.Height & vbCrLf, True)
            .WriteAllText(datFile, Me.Width & "|" & Me.Height & vbCrLf, True)

            On Error Resume Next
            For Each control As Button In splitMain.Panel1.Controls
                .WriteAllText(datFile, control.Tag & "|" & _
                              control.Text & "|" & _
                              control.Location.X & "|" & _
                              control.Location.Y & "|" & _
                              control.Width & "|" & _
                              control.Height & "|" & _
                              control.Visible & vbCrLf, True)
            Next
        End With
        splitMain.Panel1.Cursor = Cursors.Default
    End Sub
#End Region
#Region "ContextMenus"
    Private Sub csItemHide_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles csItemHide.Click
        Dim control As New ToolStripMenuItem
        Dim strip As New ContextMenuStrip
        Dim activeButton As New Button

        control = sender
        strip = control.Owner
        activeButton = strip.SourceControl

        activeButton.Visible = False
        RefreshList()
    End Sub

    Private Sub csitemRename_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles csitemRename.Click
        Dim control As New ToolStripMenuItem
        Dim strip As New ContextMenuStrip
        Dim activeButton As New Button

        control = sender
        strip = control.Owner
        activeButton = strip.SourceControl

        Dim buffer As String = InputBox("Enter a name:" & vbCrLf & "'" & activeButton.Text & "'", "Choose Name", activeButton.Text)
        If buffer <> "" Then
            If Not searchForExisting(buffer) Then
                activeButton.Text = buffer
            Else
                MsgBox("There is already a button with that name.", MsgBoxStyle.Exclamation)
            End If
        End If
        RefreshList()
    End Sub

    Private Sub csitemRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles csitemRemove.Click
        Dim control As New ToolStripMenuItem
        Dim strip As New ContextMenuStrip
        Dim activeButton As New Button

        control = sender
        strip = control.Owner
        activeButton = strip.SourceControl

        If MsgBox("Really delete '" & activeButton.Text & "'?", MsgBoxStyle.YesNo, "Delete?") = MsgBoxResult.Yes Then
            splitMain.Panel1.Controls.Remove(activeButton)
        End If
        RefreshList()
    End Sub
#End Region

    Private Sub toNormal()
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.Sizable
        Me.WindowState = FormWindowState.Normal
        Me.TopMost = False
        isFullScreen = False
    End Sub

    Private Sub toFullScreen()
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        Me.WindowState = FormWindowState.Maximized
        Me.TopMost = True
        isFullScreen = True
    End Sub

    Private Sub RefreshList()
        clbButtons.Items.Clear()
        For Each control As Button In splitMain.Panel1.Controls
            Dim checked As Boolean = IIf(control.Visible, True, False)
            clbButtons.Items.Add(control.Text, checked)
        Next
    End Sub

    Private Function searchForExisting(ByVal text As String) As Boolean
        For Each control As Button In splitMain.Panel1.Controls
            If control.Text = text Then
                Return True
            End If
        Next
        Return False
    End Function

    Private Sub frmMain_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles Me.DragDrop
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            Dim filePaths As String() = CType(e.Data.GetData(DataFormats.FileDrop), String())

            If filePaths.Length > 100 Then
                MsgBox("Too many files at once.", MsgBoxStyle.Critical)
                Exit Sub
            End If

            For fileNum As Integer = 0 To (filePaths.Count() - 1)
                If My.Computer.FileSystem.FileExists(filePaths(fileNum)) = False Then
                    MsgBox("Skipping the adding of" & vbCrLf & "'" & filePaths(fileNum) & "'" & vbCrLf & "because it could not be found.", MsgBoxStyle.Exclamation)
                ElseIf searchForExisting(RemovePath(filePaths(fileNum))) Then
                    MsgBox("Skipping the adding of" & vbCrLf & "'" & filePaths(fileNum) & "'" & vbCrLf & "because it already exists.", MsgBoxStyle.Exclamation)
                Else
                    Dim newButton As New Button
                    newButton = createButton(csButtons, filePaths(fileNum))
                    splitMain.Panel1.Controls.Add(newButton)

                    Dim panelSize As Size = New Size(splitMain.SplitterDistance, splitMain.Height)
                    Dim newLocation As Point = GetNewLocation(lastPoint, lastSize, newButton.Size, panelSize)
                    If newLocation = (New Point(-1, -1)) Then
                        Dim buffer As String = "There is no more room. The following files were not imported:" & vbCrLf
                        For leftFiles = fileNum To (filePaths.Count - 1)
                            buffer += filePaths(leftFiles) & vbCrLf
                        Next
                        buffer += vbCrLf & "The next location has been reset to (0,0)."
                        MsgBox(buffer, MsgBoxStyle.Exclamation)

                        lastPoint = New Point(-1, -1)
                        lastSize = New Size(-1, -1)
                        splitMain.Panel1.Controls.Remove(newButton)
                        RefreshList()
                        Exit Sub
                    Else
                        newButton.Location = newLocation
                    End If

                    lastSize = newButton.Size
                    lastPoint = newButton.Location
                    tmpControl = New MagicControl(newButton)
                End If
            Next
            RefreshList()
        End If
    End Sub

    Private Sub frmMain_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles Me.DragEnter
        If e.Data.GetDataPresent(DataFormats.FileDrop) And dialogSettings.chkEnAuto.Checked = True Then
            e.Effect = DragDropEffects.Copy
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub

    Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        splitMain.Panel1.BackColor = Color.FromArgb(255, 60, 70, 75)
        If Not My.Computer.FileSystem.FileExists(datFile) Then Exit Sub

        Dim streamReader As New StreamReader(datFile)
        Dim line As String
        Dim curline As Integer = 0
        Dim buffer() As String

        Do
            line = streamReader.ReadLine()
            Select Case curline
                Case 0
                    If line <> My.Application.Info.Version.Major & "." & My.Application.Info.Version.Minor Then
                        If MsgBox("Old save file detected! Would you like to delete it?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                            streamReader.Close()
                            My.Computer.FileSystem.DeleteFile(datFile)
                        End If
                        Exit Sub
                    End If
                Case 1
                    buffer = Split(line, "|")
                    dialogSettings.numCols.Value = CInt(buffer(0))
                    dialogSettings.numRows.Value = CInt(buffer(1))
                Case 2
                    If line = "True" Then dialogSettings.chkEnAuto.Checked = True
                Case 3
                    dialogSettings.openDialog.FileName = line
                Case 4
                    buffer = Split(line, "|")
                    lastPoint.X = CInt(buffer(0))
                    lastPoint.Y = CInt(buffer(1))
                Case 5
                    buffer = Split(line, "|")
                    lastSize.Width = CInt(buffer(0))
                    lastSize.Height = CInt(buffer(1))
                Case 6
                    buffer = Split(line, "|")
                    Me.Width = CInt(buffer(0))
                    Me.Height = CInt(buffer(1))
                Case Else
                    If line = "" Then Exit Do
                    buffer = Split(line, "|")

                    Dim newButton As New Button
                    newButton = createButton(csButtons)
                    newButton.Visible = CBool(buffer(6))
                    newButton.Size = New Size(buffer(4), buffer(5))
                    newButton.Location = New Point(buffer(2), buffer(3))
                    newButton.Tag = buffer(0)
                    newButton.Text = buffer(1)

                    splitMain.Panel1.Controls.Add(newButton)
                    tmpControl = New MagicControl(newButton)
            End Select
            curline += 1
        Loop
        streamReader.Close()
        RefreshList()
    End Sub

    Private Sub frmMain_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If MsgBox("You will lose any unsaved data!" & vbCrLf & "Are you sure that you want to quit?", MsgBoxStyle.YesNo Or MsgBoxStyle.Information, "Enid") = MsgBoxResult.No Then
            e.Cancel = True
        Else
            e.Cancel = False
        End If
    End Sub

    Private Sub splitMain_Panel1_Click(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles splitMain.Panel1.Click
        If splitMain.Panel1.Cursor <> Cursors.Cross Or e.Button <> Windows.Forms.MouseButtons.Left Then Exit Sub

        Dim newButton As New Button
        Dim curItem As ListViewItem

        If dialogList.lvChoosen.SelectedItems.Count = 0 Then
            curItem = dialogList.lvChoosen.Items(0)
        Else
            curItem = dialogList.lvChoosen.SelectedItems(0)
        End If

        newButton = createButton(csButtons)
        newButton.Text = curItem.Text
        newButton.Tag = curItem.Tag
        splitMain.Panel1.Controls.Add(newButton)
        newButton.Location = New Point(e.X - (newButton.Width / 2), e.Y - (newButton.Height / 2))
        tmpControl = New MagicControl(newButton)

        dialogList.lvChoosen.Items.Remove(curItem)
        If dialogList.lvChoosen.Items.Count = 0 Then
            dialogList.Close()
            splitMain.Panel1.Cursor = Cursors.Default
        Else
            dialogList.lvChoosen.Items(0).Selected = True
        End If
    End Sub

    Private Sub frmMain_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F11 Then
            If isFullScreen Then toNormal() Else toFullScreen()
        ElseIf e.KeyCode = Keys.F4 Then
            If splitMain.Panel2Collapsed Then splitMain.Panel2Collapsed = False Else splitMain.Panel2Collapsed = True
        End If
    End Sub

    Private Sub splitMain_SplitterMoved(ByVal sender As System.Object, ByVal e As System.Windows.Forms.SplitterEventArgs) Handles splitMain.SplitterMoved
        Me.ActiveControl = Nothing
    End Sub

    Private Sub clbButtons_ItemCheck(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ItemCheckEventArgs) Handles clbButtons.ItemCheck
        For Each control As Button In splitMain.Panel1.Controls
            If control.Text = clbButtons.Items(e.Index) Then
                control.Visible = IIf(e.NewValue = CheckState.Checked, True, False)
            End If
        Next
    End Sub
End Class
