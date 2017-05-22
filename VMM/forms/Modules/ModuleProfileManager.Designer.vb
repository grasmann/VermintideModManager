Imports WeifenLuo.WinFormsUI.Docking

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ModuleProfileManager
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
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ModuleProfileManager))
        Me.grd_profiles = New System.Windows.Forms.DataGridView()
        Me.col_name = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.NewProfileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ContextMenuStrip2 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.CopyToToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        CType(Me.grd_profiles, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.ContextMenuStrip2.SuspendLayout()
        Me.SuspendLayout()
        '
        'grd_profiles
        '
        Me.grd_profiles.AllowUserToAddRows = False
        Me.grd_profiles.AllowUserToDeleteRows = False
        Me.grd_profiles.AllowUserToResizeRows = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grd_profiles.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.grd_profiles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grd_profiles.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.col_name})
        Me.grd_profiles.ContextMenuStrip = Me.ContextMenuStrip1
        Me.grd_profiles.Cursor = System.Windows.Forms.Cursors.Hand
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.grd_profiles.DefaultCellStyle = DataGridViewCellStyle2
        Me.grd_profiles.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grd_profiles.Location = New System.Drawing.Point(0, 0)
        Me.grd_profiles.MultiSelect = False
        Me.grd_profiles.Name = "grd_profiles"
        Me.grd_profiles.ReadOnly = True
        Me.grd_profiles.RowHeadersVisible = False
        Me.grd_profiles.RowTemplate.Height = 30
        Me.grd_profiles.Size = New System.Drawing.Size(441, 252)
        Me.grd_profiles.TabIndex = 2
        '
        'col_name
        '
        Me.col_name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.col_name.HeaderText = "Name"
        Me.col_name.Name = "col_name"
        Me.col_name.ReadOnly = True
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NewProfileToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(148, 26)
        '
        'NewProfileToolStripMenuItem
        '
        Me.NewProfileToolStripMenuItem.Image = Global.VMM.My.Resources.Resources.add_16
        Me.NewProfileToolStripMenuItem.Name = "NewProfileToolStripMenuItem"
        Me.NewProfileToolStripMenuItem.Size = New System.Drawing.Size(147, 22)
        Me.NewProfileToolStripMenuItem.Text = "New Profile ..."
        '
        'ContextMenuStrip2
        '
        Me.ContextMenuStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CopyToToolStripMenuItem, Me.ToolStripSeparator1, Me.DeleteToolStripMenuItem})
        Me.ContextMenuStrip2.Name = "ContextMenuStrip2"
        Me.ContextMenuStrip2.Size = New System.Drawing.Size(131, 54)
        '
        'CopyToToolStripMenuItem
        '
        Me.CopyToToolStripMenuItem.Image = Global.VMM.My.Resources.Resources.add_16
        Me.CopyToToolStripMenuItem.Name = "CopyToToolStripMenuItem"
        Me.CopyToToolStripMenuItem.Size = New System.Drawing.Size(130, 22)
        Me.CopyToToolStripMenuItem.Text = "Copy To ..."
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(127, 6)
        '
        'DeleteToolStripMenuItem
        '
        Me.DeleteToolStripMenuItem.Image = Global.VMM.My.Resources.Resources.uninstall_16
        Me.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem"
        Me.DeleteToolStripMenuItem.Size = New System.Drawing.Size(130, 22)
        Me.DeleteToolStripMenuItem.Text = "Delete"
        '
        'ModuleProfileManager
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(441, 252)
        Me.Controls.Add(Me.grd_profiles)
        Me.DockAreas = WeifenLuo.WinFormsUI.Docking.DockAreas.Document
        Me.HideOnClose = True
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "ModuleProfileManager"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Profile Manager"
        CType(Me.grd_profiles, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ContextMenuStrip2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grd_profiles As DataGridView
    Friend WithEvents col_name As DataGridViewTextBoxColumn
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents NewProfileToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ContextMenuStrip2 As ContextMenuStrip
    Friend WithEvents CopyToToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents DeleteToolStripMenuItem As ToolStripMenuItem
End Class
