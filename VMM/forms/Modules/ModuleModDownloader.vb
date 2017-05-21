Imports System.ComponentModel
Imports System.Net

Public Class ModuleModDownloader

    Private Class Download
        Public Property Address As String
        Public Property Target As String
        Private WithEvents _worker As New BackgroundWorker
        Public Event DownloadFinished(Download As Download)
        Public Sub New(Address As String, Target As String)
            Me.Address = Address
            Me.Target = Target
            _worker.WorkerSupportsCancellation = True
            _worker.WorkerReportsProgress = True
        End Sub

        Private Sub _worker_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles _worker.RunWorkerCompleted

        End Sub

        Private Sub _worker_DoWork(sender As Object, e As DoWorkEventArgs) Handles _worker.DoWork
            Dim client As New WebClient
            client.DownloadFile(Address, Target)
        End Sub

    End Class

End Class