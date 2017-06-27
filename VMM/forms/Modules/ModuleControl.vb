Imports System.IO
Imports System.Xml.Serialization
Imports System.Net

Public Class ModuleControl

    Private exclude_manage As Integer

    Public Event ManageProfiles()
    Public Event SelectProfile(Name As String)
    Public Event InstallFramework()
    Public Event Output(Text As String)

    Public Event OpenAbout()
    Public Event OpenOptions()
    Public Event OpenModFinder()

    ' ##### Events ################################################################################

    Private Sub btn_install_Click(sender As Object, e As EventArgs) Handles btn_install.Click
        RaiseEvent InstallFramework()
    End Sub

    Private Sub btn_launch_Click(sender As Object, e As EventArgs) Handles btn_launch.Click
        VermintideHelper.Launch()
    End Sub

    Private Sub btn_about_Click(sender As Object, e As EventArgs) Handles btn_about.Click
        RaiseEvent OpenAbout()
    End Sub

    Private Sub btn_options_Click(sender As Object, e As EventArgs) Handles btn_options.Click
        RaiseEvent OpenOptions()
    End Sub

    Private Sub btn_find_mods_Click(sender As Object, e As EventArgs)
        RaiseEvent OpenModFinder()
    End Sub

    ' ##### Public ################################################################################

    Public Sub UpdateUI(Args As main.ModuleArgs)
        update_ui(Args.Settings)
    End Sub

    ' ##### Functionality ################################################################################

    Private Sub update_ui(Settings As Settings)
        If Not Settings.Patched Or Not PathHelper.HasFiles(PathHelper.Mods) Then
            btn_install.Text = "Install VMF"
            btn_install.Image = My.Resources.install_16
        Else
            btn_install.Text = "Uninstall VMF"
            btn_install.Image = My.Resources.uninstall_16
        End If
        btn_install.Enabled = PathHelper.HasFiles(PathHelper.Mods)
    End Sub

End Class