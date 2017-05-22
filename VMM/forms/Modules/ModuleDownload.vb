Imports System.ComponentModel
Imports System.Net
Imports Ionic.Zip
Imports Newtonsoft.Json
Imports VMM

Public Class ModuleDownload

    Private _download_type As DownloadType
    Private WithEvents _downloader As New Downloader
    Private WithEvents _file_list As New FileList

    Public Event DownloadFinished()

    Public Enum DownloadType
        Framework
    End Enum

    Public Sub New(DownloadType As DownloadType, Text As String, Optional URL As String = "")
        InitializeComponent()
        Me.Label1.Text = Text
    End Sub

    Private Sub ModuleDownload_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        start_download()
    End Sub

    Private Sub start_download()
        _file_list.StartDownload("framework")
    End Sub

    Private Sub extract_mod(Path As String)
        Using zip As ZipFile = ZipFile.Read(Path)
            zip.ExtractAll(PathHelper.Repository)
        End Using
        Application.DoEvents()
        RaiseEvent DownloadFinished()
        Me.Close()
    End Sub

    Private Sub _file_list_DownloadFinished(Files As List(Of FileInfo)) Handles _file_list.DownloadFinished
        If Not IsNothing(Files) AndAlso Files.Count > 0 Then
            _downloader.AddDownloads(New List(Of Download)({New Download(Files(Files.Count - 1))}))
        End If
    End Sub

    Private Sub _downloader_DownloadFinished(Download As Download) Handles _downloader.DownloadFinished
        extract_mod(Download.Temp)
    End Sub

    Private Sub _downloader_ProgressChanged(Download As Download, Percentage As Integer) Handles _downloader.ProgressChanged
        ProgressBar1.Value = Percentage
    End Sub

End Class