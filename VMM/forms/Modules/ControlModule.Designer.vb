Imports WeifenLuo.WinFormsUI.Docking

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ControlModule
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ControlModule))
        Me.btn_install = New System.Windows.Forms.Button()
        Me.cmb_profiles = New System.Windows.Forms.ComboBox()
        Me.btn_launch = New System.Windows.Forms.Button()
        Me.btn_about = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btn_install
        '
        Me.btn_install.Location = New System.Drawing.Point(0, 0)
        Me.btn_install.Name = "btn_install"
        Me.btn_install.Size = New System.Drawing.Size(101, 30)
        Me.btn_install.TabIndex = 8
        Me.btn_install.Text = "Button1"
        Me.btn_install.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_install.UseVisualStyleBackColor = True
        '
        'cmb_profiles
        '
        Me.cmb_profiles.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmb_profiles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_profiles.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmb_profiles.FormattingEnabled = True
        Me.cmb_profiles.Location = New System.Drawing.Point(178, 1)
        Me.cmb_profiles.Name = "cmb_profiles"
        Me.cmb_profiles.Size = New System.Drawing.Size(393, 28)
        Me.cmb_profiles.TabIndex = 10
        '
        'btn_launch
        '
        Me.btn_launch.Image = Global.VMM.My.Resources.Resources.launch_24
        Me.btn_launch.Location = New System.Drawing.Point(101, 0)
        Me.btn_launch.Name = "btn_launch"
        Me.btn_launch.Size = New System.Drawing.Size(76, 30)
        Me.btn_launch.TabIndex = 9
        Me.btn_launch.Text = "Lanuch"
        Me.btn_launch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_launch.UseVisualStyleBackColor = True
        '
        'btn_about
        '
        Me.btn_about.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_about.Image = Global.VMM.My.Resources.Resources.info_16
        Me.btn_about.Location = New System.Drawing.Point(572, 0)
        Me.btn_about.Name = "btn_about"
        Me.btn_about.Size = New System.Drawing.Size(77, 30)
        Me.btn_about.TabIndex = 11
        Me.btn_about.Text = "About"
        Me.btn_about.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_about.UseVisualStyleBackColor = True
        '
        'Controls
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(649, 140)
        Me.CloseButtonVisible = False
        Me.Controls.Add(Me.cmb_profiles)
        Me.Controls.Add(Me.btn_install)
        Me.Controls.Add(Me.btn_launch)
        Me.Controls.Add(Me.btn_about)
        Me.DockAreas = CType(((((WeifenLuo.WinFormsUI.Docking.DockAreas.Float Or WeifenLuo.WinFormsUI.Docking.DockAreas.DockLeft) _
            Or WeifenLuo.WinFormsUI.Docking.DockAreas.DockRight) _
            Or WeifenLuo.WinFormsUI.Docking.DockAreas.DockTop) _
            Or WeifenLuo.WinFormsUI.Docking.DockAreas.DockBottom), WeifenLuo.WinFormsUI.Docking.DockAreas)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Controls"
        Me.Text = "Controls"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btn_install As Button
    Friend WithEvents btn_launch As Button
    Friend WithEvents cmb_profiles As ComboBox
    Friend WithEvents btn_about As Button
End Class
