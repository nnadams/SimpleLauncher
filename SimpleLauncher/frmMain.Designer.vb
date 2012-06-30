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
        Me.csItemHide = New System.Windows.Forms.ToolStripMenuItem
        Me.csitemRename = New System.Windows.Forms.ToolStripMenuItem
        Me.csitemRemove = New System.Windows.Forms.ToolStripMenuItem
        Me.tsContainer = New System.Windows.Forms.ToolStripContainer
        Me.splitMain = New System.Windows.Forms.SplitContainer
        Me.splitSide = New System.Windows.Forms.SplitContainer
        Me.lvItems = New System.Windows.Forms.ListView
        Me.colHeader = New System.Windows.Forms.ColumnHeader
        Me.chkVisible = New System.Windows.Forms.CheckBox
        Me.btnPath = New System.Windows.Forms.Button
        Me.txtHeight = New System.Windows.Forms.TextBox
        Me.txtY = New System.Windows.Forms.TextBox
        Me.txtWidth = New System.Windows.Forms.TextBox
        Me.txtX = New System.Windows.Forms.TextBox
        Me.txtPath = New System.Windows.Forms.TextBox
        Me.txtColor = New System.Windows.Forms.TextBox
        Me.txttColor = New System.Windows.Forms.TextBox
        Me.txtText = New System.Windows.Forms.TextBox
        Me.lblHeight = New System.Windows.Forms.Label
        Me.lblY = New System.Windows.Forms.Label
        Me.lblWidth = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.lblX = New System.Windows.Forms.Label
        Me.lblColor = New System.Windows.Forms.Label
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
        Me.csButtons.SuspendLayout()
        Me.tsContainer.ContentPanel.SuspendLayout()
        Me.tsContainer.LeftToolStripPanel.SuspendLayout()
        Me.tsContainer.SuspendLayout()
        Me.splitMain.Panel2.SuspendLayout()
        Me.splitMain.SuspendLayout()
        Me.splitSide.Panel1.SuspendLayout()
        Me.splitSide.Panel2.SuspendLayout()
        Me.splitSide.SuspendLayout()
        Me.tsMain.SuspendLayout()
        Me.SuspendLayout()
        '
        'csButtons
        '
        Me.csButtons.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.csItemHide, Me.csitemRename, Me.csitemRemove})
        Me.csButtons.Name = "csButtons"
        Me.csButtons.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.csButtons.Size = New System.Drawing.Size(118, 70)
        '
        'csItemHide
        '
        Me.csItemHide.Name = "csItemHide"
        Me.csItemHide.Size = New System.Drawing.Size(117, 22)
        Me.csItemHide.Text = "Hide"
        '
        'csitemRename
        '
        Me.csitemRename.Name = "csitemRename"
        Me.csitemRename.Size = New System.Drawing.Size(117, 22)
        Me.csitemRename.Text = "Rename"
        '
        'csitemRemove
        '
        Me.csitemRemove.Name = "csitemRemove"
        Me.csitemRemove.Size = New System.Drawing.Size(117, 22)
        Me.csitemRemove.Text = "Remove"
        '
        'tsContainer
        '
        Me.tsContainer.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tsContainer.BottomToolStripPanelVisible = False
        '
        'tsContainer.ContentPanel
        '
        Me.tsContainer.ContentPanel.Controls.Add(Me.splitMain)
        Me.tsContainer.ContentPanel.Margin = New System.Windows.Forms.Padding(2)
        Me.tsContainer.ContentPanel.Size = New System.Drawing.Size(1326, 730)
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
        Me.tsContainer.Size = New System.Drawing.Size(1350, 730)
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
        Me.splitMain.Location = New System.Drawing.Point(0, 2)
        Me.splitMain.Margin = New System.Windows.Forms.Padding(2)
        Me.splitMain.Name = "splitMain"
        '
        'splitMain.Panel1
        '
        '
        'splitMain.Panel2
        '
        Me.splitMain.Panel2.BackColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.splitMain.Panel2.Controls.Add(Me.splitSide)
        Me.splitMain.Size = New System.Drawing.Size(1323, 726)
        Me.splitMain.SplitterDistance = 1121
        Me.splitMain.SplitterWidth = 3
        Me.splitMain.TabIndex = 0
        Me.splitMain.TabStop = False
        '
        'splitSide
        '
        Me.splitSide.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.splitSide.Dock = System.Windows.Forms.DockStyle.Fill
        Me.splitSide.FixedPanel = System.Windows.Forms.FixedPanel.Panel2
        Me.splitSide.Location = New System.Drawing.Point(0, 0)
        Me.splitSide.Margin = New System.Windows.Forms.Padding(2)
        Me.splitSide.Name = "splitSide"
        Me.splitSide.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'splitSide.Panel1
        '
        Me.splitSide.Panel1.Controls.Add(Me.lvItems)
        '
        'splitSide.Panel2
        '
        Me.splitSide.Panel2.Controls.Add(Me.chkVisible)
        Me.splitSide.Panel2.Controls.Add(Me.btnPath)
        Me.splitSide.Panel2.Controls.Add(Me.txtHeight)
        Me.splitSide.Panel2.Controls.Add(Me.txtY)
        Me.splitSide.Panel2.Controls.Add(Me.txtWidth)
        Me.splitSide.Panel2.Controls.Add(Me.txtX)
        Me.splitSide.Panel2.Controls.Add(Me.txtPath)
        Me.splitSide.Panel2.Controls.Add(Me.txtColor)
        Me.splitSide.Panel2.Controls.Add(Me.txttColor)
        Me.splitSide.Panel2.Controls.Add(Me.txtText)
        Me.splitSide.Panel2.Controls.Add(Me.lblHeight)
        Me.splitSide.Panel2.Controls.Add(Me.lblY)
        Me.splitSide.Panel2.Controls.Add(Me.lblWidth)
        Me.splitSide.Panel2.Controls.Add(Me.Label1)
        Me.splitSide.Panel2.Controls.Add(Me.lblX)
        Me.splitSide.Panel2.Controls.Add(Me.lblColor)
        Me.splitSide.Panel2.Controls.Add(Me.lbltColor)
        Me.splitSide.Panel2.Controls.Add(Me.lblPath)
        Me.splitSide.Panel2.Controls.Add(Me.lblText)
        Me.splitSide.Panel2.Enabled = False
        Me.splitSide.Size = New System.Drawing.Size(199, 726)
        Me.splitSide.SplitterDistance = 372
        Me.splitSide.SplitterIncrement = 17
        Me.splitSide.SplitterWidth = 3
        Me.splitSide.TabIndex = 0
        '
        'lvItems
        '
        Me.lvItems.BackColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.lvItems.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lvItems.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colHeader})
        Me.lvItems.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lvItems.ForeColor = System.Drawing.Color.White
        Me.lvItems.FullRowSelect = True
        Me.lvItems.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
        Me.lvItems.HideSelection = False
        Me.lvItems.Location = New System.Drawing.Point(0, 0)
        Me.lvItems.MultiSelect = False
        Me.lvItems.Name = "lvItems"
        Me.lvItems.ShowGroups = False
        Me.lvItems.Size = New System.Drawing.Size(197, 370)
        Me.lvItems.Sorting = System.Windows.Forms.SortOrder.Ascending
        Me.lvItems.TabIndex = 0
        Me.lvItems.UseCompatibleStateImageBehavior = False
        Me.lvItems.View = System.Windows.Forms.View.Details
        '
        'colHeader
        '
        Me.colHeader.Text = ""
        Me.colHeader.Width = 192
        '
        'chkVisible
        '
        Me.chkVisible.AutoSize = True
        Me.chkVisible.Checked = True
        Me.chkVisible.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkVisible.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDarkDark
        Me.chkVisible.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.ActiveCaption
        Me.chkVisible.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkVisible.ForeColor = System.Drawing.Color.Black
        Me.chkVisible.Location = New System.Drawing.Point(154, 113)
        Me.chkVisible.Name = "chkVisible"
        Me.chkVisible.Size = New System.Drawing.Size(12, 11)
        Me.chkVisible.TabIndex = 3
        Me.chkVisible.UseVisualStyleBackColor = True
        '
        'btnPath
        '
        Me.btnPath.BackColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.btnPath.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDarkDark
        Me.btnPath.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPath.ForeColor = System.Drawing.Color.White
        Me.btnPath.Location = New System.Drawing.Point(172, 30)
        Me.btnPath.Name = "btnPath"
        Me.btnPath.Size = New System.Drawing.Size(21, 20)
        Me.btnPath.TabIndex = 2
        Me.btnPath.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.btnPath.UseVisualStyleBackColor = False
        '
        'txtHeight
        '
        Me.txtHeight.BackColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.txtHeight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtHeight.ForeColor = System.Drawing.Color.White
        Me.txtHeight.Location = New System.Drawing.Point(130, 82)
        Me.txtHeight.MaxLength = 4
        Me.txtHeight.Name = "txtHeight"
        Me.txtHeight.Size = New System.Drawing.Size(30, 20)
        Me.txtHeight.TabIndex = 1
        Me.txtHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtY
        '
        Me.txtY.BackColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.txtY.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtY.ForeColor = System.Drawing.Color.White
        Me.txtY.Location = New System.Drawing.Point(79, 108)
        Me.txtY.MaxLength = 4
        Me.txtY.Name = "txtY"
        Me.txtY.Size = New System.Drawing.Size(30, 20)
        Me.txtY.TabIndex = 1
        Me.txtY.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtWidth
        '
        Me.txtWidth.BackColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.txtWidth.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtWidth.ForeColor = System.Drawing.Color.White
        Me.txtWidth.Location = New System.Drawing.Point(44, 82)
        Me.txtWidth.MaxLength = 4
        Me.txtWidth.Name = "txtWidth"
        Me.txtWidth.Size = New System.Drawing.Size(30, 20)
        Me.txtWidth.TabIndex = 1
        Me.txtWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtX
        '
        Me.txtX.BackColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.txtX.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtX.ForeColor = System.Drawing.Color.White
        Me.txtX.Location = New System.Drawing.Point(23, 108)
        Me.txtX.MaxLength = 4
        Me.txtX.Name = "txtX"
        Me.txtX.Size = New System.Drawing.Size(30, 20)
        Me.txtX.TabIndex = 1
        Me.txtX.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtPath
        '
        Me.txtPath.BackColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.txtPath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPath.ForeColor = System.Drawing.Color.White
        Me.txtPath.Location = New System.Drawing.Point(37, 30)
        Me.txtPath.Name = "txtPath"
        Me.txtPath.Size = New System.Drawing.Size(129, 20)
        Me.txtPath.TabIndex = 1
        '
        'txtColor
        '
        Me.txtColor.BackColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.txtColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtColor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtColor.ForeColor = System.Drawing.Color.White
        Me.txtColor.Location = New System.Drawing.Point(148, 56)
        Me.txtColor.MaxLength = 6
        Me.txtColor.Name = "txtColor"
        Me.txtColor.Size = New System.Drawing.Size(45, 20)
        Me.txtColor.TabIndex = 1
        '
        'txttColor
        '
        Me.txttColor.BackColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.txttColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txttColor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txttColor.ForeColor = System.Drawing.Color.White
        Me.txttColor.Location = New System.Drawing.Point(62, 56)
        Me.txttColor.MaxLength = 6
        Me.txttColor.Name = "txttColor"
        Me.txttColor.Size = New System.Drawing.Size(45, 20)
        Me.txttColor.TabIndex = 1
        '
        'txtText
        '
        Me.txtText.BackColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.txtText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtText.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtText.ForeColor = System.Drawing.Color.White
        Me.txtText.Location = New System.Drawing.Point(37, 3)
        Me.txtText.Name = "txtText"
        Me.txtText.Size = New System.Drawing.Size(156, 20)
        Me.txtText.TabIndex = 1
        '
        'lblHeight
        '
        Me.lblHeight.AutoSize = True
        Me.lblHeight.ForeColor = System.Drawing.Color.White
        Me.lblHeight.Location = New System.Drawing.Point(86, 86)
        Me.lblHeight.Name = "lblHeight"
        Me.lblHeight.Size = New System.Drawing.Size(38, 13)
        Me.lblHeight.TabIndex = 0
        Me.lblHeight.Text = "Height"
        '
        'lblY
        '
        Me.lblY.AutoSize = True
        Me.lblY.ForeColor = System.Drawing.Color.White
        Me.lblY.Location = New System.Drawing.Point(59, 112)
        Me.lblY.Name = "lblY"
        Me.lblY.Size = New System.Drawing.Size(14, 13)
        Me.lblY.TabIndex = 0
        Me.lblY.Text = "Y"
        '
        'lblWidth
        '
        Me.lblWidth.AutoSize = True
        Me.lblWidth.ForeColor = System.Drawing.Color.White
        Me.lblWidth.Location = New System.Drawing.Point(3, 86)
        Me.lblWidth.Name = "lblWidth"
        Me.lblWidth.Size = New System.Drawing.Size(35, 13)
        Me.lblWidth.TabIndex = 0
        Me.lblWidth.Text = "Width"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(115, 112)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(37, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Visible"
        '
        'lblX
        '
        Me.lblX.AutoSize = True
        Me.lblX.ForeColor = System.Drawing.Color.White
        Me.lblX.Location = New System.Drawing.Point(3, 112)
        Me.lblX.Name = "lblX"
        Me.lblX.Size = New System.Drawing.Size(14, 13)
        Me.lblX.TabIndex = 0
        Me.lblX.Text = "X"
        '
        'lblColor
        '
        Me.lblColor.AutoSize = True
        Me.lblColor.ForeColor = System.Drawing.Color.White
        Me.lblColor.Location = New System.Drawing.Point(111, 60)
        Me.lblColor.Name = "lblColor"
        Me.lblColor.Size = New System.Drawing.Size(31, 13)
        Me.lblColor.TabIndex = 0
        Me.lblColor.Text = "Color"
        '
        'lbltColor
        '
        Me.lbltColor.AutoSize = True
        Me.lbltColor.ForeColor = System.Drawing.Color.White
        Me.lbltColor.Location = New System.Drawing.Point(3, 60)
        Me.lbltColor.Name = "lbltColor"
        Me.lbltColor.Size = New System.Drawing.Size(55, 13)
        Me.lbltColor.TabIndex = 0
        Me.lbltColor.Text = "Text Color"
        '
        'lblPath
        '
        Me.lblPath.AutoSize = True
        Me.lblPath.ForeColor = System.Drawing.Color.White
        Me.lblPath.Location = New System.Drawing.Point(3, 34)
        Me.lblPath.Name = "lblPath"
        Me.lblPath.Size = New System.Drawing.Size(29, 13)
        Me.lblPath.TabIndex = 0
        Me.lblPath.Text = "Path"
        '
        'lblText
        '
        Me.lblText.AutoSize = True
        Me.lblText.ForeColor = System.Drawing.Color.White
        Me.lblText.Location = New System.Drawing.Point(3, 7)
        Me.lblText.Name = "lblText"
        Me.lblText.Size = New System.Drawing.Size(28, 13)
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
        Me.tbtnSave.Image = Global.Enid.My.Resources.Resources.disk
        Me.tbtnSave.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tbtnSave.Name = "tbtnSave"
        Me.tbtnSave.Size = New System.Drawing.Size(22, 20)
        Me.tbtnSave.Text = "Save"
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
        'frmMain
        '
        Me.AllowDrop = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.ClientSize = New System.Drawing.Size(1350, 730)
        Me.Controls.Add(Me.tsContainer)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MinimumSize = New System.Drawing.Size(350, 300)
        Me.Name = "frmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Enid"
        Me.csButtons.ResumeLayout(False)
        Me.tsContainer.ContentPanel.ResumeLayout(False)
        Me.tsContainer.LeftToolStripPanel.ResumeLayout(False)
        Me.tsContainer.LeftToolStripPanel.PerformLayout()
        Me.tsContainer.ResumeLayout(False)
        Me.tsContainer.PerformLayout()
        Me.splitMain.Panel2.ResumeLayout(False)
        Me.splitMain.ResumeLayout(False)
        Me.splitSide.Panel1.ResumeLayout(False)
        Me.splitSide.Panel2.ResumeLayout(False)
        Me.splitSide.Panel2.PerformLayout()
        Me.splitSide.ResumeLayout(False)
        Me.tsMain.ResumeLayout(False)
        Me.tsMain.PerformLayout()
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
    Friend WithEvents csitemRename As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents csitemRemove As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsContainer As System.Windows.Forms.ToolStripContainer
    Friend WithEvents splitMain As System.Windows.Forms.SplitContainer
    Friend WithEvents splitSide As System.Windows.Forms.SplitContainer
    Friend WithEvents csItemHide As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lvItems As System.Windows.Forms.ListView
    Friend WithEvents colHeader As System.Windows.Forms.ColumnHeader
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
    Friend WithEvents chkVisible As System.Windows.Forms.CheckBox
    Friend WithEvents Label1 As System.Windows.Forms.Label

End Class
