Imports System.Collections.Generic
Imports System.Text
Imports System.Drawing
Imports System.Drawing.Drawing2D

Public MustInherit Class Painter
    Public Enum State
        Normal
        Pressed
        Hover
    End Enum

    Public MustOverride Sub Paint(ByVal g As Graphics, ByVal position As Rectangle, ByVal buttonState As State, ByVal text As String, ByVal buttonImage As Image, ByVal textFont As Font, _
     ByVal referencePosition As System.Nullable(Of Rectangle))
End Class

Public MustInherit Class DoubleBrushPainter
    Inherits Painter

    Protected MustOverride Function BorderColor(ByVal state As Painter.State) As Color
    Protected MustOverride Function BorderWidth(ByVal state As Painter.State) As Integer
    Protected MustOverride Function UpperBrush(ByVal state As Painter.State, ByVal bounds As Rectangle) As Brush
    Protected MustOverride Function LowerBrush(ByVal state As Painter.State, ByVal bounds As Rectangle) As Brush
    Protected MustOverride Function FontColor(ByVal state As Painter.State) As Color

    Public Overrides Sub Paint(ByVal g As Graphics, ByVal position As Rectangle, ByVal buttonState As Painter.State, ByVal text As String, ByVal buttonImage As Image, ByVal textFont As Font, _
     ByVal referencePosition As System.Nullable(Of Rectangle))
        Dim upperRect As Rectangle
        Dim lowerRect As Rectangle

        If buttonState <> State.Pressed Then
            upperRect = New Rectangle(position.Left, position.Top, position.Width, position.Height \ 2 - position.Height \ 8)
            lowerRect = New Rectangle(position.Left, position.Top + position.Height \ 2 - position.Height \ 8, position.Width, position.Height \ 2 + position.Height \ 8)
        Else
            upperRect = New Rectangle(position.Left, position.Top, position.Width, Math.Max(1, position.Height \ 2))
            lowerRect = New Rectangle(position.Left, position.Top + position.Height \ 2, position.Width, Math.Max(1, position.Height \ 2))
        End If

        g.FillRectangle(UpperBrush(buttonState, upperRect), upperRect)
        g.FillRectangle(LowerBrush(buttonState, lowerRect), lowerRect)

        Dim borderRect As New Rectangle(position.X, position.Y, position.Width - BorderWidth(buttonState), position.Height - BorderWidth(buttonState))
        g.DrawRectangle(New Pen(BorderColor(buttonState), BorderWidth(buttonState)), borderRect)


        Dim textBounds As Rectangle
        If buttonImage Is Nothing Then
            textBounds = New Rectangle(position.X + 2, position.Y + 2, position.Width - 4, position.Height - 4)
        Else
            Dim imageHeight As Integer = position.Height - 10

            Dim imageRatio As Double = CDbl(buttonImage.Width) / CDbl(buttonImage.Height)
            Dim imageWidth As Integer = CInt(Math.Truncate(imageRatio * CDbl(imageHeight)))

            Dim imagePosition As New Rectangle(position.X + 5, position.Y + 5, imageWidth, imageHeight)
            textBounds = New Rectangle(imagePosition.Right + 2, position.Y + 2, position.Width - imagePosition.Width - 10, position.Height - 4)

            g.DrawImage(buttonImage, imagePosition, New Rectangle(0, 0, buttonImage.Width, buttonImage.Height), GraphicsUnit.Pixel)
        End If

        Dim format As New StringFormat()
        format.LineAlignment = StringAlignment.Center
        format.Alignment = StringAlignment.Center
        format.FormatFlags = StringFormatFlags.NoClip Or StringFormatFlags.FitBlackBox Or StringFormatFlags.NoWrap

        If referencePosition IsNot Nothing Then
            Dim xRatio As Double = CDbl(position.Width) / CDbl(referencePosition.Value.Width)
            Dim yRatio As Double = CDbl(position.Height) / CDbl(referencePosition.Value.Height)
            textFont = ScaledFont(textFont, xRatio, yRatio, text, textBounds, g, _
             format)
        End If

        Using frontBrush As Brush = New SolidBrush(FontColor(buttonState))
            g.DrawString(text, textFont, frontBrush, textBounds, format)
        End Using
    End Sub

    Protected Function ScaledFont(ByVal referenceFont As Font, ByVal xRatio As Double, ByVal yRatio As Double, ByVal text As String, ByVal fitTo As Rectangle, ByVal g As Graphics, _
     ByVal format As StringFormat) As Font
        Dim fontsize_YScaled As Single = Math.Max(1, CInt(Math.Truncate(referenceFont.Size * yRatio)))

        Dim newFont As New Font(referenceFont.FontFamily, fontsize_YScaled, referenceFont.Style)
        Dim textSize As SizeF = g.MeasureString(text, newFont, fitTo.Width, format)

        If textSize.Height <= fitTo.Height Then
            Return newFont
        Else
            Do
                newFont.Dispose()
                newFont = Nothing

                If fontsize_YScaled <= 1 Then
                    Return New Font(FontFamily.GenericSansSerif, 1, referenceFont.Style)
                End If

                fontsize_YScaled -= 0.5F
                newFont = New Font(referenceFont.FontFamily, fontsize_YScaled, referenceFont.Style)
                textSize = g.MeasureString(text, newFont, fitTo.Width)

                If textSize.Height <= fitTo.Height Then Return newFont
            Loop While textSize.Height <= fitTo.Height
            Return newFont
        End If
    End Function
End Class