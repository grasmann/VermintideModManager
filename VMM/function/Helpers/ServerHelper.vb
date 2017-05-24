Imports System.ComponentModel
Imports System.Net
Imports Newtonsoft.Json

Public Class Download
    Public Property DisplayName As String
    Public Property Name As String
    Public Property Address As String
    Public Property Target As String
    Public Property Temp As String
    Public Property Version As String
    Public Property Authors As String

    Private WithEvents _client As New WebClient

    Public Event DownloadFinished(Download As Download)
    Public Event ProgressChanged(Download As Download, Percentage As Integer)

    Public Sub New(File As FileInfo)
        DisplayName = File.DisplayName
        Name = File.Name
        Address = String.Format("{0}{1}", ServerHelper.DomainUrl, File.File)
        Target = String.Format("{0}\{1}", PathHelper.Repository, File.File.Replace("/", "\"))
        Temp = String.Format("{0}{1}", PathHelper.Temp, File.File.Replace("/", "\"))
        Version = File.Version
        Authors = File.Authors
    End Sub

    Public Sub StartDownload()
        If Not _client.IsBusy Then
            start_download()
        End If
    End Sub

    Private Sub start_download()
        Try
            Dim mods As String = PathHelper.Temp + "mods"
            If Not My.Computer.FileSystem.DirectoryExists(mods) Then
                My.Computer.FileSystem.CreateDirectory(mods)
            End If
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
        Debug.Print(e.ProgressPercentage)
        RaiseEvent ProgressChanged(Me, e.ProgressPercentage)
    End Sub

    Private Sub _client_DownloadFileCompleted(sender As Object, e As AsyncCompletedEventArgs) Handles _client.DownloadFileCompleted
        Debug.Print("Finished")
        RaiseEvent DownloadFinished(Me)
    End Sub

End Class

Public Class Downloader

    Private _downloads As New List(Of Download)

    Public Event DownloadFinished(Download As Download)
    Public Event ProgressChanged(Download As Download, Percentage As Integer)

    Public Sub AddDownloads(Downloads As List(Of Download))
        For Each Download As Download In Downloads
            _downloads.Add(Download)
            AddHandler Download.DownloadFinished, AddressOf download_finished
            AddHandler Download.ProgressChanged, AddressOf download_progress_changed
            Download.StartDownload()
        Next
    End Sub

    Private Sub download_finished(Download As Download)
        RaiseEvent DownloadFinished(Download)
        _downloads.Remove(Download)
    End Sub

    Private Sub download_progress_changed(Download As Download, Percentage As Integer)
        RaiseEvent ProgressChanged(Download, Percentage)
    End Sub

End Class

Public Class FileList

    Private WithEvents _client As New WebClient

    Public Event DownloadFinished(Files As List(Of FileInfo))
    Public Event ProgressChanged(Percentage As Integer)

    Public Sub StartDownload(Mode As String)
        If Not _client.IsBusy Then
            start_download(Mode)
        End If
    End Sub

    Private Sub start_download(Mode As String)
        Dim query As String = ServerHelper.FileListUrl
        If Not String.IsNullOrEmpty(Mode) Then
            query += String.Format("?mode={0}", Mode)
        End If
        Try
            _client.DownloadStringAsync(New Uri(query))
        Catch ex As Exception
            Debug.Print(ex.Message)
        End Try
    End Sub

    Private Sub _client_DownloadProgressChanged(sender As Object, e As DownloadProgressChangedEventArgs) Handles _client.DownloadProgressChanged
        RaiseEvent ProgressChanged(e.ProgressPercentage)
    End Sub

    Private Sub _client_DownloadStringCompleted(sender As Object, e As DownloadStringCompletedEventArgs) Handles _client.DownloadStringCompleted
        Dim files As New List(Of FileInfo)
        Try
            files = JsonConvert.DeserializeObject(Of List(Of FileInfo))(e.Result)
        Catch ex As Exception
            Debug.Print(ex.Message)
        End Try
        RaiseEvent DownloadFinished(files)
    End Sub

End Class

Public Class FileInfo
    Public Property Name As String
    Public Property Version As String
    Public Property Type As Integer
    Public Property File As String
    Public Property Size As Integer
    Public Property Authors As String
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

Public Module ServerHelper

    Public Const DomainUrl As String = "http://www.grasmann.heliohost.org/"
    Public Const FileListUrl As String = "http://www.grasmann.heliohost.org/file_list.php"

End Module
