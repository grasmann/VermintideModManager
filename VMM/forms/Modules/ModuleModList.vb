Imports System
Imports System.IO
Imports Ionic.Zip
Imports Newtonsoft.Json

Public Class ModuleModList

    Private exclude_manage As Integer

    Public Event SaveProfile()
    Public Event ShowReadMe(Text As String)
    Public Event Output(Text As String)
    Public Event SelectedMod(VermintideMod As VermintideMod)
    Public Event SelectProfile(Name As String)
    Public Event RequestRefreshList()
    Public Event InstallMods()

    Public Event ManageProfiles()
    Public Event ModDeleted(VermintideMod As VermintideMod)

    ' ##### Events ################################################################################

    Private Sub Mods_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        RaiseEvent RequestRefreshList()
        select_a_mod()
    End Sub

    Private Sub ActivateToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ActivateToolStripMenuItem.Click
        swap_mod_state()
    End Sub

    Private Sub DeactivateToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeactivateToolStripMenuItem.Click
        swap_mod_state()
    End Sub

    Private Sub SwapToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SwapToolStripMenuItem.Click
        swap_mod_state()
    End Sub

    Private Sub MetroGrid1_SelectionChanged(sender As Object, e As EventArgs) Handles MetroGrid1.SelectionChanged
        select_mod()
    End Sub

    Private Sub cmb_profiles_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb_profiles.SelectedIndexChanged
        handle_combobox()
    End Sub

    Public Sub UpdateProfiles(Args As main.ModuleArgs)
        update_profiles(Args)
    End Sub

    Private Sub update_profiles(Args As main.ModuleArgs)
        list_profiles(Args.Profiles)
        cmb_profiles.SelectedItem = Args.SelectedProfile.Name
        UpdateUI(Args)
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

    Private Sub MetroGrid1_CellMouseDown(sender As Object, e As DataGridViewCellMouseEventArgs) Handles MetroGrid1.CellMouseDown
        If e.RowIndex >= 0 And e.Button = MouseButtons.Right And Not MetroGrid1.Rows(e.RowIndex).Selected Then
            MetroGrid1.ClearSelection()
            MetroGrid1.Rows(e.RowIndex).Selected = True
        End If
    End Sub

    Private Sub MetroGrid1_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles MetroGrid1.CellMouseDoubleClick
        Dim Row As DataGridViewRow = MetroGrid1.Rows(e.RowIndex)
        If Not IsNothing(Row) Then
            Row.Selected = True
            swap_mod_state()
        End If
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

    ' ##### Public ################################################################################

    Public Sub UpdateUI(Args As main.ModuleArgs)
        MetroGrid1.Enabled = Args.Settings.Patched
        cmb_profiles.Enabled = Args.Settings.Patched And PathHelper.HasFiles(PathHelper.Mods)
    End Sub

    Public Sub SelectedProfile(Args As main.ModuleArgs)
        For Each vm As VermintideMod In Args.Mods
            vm.active = Args.SelectedProfile.Mods.Contains(vm.identifier)
        Next
        update_mods()
        RaiseEvent InstallMods()
    End Sub

    Public Sub RefreshList(Args As main.ModuleArgs)
        Dim scroll As Integer = MetroGrid1.FirstDisplayedScrollingRowIndex
        list_mods(Args)
        select_mod()
        RaiseEvent SelectProfile("")
        If scroll >= 0 And scroll <= MetroGrid1.Rows.Count Then
            MetroGrid1.FirstDisplayedScrollingRowIndex = scroll
        End If
        'RaiseEvent Output("Latest mod files were downloaded.")
    End Sub

    Public Sub UpdateMods()
        update_mods()
    End Sub

    ' ##### Functionality ################################################################################

    Private Sub update_mods()
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

    Private Sub select_a_mod()
        'If MetroGrid1.SelectedRows.Count = 0 Then
        If MetroGrid1.Rows.Count > 0 Then
            MetroGrid1.Rows(0).Selected = True
            select_mod()
        End If
        'End If
    End Sub

    Private Sub list_mods(Args As main.ModuleArgs)
        MetroGrid1.Rows.Clear()
        For Each Modfile As VermintideMod In Args.Mods
            MetroGrid1.Rows.Add("", Modfile.displayname, "", Modfile.version, "", "", Modfile.readme)
            Dim Row As DataGridViewRow = MetroGrid1.Rows(MetroGrid1.Rows.Count - 1)
            Row.InheritedStyle.BackColor = Color.LightPink
            Row.Cells(0).Value = My.Resources.uninstall_16
            Row.Tag = Modfile
            Row.ContextMenuStrip = ContextMenuStrip1
        Next
    End Sub

    Private Sub select_mod()
        Dim readme As String = String.Empty
        If MetroGrid1.SelectedRows.Count > 0 Then
            For Each Row As DataGridViewRow In MetroGrid1.SelectedRows
                Dim Modfile As VermintideMod = Row.Tag
                If Not IsNothing(Modfile) Then
                    reset_highlighting()
                    highlight_versions(Modfile)
                    highlight_requirements(Modfile)
                    readme += Modfile.readme + vbCrLf + vbCrLf
                    RaiseEvent SelectedMod(Modfile)
                End If
            Next
            RaiseEvent ShowReadMe(readme)
        End If
    End Sub

    Private Sub reset_highlighting()
        For Each Row As DataGridViewRow In MetroGrid1.Rows
            Row.DefaultCellStyle.BackColor = MetroGrid1.DefaultCellStyle.BackColor
        Next
    End Sub

    Private Sub highlight_requirements(Modfile As VermintideMod)
        For Each Row As DataGridViewRow In MetroGrid1.Rows
            Dim vm As VermintideMod = Row.Tag
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

    Private Sub highlight_versions(Modfile As VermintideMod)
        For Each Row As DataGridViewRow In MetroGrid1.Rows
            Dim vm As VermintideMod = Row.Tag
            If vm.mod_name = Modfile.mod_name Then
                If Not vm.version = Modfile.version Then
                    If Version.Compare(vm.version, Modfile.version) Then
                        Row.DefaultCellStyle.BackColor = Color.LightSkyBlue
                    Else
                        Row.DefaultCellStyle.BackColor = Color.LightGray
                    End If
                End If
            End If
        Next
    End Sub

    Private Sub swap_mod_state()
        For Each Row As DataGridViewRow In MetroGrid1.SelectedRows
            Dim Modfile As VermintideMod = Row.Tag
            Modfile.active = Not Modfile.active
            'RaiseEvent Output(String.Format("'{0}' activated in '{1}'.", Modfile.displayname, _settings.SelectedProfile))
            If Modfile.active Then
                RaiseEvent Output(String.Format("'{0}' v{1} activated.", Modfile.displayname, Modfile.version))
            Else
                RaiseEvent Output(String.Format("'{0}' v{1} deactivated.", Modfile.displayname, Modfile.version))
            End If
        Next
        mod_changed()
        RaiseEvent SaveProfile()
    End Sub

    Private Sub mod_changed()
        update_mods()
        RaiseEvent InstallMods()
    End Sub

    Private Sub DeleteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteToolStripMenuItem.Click
        For Each Row As DataGridViewRow In MetroGrid1.SelectedRows
            Dim VermintideMod As VermintideMod = Row.Tag
            If Not IsNothing(VermintideMod) Then
                If VermintideMod.active Then
                    VermintideMod.active = False
                    mod_changed()
                    RaiseEvent Output(String.Format("'{0}' v{1} deactivated.", VermintideMod.displayname, VermintideMod.version))
                    RaiseEvent SaveProfile()
                End If
                RaiseEvent ModDeleted(VermintideMod)
            End If
        Next
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        RaiseEvent RequestRefreshList()
    End Sub

End Class