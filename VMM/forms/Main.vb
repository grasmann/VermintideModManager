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

    Private WithEvents _controls As ModuleControl
    Private WithEvents _mods_module As ModuleModList
    Private WithEvents _mod_files_missing As New ModuleWarning(ModuleWarning.WarningType.ModFilesMissing, "Download")
    Private WithEvents _requirements As ModuleRequirements
    Private WithEvents _mod_content As ModuleModContent
    Private WithEvents _download_mod As ModuleDownload
    Private WithEvents _options As Options
    Private WithEvents _profile_manager As ProfileManager
    Private WithEvents _about As About

    Private _read_me As ModuleReadMe
    Private _output As ModuleOutput

    ' ##### Events ########################################################################################################################

    Private Sub main_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "Vermintide Mod Manager " + Version.Current
        init()
    End Sub

    Private Sub _mods_ShowReadMe(Text As String) Handles _mods_module.ShowReadMe
        _read_me.SetText(Text)
    End Sub

    Private Sub select_profile(Name As String) Handles _controls.SelectProfile, _mods_module.SelectProfile
        If Not String.IsNullOrEmpty(Name) Then
            For Each Profile As VermintideProfile In _profiles
                If Profile.Name = Name Then
                    _mods_module.SelectedProfile(New ModuleArgs(_profiles, _settings, _mods, Profile))
                    _settings.SelectedProfile = Name
                    Exit Sub
                End If
            Next
            _settings.SelectedProfile = _profiles(0).Name
            _mods_module.SelectedProfile(New ModuleArgs(_profiles, _settings, _mods, selected_profile()))
        Else
            _mods_module.SelectedProfile(New ModuleArgs(_profiles, _settings, _mods, selected_profile()))
        End If
    End Sub

    'Private Sub _controls_SaveSettings() Handles _controls.SaveSettings
    '    SettingsBakery.Save(_settings)
    'End Sub

    Private Sub Output(Text As String) Handles _controls.Output, _mods_module.Output, _requirements.Output
        _output.Print(Text)
    End Sub

    Private Sub _mods_SelectedMod(VermintideMod As VermintideMod) Handles _mods_module.SelectedMod
        _requirements.ListRequirements(New ModuleArgs(_profiles, _settings, _mods, selected_profile()), VermintideMod)
        _mod_content.ListContent(VermintideMod)
        selected_mods()
    End Sub

    'Private Sub _mods_ShowWarning(WarningType As ModuleWarning.WarningType) Handles _mods_module.ShowWarning
    '    _mod_files_missing.Show(DockPanel1, DockState.DockBottom)
    'End Sub

    Private Sub _mod_files_missing_Solve() Handles _mod_files_missing.Solve
        '_mods_module.DownloadModFiles()
        _download_mod = New ModuleDownload(ModuleDownload.DownloadType.Framework, "Downloading Mod Framework ...")
        _download_mod.Show(DockPanel1, DockState.DockBottom)
    End Sub

    Private Sub _download_mod_DownloadFinished() Handles _download_mod.DownloadFinished
        _mods = ModHelper.FindMods()
        '_args = New ModuleArgs(_profiles, _settings, _mods)

        _mods_module.Close()
        _mods_module = New ModuleModList() '_profiles, _settings, _mods)
        _mods_module.Show(DockPanel1, DockState.Document)

        _requirements.Close()
        _requirements = New ModuleRequirements()
        _requirements.Show(_read_me.Pane, DockAlignment.Bottom, 0.5)

        _controls.UpdateUI(New ModuleArgs(_profiles, _settings, _mods, selected_profile()))
    End Sub

    Private Sub _controls_ShowAbout() Handles _controls.ShowAbout
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

    Private Sub _controls_ManageProfiles() Handles _controls.ManageProfiles
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
        Dim Mods As New List(Of VermintideMod)
        For Each Row As DataGridViewRow In _mods_module.MetroGrid1.Rows
            If Row.Selected Then
                Dim _mod As VermintideMod = Row.Tag
                If Not IsNothing(_mod) Then
                    Mods.Add(_mod)
                End If
            End If
        Next
        Return Mods
    End Function

    ' ##### Functionality ########################################################################################################################

    Private Sub init()
        _settings = SettingsBakery.Load()
        _profiles = ProfileBakery.Load()
        _mods = ModHelper.FindMods()
        '_args = New ModuleArgs(_profiles, _settings, _mods)

        Size = _settings.WindowSize
        Location = _settings.WindowPosition
        If _settings.Maximized Then
            WindowState = FormWindowState.Maximized
        End If

        _mods_module = New ModuleModList() '_profiles, _settings, _mods)
        _mods_module.Show(DockPanel1, DockState.Document)
        _mods_module.UpdateUI(New ModuleArgs(_profiles, _settings, _mods, selected_profile()))

        _controls = New ModuleControl()
        _controls.Show(DockPanel1, DockState.DockTop)
        _controls.UpdateProfiles(New ModuleArgs(_profiles, _settings, _mods, selected_profile()))

        _read_me = New ModuleReadMe()
        _output = New ModuleOutput
        _requirements = New ModuleRequirements()
        _mod_content = New ModuleModContent

        show_modules()

        _options = New Options(New ModuleArgs(_profiles, _settings, _mods, selected_profile()))
        _profile_manager = New ProfileManager
        _about = New About

        ' Check for mod files
        If Not PathHelper.HasFiles(PathHelper.Mods) Then
            _mod_files_missing.Show(DockPanel1, DockState.DockBottom)
        End If

    End Sub

    Private Sub save_profile() Handles _mods_module.SaveProfile, _requirements.SaveProfiles
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
                'For Each p As VermintideProfile In _profiles
                '    If p.Name = _settings.SelectedProfile Then
                '        _mods_module.SelectedProfile(p)
                '        Exit For
                '    End If
                'Next
                _mods_module.SelectedProfile(New ModuleArgs(_profiles, _settings, _mods, selected_profile()))
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
        '_controls.OnInstallerRun()
        _controls.UpdateProfiles(New ModuleArgs(_profiles, _settings, _mods, selected_profile()))
        _mods_module.UpdateUI(New ModuleArgs(_profiles, _settings, _mods, selected_profile()))
    End Sub

    Private Sub _requirements_ModChanged() Handles _requirements.ModChanged
        _mods_module.UpdateMods()
    End Sub

    Private Sub _mods_module_UpdateList() Handles _mods_module.RequestRefreshList
        _mods_module.RefreshList(New ModuleArgs(_profiles, _settings, _mods, selected_profile()))
    End Sub

    Private Sub _mods_module_InstallMods() Handles _mods_module.InstallMods
        For Each vm As VermintideMod In _mods
            If Installer.SingleMod(vm, _settings.Patched) Then
                'RaiseEvent Output(String.Format("'{0}' activated in '{1}'.", vm.displayname, _settings.SelectedProfile))
            End If
        Next
    End Sub

    Private Sub _requirements_RequestActivateRequirement() Handles _requirements.RequestActivateRequirement
        If _mods_module.MetroGrid1.SelectedRows.Count > 0 Then
            Dim Modfile As VermintideMod = _mods_module.MetroGrid1.SelectedRows(0).Tag
            If Not IsNothing(Modfile) Then
                _requirements.ActivateRequirement(New ModuleArgs(_profiles, _settings, _mods, selected_profile()), Modfile)
            End If
        End If
    End Sub

    Private Sub _controls_ShowOptions() Handles _controls.ShowOptions
        '_options = New Options(New ModuleArgs(_profiles, _settings, _mods, selected_profile()))
        _options.Show(DockPanel1, DockState.Document)
    End Sub

    Private Sub _options_RequestBrowseFolder() Handles _options.RequestBrowseFolder
        _options.BrowseFolder(New ModuleArgs(_profiles, _settings, _mods, selected_profile()))
    End Sub

    Private Sub _mod_content_RequestOpenSource() Handles _mod_content.RequestOpenSource
        _mod_content.OpenSource(New ModuleArgs(_profiles, _settings, _mods, selected_profile()))
    End Sub

    Private Sub show_modules()

        Dim _pane As DockPane = Nothing

        If _settings.HideModule.Contains("Output") Then
            _output.Show(DockPanel1, DockState.DockBottomAutoHide)
        Else
            _output.Show(DockPanel1, DockState.DockBottom)
        End If
        If _settings.HideModule.Contains("ReadMe") Then
            _read_me.Show(DockPanel1, DockState.DockRightAutoHide)
        Else
            _read_me.Show(DockPanel1, DockState.DockRight)
            _pane = _read_me.Pane
        End If
        If _settings.HideModule.Contains("Requirements") Then
            _requirements.Show(DockPanel1, DockState.DockRightAutoHide)
        Else
            If Not IsNothing(_pane) Then
                _requirements.Show(_pane, DockAlignment.Bottom, 0.6)
            Else
                _requirements.Show(DockPanel1, DockState.DockRight)
            End If
            _pane = _requirements.Pane
        End If
        If _settings.HideModule.Contains("Content") Then
            _mod_content.Show(DockPanel1, DockState.DockRightAutoHide)
        Else
            If Not IsNothing(_pane) Then
                _mod_content.Show(_pane, DockAlignment.Bottom, 0.75)
            Else
                _mod_content.Show(DockPanel1, DockState.DockRight)
            End If
            _pane = _mod_content.Pane
        End If

    End Sub

    Private Sub _options_RequestModuleChange() Handles _options.RequestModuleChange
        _options.ModuleChange(New ModuleArgs(_profiles, _settings, _mods, selected_profile()))
        show_modules()
        'If _settings.HideModule.Contains("Content") Then
        '    '_mod_content.VisibleState = DockState.DockRightAutoHide
        '    _mod_content.Show(_requirements.Pane, DockAlignment.Bottom, 0.5)
        'Else
        '    '_mod_content.VisibleState = DockState.DockRightAutoHide
        '    _mod_content.Show(_requirements.Pane, DockAlignment.Bottom, 0.5)
        'End If
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
        _controls.UpdateProfiles(New ModuleArgs(_profiles, _settings, _mods, selected_profile()))
    End Sub

End Class
