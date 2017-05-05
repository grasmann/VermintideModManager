Imports WeifenLuo.WinFormsUI.Docking

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ModuleRequirements
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ModuleRequirements))
        Me.grd_requirements = New System.Windows.Forms.DataGridView()
        Me.imgl_states = New System.Windows.Forms.ImageList(Me.components)
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ActivateToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.col_state = New System.Windows.Forms.DataGridViewImageColumn()
        Me.col_name = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_install = New System.Windows.Forms.DataGridViewButtonColumn()
        CType(Me.grd_requirements, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'grd_requirements
        '
        Me.grd_requirements.AllowUserToAddRows = False
        Me.grd_requirements.AllowUserToDeleteRows = False
        Me.grd_requirements.AllowUserToResizeRows = False
        Me.grd_requirements.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grd_requirements.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.col_state, Me.col_name, Me.col_install})
        Me.grd_requirements.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grd_requirements.Location = New System.Drawing.Point(0, 0)
        Me.grd_requirements.MultiSelect = False
        Me.grd_requirements.Name = "grd_requirements"
        Me.grd_requirements.ReadOnly = True
        Me.grd_requirements.RowHeadersVisible = False
        Me.grd_requirements.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.grd_requirements.Size = New System.Drawing.Size(292, 266)
        Me.grd_requirements.TabIndex = 0
        '
        'imgl_states
        '
        Me.imgl_states.ImageStream = CType(resources.GetObject("imgl_states.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imgl_states.TransparentColor = System.Drawing.Color.Transparent
        Me.imgl_states.Images.SetKeyName(0, "activated")
        Me.imgl_states.Images.SetKeyName(1, "deactivated")
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ActivateToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(118, 26)
        '
        'ActivateToolStripMenuItem
        '
        Me.ActivateToolStripMenuItem.Image = Global.VMM.My.Resources.Resources.install_16
        Me.ActivateToolStripMenuItem.Name = "ActivateToolStripMenuItem"
        Me.ActivateToolStripMenuItem.Size = New System.Drawing.Size(117, 22)
        Me.ActivateToolStripMenuItem.Text = "Activate"
        '
        'col_state
        '
        Me.col_state.HeaderText = ""
        Me.col_state.Name = "col_state"
        Me.col_state.ReadOnly = True
        Me.col_state.Width = 35
        '
        'col_name
        '
        Me.col_name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.col_name.HeaderText = "Name"
        Me.col_name.Name = "col_name"
        Me.col_name.ReadOnly = True
        '
        'col_install
        '
        Me.col_install.HeaderText = ""
        Me.col_install.Name = "col_install"
        Me.col_install.ReadOnly = True
        Me.col_install.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.col_install.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'Requirements
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(292, 266)
        Me.CloseButtonVisible = False
        Me.Controls.Add(Me.grd_requirements)
        Me.Name = "Requirements"
        Me.Text = "Requirements"
        CType(Me.grd_requirements, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents grd_requirements As DataGridView
    Friend WithEvents imgl_states As ImageList
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents ActivateToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents col_state As DataGridViewImageColumn
    Friend WithEvents col_name As DataGridViewTextBoxColumn
    Friend WithEvents col_install As DataGridViewButtonColumn
End Class
