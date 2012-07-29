Imports System.Drawing.Drawing2D
Imports System.Runtime.InteropServices
Imports System.Security.Permissions

Public Class customTabControl
    Inherits TabControl
#Region "Declarations"
    Public Event TabsReordered As EventHandler

    Private WithEvents nativeScroller As NativeScroller
    Private WithEvents newScroller As New TabScroller

    Private Const WM_SETFONT As Int32 = &H30
    Private Const WM_FONTCHANGE As Int32 = &H1D
    Private Const WM_HSCROLL As Int32 = &H114
    Private Const WM_Create As Int32 = &H1
    Private Const WM_PARENTNOTIFY As Int32 = &H210

    Private movingTab As TabPage = Nothing

    <DllImport("user32.dll")> Private Shared Function SendMessage(ByVal hWnd As IntPtr, ByVal Msg As Integer, ByVal wParam As IntPtr, ByVal lParam As IntPtr) As IntPtr
    End Function

    <DllImport("user32.dll")> Private Shared Function SetParent(ByVal hWndChild As IntPtr, ByVal hWndNewParent As IntPtr) As IntPtr
    End Function

    <DllImport("user32.dll", CallingConvention:=CallingConvention.Cdecl)> Private Shared Function RealGetWindowClass(ByVal hwnd As IntPtr, ByVal pszType As System.Text.StringBuilder, ByVal cchType As Integer) As Integer
    End Function

    <DllImport("user32.dll")> Private Shared Function LockWindowUpdate(ByVal hWndLock As IntPtr) As Boolean
    End Function

    Private Function PointToTab(ByVal x As Integer, ByVal y As Integer) As TabPage
        For i As Integer = 0 To MyBase.TabPages.Count - 1
            Dim tmpRect As Rectangle = MyBase.GetTabRect(i)
            tmpRect.Inflate(-2, 0)
            If tmpRect.Contains(x, y) Then
                Return MyBase.TabPages(i)
            End If
        Next
        Return Nothing
    End Function
#End Region
#Region "Paint"
    Private Function GetPath(ByVal index As Integer) As System.Drawing.Drawing2D.GraphicsPath
        Dim path As New System.Drawing.Drawing2D.GraphicsPath()
        Dim rect As Rectangle = Me.GetTabRect(index)
        path.Reset()

        path.AddLine(rect.Left + 1, rect.Bottom + 1, rect.Left + rect.Height - 1, rect.Top + 2)
        path.AddLine(rect.Left + rect.Height + 7, rect.Top, rect.Right + 2, rect.Top)
        path.AddLine(rect.Right + 5, rect.Top + 2, rect.Right + 5, rect.Bottom + 1)
        Return path
    End Function

    Private Sub paintBackground(ByVal g As Graphics, ByVal clientRect As Rectangle)
        If Me.Parent IsNot Nothing Then
            clientRect.Offset(Me.Location)
            Dim e As PaintEventArgs = New PaintEventArgs(g, clientRect)
            Dim state As GraphicsState = g.Save
            g.SmoothingMode = SmoothingMode.HighSpeed

            Try
                g.TranslateTransform(CType(-Me.Location.X, Single), CType(-Me.Location.Y, Single))
                Me.InvokePaintBackground(Me.Parent, e)
                Me.InvokePaint(Me.Parent, e)
            Finally
                g.Restore(state)
                clientRect.Offset(-Me.Location.X, -Me.Location.Y)
            End Try
        Else
            Dim backBrush As New System.Drawing.Drawing2D.LinearGradientBrush(Me.Bounds, SystemColors.ControlLightLight, SystemColors.ControlLight, Drawing2D.LinearGradientMode.Vertical)
            g.FillRectangle(backBrush, Me.Bounds)
            backBrush.Dispose()
        End If
    End Sub

    Private Sub paintTab(ByVal e As System.Windows.Forms.PaintEventArgs, ByVal index As Integer)
        If index >= Me.TabPages.Count Then Exit Sub
        Dim path As System.Drawing.Drawing2D.GraphicsPath = Me.GetPath(index)
        paintTabBackground(e.Graphics, index, path)
        paintTabBorder(e.Graphics, index, path)
        paintTabText(e.Graphics, index)
    End Sub

    Private Sub paintTabBackground(ByVal graph As System.Drawing.Graphics, ByVal index As Integer, ByVal path As System.Drawing.Drawing2D.GraphicsPath)
        Dim rect As Rectangle = Me.GetTabRect(index)

        If rect.Height > 1 AndAlso rect.Width > 1 Then
            rect.Inflate(5, 2)
            Dim backBrush As System.Drawing.Brush = New LinearGradientBrush(rect, SystemColors.InactiveCaption, SystemColors.InactiveCaptionText, LinearGradientMode.Vertical)

            If index = Me.SelectedIndex Then
                backBrush = New LinearGradientBrush(rect, SystemColors.Window, SystemColors.GradientInactiveCaption, LinearGradientMode.Vertical)
            End If

            graph.FillPath(backBrush, path)
            backBrush.Dispose()
        End If
    End Sub

    Private Sub paintTabBorder(ByVal graph As System.Drawing.Graphics, ByVal index As Integer, ByVal path As System.Drawing.Drawing2D.GraphicsPath)
        Dim borderPen As New Pen(SystemColors.ControlDarkDark)
        If index = Me.SelectedIndex Then
            borderPen = New Pen(SystemColors.InactiveCaptionText)
        End If

        graph.DrawPath(borderPen, path)
        borderPen.Dispose()
    End Sub

    Private Sub paintTabText(ByVal graph As System.Drawing.Graphics, ByVal index As Integer)
        Dim rect As Rectangle = Me.GetTabRect(index)
        Dim rect2 = New Rectangle(rect.Left + rect.Height - 1, rect.Top + 1, rect.Width - rect.Height + 5, rect.Height)
        Dim strTab As String = Me.TabPages(index).Text
        Dim foreBrush As Brush = Brushes.White

        Dim format As New System.Drawing.StringFormat()
        format.Alignment = StringAlignment.Near
        format.LineAlignment = StringAlignment.Center
        format.Trimming = StringTrimming.EllipsisCharacter

        Dim tabFont As New Font("Microsoft Sans Serif", 7.5, Me.Font.Style, Me.Font.Unit)
        If index = Me.SelectedIndex Then
            foreBrush = Brushes.Black
            tabFont = New Font(tabFont, FontStyle.Bold)
        End If

        graph.DrawString(strTab, tabFont, foreBrush, rect2, format)
    End Sub
