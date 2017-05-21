Public Class About

    Private Sub About_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lbl_version.Text = Version.Current
    End Sub

End Class