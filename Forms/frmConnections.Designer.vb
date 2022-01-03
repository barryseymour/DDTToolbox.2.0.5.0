<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmConnections
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmConnections))
        Me.btnClose = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.listConnections = New System.Windows.Forms.ListBox()
        Me.btnEdit = New System.Windows.Forms.Button()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.grpEditConnection = New System.Windows.Forms.GroupBox()
        Me.lblEstablishingConnection = New System.Windows.Forms.Label()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.lblConnectionName = New System.Windows.Forms.Label()
        Me.grpMinimumRequirements = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtConnectionName = New DDTToolbox.ExtTextBox()
        Me.GroupBox1.SuspendLayout()
        Me.grpEditConnection.SuspendLayout()
        Me.grpMinimumRequirements.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(125, 256)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(75, 23)
        Me.btnClose.TabIndex = 12
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnDelete)
        Me.GroupBox1.Controls.Add(Me.listConnections)
        Me.GroupBox1.Controls.Add(Me.btnEdit)
        Me.GroupBox1.Controls.Add(Me.btnAdd)
        Me.GroupBox1.Location = New System.Drawing.Point(20, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(279, 124)
        Me.GroupBox1.TabIndex = 15
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Server connections"
        '
        'btnDelete
        '
        Me.btnDelete.Enabled = False
        Me.btnDelete.Location = New System.Drawing.Point(213, 75)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(55, 23)
        Me.btnDelete.TabIndex = 17
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'listConnections
        '
        Me.listConnections.FormattingEnabled = True
        Me.listConnections.ItemHeight = 15
        Me.listConnections.Location = New System.Drawing.Point(11, 21)
        Me.listConnections.Name = "listConnections"
        Me.listConnections.Size = New System.Drawing.Size(196, 94)
        Me.listConnections.Sorted = True
        Me.listConnections.TabIndex = 18
        '
        'btnEdit
        '
        Me.btnEdit.Enabled = False
        Me.btnEdit.Location = New System.Drawing.Point(213, 48)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(55, 23)
        Me.btnEdit.TabIndex = 16
        Me.btnEdit.Text = "Edit"
        Me.btnEdit.UseVisualStyleBackColor = True
        '
        'btnAdd
        '
        Me.btnAdd.Enabled = False
        Me.btnAdd.Location = New System.Drawing.Point(213, 21)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(55, 23)
        Me.btnAdd.TabIndex = 15
        Me.btnAdd.Text = "Add"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'grpEditConnection
        '
        Me.grpEditConnection.Controls.Add(Me.lblEstablishingConnection)
        Me.grpEditConnection.Controls.Add(Me.btnCancel)
        Me.grpEditConnection.Controls.Add(Me.btnSave)
        Me.grpEditConnection.Controls.Add(Me.txtConnectionName)
        Me.grpEditConnection.Controls.Add(Me.lblConnectionName)
        Me.grpEditConnection.Location = New System.Drawing.Point(20, 144)
        Me.grpEditConnection.Name = "grpEditConnection"
        Me.grpEditConnection.Size = New System.Drawing.Size(279, 106)
        Me.grpEditConnection.TabIndex = 16
        Me.grpEditConnection.TabStop = False
        Me.grpEditConnection.Text = "Connection Action"
        '
        'lblEstablishingConnection
        '
        Me.lblEstablishingConnection.AutoSize = True
        Me.lblEstablishingConnection.ForeColor = System.Drawing.Color.Red
        Me.lblEstablishingConnection.Location = New System.Drawing.Point(75, 49)
        Me.lblEstablishingConnection.Name = "lblEstablishingConnection"
        Me.lblEstablishingConnection.Size = New System.Drawing.Size(131, 15)
        Me.lblEstablishingConnection.TabIndex = 19
        Me.lblEstablishingConnection.Text = "Validating connection..."
        Me.lblEstablishingConnection.Visible = False
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(149, 73)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(55, 21)
        Me.btnCancel.TabIndex = 18
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(74, 73)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(55, 21)
        Me.btnSave.TabIndex = 17
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'lblConnectionName
        '
        Me.lblConnectionName.AutoSize = True
        Me.lblConnectionName.Location = New System.Drawing.Point(8, 21)
        Me.lblConnectionName.Name = "lblConnectionName"
        Me.lblConnectionName.Size = New System.Drawing.Size(104, 15)
        Me.lblConnectionName.TabIndex = 14
        Me.lblConnectionName.Text = "Connection Name"
        '
        'grpMinimumRequirements
        '
        Me.grpMinimumRequirements.Controls.Add(Me.Label1)
        Me.grpMinimumRequirements.Location = New System.Drawing.Point(12, 144)
        Me.grpMinimumRequirements.Name = "grpMinimumRequirements"
        Me.grpMinimumRequirements.Size = New System.Drawing.Size(287, 108)
        Me.grpMinimumRequirements.TabIndex = 17
        Me.grpMinimumRequirements.TabStop = False
        Me.grpMinimumRequirements.Text = "Minimum connection requirements"
        '
        'Label1
        '
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(8, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(265, 84)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = resources.GetString("Label1.Text")
        '
        'txtConnectionName
        '
        Me.txtConnectionName.Location = New System.Drawing.Point(132, 19)
        Me.txtConnectionName.Name = "txtConnectionName"
        Me.txtConnectionName.Size = New System.Drawing.Size(135, 23)
        Me.txtConnectionName.TabIndex = 15
        '
        'frmConnections
        '
        Me.AcceptButton = Me.btnSave
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(300, 298)
        Me.ControlBox = False
        Me.Controls.Add(Me.grpMinimumRequirements)
        Me.Controls.Add(Me.grpEditConnection)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnClose)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "frmConnections"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Manage Server Connections"
        Me.GroupBox1.ResumeLayout(False)
        Me.grpEditConnection.ResumeLayout(False)
        Me.grpEditConnection.PerformLayout()
        Me.grpMinimumRequirements.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents listConnections As System.Windows.Forms.ListBox
    Friend WithEvents btnEdit As System.Windows.Forms.Button
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents grpEditConnection As System.Windows.Forms.GroupBox
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents txtConnectionName As DDTToolbox.ExtTextBox
    Friend WithEvents lblConnectionName As System.Windows.Forms.Label
    Friend WithEvents lblEstablishingConnection As System.Windows.Forms.Label
    Friend WithEvents grpMinimumRequirements As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
