Imports WeifenLuo.WinFormsUI.Docking

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ModuleWarning
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ModuleWarning))
        Me.lbl_warning = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'lbl_warning
        '
        Me.lbl_warning.BackColor = System.Drawing.Color.Yellow
        Me.lbl_warning.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbl_warning.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_warning.Location = New System.Drawing.Point(0, 0)
        Me.lbl_warning.Name = "lbl_warning"
        Me.lbl_warning.Size = New System.Drawing.Size(292, 266)
        Me.lbl_warning.TabIndex = 2
        Me.lbl_warning.Text = "Label1"
        Me.lbl_warning.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ModuleWarning
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(292, 266)
        Me.Controls.Add(Me.lbl_warning)
        Me.DockAreas = CType((WeifenLuo.WinFormsUI.Docking.DockAreas.DockTop Or WeifenLuo.WinFormsUI.Docking.DockAreas.DockBottom), WeifenLuo.WinFormsUI.Docking.DockAreas)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "ModuleWarning"
        Me.Text = "Warning"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lbl_warning As Label
End Class
