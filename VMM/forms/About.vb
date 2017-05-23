Imports VMM
Imports Ionic.Zip
Imports System.ComponentModel

Public Class About

    Private WithEvents _update_check As New UpdateCheck("manager", Current)
    Private WithEvents _update_download As Download
    Private WithEvents _framework_check As New UpdateCheck("framework", ModHelper.FrameworkVersion)
    Private WithEvents _framework_download As Download
    Private WithEvents _framework_extract As New BackgroundWorker

    ' ##### Manager Events ################################################################################

    Private Sub _update_check_NoUpdate() Handles _update_check.NoUpdate
        manager_no_update()
    End Sub

    Private Sub _update_check_UpdateAvailable(File As FileInfo) Handles _update_check.UpdateAvailable
        manager_update(File)
    End Sub

    Private Sub _update_download_DownloadFinished(Download As Download) Handles _update_download.DownloadFinished
        download_finished(Download)
    End Sub

    Private Sub _update_download_ProgressChanged(Download As Download, Percentage As Integer) Handles _update_download.ProgressChanged
        If bar_manager.Visible Then bar_manager.Value = Percentage
    End Sub

    Private Sub btn_manager_Click(sender As Object, e As EventArgs) Handles btn_manager.Click
        manager_download()
    End Sub

    ' ##### Events ################################################################################

    Private Sub About_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lbl_version.Text = Version.Current
    End Sub

    Private Sub About_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        init()
    End Sub

    ' ##### Framework Events ################################################################################

    Private Sub _framework_check_NoUpdate() Handles _framework_check.NoUpdate
        framework_no_update()
    End Sub

    Private Sub _framework_check_UpdateAvailable(File As FileInfo) Handles _framework_check.UpdateAvailable
        framework_update(File)
    End Sub

    Private Sub btn_framework_Click(sender As Object, e As EventArgs) Handles btn_framework.Click
        'Debug.Print("Download Framework")
        framework_download()
    End Sub

    Private Sub _framework_download_DownloadFinished(Download As Download) Handles _framework_download.DownloadFinished
        framework_download_finished(Download)
    End Sub

    Private Sub _framework_download_ProgressChanged(Download As Download, Percentage As Integer) Handles _framework_download.ProgressChanged
        If bar_framework.Visible Then bar_framework.Value = Percentage
    End Sub

    ' ##### Form ################################################################################

    Private Sub init()
        manager_init()
        framework_init()
    End Sub

    ' ##### Manager ################################################################################

    Private Sub manager_init()
        lbl_update.Visible = False
        btn_manager.Visible = False
        lbl_checking_update.Visible = True
        pb_up_to_date.Visible = False
        lbl_up_to_date.Visible = False
        bar_manager.Visible = False
        _update_check.CheckForUpdate()
    End Sub

    Private Sub manager_no_update()
        lbl_up_to_date.Visible = True
        lbl_checking_update.Visible = False
        pb_up_to_date.Visible = True
    End Sub

    Private Sub manager_update(File As FileInfo)
        lbl_update.Visible = True
        lbl_update.Text = String.Format("Mod Manager {0} is available", File.Version)
        btn_manager.Visible = True
        btn_manager.Tag = File
        lbl_checking_update.Visible = False
    End Sub

    Private Sub manager_download()
        Dim File As FileInfo = btn_manager.Tag
        If Not IsNothing(File) Then
            btn_framework.Enabled = False
            btn_manager.Visible = False
            bar_manager.Visible = True
            _update_download = New Download(File)
            _update_download.StartDownload()
            lbl_update.Text = String.Format("Downloading Mod Manager {0} ...", File.Version)
        End If
    End Sub

    Private Sub download_finished(Download As Download)
        bar_manager.Visible = False
        Dim Updater As String = String.Format("{0}\{1}", Application.StartupPath, "Updater.exe")
        If My.Computer.FileSystem.FileExists(Updater) Then
            Process.Start(Updater, Download.Temp)
            Application.Exit()
        Else
            Process.Start(Download.Temp)
        End If
    End Sub

    ' ##### Framework ################################################################################

    Private Sub framework_init()
        lbl_framework_checking.Visible = True
        lbl_framework_up_to_date.Visible = False
        pb_framework.Visible = False
        lbl_framework_update_available.Visible = False
        btn_framework.Visible = False
        bar_framework.Visible = False
        If String.IsNullOrEmpty(ModHelper.FrameworkVersion) Then
            _framework_check = New UpdateCheck("framework", "0.0.0")
        End If
        _framework_check.CheckForUpdate()
    End Sub

    Private Sub framework_no_update()
        lbl_framework_checking.Visible = False
        lbl_framework_up_to_date.Visible = True
        pb_framework.Visible = True
    End Sub

    Private Sub framework_update(File As FileInfo)
        lbl_framework_update_available.Visible = True
        lbl_framework_update_available.Text = String.Format("Mod Framework {0} is available", File.Version)
        btn_framework.Visible = True
        btn_framework.Tag = File
        lbl_framework_checking.Visible = False
    End Sub

    Private Sub framework_download()
        Dim File As FileInfo = btn_framework.Tag
        If Not IsNothing(File) Then
            btn_manager.Enabled = False
            btn_framework.Visible = False
            bar_framework.Visible = True
            _framework_download = New Download(File)
            _framework_download.StartDownload()
            lbl_framework_update_available.Text = String.Format("Downloading Mod Framework {0} ...", File.Version)
        End If
    End Sub

    Private Sub framework_download_finished(Download As Download)
        bar_framework.Visible = False
        btn_manager.Enabled = True
        lbl_framework_update_available.Text = "Waiting for Vermintide to exit ..."
        _framework_extract.RunWorkerAsync(Download.Temp)
    End Sub

    Private Sub _framework_extract_DoWork(sender As Object, e As DoWorkEventArgs) Handles _framework_extract.DoWork
        framework_extract(e.Argument)
    End Sub

    Private Sub framework_extract(Path As String)
        Try
            ' Wait for vermintide to close
            Dim vermintide As List(Of Process) = Process.GetProcessesByName("vermintide").ToList
            While vermintide.Count > 0
                vermintide = Process.GetProcessesByName("vermintide").ToList
            End While
            ' Extract
            Using zip As ZipFile = ZipFile.Read(Path)
                zip.ExtractAll(PathHelper.Repository, ExtractExistingFileAction.OverwriteSilently)
            End Using
        Catch ex As Exception
            Debug.Print(ex.Message)
            MsgBox(ex.Message, MsgBoxStyle.OkOnly, "Error")
        End Try
    End Sub

    Private Sub _framework_extract_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles _framework_extract.RunWorkerCompleted
        _framework_check = New UpdateCheck("framework", ModHelper.FrameworkVersion)
        framework_init()
    End Sub

End Class