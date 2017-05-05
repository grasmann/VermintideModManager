Imports System.IO
Imports System.Xml.Serialization

Public Class Controls

    Private _profiles As List(Of VermintideProfile)
    Private _settings As Settings

    Public Event ReloadProfiles()
    Public Event ManageProfiles()
    Public Event SelectedProfile(Profile As VermintideProfile)
    Public Event SaveProfile()
    Public Event SaveSettings()
    Public Event InstallFramework()
    Public Event Output(Text As String)
    Public Event ShowAbout()

    ' ##### Events ################################################################################

    Public Sub New(Profiles As List(Of VermintideProfile), Settings As Settings)
        InitializeComponent()
        _profiles = Profiles
        _settings = Settings
    End Sub

    Private Sub Controls_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        UpdateProfiles()
    End Sub

    Private exclude_manage As Integer
    Private Sub cmb_profiles_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb_profiles.SelectedIndexChanged
        If cmb_profiles.SelectedIndex = 0 Then
            cmb_profiles.SelectedIndex = exclude_manage
            RaiseEvent ManageProfiles()
        Else
            exclude_manage = cmb_profiles.SelectedIndex
            RaiseEvent SelectedProfile(_profiles(cmb_profiles.SelectedIndex - 1))
        End If
        _settings.SelectedProfile = cmb_profiles.Items(cmb_profiles.SelectedIndex)
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

    Public Sub OnInstallerRun()
        UpdateUI()
    End Sub

    Public Sub UpdateProfiles()
        list_profiles()
        select_profile()
        UpdateUI()
    End Sub

    ' ##### Functionality ################################################################################

    Private Sub UpdateUI()
        If Not _settings.Patched Or Not PathHelper.HasFiles(PathHelper.Mods) Then
            btn_install.Text = "Install VMF"
            btn_install.Image = My.Resources.install_16
        Else
            btn_install.Text = "Uninstall VMF"
            btn_install.Image = My.Resources.uninstall_16
        End If
        btn_install.Enabled = PathHelper.HasFiles(PathHelper.Mods)
        cmb_profiles.Enabled = _settings.Patched And PathHelper.HasFiles(PathHelper.Mods)
    End Sub

    Private Sub list_profiles()
        cmb_profiles.Items.Clear()
        cmb_profiles.Items.Add("[Manage]")
        For Each p As VermintideProfile In _profiles
            cmb_profiles.Items.Add(p.Name)
        Next
    End Sub

    Private Sub select_profile()
        For Each p As VermintideProfile In _profiles
            If p.Name = _settings.SelectedProfile Then
                cmb_profiles.SelectedItem = p.Name
                Return
            End If
        Next
        cmb_profiles.SelectedItem = cmb_profiles.Items.Item(1)
    End Sub

End Class