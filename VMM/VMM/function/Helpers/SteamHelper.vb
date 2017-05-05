Imports System
Imports System.IO
Imports System.ComponentModel

Module SteamHelper

    Private _game_folders As New Dictionary(Of Integer, String)

    Public ReadOnly Property InstallPath As String
        Get
            Return GetSteamInstallPath()
        End Get
    End Property

    Public ReadOnly Property LibraryFile As String
        Get
            Return String.Format("{0}\steamapps\libraryfolders.vdf", InstallPath)
        End Get
    End Property

    Public ReadOnly Property Libraries As List(Of String)
        Get
            Return GetSteamLibraries()
        End Get
    End Property

    Public ReadOnly Property GameFolder(AppID As Integer) As String
        Get
            Dim Folder As String
            If _game_folders.ContainsKey(AppID) Then
                Folder = _game_folders(AppID)
            Else
                Folder = GetGameFolder(AppID)
                _game_folders.Add(AppID, Folder)
            End If
            Return Folder
        End Get
    End Property
    Public ReadOnly Property GameFolder(AppID As String) As String
        Get
            Return GetGameFolder(AppID)
        End Get
    End Property

    Private Function GetSteamInstallPath() As String
        Return My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\WOW6432Node\Valve\Steam", "InstallPath", Nothing)
    End Function

    Private Function GetSteamLibraries() As List(Of String)
        Debug.Print("Getting Libraries")
        Dim Libraries As New List(Of String)
        If My.Computer.FileSystem.FileExists(LibraryFile) Then
            Using sr As New StreamReader(LibraryFile)
                Do While sr.Peek() >= 0
                    Dim Line As String = sr.ReadLine()
                    If InStr(Line, ":") Then
                        Dim start As Integer = InStr(Line, ":") - 1
                        Dim ende As Integer = InStrRev(Line, """") - start
                        Dim Library As String = Mid(Line, start, ende)
                        Library = Library.Replace("\\", "\")
                        Libraries.Add(Library)
                    End If
                Loop
            End Using
        End If
        Libraries.Add(SteamHelper.InstallPath)
        Return Libraries
    End Function

    Private Function GetGameFolder(AppID As Integer) As String
        Return GetGameFolder(AppID.ToString)
    End Function
    Private Function GetGameFolder(AppID As String) As String
        Debug.Print("Getting Game Folder")
        For Each Library As String In Libraries
            Dim ACFFile As String = Library + String.Format("\steamapps\appmanifest_{0}.acf", AppID)
            If My.Computer.FileSystem.FileExists(ACFFile) Then
                Using sr As New StreamReader(ACFFile)
                    Do While sr.Peek() >= 0
                        Dim Line As String = sr.ReadLine()
                        If InStr(Line, "installdir") Then
                            Dim s As Integer = InStr(Line, """installdir""") + 12
                            Dim e As Integer = InStrRev(Line, """")
                            Dim Folder As String = Mid(Line, s, e)
                            Folder = Folder.Replace("""", "")
                            Folder = Folder.Trim()
                            Return String.Format("{0}\steamapps\common\{1}", Library, Folder)
                        End If
                    Loop
                End Using
            End If
        Next
        Return String.Empty
    End Function

    Public Sub LaunchGame(ByVal AppID As Integer)
        LaunchGame(AppID.ToString)
    End Sub
    Public Sub LaunchGame(ByVal AppID As String)
        Dim path As String = String.Format("{0}\steam.exe", PathHelper.Steam)
        If My.Computer.FileSystem.FileExists(path) Then
            Dim p As New Process()
            p.StartInfo.FileName = path
            p.StartInfo.Arguments = String.Format("-applaunch {0}", AppID)
            p.Start()
        Else
            MsgBox("Steam doesn't seem to be installed.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Launch Error")
        End If
    End Sub

End Module
