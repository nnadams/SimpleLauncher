Imports System.Security.Permissions
Imports System.Runtime.InteropServices

Public Class NativeScroller
    Inherits NativeWindow

    Private _bounds As Rectangle

    Private Const WM_DESTROY As Int32 = &H2
    Private Const WM_NCDESTROY As Int32 = &H82
    Private Const WM_WINDOWPOSCHANGING As Int32 = &H46

    Public Structure WINDOWPOS
        Implements IDisposable
        Public hwnd As IntPtr
        Public hwndInsertAfter As IntPtr
        Public x As Int32
        Public y As Int32
        Public cx As Int32
        Public cy As Int32
        Public flags As Int32

        Public Sub Dispose() Implements System.IDisposable.Dispose
            hwnd = Nothing
            hwndInsertAfter = Nothing
        End Sub
    End Structure

    <PermissionSetAttribute(SecurityAction.Demand, Name:="FullTrust")> _
    Protected Overrides Sub WndProc(ByRef msg As System.Windows.Forms.Message)

        If msg.Msg = WM_DESTROY OrElse msg.Msg = WM_NCDESTROY Then
            Me.ReleaseHandle()
        ElseIf msg.Msg = WM_WINDOWPOSCHANGING Then
            ' Push the scroller out of sight
            Dim winPos As WINDOWPOS = DirectCast(msg.GetLParam(GetType(WINDOWPOS)), WINDOWPOS)
            winPos.x += winPos.cx
            Marshal.StructureToPtr(winPos, msg.LParam, True)
            _bounds = New Rectangle(winPos.x, winPos.y, winPos.cx, winPos.cy)
        End If

        MyBase.WndProc(msg)
    End Sub

    Public ReadOnly Property Bounds() As Rectangle
        Get
            Return _bounds
        End Get
    End Property

    Public Sub New()
        MyBase.new()
    End Sub
End Class