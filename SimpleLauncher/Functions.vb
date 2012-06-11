Imports System.Text.RegularExpressions

Module Functions
    Public dialogSettings As New diaSettings
    Public dialogAdd As New diaAdd
    Public dialogList As New diaList

    Public Function GetWidth(ByVal text As String) As Integer
        Dim width As Integer = 75
        If Len(text) <= 10 Then
            Return width
        Else
            Return width + (Len(text) - 10) * 5
        End If
    End Function

    Public Function GetNextLocation(ByVal curLoc As Point, ByRef tableLoc As Point, ByVal cols As Integer, ByVal rows As Integer, ByVal width As Integer, ByVal height As Integer) As Point
        Dim x As Integer = curLoc.X
        Dim y As Integer = curLoc.Y

        If x = -1 And y = -1 Then
            Return New Point(0, 25)
        Else
            If tableLoc.X < cols Then
                tableLoc.X += 1
                Return New Point(curLoc.X + width, curLoc.Y)
            ElseIf tableLoc.X = cols And tableLoc.Y < rows Then
                tableLoc.X = 0
                tableLoc.Y += 1
                Return New Point(0, curLoc.Y + height)
            End If
        End If
    End Function

    Public Function GetNextFixedLocation(ByVal curLoc As Point, ByVal cols As Integer, ByVal rows As Integer, ByVal width As Integer, ByVal height As Integer) As Point
        Dim x As Integer = curLoc.X
        Dim y As Integer = curLoc.Y

        If x = -1 And y = -1 Then
            Return New Point(0, 25)
        Else
            Return New Point((x + width) Mod (width * cols), IIf((x + width) = (width * cols), (y + height) Mod (height * rows), y))
        End If
    End Function

    Public Function RemovePath(ByVal Path As String) As String
        Path = Regex.Replace(Path, ".*\\", "")
        Return Path
    End Function
End Module
