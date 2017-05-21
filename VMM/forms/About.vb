Imports VMM

Public Class About

    Private WithEvents _update_check As New ModManagerUpdateCheck

    Private Sub _update_check_UpdateAvailable(File As ModuleModBrowser.file_info) Handles _update_check.UpdateAvailable
        lbl_update.Visible = True
        lbl_update.Text = String.Format("Update {0} is available.", File.Version)
        btn_update.Visible = True
    End Sub

    Private Sub About_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lbl_version.Text = Version.Current
    End Sub

    Private Sub About_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        lbl_update.Visible = False
        btn_update.Visible = False
        _update_check.CheckForUpdate()
    End Sub
End Class