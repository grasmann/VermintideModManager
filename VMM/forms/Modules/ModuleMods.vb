Imports VMM
Imports WeifenLuo.WinFormsUI.Docking

Public Class ModuleMods

    Private WithEvents _mod_list As ModuleModList
    Private WithEvents _requirements As ModuleRequirements
    Private WithEvents _content As ModuleModContent
    Private WithEvents _read_me As ModuleReadMe

    Public Event SelectProfile(Name As String)
    'Public Event ShowReadMe(Text As String)
    Public Event InstallMods()
    Public Event SaveProfile()
    'Public Event RequestShowModules()
    Public Event RequestRefreshList()
    Public Event RequestActivateRequirement(VermintideMod As VermintideMod)
    Public Event RequestListRequirements(VermintideMod As VermintideMod)
    Public Event RequestOpenSource()
    Public Event Output(Text As String)

    Public Event ManageProfiles()
    Public Event ModDeleted(VermintideMod As VermintideMod)

    Private Sub _mod_list_Output(Text As String) Handles _mod_list.Output, _requirements.Output
        RaiseEvent Output(Text)
    End Sub

    Public Sub UpdateProfiles(Args As main.ModuleArgs)
        _mod_list.UpdateProfiles(Args)
    End Sub

    Public Sub UpdateData(Args As main.ModuleArgs)
        _mod_list.UpdateUI(Args)
        '_mod_list.UpdateMods()
        _mod_list.RefreshList(Args)
    End Sub

    Public Sub New()
        InitializeComponent()
        _mod_list = New ModuleModList() '_profiles, _settings, _mods)
        _mod_list.Show(DockPanel1, DockState.Document)
        '_mod_list.UpdateUI(New ModuleArgs(_profiles, _settings, _mods, selected_profile()))
        _read_me = New ModuleReadMe
        _requirements = New ModuleRequirements
        _content = New ModuleModContent
        'show_modules()
        'RaiseEvent RequestShowModules()
    End Sub

    Public Sub UpdateMods(Args As main.ModuleArgs)
        _mod_list.UpdateMods()
    End Sub

    Public Sub OpenSource(Args As main.ModuleArgs)
        _content.OpenSource(Args)
    End Sub

    Public Sub ShowModules(Args As main.ModuleArgs)
        show_modules(Args)
    End Sub

    Private Sub _mod_list_SelectProfile(Name As String) Handles _mod_list.SelectProfile
        RaiseEvent SelectProfile(Name)
    End Sub

    Private Sub _mod_list_ShowReadMe(Text As String) Handles _mod_list.ShowReadMe
        'RaiseEvent ShowReadMe(Text)
        _read_me.SetText(Text)
    End Sub

    Public Sub SelectedProfile(Args As main.ModuleArgs)
        For Each vm As VermintideMod In Args.Mods
            vm.active = Args.SelectedProfile.Mods.Contains(vm.identifier)
        Next
        'update_mods()
        _mod_list.UpdateMods()
        RaiseEvent InstallMods()
    End Sub

    Public Function SelectedMods() As List(Of VermintideMod)
        Dim Mods As New List(Of VermintideMod)
        For Each Row As DataGridViewRow In _mod_list.MetroGrid1.Rows
            If Row.Selected Then
                Dim _mod As VermintideMod = Row.Tag
                If Not IsNothing(_mod) Then
                    Mods.Add(_mod)
                End If
            End If
        Next
        Return Mods
    End Function

    Private Sub show_modules(Args As main.ModuleArgs)

        Dim _pane As DockPane = Nothing

        'If Args.Settings.HideModule.Contains("Output") Then
        '    _output.Show(DockPanel1, DockState.DockBottomAutoHide)
        'Else
        '    _output.Show(DockPanel1, DockState.DockBottom)
        'End If
        Me.SuspendLayout()
        DockPanel1.SuspendLayout()
        If Args.Settings.HideModule.Contains("ReadMe") Then
            If Not _read_me.DockState = DockState.DockRightAutoHide Then _read_me.Show(DockPanel1, DockState.DockRightAutoHide)
        Else
            If Not _read_me.DockState = DockState.DockRight Then _read_me.Show(DockPanel1, DockState.DockRight)
            _pane = _read_me.Pane
        End If
        If Args.Settings.HideModule.Contains("Requirements") Then
            If Not _requirements.DockState = DockState.DockRightAutoHide Then _requirements.Show(DockPanel1, DockState.DockRightAutoHide)
        Else
            If Not IsNothing(_pane) Then
                If Not _requirements.VisibleState = DockState.DockRight Then _requirements.Show(_pane, DockAlignment.Bottom, 0.6)
            Else
                If Not _requirements.DockState = DockState.DockRight Then _requirements.Show(DockPanel1, DockState.DockRight)
            End If
            _pane = _requirements.Pane
        End If
        If Args.Settings.HideModule.Contains("Content") Then
            If Not _content.DockState = DockState.DockRightAutoHide Then _content.Show(DockPanel1, DockState.DockRightAutoHide)
        Else
            If Not IsNothing(_pane) Then
                If Not _content.VisibleState = DockState.DockRight Then _content.Show(_pane, DockAlignment.Bottom, 0.5)
            Else
                If Not _content.DockState = DockState.DockRight Then _content.Show(DockPanel1, DockState.DockRight)
            End If
            _pane = _content.Pane
        End If
        DockPanel1.ResumeLayout()
        Me.ResumeLayout()

    End Sub

    Private Sub _mod_list_SaveProfile() Handles _mod_list.SaveProfile, _requirements.SaveProfiles
        RaiseEvent SaveProfile()
    End Sub

    Private Sub _requirements_ModChanged() Handles _requirements.ModChanged
        _mod_list.UpdateMods()
    End Sub

    Private Sub _mod_list_RequestRefreshList() Handles _mod_list.RequestRefreshList
        RaiseEvent RequestRefreshList()
    End Sub

    Public Sub RefreshList(Args As main.ModuleArgs)
        _mod_list.RefreshList(Args)
    End Sub

    Private Sub _requirements_RequestActivateRequirement() Handles _requirements.RequestActivateRequirement
        If _mod_list.MetroGrid1.SelectedRows.Count > 0 Then
            Dim Modfile As VermintideMod = _mod_list.MetroGrid1.SelectedRows(0).Tag
            If Not IsNothing(Modfile) Then
                '_requirements.ActivateRequirement(New ModuleArgs(_profiles, _settings, _mods, selected_profile()), Modfile)
                RaiseEvent RequestActivateRequirement(Modfile)
            End If
        End If
    End Sub

    Public Sub ActivateRequirement(Args As main.ModuleArgs, VermintideMod As VermintideMod)
        _requirements.ActivateRequirement(Args, VermintideMod)
    End Sub

    Private Sub _mod_list_SelectedMod(VermintideMod As VermintideMod) Handles _mod_list.SelectedMod
        '_requirements.ListRequirements(New ModuleArgs(_profiles, _settings, _mods, selected_profile()), VermintideMod)
        RaiseEvent RequestListRequirements(VermintideMod)
        _content.ListContent(VermintideMod)
    End Sub

    Public Sub ListRequirements(Args As main.ModuleArgs, VermintideMod As VermintideMod)
        _requirements.ListRequirements(Args, VermintideMod)
    End Sub

    Private Sub _content_RequestOpenSource() Handles _content.RequestOpenSource
        RaiseEvent RequestOpenSource()
    End Sub

    Private Sub _mod_list_ManageProfiles() Handles _mod_list.ManageProfiles
        RaiseEvent ManageProfiles()
    End Sub

    Private Sub _mod_list_ModDeleted(VermintideMod As VermintideMod) Handles _mod_list.ModDeleted
        RaiseEvent ModDeleted(VermintideMod)
    End Sub

End Class