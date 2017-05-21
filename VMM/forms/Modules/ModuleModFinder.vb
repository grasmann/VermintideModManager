Imports VMM
Imports WeifenLuo.WinFormsUI.Docking

Public Class ModuleModFinder

    Private WithEvents _find_mods As ModuleModBrowser
    Private WithEvents _downloader As ModuleModDownloader

    Public Event RequestCheckModsInstalled(Files As List(Of ModuleModBrowser.file_info))

    Public Sub New()
        InitializeComponent()
        _find_mods = New ModuleModBrowser
        _find_mods.Show(DockPanel1, DockState.Document)
        _downloader = New ModuleModDownloader
        _downloader.Show(DockPanel1, DockState.DockRight)
    End Sub

    Public Sub CheckModsInstalled(Files As List(Of ModuleModBrowser.file_info), Args As main.ModuleArgs)
        _find_mods.CheckModsInstalled(Files, Args)
    End Sub

    Private Sub _find_mods_RequestCheckModsInstalled(Files As List(Of ModuleModBrowser.file_info)) Handles _find_mods.RequestCheckModsInstalled
        RaiseEvent RequestCheckModsInstalled(Files)
    End Sub

End Class