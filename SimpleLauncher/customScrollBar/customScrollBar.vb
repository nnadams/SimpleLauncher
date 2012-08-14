Imports System.Drawing.Drawing2D

Public Class customScrollBar
    Inherits Control
    Implements IcustomScrollBar

    Public Event ValueChanged As ScrollValueChangedDelegate Implements IcustomScrollBar.ValueChanged
    Private _largeChange As Integer = 10
    Private _smallChange As Integer = 1
    Private _maximum As Integer = 99
    Private _minimum As Integer = 0
    Private _currentValue As Integer = 0

    Private _canScroll As Boolean = False

    Private _init As Integer = 0

    Private _currentThumbPosition As Rectangle
    Private _beforeThumb As Rectangle
    Private _afterThumb As Rectangle
    Private _thumbStyle As ThumbStyleEnum = ThumbStyleEnum.Auto

    Private _upperButtonState As Painter.State = Painter.State.Normal
    Private _upperButtonPainter As Painter
    Private _lowerButtonState As Painter.State = Painter.State.Normal
    Private _lowerButtonPainter As Painter
    Private _largeThumbPainter As Painter
    Private _smallThumbPainter As Painter
    Private _thumbState As Painter.State = Painter.State.Normal
    Private _beforeThumbState As Painter.State = Painter.State.Normal
    Private _afterThumbState As Painter.State = Painter.State.Normal

    Private _useCustomBackBrush As Boolean = False

    Private _activeBackColor As Color = Color.Gray
    Private _useCustomActiveBackColor As Boolean = False

    Private _timer As New Timer()

    Private _timerAction As ScrollAction

    Private _moveThumbStart As System.Nullable(Of Point) = Nothing
    Private _moveThumbValueStart As Integer
    Private _moveThumbRectStart As Rectangle

    Private _borderPen As Pen
    Private _backBrush As Brush
    Private _activeBackBrush As Brush

    Public ReadOnly Property CanScroll() As Boolean Implements IcustomScrollBar.CanScroll
        Get
            Return _canScroll
        End Get
    End Property

    Public Overrides Property BackColor() As Color
        Get
            Return MyBase.BackColor
        End Get
        Set(ByVal value As Color)
            MyBase.BackColor = value
            PrepareBack()
        End Set
    End Property

    Public Property ActiveBackColor() As Color
        Get
            Return _activeBackColor
        End Get
        Set(ByVal value As Color)
            _activeBackColor = value
            PrepareBack()
        End Set
    End Property

    Public Sub SetCustomBackBrush(ByVal brush As Brush, ByVal activeBackBrush As Brush)
        _useCustomBackBrush = brush IsNot Nothing
        _backBrush = brush

        _useCustomActiveBackColor = activeBackBrush IsNot Nothing
        _activeBackBrush = activeBackBrush
        PrepareBack()
    End Sub

    Public Property ThumbStyle() As ThumbStyleEnum
        Get
            Return _thumbStyle
        End Get
        Set(ByVal value As ThumbStyleEnum)
            _thumbStyle = value
        End Set
    End Property

    Public Property LargeChange() As Integer Implements IcustomScrollBar.LargeChange
        Get
            Return _largeChange
        End Get
        Set(ByVal value As Integer)
            _largeChange = value
        End Set
    End Property

    Public Property SmallChange() As Integer Implements IcustomScrollBar.SmallChange
        Get
            Return _smallChange
        End Get
        Set(ByVal value As Integer)
            _smallChange = value
        End Set
    End Property

    Public Property Maximum() As Integer Implements IcustomScrollBar.Maximum
        Get
            Return _maximum
        End Get
        Set(ByVal value As Integer)
            SetBounds(_minimum, value)
        End Set
    End Property

    Public Property Minimum() As Integer Implements IcustomScrollBar.Minimum
        Get
            Return _minimum
        End Get
        Set(ByVal value As Integer)
            SetBounds(value, _maximum)
        End Set
    End Property

    Public Property Value() As Integer Implements IcustomScrollBar.Value
        Get
            Return _currentValue
        End Get
        Set(ByVal value As Integer)
            SetValue(value)
        End Set
    End Property

    Private Enum ScrollAction
        Down
        Up
        PageDown
        PageUp
    End Enum

    Public Enum ThumbStyleEnum
        Auto
        Large
        Small
    End Enum

    Private Overloads Sub SetBounds(ByVal minimum As Integer, ByVal maximum As Integer)
        If _init > 0 Then
            Return
        End If

        If minimum > maximum Then
            minimum = maximum
        End If

        _minimum = minimum
        _maximum = maximum

        SetValue(_currentValue)
    End Sub

    Private Sub SetValue(ByVal newValue As Integer)
        If _init > 0 Then
            Return
        End If

        If newValue < _minimum Then
            _currentValue = _minimum
        ElseIf newValue > _maximum Then
            _currentValue = _maximum
        Else
            _currentValue = newValue
        End If

        InvalidateThumbPosition()

        RaiseEvent ValueChanged(Me, _currentValue)
    End Sub

    Public Sub BeginInit()
        _init += 1
    End Sub

    Public Sub EndInit()
        If _init > 0 Then
            _init -= 1
        End If

        If _init = 0 Then
            SetBounds(_minimum, _maximum)
        End If
    End Sub

    Protected Sub InvalidateThumbPosition()
        If _init > 0 Then
            Return
        End If

        If _minimum = _maximum Then
            _currentThumbPosition = New Rectangle(0, 0, 0, 0)
            Return
        End If

        If GetRealThumbStyle() = ThumbStyleEnum.Small Then
            _currentThumbPosition = New Rectangle(2, 32, ClientSize.Width - 4, 15)
        Else
            _currentThumbPosition = New Rectangle(2, 32, ClientSize.Width - 4, 30)
        End If


        Dim barHeight As Double = ClientSize.Height - 4 - 2 * 30 - _currentThumbPosition.Height
        Dim smallChangeHeight As Double = barHeight / CDbl(_maximum - _minimum)

        If barHeight < 0 And smallChangeHeight < 0 Then
            _canScroll = False
        Else
            _canScroll = True
        End If

        Dim thumbTopOffset As Integer = CInt(Math.Truncate(smallChangeHeight * CDbl(_currentValue)))
        _currentThumbPosition.Offset(0, thumbTopOffset)

        _beforeThumb = Rectangle.FromLTRB(2, RectUpperButton().Bottom, ClientSize.Width - 2, _currentThumbPosition.Top)
        _afterThumb = Rectangle.FromLTRB(2, _currentThumbPosition.Bottom, ClientSize.Width - 2, RectLowerButton().Top)
        Me.Invalidate()
    End Sub

    Public Sub SetUpperButtonPainter(ByVal upperButtonPainter As Painter)
        _upperButtonPainter = upperButtonPainter
    End Sub

    Public Sub SetLowerButtonPainter(ByVal lowerButtonPainter As Painter)
        _lowerButtonPainter = lowerButtonPainter
    End Sub

    Public Sub SetLargeThumbPainter(ByVal largeThumbPainter As Painter)
        _largeThumbPainter = largeThumbPainter
    End Sub

    Public Sub SetSmallThumbPainter(ByVal smallThumbPainter As Painter)
        _smallThumbPainter = smallThumbPainter
    End Sub

    Protected Sub PrepareBack()
        If Not _useCustomBackBrush Then
            _backBrush = New SolidBrush(BackColor)
        End If

        If Not _useCustomActiveBackColor Then
            _activeBackBrush = New SolidBrush(ActiveBackColor)
        End If
    End Sub

