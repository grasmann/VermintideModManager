Imports WeifenLuo.WinFormsUI.Docking

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ModuleOptions
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ModuleOptions))
        Me.tab_options = New System.Windows.Forms.TabControl()
        Me.tab_view = New System.Windows.Forms.TabPage()
        Me.grp_modules = New System.Windows.Forms.GroupBox()
        Me.grd_modules = New System.Windows.Forms.DataGridView()
        Me.mod_name = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.mod_hide = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.tab_development = New System.Windows.Forms.TabPage()
        Me.grp_mod_repository = New System.Windows.Forms.GroupBox()
        Me.lbl_source_ = New System.Windows.Forms.Label()
        Me.btn_browse_mod_repository = New System.Windows.Forms.Button()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.lbl_mod_repository_path = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.tab_options.SuspendLayout()
        Me.tab_view.SuspendLayout()
        Me.grp_modules.SuspendLayout()
        CType(Me.grd_modules, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tab_development.SuspendLayout()
        Me.grp_mod_repository.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'tab_options
        '
        Me.tab_options.Controls.Add(Me.tab_view)
        Me.tab_options.Controls.Add(Me.tab_development)
        Me.tab_options.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tab_options.HotTrack = True
        Me.tab_options.Location = New System.Drawing.Point(0, 0)
        Me.tab_options.Name = "tab_options"
        Me.tab_options.SelectedIndex = 0
        Me.tab_options.Size = New System.Drawing.Size(361, 474)
        Me.tab_options.TabIndex = 0
        '
        'tab_view
        '
        Me.tab_view.Controls.Add(Me.grp_modules)
        Me.tab_view.Location = New System.Drawing.Point(4, 24)
        Me.tab_view.Name = "tab_view"
        Me.tab_view.Size = New System.Drawing.Size(353, 446)
        Me.tab_view.TabIndex = 1
        Me.tab_view.Text = "View"
        Me.tab_view.UseVisualStyleBackColor = True
        '
        'grp_modules
        '
        Me.grp_modules.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grp_modules.Controls.Add(Me.grd_modules)
        Me.grp_modules.Location = New System.Drawing.Point(8, 6)
        Me.grp_modules.Name = "grp_modules"
        Me.grp_modules.Size = New System.Drawing.Size(325, 225)
        Me.grp_modules.TabIndex = 0
        Me.grp_modules.TabStop = False
        Me.grp_modules.Text = "Modules"
        '
        'grd_modules
        '
        Me.grd_modules.AllowUserToAddRows = False
        Me.grd_modules.AllowUserToDeleteRows = False
        Me.grd_modules.AllowUserToResizeRows = False
        Me.grd_modules.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grd_modules.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grd_modules.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.mod_name, Me.mod_hide})
        Me.grd_modules.Cursor = System.Windows.Forms.Cursors.Hand
        Me.grd_modules.Location = New System.Drawing.Point(6, 19)
        Me.grd_modules.MultiSelect = False
        Me.grd_modules.Name = "grd_modules"
        Me.grd_modules.RowHeadersVisible = False
        Me.grd_modules.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.grd_modules.Size = New System.Drawing.Size(313, 200)
        Me.grd_modules.TabIndex = 0
        '
        'mod_name
        '
        Me.mod_name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.mod_name.HeaderText = "Name"
        Me.mod_name.Name = "mod_name"
        Me.mod_name.ReadOnly = True
        '
        'mod_hide
        '
        Me.mod_hide.HeaderText = "Hide"
        Me.mod_hide.Name = "mod_hide"
        Me.mod_hide.ReadOnly = True
        Me.mod_hide.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.mod_hide.Width = 50
        '
        'tab_development
        '
        Me.tab_development.Controls.Add(Me.grp_mod_repository)
        Me.tab_development.Location = New System.Drawing.Point(4, 24)
        Me.tab_development.Name = "tab_development"
        Me.tab_development.Padding = New System.Windows.Forms.Padding(3)
        Me.tab_development.Size = New System.Drawing.Size(353, 446)
        Me.tab_development.TabIndex = 0
        Me.tab_development.Text = "Development"
        Me.tab_development.UseVisualStyleBackColor = True
        '
        'grp_mod_repository
        '
        Me.grp_mod_repository.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grp_mod_repository.Controls.Add(Me.lbl_source_)
        Me.grp_mod_repository.Controls.Add(Me.btn_browse_mod_repository)
        Me.grp_mod_repository.Controls.Add(Me.TextBox1)
        Me.grp_mod_repository.Controls.Add(Me.lbl_mod_repository_path)
        Me.grp_mod_repository.Location = New System.Drawing.Point(8, 6)
        Me.grp_mod_repository.Name = "grp_mod_repository"
        Me.grp_mod_repository.Size = New System.Drawing.Size(337, 98)
        Me.grp_mod_repository.TabIndex = 1
        Me.grp_mod_repository.TabStop = False
        Me.grp_mod_repository.Text = "Source Overwrite"
        '
        'lbl_source_
        '
        Me.lbl_source_.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbl_source_.Location = New System.Drawing.Point(6, 56)
        Me.lbl_source_.Name = "lbl_source_"
        Me.lbl_source_.Size = New System.Drawing.Size(327, 26)
        Me.lbl_source_.TabIndex = 3
        Me.lbl_source_.Text = "Open corresponding source files from a different directory." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "To choose the direct" &
    "ory browse for the vermintideconsole.dll."
        Me.lbl_source_.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btn_browse_mod_repository
        '
        Me.btn_browse_mod_repository.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_browse_mod_repository.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_browse_mod_repository.Location = New System.Drawing.Point(286, 21)
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
        Me.TextBox1.Location = New System.Drawing.Point(41, 23)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(239, 20)
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
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.tab_options)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(363, 476)
        Me.Panel1.TabIndex = 1
        '
        'ModuleOptions
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(363, 476)
        Me.Controls.Add(Me.Panel1)
        Me.HideOnClose = True
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "ModuleOptions"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Options"
        Me.tab_options.ResumeLayout(False)
        Me.tab_view.ResumeLayout(False)
        Me.grp_modules.ResumeLayout(False)
        CType(Me.grd_modules, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tab_development.ResumeLayout(False)
        Me.grp_mod_repository.ResumeLayout(False)
        Me.grp_mod_repository.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents tab_options As TabControl
    Friend WithEvents tab_development As TabPage
    Friend WithEvents grp_mod_repository As GroupBox
    Friend WithEvents lbl_mod_repository_path As Label
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents btn_browse_mod_repository As Button
    Friend WithEvents tab_view As TabPage
    Friend WithEvents grp_modules As GroupBox
    Friend WithEvents grd_modules As DataGridView
    Friend WithEvents mod_name As DataGridViewTextBoxColumn
    Friend WithEvents mod_hide As DataGridViewCheckBoxColumn
    Friend WithEvents lbl_source_ As Label
    Friend WithEvents Panel1 As Panel
End Class
