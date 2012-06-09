Public Class MagicControl : Inherits Control

    Private WithEvents myControl As Control
    Private isMouseDown As Boolean = False
    Private mEdge As EdgeEnum = EdgeEnum.None
    Private mWidth As Integer = 3
    Private mOutlineDrawn As Boolean = False

    Private Enum EdgeEnum
        None
        Right
        Left
        Top
        Bottom
        TopLeft
    End Enum

    Private Sub myControl_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles myControl.MouseMove
        Dim activeControl As Control = sender

        If frmMain.isLocked Then
            activeControl.Cursor = Cursors.Default
            mEdge = EdgeEnum.None
            Exit Sub
        End If

        Dim g As Graphics = activeControl.CreateGraphics()

        Select Case mEdge
            Case EdgeEnum.TopLeft
                g.FillRectangle(Brushes.PeachPuff, 0, 0, mWidth * 4, mWidth * 4)
                mOutlineDrawn = True
            Case EdgeEnum.Left
                g.FillRectangle(Brushes.Fuchsia, 0, 0, mWidth, activeControl.Height)
                mOutlineDrawn = True
            Case EdgeEnum.Right
                g.FillRectangle(Brushes.Fuchsia, activeControl.Width - mWidth, 0, activeControl.Width, activeControl.Height)
                mOutlineDrawn = True
            Case EdgeEnum.Top
                g.FillRectangle(Brushes.Fuchsia, 0, 0, activeControl.Width, mWidth)
                mOutlineDrawn = True
            Case EdgeEnum.Bottom
                g.FillRectangle(Brushes.Fuchsia, 0, activeControl.Height - mWidth, activeControl.Width, mWidth)
                mOutlineDrawn = True
            Case EdgeEnum.None
                If mOutlineDrawn Then
                    activeControl.Refresh()
                    mOutlineDrawn = False
                End If
        End Select

        If isMouseDown And mEdge <> EdgeEnum.None Then
            activeControl.SuspendLayout()
            Select Case mEdge
                Case EdgeEnum.TopLeft
                    activeControl.SetBounds(activeControl.Left + e.X, activeControl.Top + e.Y, activeControl.Width, activeControl.Height)
                Case EdgeEnum.Left
                    activeControl.SetBounds(activeControl.Left + e.X, activeControl.Top, activeControl.Width - e.X, activeControl.Height)
                Case EdgeEnum.Right
                    activeControl.SetBounds(activeControl.Left, activeControl.Top, activeControl.Width - (activeControl.Width - e.X), activeControl.Height)
                Case EdgeEnum.Top
                    activeControl.SetBounds(activeControl.Left, activeControl.Top + e.Y, activeControl.Width, activeControl.Height - e.Y)
                Case EdgeEnum.Bottom
                    activeControl.SetBounds(activeControl.Left, activeControl.Top, activeControl.Width, activeControl.Height - (activeControl.Height - e.Y))
            End Select
            activeControl.ResumeLayout()
        Else
            Select Case True
                Case e.X <= (mWidth * 4) And e.Y <= (mWidth * 4) 'top left corner
                    activeControl.Cursor = Cursors.SizeAll
                    mEdge = EdgeEnum.TopLeft
                Case e.X <= mWidth 'left edge
                    activeControl.Cursor = Cursors.VSplit
                    mEdge = EdgeEnum.Left
                Case e.X > activeControl.Width - (mWidth + 1) 'right edge
                    activeControl.Cursor = Cursors.VSplit
                    mEdge = EdgeEnum.Right
                Case e.Y <= mWidth 'top edge
                    activeControl.Cursor = Cursors.HSplit
                    mEdge = EdgeEnum.Top
                Case e.Y > activeControl.Height - (mWidth + 1) 'bottom edge
                    activeControl.Cursor = Cursors.HSplit
                    mEdge = EdgeEnum.Bottom
                Case Else 'no edge
                    activeControl.Cursor = Cursors.Default
                    mEdge = EdgeEnum.None
            End Select
        End If
    End Sub

    Private Sub myControl_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles myControl.MouseDown
        If frmMain.isLocked Then Exit Sub

        If e.Button = MouseButtons.Left Then
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
