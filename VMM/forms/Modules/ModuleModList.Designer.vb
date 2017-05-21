Imports WeifenLuo.WinFormsUI.Docking

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ModuleModList
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ModuleModList))
        Me.MetroGrid1 = New System.Windows.Forms.DataGridView()
        Me.col_image = New System.Windows.Forms.DataGridViewImageColumn()
        Me.col_name = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_author = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_version = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_readme = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ActivateToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeactivateToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SwapToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        CType(Me.MetroGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MetroGrid1
        '
        Me.MetroGrid1.AllowUserToAddRows = False
        Me.MetroGrid1.AllowUserToDeleteRows = False
        Me.MetroGrid1.AllowUserToResizeRows = False
        Me.MetroGrid1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.MetroGrid1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.col_image, Me.col_name, Me.col_author, Me.col_version, Me.col_readme, Me.col_1, Me.col_2})
        Me.MetroGrid1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.MetroGrid1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MetroGrid1.Location = New System.Drawing.Point(0, 0)
        Me.MetroGrid1.Name = "MetroGrid1"
        Me.MetroGrid1.ReadOnly = True
        Me.MetroGrid1.RowHeadersVisible = False
        Me.MetroGrid1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.MetroGrid1.Size = New System.Drawing.Size(511, 342)
        Me.MetroGrid1.TabIndex = 1
        '
        'col_image
        '
        Me.col_image.HeaderText = ""
        Me.col_image.Name = "col_image"
        Me.col_image.ReadOnly = True
        Me.col_image.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.col_image.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.col_image.Width = 35
        '
        'col_name
        '
        Me.col_name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.col_name.HeaderText = "Name"
        Me.col_name.Name = "col_name"
        Me.col_name.ReadOnly = True
        '
        'col_author
        '
        Me.col_author.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.col_author.HeaderText = "Author"
        Me.col_author.Name = "col_author"
        Me.col_author.ReadOnly = True
        Me.col_author.Width = 63
        '
        'col_version
        '
        Me.col_version.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.col_version.HeaderText = "Version"
        Me.col_version.Name = "col_version"
        Me.col_version.ReadOnly = True
        Me.col_version.Width = 67
        '
        'col_readme
        '
        Me.col_readme.HeaderText = ""
        Me.col_readme.Name = "col_readme"
        Me.col_readme.ReadOnly = True
        Me.col_readme.Visible = False
        '
        'col_1
        '
        Me.col_1.HeaderText = ""
        Me.col_1.Name = "col_1"
        Me.col_1.ReadOnly = True
        Me.col_1.Visible = False
        '
        'col_2
        '
        Me.col_2.HeaderText = ""
        Me.col_2.Name = "col_2"
        Me.col_2.ReadOnly = True
        Me.col_2.Visible = False
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ActivateToolStripMenuItem, Me.DeactivateToolStripMenuItem, Me.SwapToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(130, 70)
        '
        'ActivateToolStripMenuItem
        '
        Me.ActivateToolStripMenuItem.Image = Global.VMM.My.Resources.Resources.install_16
        Me.ActivateToolStripMenuItem.Name = "ActivateToolStripMenuItem"
        Me.ActivateToolStripMenuItem.Size = New System.Drawing.Size(129, 22)
        Me.ActivateToolStripMenuItem.Text = "Activate"
        '
        'DeactivateToolStripMenuItem
        '
        Me.DeactivateToolStripMenuItem.Image = Global.VMM.My.Resources.Resources.uninstall_16
        Me.DeactivateToolStripMenuItem.Name = "DeactivateToolStripMenuItem"
        Me.DeactivateToolStripMenuItem.Size = New System.Drawing.Size(129, 22)
        Me.DeactivateToolStripMenuItem.Text = "Deactivate"
        '
        'SwapToolStripMenuItem
        '
        Me.SwapToolStripMenuItem.Image = Global.VMM.My.Resources.Resources.swap_16
        Me.SwapToolStripMenuItem.Name = "SwapToolStripMenuItem"
        Me.SwapToolStripMenuItem.Size = New System.Drawing.Size(129, 22)
        Me.SwapToolStripMenuItem.Text = "Swap"
        '
        'ModuleModList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(511, 342)
        Me.CloseButton = False
        Me.CloseButtonVisible = False
        Me.Controls.Add(Me.MetroGrid1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "ModuleModList"
        Me.Text = "Mods"
        CType(Me.MetroGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents MetroGrid1 As DataGridView
    Friend WithEvents col_image As DataGridViewImageColumn
    Friend WithEvents col_name As DataGridViewTextBoxColumn
    Friend WithEvents col_author As DataGridViewTextBoxColumn
    Friend WithEvents col_version As DataGridViewTextBoxColumn
    Friend WithEvents col_readme As DataGridViewTextBoxColumn
    Friend WithEvents col_1 As DataGridViewTextBoxColumn
    Friend WithEvents col_2 As DataGridViewTextBoxColumn
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents ActivateToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DeactivateToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SwapToolStripMenuItem As ToolStripMenuItem
End Class
