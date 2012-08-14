Imports System.Collections.Generic
Imports System.Text
Imports System.Windows.Forms
Imports System.Runtime.InteropServices

Imports Enid.customScrollBar

Public Class customListView
    Inherits ListView

    <StructLayout(LayoutKind.Sequential)> _
    Private Structure ScrollInfo
        Public cbSize As UInteger
        Public fMask As UInteger
        Public nMin As Integer
        Public nMax As Integer
        Public nPage As UInteger
        Public nPos As Integer
        Public nTrackPos As Integer
    End Structure

    Private Enum ScrollBarDirection
        SB_HORZ = 0
        SB_VERT = 1
        SB_CTL = 2
        SB_BOTH = 3
    End Enum

    Private Enum ScrollInfoMask
        SIF_RANGE = &H1
        SIF_PAGE = &H2
        SIF_POS = &H4
        SIF_DISABLENOSCROLL = &H8
        SIF_TRACKPOS = &H10
        SIF_ALL = SIF_RANGE + SIF_PAGE + SIF_POS + SIF_TRACKPOS
    End Enum

    Private Enum SBTYPES
        SB_HORZ = 0
        SB_VERT = 1
        SB_CTL = 2
        SB_BOTH = 3
    End Enum

    Private Enum LPCSCROLLINFO
        SIF_RANGE = &H1
        SIF_PAGE = &H2
        SIF_POS = &H4
        SIF_DISABLENOSCROLL = &H8
        SIF_TRACKPOS = &H10
        SIF_ALL = (SIF_RANGE Or SIF_PAGE Or SIF_POS Or SIF_TRACKPOS)
    End Enum

    Public Enum ScrollBarCommands
        SB_LINEUP = 0
        SB_LINELEFT = 0
        SB_LINEDOWN = 1
        SB_LINERIGHT = 1
        SB_PAGEUP = 2
        SB_PAGELEFT = 2
        SB_PAGEDOWN = 3
        SB_PAGERIGHT = 3
        SB_THUMBPOSITION = 4
        SB_THUMBTRACK = 5
        SB_TOP = 6
        SB_LEFT = 6
        SB_BOTTOM = 7
        SB_RIGHT = 7
        SB_ENDSCROLL = 8
    End Enum

    Private Const WM_VSCROLL As UInt32 = &H115
    Private Const WM_NCCALCSIZE As UInt32 = &H83

    Private Const LVM_FIRST As UInt32 = &H1000
    Private Const LVM_INSERTITEMA As UInt32 = (LVM_FIRST + 7)
    Private Const LVM_INSERTITEMW As UInt32 = (LVM_FIRST + 77)
    Private Const LVM_DELETEITEM As UInt32 = (LVM_FIRST + 8)
    Private Const LVM_DELETEALLITEMS As UInt32 = (LVM_FIRST + 9)

    Private Const GWL_STYLE As Integer = -16
    Private Const WS_VSCROLL As Integer = &H200000

    <DllImport("user32.dll")> _
    Private Shared Function GetScrollInfo(ByVal hwnd As IntPtr, ByVal fnBar As Integer, ByRef lpsi As ScrollInfo) As <MarshalAs(UnmanagedType.Bool)> Boolean
    End Function

    <DllImport("user32.dll", EntryPoint:="GetWindowLong", CharSet:=CharSet.Auto)> _
