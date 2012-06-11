Imports System.Windows.Forms

Public Class diaList

    Private Sub diaList_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If lvChoosen.Items.Count = 0 Then Exit Sub
        If MsgBox("There are still items to import." & vbCrLf & "Would you like to quit anyway?", MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation) = MsgBoxResult.No Then
            e.Cancel = True
        End If
    End Sub
End Class
