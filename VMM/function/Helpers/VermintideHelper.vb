Imports System
Imports System.IO

Module VermintideHelper

    Private _appid As Integer = 235540

    ' ##### Functionality ################################################################################

    Public Sub Launch()

        'Dim path As String = String.Format("{0}\vermintide.exe", VermintideHelper.Binaries)
        'If My.Computer.FileSystem.FileExists(path) Then
        '    Dim p As New Process
        '    p.StartInfo.FileName = path
        '    p.StartInfo.WorkingDirectory = VermintideHelper.Binaries
        '    'p.StartInfo.WorkingDirectory = SteamHelper.InstallPath
        '    p.StartInfo.Arguments = "-bundle-dir ..\bundle -ini settings -silent-mode"
        '    p.Start()
        'Else
        '    MsgBox("Vermintide doesn't seem to be installed.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Launch Error")
        'End If

        SteamHelper.LaunchGame(_appid)
    End Sub

    ' ##### Properties ################################################################################

    Public ReadOnly Property Binaries As String
        Get
            Return Path + "\binaries"
        End Get
    End Property

    Public ReadOnly Property Launcher As String
        Get
            Return Path + "\launcher"
        End Get
    End Property

    Public ReadOnly Property Path As String
        Get
            Return SteamHelper.GameFolder(_appid)
        End Get
    End Property

End Module
