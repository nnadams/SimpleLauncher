Imports System.Text
Imports System.Xml

Module XMLFiles
    Public Sub loadSaveFile(ByRef tabControl As customTabControl, ByVal file As String)
        On Error Resume Next

        Dim xmlFile As New XmlDocument
        xmlFile.Load(file)
        Dim mainNode As XmlNodeList = xmlFile.SelectNodes("Enid")

        If Not handleVersion(mainNode) Then Exit Sub

        For i As Short = 0 To mainNode.Item(0).ChildNodes.Count - 1
            'If i = 1 Then
            '    tabControl.SelectedIndex = 1
            '    tabControl.SelectedTab.Text = mainNode.Item(0).ChildNodes(i).Attributes(0).InnerText
            'Else
            Dim newTabPage As New TabPage(mainNode.Item(0).ChildNodes(i).Attributes(0).InnerText)
            newTabPage.BackColor = Color.FromArgb(255, 60, 70, 75)
            newTabPage.BorderStyle = BorderStyle.None
            tabControl.TabPages.Add(newTabPage)
            tabControl.SelectedIndex = tabControl.TabPages.Count - 1
            'End If

            For j As Short = 0 To mainNode.Item(0).ChildNodes(i).ChildNodes.Count - 1
                Dim newButton As New Button
                With mainNode.Item(0).ChildNodes.Item(i).ChildNodes.Item(j).ChildNodes
                    newButton = createButton(frmMain.csButtons)
                    newButton.Text = .Item(0).InnerText
                    newButton.Tag = .Item(1).InnerText & "|"
                    newButton.ForeColor = HexToColor(.Item(2).InnerText)
                    newButton.BackColor = HexToColor(.Item(3).InnerText)
                    tabControl.SelectedTab.Controls.Add(newButton)

                    newButton.Location = New Point(.Item(4).InnerText, .Item(5).InnerText)
                    newButton.Size = New Size(.Item(6).InnerText, .Item(7).InnerText)

                    newButton.Tag += .Item(9).InnerText & "|"
                    newButton.Tag += .Item(8).InnerText

                    frmMain.tmpControl = New MagicControl(newButton)
                End With
            Next
        Next
    End Sub

    Private Function handleVersion(ByVal mainNode As XmlNodeList) As Boolean
        Dim filesVersion As String = mainNode.Item(0).Attributes(0).InnerText
        Dim currentVersion As String = My.Application.Info.Version.Major & "." & My.Application.Info.Version.Minor

        If filesVersion <> currentVersion Then
            If MsgBox("A different version of Enid was used to create this save file. Would you like to attempt to load it?", MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation) = MsgBoxResult.No Then
                Return False
            End If
        End If

        Return True
    End Function

    Public Function writeSaveFile(ByRef tabControl As customTabControl, ByVal file As String) As Boolean
        Try
            Dim xmlWriter As New XmlTextWriter(file, Encoding.UTF8)
            xmlWriter.Formatting = Formatting.Indented
            xmlWriter.IndentChar = vbTab
            xmlWriter.Indentation = 1

            xmlWriter.WriteStartDocument(True)
            xmlWriter.WriteStartElement("Enid")
            writeVersion(xmlWriter)

            For Each tp As TabPage In tabControl.TabPages
                If tp.Text = "Start Page" Then Continue For
                xmlWriter.WriteStartElement("Project")
                xmlWriter.WriteStartAttribute("name")
                xmlWriter.WriteString(tp.Text)
                xmlWriter.WriteEndAttribute()

                For Each btn As Button In tp.Controls
                    writeButtonNode(xmlWriter, btn)
                Next
                xmlWriter.WriteEndElement()
            Next

            xmlWriter.WriteEndElement()
            xmlWriter.WriteEndDocument()
            xmlWriter.Close()
            Return True
        Catch
            Return False
        End Try
    End Function

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
        xmlWriter.WriteString(Split(button.Tag, "|")(2))
        xmlWriter.WriteEndElement()
        xmlWriter.WriteStartElement("Program")
        xmlWriter.WriteString(Split(button.Tag, "|")(1))
        xmlWriter.WriteEndElement()

        xmlWriter.WriteEndElement()
    End Sub

    Private Sub writeVersion(ByVal xmlWriter As XmlTextWriter)
        xmlWriter.WriteStartAttribute("version")
        xmlWriter.WriteString(My.Application.Info.Version.Major & "." & My.Application.Info.Version.Minor)
        xmlWriter.WriteEndAttribute()
    End Sub
End Module
