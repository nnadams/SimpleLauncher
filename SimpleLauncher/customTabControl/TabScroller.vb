Public Class TabScroller
    Inherits System.Windows.Forms.Control

#Region "Generated code"
    Public Sub New()
        MyBase.New()
        InitializeComponent()
    End Sub

    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    Private components As System.ComponentModel.IContainer

    Friend WithEvents leftScroller As System.Windows.Forms.Button
    Friend WithEvents rightScroller As System.Windows.Forms.Button

    Private Sub InitializeComponent()
        Me.leftScroller = New System.Windows.Forms.Button
        Me.rightScroller = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'leftScroller
        '
        Me.leftScroller.Dock = System.Windows.Forms.DockStyle.Right
        Me.leftScroller.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.leftScroller.Location = New System.Drawing.Point(0, 0)
        Me.leftScroller.Name = "leftScroller"
        Me.leftScroller.Size = New System.Drawing.Size(40, 40)
        Me.leftScroller.TextAlign = ContentAlignment.MiddleCenter
        Me.leftScroller.TabIndex = 0
        Me.leftScroller.Text = "3"
        Me.leftScroller.ForeColor = Color.White
        Me.leftScroller.BackColor = SystemColors.InactiveCaptionText
        '
        'rightScroller
        '
        Me.rightScroller.Dock = System.Windows.Forms.DockStyle.Right
        Me.rightScroller.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.rightScroller.Location = New System.Drawing.Point(40, 0)
        Me.rightScroller.Name = "rightScroller"
        Me.rightScroller.Size = New System.Drawing.Size(40, 40)
        Me.rightScroller.TextAlign = ContentAlignment.MiddleCenter
        Me.rightScroller.TabIndex = 1
        Me.rightScroller.Text = "4"
        Me.rightScroller.ForeColor = Color.White
        Me.rightScroller.BackColor = SystemColors.InactiveCaptionText
        '
        'TabScroller
        '
        Me.Controls.Add(Me.leftScroller)
        Me.Controls.Add(Me.rightScroller)
        Me.Font = New System.Drawing.Font("Marlett", 6.25, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.Name = "TabScroller"
        Me.Size = New System.Drawing.Size(80, 40)
        Me.BackColor = SystemColors.InactiveCaptionText
        Me.TabStop = False
        Me.ResumeLayout(False)
    End Sub
#End Region
    Public Event ScrollLeft As EventHandler
    Public Event ScrollRight As EventHandler

    Private Sub TabScroller_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Resize
        leftScroller.Width = Me.Width \ 2
        rightScroller.Width = Me.Width \ 2
    End Sub

    Private Sub LeftScroller_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles leftScroller.Click
        RaiseEvent ScrollLeft(Me, EventArgs.Empty)
    End Sub

    Private Sub RightScroller_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles rightScroller.Click
        RaiseEvent ScrollRight(Me, EventArgs.Empty)
    End Sub
End Class