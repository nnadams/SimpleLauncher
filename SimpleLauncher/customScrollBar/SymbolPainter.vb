Imports System.Collections.Generic
Imports System.Text
Imports System.Drawing
Imports System.Drawing.Drawing2D

Public Class SymbolPainter
    Inherits Painter

    Public Shared Function Create(ByVal backgroundPainter As Painter, ByVal symbol As SymbolEnum, ByVal fill As Boolean, ByVal penWidth As Integer, ByVal forecolor As Color, ByVal hoverColor As Color, _
     ByVal clickColor As Color) As Painter
        Return New StackedPainters(New PainterFilterNoText(backgroundPainter), New SymbolPainter(symbol, fill, penWidth, forecolor, hoverColor, clickColor))
    End Function

    Public Enum SymbolEnum
        TriangleDown
        TriangleUp
        GripH
    End Enum

    Private _fill As Boolean
    Private _symbol As SymbolEnum
    Private _penWidth As Integer
    Private _color As Color
    Private _pen As Pen
    Private _fillBrush As Brush
    Private _hoverPen As Pen
    Private _clickPen As Pen

    Private _noFill As New List(Of SymbolEnum)(New SymbolEnum() {SymbolEnum.GripH})

    Public Sub New(ByVal symbol As SymbolEnum, ByVal fill As Boolean, ByVal penWidth As Integer, ByVal forecolor As Color, ByVal hoverPen As Color, ByVal clickPen As Color)
        _symbol = symbol
        _fill = fill
        _penWidth = penWidth
        _color = forecolor
        _hoverPen = New Pen(hoverPen, penWidth)
        _clickPen = New Pen(clickPen, penWidth)
        _pen = New Pen(_color, penWidth)

        _fillBrush = New SolidBrush(forecolor)
    End Sub

    Private Function BuildTriangleDown(ByVal bounds As Rectangle) As GraphicsPath
        Dim xPadding As Integer = bounds.Width \ 10
        Dim yPadding As Integer = bounds.Height \ 10
        Dim triangleHalf As Integer = Math.Max(0, bounds.Width \ 2 - xPadding)

        Dim triangle As New GraphicsPath()
        triangle.AddLine(bounds.Left + xPadding, bounds.Top + yPadding, bounds.Left + xPadding + 2 * triangleHalf, bounds.Top + yPadding)
        triangle.AddLine(bounds.Left + xPadding + 2 * triangleHalf, bounds.Top + yPadding, bounds.Left + xPadding + triangleHalf, bounds.Bottom - yPadding)
        triangle.CloseAllFigures()
        Return triangle
    End Function

    Private Function BuildTriangleUp(ByVal bounds As Rectangle) As GraphicsPath
        Dim xPadding As Integer = bounds.Width \ 10
        Dim yPadding As Integer = bounds.Height \ 10
        Dim triangleHalf As Integer = Math.Max(0, bounds.Width \ 2 - xPadding)

        Dim triangle As New GraphicsPath()
        triangle.AddLine(bounds.Left + xPadding, bounds.Bottom - yPadding, bounds.Left + xPadding + 2 * triangleHalf, bounds.Bottom - yPadding)
        triangle.AddLine(bounds.Left + xPadding + 2 * triangleHalf, bounds.Bottom - yPadding, bounds.Left + xPadding + triangleHalf, bounds.Top + yPadding)
        triangle.CloseAllFigures()
        Return triangle
    End Function

    Private Function BuildGripH(ByVal bounds As Rectangle) As GraphicsPath
        Dim xPadding As Integer = bounds.Width \ 10
        Dim yPadding As Integer = bounds.Height \ 10
        Dim half As Integer = CInt(Math.Truncate(CDbl(bounds.Height - 2 * yPadding) / 2.0))
        Dim grip As New GraphicsPath()

        grip.AddLine(bounds.Left + xPadding, bounds.Top + yPadding, bounds.Right - xPadding, bounds.Top + yPadding)
        grip.StartFigure()
        grip.AddLine(bounds.Left + xPadding, bounds.Top + yPadding + half, bounds.Right - xPadding, bounds.Top + yPadding + half)
        grip.StartFigure()
        grip.AddLine(bounds.Left + xPadding, bounds.Top + yPadding + 2 * half, bounds.Right - xPadding, bounds.Top + yPadding + 2 * half)

        Return grip
    End Function

    Public Overrides Sub Paint(ByVal g As Graphics, ByVal position As Rectangle, ByVal buttonState As Painter.State, ByVal text As String, ByVal buttonImage As Image, ByVal textFont As Font, _
     ByVal referencePosition As System.Nullable(Of Rectangle))
        Dim path As GraphicsPath

        Dim myPen As Pen = _pen

        If buttonState = State.Hover Then
            myPen = _hoverPen
        ElseIf buttonState = State.Pressed Then
            myPen = _clickPen
        End If

        If _symbol = SymbolEnum.TriangleDown Then
            path = BuildTriangleDown(position)
        ElseIf _symbol = SymbolEnum.TriangleUp Then
            path = BuildTriangleUp(position)
        ElseIf _symbol = SymbolEnum.GripH Then
            path = BuildGripH(position)
        Else
            Throw New NotImplementedException("Symbol not implemented")
        End If

        If _fill AndAlso _noFill.Contains(_symbol) = False Then
            g.FillPath(myPen.Brush, path)

            If buttonState = State.Hover Then
                g.DrawPath(myPen, path)
            ElseIf buttonState = State.Pressed Then
                g.DrawPath(myPen, path)
            End If
        Else
            g.DrawPath(myPen, path)
        End If
    End Sub
End Class