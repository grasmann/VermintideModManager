Public Class ModuleProfileManager

    'Private _profiles As List(Of VermintideProfile)

    Public Event RequestListProfiles()
    Public Event RequestCreateProfile()
    Public Event RequestDeleteProfile()
    Public Event RequestCopyProfile()
    Public Event UpdateProfiles()

    ' ##### Events ################################################################################

    Public Sub New() 'Profiles As List(Of VermintideProfile))
        InitializeComponent()
        '_profiles = Profiles
    End Sub

    Private Sub ProfileManager_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'list_profiles()
        RaiseEvent RequestListProfiles()
    End Sub

    Public Sub ListProfiles(Args As main.ModuleArgs)
        list_profiles(Args)
    End Sub

    Private Sub NewProfileToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NewProfileToolStripMenuItem.Click
        'create_profile()
        RaiseEvent RequestCreateProfile()
    End Sub

    Public Sub CreateProfile(Args As main.ModuleArgs)
        create_profile(Args)
    End Sub

    Private Sub cnt_delete_Click(sender As Object, e As EventArgs) Handles DeleteToolStripMenuItem.Click
        'delete_profile()
        RaiseEvent RequestDeleteProfile()
    End Sub

    Public Sub DeleteProfile(Args As main.ModuleArgs)
        delete_profile(Args)
    End Sub

    Private Sub CopyToToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CopyToToolStripMenuItem.Click
        'copy_profile()
        RaiseEvent RequestCopyProfile()
    End Sub

    Public Sub CopyProfile(Args As main.ModuleArgs)
        copy_profile(Args)
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

    Private Sub list_profiles(Args As main.ModuleArgs)
        grd_profiles.Rows.Clear()
        For Each vp As VermintideProfile In Args.Profiles
            grd_profiles.Rows.Add(vp.Name)
            Dim index As Integer = grd_profiles.Rows.Count - 1
            grd_profiles.Rows.Item(index).ContextMenuStrip = ContextMenuStrip2
            grd_profiles.Rows.Item(index).Tag = vp
        Next
    End Sub

    Private Sub create_profile(Args As main.ModuleArgs)
        Dim new_profile As New CreateProfile(Args.Profiles)
        new_profile.ShowDialog()
        list_profiles(Args)
        ProfileBakery.Save(Args.Profiles)
        RaiseEvent UpdateProfiles()
    End Sub

    Private Sub delete_profile(Args As main.ModuleArgs)
        If grd_profiles.SelectedRows.Count > 0 Then
            Dim profile As VermintideProfile = grd_profiles.SelectedRows(0).Tag
            If Args.Profiles.Count > 1 Then
                Dim msg As String = String.Format("Delete profile '{0}'?{1}Are you sure?", profile.Name, vbCrLf)
                If MsgBox(msg, MsgBoxStyle.Question + MsgBoxStyle.OkCancel, "Confirm") = MsgBoxResult.Ok Then
                    Args.Profiles.Remove(profile)
                    list_profiles(Args)
                    ProfileBakery.Save(Args.Profiles)
                    RaiseEvent UpdateProfiles()
                End If
            Else
                Dim msg As String = String.Format("You can't delete the profile '{0}'.{1}You need at least one profile.", profile.Name, vbCrLf)
                MsgBox(msg, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Error")
            End If
        End If
    End Sub

    Private Sub copy_profile(Args As main.ModuleArgs)
        If grd_profiles.SelectedRows.Count > 0 Then
            Dim profile As VermintideProfile = grd_profiles.SelectedRows(0).Tag
            Dim create_profile_diag As New CreateProfile(Args.Profiles, profile.Name)
            If create_profile_diag.ShowDialog() = DialogResult.OK Then
                Dim new_profile = Args.Profiles(Args.Profiles.Count - 1)
                new_profile.Mods = New List(Of String)(profile.Mods)
                list_profiles(Args)
                ProfileBakery.Save(Args.Profiles)
                RaiseEvent UpdateProfiles()
            End If
        End If
    End Sub

End Class