#Region "Paint"
    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias

        PaintBack(e)

        Dim upperButton As Rectangle = RectUpperButton()
        Dim lowerButton As Rectangle = RectLowerButton()
        _upperButtonPainter.Paint(e.Graphics, upperButton, _upperButtonState, "", Nothing, Font, Nothing)
        _lowerButtonPainter.Paint(e.Graphics, lowerButton, _lowerButtonState, "", Nothing, Font, Nothing)

        If _currentThumbPosition.Height > 0 Then
            GetThumbPainter().Paint(e.Graphics, _currentThumbPosition, _thumbState, "", Nothing, Font, _
             Nothing)
        End If
    End Sub

    Protected Sub PaintBack(ByVal e As PaintEventArgs)
        e.Graphics.FillRectangle(_backBrush, Me.ClientRectangle)

        If _beforeThumbState = Painter.State.Pressed Then
            e.Graphics.FillRectangle(_activeBackBrush, _beforeThumb)
        End If
        If _afterThumbState = Painter.State.Pressed Then
            e.Graphics.FillRectangle(_activeBackBrush, _afterThumb)
        End If
    End Sub

    Protected Function RectUpperButton() As Rectangle
        Return New Rectangle(2, 2, ClientSize.Width - 4, 30)
    End Function

    Protected Function RectLowerButton() As Rectangle
        Return New Rectangle(2, ClientSize.Height - 32, ClientSize.Width - 4, 30)
    End Function

    Protected Function GetThumbPainter() As Painter
        If GetRealThumbStyle() = ThumbStyleEnum.Small Then
            Return _smallThumbPainter
        Else
            Return _largeThumbPainter
        End If
    End Function

    Protected Function GetRealThumbStyle() As ThumbStyleEnum
        Dim myThumbStyle As ThumbStyleEnum = _thumbStyle

        If myThumbStyle = ThumbStyleEnum.Auto AndAlso _maximum - _minimum >= 200 Then
            myThumbStyle = ThumbStyleEnum.Small
        Else
            myThumbStyle = ThumbStyleEnum.Large
        End If

        Return myThumbStyle
    End Function
