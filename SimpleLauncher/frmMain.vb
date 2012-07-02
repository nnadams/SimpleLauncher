Imports System.IO
Imports System.Text

Public Class frmMain
#Region "Declarations"
    Public tmpControl As MagicControl

    Private isFullScreen As Boolean = False
    Private datFile As String = My.Application.Info.DirectoryPath.ToString() & "\data.xml"
#End Region
#Region "Button"
    Public Sub Button_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        Dim activeButton As Button
        activeButton = sender

        If frmMainLocked And e.Button = Windows.Forms.MouseButtons.Left Then
            Dim file As String = Split(activeButton.Tag, "|")(0)
            Dim program As String = Split(activeButton.Tag, "|")(1)
            If activeButton.Tag = "" Then
                MsgBox("There was an error accessing data. Please remove and reimport this file.", MsgBoxStyle.Critical)
            ElseIf file = "" Then
                MsgBox("No file is associated with this button.", MsgBoxStyle.Exclamation)
            ElseIf Split(activeButton.Tag, "|")(1) = "" AndAlso GetFileType(RemovePath(file)) <> "terminal" Then
                MsgBox("Please choose an application to launch with.", MsgBoxStyle.Exclamation)
            ElseIf Split(activeButton.Tag, "|")(1) = "" AndAlso GetFileType(RemovePath(file)) = "terminal" Then
                Process.Start(file)
            Else
                Process.Start(program, Chr(34) & file & Chr(34))
            End If
        Else
            For Each item As TreeNode In tvItems.Nodes.Item(0).Nodes
                If item Is Nothing Then Continue For
                If activeButton.Text = item.Text Then
                    tvItems.SelectedNode = item
                    Exit Sub
                End If
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
        writeSaveFile(splitMain.Panel1, datFile, tvItems.Nodes.Item(0).Text)
        splitMain.Panel1.Cursor = Cursors.Default
    End Sub
#End Region
#Region "ContextMenus"
    Private Sub csButtonsHide_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles csButtonsHide.Click
        Dim control As New ToolStripMenuItem
        Dim strip As New ContextMenuStrip
        Dim activeButton As New Button

        control = sender
        strip = control.Owner
        activeButton = strip.SourceControl

        activeButton.Visible = False
        RefreshList()
    End Sub

    Private Sub csButtonsRename_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles csButtonsRename.Click
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
                tvItems.SelectedNode.Text = buffer
            Else
                MsgBox("There is already a button with that name.", MsgBoxStyle.Exclamation)
            End If
        End If
        SetProperties(activeButton)
    End Sub

    Private Sub csButtonsRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles csButtonsRemove.Click
        Dim control As New ToolStripMenuItem
        Dim strip As New ContextMenuStrip
        Dim activeButton As New Button

        control = sender
        strip = control.Owner
        activeButton = strip.SourceControl

        If MsgBox("Really delete '" & activeButton.Text & "'?", MsgBoxStyle.YesNo + MsgBoxStyle.Information, "Delete?") = MsgBoxResult.Yes Then
            splitMain.Panel1.Controls.Remove(activeButton)
        End If
        RefreshList()
        ClearProperties()
    End Sub

    Private Sub csTreeNodesRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles csTreeNodesRemove.Click
        RemoveSelected()
    End Sub
