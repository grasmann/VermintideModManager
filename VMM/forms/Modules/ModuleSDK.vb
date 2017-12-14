Public Class ModuleSDK

    Private _file_endings As New Dictionary(Of String, SDKFile.SDKFileType)

    Private Sub ModuleSDK_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        fill_file_endings()

        ListBox1.Items.Add("Test")

        Utilities.ElevatedDragDropManager.Instance.EnableDragDrop(TreeView1.Handle)
        AddHandler Utilities.ElevatedDragDropManager.Instance.ElevatedDragDrop, AddressOf Elevated_DragDrop

    End Sub

    Private Sub fill_file_endings()
        _file_endings.Add("lua", SDKFile.SDKFileType.Script)

    End Sub

    Private Sub ignored_files()

    End Sub

    Private Sub get_current_mod_data()

    End Sub

    Private Sub create_new_mod(Name As String)

    End Sub

    Private Sub create_mod(Name As String)

    End Sub

    Private Sub create_settings_ini(Name As String)

    End Sub

    Private Sub create_packages(Name As String)

    End Sub

    Private Sub Elevated_DragDrop(sender As Object, e As Utilities.ElevatedDragDropArgs)
        For Each File As String In e.Files
            If My.Computer.FileSystem.FileExists(File) Then
                Try
                    Dim group As TreeNode = Nothing
                    Dim type As SDKFile.SDKFileType = _file_endings(PathHelper.ExtractEnding(File))
                    Select Case type
                        Case SDKFile.SDKFileType.Script
                            group = TreeView1.Nodes.Add("n_scripts", "Scripts")
                    End Select
                    If Not IsNothing(group) Then
                        Dim Name As String = PathHelper.ExtractFileName(File)
                        group.Nodes.Add(Name)
                    End If
                Catch ex As Exception

                End Try
            End If
        Next
    End Sub

    Private Sub ListBox1_MouseDown(sender As Object, e As MouseEventArgs) Handles ListBox1.MouseDown
        Dim aPoint As New Point(e.X, e.Y)
        Dim aIndex As Integer = ListBox1.IndexFromPoint(aPoint)
        If aIndex >= 0 Then
            ListBox1.DoDragDrop(ListBox1.Items(aIndex), DragDropEffects.All)
        End If
    End Sub

    Private Sub TreeView1_DragDrop(sender As Object, e As DragEventArgs) Handles TreeView1.DragDrop

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

    End Sub

End Class