#End Region
#Region "Mouse events"
    Protected Overrides Sub OnMouseMove(ByVal e As MouseEventArgs)
        MyBase.OnMouseMove(e)

        If _moveThumbStart IsNot Nothing Then
            Dim offset As Integer = e.Y - _moveThumbStart.Value.Y

            Dim barHeight As Double = ClientSize.Height - 4 - 2 * 30 - _moveThumbRectStart.Height
            Dim smallChangeHeight As Double = barHeight / CDbl(_maximum - _minimum)


            Dim lastOffset As Double = Math.Abs(offset)
            Dim currentValIncrease As Integer = 0
            While True
                If offset > 0 Then
                    currentValIncrease += 1
                Else
                    currentValIncrease -= 1
                End If

                Dim currentOffset As Double = Math.Abs(CDbl(smallChangeHeight) * CDbl(currentValIncrease) - CDbl(offset))
                If currentOffset > lastOffset OrElse (currentOffset = 0 AndAlso lastOffset = 0) Then
                    Exit While
                End If


                lastOffset = currentOffset
            End While
            If currentValIncrease > 1 Then
                SetValue(_moveThumbValueStart + currentValIncrease - 1)
            ElseIf currentValIncrease < -1 Then
                SetValue(_moveThumbValueStart + currentValIncrease + 1)
            End If
            Return
        End If

        If AnyStateHasStatus(Painter.State.Pressed) Then
            Return
        End If


        If RectUpperButton().Contains(e.Location) AndAlso _upperButtonState <> Painter.State.Hover Then
            ResetAllButtonState()
            _upperButtonState = Painter.State.Hover
            Invalidate()
        ElseIf RectLowerButton().Contains(e.Location) AndAlso _lowerButtonState <> Painter.State.Hover Then
            ResetAllButtonState()
            _lowerButtonState = Painter.State.Hover
            Invalidate()
        ElseIf _currentThumbPosition.Contains(e.Location) AndAlso _thumbState <> Painter.State.Hover Then
            ResetAllButtonState()
            _thumbState = Painter.State.Hover
            Invalidate()
        ElseIf _beforeThumb.Contains(e.Location) AndAlso _beforeThumbState <> Painter.State.Hover Then
            ResetAllButtonState()
            _beforeThumbState = Painter.State.Hover
            Invalidate()
        ElseIf _afterThumb.Contains(e.Location) AndAlso _afterThumbState <> Painter.State.Hover Then
            ResetAllButtonState()
            _afterThumbState = Painter.State.Hover
            Invalidate()
        End If
    End Sub

    Protected Overrides Sub OnMouseDown(ByVal e As MouseEventArgs)
        MyBase.OnMouseDown(e)

        If RectUpperButton().Contains(e.Location) AndAlso _upperButtonState <> Painter.State.Pressed Then
            ScrollAndActivateTimer(ScrollAction.Up)
            ResetAllButtonState()
            _upperButtonState = Painter.State.Pressed
            Invalidate()
        ElseIf RectLowerButton().Contains(e.Location) AndAlso _lowerButtonState <> Painter.State.Pressed Then
            ScrollAndActivateTimer(ScrollAction.Down)
            ResetAllButtonState()
            _lowerButtonState = Painter.State.Pressed
            Invalidate()
        ElseIf _currentThumbPosition.Contains(e.Location) AndAlso _thumbState <> Painter.State.Pressed Then
            ResetAllButtonState()
            _thumbState = Painter.State.Pressed
            _moveThumbStart = e.Location
            _moveThumbValueStart = _currentValue
            _moveThumbRectStart = _currentThumbPosition
            Invalidate()
        ElseIf _beforeThumb.Contains(e.Location) AndAlso _beforeThumbState <> Painter.State.Pressed Then
            ScrollAndActivateTimer(ScrollAction.PageUp)
            ResetAllButtonState()
            _beforeThumbState = Painter.State.Pressed
            Invalidate()
        ElseIf _afterThumb.Contains(e.Location) AndAlso _afterThumbState <> Painter.State.Pressed Then
            ScrollAndActivateTimer(ScrollAction.PageDown)
            ResetAllButtonState()
            _afterThumbState = Painter.State.Pressed
            Invalidate()
        End If
    End Sub

    Protected Overrides Sub OnMouseUp(ByVal e As MouseEventArgs)
        _timer.[Stop]()

        MyBase.OnMouseUp(e)

        ResetAllButtonState()
        Invalidate()
    End Sub

    Protected Overrides Sub OnMouseLeave(ByVal e As System.EventArgs)
        MyBase.OnMouseLeave(e)

        ResetAllButtonState()
        Invalidate()
    End Sub

    Private Sub ResetAllButtonState()
        _moveThumbStart = Nothing
        _thumbState = Painter.State.Normal
        _lowerButtonState = Painter.State.Normal
        _upperButtonState = Painter.State.Normal
        _beforeThumbState = Painter.State.Normal
        _afterThumbState = Painter.State.Normal
    End Sub

    Private Function AnyStateHasStatus(ByVal state As Painter.State) As Boolean
        Return _thumbState = state OrElse _lowerButtonState = state OrElse _upperButtonState = state OrElse _beforeThumbState = state OrElse _afterThumbState = state
    End Function