#End Region
#Region "Events"
    Protected Overrides Sub OnMouseDown(ByVal e As System.Windows.Forms.MouseEventArgs)
        If (e.Button = Windows.Forms.MouseButtons.Left) AndAlso _
        (Me.SelectedTab IsNot Nothing) AndAlso (Not Me.GetTabRect(Me.SelectedIndex).IsEmpty) Then
            movingTab = Me.SelectedTab
        End If

        MyBase.OnMouseDown(e)
    End Sub

    Protected Overrides Sub OnMouseMove(ByVal e As MouseEventArgs)
        If (e.Button = Windows.Forms.MouseButtons.Left) AndAlso (movingTab IsNot Nothing) Then
            Dim mouseTab As System.Windows.Forms.TabPage = PointToTab(e.X, e.Y)
            If (mouseTab IsNot Nothing) AndAlso (mouseTab IsNot movingTab) Then
                If Me.TabPages.IndexOf(mouseTab) < Me.TabPages.IndexOf(movingTab) Then
                    LockWindowUpdate(Me.FindForm().Handle)
                    Me.TabPages.Remove(movingTab)
                    Me.TabPages.Insert(Me.TabPages.IndexOf(mouseTab), movingTab)
                    Me.SelectedTab = movingTab
                    LockWindowUpdate(0)

                    RaiseEvent TabsReordered(Me, EventArgs.Empty)
                ElseIf (Me.TabPages.IndexOf(mouseTab) > Me.TabPages.IndexOf(movingTab)) Then
                    LockWindowUpdate(Me.FindForm().Handle)
                    Me.TabPages.Remove(movingTab)
                    Me.TabPages.Insert(Me.TabPages.IndexOf(mouseTab) + 1, movingTab)
                    Me.SelectedTab = movingTab
                    LockWindowUpdate(0)

                    RaiseEvent TabsReordered(Me, EventArgs.Empty)
                Else
                    Me.Cursor = Cursors.Default
                End If
            End If
        Else
            Me.Cursor = Cursors.Default
        End If
        MyBase.OnMouseMove(e)
    End Sub

    Protected Overrides Sub OnMouseUp(ByVal e As MouseEventArgs)
        movingTab = Nothing

        MyBase.OnMouseUp(e)
    End Sub

    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
        If Me.TabCount > 0 Then
            For index As Integer = 0 To Me.TabCount - 1
                If index = Me.SelectedIndex Then Continue For
                paintTab(e, index)
            Next
            paintTab(e, Me.SelectedIndex)
        End If
    End Sub

    Protected Overrides Sub OnPaintBackground(ByVal pevent As System.Windows.Forms.PaintEventArgs)
        paintBackground(pevent.Graphics, Me.ClientRectangle)
    End Sub

    Protected Overrides Sub OnSelected(ByVal e As System.Windows.Forms.TabControlEventArgs)
        Me.Refresh()
    End Sub

    Protected Overrides Sub OnResize(ByVal e As System.EventArgs)
        MyBase.OnResize(e)
        Invalidate(True)
        If Me.Multiline Then Exit Sub

        If Me.Alignment = TabAlignment.Top Then
            newScroller.Location = New Point(Me.Width - newScroller.Width - 4, 1)
        Else
            newScroller.Location = New Point(Me.Width - newScroller.Width, Me.Height - newScroller.Height - 2)
        End If
    End Sub

    Protected Overrides Sub OnHandleCreated(ByVal e As System.EventArgs)
        MyBase.OnHandleCreated(e)

        If Me.Multiline Then Exit Sub

        newScroller.Font = New Font("Marlett", 6.25, FontStyle.Regular, GraphicsUnit.Pixel, Me.Font.GdiCharSet)
        SetParent(newScroller.Handle, Me.Handle)
        Me.OnFontChanged(EventArgs.Empty)
    End Sub

    Protected Overloads Overrides Sub OnCreateControl()
        MyBase.OnCreateControl()
        Me.OnFontChanged(EventArgs.Empty)
    End Sub

    Protected Overloads Overrides Sub OnFontChanged(ByVal e As EventArgs)
        MyBase.OnFontChanged(e)
        Dim hFont As IntPtr = Me.Font.ToHfont()
        SendMessage(Me.Handle, WM_SETFONT, hFont, CType((-1), IntPtr))
        SendMessage(Me.Handle, WM_FONTCHANGE, IntPtr.Zero, IntPtr.Zero)
        Me.UpdateStyles()
        Me.ItemSize = New Size(0, Me.Font.Height + 2)

        newScroller.Font = New Font("Marlett", 6.25, FontStyle.Regular, GraphicsUnit.Point)
        newScroller.Height = Me.ItemSize.Height
        newScroller.Width = Me.ItemSize.Height * 2

        Me.OnResize(EventArgs.Empty)
    End Sub

    <PermissionSetAttribute(SecurityAction.Demand, Name:="FullTrust")> _
    Protected Overrides Sub WndProc(ByRef m As System.Windows.Forms.Message)
        If m.Msg = WM_PARENTNOTIFY Then
            If (m.WParam.ToInt32() And &HFFFF) = WM_Create Then
                Dim WindowName As New System.Text.StringBuilder(16)
                RealGetWindowClass(m.LParam, WindowName, 16)
                If WindowName.ToString = "msctls_updown32" Then
                    If Not nativeScroller Is Nothing Then
                        nativeScroller.ReleaseHandle()
                    End If
                    nativeScroller = New NativeScroller
                    nativeScroller.AssignHandle(m.LParam)
                End If
            End If
        End If

        MyBase.WndProc(m)
    End Sub
