Public Class ModuleReadMe

    Public Sub SetText(Text As String)
        txt_readme.Text = Text
        If Not String.IsNullOrEmpty(txt_readme.Text) Then
            txt_readme.SelectionStart = 0
            txt_readme.SelectionLength = txt_readme.Lines(0).Length

            Dim font As Font = New Font(txt_readme.Font.FontFamily, 14, FontStyle.Bold)
            txt_readme.SelectionFont = font

            txt_readme.SelectionStart += txt_readme.SelectionLength
            txt_readme.SelectionLength = txt_readme.Text.Length - txt_readme.SelectionStart
            font = New Font(txt_readme.Font.FontFamily, 8, FontStyle.Regular)
            txt_readme.SelectionFont = font

            txt_readme.SelectionLength = 0
        End If
    End Sub

End Class