#End Region
#Region "tvItems"
    Private Function isNodeButton(ByVal node As TreeNode) As Boolean
        For Each control As Button In splitMain.Panel1.Controls
            If control.Text = node.Text Then Return True
        Next
        Return False
    End Function

    Private Sub RefreshList()
        tvItems.BeginUpdate()
        Dim selected As String = ""
        If Not tvItems.SelectedNode Is Nothing Then selected = tvItems.SelectedNode.Text

        tvItems.Nodes(0).Nodes.Clear()
        For Each control As Button In splitMain.Panel1.Controls
            Dim item As New TreeNode
            item.Text = control.Text
            item.BackColor = control.BackColor
            item.ForeColor = control.ForeColor
            If control.Visible Then
                Dim type As String = GetFileType(RemovePath(Split(control.Tag, "|")(0)))
                item.ImageKey = type
                item.SelectedImageKey = type
            Else
                item.ImageKey = "blank"
                item.SelectedImageKey = "blank"
            End If

            tvItems.Nodes.Item(0).Nodes.Add(item)
            If selected = item.Text Then tvItems.SelectedNode = item
        Next
        tvItems.Nodes.Item(0).Expand()
        tvItems.EndUpdate()
    End Sub

    Private Sub RemoveSelected()
        If tvItems.SelectedNode Is Nothing Then Exit Sub
        If isNodeButton(tvItems.SelectedNode) Then
            For Each control As Button In splitMain.Panel1.Controls
                If control.Text = tvItems.SelectedNode.Text Then
                    If MsgBox("Really delete '" & control.Text & "'?", MsgBoxStyle.YesNo + MsgBoxStyle.Information, "Delete?") = MsgBoxResult.Yes Then
                        splitMain.Panel1.Controls.Remove(control)
                        RefreshList()
                        ClearProperties()
                    End If
                End If
            Next
        End If
    End Sub

    Private Sub tvItems_AfterLabelEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.NodeLabelEditEventArgs) Handles tvItems.AfterLabelEdit
        If e.Label = "" Or (isNodeButton(e.Node) AndAlso searchForExisting(e.Label)) Then
            e.CancelEdit = True
        Else
            If e.Node Is tvItems.Nodes.Item(0) Then
                Me.Text = e.Label & " - Enid"
                Exit Sub
            End If
            For Each control As Button In splitMain.Panel1.Controls
                If control.Text = e.Node.Text Then
                    control.Text = e.Label
                    tvItems.LabelEdit = False
                    Exit Sub
                End If
            Next
        End If
    End Sub

    Private Sub tvItems_AfterSelect(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles tvItems.AfterSelect
        If isNodeButton(e.Node) Then
            For Each control As Button In splitMain.Panel1.Controls
                If control.Text = e.Node.Text Then
                    splitSide.Panel2.Enabled = True
                    SetProperties(control)
                    Exit Sub
                End If
            Next
        Else
            splitSide.Panel2.Enabled = False
            ClearProperties()
        End If
    End Sub

    Private Sub tvItems_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tvItems.KeyDown
        If e.KeyCode = Keys.F2 Then
            tvItems.LabelEdit = True
            tvItems.SelectedNode.BeginEdit()
        ElseIf e.KeyCode = Keys.Delete Then
            RemoveSelected()
        End If
    End Sub

    Private Sub tvItems_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles tvItems.MouseClick
        If e.Button = Windows.Forms.MouseButtons.Right Then
            tvItems.SelectedNode = tvItems.GetNodeAt(e.Location)
            If isNodeButton(tvItems.SelectedNode) Then
                csTreeNodes.Show(tvItems, e.Location)
            End If
        End If
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
            tvItems.SelectedNode = tvItems.Nodes.Item(0).Nodes.Item(0)
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
        PrepareImageList()
        splitMain.Panel1.BackColor = Color.FromArgb(255, 60, 70, 75)

        Dim projectNode As New TreeNode("Untitled")
        projectNode.ImageKey = "folder"
        projectNode.SelectedImageKey = "folder"
        tvItems.Nodes.Add(projectNode)

        If Not My.Computer.FileSystem.FileExists(datFile) Then Exit Sub
        tvItems.Nodes.Item(0).Text = loadSaveFile(splitMain.Panel1, datFile)
        Me.Text = tvItems.Nodes.Item(0).Text & " - Enid"
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

    Private Sub PrepareImageList()
        imglstTree.Images.Add("default", My.Resources.application)
        imglstTree.Images.Add("terminal", My.Resources.application_xp_terminal)
        imglstTree.Images.Add("film", My.Resources.film)
        imglstTree.Images.Add("folder", My.Resources.folder_table)
        imglstTree.Images.Add("music", My.Resources.music)
        imglstTree.Images.Add("photo", My.Resources.photo)
        imglstTree.Images.Add("blank", My.Resources.background)

        tvItems.ImageKey = "default"
        tvItems.SelectedImageKey = "default"
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
        txtProgram.Text = ""
    End Sub

    Private Sub SetProperties(ByVal control As Button)
        txtText.Text = control.Text
        txtColor.Text = ColorToHex(control.BackColor)
        txttColor.Text = ColorToHex(control.ForeColor)
        txtWidth.Text = control.Width
        txtHeight.Text = control.Height
        txtX.Text = control.Location.X
        txtY.Text = control.Location.Y
        chkVisible.Checked = control.Visible

        Dim buffer() As String = Split(control.Tag, "|")
        txtPath.Text = buffer(0)
        txtProgram.Text = buffer(1)
    End Sub

    Private Sub PaintEllipsis(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles btnPath.Paint, btnProgram.Paint
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

    Private Sub btnProgram_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProgram.Click
        openDialog.InitialDirectory = RemoveFile(txtProgram.Text)
        openDialog.FileName = RemovePath(txtProgram.Text)
        If openDialog.ShowDialog() = Windows.Forms.DialogResult.OK Then
            txtProgram.Text = openDialog.FileName
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
        If HexToColor(control.Text) = Color.Transparent Then e.Cancel = True
    End Sub

    Private Sub FileValidating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtPath.Validating, txtProgram.Validating
        Dim control As TextBox = sender
        If My.Computer.FileSystem.FileExists(control.Text) = False Then e.Cancel = True
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
        For Each control As Button In splitMain.Panel1.Controls
            If control.Text = tvItems.SelectedNode.Text Then
                control.Text = txtText.Text
                Exit Sub
            End If
        Next
    End Sub

    Private Sub txtPath_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPath.Validated
        For Each control As Button In splitMain.Panel1.Controls
            If control.Text = tvItems.SelectedNode.Text Then
                Dim buffer() As String = Split(control.Tag, "|")
                control.Tag = txtPath.Text & "|" & buffer(1)
                Exit Sub
            End If
        Next
    End Sub

    Private Sub txtProgram_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtProgram.Validated
        For Each control As Button In splitMain.Panel1.Controls
            If control.Text = tvItems.SelectedNode.Text Then
                Dim buffer() As String = Split(control.Tag, "|")
                control.Tag = buffer(0) & "|" & txtProgram.Text
                Exit Sub
            End If
        Next
    End Sub

    Private Sub SizeValidated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtWidth.Validated, txtHeight.Validated
        For Each control As Button In splitMain.Panel1.Controls
            If control.Text = tvItems.SelectedNode.Text Then
                control.Size = New Size(CInt(txtWidth.Text), CInt(txtHeight.Text))
                Exit Sub
            End If
        Next
    End Sub

    Private Sub XYValidated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtX.Validated, txtY.Validated
        For Each control As Button In splitMain.Panel1.Controls
            If control.Text = tvItems.SelectedNode.Text Then
                control.Location = New Point(CInt(txtX.Text), CInt(txtY.Text))
                Exit Sub
            End If
        Next
    End Sub

    Private Sub ColorsValidated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txttColor.Validated, txtColor.Validated
        For Each control As Button In splitMain.Panel1.Controls
            If control.Text = tvItems.SelectedNode.Text Then
                control.ForeColor = HexToColor(txttColor.Text)
                control.BackColor = HexToColor(txtColor.Text)
                tvItems.SelectedNode.ForeColor = control.ForeColor
                tvItems.SelectedNode.BackColor = control.BackColor
                Exit Sub
            End If
        Next
    End Sub

    Private Sub chkVisible_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkVisible.CheckedChanged
        If tvItems.SelectedNode Is Nothing Then Exit Sub
        For Each control As Button In splitMain.Panel1.Controls
            If control.Text = tvItems.SelectedNode.Text Then
                control.Visible = chkVisible.Checked
                RefreshList()
                Exit Sub
            End If
        Next
    End Sub

    Private Sub txttColor_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txttColor.MouseHover, txtColor.MouseHover
        Dim control As Control = sender
        ttColorMsg.Show("Double-click to view a color picker", control)
    End Sub
#End Region
End Class