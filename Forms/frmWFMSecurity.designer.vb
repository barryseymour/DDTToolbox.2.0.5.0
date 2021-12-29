<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmWFMSecurity
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
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmWFMSecurity))
		Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
		Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
		Me.cboServer = New System.Windows.Forms.ToolStripComboBox()
		Me.btnConnect = New System.Windows.Forms.ToolStripButton()
		Me.loc = New System.Windows.Forms.Panel()
		Me.pnlPrimaryContent = New System.Windows.Forms.Panel()
		Me.lblEditMode = New System.Windows.Forms.Label()
		Me.btnDelete = New System.Windows.Forms.Button()
		Me.btnCancel = New System.Windows.Forms.Button()
		Me.btnSave = New System.Windows.Forms.Button()
		Me.btnClose = New System.Windows.Forms.Button()
		Me.lblUser = New System.Windows.Forms.Label()
		Me.grpSecurityDetail = New System.Windows.Forms.GroupBox()
		Me.grpPersonalInfo = New System.Windows.Forms.GroupBox()
		Me.rbPersInfoNo = New System.Windows.Forms.RadioButton()
		Me.rbPersInfoYes = New System.Windows.Forms.RadioButton()
		Me.grpStatusEdit = New System.Windows.Forms.GroupBox()
		Me.rbStatusNo = New System.Windows.Forms.RadioButton()
		Me.rbStatusYes = New System.Windows.Forms.RadioButton()
		Me.ToolStrip1.SuspendLayout()
		Me.loc.SuspendLayout()
		Me.pnlPrimaryContent.SuspendLayout()
		Me.grpSecurityDetail.SuspendLayout()
		Me.grpPersonalInfo.SuspendLayout()
		Me.grpStatusEdit.SuspendLayout()
		Me.SuspendLayout()
		'
		'ToolStrip1
		'
		Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel1, Me.cboServer, Me.btnConnect})
		Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
		Me.ToolStrip1.Name = "ToolStrip1"
		Me.ToolStrip1.Size = New System.Drawing.Size(566, 25)
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
		'loc
		'
		Me.loc.AutoSize = True
		Me.loc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.loc.Controls.Add(Me.pnlPrimaryContent)
		Me.loc.Dock = System.Windows.Forms.DockStyle.Fill
		Me.loc.Location = New System.Drawing.Point(0, 25)
		Me.loc.Name = "loc"
		Me.loc.Size = New System.Drawing.Size(566, 184)
		Me.loc.TabIndex = 1
		'
		'pnlPrimaryContent
		'
		Me.pnlPrimaryContent.BackColor = System.Drawing.SystemColors.Control
		Me.pnlPrimaryContent.Controls.Add(Me.lblEditMode)
		Me.pnlPrimaryContent.Controls.Add(Me.btnDelete)
		Me.pnlPrimaryContent.Controls.Add(Me.btnCancel)
		Me.pnlPrimaryContent.Controls.Add(Me.btnSave)
		Me.pnlPrimaryContent.Controls.Add(Me.btnClose)
		Me.pnlPrimaryContent.Controls.Add(Me.lblUser)
		Me.pnlPrimaryContent.Controls.Add(Me.grpSecurityDetail)
		Me.pnlPrimaryContent.Location = New System.Drawing.Point(-1, 3)
		Me.pnlPrimaryContent.Name = "pnlPrimaryContent"
		Me.pnlPrimaryContent.Size = New System.Drawing.Size(555, 172)
		Me.pnlPrimaryContent.TabIndex = 6
		'
		'lblEditMode
		'
		Me.lblEditMode.AutoSize = True
		Me.lblEditMode.ForeColor = System.Drawing.Color.Blue
		Me.lblEditMode.Location = New System.Drawing.Point(477, 68)
		Me.lblEditMode.Name = "lblEditMode"
		Me.lblEditMode.Size = New System.Drawing.Size(0, 15)
		Me.lblEditMode.TabIndex = 13
		'
		'btnDelete
		'
		Me.btnDelete.Location = New System.Drawing.Point(479, 141)
		Me.btnDelete.Name = "btnDelete"
		Me.btnDelete.Size = New System.Drawing.Size(52, 20)
		Me.btnDelete.TabIndex = 5
		Me.btnDelete.Text = "Delete"
		Me.btnDelete.UseVisualStyleBackColor = True
		'
		'btnCancel
		'
		Me.btnCancel.Location = New System.Drawing.Point(479, 113)
		Me.btnCancel.Name = "btnCancel"
		Me.btnCancel.Size = New System.Drawing.Size(52, 20)
		Me.btnCancel.TabIndex = 4
		Me.btnCancel.Text = "Cancel"
		Me.btnCancel.UseVisualStyleBackColor = True
		'
		'btnSave
		'
		Me.btnSave.Location = New System.Drawing.Point(479, 85)
		Me.btnSave.Name = "btnSave"
		Me.btnSave.Size = New System.Drawing.Size(52, 20)
		Me.btnSave.TabIndex = 3
		Me.btnSave.Text = "Save"
		Me.btnSave.UseVisualStyleBackColor = True
		'
		'btnClose
		'
		Me.btnClose.Location = New System.Drawing.Point(479, 29)
		Me.btnClose.Name = "btnClose"
		Me.btnClose.Size = New System.Drawing.Size(52, 20)
		Me.btnClose.TabIndex = 2
		Me.btnClose.Text = "Close"
		Me.btnClose.UseVisualStyleBackColor = True
		'
		'lblUser
		'
		Me.lblUser.AutoSize = True
		Me.lblUser.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblUser.Location = New System.Drawing.Point(9, 9)
		Me.lblUser.Name = "lblUser"
		Me.lblUser.Size = New System.Drawing.Size(87, 13)
		Me.lblUser.TabIndex = 1
		Me.lblUser.Text = "User Security:"
		'
		'grpSecurityDetail
		'
		Me.grpSecurityDetail.Controls.Add(Me.grpPersonalInfo)
		Me.grpSecurityDetail.Controls.Add(Me.grpStatusEdit)
		Me.grpSecurityDetail.Location = New System.Drawing.Point(4, 40)
		Me.grpSecurityDetail.Name = "grpSecurityDetail"
		Me.grpSecurityDetail.Size = New System.Drawing.Size(467, 111)
		Me.grpSecurityDetail.TabIndex = 0
		Me.grpSecurityDetail.TabStop = False
		Me.grpSecurityDetail.Text = "Security Profiles"
		'
		'grpPersonalInfo
		'
		Me.grpPersonalInfo.Controls.Add(Me.rbPersInfoNo)
		Me.grpPersonalInfo.Controls.Add(Me.rbPersInfoYes)
		Me.grpPersonalInfo.Location = New System.Drawing.Point(214, 21)
		Me.grpPersonalInfo.Name = "grpPersonalInfo"
		Me.grpPersonalInfo.Size = New System.Drawing.Size(235, 78)
		Me.grpPersonalInfo.TabIndex = 5
		Me.grpPersonalInfo.TabStop = False
		Me.grpPersonalInfo.Text = "Can User View Employee Personal Info?"
		'
		'rbPersInfoNo
		'
		Me.rbPersInfoNo.AutoSize = True
		Me.rbPersInfoNo.Checked = True
		Me.rbPersInfoNo.Location = New System.Drawing.Point(13, 42)
		Me.rbPersInfoNo.Name = "rbPersInfoNo"
		Me.rbPersInfoNo.Size = New System.Drawing.Size(41, 19)
		Me.rbPersInfoNo.TabIndex = 1
		Me.rbPersInfoNo.TabStop = True
		Me.rbPersInfoNo.Text = "No"
		Me.rbPersInfoNo.UseVisualStyleBackColor = True
		'
		'rbPersInfoYes
		'
		Me.rbPersInfoYes.AutoSize = True
		Me.rbPersInfoYes.Location = New System.Drawing.Point(13, 19)
		Me.rbPersInfoYes.Name = "rbPersInfoYes"
		Me.rbPersInfoYes.Size = New System.Drawing.Size(42, 19)
		Me.rbPersInfoYes.TabIndex = 0
		Me.rbPersInfoYes.Text = "Yes"
		Me.rbPersInfoYes.UseVisualStyleBackColor = True
		'
		'grpStatusEdit
		'
		Me.grpStatusEdit.Controls.Add(Me.rbStatusNo)
		Me.grpStatusEdit.Controls.Add(Me.rbStatusYes)
		Me.grpStatusEdit.Location = New System.Drawing.Point(6, 21)
		Me.grpStatusEdit.Name = "grpStatusEdit"
		Me.grpStatusEdit.Size = New System.Drawing.Size(193, 78)
		Me.grpStatusEdit.TabIndex = 4
		Me.grpStatusEdit.TabStop = False
		Me.grpStatusEdit.Text = "Can User Edit Employee Status?"
		'
		'rbStatusNo
		'
		Me.rbStatusNo.AutoSize = True
		Me.rbStatusNo.Checked = True
		Me.rbStatusNo.Location = New System.Drawing.Point(13, 42)
		Me.rbStatusNo.Name = "rbStatusNo"
		Me.rbStatusNo.Size = New System.Drawing.Size(41, 19)
		Me.rbStatusNo.TabIndex = 1
		Me.rbStatusNo.TabStop = True
		Me.rbStatusNo.Text = "No"
		Me.rbStatusNo.UseVisualStyleBackColor = True
		'
		'rbStatusYes
		'
		Me.rbStatusYes.AutoSize = True
		Me.rbStatusYes.Location = New System.Drawing.Point(13, 19)
		Me.rbStatusYes.Name = "rbStatusYes"
		Me.rbStatusYes.Size = New System.Drawing.Size(42, 19)
		Me.rbStatusYes.TabIndex = 0
		Me.rbStatusYes.Text = "Yes"
		Me.rbStatusYes.UseVisualStyleBackColor = True
		'
		'frmWFMSecurity
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
		Me.ClientSize = New System.Drawing.Size(566, 209)
		Me.Controls.Add(Me.loc)
		Me.Controls.Add(Me.ToolStrip1)
		Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
		Me.Name = "frmWFMSecurity"
		Me.ShowInTaskbar = False
		Me.Text = "Workforce Manager User Security"
		Me.ToolStrip1.ResumeLayout(False)
		Me.ToolStrip1.PerformLayout()
		Me.loc.ResumeLayout(False)
		Me.pnlPrimaryContent.ResumeLayout(False)
		Me.pnlPrimaryContent.PerformLayout()
		Me.grpSecurityDetail.ResumeLayout(False)
		Me.grpPersonalInfo.ResumeLayout(False)
		Me.grpPersonalInfo.PerformLayout()
		Me.grpStatusEdit.ResumeLayout(False)
		Me.grpStatusEdit.PerformLayout()
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Public WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Public WithEvents btnConnect As System.Windows.Forms.ToolStripButton
    Friend WithEvents loc As System.Windows.Forms.Panel
    Friend WithEvents grpSecurityDetail As System.Windows.Forms.GroupBox
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents lblUser As System.Windows.Forms.Label
    Friend WithEvents lblEditMode As System.Windows.Forms.Label
    Friend WithEvents grpStatusEdit As System.Windows.Forms.GroupBox
    Friend WithEvents rbStatusNo As System.Windows.Forms.RadioButton
    Friend WithEvents rbStatusYes As System.Windows.Forms.RadioButton
    Friend WithEvents grpPersonalInfo As System.Windows.Forms.GroupBox
    Friend WithEvents rbPersInfoNo As System.Windows.Forms.RadioButton
    Friend WithEvents rbPersInfoYes As System.Windows.Forms.RadioButton
    Public WithEvents cboServer As System.Windows.Forms.ToolStripComboBox
    Public WithEvents pnlPrimaryContent As System.Windows.Forms.Panel
End Class
