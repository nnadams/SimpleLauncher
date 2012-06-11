﻿Imports System.Windows.Forms

Public Class diaSettings
    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub btnOpen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOpen.Click
        openDialog.ShowDialog()
    End Sub

    Private Sub chkEnAuto_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkEnAuto.CheckedChanged
        If chkEnAuto.Checked Then
            gbAuto.Enabled = True
        Else
            gbAuto.Enabled = False
        End If
    End Sub
End Class
