Imports VMM

Public Class About

    Private WithEvents _update_check As New ModManagerUpdateCheck

    Private Sub _update_check_NoUpdate() Handles _update_check.NoUpdate
        lbl_up_to_date.Visible = True
        lbl_checking_update.Visible = False
        pb_up_to_date.Visible = True
    End Sub

    Private Sub _update_check_UpdateAvailable(File As FileInfo) Handles _update_check.UpdateAvailable
        lbl_update.Visible = True
        lbl_update.Text = String.Format("Update {0} is available.", File.Version)
        btn_update.Visible = True
        lbl_checking_update.Visible = False
    End Sub

    Private Sub About_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lbl_version.Text = Version.Current
    End Sub

    Private Sub About_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        lbl_update.Visible = False
        btn_update.Visible = False
        lbl_checking_update.Visible = True
        pb_up_to_date.Visible = False
        lbl_up_to_date.Visible = False
        _update_check.CheckForUpdate()
    End Sub
End Class