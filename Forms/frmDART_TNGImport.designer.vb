<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDART_TNGImport
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
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDART_TNGImport))
		Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
		Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
		Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
		Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
		Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
		Me.cboServer = New System.Windows.Forms.ToolStripComboBox()
		Me.btnConnect = New System.Windows.Forms.ToolStripButton()
		Me.pnlPrimaryContent = New System.Windows.Forms.Panel()
		Me.btnRefresh = New System.Windows.Forms.Button()
		Me.tabImportMonitor = New System.Windows.Forms.TabControl()
		Me.tbpgImportLog = New System.Windows.Forms.TabPage()
		Me.chkRefreshToNow = New System.Windows.Forms.CheckBox()
		Me.tabImportsAndCalcs = New System.Windows.Forms.TabControl()
		Me.tbpgFileImports = New System.Windows.Forms.TabPage()
		Me.btnViewUnzipLog = New System.Windows.Forms.Button()
		Me.lblImportLogRecordCount = New System.Windows.Forms.Label()
		Me.dgvImportLog = New System.Windows.Forms.DataGridView()
		Me.btnImportLogNow = New System.Windows.Forms.Button()
		Me.Label9 = New System.Windows.Forms.Label()
		Me.rdoLogRelativeToFileCreation = New System.Windows.Forms.RadioButton()
		Me.rdoLogRelativeToImportInitiated = New System.Windows.Forms.RadioButton()
		Me.Label7 = New System.Windows.Forms.Label()
		Me.btnRefreshImportLog = New System.Windows.Forms.Button()
		Me.Label5 = New System.Windows.Forms.Label()
		Me.Label3 = New System.Windows.Forms.Label()
		Me.dtpEndDate = New System.Windows.Forms.DateTimePicker()
		Me.dtpEndTime = New System.Windows.Forms.DateTimePicker()
		Me.dtpStartDate = New System.Windows.Forms.DateTimePicker()
		Me.dtpStartTime = New System.Windows.Forms.DateTimePicker()
		Me.tbpgImportTypes = New System.Windows.Forms.TabPage()
		Me.dgvImportReportTypes = New System.Windows.Forms.DataGridView()
		Me.tbpgOther = New System.Windows.Forms.TabPage()
		Me.grpErrorLog = New System.Windows.Forms.GroupBox()
		Me.btnErrorLogDirectoryRefresh = New System.Windows.Forms.Button()
		Me.btnErrorLogDirectoryExplore = New System.Windows.Forms.Button()
		Me.statusErrorLog = New System.Windows.Forms.Label()
		Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
		Me.Panel1 = New System.Windows.Forms.Panel()
		Me.lblErrorLogDirectoryFileCount = New System.Windows.Forms.Label()
		Me.btnErrorLogDirectoryBrowse = New System.Windows.Forms.Button()
		Me.btnErrorLogDirectoryCancel = New System.Windows.Forms.Button()
		Me.btnErrorLogDirectorySave = New System.Windows.Forms.Button()
		Me.Button7 = New System.Windows.Forms.Button()
		Me.Label6 = New System.Windows.Forms.Label()
		Me.txtErrorLogDirectory = New DDTToolbox.ExtTextBox()
		Me.grpBadZip = New System.Windows.Forms.GroupBox()
		Me.btnBadZipDirectoryRefresh = New System.Windows.Forms.Button()
		Me.btnBadZipDirectoryExplore = New System.Windows.Forms.Button()
		Me.statusBadzipFiles = New System.Windows.Forms.Label()
		Me.Panel4 = New System.Windows.Forms.Panel()
		Me.lblBadZipDirectoryFileCount = New System.Windows.Forms.Label()
		Me.btnBadZipDirectoryBrowse = New System.Windows.Forms.Button()
		Me.btnBadZipDirectorySave = New System.Windows.Forms.Button()
		Me.btnBadZipDirectoryModify = New System.Windows.Forms.Button()
		Me.Label8 = New System.Windows.Forms.Label()
		Me.txtBadZipDirectory = New DDTToolbox.ExtTextBox()
		Me.Button6 = New System.Windows.Forms.Button()
		Me.grpStatus = New System.Windows.Forms.GroupBox()
		Me.btnOverrideImportedThruWorkOfDateRefresh = New System.Windows.Forms.Button()
		Me.btnOverrideImportedThruWorkOfDateCancel = New System.Windows.Forms.Button()
		Me.btnOverrideImportedThruWorkOfDate = New System.Windows.Forms.Button()
		Me.statusImportedThruDate = New System.Windows.Forms.Label()
		Me.lblImportedThruWorkOfDate = New System.Windows.Forms.Label()
		Me.Label10 = New System.Windows.Forms.Label()
		Me.dtpImportedThruWorkOfDate = New System.Windows.Forms.DateTimePicker()
		Me.tbpgPostImportCalcs = New System.Windows.Forms.TabPage()
		Me.tabPostImportCalcs = New System.Windows.Forms.TabControl()
		Me.tbPgPostImport = New System.Windows.Forms.TabPage()
		Me.dgvPostImportCalcs = New System.Windows.Forms.DataGridView()
		Me.tbpgMonthlyCompiles = New System.Windows.Forms.TabPage()
		Me.tabMonthlyCompiles = New System.Windows.Forms.TabControl()
		Me.tbpgMonthly_Compiles = New System.Windows.Forms.TabPage()
		Me.dgvCompiles = New System.Windows.Forms.DataGridView()
		Me.Label4 = New System.Windows.Forms.Label()
		Me.MyFolderBrowser = New System.Windows.Forms.FolderBrowserDialog()
		Me.MyFileBrowser = New System.Windows.Forms.OpenFileDialog()
		Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
		Me.ToolStrip1.SuspendLayout()
		Me.pnlPrimaryContent.SuspendLayout()
		Me.tabImportMonitor.SuspendLayout()
		Me.tbpgImportLog.SuspendLayout()
		Me.tabImportsAndCalcs.SuspendLayout()
		Me.tbpgFileImports.SuspendLayout()
		CType(Me.dgvImportLog, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.tbpgImportTypes.SuspendLayout()
		CType(Me.dgvImportReportTypes, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.tbpgOther.SuspendLayout()
		Me.grpErrorLog.SuspendLayout()
		Me.grpBadZip.SuspendLayout()
		Me.grpStatus.SuspendLayout()
		Me.tbpgPostImportCalcs.SuspendLayout()
		Me.tabPostImportCalcs.SuspendLayout()
		Me.tbPgPostImport.SuspendLayout()
		CType(Me.dgvPostImportCalcs, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.tbpgMonthlyCompiles.SuspendLayout()
		Me.tabMonthlyCompiles.SuspendLayout()
		Me.tbpgMonthly_Compiles.SuspendLayout()
		CType(Me.dgvCompiles, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.SuspendLayout()
		'
		'ToolStrip1
		'
		Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel1, Me.cboServer, Me.btnConnect})
		Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
		Me.ToolStrip1.Name = "ToolStrip1"
		Me.ToolStrip1.Size = New System.Drawing.Size(918, 25)
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
		Me.pnlPrimaryContent.Controls.Add(Me.btnRefresh)
		Me.pnlPrimaryContent.Controls.Add(Me.tabImportMonitor)
		Me.pnlPrimaryContent.Dock = System.Windows.Forms.DockStyle.Fill
		Me.pnlPrimaryContent.Location = New System.Drawing.Point(0, 25)
		Me.pnlPrimaryContent.Name = "pnlPrimaryContent"
		Me.pnlPrimaryContent.Size = New System.Drawing.Size(918, 619)
		Me.pnlPrimaryContent.TabIndex = 1
		'
		'btnRefresh
		'
		Me.btnRefresh.Location = New System.Drawing.Point(661, 3)
		Me.btnRefresh.Name = "btnRefresh"
		Me.btnRefresh.Size = New System.Drawing.Size(114, 24)
		Me.btnRefresh.TabIndex = 12
		Me.btnRefresh.Text = "Refresh All"
		Me.btnRefresh.UseVisualStyleBackColor = True
		'
		'tabImportMonitor
		'
		Me.tabImportMonitor.Controls.Add(Me.tbpgImportLog)
		Me.tabImportMonitor.Controls.Add(Me.tbpgImportTypes)
		Me.tabImportMonitor.Controls.Add(Me.tbpgOther)
		Me.tabImportMonitor.Controls.Add(Me.tbpgPostImportCalcs)
		Me.tabImportMonitor.Controls.Add(Me.tbpgMonthlyCompiles)
		Me.tabImportMonitor.ImageList = Me.ImageList1
		Me.tabImportMonitor.Location = New System.Drawing.Point(3, 9)
		Me.tabImportMonitor.Name = "tabImportMonitor"
		Me.tabImportMonitor.SelectedIndex = 0
		Me.tabImportMonitor.Size = New System.Drawing.Size(914, 529)
		Me.tabImportMonitor.TabIndex = 9
		'
		'tbpgImportLog
		'
		Me.tbpgImportLog.AutoScroll = True
		Me.tbpgImportLog.BackColor = System.Drawing.SystemColors.Control
		Me.tbpgImportLog.Controls.Add(Me.chkRefreshToNow)
		Me.tbpgImportLog.Controls.Add(Me.tabImportsAndCalcs)
		Me.tbpgImportLog.Controls.Add(Me.btnImportLogNow)
		Me.tbpgImportLog.Controls.Add(Me.Label9)
		Me.tbpgImportLog.Controls.Add(Me.rdoLogRelativeToFileCreation)
		Me.tbpgImportLog.Controls.Add(Me.rdoLogRelativeToImportInitiated)
		Me.tbpgImportLog.Controls.Add(Me.Label7)
		Me.tbpgImportLog.Controls.Add(Me.btnRefreshImportLog)
		Me.tbpgImportLog.Controls.Add(Me.Label5)
		Me.tbpgImportLog.Controls.Add(Me.Label3)
		Me.tbpgImportLog.Controls.Add(Me.dtpEndDate)
		Me.tbpgImportLog.Controls.Add(Me.dtpEndTime)
		Me.tbpgImportLog.Controls.Add(Me.dtpStartDate)
		Me.tbpgImportLog.Controls.Add(Me.dtpStartTime)
		Me.tbpgImportLog.Location = New System.Drawing.Point(4, 24)
		Me.tbpgImportLog.Name = "tbpgImportLog"
		Me.tbpgImportLog.Padding = New System.Windows.Forms.Padding(3)
		Me.tbpgImportLog.Size = New System.Drawing.Size(906, 501)
		Me.tbpgImportLog.TabIndex = 0
		Me.tbpgImportLog.Text = "Import Log"
		'
		'chkRefreshToNow
		'
		Me.chkRefreshToNow.AutoSize = True
		Me.chkRefreshToNow.Checked = True
		Me.chkRefreshToNow.CheckState = System.Windows.Forms.CheckState.Checked
		Me.chkRefreshToNow.Location = New System.Drawing.Point(699, 25)
		Me.chkRefreshToNow.Name = "chkRefreshToNow"
		Me.chkRefreshToNow.Size = New System.Drawing.Size(117, 19)
		Me.chkRefreshToNow.TabIndex = 24
		Me.chkRefreshToNow.Text = "Refresh to ""Now"""
		Me.chkRefreshToNow.UseVisualStyleBackColor = True
		'
		'tabImportsAndCalcs
		'
		Me.tabImportsAndCalcs.Controls.Add(Me.tbpgFileImports)
		Me.tabImportsAndCalcs.Location = New System.Drawing.Point(5, 62)
		Me.tabImportsAndCalcs.Margin = New System.Windows.Forms.Padding(0)
		Me.tabImportsAndCalcs.Name = "tabImportsAndCalcs"
		Me.tabImportsAndCalcs.SelectedIndex = 0
		Me.tabImportsAndCalcs.Size = New System.Drawing.Size(763, 441)
		Me.tabImportsAndCalcs.TabIndex = 23
		'
		'tbpgFileImports
		'
		Me.tbpgFileImports.BackColor = System.Drawing.SystemColors.Control
		Me.tbpgFileImports.Controls.Add(Me.btnViewUnzipLog)
		Me.tbpgFileImports.Controls.Add(Me.lblImportLogRecordCount)
		Me.tbpgFileImports.Controls.Add(Me.dgvImportLog)
		Me.tbpgFileImports.Location = New System.Drawing.Point(4, 24)
		Me.tbpgFileImports.Name = "tbpgFileImports"
		Me.tbpgFileImports.Padding = New System.Windows.Forms.Padding(3)
		Me.tbpgFileImports.Size = New System.Drawing.Size(755, 413)
		Me.tbpgFileImports.TabIndex = 0
		Me.tbpgFileImports.Text = "File Imports"
		'
		'btnViewUnzipLog
		'
		Me.btnViewUnzipLog.Location = New System.Drawing.Point(645, 351)
		Me.btnViewUnzipLog.Name = "btnViewUnzipLog"
		Me.btnViewUnzipLog.Size = New System.Drawing.Size(92, 23)
		Me.btnViewUnzipLog.TabIndex = 20
		Me.btnViewUnzipLog.Text = "View Unzip Log"
		Me.btnViewUnzipLog.UseVisualStyleBackColor = True
		Me.btnViewUnzipLog.Visible = False
		'
		'lblImportLogRecordCount
		'
		Me.lblImportLogRecordCount.AutoSize = True
		Me.lblImportLogRecordCount.Location = New System.Drawing.Point(-1, 368)
		Me.lblImportLogRecordCount.Name = "lblImportLogRecordCount"
		Me.lblImportLogRecordCount.Size = New System.Drawing.Size(61, 15)
		Me.lblImportLogRecordCount.TabIndex = 18
		Me.lblImportLogRecordCount.Text = "xx records"
		'
		'dgvImportLog
		'
		Me.dgvImportLog.AllowUserToAddRows = False
		Me.dgvImportLog.AllowUserToDeleteRows = False
		Me.dgvImportLog.AllowUserToOrderColumns = True
		Me.dgvImportLog.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
		Me.dgvImportLog.BackgroundColor = System.Drawing.SystemColors.Control
		Me.dgvImportLog.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
		DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
		DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
		DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
		DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
		DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
		Me.dgvImportLog.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
		Me.dgvImportLog.Location = New System.Drawing.Point(0, -1)
		Me.dgvImportLog.Margin = New System.Windows.Forms.Padding(0)
		Me.dgvImportLog.Name = "dgvImportLog"
		Me.dgvImportLog.ReadOnly = True
		Me.dgvImportLog.RowHeadersVisible = False
		Me.dgvImportLog.RowTemplate.Height = 18
		Me.dgvImportLog.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
		Me.dgvImportLog.ShowCellToolTips = False
		Me.dgvImportLog.Size = New System.Drawing.Size(737, 349)
		Me.dgvImportLog.TabIndex = 17
		'
		'btnImportLogNow
		'
		Me.btnImportLogNow.Location = New System.Drawing.Point(320, 29)
		Me.btnImportLogNow.Name = "btnImportLogNow"
		Me.btnImportLogNow.Size = New System.Drawing.Size(52, 21)
		Me.btnImportLogNow.TabIndex = 22
		Me.btnImportLogNow.Text = "<- Now"
		Me.btnImportLogNow.UseVisualStyleBackColor = True
		'
		'Label9
		'
		Me.Label9.AutoSize = True
		Me.Label9.Location = New System.Drawing.Point(27, 13)
		Me.Label9.Name = "Label9"
		Me.Label9.Size = New System.Drawing.Size(93, 15)
		Me.Label9.TabIndex = 21
		Me.Label9.Text = "Display records :"
		'
		'rdoLogRelativeToFileCreation
		'
		Me.rdoLogRelativeToFileCreation.AutoSize = True
		Me.rdoLogRelativeToFileCreation.Location = New System.Drawing.Point(489, 32)
		Me.rdoLogRelativeToFileCreation.Name = "rdoLogRelativeToFileCreation"
		Me.rdoLogRelativeToFileCreation.Size = New System.Drawing.Size(89, 19)
		Me.rdoLogRelativeToFileCreation.TabIndex = 19
		Me.rdoLogRelativeToFileCreation.Text = "File creation"
		Me.rdoLogRelativeToFileCreation.UseVisualStyleBackColor = True
		'
		'rdoLogRelativeToImportInitiated
		'
		Me.rdoLogRelativeToImportInitiated.AutoSize = True
		Me.rdoLogRelativeToImportInitiated.Checked = True
		Me.rdoLogRelativeToImportInitiated.Location = New System.Drawing.Point(489, 13)
		Me.rdoLogRelativeToImportInitiated.Name = "rdoLogRelativeToImportInitiated"
		Me.rdoLogRelativeToImportInitiated.Size = New System.Drawing.Size(107, 19)
		Me.rdoLogRelativeToImportInitiated.TabIndex = 18
		Me.rdoLogRelativeToImportInitiated.TabStop = True
		Me.rdoLogRelativeToImportInitiated.Text = "Import initiated"
		Me.rdoLogRelativeToImportInitiated.UseVisualStyleBackColor = True
		'
		'Label7
		'
		Me.Label7.AutoSize = True
		Me.Label7.Location = New System.Drawing.Point(397, 13)
		Me.Label7.Name = "Label7"
		Me.Label7.Size = New System.Drawing.Size(94, 15)
		Me.Label7.TabIndex = 17
		Me.Label7.Text = "Time relative to :"
		'
		'btnRefreshImportLog
		'
		Me.btnRefreshImportLog.Location = New System.Drawing.Point(608, 20)
		Me.btnRefreshImportLog.Name = "btnRefreshImportLog"
		Me.btnRefreshImportLog.Size = New System.Drawing.Size(73, 24)
		Me.btnRefreshImportLog.TabIndex = 14
		Me.btnRefreshImportLog.Text = "Refresh"
		Me.btnRefreshImportLog.UseVisualStyleBackColor = True
		'
		'Label5
		'
		Me.Label5.AutoSize = True
		Me.Label5.Location = New System.Drawing.Point(122, 33)
		Me.Label5.Name = "Label5"
		Me.Label5.Size = New System.Drawing.Size(19, 15)
		Me.Label5.TabIndex = 13
		Me.Label5.Text = "To"
		'
		'Label3
		'
		Me.Label3.AutoSize = True
		Me.Label3.Location = New System.Drawing.Point(112, 13)
		Me.Label3.Name = "Label3"
		Me.Label3.Size = New System.Drawing.Size(35, 15)
		Me.Label3.TabIndex = 12
		Me.Label3.Text = "From"
		'
		'dtpEndDate
		'
		Me.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
		Me.dtpEndDate.Location = New System.Drawing.Point(148, 29)
		Me.dtpEndDate.Name = "dtpEndDate"
		Me.dtpEndDate.Size = New System.Drawing.Size(86, 23)
		Me.dtpEndDate.TabIndex = 11
		'
		'dtpEndTime
		'
		Me.dtpEndTime.Format = System.Windows.Forms.DateTimePickerFormat.Time
		Me.dtpEndTime.Location = New System.Drawing.Point(233, 29)
		Me.dtpEndTime.Name = "dtpEndTime"
		Me.dtpEndTime.ShowUpDown = True
		Me.dtpEndTime.Size = New System.Drawing.Size(86, 23)
		Me.dtpEndTime.TabIndex = 10
		'
		'dtpStartDate
		'
		Me.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
		Me.dtpStartDate.Location = New System.Drawing.Point(148, 10)
		Me.dtpStartDate.Name = "dtpStartDate"
		Me.dtpStartDate.Size = New System.Drawing.Size(86, 23)
		Me.dtpStartDate.TabIndex = 9
		'
		'dtpStartTime
		'
		Me.dtpStartTime.Format = System.Windows.Forms.DateTimePickerFormat.Time
		Me.dtpStartTime.Location = New System.Drawing.Point(233, 10)
		Me.dtpStartTime.Name = "dtpStartTime"
		Me.dtpStartTime.ShowUpDown = True
		Me.dtpStartTime.Size = New System.Drawing.Size(86, 23)
		Me.dtpStartTime.TabIndex = 8
		'
		'tbpgImportTypes
		'
		Me.tbpgImportTypes.Controls.Add(Me.dgvImportReportTypes)
		Me.tbpgImportTypes.Location = New System.Drawing.Point(4, 24)
		Me.tbpgImportTypes.Name = "tbpgImportTypes"
		Me.tbpgImportTypes.Padding = New System.Windows.Forms.Padding(3)
		Me.tbpgImportTypes.Size = New System.Drawing.Size(906, 501)
		Me.tbpgImportTypes.TabIndex = 6
		Me.tbpgImportTypes.Text = "Import File Types"
		Me.tbpgImportTypes.UseVisualStyleBackColor = True
		'
		'dgvImportReportTypes
		'
		Me.dgvImportReportTypes.AllowUserToAddRows = False
		Me.dgvImportReportTypes.AllowUserToDeleteRows = False
		Me.dgvImportReportTypes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
		Me.dgvImportReportTypes.BackgroundColor = System.Drawing.Color.White
		Me.dgvImportReportTypes.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.dgvImportReportTypes.Location = New System.Drawing.Point(0, 2)
		Me.dgvImportReportTypes.MultiSelect = False
		Me.dgvImportReportTypes.Name = "dgvImportReportTypes"
		Me.dgvImportReportTypes.ReadOnly = True
		Me.dgvImportReportTypes.RowHeadersVisible = False
		Me.dgvImportReportTypes.RowTemplate.Height = 18
		Me.dgvImportReportTypes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
		Me.dgvImportReportTypes.Size = New System.Drawing.Size(751, 356)
		Me.dgvImportReportTypes.TabIndex = 0
		'
		'tbpgOther
		'
		Me.tbpgOther.Controls.Add(Me.grpErrorLog)
		Me.tbpgOther.Controls.Add(Me.grpBadZip)
		Me.tbpgOther.Controls.Add(Me.grpStatus)
		Me.tbpgOther.ImageIndex = 1
		Me.tbpgOther.Location = New System.Drawing.Point(4, 24)
		Me.tbpgOther.Name = "tbpgOther"
		Me.tbpgOther.Size = New System.Drawing.Size(906, 501)
		Me.tbpgOther.TabIndex = 8
		Me.tbpgOther.Text = "Other Errors"
		Me.tbpgOther.UseVisualStyleBackColor = True
		'
		'grpErrorLog
		'
		Me.grpErrorLog.Controls.Add(Me.btnErrorLogDirectoryRefresh)
		Me.grpErrorLog.Controls.Add(Me.btnErrorLogDirectoryExplore)
		Me.grpErrorLog.Controls.Add(Me.statusErrorLog)
		Me.grpErrorLog.Controls.Add(Me.Panel1)
		Me.grpErrorLog.Controls.Add(Me.lblErrorLogDirectoryFileCount)
		Me.grpErrorLog.Controls.Add(Me.btnErrorLogDirectoryBrowse)
		Me.grpErrorLog.Controls.Add(Me.btnErrorLogDirectoryCancel)
		Me.grpErrorLog.Controls.Add(Me.btnErrorLogDirectorySave)
		Me.grpErrorLog.Controls.Add(Me.Button7)
		Me.grpErrorLog.Controls.Add(Me.Label6)
		Me.grpErrorLog.Controls.Add(Me.txtErrorLogDirectory)
		Me.grpErrorLog.Location = New System.Drawing.Point(133, 299)
		Me.grpErrorLog.Name = "grpErrorLog"
		Me.grpErrorLog.Size = New System.Drawing.Size(474, 157)
		Me.grpErrorLog.TabIndex = 24
		Me.grpErrorLog.TabStop = False
		Me.grpErrorLog.Text = "Error Logs"
		'
		'btnErrorLogDirectoryRefresh
		'
		Me.btnErrorLogDirectoryRefresh.Location = New System.Drawing.Point(363, 79)
		Me.btnErrorLogDirectoryRefresh.Name = "btnErrorLogDirectoryRefresh"
		Me.btnErrorLogDirectoryRefresh.Size = New System.Drawing.Size(67, 24)
		Me.btnErrorLogDirectoryRefresh.TabIndex = 31
		Me.btnErrorLogDirectoryRefresh.Text = "Refresh"
		Me.btnErrorLogDirectoryRefresh.UseVisualStyleBackColor = True
		'
		'btnErrorLogDirectoryExplore
		'
		Me.btnErrorLogDirectoryExplore.Location = New System.Drawing.Point(363, 116)
		Me.btnErrorLogDirectoryExplore.Name = "btnErrorLogDirectoryExplore"
		Me.btnErrorLogDirectoryExplore.Size = New System.Drawing.Size(67, 24)
		Me.btnErrorLogDirectoryExplore.TabIndex = 30
		Me.btnErrorLogDirectoryExplore.Text = "Explore"
		Me.btnErrorLogDirectoryExplore.UseVisualStyleBackColor = True
		'
		'statusErrorLog
		'
		Me.statusErrorLog.ImageIndex = 0
		Me.statusErrorLog.ImageList = Me.ImageList1
		Me.statusErrorLog.Location = New System.Drawing.Point(38, 44)
		Me.statusErrorLog.Name = "statusErrorLog"
		Me.statusErrorLog.Size = New System.Drawing.Size(16, 16)
		Me.statusErrorLog.TabIndex = 29
		'
		'ImageList1
		'
		Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
		Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
		Me.ImageList1.Images.SetKeyName(0, "Greenlight2.ico")
		Me.ImageList1.Images.SetKeyName(1, "Redlight2.ico")
		'
		'Panel1
		'
		Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.Panel1.Location = New System.Drawing.Point(41, 66)
		Me.Panel1.Name = "Panel1"
		Me.Panel1.Size = New System.Drawing.Size(388, 1)
		Me.Panel1.TabIndex = 28
		'
		'lblErrorLogDirectoryFileCount
		'
		Me.lblErrorLogDirectoryFileCount.AutoSize = True
		Me.lblErrorLogDirectoryFileCount.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.lblErrorLogDirectoryFileCount.ImageIndex = 0
		Me.lblErrorLogDirectoryFileCount.Location = New System.Drawing.Point(55, 46)
		Me.lblErrorLogDirectoryFileCount.Name = "lblErrorLogDirectoryFileCount"
		Me.lblErrorLogDirectoryFileCount.Size = New System.Drawing.Size(182, 15)
		Me.lblErrorLogDirectoryFileCount.TabIndex = 27
		Me.lblErrorLogDirectoryFileCount.Text = "Files found in error log directory :"
		'
		'btnErrorLogDirectoryBrowse
		'
		Me.btnErrorLogDirectoryBrowse.Location = New System.Drawing.Point(325, 19)
		Me.btnErrorLogDirectoryBrowse.Name = "btnErrorLogDirectoryBrowse"
		Me.btnErrorLogDirectoryBrowse.Size = New System.Drawing.Size(67, 24)
		Me.btnErrorLogDirectoryBrowse.TabIndex = 26
		Me.btnErrorLogDirectoryBrowse.Text = "Browse..."
		Me.btnErrorLogDirectoryBrowse.UseVisualStyleBackColor = True
		Me.btnErrorLogDirectoryBrowse.Visible = False
		'
		'btnErrorLogDirectoryCancel
		'
		Me.btnErrorLogDirectoryCancel.Location = New System.Drawing.Point(165, 19)
		Me.btnErrorLogDirectoryCancel.Name = "btnErrorLogDirectoryCancel"
		Me.btnErrorLogDirectoryCancel.Size = New System.Drawing.Size(67, 24)
		Me.btnErrorLogDirectoryCancel.TabIndex = 25
		Me.btnErrorLogDirectoryCancel.Text = "Cancel"
		Me.btnErrorLogDirectoryCancel.UseVisualStyleBackColor = True
		Me.btnErrorLogDirectoryCancel.Visible = False
		'
		'btnErrorLogDirectorySave
		'
		Me.btnErrorLogDirectorySave.Location = New System.Drawing.Point(245, 19)
		Me.btnErrorLogDirectorySave.Name = "btnErrorLogDirectorySave"
		Me.btnErrorLogDirectorySave.Size = New System.Drawing.Size(67, 24)
		Me.btnErrorLogDirectorySave.TabIndex = 24
		Me.btnErrorLogDirectorySave.Text = "Save"
		Me.btnErrorLogDirectorySave.UseVisualStyleBackColor = True
		Me.btnErrorLogDirectorySave.Visible = False
		'
		'Button7
		'
		Me.Button7.Location = New System.Drawing.Point(85, 19)
		Me.Button7.Name = "Button7"
		Me.Button7.Size = New System.Drawing.Size(67, 24)
		Me.Button7.TabIndex = 23
		Me.Button7.Text = "Modify"
		Me.Button7.UseVisualStyleBackColor = True
		Me.Button7.Visible = False
		'
		'Label6
		'
		Me.Label6.AutoSize = True
		Me.Label6.Location = New System.Drawing.Point(19, 82)
		Me.Label6.Name = "Label6"
		Me.Label6.Size = New System.Drawing.Size(132, 15)
		Me.Label6.TabIndex = 22
		Me.Label6.Text = "Error logs file directory :"
		'
		'txtErrorLogDirectory
		'
		Me.txtErrorLogDirectory.Enabled = False
		Me.txtErrorLogDirectory.Location = New System.Drawing.Point(22, 100)
		Me.txtErrorLogDirectory.Name = "txtErrorLogDirectory"
		Me.txtErrorLogDirectory.Size = New System.Drawing.Size(327, 23)
		Me.txtErrorLogDirectory.TabIndex = 21
		'
		'grpBadZip
		'
		Me.grpBadZip.Controls.Add(Me.btnBadZipDirectoryRefresh)
		Me.grpBadZip.Controls.Add(Me.btnBadZipDirectoryExplore)
		Me.grpBadZip.Controls.Add(Me.statusBadzipFiles)
		Me.grpBadZip.Controls.Add(Me.Panel4)
		Me.grpBadZip.Controls.Add(Me.lblBadZipDirectoryFileCount)
		Me.grpBadZip.Controls.Add(Me.btnBadZipDirectoryBrowse)
		Me.grpBadZip.Controls.Add(Me.btnBadZipDirectorySave)
		Me.grpBadZip.Controls.Add(Me.btnBadZipDirectoryModify)
		Me.grpBadZip.Controls.Add(Me.Label8)
		Me.grpBadZip.Controls.Add(Me.txtBadZipDirectory)
		Me.grpBadZip.Controls.Add(Me.Button6)
		Me.grpBadZip.Location = New System.Drawing.Point(133, 133)
		Me.grpBadZip.Name = "grpBadZip"
		Me.grpBadZip.Size = New System.Drawing.Size(474, 154)
		Me.grpBadZip.TabIndex = 23
		Me.grpBadZip.TabStop = False
		Me.grpBadZip.Text = "Bad Zip Files"
		'
		'btnBadZipDirectoryRefresh
		'
		Me.btnBadZipDirectoryRefresh.Location = New System.Drawing.Point(363, 84)
		Me.btnBadZipDirectoryRefresh.Name = "btnBadZipDirectoryRefresh"
		Me.btnBadZipDirectoryRefresh.Size = New System.Drawing.Size(67, 24)
		Me.btnBadZipDirectoryRefresh.TabIndex = 31
		Me.btnBadZipDirectoryRefresh.Text = "Refresh"
		Me.btnBadZipDirectoryRefresh.UseVisualStyleBackColor = True
		'
		'btnBadZipDirectoryExplore
		'
		Me.btnBadZipDirectoryExplore.Location = New System.Drawing.Point(363, 122)
		Me.btnBadZipDirectoryExplore.Name = "btnBadZipDirectoryExplore"
		Me.btnBadZipDirectoryExplore.Size = New System.Drawing.Size(67, 24)
		Me.btnBadZipDirectoryExplore.TabIndex = 30
		Me.btnBadZipDirectoryExplore.Text = "Explore"
		Me.btnBadZipDirectoryExplore.UseVisualStyleBackColor = True
		'
		'statusBadzipFiles
		'
		Me.statusBadzipFiles.ImageIndex = 0
		Me.statusBadzipFiles.ImageList = Me.ImageList1
		Me.statusBadzipFiles.Location = New System.Drawing.Point(39, 53)
		Me.statusBadzipFiles.Name = "statusBadzipFiles"
		Me.statusBadzipFiles.Size = New System.Drawing.Size(16, 16)
		Me.statusBadzipFiles.TabIndex = 29
		'
		'Panel4
		'
		Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.Panel4.Location = New System.Drawing.Point(42, 77)
		Me.Panel4.Name = "Panel4"
		Me.Panel4.Size = New System.Drawing.Size(388, 1)
		Me.Panel4.TabIndex = 28
		'
		'lblBadZipDirectoryFileCount
		'
		Me.lblBadZipDirectoryFileCount.AutoSize = True
		Me.lblBadZipDirectoryFileCount.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.lblBadZipDirectoryFileCount.ImageIndex = 0
		Me.lblBadZipDirectoryFileCount.Location = New System.Drawing.Point(56, 55)
		Me.lblBadZipDirectoryFileCount.Name = "lblBadZipDirectoryFileCount"
		Me.lblBadZipDirectoryFileCount.Size = New System.Drawing.Size(175, 15)
		Me.lblBadZipDirectoryFileCount.TabIndex = 27
		Me.lblBadZipDirectoryFileCount.Text = "Files found in bad zip directory :"
		'
		'btnBadZipDirectoryBrowse
		'
		Me.btnBadZipDirectoryBrowse.Location = New System.Drawing.Point(325, 19)
		Me.btnBadZipDirectoryBrowse.Name = "btnBadZipDirectoryBrowse"
		Me.btnBadZipDirectoryBrowse.Size = New System.Drawing.Size(67, 24)
		Me.btnBadZipDirectoryBrowse.TabIndex = 26
		Me.btnBadZipDirectoryBrowse.Text = "Browse..."
		Me.btnBadZipDirectoryBrowse.UseVisualStyleBackColor = True
		Me.btnBadZipDirectoryBrowse.Visible = False
		'
		'btnBadZipDirectorySave
		'
		Me.btnBadZipDirectorySave.Location = New System.Drawing.Point(85, 19)
		Me.btnBadZipDirectorySave.Name = "btnBadZipDirectorySave"
		Me.btnBadZipDirectorySave.Size = New System.Drawing.Size(67, 24)
		Me.btnBadZipDirectorySave.TabIndex = 24
		Me.btnBadZipDirectorySave.Text = "Save"
		Me.btnBadZipDirectorySave.UseVisualStyleBackColor = True
		Me.btnBadZipDirectorySave.Visible = False
		'
		'btnBadZipDirectoryModify
		'
		Me.btnBadZipDirectoryModify.Location = New System.Drawing.Point(245, 19)
		Me.btnBadZipDirectoryModify.Name = "btnBadZipDirectoryModify"
		Me.btnBadZipDirectoryModify.Size = New System.Drawing.Size(67, 24)
		Me.btnBadZipDirectoryModify.TabIndex = 23
		Me.btnBadZipDirectoryModify.Text = "Modify"
		Me.btnBadZipDirectoryModify.UseVisualStyleBackColor = True
		Me.btnBadZipDirectoryModify.Visible = False
		'
		'Label8
		'
		Me.Label8.AutoSize = True
		Me.Label8.Location = New System.Drawing.Point(39, 84)
		Me.Label8.Name = "Label8"
		Me.Label8.Size = New System.Drawing.Size(122, 15)
		Me.Label8.TabIndex = 22
		Me.Label8.Text = "Bad Zip file directory :"
		'
		'txtBadZipDirectory
		'
		Me.txtBadZipDirectory.Enabled = False
		Me.txtBadZipDirectory.Location = New System.Drawing.Point(42, 100)
		Me.txtBadZipDirectory.Name = "txtBadZipDirectory"
		Me.txtBadZipDirectory.Size = New System.Drawing.Size(307, 23)
		Me.txtBadZipDirectory.TabIndex = 21
		'
		'Button6
		'
		Me.Button6.Enabled = False
		Me.Button6.Location = New System.Drawing.Point(165, 19)
		Me.Button6.Name = "Button6"
		Me.Button6.Size = New System.Drawing.Size(67, 24)
		Me.Button6.TabIndex = 25
		Me.Button6.Text = "Cancel"
		Me.Button6.UseVisualStyleBackColor = True
		Me.Button6.Visible = False
		'
		'grpStatus
		'
		Me.grpStatus.Controls.Add(Me.btnOverrideImportedThruWorkOfDateRefresh)
		Me.grpStatus.Controls.Add(Me.btnOverrideImportedThruWorkOfDateCancel)
		Me.grpStatus.Controls.Add(Me.btnOverrideImportedThruWorkOfDate)
		Me.grpStatus.Controls.Add(Me.statusImportedThruDate)
		Me.grpStatus.Controls.Add(Me.lblImportedThruWorkOfDate)
		Me.grpStatus.Controls.Add(Me.Label10)
		Me.grpStatus.Controls.Add(Me.dtpImportedThruWorkOfDate)
		Me.grpStatus.Location = New System.Drawing.Point(133, 14)
		Me.grpStatus.Name = "grpStatus"
		Me.grpStatus.Size = New System.Drawing.Size(474, 107)
		Me.grpStatus.TabIndex = 22
		Me.grpStatus.TabStop = False
		Me.grpStatus.Text = "Status"
		'
		'btnOverrideImportedThruWorkOfDateRefresh
		'
		Me.btnOverrideImportedThruWorkOfDateRefresh.Location = New System.Drawing.Point(290, 77)
		Me.btnOverrideImportedThruWorkOfDateRefresh.Name = "btnOverrideImportedThruWorkOfDateRefresh"
		Me.btnOverrideImportedThruWorkOfDateRefresh.Size = New System.Drawing.Size(61, 24)
		Me.btnOverrideImportedThruWorkOfDateRefresh.TabIndex = 48
		Me.btnOverrideImportedThruWorkOfDateRefresh.Text = "Refresh"
		Me.btnOverrideImportedThruWorkOfDateRefresh.UseVisualStyleBackColor = True
		'
		'btnOverrideImportedThruWorkOfDateCancel
		'
		Me.btnOverrideImportedThruWorkOfDateCancel.Location = New System.Drawing.Point(363, 47)
		Me.btnOverrideImportedThruWorkOfDateCancel.Name = "btnOverrideImportedThruWorkOfDateCancel"
		Me.btnOverrideImportedThruWorkOfDateCancel.Size = New System.Drawing.Size(61, 24)
		Me.btnOverrideImportedThruWorkOfDateCancel.TabIndex = 47
		Me.btnOverrideImportedThruWorkOfDateCancel.Text = "Cancel"
		Me.btnOverrideImportedThruWorkOfDateCancel.UseVisualStyleBackColor = True
		Me.btnOverrideImportedThruWorkOfDateCancel.Visible = False
		'
		'btnOverrideImportedThruWorkOfDate
		'
		Me.btnOverrideImportedThruWorkOfDate.Location = New System.Drawing.Point(290, 47)
		Me.btnOverrideImportedThruWorkOfDate.Name = "btnOverrideImportedThruWorkOfDate"
		Me.btnOverrideImportedThruWorkOfDate.Size = New System.Drawing.Size(61, 24)
		Me.btnOverrideImportedThruWorkOfDate.TabIndex = 46
		Me.btnOverrideImportedThruWorkOfDate.Text = "Override"
		Me.btnOverrideImportedThruWorkOfDate.UseVisualStyleBackColor = True
		'
		'statusImportedThruDate
		'
		Me.statusImportedThruDate.ImageIndex = 0
		Me.statusImportedThruDate.ImageList = Me.ImageList1
		Me.statusImportedThruDate.Location = New System.Drawing.Point(38, 51)
		Me.statusImportedThruDate.Name = "statusImportedThruDate"
		Me.statusImportedThruDate.Size = New System.Drawing.Size(16, 16)
		Me.statusImportedThruDate.TabIndex = 44
		'
		'lblImportedThruWorkOfDate
		'
		Me.lblImportedThruWorkOfDate.AutoSize = True
		Me.lblImportedThruWorkOfDate.Location = New System.Drawing.Point(191, 53)
		Me.lblImportedThruWorkOfDate.Name = "lblImportedThruWorkOfDate"
		Me.lblImportedThruWorkOfDate.Size = New System.Drawing.Size(65, 15)
		Me.lblImportedThruWorkOfDate.TabIndex = 43
		Me.lblImportedThruWorkOfDate.Text = "01/01/2007"
		'
		'Label10
		'
		Me.Label10.Location = New System.Drawing.Point(56, 53)
		Me.Label10.Name = "Label10"
		Me.Label10.Size = New System.Drawing.Size(137, 16)
		Me.Label10.TabIndex = 42
		Me.Label10.Text = "Imported thru work of date :"
		'
		'dtpImportedThruWorkOfDate
		'
		Me.dtpImportedThruWorkOfDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
		Me.dtpImportedThruWorkOfDate.Location = New System.Drawing.Point(193, 49)
		Me.dtpImportedThruWorkOfDate.Name = "dtpImportedThruWorkOfDate"
		Me.dtpImportedThruWorkOfDate.Size = New System.Drawing.Size(87, 23)
		Me.dtpImportedThruWorkOfDate.TabIndex = 45
		Me.dtpImportedThruWorkOfDate.Visible = False
		'
		'tbpgPostImportCalcs
		'
		Me.tbpgPostImportCalcs.Controls.Add(Me.tabPostImportCalcs)
		Me.tbpgPostImportCalcs.Location = New System.Drawing.Point(4, 24)
		Me.tbpgPostImportCalcs.Name = "tbpgPostImportCalcs"
		Me.tbpgPostImportCalcs.Padding = New System.Windows.Forms.Padding(3)
		Me.tbpgPostImportCalcs.Size = New System.Drawing.Size(906, 501)
		Me.tbpgPostImportCalcs.TabIndex = 9
		Me.tbpgPostImportCalcs.Text = "Post Import Processes"
		Me.tbpgPostImportCalcs.UseVisualStyleBackColor = True
		'
		'tabPostImportCalcs
		'
		Me.tabPostImportCalcs.Controls.Add(Me.tbPgPostImport)
		Me.tabPostImportCalcs.Location = New System.Drawing.Point(5, 16)
		Me.tabPostImportCalcs.Margin = New System.Windows.Forms.Padding(0)
		Me.tabPostImportCalcs.Name = "tabPostImportCalcs"
		Me.tabPostImportCalcs.SelectedIndex = 0
		Me.tabPostImportCalcs.Size = New System.Drawing.Size(847, 450)
		Me.tabPostImportCalcs.TabIndex = 24
		'
		'tbPgPostImport
		'
		Me.tbPgPostImport.Controls.Add(Me.dgvPostImportCalcs)
		Me.tbPgPostImport.Location = New System.Drawing.Point(4, 24)
		Me.tbPgPostImport.Name = "tbPgPostImport"
		Me.tbPgPostImport.Padding = New System.Windows.Forms.Padding(3)
		Me.tbPgPostImport.Size = New System.Drawing.Size(839, 422)
		Me.tbPgPostImport.TabIndex = 0
		Me.tbPgPostImport.Text = "Post Import Processes"
		Me.tbPgPostImport.UseVisualStyleBackColor = True
		'
		'dgvPostImportCalcs
		'
		Me.dgvPostImportCalcs.AllowUserToAddRows = False
		Me.dgvPostImportCalcs.AllowUserToDeleteRows = False
		Me.dgvPostImportCalcs.AllowUserToOrderColumns = True
		Me.dgvPostImportCalcs.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
		Me.dgvPostImportCalcs.BackgroundColor = System.Drawing.Color.White
		Me.dgvPostImportCalcs.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
		DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
		DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
		DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
		DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
		DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
		Me.dgvPostImportCalcs.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
		Me.dgvPostImportCalcs.Location = New System.Drawing.Point(13, 19)
		Me.dgvPostImportCalcs.Margin = New System.Windows.Forms.Padding(0)
		Me.dgvPostImportCalcs.Name = "dgvPostImportCalcs"
		Me.dgvPostImportCalcs.ReadOnly = True
		Me.dgvPostImportCalcs.RowHeadersVisible = False
		Me.dgvPostImportCalcs.RowTemplate.Height = 18
		Me.dgvPostImportCalcs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
		Me.dgvPostImportCalcs.ShowCellToolTips = False
		Me.dgvPostImportCalcs.Size = New System.Drawing.Size(811, 349)
		Me.dgvPostImportCalcs.TabIndex = 19
		'
		'tbpgMonthlyCompiles
		'
		Me.tbpgMonthlyCompiles.Controls.Add(Me.tabMonthlyCompiles)
		Me.tbpgMonthlyCompiles.Location = New System.Drawing.Point(4, 24)
		Me.tbpgMonthlyCompiles.Name = "tbpgMonthlyCompiles"
		Me.tbpgMonthlyCompiles.Size = New System.Drawing.Size(906, 501)
		Me.tbpgMonthlyCompiles.TabIndex = 10
		Me.tbpgMonthlyCompiles.Text = "Monthly Compiles"
		Me.tbpgMonthlyCompiles.UseVisualStyleBackColor = True
		'
		'tabMonthlyCompiles
		'
		Me.tabMonthlyCompiles.Controls.Add(Me.tbpgMonthly_Compiles)
		Me.tabMonthlyCompiles.Location = New System.Drawing.Point(5, 13)
		Me.tabMonthlyCompiles.Margin = New System.Windows.Forms.Padding(0)
		Me.tabMonthlyCompiles.Name = "tabMonthlyCompiles"
		Me.tabMonthlyCompiles.SelectedIndex = 0
		Me.tabMonthlyCompiles.Size = New System.Drawing.Size(896, 441)
		Me.tabMonthlyCompiles.TabIndex = 24
		'
		'tbpgMonthly_Compiles
		'
		Me.tbpgMonthly_Compiles.Controls.Add(Me.dgvCompiles)
		Me.tbpgMonthly_Compiles.Location = New System.Drawing.Point(4, 24)
		Me.tbpgMonthly_Compiles.Name = "tbpgMonthly_Compiles"
		Me.tbpgMonthly_Compiles.Padding = New System.Windows.Forms.Padding(3)
		Me.tbpgMonthly_Compiles.Size = New System.Drawing.Size(888, 413)
		Me.tbpgMonthly_Compiles.TabIndex = 0
		Me.tbpgMonthly_Compiles.Text = "Monthly Compiles"
		Me.tbpgMonthly_Compiles.UseVisualStyleBackColor = True
		'
		'dgvCompiles
		'
		Me.dgvCompiles.AllowUserToAddRows = False
		Me.dgvCompiles.AllowUserToDeleteRows = False
		Me.dgvCompiles.AllowUserToOrderColumns = True
		Me.dgvCompiles.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
		Me.dgvCompiles.BackgroundColor = System.Drawing.Color.White
		Me.dgvCompiles.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
		DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
		DataGridViewCellStyle3.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
		DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
		DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
		DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
		Me.dgvCompiles.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle3
		Me.dgvCompiles.Location = New System.Drawing.Point(7, 19)
		Me.dgvCompiles.Margin = New System.Windows.Forms.Padding(0)
		Me.dgvCompiles.Name = "dgvCompiles"
		Me.dgvCompiles.ReadOnly = True
		Me.dgvCompiles.RowHeadersVisible = False
		Me.dgvCompiles.RowTemplate.Height = 18
		Me.dgvCompiles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
		Me.dgvCompiles.ShowCellToolTips = False
		Me.dgvCompiles.Size = New System.Drawing.Size(878, 349)
		Me.dgvCompiles.TabIndex = 17
		'
		'Label4
		'
		Me.Label4.Location = New System.Drawing.Point(0, 0)
		Me.Label4.Name = "Label4"
		Me.Label4.Size = New System.Drawing.Size(100, 23)
		Me.Label4.TabIndex = 0
		'
		'MyFileBrowser
		'
		Me.MyFileBrowser.Filter = "|Text files|*.txt*|All files|*.*|"
		Me.MyFileBrowser.FilterIndex = 0
		'
		'Timer1
		'
		Me.Timer1.Interval = 60000
		'
		'frmDART_TNGImport
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
		Me.ClientSize = New System.Drawing.Size(918, 644)
		Me.Controls.Add(Me.pnlPrimaryContent)
		Me.Controls.Add(Me.ToolStrip1)
		Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
		Me.MinimumSize = New System.Drawing.Size(836, 300)
		Me.Name = "frmDART_TNGImport"
		Me.ShowInTaskbar = False
		Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.Text = "DART Pro Import Monitor"
		Me.ToolStrip1.ResumeLayout(False)
		Me.ToolStrip1.PerformLayout()
		Me.pnlPrimaryContent.ResumeLayout(False)
		Me.tabImportMonitor.ResumeLayout(False)
		Me.tbpgImportLog.ResumeLayout(False)
		Me.tbpgImportLog.PerformLayout()
		Me.tabImportsAndCalcs.ResumeLayout(False)
		Me.tbpgFileImports.ResumeLayout(False)
		Me.tbpgFileImports.PerformLayout()
		CType(Me.dgvImportLog, System.ComponentModel.ISupportInitialize).EndInit()
		Me.tbpgImportTypes.ResumeLayout(False)
		CType(Me.dgvImportReportTypes, System.ComponentModel.ISupportInitialize).EndInit()
		Me.tbpgOther.ResumeLayout(False)
		Me.grpErrorLog.ResumeLayout(False)
		Me.grpErrorLog.PerformLayout()
		Me.grpBadZip.ResumeLayout(False)
		Me.grpBadZip.PerformLayout()
		Me.grpStatus.ResumeLayout(False)
		Me.grpStatus.PerformLayout()
		Me.tbpgPostImportCalcs.ResumeLayout(False)
		Me.tabPostImportCalcs.ResumeLayout(False)
		Me.tbPgPostImport.ResumeLayout(False)
		CType(Me.dgvPostImportCalcs, System.ComponentModel.ISupportInitialize).EndInit()
		Me.tbpgMonthlyCompiles.ResumeLayout(False)
		Me.tabMonthlyCompiles.ResumeLayout(False)
		Me.tbpgMonthly_Compiles.ResumeLayout(False)
		CType(Me.dgvCompiles, System.ComponentModel.ISupportInitialize).EndInit()
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Public WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Public WithEvents btnConnect As System.Windows.Forms.ToolStripButton
    Friend WithEvents MyFolderBrowser As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents MyFileBrowser As System.Windows.Forms.OpenFileDialog
    'Friend WithEvents DDTDataSet As DDTToolbox.DDTDataSet
    'Friend WithEvents SGetImportFileStatsTableAdapter As DDTToolbox.DDTDataSetTableAdapters.sGetImportFileStatsTableAdapter
    Friend WithEvents btnRefresh As System.Windows.Forms.Button
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label4 As System.Windows.Forms.Label
    'Friend WithEvents SGetAMPMTravelCalcStatsBindingSource As System.Windows.Forms.BindingSource
    'Friend WithEvents SGetAMPMTravelCalcStatsTableAdapter As DDTToolbox.DDTDataSetTableAdapters.sGetAMPMTravelCalcStatsTableAdapter
    'Friend WithEvents SGetPMCUpdateStatsBindingSource As System.Windows.Forms.BindingSource
    'Friend WithEvents SGetPMCUpdateStatsTableAdapter As DDTToolbox.DDTDataSetTableAdapters.sGetPMCUpdateStatsTableAdapter
    'Friend WithEvents SGetCleanDataStatsTableAdapter As DDTToolbox.DDTDataSetTableAdapters.sGetCleanDataStatsTableAdapter
    'Friend WithEvents SGetCleanDataStatsBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents colImportType As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colErrors As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colFileSize As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colBytesRead As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn10 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn11 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn12 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colElapsedSecs As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    'Friend WithEvents SGetRouteStudyStageSummaryBindingSource As System.Windows.Forms.BindingSource
    'Friend WithEvents SGetRouteStudyStageSummaryTableAdapter As DDTToolbox.DDTDataSetTableAdapters.sGetRouteStudyStageSummaryTableAdapter
    'Friend WithEvents SScheduledReportsRetrieveTodaysBindingSource As System.Windows.Forms.BindingSource
    'Friend WithEvents SScheduledReportsRetrieveTodaysTableAdapter As DDTToolbox.DDTDataSetTableAdapters.sScheduledReportsRetrieveTodaysTableAdapter
    'Friend WithEvents SScheduledReportsLoginsRetrieveBindingSource As System.Windows.Forms.BindingSource
    'Friend WithEvents SScheduledReportsLoginsRetrieveTableAdapter As DDTToolbox.DDTDataSetTableAdapters.sScheduledReportsLoginsRetrieveTableAdapter
    'Friend WithEvents SDARTImportReportTypesRetrieveBindingSource As System.Windows.Forms.BindingSource
    'Friend WithEvents SDARTImportReportTypesRetrieveTableAdapter As DDTToolbox.DDTDataSetTableAdapters.sDARTImportReportTypesRetrieveTableAdapter
    Friend WithEvents DataGridViewTextBoxColumn60 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn61 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn65 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn66 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn59 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RecordCountDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RSIDDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents STATUSDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents tabImportMonitor As System.Windows.Forms.TabControl
    Friend WithEvents tbpgImportLog As System.Windows.Forms.TabPage
    Friend WithEvents chkRefreshToNow As System.Windows.Forms.CheckBox
    Friend WithEvents tabImportsAndCalcs As System.Windows.Forms.TabControl
    Friend WithEvents tbpgFileImports As System.Windows.Forms.TabPage
    Friend WithEvents btnViewUnzipLog As System.Windows.Forms.Button
    Friend WithEvents lblImportLogRecordCount As System.Windows.Forms.Label
    Friend WithEvents dgvImportLog As System.Windows.Forms.DataGridView
    Friend WithEvents btnImportLogNow As System.Windows.Forms.Button
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents rdoLogRelativeToFileCreation As System.Windows.Forms.RadioButton
    Friend WithEvents rdoLogRelativeToImportInitiated As System.Windows.Forms.RadioButton
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents btnRefreshImportLog As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents dtpEndDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpEndTime As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpStartDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpStartTime As System.Windows.Forms.DateTimePicker
    Friend WithEvents tbpgImportTypes As System.Windows.Forms.TabPage
    Friend WithEvents dgvImportReportTypes As System.Windows.Forms.DataGridView
    Protected Friend WithEvents tbpgOther As System.Windows.Forms.TabPage
    Friend WithEvents grpStatus As System.Windows.Forms.GroupBox
    Friend WithEvents btnOverrideImportedThruWorkOfDateRefresh As System.Windows.Forms.Button
    Friend WithEvents btnOverrideImportedThruWorkOfDateCancel As System.Windows.Forms.Button
    Friend WithEvents btnOverrideImportedThruWorkOfDate As System.Windows.Forms.Button
    Friend WithEvents statusImportedThruDate As System.Windows.Forms.Label
    Friend WithEvents lblImportedThruWorkOfDate As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents dtpImportedThruWorkOfDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents grpBadZip As System.Windows.Forms.GroupBox
    Friend WithEvents btnBadZipDirectoryRefresh As System.Windows.Forms.Button
    Friend WithEvents btnBadZipDirectoryExplore As System.Windows.Forms.Button
    Friend WithEvents statusBadzipFiles As System.Windows.Forms.Label
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents lblBadZipDirectoryFileCount As System.Windows.Forms.Label
    Friend WithEvents btnBadZipDirectoryBrowse As System.Windows.Forms.Button
    Friend WithEvents btnBadZipDirectorySave As System.Windows.Forms.Button
    Friend WithEvents btnBadZipDirectoryModify As System.Windows.Forms.Button
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtBadZipDirectory As DDTToolbox.ExtTextBox
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents grpErrorLog As System.Windows.Forms.GroupBox
    Friend WithEvents btnErrorLogDirectoryRefresh As System.Windows.Forms.Button
    Friend WithEvents btnErrorLogDirectoryExplore As System.Windows.Forms.Button
    Friend WithEvents statusErrorLog As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lblErrorLogDirectoryFileCount As System.Windows.Forms.Label
    Friend WithEvents btnErrorLogDirectoryBrowse As System.Windows.Forms.Button
    Friend WithEvents btnErrorLogDirectoryCancel As System.Windows.Forms.Button
    Friend WithEvents btnErrorLogDirectorySave As System.Windows.Forms.Button
    Friend WithEvents Button7 As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtErrorLogDirectory As DDTToolbox.ExtTextBox
    Public WithEvents cboServer As System.Windows.Forms.ToolStripComboBox
    Public WithEvents pnlPrimaryContent As System.Windows.Forms.Panel
    Friend WithEvents tbpgPostImportCalcs As System.Windows.Forms.TabPage
    Friend WithEvents tabPostImportCalcs As System.Windows.Forms.TabControl
    Friend WithEvents tbPgPostImport As System.Windows.Forms.TabPage
    Friend WithEvents tbpgMonthlyCompiles As System.Windows.Forms.TabPage
    Friend WithEvents tabMonthlyCompiles As System.Windows.Forms.TabControl
    Friend WithEvents tbpgMonthly_Compiles As System.Windows.Forms.TabPage
    Friend WithEvents dgvCompiles As System.Windows.Forms.DataGridView
    Friend WithEvents dgvPostImportCalcs As System.Windows.Forms.DataGridView
End Class
