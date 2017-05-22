Imports VMM

Public Class About

    Private WithEvents _update_check As New ModManagerUpdateCheck
    Private WithEvents _update_download As Download

    Private Sub _update_check_NoUpdate() Handles _update_check.NoUpdate
        lbl_up_to_date.Visible = True
        lbl_checking_update.Visible = False
        pb_up_to_date.Visible = True
    End Sub

    Private Sub _update_check_UpdateAvailable(File As FileInfo) Handles _update_check.UpdateAvailable
        lbl_update.Visible = True
        lbl_update.Text = String.Format("Update {0} is available.", File.Version)
        btn_update.Visible = True
        btn_update.Tag = File
        lbl_checking_update.Visible = False
    End Sub

    Private Sub _update_download_DownloadFinished(Download As Download) Handles _update_download.DownloadFinished
        ProgressBar1.Visible = False
        'Process.Start(Download.Temp)
        Dim Updater As String = String.Format("{0}\{1}", Application.StartupPath, "Updater.exe")
        If My.Computer.FileSystem.FileExists(Updater) Then
            Process.Start(Updater, Download.Temp)
            Application.Exit()
        Else
            Process.Start(Download.Temp)
        End If
        'Using zip As ZipFile = ZipFile.Read(Path)
        '    'zip.ExtractAll(PathHelper.)
        'End Using
        'Debug.Print(Download.Temp)
    End Sub

    Private Sub _update_download_ProgressChanged(Download As Download, Percentage As Integer) Handles _update_download.ProgressChanged
        If ProgressBar1.Visible Then
            ProgressBar1.Value = Percentage
        End If
    End Sub

    Private Sub About_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lbl_version.Text = Version.Current
    End Sub

    Private Sub About_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        lbl_update.Visible = False
        btn_update.Visible = False
        lbl_checking_update.Visible = True
        pb_up_to_date.Visible = False
        lbl_up_to_date.Visible = False
        ProgressBar1.Visible = False
        _update_check.CheckForUpdate()
    End Sub

    Private Sub btn_update_Click(sender As Object, e As EventArgs) Handles btn_update.Click
        Dim File As FileInfo = btn_update.Tag
        If Not IsNothing(File) Then
            btn_update.Visible = False
            ProgressBar1.Visible = True
            _update_download = New Download(File)
            _update_download.StartDownload()
        End If
    End Sub

End Class