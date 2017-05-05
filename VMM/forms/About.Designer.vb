<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class About
    Inherits System.Windows.Forms.Form

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(About))
        Me.lbl_name = New System.Windows.Forms.Label()
        Me.lbl_version = New System.Windows.Forms.Label()
        Me.lbl_made_by = New System.Windows.Forms.Label()
        Me.pb_image = New System.Windows.Forms.PictureBox()
        CType(Me.pb_image, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lbl_name
        '
        Me.lbl_name.AutoSize = True
        Me.lbl_name.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_name.Location = New System.Drawing.Point(227, 12)
        Me.lbl_name.Name = "lbl_name"
        Me.lbl_name.Size = New System.Drawing.Size(337, 31)
        Me.lbl_name.TabIndex = 1
        Me.lbl_name.Text = "Vermintide Mod Manager"
        '
        'lbl_version
        '
        Me.lbl_version.AutoSize = True
        Me.lbl_version.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_version.Location = New System.Drawing.Point(229, 52)
        Me.lbl_version.Name = "lbl_version"
        Me.lbl_version.Size = New System.Drawing.Size(63, 20)
        Me.lbl_version.TabIndex = 2
        Me.lbl_version.Text = "Label2"
        '
        'lbl_made_by
        '
        Me.lbl_made_by.AutoSize = True
        Me.lbl_made_by.Location = New System.Drawing.Point(468, 225)
        Me.lbl_made_by.Name = "lbl_made_by"
        Me.lbl_made_by.Size = New System.Drawing.Size(96, 13)
        Me.lbl_made_by.TabIndex = 3
        Me.lbl_made_by.Text = "made by grasmann"
        '
        'pb_image
        '
        Me.pb_image.Image = Global.VMM.My.Resources.Resources.n5vnLDPV
        Me.pb_image.Location = New System.Drawing.Point(12, 12)
        Me.pb_image.Name = "pb_image"
        Me.pb_image.Size = New System.Drawing.Size(209, 226)
        Me.pb_image.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pb_image.TabIndex = 0
        Me.pb_image.TabStop = False
        '
        'About
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(572, 250)
        Me.Controls.Add(Me.lbl_made_by)
        Me.Controls.Add(Me.lbl_version)
        Me.Controls.Add(Me.lbl_name)
        Me.Controls.Add(Me.pb_image)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "About"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "About"
        CType(Me.pb_image, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents pb_image As PictureBox
    Friend WithEvents lbl_name As Label
    Friend WithEvents lbl_version As Label
    Friend WithEvents lbl_made_by As Label
End Class
