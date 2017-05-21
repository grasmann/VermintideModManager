Imports WeifenLuo.WinFormsUI.Docking

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ModuleReadMe
    Inherits DockContent

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ModuleReadMe))
        Me.txt_readme = New System.Windows.Forms.RichTextBox()
        Me.SuspendLayout()
        '
        'txt_readme
        '
        Me.txt_readme.BackColor = System.Drawing.SystemColors.Window
        Me.txt_readme.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_readme.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txt_readme.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txt_readme.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txt_readme.Location = New System.Drawing.Point(0, 0)
        Me.txt_readme.Name = "txt_readme"
        Me.txt_readme.ReadOnly = True
        Me.txt_readme.Size = New System.Drawing.Size(683, 440)
        Me.txt_readme.TabIndex = 1
        Me.txt_readme.Text = ""
        '
        'ModuleReadMe
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.ClientSize = New System.Drawing.Size(683, 440)
        Me.CloseButtonVisible = False
        Me.Controls.Add(Me.txt_readme)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "ModuleReadMe"
        Me.Text = "ReadMe"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents txt_readme As RichTextBox
End Class
