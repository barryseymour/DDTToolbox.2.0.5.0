<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmNodeSecurity
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
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmNodeSecurity))
		Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
		Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
		Me.cboServer = New System.Windows.Forms.ToolStripComboBox()
		Me.btnConnect = New System.Windows.Forms.ToolStripButton()
		Me.pnlPrimaryContent = New System.Windows.Forms.Panel()
		Me.grpApp = New System.Windows.Forms.GroupBox()
		Me.rbWFM = New System.Windows.Forms.RadioButton()
		Me.rbDART = New System.Windows.Forms.RadioButton()
		Me.lblUserInfo = New System.Windows.Forms.Label()
		Me.pnlNodeSecurity = New System.Windows.Forms.Panel()
		Me.btnExit = New System.Windows.Forms.Button()
		Me.btnCancel = New System.Windows.Forms.Button()
		Me.Label1 = New System.Windows.Forms.Label()
		Me.lblCurrentNodes = New System.Windows.Forms.Label()
		Me.btnSave = New System.Windows.Forms.Button()
		Me.lblAvailNodes = New System.Windows.Forms.Label()
		Me.btnCopyFrom = New System.Windows.Forms.Button()
		Me.grpSecureNodes = New System.Windows.Forms.GroupBox()
		Me.dgvSecureNodes = New System.Windows.Forms.DataGridView()
		Me.btnCopyTo = New System.Windows.Forms.Button()
		Me.grpAvailableNodes = New System.Windows.Forms.GroupBox()
		Me.dgvAvailableNodes = New System.Windows.Forms.DataGridView()
		Me.lblNodeSecurity = New System.Windows.Forms.Label()
		Me.ToolStrip1.SuspendLayout()
		Me.pnlPrimaryContent.SuspendLayout()
		Me.grpApp.SuspendLayout()
		Me.pnlNodeSecurity.SuspendLayout()
		Me.grpSecureNodes.SuspendLayout()
		CType(Me.dgvSecureNodes, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.grpAvailableNodes.SuspendLayout()
		CType(Me.dgvAvailableNodes, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.SuspendLayout()
		'
		'ToolStrip1
		'
		Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel1, Me.cboServer, Me.btnConnect})
		Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
		Me.ToolStrip1.Name = "ToolStrip1"
		Me.ToolStrip1.Size = New System.Drawing.Size(1073, 25)
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
		Me.pnlPrimaryContent.Controls.Add(Me.grpApp)
		Me.pnlPrimaryContent.Controls.Add(Me.lblUserInfo)
		Me.pnlPrimaryContent.Controls.Add(Me.pnlNodeSecurity)
		Me.pnlPrimaryContent.Controls.Add(Me.lblNodeSecurity)
		Me.pnlPrimaryContent.Dock = System.Windows.Forms.DockStyle.Fill
		Me.pnlPrimaryContent.Location = New System.Drawing.Point(0, 25)
		Me.pnlPrimaryContent.Name = "pnlPrimaryContent"
		Me.pnlPrimaryContent.Size = New System.Drawing.Size(1073, 612)
		Me.pnlPrimaryContent.TabIndex = 1
		'
		'grpApp
		'
		Me.grpApp.Controls.Add(Me.rbWFM)
		Me.grpApp.Controls.Add(Me.rbDART)
		Me.grpApp.Location = New System.Drawing.Point(454, 43)
		Me.grpApp.Name = "grpApp"
		Me.grpApp.Size = New System.Drawing.Size(162, 42)
		Me.grpApp.TabIndex = 31
		Me.grpApp.TabStop = False
		Me.grpApp.Text = "Application"
		'
		'rbWFM
		'
		Me.rbWFM.AutoSize = True
		Me.rbWFM.Location = New System.Drawing.Point(87, 19)
		Me.rbWFM.Name = "rbWFM"
		Me.rbWFM.Size = New System.Drawing.Size(53, 19)
		Me.rbWFM.TabIndex = 1
		Me.rbWFM.Text = "WFM"
		Me.rbWFM.UseVisualStyleBackColor = True
		'
		'rbDART
		'
		Me.rbDART.AutoSize = True
		Me.rbDART.Checked = True
		Me.rbDART.Location = New System.Drawing.Point(7, 20)
		Me.rbDART.Name = "rbDART"
		Me.rbDART.Size = New System.Drawing.Size(53, 19)
		Me.rbDART.TabIndex = 0
		Me.rbDART.TabStop = True
		Me.rbDART.Text = "DART"
		Me.rbDART.UseVisualStyleBackColor = True
		'
		'lblUserInfo
		'
		Me.lblUserInfo.AutoSize = True
		Me.lblUserInfo.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblUserInfo.Location = New System.Drawing.Point(44, 43)
		Me.lblUserInfo.Name = "lblUserInfo"
		Me.lblUserInfo.Size = New System.Drawing.Size(62, 15)
		Me.lblUserInfo.TabIndex = 29
		Me.lblUserInfo.Text = "User Info:"
		'
		'pnlNodeSecurity
		'
		Me.pnlNodeSecurity.Controls.Add(Me.btnExit)
		Me.pnlNodeSecurity.Controls.Add(Me.btnCancel)
		Me.pnlNodeSecurity.Controls.Add(Me.Label1)
		Me.pnlNodeSecurity.Controls.Add(Me.lblCurrentNodes)
		Me.pnlNodeSecurity.Controls.Add(Me.btnSave)
		Me.pnlNodeSecurity.Controls.Add(Me.lblAvailNodes)
		Me.pnlNodeSecurity.Controls.Add(Me.btnCopyFrom)
		Me.pnlNodeSecurity.Controls.Add(Me.grpSecureNodes)
		Me.pnlNodeSecurity.Controls.Add(Me.btnCopyTo)
		Me.pnlNodeSecurity.Controls.Add(Me.grpAvailableNodes)
		Me.pnlNodeSecurity.Location = New System.Drawing.Point(11, 88)
		Me.pnlNodeSecurity.Name = "pnlNodeSecurity"
		Me.pnlNodeSecurity.Size = New System.Drawing.Size(1048, 511)
		Me.pnlNodeSecurity.TabIndex = 27
		'
		'btnExit
		'
		Me.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel
		Me.btnExit.Location = New System.Drawing.Point(562, 463)
		Me.btnExit.Name = "btnExit"
		Me.btnExit.Size = New System.Drawing.Size(86, 28)
		Me.btnExit.TabIndex = 29
		Me.btnExit.Text = "Exit"
		Me.btnExit.UseVisualStyleBackColor = True
		'
		'btnCancel
		'
		Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
		Me.btnCancel.Location = New System.Drawing.Point(428, 464)
		Me.btnCancel.Name = "btnCancel"
		Me.btnCancel.Size = New System.Drawing.Size(86, 28)
		Me.btnCancel.TabIndex = 5
		Me.btnCancel.Text = "Cancel"
		Me.btnCancel.UseVisualStyleBackColor = True
		'
		'Label1
		'
		Me.Label1.AutoSize = True
		Me.Label1.Location = New System.Drawing.Point(783, 553)
		Me.Label1.Name = "Label1"
		Me.Label1.Size = New System.Drawing.Size(54, 15)
		Me.Label1.TabIndex = 28
		Me.Label1.Text = "Nodes(s)"
		'
		'lblCurrentNodes
		'
		Me.lblCurrentNodes.AutoSize = True
		Me.lblCurrentNodes.Location = New System.Drawing.Point(565, 439)
		Me.lblCurrentNodes.Name = "lblCurrentNodes"
		Me.lblCurrentNodes.Size = New System.Drawing.Size(54, 15)
		Me.lblCurrentNodes.TabIndex = 28
		Me.lblCurrentNodes.Text = "Nodes(s)"
		'
		'btnSave
		'
		Me.btnSave.Location = New System.Drawing.Point(292, 465)
		Me.btnSave.Name = "btnSave"
		Me.btnSave.Size = New System.Drawing.Size(86, 27)
		Me.btnSave.TabIndex = 4
		Me.btnSave.Text = "Save"
		Me.btnSave.UseVisualStyleBackColor = True
		'
		'lblAvailNodes
		'
		Me.lblAvailNodes.AutoSize = True
		Me.lblAvailNodes.Location = New System.Drawing.Point(13, 439)
		Me.lblAvailNodes.Name = "lblAvailNodes"
		Me.lblAvailNodes.Size = New System.Drawing.Size(49, 15)
		Me.lblAvailNodes.TabIndex = 27
		Me.lblAvailNodes.Text = "Node(s)"
		'
		'btnCopyFrom
		'
		Me.btnCopyFrom.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
		Me.btnCopyFrom.FlatAppearance.BorderSize = 0
		Me.btnCopyFrom.FlatStyle = System.Windows.Forms.FlatStyle.Flat
		Me.btnCopyFrom.Image = Global.DDTToolbox.My.Resources.Resources.removefield
		Me.btnCopyFrom.Location = New System.Drawing.Point(510, 201)
		Me.btnCopyFrom.Name = "btnCopyFrom"
		Me.btnCopyFrom.Size = New System.Drawing.Size(26, 35)
		Me.btnCopyFrom.TabIndex = 26
		Me.btnCopyFrom.UseVisualStyleBackColor = False
		'
		'grpSecureNodes
		'
		Me.grpSecureNodes.Controls.Add(Me.dgvSecureNodes)
		Me.grpSecureNodes.Location = New System.Drawing.Point(562, 14)
		Me.grpSecureNodes.Name = "grpSecureNodes"
		Me.grpSecureNodes.Size = New System.Drawing.Size(473, 422)
		Me.grpSecureNodes.TabIndex = 16
		Me.grpSecureNodes.TabStop = False
		Me.grpSecureNodes.Text = "Secure Nodes"
		'
		'dgvSecureNodes
		'
		Me.dgvSecureNodes.AllowUserToAddRows = False
		Me.dgvSecureNodes.AllowUserToDeleteRows = False
		Me.dgvSecureNodes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
		Me.dgvSecureNodes.Location = New System.Drawing.Point(6, 16)
		Me.dgvSecureNodes.Name = "dgvSecureNodes"
		Me.dgvSecureNodes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
		Me.dgvSecureNodes.Size = New System.Drawing.Size(460, 400)
		Me.dgvSecureNodes.TabIndex = 0
		'
		'btnCopyTo
		'
		Me.btnCopyTo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
		Me.btnCopyTo.FlatAppearance.BorderSize = 0
		Me.btnCopyTo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
		Me.btnCopyTo.Image = Global.DDTToolbox.My.Resources.Resources.addfield
		Me.btnCopyTo.Location = New System.Drawing.Point(510, 128)
		Me.btnCopyTo.Name = "btnCopyTo"
		Me.btnCopyTo.Size = New System.Drawing.Size(26, 35)
		Me.btnCopyTo.TabIndex = 24
		Me.btnCopyTo.UseVisualStyleBackColor = False
		'
		'grpAvailableNodes
		'
		Me.grpAvailableNodes.Controls.Add(Me.dgvAvailableNodes)
		Me.grpAvailableNodes.Location = New System.Drawing.Point(16, 14)
		Me.grpAvailableNodes.Name = "grpAvailableNodes"
		Me.grpAvailableNodes.Size = New System.Drawing.Size(473, 422)
		Me.grpAvailableNodes.TabIndex = 17
		Me.grpAvailableNodes.TabStop = False
		Me.grpAvailableNodes.Text = "Available Nodes"
		'
		'dgvAvailableNodes
		'
		Me.dgvAvailableNodes.AllowUserToAddRows = False
		Me.dgvAvailableNodes.AllowUserToDeleteRows = False
		Me.dgvAvailableNodes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
		Me.dgvAvailableNodes.Location = New System.Drawing.Point(6, 16)
		Me.dgvAvailableNodes.Name = "dgvAvailableNodes"
		Me.dgvAvailableNodes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
		Me.dgvAvailableNodes.Size = New System.Drawing.Size(460, 400)
		Me.dgvAvailableNodes.TabIndex = 1
		'
		'lblNodeSecurity
		'
		Me.lblNodeSecurity.BackColor = System.Drawing.Color.WhiteSmoke
		Me.lblNodeSecurity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.lblNodeSecurity.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblNodeSecurity.Location = New System.Drawing.Point(11, 12)
		Me.lblNodeSecurity.Name = "lblNodeSecurity"
		Me.lblNodeSecurity.Size = New System.Drawing.Size(1048, 19)
		Me.lblNodeSecurity.TabIndex = 28
		Me.lblNodeSecurity.Text = "NODE SECURITY"
		Me.lblNodeSecurity.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		'
		'frmNodeSecurity
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
		Me.ClientSize = New System.Drawing.Size(1073, 637)
		Me.Controls.Add(Me.pnlPrimaryContent)
		Me.Controls.Add(Me.ToolStrip1)
		Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
		Me.MinimumSize = New System.Drawing.Size(996, 675)
		Me.Name = "frmNodeSecurity"
		Me.ShowInTaskbar = False
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.Text = "Node Security"
		Me.ToolStrip1.ResumeLayout(False)
		Me.ToolStrip1.PerformLayout()
		Me.pnlPrimaryContent.ResumeLayout(False)
		Me.pnlPrimaryContent.PerformLayout()
		Me.grpApp.ResumeLayout(False)
		Me.grpApp.PerformLayout()
		Me.pnlNodeSecurity.ResumeLayout(False)
		Me.pnlNodeSecurity.PerformLayout()
		Me.grpSecureNodes.ResumeLayout(False)
		CType(Me.dgvSecureNodes, System.ComponentModel.ISupportInitialize).EndInit()
		Me.grpAvailableNodes.ResumeLayout(False)
		CType(Me.dgvAvailableNodes, System.ComponentModel.ISupportInitialize).EndInit()
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Public WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Public WithEvents btnConnect As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents lblNodeSecurity As System.Windows.Forms.Label
    Friend WithEvents pnlNodeSecurity As System.Windows.Forms.Panel
    Friend WithEvents grpSecureNodes As System.Windows.Forms.GroupBox
    Friend WithEvents grpAvailableNodes As System.Windows.Forms.GroupBox
    Friend WithEvents btnCopyFrom As System.Windows.Forms.Button
    Friend WithEvents btnCopyTo As System.Windows.Forms.Button
    Friend WithEvents lblCurrentNodes As System.Windows.Forms.Label
    Friend WithEvents lblAvailNodes As System.Windows.Forms.Label
    Friend WithEvents lblUserInfo As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents grpApp As System.Windows.Forms.GroupBox
    Friend WithEvents rbWFM As System.Windows.Forms.RadioButton
    Friend WithEvents rbDART As System.Windows.Forms.RadioButton
    Friend WithEvents btnExit As System.Windows.Forms.Button
    Friend WithEvents dgvSecureNodes As System.Windows.Forms.DataGridView
    Friend WithEvents dgvAvailableNodes As System.Windows.Forms.DataGridView
    Public WithEvents cboServer As System.Windows.Forms.ToolStripComboBox
    Public WithEvents pnlPrimaryContent As System.Windows.Forms.Panel
End Class
