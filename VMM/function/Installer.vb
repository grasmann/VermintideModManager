Imports System
Imports System.IO
Imports System.Runtime.InteropServices

Module Installer

    Private _file_cache As List(Of File)
    Private _copy_files As New List(Of String)({"\doc\"})

    Private Enum SYMBOLIC_LINK_FLAG As Integer
        File = 0
        Directory = 1
    End Enum

    Private Structure File
        Public Path As String
        Public Target As String
        Public Folder As String
        Public Modfile As Boolean
    End Structure

    <DllImport("kernel32.dll")>
    Private Function CreateSymbolicLink(ByVal lpSymlinkFileName As String, ByVal lpTargetFileName As String, ByVal dwFlags As SYMBOLIC_LINK_FLAG) As Boolean
    End Function
    <DllImport("kernel32.dll")>
    Private Function GetLastError() As Long
    End Function
    <DllImport("kernel32.dll")>
<<<<<<< HEAD
    Private Function FormatMessage(ByVal dwFlags As Long, lpSource As IntPtr, ByVal dwMessageId As Long,
                                   ByVal dwLanguageId As Long, ByVal lpBuffer As String, ByVal nSize As Long, Arguments As IntPtr) As Long
=======
    Private Function FormatMessage(ByVal dwFlags As Long, lpSource As Object, ByVal dwMessageId As Long,
                                   ByVal dwLanguageId As Long, ByVal lpBuffer As String, ByVal nSize As Long, Arguments As Long) As Long
>>>>>>> 198fad8cddbe9ca46532b79357e1bea7de2176f4
    End Function

    Private Const FORMAT_MESSAGE_IGNORE_INSERTS = &H200
    Private Const FORMAT_MESSAGE_FROM_SYSTEM = &H1000

    Private Const LANG_NEUTRAL = &H0
    Private Const SUBLANG_DEFAULT = &H1

    Private Function IsSymbolicLink(ByVal Path As String) As Boolean
        Dim pathInfo As New System.IO.FileInfo(Path)
        Return pathInfo.Attributes.HasFlag(FileAttributes.ReparsePoint)
    End Function

    Public Function Framework() As Boolean
        ' Check if repository exists
        If My.Computer.FileSystem.DirectoryExists(PathHelper.Repository) Then
            BuildFileCache()
            ' Build file cache
            Dim files As New List(Of File)
            RecursiveFindFiles(PathHelper.Repository, files)
            ' Dialog
            For Each file As File In files
                If Not file.Modfile Then
                    If Not My.Computer.FileSystem.DirectoryExists(file.Folder) Then
                        My.Computer.FileSystem.CreateDirectory(file.Folder)
                    End If
                    Dim local_path As String = Right(file.Folder, file.Folder.Length - VermintideHelper.Binaries.Length).ToLower
                    If _copy_files.Contains(local_path) Then
                        My.Computer.FileSystem.CopyFile(file.Path, file.Target)
                    Else
                        If Not CreateSymbolicLink(file.Target, file.Path, 0) Then
                            Dim Flags As Long = FORMAT_MESSAGE_FROM_SYSTEM Or FORMAT_MESSAGE_IGNORE_INSERTS
                            Dim Lang As Long = LANG_NEUTRAL Or (SUBLANG_DEFAULT * 1024)
                            Dim Buffer As String = Space(256)
                            Dim Err As Long = GetLastError()
<<<<<<< HEAD
                            Dim Retval As Long = FormatMessage(Flags, IntPtr.Zero, Err, Lang, Buffer, Len(Buffer), IntPtr.Zero)
=======
                            Dim Retval As Long = FormatMessage(Flags, 0&, Err, Lang, Buffer, Len(Buffer), 0&)
>>>>>>> 198fad8cddbe9ca46532b79357e1bea7de2176f4
                            If Retval > 0 Then
                                MsgBox(Left(Buffer, Retval), MsgBoxStyle.OkOnly, "An error occured")
                            Else
                                Try
                                    My.Computer.FileSystem.DeleteFile(file.Target)
                                    CreateSymbolicLink(file.Target, file.Path, 0)
                                Catch ex As Exception
                                    MsgBox(ex.Message)
                                End Try
                            End If
                            'Return False
                        End If
                        'If Not CreateSymbolicLink(file.Target, file.Path, 0) Then


                        '    My.Computer.FileSystem.DeleteFile(file.Target)
                        '    CreateSymbolicLink(file.Target, file.Path, 0)
                        '    'Return False
                        'End If
                    End If
                End If
            Next
            ' Check for 'mods'
            check_mods_folder()
            Return True
        End If
        Return False
    End Function

    Private Sub check_mods_folder()
        'Debug.Print(VermintideHelper.Binaries + "\mods")
        If Not My.Computer.FileSystem.DirectoryExists(VermintideHelper.Binaries + "\mods") Then
            My.Computer.FileSystem.CreateDirectory(VermintideHelper.Binaries + "\mods")
        End If
    End Sub

    Public Function SingleMod(Modfile As VermintideMod, Active As Boolean) As Boolean
        If Modfile.active And Active Then
            Try
                check_mods_folder()
                If Not My.Computer.FileSystem.FileExists(Modfile.target) Then
                    CreateSymbolicLink(Modfile.target, Modfile.path, 0)
                End If
                Return True
            Catch ex As Exception
                Debug.Print(ex.Message)
            End Try
        Else
            Try
                If My.Computer.FileSystem.FileExists(Modfile.target) Then
                    My.Computer.FileSystem.DeleteFile(Modfile.target, FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.DeletePermanently)
                End If
                Return True
            Catch ex As Exception
                Debug.Print(ex.Message)
            End Try
        End If
        Return False
    End Function

    'Public Function Mods(Modfiles As List(Of VermintideMod)) As Boolean
    '    For Each Modfile As VermintideMod In Modfiles
    '        'Dim File As File = Nothing
    '        'For Each f As File In _file_cache
    '        '    If f.Path = Modfile.path Then
    '        If Modfile.active Then
    '            Try
    '                CreateSymbolicLink(Modfile.target, Modfile.path, 0)
    '            Catch ex As Exception
    '                Debug.Print(ex.Message)
    '            End Try
    '        Else
    '            Try
    '                My.Computer.FileSystem.DeleteFile(Modfile.target, FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.DeletePermanently)
    '            Catch ex As Exception
    '                Debug.Print(ex.Message)
    '            End Try
    '        End If
    '        '    End If
    '        'Next
    '    Next
    '    Return False
    'End Function

    Public Sub Purge()
        BuildFileCache()
        Dim _not_empty As New List(Of String)
        ' Delete files
        For Each File In _file_cache
            Try
                My.Computer.FileSystem.DeleteFile(File.Target)
                My.Computer.FileSystem.DeleteDirectory(File.Folder, FileIO.DeleteDirectoryOption.ThrowIfDirectoryNonEmpty)
            Catch ex As Exception
                _not_empty.Add(File.Folder)
            End Try
        Next
        ' Retry folders
        For Each Folder In _not_empty
            If My.Computer.FileSystem.DirectoryExists(Folder) Then
                Try
                    My.Computer.FileSystem.DeleteDirectory(Folder, FileIO.DeleteDirectoryOption.ThrowIfDirectoryNonEmpty)
                Catch ex As Exception
                End Try
            End If
        Next
        ' Fix
        Try
            My.Computer.FileSystem.DeleteDirectory(VermintideHelper.Binaries + "\mod_loader", FileIO.DeleteDirectoryOption.DeleteAllContents)
        Catch ex As Exception
        End Try
        Try
            My.Computer.FileSystem.DeleteDirectory(VermintideHelper.Binaries + "\mods", FileIO.DeleteDirectoryOption.DeleteAllContents)
        Catch ex As Exception
        End Try
    End Sub

    Public Sub BuildFileCache()
        _file_cache = New List(Of File)
        RecursiveFindFiles(PathHelper.Repository, _file_cache)
    End Sub

    Private Sub RecursiveFindFiles(Path As String, Files As List(Of File))
        Dim di As New DirectoryInfo(Path)

        Dim diArr As DirectoryInfo() = di.GetDirectories()
        For Each dri As DirectoryInfo In diArr
            RecursiveFindFiles(dri.FullName, Files)
        Next

        Dim fiArr As System.IO.FileInfo() = di.GetFiles()
        For Each fri As System.IO.FileInfo In fiArr
            'If Not fri.Extension = ".mod" Then
            Dim File As New File
            File.Path = fri.FullName
            File.Target = VermintideHelper.Binaries + "\" + Mid(File.Path, PathHelper.Repository.Length + 2)
            File.Folder = Mid(File.Target, 1, InStrRev(File.Target, "\"))
            If fri.Extension = ".mod" Then File.Modfile = True
            Files.Add(File)
        Next fri
    End Sub

    'Private Function RepositoryIsEmpty() As Boolean

    'End Function

End Module
