﻿Public Module Version

    Public Const major As Integer = 0
    Public Const minor As Integer = 6
    Public Const patch As Integer = 27

    Public ReadOnly Property Current() As String
        Get
            Return major.ToString + "." + minor.ToString + "." + patch.ToString
        End Get
    End Property

    Public Function Compare(V1 As String, V2 As String) As Boolean
        Dim n1s As List(Of String) = V1.Split(".").ToList
        Dim n2s As List(Of String) = V2.Split(".").ToList
        If String.IsNullOrEmpty(V1) Or String.IsNullOrEmpty(V2) Then Return False
        For i As Integer = 0 To 2
            If n1s.Count >= i And n2s.Count >= i Then
                If IsNumeric(n1s(i)) And IsNumeric(n2s(i)) Then
                    If Val(n1s(i)) > Val(n2s(i)) Then
                        Return True
                    End If
                End If
            End If
        Next
        Return False
    End Function

End Module
