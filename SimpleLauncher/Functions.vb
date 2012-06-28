Imports System.Text.RegularExpressions

Module Functions
    Public dialogSettings As New diaSettings
    Public dialogAdd As New diaAdd
    Public dialogList As New diaList

    Public frmMainLocked As Boolean = False
    Public lastPoint As Point = New Point(-1, -1)
    Public lastSize As Size = New Size(-1, -1)
    Public Const buttonPadding As Integer = 10

    Public Function GetNewLocation(ByVal lastLoc As Point, ByVal lastSize As Size, ByVal newSize As Size, ByVal boxSize As Size) As Point
        Dim nextRightEdge As Integer = lastLoc.X + lastSize.Width + buttonPadding + newSize.Width
        Dim nextLowerEdge As Integer = lastLoc.Y + lastSize.Height + buttonPadding + newSize.Height

        If nextRightEdge <= boxSize.Width Then
            If lastLoc = (New Point(-1, -1)) Then Return New Point(2, 2)
            Return New Point(lastLoc.X + lastSize.Width + buttonPadding, lastLoc.Y)
        Else
            If nextLowerEdge <= boxSize.Height And (2 + newSize.Width) <= boxSize.Width Then
                Return New Point(2, lastLoc.Y + lastSize.Height + buttonPadding)
            Else
                Return New Point(-1, -1)
            End If
        End If
    End Function

    Public Function createButton(ByRef contextmenu As ContextMenuStrip, Optional ByVal path As String = "") As Button
        Dim newButton As New Button
        newButton.AutoSize = True
        newButton.Text = RemovePath(path)
        newButton.ContextMenuStrip = contextmenu
        newButton.Tag = path
        newButton.FlatStyle = FlatStyle.Popup
        newButton.BackColor = Color.FromArgb(120, 120, 190)
        newButton.ForeColor = Color.White

        AddHandler newButton.MouseDown, AddressOf Button_MouseDown
        Return newButton
    End Function

    Public Sub Button_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        Dim activeButton As New Button
        activeButton = sender

        If frmMainLocked And e.Button = Windows.Forms.MouseButtons.Left Then
            If activeButton.Tag = "" Then
                MsgBox("There was an error accessing data. Please remove and reimport this file.", MsgBoxStyle.Critical)
            ElseIf dialogSettings.openDialog.FileName = "" Then
                MsgBox("Please choose an application to launch with.", MsgBoxStyle.Exclamation)
            Else
                Process.Start(dialogSettings.openDialog.FileName, Chr(34) & activeButton.Tag & Chr(34))
            End If
        End If
    End Sub

    Public Function RemovePath(ByVal Path As String) As String
        Path = Regex.Replace(Path, ".*\\", "")
        Return Path
    End Function
End Module
