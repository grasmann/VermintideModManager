Imports WeifenLuo.WinFormsUI.Docking

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ModuleWarning
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ModuleWarning))
        Me.lbl_warning = New System.Windows.Forms.Label()
        Me.btn_solve = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'lbl_warning
        '
        Me.lbl_warning.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbl_warning.BackColor = System.Drawing.Color.Yellow
        Me.lbl_warning.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_warning.Location = New System.Drawing.Point(2, 2)
        Me.lbl_warning.Name = "lbl_warning"
        Me.lbl_warning.Size = New System.Drawing.Size(288, 231)
        Me.lbl_warning.TabIndex = 2
        Me.lbl_warning.Text = "Label1"
        Me.lbl_warning.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btn_solve
        '
        Me.btn_solve.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.btn_solve.Image = Global.VMM.My.Resources.Resources.install_16
        Me.btn_solve.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_solve.Location = New System.Drawing.Point(0, 234)
        Me.btn_solve.Name = "btn_solve"
        Me.btn_solve.Size = New System.Drawing.Size(292, 32)
        Me.btn_solve.TabIndex = 3
        Me.btn_solve.Text = "Solve"
        Me.btn_solve.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_solve.UseVisualStyleBackColor = True
        '
        'ModuleWarning
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(292, 266)
        Me.Controls.Add(Me.btn_solve)
        Me.Controls.Add(Me.lbl_warning)
        Me.DockAreas = CType((WeifenLuo.WinFormsUI.Docking.DockAreas.DockTop Or WeifenLuo.WinFormsUI.Docking.DockAreas.DockBottom), WeifenLuo.WinFormsUI.Docking.DockAreas)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "ModuleWarning"
        Me.Text = "Warning"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lbl_warning As Label
    Friend WithEvents btn_solve As Button
End Class
