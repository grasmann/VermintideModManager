Imports System.ComponentModel
Imports System.Net

Public Class ModuleModDownloader

    Public Class Download
        Public Property DisplayName As String
        Public Property Name As String
        Public Property Address As String
        Public Property Target As String
        Public Property Temp As String

        Private WithEvents _client As New WebClient

        Public Event DownloadFinished(Download As Download)
        Public Event ProgressChanged(Download As Download, Percentage As Integer)

        Public Sub New(File As ModuleModBrowser.file_info)
            DisplayName = File.DisplayName
            Name = File.Name
            Address = String.Format("http://www.vmf.heliohost.org/{0}", File.File)
            Target = String.Format("{0}/{1}", PathHelper.Mods, File.File)
            Temp = String.Format("{0}{1}", PathHelper.Temp, File.File.Replace("/", "\"))
            '_worker.WorkerSupportsCancellation = True
            '_worker.WorkerReportsProgress = True
            'start_download()
        End Sub

        Public Sub StartDownload()
            start_download()
        End Sub

        Private Sub start_download()
            Try
                If My.Computer.FileSystem.FileExists(Temp) Then
                    My.Computer.FileSystem.DeleteFile(Temp)
                End If
                _client.DownloadFileAsync(New Uri(Address), Temp)
                Debug.Print(String.Format("Downloading mod {0} from {1} to {2} ...", DisplayName, Address, Temp))
            Catch ex As Exception
                Debug.Print(ex.Message)
            End Try
        End Sub

        Private Sub _client_DownloadProgressChanged(sender As Object, e As DownloadProgressChangedEventArgs) Handles _client.DownloadProgressChanged
            'RaiseEvent ProgressChanged()
            Debug.Print(e.ProgressPercentage)
            RaiseEvent ProgressChanged(Me, e.ProgressPercentage)
        End Sub

        Private Sub _client_DownloadFileCompleted(sender As Object, e As AsyncCompletedEventArgs) Handles _client.DownloadFileCompleted
            Debug.Print("Finished")
            RaiseEvent DownloadFinished(Me)
        End Sub

    End Class

    Private _downloads As List(Of Download)

    Public Sub New()
        InitializeComponent()
        _downloads = New List(Of Download)
    End Sub

    'Public Sub AddDownload(DisplayName As String, Name As String, Address As String, Target As String)
    '    _downloads.Add(New Download(Name, Address, Target))
    '    Dim download As Download = _downloads(_downloads.Count - 1)
    '    new_downloads(New List(Of Download)({download}))
    'End Sub

    Public Sub AddDownload(Download As Download)
        _downloads.Add(Download)
        AddHandler Download.DownloadFinished, AddressOf download_finished
        AddHandler Download.ProgressChanged, AddressOf download_progress_changed
        new_downloads(New List(Of Download)({Download}))
        Download.StartDownload()
    End Sub

    'Public Sub AddDownloads(Downloads As List(Of Download))
    '    _downloads.AddRange(Downloads)
    '    new_downloads(Downloads)
    'End Sub

    Private Sub download_finished(Download As Download)
        _downloads.Remove(Download)
        For Each Row As DataGridViewRow In DataGridView1.Rows
            Dim dl As Download = Row.Tag
            If Not IsNothing(dl) Then
                If Download.Name = dl.Name Then
                    'DataGridView1.Rows.Remove(Row)
                    Exit Sub
                End If
            End If
        Next
    End Sub

    Private Sub download_progress_changed(Download As Download, Percentage As Integer)
        For Each Row As DataGridViewRow In DataGridView1.Rows
            Dim dl As Download = Row.Tag
            If Not IsNothing(dl) Then
                If Download.Name = dl.Name Then
                    Row.Cells(1).Value = Percentage
                End If
            End If
        Next
    End Sub

    Private Sub new_downloads(Downloads As List(Of Download))
        For Each download As Download In Downloads
            DataGridView1.Rows.Add(download.Name, "")
            Dim row As DataGridViewRow = DataGridView1.Rows(DataGridView1.Rows.Count - 1)
            row.Tag = download
        Next
    End Sub

    Private Sub DataGridView1_CellMouseDown(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseDown
        If e.RowIndex >= 0 Then
            If e.Button = MouseButtons.Right Then
                DataGridView1.ClearSelection()
                DataGridView1.Rows(e.RowIndex).Selected = True
            End If
        End If
    End Sub

End Class