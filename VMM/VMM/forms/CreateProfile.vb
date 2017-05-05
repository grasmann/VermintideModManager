Public Class CreateProfile

    Private _profiles As List(Of VermintideProfile)

    ' ##### Events ################################################################################

    Public Sub New(Profiles As List(Of VermintideProfile), Optional Text As String = "")
        InitializeComponent()
        _profiles = Profiles
        txt_name.Text = Text
    End Sub

    Private Sub CreateProfile_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If String.IsNullOrEmpty(txt_name.Text) And Me.DialogResult = DialogResult.OK Then
            e.Cancel = True
        End If
    End Sub

    Private Sub btn_ok_Click(sender As Object, e As EventArgs) Handles btn_ok.Click
        create_profile()
    End Sub

    ' ##### Functionality ################################################################################

    Private Sub create_profile()
        If Not String.IsNullOrEmpty(txt_name.Text) Then
            If Not profile_exists(txt_name.Text) Then
                _profiles.Add(New VermintideProfile(txt_name.Text))
                ProfileBakery.Save(_profiles)
            End If
        End If
    End Sub

    Private Function profile_exists(Name As String) As Boolean
        For Each p As VermintideProfile In _profiles
            If p.Name = Name Then
                Return True
            End If
        Next
        Return False
    End Function

End Class