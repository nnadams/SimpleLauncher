Imports System.Text
Imports System.Xml

Module XMLFiles
    Public Function loadSaveFile(ByRef window As Control, ByVal file As String) As String
        On Error Resume Next

        Dim projectName As String = "Untitled"
        Dim xmlFile As New XmlDocument
        xmlFile.Load(file)
        Dim mainNode As XmlNodeList = xmlFile.SelectNodes("Project")

        If Not handleVersion(mainNode) Then Return projectName

        projectName = mainNode.Item(0).Attributes(0).InnerText
        loadSettings(mainNode)

        For i As Short = 1 To mainNode.Item(0).ChildNodes.Count - 1
            Dim newButton As New Button
            newButton = createButton(frmMain.csButtons)
            newButton.Text = mainNode.Item(0).ChildNodes.Item(i).ChildNodes.Item(0).InnerText
            newButton.Tag = mainNode.Item(0).ChildNodes.Item(i).ChildNodes.Item(1).InnerText & "|"
            newButton.ForeColor = HexToColor(mainNode.Item(0).ChildNodes.Item(i).ChildNodes.Item(2).InnerText)
            newButton.BackColor = HexToColor(mainNode.Item(0).ChildNodes.Item(i).ChildNodes.Item(3).InnerText)
            window.Controls.Add(newButton)
            newButton.Location = New Point(mainNode.Item(0).ChildNodes.Item(i).ChildNodes.Item(4).InnerText, mainNode.Item(0).ChildNodes.Item(i).ChildNodes.Item(5).InnerText)
            newButton.Size = New Size(mainNode.Item(0).ChildNodes.Item(i).ChildNodes.Item(6).InnerText, mainNode.Item(0).ChildNodes.Item(i).ChildNodes.Item(7).InnerText)
            newButton.Visible = CBool(mainNode.Item(0).ChildNodes.Item(i).ChildNodes.Item(8).InnerText)

            If mainNode.Item(0).ChildNodes.Item(i).ChildNodes.Item(9).InnerText = "" Then

            Else
                newButton.Tag += mainNode.Item(0).ChildNodes.Item(i).ChildNodes.Item(9).InnerText
            End If

            frmMain.tmpControl = New MagicControl(newButton)
        Next
        Return projectName
    End Function

    Private Function handleVersion(ByVal mainNode As XmlNodeList) As Boolean
        Dim filesVersion As String = mainNode.Item(0).Attributes(1).InnerText
        Dim currentVersion As String = My.Application.Info.Version.Major & "." & My.Application.Info.Version.Minor

        If filesVersion <> currentVersion Then
            If MsgBox("A different version of Enid was used to create this save file. Would you like to attempt to load it?", MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation) = MsgBoxResult.No Then
                Return False
            End If
        End If

        Return True
    End Function

    Private Sub loadSettings(ByVal mainNode As XmlNodeList)
        On Error Resume Next

        Dim settingsNode As XmlNode = mainNode.Item(0).ChildNodes.Item(0)
        dialogSettings.chkEnAuto.Checked = CBool(settingsNode.ChildNodes.Item(0).InnerText)
        dialogSettings.numCols.Value = CDec(settingsNode.ChildNodes.Item(1).InnerText)
        dialogSettings.numRows.Value = CDec(settingsNode.ChildNodes.Item(2).InnerText)
        dialogSettings.openDialog.FileName = settingsNode.ChildNodes.Item(3).InnerText
        frmMain.Width = CInt(settingsNode.ChildNodes.Item(4).InnerText)
        frmMain.Height = CInt(settingsNode.ChildNodes.Item(5).InnerText)
        lastPoint.X = CInt(settingsNode.ChildNodes.Item(6).InnerText)
        lastPoint.Y = CInt(settingsNode.ChildNodes.Item(7).InnerText)
        lastSize.Width = CInt(settingsNode.ChildNodes.Item(8).InnerText)
        lastSize.Height = CInt(settingsNode.ChildNodes.Item(9).InnerText)
    End Sub

    Public Function writeSaveFile(ByRef window As Control, ByVal file As String, Optional ByVal name As String = "Untitled") As Boolean
        Try
            Dim xmlWriter As New XmlTextWriter(file, Encoding.UTF8)
            xmlWriter.Formatting = Formatting.Indented
            xmlWriter.IndentChar = vbTab
            xmlWriter.Indentation = 1

            xmlWriter.WriteStartDocument(True)
            xmlWriter.WriteStartElement("Project")
            writeProjectAttributes(xmlWriter, name)

            writeSettings(xmlWriter)

            For Each btn As Button In window.Controls
                writeButtonNode(xmlWriter, btn)
            Next

            xmlWriter.WriteEndElement()
            xmlWriter.WriteEndDocument()
            xmlWriter.Close()
            Return True
        Catch
            Return False
        End Try
    End Function

    Private Sub writeSettings(ByVal xmlWriter As XmlTextWriter)
        xmlWriter.WriteStartElement("Settings")

        xmlWriter.WriteStartElement("canAutoImport")
        xmlWriter.WriteString(dialogSettings.chkEnAuto.Checked.ToString)
        xmlWriter.WriteEndElement()
        xmlWriter.WriteStartElement("AutoImportColumns")
        xmlWriter.WriteString(dialogSettings.numCols.Value)
        xmlWriter.WriteEndElement()
        xmlWriter.WriteStartElement("AutoImportRows")
        xmlWriter.WriteString(dialogSettings.numRows.Value)
        xmlWriter.WriteEndElement()
        xmlWriter.WriteStartElement("DefaultProgram")
        xmlWriter.WriteString(dialogSettings.openDialog.FileName)
        xmlWriter.WriteEndElement()
        xmlWriter.WriteStartElement("WindowWidth")
        xmlWriter.WriteString(frmMain.Width)
        xmlWriter.WriteEndElement()
        xmlWriter.WriteStartElement("WindowHeight")
        xmlWriter.WriteString(frmMain.Height)
        xmlWriter.WriteEndElement()
        xmlWriter.WriteStartElement("lastX")
        xmlWriter.WriteString(lastPoint.X)
        xmlWriter.WriteEndElement()
        xmlWriter.WriteStartElement("lastY")
        xmlWriter.WriteString(lastPoint.Y)
        xmlWriter.WriteEndElement()
        xmlWriter.WriteStartElement("lastWidth")
        xmlWriter.WriteString(lastSize.Width)
        xmlWriter.WriteEndElement()
        xmlWriter.WriteStartElement("lastHeight")
        xmlWriter.WriteString(lastSize.Height)
        xmlWriter.WriteEndElement()

        xmlWriter.WriteEndElement()
    End Sub

    Private Sub writeButtonNode(ByVal xmlWriter As XmlTextWriter, ByVal button As Button)
        xmlWriter.WriteStartElement("Button")

        xmlWriter.WriteStartElement("Text")
        xmlWriter.WriteString(button.Text)
        xmlWriter.WriteEndElement()
        xmlWriter.WriteStartElement("Path")
        xmlWriter.WriteString(Split(button.Tag, "|")(0))
        xmlWriter.WriteEndElement()
        xmlWriter.WriteStartElement("TextColor")
        xmlWriter.WriteString(ColorToHex(button.ForeColor))
        xmlWriter.WriteEndElement()
        xmlWriter.WriteStartElement("BackColor")
        xmlWriter.WriteString(ColorToHex(button.BackColor))
        xmlWriter.WriteEndElement()
        xmlWriter.WriteStartElement("X")
        xmlWriter.WriteString(button.Location.X.ToString)
        xmlWriter.WriteEndElement()
        xmlWriter.WriteStartElement("Y")
        xmlWriter.WriteString(button.Location.Y.ToString)
        xmlWriter.WriteEndElement()
        xmlWriter.WriteStartElement("Width")
        xmlWriter.WriteString(button.Size.Width)
        xmlWriter.WriteEndElement()
        xmlWriter.WriteStartElement("Height")
        xmlWriter.WriteString(button.Size.Height)
        xmlWriter.WriteEndElement()
        xmlWriter.WriteStartElement("Visible")
        xmlWriter.WriteString(button.Visible.ToString)
        xmlWriter.WriteEndElement()
        xmlWriter.WriteStartElement("Program")
        xmlWriter.WriteString(Split(button.Tag, "|")(1))
        xmlWriter.WriteEndElement()

        xmlWriter.WriteEndElement()
    End Sub

    Private Sub writeProjectAttributes(ByVal xmlWriter As XmlTextWriter, ByVal name As String)
        xmlWriter.WriteStartAttribute("name")
        xmlWriter.WriteString(name)
        xmlWriter.WriteEndAttribute()

        xmlWriter.WriteStartAttribute("version")
        xmlWriter.WriteString(My.Application.Info.Version.Major & "." & My.Application.Info.Version.Minor)
        xmlWriter.WriteEndAttribute()
    End Sub
End Module
