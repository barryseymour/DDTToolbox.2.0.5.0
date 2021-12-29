<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPending
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPending))
		Me.btnOK = New System.Windows.Forms.Button()
		Me.dgvPending = New DDTToolbox.ExtDataGridView()
		Me.btnDelete = New DDTToolbox.ExtButton()
		Me.btnEdit = New DDTToolbox.ExtButton()
		CType(Me.dgvPending, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.SuspendLayout()
		'
		'btnOK
		'
		Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
		Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.Cancel
		Me.btnOK.Location = New System.Drawing.Point(311, 347)
		Me.btnOK.Name = "btnOK"
		Me.btnOK.Size = New System.Drawing.Size(76, 25)
		Me.btnOK.TabIndex = 0
		Me.btnOK.Text = "OK"
		Me.btnOK.UseVisualStyleBackColor = True
		'
		'dgvPending
		'
		Me.dgvPending.AllowUserToAddRows = False
		Me.dgvPending.AllowUserToDeleteRows = False
		Me.dgvPending.AllowUserToOrderColumns = True
		Me.dgvPending.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
			Or System.Windows.Forms.AnchorStyles.Left) _
			Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.dgvPending.BackgroundColor = System.Drawing.SystemColors.Control
		Me.dgvPending.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
		Me.dgvPending.Location = New System.Drawing.Point(12, 13)
		Me.dgvPending.Name = "dgvPending"
		Me.dgvPending.ReadOnly = True
		Me.dgvPending.RowHeaderNumbers = True
		Me.dgvPending.RowHeaderNumbersLocationX = 10
		Me.dgvPending.RowHeaderNumbersLocationY = 3
		Me.dgvPending.RowHeadersWidth = 30
		Me.dgvPending.RowTemplate.Height = 18
		Me.dgvPending.Size = New System.Drawing.Size(676, 318)
		Me.dgvPending.TabIndex = 4
		'
		'btnDelete
		'
		Me.btnDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
		Me.btnDelete.Location = New System.Drawing.Point(611, 347)
		Me.btnDelete.MouseOverBackColor = System.Drawing.Color.Empty
		Me.btnDelete.MouseOverCursor = Nothing
		Me.btnDelete.MouseOverFont = Nothing
		Me.btnDelete.MouseOverForeColor = System.Drawing.Color.Empty
		Me.btnDelete.MouseOverImage = Nothing
		Me.btnDelete.MouseOverText = Nothing
		Me.btnDelete.Name = "btnDelete"
		Me.btnDelete.Size = New System.Drawing.Size(75, 23)
		Me.btnDelete.TabIndex = 6
		Me.btnDelete.Text = "Delete"
		Me.btnDelete.UseVisualStyleBackColor = True
		Me.btnDelete.Visible = False
		'
		'btnEdit
		'
		Me.btnEdit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
		Me.btnEdit.Location = New System.Drawing.Point(525, 347)
		Me.btnEdit.MouseOverBackColor = System.Drawing.Color.Empty
		Me.btnEdit.MouseOverCursor = Nothing
		Me.btnEdit.MouseOverFont = Nothing
		Me.btnEdit.MouseOverForeColor = System.Drawing.Color.Empty
		Me.btnEdit.MouseOverImage = Nothing
		Me.btnEdit.MouseOverText = Nothing
		Me.btnEdit.Name = "btnEdit"
		Me.btnEdit.Size = New System.Drawing.Size(75, 23)
		Me.btnEdit.TabIndex = 5
		Me.btnEdit.Text = "Edit"
		Me.btnEdit.UseVisualStyleBackColor = True
		'
		'frmPending
		'
		Me.AcceptButton = Me.btnOK
		Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
		Me.CancelButton = Me.btnOK
		Me.ClientSize = New System.Drawing.Size(698, 390)
		Me.Controls.Add(Me.btnDelete)
		Me.Controls.Add(Me.btnEdit)
		Me.Controls.Add(Me.dgvPending)
		Me.Controls.Add(Me.btnOK)
		Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
		Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
		Me.MinimizeBox = False
		Me.Name = "frmPending"
		Me.ShowInTaskbar = False
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.Text = "Pending AD Updates"
		CType(Me.dgvPending, System.ComponentModel.ISupportInitialize).EndInit()
		Me.ResumeLayout(False)

	End Sub
    Friend WithEvents btnOK As System.Windows.Forms.Button
    'Friend WithEvents dgvPending As System.Windows.Forms.DataGridView
    Friend WithEvents dgvPending As DDTToolbox.ExtDataGridView
    Friend WithEvents btnEdit As DDTToolbox.ExtButton
    Friend WithEvents btnDelete As DDTToolbox.ExtButton
End Class
