<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDART_TNGScheduledReports
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
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDART_TNGScheduledReports))
		Me.pnlPrimaryContent = New System.Windows.Forms.Panel()
		Me.splScheduledReports = New System.Windows.Forms.SplitContainer()
		Me.dgvPackages = New DDTToolbox.ExtDataGridView()
		Me.splDetails = New System.Windows.Forms.SplitContainer()
		Me.dgvEmails = New System.Windows.Forms.DataGridView()
		Me.lblEmailDistribution = New System.Windows.Forms.Label()
		Me.dgvReportParams = New System.Windows.Forms.DataGridView()
		Me.lblReportParams = New System.Windows.Forms.Label()
		Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
		Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
		Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel()
		Me.grpMonitor = New System.Windows.Forms.GroupBox()
		Me.chkAutoScroll = New System.Windows.Forms.CheckBox()
		Me.lblSeconds = New System.Windows.Forms.Label()
		Me.chkAutoRefresh = New System.Windows.Forms.CheckBox()
		Me.Label1 = New System.Windows.Forms.Label()
		Me.cboTmrInterval = New System.Windows.Forms.ComboBox()
		Me.grpRuntimeOptions = New System.Windows.Forms.GroupBox()
		Me.cboReportPath = New System.Windows.Forms.ComboBox()
		Me.lblReportPath = New System.Windows.Forms.Label()
		Me.grpPackages = New System.Windows.Forms.GroupBox()
		Me.chkRefreshOnComplete = New System.Windows.Forms.CheckBox()
		Me.chkDetails = New System.Windows.Forms.CheckBox()
		Me.rbAllPackages = New System.Windows.Forms.RadioButton()
		Me.rbTodaysPackages = New System.Windows.Forms.RadioButton()
		Me.btnRefresh = New System.Windows.Forms.Button()
		Me.chkAllColumns = New System.Windows.Forms.CheckBox()
		Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
		Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
		Me.cboServer = New System.Windows.Forms.ToolStripComboBox()
		Me.btnConnect = New System.Windows.Forms.ToolStripButton()
		Me.tmrRefresh = New System.Windows.Forms.Timer(Me.components)
		Me.tmrProcessBox = New System.Windows.Forms.Timer(Me.components)
		Me.pnlPrimaryContent.SuspendLayout()
		CType(Me.splScheduledReports, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.splScheduledReports.Panel1.SuspendLayout()
		Me.splScheduledReports.Panel2.SuspendLayout()
		Me.splScheduledReports.SuspendLayout()
		CType(Me.dgvPackages, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.splDetails, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.splDetails.Panel1.SuspendLayout()
		Me.splDetails.Panel2.SuspendLayout()
		Me.splDetails.SuspendLayout()
		CType(Me.dgvEmails, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.dgvReportParams, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.StatusStrip1.SuspendLayout()
		Me.grpMonitor.SuspendLayout()
		Me.grpRuntimeOptions.SuspendLayout()
		Me.grpPackages.SuspendLayout()
		Me.ToolStrip1.SuspendLayout()
		Me.SuspendLayout()
		'
		'pnlPrimaryContent
		'
		Me.pnlPrimaryContent.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
			Or System.Windows.Forms.AnchorStyles.Left) _
			Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.pnlPrimaryContent.BackColor = System.Drawing.SystemColors.Control
		Me.pnlPrimaryContent.Controls.Add(Me.splScheduledReports)
		Me.pnlPrimaryContent.Controls.Add(Me.StatusStrip1)
		Me.pnlPrimaryContent.Controls.Add(Me.grpMonitor)
		Me.pnlPrimaryContent.Controls.Add(Me.grpRuntimeOptions)
		Me.pnlPrimaryContent.Controls.Add(Me.grpPackages)
		Me.pnlPrimaryContent.Location = New System.Drawing.Point(0, 25)
		Me.pnlPrimaryContent.Name = "pnlPrimaryContent"
		Me.pnlPrimaryContent.Size = New System.Drawing.Size(1050, 483)
		Me.pnlPrimaryContent.TabIndex = 0
		'
		'splScheduledReports
		'
		Me.splScheduledReports.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
			Or System.Windows.Forms.AnchorStyles.Left) _
			Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.splScheduledReports.BackColor = System.Drawing.SystemColors.ActiveCaption
		Me.splScheduledReports.Location = New System.Drawing.Point(3, 92)
		Me.splScheduledReports.Name = "splScheduledReports"
		Me.splScheduledReports.Orientation = System.Windows.Forms.Orientation.Horizontal
		'
		'splScheduledReports.Panel1
		'
		Me.splScheduledReports.Panel1.Controls.Add(Me.dgvPackages)
		Me.splScheduledReports.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.No
		'
		'splScheduledReports.Panel2
		'
		Me.splScheduledReports.Panel2.Controls.Add(Me.splDetails)
		Me.splScheduledReports.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.splScheduledReports.Size = New System.Drawing.Size(1044, 366)
		Me.splScheduledReports.SplitterDistance = 213
		Me.splScheduledReports.SplitterWidth = 6
		Me.splScheduledReports.TabIndex = 23
		'
		'dgvPackages
		'
		Me.dgvPackages.AllowUserToAddRows = False
		Me.dgvPackages.AllowUserToDeleteRows = False
		Me.dgvPackages.AllowUserToOrderColumns = True
		Me.dgvPackages.AllowUserToResizeRows = False
		Me.dgvPackages.BackgroundColor = System.Drawing.SystemColors.Control
		Me.dgvPackages.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
		Me.dgvPackages.Dock = System.Windows.Forms.DockStyle.Fill
		Me.dgvPackages.Location = New System.Drawing.Point(0, 0)
		Me.dgvPackages.Name = "dgvPackages"
		Me.dgvPackages.ReadOnly = True
		Me.dgvPackages.RowHeaderNumbers = True
		Me.dgvPackages.RowHeaderNumbersLocationX = 8
		Me.dgvPackages.RowHeaderNumbersLocationY = 2
		Me.dgvPackages.RowHeadersWidth = 40
		Me.dgvPackages.RowTemplate.Height = 18
		Me.dgvPackages.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
		Me.dgvPackages.ShowCellToolTips = False
		Me.dgvPackages.Size = New System.Drawing.Size(1044, 213)
		Me.dgvPackages.TabIndex = 0
		'
		'splDetails
		'
		Me.splDetails.BackColor = System.Drawing.SystemColors.ActiveCaption
		Me.splDetails.Dock = System.Windows.Forms.DockStyle.Fill
		Me.splDetails.Location = New System.Drawing.Point(0, 0)
		Me.splDetails.Name = "splDetails"
		'
		'splDetails.Panel1
		'
		Me.splDetails.Panel1.BackColor = System.Drawing.SystemColors.Control
		Me.splDetails.Panel1.Controls.Add(Me.dgvEmails)
		Me.splDetails.Panel1.Controls.Add(Me.lblEmailDistribution)
		Me.splDetails.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.No
		'
		'splDetails.Panel2
		'
		Me.splDetails.Panel2.BackColor = System.Drawing.SystemColors.Control
		Me.splDetails.Panel2.Controls.Add(Me.dgvReportParams)
		Me.splDetails.Panel2.Controls.Add(Me.lblReportParams)
		Me.splDetails.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.splDetails.Size = New System.Drawing.Size(1044, 147)
		Me.splDetails.SplitterDistance = 266
		Me.splDetails.SplitterWidth = 6
		Me.splDetails.TabIndex = 9
		'
		'dgvEmails
		'
		Me.dgvEmails.AllowUserToDeleteRows = False
		Me.dgvEmails.AllowUserToResizeRows = False
		Me.dgvEmails.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
			Or System.Windows.Forms.AnchorStyles.Left) _
			Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.dgvEmails.BackgroundColor = System.Drawing.SystemColors.Control
		Me.dgvEmails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
		Me.dgvEmails.Location = New System.Drawing.Point(2, 21)
		Me.dgvEmails.Name = "dgvEmails"
		Me.dgvEmails.RowHeadersVisible = False
		Me.dgvEmails.RowHeadersWidth = 15
		Me.dgvEmails.RowTemplate.Height = 18
		Me.dgvEmails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
		Me.dgvEmails.ShowCellToolTips = False
		Me.dgvEmails.Size = New System.Drawing.Size(263, 125)
		Me.dgvEmails.TabIndex = 5
		'
		'lblEmailDistribution
		'
		Me.lblEmailDistribution.AutoSize = True
		Me.lblEmailDistribution.Location = New System.Drawing.Point(4, 5)
		Me.lblEmailDistribution.Name = "lblEmailDistribution"
		Me.lblEmailDistribution.Size = New System.Drawing.Size(101, 15)
		Me.lblEmailDistribution.TabIndex = 7
		Me.lblEmailDistribution.Text = "Email Distribution"
		'
		'dgvReportParams
		'
		Me.dgvReportParams.AllowUserToAddRows = False
		Me.dgvReportParams.AllowUserToDeleteRows = False
		Me.dgvReportParams.AllowUserToResizeRows = False
		Me.dgvReportParams.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
			Or System.Windows.Forms.AnchorStyles.Left) _
			Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.dgvReportParams.BackgroundColor = System.Drawing.SystemColors.Control
		Me.dgvReportParams.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
		Me.dgvReportParams.Location = New System.Drawing.Point(2, 21)
		Me.dgvReportParams.Name = "dgvReportParams"
		Me.dgvReportParams.ReadOnly = True
		Me.dgvReportParams.RowHeadersVisible = False
		Me.dgvReportParams.RowHeadersWidth = 15
		Me.dgvReportParams.RowTemplate.Height = 18
		Me.dgvReportParams.ShowCellToolTips = False
		Me.dgvReportParams.Size = New System.Drawing.Size(758, 125)
		Me.dgvReportParams.TabIndex = 6
		'
		'lblReportParams
		'
		Me.lblReportParams.AutoSize = True
		Me.lblReportParams.Location = New System.Drawing.Point(3, 5)
		Me.lblReportParams.Name = "lblReportParams"
		Me.lblReportParams.Size = New System.Drawing.Size(84, 15)
		Me.lblReportParams.TabIndex = 8
		Me.lblReportParams.Text = "Report Params"
		'
		'StatusStrip1
		'
		Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.ToolStripStatusLabel2})
		Me.StatusStrip1.Location = New System.Drawing.Point(0, 461)
		Me.StatusStrip1.Name = "StatusStrip1"
		Me.StatusStrip1.Size = New System.Drawing.Size(1050, 22)
		Me.StatusStrip1.TabIndex = 22
		Me.StatusStrip1.Text = "StatusStrip1"
		'
		'ToolStripStatusLabel1
		'
		Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
		Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(119, 17)
		Me.ToolStripStatusLabel1.Text = "ToolStripStatusLabel1"
		'
		'ToolStripStatusLabel2
		'
		Me.ToolStripStatusLabel2.Name = "ToolStripStatusLabel2"
		Me.ToolStripStatusLabel2.Size = New System.Drawing.Size(916, 17)
		Me.ToolStripStatusLabel2.Spring = True
		Me.ToolStripStatusLabel2.Text = "ToolStripStatusLabel2"
		Me.ToolStripStatusLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'grpMonitor
		'
		Me.grpMonitor.Controls.Add(Me.chkAutoScroll)
		Me.grpMonitor.Controls.Add(Me.lblSeconds)
		Me.grpMonitor.Controls.Add(Me.chkAutoRefresh)
		Me.grpMonitor.Controls.Add(Me.Label1)
		Me.grpMonitor.Controls.Add(Me.cboTmrInterval)
		Me.grpMonitor.Location = New System.Drawing.Point(682, 3)
		Me.grpMonitor.Name = "grpMonitor"
		Me.grpMonitor.Size = New System.Drawing.Size(129, 83)
		Me.grpMonitor.TabIndex = 21
		Me.grpMonitor.TabStop = False
		Me.grpMonitor.Text = "Monitor Options"
		'
		'chkAutoScroll
		'
		Me.chkAutoScroll.AutoSize = True
		Me.chkAutoScroll.Location = New System.Drawing.Point(20, 35)
		Me.chkAutoScroll.Name = "chkAutoScroll"
		Me.chkAutoScroll.Size = New System.Drawing.Size(84, 19)
		Me.chkAutoScroll.TabIndex = 31
		Me.chkAutoScroll.Text = "Auto Scroll"
		Me.chkAutoScroll.UseVisualStyleBackColor = True
		'
		'lblSeconds
		'
		Me.lblSeconds.AutoSize = True
		Me.lblSeconds.Location = New System.Drawing.Point(60, 59)
		Me.lblSeconds.Name = "lblSeconds"
		Me.lblSeconds.Size = New System.Drawing.Size(51, 15)
		Me.lblSeconds.TabIndex = 30
		Me.lblSeconds.Text = "Seconds"
		'
		'chkAutoRefresh
		'
		Me.chkAutoRefresh.AutoSize = True
		Me.chkAutoRefresh.Location = New System.Drawing.Point(20, 19)
		Me.chkAutoRefresh.Name = "chkAutoRefresh"
		Me.chkAutoRefresh.Size = New System.Drawing.Size(94, 19)
		Me.chkAutoRefresh.TabIndex = 1
		Me.chkAutoRefresh.Text = "Auto Refresh"
		Me.chkAutoRefresh.UseVisualStyleBackColor = True
		'
		'Label1
		'
		Me.Label1.AutoSize = True
		Me.Label1.Location = New System.Drawing.Point(115, 10)
		Me.Label1.Name = "Label1"
		Me.Label1.Size = New System.Drawing.Size(12, 15)
		Me.Label1.TabIndex = 29
		Me.Label1.Text = "-"
		Me.Label1.Visible = False
		'
		'cboTmrInterval
		'
		Me.cboTmrInterval.FormattingEnabled = True
		Me.cboTmrInterval.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "10", "30", "60"})
		Me.cboTmrInterval.Location = New System.Drawing.Point(20, 55)
		Me.cboTmrInterval.MaxDropDownItems = 10
		Me.cboTmrInterval.Name = "cboTmrInterval"
		Me.cboTmrInterval.Size = New System.Drawing.Size(37, 23)
		Me.cboTmrInterval.TabIndex = 0
		Me.cboTmrInterval.Text = "2"
		'
		'grpRuntimeOptions
		'
		Me.grpRuntimeOptions.Controls.Add(Me.cboReportPath)
		Me.grpRuntimeOptions.Controls.Add(Me.lblReportPath)
		Me.grpRuntimeOptions.Location = New System.Drawing.Point(277, 3)
		Me.grpRuntimeOptions.Name = "grpRuntimeOptions"
		Me.grpRuntimeOptions.Size = New System.Drawing.Size(387, 83)
		Me.grpRuntimeOptions.TabIndex = 20
		Me.grpRuntimeOptions.TabStop = False
		Me.grpRuntimeOptions.Text = "Runtime Options"
		'
		'cboReportPath
		'
		Me.cboReportPath.BackColor = System.Drawing.SystemColors.Control
		Me.cboReportPath.FormattingEnabled = True
		Me.cboReportPath.Location = New System.Drawing.Point(4, 51)
		Me.cboReportPath.Name = "cboReportPath"
		Me.cboReportPath.Size = New System.Drawing.Size(357, 23)
		Me.cboReportPath.TabIndex = 24
		'
		'lblReportPath
		'
		Me.lblReportPath.AutoSize = True
		Me.lblReportPath.Location = New System.Drawing.Point(6, 35)
		Me.lblReportPath.Name = "lblReportPath"
		Me.lblReportPath.Size = New System.Drawing.Size(125, 15)
		Me.lblReportPath.TabIndex = 23
		Me.lblReportPath.Text = "Schedule Reports Path"
		'
		'grpPackages
		'
		Me.grpPackages.Controls.Add(Me.chkRefreshOnComplete)
		Me.grpPackages.Controls.Add(Me.chkDetails)
		Me.grpPackages.Controls.Add(Me.rbAllPackages)
		Me.grpPackages.Controls.Add(Me.rbTodaysPackages)
		Me.grpPackages.Controls.Add(Me.btnRefresh)
		Me.grpPackages.Controls.Add(Me.chkAllColumns)
		Me.grpPackages.Location = New System.Drawing.Point(3, 3)
		Me.grpPackages.Name = "grpPackages"
		Me.grpPackages.Size = New System.Drawing.Size(268, 83)
		Me.grpPackages.TabIndex = 19
		Me.grpPackages.TabStop = False
		Me.grpPackages.Text = "Scheduled Packages"
		'
		'chkRefreshOnComplete
		'
		Me.chkRefreshOnComplete.AutoSize = True
		Me.chkRefreshOnComplete.Location = New System.Drawing.Point(140, 63)
		Me.chkRefreshOnComplete.Name = "chkRefreshOnComplete"
		Me.chkRefreshOnComplete.Size = New System.Drawing.Size(139, 19)
		Me.chkRefreshOnComplete.TabIndex = 12
		Me.chkRefreshOnComplete.Text = "Refresh On Complete"
		Me.chkRefreshOnComplete.UseVisualStyleBackColor = True
		'
		'chkDetails
		'
		Me.chkDetails.AutoSize = True
		Me.chkDetails.Checked = True
		Me.chkDetails.CheckState = System.Windows.Forms.CheckState.Checked
		Me.chkDetails.Location = New System.Drawing.Point(140, 37)
		Me.chkDetails.Name = "chkDetails"
		Me.chkDetails.Size = New System.Drawing.Size(118, 19)
		Me.chkDetails.TabIndex = 11
		Me.chkDetails.Text = "Show Detail Grids"
		Me.chkDetails.UseVisualStyleBackColor = True
		'
		'rbAllPackages
		'
		Me.rbAllPackages.AutoSize = True
		Me.rbAllPackages.Location = New System.Drawing.Point(15, 36)
		Me.rbAllPackages.Name = "rbAllPackages"
		Me.rbAllPackages.Size = New System.Drawing.Size(91, 19)
		Me.rbAllPackages.TabIndex = 1
		Me.rbAllPackages.Text = "All Packages"
		Me.rbAllPackages.UseVisualStyleBackColor = True
		'
		'rbTodaysPackages
		'
		Me.rbTodaysPackages.AutoSize = True
		Me.rbTodaysPackages.Checked = True
		Me.rbTodaysPackages.Location = New System.Drawing.Point(15, 18)
		Me.rbTodaysPackages.Name = "rbTodaysPackages"
		Me.rbTodaysPackages.Size = New System.Drawing.Size(110, 19)
		Me.rbTodaysPackages.TabIndex = 0
		Me.rbTodaysPackages.TabStop = True
		Me.rbTodaysPackages.Text = "TodaysPackages"
		Me.rbTodaysPackages.UseVisualStyleBackColor = True
		'
		'btnRefresh
		'
		Me.btnRefresh.Location = New System.Drawing.Point(32, 56)
		Me.btnRefresh.Name = "btnRefresh"
		Me.btnRefresh.Size = New System.Drawing.Size(64, 23)
		Me.btnRefresh.TabIndex = 10
		Me.btnRefresh.Text = "Refresh"
		Me.btnRefresh.UseVisualStyleBackColor = True
		'
		'chkAllColumns
		'
		Me.chkAllColumns.AutoSize = True
		Me.chkAllColumns.Location = New System.Drawing.Point(140, 18)
		Me.chkAllColumns.Name = "chkAllColumns"
		Me.chkAllColumns.Size = New System.Drawing.Size(112, 19)
		Me.chkAllColumns.TabIndex = 8
		Me.chkAllColumns.Text = "See All Columns"
		Me.chkAllColumns.UseVisualStyleBackColor = True
		'
		'ToolStrip1
		'
		Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel1, Me.cboServer, Me.btnConnect})
		Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
		Me.ToolStrip1.Name = "ToolStrip1"
		Me.ToolStrip1.Size = New System.Drawing.Size(1049, 25)
		Me.ToolStrip1.TabIndex = 3
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
		'tmrRefresh
		'
		'
		'tmrProcessBox
		'
		'
		'frmDART_TNGScheduledReports
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
		Me.ClientSize = New System.Drawing.Size(1049, 508)
		Me.Controls.Add(Me.ToolStrip1)
		Me.Controls.Add(Me.pnlPrimaryContent)
		Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
		Me.Name = "frmDART_TNGScheduledReports"
		Me.Text = "DART Pro Scheduled Reports"
		Me.pnlPrimaryContent.ResumeLayout(False)
		Me.pnlPrimaryContent.PerformLayout()
		Me.splScheduledReports.Panel1.ResumeLayout(False)
		Me.splScheduledReports.Panel2.ResumeLayout(False)
		CType(Me.splScheduledReports, System.ComponentModel.ISupportInitialize).EndInit()
		Me.splScheduledReports.ResumeLayout(False)
		CType(Me.dgvPackages, System.ComponentModel.ISupportInitialize).EndInit()
		Me.splDetails.Panel1.ResumeLayout(False)
		Me.splDetails.Panel1.PerformLayout()
		Me.splDetails.Panel2.ResumeLayout(False)
		Me.splDetails.Panel2.PerformLayout()
		CType(Me.splDetails, System.ComponentModel.ISupportInitialize).EndInit()
		Me.splDetails.ResumeLayout(False)
		CType(Me.dgvEmails, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.dgvReportParams, System.ComponentModel.ISupportInitialize).EndInit()
		Me.StatusStrip1.ResumeLayout(False)
		Me.StatusStrip1.PerformLayout()
		Me.grpMonitor.ResumeLayout(False)
		Me.grpMonitor.PerformLayout()
		Me.grpRuntimeOptions.ResumeLayout(False)
		Me.grpRuntimeOptions.PerformLayout()
		Me.grpPackages.ResumeLayout(False)
		Me.grpPackages.PerformLayout()
		Me.ToolStrip1.ResumeLayout(False)
		Me.ToolStrip1.PerformLayout()
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub
    Public WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Public WithEvents btnConnect As System.Windows.Forms.ToolStripButton
    Friend WithEvents splScheduledReports As System.Windows.Forms.SplitContainer
    Friend WithEvents dgvPackages As DDTToolbox.ExtDataGridView
    Friend WithEvents splDetails As System.Windows.Forms.SplitContainer
    Friend WithEvents dgvEmails As System.Windows.Forms.DataGridView
    Friend WithEvents lblEmailDistribution As System.Windows.Forms.Label
    Friend WithEvents dgvReportParams As System.Windows.Forms.DataGridView
    Friend WithEvents lblReportParams As System.Windows.Forms.Label
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel2 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents grpMonitor As System.Windows.Forms.GroupBox
    Friend WithEvents lblSeconds As System.Windows.Forms.Label
    Friend WithEvents chkAutoRefresh As System.Windows.Forms.CheckBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboTmrInterval As System.Windows.Forms.ComboBox
    Friend WithEvents grpRuntimeOptions As System.Windows.Forms.GroupBox
    Friend WithEvents cboReportPath As System.Windows.Forms.ComboBox
    Friend WithEvents lblReportPath As System.Windows.Forms.Label
    Friend WithEvents grpPackages As System.Windows.Forms.GroupBox
    Friend WithEvents chkRefreshOnComplete As System.Windows.Forms.CheckBox
    Friend WithEvents chkDetails As System.Windows.Forms.CheckBox
    Friend WithEvents rbAllPackages As System.Windows.Forms.RadioButton
    Friend WithEvents rbTodaysPackages As System.Windows.Forms.RadioButton
    Friend WithEvents btnRefresh As System.Windows.Forms.Button
    Friend WithEvents chkAllColumns As System.Windows.Forms.CheckBox
    Friend WithEvents tmrRefresh As System.Windows.Forms.Timer
    Friend WithEvents tmrProcessBox As System.Windows.Forms.Timer
    Friend WithEvents chkAutoScroll As System.Windows.Forms.CheckBox
    Public WithEvents cboServer As System.Windows.Forms.ToolStripComboBox
    Public WithEvents pnlPrimaryContent As System.Windows.Forms.Panel
End Class
