<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.csButtons = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.csButtonsHide = New System.Windows.Forms.ToolStripMenuItem
        Me.csButtonsRename = New System.Windows.Forms.ToolStripMenuItem
        Me.csButtonsRemove = New System.Windows.Forms.ToolStripMenuItem
        Me.tsContainer = New System.Windows.Forms.ToolStripContainer
        Me.splitMain = New System.Windows.Forms.SplitContainer
        Me.csRecent = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.csRecentClear = New System.Windows.Forms.ToolStripMenuItem
        Me.imglstProject = New System.Windows.Forms.ImageList(Me.components)
        Me.imglstPlugins = New System.Windows.Forms.ImageList(Me.components)
        Me.rectPlugins = New Microsoft.VisualBasic.PowerPacks.RectangleShape
        Me.rectHelp = New Microsoft.VisualBasic.PowerPacks.RectangleShape
        Me.rectcurProjects = New Microsoft.VisualBasic.PowerPacks.RectangleShape
        Me.rectProjects = New Microsoft.VisualBasic.PowerPacks.RectangleShape
        Me.splitSide = New System.Windows.Forms.SplitContainer
        Me.tvItems = New System.Windows.Forms.TreeView
        Me.imglstTree = New System.Windows.Forms.ImageList(Me.components)
        Me.chkVisible = New System.Windows.Forms.CheckBox
        Me.btnProgram = New System.Windows.Forms.Button
        Me.btnPath = New System.Windows.Forms.Button
        Me.txtHeight = New System.Windows.Forms.TextBox
        Me.txtY = New System.Windows.Forms.TextBox
        Me.txtWidth = New System.Windows.Forms.TextBox
        Me.txtX = New System.Windows.Forms.TextBox
        Me.txtProgram = New System.Windows.Forms.TextBox
        Me.txtPath = New System.Windows.Forms.TextBox
        Me.txtColor = New System.Windows.Forms.TextBox
        Me.txttColor = New System.Windows.Forms.TextBox
        Me.txtText = New System.Windows.Forms.TextBox
        Me.lblHeight = New System.Windows.Forms.Label
        Me.lblY = New System.Windows.Forms.Label
        Me.lblWidth = New System.Windows.Forms.Label
        Me.lblVisible = New System.Windows.Forms.Label
        Me.lblX = New System.Windows.Forms.Label
        Me.lblColor = New System.Windows.Forms.Label
        Me.lblProgram = New System.Windows.Forms.Label
        Me.lbltColor = New System.Windows.Forms.Label
        Me.lblPath = New System.Windows.Forms.Label
        Me.lblText = New System.Windows.Forms.Label
        Me.tsMain = New System.Windows.Forms.ToolStrip
        Me.tbtnLock = New System.Windows.Forms.ToolStripButton
        Me.tsSep1 = New System.Windows.Forms.ToolStripSeparator
        Me.tbtnAdd = New System.Windows.Forms.ToolStripButton
        Me.tbtnSave = New System.Windows.Forms.ToolStripButton
        Me.tsSep2 = New System.Windows.Forms.ToolStripSeparator
        Me.tbtnSettings = New System.Windows.Forms.ToolStripButton
        Me.openDialog = New System.Windows.Forms.OpenFileDialog
        Me.colorDialog = New System.Windows.Forms.ColorDialog
        Me.ttColorMsg = New System.Windows.Forms.ToolTip(Me.components)
        Me.csTreeNodes = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.csTreeNodesRemove = New System.Windows.Forms.ToolStripMenuItem
        Me.tbMain = New Enid.customTabControl
        Me.tpStart = New System.Windows.Forms.TabPage
        Me.lnkLocatePlugins = New System.Windows.Forms.LinkLabel
        Me.lvProjects = New System.Windows.Forms.ListView
        Me.lvPlugins = New System.Windows.Forms.ListView
        Me.lblPlugins = New System.Windows.Forms.Label
        Me.lblcurProj = New System.Windows.Forms.Label
        Me.lblHelp = New System.Windows.Forms.Label
        Me.lnkOpenProject = New System.Windows.Forms.LinkLabel
        Me.lnkNewProject = New System.Windows.Forms.LinkLabel
        Me.lblRecentProj = New System.Windows.Forms.Label
        Me.ShapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer
        Me.CustomTreeView1 = New Enid.customTreeView
        Me.csButtons.SuspendLayout()
        Me.tsContainer.ContentPanel.SuspendLayout()
        Me.tsContainer.LeftToolStripPanel.SuspendLayout()
        Me.tsContainer.SuspendLayout()
        Me.splitMain.Panel1.SuspendLayout()
        Me.splitMain.Panel2.SuspendLayout()
        Me.splitMain.SuspendLayout()
        Me.csRecent.SuspendLayout()
        Me.splitSide.Panel1.SuspendLayout()
        Me.splitSide.Panel2.SuspendLayout()
        Me.splitSide.SuspendLayout()
        Me.tsMain.SuspendLayout()
        Me.csTreeNodes.SuspendLayout()
        Me.tbMain.SuspendLayout()
        Me.tpStart.SuspendLayout()
        Me.SuspendLayout()
        '
        'csButtons
        '
        Me.csButtons.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.csButtonsHide, Me.csButtonsRename, Me.csButtonsRemove})
        Me.csButtons.Name = "csButtons"
        Me.csButtons.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.csButtons.Size = New System.Drawing.Size(118, 70)
        '
        'csButtonsHide
        '
        Me.csButtonsHide.Name = "csButtonsHide"
        Me.csButtonsHide.Size = New System.Drawing.Size(117, 22)
        Me.csButtonsHide.Text = "Hide"
        '
        'csButtonsRename
        '
        Me.csButtonsRename.Name = "csButtonsRename"
        Me.csButtonsRename.Size = New System.Drawing.Size(117, 22)
        Me.csButtonsRename.Text = "Rename"
        '
        'csButtonsRemove
        '
        Me.csButtonsRemove.Name = "csButtonsRemove"
        Me.csButtonsRemove.Size = New System.Drawing.Size(117, 22)
        Me.csButtonsRemove.Text = "Remove"
        '
        'tsContainer
        '
        Me.tsContainer.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        '
        'tsContainer.BottomToolStripPanel
        '
        Me.tsContainer.BottomToolStripPanel.Enabled = False
        Me.tsContainer.BottomToolStripPanelVisible = False
        '
        'tsContainer.ContentPanel
        '
        Me.tsContainer.ContentPanel.Controls.Add(Me.splitMain)
        Me.tsContainer.ContentPanel.Margin = New System.Windows.Forms.Padding(2)
        Me.tsContainer.ContentPanel.Size = New System.Drawing.Size(1360, 736)
        '
        'tsContainer.LeftToolStripPanel
        '
        Me.tsContainer.LeftToolStripPanel.BackgroundImage = Global.Enid.My.Resources.Resources.background
        Me.tsContainer.LeftToolStripPanel.Controls.Add(Me.tsMain)
        Me.tsContainer.LeftToolStripPanel.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.tsContainer.Location = New System.Drawing.Point(0, 0)
        Me.tsContainer.Margin = New System.Windows.Forms.Padding(2)
        Me.tsContainer.Name = "tsContainer"
        '
        'tsContainer.RightToolStripPanel
        '
        Me.tsContainer.RightToolStripPanel.BackgroundImage = Global.Enid.My.Resources.Resources.background
        Me.tsContainer.RightToolStripPanelVisible = False
        Me.tsContainer.Size = New System.Drawing.Size(1384, 736)
        Me.tsContainer.TabIndex = 2
        Me.tsContainer.TopToolStripPanelVisible = False
        '
        'splitMain
        '
        Me.splitMain.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.splitMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.splitMain.FixedPanel = System.Windows.Forms.FixedPanel.Panel2
        Me.splitMain.IsSplitterFixed = True
        Me.splitMain.Location = New System.Drawing.Point(0, 0)
        Me.splitMain.Margin = New System.Windows.Forms.Padding(2)
        Me.splitMain.Name = "splitMain"
        '
        'splitMain.Panel1
        '
        Me.splitMain.Panel1.Controls.Add(Me.tbMain)
        Me.splitMain.Panel1MinSize = 800
        '
        'splitMain.Panel2
        '
        Me.splitMain.Panel2.BackColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.splitMain.Panel2.Controls.Add(Me.splitSide)
        Me.splitMain.Panel2MinSize = 140
        Me.splitMain.Size = New System.Drawing.Size(1358, 734)
        Me.splitMain.SplitterDistance = 1092
        Me.splitMain.SplitterIncrement = 10
        Me.splitMain.SplitterWidth = 3
        Me.splitMain.TabIndex = 0
        Me.splitMain.TabStop = False
        '
        'csRecent
        '
        Me.csRecent.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.csRecentClear})
        Me.csRecent.Name = "csRecent"
        Me.csRecent.Size = New System.Drawing.Size(102, 26)
        '
        'csRecentClear
        '
        Me.csRecentClear.Name = "csRecentClear"
        Me.csRecentClear.Size = New System.Drawing.Size(101, 22)
        Me.csRecentClear.Text = "Clear"
        '
        'imglstProject
        '
        Me.imglstProject.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit
        Me.imglstProject.ImageSize = New System.Drawing.Size(16, 16)
        Me.imglstProject.TransparentColor = System.Drawing.Color.Transparent
        '
        'imglstPlugins
        '
        Me.imglstPlugins.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit
        Me.imglstPlugins.ImageSize = New System.Drawing.Size(16, 16)
        Me.imglstPlugins.TransparentColor = System.Drawing.Color.Transparent
        '
        'rectPlugins
        '
        Me.rectPlugins.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me.rectPlugins.BorderColor = System.Drawing.SystemColors.ControlDarkDark
        Me.rectPlugins.BorderWidth = 3
        Me.rectPlugins.CornerRadius = 25
        Me.rectPlugins.FillColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.rectPlugins.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Solid
        Me.rectPlugins.Location = New System.Drawing.Point(3, 283)
        Me.rectPlugins.Name = "rectPlugins"
        Me.rectPlugins.SelectionColor = System.Drawing.Color.Transparent
        Me.rectPlugins.Size = New System.Drawing.Size(254, 190)
        '
        'rectHelp
        '
        Me.rectHelp.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me.rectHelp.BorderColor = System.Drawing.SystemColors.ControlDarkDark
        Me.rectHelp.BorderWidth = 3
        Me.rectHelp.CornerRadius = 25
        Me.rectHelp.FillColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.rectHelp.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Solid
        Me.rectHelp.Location = New System.Drawing.Point(3, 487)
        Me.rectHelp.Name = "rectHelp"
        Me.rectHelp.SelectionColor = System.Drawing.Color.Transparent
        Me.rectHelp.Size = New System.Drawing.Size(254, 205)
        '
        'rectcurProjects
        '
        Me.rectcurProjects.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me.rectcurProjects.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rectcurProjects.BorderColor = System.Drawing.SystemColors.ControlDarkDark
        Me.rectcurProjects.BorderWidth = 3
        Me.rectcurProjects.CornerRadius = 25
        Me.rectcurProjects.FillColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.rectcurProjects.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Solid
        Me.rectcurProjects.Location = New System.Drawing.Point(269, 3)
        Me.rectcurProjects.Name = "rectcurProjects"
        Me.rectcurProjects.SelectionColor = System.Drawing.Color.Transparent
        Me.rectcurProjects.Size = New System.Drawing.Size(800, 695)
        '
        'rectProjects
        '
        Me.rectProjects.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me.rectProjects.BorderColor = System.Drawing.SystemColors.ControlDarkDark
        Me.rectProjects.BorderWidth = 3
        Me.rectProjects.CornerRadius = 25
        Me.rectProjects.FillColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.rectProjects.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Solid
        Me.rectProjects.Location = New System.Drawing.Point(3, 3)
        Me.rectProjects.Name = "RectangleShape1"
        Me.rectProjects.SelectionColor = System.Drawing.Color.Transparent
        Me.rectProjects.Size = New System.Drawing.Size(254, 266)
        '
        'splitSide
        '
        Me.splitSide.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.splitSide.Dock = System.Windows.Forms.DockStyle.Fill
        Me.splitSide.FixedPanel = System.Windows.Forms.FixedPanel.Panel2
        Me.splitSide.IsSplitterFixed = True
        Me.splitSide.Location = New System.Drawing.Point(0, 0)
        Me.splitSide.Margin = New System.Windows.Forms.Padding(2)
        Me.splitSide.Name = "splitSide"
        Me.splitSide.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'splitSide.Panel1
        '
        Me.splitSide.Panel1.Controls.Add(Me.CustomTreeView1)
        '
        'splitSide.Panel2
        '
        Me.splitSide.Panel2.Controls.Add(Me.chkVisible)
        Me.splitSide.Panel2.Controls.Add(Me.btnProgram)
        Me.splitSide.Panel2.Controls.Add(Me.btnPath)
        Me.splitSide.Panel2.Controls.Add(Me.txtHeight)
        Me.splitSide.Panel2.Controls.Add(Me.txtY)
        Me.splitSide.Panel2.Controls.Add(Me.txtWidth)
        Me.splitSide.Panel2.Controls.Add(Me.txtX)
        Me.splitSide.Panel2.Controls.Add(Me.txtProgram)
        Me.splitSide.Panel2.Controls.Add(Me.txtPath)
        Me.splitSide.Panel2.Controls.Add(Me.txtColor)
        Me.splitSide.Panel2.Controls.Add(Me.txttColor)
        Me.splitSide.Panel2.Controls.Add(Me.txtText)
        Me.splitSide.Panel2.Controls.Add(Me.lblHeight)
        Me.splitSide.Panel2.Controls.Add(Me.lblY)
        Me.splitSide.Panel2.Controls.Add(Me.lblWidth)
        Me.splitSide.Panel2.Controls.Add(Me.lblVisible)
        Me.splitSide.Panel2.Controls.Add(Me.lblX)
        Me.splitSide.Panel2.Controls.Add(Me.lblColor)
        Me.splitSide.Panel2.Controls.Add(Me.lblProgram)
        Me.splitSide.Panel2.Controls.Add(Me.lbltColor)
        Me.splitSide.Panel2.Controls.Add(Me.lblPath)
        Me.splitSide.Panel2.Controls.Add(Me.lblText)
        Me.splitSide.Size = New System.Drawing.Size(263, 734)
        Me.splitSide.SplitterDistance = 532
        Me.splitSide.SplitterIncrement = 17
        Me.splitSide.SplitterWidth = 3
        Me.splitSide.TabIndex = 0
        '
        'tvItems
        '
        Me.tvItems.BackColor = System.Drawing.SystemColors.Highlight
        Me.tvItems.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.tvItems.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tvItems.ForeColor = System.Drawing.Color.White
        Me.tvItems.HideSelection = False
        Me.tvItems.ImageIndex = 0
        Me.tvItems.ImageList = Me.imglstTree
        Me.tvItems.LineColor = System.Drawing.Color.FromArgb(CType(CType(160, Byte), Integer), CType(CType(160, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.tvItems.Location = New System.Drawing.Point(727, 74)
        Me.tvItems.Name = "tvItems"
        Me.tvItems.SelectedImageIndex = 0
        Me.tvItems.ShowRootLines = False
        Me.tvItems.Size = New System.Drawing.Size(209, 445)
        Me.tvItems.TabIndex = 0
        Me.tvItems.TabStop = False
        '
        'imglstTree
        '
        Me.imglstTree.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit
        Me.imglstTree.ImageSize = New System.Drawing.Size(16, 16)
        Me.imglstTree.TransparentColor = System.Drawing.Color.Transparent
        '
        'chkVisible
        '
        Me.chkVisible.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.chkVisible.AutoSize = True
        Me.chkVisible.BackColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.chkVisible.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDarkDark
        Me.chkVisible.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.ActiveCaption
        Me.chkVisible.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkVisible.ForeColor = System.Drawing.Color.Black
        Me.chkVisible.Location = New System.Drawing.Point(226, 139)
        Me.chkVisible.Name = "chkVisible"
        Me.chkVisible.Size = New System.Drawing.Size(12, 11)
        Me.chkVisible.TabIndex = 6
        Me.chkVisible.UseVisualStyleBackColor = False
        '
        'btnProgram
        '
        Me.btnProgram.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnProgram.BackColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.btnProgram.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDarkDark
        Me.btnProgram.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnProgram.ForeColor = System.Drawing.Color.White
        Me.btnProgram.Location = New System.Drawing.Point(236, 164)
        Me.btnProgram.Name = "btnProgram"
        Me.btnProgram.Size = New System.Drawing.Size(21, 22)
        Me.btnProgram.TabIndex = 9
        Me.btnProgram.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.btnProgram.UseVisualStyleBackColor = False
        '
        'btnPath
        '
        Me.btnPath.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnPath.BackColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.btnPath.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDarkDark
        Me.btnPath.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPath.ForeColor = System.Drawing.Color.White
        Me.btnPath.Location = New System.Drawing.Point(236, 43)
        Me.btnPath.Name = "btnPath"
        Me.btnPath.Size = New System.Drawing.Size(21, 22)
        Me.btnPath.TabIndex = 2
        Me.btnPath.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.btnPath.UseVisualStyleBackColor = False
        '
        'txtHeight
        '
        Me.txtHeight.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtHeight.BackColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.txtHeight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtHeight.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHeight.ForeColor = System.Drawing.Color.White
        Me.txtHeight.Location = New System.Drawing.Point(203, 104)
        Me.txtHeight.MaxLength = 4
        Me.txtHeight.Name = "txtHeight"
        Me.txtHeight.Size = New System.Drawing.Size(30, 22)
        Me.txtHeight.TabIndex = 5
        Me.txtHeight.TabStop = False
        Me.txtHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtY
        '
        Me.txtY.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtY.BackColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.txtY.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtY.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtY.ForeColor = System.Drawing.Color.White
        Me.txtY.Location = New System.Drawing.Point(116, 134)
        Me.txtY.MaxLength = 4
        Me.txtY.Name = "txtY"
        Me.txtY.Size = New System.Drawing.Size(41, 22)
        Me.txtY.TabIndex = 7
        Me.txtY.TabStop = False
        Me.txtY.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtWidth
        '
        Me.txtWidth.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtWidth.BackColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.txtWidth.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtWidth.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtWidth.ForeColor = System.Drawing.Color.White
        Me.txtWidth.Location = New System.Drawing.Point(111, 104)
        Me.txtWidth.MaxLength = 4
        Me.txtWidth.Name = "txtWidth"
        Me.txtWidth.Size = New System.Drawing.Size(30, 22)
        Me.txtWidth.TabIndex = 4
        Me.txtWidth.TabStop = False
        Me.txtWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtX
        '
        Me.txtX.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtX.BackColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.txtX.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtX.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtX.ForeColor = System.Drawing.Color.White
        Me.txtX.Location = New System.Drawing.Point(46, 134)
        Me.txtX.MaxLength = 4
        Me.txtX.Name = "txtX"
        Me.txtX.Size = New System.Drawing.Size(41, 22)
        Me.txtX.TabIndex = 1
        Me.txtX.TabStop = False
        Me.txtX.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtProgram
        '
        Me.txtProgram.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtProgram.BackColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.txtProgram.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtProgram.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtProgram.ForeColor = System.Drawing.Color.White
        Me.txtProgram.Location = New System.Drawing.Point(67, 164)
        Me.txtProgram.Name = "txtProgram"
        Me.txtProgram.Size = New System.Drawing.Size(167, 22)
        Me.txtProgram.TabIndex = 8
        Me.txtProgram.TabStop = False
        '
        'txtPath
        '
        Me.txtPath.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtPath.BackColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.txtPath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPath.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPath.ForeColor = System.Drawing.Color.White
        Me.txtPath.Location = New System.Drawing.Point(41, 43)
        Me.txtPath.Name = "txtPath"
        Me.txtPath.Size = New System.Drawing.Size(193, 22)
        Me.txtPath.TabIndex = 1
        Me.txtPath.TabStop = False
        '
        'txtColor
        '
        Me.txtColor.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtColor.BackColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.txtColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtColor.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtColor.ForeColor = System.Drawing.Color.White
        Me.txtColor.Location = New System.Drawing.Point(191, 75)
        Me.txtColor.MaxLength = 6
        Me.txtColor.Name = "txtColor"
        Me.txtColor.Size = New System.Drawing.Size(60, 22)
        Me.txtColor.TabIndex = 3
        Me.txtColor.TabStop = False
        '
        'txttColor
        '
        Me.txttColor.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txttColor.BackColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.txttColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txttColor.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txttColor.ForeColor = System.Drawing.Color.White
        Me.txttColor.Location = New System.Drawing.Point(85, 75)
        Me.txttColor.MaxLength = 6
        Me.txttColor.Name = "txttColor"
        Me.txttColor.Size = New System.Drawing.Size(60, 22)
        Me.txttColor.TabIndex = 2
        Me.txttColor.TabStop = False
        '
        'txtText
        '
        Me.txtText.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtText.BackColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.txtText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtText.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtText.ForeColor = System.Drawing.Color.White
        Me.txtText.Location = New System.Drawing.Point(41, 13)
        Me.txtText.Name = "txtText"
        Me.txtText.Size = New System.Drawing.Size(216, 22)
        Me.txtText.TabIndex = 0
        Me.txtText.TabStop = False
        '
        'lblHeight
        '
        Me.lblHeight.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblHeight.AutoSize = True
        Me.lblHeight.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHeight.ForeColor = System.Drawing.Color.White
        Me.lblHeight.Location = New System.Drawing.Point(147, 104)
        Me.lblHeight.Name = "lblHeight"
        Me.lblHeight.Size = New System.Drawing.Size(50, 18)
        Me.lblHeight.TabIndex = 0
        Me.lblHeight.Text = "Height"
        '
        'lblY
        '
        Me.lblY.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblY.AutoSize = True
        Me.lblY.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblY.ForeColor = System.Drawing.Color.White
        Me.lblY.Location = New System.Drawing.Point(93, 136)
        Me.lblY.Name = "lblY"
        Me.lblY.Size = New System.Drawing.Size(17, 16)
        Me.lblY.TabIndex = 0
        Me.lblY.Text = "Y"
        '
        'lblWidth
        '
        Me.lblWidth.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblWidth.AutoSize = True
        Me.lblWidth.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWidth.ForeColor = System.Drawing.Color.White
        Me.lblWidth.Location = New System.Drawing.Point(59, 104)
        Me.lblWidth.Name = "lblWidth"
        Me.lblWidth.Size = New System.Drawing.Size(46, 18)
        Me.lblWidth.TabIndex = 0
        Me.lblWidth.Text = "Width"
        '
        'lblVisible
        '
        Me.lblVisible.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblVisible.AutoSize = True
        Me.lblVisible.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVisible.ForeColor = System.Drawing.Color.White
        Me.lblVisible.Location = New System.Drawing.Point(175, 136)
        Me.lblVisible.Name = "lblVisible"
        Me.lblVisible.Size = New System.Drawing.Size(49, 16)
        Me.lblVisible.TabIndex = 0
        Me.lblVisible.Text = "Visible"
        '
        'lblX
        '
        Me.lblX.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblX.AutoSize = True
        Me.lblX.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblX.ForeColor = System.Drawing.Color.White
        Me.lblX.Location = New System.Drawing.Point(26, 134)
        Me.lblX.Name = "lblX"
        Me.lblX.Size = New System.Drawing.Size(18, 18)
        Me.lblX.TabIndex = 0
        Me.lblX.Text = "X"
        '
        'lblColor
        '
        Me.lblColor.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblColor.AutoSize = True
        Me.lblColor.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblColor.ForeColor = System.Drawing.Color.White
        Me.lblColor.Location = New System.Drawing.Point(147, 75)
        Me.lblColor.Name = "lblColor"
        Me.lblColor.Size = New System.Drawing.Size(45, 18)
        Me.lblColor.TabIndex = 0
        Me.lblColor.Text = "Color"
        '
        'lblProgram
        '
        Me.lblProgram.AutoSize = True
        Me.lblProgram.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProgram.ForeColor = System.Drawing.Color.White
        Me.lblProgram.Location = New System.Drawing.Point(2, 164)
        Me.lblProgram.Name = "lblProgram"
        Me.lblProgram.Size = New System.Drawing.Size(66, 18)
        Me.lblProgram.TabIndex = 0
        Me.lblProgram.Text = "Program"
        '
        'lbltColor
        '
        Me.lbltColor.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lbltColor.AutoSize = True
        Me.lbltColor.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbltColor.ForeColor = System.Drawing.Color.White
        Me.lbltColor.Location = New System.Drawing.Point(8, 75)
        Me.lbltColor.Name = "lbltColor"
        Me.lbltColor.Size = New System.Drawing.Size(77, 18)
        Me.lbltColor.TabIndex = 0
        Me.lbltColor.Text = "Text Color"
        '
        'lblPath
        '
        Me.lblPath.AutoSize = True
        Me.lblPath.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPath.ForeColor = System.Drawing.Color.White
        Me.lblPath.Location = New System.Drawing.Point(2, 43)
        Me.lblPath.Name = "lblPath"
        Me.lblPath.Size = New System.Drawing.Size(38, 18)
        Me.lblPath.TabIndex = 0
        Me.lblPath.Text = "Path"
        '
        'lblText
        '
        Me.lblText.AutoSize = True
        Me.lblText.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblText.ForeColor = System.Drawing.Color.White
        Me.lblText.Location = New System.Drawing.Point(2, 13)
        Me.lblText.Name = "lblText"
        Me.lblText.Size = New System.Drawing.Size(36, 18)
        Me.lblText.TabIndex = 0
        Me.lblText.Text = "Text"
        '
        'tsMain
        '
        Me.tsMain.BackgroundImage = Global.Enid.My.Resources.Resources.background
        Me.tsMain.CanOverflow = False
        Me.tsMain.Dock = System.Windows.Forms.DockStyle.None
        Me.tsMain.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.tsMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tbtnLock, Me.tsSep1, Me.tbtnAdd, Me.tbtnSave, Me.tsSep2, Me.tbtnSettings})
        Me.tsMain.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow
        Me.tsMain.Location = New System.Drawing.Point(0, 3)
        Me.tsMain.Name = "tsMain"
        Me.tsMain.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.tsMain.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.tsMain.Size = New System.Drawing.Size(24, 106)
        Me.tsMain.TabIndex = 1
        '
        'tbtnLock
        '
        Me.tbtnLock.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tbtnLock.Image = Global.Enid.My.Resources.Resources.lock_open
        Me.tbtnLock.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tbtnLock.Name = "tbtnLock"
        Me.tbtnLock.Size = New System.Drawing.Size(22, 20)
        Me.tbtnLock.Text = "Lock/Unlock"
        '
        'tsSep1
        '
        Me.tsSep1.Name = "tsSep1"
        Me.tsSep1.Size = New System.Drawing.Size(22, 6)
        '
        'tbtnAdd
        '
        Me.tbtnAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tbtnAdd.Image = Global.Enid.My.Resources.Resources.add
        Me.tbtnAdd.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tbtnAdd.Name = "tbtnAdd"
        Me.tbtnAdd.Size = New System.Drawing.Size(22, 20)
        Me.tbtnAdd.Text = "Import"
        '
        'tbtnSave
        '
        Me.tbtnSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tbtnSave.Image = Global.Enid.My.Resources.Resources.project_disk
        Me.tbtnSave.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tbtnSave.Name = "tbtnSave"
        Me.tbtnSave.Size = New System.Drawing.Size(22, 20)
        Me.tbtnSave.Text = "Save Project"
        '
        'tsSep2
        '
        Me.tsSep2.Name = "tsSep2"
        Me.tsSep2.Size = New System.Drawing.Size(22, 6)
        '
        'tbtnSettings
        '
        Me.tbtnSettings.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tbtnSettings.Image = Global.Enid.My.Resources.Resources.cog
        Me.tbtnSettings.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tbtnSettings.Name = "tbtnSettings"
        Me.tbtnSettings.Size = New System.Drawing.Size(22, 20)
        Me.tbtnSettings.Text = "Settings"
        '
        'openDialog
        '
        Me.openDialog.Title = "Choose file - Enid"
        '
        'colorDialog
        '
        Me.colorDialog.AnyColor = True
        Me.colorDialog.Color = System.Drawing.Color.White
        Me.colorDialog.FullOpen = True
        '
        'csTreeNodes
        '
        Me.csTreeNodes.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.csTreeNodesRemove})
        Me.csTreeNodes.Name = "csTreeNodes"
        Me.csTreeNodes.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.csTreeNodes.Size = New System.Drawing.Size(118, 26)
        '
        'csTreeNodesRemove
        '
        Me.csTreeNodesRemove.Name = "csTreeNodesRemove"
        Me.csTreeNodesRemove.Size = New System.Drawing.Size(117, 22)
        Me.csTreeNodesRemove.Text = "Remove"
        '
        'tbMain
        '
        Me.tbMain.Controls.Add(Me.tpStart)
        Me.tbMain.Cursor = System.Windows.Forms.Cursors.Default
        Me.tbMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tbMain.ItemSize = New System.Drawing.Size(0, 15)
        Me.tbMain.Location = New System.Drawing.Point(0, 0)
        Me.tbMain.Name = "tbMain"
        Me.tbMain.Padding = New System.Drawing.Point(9, 0)
        Me.tbMain.SelectedIndex = 0
        Me.tbMain.Size = New System.Drawing.Size(1090, 732)
        Me.tbMain.TabIndex = 0
        Me.tbMain.TabStop = False
        Me.tbMain.Tag = ""
        '
        'tpStart
        '
        Me.tpStart.BackColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.tpStart.Controls.Add(Me.tvItems)
        Me.tpStart.Controls.Add(Me.lnkLocatePlugins)
        Me.tpStart.Controls.Add(Me.lvProjects)
        Me.tpStart.Controls.Add(Me.lvPlugins)
        Me.tpStart.Controls.Add(Me.lblPlugins)
        Me.tpStart.Controls.Add(Me.lblcurProj)
        Me.tpStart.Controls.Add(Me.lblHelp)
        Me.tpStart.Controls.Add(Me.lnkOpenProject)
        Me.tpStart.Controls.Add(Me.lnkNewProject)
        Me.tpStart.Controls.Add(Me.lblRecentProj)
        Me.tpStart.Controls.Add(Me.ShapeContainer1)
        Me.tpStart.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tpStart.Location = New System.Drawing.Point(4, 19)
        Me.tpStart.Name = "tpStart"
        Me.tpStart.Padding = New System.Windows.Forms.Padding(3)
        Me.tpStart.Size = New System.Drawing.Size(1082, 709)
        Me.tpStart.TabIndex = 0
        Me.tpStart.Tag = "start"
        Me.tpStart.Text = "  Enid"
        Me.tpStart.UseVisualStyleBackColor = True
        '
        'lnkLocatePlugins
        '
        Me.lnkLocatePlugins.ActiveLinkColor = System.Drawing.SystemColors.Highlight
        Me.lnkLocatePlugins.AutoSize = True
        Me.lnkLocatePlugins.BackColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.lnkLocatePlugins.Enabled = False
        Me.lnkLocatePlugins.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lnkLocatePlugins.ForeColor = System.Drawing.Color.White
        Me.lnkLocatePlugins.Image = Global.Enid.My.Resources.Resources.plugin_go
        Me.lnkLocatePlugins.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.lnkLocatePlugins.LinkArea = New System.Windows.Forms.LinkArea(4, 18)
        Me.lnkLocatePlugins.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline
        Me.lnkLocatePlugins.LinkColor = System.Drawing.Color.White
        Me.lnkLocatePlugins.Location = New System.Drawing.Point(68, 448)
        Me.lnkLocatePlugins.Name = "lnkLocatePlugins"
        Me.lnkLocatePlugins.Size = New System.Drawing.Size(131, 24)
        Me.lnkLocatePlugins.TabIndex = 0
        Me.lnkLocatePlugins.TabStop = True
        Me.lnkLocatePlugins.Text = "    Locate Plugins"
        Me.lnkLocatePlugins.UseCompatibleTextRendering = True
        Me.lnkLocatePlugins.VisitedLinkColor = System.Drawing.Color.White
        '
        'lvProjects
        '
        Me.lvProjects.AutoArrange = False
        Me.lvProjects.BackColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.lvProjects.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lvProjects.ContextMenuStrip = Me.csRecent
        Me.lvProjects.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvProjects.ForeColor = System.Drawing.Color.White
        Me.lvProjects.LargeImageList = Me.imglstProject
        Me.lvProjects.Location = New System.Drawing.Point(17, 36)
        Me.lvProjects.Name = "lvProjects"
        Me.lvProjects.Scrollable = False
        Me.lvProjects.Size = New System.Drawing.Size(232, 201)
        Me.lvProjects.SmallImageList = Me.imglstProject
        Me.lvProjects.TabIndex = 4
        Me.lvProjects.TileSize = New System.Drawing.Size(230, 20)
        Me.lvProjects.UseCompatibleStateImageBehavior = False
        Me.lvProjects.View = System.Windows.Forms.View.SmallIcon
        '
        'lvPlugins
        '
        Me.lvPlugins.BackColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.lvPlugins.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lvPlugins.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvPlugins.ForeColor = System.Drawing.Color.White
        Me.lvPlugins.Location = New System.Drawing.Point(17, 328)
        Me.lvPlugins.Name = "lvPlugins"
        Me.lvPlugins.Size = New System.Drawing.Size(232, 123)
        Me.lvPlugins.SmallImageList = Me.imglstPlugins
        Me.lvPlugins.TabIndex = 4
        Me.lvPlugins.TileSize = New System.Drawing.Size(230, 20)
        Me.lvPlugins.UseCompatibleStateImageBehavior = False
        Me.lvPlugins.View = System.Windows.Forms.View.Tile
        '
        'lblPlugins
        '
        Me.lblPlugins.AutoSize = True
        Me.lblPlugins.BackColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.lblPlugins.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPlugins.ForeColor = System.Drawing.SystemColors.ControlDark
        Me.lblPlugins.Location = New System.Drawing.Point(18, 293)
        Me.lblPlugins.Name = "lblPlugins"
        Me.lblPlugins.Size = New System.Drawing.Size(231, 24)
        Me.lblPlugins.TabIndex = 3
        Me.lblPlugins.Text = "Plugins - Coming Soon!"
        Me.lblPlugins.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblcurProj
        '
        Me.lblcurProj.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblcurProj.AutoSize = True
        Me.lblcurProj.BackColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.lblcurProj.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblcurProj.ForeColor = System.Drawing.Color.White
        Me.lblcurProj.Location = New System.Drawing.Point(574, 11)
        Me.lblcurProj.Name = "lblcurProj"
        Me.lblcurProj.Size = New System.Drawing.Size(150, 24)
        Me.lblcurProj.TabIndex = 3
        Me.lblcurProj.Text = "Current Project"
        Me.lblcurProj.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblHelp
        '
        Me.lblHelp.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblHelp.AutoSize = True
        Me.lblHelp.BackColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.lblHelp.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHelp.ForeColor = System.Drawing.Color.White
        Me.lblHelp.Location = New System.Drawing.Point(106, 495)
        Me.lblHelp.Name = "lblHelp"
        Me.lblHelp.Size = New System.Drawing.Size(54, 24)
        Me.lblHelp.TabIndex = 3
        Me.lblHelp.Text = "Help"
        Me.lblHelp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lnkOpenProject
        '
        Me.lnkOpenProject.ActiveLinkColor = System.Drawing.SystemColors.Highlight
        Me.lnkOpenProject.AutoSize = True
        Me.lnkOpenProject.BackColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.lnkOpenProject.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lnkOpenProject.ForeColor = System.Drawing.Color.White
        Me.lnkOpenProject.Image = Global.Enid.My.Resources.Resources.project_go
        Me.lnkOpenProject.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.lnkOpenProject.LinkArea = New System.Windows.Forms.LinkArea(4, 16)
        Me.lnkOpenProject.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline
        Me.lnkOpenProject.LinkColor = System.Drawing.Color.White
        Me.lnkOpenProject.Location = New System.Drawing.Point(132, 240)
        Me.lnkOpenProject.Name = "lnkOpenProject"
        Me.lnkOpenProject.Size = New System.Drawing.Size(119, 24)
        Me.lnkOpenProject.TabIndex = 0
        Me.lnkOpenProject.TabStop = True
        Me.lnkOpenProject.Text = "    Open Project"
        Me.lnkOpenProject.UseCompatibleTextRendering = True
        Me.lnkOpenProject.VisitedLinkColor = System.Drawing.Color.White
        '
        'lnkNewProject
        '
        Me.lnkNewProject.ActiveLinkColor = System.Drawing.SystemColors.Highlight
        Me.lnkNewProject.AutoSize = True
        Me.lnkNewProject.BackColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.lnkNewProject.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lnkNewProject.ForeColor = System.Drawing.Color.White
        Me.lnkNewProject.Image = Global.Enid.My.Resources.Resources.report_add
        Me.lnkNewProject.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.lnkNewProject.LinkArea = New System.Windows.Forms.LinkArea(4, 15)
        Me.lnkNewProject.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline
        Me.lnkNewProject.LinkColor = System.Drawing.Color.White
        Me.lnkNewProject.Location = New System.Drawing.Point(17, 240)
        Me.lnkNewProject.Name = "lnkNewProject"
        Me.lnkNewProject.Size = New System.Drawing.Size(112, 24)
        Me.lnkNewProject.TabIndex = 0
        Me.lnkNewProject.TabStop = True
        Me.lnkNewProject.Text = "    New Project"
        Me.lnkNewProject.UseCompatibleTextRendering = True
        Me.lnkNewProject.VisitedLinkColor = System.Drawing.Color.White
        '
        'lblRecentProj
        '
        Me.lblRecentProj.AutoSize = True
        Me.lblRecentProj.BackColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.lblRecentProj.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRecentProj.ForeColor = System.Drawing.Color.White
        Me.lblRecentProj.Location = New System.Drawing.Point(55, 9)
        Me.lblRecentProj.Name = "lblRecentProj"
        Me.lblRecentProj.Size = New System.Drawing.Size(157, 24)
        Me.lblRecentProj.TabIndex = 2
        Me.lblRecentProj.Text = "Recent Projects"
        Me.lblRecentProj.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ShapeContainer1
        '
        Me.ShapeContainer1.Location = New System.Drawing.Point(3, 3)
        Me.ShapeContainer1.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer1.Name = "ShapeContainer1"
        Me.ShapeContainer1.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.rectPlugins, Me.rectHelp, Me.rectcurProjects, Me.rectProjects})
        Me.ShapeContainer1.Size = New System.Drawing.Size(1076, 703)
        Me.ShapeContainer1.TabIndex = 0
        Me.ShapeContainer1.TabStop = False
        '
        'CustomTreeView1
        '
        Me.CustomTreeView1.BackColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.CustomTreeView1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.CustomTreeView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CustomTreeView1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.CustomTreeView1.ForeColor = System.Drawing.Color.White
        Me.CustomTreeView1.HideSelection = False
        Me.CustomTreeView1.ImageIndex = 0
        Me.CustomTreeView1.ImageList = Me.imglstTree
        Me.CustomTreeView1.LineColor = System.Drawing.Color.FromArgb(CType(CType(160, Byte), Integer), CType(CType(160, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.CustomTreeView1.Location = New System.Drawing.Point(0, 0)
        Me.CustomTreeView1.Name = "CustomTreeView1"
        Me.CustomTreeView1.SelectedImageIndex = 0
        Me.CustomTreeView1.ShowRootLines = False
        Me.CustomTreeView1.Size = New System.Drawing.Size(261, 530)
        Me.CustomTreeView1.TabIndex = 0
        Me.CustomTreeView1.TabStop = False
        Me.CustomTreeView1.VScrollbar = Nothing
        '
        'frmMain
        '
        Me.AllowDrop = True
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.ClientSize = New System.Drawing.Size(1384, 736)
        Me.Controls.Add(Me.tsContainer)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MinimumSize = New System.Drawing.Size(400, 768)
        Me.Name = "frmMain"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Enid"
        Me.csButtons.ResumeLayout(False)
        Me.tsContainer.ContentPanel.ResumeLayout(False)
        Me.tsContainer.LeftToolStripPanel.ResumeLayout(False)
        Me.tsContainer.LeftToolStripPanel.PerformLayout()
        Me.tsContainer.ResumeLayout(False)
        Me.tsContainer.PerformLayout()
        Me.splitMain.Panel1.ResumeLayout(False)
        Me.splitMain.Panel2.ResumeLayout(False)
        Me.splitMain.ResumeLayout(False)
        Me.csRecent.ResumeLayout(False)
        Me.splitSide.Panel1.ResumeLayout(False)
        Me.splitSide.Panel2.ResumeLayout(False)
        Me.splitSide.Panel2.PerformLayout()
        Me.splitSide.ResumeLayout(False)
        Me.tsMain.ResumeLayout(False)
        Me.tsMain.PerformLayout()
        Me.csTreeNodes.ResumeLayout(False)
        Me.tbMain.ResumeLayout(False)
        Me.tpStart.ResumeLayout(False)
        Me.tpStart.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tsMain As System.Windows.Forms.ToolStrip
    Friend WithEvents csButtons As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents tbtnLock As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsSep1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tbtnSave As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsSep2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tbtnSettings As System.Windows.Forms.ToolStripButton
    Friend WithEvents tbtnAdd As System.Windows.Forms.ToolStripButton
    Friend WithEvents csButtonsRename As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents csButtonsRemove As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsContainer As System.Windows.Forms.ToolStripContainer
    Friend WithEvents splitMain As System.Windows.Forms.SplitContainer
    Friend WithEvents splitSide As System.Windows.Forms.SplitContainer
    Friend WithEvents csButtonsHide As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents txtText As System.Windows.Forms.TextBox
    Friend WithEvents lblText As System.Windows.Forms.Label
    Friend WithEvents txtPath As System.Windows.Forms.TextBox
    Friend WithEvents lblPath As System.Windows.Forms.Label
    Friend WithEvents btnPath As System.Windows.Forms.Button
    Friend WithEvents openDialog As System.Windows.Forms.OpenFileDialog
    Friend WithEvents lblX As System.Windows.Forms.Label
    Friend WithEvents txtY As System.Windows.Forms.TextBox
    Friend WithEvents txtX As System.Windows.Forms.TextBox
    Friend WithEvents lblY As System.Windows.Forms.Label
    Friend WithEvents txtHeight As System.Windows.Forms.TextBox
    Friend WithEvents txtWidth As System.Windows.Forms.TextBox
    Friend WithEvents lblHeight As System.Windows.Forms.Label
    Friend WithEvents lblWidth As System.Windows.Forms.Label
    Friend WithEvents txtColor As System.Windows.Forms.TextBox
    Friend WithEvents txttColor As System.Windows.Forms.TextBox
    Friend WithEvents lblColor As System.Windows.Forms.Label
    Friend WithEvents lbltColor As System.Windows.Forms.Label
    Friend WithEvents colorDialog As System.Windows.Forms.ColorDialog
    Friend WithEvents lblVisible As System.Windows.Forms.Label
    Friend WithEvents tvItems As System.Windows.Forms.TreeView
    Friend WithEvents imglstTree As System.Windows.Forms.ImageList
    Friend WithEvents ttColorMsg As System.Windows.Forms.ToolTip
    Friend WithEvents btnProgram As System.Windows.Forms.Button
    Friend WithEvents txtProgram As System.Windows.Forms.TextBox
    Friend WithEvents lblProgram As System.Windows.Forms.Label
    Friend WithEvents csTreeNodes As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents csTreeNodesRemove As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tbMain As Enid.customTabControl
    Friend WithEvents tpStart As System.Windows.Forms.TabPage
    Friend WithEvents ShapeContainer1 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
    Friend WithEvents rectProjects As Microsoft.VisualBasic.PowerPacks.RectangleShape
    Friend WithEvents lblRecentProj As System.Windows.Forms.Label
    Friend WithEvents lnkNewProject As System.Windows.Forms.LinkLabel
    Friend WithEvents lnkOpenProject As System.Windows.Forms.LinkLabel
    Friend WithEvents rectcurProjects As Microsoft.VisualBasic.PowerPacks.RectangleShape
    Friend WithEvents chkVisible As System.Windows.Forms.CheckBox
    Friend WithEvents lblHelp As System.Windows.Forms.Label
    Friend WithEvents rectHelp As Microsoft.VisualBasic.PowerPacks.RectangleShape
    Friend WithEvents lblcurProj As System.Windows.Forms.Label
    Friend WithEvents rectPlugins As Microsoft.VisualBasic.PowerPacks.RectangleShape
    Friend WithEvents lblPlugins As System.Windows.Forms.Label
    Friend WithEvents lvPlugins As System.Windows.Forms.ListView
    Friend WithEvents lvProjects As System.Windows.Forms.ListView
    Friend WithEvents imglstProject As System.Windows.Forms.ImageList
    Friend WithEvents imglstPlugins As System.Windows.Forms.ImageList
    Friend WithEvents lnkLocatePlugins As System.Windows.Forms.LinkLabel
    Friend WithEvents csRecent As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents csRecentClear As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CustomTreeView1 As Enid.customTreeView

End Class
