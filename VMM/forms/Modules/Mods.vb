Imports System
Imports System.IO
Imports Ionic.Zip
Imports Newtonsoft.Json

Public Class Mods

    Private _mods As List(Of VermintideMod)
    Private _profiles As List(Of VermintideProfile)
    Private _settings As Settings

    Public Event SaveProfile()
    Public Event ShowReadMe(Text As String)
    Public Event Output(Text As String)
    Public Event SelectedMod(VermintideMod As VermintideMod)
    Public Event ShowWarning(WarningType As ModuleWarning.WarningType)

    ' ##### Events ################################################################################

    Public Sub New(Profiles As List(Of VermintideProfile), Settings As Settings, Mods As List(Of VermintideMod))
        InitializeComponent()
        _profiles = Profiles
        _settings = Settings
        _mods = Mods
    End Sub

    Private Sub Mods_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Init()
    End Sub

    Private Sub Mods_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        CheckModFiles()
        '_mods = ModHelper.FindMods()
        'For Each p As VermintideProfile In _profiles
        '    If p.Name = _settings.SelectedProfile Then
        '_mods = ModHelper.FindMods()
        '        Exit For
        '    End If
        'Next
        ListMods()
        ' Select profile
        For Each p As VermintideProfile In _profiles
            If p.Name = _settings.SelectedProfile Then
                SelectedProfile(p)
                Exit For
            End If
        Next
        ' Select mod
        If MetroGrid1.Rows.Count > 0 Then
            MetroGrid1.Rows(0).Selected = True
            SelectMod()
        End If
    End Sub

    ' ##### Public ################################################################################

    Public Sub Init()
        MetroGrid1.Enabled = _settings.Patched
    End Sub

    Public Sub SelectedProfile(Profile As VermintideProfile)
        For Each vm As VermintideMod In _mods
            vm.active = Profile.Mods.Contains(vm.identifier)
        Next
        UpdateMods()
        For Each vm As VermintideMod In _mods
            Installer.SingleMod(vm)
        Next
    End Sub

    Public Sub FrameworkDownloaded()
        'FindMods()
        ListMods()
        'Init()
        For Each p As VermintideProfile In _profiles
            If p.Name = _settings.SelectedProfile Then
                SelectedProfile(p)
                Exit For
            End If
        Next
        RaiseEvent Output("Latest mod files were downloaded.")
    End Sub

    'Public Sub DownloadModFiles()
    '    'If MsgBox("The mod files are missing." + vbCrLf + "Do you want to download the latest mod version?",
    '    '          MsgBoxStyle.Critical + MsgBoxStyle.OkCancel, "Mod files missing") = MsgBoxResult.Ok Then
    '    '    Dim Path As String = Environment.GetFolderPath(Environment.SpecialFolder.InternetCache) + "\Vermitide-Mod-Framework-0.15.4.zip"
    '    '    If My.Computer.FileSystem.FileExists(Path) Then
    '    '        My.Computer.FileSystem.DeleteFile(Path)
    '    '    End If
    '    '    My.Computer.Network.DownloadFile("http://iamlupo.nl/WarhammerDerp/Vermitide-Mod-Framework-0.15.4.zip", Path)
    '    '    Using zip As ZipFile = ZipFile.Read(Path)
    '    '        zip.ExtractAll(PathHelper.Repository)
    '    '        'RaiseEvent 
    '    '        FindMods()
    '    '        ListMods()
    '    '        For Each p As VermintideProfile In _profiles
    '    '            If p.Name = _settings.SelectedProfile Then
    '    '                SelectedProfile(p)
    '    '                Exit For
    '    '            End If
    '    '        Next
    '    '        RaiseEvent Output("Latest mod files were downloaded.")
    '    '    End Using
    '    'End If
    'End Sub

    Public Sub UpdateMods()
        For Each Row As DataGridViewRow In MetroGrid1.Rows
            Dim Modfile As VermintideMod = Row.Tag
            Dim img As Image = Nothing
            If Modfile.active Then
                img = My.Resources.install_16
            Else
                img = My.Resources.uninstall_16
            End If
            If Modfile.outdated Then
                For Each Cell As DataGridViewCell In Row.Cells
                    Cell.Style.ForeColor = Color.Red
                Next
            End If
            Row.Cells(0).Value = img
        Next
        For Each Row As DataGridViewRow In MetroGrid1.SelectedRows
            Dim Modfile As VermintideMod = Row.Tag
            highlight_requirements(Modfile)
        Next
    End Sub

    ' ##### Functionality ################################################################################

    Private Function CheckModFiles() As Boolean
        If Not PathHelper.HasFiles(PathHelper.Mods) Then
            RaiseEvent ShowWarning(ModuleWarning.WarningType.ModFilesMissing)
            Return False
        End If
        Return True
    End Function

    Private Sub ListMods()
        MetroGrid1.Rows.Clear()
        For Each Modfile As VermintideMod In _mods
            MetroGrid1.Rows.Add("", Modfile.displayname, "Somebody", Modfile.version, "", "", Modfile.readme)
            MetroGrid1.Rows(MetroGrid1.Rows.Count - 1).InheritedStyle.BackColor = Color.LightPink
            MetroGrid1.Rows(MetroGrid1.Rows.Count - 1).Cells(0).Value = My.Resources.uninstall_16
            MetroGrid1.Rows(MetroGrid1.Rows.Count - 1).Tag = Modfile
            MetroGrid1.Rows(MetroGrid1.Rows.Count - 1).ContextMenuStrip = ContextMenuStrip1
        Next
    End Sub

    Private Sub SelectMod()
        Dim readme As String = String.Empty
        If MetroGrid1.SelectedRows.Count > 0 Then
            For Each Row As DataGridViewRow In MetroGrid1.SelectedRows
                Dim Modfile As VermintideMod = Row.Tag
                If Not IsNothing(Modfile) Then
                    highlight_requirements(Modfile)
                    readme += Modfile.readme + vbCrLf + vbCrLf
                    RaiseEvent SelectedMod(Modfile)
                End If
            Next
            RaiseEvent ShowReadMe(readme)
        End If
    End Sub

    Private Sub MetroGrid1_SelectionChanged(sender As Object, e As EventArgs) Handles MetroGrid1.SelectionChanged
        SelectMod()
    End Sub

    Private Sub highlight_requirements(Modfile As VermintideMod)
        For Each Row As DataGridViewRow In MetroGrid1.Rows
            Dim vm As VermintideMod = Row.Tag
            Row.DefaultCellStyle.BackColor = MetroGrid1.DefaultCellStyle.BackColor
            If Not IsNothing(Modfile.requirement) Then
                For Each Requirement In Modfile.requirement
                    If vm.mod_name = Requirement Then
                        If vm.active Then
                            Row.DefaultCellStyle.BackColor = Color.LightGreen
                        Else
                            Row.DefaultCellStyle.BackColor = Color.LightPink
                        End If
                    End If
                Next
            End If
        Next
    End Sub

    Private Sub MetroGrid1_CellMouseDown(sender As Object, e As DataGridViewCellMouseEventArgs) Handles MetroGrid1.CellMouseDown
        If e.RowIndex >= 0 Then
            If e.Button = MouseButtons.Right Then
                If MetroGrid1.Rows(e.RowIndex).Selected Then
                Else
                    MetroGrid1.ClearSelection()
                    MetroGrid1.Rows(e.RowIndex).Selected = True
                End If
            End If
        End If
    End Sub

    Private Sub SwapModState()
        For Each Row As DataGridViewRow In MetroGrid1.SelectedRows
            Dim Modfile As VermintideMod = Row.Tag
            Modfile.active = Not Modfile.active
            'RaiseEvent Output(String.Format("'{0}' activated in '{1}'.", Modfile.displayname, _settings.SelectedProfile))
            If Modfile.active Then
                RaiseEvent Output(String.Format("'{0}' activated in '{1}'.", Modfile.displayname, _settings.SelectedProfile))
            Else
                RaiseEvent Output(String.Format("'{0}' deactivated in '{1}'.", Modfile.displayname, _settings.SelectedProfile))
            End If
        Next
        ModChanged()
        RaiseEvent SaveProfile()
    End Sub

    Private Sub ActivateToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ActivateToolStripMenuItem.Click
        SwapModState()
    End Sub

    Private Sub DeactivateToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeactivateToolStripMenuItem.Click
        SwapModState()
    End Sub

    Private Sub SwapToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SwapToolStripMenuItem.Click
        SwapModState()
    End Sub

    Private Sub MetroContextMenu1_Opening(sender As Object, e As ComponentModel.CancelEventArgs) Handles ContextMenuStrip1.Opening
        Dim activated As Integer = 0
        Dim deactivated As Integer = 0
        If MetroGrid1.SelectedRows.Count > 0 Then
            For Each Row As DataGridViewRow In MetroGrid1.SelectedRows
                Dim vm As VermintideMod = Row.Tag
                If vm.active Then
                    activated += 1
                Else
                    deactivated += 1
                End If
            Next
        End If
        For Each Row As DataGridViewRow In MetroGrid1.SelectedRows
            Row.ContextMenuStrip.Items(0).Visible = False
            Row.ContextMenuStrip.Items(1).Visible = False
            Row.ContextMenuStrip.Items(2).Visible = False
            If deactivated > 0 And activated = 0 Then
                Row.ContextMenuStrip.Items(0).Visible = True
            ElseIf activated > 0 And deactivated = 0 Then
                Row.ContextMenuStrip.Items(1).Visible = True
            ElseIf activated > 0 And deactivated > 0 Then
                Row.ContextMenuStrip.Items(2).Visible = True
            End If
        Next
    End Sub

    Private Sub MetroGrid1_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles MetroGrid1.CellMouseDoubleClick
        'Dim Row As DataGridViewRow = MetroGrid1.Rows(MetroGrid1.SelectedRows(0).Index)
        Dim Row As DataGridViewRow = MetroGrid1.Rows(e.RowIndex)
        If Not IsNothing(Row) Then
            Row.Selected = True
            '    Dim VM As VermintideMod = Row.Tag
            '    If Not IsNothing(VM) Then
            'VM.active = Not VM.active
            'ModChanged()
            SwapModState()
            'Dim VM As VermintideMod = Row.Tag
            'VM.active = Not VM.active
            ''RaiseEvent Output(String.Format("'{0}' activated in '{1}'.", VM.displayname, _settings.SelectedProfile))
            'If VM.active Then
            '    RaiseEvent Output(String.Format("'{0}' activated in '{1}'.", VM.displayname, _settings.SelectedProfile))
            'Else
            '    RaiseEvent Output(String.Format("'{0}' deactivated in '{1}'.", VM.displayname, _settings.SelectedProfile))
            'End If
            ''    End If
            'ModChanged()
            'RaiseEvent SaveProfile()
        End If
    End Sub

    Private Sub ModChanged()
        UpdateMods()
        For Each vm As VermintideMod In _mods
            If Installer.SingleMod(vm) Then
                'RaiseEvent Output(String.Format("'{0}' activated in '{1}'.", vm.displayname, _settings.SelectedProfile))
            End If
        Next
    End Sub

End Class