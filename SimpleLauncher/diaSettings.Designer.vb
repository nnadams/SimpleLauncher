﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class diaSettings
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
        Me.btnOk = New System.Windows.Forms.Button
        Me.lblProgram = New System.Windows.Forms.Label
        Me.btnOpen = New System.Windows.Forms.Button
        Me.openDialog = New System.Windows.Forms.OpenFileDialog
        Me.gbAuto = New System.Windows.Forms.GroupBox
        Me.numRows = New System.Windows.Forms.NumericUpDown
        Me.lblRows = New System.Windows.Forms.Label
        Me.numCols = New System.Windows.Forms.NumericUpDown
        Me.lblColumns = New System.Windows.Forms.Label
        Me.chkEnAuto = New System.Windows.Forms.CheckBox
        Me.gbAuto.SuspendLayout()
        CType(Me.numRows, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numCols, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnOk
        '
        Me.btnOk.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnOk.Location = New System.Drawing.Point(117, 167)
        Me.btnOk.Margin = New System.Windows.Forms.Padding(4)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(89, 28)
        Me.btnOk.TabIndex = 0
        Me.btnOk.Text = "OK"
        '
        'lblProgram
        '
        Me.lblProgram.AutoSize = True
        Me.lblProgram.Location = New System.Drawing.Point(79, 134)
        Me.lblProgram.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblProgram.Name = "lblProgram"
        Me.lblProgram.Size = New System.Drawing.Size(66, 17)
        Me.lblProgram.TabIndex = 5
        Me.lblProgram.Text = "Program:"
        '
        'btnOpen
        '
        Me.btnOpen.Location = New System.Drawing.Point(149, 128)
        Me.btnOpen.Margin = New System.Windows.Forms.Padding(4)
        Me.btnOpen.Name = "btnOpen"
        Me.btnOpen.Size = New System.Drawing.Size(96, 28)
        Me.btnOpen.TabIndex = 0
        Me.btnOpen.Text = "..."
        Me.btnOpen.UseVisualStyleBackColor = True
        '
        'openDialog
        '
        Me.openDialog.Title = "Choose a Program - Enid"
        '
        'gbAuto
        '
        Me.gbAuto.Controls.Add(Me.numRows)
        Me.gbAuto.Controls.Add(Me.lblRows)
        Me.gbAuto.Controls.Add(Me.numCols)
        Me.gbAuto.Controls.Add(Me.lblColumns)
        Me.gbAuto.Location = New System.Drawing.Point(16, 32)
        Me.gbAuto.Margin = New System.Windows.Forms.Padding(4)
        Me.gbAuto.Name = "gbAuto"
        Me.gbAuto.Padding = New System.Windows.Forms.Padding(4)
        Me.gbAuto.Size = New System.Drawing.Size(296, 89)
        Me.gbAuto.TabIndex = 7
        Me.gbAuto.TabStop = False
        Me.gbAuto.Text = "Automatic Import Settings"
        '
        'numRows
        '
        Me.numRows.Location = New System.Drawing.Point(137, 52)
        Me.numRows.Margin = New System.Windows.Forms.Padding(4)
        Me.numRows.Maximum = New Decimal(New Integer() {10, 0, 0, 0})
        Me.numRows.Minimum = New Decimal(New Integer() {2, 0, 0, 0})
        Me.numRows.Name = "numRows"
        Me.numRows.Size = New System.Drawing.Size(96, 22)
        Me.numRows.TabIndex = 1
        Me.numRows.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.numRows.Value = New Decimal(New Integer() {10, 0, 0, 0})
        '
        'lblRows
        '
        Me.lblRows.AutoSize = True
        Me.lblRows.Location = New System.Drawing.Point(63, 54)
        Me.lblRows.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblRows.Name = "lblRows"
        Me.lblRows.Size = New System.Drawing.Size(46, 17)
        Me.lblRows.TabIndex = 7
        Me.lblRows.Text = "Rows:"
        '
        'numCols
        '
        Me.numCols.Location = New System.Drawing.Point(137, 23)
        Me.numCols.Margin = New System.Windows.Forms.Padding(4)
        Me.numCols.Maximum = New Decimal(New Integer() {10, 0, 0, 0})
        Me.numCols.Minimum = New Decimal(New Integer() {2, 0, 0, 0})
        Me.numCols.Name = "numCols"
        Me.numCols.Size = New System.Drawing.Size(96, 22)
        Me.numCols.TabIndex = 0
        Me.numCols.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.numCols.Value = New Decimal(New Integer() {5, 0, 0, 0})
        '
        'lblColumns
        '
        Me.lblColumns.AutoSize = True
        Me.lblColumns.Location = New System.Drawing.Point(63, 26)
        Me.lblColumns.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblColumns.Name = "lblColumns"
        Me.lblColumns.Size = New System.Drawing.Size(66, 17)
        Me.lblColumns.TabIndex = 5
        Me.lblColumns.Text = "Columns:"
        '
        'chkEnAuto
        '
        Me.chkEnAuto.AutoSize = True
        Me.chkEnAuto.Checked = True
        Me.chkEnAuto.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkEnAuto.Location = New System.Drawing.Point(16, 4)
        Me.chkEnAuto.Margin = New System.Windows.Forms.Padding(4)
        Me.chkEnAuto.Name = "chkEnAuto"
        Me.chkEnAuto.Size = New System.Drawing.Size(202, 21)
        Me.chkEnAuto.TabIndex = 9
        Me.chkEnAuto.Text = "Enable Automatic Importing"
        Me.chkEnAuto.UseVisualStyleBackColor = True
        '
        'diaSettings
        '
        Me.AcceptButton = Me.btnOk
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(323, 204)
        Me.Controls.Add(Me.btnOk)
        Me.Controls.Add(Me.chkEnAuto)
        Me.Controls.Add(Me.gbAuto)
        Me.Controls.Add(Me.btnOpen)
        Me.Controls.Add(Me.lblProgram)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "diaSettings"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Settings"
        Me.TopMost = True
        Me.gbAuto.ResumeLayout(False)
        Me.gbAuto.PerformLayout()
        CType(Me.numRows, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numCols, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnOk As System.Windows.Forms.Button
    Friend WithEvents lblProgram As System.Windows.Forms.Label
    Friend WithEvents btnOpen As System.Windows.Forms.Button
    Public WithEvents openDialog As System.Windows.Forms.OpenFileDialog
    Friend WithEvents gbAuto As System.Windows.Forms.GroupBox
    Friend WithEvents chkEnAuto As System.Windows.Forms.CheckBox
    Public WithEvents numRows As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblRows As System.Windows.Forms.Label
    Public WithEvents numCols As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblColumns As System.Windows.Forms.Label

End Class
