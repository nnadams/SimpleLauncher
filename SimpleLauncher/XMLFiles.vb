Imports System.Text
Imports System.Xml

Module XMLFiles
    Public Function loadData(ByRef window As Control, ByVal file As String) As String
        On Error Resume Next

        Dim projectName As String = "Untitled"
        Dim xmlFile As New XmlDocument
        xmlFile.Load(file)
        Dim mainNode As System.Xml.XmlNodeList = xmlFile.SelectNodes("Project")
        projectName = mainNode.Item(0).Attributes(0).InnerText

        For i As Short = 0 To mainNode.Item(0).ChildNodes.Count - 1
            Dim newButton As New Button
            newButton = createButton(frmMain.csButtons)
            newButton.Text = mainNode.Item(0).ChildNodes.Item(i).ChildNodes.Item(0).InnerText
            newButton.Tag = mainNode.Item(0).ChildNodes.Item(i).ChildNodes.Item(1).InnerText
            newButton.ForeColor = HexToColor(mainNode.Item(0).ChildNodes.Item(i).ChildNodes.Item(2).InnerText)
            newButton.BackColor = HexToColor(mainNode.Item(0).ChildNodes.Item(i).ChildNodes.Item(3).InnerText)
            window.Controls.Add(newButton)
            newButton.Location = New Point(mainNode.Item(0).ChildNodes.Item(i).ChildNodes.Item(4).InnerText, mainNode.Item(0).ChildNodes.Item(i).ChildNodes.Item(5).InnerText)
            newButton.Size = New Size(mainNode.Item(0).ChildNodes.Item(i).ChildNodes.Item(6).InnerText, mainNode.Item(0).ChildNodes.Item(i).ChildNodes.Item(7).InnerText)
            newButton.Visible = CBool(mainNode.Item(0).ChildNodes.Item(i).ChildNodes.Item(8).InnerText)
            frmMain.tmpControl = New MagicControl(newButton)
        Next
        Return projectName
    End Function

    Public Function writeSaveFile(ByRef window As Control, ByVal file As String, Optional ByVal name As String = "Untitled") As Boolean
        Try
            Dim xmlWriter As New XmlTextWriter(file, Encoding.UTF8)
            xmlWriter.Formatting = Formatting.Indented
            xmlWriter.IndentChar = vbTab
            xmlWriter.Indentation = 1

            xmlWriter.WriteStartDocument(True)
            xmlWriter.WriteStartElement("Project")
            WriteProjectAttributes(xmlWriter, name)

            For Each btn As Button In window.Controls
                createButtonNode(xmlWriter, btn)
            Next

            xmlWriter.WriteEndElement()
            xmlWriter.WriteEndDocument()
            xmlWriter.Close()
            Return True
        Catch
            Return False
        End Try
    End Function

    Private Sub createButtonNode(ByVal xmlWriter As XmlTextWriter, ByVal button As Button)
        xmlWriter.WriteStartElement("Button")

        xmlWriter.WriteStartElement("Text")
        xmlWriter.WriteString(button.Text)
        xmlWriter.WriteEndElement()
        xmlWriter.WriteStartElement("Path")
        xmlWriter.WriteString(button.Tag)
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

        xmlWriter.WriteEndElement()
    End Sub

    Private Sub WriteProjectAttributes(ByVal xmlWriter As XmlTextWriter, ByVal name As String)
        xmlWriter.WriteStartAttribute("name")
        xmlWriter.WriteString(name)
        xmlWriter.WriteEndAttribute()

        xmlWriter.WriteStartAttribute("version")
        xmlWriter.WriteString(My.Application.Info.Version.Major & "." & My.Application.Info.Version.Minor)
        xmlWriter.WriteEndAttribute()
    End Sub
End Module
