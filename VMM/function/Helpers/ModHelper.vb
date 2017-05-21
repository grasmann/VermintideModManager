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
        ' outdated
        For Each _mod As VermintideMod In Mods
            For Each _c As VermintideMod In Mods
                If Not _mod.identifier = _c.identifier Then
                    If _mod.mod_name = _c.mod_name Then
                        'Debug.Print(_mod.mod_name)
                        If Version.Compare(_mod.version, _c.version) Then
                            _c.outdated = True
                        Else
                            _mod.outdated = True
                        End If
                    End If
                End If
            Next
        Next
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

    Public Sub OpenFile(Path As String, File As String)
        If Path = File Then
            Process.Start(Path)
        End If
        Using zip As ZipFile = ZipFile.Read(Path)
            For Each e As ZipEntry In zip
                If e.FileName = File Then
                    Dim t As String = PathHelper.Temp
                    e.Extract(t, ExtractExistingFileAction.OverwriteSilently)
                    Dim p As String = String.Format("{0}{1}", t, File)
                    'Debug.Print(p)
                    Process.Start(p)
                End If
            Next
        End Using
    End Sub

    Public Sub OpenSource(Name As String, File As String, Optional Overwrite As String = "")
        If String.IsNullOrEmpty(Overwrite) Then
            Overwrite = PathHelper.ModLoader
        Else
            Overwrite += "mod_loader\"
        End If
        If Not Right(Overwrite, 1) = "\" Then Overwrite += "\"
        Dim file_path As String = String.Empty
        If InStr(File, ".mod") Then
            file_path = String.Format("{0}mods\{1}\", Overwrite, Name)
        Else
            file_path = String.Format("{0}mods\{1}\{2}", Overwrite, Name, File)
        End If
        If My.Computer.FileSystem.FileExists(file_path) Or My.Computer.FileSystem.DirectoryExists(file_path) Then
            Process.Start(file_path)
        End If
    End Sub

End Module
