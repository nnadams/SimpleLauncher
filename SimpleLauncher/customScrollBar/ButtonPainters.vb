Imports System.Collections.Generic
Imports System.Text
Imports System.Drawing
Imports System.Drawing.Drawing2D

Public Class Office2007BlackButtonPainter
    Inherits DoubleBrushPainter

    Protected Overrides Function BorderColor(ByVal state_1 As Painter.State) As Color
        If state_1 = State.Pressed Then
            Return Color.FromArgb(&H8B, &H76, &H54)
        Else
            Return Color.FromArgb(&H96, &H9F, &HA3)
        End If
    End Function

    Protected Overrides Function FontColor(ByVal state As Painter.State) As Color
        Return Color.FromArgb(&H46, &H46, &H46)
    End Function

    Protected Overrides Function BorderWidth(ByVal state As Painter.State) As Integer
        Return 1
    End Function

    Protected Overrides Function UpperBrush(ByVal state_1 As Painter.State, ByVal bounds As Rectangle) As Brush
        If state_1 = State.Normal Then
            Return New LinearGradientBrush(bounds, Color.FromArgb(&HD6, &HDE, &HDF), Color.FromArgb(&HDB, &HE2, &HE4), LinearGradientMode.Vertical)
        ElseIf state_1 = State.Hover Then
            Return New LinearGradientBrush(bounds, Color.FromArgb(&HFE, &HFA, &HE5), Color.FromArgb(&HFB, &HE0, &H91), LinearGradientMode.Vertical)
        Else
            Return New LinearGradientBrush(bounds, Color.FromArgb(&HCC, &H96, &H66), Color.FromArgb(&HFF, &HAA, &H46), LinearGradientMode.Vertical)
        End If
    End Function

    Protected Overrides Function LowerBrush(ByVal state_1 As Painter.State, ByVal bounds As Rectangle) As Brush
        If state_1 = State.Normal Then
            Return New LinearGradientBrush(bounds, Color.FromArgb(&HCE, &HD5, &HD7), Color.FromArgb(&HDF, &HE4, &HE6), LinearGradientMode.Vertical)
        ElseIf state_1 = State.Hover Then
            Return New LinearGradientBrush(bounds, Color.FromArgb(&HFE, &HD2, &H53), Color.FromArgb(&HFF, &HE3, &H97), LinearGradientMode.Vertical)
        Else
            Return New LinearGradientBrush(bounds, Color.FromArgb(&HFF, &H9C, &H26), Color.FromArgb(&HFF, &HC0, &H4B), LinearGradientMode.Vertical)
        End If

    End Function
End Class

Public Class Office2007BlueButtonPainter
    Inherits Office2007BlackButtonPainter

    Protected Overrides Function UpperBrush(ByVal state_1 As State, ByVal bounds As Rectangle) As Brush
        If state_1 = State.Normal Then
            Return New LinearGradientBrush(bounds, Color.FromArgb(&HC8, &HDB, &HEF), Color.FromArgb(&HC6, &HDA, &HF3), LinearGradientMode.Vertical)
        Else
            Return MyBase.UpperBrush(state_1, bounds)
        End If
    End Function

    Protected Overrides Function LowerBrush(ByVal state_1 As State, ByVal bounds As Rectangle) As Brush
        If state_1 = State.Normal Then
            Return New LinearGradientBrush(bounds, Color.FromArgb(&HBD, &HD1, &HEA), Color.FromArgb(&HCE, &HDF, &HF5), LinearGradientMode.Vertical)
        Else
            Return MyBase.LowerBrush(state_1, bounds)
        End If
    End Function
End Class