#End Region

    Private Sub Scroll(ByVal scrollAction As ScrollAction)
        Dim change As Integer = SmallChange

        If scrollAction = scrollAction.Up Then
            change = -SmallChange
        ElseIf scrollAction = scrollAction.PageDown Then
            change = LargeChange
        ElseIf scrollAction = scrollAction.PageUp Then
            change = -LargeChange
        End If

        SetValue(_currentValue + change)
    End Sub

    Private Sub ScrollAndActivateTimer(ByVal scrollAction As ScrollAction)
        Scroll(scrollAction)
        _timerAction = scrollAction
        _timer.Interval = 100
        _timer.Start()
    End Sub

    Private Sub _timer_Tick(ByVal sender As Object, ByVal e As EventArgs)
        _timer.Interval = 1
        Scroll(_timerAction)
    End Sub

    Protected Overrides Sub OnResize(ByVal e As EventArgs)
        MyBase.OnResize(e)

        InvalidateThumbPosition()
    End Sub

    Public Sub New()
        SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.OptimizedDoubleBuffer, True)
        PrepareBack()

        _upperButtonPainter = New StackedPainters(New WindowsStyledButtonPainter(), New PainterFilterSize(New SymbolPainter(SymbolPainter.SymbolEnum.TriangleUp, True, 1, Color.Black, Color.DimGray, Color.Black), PainterFilterSize.Alignment.Center, PainterFilterSize.Alignment.Center, 0, 0, 0, 0, 10, 2))

        _lowerButtonPainter = New StackedPainters(New WindowsStyledButtonPainter(), New PainterFilterSize(New SymbolPainter(SymbolPainter.SymbolEnum.TriangleDown, True, 1, Color.Black, Color.DimGray, Color.Black), PainterFilterSize.Alignment.Center, PainterFilterSize.Alignment.Center, 0, 0, 0, 0, 10, 2))

        _smallThumbPainter = New WindowsStyledButtonPainter()
        _largeThumbPainter = New StackedPainters(New WindowsStyledButtonPainter(), New PainterFilterSize(New SymbolPainter(SymbolPainter.SymbolEnum.GripH, True, 1, SystemColors.ControlDark, SystemColors.GrayText, Color.Black), PainterFilterSize.Alignment.Center, PainterFilterSize.Alignment.Center, 0, 0, 0, 0, 10, 2))

        InvalidateThumbPosition()

        AddHandler _timer.Tick, AddressOf _timer_Tick
    End Sub
End Class