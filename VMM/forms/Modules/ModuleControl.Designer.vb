Imports WeifenLuo.WinFormsUI.Docking

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ModuleControl
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ModuleControl))
        Me.btn_install = New System.Windows.Forms.Button()
        Me.btn_options = New System.Windows.Forms.Button()
        Me.btn_launch = New System.Windows.Forms.Button()
        Me.btn_about = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btn_install
        '
        Me.btn_install.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn_install.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_install.Location = New System.Drawing.Point(0, 0)
        Me.btn_install.Name = "btn_install"
        Me.btn_install.Size = New System.Drawing.Size(101, 140)
        Me.btn_install.TabIndex = 8
        Me.btn_install.Text = "Button1"
        Me.btn_install.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_install.UseVisualStyleBackColor = True
        '
        'btn_options
        '
        Me.btn_options.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_options.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_options.Image = Global.VMM.My.Resources.Resources.options_16
        Me.btn_options.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_options.Location = New System.Drawing.Point(497, 0)
        Me.btn_options.Name = "btn_options"
        Me.btn_options.Size = New System.Drawing.Size(75, 140)
        Me.btn_options.TabIndex = 12
        Me.btn_options.Text = "Options"
        Me.btn_options.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_options.UseVisualStyleBackColor = True
        '
        'btn_launch
        '
        Me.btn_launch.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn_launch.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_launch.Image = Global.VMM.My.Resources.Resources.launch_24
        Me.btn_launch.Location = New System.Drawing.Point(101, 0)
        Me.btn_launch.Name = "btn_launch"
        Me.btn_launch.Size = New System.Drawing.Size(84, 140)
        Me.btn_launch.TabIndex = 9
        Me.btn_launch.Text = "Launch"
        Me.btn_launch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_launch.UseVisualStyleBackColor = True
        '
        'btn_about
        '
        Me.btn_about.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_about.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_about.Image = Global.VMM.My.Resources.Resources.info_16
        Me.btn_about.Location = New System.Drawing.Point(572, 0)
        Me.btn_about.Name = "btn_about"
        Me.btn_about.Size = New System.Drawing.Size(77, 140)
        Me.btn_about.TabIndex = 11
        Me.btn_about.Text = "About"
        Me.btn_about.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_about.UseVisualStyleBackColor = True
        '
        'ModuleControl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(649, 140)
        Me.CloseButtonVisible = False
        Me.Controls.Add(Me.btn_options)
        Me.Controls.Add(Me.btn_install)
        Me.Controls.Add(Me.btn_launch)
        Me.Controls.Add(Me.btn_about)
        Me.DockAreas = CType((WeifenLuo.WinFormsUI.Docking.DockAreas.DockTop Or WeifenLuo.WinFormsUI.Docking.DockAreas.DockBottom), WeifenLuo.WinFormsUI.Docking.DockAreas)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "ModuleControl"
        Me.Text = "Controls"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btn_install As Button
    Friend WithEvents btn_launch As Button
    Friend WithEvents btn_about As Button
    Friend WithEvents btn_options As Button
End Class
