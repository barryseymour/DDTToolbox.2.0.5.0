<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmInsertWFMTreeItem
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
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmInsertWFMTreeItem))
		Me.grpPlacementOptions = New System.Windows.Forms.GroupBox()
		Me.rdoInsertAfter = New System.Windows.Forms.RadioButton()
		Me.rdoInsertIn = New System.Windows.Forms.RadioButton()
		Me.rdoInsertBefore = New System.Windows.Forms.RadioButton()
		Me.grpInsertOptions = New System.Windows.Forms.GroupBox()
		Me.rdoPasteItemFromClipboard = New System.Windows.Forms.RadioButton()
		Me.rdoInsertBlankItem = New System.Windows.Forms.RadioButton()
		Me.btnCancel = New System.Windows.Forms.Button()
		Me.btnOK = New System.Windows.Forms.Button()
		Me.grpPlacementOptions.SuspendLayout()
		Me.grpInsertOptions.SuspendLayout()
		Me.SuspendLayout()
		'
		'grpPlacementOptions
		'
		Me.grpPlacementOptions.Controls.Add(Me.rdoInsertAfter)
		Me.grpPlacementOptions.Controls.Add(Me.rdoInsertIn)
		Me.grpPlacementOptions.Controls.Add(Me.rdoInsertBefore)
		Me.grpPlacementOptions.Location = New System.Drawing.Point(47, 143)
		Me.grpPlacementOptions.Name = "grpPlacementOptions"
		Me.grpPlacementOptions.Size = New System.Drawing.Size(196, 115)
		Me.grpPlacementOptions.TabIndex = 5
		Me.grpPlacementOptions.TabStop = False
		Me.grpPlacementOptions.Text = "Placement options"
		'
		'rdoInsertAfter
		'
		Me.rdoInsertAfter.AutoSize = True
		Me.rdoInsertAfter.Location = New System.Drawing.Point(18, 52)
		Me.rdoInsertAfter.Name = "rdoInsertAfter"
		Me.rdoInsertAfter.Size = New System.Drawing.Size(163, 19)
		Me.rdoInsertAfter.TabIndex = 5
		Me.rdoInsertAfter.TabStop = True
		Me.rdoInsertAfter.Text = "Insert AFTER selected item"
		Me.rdoInsertAfter.UseVisualStyleBackColor = True
		'
		'rdoInsertIn
		'
		Me.rdoInsertIn.AutoSize = True
		Me.rdoInsertIn.Checked = True
		Me.rdoInsertIn.Location = New System.Drawing.Point(18, 75)
		Me.rdoInsertIn.Name = "rdoInsertIn"
		Me.rdoInsertIn.Size = New System.Drawing.Size(149, 19)
		Me.rdoInsertIn.TabIndex = 4
		Me.rdoInsertIn.TabStop = True
		Me.rdoInsertIn.Text = "Insert IN selected folder"
		Me.rdoInsertIn.UseVisualStyleBackColor = True
		'
		'rdoInsertBefore
		'
		Me.rdoInsertBefore.AutoSize = True
		Me.rdoInsertBefore.Location = New System.Drawing.Point(18, 28)
		Me.rdoInsertBefore.Name = "rdoInsertBefore"
		Me.rdoInsertBefore.Size = New System.Drawing.Size(171, 19)
		Me.rdoInsertBefore.TabIndex = 2
		Me.rdoInsertBefore.Text = "Insert BEFORE selected item"
		Me.rdoInsertBefore.UseVisualStyleBackColor = True
		'
		'grpInsertOptions
		'
		Me.grpInsertOptions.Controls.Add(Me.rdoPasteItemFromClipboard)
		Me.grpInsertOptions.Controls.Add(Me.rdoInsertBlankItem)
		Me.grpInsertOptions.Location = New System.Drawing.Point(46, 39)
		Me.grpInsertOptions.Name = "grpInsertOptions"
		Me.grpInsertOptions.Size = New System.Drawing.Size(197, 84)
		Me.grpInsertOptions.TabIndex = 3
		Me.grpInsertOptions.TabStop = False
		Me.grpInsertOptions.Text = "Insert options"
		'
		'rdoPasteItemFromClipboard
		'
		Me.rdoPasteItemFromClipboard.AutoSize = True
		Me.rdoPasteItemFromClipboard.Location = New System.Drawing.Point(18, 50)
		Me.rdoPasteItemFromClipboard.Name = "rdoPasteItemFromClipboard"
		Me.rdoPasteItemFromClipboard.Size = New System.Drawing.Size(162, 19)
		Me.rdoPasteItemFromClipboard.TabIndex = 3
		Me.rdoPasteItemFromClipboard.Text = "Paste item from clipboard"
		Me.rdoPasteItemFromClipboard.UseVisualStyleBackColor = True
		'
		'rdoInsertBlankItem
		'
		Me.rdoInsertBlankItem.AutoSize = True
		Me.rdoInsertBlankItem.Checked = True
		Me.rdoInsertBlankItem.Location = New System.Drawing.Point(18, 27)
		Me.rdoInsertBlankItem.Name = "rdoInsertBlankItem"
		Me.rdoInsertBlankItem.Size = New System.Drawing.Size(113, 19)
		Me.rdoInsertBlankItem.TabIndex = 2
		Me.rdoInsertBlankItem.TabStop = True
		Me.rdoInsertBlankItem.Text = "Insert blank item"
		Me.rdoInsertBlankItem.UseVisualStyleBackColor = True
		'
		'btnCancel
		'
		Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
		Me.btnCancel.Location = New System.Drawing.Point(157, 287)
		Me.btnCancel.Name = "btnCancel"
		Me.btnCancel.Size = New System.Drawing.Size(59, 24)
		Me.btnCancel.TabIndex = 4
		Me.btnCancel.Text = "Cancel"
		Me.btnCancel.UseVisualStyleBackColor = True
		'
		'btnOK
		'
		Me.btnOK.Location = New System.Drawing.Point(74, 287)
		Me.btnOK.Name = "btnOK"
		Me.btnOK.Size = New System.Drawing.Size(59, 24)
		Me.btnOK.TabIndex = 6
		Me.btnOK.Text = "OK"
		Me.btnOK.UseVisualStyleBackColor = True
		'
		'frmInsertWFMTreeItem
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
		Me.ClientSize = New System.Drawing.Size(292, 338)
		Me.Controls.Add(Me.grpPlacementOptions)
		Me.Controls.Add(Me.grpInsertOptions)
		Me.Controls.Add(Me.btnCancel)
		Me.Controls.Add(Me.btnOK)
		Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
		Me.Name = "frmInsertWFMTreeItem"
		Me.Text = "frmInsertDARTTngTreeItem"
		Me.grpPlacementOptions.ResumeLayout(False)
		Me.grpPlacementOptions.PerformLayout()
		Me.grpInsertOptions.ResumeLayout(False)
		Me.grpInsertOptions.PerformLayout()
		Me.ResumeLayout(False)

	End Sub
    Friend WithEvents grpPlacementOptions As System.Windows.Forms.GroupBox
    Friend WithEvents rdoInsertIn As System.Windows.Forms.RadioButton
    Friend WithEvents rdoInsertBefore As System.Windows.Forms.RadioButton
    Friend WithEvents grpInsertOptions As System.Windows.Forms.GroupBox
    Friend WithEvents rdoPasteItemFromClipboard As System.Windows.Forms.RadioButton
    Friend WithEvents rdoInsertBlankItem As System.Windows.Forms.RadioButton
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents rdoInsertAfter As System.Windows.Forms.RadioButton
End Class
