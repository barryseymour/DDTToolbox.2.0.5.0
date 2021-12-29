<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDART_TNGApp

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
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDART_TNGApp))
		Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
		Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
		Me.cboServer = New System.Windows.Forms.ToolStripComboBox()
		Me.btnConnect = New System.Windows.Forms.ToolStripButton()
		Me.pnlPrimaryContent = New System.Windows.Forms.Panel()
		Me.DPPanel = New System.Windows.Forms.Panel()
		Me.grpAvailability = New System.Windows.Forms.GroupBox()
		Me.txtUnavailableMessage = New System.Windows.Forms.TextBox()
		Me.Label4 = New System.Windows.Forms.Label()
		Me.Label3 = New System.Windows.Forms.Label()
		Me.cboServerState = New System.Windows.Forms.ComboBox()
		Me.grpScheduledReports = New System.Windows.Forms.GroupBox()
		Me.cboDeleteExisting = New System.Windows.Forms.ComboBox()
		Me.cboUpdateSchedule = New System.Windows.Forms.ComboBox()
		Me.cboSendEmails = New System.Windows.Forms.ComboBox()
		Me.cboRunScheduled = New System.Windows.Forms.ComboBox()
		Me.Label8 = New System.Windows.Forms.Label()
		Me.Label7 = New System.Windows.Forms.Label()
		Me.Label5 = New System.Windows.Forms.Label()
		Me.Label6 = New System.Windows.Forms.Label()
		Me.grpSupportDecisions = New System.Windows.Forms.GroupBox()
		Me.btnSampleScheduled = New System.Windows.Forms.Button()
		Me.btnBulletins = New System.Windows.Forms.Button()
		Me.lblSampleScheduled = New System.Windows.Forms.Label()
		Me.txtSampleScheduled = New System.Windows.Forms.TextBox()
		Me.txtBulletins = New System.Windows.Forms.TextBox()
		Me.lblBulletins = New System.Windows.Forms.Label()
		Me.btnEdit = New System.Windows.Forms.Button()
		Me.btnCancel = New System.Windows.Forms.Button()
		Me.btnExit = New System.Windows.Forms.Button()
		Me.GroupBox6 = New System.Windows.Forms.GroupBox()
		Me.lblBB = New System.Windows.Forms.Label()
		Me.Label22 = New System.Windows.Forms.Label()
		Me.btnFlags = New System.Windows.Forms.Button()
		Me.btnEditBulletinBoard = New System.Windows.Forms.Button()
		Me.OpenFD = New System.Windows.Forms.OpenFileDialog()
		Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
		Me.ToolStrip1.SuspendLayout()
		Me.pnlPrimaryContent.SuspendLayout()
		Me.DPPanel.SuspendLayout()
		Me.grpAvailability.SuspendLayout()
		Me.grpScheduledReports.SuspendLayout()
		Me.grpSupportDecisions.SuspendLayout()
		Me.GroupBox6.SuspendLayout()
		CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.SuspendLayout()
		'
		'ToolStrip1
		'
		Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel1, Me.cboServer, Me.btnConnect})
		Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
		Me.ToolStrip1.Name = "ToolStrip1"
		Me.ToolStrip1.Size = New System.Drawing.Size(672, 25)
		Me.ToolStrip1.TabIndex = 0
		Me.ToolStrip1.Text = "ToolStrip1"
		'
		'ToolStripLabel1
		'
		Me.ToolStripLabel1.LinkColor = System.Drawing.Color.Blue
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
		Me.pnlPrimaryContent.Controls.Add(Me.DPPanel)
		Me.pnlPrimaryContent.Dock = System.Windows.Forms.DockStyle.Fill
		Me.pnlPrimaryContent.Location = New System.Drawing.Point(0, 0)
		Me.pnlPrimaryContent.Name = "pnlPrimaryContent"
		Me.pnlPrimaryContent.Size = New System.Drawing.Size(672, 630)
		Me.pnlPrimaryContent.TabIndex = 1
		'
		'DPPanel
		'
		Me.DPPanel.Controls.Add(Me.grpAvailability)
		Me.DPPanel.Controls.Add(Me.grpScheduledReports)
		Me.DPPanel.Controls.Add(Me.grpSupportDecisions)
		Me.DPPanel.Controls.Add(Me.btnEdit)
		Me.DPPanel.Controls.Add(Me.btnCancel)
		Me.DPPanel.Controls.Add(Me.btnExit)
		Me.DPPanel.Controls.Add(Me.GroupBox6)
		Me.DPPanel.Location = New System.Drawing.Point(13, 32)
		Me.DPPanel.Name = "DPPanel"
		Me.DPPanel.Size = New System.Drawing.Size(642, 580)
		Me.DPPanel.TabIndex = 0
		'
		'grpAvailability
		'
		Me.grpAvailability.Controls.Add(Me.txtUnavailableMessage)
		Me.grpAvailability.Controls.Add(Me.Label4)
		Me.grpAvailability.Controls.Add(Me.Label3)
		Me.grpAvailability.Controls.Add(Me.cboServerState)
		Me.grpAvailability.Location = New System.Drawing.Point(17, 217)
		Me.grpAvailability.Name = "grpAvailability"
		Me.grpAvailability.Size = New System.Drawing.Size(604, 106)
		Me.grpAvailability.TabIndex = 6
		Me.grpAvailability.TabStop = False
		Me.grpAvailability.Text = "Database Availability"
		'
		'txtUnavailableMessage
		'
		Me.txtUnavailableMessage.AcceptsReturn = True
		Me.txtUnavailableMessage.Location = New System.Drawing.Point(12, 47)
		Me.txtUnavailableMessage.Multiline = True
		Me.txtUnavailableMessage.Name = "txtUnavailableMessage"
		Me.txtUnavailableMessage.Size = New System.Drawing.Size(576, 45)
		Me.txtUnavailableMessage.TabIndex = 1
		'
		'Label4
		'
		Me.Label4.AutoSize = True
		Me.Label4.Location = New System.Drawing.Point(8, 25)
		Me.Label4.Name = "Label4"
		Me.Label4.Size = New System.Drawing.Size(117, 15)
		Me.Label4.TabIndex = 2
		Me.Label4.Text = "Unavailable message"
		'
		'Label3
		'
		Me.Label3.AutoSize = True
		Me.Label3.Location = New System.Drawing.Point(188, 25)
		Me.Label3.Name = "Label3"
		Me.Label3.Size = New System.Drawing.Size(55, 15)
		Me.Label3.TabIndex = 1
		Me.Label3.Text = "Available"
		'
		'cboServerState
		'
		Me.cboServerState.FormattingEnabled = True
		Me.cboServerState.Items.AddRange(New Object() {"Yes", "No"})
		Me.cboServerState.Location = New System.Drawing.Point(255, 21)
		Me.cboServerState.Name = "cboServerState"
		Me.cboServerState.Size = New System.Drawing.Size(59, 23)
		Me.cboServerState.TabIndex = 0
		'
		'grpScheduledReports
		'
		Me.grpScheduledReports.Controls.Add(Me.cboDeleteExisting)
		Me.grpScheduledReports.Controls.Add(Me.cboUpdateSchedule)
		Me.grpScheduledReports.Controls.Add(Me.cboSendEmails)
		Me.grpScheduledReports.Controls.Add(Me.cboRunScheduled)
		Me.grpScheduledReports.Controls.Add(Me.Label8)
		Me.grpScheduledReports.Controls.Add(Me.Label7)
		Me.grpScheduledReports.Controls.Add(Me.Label5)
		Me.grpScheduledReports.Controls.Add(Me.Label6)
		Me.grpScheduledReports.Location = New System.Drawing.Point(16, 7)
		Me.grpScheduledReports.Name = "grpScheduledReports"
		Me.grpScheduledReports.Size = New System.Drawing.Size(391, 98)
		Me.grpScheduledReports.TabIndex = 14
		Me.grpScheduledReports.TabStop = False
		Me.grpScheduledReports.Text = "Scheduled Reports"
		'
		'cboDeleteExisting
		'
		Me.cboDeleteExisting.CausesValidation = False
		Me.cboDeleteExisting.FormattingEnabled = True
		Me.cboDeleteExisting.Items.AddRange(New Object() {"Yes", "No"})
		Me.cboDeleteExisting.Location = New System.Drawing.Point(319, 61)
		Me.cboDeleteExisting.Name = "cboDeleteExisting"
		Me.cboDeleteExisting.Size = New System.Drawing.Size(54, 23)
		Me.cboDeleteExisting.TabIndex = 7
		'
		'cboUpdateSchedule
		'
		Me.cboUpdateSchedule.CausesValidation = False
		Me.cboUpdateSchedule.FormattingEnabled = True
		Me.cboUpdateSchedule.Items.AddRange(New Object() {"Yes", "No"})
		Me.cboUpdateSchedule.Location = New System.Drawing.Point(119, 61)
		Me.cboUpdateSchedule.Name = "cboUpdateSchedule"
		Me.cboUpdateSchedule.Size = New System.Drawing.Size(54, 23)
		Me.cboUpdateSchedule.TabIndex = 6
		'
		'cboSendEmails
		'
		Me.cboSendEmails.FormattingEnabled = True
		Me.cboSendEmails.Items.AddRange(New Object() {"Yes", "No"})
		Me.cboSendEmails.Location = New System.Drawing.Point(266, 25)
		Me.cboSendEmails.Name = "cboSendEmails"
		Me.cboSendEmails.Size = New System.Drawing.Size(54, 23)
		Me.cboSendEmails.TabIndex = 5
		'
		'cboRunScheduled
		'
		Me.cboRunScheduled.FormattingEnabled = True
		Me.cboRunScheduled.Items.AddRange(New Object() {"Yes", "No"})
		Me.cboRunScheduled.Location = New System.Drawing.Point(119, 25)
		Me.cboRunScheduled.Name = "cboRunScheduled"
		Me.cboRunScheduled.Size = New System.Drawing.Size(54, 23)
		Me.cboRunScheduled.TabIndex = 4
		'
		'Label8
		'
		Me.Label8.AutoSize = True
		Me.Label8.Location = New System.Drawing.Point(190, 67)
		Me.Label8.Name = "Label8"
		Me.Label8.Size = New System.Drawing.Size(124, 15)
		Me.Label8.TabIndex = 3
		Me.Label8.Text = "Delete Existing at Start"
		'
		'Label7
		'
		Me.Label7.AutoSize = True
		Me.Label7.Location = New System.Drawing.Point(7, 67)
		Me.Label7.Name = "Label7"
		Me.Label7.Size = New System.Drawing.Size(80, 15)
		Me.Label7.TabIndex = 2
		Me.Label7.Text = "Update Sched"
		'
		'Label5
		'
		Me.Label5.AutoSize = True
		Me.Label5.Location = New System.Drawing.Point(7, 31)
		Me.Label5.Name = "Label5"
		Me.Label5.Size = New System.Drawing.Size(106, 15)
		Me.Label5.TabIndex = 0
		Me.Label5.Text = "Run Sched Reports"
		'
		'Label6
		'
		Me.Label6.AutoSize = True
		Me.Label6.Location = New System.Drawing.Point(189, 31)
		Me.Label6.Name = "Label6"
		Me.Label6.Size = New System.Drawing.Size(70, 15)
		Me.Label6.TabIndex = 1
		Me.Label6.Text = "Send EMails"
		'
		'grpSupportDecisions
		'
		Me.grpSupportDecisions.Controls.Add(Me.btnSampleScheduled)
		Me.grpSupportDecisions.Controls.Add(Me.btnBulletins)
		Me.grpSupportDecisions.Controls.Add(Me.lblSampleScheduled)
		Me.grpSupportDecisions.Controls.Add(Me.txtSampleScheduled)
		Me.grpSupportDecisions.Controls.Add(Me.txtBulletins)
		Me.grpSupportDecisions.Controls.Add(Me.lblBulletins)
		Me.grpSupportDecisions.Location = New System.Drawing.Point(17, 113)
		Me.grpSupportDecisions.Name = "grpSupportDecisions"
		Me.grpSupportDecisions.Size = New System.Drawing.Size(604, 98)
		Me.grpSupportDecisions.TabIndex = 11
		Me.grpSupportDecisions.TabStop = False
		Me.grpSupportDecisions.Text = "Support Directories"
		'
		'btnSampleScheduled
		'
		Me.btnSampleScheduled.Location = New System.Drawing.Point(501, 22)
		Me.btnSampleScheduled.Name = "btnSampleScheduled"
		Me.btnSampleScheduled.Size = New System.Drawing.Size(87, 27)
		Me.btnSampleScheduled.TabIndex = 15
		Me.btnSampleScheduled.Text = "Browse..."
		Me.btnSampleScheduled.UseVisualStyleBackColor = True
		'
		'btnBulletins
		'
		Me.btnBulletins.Location = New System.Drawing.Point(501, 53)
		Me.btnBulletins.Name = "btnBulletins"
		Me.btnBulletins.Size = New System.Drawing.Size(87, 27)
		Me.btnBulletins.TabIndex = 13
		Me.btnBulletins.Text = "Browse..."
		Me.btnBulletins.UseVisualStyleBackColor = True
		'
		'lblSampleScheduled
		'
		Me.lblSampleScheduled.AutoSize = True
		Me.lblSampleScheduled.Location = New System.Drawing.Point(15, 27)
		Me.lblSampleScheduled.Name = "lblSampleScheduled"
		Me.lblSampleScheduled.Size = New System.Drawing.Size(105, 15)
		Me.lblSampleScheduled.TabIndex = 4
		Me.lblSampleScheduled.Text = "Scheduled Reports"
		'
		'txtSampleScheduled
		'
		Me.txtSampleScheduled.Location = New System.Drawing.Point(135, 24)
		Me.txtSampleScheduled.Name = "txtSampleScheduled"
		Me.txtSampleScheduled.Size = New System.Drawing.Size(345, 23)
		Me.txtSampleScheduled.TabIndex = 3
		'
		'txtBulletins
		'
		Me.txtBulletins.Location = New System.Drawing.Point(135, 57)
		Me.txtBulletins.Name = "txtBulletins"
		Me.txtBulletins.Size = New System.Drawing.Size(345, 23)
		Me.txtBulletins.TabIndex = 1
		'
		'lblBulletins
		'
		Me.lblBulletins.AutoSize = True
		Me.lblBulletins.Location = New System.Drawing.Point(15, 60)
		Me.lblBulletins.Name = "lblBulletins"
		Me.lblBulletins.Size = New System.Drawing.Size(52, 15)
		Me.lblBulletins.TabIndex = 1
		Me.lblBulletins.Text = "Bulletins"
		'
		'btnEdit
		'
		Me.btnEdit.Location = New System.Drawing.Point(257, 538)
		Me.btnEdit.Name = "btnEdit"
		Me.btnEdit.Size = New System.Drawing.Size(87, 27)
		Me.btnEdit.TabIndex = 12
		Me.btnEdit.Text = "Edit"
		Me.btnEdit.UseVisualStyleBackColor = True
		'
		'btnCancel
		'
		Me.btnCancel.Location = New System.Drawing.Point(395, 538)
		Me.btnCancel.Name = "btnCancel"
		Me.btnCancel.Size = New System.Drawing.Size(87, 27)
		Me.btnCancel.TabIndex = 11
		Me.btnCancel.Text = "Cancel"
		Me.btnCancel.UseVisualStyleBackColor = True
		'
		'btnExit
		'
		Me.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel
		Me.btnExit.Location = New System.Drawing.Point(119, 538)
		Me.btnExit.Name = "btnExit"
		Me.btnExit.Size = New System.Drawing.Size(87, 27)
		Me.btnExit.TabIndex = 10
		Me.btnExit.Text = "Exit"
		Me.btnExit.UseVisualStyleBackColor = True
		'
		'GroupBox6
		'
		Me.GroupBox6.Controls.Add(Me.lblBB)
		Me.GroupBox6.Controls.Add(Me.Label22)
		Me.GroupBox6.Controls.Add(Me.btnFlags)
		Me.GroupBox6.Controls.Add(Me.btnEditBulletinBoard)
		Me.GroupBox6.Location = New System.Drawing.Point(20, 329)
		Me.GroupBox6.Name = "GroupBox6"
		Me.GroupBox6.Size = New System.Drawing.Size(601, 193)
		Me.GroupBox6.TabIndex = 9
		Me.GroupBox6.TabStop = False
		Me.GroupBox6.Text = "Bulletin Board"
		'
		'lblBB
		'
		Me.lblBB.AutoSize = True
		Me.lblBB.Location = New System.Drawing.Point(6, 23)
		Me.lblBB.Name = "lblBB"
		Me.lblBB.Size = New System.Drawing.Size(316, 15)
		Me.lblBB.TabIndex = 9
		Me.lblBB.Text = "To edit the DartPro Bulletin Board, take the following steps:"
		'
		'Label22
		'
		Me.Label22.Location = New System.Drawing.Point(8, 51)
		Me.Label22.Name = "Label22"
		Me.Label22.Size = New System.Drawing.Size(572, 84)
		Me.Label22.TabIndex = 8
		Me.Label22.Text = resources.GetString("Label22.Text")
		'
		'btnFlags
		'
		Me.btnFlags.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.btnFlags.Location = New System.Drawing.Point(188, 152)
		Me.btnFlags.Name = "btnFlags"
		Me.btnFlags.Size = New System.Drawing.Size(307, 29)
		Me.btnFlags.TabIndex = 2
		Me.btnFlags.Tag = "ON"
		Me.btnFlags.Text = "Bulletin Flags"
		Me.btnFlags.UseVisualStyleBackColor = True
		'
		'btnEditBulletinBoard
		'
		Me.btnEditBulletinBoard.Location = New System.Drawing.Point(49, 152)
		Me.btnEditBulletinBoard.Name = "btnEditBulletinBoard"
		Me.btnEditBulletinBoard.Size = New System.Drawing.Size(127, 29)
		Me.btnEditBulletinBoard.TabIndex = 1
		Me.btnEditBulletinBoard.Text = "Edit Bulletin Board"
		Me.btnEditBulletinBoard.UseVisualStyleBackColor = True
		'
		'ErrorProvider1
		'
		Me.ErrorProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
		Me.ErrorProvider1.ContainerControl = Me
		'
		'frmDART_TNGApp
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
		Me.CancelButton = Me.btnExit
		Me.ClientSize = New System.Drawing.Size(672, 630)
		Me.Controls.Add(Me.ToolStrip1)
		Me.Controls.Add(Me.pnlPrimaryContent)
		Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
		Me.Name = "frmDART_TNGApp"
		Me.ShowInTaskbar = False
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.Text = "DART Application"
		Me.ToolStrip1.ResumeLayout(False)
		Me.ToolStrip1.PerformLayout()
		Me.pnlPrimaryContent.ResumeLayout(False)
		Me.DPPanel.ResumeLayout(False)
		Me.grpAvailability.ResumeLayout(False)
		Me.grpAvailability.PerformLayout()
		Me.grpScheduledReports.ResumeLayout(False)
		Me.grpScheduledReports.PerformLayout()
		Me.grpSupportDecisions.ResumeLayout(False)
		Me.grpSupportDecisions.PerformLayout()
		Me.GroupBox6.ResumeLayout(False)
		Me.GroupBox6.PerformLayout()
		CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Public WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Public WithEvents btnConnect As System.Windows.Forms.ToolStripButton
    Friend WithEvents DPPanel As System.Windows.Forms.Panel
    Friend WithEvents grpAvailability As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cboServerState As System.Windows.Forms.ComboBox
    Friend WithEvents txtUnavailableMessage As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
	Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
	Friend WithEvents btnFlags As System.Windows.Forms.Button
    Friend WithEvents btnEditBulletinBoard As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnExit As System.Windows.Forms.Button
	Friend WithEvents OpenFD As System.Windows.Forms.OpenFileDialog
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents btnEdit As System.Windows.Forms.Button
    Friend WithEvents lblBB As System.Windows.Forms.Label
    Friend WithEvents grpSupportDecisions As System.Windows.Forms.GroupBox
    Friend WithEvents btnSampleScheduled As System.Windows.Forms.Button
    Friend WithEvents btnBulletins As System.Windows.Forms.Button
    Friend WithEvents lblSampleScheduled As System.Windows.Forms.Label
    Friend WithEvents txtSampleScheduled As System.Windows.Forms.TextBox
    Friend WithEvents txtBulletins As System.Windows.Forms.TextBox
    Friend WithEvents lblBulletins As System.Windows.Forms.Label
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents grpScheduledReports As System.Windows.Forms.GroupBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cboRunScheduled As System.Windows.Forms.ComboBox
    Friend WithEvents cboUpdateSchedule As System.Windows.Forms.ComboBox
    Friend WithEvents cboSendEmails As System.Windows.Forms.ComboBox
    Friend WithEvents cboDeleteExisting As System.Windows.Forms.ComboBox
    Public WithEvents cboServer As System.Windows.Forms.ToolStripComboBox
	Public WithEvents pnlPrimaryContent As System.Windows.Forms.Panel

End Class
