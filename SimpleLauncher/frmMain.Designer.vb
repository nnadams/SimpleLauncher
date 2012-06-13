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
        Me.csitemRename = New System.Windows.Forms.ToolStripMenuItem
        Me.csitemRemove = New System.Windows.Forms.ToolStripMenuItem
        Me.tsMain = New System.Windows.Forms.ToolStrip
        Me.tsSep1 = New System.Windows.Forms.ToolStripSeparator
        Me.tsSep3 = New System.Windows.Forms.ToolStripSeparator
        Me.tsSep2 = New System.Windows.Forms.ToolStripSeparator
        Me.tbtnLock = New System.Windows.Forms.ToolStripButton
        Me.tbtnAdd = New System.Windows.Forms.ToolStripButton
        Me.tbtnSave = New System.Windows.Forms.ToolStripButton
        Me.tbtnLight = New System.Windows.Forms.ToolStripButton
        Me.tbtnSettings = New System.Windows.Forms.ToolStripButton
        Me.csButtons.SuspendLayout()
        Me.tsMain.SuspendLayout()
        Me.SuspendLayout()
        '
        'csButtons
        '
        Me.csButtons.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.csitemRename, Me.csitemRemove})
        Me.csButtons.Name = "csButtons"
        Me.csButtons.ShowImageMargin = False
        Me.csButtons.Size = New System.Drawing.Size(93, 48)
        '
        'csitemRename
        '
        Me.csitemRename.Name = "csitemRename"
        Me.csitemRename.Size = New System.Drawing.Size(92, 22)
        Me.csitemRename.Text = "Rename"
        '
        'csitemRemove
        '
        Me.csitemRemove.Name = "csitemRemove"
        Me.csitemRemove.Size = New System.Drawing.Size(92, 22)
        Me.csitemRemove.Text = "Remove"
        '
        'tsMain
        '
        Me.tsMain.Dock = System.Windows.Forms.DockStyle.None
        Me.tsMain.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.tsMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tbtnLock, Me.tsSep1, Me.tbtnAdd, Me.tbtnSave, Me.tsSep3, Me.tbtnLight, Me.tsSep2, Me.tbtnSettings})
        Me.tsMain.Location = New System.Drawing.Point(0, 0)
        Me.tsMain.Name = "tsMain"
        Me.tsMain.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.tsMain.Size = New System.Drawing.Size(167, 25)
        Me.tsMain.TabIndex = 1
        '
        'tsSep1
        '
        Me.tsSep1.Name = "tsSep1"
        Me.tsSep1.Size = New System.Drawing.Size(6, 25)
        '
        'tsSep3
        '
        Me.tsSep3.Name = "tsSep3"
        Me.tsSep3.Size = New System.Drawing.Size(6, 25)
        '
        'tsSep2
        '
        Me.tsSep2.Name = "tsSep2"
        Me.tsSep2.Size = New System.Drawing.Size(6, 25)
        '
        'tbtnLock
        '
        Me.tbtnLock.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tbtnLock.Image = Global.Enid.My.Resources.Resources.lock_open
        Me.tbtnLock.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tbtnLock.Name = "tbtnLock"
        Me.tbtnLock.Size = New System.Drawing.Size(23, 22)
        Me.tbtnLock.Text = "Lock/Unlock"
        '
        'tbtnAdd
        '
        Me.tbtnAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tbtnAdd.Image = Global.Enid.My.Resources.Resources.add
        Me.tbtnAdd.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tbtnAdd.Name = "tbtnAdd"
        Me.tbtnAdd.Size = New System.Drawing.Size(23, 22)
        Me.tbtnAdd.Text = "Import"
        '
        'tbtnSave
        '
        Me.tbtnSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tbtnSave.Image = Global.Enid.My.Resources.Resources.disk
        Me.tbtnSave.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tbtnSave.Name = "tbtnSave"
        Me.tbtnSave.Size = New System.Drawing.Size(23, 22)
        Me.tbtnSave.Text = "Save"
        '
        'tbtnLight
        '
        Me.tbtnLight.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tbtnLight.Image = Global.Enid.My.Resources.Resources.lightbulb
        Me.tbtnLight.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tbtnLight.Name = "tbtnLight"
        Me.tbtnLight.Size = New System.Drawing.Size(23, 22)
        Me.tbtnLight.Text = "Toggle Lights"
        '
        'tbtnSettings
        '
        Me.tbtnSettings.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tbtnSettings.Image = Global.Enid.My.Resources.Resources.cog
        Me.tbtnSettings.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tbtnSettings.Name = "tbtnSettings"
        Me.tbtnSettings.Size = New System.Drawing.Size(23, 22)
        Me.tbtnSettings.Text = "Settings"
        '
        'frmMain
        '
        Me.AllowDrop = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(562, 502)
        Me.Controls.Add(Me.tsMain)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Enid"
        Me.csButtons.ResumeLayout(False)
        Me.tsMain.ResumeLayout(False)
        Me.tsMain.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

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
    Friend WithEvents tbtnLight As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsSep3 As System.Windows.Forms.ToolStripSeparator

End Class
