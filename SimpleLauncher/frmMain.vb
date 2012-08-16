Imports System.IO
Imports System.Text

Public Class frmMain
#Region "Declarations"
    Public tmpControl As MagicControl

    Private isFullScreen As Boolean = False
    Private isTabNodeSelected As Boolean = False
    Private panel2Enabled As Boolean = False
    Private selectedOnRedraw As Boolean = False

    Private Const strNone As String = "                  (None)                  "
#End Region
#Region "Buttons"
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
            For i = 0 To tvItems.Nodes.Count - 1
                For Each item As TreeNode In tvItems.Nodes.Item(i).Nodes
                    If item Is Nothing Then Continue For
                    If activeButton.Text = item.Text Then
                        tvItems.SelectedNode = item
                        Exit Sub
                    End If
                Next
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
            Me.Text = Strings.Left(Me.Text, Me.Text.Length - Len(" (Locked)"))
            frmMainLocked = False
        Else
            tbtnLock.Image = My.Resources.lock
            Me.Text = Me.Text & " (Locked)"
            frmMainLocked = True
        End If
    End Sub

    Private Sub tbtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbtnSave.Click
        tbMain.SelectedTab.Cursor = Cursors.WaitCursor
        writeSaveFile(tbMain, curProject.Path)
        SaveSettings()
        tbMain.SelectedTab.Cursor = Cursors.Default
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
        chkVisible.Checked = False
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
            tbMain.SelectedTab.Controls.Remove(activeButton)
        End If
        CreateList()
        ClearProperties()
    End Sub

    Private Sub csTreeNodesRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles csTreeNodesRemove.Click
        RemoveSelected()
    End Sub
