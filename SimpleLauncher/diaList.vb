Imports System.Windows.Forms

Public Class diaList

    Private Sub diaList_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If lvChoosen.Items.Count = 0 Then
            dialogList = New diaList
            frmMain.splitMain.Panel1.Cursor = Cursors.Default
            Exit Sub
        End If

        If MsgBox("There are still items to import." & vbCrLf & "Would you like to quit anyway?", MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation) = MsgBoxResult.No Then
            e.Cancel = True
        Else
            frmMain.splitMain.Panel1.Cursor = Cursors.Default
            dialogList = New diaList
        End If
    End Sub
End Class
