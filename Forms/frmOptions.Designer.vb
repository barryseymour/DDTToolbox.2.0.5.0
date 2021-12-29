<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmOptions
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
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmOptions))
		Me.grpConnections = New System.Windows.Forms.GroupBox()
		Me.lblNoConnectionsDefined = New System.Windows.Forms.Label()
		Me.cboDefaultConnection = New System.Windows.Forms.ComboBox()
		Me.rdoUseDefaultConnection = New System.Windows.Forms.RadioButton()
		Me.rdoUseLastConnection = New System.Windows.Forms.RadioButton()
		Me.btnOK = New System.Windows.Forms.Button()
		Me.btnCancel = New System.Windows.Forms.Button()
		Me.chkAutoCenterMainWindow = New System.Windows.Forms.CheckBox()
		Me.grpConnections.SuspendLayout()
		Me.SuspendLayout()
		'
		'grpConnections
		'
		Me.grpConnections.Controls.Add(Me.lblNoConnectionsDefined)
		Me.grpConnections.Controls.Add(Me.cboDefaultConnection)
		Me.grpConnections.Controls.Add(Me.rdoUseDefaultConnection)
		Me.grpConnections.Controls.Add(Me.rdoUseLastConnection)
		Me.grpConnections.Location = New System.Drawing.Point(12, 48)
		Me.grpConnections.Name = "grpConnections"
		Me.grpConnections.Size = New System.Drawing.Size(355, 80)
		Me.grpConnections.TabIndex = 1
		Me.grpConnections.TabStop = False
		Me.grpConnections.Text = "Default connection when opening a new tool"
		'
		'lblNoConnectionsDefined
		'
		Me.lblNoConnectionsDefined.AutoSize = True
		Me.lblNoConnectionsDefined.Enabled = False
		Me.lblNoConnectionsDefined.Location = New System.Drawing.Point(156, 50)
		Me.lblNoConnectionsDefined.Name = "lblNoConnectionsDefined"
		Me.lblNoConnectionsDefined.Size = New System.Drawing.Size(197, 15)
		Me.lblNoConnectionsDefined.TabIndex = 3
		Me.lblNoConnectionsDefined.Text = "(no connections have been defined)"
		Me.lblNoConnectionsDefined.Visible = False
		'
		'cboDefaultConnection
		'
		Me.cboDefaultConnection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cboDefaultConnection.FormattingEnabled = True
		Me.cboDefaultConnection.Location = New System.Drawing.Point(170, 46)
		Me.cboDefaultConnection.Name = "cboDefaultConnection"
		Me.cboDefaultConnection.Size = New System.Drawing.Size(148, 23)
		Me.cboDefaultConnection.TabIndex = 3
		Me.cboDefaultConnection.Visible = False
		'
		'rdoUseDefaultConnection
		'
		Me.rdoUseDefaultConnection.AutoSize = True
		Me.rdoUseDefaultConnection.Checked = True
		Me.rdoUseDefaultConnection.Location = New System.Drawing.Point(20, 48)
		Me.rdoUseDefaultConnection.Name = "rdoUseDefaultConnection"
		Me.rdoUseDefaultConnection.Size = New System.Drawing.Size(147, 19)
		Me.rdoUseDefaultConnection.TabIndex = 2
		Me.rdoUseDefaultConnection.TabStop = True
		Me.rdoUseDefaultConnection.Text = "Use default connection"
		Me.rdoUseDefaultConnection.UseVisualStyleBackColor = True
		'
		'rdoUseLastConnection
		'
		Me.rdoUseLastConnection.AutoSize = True
		Me.rdoUseLastConnection.Location = New System.Drawing.Point(20, 25)
		Me.rdoUseLastConnection.Name = "rdoUseLastConnection"
		Me.rdoUseLastConnection.Size = New System.Drawing.Size(185, 19)
		Me.rdoUseLastConnection.TabIndex = 1
		Me.rdoUseLastConnection.Text = "Use last successful connection"
		Me.rdoUseLastConnection.UseVisualStyleBackColor = True
		'
		'btnOK
		'
		Me.btnOK.Location = New System.Drawing.Point(101, 134)
		Me.btnOK.Name = "btnOK"
		Me.btnOK.Size = New System.Drawing.Size(76, 25)
		Me.btnOK.TabIndex = 0
		Me.btnOK.Text = "OK"
		Me.btnOK.UseVisualStyleBackColor = True
		'
		'btnCancel
		'
		Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
		Me.btnCancel.Location = New System.Drawing.Point(205, 134)
		Me.btnCancel.Name = "btnCancel"
		Me.btnCancel.Size = New System.Drawing.Size(76, 25)
		Me.btnCancel.TabIndex = 3
		Me.btnCancel.Text = "Cancel"
		Me.btnCancel.UseVisualStyleBackColor = True
		'
		'chkAutoCenterMainWindow
		'
		Me.chkAutoCenterMainWindow.AutoSize = True
		Me.chkAutoCenterMainWindow.Location = New System.Drawing.Point(32, 12)
		Me.chkAutoCenterMainWindow.Name = "chkAutoCenterMainWindow"
		Me.chkAutoCenterMainWindow.Size = New System.Drawing.Size(252, 19)
		Me.chkAutoCenterMainWindow.TabIndex = 0
		Me.chkAutoCenterMainWindow.Text = "Auto center application window on startup"
		Me.chkAutoCenterMainWindow.UseVisualStyleBackColor = True
		'
		'frmOptions
		'
		Me.AcceptButton = Me.btnOK
		Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
		Me.CancelButton = Me.btnCancel
		Me.ClientSize = New System.Drawing.Size(377, 167)
		Me.ControlBox = False
		Me.Controls.Add(Me.chkAutoCenterMainWindow)
		Me.Controls.Add(Me.btnCancel)
		Me.Controls.Add(Me.btnOK)
		Me.Controls.Add(Me.grpConnections)
		Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
		Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
		Me.Name = "frmOptions"
		Me.ShowInTaskbar = False
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
		Me.Text = "Options"
		Me.grpConnections.ResumeLayout(False)
		Me.grpConnections.PerformLayout()
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub
    Friend WithEvents grpConnections As System.Windows.Forms.GroupBox
    Friend WithEvents rdoUseDefaultConnection As System.Windows.Forms.RadioButton
    Friend WithEvents rdoUseLastConnection As System.Windows.Forms.RadioButton
    Friend WithEvents cboDefaultConnection As System.Windows.Forms.ComboBox
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents lblNoConnectionsDefined As System.Windows.Forms.Label
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents chkAutoCenterMainWindow As System.Windows.Forms.CheckBox
End Class
