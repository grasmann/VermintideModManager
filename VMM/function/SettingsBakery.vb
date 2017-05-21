Imports System.IO
Imports System.Xml.Serialization

Module SettingsBakery

    Public Function Create()
        If Not My.Computer.FileSystem.FileExists(PathHelper.Settings) Then
            Dim settings As New Settings()
            Save(settings)
            Return True
        End If
        Return False
    End Function

    Public Function Load(Optional ByRef FirstStart As Boolean = False) As Settings
        FirstStart = Create()
        If My.Computer.FileSystem.FileExists(PathHelper.Settings) Then
            Dim serializer As XmlSerializer = New XmlSerializer(GetType(Settings))
            Using tr As New StreamReader(PathHelper.Settings)
                Dim settings As Settings = serializer.Deserialize(tr)
                Return settings
            End Using
        End If
        Return Nothing
    End Function

    Public Function Save(Settings As Settings)
        Dim serializer As XmlSerializer = New XmlSerializer(GetType(Settings))
        Using tr As New StreamWriter(PathHelper.Settings)
            serializer.Serialize(tr, Settings)
        End Using
        Return True
    End Function

End Module