#End Region
#Region "Scroller"
    Private ReadOnly Property ScrollPosition() As Int32
        Get
            Dim multiplier As Int32 = -1
            Dim tabRect As Rectangle
            Do
                tabRect = GetTabRect(multiplier + 1)
                multiplier += 1
            Loop While tabRect.Left < 0 AndAlso multiplier < Me.TabCount
            Return multiplier
        End Get
    End Property

    Private Sub Scroller_ScrollLeft(ByVal sender As Object, ByVal e As System.EventArgs) Handles newScroller.ScrollLeft
        If Me.TabCount = 0 Then Exit Sub
        Dim scrollPos As Int32 = Math.Max(0, (ScrollPosition - 1) * &H10000)

        LockWindowUpdate(Me.Handle)
        SendMessage(Me.Handle, WM_HSCROLL, IntPtr.op_Explicit(scrollPos Or &H4), IntPtr.Zero)
        SendMessage(Me.Handle, WM_HSCROLL, IntPtr.op_Explicit(scrollPos Or &H8), IntPtr.Zero)

        Me.CreateGraphics().Clear(SystemColors.InactiveCaptionText)
        OnPaint(New PaintEventArgs(Me.CreateGraphics(), Me.ClientRectangle))
        newScroller.Refresh()

        LockWindowUpdate(0)
    End Sub

    Private Sub Scroller_ScrollRight(ByVal sender As Object, ByVal e As System.EventArgs) Handles newScroller.ScrollRight
        If Me.TabCount = 0 Then Exit Sub
        If GetTabRect(Me.TabCount - 1).Right <= newScroller.Left Then Return
        Dim scrollPos As Int32 = Math.Max(0, (ScrollPosition + 1) * &H10000)

        LockWindowUpdate(Me.Handle)
        SendMessage(Me.Handle, WM_HSCROLL, IntPtr.op_Explicit(scrollPos Or &H4), IntPtr.Zero)
        SendMessage(Me.Handle, WM_HSCROLL, IntPtr.op_Explicit(scrollPos Or &H8), IntPtr.Zero)

        Me.CreateGraphics().Clear(SystemColors.InactiveCaptionText)
        OnPaint(New PaintEventArgs(Me.CreateGraphics(), Me.ClientRectangle))
        newScroller.Refresh()

        LockWindowUpdate(0)
    End Sub
#End Region
#Region "Constructer"
    Public Sub New()
        MyBase.New()

        Me.SetStyle(ControlStyles.UserPaint, True)
        Me.ItemSize = New Size(0, 15)
        Me.Padding = New Point(9, 0)
        Me.SetStyle(ControlStyles.SupportsTransparentBackColor, True)
        Me.SetStyle(ControlStyles.OptimizedDoubleBuffer, True)
        Me.SetStyle(ControlStyles.ResizeRedraw, True)
        Me.ResizeRedraw = True
    End Sub
#End Region
End Class