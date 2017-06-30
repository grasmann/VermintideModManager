Imports WeifenLuo.WinFormsUI.Docking
Imports VMM
Imports System.ComponentModel

Public Class main

    Public Class ModuleArgs
        Public Property Profiles As List(Of VermintideProfile)
        Public Property Settings As Settings
        Public Property Mods As List(Of VermintideMod)
        Public Property SelectedProfile As VermintideProfile
        'Public Property SelectedMods As List(Of VermintideMod)
        Public Sub New(Profiles As List(Of VermintideProfile), Settings As Settings, Mods As List(Of VermintideMod),
                       SelectedProfile As VermintideProfile) ', SelectedMods As List(Of VermintideMod))
            Me.Profiles = Profiles
            Me.Settings = Settings
            Me.Mods = Mods
            Me.SelectedProfile = SelectedProfile
            'Me.SelectedMods = SelectedMods
        End Sub
    End Class

    Private _settings As Settings
    Private _profiles As List(Of VermintideProfile)
    Private _mods As New List(Of VermintideMod)
    'Private _args As ModuleArgs

    Private WithEvents _mod_module As ModuleMods
    Private WithEvents _controls As ModuleControl
    Private WithEvents _mod_files_missing As New ModuleWarning(ModuleWarning.WarningType.ModFilesMissing, "Download")
    Private WithEvents _options As ModuleOptions
    Private WithEvents _profile_manager As ModuleProfileManager
    Private WithEvents _about As About

    'Private _read_me As ModuleReadMe
    Private _output As ModuleOutput

    ' ##### Events ########################################################################################################################

    Private Sub main_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "Vermintide Mod Manager " + Version.Current
        init()
    End Sub

    Private Sub select_profile(Name As String) Handles _controls.SelectProfile, _mod_module.SelectProfile
        If Not String.IsNullOrEmpty(Name) Then
            For Each Profile As VermintideProfile In _profiles
                If Profile.Name = Name Then
                    _mod_module.SelectedProfile(New ModuleArgs(_profiles, _settings, _mods, Profile))
                    _settings.SelectedProfile = Name
                    Exit Sub
                End If
            Next
            _settings.SelectedProfile = _profiles(0).Name
            _mod_module.SelectedProfile(New ModuleArgs(_profiles, _settings, _mods, selected_profile()))
        Else
            _mod_module.SelectedProfile(New ModuleArgs(_profiles, _settings, _mods, selected_profile()))
        End If
    End Sub

    Private Sub Output(Text As String) Handles _controls.Output, _mod_module.Output ', _mod_downloader.Output '_mods_module.Output, _requirements.Output
        _output.Print(Text)
    End Sub

    Private Sub _controls_ShowAbout() Handles _controls.OpenAbout
        'Dim about As New About
        _about.ShowDialog()
        '_about.Show(DockPanel1, DockState.Document)
    End Sub

    Private Sub main_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        _settings.Maximized = WindowState = FormWindowState.Maximized
        If Not _settings.Maximized Then
            _settings.WindowSize = Size
            _settings.WindowPosition = Location
        End If
        SettingsBakery.Save(_settings)
    End Sub

    Private Sub _controls_ManageProfiles() Handles _controls.ManageProfiles, _mod_module.ManageProfiles
        'Dim pm As New ProfileManager() '_profiles)
        'pm.ShowDialog()
        _profile_manager.Show(DockPanel1, DockState.Document)
        '_controls.UpdateProfiles(New ModuleArgs(_profiles, _settings, _mods, selected_profile()))
    End Sub

    Private Function selected_profile() As VermintideProfile
        For Each p As VermintideProfile In _profiles
            If p.Name = _settings.SelectedProfile Then
                Return p
            End If
        Next
        Return _profiles(0)
    End Function

    Private Function selected_mods() As List(Of VermintideMod)
        Return _mod_module.SelectedMods
    End Function

    ' ##### Functionality ########################################################################################################################

    Private Sub init()
        _settings = SettingsBakery.Load()
        _profiles = ProfileBakery.Load()
        _mods = ModHelper.FindMods()
        '_args = New ModuleArgs(_profiles, _settings, _mods)

        Size = _settings.WindowSize
        Location = _settings.WindowPosition
        If Not Screen.PrimaryScreen.Bounds.Contains(Location) Then
            Dim x = Screen.PrimaryScreen.Bounds.Width / 2 - Size.Width / 2
            Dim y = Screen.PrimaryScreen.Bounds.Height / 2 - Size.Height / 2
            Location = New Point(x, y)
            _settings.WindowPosition = Location
        End If

        _mod_module = New ModuleMods
        _mod_module.Show(DockPanel1, DockState.Document)
        _mod_module.UpdateData(New ModuleArgs(_profiles, _settings, _mods, selected_profile()))
        _mod_module.UpdateProfiles(New ModuleArgs(_profiles, _settings, _mods, selected_profile()))

        _controls = New ModuleControl()
        _controls.Show(DockPanel1, DockState.DockTop)
        _controls.UpdateUI(New ModuleArgs(_profiles, _settings, _mods, selected_profile()))

        _output = New ModuleOutput

        show_modules()

        _options = New ModuleOptions(New ModuleArgs(_profiles, _settings, _mods, selected_profile()))
        _profile_manager = New ModuleProfileManager
        _about = New About

        ' Check for mod files
        If Not PathHelper.HasFiles(PathHelper.Mods) Then
            _mod_files_missing.Show(DockPanel1, DockState.DockBottom)
        End If

        If _settings.Maximized Then
            WindowState = FormWindowState.Maximized
        End If

    End Sub

    Private Sub save_profile() Handles _mod_module.SaveProfile ', _requirements.SaveProfiles
        For Each p As VermintideProfile In _profiles
            If p.Name = _settings.SelectedProfile Then
                p.Mods.Clear()
                For Each vm As VermintideMod In _mods
                    If vm.active Then
                        p.Mods.Add(vm.identifier)
                    End If
                Next
            End If
        Next
        ProfileBakery.Save(_profiles)
    End Sub

    ' ##### Framework ########################################################################################################################

    Private Sub InstallFramework() Handles _controls.InstallFramework
        If Not _settings.Patched Then
            Output("Installing Framework ...")
            If Installer.Framework() Then
                Output("Done.")
                _mod_module.SelectedProfile(New ModuleArgs(_profiles, _settings, _mods, selected_profile()))
                _settings.Patched = Not _settings.Patched
            End If
        Else
            Output("Purging Framework ...")
            Installer.Purge()
            Output("Done.")
            _settings.Patched = Not _settings.Patched
        End If
        SettingsBakery.Save(_settings)
        Output("Settings saved.")
        '_settings.Patched = Not _settings.Patched
        _controls.UpdateUI(New ModuleArgs(_profiles, _settings, _mods, selected_profile()))
        _mod_module.UpdateProfiles(New ModuleArgs(_profiles, _settings, _mods, selected_profile()))
        _mod_module.UpdateData(New ModuleArgs(_profiles, _settings, _mods, selected_profile()))
    End Sub

    Private Sub _mods_module_UpdateList() Handles _mod_module.RequestRefreshList
        If Not IsNothing(_profiles) And Not IsNothing(_settings) Then
            _mods = ModHelper.FindMods()
            _mod_module.RefreshList(New ModuleArgs(_profiles, _settings, _mods, selected_profile()))
        End If
    End Sub

    Private Sub _mods_module_InstallMods() Handles _mod_module.InstallMods
        For Each vm As VermintideMod In _mods
            If Installer.SingleMod(vm, _settings.Patched) Then
                'RaiseEvent Output(String.Format("'{0}' activated in '{1}'.", vm.displayname, _settings.SelectedProfile))
            End If
        Next
    End Sub

    Private Sub _mod_module_RequestActivateRequirement(VermintideMod As VermintideMod) Handles _mod_module.RequestActivateRequirement
        _mod_module.ActivateRequirement(New ModuleArgs(_profiles, _settings, _mods, selected_profile()), VermintideMod)
    End Sub

    Private Sub _mod_module_RequestListRequirements(VermintideMod As VermintideMod) Handles _mod_module.RequestListRequirements
        _mod_module.ListRequirements(New ModuleArgs(_profiles, _settings, _mods, selected_profile()), VermintideMod)
    End Sub

    Private Sub _controls_ShowOptions() Handles _controls.OpenOptions
        '_options = New Options(New ModuleArgs(_profiles, _settings, _mods, selected_profile()))
        _options.Show(DockPanel1, DockState.Document)
    End Sub

    Private Sub _options_RequestBrowseFolder() Handles _options.RequestBrowseFolder
        _options.BrowseFolder(New ModuleArgs(_profiles, _settings, _mods, selected_profile()))
    End Sub

    Private Sub _mod_content_RequestOpenSource() Handles _mod_module.RequestOpenSource
        _mod_module.OpenSource(New ModuleArgs(_profiles, _settings, _mods, selected_profile()))
    End Sub

    Private Sub show_modules()

        Dim _pane As DockPane = Nothing

        Me.SuspendLayout()
        DockPanel1.SuspendLayout()
        If _settings.HideModule.Contains("Output") Then
            _output.Show(DockPanel1, DockState.DockBottomAutoHide)
        Else
            _output.Show(DockPanel1, DockState.DockBottom)
        End If
        _mod_module.ShowModules(New ModuleArgs(_profiles, _settings, _mods, selected_profile()))
        DockPanel1.ResumeLayout()
        Me.ResumeLayout()

    End Sub

    Private Sub _options_RequestModuleChange() Handles _options.RequestModuleChange
        _options.ModuleChange(New ModuleArgs(_profiles, _settings, _mods, selected_profile()))
        show_modules()
    End Sub

    Private Sub _options_RequestModuleValues() Handles _options.RequestModuleValues
        _options.SetValues(New ModuleArgs(_profiles, _settings, _mods, selected_profile()))
    End Sub

    Private Sub _profile_manager_RequestCopyProfile() Handles _profile_manager.RequestCopyProfile
        _profile_manager.CopyProfile(New ModuleArgs(_profiles, _settings, _mods, selected_profile()))
    End Sub

    Private Sub _profile_manager_RequestCreateProfile() Handles _profile_manager.RequestCreateProfile
        _profile_manager.CreateProfile(New ModuleArgs(_profiles, _settings, _mods, selected_profile()))
    End Sub

    Private Sub _profile_manager_RequestDeleteProfile() Handles _profile_manager.RequestDeleteProfile
        _profile_manager.DeleteProfile(New ModuleArgs(_profiles, _settings, _mods, selected_profile()))
    End Sub

    Private Sub _profile_manager_RequestListProfiles() Handles _profile_manager.RequestListProfiles
        _profile_manager.ListProfiles(New ModuleArgs(_profiles, _settings, _mods, selected_profile()))
    End Sub

    Private Sub _profile_manager_UpdateProfiles() Handles _profile_manager.UpdateProfiles
        _mod_module.UpdateProfiles(New ModuleArgs(_profiles, _settings, _mods, selected_profile()))
    End Sub

    Private Sub _mod_module_ModDeleted(VermintideMod As VermintideMod) Handles _mod_module.ModDeleted
        _mods.Remove(VermintideMod)
        Try
            If My.Computer.FileSystem.FileExists(VermintideMod.path) Then
                My.Computer.FileSystem.DeleteFile(VermintideMod.path)
                Output(String.Format("'{0}' v{1} deleted.", VermintideMod.displayname, VermintideMod.version))
                _mod_module.UpdateProfiles(New ModuleArgs(_profiles, _settings, _mods, selected_profile()))
                _mod_module.UpdateData(New ModuleArgs(_profiles, _settings, _mods, selected_profile()))
                '_mod_downloader.UpdateList()
            End If
        Catch ex As Exception
            Debug.Print(ex.Message)
        End Try
    End Sub

    Private Sub main_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        _mods_module_UpdateList()
    End Sub

End Class
