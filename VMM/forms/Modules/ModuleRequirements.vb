Public Class ModuleRequirements

    Private _core As New List(Of String)(New String() {"OptionsInjector"})

    Public Event ModChanged()
    Public Event Output(Text As String)
    Public Event SaveProfiles()
    Public Event RequestActivateRequirement()

    ' ##### Events ################################################################################

    Private Sub grd_requirements_CellMouseDown(sender As Object, e As DataGridViewCellMouseEventArgs) Handles grd_requirements.CellMouseDown
        If e.RowIndex >= 0 Then
            grd_requirements.ClearSelection()
            grd_requirements.Rows(e.RowIndex).Selected = True
        End If
    End Sub

    Private Sub ActivateToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ActivateToolStripMenuItem.Click
        RaiseEvent RequestActivateRequirement()
    End Sub

    Private Sub grd_requirements_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles grd_requirements.CellContentClick
        If e.RowIndex >= 0 And e.ColumnIndex = 2 Then
            If Not String.IsNullOrEmpty(grd_requirements.Rows(e.RowIndex).Cells(e.ColumnIndex).Value) Then
                RaiseEvent RequestActivateRequirement()
            End If
        End If
    End Sub

    ' ##### Public ################################################################################

    Public Sub ListRequirements(Args As main.ModuleArgs, VermintideMod As VermintideMod)
        list_requirements(Args, VermintideMod)
    End Sub

    Public Sub ActivateRequirement(Args As main.ModuleArgs, VermintideMod As VermintideMod)
        activate_requirement(Args, VermintideMod)
    End Sub

    ' ##### Functionality ################################################################################

    Private Sub list_requirements(Args As main.ModuleArgs, VermintideMod As VermintideMod)
        grd_requirements.Rows.Clear()
        If Not IsNothing(VermintideMod.requirement) Then
            For Each Requirement As String In VermintideMod.requirement
                Dim Active As Boolean = False
                Dim img As Image = Nothing
                Dim Modfile As VermintideMod = Nothing
                Dim Name As String = Requirement
                Dim Button As String = "Core"
                ' Core functions
                If _core.Contains(Requirement) Then
                    Active = True
                    img = My.Resources.core_24
                    Name = String.Format("{0}", Requirement)
                Else
                    ' Mod
                    For i As Integer = 0 To Args.Mods.Count - 1
                        If Args.Mods(i).mod_name = Requirement Then
                            Active = Args.Mods(i).active
                            Modfile = Args.Mods(i)
                            If Not Active Then
                                Button = "Activate"
                            Else
                                Button = "Active"
                            End If
                            Exit For
                        End If
                    Next
                    ' Img
                    If Active Then
                        img = My.Resources.install_16
                    Else
                        img = My.Resources.uninstall_16
                    End If
                End If
                ' Add
                grd_requirements.Rows.Add(img, Name, Button)
                Dim Row As DataGridViewRow = grd_requirements.Rows(grd_requirements.Rows.Count - 1)
                If Active Then
                    Row.DefaultCellStyle.BackColor = Color.LightGreen
                    Row.DefaultCellStyle.SelectionBackColor = Color.LightGreen
                    Row.Cells(2) = New DataGridViewTextBoxCell()
                    Row.Cells(2).Value = Button
                Else
                    Row.DefaultCellStyle.BackColor = Color.LightPink
                    Row.DefaultCellStyle.SelectionBackColor = Color.LightPink
                    Dim b As DataGridViewButtonCell = Row.Cells(2)
                    Row.ContextMenuStrip = ContextMenuStrip1
                End If
                Row.Tag = Modfile

            Next
        End If
        lbl_no_requirements.Visible = grd_requirements.Rows.Count = 0
    End Sub

    Private Sub activate_requirement(Args As main.ModuleArgs, VermintideMod As VermintideMod)
        If grd_requirements.SelectedRows.Count > 0 Then
            Dim Modfile As VermintideMod = grd_requirements.SelectedRows(0).Tag
            If Not IsNothing(Modfile) Then
                Modfile.active = True
                RaiseEvent Output(String.Format("'{0}' activated in '{1}'.", Modfile.displayname, Args.Settings.SelectedProfile))
                RaiseEvent ModChanged()
                RaiseEvent SaveProfiles()
            End If
            ListRequirements(Args, VermintideMod)
        End If
    End Sub

End Class