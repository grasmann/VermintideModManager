Imports System.ComponentModel
Imports System.Net
Imports Ionic.Zip
Imports Newtonsoft.Json

Public Class ModuleDownload

    Private Const _mod_url As String = "http://www.vmf.heliohost.org/Vermitide-Mod-Framework-0.15.5.zip"

    Private _download_type As DownloadType
    Private _path As String

    Private WithEvents _client As New WebClient

    Public Event DownloadFinished()

    Public Enum DownloadType
        Framework
    End Enum

    Public Sub New(DownloadType As DownloadType, Text As String, Optional URL As String = "")
        InitializeComponent()
        Me.Label1.Text = Text
        _download_type = DownloadType
    End Sub

    Private Sub _client_DownloadProgressChanged(sender As Object, e As DownloadProgressChangedEventArgs) Handles _client.DownloadProgressChanged
        ProgressBar1.Value = e.ProgressPercentage
    End Sub

    Private Sub _client_DownloadFileCompleted(sender As Object, e As AsyncCompletedEventArgs) Handles _client.DownloadFileCompleted
        extract_mod()
    End Sub

    Private Sub ModuleDownload_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        start_download()
    End Sub

    Private Sub start_download()
        _path = Environment.GetFolderPath(Environment.SpecialFolder.InternetCache) + "\Vermitide-Mod-Framework-0.15.4.zip"
        If My.Computer.FileSystem.FileExists(_path) Then
            My.Computer.FileSystem.DeleteFile(_path)
        End If
        _client.DownloadFileAsync(New Uri(_mod_url), _path)
    End Sub

    Private Sub extract_mod()
        Using zip As ZipFile = ZipFile.Read(_path)
            zip.ExtractAll(PathHelper.Repository)
        End Using
        Application.DoEvents()
        RaiseEvent DownloadFinished()
        Me.Close()
    End Sub

End Class