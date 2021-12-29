<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
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
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
		Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
		Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		Me.mnuFileExit = New System.Windows.Forms.ToolStripMenuItem()
		Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
		Me.DARTToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		Me.DARTTNGApplicationToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
		Me.DART_TNGImportMonitorToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		Me.DARTTngReportTreeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		Me.DARTTNGRetrieveReportParamsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		Me.ScheduleReportMonitorToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		Me.QARTSettingsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		Me.WorkforceManagerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		Me.WFMReportTreeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
		Me.ManagedADGroupsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		Me.ApplicationUsersToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		Me.TeamToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		Me.DevelopersToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		Me.SecurityloginAndPasswordTrackingToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		Me.ManageReportsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		Me.ToolStripMenuItem4 = New System.Windows.Forms.ToolStripSeparator()
		Me.ManageServerConnectionsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		Me.OptionsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
		Me.MyToolsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		Me.mnuWindowsOpen = New System.Windows.Forms.ToolStripMenuItem()
		Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		Me.ActiveDirectoryGroupsSQLServerRolesRelationshipsToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
		Me.DataContactsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		Me.mnuViewServerSQLAgentJobTaskSchedule = New System.Windows.Forms.ToolStripMenuItem()
		Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
		Me.VersionNotesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
		Me.lblStatusUser = New System.Windows.Forms.ToolStripStatusLabel()
		Me.lblCurrentDateTime = New System.Windows.Forms.ToolStripStatusLabel()
		Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
		Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
		Me.tsMyButtons = New System.Windows.Forms.ToolStrip()
		Me.imlToolbox = New System.Windows.Forms.ImageList(Me.components)
		Me.MenuStrip1.SuspendLayout()
		Me.StatusStrip1.SuspendLayout()
		Me.SuspendLayout()
		'
		'MenuStrip1
		'
		Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.ToolStripMenuItem1, Me.mnuWindowsOpen, Me.HelpToolStripMenuItem})
		Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
		Me.MenuStrip1.Name = "MenuStrip1"
		Me.MenuStrip1.Padding = New System.Windows.Forms.Padding(7, 2, 0, 2)
		Me.MenuStrip1.Size = New System.Drawing.Size(1185, 24)
		Me.MenuStrip1.TabIndex = 0
		Me.MenuStrip1.Text = "MenuStrip1"
		'
		'FileToolStripMenuItem
		'
		Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuFileExit})
		Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
		Me.FileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
		Me.FileToolStripMenuItem.Text = "File"
		'
		'mnuFileExit
		'
		Me.mnuFileExit.Name = "mnuFileExit"
		Me.mnuFileExit.Size = New System.Drawing.Size(92, 22)
		Me.mnuFileExit.Text = "Exit"
		'
		'ToolStripMenuItem1
		'
		Me.ToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DARTToolStripMenuItem, Me.QARTSettingsToolStripMenuItem, Me.WorkforceManagerToolStripMenuItem, Me.ToolStripSeparator3, Me.ManagedADGroupsToolStripMenuItem, Me.TeamToolStripMenuItem, Me.ManageReportsToolStripMenuItem, Me.ToolStripMenuItem4, Me.ManageServerConnectionsToolStripMenuItem, Me.OptionsToolStripMenuItem, Me.ToolStripSeparator1, Me.MyToolsToolStripMenuItem})
		Me.ToolStripMenuItem1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
		Me.ToolStripMenuItem1.Size = New System.Drawing.Size(47, 20)
		Me.ToolStripMenuItem1.Text = "Tools"
		'
		'DARTToolStripMenuItem
		'
		Me.DARTToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
		Me.DARTToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DARTTNGApplicationToolStripMenuItem1, Me.DART_TNGImportMonitorToolStripMenuItem, Me.DARTTngReportTreeToolStripMenuItem, Me.DARTTNGRetrieveReportParamsToolStripMenuItem, Me.ScheduleReportMonitorToolStripMenuItem})
		Me.DARTToolStripMenuItem.Name = "DARTToolStripMenuItem"
		Me.DARTToolStripMenuItem.Size = New System.Drawing.Size(228, 22)
		Me.DARTToolStripMenuItem.Text = "DART"
		'
		'DARTTNGApplicationToolStripMenuItem1
		'
		Me.DARTTNGApplicationToolStripMenuItem1.Name = "DARTTNGApplicationToolStripMenuItem1"
		Me.DARTTNGApplicationToolStripMenuItem1.Size = New System.Drawing.Size(211, 22)
		Me.DARTTNGApplicationToolStripMenuItem1.Text = "Application"
		'
		'DART_TNGImportMonitorToolStripMenuItem
		'
		Me.DART_TNGImportMonitorToolStripMenuItem.Name = "DART_TNGImportMonitorToolStripMenuItem"
		Me.DART_TNGImportMonitorToolStripMenuItem.Size = New System.Drawing.Size(211, 22)
		Me.DART_TNGImportMonitorToolStripMenuItem.Text = "Import Monitor"
		'
		'DARTTngReportTreeToolStripMenuItem
		'
		Me.DARTTngReportTreeToolStripMenuItem.Name = "DARTTngReportTreeToolStripMenuItem"
		Me.DARTTngReportTreeToolStripMenuItem.Size = New System.Drawing.Size(211, 22)
		Me.DARTTngReportTreeToolStripMenuItem.Text = "Report Tree"
		Me.DARTTngReportTreeToolStripMenuItem.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'DARTTNGRetrieveReportParamsToolStripMenuItem
		'
		Me.DARTTNGRetrieveReportParamsToolStripMenuItem.Name = "DARTTNGRetrieveReportParamsToolStripMenuItem"
		Me.DARTTNGRetrieveReportParamsToolStripMenuItem.Size = New System.Drawing.Size(211, 22)
		Me.DARTTNGRetrieveReportParamsToolStripMenuItem.Text = "Retrieve Report Params"
		'
		'ScheduleReportMonitorToolStripMenuItem
		'
		Me.ScheduleReportMonitorToolStripMenuItem.Name = "ScheduleReportMonitorToolStripMenuItem"
		Me.ScheduleReportMonitorToolStripMenuItem.Size = New System.Drawing.Size(211, 22)
		Me.ScheduleReportMonitorToolStripMenuItem.Text = "Schedule Reports Monitor"
		'
		'QARTSettingsToolStripMenuItem
		'
		Me.QARTSettingsToolStripMenuItem.Name = "QARTSettingsToolStripMenuItem"
		Me.QARTSettingsToolStripMenuItem.Size = New System.Drawing.Size(228, 22)
		Me.QARTSettingsToolStripMenuItem.Text = "QART"
		'
		'WorkforceManagerToolStripMenuItem
		'
		Me.WorkforceManagerToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.WFMReportTreeToolStripMenuItem})
		Me.WorkforceManagerToolStripMenuItem.Name = "WorkforceManagerToolStripMenuItem"
		Me.WorkforceManagerToolStripMenuItem.Size = New System.Drawing.Size(228, 22)
		Me.WorkforceManagerToolStripMenuItem.Text = "Workforce Manager"
		'
		'WFMReportTreeToolStripMenuItem
		'
		Me.WFMReportTreeToolStripMenuItem.Name = "WFMReportTreeToolStripMenuItem"
		Me.WFMReportTreeToolStripMenuItem.Size = New System.Drawing.Size(134, 22)
		Me.WFMReportTreeToolStripMenuItem.Text = "Report Tree"
		'
		'ToolStripSeparator3
		'
		Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
		Me.ToolStripSeparator3.Size = New System.Drawing.Size(225, 6)
		'
		'ManagedADGroupsToolStripMenuItem
		'
		Me.ManagedADGroupsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ApplicationUsersToolStripMenuItem})
		Me.ManagedADGroupsToolStripMenuItem.Name = "ManagedADGroupsToolStripMenuItem"
		Me.ManagedADGroupsToolStripMenuItem.Size = New System.Drawing.Size(228, 22)
		Me.ManagedADGroupsToolStripMenuItem.Text = "Managed AD Groups"
		'
		'ApplicationUsersToolStripMenuItem
		'
		Me.ApplicationUsersToolStripMenuItem.Name = "ApplicationUsersToolStripMenuItem"
		Me.ApplicationUsersToolStripMenuItem.Size = New System.Drawing.Size(166, 22)
		Me.ApplicationUsersToolStripMenuItem.Text = "Application Users"
		'
		'TeamToolStripMenuItem
		'
		Me.TeamToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DevelopersToolStripMenuItem, Me.SecurityloginAndPasswordTrackingToolStripMenuItem})
		Me.TeamToolStripMenuItem.Name = "TeamToolStripMenuItem"
		Me.TeamToolStripMenuItem.Size = New System.Drawing.Size(228, 22)
		Me.TeamToolStripMenuItem.Text = "Team"
		'
		'DevelopersToolStripMenuItem
		'
		Me.DevelopersToolStripMenuItem.Name = "DevelopersToolStripMenuItem"
		Me.DevelopersToolStripMenuItem.Size = New System.Drawing.Size(276, 22)
		Me.DevelopersToolStripMenuItem.Text = "Developers"
		'
		'SecurityloginAndPasswordTrackingToolStripMenuItem
		'
		Me.SecurityloginAndPasswordTrackingToolStripMenuItem.Name = "SecurityloginAndPasswordTrackingToolStripMenuItem"
		Me.SecurityloginAndPasswordTrackingToolStripMenuItem.Size = New System.Drawing.Size(276, 22)
		Me.SecurityloginAndPasswordTrackingToolStripMenuItem.Text = "Security (login and password tracking)"
		'
		'ManageReportsToolStripMenuItem
		'
		Me.ManageReportsToolStripMenuItem.Name = "ManageReportsToolStripMenuItem"
		Me.ManageReportsToolStripMenuItem.Size = New System.Drawing.Size(228, 22)
		Me.ManageReportsToolStripMenuItem.Text = "Manage Reports"
		'
		'ToolStripMenuItem4
		'
		Me.ToolStripMenuItem4.Name = "ToolStripMenuItem4"
		Me.ToolStripMenuItem4.Size = New System.Drawing.Size(225, 6)
		'
		'ManageServerConnectionsToolStripMenuItem
		'
		Me.ManageServerConnectionsToolStripMenuItem.Name = "ManageServerConnectionsToolStripMenuItem"
		Me.ManageServerConnectionsToolStripMenuItem.Size = New System.Drawing.Size(228, 22)
		Me.ManageServerConnectionsToolStripMenuItem.Text = "Manage server connections..."
		'
		'OptionsToolStripMenuItem
		'
		Me.OptionsToolStripMenuItem.Name = "OptionsToolStripMenuItem"
		Me.OptionsToolStripMenuItem.Size = New System.Drawing.Size(228, 22)
		Me.OptionsToolStripMenuItem.Text = "Options..."
		'
		'ToolStripSeparator1
		'
		Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
		Me.ToolStripSeparator1.Size = New System.Drawing.Size(225, 6)
		'
		'MyToolsToolStripMenuItem
		'
		Me.MyToolsToolStripMenuItem.Name = "MyToolsToolStripMenuItem"
		Me.MyToolsToolStripMenuItem.Size = New System.Drawing.Size(228, 22)
		Me.MyToolsToolStripMenuItem.Text = "MyTools Builder"
		'
		'mnuWindowsOpen
		'
		Me.mnuWindowsOpen.Name = "mnuWindowsOpen"
		Me.mnuWindowsOpen.Size = New System.Drawing.Size(68, 20)
		Me.mnuWindowsOpen.Text = "Windows"
		'
		'HelpToolStripMenuItem
		'
		Me.HelpToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ActiveDirectoryGroupsSQLServerRolesRelationshipsToolStripMenuItem1, Me.DataContactsToolStripMenuItem, Me.mnuViewServerSQLAgentJobTaskSchedule, Me.ToolStripSeparator2, Me.VersionNotesToolStripMenuItem})
		Me.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
		Me.HelpToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
		Me.HelpToolStripMenuItem.Text = "Help"
		'
		'ActiveDirectoryGroupsSQLServerRolesRelationshipsToolStripMenuItem1
		'
		Me.ActiveDirectoryGroupsSQLServerRolesRelationshipsToolStripMenuItem1.Name = "ActiveDirectoryGroupsSQLServerRolesRelationshipsToolStripMenuItem1"
		Me.ActiveDirectoryGroupsSQLServerRolesRelationshipsToolStripMenuItem1.Size = New System.Drawing.Size(367, 22)
		Me.ActiveDirectoryGroupsSQLServerRolesRelationshipsToolStripMenuItem1.Text = "Active Directory Groups / SQL Server Roles relationships"
		'
		'DataContactsToolStripMenuItem
		'
		Me.DataContactsToolStripMenuItem.Name = "DataContactsToolStripMenuItem"
		Me.DataContactsToolStripMenuItem.Size = New System.Drawing.Size(367, 22)
		Me.DataContactsToolStripMenuItem.Text = "Data Contacts and FTP Tracking"
		'
		'mnuViewServerSQLAgentJobTaskSchedule
		'
		Me.mnuViewServerSQLAgentJobTaskSchedule.Name = "mnuViewServerSQLAgentJobTaskSchedule"
		Me.mnuViewServerSQLAgentJobTaskSchedule.Size = New System.Drawing.Size(367, 22)
		Me.mnuViewServerSQLAgentJobTaskSchedule.Text = "SQL Agent Job/Task Schedule"
		'
		'ToolStripSeparator2
		'
		Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
		Me.ToolStripSeparator2.Size = New System.Drawing.Size(364, 6)
		'
		'VersionNotesToolStripMenuItem
		'
		Me.VersionNotesToolStripMenuItem.Name = "VersionNotesToolStripMenuItem"
		Me.VersionNotesToolStripMenuItem.Size = New System.Drawing.Size(367, 22)
		Me.VersionNotesToolStripMenuItem.Text = "Version Notes..."
		'
		'StatusStrip1
		'
		Me.StatusStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
		Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblStatusUser, Me.lblCurrentDateTime})
		Me.StatusStrip1.Location = New System.Drawing.Point(0, 825)
		Me.StatusStrip1.Name = "StatusStrip1"
		Me.StatusStrip1.Padding = New System.Windows.Forms.Padding(1, 0, 16, 0)
		Me.StatusStrip1.Size = New System.Drawing.Size(1185, 22)
		Me.StatusStrip1.TabIndex = 2
		Me.StatusStrip1.Text = "StatusStrip1"
		'
		'lblStatusUser
		'
		Me.lblStatusUser.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
		Me.lblStatusUser.Name = "lblStatusUser"
		Me.lblStatusUser.Size = New System.Drawing.Size(584, 17)
		Me.lblStatusUser.Spring = True
		Me.lblStatusUser.Text = "ToolStripStatusLabel1"
		Me.lblStatusUser.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'lblCurrentDateTime
		'
		Me.lblCurrentDateTime.Name = "lblCurrentDateTime"
		Me.lblCurrentDateTime.Size = New System.Drawing.Size(584, 17)
		Me.lblCurrentDateTime.Spring = True
		Me.lblCurrentDateTime.Text = "ToolStripStatusLabel1"
		Me.lblCurrentDateTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'Timer1
		'
		Me.Timer1.Interval = 50
		'
		'Timer2
		'
		Me.Timer2.Enabled = True
		Me.Timer2.Interval = 1000
		'
		'tsMyButtons
		'
		Me.tsMyButtons.AllowItemReorder = True
		Me.tsMyButtons.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
		Me.tsMyButtons.ImeMode = System.Windows.Forms.ImeMode.NoControl
		Me.tsMyButtons.Location = New System.Drawing.Point(0, 24)
		Me.tsMyButtons.Name = "tsMyButtons"
		Me.tsMyButtons.Size = New System.Drawing.Size(1185, 25)
		Me.tsMyButtons.TabIndex = 4
		Me.tsMyButtons.Text = "tsMyButtons"
		'
		'imlToolbox
		'
		Me.imlToolbox.ImageStream = CType(resources.GetObject("imlToolbox.ImageStream"), System.Windows.Forms.ImageListStreamer)
		Me.imlToolbox.TransparentColor = System.Drawing.Color.Transparent
		Me.imlToolbox.Images.SetKeyName(0, "DDT_Toolbox.ico")
		Me.imlToolbox.Images.SetKeyName(1, "folderclosed.ico")
		Me.imlToolbox.Images.SetKeyName(2, "folderopen.ico")
		Me.imlToolbox.Images.SetKeyName(3, "Redlight2.ico")
		Me.imlToolbox.Images.SetKeyName(4, "Redlight.ico")
		Me.imlToolbox.Images.SetKeyName(5, "Greenlight2.ico")
		Me.imlToolbox.Images.SetKeyName(6, "Greenlight.ico")
		Me.imlToolbox.Images.SetKeyName(7, "Blue Disk.ico")
		Me.imlToolbox.Images.SetKeyName(8, "Folder.ico")
		Me.imlToolbox.Images.SetKeyName(9, "Projects.ico")
		Me.imlToolbox.Images.SetKeyName(10, "DartRed.ico")
		Me.imlToolbox.Images.SetKeyName(11, "DART_TNG.ico")
		Me.imlToolbox.Images.SetKeyName(12, "Computer.ico")
		Me.imlToolbox.Images.SetKeyName(13, "setupdll_ASETUP.ico")
		Me.imlToolbox.Images.SetKeyName(14, "WINWORD_1.ico")
		Me.imlToolbox.Images.SetKeyName(15, "admparse_1_USER.ico")
		Me.imlToolbox.Images.SetKeyName(16, "Casette.ico")
		Me.imlToolbox.Images.SetKeyName(17, "Check.ico")
		Me.imlToolbox.Images.SetKeyName(18, "Shades.ico")
		'
		'frmMain
		'
		Me.AllowDrop = True
		Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
		Me.BackColor = System.Drawing.SystemColors.Control
		Me.ClientSize = New System.Drawing.Size(1185, 847)
		Me.Controls.Add(Me.tsMyButtons)
		Me.Controls.Add(Me.StatusStrip1)
		Me.Controls.Add(Me.MenuStrip1)
		Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
		Me.IsMdiContainer = True
		Me.KeyPreview = True
		Me.MainMenuStrip = Me.MenuStrip1
		Me.Name = "frmMain"
		Me.Text = "DDT Toolbox"
		Me.MenuStrip1.ResumeLayout(False)
		Me.MenuStrip1.PerformLayout()
		Me.StatusStrip1.ResumeLayout(False)
		Me.StatusStrip1.PerformLayout()
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuFileExit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents lblStatusUser As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents HelpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents VersionNotesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuWindowsOpen As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents lblCurrentDateTime As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents Timer2 As System.Windows.Forms.Timer
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ManageServerConnectionsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
	Friend WithEvents WorkforceManagerToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents QARTSettingsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ManagedADGroupsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TeamToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents DevelopersToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SecurityloginAndPasswordTrackingToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OptionsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ActiveDirectoryGroupsSQLServerRolesRelationshipsToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents DataContactsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuViewServerSQLAgentJobTaskSchedule As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsMyButtons As System.Windows.Forms.ToolStrip
    Friend WithEvents MyToolsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents imlToolbox As System.Windows.Forms.ImageList
    Friend WithEvents ManageReportsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DARTToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DART_TNGImportMonitorToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DARTTngReportTreeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DARTTNGApplicationToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ScheduleReportMonitorToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DARTTNGRetrieveReportParamsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ApplicationUsersToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents WFMReportTreeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

End Class