#End Region
#Region "tvItems"
    Private Function isNodeButton(ByVal node As TreeNode) As Boolean
        If node.Level = 0 Then Return False
        For Each tp As TabPage In tbMain.TabPages
            If tp.Tag = "start" Then Continue For
            For Each control As Button In tp.Controls
                If control.Text = node.Text Then Return True
            Next
        Next
        Return False
    End Function

    Private Sub CreateList()
        Dim selected As String = ""
        If tvItems.SelectedNode IsNot Nothing Then selected = tvItems.SelectedNode.Text
        tvItems.BeginUpdate()
        LockWindowUpdate(Me.Handle)

        tvItems.Nodes.Clear()
        For Each tp As TabPage In tbMain.TabPages
            If tp.Tag = "start" Then Continue For
            Dim projectNode As New TreeNode(tp.Text)
            projectNode.ImageKey = "folder"
            projectNode.SelectedImageKey = "folder"
            tvItems.Nodes.Add(projectNode)

            For Each control As Button In tp.Controls
                Dim item As New TreeNode
                item.Text = control.Text
                item.BackColor = control.BackColor
                item.ForeColor = control.ForeColor
                If CBool(Split(control.Tag, "|")(2)) Then
                    Dim type As String = GetFileType(RemovePath(Split(control.Tag, "|")(0)))
                    item.ImageKey = type
                    item.SelectedImageKey = type
                Else
                    item.ImageKey = "blank"
                    item.SelectedImageKey = "blank"
                End If

                tvItems.Nodes.Item(tvItems.Nodes.Count - 1).Nodes.Add(item)
                If item.Text = selected Then
                    selectedOnRedraw = True
                    tvItems.SelectedNode = item
                End If
            Next
        Next
        tvItems.ExpandAll()
        LockWindowUpdate(0)
        tvItems.EndUpdate()
    End Sub

    Private Sub RemoveSelected()
        If tvItems.SelectedNode Is Nothing Then Exit Sub
        If isNodeButton(tvItems.SelectedNode) Then
            For Each control As Button In tbMain.SelectedTab.Controls
                If control.Text = tvItems.SelectedNode.Text Then
                    If MsgBox("Really delete '" & control.Text & "'?", MsgBoxStyle.YesNo + MsgBoxStyle.Information, "Delete?") = MsgBoxResult.Yes Then
                        tbMain.SelectedTab.Controls.Remove(control)
                        CreateList()
                        ClearProperties()
                        Exit For
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
                Me.Text = e.Label & " - Enid" & IIf(frmMainLocked, " (Locked)", "")
                tbMain.SelectedTab.Text = e.Label
                Exit Sub
            End If
            For Each control As Button In tbMain.SelectedTab.Controls
                If control.Text = e.Node.Text Then
                    control.Text = e.Label
                    tvItems.LabelEdit = False
                    Exit Sub
                End If
            Next
        End If
    End Sub

    Private Sub tvItems_BeforeCollapse(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewCancelEventArgs) Handles tvItems.BeforeCollapse
        e.Cancel = True
    End Sub

    Private Sub tvItems_BeforeSelect(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewCancelEventArgs) Handles tvItems.BeforeSelect
        LockWindowUpdate(tvItems.Handle)
    End Sub

    Private Sub tvItems_AfterSelect(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles tvItems.AfterSelect
        If selectedOnRedraw Then selectedOnRedraw = False : Exit Sub

        If isNodeButton(e.Node) Then
            If e.Node.Parent.Text <> tbMain.SelectedTab.Text Then
                For Each tp As TabPage In tbMain.TabPages
                    If tp.Tag = "start" Then Continue For
                    If e.Node.Parent.Text = tp.Text Then
                        isTabNodeSelected = True
                        tbMain.SelectTab(tp)
                        tvItems.Focus()
                    End If
                Next
            End If

            For Each control As Button In tbMain.SelectedTab.Controls
                If control.Text = e.Node.Text Then
                    EnablePanel2()
                    SetProperties(control)
                    Exit For
                End If
            Next
        Else
            For Each tp As TabPage In tbMain.TabPages
                If tp.Tag = "start" Then Continue For
                If e.Node.Text = tp.Text Then
                    tbMain.SelectTab(tp)
                    tvItems.Focus()
                    Exit For
                End If
            Next
            DisablePanel2()
            ClearProperties()
        End If
        LockWindowUpdate(0)
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

    Private Sub tvItems_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles tvItems.MouseDoubleClick
        If e.Button = Windows.Forms.MouseButtons.Left Then
            tvItems.SelectedNode = tvItems.GetNodeAt(e.Location)
            If frmMainLocked AndAlso tvItems.SelectedNode.Level > 0 Then
                For Each tp As TabPage In tbMain.TabPages
                    If tp.Tag = "start" Then Continue For
                    For Each control As Button In tp.Controls
                        If control.Text = tvItems.SelectedNode.Text Then
                            Button_MouseDown(control, e)
                        End If
                    Next
                Next
            End If
        End If
    End Sub

    Private Sub tvItems_ItemAdded(ByVal obj As customTreeView) Handles tvItems.ItemAdded
        If tvItems.GetScrollMax() = 0 Then
            sbTreeView.Visible = False
            tvItems.UpdateScrollbar()
        Else
            sbTreeView.Visible = True
            tvItems.UpdateScrollbar()
        End If
    End Sub

    Private Sub tvItems_ItemsRemoved(ByVal obj As customTreeView) Handles tvItems.ItemsRemoved
        If tvItems.GetScrollMax() = 0 Then
            sbTreeView.Visible = False
            tvItems.UpdateScrollbar()
        Else
            sbTreeView.Visible = True
            tvItems.UpdateScrollbar()
        End If
    End Sub
#End Region
#Region "tbMain"
    Private Sub CloseAllTabs()
        For Each tp As TabPage In tbMain.TabPages
            If tp.Tag = "start" Then Continue For
            tbMain.TabPages.Remove(tp)
        Next
    End Sub

    Private Sub tbMain_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbMain.SelectedIndexChanged
        If isTabNodeSelected Then
            isTabNodeSelected = False
            Exit Sub
        End If

        If tbMain.SelectedTab.Tag = "start" Then
            Me.Text = curProject.Name & " - Enid" & IIf(frmMainLocked, " (Locked)", "")
        Else
            For Each node As TreeNode In tvItems.Nodes
                If node.Text = tbMain.SelectedTab.Text Then
                    tvItems.SelectedNode = node
                    Me.Text = tbMain.SelectedTab.Text & " - Enid" & IIf(frmMainLocked, " (Locked)", "")
                    Exit For
                End If
            Next
        End If

        frmMain_Resize(Me, EventArgs.Empty)
    End Sub

    Private Sub tbMain_TabsReordered(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbMain.TabsReordered
        CreateList()
    End Sub
#End Region
#Region "Form"
    Private Sub toNormal()
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.Fixed3D
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
        For Each tp As TabPage In tbMain.TabPages
            If tp.Tag = "start" Then Continue For
            For Each control As Button In tp.Controls
                If control.Text = text Then
                    Return True
                End If
            Next
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
                    If lastPoint = (New Point(-1, -1)) Then lastPoint = New Point(e.X, e.Y)

                    Dim newButton As New Button
                    newButton = createButton(csButtons, filePaths(fileNum))
                    tbMain.SelectedTab.Controls.Add(newButton)

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
                        tbMain.SelectedTab.Controls.Remove(newButton)
                        CreateList()
                        Exit Sub
                    Else
                        newButton.Location = newLocation
                    End If

                    lastSize = newButton.Size
                    lastPoint = newButton.Location
                    tmpControl = New MagicControl(newButton)
                End If
            Next

            lastPoint = New Point(-1, -1)
            lastSize = New Size(-1, -1)
            CreateList()
        End If
    End Sub

    Private Sub frmMain_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles Me.DragEnter
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            e.Effect = DragDropEffects.Copy
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub

    Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        PrepareImageList()
        FillRecentProjects()
        DisablePanel2()
        LoadSettings()

        curProject.isOpened = False
        tbMain.TabPages(0).BackColor = Color.FromArgb(255, 60, 70, 75)
        If My.Settings.recentProjects Is Nothing Then My.Settings.recentProjects = New Specialized.StringCollection()

        'If My.Computer.FileSystem.FileExists(datFile) Then
        '    loadSaveFile(tbMain, datFile)
        '    tbMain.SelectedIndex = 1
        '    Me.Text = tbMain.SelectedTab.Text & " - Enid"

        '    ClearProperties()
        '    CreateList()
        'Else
        '    tbMain.SelectedTab.Text = "Untitled"
        '    Me.Text = tbMain.SelectedTab.Text & " - Enid"

        '    Dim projectNode As New TreeNode("Untitled")
        '    projectNode.ImageKey = "folder"
        '    projectNode.SelectedImageKey = "folder"
        '    tvItems.Nodes.Add(projectNode)
        'End If
    End Sub

    Private Sub frmMain_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If MsgBox("You will lose any unsaved data!" & vbCrLf & "Are you sure that you want to quit?", MsgBoxStyle.YesNo Or MsgBoxStyle.Information, "Enid") = MsgBoxResult.No Then
            e.Cancel = True
        Else
            My.Settings.Save()
            e.Cancel = False
        End If
    End Sub

    Private Sub frmMain_Resize(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Resize
        rectcurProjects.Width = (tbMain.SelectedTab.Size.Width - 270) - 9
        rectcurProjects.Height = (tbMain.SelectedTab.Size.Height - 3) - 8
        rectHelp.Height = (tbMain.SelectedTab.Size.Height - 492) - 10

        lblcurProj.Left = ((rectcurProjects.Left + rectcurProjects.Width) / 2) + (lblcurProj.Width / 2)
    End Sub

    Private Sub frmMain_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F11 Then
            If isFullScreen Then toNormal() Else toFullScreen()
        ElseIf e.KeyCode = Keys.F4 Then
            If splitMain.Panel2Collapsed Then splitMain.Panel2Collapsed = False Else splitMain.Panel2Collapsed = True
        End If
    End Sub

    Private Sub splitMain_SplitterMoved(ByVal sender As System.Object, ByVal e As System.Windows.Forms.SplitterEventArgs) Handles splitMain.SplitterMoved
        Me.Focus()
    End Sub

    Private Sub splitMain_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles splitMain.MouseUp
        Me.Focus()
    End Sub

    Private Sub splitMain_Panel1_Click(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles splitMain.Panel1.Click
        If tbMain.SelectedTab.Cursor <> Cursors.Cross Or e.Button <> Windows.Forms.MouseButtons.Left Then Exit Sub

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
        tbMain.SelectedTab.Controls.Add(newButton)
        newButton.Location = New Point(e.X - (newButton.Width / 2), e.Y - (newButton.Height / 2))
        tmpControl = New MagicControl(newButton)

        dialogList.lvChoosen.Items.Remove(curItem)
        If dialogList.lvChoosen.Items.Count = 0 Then
            dialogList.Close()
            tbMain.SelectedTab.Cursor = Cursors.Default
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

        imglstProject.Images.Add("project", My.Resources.report)
        imglstProject.Images.Add("no_project", My.Resources.report_delete)

        imglstPlugins.Images.Add("plugin", My.Resources.plugin)
    End Sub
#End Region
#Region "Properties Bar"

    Private Sub EnablePanel2()
        panel2Enabled = True

        lblText.ForeColor = Color.White
        lblPath.ForeColor = Color.White
        lblColor.ForeColor = Color.White
        lbltColor.ForeColor = Color.White
        lblWidth.ForeColor = Color.White
        lblHeight.ForeColor = Color.White
        lblX.ForeColor = Color.White
        lblY.ForeColor = Color.White
        lblVisible.ForeColor = Color.White
        lblProgram.ForeColor = Color.White
        chkVisible.FlatAppearance.BorderColor = SystemColors.ControlDarkDark
        chkVisible.FlatAppearance.CheckedBackColor = SystemColors.ActiveCaption

        txtText.Enabled = True
        txtPath.Enabled = True
        btnPath.Enabled = True
        btnPath.Refresh()
        txttColor.Enabled = True
        txtColor.Enabled = True
        txtWidth.Enabled = True
        txtHeight.Enabled = True
        txtX.Enabled = True
        txtY.Enabled = True
        chkVisible.Enabled = True
        txtProgram.Enabled = True
        btnProgram.Enabled = True
        btnProgram.Refresh()
    End Sub

    Private Sub DisablePanel2()
        panel2Enabled = False

        lblText.ForeColor = Color.DarkGray
        lblPath.ForeColor = Color.DarkGray
        lblColor.ForeColor = Color.DarkGray
        lbltColor.ForeColor = Color.DarkGray
        lblWidth.ForeColor = Color.DarkGray
        lblHeight.ForeColor = Color.DarkGray
        lblX.ForeColor = Color.DarkGray
        lblY.ForeColor = Color.DarkGray
        lblVisible.ForeColor = Color.DarkGray
        lblProgram.ForeColor = Color.DarkGray
        chkVisible.FlatAppearance.BorderColor = Color.DarkGray
        chkVisible.FlatAppearance.CheckedBackColor = SystemColors.InactiveCaptionText

        txtText.Enabled = False
        txtPath.Enabled = False
        btnPath.Enabled = False
        btnPath.Refresh()
        txttColor.Enabled = False
        txtColor.Enabled = False
        txtWidth.Enabled = False
        txtHeight.Enabled = False
        txtX.Enabled = False
        txtY.Enabled = False
        chkVisible.Enabled = False
        txtProgram.Enabled = False
        btnProgram.Enabled = False
        btnProgram.Refresh()
    End Sub

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

        Dim buffer() As String = Split(control.Tag, "|")
        txtPath.Text = buffer(0)
        txtProgram.Text = buffer(1)
        chkVisible.Checked = buffer(2)
    End Sub

    Private Sub PaintEllipsis(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles btnPath.Paint, btnProgram.Paint
        If panel2Enabled Then
            e.Graphics.DrawString("...", New Font("Microsoft Sans Serif", 8.25, FontStyle.Regular, GraphicsUnit.Point, 0), Brushes.White, 4, 2)
        Else
            e.Graphics.DrawString("...", New Font("Microsoft Sans Serif", 8.25, FontStyle.Regular, GraphicsUnit.Point, 0), Brushes.DarkGray, 4, 2)
        End If
    End Sub

    Private Sub btnPath_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPath.Click
        openDialog.InitialDirectory = RemoveFile(txtPath.Text)
        openDialog.FileName = RemovePath(txtPath.Text)
        openDialog.Filter = "All Files|*.*"
        If openDialog.ShowDialog() = Windows.Forms.DialogResult.OK Then
            txtPath.Text = openDialog.FileName
        End If
    End Sub

    Private Sub btnProgram_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProgram.Click
        openDialog.InitialDirectory = RemoveFile(txtProgram.Text)
        openDialog.FileName = RemovePath(txtProgram.Text)
        openDialog.Filter = "All Files|*.*"
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
        For Each control As Button In tbMain.SelectedTab.Controls
            If control.Text = tvItems.SelectedNode.Text Then
                control.Text = txtText.Text
                Exit Sub
            End If
        Next
    End Sub

    Private Sub txtPath_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPath.Validated
        For Each control As Button In tbMain.SelectedTab.Controls
            If control.Text = tvItems.SelectedNode.Text Then
                Dim buffer() As String = Split(control.Tag, "|")
                control.Tag = txtPath.Text & "|" & buffer(1) & "|" & buffer(2)
                Exit Sub
            End If
        Next
    End Sub

    Private Sub txtProgram_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtProgram.Validated
        For Each control As Button In tbMain.SelectedTab.Controls
            If control.Text = tvItems.SelectedNode.Text Then
                Dim buffer() As String = Split(control.Tag, "|")
                control.Tag = buffer(0) & "|" & txtProgram.Text & "|" & buffer(2)
                Exit Sub
            End If
        Next
    End Sub

    Private Sub SizeValidated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtWidth.Validated, txtHeight.Validated
        For Each control As Button In tbMain.SelectedTab.Controls
            If control.Text = tvItems.SelectedNode.Text Then
                control.Size = New Size(CInt(txtWidth.Text), CInt(txtHeight.Text))
                Exit Sub
            End If
        Next
    End Sub

    Private Sub XYValidated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtX.Validated, txtY.Validated
        For Each control As Button In tbMain.SelectedTab.Controls
            If control.Text = tvItems.SelectedNode.Text Then
                control.Location = New Point(CInt(txtX.Text), CInt(txtY.Text))
                Exit Sub
            End If
        Next
    End Sub

    Private Sub ColorsValidated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txttColor.Validated, txtColor.Validated
        For Each control As Button In tbMain.SelectedTab.Controls
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
        For Each control As Button In tbMain.SelectedTab.Controls
            If control.Text = tvItems.SelectedNode.Text Then
                Dim buffer() As String = Split(control.Tag, "|")
                control.Tag = buffer(0) & "|" & buffer(1) & "|" & chkVisible.Checked.ToString
                control.Visible = chkVisible.Checked
                CreateList()
                Exit Sub
            End If
        Next
    End Sub

    Private Sub txttColor_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txttColor.MouseHover, txtColor.MouseHover
        Dim control As Control = sender
        ttColorMsg.Show("Double-click to view a color picker", control)
    End Sub

    Private Sub PathProg_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPath.TextChanged, txtProgram.TextChanged
        Dim control As Control = sender
        If control.Tag Is Nothing Then control.Tag = txtPath.Text & "|" & txtProgram.Text & "|True" : Exit Sub
        control.Tag = txtPath.Text & "|" & txtProgram.Text & "|" & Split(control.Tag, "|")(2)
    End Sub
#End Region
#Region "Start Page"
    Private Sub ResetAndLoad()
        CloseAllTabs()
        tvItems.Nodes.Clear()
        loadSaveFile(tbMain, curProject.Path)
        tbMain.SelectedIndex = 1
        CreateList()
        ClearProperties()
        Me.Text = tbMain.SelectedTab.Text & " - Enid" & IIf(frmMainLocked, " (Locked)", "")
    End Sub

    Private Sub AddProjectToRecent()
        Dim newItem As New ListViewItem
        newItem.Text = RemovePath(curProject.Path)
        newItem.Tag = curProject.Path
        newItem.ImageKey = "project"
        If Strings.Trim(lvProjects.Items(0).Text) = "(None)" Then
            lvProjects.Items.Clear()
            lvProjects.Items.Add(newItem)
        Else
            For Each item As ListViewItem In lvProjects.Items
                If item.Tag = newItem.Tag Then
                    lvProjects.Items.Remove(item)
                    lvProjects.Items.Insert(0, newItem)
                    UpdateRecentProjectSettings()
                    Exit Sub
                End If
            Next

            If lvProjects.Items.Count = 10 Then
                lvProjects.Items.RemoveAt(9)
                lvProjects.Items.Insert(0, newItem)
            Else
                lvProjects.Items.Insert(0, newItem)
            End If
        End If

        UpdateRecentProjectSettings()
    End Sub

    Private Sub FillRecentProjects()
        If My.Settings.recentProjects.Count > 0 And My.Settings.recentProjects IsNot Nothing Then
            For i As Short = 0 To (My.Settings.recentProjects.Count - 1)
                Dim newItem As New ListViewItem
                newItem.Text = RemovePath(My.Settings.recentProjects.Item(i))
                newItem.Tag = My.Settings.recentProjects.Item(i)
                If My.Computer.FileSystem.FileExists(newItem.Tag) Then
                    newItem.ImageKey = "project"
                Else
                    newItem.ImageKey = "no_project"
                End If
                lvProjects.Items.Add(newItem)
            Next
        Else
            lvProjects.Items.Add(strNone)
        End If
    End Sub

    Private Sub UpdateRecentProjectSettings()
        My.Settings.recentProjects.Clear()
        For Each item As ListViewItem In lvProjects.Items
            My.Settings.recentProjects.Add(item.Tag)
        Next
    End Sub

    Private Sub lvProjects_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lvProjects.MouseDoubleClick
        Dim clickedItem As ListViewItem = lvProjects.GetItemAt(e.X, e.Y)
        Dim nextPath As String = clickedItem.Tag

        If Not My.Computer.FileSystem.FileExists(clickedItem.Tag) Then
            lvProjects.Items(clickedItem.Index).ImageKey = "no_project"
            If MsgBox("This project does not exist!" & vbCrLf & vbCrLf & "Would you like to locate it yourself?", MsgBoxStyle.YesNo + MsgBoxStyle.Critical) = MsgBoxResult.Yes Then
                openDialog.Filter = "Enid Projects|*.enid|All Files|*.*"
                If openDialog.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    lvProjects.Items(clickedItem.Index).Text = RemovePath(openDialog.FileName)
                    lvProjects.Items(clickedItem.Index).Tag = openDialog.FileName
                    nextPath = openDialog.FileName
                Else
                    Exit Sub
                End If
            Else
                lvProjects.Items.Remove(clickedItem)
                UpdateRecentProjectSettings()
                Exit Sub
            End If
        End If

        If curProject.isOpened Then
            Select Case MsgBox("Would you like to save your current project before opening another?", MsgBoxStyle.YesNoCancel + MsgBoxStyle.Information)
                Case MsgBoxResult.Yes
                    tbMain.SelectedTab.Cursor = Cursors.WaitCursor
                    writeSaveFile(tbMain, curProject.Path)
                    SaveSettings()
                    tbMain.SelectedTab.Cursor = Cursors.Default
                Case MsgBoxResult.Cancel
                    Exit Sub
            End Select
        End If

        curProject.isOpened = False
        curProject.Path = nextPath
        ResetAndLoad()
        AddProjectToRecent()
        lvProjects.Clear()
        FillRecentProjects()
    End Sub

    Private Sub lvProjects_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvProjects.SelectedIndexChanged
        If Strings.Trim(lvProjects.Items(0).Text) = "(None)" Then
            lvProjects.Items(0).Selected = False
        End If
    End Sub

    Private Sub lnkOpenProject_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkOpenProject.LinkClicked
        If e.Button = Windows.Forms.MouseButtons.Left Then
            openDialog.Filter = "Enid Projects|*.enid|All Files|*.*"
            If openDialog.ShowDialog() = Windows.Forms.DialogResult.OK AndAlso My.Computer.FileSystem.FileExists(openDialog.FileName) Then
                If curProject.isOpened Then
                    Select Case MsgBox("Would you like to save your current project before opening another?", MsgBoxStyle.YesNoCancel + MsgBoxStyle.Information)
                        Case MsgBoxResult.Yes
                            tbMain.SelectedTab.Cursor = Cursors.WaitCursor
                            writeSaveFile(tbMain, curProject.Path)
                            SaveSettings()
                            tbMain.SelectedTab.Cursor = Cursors.Default
                        Case MsgBoxResult.Cancel
                            Exit Sub
                    End Select
                End If
                curProject.isOpened = False
                curProject.Path = openDialog.FileName
                ResetAndLoad()
                AddProjectToRecent()
                lvProjects.Clear()
                FillRecentProjects()
            End If
        End If
    End Sub

    Private Sub csRecentClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles csRecentClear.Click
        lvProjects.Clear()
        lvProjects.Items.Add(strNone)
        My.Settings.recentProjects.Clear()
        My.Settings.Save()
    End Sub

    Private Sub lnkLocatePlugins_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkLocatePlugins.LinkClicked
        ' TODO Plugins
    End Sub
#End Region
End Class