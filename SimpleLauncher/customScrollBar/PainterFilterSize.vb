Imports System.Collections.Generic
Imports System.Text
Imports System.Drawing

Public Class PainterFilterSize
    Inherits Painter

    Public Enum Alignment
        Center
        Near
        Far
    End Enum

    Private _hAlign As Alignment
    Private _vAlign As Alignment
    Private _paddingTop As Integer
    Private _paddingRight As Integer
    Private _paddingLeft As Integer
    Private _paddingBottom As Integer
    Private _maxWidth As Integer

    Private _targetRatio As Double

    Private _subPainter As Painter

    Public Sub New(ByVal subPainter As Painter, ByVal hAlign As Alignment, ByVal vAlign As Alignment, ByVal paddingTop As Integer, ByVal paddingLeft As Integer, ByVal paddingRight As Integer, _
     ByVal paddingBottom As Integer, ByVal maxWidth As Integer, ByVal targetRatio As Double)
        _hAlign = hAlign
        _vAlign = vAlign
        _paddingTop = paddingTop
        _paddingBottom = paddingBottom
        _paddingLeft = paddingLeft
        _paddingRight = paddingRight

        _maxWidth = maxWidth
        _targetRatio = targetRatio
        _subPainter = subPainter
    End Sub

    Public Overrides Sub Paint(ByVal g As Graphics, ByVal position As Rectangle, ByVal buttonState As Painter.State, ByVal text As String, ByVal buttonImage As Image, ByVal textFont As Font, _
     ByVal referencePosition As System.Nullable(Of Rectangle))
        Dim layoutArea As Rectangle = Rectangle.FromLTRB(position.X + _paddingLeft, position.Y + _paddingTop, position.Right - _paddingRight, position.Bottom - _paddingBottom)

        If layoutArea.Width <= 0 OrElse layoutArea.Height <= 0 Then
            Return
        End If

        Dim layoutRatio As Double = CDbl(layoutArea.Width) / CDbl(layoutArea.Height)
        Dim targetRect As Rectangle

        If layoutRatio < _targetRatio Then
            Dim targetWidth As Integer = layoutArea.Width

            If _maxWidth > 0 Then
                targetWidth = Math.Min(layoutArea.Width, _maxWidth)
            End If

            Dim targetHeight As Integer = CInt(Math.Truncate(CDbl(targetWidth) / _targetRatio))
            targetRect = New Rectangle(layoutArea.X, layoutArea.Y, targetWidth, targetHeight)
        Else
            Dim targetWidth As Integer = CInt(Math.Truncate(CDbl(layoutArea.Height) * _targetRatio))
            Dim targetHeight As Integer = layoutArea.Height

            If _maxWidth > 0 AndAlso targetWidth > _maxWidth Then
                targetWidth = _maxWidth
                targetHeight = CInt(Math.Truncate(CDbl(targetHeight) / _targetRatio))
            End If

            targetRect = New Rectangle(layoutArea.X, layoutArea.Y, targetWidth, targetHeight)
        End If

        If _vAlign = Alignment.Far Then
            targetRect = New Rectangle(targetRect.X, layoutArea.Bottom - targetRect.Height, targetRect.Width, targetRect.Height)
        ElseIf _vAlign = Alignment.Center Then
            targetRect = New Rectangle(targetRect.X, layoutArea.Top + CInt(Math.Truncate(CDbl(layoutArea.Height) / 2.0 - CDbl(targetRect.Height) / 2.0)), targetRect.Width, targetRect.Height)
        End If

        If _hAlign = Alignment.Far Then
            targetRect = New Rectangle(layoutArea.Right - targetRect.Width, targetRect.Y, targetRect.Width, targetRect.Height)
        ElseIf _hAlign = Alignment.Center Then
            targetRect = New Rectangle(targetRect.X + CInt(Math.Truncate(CDbl(layoutArea.Width) / 2.0 - CDbl(targetRect.Width) / 2.0)), targetRect.Y, targetRect.Width, targetRect.Height)
        End If

        _subPainter.Paint(g, targetRect, buttonState, text, buttonImage, textFont, referencePosition)
    End Sub
End Class