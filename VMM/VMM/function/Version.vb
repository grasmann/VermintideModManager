Public Module Version

    Public Const major As Integer = 0
    Public Const minor As Integer = 3
    Public Const patch As Integer = 4

    Public ReadOnly Property Current() As String
        Get
            Return major.ToString + "." + minor.ToString + "." + patch.ToString
        End Get
    End Property

End Module
