<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class diaList
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
        Me.lvChoosen = New System.Windows.Forms.ListView
        Me.chLabel = New System.Windows.Forms.ColumnHeader
        Me.SuspendLayout()
        '
        'lvChoosen
        '
        Me.lvChoosen.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.chLabel})
        Me.lvChoosen.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lvChoosen.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
        Me.lvChoosen.HideSelection = False
        Me.lvChoosen.Location = New System.Drawing.Point(0, 0)
        Me.lvChoosen.Name = "lvChoosen"
        Me.lvChoosen.Size = New System.Drawing.Size(215, 354)
        Me.lvChoosen.TabIndex = 0
        Me.lvChoosen.UseCompatibleStateImageBehavior = False
        Me.lvChoosen.View = System.Windows.Forms.View.Details
        '
        'chLabel
        '
        Me.chLabel.Text = "Label"
        Me.chLabel.Width = 209
        '
        'diaList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(215, 354)
        Me.Controls.Add(Me.lvChoosen)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "diaList"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Enid"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lvChoosen As System.Windows.Forms.ListView
    Friend WithEvents chLabel As System.Windows.Forms.ColumnHeader

End Class
