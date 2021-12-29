<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLoginTracking
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
		Me.components = New System.ComponentModel.Container()
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmLoginTracking))
		Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
		Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
		Me.cboServer = New System.Windows.Forms.ToolStripComboBox()
		Me.btnConnect = New System.Windows.Forms.ToolStripButton()
		Me.pnlPrimaryContent = New System.Windows.Forms.Panel()
		Me.lblRecordCount = New System.Windows.Forms.Label()
		Me.pnlControls = New System.Windows.Forms.Panel()
		Me.grpView = New System.Windows.Forms.GroupBox()
		Me.lblEditingMode = New System.Windows.Forms.Label()
		Me.btnEditRecord = New System.Windows.Forms.Button()
		Me.txtDescription = New System.Windows.Forms.TextBox()
		Me.btnDeleteRecord = New System.Windows.Forms.Button()
		Me.txtPassword = New System.Windows.Forms.TextBox()
		Me.btnAddRecord = New System.Windows.Forms.Button()
		Me.txtLogin = New System.Windows.Forms.TextBox()
		Me.txtProcess = New System.Windows.Forms.TextBox()
		Me.lblLogin = New System.Windows.Forms.Label()
		Me.lblPassword = New System.Windows.Forms.Label()
		Me.lblDescription = New System.Windows.Forms.Label()
		Me.lblProcess = New System.Windows.Forms.Label()
		Me.btnSaveRecord = New System.Windows.Forms.Button()
		Me.btnCancel = New System.Windows.Forms.Button()
		Me.dgvLoginTracking = New System.Windows.Forms.DataGridView()
		Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
		Me.ToolStrip1.SuspendLayout()
		Me.pnlPrimaryContent.SuspendLayout()
		Me.pnlControls.SuspendLayout()
		Me.grpView.SuspendLayout()
		CType(Me.dgvLoginTracking, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.SuspendLayout()
		'
		'ToolStrip1
		'
		Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel1, Me.cboServer, Me.btnConnect})
		Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
		Me.ToolStrip1.Name = "ToolStrip1"
		Me.ToolStrip1.Size = New System.Drawing.Size(834, 25)
		Me.ToolStrip1.TabIndex = 0
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
		Me.cboServer.Size = New System.Drawing.Size(121, 25)
		'
		'btnConnect
		'
		Me.btnConnect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
		Me.btnConnect.Image = CType(resources.GetObject("btnConnect.Image"), System.Drawing.Image)
		Me.btnConnect.ImageTransparentColor = System.Drawing.Color.Magenta
		Me.btnConnect.Name = "btnConnect"
		Me.btnConnect.Size = New System.Drawing.Size(56, 22)
		Me.btnConnect.Text = "Connect"
		'
		'pnlPrimaryContent
		'
		Me.pnlPrimaryContent.AutoSize = True
		Me.pnlPrimaryContent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.pnlPrimaryContent.Controls.Add(Me.lblRecordCount)
		Me.pnlPrimaryContent.Controls.Add(Me.pnlControls)
		Me.pnlPrimaryContent.Controls.Add(Me.dgvLoginTracking)
		Me.pnlPrimaryContent.Dock = System.Windows.Forms.DockStyle.Fill
		Me.pnlPrimaryContent.Location = New System.Drawing.Point(0, 25)
		Me.pnlPrimaryContent.Name = "pnlPrimaryContent"
		Me.pnlPrimaryContent.Size = New System.Drawing.Size(834, 541)
		Me.pnlPrimaryContent.TabIndex = 1
		'
		'lblRecordCount
		'
		Me.lblRecordCount.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
		Me.lblRecordCount.AutoSize = True
		Me.lblRecordCount.Location = New System.Drawing.Point(12, 522)
		Me.lblRecordCount.Name = "lblRecordCount"
		Me.lblRecordCount.Size = New System.Drawing.Size(83, 15)
		Me.lblRecordCount.TabIndex = 7
		Me.lblRecordCount.Text = "Record Count:"
		'
		'pnlControls
		'
		Me.pnlControls.Controls.Add(Me.grpView)
		Me.pnlControls.Dock = System.Windows.Forms.DockStyle.Right
		Me.pnlControls.Location = New System.Drawing.Point(525, 0)
		Me.pnlControls.Name = "pnlControls"
		Me.pnlControls.Size = New System.Drawing.Size(307, 539)
		Me.pnlControls.TabIndex = 6
		'
		'grpView
		'
		Me.grpView.Controls.Add(Me.lblEditingMode)
		Me.grpView.Controls.Add(Me.btnEditRecord)
		Me.grpView.Controls.Add(Me.txtDescription)
		Me.grpView.Controls.Add(Me.btnDeleteRecord)
		Me.grpView.Controls.Add(Me.txtPassword)
		Me.grpView.Controls.Add(Me.btnAddRecord)
		Me.grpView.Controls.Add(Me.txtLogin)
		Me.grpView.Controls.Add(Me.txtProcess)
		Me.grpView.Controls.Add(Me.lblLogin)
		Me.grpView.Controls.Add(Me.lblPassword)
		Me.grpView.Controls.Add(Me.lblDescription)
		Me.grpView.Controls.Add(Me.lblProcess)
		Me.grpView.Controls.Add(Me.btnSaveRecord)
		Me.grpView.Controls.Add(Me.btnCancel)
		Me.grpView.Location = New System.Drawing.Point(13, 3)
		Me.grpView.Name = "grpView"
		Me.grpView.Size = New System.Drawing.Size(282, 360)
		Me.grpView.TabIndex = 5
		Me.grpView.TabStop = False
		'
		'lblEditingMode
		'
		Me.lblEditingMode.ForeColor = System.Drawing.Color.Crimson
		Me.lblEditingMode.Location = New System.Drawing.Point(92, 254)
		Me.lblEditingMode.Name = "lblEditingMode"
		Me.lblEditingMode.Size = New System.Drawing.Size(158, 13)
		Me.lblEditingMode.TabIndex = 17
		'
		'btnEditRecord
		'
		Me.btnEditRecord.Location = New System.Drawing.Point(102, 332)
		Me.btnEditRecord.Name = "btnEditRecord"
		Me.btnEditRecord.Size = New System.Drawing.Size(75, 23)
		Me.btnEditRecord.TabIndex = 6
		Me.btnEditRecord.Text = "Edit"
		Me.btnEditRecord.UseVisualStyleBackColor = True
		'
		'txtDescription
		'
		Me.txtDescription.Location = New System.Drawing.Point(91, 138)
		Me.txtDescription.MaxLength = 1000
		Me.txtDescription.Multiline = True
		Me.txtDescription.Name = "txtDescription"
		Me.txtDescription.Size = New System.Drawing.Size(164, 112)
		Me.txtDescription.TabIndex = 12
		'
		'btnDeleteRecord
		'
		Me.btnDeleteRecord.Location = New System.Drawing.Point(180, 332)
		Me.btnDeleteRecord.Name = "btnDeleteRecord"
		Me.btnDeleteRecord.Size = New System.Drawing.Size(75, 23)
		Me.btnDeleteRecord.TabIndex = 2
		Me.btnDeleteRecord.Text = "Delete"
		Me.btnDeleteRecord.UseVisualStyleBackColor = True
		'
		'txtPassword
		'
		Me.txtPassword.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtPassword.Location = New System.Drawing.Point(91, 96)
		Me.txtPassword.MaxLength = 50
		Me.txtPassword.Name = "txtPassword"
		Me.txtPassword.Size = New System.Drawing.Size(164, 23)
		Me.txtPassword.TabIndex = 11
		'
		'btnAddRecord
		'
		Me.btnAddRecord.Location = New System.Drawing.Point(23, 332)
		Me.btnAddRecord.Name = "btnAddRecord"
		Me.btnAddRecord.Size = New System.Drawing.Size(75, 23)
		Me.btnAddRecord.TabIndex = 1
		Me.btnAddRecord.Text = "Add"
		Me.btnAddRecord.UseVisualStyleBackColor = True
		'
		'txtLogin
		'
		Me.txtLogin.Location = New System.Drawing.Point(91, 54)
		Me.txtLogin.MaxLength = 50
		Me.txtLogin.Name = "txtLogin"
		Me.txtLogin.Size = New System.Drawing.Size(164, 23)
		Me.txtLogin.TabIndex = 10
		'
		'txtProcess
		'
		Me.txtProcess.Location = New System.Drawing.Point(91, 12)
		Me.txtProcess.MaxLength = 50
		Me.txtProcess.Name = "txtProcess"
		Me.txtProcess.Size = New System.Drawing.Size(164, 23)
		Me.txtProcess.TabIndex = 9
		'
		'lblLogin
		'
		Me.lblLogin.AutoSize = True
		Me.lblLogin.Location = New System.Drawing.Point(20, 56)
		Me.lblLogin.Name = "lblLogin"
		Me.lblLogin.Size = New System.Drawing.Size(37, 15)
		Me.lblLogin.TabIndex = 8
		Me.lblLogin.Text = "Login"
		'
		'lblPassword
		'
		Me.lblPassword.AutoSize = True
		Me.lblPassword.Location = New System.Drawing.Point(20, 98)
		Me.lblPassword.Name = "lblPassword"
		Me.lblPassword.Size = New System.Drawing.Size(57, 15)
		Me.lblPassword.TabIndex = 7
		Me.lblPassword.Text = "Password"
		'
		'lblDescription
		'
		Me.lblDescription.AutoSize = True
		Me.lblDescription.Location = New System.Drawing.Point(20, 140)
		Me.lblDescription.Name = "lblDescription"
		Me.lblDescription.Size = New System.Drawing.Size(67, 15)
		Me.lblDescription.TabIndex = 6
		Me.lblDescription.Text = "Description"
		'
		'lblProcess
		'
		Me.lblProcess.AutoSize = True
		Me.lblProcess.Location = New System.Drawing.Point(20, 14)
		Me.lblProcess.Name = "lblProcess"
		Me.lblProcess.Size = New System.Drawing.Size(47, 15)
		Me.lblProcess.TabIndex = 5
		Me.lblProcess.Text = "Process"
		'
		'btnSaveRecord
		'
		Me.btnSaveRecord.Location = New System.Drawing.Point(23, 304)
		Me.btnSaveRecord.Name = "btnSaveRecord"
		Me.btnSaveRecord.Size = New System.Drawing.Size(75, 23)
		Me.btnSaveRecord.TabIndex = 4
		Me.btnSaveRecord.Text = "Save"
		Me.btnSaveRecord.UseVisualStyleBackColor = True
		'
		'btnCancel
		'
		Me.btnCancel.Location = New System.Drawing.Point(180, 304)
		Me.btnCancel.Name = "btnCancel"
		Me.btnCancel.Size = New System.Drawing.Size(75, 23)
		Me.btnCancel.TabIndex = 3
		Me.btnCancel.Text = "Cancel"
		Me.btnCancel.UseVisualStyleBackColor = True
		'
		'dgvLoginTracking
		'
		Me.dgvLoginTracking.AllowUserToAddRows = False
		Me.dgvLoginTracking.AllowUserToDeleteRows = False
		Me.dgvLoginTracking.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
		Me.dgvLoginTracking.BackgroundColor = System.Drawing.SystemColors.Control
		Me.dgvLoginTracking.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.dgvLoginTracking.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
		Me.dgvLoginTracking.Location = New System.Drawing.Point(3, 3)
		Me.dgvLoginTracking.MultiSelect = False
		Me.dgvLoginTracking.Name = "dgvLoginTracking"
		Me.dgvLoginTracking.ReadOnly = True
		Me.dgvLoginTracking.RowHeadersWidth = 31
		Me.dgvLoginTracking.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
		Me.dgvLoginTracking.Size = New System.Drawing.Size(516, 298)
		Me.dgvLoginTracking.TabIndex = 5
		'
		'Timer1
		'
		Me.Timer1.Interval = 550
		'
		'frmLoginTracking
		'
		Me.AcceptButton = Me.btnSaveRecord
		Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
		Me.ClientSize = New System.Drawing.Size(834, 566)
		Me.Controls.Add(Me.pnlPrimaryContent)
		Me.Controls.Add(Me.ToolStrip1)
		Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
		Me.MinimizeBox = False
		Me.MinimumSize = New System.Drawing.Size(800, 450)
		Me.Name = "frmLoginTracking"
		Me.ShowInTaskbar = False
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.Text = "Login Tracking"
		Me.ToolStrip1.ResumeLayout(False)
		Me.ToolStrip1.PerformLayout()
		Me.pnlPrimaryContent.ResumeLayout(False)
		Me.pnlPrimaryContent.PerformLayout()
		Me.pnlControls.ResumeLayout(False)
		Me.grpView.ResumeLayout(False)
		Me.grpView.PerformLayout()
		CType(Me.dgvLoginTracking, System.ComponentModel.ISupportInitialize).EndInit()
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Public WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Public WithEvents btnConnect As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnSaveRecord As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnDeleteRecord As System.Windows.Forms.Button
    Friend WithEvents btnAddRecord As System.Windows.Forms.Button
    'Friend WithEvents DDTDataSet As DDTToolbox.DDTDataSet
    Friend WithEvents dgvLoginTracking As System.Windows.Forms.DataGridView
    Friend WithEvents grpView As System.Windows.Forms.GroupBox
    Friend WithEvents btnEditRecord As System.Windows.Forms.Button
    Friend WithEvents lblProcess As System.Windows.Forms.Label
    Friend WithEvents txtDescription As System.Windows.Forms.TextBox
    Friend WithEvents txtPassword As System.Windows.Forms.TextBox
    Friend WithEvents txtLogin As System.Windows.Forms.TextBox
    Friend WithEvents txtProcess As System.Windows.Forms.TextBox
    Friend WithEvents lblLogin As System.Windows.Forms.Label
    Friend WithEvents lblPassword As System.Windows.Forms.Label
    Friend WithEvents lblDescription As System.Windows.Forms.Label
    'Friend WithEvents SLoginTracking_GetTableAdapter As DDTToolbox.DDTDataSetTableAdapters.sLoginTracking_GetTableAdapter
    Friend WithEvents lblRecordCount As System.Windows.Forms.Label
    Friend WithEvents lblEditingMode As System.Windows.Forms.Label
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents colID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colProcess As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colLogin As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPassword As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDescription As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents pnlControls As System.Windows.Forms.Panel
    Public WithEvents cboServer As System.Windows.Forms.ToolStripComboBox
    Public WithEvents pnlPrimaryContent As System.Windows.Forms.Panel
End Class
