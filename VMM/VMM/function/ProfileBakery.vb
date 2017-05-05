Imports System.IO
Imports System.Xml.Serialization

Module ProfileBakery

    Public Function Create()
        If Not My.Computer.FileSystem.FileExists(PathHelper.Profiles) Then
            Dim profiles As New List(Of VermintideProfile)
            profiles.Add(New VermintideProfile("Default"))
            Save(profiles)
            Return True
        End If
        Return False
    End Function

    Public Function Load(Optional ByRef FirstStart As Boolean = False) As List(Of VermintideProfile)
        FirstStart = Create()
        If My.Computer.FileSystem.FileExists(PathHelper.Profiles) Then
            Dim serializer As XmlSerializer = New XmlSerializer(GetType(List(Of VermintideProfile)))
            Using tr As New StreamReader(PathHelper.Profiles)
                Dim profiles As List(Of VermintideProfile) = serializer.Deserialize(tr)
                Return profiles
            End Using
        End If
        Return Nothing
    End Function

    Public Function Save(Profiles As List(Of VermintideProfile))
        Dim serializer As XmlSerializer = New XmlSerializer(GetType(List(Of VermintideProfile)))
        Using tr As New StreamWriter(PathHelper.Profiles)
            serializer.Serialize(tr, Profiles)
        End Using
        Return True
    End Function

End Module
