Public Class MagicControl : Inherits Control

    Private WithEvents myControl As Control
    Private isMouseDown As Boolean = False
    Private onEdge As EdgeEnum = EdgeEnum.None
    Private mWidth As Integer = 3
    Private outlineDrawn As Boolean = False
    Private beginX As Integer = 0
    Private beginY As Integer = 0

    Private Enum EdgeEnum
        None
        Right
        Left
        Top
        Bottom
        Inside
    End Enum

    Private Sub myControl_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles myControl.MouseMove
        Dim activeControl As Control = sender

        If frmMain.isLocked Then
            activeControl.Cursor = Cursors.Default
            onEdge = EdgeEnum.None
            Exit Sub
        End If

        Dim g As Graphics = activeControl.CreateGraphics()

        Select Case onEdge
            Case EdgeEnum.Inside
                If outlineDrawn Then activeControl.Refresh()
                outlineDrawn = True
            Case EdgeEnum.Left
                g.FillRectangle(Brushes.Fuchsia, 0, 0, mWidth, activeControl.Height)
                outlineDrawn = True
            Case EdgeEnum.Right
                g.FillRectangle(Brushes.Fuchsia, activeControl.Width - mWidth, 0, activeControl.Width, activeControl.Height)
                outlineDrawn = True
            Case EdgeEnum.Top
                g.FillRectangle(Brushes.Fuchsia, 0, 0, activeControl.Width, mWidth)
                outlineDrawn = True
            Case EdgeEnum.Bottom
                g.FillRectangle(Brushes.Fuchsia, 0, activeControl.Height - mWidth, activeControl.Width, mWidth)
                outlineDrawn = True
            Case EdgeEnum.None
                If outlineDrawn Then
                    activeControl.Refresh()
                    outlineDrawn = False
                End If
        End Select

        If isMouseDown And onEdge <> EdgeEnum.None Then
            activeControl.SuspendLayout()
            Select Case onEdge
                Case EdgeEnum.Left
                    activeControl.SetBounds(activeControl.Left + e.X, activeControl.Top, activeControl.Width - e.X, activeControl.Height)
                Case EdgeEnum.Right
                    activeControl.SetBounds(activeControl.Left, activeControl.Top, activeControl.Width - (activeControl.Width - e.X), activeControl.Height)
                Case EdgeEnum.Top
                    activeControl.SetBounds(activeControl.Left, activeControl.Top + e.Y, activeControl.Width, activeControl.Height - e.Y)
                Case EdgeEnum.Bottom
                    activeControl.SetBounds(activeControl.Left, activeControl.Top, activeControl.Width, activeControl.Height - (activeControl.Height - e.Y))
                Case EdgeEnum.Inside
                    activeControl.Location = New Point(activeControl.Left + e.X - beginX, activeControl.Top + e.Y - beginY)
            End Select
            activeControl.ResumeLayout()
        Else
            Select Case True
                Case e.X <= mWidth
                    activeControl.Cursor = Cursors.VSplit
                    onEdge = EdgeEnum.Left
                Case e.X > activeControl.Width - (mWidth + 1)
                    activeControl.Cursor = Cursors.VSplit
                    onEdge = EdgeEnum.Right
                Case e.Y <= mWidth
                    activeControl.Cursor = Cursors.HSplit
                    onEdge = EdgeEnum.Top
                Case e.Y > activeControl.Height - (mWidth + 1)
                    activeControl.Cursor = Cursors.HSplit
                    onEdge = EdgeEnum.Bottom
                Case e.X < (myControl.Location.X + myControl.Width - mWidth * 2) And e.Y < (myControl.Location.Y + myControl.Height - mWidth * 2)
                    activeControl.Cursor = Cursors.SizeAll
                    onEdge = EdgeEnum.Inside
                Case Else
                    activeControl.Cursor = Cursors.Default
                    onEdge = EdgeEnum.None
            End Select
        End If
    End Sub

    Private Sub myControl_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles myControl.MouseDown
        If frmMain.isLocked Then Exit Sub

        If e.Button = MouseButtons.Left Then
            beginX = e.X
            beginY = e.Y
            isMouseDown = True
        End If
    End Sub

    Private Sub myControl_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles myControl.MouseUp
        If frmMain.isLocked Then Exit Sub

        If e.Button = MouseButtons.Left Then
            isMouseDown = False
        End If
    End Sub

    Private Sub myControl_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles myControl.MouseLeave
        If frmMain.isLocked Then Exit Sub

        Dim activeControl As Control = sender
        activeControl.Refresh()
    End Sub

    Public Sub New(ByVal control As Control)
        myControl = control
    End Sub
End Class
