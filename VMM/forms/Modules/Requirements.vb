Public Class Requirements

    Private _settings As Settings
    Private _mod As VermintideMod
    Private _mods As List(Of VermintideMod)
    Private _core As New List(Of String)(New String() {"OptionsInjector"})

    Public Event ModChanged()
    Public Event Output(Text As String)
    Public Event SaveProfiles()

    Public Sub New(Mods As List(Of VermintideMod), Settings As Settings)
        InitializeComponent()
        _mods = Mods
        _settings = Settings
    End Sub

    Public Sub ListRequirements(VermintideMod As VermintideMod)
        _mod = VermintideMod
        grd_requirements.Rows.Clear()
        If Not IsNothing(_mod.requirement) Then
            For Each Requirement As String In _mod.requirement
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
                    For i As Integer = 0 To _mods.Count - 1
                        If _mods(i).mod_name = Requirement Then
                            Active = _mods(i).active
                            Modfile = _mods(i)
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

            'highlight_requirements(_mod)
        End If
    End Sub

    Private Sub highlight_requirements(VermintideMod As VermintideMod)
        For Each Row As DataGridViewRow In grd_requirements.Rows
            'Dim vm As VermintideMod = Row.Tag
            Row.DefaultCellStyle.BackColor = grd_requirements.DefaultCellStyle.BackColor
            'If Not IsNothing(VermintideMod.requirement) Then
            '    For Each Requirement In VermintideMod.requirement
            '        If vm.mod_name = Requirement Then
            '            If vm.active Then
            '                Row.DefaultCellStyle.BackColor = Color.LightGreen
            '            Else
            '                Row.DefaultCellStyle.BackColor = Color.LightPink
            '            End If
            '        End If
            '    Next
            'End If
        Next
    End Sub

    Private Sub grd_requirements_CellMouseDown(sender As Object, e As DataGridViewCellMouseEventArgs) Handles grd_requirements.CellMouseDown
        If e.RowIndex >= 0 Then
            grd_requirements.ClearSelection()
            grd_requirements.Rows(e.RowIndex).Selected = True
        End If
    End Sub

    Private Sub ActivateRequirement()
        Dim Row As DataGridViewRow = grd_requirements.SelectedRows(0)
        If Not IsNothing(Row) Then
            Dim Modfile As VermintideMod = Row.Tag
            If Not IsNothing(Modfile) Then
                Modfile.active = True
                RaiseEvent Output(String.Format("'{0}' activated in '{1}'.", Modfile.displayname, _settings.SelectedProfile))
                RaiseEvent ModChanged()
                RaiseEvent SaveProfiles()
            End If
        End If
        ListRequirements(_mod)
    End Sub

    Private Sub ActivateToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ActivateToolStripMenuItem.Click
        ActivateRequirement()
        'Dim Row As DataGridViewRow = grd_requirements.SelectedRows(0)
        'If Not IsNothing(Row) Then
        '    Dim Modfile As VermintideMod = Row.Tag
        '    If Not IsNothing(Modfile) Then
        '        Modfile.active = True
        '        RaiseEvent Output(String.Format("'{0}' activated in '{1}'.", Modfile.displayname, _settings.SelectedProfile))
        '        RaiseEvent ModChanged()
        '    End If
        'End If
        'ListRequirements(_mod)
    End Sub

    Private Sub grd_requirements_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles grd_requirements.CellContentClick
        If e.RowIndex >= 0 And e.ColumnIndex = 2 Then
            If Not String.IsNullOrEmpty(grd_requirements.Rows(e.RowIndex).Cells(e.ColumnIndex).Value) Then
                ActivateRequirement()
            End If
        End If
    End Sub

    'Private Sub grd_requirements_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles grd_requirements.CellContentClick
    '    'If e.RowIndex >= 0 Then
    '    '    grd_requirements.DefaultCellStyle.SelectionBackColor = grd_requirements.Rows(e.RowIndex).DefaultCellStyle.BackColor
    '    '    grd_requirements.DefaultCellStyle.SelectionForeColor = grd_requirements.Rows(e.RowIndex).DefaultCellStyle.ForeColor
    '    'End If
    'End Sub

End Class