Imports System.IO
Imports System.Text

Public Class frmMain
#Region "Declarations"
    Public tmpControl As MagicControl

    Private isFullScreen As Boolean = False
    Private datFile As String = My.Application.Info.DirectoryPath.ToString() & "\Enid.dat"
#End Region
#Region "Button"
    Public Sub Button_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        Dim activeButton As Button
        activeButton = sender

        If frmMainLocked And e.Button = Windows.Forms.MouseButtons.Left Then
            If activeButton.Tag = "" Then
                MsgBox("There was an error accessing data. Please remove and reimport this file.", MsgBoxStyle.Critical)
            ElseIf dialogSettings.openDialog.FileName = "" Then
                MsgBox("Please choose an application to launch with.", MsgBoxStyle.Exclamation)
            Else
                Process.Start(dialogSettings.openDialog.FileName, Chr(34) & activeButton.Tag & Chr(34))
            End If
        Else
            For Each item As ListViewItem In lvItems.Items
                If activeButton.Text = item.Text Then lvItems.Items(item.Index).Selected = True
            Next
        End If
    End Sub

    Public Sub Button_Reize(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim activeButton As Button
        activeButton = sender

        txtWidth.Text = activeButton.Width
        txtHeight.Text = activeButton.Height
    End Sub

    Public Sub Button_Move(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim activeButton As Button
        activeButton = sender

        txtX.Text = activeButton.Location.X
        txtY.Text = activeButton.Location.Y
    End Sub
#End Region
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
        ClearProperties()
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
                lvItems.SelectedItems(0).Text = buffer
            Else
                MsgBox("There is already a button with that name.", MsgBoxStyle.Exclamation)
            End If
        End If
        SetProperties(activeButton)
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
        ClearProperties()
    End Sub
#End Region
#Region "lvItems"

    Private Sub lvItems_AfterLabelEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LabelEditEventArgs) Handles lvItems.AfterLabelEdit
        If e.Label = "" Or searchForExisting(e.Label) Then
            e.CancelEdit = True
        Else
            For Each control As Button In splitMain.Panel1.Controls
                If control.Text = lvItems.Items(e.Item).Text Then control.Text = e.Label
            Next
        End If
        lvItems.LabelEdit = False
    End Sub

    Private Sub lvItems_ItemSelectionChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.ListViewItemSelectionChangedEventArgs) Handles lvItems.ItemSelectionChanged
        If lvItems.SelectedItems.Count = 0 Then
            splitSide.Panel2.Enabled = False
            ClearProperties()
        Else
            splitSide.Panel2.Enabled = True
            For Each control As Button In splitMain.Panel1.Controls
                If control.Text = e.Item.Text Then
                    control.Focus()
                    SetProperties(control)
                    Exit Sub
                End If
            Next
        End If
    End Sub

    Private Sub lvMain_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles lvItems.KeyDown
        If e.KeyCode = Keys.F2 And lvItems.SelectedItems.Count = 1 Then
            lvItems.LabelEdit = True
            lvItems.SelectedItems.Item(0).BeginEdit()
        End If
    End Sub

    Private Sub RefreshList()
        lvItems.Items.Clear()
        For Each control As Button In splitMain.Panel1.Controls
            Dim item As New ListViewItem
            item.Text = control.Text
            item.BackColor = control.BackColor
            item.ForeColor = control.ForeColor

            lvItems.Items.Add(item)
        Next
    End Sub
