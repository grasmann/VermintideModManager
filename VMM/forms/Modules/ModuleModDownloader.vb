Imports System.ComponentModel
Imports System.Net
Imports VMM

Public Class ModuleModDownloader

    Private WithEvents _downloader As New Downloader

    Public Event ModDownloaded(Path As String)

    Public Sub AddDownload(Downloads As List(Of Download))
        _downloader.AddDownloads(Downloads)
        new_downloads(Downloads)
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

    Private Sub _downloader_DownloadFinished(Download As Download) Handles _downloader.DownloadFinished
        ' Remove from list
        For Each Row As DataGridViewRow In DataGridView1.Rows
            Dim dl As Download = Row.Tag
            If Not IsNothing(dl) Then
                If Download.Name = dl.Name Then
                    Dim Icon As New DataGridViewImageCell
                    Icon.Value = My.Resources.install_16
                    Icon.Style.Padding = New Padding(6, 0, 0, 0)
                    Icon.ImageLayout = DataGridViewImageCellLayout.Normal
                    Icon.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                    Row.Cells(1) = Icon
                    Exit For
                End If
            End If
        Next
        ' Check mod file
        If ModHelper.TestMod(Download.Temp) Then
            If Not My.Computer.FileSystem.FileExists(Download.Target) Then
                My.Computer.FileSystem.CopyFile(Download.Temp, Download.Target)
                RaiseEvent ModDownloaded(Download.Target)
            End If
        End If
    End Sub

    Private Sub _downloader_ProgressChanged(Download As Download, Percentage As Integer) Handles _downloader.ProgressChanged
        For Each Row As DataGridViewRow In DataGridView1.Rows
            Dim dl As Download = Row.Tag
            If Not IsNothing(dl) Then
                If Download.Name = dl.Name And TypeOf (Row.Cells(1).Value) Is String Then
                    Row.Cells(1).Value = Percentage
                End If
            End If
        Next
    End Sub

End Class