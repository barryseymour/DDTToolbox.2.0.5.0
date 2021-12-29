<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmManageReports
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
		Me.components = New System.ComponentModel.Container()
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmManageReports))
		Me.pnlPrimary = New System.Windows.Forms.Panel()
		Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
		Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel()
		Me.grpReports = New System.Windows.Forms.GroupBox()
		Me.pnlButtons = New System.Windows.Forms.Panel()
		Me.btnPaste = New DDTToolbox.ExtButton()
		Me.btnCopy = New DDTToolbox.ExtButton()
		Me.btnCancel = New System.Windows.Forms.Button()
		Me.btnDeleteReport = New System.Windows.Forms.Button()
		Me.btnAddReport = New System.Windows.Forms.Button()
		Me.btnEditReport = New System.Windows.Forms.Button()
		Me.ckUseTabs = New System.Windows.Forms.CheckBox()
		Me.ckIsStatic = New System.Windows.Forms.CheckBox()
		Me.dgvReports = New System.Windows.Forms.DataGridView()
		Me.cmEditOptions = New System.Windows.Forms.ContextMenuStrip(Me.components)
		Me.AddToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		Me.CopyToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		Me.dgvReportProperties = New System.Windows.Forms.DataGridView()
		Me.PropertyName = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.PropertyValue = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
		Me.lblServerConnection = New System.Windows.Forms.ToolStripLabel()
		Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
		Me.ToolStripLblEditing = New System.Windows.Forms.ToolStripLabel()
		Me.tmrEditAvailability = New System.Windows.Forms.Timer(Me.components)
		Me.tmrBlinkEdit = New System.Windows.Forms.Timer(Me.components)
		Me.pnlPrimary.SuspendLayout()
		Me.StatusStrip1.SuspendLayout()
		Me.grpReports.SuspendLayout()
		Me.pnlButtons.SuspendLayout()
		CType(Me.dgvReports, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.cmEditOptions.SuspendLayout()
		CType(Me.dgvReportProperties, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.ToolStrip1.SuspendLayout()
		Me.SuspendLayout()
		'
		'pnlPrimary
		'
		Me.pnlPrimary.BackColor = System.Drawing.Color.White
		Me.pnlPrimary.Controls.Add(Me.StatusStrip1)
		Me.pnlPrimary.Controls.Add(Me.grpReports)
		Me.pnlPrimary.Dock = System.Windows.Forms.DockStyle.Fill
		Me.pnlPrimary.Location = New System.Drawing.Point(0, 25)
		Me.pnlPrimary.Name = "pnlPrimary"
		Me.pnlPrimary.Size = New System.Drawing.Size(938, 636)
		Me.pnlPrimary.TabIndex = 0
		'
		'StatusStrip1
		'
		Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel2})
		Me.StatusStrip1.Location = New System.Drawing.Point(0, 614)
		Me.StatusStrip1.Name = "StatusStrip1"
		Me.StatusStrip1.Size = New System.Drawing.Size(938, 22)
		Me.StatusStrip1.Stretch = False
		Me.StatusStrip1.TabIndex = 6
		Me.StatusStrip1.Text = "StatusStrip1"
		'
		'ToolStripStatusLabel2
		'
		Me.ToolStripStatusLabel2.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.ToolStripStatusLabel2.ForeColor = System.Drawing.Color.PaleVioletRed
		Me.ToolStripStatusLabel2.Name = "ToolStripStatusLabel2"
		Me.ToolStripStatusLabel2.Size = New System.Drawing.Size(100, 17)
		Me.ToolStripStatusLabel2.Text = "No Tree Level ID"
		'
		'grpReports
		'
		Me.grpReports.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
			Or System.Windows.Forms.AnchorStyles.Left) _
			Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.grpReports.Controls.Add(Me.pnlButtons)
		Me.grpReports.Controls.Add(Me.ckUseTabs)
		Me.grpReports.Controls.Add(Me.ckIsStatic)
		Me.grpReports.Controls.Add(Me.dgvReports)
		Me.grpReports.Controls.Add(Me.dgvReportProperties)
		Me.grpReports.Location = New System.Drawing.Point(3, 3)
		Me.grpReports.Name = "grpReports"
		Me.grpReports.Size = New System.Drawing.Size(932, 608)
		Me.grpReports.TabIndex = 4
		Me.grpReports.TabStop = False
		Me.grpReports.Text = "Reports"
		'
		'pnlButtons
		'
		Me.pnlButtons.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
			Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.pnlButtons.BackColor = System.Drawing.SystemColors.Control
		Me.pnlButtons.Controls.Add(Me.btnPaste)
		Me.pnlButtons.Controls.Add(Me.btnCopy)
		Me.pnlButtons.Controls.Add(Me.btnCancel)
		Me.pnlButtons.Controls.Add(Me.btnDeleteReport)
		Me.pnlButtons.Controls.Add(Me.btnAddReport)
		Me.pnlButtons.Controls.Add(Me.btnEditReport)
		Me.pnlButtons.Location = New System.Drawing.Point(342, 556)
		Me.pnlButtons.Name = "pnlButtons"
		Me.pnlButtons.Size = New System.Drawing.Size(588, 52)
		Me.pnlButtons.TabIndex = 5
		'
		'btnPaste
		'
		Me.btnPaste.Location = New System.Drawing.Point(335, 15)
		Me.btnPaste.MouseOverBackColor = System.Drawing.Color.Empty
		Me.btnPaste.MouseOverCursor = Nothing
		Me.btnPaste.MouseOverFont = Nothing
		Me.btnPaste.MouseOverForeColor = System.Drawing.Color.Empty
		Me.btnPaste.MouseOverImage = Nothing
		Me.btnPaste.MouseOverText = Nothing
		Me.btnPaste.Name = "btnPaste"
		Me.btnPaste.Size = New System.Drawing.Size(75, 23)
		Me.btnPaste.TabIndex = 7
		Me.btnPaste.Text = "Paste"
		Me.btnPaste.UseVisualStyleBackColor = True
		'
		'btnCopy
		'
		Me.btnCopy.Location = New System.Drawing.Point(254, 15)
		Me.btnCopy.MouseOverBackColor = System.Drawing.Color.Empty
		Me.btnCopy.MouseOverCursor = Nothing
		Me.btnCopy.MouseOverFont = Nothing
		Me.btnCopy.MouseOverForeColor = System.Drawing.Color.Empty
		Me.btnCopy.MouseOverImage = Nothing
		Me.btnCopy.MouseOverText = Nothing
		Me.btnCopy.Name = "btnCopy"
		Me.btnCopy.Size = New System.Drawing.Size(75, 23)
		Me.btnCopy.TabIndex = 6
		Me.btnCopy.Text = "Copy"
		Me.btnCopy.UseVisualStyleBackColor = True
		'
		'btnCancel
		'
		Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
		Me.btnCancel.Location = New System.Drawing.Point(416, 15)
		Me.btnCancel.Name = "btnCancel"
		Me.btnCancel.Size = New System.Drawing.Size(75, 23)
		Me.btnCancel.TabIndex = 4
		Me.btnCancel.Text = "Cancel"
		Me.btnCancel.UseVisualStyleBackColor = True
		'
		'btnDeleteReport
		'
		Me.btnDeleteReport.Enabled = False
		Me.btnDeleteReport.Location = New System.Drawing.Point(10, 15)
		Me.btnDeleteReport.Name = "btnDeleteReport"
		Me.btnDeleteReport.Size = New System.Drawing.Size(75, 23)
		Me.btnDeleteReport.TabIndex = 5
		Me.btnDeleteReport.Text = "Delete"
		Me.btnDeleteReport.UseVisualStyleBackColor = True
		'
		'btnAddReport
		'
		Me.btnAddReport.Location = New System.Drawing.Point(91, 15)
		Me.btnAddReport.Name = "btnAddReport"
		Me.btnAddReport.Size = New System.Drawing.Size(75, 23)
		Me.btnAddReport.TabIndex = 2
		Me.btnAddReport.Text = "Add"
		Me.btnAddReport.UseVisualStyleBackColor = True
		'
		'btnEditReport
		'
		Me.btnEditReport.Location = New System.Drawing.Point(173, 15)
		Me.btnEditReport.Name = "btnEditReport"
		Me.btnEditReport.Size = New System.Drawing.Size(75, 23)
		Me.btnEditReport.TabIndex = 3
		Me.btnEditReport.Text = "Edit"
		Me.btnEditReport.UseVisualStyleBackColor = True
		'
		'ckUseTabs
		'
		Me.ckUseTabs.AutoSize = True
		Me.ckUseTabs.Location = New System.Drawing.Point(373, 19)
		Me.ckUseTabs.Name = "ckUseTabs"
		Me.ckUseTabs.Size = New System.Drawing.Size(68, 19)
		Me.ckUseTabs.TabIndex = 4
		Me.ckUseTabs.Text = "UseTabs"
		Me.ckUseTabs.UseVisualStyleBackColor = True
		'
		'ckIsStatic
		'
		Me.ckIsStatic.AutoSize = True
		Me.ckIsStatic.Location = New System.Drawing.Point(464, 19)
		Me.ckIsStatic.Name = "ckIsStatic"
		Me.ckIsStatic.Size = New System.Drawing.Size(63, 19)
		Me.ckIsStatic.TabIndex = 1
		Me.ckIsStatic.Text = "IsStatic"
		Me.ckIsStatic.UseVisualStyleBackColor = True
		'
		'dgvReports
		'
		Me.dgvReports.AllowUserToAddRows = False
		Me.dgvReports.AllowUserToDeleteRows = False
		Me.dgvReports.AllowUserToOrderColumns = True
		Me.dgvReports.AllowUserToResizeRows = False
		Me.dgvReports.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
			Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
		Me.dgvReports.BackgroundColor = System.Drawing.SystemColors.Control
		Me.dgvReports.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
		Me.dgvReports.ContextMenuStrip = Me.cmEditOptions
		Me.dgvReports.Location = New System.Drawing.Point(9, 19)
		Me.dgvReports.MultiSelect = False
		Me.dgvReports.Name = "dgvReports"
		Me.dgvReports.RowHeadersVisible = False
		Me.dgvReports.RowTemplate.Height = 18
		Me.dgvReports.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
		Me.dgvReports.ShowCellToolTips = False
		Me.dgvReports.Size = New System.Drawing.Size(327, 589)
		Me.dgvReports.TabIndex = 0
		'
		'cmEditOptions
		'
		Me.cmEditOptions.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AddToolStripMenuItem, Me.EditToolStripMenuItem, Me.CopyToolStripMenuItem})
		Me.cmEditOptions.Name = "cmEditOptions"
		Me.cmEditOptions.Size = New System.Drawing.Size(103, 70)
		'
		'AddToolStripMenuItem
		'
		Me.AddToolStripMenuItem.Name = "AddToolStripMenuItem"
		Me.AddToolStripMenuItem.Size = New System.Drawing.Size(102, 22)
		Me.AddToolStripMenuItem.Text = "Add"
		'
		'EditToolStripMenuItem
		'
		Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
		Me.EditToolStripMenuItem.Size = New System.Drawing.Size(102, 22)
		Me.EditToolStripMenuItem.Text = "Edit"
		'
		'CopyToolStripMenuItem
		'
		Me.CopyToolStripMenuItem.Name = "CopyToolStripMenuItem"
		Me.CopyToolStripMenuItem.Size = New System.Drawing.Size(102, 22)
		Me.CopyToolStripMenuItem.Text = "Copy"
		'
		'dgvReportProperties
		'
		Me.dgvReportProperties.AllowUserToAddRows = False
		Me.dgvReportProperties.AllowUserToDeleteRows = False
		Me.dgvReportProperties.AllowUserToResizeRows = False
		Me.dgvReportProperties.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
			Or System.Windows.Forms.AnchorStyles.Left) _
			Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.dgvReportProperties.BackgroundColor = System.Drawing.SystemColors.Control
		Me.dgvReportProperties.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
		Me.dgvReportProperties.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.PropertyName, Me.PropertyValue})
		Me.dgvReportProperties.Location = New System.Drawing.Point(342, 59)
		Me.dgvReportProperties.Name = "dgvReportProperties"
		Me.dgvReportProperties.RowHeadersVisible = False
		Me.dgvReportProperties.RowTemplate.Height = 18
		Me.dgvReportProperties.Size = New System.Drawing.Size(588, 497)
		Me.dgvReportProperties.TabIndex = 0
		'
		'PropertyName
		'
		Me.PropertyName.Frozen = True
		Me.PropertyName.HeaderText = "PropertyName"
		Me.PropertyName.Name = "PropertyName"
		Me.PropertyName.ReadOnly = True
		Me.PropertyName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
		Me.PropertyName.Width = 120
		'
		'PropertyValue
		'
		Me.PropertyValue.HeaderText = "PropertyValue"
		Me.PropertyValue.Name = "PropertyValue"
		Me.PropertyValue.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
		Me.PropertyValue.Width = 200
		'
		'ToolStrip1
		'
		Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblServerConnection, Me.ToolStripSeparator1, Me.ToolStripLblEditing})
		Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
		Me.ToolStrip1.Name = "ToolStrip1"
		Me.ToolStrip1.Size = New System.Drawing.Size(938, 25)
		Me.ToolStrip1.TabIndex = 4
		Me.ToolStrip1.Text = "ToolStrip1"
		'
		'lblServerConnection
		'
		Me.lblServerConnection.Name = "lblServerConnection"
		Me.lblServerConnection.Size = New System.Drawing.Size(108, 22)
		Me.lblServerConnection.Text = "Server connection :"
		'
		'ToolStripSeparator1
		'
		Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
		Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
		'
		'ToolStripLblEditing
		'
		Me.ToolStripLblEditing.ActiveLinkColor = System.Drawing.Color.Maroon
		Me.ToolStripLblEditing.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.ToolStripLblEditing.ForeColor = System.Drawing.Color.Red
		Me.ToolStripLblEditing.Name = "ToolStripLblEditing"
		Me.ToolStripLblEditing.Size = New System.Drawing.Size(128, 22)
		Me.ToolStripLblEditing.Text = "--  EDITING  --"
		Me.ToolStripLblEditing.Visible = False
		'
		'tmrEditAvailability
		'
		Me.tmrEditAvailability.Enabled = True
		Me.tmrEditAvailability.Interval = 60000
		'
		'tmrBlinkEdit
		'
		Me.tmrBlinkEdit.Interval = 400
		'
		'frmManageReports
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
		Me.ClientSize = New System.Drawing.Size(938, 661)
		Me.Controls.Add(Me.pnlPrimary)
		Me.Controls.Add(Me.ToolStrip1)
		Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
		Me.MinimumSize = New System.Drawing.Size(750, 300)
		Me.Name = "frmManageReports"
		Me.Text = "Manage Reports"
		Me.pnlPrimary.ResumeLayout(False)
		Me.pnlPrimary.PerformLayout()
		Me.StatusStrip1.ResumeLayout(False)
		Me.StatusStrip1.PerformLayout()
		Me.grpReports.ResumeLayout(False)
		Me.grpReports.PerformLayout()
		Me.pnlButtons.ResumeLayout(False)
		CType(Me.dgvReports, System.ComponentModel.ISupportInitialize).EndInit()
		Me.cmEditOptions.ResumeLayout(False)
		CType(Me.dgvReportProperties, System.ComponentModel.ISupportInitialize).EndInit()
		Me.ToolStrip1.ResumeLayout(False)
		Me.ToolStrip1.PerformLayout()
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub
    Friend WithEvents pnlPrimary As System.Windows.Forms.Panel
    Public WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents lblServerConnection As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents dgvReports As System.Windows.Forms.DataGridView
    Friend WithEvents btnAddReport As System.Windows.Forms.Button
    Friend WithEvents grpReports As System.Windows.Forms.GroupBox
    Friend WithEvents btnEditReport As System.Windows.Forms.Button
    Friend WithEvents pnlButtons As System.Windows.Forms.Panel
    Friend WithEvents btnDeleteReport As System.Windows.Forms.Button
    Friend WithEvents dgvReportProperties As System.Windows.Forms.DataGridView
    Friend WithEvents ckIsStatic As System.Windows.Forms.CheckBox
    Friend WithEvents ckUseTabs As System.Windows.Forms.CheckBox
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents tmrEditAvailability As System.Windows.Forms.Timer
    Friend WithEvents PropertyName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PropertyValue As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btnCopy As DDTToolbox.ExtButton
    Friend WithEvents btnPaste As DDTToolbox.ExtButton
    Friend WithEvents cmEditOptions As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents AddToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CopyToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripLblEditing As System.Windows.Forms.ToolStripLabel
    Friend WithEvents tmrBlinkEdit As System.Windows.Forms.Timer
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel2 As System.Windows.Forms.ToolStripStatusLabel
    'Friend WithEvents ckIsSecure As System.Windows.Forms.CheckBox
End Class
