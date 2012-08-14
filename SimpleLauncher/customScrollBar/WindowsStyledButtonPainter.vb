Imports System.Collections.Generic
Imports System.Text
Imports System.Drawing
Imports System.Drawing.Drawing2D

Public Class WindowsStyledButtonPainter
    Inherits Painter

    Protected _lastPosition As System.Nullable(Of Rectangle) = Nothing
    Protected _lastState As System.Nullable(Of Painter.State) = Nothing

    Protected _upperGradientPath As GraphicsPath = Nothing
    Protected _upperGradientBrush As Brush = Nothing

    Protected _upperGradientRect As Rectangle


    Protected _leftBounds As Rectangle
    Protected _leftBrush As Brush = Nothing

    Protected _middleBounds As Rectangle
    Protected _middleBrush As Brush = Nothing

    Protected _rightBounds As Rectangle
    Protected _rightBrush As Brush = Nothing

    Protected _borderPen As Pen = Nothing

    Protected Overridable Sub RecalcBrushes(ByVal position As Rectangle, ByVal state__1 As Painter.State)
        If _lastPosition Is Nothing OrElse _lastPosition.Value <> position OrElse _lastState Is Nothing OrElse _lastState.Value <> state__1 Then
            _lastState = state__1
            If state__1 = State.Hover Then
                _borderPen = New Pen(Color.FromArgb(&H3C, &H7F, &HB1), 1)
            ElseIf state__1 = State.Pressed Then
                _borderPen = New Pen(Color.FromArgb(&H18, &H59, &H8A), 1)
            Else
                _borderPen = New Pen(Color.FromArgb(&H9A, &H9A, &H9A), 1)
            End If

            _leftBounds = New Rectangle(position.X, position.Y, 8, position.Height)
            _leftBrush = CreateLeftBrush(_leftBounds, state__1)

            _middleBounds = New Rectangle(_leftBounds.Right, _leftBounds.Y, CInt(Math.Truncate(CSng(position.Width) - 16)), position.Height)
            _middleBrush = CreateMiddleBrush(_middleBounds, state__1)

            _rightBounds = New Rectangle(_middleBounds.Right, _leftBounds.Y, 8, position.Height)
            _rightBrush = CreateRightBrush(_rightBounds, state__1)

            _upperGradientPath = New GraphicsPath()
            _upperGradientPath.AddLine(position.X + 8, position.Y + 1, position.X + 8, position.Y + 5)
            _upperGradientPath.AddLine(position.X + 8, position.Y + 5, _middleBounds.Right, position.Y + 5)
            _upperGradientPath.AddLine(_middleBounds.Right, position.Y + 5, _rightBounds.Right - 1, position.Y + 1)
            _upperGradientPath.CloseAllFigures()

            _upperGradientRect = New Rectangle(position.X + 8, position.Y + 1, 10, 4)
            _upperGradientBrush = New LinearGradientBrush(_upperGradientRect, Color.FromArgb(&HED, &HED, &HED), Color.FromArgb(&HDD, &HDD, &HE0), LinearGradientMode.Vertical)

            _lastPosition = position
        End If
    End Sub

    Protected Overridable Function CreateLeftBrush(ByVal bounds As Rectangle, ByVal state__1 As Painter.State) As Brush
        If state__1 = State.Hover Then
            Return New LinearGradientBrush(bounds, Color.FromArgb(&HE3, &HF4, &HFC), Color.FromArgb(&HD6, &HEE, &HFB), LinearGradientMode.Horizontal)
        ElseIf state__1 = State.Pressed Then
            Return New LinearGradientBrush(bounds, Color.FromArgb(&HCE, &HED, &HFA), Color.FromArgb(&HB5, &HE4, &HF7), LinearGradientMode.Horizontal)
        Else
            Return New LinearGradientBrush(bounds, Color.FromArgb(&HF5, &HF5, &HF5), Color.FromArgb(&HE9, &HE9, &HEB), LinearGradientMode.Horizontal)
        End If
    End Function

    Protected Overridable Function CreateMiddleBrush(ByVal bounds As Rectangle, ByVal state__1 As Painter.State) As Brush
        If state__1 = State.Hover Then
            Return New SolidBrush(Color.FromArgb(&HA9, &HDB, &HF6))
        ElseIf state__1 = State.Pressed Then
            Return New SolidBrush(Color.FromArgb(&H6F, &HCA, &HF0))
        Else
            Return New SolidBrush(Color.FromArgb(&HD9, &HDA, &HDC))
        End If
    End Function

    Protected Overridable Function CreateRightBrush(ByVal bounds As Rectangle, ByVal state__1 As Painter.State) As Brush
        If state__1 = State.Hover Then
            Return New LinearGradientBrush(bounds, Color.FromArgb(&HA9, &HDB, &HF6), Color.FromArgb(&H9C, &HCA, &HE3), LinearGradientMode.Horizontal)
        ElseIf state__1 = State.Pressed Then
            Return New LinearGradientBrush(bounds, Color.FromArgb(&H6F, &HCA, &HF0), Color.FromArgb(&H66, &HBA, &HDD), LinearGradientMode.Horizontal)
        Else
            Return New LinearGradientBrush(bounds, Color.FromArgb(&HD5, &HD5, &HD8), Color.FromArgb(&HC0, &HC0, &HC4), LinearGradientMode.Horizontal)
        End If
    End Function

    Public Overrides Sub Paint(ByVal g As Graphics, ByVal position As Rectangle, ByVal state As Painter.State, ByVal text As String, ByVal buttonImage As Image, ByVal textFont As Font, _
     ByVal referencePosition As System.Nullable(Of Rectangle))
        If position.Height < 10 OrElse position.Width < 20 Then
            Return
        End If

        RecalcBrushes(position, state)

        g.FillRectangle(_leftBrush, _leftBounds)
        g.FillRectangle(_middleBrush, _middleBounds)
        g.FillRectangle(_rightBrush, _rightBounds)
        DrawBorder(g, position, state)

        g.FillPath(_upperGradientBrush, _upperGradientPath)
    End Sub

    Public Overridable Sub DrawBorder(ByVal g As Graphics, ByVal position As Rectangle, ByVal state As Painter.State)
        g.DrawRectangle(_borderPen, New Rectangle(position.X, position.Y, CInt(Math.Truncate(position.Width - _borderPen.Width)), CInt(Math.Truncate(position.Height - _borderPen.Width))))
    End Sub
End Class