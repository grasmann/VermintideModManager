Public Class Options

    Public Event SaveSettings()
    Public Event RequestBrowseFolder()

    Public Sub New(Args As main.ModuleArgs)
        InitializeComponent()
        TextBox1.Text = Args.Settings.SourceOverwrite
    End Sub

    Public Sub BrowseFolder(Args As main.ModuleArgs)
        open_dialog(Args)
    End Sub

    Private Sub btn_browse_mod_repository_Click(sender As Object, e As EventArgs) Handles btn_browse_mod_repository.Click
        RaiseEvent RequestBrowseFolder()
    End Sub

    Private Sub open_dialog(Args As main.ModuleArgs)
        Dim dialog As New OpenFileDialog()
        dialog.InitialDirectory = Args.Settings.SourceOverwrite
        If String.IsNullOrEmpty(dialog.InitialDirectory) Then dialog.InitialDirectory = Application.StartupPath
        dialog.Filter = "vermintideconsole.dll (vermintideconsole.dll)|vermintideconsole.dll"
        If dialog.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            Dim Folder As String = PathHelper.ExtractFolder(dialog.FileName)
            If My.Computer.FileSystem.DirectoryExists(Folder) Then
                If PathHelper.HasFiles(Folder) Then
                    TextBox1.Text = Folder
                    Args.Settings.SourceOverwrite = Folder
                End If
            End If
        End If
    End Sub

    Private Sub Options_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        grd_modules.Rows.Add("Content", True)
        grd_modules.Rows.Add("Requirements", True)
        grd_modules.Rows.Add("ReadMe", True)
        grd_modules.Rows.Add("Output", True)
    End Sub

    Private Sub grd_modules_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles grd_modules.CellContentClick
        If e.RowIndex >= 0 Then
            If e.ColumnIndex = 1 Then
                grd_modules.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = Not grd_modules.Rows(e.RowIndex).Cells(e.ColumnIndex).Value
            End If
        End If
    End Sub

End Class