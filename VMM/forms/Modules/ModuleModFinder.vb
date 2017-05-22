﻿Imports VMM
Imports WeifenLuo.WinFormsUI.Docking

Public Class ModuleModFinder

    Private WithEvents _find_mods As ModuleModBrowser
    Private WithEvents _downloader As ModuleModDownloader

    Public Event RequestCheckModsInstalled(Files As List(Of FileInfo))
    Public Event DownloadFinished()

    Public Sub New()
        InitializeComponent()
        _find_mods = New ModuleModBrowser
        _find_mods.Show(DockPanel1, DockState.Document)
        _downloader = New ModuleModDownloader
        _downloader.Show(DockPanel1, DockState.DockRight)
    End Sub

    Public Sub CheckModsInstalled(Files As List(Of FileInfo), Args As main.ModuleArgs)
        _find_mods.CheckModsInstalled(Files, Args)
    End Sub

    Private Sub _find_mods_RequestCheckModsInstalled(Files As List(Of FileInfo)) Handles _find_mods.RequestCheckModsInstalled
        RaiseEvent RequestCheckModsInstalled(Files)
    End Sub

    Private Sub _find_mods_AddDownload(File As FileInfo) Handles _find_mods.AddDownload
        Dim Download As New Download(File)
        _downloader.AddDownload(New List(Of Download)({Download}))
    End Sub

    Private Sub _downloader_ModDownloaded(Path As String) Handles _downloader.ModDownloaded
        Debug.Print(Path)
        RaiseEvent DownloadFinished()
        _find_mods.UpdateList()
    End Sub

End Class