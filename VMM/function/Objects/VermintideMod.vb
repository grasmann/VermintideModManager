Public Class VermintideModChatEntry
    Public Property command As String
    Public Property execute As String
    Public Property description As String
End Class

Public Class VermintideMod
    Public Property mod_name As String
    Public Property version As String
    Public Property chat As VermintideModChatEntry()
    Public Property requirement As String()
    Public Property patch As String()
    Public ReadOnly Property displayname As String
        Get
            Dim name As String = String.Empty
            For Each c As Char In mod_name
                If c.ToString = Char.ToUpper(c).ToString Then
                    name += " " + c.ToString
                Else
                    name += c.ToString
                End If
            Next
            Return Trim(name)
        End Get
    End Property
    Public Property readme As String
    Public Property active As Boolean
    Public Property path As String
    Public Property target As String
    Public Property folder As String
    Public Property content As New List(Of String)
    Public ReadOnly Property identifier As String
        Get
            Return mod_name + version
        End Get
    End Property
    Public Property outdated As Boolean
End Class