Public Shared Function GetWindowLong32(ByVal hWnd As IntPtr, ByVal nIndex As Integer) As IntPtr
    End Function

    <DllImport("user32.dll", EntryPoint:="GetWindowLongPtr", CharSet:=CharSet.Auto)> _
    Public Shared Function GetWindowLongPtr64(ByVal hWnd As IntPtr, ByVal nIndex As Integer) As IntPtr
    End Function

    <DllImport("user32.dll", EntryPoint:="SetWindowLong", CharSet:=CharSet.Auto)> _
    Public Shared Function SetWindowLongPtr32(ByVal hWnd As IntPtr, ByVal nIndex As Integer, ByVal dwNewLong As Integer) As IntPtr
    End Function

    <DllImport("user32.dll", EntryPoint:="SetWindowLongPtr", CharSet:=CharSet.Auto)> _
    Public Shared Function SetWindowLongPtr64(ByVal hWnd As IntPtr, ByVal nIndex As Integer, ByVal dwNewLong As Integer) As IntPtr
    End Function

    Public Delegate Sub ScrollPositionChangedDelegate(ByVal listview As customListView, ByVal pos As Integer)

    Public Event ScrollPositionChanged As ScrollPositionChangedDelegate
    Public Event ItemAdded As Action(Of customListView)
    Public Event ItemsRemoved As Action(Of customListView)

    Private _disableChangeEvents As Integer = 0
    Private _vScrollbar As IcustomScrollBar = Nothing

    Private Sub BeginDisableChangeEvents()
        _disableChangeEvents += 1
    End Sub

    Private Sub EndDisableChangeEvents()
        If _disableChangeEvents > 0 Then
            _disableChangeEvents -= 1
        End If
    End Sub

    Public Property VScrollbar() As IcustomScrollBar
        Get
            Return _vScrollbar
        End Get
        Set(ByVal value As IcustomScrollBar)
            If value IsNot Nothing Then
                UpdateScrollbar()
                AddHandler value.ValueChanged, New ScrollValueChangedDelegate(AddressOf value_ValueChanged)
            End If

            _vScrollbar = value
        End Set
    End Property

    Public Sub New()
        AddHandler SelectedIndexChanged, New EventHandler(AddressOf CustomListView_SelectedIndexChanged)
    End Sub

    Private Sub CustomListView_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
        UpdateScrollbar()
    End Sub

    Private Sub value_ValueChanged(ByVal sender As IcustomScrollBar, ByVal newValue As Integer)
        If _disableChangeEvents > 0 Then
            Return
        End If

        SetScrollPosition(_vScrollbar.Value)
    End Sub

    Public Sub GetScrollPosition(ByRef min As Integer, ByRef max As Integer, ByRef pos As Integer, ByRef smallchange As Integer, ByRef largechange As Integer)
        Dim scrollinfo As New ScrollInfo()
        scrollinfo.cbSize = CUInt(Marshal.SizeOf(GetType(ScrollInfo)))
        scrollinfo.fMask = CInt(ScrollInfoMask.SIF_ALL)
        If GetScrollInfo(Me.Handle, CInt(SBTYPES.SB_VERT), scrollinfo) Then
            min = scrollinfo.nMin
            max = scrollinfo.nMax
            pos = scrollinfo.nPos
            smallchange = 1
            largechange = CInt(scrollinfo.nPage)
        Else
            min = 0
            max = 0
            pos = 0
            smallchange = 0
            largechange = 0
        End If
    End Sub

    Private Sub UpdateScrollbar()
        If _vScrollbar IsNot Nothing Then
            Dim max As Integer, min As Integer, pos As Integer, smallchange As Integer, largechange As Integer
            GetScrollPosition(min, max, pos, smallchange, largechange)

            BeginDisableChangeEvents()
            _vScrollbar.Value = pos
            _vScrollbar.Maximum = max - largechange + 1
            _vScrollbar.Minimum = min
            _vScrollbar.SmallChange = smallchange
            _vScrollbar.LargeChange = largechange
            EndDisableChangeEvents()
        End If
    End Sub

    Public Sub SetScrollPosition(ByVal pos As Integer)
        pos = Math.Min(Items.Count - 1, pos)
        If pos < 0 OrElse pos >= Items.Count Then
            Return
        End If

        SuspendLayout()
        EnsureVisible(pos)

        For i As Integer = 0 To 9
            If TopItem IsNot Nothing AndAlso TopItem.Index <> pos Then
                TopItem = Items(pos)
            End If
        Next

        ResumeLayout()
    End Sub

    Protected Sub OnItemAdded()
        If _disableChangeEvents > 0 Then
            Return
        End If

        UpdateScrollbar()
        RaiseEvent ItemAdded(Me)
    End Sub

    Protected Sub OnItemsRemoved()
        If _disableChangeEvents > 0 Then
            Return
        End If

        UpdateScrollbar()
        RaiseEvent ItemsRemoved(Me)
    End Sub

    Protected Overrides Sub OnMouseWheel(ByVal e As MouseEventArgs)
        MyBase.OnMouseWheel(e)

        If _vScrollbar IsNot Nothing Then
            _vScrollbar.Value -= 3 * Math.Sign(e.Delta)
        End If
    End Sub

    Protected Overrides Sub WndProc(ByRef m As Message)
        If m.Msg = WM_VSCROLL Then
            Dim max As Integer, min As Integer, pos As Integer, smallchange As Integer, largechange As Integer
            GetScrollPosition(min, max, pos, smallchange, largechange)

            RaiseEvent ScrollPositionChanged(Me, pos)

            If _vScrollbar IsNot Nothing Then
                _vScrollbar.Value = pos
            End If
        ElseIf m.Msg = WM_NCCALCSIZE Then
            Dim style As Integer = CInt(GetWindowLong(Me.Handle, GWL_STYLE))
            If (style And WS_VSCROLL) = WS_VSCROLL Then
                SetWindowLong(Me.Handle, GWL_STYLE, style And Not WS_VSCROLL)
            End If
        ElseIf m.Msg = LVM_INSERTITEMA OrElse m.Msg = LVM_INSERTITEMW Then
            OnItemAdded()
        ElseIf m.Msg = LVM_DELETEITEM OrElse m.Msg = LVM_DELETEALLITEMS Then
            OnItemsRemoved()
        End If

        MyBase.WndProc(m)
    End Sub

    Public Shared Function GetWindowLong(ByVal hWnd As IntPtr, ByVal nIndex As Integer) As Integer
        If IntPtr.Size = 4 Then
            Return CInt(GetWindowLong32(hWnd, nIndex))
        Else
            Return CInt(CLng(GetWindowLongPtr64(hWnd, nIndex)))
        End If
    End Function

    Public Shared Function SetWindowLong(ByVal hWnd As IntPtr, ByVal nIndex As Integer, ByVal dwNewLong As Integer) As Integer
        If IntPtr.Size = 4 Then
            Return CInt(SetWindowLongPtr32(hWnd, nIndex, dwNewLong))
        Else
            Return CInt(CLng(SetWindowLongPtr64(hWnd, nIndex, dwNewLong)))
        End If
    End Function
End Class