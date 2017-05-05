Imports System.ComponentModel
Imports System.Net
Imports Ionic.Zip
Imports Newtonsoft.Json

Public Class ModuleDownload

    Private Const _mod_url As String = "http://iamlupo.nl/WarhammerDerp/Vermitide-Mod-Framework-0.15.4.zip"

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
        'RaiseEvent DownloadProgressChanged(e.ProgressPercentage)
        ProgressBar1.Value = e.ProgressPercentage
    End Sub

    Private Sub _client_DownloadFileCompleted(sender As Object, e As AsyncCompletedEventArgs) Handles _client.DownloadFileCompleted
        'RaiseEvent DownloadFinished(_download_type, _path)
        Using zip As ZipFile = ZipFile.Read(_path)
            zip.ExtractAll(PathHelper.Repository)
        End Using
        Application.DoEvents()
        RaiseEvent DownloadFinished()
        Me.Close()
    End Sub

    Private Sub ModuleDownload_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub ModuleDownload_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        _path = Environment.GetFolderPath(Environment.SpecialFolder.InternetCache) + "\Vermitide-Mod-Framework-0.15.4.zip"
        If My.Computer.FileSystem.FileExists(_path) Then
            My.Computer.FileSystem.DeleteFile(_path)
        End If
        _client.DownloadFileAsync(New Uri(_mod_url), _path)

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

    End Sub

End Class