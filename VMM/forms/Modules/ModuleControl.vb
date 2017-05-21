Imports System.IO
Imports System.Xml.Serialization
Imports System.Net

Public Class ModuleControl

    Private exclude_manage As Integer

    Public Event ManageProfiles()
    Public Event SelectProfile(Name As String)
    Public Event InstallFramework()
    Public Event Output(Text As String)
    Public Event ShowAbout()
    Public Event ShowOptions()
    Public Event FindMods()

    ' ##### Events ################################################################################

    Private Sub cmb_profiles_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb_profiles.SelectedIndexChanged
        handle_combobox()
    End Sub

    Private Sub btn_install_Click(sender As Object, e As EventArgs) Handles btn_install.Click
        RaiseEvent InstallFramework()
    End Sub

    Private Sub btn_launch_Click(sender As Object, e As EventArgs) Handles btn_launch.Click
        VermintideHelper.Launch()
    End Sub

    Private Sub btn_about_Click(sender As Object, e As EventArgs) Handles btn_about.Click
        RaiseEvent ShowAbout()
    End Sub

    ' ##### Public ################################################################################

    Public Sub UpdateUI(Args As main.ModuleArgs)
        update_ui(Args.Settings)
    End Sub

    Public Sub UpdateProfiles(Args As main.ModuleArgs)
        list_profiles(Args.Profiles)
        cmb_profiles.SelectedItem = Args.SelectedProfile.Name
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
        cmb_profiles.Enabled = Settings.Patched And PathHelper.HasFiles(PathHelper.Mods)
    End Sub

    Private Sub list_profiles(Profiles As List(Of VermintideProfile))
        cmb_profiles.Items.Clear()
        cmb_profiles.Items.Add("[Manage]")
        For Each p As VermintideProfile In Profiles
            cmb_profiles.Items.Add(p.Name)
        Next
    End Sub

    Private Sub handle_combobox()
        If cmb_profiles.SelectedIndex = 0 Then
            cmb_profiles.SelectedIndex = exclude_manage
            RaiseEvent ManageProfiles()
        Else
            exclude_manage = cmb_profiles.SelectedIndex
            RaiseEvent SelectProfile(cmb_profiles.Items(cmb_profiles.SelectedIndex))
        End If
    End Sub

    Private Sub btn_options_Click(sender As Object, e As EventArgs) Handles btn_options.Click
        RaiseEvent ShowOptions()
    End Sub

    Private Sub btn_find_mods_Click(sender As Object, e As EventArgs) Handles btn_find_mods.Click
        'RaiseEvent FindMods()
    End Sub

End Class