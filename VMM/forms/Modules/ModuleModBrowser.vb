Imports System.ComponentModel
Imports System.Net
Imports Newtonsoft.Json
Imports System.Drawing
Imports VMM

Public Class ModuleModBrowser

    Private WithEvents _file_list As New FileList

    Public Event RequestCheckModsInstalled(Files As List(Of FileInfo))
    Public Event AddDownload(File As FileInfo)

    ' ##### Events ################################################################################

    Private Sub ModuleModFinder_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        ComboBox1.SelectedIndex = 0
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        fetch_info()
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        If e.RowIndex >= 0 And e.ColumnIndex = 4 Then
            Dim file As FileInfo = DataGridView1.Rows(e.RowIndex).Tag
            If Not IsNothing(file) Then RaiseEvent AddDownload(file)
        End If
    End Sub

    Private Sub _file_list_DownloadFinished(Files As List(Of FileInfo)) Handles _file_list.DownloadFinished
        list_files(Files)
    End Sub

    Private Sub DataGridView1_CellMouseDown(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseDown
        If e.RowIndex >= 0 And e.Button = MouseButtons.Right Then
            DataGridView1.ClearSelection()
            DataGridView1.Rows(e.RowIndex).Selected = True
        End If
    End Sub

    ' ##### Public ################################################################################

    Public Sub UpdateList()
        fetch_info()
    End Sub

    Public Sub CheckModsInstalled(Files As List(Of FileInfo), Args As main.ModuleArgs)
        check_mods_installed(Files, Args)
    End Sub

    ' ##### Events ################################################################################

    Private Sub fetch_info()
        If Not IsNothing(ComboBox1.SelectedItem) Then
            _file_list.StartDownload(ComboBox1.SelectedItem.ToString.ToLower)
        End If
    End Sub

    Public Sub check_mods_installed(Files As List(Of FileInfo), Args As main.ModuleArgs)
        For Each file As FileInfo In Files
            For Each vm As VermintideMod In Args.Mods
                If file.Name = vm.mod_name And file.Version = vm.version Then
                    file.Installed = True
                End If
            Next
        Next
    End Sub

    Private Sub list_files(Files As List(Of FileInfo))
        RaiseEvent RequestCheckModsInstalled(Files)
        Dim scroll As Integer = DataGridView1.FirstDisplayedScrollingRowIndex
        DataGridView1.Rows.Clear()
        For Each file As FileInfo In Files
            DataGridView1.Rows.Add(file.DisplayName, file.Version, String.Format("{0} KB", FormatNumber(file.Size / 1024, 2)), "", "", file.Type)
            Dim Row As DataGridViewRow = DataGridView1.Rows(DataGridView1.Rows.Count - 1)
            Row.Tag = file
            If file.Installed Then
                Row.Cells(3).Value = My.Resources.install_16
            Else
                Row.Cells(3).Value = My.Resources.uninstall_16
                Dim btn As New DataGridViewButtonCell
                btn.Value = "Download"
                Row.Cells(4) = btn
                Row.DefaultCellStyle.BackColor = Color.LightPink
            End If
        Next
        If scroll >= 0 And scroll <= DataGridView1.Rows.Count Then
            DataGridView1.FirstDisplayedScrollingRowIndex = scroll
        End If
    End Sub

    Private Sub btn_refresh_Click(sender As Object, e As EventArgs) Handles btn_refresh.Click
        fetch_info()
    End Sub

End Class