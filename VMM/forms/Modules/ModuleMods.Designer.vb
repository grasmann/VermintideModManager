Imports WeifenLuo.WinFormsUI.Docking

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ModuleMods
    Inherits DockContent

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.DockPanel1 = New WeifenLuo.WinFormsUI.Docking.DockPanel()
        Me.VS2015LightTheme1 = New WeifenLuo.WinFormsUI.Docking.VS2015LightTheme()
        Me.SuspendLayout()
        '
        'DockPanel1
        '
        Me.DockPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DockPanel1.DockBackColor = System.Drawing.Color.FromArgb(CType(CType(238, Byte), Integer), CType(CType(238, Byte), Integer), CType(CType(242, Byte), Integer))
        Me.DockPanel1.DocumentStyle = WeifenLuo.WinFormsUI.Docking.DocumentStyle.DockingWindow
        Me.DockPanel1.DocumentTabStripLocation = WeifenLuo.WinFormsUI.Docking.DocumentTabStripLocation.Bottom
        Me.DockPanel1.Location = New System.Drawing.Point(0, 0)
        Me.DockPanel1.Name = "DockPanel1"
        Me.DockPanel1.Padding = New System.Windows.Forms.Padding(6)
        Me.DockPanel1.ShowAutoHideContentOnHover = False
        Me.DockPanel1.Size = New System.Drawing.Size(668, 453)
        Me.DockPanel1.TabIndex = 0
        Me.DockPanel1.Theme = Me.VS2015LightTheme1
        '
        'ModuleMods
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(668, 453)
        Me.Controls.Add(Me.DockPanel1)
        Me.Name = "ModuleMods"
        Me.Text = "Mod List"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents DockPanel1 As DockPanel
    Friend WithEvents VS2015LightTheme1 As VS2015LightTheme
End Class
