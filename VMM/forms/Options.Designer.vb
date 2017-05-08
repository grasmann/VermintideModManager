<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Options
    Inherits System.Windows.Forms.Form

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
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.lbl_mod_repository_path = New System.Windows.Forms.Label()
        Me.grp_mod_repository = New System.Windows.Forms.GroupBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.btn_browse_mod_repository = New System.Windows.Forms.Button()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.grp_mod_repository.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(464, 387)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.grp_mod_repository)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(456, 361)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Development"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'lbl_mod_repository_path
        '
        Me.lbl_mod_repository_path.AutoSize = True
        Me.lbl_mod_repository_path.Location = New System.Drawing.Point(6, 26)
        Me.lbl_mod_repository_path.Name = "lbl_mod_repository_path"
        Me.lbl_mod_repository_path.Size = New System.Drawing.Size(29, 13)
        Me.lbl_mod_repository_path.TabIndex = 0
        Me.lbl_mod_repository_path.Text = "Path"
        '
        'grp_mod_repository
        '
        Me.grp_mod_repository.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grp_mod_repository.Controls.Add(Me.btn_browse_mod_repository)
        Me.grp_mod_repository.Controls.Add(Me.TextBox1)
        Me.grp_mod_repository.Controls.Add(Me.lbl_mod_repository_path)
        Me.grp_mod_repository.Location = New System.Drawing.Point(8, 6)
        Me.grp_mod_repository.Name = "grp_mod_repository"
        Me.grp_mod_repository.Size = New System.Drawing.Size(440, 56)
        Me.grp_mod_repository.TabIndex = 1
        Me.grp_mod_repository.TabStop = False
        Me.grp_mod_repository.Text = "Source Overwrite"
        '
        'TextBox1
        '
        Me.TextBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox1.Location = New System.Drawing.Point(84, 23)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(299, 20)
        Me.TextBox1.TabIndex = 1
        '
        'btn_browse_mod_repository
        '
        Me.btn_browse_mod_repository.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_browse_mod_repository.Location = New System.Drawing.Point(389, 21)
        Me.btn_browse_mod_repository.Name = "btn_browse_mod_repository"
        Me.btn_browse_mod_repository.Size = New System.Drawing.Size(45, 23)
        Me.btn_browse_mod_repository.TabIndex = 2
        Me.btn_browse_mod_repository.Text = "..."
        Me.btn_browse_mod_repository.UseVisualStyleBackColor = True
        '
        'Options
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(464, 387)
        Me.Controls.Add(Me.TabControl1)
        Me.Name = "Options"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Options"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.grp_mod_repository.ResumeLayout(False)
        Me.grp_mod_repository.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents grp_mod_repository As GroupBox
    Friend WithEvents lbl_mod_repository_path As Label
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents btn_browse_mod_repository As Button
End Class
