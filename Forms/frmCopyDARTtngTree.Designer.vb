<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCopyDARTtngTree
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCopyDARTtngTree))
        Me.btnCopy = New System.Windows.Forms.Button()
        Me.btnDone = New System.Windows.Forms.Button()
        Me.dgvServers = New System.Windows.Forms.DataGridView()
        Me.colCheckBox = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.colServer = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colResult = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.dgvServers, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnCopy
        '
        Me.btnCopy.Location = New System.Drawing.Point(242, 322)
        Me.btnCopy.Name = "btnCopy"
        Me.btnCopy.Size = New System.Drawing.Size(71, 25)
        Me.btnCopy.TabIndex = 3
        Me.btnCopy.Text = "&Copy"
        Me.btnCopy.UseVisualStyleBackColor = True
        '
        'btnDone
        '
        Me.btnDone.Location = New System.Drawing.Point(367, 322)
        Me.btnDone.Name = "btnDone"
        Me.btnDone.Size = New System.Drawing.Size(71, 25)
        Me.btnDone.TabIndex = 4
        Me.btnDone.Text = "E&xit"
        Me.btnDone.UseVisualStyleBackColor = True
        '
        'dgvServers
        '
        Me.dgvServers.AllowUserToAddRows = False
        Me.dgvServers.AllowUserToDeleteRows = False
        Me.dgvServers.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvServers.BackgroundColor = System.Drawing.Color.White
        Me.dgvServers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvServers.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colCheckBox, Me.colServer, Me.colResult})
        Me.dgvServers.Location = New System.Drawing.Point(14, 126)
        Me.dgvServers.Name = "dgvServers"
        Me.dgvServers.RowHeadersVisible = False
        Me.dgvServers.Size = New System.Drawing.Size(655, 180)
        Me.dgvServers.TabIndex = 5
        '
        'colCheckBox
        '
        Me.colCheckBox.FalseValue = "0"
        Me.colCheckBox.Frozen = True
        Me.colCheckBox.HeaderText = ""
        Me.colCheckBox.Name = "colCheckBox"
        Me.colCheckBox.TrueValue = "1"
        Me.colCheckBox.Width = 25
        '
        'colServer
        '
        Me.colServer.Frozen = True
        Me.colServer.HeaderText = "Server"
        Me.colServer.Name = "colServer"
        Me.colServer.ReadOnly = True
        Me.colServer.Width = 190
        '
        'colResult
        '
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colResult.DefaultCellStyle = DataGridViewCellStyle1
        Me.colResult.Frozen = True
        Me.colResult.HeaderText = "Result"
        Me.colResult.Name = "colResult"
        Me.colResult.ReadOnly = True
        Me.colResult.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.colResult.Width = 420
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.TextBox1)
        Me.GroupBox1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.GroupBox1.Location = New System.Drawing.Point(15, 1)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(653, 106)
        Me.GroupBox1.TabIndex = 6
        Me.GroupBox1.TabStop = False
        '
        'TextBox1
        '
        Me.TextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox1.Location = New System.Drawing.Point(3, 19)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ReadOnly = True
        Me.TextBox1.Size = New System.Drawing.Size(647, 84)
        Me.TextBox1.TabIndex = 8
        Me.TextBox1.TabStop = False
        Me.TextBox1.Text = resources.GetString("TextBox1.Text")
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(16, 110)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(134, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Select destination servers :"
        '
        'frmCopyDARTtngTree
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(681, 357)
        Me.ControlBox = False
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.dgvServers)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnDone)
        Me.Controls.Add(Me.btnCopy)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmCopyDARTtngTree"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Copy DART_TNG Tree"
        CType(Me.dgvServers, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnCopy As System.Windows.Forms.Button
    Friend WithEvents btnDone As System.Windows.Forms.Button
    Friend WithEvents dgvServers As System.Windows.Forms.DataGridView
    Friend WithEvents colCheckBox As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents colServer As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colResult As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As TextBox
End Class
