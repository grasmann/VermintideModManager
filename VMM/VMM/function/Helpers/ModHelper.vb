Imports System.IO
Imports Ionic.Zip
Imports Newtonsoft.Json

Module ModHelper

    Public Function FindMods() As List(Of VermintideMod)
        Debug.Print("Finding Mods")
        Dim Mods As New List(Of VermintideMod)
        If My.Computer.FileSystem.DirectoryExists(PathHelper.Mods) Then
            Dim di As New DirectoryInfo(PathHelper.Mods)
            Dim fiArr As FileInfo() = di.GetFiles()
            For Each fri As FileInfo In fiArr
                If fri.Extension = ".mod" Then
                    Dim _mod As VermintideMod = ReadMod(fri.FullName)
                    If Not IsNothing(_mod) Then
                        Mods.Add(_mod)
                    End If
                End If
            Next
        End If
        Return Mods
    End Function

    Private Function ReadMod(Path As String) As VermintideMod
        Dim _mod As VermintideMod = Nothing
        Dim _readme As String = String.Empty
        Dim _content As New List(Of String)
        Using zip As ZipFile = ZipFile.Read(Path)
            For Each e As ZipEntry In zip
                If e.FileName = "config.json" Then
                    Using s As Ionic.Crc.CrcCalculatorStream = e.OpenReader()
                        Dim sr As StreamReader = New StreamReader(s)
                        _mod = JsonConvert.DeserializeObject(Of VermintideMod)(sr.ReadToEnd())
                    End Using
                End If
                If e.FileName = "readme.txt" Then
                    Using s As Ionic.Crc.CrcCalculatorStream = e.OpenReader()
                        Dim sr As StreamReader = New StreamReader(s)
                        _readme = sr.ReadToEnd()
                    End Using
                End If
                _content.Add(e.FileName)
            Next
        End Using
        _mod.content = _content
        _mod.readme = _readme
        _mod.path = Path
        _mod.target = VermintideHelper.Binaries + "\" + Mid(_mod.path, PathHelper.Repository.Length + 2)
        _mod.folder = Mid(_mod.target, 1, InStrRev(_mod.target, "\"))
        _mod.active = False 'My.Computer.FileSystem.FileExists(_mod.target)

        Return _mod
    End Function

    Public Sub OpenFile(Path As String, ByRef File As String)
        If Path = File Then
            Process.Start(Path)
        End If
        Using zip As ZipFile = ZipFile.Read(Path)
            For Each e As ZipEntry In zip
                If e.FileName = File Then
                    Dim t As String = IO.Path.GetTempPath()
                    e.Extract(t, ExtractExistingFileAction.OverwriteSilently)
                    Dim p As String = String.Format("{0}{1}", IO.Path.GetTempPath(), File)
                    'Debug.Print(p)
                    Process.Start(p)
                End If
            Next
        End Using
    End Sub

End Module
