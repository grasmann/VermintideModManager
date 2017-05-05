Public Class ModuleWarning

    Private _warning_type As WarningType
    Private _mod As VermintideMod

    Public Event Solve()

    Public Enum WarningType
        ModFilesMissing
        RequirementMissing
    End Enum

    ' ##### Events ########################################################################################################################

    Public Sub New(WarningType As WarningType, Text As String, Optional VM As VermintideMod = Nothing)
        InitializeComponent()
        _warning_type = WarningType
        _mod = VM
        btn_solve.Text = Text
    End Sub

    Private Sub btn_solve_Click(sender As Object, e As EventArgs) Handles btn_solve.Click
        RaiseEvent Solve()
        Me.Close()
    End Sub

    Private Sub ModuleWarning_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Select Case _warning_type
            Case WarningType.ModFilesMissing
                lbl_warning.Text = "The mod files are missing."
            Case WarningType.RequirementMissing
                lbl_warning.Text = String.Format("The mod '{0}' is missing one or more of it's requirements.", _mod.mod_name)
        End Select
    End Sub

End Class