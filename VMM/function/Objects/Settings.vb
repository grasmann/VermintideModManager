<Serializable()>
Public Class Settings

    Public Property SelectedProfile As String
    Public Property Patched As Boolean
    Public Property WindowSize As Size
    Public Property WindowPosition As Point
    Public Property Maximized As Boolean
    Public Property SourceOverwrite As String

    Public Sub New()
        SelectedProfile = "Default"
        Patched = False
        WindowSize = New Size(800, 600)
        WindowPosition = New Point(Screen.PrimaryScreen.WorkingArea.Width / 2 - WindowSize.Width / 2, Screen.PrimaryScreen.WorkingArea.Height / 2 - WindowSize.Height / 2)
        Maximized = False
        SourceOverwrite = String.Empty
    End Sub

End Class