#End Region
#Region "Form"
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
        ClearProperties()
        RefreshList()
    End Sub

    Private Sub frmMain_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If MsgBox("You will lose any unsaved data!" & vbCrLf & "Are you sure that you want to quit?", MsgBoxStyle.YesNo Or MsgBoxStyle.Information, "Enid") = MsgBoxResult.No Then
            e.Cancel = True
        Else
            e.Cancel = False
        End If
    End Sub

    Private Sub frmMain_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F11 Then
            If isFullScreen Then toNormal() Else toFullScreen()
        ElseIf e.KeyCode = Keys.F4 Then
            If splitMain.Panel2Collapsed Then splitMain.Panel2Collapsed = False Else splitMain.Panel2Collapsed = True
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
#End Region
#Region "Properties Bar"
    Private Sub ClearProperties()
        txtText.Text = ""
        txtPath.Text = ""
        txtColor.Text = ""
        txttColor.Text = ""
        txtWidth.Text = ""
        txtHeight.Text = ""
        txtX.Text = ""
        txtY.Text = ""
        chkVisible.Checked = False
    End Sub

    Private Sub SetProperties(ByVal control As Button)
        txtText.Text = control.Text
        txtPath.Text = control.Tag
        txtColor.Text = ColorToHex(control.BackColor)
        txttColor.Text = ColorToHex(control.ForeColor)
        txtWidth.Text = control.Width
        txtHeight.Text = control.Height
        txtX.Text = control.Location.X
        txtY.Text = control.Location.Y
        chkVisible.Checked = control.Visible
    End Sub

    Private Sub PaintEllipsis(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles btnPath.Paint
        If splitSide.Panel2.Enabled Then
            e.Graphics.DrawString("...", New Font("Microsoft Sans Serif", 8.25, FontStyle.Regular, GraphicsUnit.Point, 0), Brushes.White, 4, 1)
        Else
            e.Graphics.DrawString("...", New Font("Microsoft Sans Serif", 8.25, FontStyle.Regular, GraphicsUnit.Point, 0), Brushes.DarkGray, 4, 1)
        End If
    End Sub

    Private Sub btnPath_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPath.Click
        openDialog.InitialDirectory = RemoveFile(txtPath.Text)
        openDialog.FileName = RemovePath(txtPath.Text)
        If openDialog.ShowDialog() = Windows.Forms.DialogResult.OK Then
            txtPath.Text = openDialog.FileName
        End If
    End Sub

    Private Sub txttColor_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txttColor.DoubleClick
        colorDialog.Color = HexToColor(txttColor.Text)
        If colorDialog.ShowDialog = Windows.Forms.DialogResult.OK Then
            txttColor.Text = ColorToHex(colorDialog.Color)
            ColorsValidated(sender, e)
        End If
    End Sub

    Private Sub txtColor_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtColor.DoubleClick
        colorDialog.Color = HexToColor(txtColor.Text)
        If colorDialog.ShowDialog = Windows.Forms.DialogResult.OK Then
            txtColor.Text = ColorToHex(colorDialog.Color)
            ColorsValidated(sender, e)
        End If
    End Sub

    Private Sub ColorValidating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txttColor.Validating, txtColor.Validating
        Dim control As TextBox = sender
        If control.Text.Length <> 6 Then e.Cancel = True : Exit Sub
        If HexToColor(control.Text) = Color.Transparent Then e.Cancel = True
    End Sub

    Private Sub FileValidating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtPath.Validating
        Dim control As TextBox = sender
        If My.Computer.FileSystem.FileExists(control.Text) = False Then
            MsgBox("That file does not exist!", MsgBoxStyle.Critical)
            e.Cancel = True
        End If
    End Sub

    Private Sub EmptyValidating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtText.Validating
        Dim control As TextBox = sender
        If control.Text = "" Then e.Cancel = True
    End Sub

    Private Sub NumberValidating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtWidth.Validating, txtHeight.Validating, txtX.Validating, txtY.Validating
        Dim control As TextBox = sender
        If control.Text = "" Or IsNumeric(control.Text) = False Then e.Cancel = True
    End Sub

    Private Sub txtText_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtText.Validated
        If lvItems.SelectedItems.Count = 0 Then Exit Sub
        For Each control As Button In splitMain.Panel1.Controls
            If control.Text = lvItems.SelectedItems(0).Text Then
                control.Text = txtText.Text
            End If
        Next
    End Sub

    Private Sub txtPath_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPath.Validated
        If lvItems.SelectedItems.Count = 0 Then Exit Sub
        For Each control As Button In splitMain.Panel1.Controls
            If control.Text = lvItems.SelectedItems(0).Text Then
                control.Tag = txtPath.Text
            End If
        Next
    End Sub

    Private Sub SizeValidated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtWidth.Validated, txtHeight.Validated
        If lvItems.SelectedItems.Count = 0 Then Exit Sub
        For Each control As Button In splitMain.Panel1.Controls
            If control.Text = lvItems.SelectedItems(0).Text Then
                control.Size = New Size(CInt(txtWidth.Text), CInt(txtHeight.Text))
            End If
        Next
    End Sub

    Private Sub XYValidated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtX.Validated, txtY.Validated
        If lvItems.SelectedItems.Count = 0 Then Exit Sub
        For Each control As Button In splitMain.Panel1.Controls
            If control.Text = lvItems.SelectedItems(0).Text Then
                control.Location = New Point(CInt(txtX.Text), CInt(txtY.Text))
            End If
        Next
    End Sub

    Private Sub ColorsValidated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txttColor.Validated, txtColor.Validated
        If lvItems.SelectedItems.Count = 0 Then Exit Sub
        For Each control As Button In splitMain.Panel1.Controls
            If control.Text = lvItems.SelectedItems(0).Text Then
                control.ForeColor = HexToColor(txttColor.Text)
                control.BackColor = HexToColor(txtColor.Text)
                lvItems.SelectedItems(0).ForeColor = control.ForeColor
                lvItems.SelectedItems(0).BackColor = control.BackColor
            End If
        Next
    End Sub

    Private Sub chkVisible_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkVisible.CheckedChanged
        If lvItems.SelectedItems.Count = 0 Then Exit Sub
        For Each control As Button In splitMain.Panel1.Controls
            If control.Text = lvItems.SelectedItems(0).Text Then
                control.Visible = chkVisible.Checked
                Exit Sub
            End If
        Next
    End Sub
#End Region
End Class