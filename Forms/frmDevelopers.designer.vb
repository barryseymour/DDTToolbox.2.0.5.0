<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmDevelopers
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
		Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDevelopers))
		Me.pnlPrimaryContent = New System.Windows.Forms.Panel()
		Me.pnlBottom = New System.Windows.Forms.Panel()
		Me.pnlEditControlsCtrls = New System.Windows.Forms.Panel()
		Me.cmdEdit = New System.Windows.Forms.Button()
		Me.grpEdit = New System.Windows.Forms.GroupBox()
		Me.cmdSave = New System.Windows.Forms.Button()
		Me.cmdCancel = New System.Windows.Forms.Button()
		Me.lblSortOrder = New System.Windows.Forms.Label()
		Me.lblTelephone = New System.Windows.Forms.Label()
		Me.lblTitle = New System.Windows.Forms.Label()
		Me.lblFullName = New System.Windows.Forms.Label()
		Me.lblTPID = New System.Windows.Forms.Label()
		Me.txtSortOrder = New DDTToolbox.ExtTextBox()
		Me.txtTelephone = New DDTToolbox.ExtTextBox()
		Me.txtTitle = New DDTToolbox.ExtTextBox()
		Me.txtFullname = New DDTToolbox.ExtTextBox()
		Me.txtTPID = New DDTToolbox.ExtTextBox()
		Me.cmdDelete = New System.Windows.Forms.Button()
		Me.cmdAdd = New System.Windows.Forms.Button()
		Me.dgvDevelopers = New System.Windows.Forms.DataGridView()
		Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
		Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
		Me.cboServer = New System.Windows.Forms.ToolStripComboBox()
		Me.btnConnect = New System.Windows.Forms.ToolStripButton()
		Me.btnHelp = New System.Windows.Forms.ToolStripButton()
		Me.pnlPrimaryContent.SuspendLayout()
		Me.pnlBottom.SuspendLayout()
		Me.pnlEditControlsCtrls.SuspendLayout()
		Me.grpEdit.SuspendLayout()
		CType(Me.dgvDevelopers, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.ToolStrip1.SuspendLayout()
		Me.SuspendLayout()
		'
		'pnlPrimaryContent
		'
		Me.pnlPrimaryContent.BackColor = System.Drawing.SystemColors.Control
		Me.pnlPrimaryContent.Controls.Add(Me.pnlBottom)
		Me.pnlPrimaryContent.Controls.Add(Me.dgvDevelopers)
		Me.pnlPrimaryContent.Location = New System.Drawing.Point(3, 28)
		Me.pnlPrimaryContent.Name = "pnlPrimaryContent"
		Me.pnlPrimaryContent.Size = New System.Drawing.Size(587, 421)
		Me.pnlPrimaryContent.TabIndex = 0
		'
		'pnlBottom
		'
		Me.pnlBottom.Controls.Add(Me.pnlEditControlsCtrls)
		Me.pnlBottom.Location = New System.Drawing.Point(0, 127)
		Me.pnlBottom.Name = "pnlBottom"
		Me.pnlBottom.Size = New System.Drawing.Size(547, 279)
		Me.pnlBottom.TabIndex = 4
		'
		'pnlEditControlsCtrls
		'
		Me.pnlEditControlsCtrls.Controls.Add(Me.cmdEdit)
		Me.pnlEditControlsCtrls.Controls.Add(Me.grpEdit)
		Me.pnlEditControlsCtrls.Controls.Add(Me.cmdDelete)
		Me.pnlEditControlsCtrls.Controls.Add(Me.cmdAdd)
		Me.pnlEditControlsCtrls.Location = New System.Drawing.Point(9, 7)
		Me.pnlEditControlsCtrls.Name = "pnlEditControlsCtrls"
		Me.pnlEditControlsCtrls.Size = New System.Drawing.Size(511, 256)
		Me.pnlEditControlsCtrls.TabIndex = 21
		'
		'cmdEdit
		'
		Me.cmdEdit.Location = New System.Drawing.Point(231, 179)
		Me.cmdEdit.Name = "cmdEdit"
		Me.cmdEdit.Size = New System.Drawing.Size(75, 23)
		Me.cmdEdit.TabIndex = 24
		Me.cmdEdit.Text = "Edit"
		Me.cmdEdit.UseVisualStyleBackColor = True
		'
		'grpEdit
		'
		Me.grpEdit.Controls.Add(Me.cmdSave)
		Me.grpEdit.Controls.Add(Me.cmdCancel)
		Me.grpEdit.Controls.Add(Me.lblSortOrder)
		Me.grpEdit.Controls.Add(Me.lblTelephone)
		Me.grpEdit.Controls.Add(Me.lblTitle)
		Me.grpEdit.Controls.Add(Me.lblFullName)
		Me.grpEdit.Controls.Add(Me.lblTPID)
		Me.grpEdit.Controls.Add(Me.txtSortOrder)
		Me.grpEdit.Controls.Add(Me.txtTelephone)
		Me.grpEdit.Controls.Add(Me.txtTitle)
		Me.grpEdit.Controls.Add(Me.txtFullname)
		Me.grpEdit.Controls.Add(Me.txtTPID)
		Me.grpEdit.Location = New System.Drawing.Point(18, 3)
		Me.grpEdit.Name = "grpEdit"
		Me.grpEdit.Size = New System.Drawing.Size(474, 170)
		Me.grpEdit.TabIndex = 23
		Me.grpEdit.TabStop = False
		'
		'cmdSave
		'
		Me.cmdSave.Location = New System.Drawing.Point(366, 47)
		Me.cmdSave.Name = "cmdSave"
		Me.cmdSave.Size = New System.Drawing.Size(75, 23)
		Me.cmdSave.TabIndex = 32
		Me.cmdSave.Text = "Save"
		Me.cmdSave.UseVisualStyleBackColor = True
		'
		'cmdCancel
		'
		Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
		Me.cmdCancel.Location = New System.Drawing.Point(367, 92)
		Me.cmdCancel.Name = "cmdCancel"
		Me.cmdCancel.Size = New System.Drawing.Size(75, 23)
		Me.cmdCancel.TabIndex = 31
		Me.cmdCancel.Text = "Cancel"
		Me.cmdCancel.UseVisualStyleBackColor = True
		'
		'lblSortOrder
		'
		Me.lblSortOrder.AutoSize = True
		Me.lblSortOrder.Location = New System.Drawing.Point(24, 130)
		Me.lblSortOrder.Name = "lblSortOrder"
		Me.lblSortOrder.Size = New System.Drawing.Size(58, 15)
		Me.lblSortOrder.TabIndex = 26
		Me.lblSortOrder.Text = "SortOrder"
		'
		'lblTelephone
		'
		Me.lblTelephone.AutoSize = True
		Me.lblTelephone.Location = New System.Drawing.Point(24, 104)
		Me.lblTelephone.Name = "lblTelephone"
		Me.lblTelephone.Size = New System.Drawing.Size(61, 15)
		Me.lblTelephone.TabIndex = 25
		Me.lblTelephone.Text = "Telephone"
		'
		'lblTitle
		'
		Me.lblTitle.AutoSize = True
		Me.lblTitle.Location = New System.Drawing.Point(24, 78)
		Me.lblTitle.Name = "lblTitle"
		Me.lblTitle.Size = New System.Drawing.Size(29, 15)
		Me.lblTitle.TabIndex = 24
		Me.lblTitle.Text = "Title"
		'
		'lblFullName
		'
		Me.lblFullName.AutoSize = True
		Me.lblFullName.Location = New System.Drawing.Point(24, 52)
		Me.lblFullName.Name = "lblFullName"
		Me.lblFullName.Size = New System.Drawing.Size(58, 15)
		Me.lblFullName.TabIndex = 23
		Me.lblFullName.Text = "FullName"
		'
		'lblTPID
		'
		Me.lblTPID.AutoSize = True
		Me.lblTPID.Location = New System.Drawing.Point(24, 26)
		Me.lblTPID.Name = "lblTPID"
		Me.lblTPID.Size = New System.Drawing.Size(31, 15)
		Me.lblTPID.TabIndex = 22
		Me.lblTPID.Text = "TPID"
		'
		'txtSortOrder
		'
		Me.txtSortOrder.Location = New System.Drawing.Point(92, 123)
		Me.txtSortOrder.Name = "txtSortOrder"
		Me.txtSortOrder.Size = New System.Drawing.Size(251, 23)
		Me.txtSortOrder.TabIndex = 20
		'
		'txtTelephone
		'
		Me.txtTelephone.Location = New System.Drawing.Point(92, 97)
		Me.txtTelephone.Name = "txtTelephone"
		Me.txtTelephone.Size = New System.Drawing.Size(251, 23)
		Me.txtTelephone.TabIndex = 19
		'
		'txtTitle
		'
		Me.txtTitle.Location = New System.Drawing.Point(92, 71)
		Me.txtTitle.Name = "txtTitle"
		Me.txtTitle.Size = New System.Drawing.Size(251, 23)
		Me.txtTitle.TabIndex = 18
		'
		'txtFullname
		'
		Me.txtFullname.Location = New System.Drawing.Point(92, 45)
		Me.txtFullname.Name = "txtFullname"
		Me.txtFullname.Size = New System.Drawing.Size(251, 23)
		Me.txtFullname.TabIndex = 17
		'
		'txtTPID
		'
		Me.txtTPID.Location = New System.Drawing.Point(92, 19)
		Me.txtTPID.Name = "txtTPID"
		Me.txtTPID.Size = New System.Drawing.Size(251, 23)
		Me.txtTPID.TabIndex = 16
		'
		'cmdDelete
		'
		Me.cmdDelete.Location = New System.Drawing.Point(367, 179)
		Me.cmdDelete.Name = "cmdDelete"
		Me.cmdDelete.Size = New System.Drawing.Size(75, 23)
		Me.cmdDelete.TabIndex = 22
		Me.cmdDelete.Text = "Delete"
		Me.cmdDelete.UseVisualStyleBackColor = True
		'
		'cmdAdd
		'
		Me.cmdAdd.Location = New System.Drawing.Point(93, 179)
		Me.cmdAdd.Name = "cmdAdd"
		Me.cmdAdd.Size = New System.Drawing.Size(75, 23)
		Me.cmdAdd.TabIndex = 21
		Me.cmdAdd.Text = "Add"
		Me.cmdAdd.UseVisualStyleBackColor = True
		'
		'dgvDevelopers
		'
		Me.dgvDevelopers.AllowUserToAddRows = False
		Me.dgvDevelopers.AllowUserToDeleteRows = False
		Me.dgvDevelopers.AllowUserToResizeRows = False
		Me.dgvDevelopers.BackgroundColor = System.Drawing.SystemColors.Control
		Me.dgvDevelopers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
		Me.dgvDevelopers.Dock = System.Windows.Forms.DockStyle.Top
		Me.dgvDevelopers.Location = New System.Drawing.Point(0, 0)
		Me.dgvDevelopers.MultiSelect = False
		Me.dgvDevelopers.Name = "dgvDevelopers"
		Me.dgvDevelopers.ReadOnly = True
		Me.dgvDevelopers.RowHeadersVisible = False
		DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.dgvDevelopers.RowsDefaultCellStyle = DataGridViewCellStyle1
		Me.dgvDevelopers.RowTemplate.Height = 18
		Me.dgvDevelopers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
		Me.dgvDevelopers.ShowCellToolTips = False
		Me.dgvDevelopers.Size = New System.Drawing.Size(587, 98)
		Me.dgvDevelopers.TabIndex = 0
		'
		'ToolStrip1
		'
		Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel1, Me.cboServer, Me.btnConnect, Me.btnHelp})
		Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
		Me.ToolStrip1.Name = "ToolStrip1"
		Me.ToolStrip1.Size = New System.Drawing.Size(619, 25)
		Me.ToolStrip1.TabIndex = 2
		Me.ToolStrip1.Text = "ToolStrip1"
		'
		'ToolStripLabel1
		'
		Me.ToolStripLabel1.Name = "ToolStripLabel1"
		Me.ToolStripLabel1.Size = New System.Drawing.Size(108, 22)
		Me.ToolStripLabel1.Text = "Server connection :"
		'
		'cboServer
		'
		Me.cboServer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cboServer.Name = "cboServer"
		Me.cboServer.Size = New System.Drawing.Size(125, 25)
		'
		'btnConnect
		'
		Me.btnConnect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
		Me.btnConnect.Image = CType(resources.GetObject("btnConnect.Image"), System.Drawing.Image)
		Me.btnConnect.ImageTransparentColor = System.Drawing.Color.Magenta
		Me.btnConnect.Name = "btnConnect"
		Me.btnConnect.Size = New System.Drawing.Size(56, 22)
		Me.btnConnect.Text = "Connect"
		Me.btnConnect.ToolTipText = "Connect to a SQL Server database server"
		'
		'btnHelp
		'
		Me.btnHelp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
		Me.btnHelp.Image = CType(resources.GetObject("btnHelp.Image"), System.Drawing.Image)
		Me.btnHelp.ImageTransparentColor = System.Drawing.Color.Magenta
		Me.btnHelp.Name = "btnHelp"
		Me.btnHelp.Size = New System.Drawing.Size(36, 22)
		Me.btnHelp.Text = "Help"
		Me.btnHelp.Visible = False
		'
		'frmDevelopers
		'
		Me.AcceptButton = Me.cmdSave
		Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
		Me.CancelButton = Me.cmdCancel
		Me.ClientSize = New System.Drawing.Size(619, 461)
		Me.Controls.Add(Me.ToolStrip1)
		Me.Controls.Add(Me.pnlPrimaryContent)
		Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
		Me.KeyPreview = True
		Me.MinimumSize = New System.Drawing.Size(500, 400)
		Me.Name = "frmDevelopers"
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.Text = "Developers"
		Me.pnlPrimaryContent.ResumeLayout(False)
		Me.pnlBottom.ResumeLayout(False)
		Me.pnlEditControlsCtrls.ResumeLayout(False)
		Me.grpEdit.ResumeLayout(False)
		Me.grpEdit.PerformLayout()
		CType(Me.dgvDevelopers, System.ComponentModel.ISupportInitialize).EndInit()
		Me.ToolStrip1.ResumeLayout(False)
		Me.ToolStrip1.PerformLayout()
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub
    Friend WithEvents dgvDevelopers As System.Windows.Forms.DataGridView
    'Friend WithEvents DDTDataSet As DDTToolbox.DDTDataSet
    'Friend WithEvents SGetDeveloperInfoTableAdapter As DDTToolbox.DDTDataSetTableAdapters.sGetDeveloperInfoTableAdapter
    Public WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Public WithEvents btnConnect As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnHelp As System.Windows.Forms.ToolStripButton
    Friend WithEvents pnlBottom As System.Windows.Forms.Panel
    Friend WithEvents pnlEditControlsCtrls As System.Windows.Forms.Panel
    Friend WithEvents cmdEdit As System.Windows.Forms.Button
    Friend WithEvents grpEdit As System.Windows.Forms.GroupBox
    Friend WithEvents cmdSave As System.Windows.Forms.Button
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents lblSortOrder As System.Windows.Forms.Label
    Friend WithEvents lblTelephone As System.Windows.Forms.Label
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents lblFullName As System.Windows.Forms.Label
    Friend WithEvents lblTPID As System.Windows.Forms.Label
    Friend WithEvents txtSortOrder As DDTToolbox.ExtTextBox
    Friend WithEvents txtTelephone As DDTToolbox.ExtTextBox
    Friend WithEvents txtTitle As DDTToolbox.ExtTextBox
    Friend WithEvents txtFullname As DDTToolbox.ExtTextBox
    Friend WithEvents txtTPID As DDTToolbox.ExtTextBox
    Friend WithEvents cmdDelete As System.Windows.Forms.Button
    Friend WithEvents cmdAdd As System.Windows.Forms.Button
    Friend WithEvents ID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TPID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FullName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Title As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Telephone As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DPDeveloper As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents WMDeveloper As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SortOrder As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TestAcctID As System.Windows.Forms.DataGridViewTextBoxColumn
    Public WithEvents cboServer As System.Windows.Forms.ToolStripComboBox
    Public WithEvents pnlPrimaryContent As System.Windows.Forms.Panel
End Class
