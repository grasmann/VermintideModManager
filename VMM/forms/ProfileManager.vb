Public Class ProfileManager

    Private _profiles As List(Of VermintideProfile)

    ' ##### Events ################################################################################

    Public Sub New(Profiles As List(Of VermintideProfile))
        InitializeComponent()
        _profiles = Profiles
    End Sub

    Private Sub ProfileManager_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        list_profiles()
    End Sub

    Private Sub NewProfileToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NewProfileToolStripMenuItem.Click
        create_profile()
    End Sub

    Private Sub cnt_delete_Click(sender As Object, e As EventArgs) Handles DeleteToolStripMenuItem.Click
        delete_profile()
    End Sub

    Private Sub CopyToToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CopyToToolStripMenuItem.Click
        copy_profile()
    End Sub

    Private Sub grd_profiles_CellMouseDown(sender As Object, e As DataGridViewCellMouseEventArgs) Handles grd_profiles.CellMouseDown
        If e.RowIndex > -1 Then
            If e.Button = MouseButtons.Right Then
                If grd_profiles.Rows(e.RowIndex).Selected Then
                Else
                    grd_profiles.ClearSelection()
                    grd_profiles.Rows(e.RowIndex).Selected = True
                End If
            End If
        End If
    End Sub

    ' ##### Functionality ################################################################################

    Private Sub list_profiles()
        grd_profiles.Rows.Clear()
        For Each vp As VermintideProfile In _profiles
            grd_profiles.Rows.Add(vp.Name)
            Dim index As Integer = grd_profiles.Rows.Count - 1
            grd_profiles.Rows.Item(index).ContextMenuStrip = ContextMenuStrip2
            grd_profiles.Rows.Item(index).Tag = vp
        Next
    End Sub

    Private Sub create_profile()
        Dim new_profile As New CreateProfile(_profiles)
        new_profile.ShowDialog()
        list_profiles()
        ProfileBakery.Save(_profiles)
    End Sub

    Private Sub delete_profile()
        If grd_profiles.SelectedRows.Count > 0 Then
            Dim profile As VermintideProfile = grd_profiles.SelectedRows(0).Tag
            If _profiles.Count > 1 Then
                Dim msg As String = String.Format("Delete profile '{0}'?{1}Are you sure?", profile.Name, vbCrLf)
                If MsgBox(msg, MsgBoxStyle.Question + MsgBoxStyle.OkCancel, "Confirm") = MsgBoxResult.Ok Then
                    _profiles.Remove(profile)
                    list_profiles()
                    ProfileBakery.Save(_profiles)
                End If
            Else
                Dim msg As String = String.Format("You can't delete the profile '{0}'.{1}You need at least one profile.", profile.Name, vbCrLf)
                MsgBox(msg, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Error")
            End If
        End If
    End Sub

    Private Sub copy_profile()
        If grd_profiles.SelectedRows.Count > 0 Then
            Dim profile As VermintideProfile = grd_profiles.SelectedRows(0).Tag
            Dim create_profile_diag As New CreateProfile(_profiles, profile.Name)
            If create_profile_diag.ShowDialog() = DialogResult.OK Then
                Dim new_profile = _profiles(_profiles.Count - 1)
                new_profile.Mods = New List(Of String)(profile.Mods)
                list_profiles()
                ProfileBakery.Save(_profiles)
            End If
        End If
    End Sub

End Class