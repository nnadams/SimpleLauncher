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
        Me.clbButtons = New System.Windows.Forms.CheckedListBox
        Me.tsMain = New System.Windows.Forms.ToolStrip
        Me.tbtnLock = New System.Windows.Forms.ToolStripButton
        Me.tsSep1 = New System.Windows.Forms.ToolStripSeparator
        Me.tbtnAdd = New System.Windows.Forms.ToolStripButton
        Me.tbtnSave = New System.Windows.Forms.ToolStripButton
        Me.tsSep2 = New System.Windows.Forms.ToolStripSeparator
        Me.tbtnSettings = New System.Windows.Forms.ToolStripButton
        Me.csButtons.SuspendLayout()
        Me.tsContainer.ContentPanel.SuspendLayout()
        Me.tsContainer.LeftToolStripPanel.SuspendLayout()
        Me.tsContainer.SuspendLayout()
        Me.splitMain.Panel2.SuspendLayout()
        Me.splitMain.SuspendLayout()
        Me.splitSide.Panel1.SuspendLayout()
        Me.splitSide.SuspendLayout()
        Me.tsMain.SuspendLayout()
        Me.SuspendLayout()
        '
        'csButtons
        '
        Me.csButtons.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.csItemHide, Me.csitemRename, Me.csitemRemove})
        Me.csButtons.Name = "csButtons"
        Me.csButtons.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.csButtons.Size = New System.Drawing.Size(133, 76)
        '
        'csItemHide
        '
        Me.csItemHide.Name = "csItemHide"
        Me.csItemHide.Size = New System.Drawing.Size(132, 24)
        Me.csItemHide.Text = "Hide"
        '
        'csitemRename
        '
        Me.csitemRename.Name = "csitemRename"
        Me.csitemRename.Size = New System.Drawing.Size(132, 24)
        Me.csitemRename.Text = "Rename"
        '
        'csitemRemove
        '
        Me.csitemRemove.Name = "csitemRemove"
        Me.csitemRemove.Size = New System.Drawing.Size(132, 24)
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
        Me.tsContainer.ContentPanel.Size = New System.Drawing.Size(1458, 723)
        '
        'tsContainer.LeftToolStripPanel
        '
        Me.tsContainer.LeftToolStripPanel.BackgroundImage = Global.Enid.My.Resources.Resources.background
        Me.tsContainer.LeftToolStripPanel.Controls.Add(Me.tsMain)
        Me.tsContainer.LeftToolStripPanel.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.tsContainer.Location = New System.Drawing.Point(0, 0)
        Me.tsContainer.Name = "tsContainer"
        '
        'tsContainer.RightToolStripPanel
        '
        Me.tsContainer.RightToolStripPanel.BackgroundImage = Global.Enid.My.Resources.Resources.background
        Me.tsContainer.RightToolStripPanelVisible = False
        Me.tsContainer.Size = New System.Drawing.Size(1482, 723)
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
        Me.splitMain.Location = New System.Drawing.Point(0, 3)
        Me.splitMain.Name = "splitMain"
        '
        'splitMain.Panel1
        '
        '
        'splitMain.Panel2
        '
        Me.splitMain.Panel2.BackColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.splitMain.Panel2.Controls.Add(Me.splitSide)
        Me.splitMain.Size = New System.Drawing.Size(1455, 717)
        Me.splitMain.SplitterDistance = 1235
        Me.splitMain.TabIndex = 0
        Me.splitMain.TabStop = False
        '
        'splitSide
        '
        Me.splitSide.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.splitSide.Dock = System.Windows.Forms.DockStyle.Fill
        Me.splitSide.IsSplitterFixed = True
        Me.splitSide.Location = New System.Drawing.Point(0, 0)
        Me.splitSide.Name = "splitSide"
        Me.splitSide.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'splitSide.Panel1
        '
        Me.splitSide.Panel1.Controls.Add(Me.clbButtons)
        Me.splitSide.Size = New System.Drawing.Size(216, 717)
        Me.splitSide.SplitterDistance = 395
        Me.splitSide.SplitterIncrement = 17
        Me.splitSide.TabIndex = 0
        '
        'clbButtons
        '
        Me.clbButtons.BackColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.clbButtons.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.clbButtons.Dock = System.Windows.Forms.DockStyle.Fill
        Me.clbButtons.ForeColor = System.Drawing.Color.White
        Me.clbButtons.Location = New System.Drawing.Point(0, 0)
        Me.clbButtons.Name = "clbButtons"
        Me.clbButtons.Size = New System.Drawing.Size(214, 391)
        Me.clbButtons.Sorted = True
        Me.clbButtons.TabIndex = 0
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
        'frmMain
        '
        Me.AllowDrop = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.ClientSize = New System.Drawing.Size(1482, 723)
        Me.Controls.Add(Me.tsContainer)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MinimumSize = New System.Drawing.Size(425, 350)
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
    Friend WithEvents clbButtons As System.Windows.Forms.CheckedListBox
    Friend WithEvents csItemHide As System.Windows.Forms.ToolStripMenuItem

End Class
