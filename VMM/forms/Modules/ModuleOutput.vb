Public Class ModuleOutput

    Public Sub Print(Text As String)
        If Not String.IsNullOrEmpty(RichTextBox1.Text) Then
            RichTextBox1.Text += vbCrLf
        End If
        RichTextBox1.Text += Text
        RichTextBox1.SelectionStart = RichTextBox1.TextLength
        RichTextBox1.ScrollToCaret()
    End Sub

    Private Sub ClearToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ClearToolStripMenuItem.Click
        RichTextBox1.Clear()
    End Sub

End Class