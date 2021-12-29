<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDART_TNGRetrieveDARTReportParams
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
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDART_TNGRetrieveDARTReportParams))
		Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
		Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
		Me.cboServer = New System.Windows.Forms.ToolStripComboBox()
		Me.btnConnect = New System.Windows.Forms.ToolStripButton()
		Me.pnlPrimaryContent = New System.Windows.Forms.Panel()
		Me.cboChoseServer = New System.Windows.Forms.ComboBox()
		Me.btnCopyForTesting = New System.Windows.Forms.Button()
		Me.chkAppendResults = New System.Windows.Forms.CheckBox()
		Me.btnRetrieveParameters = New System.Windows.Forms.Button()
		Me.txtUniqueUserID = New DDTToolbox.ExtTextBox()
		Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
		Me.GetTodaysUserIDsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		Me.lblUniqueUserID = New System.Windows.Forms.Label()
		Me.dgvParameters = New System.Windows.Forms.DataGridView()
		Me.colUserID = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.colParamType = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.colParamValue = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.colParamText = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.ToolStrip1.SuspendLayout()
		Me.pnlPrimaryContent.SuspendLayout()
		Me.ContextMenuStrip1.SuspendLayout()
		CType(Me.dgvParameters, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.SuspendLayout()
		'
		'ToolStrip1
		'
		Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel1, Me.cboServer, Me.btnConnect})
		Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
		Me.ToolStrip1.Name = "ToolStrip1"
		Me.ToolStrip1.Size = New System.Drawing.Size(520, 25)
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
		'
		'pnlPrimaryContent
		'
		Me.pnlPrimaryContent.AutoSize = True
		Me.pnlPrimaryContent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.pnlPrimaryContent.Controls.Add(Me.cboChoseServer)
		Me.pnlPrimaryContent.Controls.Add(Me.btnCopyForTesting)
		Me.pnlPrimaryContent.Controls.Add(Me.chkAppendResults)
		Me.pnlPrimaryContent.Controls.Add(Me.btnRetrieveParameters)
		Me.pnlPrimaryContent.Controls.Add(Me.txtUniqueUserID)
		Me.pnlPrimaryContent.Controls.Add(Me.lblUniqueUserID)
		Me.pnlPrimaryContent.Controls.Add(Me.dgvParameters)
		Me.pnlPrimaryContent.Dock = System.Windows.Forms.DockStyle.Fill
		Me.pnlPrimaryContent.Location = New System.Drawing.Point(0, 25)
		Me.pnlPrimaryContent.Name = "pnlPrimaryContent"
		Me.pnlPrimaryContent.Size = New System.Drawing.Size(520, 493)
		Me.pnlPrimaryContent.TabIndex = 1
		'
		'cboChoseServer
		'
		Me.cboChoseServer.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
		Me.cboChoseServer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cboChoseServer.FormattingEnabled = True
		Me.cboChoseServer.Location = New System.Drawing.Point(165, 452)
		Me.cboChoseServer.Name = "cboChoseServer"
		Me.cboChoseServer.Size = New System.Drawing.Size(167, 23)
		Me.cboChoseServer.TabIndex = 6
		'
		'btnCopyForTesting
		'
		Me.btnCopyForTesting.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
		Me.btnCopyForTesting.Location = New System.Drawing.Point(12, 450)
		Me.btnCopyForTesting.Name = "btnCopyForTesting"
		Me.btnCopyForTesting.Size = New System.Drawing.Size(132, 26)
		Me.btnCopyForTesting.TabIndex = 5
		Me.btnCopyForTesting.Text = "Copy for testing"
		Me.btnCopyForTesting.UseVisualStyleBackColor = True
		'
		'chkAppendResults
		'
		Me.chkAppendResults.AutoSize = True
		Me.chkAppendResults.Location = New System.Drawing.Point(373, 41)
		Me.chkAppendResults.Name = "chkAppendResults"
		Me.chkAppendResults.Size = New System.Drawing.Size(105, 19)
		Me.chkAppendResults.TabIndex = 4
		Me.chkAppendResults.Text = "Append results"
		Me.chkAppendResults.UseVisualStyleBackColor = True
		'
		'btnRetrieveParameters
		'
		Me.btnRetrieveParameters.Enabled = False
		Me.btnRetrieveParameters.Location = New System.Drawing.Point(369, 11)
		Me.btnRetrieveParameters.Name = "btnRetrieveParameters"
		Me.btnRetrieveParameters.Size = New System.Drawing.Size(136, 23)
		Me.btnRetrieveParameters.TabIndex = 2
		Me.btnRetrieveParameters.Text = "Retrieve Parameters"
		Me.btnRetrieveParameters.UseVisualStyleBackColor = True
		'
		'txtUniqueUserID
		'
		Me.txtUniqueUserID.ContextMenuStrip = Me.ContextMenuStrip1
		Me.txtUniqueUserID.Location = New System.Drawing.Point(97, 13)
		Me.txtUniqueUserID.MaxLength = 100
		Me.txtUniqueUserID.Name = "txtUniqueUserID"
		Me.txtUniqueUserID.Size = New System.Drawing.Size(266, 23)
		Me.txtUniqueUserID.TabIndex = 1
		'
		'ContextMenuStrip1
		'
		Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.GetTodaysUserIDsToolStripMenuItem})
		Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
		Me.ContextMenuStrip1.Size = New System.Drawing.Size(207, 26)
		'
		'GetTodaysUserIDsToolStripMenuItem
		'
		Me.GetTodaysUserIDsToolStripMenuItem.Name = "GetTodaysUserIDsToolStripMenuItem"
		Me.GetTodaysUserIDsToolStripMenuItem.Size = New System.Drawing.Size(206, 22)
		Me.GetTodaysUserIDsToolStripMenuItem.Text = "Get My UserIDs for Today"
		'
		'lblUniqueUserID
		'
		Me.lblUniqueUserID.AutoSize = True
		Me.lblUniqueUserID.Location = New System.Drawing.Point(14, 17)
		Me.lblUniqueUserID.Name = "lblUniqueUserID"
		Me.lblUniqueUserID.Size = New System.Drawing.Size(85, 15)
		Me.lblUniqueUserID.TabIndex = 0
		Me.lblUniqueUserID.Text = "Unique User ID"
		'
		'dgvParameters
		'
		Me.dgvParameters.AllowUserToAddRows = False
		Me.dgvParameters.AllowUserToDeleteRows = False
		Me.dgvParameters.AllowUserToResizeRows = False
		Me.dgvParameters.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
			Or System.Windows.Forms.AnchorStyles.Left) _
			Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.dgvParameters.BackgroundColor = System.Drawing.Color.White
		Me.dgvParameters.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.dgvParameters.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
		Me.dgvParameters.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colUserID, Me.colParamType, Me.colParamValue, Me.colParamText})
		Me.dgvParameters.Location = New System.Drawing.Point(12, 64)
		Me.dgvParameters.Name = "dgvParameters"
		Me.dgvParameters.ReadOnly = True
		Me.dgvParameters.RowHeadersVisible = False
		Me.dgvParameters.RowTemplate.Height = 18
		Me.dgvParameters.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
		Me.dgvParameters.ShowCellToolTips = False
		Me.dgvParameters.Size = New System.Drawing.Size(493, 372)
		Me.dgvParameters.TabIndex = 3
		'
		'colUserID
		'
		Me.colUserID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
		Me.colUserID.HeaderText = "UserID"
		Me.colUserID.Name = "colUserID"
		Me.colUserID.ReadOnly = True
		Me.colUserID.Width = 66
		'
		'colParamType
		'
		Me.colParamType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
		Me.colParamType.HeaderText = "ParamType"
		Me.colParamType.Name = "colParamType"
		Me.colParamType.ReadOnly = True
		Me.colParamType.Width = 90
		'
		'colParamValue
		'
		Me.colParamValue.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
		Me.colParamValue.HeaderText = "ParamValue"
		Me.colParamValue.Name = "colParamValue"
		Me.colParamValue.ReadOnly = True
		Me.colParamValue.Width = 94
		'
		'colParamText
		'
		Me.colParamText.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
		Me.colParamText.HeaderText = "ParamText"
		Me.colParamText.Name = "colParamText"
		Me.colParamText.ReadOnly = True
		Me.colParamText.Width = 87
		'
		'frmDART_TNGRetrieveDARTReportParams
		'
		Me.AcceptButton = Me.btnRetrieveParameters
		Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
		Me.ClientSize = New System.Drawing.Size(520, 518)
		Me.Controls.Add(Me.pnlPrimaryContent)
		Me.Controls.Add(Me.ToolStrip1)
		Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
		Me.MinimumSize = New System.Drawing.Size(528, 300)
		Me.Name = "frmDART_TNGRetrieveDARTReportParams"
		Me.ShowInTaskbar = False
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.Text = "Retrieve DART Report Parameters"
		Me.ToolStrip1.ResumeLayout(False)
		Me.ToolStrip1.PerformLayout()
		Me.pnlPrimaryContent.ResumeLayout(False)
		Me.pnlPrimaryContent.PerformLayout()
		Me.ContextMenuStrip1.ResumeLayout(False)
		CType(Me.dgvParameters, System.ComponentModel.ISupportInitialize).EndInit()
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Public WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Public WithEvents btnConnect As System.Windows.Forms.ToolStripButton
    Friend WithEvents lblUniqueUserID As System.Windows.Forms.Label
    Friend WithEvents dgvParameters As System.Windows.Forms.DataGridView
    Friend WithEvents btnRetrieveParameters As System.Windows.Forms.Button
    Friend WithEvents txtUniqueUserID As DDTToolbox.ExtTextBox
    Friend WithEvents colUserID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colParamType As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colParamValue As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colParamText As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents chkAppendResults As System.Windows.Forms.CheckBox
    Friend WithEvents btnCopyForTesting As System.Windows.Forms.Button
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents GetTodaysUserIDsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents cboServer As System.Windows.Forms.ToolStripComboBox
    Public WithEvents cboChoseServer As System.Windows.Forms.ComboBox
    Public WithEvents pnlPrimaryContent As System.Windows.Forms.Panel
End Class
