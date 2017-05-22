Imports WeifenLuo.WinFormsUI.Docking

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class About
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(About))
        Me.lbl_name = New System.Windows.Forms.Label()
        Me.lbl_version = New System.Windows.Forms.Label()
        Me.lbl_made_by = New System.Windows.Forms.Label()
        Me.pb_image = New System.Windows.Forms.PictureBox()
        Me.lbl_update = New System.Windows.Forms.Label()
        Me.btn_update = New System.Windows.Forms.Button()
        Me.lbl_up_to_date = New System.Windows.Forms.Label()
        Me.lbl_checking_update = New System.Windows.Forms.Label()
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
        'lbl_update
        '
        Me.lbl_update.AutoSize = True
        Me.lbl_update.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_update.Location = New System.Drawing.Point(230, 110)
        Me.lbl_update.Name = "lbl_update"
        Me.lbl_update.Size = New System.Drawing.Size(156, 18)
        Me.lbl_update.TabIndex = 4
        Me.lbl_update.Text = "New Version available."
        Me.lbl_update.Visible = False
        '
        'btn_update
        '
        Me.btn_update.Image = Global.VMM.My.Resources.Resources.launch_24
        Me.btn_update.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_update.Location = New System.Drawing.Point(233, 131)
        Me.btn_update.Name = "btn_update"
        Me.btn_update.Size = New System.Drawing.Size(98, 30)
        Me.btn_update.TabIndex = 5
        Me.btn_update.Text = "Update"
        Me.btn_update.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_update.UseVisualStyleBackColor = True
        Me.btn_update.Visible = False
        '
        'lbl_up_to_date
        '
        Me.lbl_up_to_date.AutoSize = True
        Me.lbl_up_to_date.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_up_to_date.Location = New System.Drawing.Point(230, 110)
        Me.lbl_up_to_date.Name = "lbl_up_to_date"
        Me.lbl_up_to_date.Size = New System.Drawing.Size(188, 18)
        Me.lbl_up_to_date.TabIndex = 6
        Me.lbl_up_to_date.Text = "Mod Manager is up to date."
        Me.lbl_up_to_date.Visible = False
        '
        'lbl_checking_update
        '
        Me.lbl_checking_update.AutoSize = True
        Me.lbl_checking_update.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_checking_update.Location = New System.Drawing.Point(230, 110)
        Me.lbl_checking_update.Name = "lbl_checking_update"
        Me.lbl_checking_update.Size = New System.Drawing.Size(260, 18)
        Me.lbl_checking_update.TabIndex = 7
        Me.lbl_checking_update.Text = "Checking for Mod Manager updates ..."
        Me.lbl_checking_update.Visible = False
        '
        'About
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(572, 250)
        Me.Controls.Add(Me.lbl_checking_update)
        Me.Controls.Add(Me.lbl_up_to_date)
        Me.Controls.Add(Me.btn_update)
        Me.Controls.Add(Me.lbl_update)
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
    Friend WithEvents lbl_update As Label
    Friend WithEvents btn_update As Button
    Friend WithEvents lbl_up_to_date As Label
    Friend WithEvents lbl_checking_update As Label
End Class
