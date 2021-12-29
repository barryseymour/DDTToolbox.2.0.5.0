<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmApplicationUsers
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
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmApplicationUsers))
		Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
		Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
		Me.cboServer = New System.Windows.Forms.ToolStripComboBox()
		Me.btnConnect = New System.Windows.Forms.ToolStripButton()
		Me.pnlPrimaryContent = New System.Windows.Forms.Panel()
		Me.grpUserInfo = New System.Windows.Forms.GroupBox()
		Me.lblSecurityDDTGroups = New System.Windows.Forms.Label()
		Me.pnlUserInfo = New System.Windows.Forms.Panel()
		Me.lblWITSOrganization = New System.Windows.Forms.Label()
		Me.txtWITSOrganization = New DDTToolbox.ExtTextBox()
		Me.lblEditMode = New System.Windows.Forms.Label()
		Me.txtWITSCompany = New DDTToolbox.ExtTextBox()
		Me.txtWITSLocation = New DDTToolbox.ExtTextBox()
		Me.txtTitle = New DDTToolbox.ExtTextBox()
		Me.txtEmployeeNum = New DDTToolbox.ExtTextBox()
		Me.txtLastName = New DDTToolbox.ExtTextBox()
		Me.txtFirstName = New DDTToolbox.ExtTextBox()
		Me.txtUserID = New DDTToolbox.ExtTextBox()
		Me.lblWITSCompany = New System.Windows.Forms.Label()
		Me.lblWITSLocation = New System.Windows.Forms.Label()
		Me.lblTitle = New System.Windows.Forms.Label()
		Me.lblEmployeeNum = New System.Windows.Forms.Label()
		Me.lblLastName = New System.Windows.Forms.Label()
		Me.lblFirstName = New System.Windows.Forms.Label()
		Me.lblUserID = New System.Windows.Forms.Label()
		Me.pnlSecurityGroups = New System.Windows.Forms.Panel()
		Me.lblCurrentADGroups = New System.Windows.Forms.Label()
		Me.lblAvailADGroups = New System.Windows.Forms.Label()
		Me.btnCopyFrom = New System.Windows.Forms.Button()
		Me.grpCurrentPermission = New System.Windows.Forms.GroupBox()
		Me.dgvUserPermissionsTo = New System.Windows.Forms.DataGridView()
		Me.ADGroup = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.btnCopyAllFrom = New System.Windows.Forms.Button()
		Me.btnCopyTo = New System.Windows.Forms.Button()
		Me.btnCopyAllTo = New System.Windows.Forms.Button()
		Me.grpAvailablePermissions = New System.Windows.Forms.GroupBox()
		Me.dgvUserPermissionsFrom = New System.Windows.Forms.DataGridView()
		Me.ADGroupAvailable = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.pnlUserActions = New System.Windows.Forms.Panel()
		Me.btnNodeSecurity = New System.Windows.Forms.Button()
		Me.btnWFM = New System.Windows.Forms.Button()
		Me.lblJobType = New System.Windows.Forms.Label()
		Me.Label6 = New System.Windows.Forms.Label()
		Me.btnNext = New System.Windows.Forms.Button()
		Me.chkSearchMatchCase = New System.Windows.Forms.CheckBox()
		Me.lblSearchOf = New System.Windows.Forms.Label()
		Me.cboSearchPart = New System.Windows.Forms.ComboBox()
		Me.cboSearchColumn = New System.Windows.Forms.ComboBox()
		Me.txtSearch = New DDTToolbox.ExtTextBox()
		Me.lblSearchFor = New System.Windows.Forms.Label()
		Me.btnSearch = New System.Windows.Forms.Button()
		Me.btnNewUserEmail = New System.Windows.Forms.Button()
		Me.btnCancel = New System.Windows.Forms.Button()
		Me.btnSave = New System.Windows.Forms.Button()
		Me.btnRefresh = New System.Windows.Forms.Button()
		Me.btnPending = New System.Windows.Forms.Button()
		Me.btnEdit = New System.Windows.Forms.Button()
		Me.btnAdd = New System.Windows.Forms.Button()
		Me.lblUserCount = New System.Windows.Forms.Label()
		Me.dgvUsers = New System.Windows.Forms.DataGridView()
		Me.cmCancelPending = New System.Windows.Forms.ContextMenuStrip(Me.components)
		Me.CancelPendingToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		Me.ToolStrip1.SuspendLayout()
		Me.pnlPrimaryContent.SuspendLayout()
		Me.grpUserInfo.SuspendLayout()
		Me.pnlUserInfo.SuspendLayout()
		Me.pnlSecurityGroups.SuspendLayout()
		Me.grpCurrentPermission.SuspendLayout()
		CType(Me.dgvUserPermissionsTo, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.grpAvailablePermissions.SuspendLayout()
		CType(Me.dgvUserPermissionsFrom, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.pnlUserActions.SuspendLayout()
		CType(Me.dgvUsers, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.cmCancelPending.SuspendLayout()
		Me.SuspendLayout()
		'
		'ToolStrip1
		'
		Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel1, Me.cboServer, Me.btnConnect})
		Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
		Me.ToolStrip1.Name = "ToolStrip1"
		Me.ToolStrip1.Size = New System.Drawing.Size(1003, 25)
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
		Me.pnlPrimaryContent.Controls.Add(Me.grpUserInfo)
		Me.pnlPrimaryContent.Controls.Add(Me.pnlUserActions)
		Me.pnlPrimaryContent.Controls.Add(Me.dgvUsers)
		Me.pnlPrimaryContent.Dock = System.Windows.Forms.DockStyle.Fill
		Me.pnlPrimaryContent.Location = New System.Drawing.Point(0, 25)
		Me.pnlPrimaryContent.Name = "pnlPrimaryContent"
		Me.pnlPrimaryContent.Size = New System.Drawing.Size(1003, 631)
		Me.pnlPrimaryContent.TabIndex = 1
		'
		'grpUserInfo
		'
		Me.grpUserInfo.Controls.Add(Me.lblSecurityDDTGroups)
		Me.grpUserInfo.Controls.Add(Me.pnlUserInfo)
		Me.grpUserInfo.Controls.Add(Me.pnlSecurityGroups)
		Me.grpUserInfo.Location = New System.Drawing.Point(3, 316)
		Me.grpUserInfo.Name = "grpUserInfo"
		Me.grpUserInfo.Size = New System.Drawing.Size(987, 310)
		Me.grpUserInfo.TabIndex = 91
		Me.grpUserInfo.TabStop = False
		Me.grpUserInfo.Text = "User Information"
		'
		'lblSecurityDDTGroups
		'
		Me.lblSecurityDDTGroups.BackColor = System.Drawing.Color.WhiteSmoke
		Me.lblSecurityDDTGroups.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.lblSecurityDDTGroups.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblSecurityDDTGroups.Location = New System.Drawing.Point(314, 22)
		Me.lblSecurityDDTGroups.Name = "lblSecurityDDTGroups"
		Me.lblSecurityDDTGroups.Size = New System.Drawing.Size(651, 18)
		Me.lblSecurityDDTGroups.TabIndex = 28
		Me.lblSecurityDDTGroups.Text = "SECURITY-DDT Groups"
		Me.lblSecurityDDTGroups.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		'
		'pnlUserInfo
		'
		Me.pnlUserInfo.Controls.Add(Me.lblWITSOrganization)
		Me.pnlUserInfo.Controls.Add(Me.txtWITSOrganization)
		Me.pnlUserInfo.Controls.Add(Me.lblEditMode)
		Me.pnlUserInfo.Controls.Add(Me.txtWITSCompany)
		Me.pnlUserInfo.Controls.Add(Me.txtWITSLocation)
		Me.pnlUserInfo.Controls.Add(Me.txtTitle)
		Me.pnlUserInfo.Controls.Add(Me.txtEmployeeNum)
		Me.pnlUserInfo.Controls.Add(Me.txtLastName)
		Me.pnlUserInfo.Controls.Add(Me.txtFirstName)
		Me.pnlUserInfo.Controls.Add(Me.txtUserID)
		Me.pnlUserInfo.Controls.Add(Me.lblWITSCompany)
		Me.pnlUserInfo.Controls.Add(Me.lblWITSLocation)
		Me.pnlUserInfo.Controls.Add(Me.lblTitle)
		Me.pnlUserInfo.Controls.Add(Me.lblEmployeeNum)
		Me.pnlUserInfo.Controls.Add(Me.lblLastName)
		Me.pnlUserInfo.Controls.Add(Me.lblFirstName)
		Me.pnlUserInfo.Controls.Add(Me.lblUserID)
		Me.pnlUserInfo.Location = New System.Drawing.Point(0, 22)
		Me.pnlUserInfo.Name = "pnlUserInfo"
		Me.pnlUserInfo.Size = New System.Drawing.Size(308, 280)
		Me.pnlUserInfo.TabIndex = 88
		'
		'lblWITSOrganization
		'
		Me.lblWITSOrganization.AutoSize = True
		Me.lblWITSOrganization.Location = New System.Drawing.Point(5, 98)
		Me.lblWITSOrganization.Name = "lblWITSOrganization"
		Me.lblWITSOrganization.Size = New System.Drawing.Size(116, 15)
		Me.lblWITSOrganization.TabIndex = 102
		Me.lblWITSOrganization.Text = "MyInfo Organization"
		'
		'txtWITSOrganization
		'
		Me.txtWITSOrganization.Location = New System.Drawing.Point(127, 98)
		Me.txtWITSOrganization.Name = "txtWITSOrganization"
		Me.txtWITSOrganization.ReadOnly = True
		Me.txtWITSOrganization.Size = New System.Drawing.Size(177, 23)
		Me.txtWITSOrganization.TabIndex = 5
		'
		'lblEditMode
		'
		Me.lblEditMode.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblEditMode.ForeColor = System.Drawing.Color.Red
		Me.lblEditMode.Location = New System.Drawing.Point(74, 177)
		Me.lblEditMode.Name = "lblEditMode"
		Me.lblEditMode.Size = New System.Drawing.Size(105, 17)
		Me.lblEditMode.TabIndex = 90
		Me.lblEditMode.Text = "Edit Mode"
		Me.lblEditMode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		'
		'txtWITSCompany
		'
		Me.txtWITSCompany.Location = New System.Drawing.Point(127, 79)
		Me.txtWITSCompany.Name = "txtWITSCompany"
		Me.txtWITSCompany.ReadOnly = True
		Me.txtWITSCompany.Size = New System.Drawing.Size(177, 23)
		Me.txtWITSCompany.TabIndex = 4
		'
		'txtWITSLocation
		'
		Me.txtWITSLocation.Location = New System.Drawing.Point(127, 136)
		Me.txtWITSLocation.Name = "txtWITSLocation"
		Me.txtWITSLocation.ReadOnly = True
		Me.txtWITSLocation.Size = New System.Drawing.Size(177, 23)
		Me.txtWITSLocation.TabIndex = 7
		'
		'txtTitle
		'
		Me.txtTitle.Location = New System.Drawing.Point(127, 117)
		Me.txtTitle.Name = "txtTitle"
		Me.txtTitle.ReadOnly = True
		Me.txtTitle.Size = New System.Drawing.Size(177, 23)
		Me.txtTitle.TabIndex = 6
		'
		'txtEmployeeNum
		'
		Me.txtEmployeeNum.Location = New System.Drawing.Point(127, 60)
		Me.txtEmployeeNum.Name = "txtEmployeeNum"
		Me.txtEmployeeNum.ReadOnly = True
		Me.txtEmployeeNum.Size = New System.Drawing.Size(177, 23)
		Me.txtEmployeeNum.TabIndex = 3
		'
		'txtLastName
		'
		Me.txtLastName.Location = New System.Drawing.Point(127, 41)
		Me.txtLastName.Name = "txtLastName"
		Me.txtLastName.ReadOnly = True
		Me.txtLastName.Size = New System.Drawing.Size(177, 23)
		Me.txtLastName.TabIndex = 2
		'
		'txtFirstName
		'
		Me.txtFirstName.Location = New System.Drawing.Point(127, 22)
		Me.txtFirstName.Name = "txtFirstName"
		Me.txtFirstName.ReadOnly = True
		Me.txtFirstName.Size = New System.Drawing.Size(177, 23)
		Me.txtFirstName.TabIndex = 1
		'
		'txtUserID
		'
		Me.txtUserID.Location = New System.Drawing.Point(127, 3)
		Me.txtUserID.Name = "txtUserID"
		Me.txtUserID.ReadOnly = True
		Me.txtUserID.Size = New System.Drawing.Size(177, 23)
		Me.txtUserID.TabIndex = 0
		'
		'lblWITSCompany
		'
		Me.lblWITSCompany.AutoSize = True
		Me.lblWITSCompany.Location = New System.Drawing.Point(5, 79)
		Me.lblWITSCompany.Name = "lblWITSCompany"
		Me.lblWITSCompany.Size = New System.Drawing.Size(100, 15)
		Me.lblWITSCompany.TabIndex = 92
		Me.lblWITSCompany.Text = "MyInfo Company"
		'
		'lblWITSLocation
		'
		Me.lblWITSLocation.AutoSize = True
		Me.lblWITSLocation.Location = New System.Drawing.Point(5, 136)
		Me.lblWITSLocation.Name = "lblWITSLocation"
		Me.lblWITSLocation.Size = New System.Drawing.Size(94, 15)
		Me.lblWITSLocation.TabIndex = 91
		Me.lblWITSLocation.Text = "MyInfo Location"
		'
		'lblTitle
		'
		Me.lblTitle.AutoSize = True
		Me.lblTitle.Location = New System.Drawing.Point(5, 117)
		Me.lblTitle.Name = "lblTitle"
		Me.lblTitle.Size = New System.Drawing.Size(70, 15)
		Me.lblTitle.TabIndex = 90
		Me.lblTitle.Text = "MyInfo Title"
		'
		'lblEmployeeNum
		'
		Me.lblEmployeeNum.AutoSize = True
		Me.lblEmployeeNum.Location = New System.Drawing.Point(5, 60)
		Me.lblEmployeeNum.Name = "lblEmployeeNum"
		Me.lblEmployeeNum.Size = New System.Drawing.Size(69, 15)
		Me.lblEmployeeNum.TabIndex = 89
		Me.lblEmployeeNum.Text = "Employee #"
		'
		'lblLastName
		'
		Me.lblLastName.AutoSize = True
		Me.lblLastName.Location = New System.Drawing.Point(5, 41)
		Me.lblLastName.Name = "lblLastName"
		Me.lblLastName.Size = New System.Drawing.Size(63, 15)
		Me.lblLastName.TabIndex = 88
		Me.lblLastName.Text = "Last Name"
		'
		'lblFirstName
		'
		Me.lblFirstName.AutoSize = True
		Me.lblFirstName.Location = New System.Drawing.Point(5, 22)
		Me.lblFirstName.Name = "lblFirstName"
		Me.lblFirstName.Size = New System.Drawing.Size(64, 15)
		Me.lblFirstName.TabIndex = 87
		Me.lblFirstName.Text = "First Name"
		'
		'lblUserID
		'
		Me.lblUserID.AutoSize = True
		Me.lblUserID.Location = New System.Drawing.Point(5, 3)
		Me.lblUserID.Name = "lblUserID"
		Me.lblUserID.Size = New System.Drawing.Size(49, 15)
		Me.lblUserID.TabIndex = 86
		Me.lblUserID.Text = "UserID *"
		'
		'pnlSecurityGroups
		'
		Me.pnlSecurityGroups.Controls.Add(Me.lblCurrentADGroups)
		Me.pnlSecurityGroups.Controls.Add(Me.lblAvailADGroups)
		Me.pnlSecurityGroups.Controls.Add(Me.btnCopyFrom)
		Me.pnlSecurityGroups.Controls.Add(Me.grpCurrentPermission)
		Me.pnlSecurityGroups.Controls.Add(Me.btnCopyAllFrom)
		Me.pnlSecurityGroups.Controls.Add(Me.btnCopyTo)
		Me.pnlSecurityGroups.Controls.Add(Me.btnCopyAllTo)
		Me.pnlSecurityGroups.Controls.Add(Me.grpAvailablePermissions)
		Me.pnlSecurityGroups.Location = New System.Drawing.Point(311, 44)
		Me.pnlSecurityGroups.Name = "pnlSecurityGroups"
		Me.pnlSecurityGroups.Size = New System.Drawing.Size(666, 258)
		Me.pnlSecurityGroups.TabIndex = 27
		'
		'lblCurrentADGroups
		'
		Me.lblCurrentADGroups.AutoSize = True
		Me.lblCurrentADGroups.Location = New System.Drawing.Point(362, 217)
		Me.lblCurrentADGroups.Name = "lblCurrentADGroups"
		Me.lblCurrentADGroups.Size = New System.Drawing.Size(52, 15)
		Me.lblCurrentADGroups.TabIndex = 28
		Me.lblCurrentADGroups.Text = "group(s)"
		'
		'lblAvailADGroups
		'
		Me.lblAvailADGroups.AutoSize = True
		Me.lblAvailADGroups.Location = New System.Drawing.Point(10, 217)
		Me.lblAvailADGroups.Name = "lblAvailADGroups"
		Me.lblAvailADGroups.Size = New System.Drawing.Size(52, 15)
		Me.lblAvailADGroups.TabIndex = 27
		Me.lblAvailADGroups.Text = "group(s)"
		'
		'btnCopyFrom
		'
		Me.btnCopyFrom.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
		Me.btnCopyFrom.FlatAppearance.BorderSize = 0
		Me.btnCopyFrom.FlatStyle = System.Windows.Forms.FlatStyle.Flat
		Me.btnCopyFrom.Image = Global.DDTToolbox.My.Resources.Resources.removefield
		Me.btnCopyFrom.Location = New System.Drawing.Point(317, 102)
		Me.btnCopyFrom.Name = "btnCopyFrom"
		Me.btnCopyFrom.Size = New System.Drawing.Size(26, 35)
		Me.btnCopyFrom.TabIndex = 26
		Me.btnCopyFrom.UseVisualStyleBackColor = False
		'
		'grpCurrentPermission
		'
		Me.grpCurrentPermission.Controls.Add(Me.dgvUserPermissionsTo)
		Me.grpCurrentPermission.Location = New System.Drawing.Point(355, 3)
		Me.grpCurrentPermission.Name = "grpCurrentPermission"
		Me.grpCurrentPermission.Size = New System.Drawing.Size(302, 211)
		Me.grpCurrentPermission.TabIndex = 16
		Me.grpCurrentPermission.TabStop = False
		Me.grpCurrentPermission.Text = "Current Permissions"
		'
		'dgvUserPermissionsTo
		'
		Me.dgvUserPermissionsTo.AllowUserToAddRows = False
		Me.dgvUserPermissionsTo.AllowUserToDeleteRows = False
		Me.dgvUserPermissionsTo.AllowUserToResizeColumns = False
		Me.dgvUserPermissionsTo.AllowUserToResizeRows = False
		Me.dgvUserPermissionsTo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
		Me.dgvUserPermissionsTo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
		Me.dgvUserPermissionsTo.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ADGroup})
		Me.dgvUserPermissionsTo.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
		Me.dgvUserPermissionsTo.Location = New System.Drawing.Point(10, 17)
		Me.dgvUserPermissionsTo.MultiSelect = False
		Me.dgvUserPermissionsTo.Name = "dgvUserPermissionsTo"
		Me.dgvUserPermissionsTo.RowHeadersVisible = False
		Me.dgvUserPermissionsTo.RowTemplate.Height = 18
		Me.dgvUserPermissionsTo.ShowCellToolTips = False
		Me.dgvUserPermissionsTo.Size = New System.Drawing.Size(286, 184)
		Me.dgvUserPermissionsTo.TabIndex = 19
		'
		'ADGroup
		'
		Me.ADGroup.HeaderText = "ADGroup"
		Me.ADGroup.Name = "ADGroup"
		'
		'btnCopyAllFrom
		'
		Me.btnCopyAllFrom.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
		Me.btnCopyAllFrom.FlatAppearance.BorderSize = 0
		Me.btnCopyAllFrom.FlatStyle = System.Windows.Forms.FlatStyle.Flat
		Me.btnCopyAllFrom.Image = Global.DDTToolbox.My.Resources.Resources.removeallfield
		Me.btnCopyAllFrom.Location = New System.Drawing.Point(317, 155)
		Me.btnCopyAllFrom.Name = "btnCopyAllFrom"
		Me.btnCopyAllFrom.Size = New System.Drawing.Size(26, 35)
		Me.btnCopyAllFrom.TabIndex = 25
		Me.btnCopyAllFrom.UseVisualStyleBackColor = False
		'
		'btnCopyTo
		'
		Me.btnCopyTo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
		Me.btnCopyTo.FlatAppearance.BorderSize = 0
		Me.btnCopyTo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
		Me.btnCopyTo.Image = Global.DDTToolbox.My.Resources.Resources.addfield
		Me.btnCopyTo.Location = New System.Drawing.Point(317, 11)
		Me.btnCopyTo.Name = "btnCopyTo"
		Me.btnCopyTo.Size = New System.Drawing.Size(26, 35)
		Me.btnCopyTo.TabIndex = 24
		Me.btnCopyTo.UseVisualStyleBackColor = False
		'
		'btnCopyAllTo
		'
		Me.btnCopyAllTo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
		Me.btnCopyAllTo.FlatAppearance.BorderSize = 0
		Me.btnCopyAllTo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
		Me.btnCopyAllTo.Image = Global.DDTToolbox.My.Resources.Resources.addallfield
		Me.btnCopyAllTo.Location = New System.Drawing.Point(317, 52)
		Me.btnCopyAllTo.Name = "btnCopyAllTo"
		Me.btnCopyAllTo.Size = New System.Drawing.Size(26, 35)
		Me.btnCopyAllTo.TabIndex = 23
		Me.btnCopyAllTo.UseVisualStyleBackColor = False
		'
		'grpAvailablePermissions
		'
		Me.grpAvailablePermissions.Controls.Add(Me.dgvUserPermissionsFrom)
		Me.grpAvailablePermissions.Location = New System.Drawing.Point(3, 3)
		Me.grpAvailablePermissions.Name = "grpAvailablePermissions"
		Me.grpAvailablePermissions.Size = New System.Drawing.Size(308, 211)
		Me.grpAvailablePermissions.TabIndex = 17
		Me.grpAvailablePermissions.TabStop = False
		Me.grpAvailablePermissions.Text = "Available Permissions"
		'
		'dgvUserPermissionsFrom
		'
		Me.dgvUserPermissionsFrom.AllowUserToAddRows = False
		Me.dgvUserPermissionsFrom.AllowUserToDeleteRows = False
		Me.dgvUserPermissionsFrom.AllowUserToResizeColumns = False
		Me.dgvUserPermissionsFrom.AllowUserToResizeRows = False
		Me.dgvUserPermissionsFrom.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
		Me.dgvUserPermissionsFrom.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
		Me.dgvUserPermissionsFrom.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ADGroupAvailable})
		Me.dgvUserPermissionsFrom.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
		Me.dgvUserPermissionsFrom.Location = New System.Drawing.Point(10, 17)
		Me.dgvUserPermissionsFrom.MultiSelect = False
		Me.dgvUserPermissionsFrom.Name = "dgvUserPermissionsFrom"
		Me.dgvUserPermissionsFrom.ReadOnly = True
		Me.dgvUserPermissionsFrom.RowHeadersVisible = False
		Me.dgvUserPermissionsFrom.RowTemplate.Height = 18
		Me.dgvUserPermissionsFrom.ShowCellToolTips = False
		Me.dgvUserPermissionsFrom.Size = New System.Drawing.Size(292, 184)
		Me.dgvUserPermissionsFrom.TabIndex = 19
		'
		'ADGroupAvailable
		'
		Me.ADGroupAvailable.HeaderText = "ADGroup"
		Me.ADGroupAvailable.Name = "ADGroupAvailable"
		Me.ADGroupAvailable.ReadOnly = True
		'
		'pnlUserActions
		'
		Me.pnlUserActions.Controls.Add(Me.btnNodeSecurity)
		Me.pnlUserActions.Controls.Add(Me.btnWFM)
		Me.pnlUserActions.Controls.Add(Me.lblJobType)
		Me.pnlUserActions.Controls.Add(Me.Label6)
		Me.pnlUserActions.Controls.Add(Me.btnNext)
		Me.pnlUserActions.Controls.Add(Me.chkSearchMatchCase)
		Me.pnlUserActions.Controls.Add(Me.lblSearchOf)
		Me.pnlUserActions.Controls.Add(Me.cboSearchPart)
		Me.pnlUserActions.Controls.Add(Me.cboSearchColumn)
		Me.pnlUserActions.Controls.Add(Me.txtSearch)
		Me.pnlUserActions.Controls.Add(Me.lblSearchFor)
		Me.pnlUserActions.Controls.Add(Me.btnSearch)
		Me.pnlUserActions.Controls.Add(Me.btnNewUserEmail)
		Me.pnlUserActions.Controls.Add(Me.btnCancel)
		Me.pnlUserActions.Controls.Add(Me.btnSave)
		Me.pnlUserActions.Controls.Add(Me.btnRefresh)
		Me.pnlUserActions.Controls.Add(Me.btnPending)
		Me.pnlUserActions.Controls.Add(Me.btnEdit)
		Me.pnlUserActions.Controls.Add(Me.btnAdd)
		Me.pnlUserActions.Controls.Add(Me.lblUserCount)
		Me.pnlUserActions.Location = New System.Drawing.Point(-1, 226)
		Me.pnlUserActions.Name = "pnlUserActions"
		Me.pnlUserActions.Size = New System.Drawing.Size(991, 87)
		Me.pnlUserActions.TabIndex = 1
		'
		'btnNodeSecurity
		'
		Me.btnNodeSecurity.Location = New System.Drawing.Point(845, 5)
		Me.btnNodeSecurity.Name = "btnNodeSecurity"
		Me.btnNodeSecurity.Size = New System.Drawing.Size(99, 24)
		Me.btnNodeSecurity.TabIndex = 108
		Me.btnNodeSecurity.Text = "Node Security"
		Me.btnNodeSecurity.UseVisualStyleBackColor = True
		'
		'btnWFM
		'
		Me.btnWFM.Location = New System.Drawing.Point(732, 5)
		Me.btnWFM.Name = "btnWFM"
		Me.btnWFM.Size = New System.Drawing.Size(108, 24)
		Me.btnWFM.TabIndex = 107
		Me.btnWFM.Text = "WFM Security"
		Me.btnWFM.UseVisualStyleBackColor = True
		'
		'lblJobType
		'
		Me.lblJobType.AutoSize = True
		Me.lblJobType.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblJobType.ForeColor = System.Drawing.Color.Red
		Me.lblJobType.Location = New System.Drawing.Point(691, 62)
		Me.lblJobType.Name = "lblJobType"
		Me.lblJobType.Size = New System.Drawing.Size(0, 24)
		Me.lblJobType.TabIndex = 106
		Me.lblJobType.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		'
		'Label6
		'
		Me.Label6.AutoSize = True
		Me.Label6.ForeColor = System.Drawing.Color.Red
		Me.Label6.Location = New System.Drawing.Point(185, 64)
		Me.Label6.Name = "Label6"
		Me.Label6.Size = New System.Drawing.Size(216, 15)
		Me.Label6.TabIndex = 104
		Me.Label6.Text = "* Do not include domain in UserID field."
		'
		'btnNext
		'
		Me.btnNext.Enabled = False
		Me.btnNext.Location = New System.Drawing.Point(97, 60)
		Me.btnNext.Name = "btnNext"
		Me.btnNext.Size = New System.Drawing.Size(67, 24)
		Me.btnNext.TabIndex = 11
		Me.btnNext.Text = "Next"
		Me.btnNext.UseVisualStyleBackColor = True
		'
		'chkSearchMatchCase
		'
		Me.chkSearchMatchCase.AutoSize = True
		Me.chkSearchMatchCase.Location = New System.Drawing.Point(422, 60)
		Me.chkSearchMatchCase.Name = "chkSearchMatchCase"
		Me.chkSearchMatchCase.Size = New System.Drawing.Size(86, 19)
		Me.chkSearchMatchCase.TabIndex = 15
		Me.chkSearchMatchCase.Text = "match case"
		Me.chkSearchMatchCase.UseVisualStyleBackColor = True
		'
		'lblSearchOf
		'
		Me.lblSearchOf.AutoSize = True
		Me.lblSearchOf.Location = New System.Drawing.Point(542, 39)
		Me.lblSearchOf.Name = "lblSearchOf"
		Me.lblSearchOf.Size = New System.Drawing.Size(18, 15)
		Me.lblSearchOf.TabIndex = 102
		Me.lblSearchOf.Text = "of"
		'
		'cboSearchPart
		'
		Me.cboSearchPart.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cboSearchPart.FormattingEnabled = True
		Me.cboSearchPart.Items.AddRange(New Object() {"in any part", "from the beginning", "at the end", "as an exact match"})
		Me.cboSearchPart.Location = New System.Drawing.Point(421, 35)
		Me.cboSearchPart.Name = "cboSearchPart"
		Me.cboSearchPart.Size = New System.Drawing.Size(120, 23)
		Me.cboSearchPart.TabIndex = 13
		'
		'cboSearchColumn
		'
		Me.cboSearchColumn.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cboSearchColumn.FormattingEnabled = True
		Me.cboSearchColumn.Items.AddRange(New Object() {"first record", "current record"})
		Me.cboSearchColumn.Location = New System.Drawing.Point(561, 34)
		Me.cboSearchColumn.Name = "cboSearchColumn"
		Me.cboSearchColumn.Size = New System.Drawing.Size(250, 23)
		Me.cboSearchColumn.TabIndex = 14
		'
		'txtSearch
		'
		Me.txtSearch.Location = New System.Drawing.Point(192, 35)
		Me.txtSearch.Name = "txtSearch"
		Me.txtSearch.Size = New System.Drawing.Size(223, 23)
		Me.txtSearch.TabIndex = 12
		'
		'lblSearchFor
		'
		Me.lblSearchFor.AutoSize = True
		Me.lblSearchFor.Location = New System.Drawing.Point(170, 39)
		Me.lblSearchFor.Name = "lblSearchFor"
		Me.lblSearchFor.Size = New System.Drawing.Size(22, 15)
		Me.lblSearchFor.TabIndex = 100
		Me.lblSearchFor.Text = "for"
		'
		'btnSearch
		'
		Me.btnSearch.Enabled = False
		Me.btnSearch.Location = New System.Drawing.Point(97, 33)
		Me.btnSearch.Name = "btnSearch"
		Me.btnSearch.Size = New System.Drawing.Size(67, 24)
		Me.btnSearch.TabIndex = 10
		Me.btnSearch.Text = "Search"
		Me.btnSearch.UseVisualStyleBackColor = True
		'
		'btnNewUserEmail
		'
		Me.btnNewUserEmail.Location = New System.Drawing.Point(385, 5)
		Me.btnNewUserEmail.Name = "btnNewUserEmail"
		Me.btnNewUserEmail.Size = New System.Drawing.Size(103, 24)
		Me.btnNewUserEmail.TabIndex = 8
		Me.btnNewUserEmail.Text = "New User Email"
		Me.btnNewUserEmail.UseVisualStyleBackColor = True
		'
		'btnCancel
		'
		Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
		Me.btnCancel.Location = New System.Drawing.Point(313, 5)
		Me.btnCancel.Name = "btnCancel"
		Me.btnCancel.Size = New System.Drawing.Size(67, 24)
		Me.btnCancel.TabIndex = 5
		Me.btnCancel.Text = "Cancel"
		Me.btnCancel.UseVisualStyleBackColor = True
		'
		'btnSave
		'
		Me.btnSave.Location = New System.Drawing.Point(241, 5)
		Me.btnSave.Name = "btnSave"
		Me.btnSave.Size = New System.Drawing.Size(67, 24)
		Me.btnSave.TabIndex = 4
		Me.btnSave.Text = "Save"
		Me.btnSave.UseVisualStyleBackColor = True
		'
		'btnRefresh
		'
		Me.btnRefresh.Location = New System.Drawing.Point(493, 5)
		Me.btnRefresh.Name = "btnRefresh"
		Me.btnRefresh.Size = New System.Drawing.Size(81, 24)
		Me.btnRefresh.TabIndex = 9
		Me.btnRefresh.Text = "Refresh"
		Me.btnRefresh.UseVisualStyleBackColor = True
		'
		'btnPending
		'
		Me.btnPending.Location = New System.Drawing.Point(579, 5)
		Me.btnPending.Name = "btnPending"
		Me.btnPending.Size = New System.Drawing.Size(148, 24)
		Me.btnPending.TabIndex = 3
		Me.btnPending.Text = "View Pending Updates"
		Me.btnPending.UseVisualStyleBackColor = True
		'
		'btnEdit
		'
		Me.btnEdit.Location = New System.Drawing.Point(169, 5)
		Me.btnEdit.Name = "btnEdit"
		Me.btnEdit.Size = New System.Drawing.Size(67, 24)
		Me.btnEdit.TabIndex = 2
		Me.btnEdit.Text = "Edit"
		Me.btnEdit.UseVisualStyleBackColor = True
		'
		'btnAdd
		'
		Me.btnAdd.Location = New System.Drawing.Point(97, 5)
		Me.btnAdd.Name = "btnAdd"
		Me.btnAdd.Size = New System.Drawing.Size(67, 24)
		Me.btnAdd.TabIndex = 1
		Me.btnAdd.Text = "Add"
		Me.btnAdd.UseVisualStyleBackColor = True
		'
		'lblUserCount
		'
		Me.lblUserCount.AutoSize = True
		Me.lblUserCount.Location = New System.Drawing.Point(3, 6)
		Me.lblUserCount.Name = "lblUserCount"
		Me.lblUserCount.Size = New System.Drawing.Size(54, 15)
		Me.lblUserCount.TabIndex = 0
		Me.lblUserCount.Text = "record(s)"
		'
		'dgvUsers
		'
		Me.dgvUsers.AllowUserToAddRows = False
		Me.dgvUsers.AllowUserToDeleteRows = False
		Me.dgvUsers.BackgroundColor = System.Drawing.Color.White
		Me.dgvUsers.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.dgvUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
		Me.dgvUsers.Location = New System.Drawing.Point(-1, -1)
		Me.dgvUsers.MultiSelect = False
		Me.dgvUsers.Name = "dgvUsers"
		Me.dgvUsers.ReadOnly = True
		Me.dgvUsers.RowHeadersVisible = False
		Me.dgvUsers.RowHeadersWidth = 20
		Me.dgvUsers.RowTemplate.Height = 18
		Me.dgvUsers.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
		Me.dgvUsers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
		Me.dgvUsers.ShowCellToolTips = False
		Me.dgvUsers.Size = New System.Drawing.Size(991, 230)
		Me.dgvUsers.TabIndex = 0
		'
		'cmCancelPending
		'
		Me.cmCancelPending.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CancelPendingToolStripMenuItem})
		Me.cmCancelPending.Name = "cmCancelPending"
		Me.cmCancelPending.Size = New System.Drawing.Size(158, 26)
		'
		'CancelPendingToolStripMenuItem
		'
		Me.CancelPendingToolStripMenuItem.Name = "CancelPendingToolStripMenuItem"
		Me.CancelPendingToolStripMenuItem.Size = New System.Drawing.Size(157, 22)
		Me.CancelPendingToolStripMenuItem.Text = "Cancel Pending"
		Me.CancelPendingToolStripMenuItem.Visible = False
		'
		'frmApplicationUsers
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
		Me.ClientSize = New System.Drawing.Size(1003, 656)
		Me.Controls.Add(Me.pnlPrimaryContent)
		Me.Controls.Add(Me.ToolStrip1)
		Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
		Me.MinimumSize = New System.Drawing.Size(996, 675)
		Me.Name = "frmApplicationUsers"
		Me.ShowInTaskbar = False
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.Text = "Application Users"
		Me.ToolStrip1.ResumeLayout(False)
		Me.ToolStrip1.PerformLayout()
		Me.pnlPrimaryContent.ResumeLayout(False)
		Me.grpUserInfo.ResumeLayout(False)
		Me.pnlUserInfo.ResumeLayout(False)
		Me.pnlUserInfo.PerformLayout()
		Me.pnlSecurityGroups.ResumeLayout(False)
		Me.pnlSecurityGroups.PerformLayout()
		Me.grpCurrentPermission.ResumeLayout(False)
		CType(Me.dgvUserPermissionsTo, System.ComponentModel.ISupportInitialize).EndInit()
		Me.grpAvailablePermissions.ResumeLayout(False)
		CType(Me.dgvUserPermissionsFrom, System.ComponentModel.ISupportInitialize).EndInit()
		Me.pnlUserActions.ResumeLayout(False)
		Me.pnlUserActions.PerformLayout()
		CType(Me.dgvUsers, System.ComponentModel.ISupportInitialize).EndInit()
		Me.cmCancelPending.ResumeLayout(False)
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Public WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Public WithEvents btnConnect As System.Windows.Forms.ToolStripButton
    Friend WithEvents dgvUsers As System.Windows.Forms.DataGridView
    Friend WithEvents pnlUserActions As System.Windows.Forms.Panel
    Friend WithEvents btnNext As System.Windows.Forms.Button
    Friend WithEvents chkSearchMatchCase As System.Windows.Forms.CheckBox
    Friend WithEvents lblSearchOf As System.Windows.Forms.Label
    Friend WithEvents cboSearchPart As System.Windows.Forms.ComboBox
    Friend WithEvents cboSearchColumn As System.Windows.Forms.ComboBox
    Friend WithEvents txtSearch As DDTToolbox.ExtTextBox
    Friend WithEvents lblSearchFor As System.Windows.Forms.Label
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents btnNewUserEmail As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnRefresh As System.Windows.Forms.Button
    Friend WithEvents btnPending As System.Windows.Forms.Button
    Friend WithEvents btnEdit As System.Windows.Forms.Button
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents lblUserCount As System.Windows.Forms.Label
    Friend WithEvents grpUserInfo As System.Windows.Forms.GroupBox
    Friend WithEvents lblEditMode As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lblSecurityDDTGroups As System.Windows.Forms.Label
    Friend WithEvents pnlSecurityGroups As System.Windows.Forms.Panel
    Friend WithEvents pnlUserInfo As System.Windows.Forms.Panel
    Friend WithEvents lblWITSOrganization As System.Windows.Forms.Label
    Friend WithEvents txtWITSOrganization As DDTToolbox.ExtTextBox
    Friend WithEvents txtWITSCompany As DDTToolbox.ExtTextBox
    Friend WithEvents txtWITSLocation As DDTToolbox.ExtTextBox
    Friend WithEvents txtTitle As DDTToolbox.ExtTextBox
    Friend WithEvents txtEmployeeNum As DDTToolbox.ExtTextBox
    Friend WithEvents txtLastName As DDTToolbox.ExtTextBox
    Friend WithEvents txtFirstName As DDTToolbox.ExtTextBox
    Friend WithEvents txtUserID As DDTToolbox.ExtTextBox
    Friend WithEvents lblWITSCompany As System.Windows.Forms.Label
    Friend WithEvents lblWITSLocation As System.Windows.Forms.Label
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents lblEmployeeNum As System.Windows.Forms.Label
    Friend WithEvents lblLastName As System.Windows.Forms.Label
    Friend WithEvents lblFirstName As System.Windows.Forms.Label
    Friend WithEvents lblUserID As System.Windows.Forms.Label
    Friend WithEvents grpCurrentPermission As System.Windows.Forms.GroupBox
    Friend WithEvents dgvUserPermissionsFrom As System.Windows.Forms.DataGridView
    Friend WithEvents grpAvailablePermissions As System.Windows.Forms.GroupBox
    Friend WithEvents dgvUserPermissionsTo As System.Windows.Forms.DataGridView
    Friend WithEvents btnCopyFrom As System.Windows.Forms.Button
    Friend WithEvents btnCopyAllFrom As System.Windows.Forms.Button
    Friend WithEvents btnCopyTo As System.Windows.Forms.Button
    Friend WithEvents btnCopyAllTo As System.Windows.Forms.Button
    Friend WithEvents ADGroupAvailable As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lblCurrentADGroups As System.Windows.Forms.Label
    Friend WithEvents lblAvailADGroups As System.Windows.Forms.Label
    Friend WithEvents ADGroup As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cmCancelPending As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents CancelPendingToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lblJobType As System.Windows.Forms.Label
    Public WithEvents btnWFM As System.Windows.Forms.Button
    Public WithEvents btnNodeSecurity As System.Windows.Forms.Button
    Public WithEvents cboServer As System.Windows.Forms.ToolStripComboBox
    Public WithEvents pnlPrimaryContent As System.Windows.Forms.Panel
End Class
