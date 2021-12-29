<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAddApplicationUser
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
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAddApplicationUser))
		Me.btnOK = New System.Windows.Forms.Button()
		Me.btnCancel = New System.Windows.Forms.Button()
		Me.rdoLookupByEmployeeNumber = New System.Windows.Forms.RadioButton()
		Me.btnPaste = New System.Windows.Forms.Button()
		Me.txtEmployeeNumber = New DDTToolbox.DDT_TextBox()
		Me.SuspendLayout()
		'
		'btnOK
		'
		Me.btnOK.Enabled = False
		Me.btnOK.Location = New System.Drawing.Point(76, 82)
		Me.btnOK.Name = "btnOK"
		Me.btnOK.Size = New System.Drawing.Size(76, 24)
		Me.btnOK.TabIndex = 2
		Me.btnOK.Text = "OK"
		Me.btnOK.UseVisualStyleBackColor = True
		'
		'btnCancel
		'
		Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
		Me.btnCancel.Location = New System.Drawing.Point(193, 82)
		Me.btnCancel.Name = "btnCancel"
		Me.btnCancel.Size = New System.Drawing.Size(76, 24)
		Me.btnCancel.TabIndex = 3
		Me.btnCancel.Text = "Cancel"
		Me.btnCancel.UseVisualStyleBackColor = True
		'
		'rdoLookupByEmployeeNumber
		'
		Me.rdoLookupByEmployeeNumber.AutoSize = True
		Me.rdoLookupByEmployeeNumber.Checked = True
		Me.rdoLookupByEmployeeNumber.Location = New System.Drawing.Point(15, 24)
		Me.rdoLookupByEmployeeNumber.Name = "rdoLookupByEmployeeNumber"
		Me.rdoLookupByEmployeeNumber.Size = New System.Drawing.Size(183, 19)
		Me.rdoLookupByEmployeeNumber.TabIndex = 4
		Me.rdoLookupByEmployeeNumber.TabStop = True
		Me.rdoLookupByEmployeeNumber.Text = "Lookup by Employee Number"
		Me.rdoLookupByEmployeeNumber.UseVisualStyleBackColor = True
		'
		'btnPaste
		'
		Me.btnPaste.Location = New System.Drawing.Point(294, 23)
		Me.btnPaste.Name = "btnPaste"
		Me.btnPaste.Size = New System.Drawing.Size(50, 21)
		Me.btnPaste.TabIndex = 7
		Me.btnPaste.Text = "Paste"
		Me.btnPaste.UseVisualStyleBackColor = True
		'
		'txtEmployeeNumber
		'
		Me.txtEmployeeNumber.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.txtEmployeeNumber.Location = New System.Drawing.Point(204, 23)
		Me.txtEmployeeNumber.Name = "txtEmployeeNumber"
		Me.txtEmployeeNumber.Size = New System.Drawing.Size(84, 23)
		Me.txtEmployeeNumber.TabIndex = 1
		'
		'frmAddApplicationUser
		'
		Me.AcceptButton = Me.btnOK
		Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
		Me.CancelButton = Me.btnCancel
		Me.ClientSize = New System.Drawing.Size(379, 120)
		Me.ControlBox = False
		Me.Controls.Add(Me.txtEmployeeNumber)
		Me.Controls.Add(Me.btnPaste)
		Me.Controls.Add(Me.rdoLookupByEmployeeNumber)
		Me.Controls.Add(Me.btnCancel)
		Me.Controls.Add(Me.btnOK)
		Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
		Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
		Me.Name = "frmAddApplicationUser"
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.Text = "Add Application User"
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents rdoLookupByEmployeeNumber As System.Windows.Forms.RadioButton
    Friend WithEvents btnPaste As System.Windows.Forms.Button
    Friend WithEvents txtEmployeeNumber As DDT_TextBox
End Class
