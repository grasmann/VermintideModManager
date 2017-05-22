Imports System.ComponentModel
Imports System.Net
Imports Newtonsoft.Json
Imports System.Drawing

Public Class ModuleModBrowser

    Public Class file_info
        Public Property Name As String
        Public Property Version As String
        Public Property Type As Integer
        Public Property File As String
        Public Property Size As Integer
        Public Property Installed As Boolean
        Public ReadOnly Property DisplayName As String
            Get
                Dim dname As String = String.Empty
                For Each c As Char In Name
                    If c.ToString = Char.ToUpper(c).ToString Then
                        dname += " " + c.ToString
                    Else
                        dname += c.ToString
                    End If
                Next
                Return dname
            End Get
        End Property
    End Class

    Private WithEvents _fetcher As New BackgroundWorker

    Public Event RequestCheckModsInstalled(Files As List(Of file_info))
    'Public Event AddDownload(Download As ModuleModDownloader.Download)
    Public Event AddDownload(File As ModuleModBrowser.file_info)

    Private Sub ModuleModFinder_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        ComboBox1.SelectedIndex = 0
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        fetch_info()
    End Sub

    Private Sub fetch_info()
        If Not _fetcher.IsBusy Then
            _fetcher.RunWorkerAsync(ComboBox1.SelectedItem.ToString.ToLower)
        End If
    End Sub

    Public Sub CheckModsInstalled(Files As List(Of file_info), Args As main.ModuleArgs)
        For Each file As file_info In Files
            For Each vm As VermintideMod In Args.Mods
                If file.Name = vm.mod_name And file.Version = vm.version Then
                    file.Installed = True
                End If
            Next
        Next
    End Sub

    Private Sub list_files(Files As List(Of file_info))
        RaiseEvent RequestCheckModsInstalled(Files)
        DataGridView1.Rows.Clear()
        For Each file As file_info In Files
            DataGridView1.Rows.Add(file.DisplayName, file.Version, String.Format("{0} KB", FormatNumber(file.Size / 1024, 2)), "", "", file.Type)
            Dim Row As DataGridViewRow = DataGridView1.Rows(DataGridView1.Rows.Count - 1)
            Row.Tag = file
            If file.Installed Then
                Row.Cells(3).Value = My.Resources.install_16
                'Row.Cells(4).Value = "Installed"
                'Row.DefaultCellStyle.BackColor = Color.LightGreen
            Else
                Row.Cells(3).Value = My.Resources.uninstall_16
                'Row.Cells(4).Value = "Not Installed"
                Dim btn As New DataGridViewButtonCell
                btn.Value = "Download"
                Row.Cells(4) = btn
                'Row.Cells(4) = New DataGridViewButtonCell

                Row.DefaultCellStyle.BackColor = Color.LightPink

            End If
        Next
    End Sub

    Private Sub _fetcher_DoWork(sender As Object, e As DoWorkEventArgs) Handles _fetcher.DoWork
        Try
            Dim client As New WebClient
            Dim url As String = String.Format("{0}file_list.php?mode={1}", ServerHelper._domain_url, e.Argument)
            Dim str As String = client.DownloadString(url)
            Dim files As List(Of file_info) = JsonConvert.DeserializeObject(Of List(Of file_info))(str)
            e.Result = files
        Catch ex As Exception
            Debug.Print(ex.Message)
        End Try
    End Sub

    Private Sub _fetcher_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles _fetcher.RunWorkerCompleted
        If Not IsNothing(e.Result) Then
            list_files(e.Result)
        End If
    End Sub

    Private Sub DataGridView1_CellMouseDown(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseDown
        If e.RowIndex >= 0 Then
            If e.Button = MouseButtons.Right Then
                DataGridView1.ClearSelection()
                DataGridView1.Rows(e.RowIndex).Selected = True
            End If
        End If
    End Sub

    'Private Function mod_address(File As String)

    'End Function

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        If e.RowIndex >= 0 Then
            If e.ColumnIndex = 4 Then
                Dim file As ModuleModBrowser.file_info = DataGridView1.Rows(e.RowIndex).Tag
                If Not IsNothing(file) Then
                    'Debug.Print(String.Format("Downloading mod {0} from http://www.grasmann.heliohost.org/{1} ...", file.DisplayName, file.File))
                    'RaiseEvent AddDownload(file) '.DisplayName, String.Format("http://www.grasmann.heliohost.org/{0}", file.File), "")
                End If
            End If
        End If
    End Sub

End Class