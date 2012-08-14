Imports System.Collections.Generic
Imports System.Text
Imports System.Drawing

Public Class PainterFilterNoText
    Inherits Painter

    Private _subPainter As Painter

    Public Sub New(ByVal p As Painter)
        _subPainter = p
    End Sub

    Public Overrides Sub Paint(ByVal g As Graphics, ByVal position As Rectangle, ByVal buttonState As Painter.State, ByVal text As String, ByVal buttonImage As Image, ByVal textFont As Font, _
     ByVal referencePosition As System.Nullable(Of Rectangle))
        _subPainter.Paint(g, position, buttonState, "", buttonImage, textFont, referencePosition)
    End Sub
End Class