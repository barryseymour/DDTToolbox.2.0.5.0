<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmQAApp
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
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmQAApp))
		Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
		Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
		Me.cboServer = New System.Windows.Forms.ToolStripComboBox()
		Me.btnConnect = New System.Windows.Forms.ToolStripButton()
		Me.pnlPrimaryContent = New System.Windows.Forms.Panel()
		Me.txtSDGERoutingDefaultEmailList = New DDTToolbox.ExtTextBox()
		Me.Label7 = New System.Windows.Forms.Label()
		Me.btnSDGERoutingTemplateLocation = New System.Windows.Forms.Button()
		Me.txtSDGERoutingTemplateLocation = New DDTToolbox.ExtTextBox()
		Me.Label1 = New System.Windows.Forms.Label()
		Me.chkValidate = New System.Windows.Forms.CheckBox()
		Me.btnCancel = New System.Windows.Forms.Button()
		Me.btnSetupFileLocation = New System.Windows.Forms.Button()
		Me.btnVersionNotesFileLocation = New System.Windows.Forms.Button()
		Me.btnRoutingTemplateLocation = New System.Windows.Forms.Button()
		Me.btnSave = New System.Windows.Forms.Button()
		Me.btnEdit = New System.Windows.Forms.Button()
		Me.txtSetupFileLocation = New DDTToolbox.ExtTextBox()
		Me.txtVersionNotesFileLocation = New DDTToolbox.ExtTextBox()
		Me.txtRoutingTemplateLocation = New DDTToolbox.ExtTextBox()
		Me.Label6 = New System.Windows.Forms.Label()
		Me.Label3 = New System.Windows.Forms.Label()
		Me.Label2 = New System.Windows.Forms.Label()
		Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
		Me.ToolStrip1.SuspendLayout()
		Me.pnlPrimaryContent.SuspendLayout()
		Me.SuspendLayout()
		'
		'ToolStrip1
		'
		Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel1, Me.cboServer, Me.btnConnect})
		Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
		Me.ToolStrip1.Name = "ToolStrip1"
		Me.ToolStrip1.Padding = New System.Windows.Forms.Padding(0)
		Me.ToolStrip1.Size = New System.Drawing.Size(744, 25)
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
		Me.pnlPrimaryContent.Controls.Add(Me.txtSDGERoutingDefaultEmailList)
		Me.pnlPrimaryContent.Controls.Add(Me.Label7)
		Me.pnlPrimaryContent.Controls.Add(Me.btnSDGERoutingTemplateLocation)
		Me.pnlPrimaryContent.Controls.Add(Me.txtSDGERoutingTemplateLocation)
		Me.pnlPrimaryContent.Controls.Add(Me.Label1)
		Me.pnlPrimaryContent.Controls.Add(Me.chkValidate)
		Me.pnlPrimaryContent.Controls.Add(Me.btnCancel)
		Me.pnlPrimaryContent.Controls.Add(Me.btnSetupFileLocation)
		Me.pnlPrimaryContent.Controls.Add(Me.btnVersionNotesFileLocation)
		Me.pnlPrimaryContent.Controls.Add(Me.btnRoutingTemplateLocation)
		Me.pnlPrimaryContent.Controls.Add(Me.btnSave)
		Me.pnlPrimaryContent.Controls.Add(Me.btnEdit)
		Me.pnlPrimaryContent.Controls.Add(Me.txtSetupFileLocation)
		Me.pnlPrimaryContent.Controls.Add(Me.txtVersionNotesFileLocation)
		Me.pnlPrimaryContent.Controls.Add(Me.txtRoutingTemplateLocation)
		Me.pnlPrimaryContent.Controls.Add(Me.Label6)
		Me.pnlPrimaryContent.Controls.Add(Me.Label3)
		Me.pnlPrimaryContent.Controls.Add(Me.Label2)
		Me.pnlPrimaryContent.Dock = System.Windows.Forms.DockStyle.Fill
		Me.pnlPrimaryContent.Location = New System.Drawing.Point(0, 25)
		Me.pnlPrimaryContent.Name = "pnlPrimaryContent"
		Me.pnlPrimaryContent.Size = New System.Drawing.Size(744, 211)
		Me.pnlPrimaryContent.TabIndex = 1
		'
		'txtSDGERoutingDefaultEmailList
		'
		Me.txtSDGERoutingDefaultEmailList.Location = New System.Drawing.Point(253, 73)
		Me.txtSDGERoutingDefaultEmailList.Name = "txtSDGERoutingDefaultEmailList"
		Me.txtSDGERoutingDefaultEmailList.Size = New System.Drawing.Size(404, 23)
		Me.txtSDGERoutingDefaultEmailList.TabIndex = 2
		'
		'Label7
		'
		Me.Label7.AutoSize = True
		Me.Label7.Location = New System.Drawing.Point(71, 76)
		Me.Label7.Name = "Label7"
		Me.Label7.Size = New System.Drawing.Size(170, 15)
		Me.Label7.TabIndex = 17
		Me.Label7.Text = "SDGE Routing default email list"
		'
		'btnSDGERoutingTemplateLocation
		'
		Me.btnSDGERoutingTemplateLocation.Location = New System.Drawing.Point(670, 44)
		Me.btnSDGERoutingTemplateLocation.Name = "btnSDGERoutingTemplateLocation"
		Me.btnSDGERoutingTemplateLocation.Size = New System.Drawing.Size(62, 22)
		Me.btnSDGERoutingTemplateLocation.TabIndex = 12
		Me.btnSDGERoutingTemplateLocation.Text = "..."
		Me.btnSDGERoutingTemplateLocation.UseVisualStyleBackColor = True
		'
		'txtSDGERoutingTemplateLocation
		'
		Me.txtSDGERoutingTemplateLocation.Location = New System.Drawing.Point(253, 45)
		Me.txtSDGERoutingTemplateLocation.Name = "txtSDGERoutingTemplateLocation"
		Me.txtSDGERoutingTemplateLocation.Size = New System.Drawing.Size(404, 23)
		Me.txtSDGERoutingTemplateLocation.TabIndex = 1
		'
		'Label1
		'
		Me.Label1.AutoSize = True
		Me.Label1.Location = New System.Drawing.Point(4, 48)
		Me.Label1.Name = "Label1"
		Me.Label1.Size = New System.Drawing.Size(242, 15)
		Me.Label1.TabIndex = 14
		Me.Label1.Text = "SDGE Routing template spreadsheet location"
		'
		'chkValidate
		'
		Me.chkValidate.AutoSize = True
		Me.chkValidate.Checked = True
		Me.chkValidate.CheckState = System.Windows.Forms.CheckState.Checked
		Me.chkValidate.Location = New System.Drawing.Point(489, 173)
		Me.chkValidate.Name = "chkValidate"
		Me.chkValidate.Size = New System.Drawing.Size(186, 19)
		Me.chkValidate.TabIndex = 10
		Me.chkValidate.Text = "Validate file paths prior to save"
		Me.chkValidate.UseVisualStyleBackColor = True
		'
		'btnCancel
		'
		Me.btnCancel.Location = New System.Drawing.Point(396, 173)
		Me.btnCancel.Name = "btnCancel"
		Me.btnCancel.Size = New System.Drawing.Size(65, 22)
		Me.btnCancel.TabIndex = 9
		Me.btnCancel.Text = "Cancel"
		Me.btnCancel.UseVisualStyleBackColor = True
		Me.btnCancel.Visible = False
		'
		'btnSetupFileLocation
		'
		Me.btnSetupFileLocation.Location = New System.Drawing.Point(670, 127)
		Me.btnSetupFileLocation.Name = "btnSetupFileLocation"
		Me.btnSetupFileLocation.Size = New System.Drawing.Size(62, 22)
		Me.btnSetupFileLocation.TabIndex = 14
		Me.btnSetupFileLocation.Text = "..."
		Me.btnSetupFileLocation.UseVisualStyleBackColor = True
		Me.btnSetupFileLocation.Visible = False
		'
		'btnVersionNotesFileLocation
		'
		Me.btnVersionNotesFileLocation.Location = New System.Drawing.Point(670, 100)
		Me.btnVersionNotesFileLocation.Name = "btnVersionNotesFileLocation"
		Me.btnVersionNotesFileLocation.Size = New System.Drawing.Size(62, 22)
		Me.btnVersionNotesFileLocation.TabIndex = 13
		Me.btnVersionNotesFileLocation.Text = "..."
		Me.btnVersionNotesFileLocation.UseVisualStyleBackColor = True
		'
		'btnRoutingTemplateLocation
		'
		Me.btnRoutingTemplateLocation.Location = New System.Drawing.Point(670, 16)
		Me.btnRoutingTemplateLocation.Name = "btnRoutingTemplateLocation"
		Me.btnRoutingTemplateLocation.Size = New System.Drawing.Size(62, 22)
		Me.btnRoutingTemplateLocation.TabIndex = 11
		Me.btnRoutingTemplateLocation.Text = "..."
		Me.btnRoutingTemplateLocation.UseVisualStyleBackColor = True
		'
		'btnSave
		'
		Me.btnSave.Location = New System.Drawing.Point(256, 173)
		Me.btnSave.Name = "btnSave"
		Me.btnSave.Size = New System.Drawing.Size(65, 22)
		Me.btnSave.TabIndex = 7
		Me.btnSave.Text = "Save"
		Me.btnSave.UseVisualStyleBackColor = True
		Me.btnSave.Visible = False
		'
		'btnEdit
		'
		Me.btnEdit.Location = New System.Drawing.Point(326, 173)
		Me.btnEdit.Name = "btnEdit"
		Me.btnEdit.Size = New System.Drawing.Size(65, 22)
		Me.btnEdit.TabIndex = 8
		Me.btnEdit.Text = "Edit"
		Me.btnEdit.UseVisualStyleBackColor = True
		'
		'txtSetupFileLocation
		'
		Me.txtSetupFileLocation.Location = New System.Drawing.Point(253, 128)
		Me.txtSetupFileLocation.Name = "txtSetupFileLocation"
		Me.txtSetupFileLocation.Size = New System.Drawing.Size(404, 23)
		Me.txtSetupFileLocation.TabIndex = 5
		Me.txtSetupFileLocation.Visible = False
		'
		'txtVersionNotesFileLocation
		'
		Me.txtVersionNotesFileLocation.Location = New System.Drawing.Point(253, 101)
		Me.txtVersionNotesFileLocation.Name = "txtVersionNotesFileLocation"
		Me.txtVersionNotesFileLocation.Size = New System.Drawing.Size(404, 23)
		Me.txtVersionNotesFileLocation.TabIndex = 3
		'
		'txtRoutingTemplateLocation
		'
		Me.txtRoutingTemplateLocation.Location = New System.Drawing.Point(253, 17)
		Me.txtRoutingTemplateLocation.Name = "txtRoutingTemplateLocation"
		Me.txtRoutingTemplateLocation.Size = New System.Drawing.Size(404, 23)
		Me.txtRoutingTemplateLocation.TabIndex = 0
		'
		'Label6
		'
		Me.Label6.AutoSize = True
		Me.Label6.Location = New System.Drawing.Point(134, 131)
		Me.Label6.Name = "Label6"
		Me.Label6.Size = New System.Drawing.Size(102, 15)
		Me.Label6.TabIndex = 5
		Me.Label6.Text = "Setup file location"
		Me.Label6.Visible = False
		'
		'Label3
		'
		Me.Label3.AutoSize = True
		Me.Label3.Location = New System.Drawing.Point(96, 104)
		Me.Label3.Name = "Label3"
		Me.Label3.Size = New System.Drawing.Size(144, 15)
		Me.Label3.TabIndex = 2
		Me.Label3.Text = "Version Notes file location"
		'
		'Label2
		'
		Me.Label2.AutoSize = True
		Me.Label2.Location = New System.Drawing.Point(12, 20)
		Me.Label2.Name = "Label2"
		Me.Label2.Size = New System.Drawing.Size(236, 15)
		Me.Label2.TabIndex = 1
		Me.Label2.Text = "SCG Routing template spreadsheet location"
		'
		'OpenFileDialog1
		'
		Me.OpenFileDialog1.FileName = "OpenFileDialog1"
		Me.OpenFileDialog1.ShowReadOnly = True
		'
		'frmQAApp
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
		Me.ClientSize = New System.Drawing.Size(744, 236)
		Me.Controls.Add(Me.pnlPrimaryContent)
		Me.Controls.Add(Me.ToolStrip1)
		Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
		Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
		Me.MaximizeBox = False
		Me.Name = "frmQAApp"
		Me.ShowInTaskbar = False
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.Text = "QART Application Settings"
		Me.ToolStrip1.ResumeLayout(False)
		Me.ToolStrip1.PerformLayout()
		Me.pnlPrimaryContent.ResumeLayout(False)
		Me.pnlPrimaryContent.PerformLayout()
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Public WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Public WithEvents btnConnect As System.Windows.Forms.ToolStripButton
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnEdit As System.Windows.Forms.Button
    Friend WithEvents txtSetupFileLocation As DDTToolbox.ExtTextBox
    Friend WithEvents txtVersionNotesFileLocation As DDTToolbox.ExtTextBox
    Friend WithEvents txtRoutingTemplateLocation As DDTToolbox.ExtTextBox
    Friend WithEvents btnSetupFileLocation As System.Windows.Forms.Button
    Friend WithEvents btnVersionNotesFileLocation As System.Windows.Forms.Button
    Friend WithEvents btnRoutingTemplateLocation As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents chkValidate As System.Windows.Forms.CheckBox
    Friend WithEvents txtSDGERoutingDefaultEmailList As DDTToolbox.ExtTextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents btnSDGERoutingTemplateLocation As System.Windows.Forms.Button
    Friend WithEvents txtSDGERoutingTemplateLocation As DDTToolbox.ExtTextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Public WithEvents cboServer As System.Windows.Forms.ToolStripComboBox
    Public WithEvents pnlPrimaryContent As System.Windows.Forms.Panel
End Class
