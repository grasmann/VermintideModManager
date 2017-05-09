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
        Me.grp_mod_repository = New System.Windows.Forms.GroupBox()
        Me.btn_browse_mod_repository = New System.Windows.Forms.Button()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.lbl_mod_repository_path = New System.Windows.Forms.Label()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.grp_modules = New System.Windows.Forms.GroupBox()
        Me.grd_modules = New System.Windows.Forms.DataGridView()
        Me.mod_name = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.mod_active = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.grp_mod_repository.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.grp_modules.SuspendLayout()
        CType(Me.grd_modules, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage2)
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
        'btn_browse_mod_repository
        '
        Me.btn_browse_mod_repository.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_browse_mod_repository.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_browse_mod_repository.Location = New System.Drawing.Point(389, 21)
        Me.btn_browse_mod_repository.Name = "btn_browse_mod_repository"
        Me.btn_browse_mod_repository.Size = New System.Drawing.Size(45, 23)
        Me.btn_browse_mod_repository.TabIndex = 2
        Me.btn_browse_mod_repository.Text = "..."
        Me.btn_browse_mod_repository.UseVisualStyleBackColor = True
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
        'lbl_mod_repository_path
        '
        Me.lbl_mod_repository_path.AutoSize = True
        Me.lbl_mod_repository_path.Location = New System.Drawing.Point(6, 26)
        Me.lbl_mod_repository_path.Name = "lbl_mod_repository_path"
        Me.lbl_mod_repository_path.Size = New System.Drawing.Size(29, 13)
        Me.lbl_mod_repository_path.TabIndex = 0
        Me.lbl_mod_repository_path.Text = "Path"
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.grp_modules)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Size = New System.Drawing.Size(456, 361)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "View"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'grp_modules
        '
        Me.grp_modules.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grp_modules.Controls.Add(Me.grd_modules)
        Me.grp_modules.Location = New System.Drawing.Point(8, 6)
        Me.grp_modules.Name = "grp_modules"
        Me.grp_modules.Size = New System.Drawing.Size(440, 143)
        Me.grp_modules.TabIndex = 0
        Me.grp_modules.TabStop = False
        Me.grp_modules.Text = "Modules"
        '
        'grd_modules
        '
        Me.grd_modules.AllowUserToAddRows = False
        Me.grd_modules.AllowUserToDeleteRows = False
        Me.grd_modules.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grd_modules.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grd_modules.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.mod_name, Me.mod_active})
        Me.grd_modules.Location = New System.Drawing.Point(6, 19)
        Me.grd_modules.MultiSelect = False
        Me.grd_modules.Name = "grd_modules"
        Me.grd_modules.RowHeadersVisible = False
        Me.grd_modules.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.grd_modules.Size = New System.Drawing.Size(428, 118)
        Me.grd_modules.TabIndex = 0
        '
        'mod_name
        '
        Me.mod_name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.mod_name.HeaderText = "Name"
        Me.mod_name.Name = "mod_name"
        Me.mod_name.ReadOnly = True
        '
        'mod_active
        '
        Me.mod_active.HeaderText = "Active"
        Me.mod_active.Name = "mod_active"
        Me.mod_active.ReadOnly = True
        Me.mod_active.Width = 50
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
        Me.TabPage2.ResumeLayout(False)
        Me.grp_modules.ResumeLayout(False)
        CType(Me.grd_modules, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents grp_mod_repository As GroupBox
    Friend WithEvents lbl_mod_repository_path As Label
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents btn_browse_mod_repository As Button
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents grp_modules As GroupBox
    Friend WithEvents grd_modules As DataGridView
    Friend WithEvents mod_name As DataGridViewTextBoxColumn
    Friend WithEvents mod_active As DataGridViewCheckBoxColumn
End Class
