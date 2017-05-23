Imports System.ComponentModel
Imports System.Net
Imports Newtonsoft.Json

Public Class UpdateCheck

    Private WithEvents _check_update As New BackgroundWorker

    Private _mode As String
    Private _version As String

    Public Event UpdateAvailable(File As FileInfo)
    Public Event NoUpdate()

    Public Sub New(Mode As String, Version As String)
        _mode = Mode
        _version = Version
    End Sub

    Public Sub CheckForUpdate()
        If Not _check_update.IsBusy Then _check_update.RunWorkerAsync()
    End Sub

    Private Sub _check_update_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles _check_update.RunWorkerCompleted
        Try
            Dim file As FileInfo = e.Result
            If Not IsNothing(file) Then
                RaiseEvent UpdateAvailable(file)
            Else
                RaiseEvent NoUpdate()
            End If
        Catch ex As Exception
            Debug.Print(ex.Message)
        End Try
    End Sub

    Private Sub _check_update_DoWork(sender As Object, e As DoWorkEventArgs) Handles _check_update.DoWork
        Try
            Dim client As New WebClient
            Dim json As String = client.DownloadString(String.Format("{0}file_list.php?mode={1}", ServerHelper.DomainUrl, _mode))
            Dim files As List(Of FileInfo) = JsonConvert.DeserializeObject(Of List(Of FileInfo))(json)
            Dim file As FileInfo = files(files.Count - 1)
            If Compare(file.Version, _version) Then
                Debug.Print("New version available.")
                e.Result = file
            End If
        Catch ex As Exception
            Debug.Print(ex.Message)
        End Try
    End Sub

End Class
