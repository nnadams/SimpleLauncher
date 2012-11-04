<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class diaAdd
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(diaAdd))
        Me.layoutPanel = New System.Windows.Forms.TableLayoutPanel
        Me.btnCancel = New System.Windows.Forms.Button
        Me.btnImport = New System.Windows.Forms.Button
        Me.pbarImport = New System.Windows.Forms.ProgressBar
        Me.lvMain = New System.Windows.Forms.ListView
        Me.chText = New System.Windows.Forms.ColumnHeader
        Me.chPath = New System.Windows.Forms.ColumnHeader
        Me.openDialog = New System.Windows.Forms.OpenFileDialog
        Me.numRows = New System.Windows.Forms.NumericUpDown
        Me.numCols = New System.Windows.Forms.NumericUpDown
        Me.lblRows = New System.Windows.Forms.Label
        Me.lblColomns = New System.Windows.Forms.Label
        Me.gbGrid = New System.Windows.Forms.GroupBox
        Me.rbtnGrid = New System.Windows.Forms.RadioButton
        Me.rbtnManual = New System.Windows.Forms.RadioButton
        Me.btnSelectAll = New System.Windows.Forms.Button
        Me.btnSelectNone = New System.Windows.Forms.Button
        Me.lblCount = New System.Windows.Forms.Label
        Me.btnRemove = New System.Windows.Forms.Button
        Me.btnOpen = New System.Windows.Forms.Button
        Me.layoutPanel.SuspendLayout()
        CType(Me.numRows, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numCols, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbGrid.SuspendLayout()
        Me.SuspendLayout()
        '
        'layoutPanel
        '
        Me.layoutPanel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.layoutPanel.ColumnCount = 3
        Me.layoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 87.04762!))
        Me.layoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.95238!))
        Me.layoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 76.0!))
        Me.layoutPanel.Controls.Add(Me.btnCancel, 2, 0)
        Me.layoutPanel.Controls.Add(Me.btnImport, 1, 0)
        Me.layoutPanel.Controls.Add(Me.pbarImport, 0, 0)
        Me.layoutPanel.Location = New System.Drawing.Point(6, 457)
        Me.layoutPanel.Name = "layoutPanel"
        Me.layoutPanel.RowCount = 1
        Me.layoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.layoutPanel.Size = New System.Drawing.Size(621, 29)
        Me.layoutPanel.TabIndex = 0
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(552, 3)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(61, 23)
        Me.btnCancel.TabIndex = 1
        Me.btnCancel.Text = "Cancel"
        '
        'btnImport
        '
        Me.btnImport.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnImport.Location = New System.Drawing.Point(477, 3)
        Me.btnImport.Name = "btnImport"
        Me.btnImport.Size = New System.Drawing.Size(64, 23)
        Me.btnImport.TabIndex = 0
        Me.btnImport.Text = "Import"
        '
        'pbarImport
        '
        Me.pbarImport.Location = New System.Drawing.Point(3, 3)
        Me.pbarImport.Name = "pbarImport"
        Me.pbarImport.Size = New System.Drawing.Size(468, 23)
        Me.pbarImport.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.pbarImport.TabIndex = 2
        '
        'lvMain
        '
        Me.lvMain.AllowDrop = True
        Me.lvMain.CheckBoxes = True
        Me.lvMain.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.chText, Me.chPath})
        Me.lvMain.GridLines = True
        Me.lvMain.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.lvMain.LabelEdit = True
        Me.lvMain.Location = New System.Drawing.Point(6, 13)
        Me.lvMain.Name = "lvMain"
        Me.lvMain.ShowGroups = False
        Me.lvMain.Size = New System.Drawing.Size(618, 400)
        Me.lvMain.TabIndex = 1
        Me.lvMain.UseCompatibleStateImageBehavior = False
        Me.lvMain.View = System.Windows.Forms.View.Details
        '
        'chText
        '
        Me.chText.Text = "Display Text"
        Me.chText.Width = 142
        '
        'chPath
        '
        Me.chPath.Text = "File Path"
        Me.chPath.Width = 382
        '
        'openDialog
        '
        Me.openDialog.Multiselect = True
        Me.openDialog.Title = "Open File(s) - Enid"
        '
        'numRows
        '
        Me.numRows.Location = New System.Drawing.Point(146, 14)
        Me.numRows.Maximum = New Decimal(New Integer() {10, 0, 0, 0})
        Me.numRows.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.numRows.Name = "numRows"
        Me.numRows.Size = New System.Drawing.Size(41, 20)
        Me.numRows.TabIndex = 4
        Me.numRows.Value = New Decimal(New Integer() {10, 0, 0, 0})
        '
        'numCols
        '
        Me.numCols.Location = New System.Drawing.Point(63, 14)
        Me.numCols.Maximum = New Decimal(New Integer() {10, 0, 0, 0})
        Me.numCols.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.numCols.Name = "numCols"
        Me.numCols.Size = New System.Drawing.Size(41, 20)
        Me.numCols.TabIndex = 5
        Me.numCols.Value = New Decimal(New Integer() {10, 0, 0, 0})
        '
        'lblRows
        '
        Me.lblRows.AutoSize = True
        Me.lblRows.Location = New System.Drawing.Point(110, 16)
        Me.lblRows.Name = "lblRows"
        Me.lblRows.Size = New System.Drawing.Size(37, 13)
        Me.lblRows.TabIndex = 6
        Me.lblRows.Text = "Rows:"
        '
        'lblColomns
        '
        Me.lblColomns.AutoSize = True
        Me.lblColomns.Location = New System.Drawing.Point(7, 16)
        Me.lblColomns.Name = "lblColomns"
        Me.lblColomns.Size = New System.Drawing.Size(50, 13)
        Me.lblColomns.TabIndex = 7
        Me.lblColomns.Text = "Columns:"
        '
        'gbGrid
        '
        Me.gbGrid.Controls.Add(Me.lblColomns)
        Me.gbGrid.Controls.Add(Me.numRows)
        Me.gbGrid.Controls.Add(Me.numCols)
        Me.gbGrid.Controls.Add(Me.lblRows)
        Me.gbGrid.Location = New System.Drawing.Point(276, 415)
        Me.gbGrid.Name = "gbGrid"
        Me.gbGrid.Size = New System.Drawing.Size(201, 40)
        Me.gbGrid.TabIndex = 9
        Me.gbGrid.TabStop = False
        '
        'rbtnGrid
        '
        Me.rbtnGrid.AutoSize = True
        Me.rbtnGrid.Checked = True
        Me.rbtnGrid.Location = New System.Drawing.Point(206, 427)
        Me.rbtnGrid.Name = "rbtnGrid"
        Me.rbtnGrid.Size = New System.Drawing.Size(70, 17)
        Me.rbtnGrid.TabIndex = 10
        Me.rbtnGrid.TabStop = True
        Me.rbtnGrid.Text = "Grid Align"
        Me.rbtnGrid.UseVisualStyleBackColor = True
        '
        'rbtnManual
        '
        Me.rbtnManual.AutoSize = True
        Me.rbtnManual.Location = New System.Drawing.Point(485, 427)
        Me.rbtnManual.Name = "rbtnManual"
        Me.rbtnManual.Size = New System.Drawing.Size(86, 17)
        Me.rbtnManual.TabIndex = 11
        Me.rbtnManual.TabStop = True
        Me.rbtnManual.Text = "Manual Align"
        Me.rbtnManual.UseVisualStyleBackColor = True
        '
        'btnSelectAll
        '
        Me.btnSelectAll.Location = New System.Drawing.Point(61, 424)
        Me.btnSelectAll.Name = "btnSelectAll"
        Me.btnSelectAll.Size = New System.Drawing.Size(59, 23)
        Me.btnSelectAll.TabIndex = 12
        Me.btnSelectAll.Text = "Select All"
        Me.btnSelectAll.UseVisualStyleBackColor = True
        '
        'btnSelectNone
        '
        Me.btnSelectNone.Location = New System.Drawing.Point(126, 424)
        Me.btnSelectNone.Name = "btnSelectNone"
        Me.btnSelectNone.Size = New System.Drawing.Size(74, 23)
        Me.btnSelectNone.TabIndex = 12
        Me.btnSelectNone.Text = "Select None"
        Me.btnSelectNone.UseVisualStyleBackColor = True
        '
        'lblCount
        '
        Me.lblCount.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCount.Location = New System.Drawing.Point(566, 429)
        Me.lblCount.Name = "lblCount"
        Me.lblCount.Size = New System.Drawing.Size(60, 15)
        Me.lblCount.TabIndex = 13
        Me.lblCount.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'btnRemove
        '
        Me.btnRemove.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRemove.Image = Global.Enid.My.Resources.Resources.page_delete
        Me.btnRemove.Location = New System.Drawing.Point(31, 421)
        Me.btnRemove.Name = "btnRemove"
        Me.btnRemove.Size = New System.Drawing.Size(24, 28)
        Me.btnRemove.TabIndex = 8
        Me.btnRemove.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnRemove.UseVisualStyleBackColor = True
        '
        'btnOpen
        '
        Me.btnOpen.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOpen.Image = Global.Enid.My.Resources.Resources.page_add
        Me.btnOpen.Location = New System.Drawing.Point(6, 421)
        Me.btnOpen.Name = "btnOpen"
        Me.btnOpen.Size = New System.Drawing.Size(24, 28)
        Me.btnOpen.TabIndex = 8
        Me.btnOpen.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnOpen.UseVisualStyleBackColor = True
        '
        'diaAdd
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(638, 496)
        Me.Controls.Add(Me.lblCount)
        Me.Controls.Add(Me.btnSelectNone)
        Me.Controls.Add(Me.btnSelectAll)
        Me.Controls.Add(Me.rbtnManual)
        Me.Controls.Add(Me.rbtnGrid)
        Me.Controls.Add(Me.gbGrid)
        Me.Controls.Add(Me.btnRemove)
        Me.Controls.Add(Me.btnOpen)
        Me.Controls.Add(Me.lvMain)
        Me.Controls.Add(Me.layoutPanel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "diaAdd"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Import"
        Me.layoutPanel.ResumeLayout(False)
        CType(Me.numRows, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numCols, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbGrid.ResumeLayout(False)
        Me.gbGrid.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents layoutPanel As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btnImport As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents lvMain As System.Windows.Forms.ListView
    Friend WithEvents chText As System.Windows.Forms.ColumnHeader
    Friend WithEvents chPath As System.Windows.Forms.ColumnHeader
    Friend WithEvents openDialog As System.Windows.Forms.OpenFileDialog
    Friend WithEvents pbarImport As System.Windows.Forms.ProgressBar
    Friend WithEvents numRows As System.Windows.Forms.NumericUpDown
    Friend WithEvents numCols As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblRows As System.Windows.Forms.Label
    Friend WithEvents lblColomns As System.Windows.Forms.Label
    Friend WithEvents btnOpen As System.Windows.Forms.Button
    Friend WithEvents gbGrid As System.Windows.Forms.GroupBox
    Friend WithEvents rbtnGrid As System.Windows.Forms.RadioButton
    Friend WithEvents rbtnManual As System.Windows.Forms.RadioButton
    Friend WithEvents btnSelectAll As System.Windows.Forms.Button
    Friend WithEvents btnSelectNone As System.Windows.Forms.Button
    Friend WithEvents btnRemove As System.Windows.Forms.Button
    Friend WithEvents lblCount As System.Windows.Forms.Label

End Class
