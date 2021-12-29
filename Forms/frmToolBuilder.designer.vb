<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmToolBuilder
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
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmToolBuilder))
		Me.dgvTools = New System.Windows.Forms.DataGridView()
		Me.cboDocking = New System.Windows.Forms.ComboBox()
		Me.cboTextDirection = New System.Windows.Forms.ComboBox()
		Me.ckShowTools = New System.Windows.Forms.CheckBox()
		Me.btnSaveTool = New System.Windows.Forms.Button()
		Me.btnAddTool = New System.Windows.Forms.Button()
		Me.btnRemoveTool = New System.Windows.Forms.Button()
		Me.cboButtonStyle = New System.Windows.Forms.ComboBox()
		Me.grpOrientation = New System.Windows.Forms.GroupBox()
		Me.lblButtonStyle = New System.Windows.Forms.Label()
		Me.lblTextDirection = New System.Windows.Forms.Label()
		Me.lbldockLocation = New System.Windows.Forms.Label()
		Me.grpToolBuild = New System.Windows.Forms.GroupBox()
		Me.dgvImages = New System.Windows.Forms.DataGridView()
		Me.Image = New System.Windows.Forms.DataGridViewImageColumn()
		Me.ImageIndex = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.btnEdit = New System.Windows.Forms.Button()
		Me.btnCancel = New System.Windows.Forms.Button()
		Me.cboClickFunctions = New System.Windows.Forms.ComboBox()
		Me.lblFunctionName = New System.Windows.Forms.Label()
		Me.txtFullName = New System.Windows.Forms.TextBox()
		Me.lblFullName = New System.Windows.Forms.Label()
		Me.lblNickName = New System.Windows.Forms.Label()
		Me.txtNickName = New System.Windows.Forms.TextBox()
		Me.btnNew = New System.Windows.Forms.Button()
		Me.txtNewToolNotice = New System.Windows.Forms.TextBox()
		Me.lstMenuItems = New System.Windows.Forms.ListBox()
		Me.txtMessageReOrderButtons = New System.Windows.Forms.TextBox()
		CType(Me.dgvTools, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.grpOrientation.SuspendLayout()
		Me.grpToolBuild.SuspendLayout()
		CType(Me.dgvImages, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.SuspendLayout()
		'
		'dgvTools
		'
		Me.dgvTools.AllowDrop = True
		Me.dgvTools.AllowUserToAddRows = False
		Me.dgvTools.AllowUserToDeleteRows = False
		Me.dgvTools.AllowUserToOrderColumns = True
		Me.dgvTools.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
			Or System.Windows.Forms.AnchorStyles.Left) _
			Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.dgvTools.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
		Me.dgvTools.BackgroundColor = System.Drawing.SystemColors.Control
		Me.dgvTools.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
		Me.dgvTools.Location = New System.Drawing.Point(6, 54)
		Me.dgvTools.Name = "dgvTools"
		Me.dgvTools.RowHeadersWidth = 10
		Me.dgvTools.RowTemplate.Height = 18
		Me.dgvTools.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
		Me.dgvTools.Size = New System.Drawing.Size(321, 470)
		Me.dgvTools.TabIndex = 0
		'
		'cboDocking
		'
		Me.cboDocking.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cboDocking.FormattingEnabled = True
		Me.cboDocking.Items.AddRange(New Object() {"Top", "Left", "Right", "Bottom"})
		Me.cboDocking.Location = New System.Drawing.Point(11, 43)
		Me.cboDocking.Name = "cboDocking"
		Me.cboDocking.Size = New System.Drawing.Size(98, 23)
		Me.cboDocking.TabIndex = 1
		'
		'cboTextDirection
		'
		Me.cboTextDirection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cboTextDirection.FormattingEnabled = True
		Me.cboTextDirection.Items.AddRange(New Object() {"Inherit", "Horizontal", "Vertical90", "Vertical270"})
		Me.cboTextDirection.Location = New System.Drawing.Point(11, 94)
		Me.cboTextDirection.Name = "cboTextDirection"
		Me.cboTextDirection.Size = New System.Drawing.Size(98, 23)
		Me.cboTextDirection.TabIndex = 2
		'
		'ckShowTools
		'
		Me.ckShowTools.AutoSize = True
		Me.ckShowTools.Checked = True
		Me.ckShowTools.CheckState = System.Windows.Forms.CheckState.Checked
		Me.ckShowTools.Location = New System.Drawing.Point(37, 10)
		Me.ckShowTools.Name = "ckShowTools"
		Me.ckShowTools.Size = New System.Drawing.Size(119, 19)
		Me.ckShowTools.TabIndex = 3
		Me.ckShowTools.Text = "Show Tool Palette"
		Me.ckShowTools.UseVisualStyleBackColor = True
		'
		'btnSaveTool
		'
		Me.btnSaveTool.Location = New System.Drawing.Point(23, 59)
		Me.btnSaveTool.Name = "btnSaveTool"
		Me.btnSaveTool.Size = New System.Drawing.Size(88, 23)
		Me.btnSaveTool.TabIndex = 5
		Me.btnSaveTool.Text = "Save ToolBar"
		Me.btnSaveTool.UseVisualStyleBackColor = True
		'
		'btnAddTool
		'
		Me.btnAddTool.Location = New System.Drawing.Point(6, 25)
		Me.btnAddTool.Name = "btnAddTool"
		Me.btnAddTool.Size = New System.Drawing.Size(75, 23)
		Me.btnAddTool.TabIndex = 6
		Me.btnAddTool.Text = "Add"
		Me.btnAddTool.UseVisualStyleBackColor = True
		'
		'btnRemoveTool
		'
		Me.btnRemoveTool.AllowDrop = True
		Me.btnRemoveTool.Location = New System.Drawing.Point(87, 25)
		Me.btnRemoveTool.Name = "btnRemoveTool"
		Me.btnRemoveTool.Size = New System.Drawing.Size(75, 23)
		Me.btnRemoveTool.TabIndex = 7
		Me.btnRemoveTool.Text = "Remove"
		Me.btnRemoveTool.UseVisualStyleBackColor = True
		'
		'cboButtonStyle
		'
		Me.cboButtonStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cboButtonStyle.FormattingEnabled = True
		Me.cboButtonStyle.Items.AddRange(New Object() {"Text", "Image", "ImageAndText"})
		Me.cboButtonStyle.Location = New System.Drawing.Point(11, 144)
		Me.cboButtonStyle.Name = "cboButtonStyle"
		Me.cboButtonStyle.Size = New System.Drawing.Size(98, 23)
		Me.cboButtonStyle.TabIndex = 8
		'
		'grpOrientation
		'
		Me.grpOrientation.Controls.Add(Me.lblButtonStyle)
		Me.grpOrientation.Controls.Add(Me.lblTextDirection)
		Me.grpOrientation.Controls.Add(Me.lbldockLocation)
		Me.grpOrientation.Controls.Add(Me.cboDocking)
		Me.grpOrientation.Controls.Add(Me.cboButtonStyle)
		Me.grpOrientation.Controls.Add(Me.cboTextDirection)
		Me.grpOrientation.Location = New System.Drawing.Point(12, 128)
		Me.grpOrientation.Name = "grpOrientation"
		Me.grpOrientation.Size = New System.Drawing.Size(121, 184)
		Me.grpOrientation.TabIndex = 9
		Me.grpOrientation.TabStop = False
		Me.grpOrientation.Text = "ToolStrip Orientation"
		'
		'lblButtonStyle
		'
		Me.lblButtonStyle.AutoSize = True
		Me.lblButtonStyle.Location = New System.Drawing.Point(8, 128)
		Me.lblButtonStyle.Name = "lblButtonStyle"
		Me.lblButtonStyle.Size = New System.Drawing.Size(74, 15)
		Me.lblButtonStyle.TabIndex = 12
		Me.lblButtonStyle.Text = "Button Style:"
		'
		'lblTextDirection
		'
		Me.lblTextDirection.AutoSize = True
		Me.lblTextDirection.Location = New System.Drawing.Point(8, 78)
		Me.lblTextDirection.Name = "lblTextDirection"
		Me.lblTextDirection.Size = New System.Drawing.Size(82, 15)
		Me.lblTextDirection.TabIndex = 12
		Me.lblTextDirection.Text = "Text Direction:"
		'
		'lbldockLocation
		'
		Me.lbldockLocation.AutoSize = True
		Me.lbldockLocation.Location = New System.Drawing.Point(8, 27)
		Me.lbldockLocation.Name = "lbldockLocation"
		Me.lbldockLocation.Size = New System.Drawing.Size(86, 15)
		Me.lbldockLocation.TabIndex = 12
		Me.lbldockLocation.Text = "Dock Location:"
		'
		'grpToolBuild
		'
		Me.grpToolBuild.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
			Or System.Windows.Forms.AnchorStyles.Left) _
			Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.grpToolBuild.Controls.Add(Me.dgvImages)
		Me.grpToolBuild.Controls.Add(Me.btnEdit)
		Me.grpToolBuild.Controls.Add(Me.btnCancel)
		Me.grpToolBuild.Controls.Add(Me.cboClickFunctions)
		Me.grpToolBuild.Controls.Add(Me.lblFunctionName)
		Me.grpToolBuild.Controls.Add(Me.txtFullName)
		Me.grpToolBuild.Controls.Add(Me.lblFullName)
		Me.grpToolBuild.Controls.Add(Me.lblNickName)
		Me.grpToolBuild.Controls.Add(Me.txtNickName)
		Me.grpToolBuild.Controls.Add(Me.btnNew)
		Me.grpToolBuild.Controls.Add(Me.dgvTools)
		Me.grpToolBuild.Controls.Add(Me.btnAddTool)
		Me.grpToolBuild.Controls.Add(Me.btnRemoveTool)
		Me.grpToolBuild.Controls.Add(Me.txtNewToolNotice)
		Me.grpToolBuild.Location = New System.Drawing.Point(156, 5)
		Me.grpToolBuild.Name = "grpToolBuild"
		Me.grpToolBuild.Size = New System.Drawing.Size(336, 538)
		Me.grpToolBuild.TabIndex = 10
		Me.grpToolBuild.TabStop = False
		Me.grpToolBuild.Text = "Add or Remove Tools from Strip"
		'
		'dgvImages
		'
		Me.dgvImages.AllowUserToAddRows = False
		Me.dgvImages.AllowUserToDeleteRows = False
		Me.dgvImages.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
			Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
		Me.dgvImages.BackgroundColor = System.Drawing.SystemColors.Control
		Me.dgvImages.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
		Me.dgvImages.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Image, Me.ImageIndex})
		Me.dgvImages.Location = New System.Drawing.Point(6, 340)
		Me.dgvImages.MultiSelect = False
		Me.dgvImages.Name = "dgvImages"
		Me.dgvImages.ReadOnly = True
		Me.dgvImages.RowHeadersWidth = 10
		Me.dgvImages.RowTemplate.Height = 18
		Me.dgvImages.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
		Me.dgvImages.Size = New System.Drawing.Size(133, 184)
		Me.dgvImages.TabIndex = 17
		Me.dgvImages.Visible = False
		'
		'Image
		'
		Me.Image.HeaderText = "Image"
		Me.Image.Name = "Image"
		Me.Image.ReadOnly = True
		Me.Image.Width = 50
		'
		'ImageIndex
		'
		Me.ImageIndex.HeaderText = "Index"
		Me.ImageIndex.Name = "ImageIndex"
		Me.ImageIndex.ReadOnly = True
		Me.ImageIndex.Width = 50
		'
		'btnEdit
		'
		Me.btnEdit.Location = New System.Drawing.Point(168, 25)
		Me.btnEdit.Name = "btnEdit"
		Me.btnEdit.Size = New System.Drawing.Size(63, 23)
		Me.btnEdit.TabIndex = 8
		Me.btnEdit.Text = "EditName"
		Me.btnEdit.UseVisualStyleBackColor = True
		Me.btnEdit.Visible = False
		'
		'btnCancel
		'
		Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
		Me.btnCancel.Location = New System.Drawing.Point(252, 55)
		Me.btnCancel.Name = "btnCancel"
		Me.btnCancel.Size = New System.Drawing.Size(75, 23)
		Me.btnCancel.TabIndex = 16
		Me.btnCancel.Text = "Cancel"
		Me.btnCancel.UseVisualStyleBackColor = True
		Me.btnCancel.Visible = False
		'
		'cboClickFunctions
		'
		Me.cboClickFunctions.AllowDrop = True
		Me.cboClickFunctions.FormattingEnabled = True
		Me.cboClickFunctions.Location = New System.Drawing.Point(6, 313)
		Me.cboClickFunctions.Name = "cboClickFunctions"
		Me.cboClickFunctions.Size = New System.Drawing.Size(306, 23)
		Me.cboClickFunctions.Sorted = True
		Me.cboClickFunctions.TabIndex = 15
		Me.cboClickFunctions.Visible = False
		'
		'lblFunctionName
		'
		Me.lblFunctionName.AutoSize = True
		Me.lblFunctionName.Location = New System.Drawing.Point(9, 297)
		Me.lblFunctionName.Name = "lblFunctionName"
		Me.lblFunctionName.Size = New System.Drawing.Size(297, 15)
		Me.lblFunctionName.TabIndex = 13
		Me.lblFunctionName.Text = "FunctionName  (This is a list of Public Methods found.)"
		Me.lblFunctionName.Visible = False
		'
		'txtFullName
		'
		Me.txtFullName.AllowDrop = True
		Me.txtFullName.Location = New System.Drawing.Point(6, 257)
		Me.txtFullName.Name = "txtFullName"
		Me.txtFullName.Size = New System.Drawing.Size(306, 23)
		Me.txtFullName.TabIndex = 12
		Me.txtFullName.Visible = False
		'
		'lblFullName
		'
		Me.lblFullName.AutoSize = True
		Me.lblFullName.Location = New System.Drawing.Point(9, 241)
		Me.lblFullName.Name = "lblFullName"
		Me.lblFullName.Size = New System.Drawing.Size(61, 15)
		Me.lblFullName.TabIndex = 11
		Me.lblFullName.Text = "FullName:"
		Me.lblFullName.Visible = False
		'
		'lblNickName
		'
		Me.lblNickName.AutoSize = True
		Me.lblNickName.Location = New System.Drawing.Point(9, 187)
		Me.lblNickName.Name = "lblNickName"
		Me.lblNickName.Size = New System.Drawing.Size(66, 15)
		Me.lblNickName.TabIndex = 10
		Me.lblNickName.Text = "NickName:"
		Me.lblNickName.Visible = False
		'
		'txtNickName
		'
		Me.txtNickName.AllowDrop = True
		Me.txtNickName.Location = New System.Drawing.Point(6, 203)
		Me.txtNickName.Name = "txtNickName"
		Me.txtNickName.Size = New System.Drawing.Size(306, 23)
		Me.txtNickName.TabIndex = 9
		Me.txtNickName.Visible = False
		'
		'btnNew
		'
		Me.btnNew.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.btnNew.Location = New System.Drawing.Point(252, 25)
		Me.btnNew.Name = "btnNew"
		Me.btnNew.Size = New System.Drawing.Size(75, 23)
		Me.btnNew.TabIndex = 8
		Me.btnNew.Text = "New"
		Me.btnNew.UseVisualStyleBackColor = True
		Me.btnNew.Visible = False
		'
		'txtNewToolNotice
		'
		Me.txtNewToolNotice.BackColor = System.Drawing.Color.White
		Me.txtNewToolNotice.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.txtNewToolNotice.ForeColor = System.Drawing.Color.DimGray
		Me.txtNewToolNotice.Location = New System.Drawing.Point(12, 77)
		Me.txtNewToolNotice.Multiline = True
		Me.txtNewToolNotice.Name = "txtNewToolNotice"
		Me.txtNewToolNotice.ReadOnly = True
		Me.txtNewToolNotice.Size = New System.Drawing.Size(294, 110)
		Me.txtNewToolNotice.TabIndex = 12
		Me.txtNewToolNotice.Text = resources.GetString("txtNewToolNotice.Text")
		Me.txtNewToolNotice.Visible = False
		'
		'lstMenuItems
		'
		Me.lstMenuItems.AllowDrop = True
		Me.lstMenuItems.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
			Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
		Me.lstMenuItems.FormattingEnabled = True
		Me.lstMenuItems.ItemHeight = 15
		Me.lstMenuItems.Items.AddRange(New Object() {"Not Currently Used"})
		Me.lstMenuItems.Location = New System.Drawing.Point(0, 369)
		Me.lstMenuItems.Name = "lstMenuItems"
		Me.lstMenuItems.Size = New System.Drawing.Size(152, 79)
		Me.lstMenuItems.TabIndex = 9
		Me.lstMenuItems.Visible = False
		'
		'txtMessageReOrderButtons
		'
		Me.txtMessageReOrderButtons.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
		Me.txtMessageReOrderButtons.BackColor = System.Drawing.Color.White
		Me.txtMessageReOrderButtons.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.txtMessageReOrderButtons.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.txtMessageReOrderButtons.ForeColor = System.Drawing.Color.Gray
		Me.txtMessageReOrderButtons.Location = New System.Drawing.Point(4, 487)
		Me.txtMessageReOrderButtons.Multiline = True
		Me.txtMessageReOrderButtons.Name = "txtMessageReOrderButtons"
		Me.txtMessageReOrderButtons.ReadOnly = True
		Me.txtMessageReOrderButtons.Size = New System.Drawing.Size(146, 42)
		Me.txtMessageReOrderButtons.TabIndex = 11
		Me.txtMessageReOrderButtons.TabStop = False
		Me.txtMessageReOrderButtons.Text = "Note:  Buttons can be re-ordered on the ToolStrip using the ALT key.  (Don't forg" & _
	"et to save it!)"
		'
		'frmToolBuilder
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
		Me.ClientSize = New System.Drawing.Size(492, 552)
		Me.Controls.Add(Me.txtMessageReOrderButtons)
		Me.Controls.Add(Me.lstMenuItems)
		Me.Controls.Add(Me.grpToolBuild)
		Me.Controls.Add(Me.grpOrientation)
		Me.Controls.Add(Me.btnSaveTool)
		Me.Controls.Add(Me.ckShowTools)
		Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
		Me.MinimumSize = New System.Drawing.Size(495, 542)
		Me.Name = "frmToolBuilder"
		Me.ShowInTaskbar = False
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.Text = "MyTools Builder"
		CType(Me.dgvTools, System.ComponentModel.ISupportInitialize).EndInit()
		Me.grpOrientation.ResumeLayout(False)
		Me.grpOrientation.PerformLayout()
		Me.grpToolBuild.ResumeLayout(False)
		Me.grpToolBuild.PerformLayout()
		CType(Me.dgvImages, System.ComponentModel.ISupportInitialize).EndInit()
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub
    Friend WithEvents cboDocking As System.Windows.Forms.ComboBox
    Friend WithEvents cboTextDirection As System.Windows.Forms.ComboBox
    Friend WithEvents ckShowTools As System.Windows.Forms.CheckBox
    'Friend WithEvents ShapeContainer1 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
    'Friend WithEvents OvalShape1 As Microsoft.VisualBasic.PowerPacks.OvalShape
    Friend WithEvents btnSaveTool As System.Windows.Forms.Button
    Friend WithEvents btnAddTool As System.Windows.Forms.Button
    Friend WithEvents btnRemoveTool As System.Windows.Forms.Button
    Friend WithEvents cboButtonStyle As System.Windows.Forms.ComboBox
    Friend WithEvents grpOrientation As System.Windows.Forms.GroupBox
    Friend WithEvents grpToolBuild As System.Windows.Forms.GroupBox
    Friend WithEvents btnEdit As System.Windows.Forms.Button
    Friend WithEvents lstMenuItems As System.Windows.Forms.ListBox
    Public WithEvents dgvTools As System.Windows.Forms.DataGridView
    Friend WithEvents btnNew As System.Windows.Forms.Button
    Friend WithEvents txtNickName As System.Windows.Forms.TextBox
    Friend WithEvents lblFunctionName As System.Windows.Forms.Label
    Friend WithEvents txtFullName As System.Windows.Forms.TextBox
    Friend WithEvents lblFullName As System.Windows.Forms.Label
    Friend WithEvents lblNickName As System.Windows.Forms.Label
    Friend WithEvents cboClickFunctions As System.Windows.Forms.ComboBox
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents txtMessageReOrderButtons As System.Windows.Forms.TextBox
    Friend WithEvents txtNewToolNotice As System.Windows.Forms.TextBox
    Friend WithEvents lblTextDirection As System.Windows.Forms.Label
    Friend WithEvents lbldockLocation As System.Windows.Forms.Label
    Friend WithEvents lblButtonStyle As System.Windows.Forms.Label
    Friend WithEvents dgvImages As System.Windows.Forms.DataGridView
    Friend WithEvents Image As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents ImageIndex As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
