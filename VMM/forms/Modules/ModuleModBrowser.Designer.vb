Imports WeifenLuo.WinFormsUI.Docking

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ModuleModBrowser
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.btn_refresh = New System.Windows.Forms.Button()
        Me.lbl_fetch = New System.Windows.Forms.Label()
        Me.col_img = New System.Windows.Forms.DataGridViewImageColumn()
        Me.col_name = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_authors = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_version = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_size = New System.Windows.Forms.DataGridViewTextBoxColumn()
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
        Me.ComboBox1.Location = New System.Drawing.Point(60, 0)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(888, 28)
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
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.col_img, Me.col_name, Me.col_authors, Me.col_version, Me.col_size, Me.col_installed, Me.col_type})
        Me.DataGridView1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.DataGridView1.EnableHeadersVisualStyles = False
        Me.DataGridView1.Location = New System.Drawing.Point(0, 29)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(1024, 470)
        Me.DataGridView1.TabIndex = 1
        '
        'btn_refresh
        '
        Me.btn_refresh.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_refresh.Image = Global.VMM.My.Resources.Resources.swap_16
        Me.btn_refresh.Location = New System.Drawing.Point(948, -1)
        Me.btn_refresh.Name = "btn_refresh"
        Me.btn_refresh.Size = New System.Drawing.Size(77, 30)
        Me.btn_refresh.TabIndex = 2
        Me.btn_refresh.Text = "Refresh"
        Me.btn_refresh.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_refresh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_refresh.UseVisualStyleBackColor = True
        '
        'lbl_fetch
        '
        Me.lbl_fetch.AutoSize = True
        Me.lbl_fetch.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_fetch.Location = New System.Drawing.Point(2, 2)
        Me.lbl_fetch.Name = "lbl_fetch"
        Me.lbl_fetch.Size = New System.Drawing.Size(58, 24)
        Me.lbl_fetch.TabIndex = 3
        Me.lbl_fetch.Text = "Fetch"
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
        'col_name
        '
        Me.col_name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.col_name.HeaderText = "Name"
        Me.col_name.Name = "col_name"
        Me.col_name.ReadOnly = True
        '
        'col_authors
        '
        Me.col_authors.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.col_authors.HeaderText = "Authors"
        Me.col_authors.Name = "col_authors"
        Me.col_authors.ReadOnly = True
        Me.col_authors.Width = 90
        '
        'col_version
        '
        Me.col_version.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.col_version.HeaderText = "Version"
        Me.col_version.Name = "col_version"
        Me.col_version.ReadOnly = True
        Me.col_version.Width = 88
        '
        'col_size
        '
        Me.col_size.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.col_size.HeaderText = "Size"
        Me.col_size.Name = "col_size"
        Me.col_size.ReadOnly = True
        Me.col_size.Width = 65
        '
        'col_installed
        '
        Me.col_installed.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.col_installed.HeaderText = ""
        Me.col_installed.Name = "col_installed"
        Me.col_installed.ReadOnly = True
        Me.col_installed.Width = 19
        '
        'col_type
        '
        Me.col_type.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.col_type.HeaderText = "Type"
        Me.col_type.Name = "col_type"
        Me.col_type.ReadOnly = True
        Me.col_type.Visible = False
        Me.col_type.Width = 68
        '
        'ModuleModBrowser
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1024, 499)
        Me.CloseButton = False
        Me.CloseButtonVisible = False
        Me.Controls.Add(Me.lbl_fetch)
        Me.Controls.Add(Me.btn_refresh)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.ComboBox1)
        Me.DockAreas = WeifenLuo.WinFormsUI.Docking.DockAreas.Document
        Me.Name = "ModuleModBrowser"
        Me.Text = "Mod Browser"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents btn_refresh As Button
    Friend WithEvents lbl_fetch As Label
    Friend WithEvents col_img As DataGridViewImageColumn
    Friend WithEvents col_name As DataGridViewTextBoxColumn
    Friend WithEvents col_authors As DataGridViewTextBoxColumn
    Friend WithEvents col_version As DataGridViewTextBoxColumn
    Friend WithEvents col_size As DataGridViewTextBoxColumn
    Friend WithEvents col_installed As DataGridViewTextBoxColumn
    Friend WithEvents col_type As DataGridViewTextBoxColumn
End Class
