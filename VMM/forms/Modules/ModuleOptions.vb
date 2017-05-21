Public Class ModuleOptions

    Public Event SaveSettings()
    Public Event RequestBrowseFolder()
    Public Event RequestModuleChange()
    Public Event RequestModuleValues()

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
        RaiseEvent RequestModuleValues()
    End Sub

    Public Sub SetValues(Args As main.ModuleArgs)
        set_values(Args)
    End Sub

    Private Sub set_values(Args As main.ModuleArgs)
        grd_modules.Rows.Add("Content", Args.Settings.HideModule.Contains("Content"))
        grd_modules.Rows.Add("Requirements", Args.Settings.HideModule.Contains("Requirements"))
        grd_modules.Rows.Add("ReadMe", Args.Settings.HideModule.Contains("ReadMe"))
        grd_modules.Rows.Add("Output", Args.Settings.HideModule.Contains("Output"))
    End Sub

    Private Sub grd_modules_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles grd_modules.CellContentClick
        If e.RowIndex >= 0 Then
            If e.ColumnIndex = 1 Then
                grd_modules.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = Not grd_modules.Rows(e.RowIndex).Cells(e.ColumnIndex).Value
                RaiseEvent RequestModuleChange()
            End If
        End If
    End Sub

    Public Sub ModuleChange(Args As main.ModuleArgs)
        module_change(Args)
    End Sub

    Private Sub module_change(Args As main.ModuleArgs)
        Args.Settings.HideModule.Clear()
        If grd_modules.Rows(0).Cells(1).Value Then
            Args.Settings.HideModule.Add("Content")
        End If
        If grd_modules.Rows(1).Cells(1).Value Then
            Args.Settings.HideModule.Add("Requirements")
        End If
        If grd_modules.Rows(2).Cells(1).Value Then
            Args.Settings.HideModule.Add("ReadMe")
        End If
        If grd_modules.Rows(3).Cells(1).Value Then
            Args.Settings.HideModule.Add("Output")
        End If
        SettingsBakery.Save(Args.Settings)
    End Sub

End Class