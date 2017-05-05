<Serializable()>
Public Class VermintideProfile

    Private _name As String
    Private _mods As New List(Of String)

    Public Sub New()
    End Sub
    Public Sub New(Name As String)
        _name = Name
    End Sub

    Public Property Name As String
        Get
            Return _name
        End Get
        Set(value As String)
            _name = value
        End Set
    End Property

    Public Property Mods As List(Of String)
        Get
            Return _mods
        End Get
        Set(value As List(Of String))
            _mods = value
        End Set
    End Property

End Class
