Imports WeifenLuo.WinFormsUI.Docking
Imports VMM

Public Class main

    Private _settings As Settings
    Private _profiles As List(Of VermintideProfile)
    Private _mods As New List(Of VermintideMod)

    Private WithEvents _controls As Controls
    Private WithEvents _mods_module As Mods
    Private WithEvents _mod_files_missing As New ModuleWarning(ModuleWarning.WarningType.ModFilesMissing, "Download")
    Private WithEvents _requirements As Requirements
    Private WithEvents _mod_content As ModContent
    Private WithEvents _download_mod As ModuleDownload

    Private _read_me As ReadMe
    Private _output As ModuleOutput

    ' ##### Events ########################################################################################################################

    Private Sub main_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "Vermintide Mod Manager " + Version.Current
        init()
    End Sub

    Private Sub _mods_ShowReadMe(Text As String) Handles _mods_module.ShowReadMe
        _read_me.txt_readme.Text = Text
    End Sub

    Private Sub _controls_SelectedProfile(Profile As VermintideProfile) Handles _controls.SelectedProfile
        _mods_module.SelectedProfile(Profile)
    End Sub

    Private Sub _controls_SaveSettings() Handles _controls.SaveSettings
        SettingsBakery.Save(_settings)
    End Sub

    Private Sub Output(Text As String) Handles _controls.Output, _mods_module.Output, _requirements.Output
        _output.Print(Text)
    End Sub

    Private Sub _mods_SelectedMod(VermintideMod As VermintideMod) Handles _mods_module.SelectedMod
        _requirements.ListRequirements(VermintideMod)
        _mod_content.ListContent(VermintideMod)
    End Sub

    Private Sub _mods_ShowWarning(WarningType As ModuleWarning.WarningType) Handles _mods_module.ShowWarning
        _mod_files_missing.Show(DockPanel1, DockState.DockBottom)
    End Sub

    Private Sub _mod_files_missing_Solve() Handles _mod_files_missing.Solve
        '_mods_module.DownloadModFiles()
        _download_mod = New ModuleDownload(ModuleDownload.DownloadType.Framework, "Downloading Mod Framework ...")
        _download_mod.Show(DockPanel1, DockState.DockBottom)
    End Sub

    Private Sub _download_mod_DownloadFinished() Handles _download_mod.DownloadFinished
        _mods = ModHelper.FindMods()

        _mods_module.Close()
        _mods_module = New Mods(_profiles, _settings, _mods)
        _mods_module.Show(DockPanel1, DockState.Document)

        _requirements.Close()
        _requirements = New Requirements(_mods, _settings)
        _requirements.Show(_read_me.Pane, DockAlignment.Bottom, 0.5)

        _controls.OnInstallerRun()
    End Sub

    Private Sub _controls_ShowAbout() Handles _controls.ShowAbout
        Dim about As New About
        about.ShowDialog()
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
        Dim pm As New ProfileManager(_profiles)
        pm.ShowDialog()
        _controls.UpdateProfiles()
    End Sub

    ' ##### Functionality ########################################################################################################################

    Private Sub init()
        _settings = SettingsBakery.Load()
        _profiles = ProfileBakery.Load()
        _mods = ModHelper.FindMods()

        Size = _settings.WindowSize
        Location = _settings.WindowPosition
        If _settings.Maximized Then
            WindowState = FormWindowState.Maximized
        End If

        _read_me = New ReadMe()
        _read_me.Show(DockPanel1, DockState.DockRight)

        _mods_module = New Mods(_profiles, _settings, _mods)
        _mods_module.Show(DockPanel1, DockState.Document)

        _output = New ModuleOutput
        _output.Show(DockPanel1, DockState.DockBottom)

        _controls = New Controls(_profiles, _settings)
        _controls.Show(DockPanel1, DockState.DockTop)

        _requirements = New Requirements(_mods, _settings)
        _requirements.Show(_read_me.Pane, DockAlignment.Bottom, 0.5)

        _mod_content = New ModContent
        _mod_content.Show(_requirements.Pane, DockAlignment.Bottom, 0.5)

    End Sub

    Private Sub save_profile() Handles _controls.SaveProfile, _mods_module.SaveProfile, _requirements.SaveProfiles
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
                For Each p As VermintideProfile In _profiles
                    If p.Name = _settings.SelectedProfile Then
                        _mods_module.SelectedProfile(p)
                        Exit For
                    End If
                Next
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
        _controls.OnInstallerRun()
        _mods_module.Init()
    End Sub

    Private Sub _requirements_ModChanged() Handles _requirements.ModChanged
        _mods_module.UpdateMods()
    End Sub

End Class
