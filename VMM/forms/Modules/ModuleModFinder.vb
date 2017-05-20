Imports System.ComponentModel
Imports System.Net
Imports Newtonsoft.Json
Imports System.Drawing

Public Class ModuleModFinder

    Private Class file_info
        Public Property Name As String
        Public Property Version As String
        Public Property Type As Integer
        Public Property File As String
    End Class

    Private WithEvents _fetcher As New BackgroundWorker

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

    Private Sub list_files(Files As List(Of file_info))
        DataGridView1.Rows.Clear()
        For Each file As file_info In Files
            DataGridView1.Rows.Add(file.Name, file.Version, "", file.Type)
        Next
    End Sub

    Private Sub _fetcher_DoWork(sender As Object, e As DoWorkEventArgs) Handles _fetcher.DoWork
        Dim client As New WebClient
        Dim url As String = String.Format("http://www.vmf.heliohost.org/file_list.php?mode={0}", e.Argument)
        Dim str As String = client.DownloadString(url)
        Dim files As List(Of file_info) = JsonConvert.DeserializeObject(Of List(Of file_info))(str)
        e.Result = files
    End Sub

    Private Sub _fetcher_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles _fetcher.RunWorkerCompleted
        list_files(e.Result)
    End Sub

End Class