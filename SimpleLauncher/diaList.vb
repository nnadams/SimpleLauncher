﻿Imports System.Windows.Forms

Public Class diaList

    Private Sub diaList_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If lvChoosen.Items.Count = 0 Then
            dialogList = New diaList
            Exit Sub
        End If

        If MsgBox("There are still items to import." & vbCrLf & "Would you like to quit anyway?", MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation) = MsgBoxResult.No Then
            e.Cancel = True
        Else
            dialogList = New diaList
        End If
    End Sub
End Class
