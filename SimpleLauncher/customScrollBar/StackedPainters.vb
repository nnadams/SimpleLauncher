Imports System.Collections.Generic
Imports System.Text
Imports System.Drawing

Public Class StackedPainters
    Inherits Painter
    Private _painters As List(Of Painter)

    Public Sub New(ByVal ParamArray painters As Painter())
        _painters = New List(Of Painter)(painters)
    End Sub

    Public Overrides Sub Paint(ByVal g As Graphics, ByVal position As Rectangle, ByVal buttonState As Painter.State, ByVal text As String, ByVal buttonImage As Image, ByVal textFont As Font, _
     ByVal referencePosition As System.Nullable(Of Rectangle))

        For Each p As Painter In _painters
            p.Paint(g, position, buttonState, text, buttonImage, textFont, referencePosition)
        Next
    End Sub
End Class