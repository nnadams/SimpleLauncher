Imports System.Text.RegularExpressions
Imports System.Runtime.InteropServices

Module Functions
    Public dialogSettings As New diaSettings
    Public dialogAdd As New diaAdd
    Public dialogList As New diaList

    Public curProject As _project
    Public frmMainLocked As Boolean = False
    Public lastPoint As Point = New Point(-1, -1)
    Public lastSize As Size = New Size(-1, -1)

    Public Const defaultName As String = "Untitled"
    Public Const xStartDist As Integer = 2
    Public Const yStartDist As Integer = 2
    Public Const buttonPadding As Integer = 10

    Public videoExtensions() As String = {"3gp", "3gp2", "avi", "divx", "f4v", "flv", "m2p", "m4v", "mkv", "mov", "mp4", "mpeg", "mpg", "mts", "ogm", "ogv", "rm", "rmvb", "swf", "vob", "webm", "wmv", "xvid"}
    Public audioExtensions() As String = {"3ga", "flac", "m3u", "m4a", "mid", "midi", "mka", "mp2", "mp3", "mpa", "oga", "ogg", "pls", "ra", "wav", "wma"}
    Public imageExtensions() As String = {"bmp", "dds", "dib", "gif", "jpeg", "jpg", "png", "psd", "ps", "svg", "tga", "tiff", "tif", "xcf"}
    Public progrExtensions() As String = {"com", "exe", "jar", "vbs", "wsf"}

    Public Structure _project
        Public Name As String
        Public Path As String
        Public isOpened As Boolean
    End Structure

    <DllImport("user32.dll")> Public Function LockWindowUpdate(ByVal hWndLock As IntPtr) As Boolean
    End Function

    Public Sub SaveSettings()
        My.Settings.formSize = frmMain.Size
        My.Settings.defaultProgram = dialogSettings.openDialog.FileName
        My.Settings.Save()
    End Sub

    Public Sub LoadSettings()
        frmMain.Size = My.Settings.formSize
        dialogSettings.openDialog.FileName = My.Settings.defaultProgram
    End Sub

    Public Function GetFileType(ByVal name As String) As String
        Dim theExtension As String = Mid(name, InStrRev(name, ".") + 1).ToLower
        For Each ext As String In videoExtensions
            If theExtension = ext Then Return "film"
        Next
        For Each ext As String In audioExtensions
            If theExtension = ext Then Return "music"
        Next
        For Each ext As String In progrExtensions
            If theExtension = ext Then Return "terminal"
        Next
        For Each ext As String In imageExtensions
            If theExtension = ext Then Return "photo"
        Next
        Return "default"
    End Function

    Public Function GetNewLocation(ByVal lastLoc As Point, ByVal lastSize As Size, ByVal newSize As Size, ByVal clientSize As Size) As Point
        Dim nextRightEdge As Integer = lastLoc.X + lastSize.Width + buttonPadding + newSize.Width
        Dim nextLowerEdge As Integer = lastLoc.Y + lastSize.Height + buttonPadding + newSize.Height

        If nextRightEdge <= clientSize.Width Then
            If lastLoc = (New Point(-1, -1)) Then Return New Point(xStartDist, yStartDist)
            If lastSize = (New Size(-1, -1)) Then Return New Point(lastLoc.X - (newSize.Width / 1.5), lastLoc.Y - (newSize.Height * 2))
            Return New Point(lastLoc.X + lastSize.Width + buttonPadding, lastLoc.Y)
        Else
            If nextLowerEdge <= clientSize.Height And (xStartDist + newSize.Width) <= clientSize.Width Then
                Return New Point(xStartDist, lastLoc.Y + lastSize.Height + buttonPadding)
            Else
                Return New Point(-1, -1)
            End If
        End If
    End Function

    Public Function createButton(ByRef contextmenu As ContextMenuStrip, Optional ByVal path As String = "") As Button
        Dim newButton As New Button
        newButton.AutoSize = True
        newButton.MinimumSize = New Size(23, 23)
        newButton.Text = RemovePath(path)
        newButton.ContextMenuStrip = contextmenu
        newButton.Tag = path & "|" & IIf(GetFileType(RemovePath(path)) = "terminal", "", dialogSettings.openDialog.FileName) & "|True"
        newButton.FlatStyle = FlatStyle.Popup
        newButton.BackColor = Color.FromArgb(120, 120, 190)
        newButton.ForeColor = Color.White
        newButton.Visible = True

        AddHandler newButton.MouseDown, AddressOf frmMain.Button_MouseDown
        AddHandler newButton.Resize, AddressOf frmMain.Button_Reize
        AddHandler newButton.Move, AddressOf frmMain.Button_Move

        Return newButton
    End Function

    Public Function HexToColor(ByVal color As String) As Color
        On Error GoTo erro

        Dim R As Long = CLng("&H" & Left(color, 2))
        Dim G As Long = CLng("&H" & Mid(color, 3, 2))
        Dim B As Long = CLng("&H" & Right(color, 2))
        Return Drawing.Color.FromArgb(R, G, B)

erro:
        Return Drawing.Color.Transparent
    End Function

    Public Function ColorToHex(ByVal color As Color) As String
        Return Hex(color.R) & Hex(color.G) & Hex(color.B)
    End Function

    Public Function RemoveFile(ByVal Path As String) As String
        If Path = "" Then
            Return ""
        Else
            Return Path.Replace(RemovePath(Path), "")
        End If
    End Function

    Public Function RemovePath(ByVal Path As String) As String
        Return Regex.Replace(Path, ".*\\", "")
    End Function
End Module
