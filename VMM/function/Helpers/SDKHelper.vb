Module SDKHelper

    Private _appid As Integer = 718610

    Public ReadOnly Property Path As String
        Get
            Return SteamHelper.GameFolder(_appid)
        End Get
    End Property

    Public ReadOnly Property Compiler As String
        Get
            Return Path + "\bin\stingray_win64_dev_x64.exe"
        End Get
    End Property

End Module
