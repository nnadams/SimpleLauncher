Imports System.Windows.Forms

Public Class diaSettings
    ' TODO Add help tooltips for each item.
    Private helpToolTip As New ToolTip

    Private Sub diaSettings_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        helpToolTip.UseFading = True
    End Sub

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

#Region "Help Texts"
    Private Sub chkEnAuto_HelpRequested(ByVal sender As System.Object, ByVal hlpevent As System.Windows.Forms.HelpEventArgs) Handles chkEnAuto.HelpRequested
        Dim hlpMsg As String = _
        "Automatic Importing allows groups of files to be simply dragged " & _
        "onto the workspace instead of using the default import dialog. " & _
        "When this is done, files are automatically named and aligned " & _
        "to allow for hassle-free importing."

        MsgBox(hlpMsg, MsgBoxStyle.Information)
    End Sub

    Private Sub btnOpen_HelpRequested(ByVal sender As System.Object, ByVal hlpevent As System.Windows.Forms.HelpEventArgs) Handles btnOpen.HelpRequested
        Dim hlpMsg As String = _
        "Browse for the progam that launches the files when the buttons are clicked."

        MsgBox(hlpMsg, MsgBoxStyle.Information)
    End Sub

    Private Sub lblProgram_HelpRequested(ByVal sender As System.Object, ByVal hlpevent As System.Windows.Forms.HelpEventArgs) Handles lblProgram.HelpRequested
        btnOpen_HelpRequested(sender, hlpevent)
    End Sub
#End Region
End Class
