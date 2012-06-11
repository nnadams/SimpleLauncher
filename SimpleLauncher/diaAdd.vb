Imports System.Windows.Forms

Public Class diaAdd

    Private nextState As CheckState = CheckState.Indeterminate

    Private Sub btnImport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImport.Click
        If rbtnGrid.Checked Then
            Dim tableLoc As New Point(0, 0)
            Dim oldButton As Button = New Button()
            For Each item As ListViewItem In lvMain.CheckedItems

                Dim label As String = item.Text
                Dim path As String = item.SubItems.Item(1).Text

                If My.Computer.FileSystem.FileExists(path) Then
                    Dim newButton As New Button

                    newButton.Tag = path
                    newButton.Text = label
                    newButton.ContextMenuStrip = frmMain.csButtons
                    newButton.Width = GetWidth(label)
                    newButton.Location = GetNextLocation(frmMain.lastPoint, tableLoc, numCols.Value, numRows.Value, oldButton.Width + 10, oldButton.Height + 10)
                    frmMain.lastPoint = newButton.Location

                    AddHandler newButton.MouseDown, AddressOf frmMain.Button_MouseDown
                    frmMain.Controls.Add(newButton)
                    frmMain.tmpControl = New MagicControl(newButton)
                    oldButton = newButton
                Else
                    MsgBox("Skipping the adding of" & vbCrLf & "'" & label & "'" & vbCrLf & "because it could not be found!", MsgBoxStyle.Exclamation)
                End If
                pbarImport.Value = IIf(pbarImport.Value + (100 / lvMain.CheckedItems.Count) > 100, 100, pbarImport.Value + (100 / lvMain.CheckedItems.Count))
            Next
            lvMain.Items.Clear()
            lblCount.Text = ""
            numCols.Value = 10
            numRows.Value = 10
            pbarImport.Value = 0

            Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Me.Close()
        ElseIf rbtnManual.Checked Then
            Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Me.Hide()

            frmMain.Cursor = Cursors.Cross

            dialogList.Location = New Point(frmMain.Location.X + frmMain.Width + 5, frmMain.Location.Y + 5)
            dialogList.Show(frmMain)
            For Each item As ListViewItem In lvMain.CheckedItems
                Dim label As String = item.Text
                Dim path As String = item.SubItems.Item(1).Text
                Dim newItem As New ListViewItem(label)

                newItem.Tag = path
                dialogList.lvChoosen.Items.Add(newItem)
            Next
            dialogList.lvChoosen.Items(0).Selected = True
            lvMain.Items.Clear()
            lblCount.Text = ""
            numCols.Value = 10
            numRows.Value = 10
            pbarImport.Value = 0

            frmMain.Focus()
            Me.Close()
        End If
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        lvMain.Items.Clear()
        lblCount.Text = ""
        numCols.Value = 10
        numRows.Value = 10
        pbarImport.Value = 0

        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub lvMain_AfterLabelEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.LabelEditEventArgs) Handles lvMain.AfterLabelEdit
        If e.Label = "" Then
            e.CancelEdit = True
        End If
    End Sub

    Private Sub lvMain_DragDrop(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles lvMain.DragDrop
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            Dim filePaths As String() = CType(e.Data.GetData(DataFormats.FileDrop), String())
            For Each file In filePaths
                Dim lvItem As New ListViewItem(RemovePath(file))
                lvItem.SubItems.Add(file)
                lvItem.Checked = True
                lvMain.Items.Add(lvItem)
            Next
            numRows_ValueChanged(sender, e)
            UpdateLabel()
        End If
    End Sub

    Private Sub lvMain_DragEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles lvMain.DragEnter
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            e.Effect = DragDropEffects.Copy
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub

    Private Sub rbtnGrid_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtnGrid.CheckedChanged
        gbGrid.Enabled = rbtnGrid.Checked
    End Sub

    Private Sub btnSelectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelectAll.Click
        For Each item As ListViewItem In lvMain.Items
            item.Checked = True
        Next
    End Sub

    Private Sub btnSelectNone_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelectNone.Click
        For Each item As ListViewItem In lvMain.Items
            item.Checked = False
        Next
    End Sub

    Private Sub btnOpen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOpen.Click
        If openDialog.ShowDialog() = DialogResult.OK Then
            For Each file In openDialog.FileNames
                Dim lvItem As New ListViewItem(RemovePath(file))
                lvItem.SubItems.Add(file)
                lvItem.Checked = True
                lvMain.Items.Add(lvItem)
            Next
            UpdateLabel()
            numRows_ValueChanged(sender, e)
        End If
    End Sub

    Private Sub btnRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemove.Click
        If MsgBox("Are you sure you want to remove " & lvMain.SelectedItems.Count.ToString & " items?", MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation) = MsgBoxResult.Yes Then
            For Each item As ListViewItem In lvMain.SelectedItems
                lvMain.Items.Remove(item)
            Next
            UpdateLabel()
        End If
    End Sub

    Private Sub numCols_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles numCols.ValueChanged
        Dim realItems As Integer = lvMain.CheckedItems.Count
        Select Case nextState
            Case CheckState.Checked
                realItems += 1
            Case CheckState.Unchecked
                realItems -= 1
        End Select

        Do While (numCols.Value * numRows.Value) < realItems
            numCols.Value = Math.Floor(Math.Sqrt(realItems))
            If (numCols.Value * numRows.Value) >= realItems Then Exit Do
            numRows.Value = Math.Ceiling(Math.Sqrt(realItems))
            If (numCols.Value * numRows.Value) < realItems Then
                numRows.Value += 1
            End If
        Loop
        nextState = CheckState.Indeterminate
    End Sub

    Private Sub numRows_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles numRows.ValueChanged
        Dim realItems As Integer = lvMain.CheckedItems.Count
        Select Case nextState
            Case CheckState.Checked
                realItems += 1
            Case CheckState.Unchecked
                realItems -= 1
        End Select

        Do While (numCols.Value * numRows.Value) < realItems
            numRows.Value = Math.Floor(Math.Sqrt(realItems))
            If (numCols.Value * numRows.Value) >= realItems Then Exit Do
            numCols.Value = Math.Ceiling(Math.Sqrt(realItems))
            If (numCols.Value * numRows.Value) < realItems Then
                numCols.Value += 1
            End If
        Loop
        nextState = CheckState.Indeterminate
    End Sub

    Private Sub lvMain_ItemCheck(ByVal sender As Object, ByVal e As System.Windows.Forms.ItemCheckEventArgs) Handles lvMain.ItemCheck
        nextState = e.NewValue
        UpdateLabel()
        numRows_ValueChanged(sender, e)
    End Sub

    Private Sub UpdateLabel()
        Dim totalItems As Integer = lvMain.Items.Count
        Dim realItems As Integer = lvMain.CheckedItems.Count
        Select Case nextState
            Case CheckState.Checked
                realItems += 1
            Case CheckState.Unchecked
                realItems -= 1
        End Select
        lblCount.Text = IIf(totalItems > 0, realItems.ToString & "/" & totalItems.ToString, "")
    End Sub
End Class
