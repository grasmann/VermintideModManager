Imports System
Imports System.IO

Module PathHelper

    Public ReadOnly Property ModLoader As String
        Get
            Return String.Format("{0}\mod_loader", Repository)
        End Get
    End Property

    Public ReadOnly Property Repository As String
        Get
            Return String.Format("{0}\Mod", Application.StartupPath)
        End Get
    End Property

    Public ReadOnly Property Mods As String
        Get
            Return String.Format("{0}\Mods", Repository)
        End Get
    End Property

    'Public ReadOnly Property Vermintide As String
    '    Get
    '        Return VermintideHelper.Path
    '    End Get
    'End Property

    Public ReadOnly Property AppData As String
        Get
            Dim localappdata As String = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)
            Dim path As String = String.Format("{0}\VermintideModManager", localappdata)
            If Not My.Computer.FileSystem.DirectoryExists(path) Then
                My.Computer.FileSystem.CreateDirectory(path)
            End If
            Return path
        End Get
    End Property

    Public ReadOnly Property Profiles As String
        Get
            Return String.Format("{0}\profiles.xml", AppData)
        End Get
    End Property

    Public ReadOnly Property Settings As String
        Get
            Return String.Format("{0}\settings.xml", AppData)
        End Get
    End Property

    Public ReadOnly Property Steam As String
        Get
            Return SteamHelper.InstallPath
        End Get
    End Property

    Public Function HasFiles(Path As String) As Boolean
        Try
            Dim di As New DirectoryInfo(Path)
            Dim fiArr As FileInfo() = di.GetFiles()
        Catch ex As Exception
            Return False
        End Try
        Return True
    End Function

    Public Function ExtractFolder(Path As String) As String
        Dim folder As String = Left(Path, InStrRev(Path, "\"))
        Return folder
    End Function

End Module
