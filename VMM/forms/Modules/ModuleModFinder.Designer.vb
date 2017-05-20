Imports WeifenLuo.WinFormsUI.Docking

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ModuleModFinder
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
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.col_name = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_version = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_size = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_img = New System.Windows.Forms.DataGridViewImageColumn()
        Me.col_installed = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_type = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ComboBox1
        '
        Me.ComboBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Items.AddRange(New Object() {"All", "Feature", "Fix", "Convenience", "Gamemode", "Cheat", "Debug"})
        Me.ComboBox1.Location = New System.Drawing.Point(0, 0)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(1024, 28)
        Me.ComboBox1.TabIndex = 0
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.AllowUserToResizeRows = False
        Me.DataGridView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.col_name, Me.col_version, Me.col_size, Me.col_img, Me.col_installed, Me.col_type})
        Me.DataGridView1.Location = New System.Drawing.Point(0, 29)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(1024, 470)
        Me.DataGridView1.TabIndex = 1
        '
        'col_name
        '
        Me.col_name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.col_name.HeaderText = "Name"
        Me.col_name.Name = "col_name"
        Me.col_name.ReadOnly = True
        '
        'col_version
        '
        Me.col_version.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.col_version.HeaderText = "Version"
        Me.col_version.Name = "col_version"
        Me.col_version.ReadOnly = True
        Me.col_version.Width = 67
        '
        'col_size
        '
        Me.col_size.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.col_size.HeaderText = "Size"
        Me.col_size.Name = "col_size"
        Me.col_size.ReadOnly = True
        Me.col_size.Width = 52
        '
        'col_img
        '
        Me.col_img.HeaderText = ""
        Me.col_img.Name = "col_img"
        Me.col_img.ReadOnly = True
        Me.col_img.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.col_img.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.col_img.Width = 30
        '
        'col_installed
        '
        Me.col_installed.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.col_installed.HeaderText = "Installed"
        Me.col_installed.Name = "col_installed"
        Me.col_installed.ReadOnly = True
        Me.col_installed.Width = 71
        '
        'col_type
        '
        Me.col_type.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.col_type.HeaderText = "Type"
        Me.col_type.Name = "col_type"
        Me.col_type.ReadOnly = True
        Me.col_type.Visible = False
        Me.col_type.Width = 56
        '
        'ModuleModFinder
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1024, 499)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.ComboBox1)
        Me.HideOnClose = True
        Me.Name = "ModuleModFinder"
        Me.Text = "Mod Downloader"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents col_name As DataGridViewTextBoxColumn
    Friend WithEvents col_version As DataGridViewTextBoxColumn
    Friend WithEvents col_size As DataGridViewTextBoxColumn
    Friend WithEvents col_img As DataGridViewImageColumn
    Friend WithEvents col_installed As DataGridViewTextBoxColumn
    Friend WithEvents col_type As DataGridViewTextBoxColumn
End Class
