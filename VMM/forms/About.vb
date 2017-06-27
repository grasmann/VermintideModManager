Imports VMM
Imports Ionic.Zip
Imports System.ComponentModel

Public Class About

    ' ##### Events ################################################################################

    Private Sub About_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lbl_version.Text = Version.Current
        lbl_framework_checking.Text = "Framework version: " + ModHelper.FrameworkVersion.ToString
    End Sub

End Class