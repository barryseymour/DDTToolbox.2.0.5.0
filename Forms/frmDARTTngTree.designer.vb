<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDARTTngTree
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
		Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
		Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
		Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
		Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
		Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
		Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
		Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
		Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDARTTngTree))
		Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
		Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
		Me.ToolStripLblEditing = New System.Windows.Forms.ToolStripLabel()
		Me.pnlPrimaryContent = New System.Windows.Forms.Panel()
		Me.lblDragNode = New System.Windows.Forms.Label()
		Me.splTreeProps = New System.Windows.Forms.SplitContainer()
		Me.pnlCommittingChanges = New System.Windows.Forms.Panel()
		Me.pbCommittingChanges = New System.Windows.Forms.ProgressBar()
		Me.lblCommittingChanges = New System.Windows.Forms.Label()
		Me.cmTreeNodeOperations = New System.Windows.Forms.ContextMenuStrip(Me.components)
		Me.MoveUpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		Me.MoveDownToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		Me.CopyToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		Me.InsertToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		Me.pnlUsedReportNumbers = New System.Windows.Forms.Panel()
		Me.lblUsedReportNumbers = New System.Windows.Forms.Label()
		Me.dgvUsedReportNumbers = New System.Windows.Forms.DataGridView()
		Me.UsedRptNums = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.ReportID = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.lstUsedReportNumbers = New System.Windows.Forms.ListBox()
		Me.tcReportProperties = New System.Windows.Forms.TabControl()
		Me.tabTreeNodeProperties = New System.Windows.Forms.TabPage()
		Me.dgvImages = New System.Windows.Forms.DataGridView()
		Me.Img = New System.Windows.Forms.DataGridViewImageColumn()
		Me.ImageType = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.ImageID = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.ImageListIndex = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.IsFolder = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.dgvImagesFolderClosed = New System.Windows.Forms.DataGridView()
		Me.ImgClosed = New System.Windows.Forms.DataGridViewImageColumn()
		Me.ImageTypeClosed = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.ImageIDClosed = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.ImageListIndexClosed = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.IsFolderClosed = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.dgvTreeProperties = New System.Windows.Forms.DataGridView()
		Me.ReportProperty = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.ReportValue = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.FolderEditType = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.PrefEditType = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.ReportEditType = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.pnlItemControls = New System.Windows.Forms.Panel()
		Me.cboItemTypeSelect = New System.Windows.Forms.ComboBox()
		Me.rbReport = New System.Windows.Forms.RadioButton()
		Me.rbFolder = New System.Windows.Forms.RadioButton()
		Me.chkSchedulingEnabled = New System.Windows.Forms.CheckBox()
		Me.lblChangeItemTypeNotAllowed = New System.Windows.Forms.Label()
		Me.chkHelpButton = New System.Windows.Forms.CheckBox()
		Me.chkActive = New System.Windows.Forms.CheckBox()
		Me.tabReportControls = New System.Windows.Forms.TabPage()
		Me.grpRepControlsEdit = New System.Windows.Forms.GroupBox()
		Me.lblReportControlMessage = New System.Windows.Forms.Label()
		Me.btnControlADD = New System.Windows.Forms.Button()
		Me.btnControlDelete = New System.Windows.Forms.Button()
		Me.tcReportControls = New System.Windows.Forms.TabControl()
		Me.Grid = New System.Windows.Forms.TabPage()
		Me.dgvReportControls = New System.Windows.Forms.DataGridView()
		Me.cmReportControls = New System.Windows.Forms.ContextMenuStrip(Me.components)
		Me.cmsiAddNewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		Me.cmsiEditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		Me.cmsiDeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		Me.Graphical = New System.Windows.Forms.TabPage()
		Me.cboGridLines = New System.Windows.Forms.ComboBox()
		Me.lblUnits_AlignControls = New System.Windows.Forms.Label()
		Me.chkDisplayGridLines = New System.Windows.Forms.CheckBox()
		Me.tabControlForReportParams = New System.Windows.Forms.TabControl()
		Me.TabPage1 = New System.Windows.Forms.TabPage()
		Me.TabPage2 = New System.Windows.Forms.TabPage()
		Me.tabReportPropertiesView = New System.Windows.Forms.TabPage()
		Me.grpReportPropertiesView = New System.Windows.Forms.GroupBox()
		Me.dgvReportsView = New System.Windows.Forms.DataGridView()
		Me.PropertyName = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.PropertyValue = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.pnlGridLegend = New System.Windows.Forms.Panel()
		Me.lblOptionalValue = New System.Windows.Forms.Label()
		Me.lblRequiredValue = New System.Windows.Forms.Label()
		Me.lblReadOnlyValue = New System.Windows.Forms.Label()
		Me.pnlTreeLegend = New System.Windows.Forms.Panel()
		Me.Label1 = New System.Windows.Forms.Label()
		Me.pnlButtons = New System.Windows.Forms.Panel()
		Me.pnlSeparatorLine = New System.Windows.Forms.Panel()
		Me.pnlButtonsRight = New System.Windows.Forms.Panel()
		Me.btnRefresh = New System.Windows.Forms.Button()
		Me.btnCopyToProduction = New System.Windows.Forms.Button()
		Me.pnlButtonsCenter = New System.Windows.Forms.Panel()
		Me.btnCopyItem = New System.Windows.Forms.Button()
		Me.btnCancel = New System.Windows.Forms.Button()
		Me.btnSave = New System.Windows.Forms.Button()
		Me.btnEdit = New System.Windows.Forms.Button()
		Me.btnDelete = New System.Windows.Forms.Button()
		Me.btnInsert = New System.Windows.Forms.Button()
		Me.pnlButtonsLeft = New System.Windows.Forms.Panel()
		Me.btnOpenAllFolders = New System.Windows.Forms.Button()
		Me.btnCloseAllFolders = New System.Windows.Forms.Button()
		Me.btnMoveUp = New System.Windows.Forms.Button()
		Me.btnMoveDown = New System.Windows.Forms.Button()
		Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
		Me.lblEditingStatus = New System.Windows.Forms.ToolStripStatusLabel()
		Me.lblCopyItemBuffer = New System.Windows.Forms.ToolStripStatusLabel()
		Me.tmrControlBlink = New System.Windows.Forms.Timer(Me.components)
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
		Me.tmrBlinkEdit = New System.Windows.Forms.Timer(Me.components)
		Me.tvwDARTTng = New DDTToolbox.ExtTreeView()
		Me.btnControlEdit = New DDTToolbox.ExtButton()
		Me.cboColor_AlignControls = New DDTToolbox.clsColorComboBox()
		Me.btnShowControls = New DDTToolbox.ExtButton()
		Me.TreeImageList = New DDTToolbox.DDT_ImageList(Me.components)
		Me.ToolStrip1.SuspendLayout()
		Me.pnlPrimaryContent.SuspendLayout()
		CType(Me.splTreeProps, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.splTreeProps.Panel1.SuspendLayout()
		Me.splTreeProps.Panel2.SuspendLayout()
		Me.splTreeProps.SuspendLayout()
		Me.pnlCommittingChanges.SuspendLayout()
		Me.cmTreeNodeOperations.SuspendLayout()
		Me.pnlUsedReportNumbers.SuspendLayout()
		CType(Me.dgvUsedReportNumbers, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.tcReportProperties.SuspendLayout()
		Me.tabTreeNodeProperties.SuspendLayout()
		CType(Me.dgvImages, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.dgvImagesFolderClosed, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.dgvTreeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.pnlItemControls.SuspendLayout()
		Me.tabReportControls.SuspendLayout()
		Me.grpRepControlsEdit.SuspendLayout()
		Me.tcReportControls.SuspendLayout()
		Me.Grid.SuspendLayout()
		CType(Me.dgvReportControls, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.cmReportControls.SuspendLayout()
		Me.Graphical.SuspendLayout()
		Me.tabControlForReportParams.SuspendLayout()
		Me.tabReportPropertiesView.SuspendLayout()
		Me.grpReportPropertiesView.SuspendLayout()
		CType(Me.dgvReportsView, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.pnlGridLegend.SuspendLayout()
		Me.pnlTreeLegend.SuspendLayout()
		Me.pnlButtons.SuspendLayout()
		Me.pnlButtonsRight.SuspendLayout()
		Me.pnlButtonsCenter.SuspendLayout()
		Me.pnlButtonsLeft.SuspendLayout()
		Me.StatusStrip1.SuspendLayout()
		Me.SuspendLayout()
		'
		'ToolStrip1
		'
		Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator1, Me.ToolStripLblEditing})
		Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
		Me.ToolStrip1.Name = "ToolStrip1"
		Me.ToolStrip1.Size = New System.Drawing.Size(1156, 25)
		Me.ToolStrip1.TabIndex = 5
		Me.ToolStrip1.Text = "ToolStrip1"
		'
		'ToolStripSeparator1
		'
		Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
		Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
		'
		'ToolStripLblEditing
		'
		Me.ToolStripLblEditing.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.ToolStripLblEditing.ForeColor = System.Drawing.Color.Red
		Me.ToolStripLblEditing.Name = "ToolStripLblEditing"
		Me.ToolStripLblEditing.Size = New System.Drawing.Size(128, 22)
		Me.ToolStripLblEditing.Text = "--  EDITING  --"
		Me.ToolStripLblEditing.Visible = False
		'
		'pnlPrimaryContent
		'
		Me.pnlPrimaryContent.AutoSize = True
		Me.pnlPrimaryContent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.pnlPrimaryContent.Controls.Add(Me.lblDragNode)
		Me.pnlPrimaryContent.Controls.Add(Me.splTreeProps)
		Me.pnlPrimaryContent.Controls.Add(Me.pnlGridLegend)
		Me.pnlPrimaryContent.Controls.Add(Me.pnlTreeLegend)
		Me.pnlPrimaryContent.Controls.Add(Me.pnlButtons)
		Me.pnlPrimaryContent.Controls.Add(Me.StatusStrip1)
		Me.pnlPrimaryContent.Dock = System.Windows.Forms.DockStyle.Fill
		Me.pnlPrimaryContent.Location = New System.Drawing.Point(0, 25)
		Me.pnlPrimaryContent.Name = "pnlPrimaryContent"
		Me.pnlPrimaryContent.Size = New System.Drawing.Size(1156, 712)
		Me.pnlPrimaryContent.TabIndex = 6
		'
		'lblDragNode
		'
		Me.lblDragNode.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
		Me.lblDragNode.ForeColor = System.Drawing.Color.Gray
		Me.lblDragNode.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.lblDragNode.ImageIndex = 1
		Me.lblDragNode.Location = New System.Drawing.Point(184, 480)
		Me.lblDragNode.Name = "lblDragNode"
		Me.lblDragNode.Size = New System.Drawing.Size(120, 18)
		Me.lblDragNode.TabIndex = 12
		Me.lblDragNode.Text = "      Drag label"
		Me.lblDragNode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.lblDragNode.Visible = False
		'
		'splTreeProps
		'
		Me.splTreeProps.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
			Or System.Windows.Forms.AnchorStyles.Left) _
			Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.splTreeProps.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.splTreeProps.Location = New System.Drawing.Point(-1, 2)
		Me.splTreeProps.Name = "splTreeProps"
		'
		'splTreeProps.Panel1
		'
		Me.splTreeProps.Panel1.BackColor = System.Drawing.SystemColors.Window
		Me.splTreeProps.Panel1.Controls.Add(Me.pnlCommittingChanges)
		Me.splTreeProps.Panel1.Controls.Add(Me.tvwDARTTng)
		Me.splTreeProps.Panel1MinSize = 200
		'
		'splTreeProps.Panel2
		'
		Me.splTreeProps.Panel2.Controls.Add(Me.pnlUsedReportNumbers)
		Me.splTreeProps.Panel2.Controls.Add(Me.tcReportProperties)
		Me.splTreeProps.Panel2MinSize = 100
		Me.splTreeProps.Size = New System.Drawing.Size(1155, 602)
		Me.splTreeProps.SplitterDistance = 365
		Me.splTreeProps.SplitterWidth = 3
		Me.splTreeProps.TabIndex = 27
		'
		'pnlCommittingChanges
		'
		Me.pnlCommittingChanges.BackColor = System.Drawing.SystemColors.Control
		Me.pnlCommittingChanges.Controls.Add(Me.pbCommittingChanges)
		Me.pnlCommittingChanges.Controls.Add(Me.lblCommittingChanges)
		Me.pnlCommittingChanges.Location = New System.Drawing.Point(4, 67)
		Me.pnlCommittingChanges.Name = "pnlCommittingChanges"
		Me.pnlCommittingChanges.Size = New System.Drawing.Size(316, 71)
		Me.pnlCommittingChanges.TabIndex = 23
		Me.pnlCommittingChanges.Visible = False
		'
		'pbCommittingChanges
		'
		Me.pbCommittingChanges.Location = New System.Drawing.Point(16, 39)
		Me.pbCommittingChanges.Name = "pbCommittingChanges"
		Me.pbCommittingChanges.Size = New System.Drawing.Size(285, 15)
		Me.pbCommittingChanges.TabIndex = 1
		'
		'lblCommittingChanges
		'
		Me.lblCommittingChanges.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblCommittingChanges.Location = New System.Drawing.Point(16, 6)
		Me.lblCommittingChanges.Name = "lblCommittingChanges"
		Me.lblCommittingChanges.Size = New System.Drawing.Size(297, 23)
		Me.lblCommittingChanges.TabIndex = 0
		Me.lblCommittingChanges.Text = "Committing changes..."
		Me.lblCommittingChanges.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		'
		'cmTreeNodeOperations
		'
		Me.cmTreeNodeOperations.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MoveUpToolStripMenuItem, Me.MoveDownToolStripMenuItem, Me.CopyToolStripMenuItem, Me.EditToolStripMenuItem, Me.InsertToolStripMenuItem, Me.DeleteToolStripMenuItem})
		Me.cmTreeNodeOperations.Name = "cmTreeNodeOperations"
		Me.cmTreeNodeOperations.Size = New System.Drawing.Size(139, 136)
		'
		'MoveUpToolStripMenuItem
		'
		Me.MoveUpToolStripMenuItem.Name = "MoveUpToolStripMenuItem"
		Me.MoveUpToolStripMenuItem.Size = New System.Drawing.Size(138, 22)
		Me.MoveUpToolStripMenuItem.Text = "Move Up"
		'
		'MoveDownToolStripMenuItem
		'
		Me.MoveDownToolStripMenuItem.Name = "MoveDownToolStripMenuItem"
		Me.MoveDownToolStripMenuItem.Size = New System.Drawing.Size(138, 22)
		Me.MoveDownToolStripMenuItem.Text = "Move Down"
		'
		'CopyToolStripMenuItem
		'
		Me.CopyToolStripMenuItem.Name = "CopyToolStripMenuItem"
		Me.CopyToolStripMenuItem.Size = New System.Drawing.Size(138, 22)
		Me.CopyToolStripMenuItem.Text = "Copy"
		'
		'EditToolStripMenuItem
		'
		Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
		Me.EditToolStripMenuItem.Size = New System.Drawing.Size(138, 22)
		Me.EditToolStripMenuItem.Text = "Edit"
		'
		'InsertToolStripMenuItem
		'
		Me.InsertToolStripMenuItem.Name = "InsertToolStripMenuItem"
		Me.InsertToolStripMenuItem.Size = New System.Drawing.Size(138, 22)
		Me.InsertToolStripMenuItem.Text = "Insert"
		'
		'DeleteToolStripMenuItem
		'
		Me.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem"
		Me.DeleteToolStripMenuItem.Size = New System.Drawing.Size(138, 22)
		Me.DeleteToolStripMenuItem.Text = "Delete"
		'
		'pnlUsedReportNumbers
		'
		Me.pnlUsedReportNumbers.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
			Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
		Me.pnlUsedReportNumbers.Controls.Add(Me.lblUsedReportNumbers)
		Me.pnlUsedReportNumbers.Controls.Add(Me.dgvUsedReportNumbers)
		Me.pnlUsedReportNumbers.Controls.Add(Me.lstUsedReportNumbers)
		Me.pnlUsedReportNumbers.Location = New System.Drawing.Point(2, 3)
		Me.pnlUsedReportNumbers.Name = "pnlUsedReportNumbers"
		Me.pnlUsedReportNumbers.Size = New System.Drawing.Size(92, 597)
		Me.pnlUsedReportNumbers.TabIndex = 34
		'
		'lblUsedReportNumbers
		'
		Me.lblUsedReportNumbers.BackColor = System.Drawing.SystemColors.ButtonFace
		Me.lblUsedReportNumbers.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.lblUsedReportNumbers.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblUsedReportNumbers.Location = New System.Drawing.Point(1, 1)
		Me.lblUsedReportNumbers.Name = "lblUsedReportNumbers"
		Me.lblUsedReportNumbers.Size = New System.Drawing.Size(90, 21)
		Me.lblUsedReportNumbers.TabIndex = 23
		Me.lblUsedReportNumbers.Text = "Used Rpt #s"
		Me.lblUsedReportNumbers.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		'
		'dgvUsedReportNumbers
		'
		Me.dgvUsedReportNumbers.AllowUserToAddRows = False
		Me.dgvUsedReportNumbers.AllowUserToDeleteRows = False
		Me.dgvUsedReportNumbers.AllowUserToResizeColumns = False
		Me.dgvUsedReportNumbers.AllowUserToResizeRows = False
		Me.dgvUsedReportNumbers.BackgroundColor = System.Drawing.SystemColors.Control
		DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.BottomLeft
		DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
		DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
		DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
		DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
		DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
		Me.dgvUsedReportNumbers.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
		Me.dgvUsedReportNumbers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
		Me.dgvUsedReportNumbers.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.UsedRptNums, Me.ReportID})
		Me.dgvUsedReportNumbers.Dock = System.Windows.Forms.DockStyle.Fill
		Me.dgvUsedReportNumbers.Location = New System.Drawing.Point(0, 0)
		Me.dgvUsedReportNumbers.MultiSelect = False
		Me.dgvUsedReportNumbers.Name = "dgvUsedReportNumbers"
		Me.dgvUsedReportNumbers.ReadOnly = True
		DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
		DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
		DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
		DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
		DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
		DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
		Me.dgvUsedReportNumbers.RowHeadersDefaultCellStyle = DataGridViewCellStyle2
		Me.dgvUsedReportNumbers.RowHeadersVisible = False
		DataGridViewCellStyle3.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.dgvUsedReportNumbers.RowsDefaultCellStyle = DataGridViewCellStyle3
		Me.dgvUsedReportNumbers.RowTemplate.Height = 18
		Me.dgvUsedReportNumbers.ShowCellToolTips = False
		Me.dgvUsedReportNumbers.ShowEditingIcon = False
		Me.dgvUsedReportNumbers.Size = New System.Drawing.Size(92, 597)
		Me.dgvUsedReportNumbers.TabIndex = 25
		'
		'UsedRptNums
		'
		Me.UsedRptNums.HeaderText = "Used Rpt #s"
		Me.UsedRptNums.Name = "UsedRptNums"
		Me.UsedRptNums.ReadOnly = True
		Me.UsedRptNums.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
		Me.UsedRptNums.Width = 74
		'
		'ReportID
		'
		Me.ReportID.HeaderText = "ReportID"
		Me.ReportID.Name = "ReportID"
		Me.ReportID.ReadOnly = True
		Me.ReportID.Visible = False
		'
		'lstUsedReportNumbers
		'
		Me.lstUsedReportNumbers.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lstUsedReportNumbers.FormattingEnabled = True
		Me.lstUsedReportNumbers.IntegralHeight = False
		Me.lstUsedReportNumbers.Location = New System.Drawing.Point(0, 0)
		Me.lstUsedReportNumbers.Name = "lstUsedReportNumbers"
		Me.lstUsedReportNumbers.Size = New System.Drawing.Size(72, 439)
		Me.lstUsedReportNumbers.TabIndex = 22
		'
		'tcReportProperties
		'
		Me.tcReportProperties.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
			Or System.Windows.Forms.AnchorStyles.Left) _
			Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.tcReportProperties.Controls.Add(Me.tabTreeNodeProperties)
		Me.tcReportProperties.Controls.Add(Me.tabReportControls)
		Me.tcReportProperties.Controls.Add(Me.tabReportPropertiesView)
		Me.tcReportProperties.Location = New System.Drawing.Point(96, 3)
		Me.tcReportProperties.Name = "tcReportProperties"
		Me.tcReportProperties.SelectedIndex = 0
		Me.tcReportProperties.Size = New System.Drawing.Size(724, 598)
		Me.tcReportProperties.TabIndex = 33
		'
		'tabTreeNodeProperties
		'
		Me.tabTreeNodeProperties.BackColor = System.Drawing.SystemColors.Control
		Me.tabTreeNodeProperties.Controls.Add(Me.dgvImages)
		Me.tabTreeNodeProperties.Controls.Add(Me.dgvImagesFolderClosed)
		Me.tabTreeNodeProperties.Controls.Add(Me.dgvTreeProperties)
		Me.tabTreeNodeProperties.Controls.Add(Me.pnlItemControls)
		Me.tabTreeNodeProperties.Location = New System.Drawing.Point(4, 24)
		Me.tabTreeNodeProperties.Name = "tabTreeNodeProperties"
		Me.tabTreeNodeProperties.Size = New System.Drawing.Size(716, 570)
		Me.tabTreeNodeProperties.TabIndex = 2
		Me.tabTreeNodeProperties.Text = "TreeNodeProperties"
		'
		'dgvImages
		'
		Me.dgvImages.AllowUserToAddRows = False
		Me.dgvImages.AllowUserToDeleteRows = False
		Me.dgvImages.AllowUserToResizeColumns = False
		Me.dgvImages.AllowUserToResizeRows = False
		Me.dgvImages.BackgroundColor = System.Drawing.SystemColors.Control
		Me.dgvImages.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
		Me.dgvImages.ColumnHeadersVisible = False
		Me.dgvImages.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Img, Me.ImageType, Me.ImageID, Me.ImageListIndex, Me.IsFolder})
		DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
		DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window
		DataGridViewCellStyle4.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText
		DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.PowderBlue
		DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.ControlText
		DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
		Me.dgvImages.DefaultCellStyle = DataGridViewCellStyle4
		Me.dgvImages.Enabled = False
		Me.dgvImages.ImeMode = System.Windows.Forms.ImeMode.NoControl
		Me.dgvImages.Location = New System.Drawing.Point(3, 71)
		Me.dgvImages.MultiSelect = False
		Me.dgvImages.Name = "dgvImages"
		Me.dgvImages.ReadOnly = True
		Me.dgvImages.RowHeadersVisible = False
		Me.dgvImages.RowTemplate.Height = 18
		Me.dgvImages.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.dgvImages.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
		Me.dgvImages.ShowCellToolTips = False
		Me.dgvImages.ShowEditingIcon = False
		Me.dgvImages.Size = New System.Drawing.Size(208, 21)
		Me.dgvImages.StandardTab = True
		Me.dgvImages.TabIndex = 33
		'
		'Img
		'
		Me.Img.Frozen = True
		Me.Img.HeaderText = "Img"
		Me.Img.Name = "Img"
		Me.Img.ReadOnly = True
		Me.Img.Width = 30
		'
		'ImageType
		'
		Me.ImageType.HeaderText = "ImageType"
		Me.ImageType.Name = "ImageType"
		Me.ImageType.ReadOnly = True
		Me.ImageType.Width = 175
		'
		'ImageID
		'
		Me.ImageID.HeaderText = "ImageID"
		Me.ImageID.Name = "ImageID"
		Me.ImageID.ReadOnly = True
		Me.ImageID.Width = 40
		'
		'ImageListIndex
		'
		Me.ImageListIndex.HeaderText = "ImageListIndex"
		Me.ImageListIndex.Name = "ImageListIndex"
		Me.ImageListIndex.ReadOnly = True
		'
		'IsFolder
		'
		Me.IsFolder.HeaderText = "IsFolder"
		Me.IsFolder.Name = "IsFolder"
		Me.IsFolder.ReadOnly = True
		Me.IsFolder.Visible = False
		'
		'dgvImagesFolderClosed
		'
		Me.dgvImagesFolderClosed.AllowUserToAddRows = False
		Me.dgvImagesFolderClosed.AllowUserToDeleteRows = False
		Me.dgvImagesFolderClosed.AllowUserToResizeColumns = False
		Me.dgvImagesFolderClosed.AllowUserToResizeRows = False
		Me.dgvImagesFolderClosed.BackgroundColor = System.Drawing.SystemColors.Control
		Me.dgvImagesFolderClosed.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
		Me.dgvImagesFolderClosed.ColumnHeadersVisible = False
		Me.dgvImagesFolderClosed.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ImgClosed, Me.ImageTypeClosed, Me.ImageIDClosed, Me.ImageListIndexClosed, Me.IsFolderClosed})
		DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
		DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window
		DataGridViewCellStyle5.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText
		DataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.PowderBlue
		DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.ControlText
		DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
		Me.dgvImagesFolderClosed.DefaultCellStyle = DataGridViewCellStyle5
		Me.dgvImagesFolderClosed.Enabled = False
		Me.dgvImagesFolderClosed.Location = New System.Drawing.Point(233, 71)
		Me.dgvImagesFolderClosed.MultiSelect = False
		Me.dgvImagesFolderClosed.Name = "dgvImagesFolderClosed"
		Me.dgvImagesFolderClosed.ReadOnly = True
		Me.dgvImagesFolderClosed.RowHeadersVisible = False
		Me.dgvImagesFolderClosed.RowTemplate.Height = 18
		Me.dgvImagesFolderClosed.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.dgvImagesFolderClosed.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
		Me.dgvImagesFolderClosed.Size = New System.Drawing.Size(208, 21)
		Me.dgvImagesFolderClosed.TabIndex = 35
		'
		'ImgClosed
		'
		Me.ImgClosed.HeaderText = "ImgClosed"
		Me.ImgClosed.Name = "ImgClosed"
		Me.ImgClosed.ReadOnly = True
		Me.ImgClosed.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
		Me.ImgClosed.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
		Me.ImgClosed.Width = 30
		'
		'ImageTypeClosed
		'
		Me.ImageTypeClosed.HeaderText = "ImageTypeClosed"
		Me.ImageTypeClosed.Name = "ImageTypeClosed"
		Me.ImageTypeClosed.ReadOnly = True
		Me.ImageTypeClosed.Width = 175
		'
		'ImageIDClosed
		'
		Me.ImageIDClosed.HeaderText = "ImageIDClosed"
		Me.ImageIDClosed.Name = "ImageIDClosed"
		Me.ImageIDClosed.ReadOnly = True
		'
		'ImageListIndexClosed
		'
		Me.ImageListIndexClosed.HeaderText = "ImageListIndexClosed"
		Me.ImageListIndexClosed.Name = "ImageListIndexClosed"
		Me.ImageListIndexClosed.ReadOnly = True
		'
		'IsFolderClosed
		'
		Me.IsFolderClosed.HeaderText = "IsFolderClosed"
		Me.IsFolderClosed.Name = "IsFolderClosed"
		Me.IsFolderClosed.ReadOnly = True
		'
		'dgvTreeProperties
		'
		Me.dgvTreeProperties.AllowUserToAddRows = False
		Me.dgvTreeProperties.AllowUserToDeleteRows = False
		Me.dgvTreeProperties.AllowUserToResizeRows = False
		Me.dgvTreeProperties.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
			Or System.Windows.Forms.AnchorStyles.Left) _
			Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.dgvTreeProperties.BackgroundColor = System.Drawing.SystemColors.Control
		Me.dgvTreeProperties.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.dgvTreeProperties.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
		Me.dgvTreeProperties.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ReportProperty, Me.ReportValue, Me.FolderEditType, Me.PrefEditType, Me.ReportEditType})
		Me.dgvTreeProperties.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
		Me.dgvTreeProperties.Location = New System.Drawing.Point(0, 183)
		Me.dgvTreeProperties.MultiSelect = False
		Me.dgvTreeProperties.Name = "dgvTreeProperties"
		Me.dgvTreeProperties.RowHeadersVisible = False
		Me.dgvTreeProperties.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
		Me.dgvTreeProperties.RowTemplate.Height = 18
		Me.dgvTreeProperties.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
		Me.dgvTreeProperties.Size = New System.Drawing.Size(682, 456)
		Me.dgvTreeProperties.TabIndex = 34
		'
		'ReportProperty
		'
		Me.ReportProperty.DataPropertyName = "ReportProperty"
		DataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
		DataGridViewCellStyle6.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.ReportProperty.DefaultCellStyle = DataGridViewCellStyle6
		Me.ReportProperty.HeaderText = "Property"
		Me.ReportProperty.Name = "ReportProperty"
		Me.ReportProperty.ReadOnly = True
		Me.ReportProperty.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
		Me.ReportProperty.Width = 180
		'
		'ReportValue
		'
		Me.ReportValue.DataPropertyName = "Value"
		DataGridViewCellStyle7.BackColor = System.Drawing.Color.White
		Me.ReportValue.DefaultCellStyle = DataGridViewCellStyle7
		Me.ReportValue.HeaderText = "Value"
		Me.ReportValue.Name = "ReportValue"
		Me.ReportValue.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
		Me.ReportValue.Width = 240
		'
		'FolderEditType
		'
		Me.FolderEditType.DataPropertyName = "FolderEditType"
		Me.FolderEditType.HeaderText = "FolderEditType"
		Me.FolderEditType.Name = "FolderEditType"
		Me.FolderEditType.ReadOnly = True
		Me.FolderEditType.Visible = False
		'
		'PrefEditType
		'
		Me.PrefEditType.DataPropertyName = "PrefEditType"
		Me.PrefEditType.HeaderText = "PrefEditType"
		Me.PrefEditType.Name = "PrefEditType"
		Me.PrefEditType.Visible = False
		'
		'ReportEditType
		'
		Me.ReportEditType.DataPropertyName = "ReportEditType"
		Me.ReportEditType.HeaderText = "ReportEditType"
		Me.ReportEditType.Name = "ReportEditType"
		Me.ReportEditType.Visible = False
		'
		'pnlItemControls
		'
		Me.pnlItemControls.Controls.Add(Me.cboItemTypeSelect)
		Me.pnlItemControls.Controls.Add(Me.rbReport)
		Me.pnlItemControls.Controls.Add(Me.rbFolder)
		Me.pnlItemControls.Controls.Add(Me.chkSchedulingEnabled)
		Me.pnlItemControls.Controls.Add(Me.lblChangeItemTypeNotAllowed)
		Me.pnlItemControls.Controls.Add(Me.chkHelpButton)
		Me.pnlItemControls.Controls.Add(Me.chkActive)
		Me.pnlItemControls.Dock = System.Windows.Forms.DockStyle.Top
		Me.pnlItemControls.ForeColor = System.Drawing.Color.Black
		Me.pnlItemControls.Location = New System.Drawing.Point(0, 0)
		Me.pnlItemControls.Name = "pnlItemControls"
		Me.pnlItemControls.Size = New System.Drawing.Size(716, 65)
		Me.pnlItemControls.TabIndex = 3
		'
		'cboItemTypeSelect
		'
		Me.cboItemTypeSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cboItemTypeSelect.FormattingEnabled = True
		Me.cboItemTypeSelect.Location = New System.Drawing.Point(132, 41)
		Me.cboItemTypeSelect.MaxDropDownItems = 25
		Me.cboItemTypeSelect.Name = "cboItemTypeSelect"
		Me.cboItemTypeSelect.Size = New System.Drawing.Size(383, 23)
		Me.cboItemTypeSelect.TabIndex = 18
		Me.ToolTip1.SetToolTip(Me.cboItemTypeSelect, "Valid Reports" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Select a report from the list.")
		'
		'rbReport
		'
		Me.rbReport.AutoSize = True
		Me.rbReport.Location = New System.Drawing.Point(69, 45)
		Me.rbReport.Name = "rbReport"
		Me.rbReport.Size = New System.Drawing.Size(60, 19)
		Me.rbReport.TabIndex = 16
		Me.rbReport.Text = "Report"
		Me.rbReport.UseVisualStyleBackColor = True
		'
		'rbFolder
		'
		Me.rbFolder.AutoSize = True
		Me.rbFolder.Location = New System.Drawing.Point(4, 45)
		Me.rbFolder.Name = "rbFolder"
		Me.rbFolder.Size = New System.Drawing.Size(58, 19)
		Me.rbFolder.TabIndex = 15
		Me.rbFolder.Text = "Folder"
		Me.rbFolder.UseVisualStyleBackColor = True
		'
		'chkSchedulingEnabled
		'
		Me.chkSchedulingEnabled.Location = New System.Drawing.Point(13, 11)
		Me.chkSchedulingEnabled.Name = "chkSchedulingEnabled"
		Me.chkSchedulingEnabled.Size = New System.Drawing.Size(124, 24)
		Me.chkSchedulingEnabled.TabIndex = 14
		Me.chkSchedulingEnabled.Text = "Allow Scheduling"
		Me.chkSchedulingEnabled.UseVisualStyleBackColor = True
		'
		'lblChangeItemTypeNotAllowed
		'
		Me.lblChangeItemTypeNotAllowed.AutoSize = True
		Me.lblChangeItemTypeNotAllowed.Location = New System.Drawing.Point(521, 44)
		Me.lblChangeItemTypeNotAllowed.Name = "lblChangeItemTypeNotAllowed"
		Me.lblChangeItemTypeNotAllowed.Size = New System.Drawing.Size(272, 15)
		Me.lblChangeItemTypeNotAllowed.TabIndex = 11
		Me.lblChangeItemTypeNotAllowed.Text = "(can't change because folder contains child items)"
		Me.lblChangeItemTypeNotAllowed.Visible = False
		'
		'chkHelpButton
		'
		Me.chkHelpButton.Location = New System.Drawing.Point(150, 11)
		Me.chkHelpButton.Name = "chkHelpButton"
		Me.chkHelpButton.Size = New System.Drawing.Size(99, 24)
		Me.chkHelpButton.TabIndex = 5
		Me.chkHelpButton.Text = "Help Button"
		Me.chkHelpButton.UseVisualStyleBackColor = True
		'
		'chkActive
		'
		Me.chkActive.Location = New System.Drawing.Point(260, 11)
		Me.chkActive.Name = "chkActive"
		Me.chkActive.Size = New System.Drawing.Size(74, 24)
		Me.chkActive.TabIndex = 0
		Me.chkActive.Text = "Active"
		Me.chkActive.UseVisualStyleBackColor = True
		'
		'tabReportControls
		'
		Me.tabReportControls.Controls.Add(Me.grpRepControlsEdit)
		Me.tabReportControls.Controls.Add(Me.tcReportControls)
		Me.tabReportControls.Location = New System.Drawing.Point(4, 24)
		Me.tabReportControls.Name = "tabReportControls"
		Me.tabReportControls.Padding = New System.Windows.Forms.Padding(3)
		Me.tabReportControls.Size = New System.Drawing.Size(716, 570)
		Me.tabReportControls.TabIndex = 1
		Me.tabReportControls.Text = "ReportControls"
		Me.tabReportControls.UseVisualStyleBackColor = True
		'
		'grpRepControlsEdit
		'
		Me.grpRepControlsEdit.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
			Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.grpRepControlsEdit.Controls.Add(Me.lblReportControlMessage)
		Me.grpRepControlsEdit.Controls.Add(Me.btnControlEdit)
		Me.grpRepControlsEdit.Controls.Add(Me.btnControlADD)
		Me.grpRepControlsEdit.Controls.Add(Me.btnControlDelete)
		Me.grpRepControlsEdit.Location = New System.Drawing.Point(3, 3)
		Me.grpRepControlsEdit.Name = "grpRepControlsEdit"
		Me.grpRepControlsEdit.Size = New System.Drawing.Size(729, 41)
		Me.grpRepControlsEdit.TabIndex = 17
		Me.grpRepControlsEdit.TabStop = False
		Me.grpRepControlsEdit.Text = "Controls Editing"
		'
		'lblReportControlMessage
		'
		Me.lblReportControlMessage.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.lblReportControlMessage.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblReportControlMessage.ForeColor = System.Drawing.Color.Blue
		Me.lblReportControlMessage.Location = New System.Drawing.Point(518, 17)
		Me.lblReportControlMessage.Name = "lblReportControlMessage"
		Me.lblReportControlMessage.Size = New System.Drawing.Size(194, 13)
		Me.lblReportControlMessage.TabIndex = 16
		Me.lblReportControlMessage.Text = "To Edit Controls, First Save the TreeNode"
		Me.lblReportControlMessage.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'btnControlADD
		'
		Me.btnControlADD.Location = New System.Drawing.Point(72, 16)
		Me.btnControlADD.Name = "btnControlADD"
		Me.btnControlADD.Size = New System.Drawing.Size(80, 23)
		Me.btnControlADD.TabIndex = 13
		Me.btnControlADD.Text = "Add"
		Me.btnControlADD.UseVisualStyleBackColor = True
		'
		'btnControlDelete
		'
		Me.btnControlDelete.Location = New System.Drawing.Point(255, 16)
		Me.btnControlDelete.Name = "btnControlDelete"
		Me.btnControlDelete.Size = New System.Drawing.Size(80, 23)
		Me.btnControlDelete.TabIndex = 14
		Me.btnControlDelete.Text = "Delete"
		Me.btnControlDelete.UseVisualStyleBackColor = True
		'
		'tcReportControls
		'
		Me.tcReportControls.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
			Or System.Windows.Forms.AnchorStyles.Left) _
			Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.tcReportControls.Controls.Add(Me.Grid)
		Me.tcReportControls.Controls.Add(Me.Graphical)
		Me.tcReportControls.Location = New System.Drawing.Point(3, 50)
		Me.tcReportControls.Name = "tcReportControls"
		Me.tcReportControls.SelectedIndex = 0
		Me.tcReportControls.Size = New System.Drawing.Size(739, 522)
		Me.tcReportControls.TabIndex = 16
		'
		'Grid
		'
		Me.Grid.Controls.Add(Me.dgvReportControls)
		Me.Grid.Location = New System.Drawing.Point(4, 24)
		Me.Grid.Name = "Grid"
		Me.Grid.Padding = New System.Windows.Forms.Padding(3)
		Me.Grid.Size = New System.Drawing.Size(731, 494)
		Me.Grid.TabIndex = 1
		Me.Grid.Text = "Grid"
		Me.Grid.UseVisualStyleBackColor = True
		'
		'dgvReportControls
		'
		Me.dgvReportControls.AllowUserToAddRows = False
		Me.dgvReportControls.AllowUserToDeleteRows = False
		Me.dgvReportControls.AllowUserToOrderColumns = True
		Me.dgvReportControls.AllowUserToResizeRows = False
		Me.dgvReportControls.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
			Or System.Windows.Forms.AnchorStyles.Left) _
			Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.dgvReportControls.BackgroundColor = System.Drawing.Color.White
		Me.dgvReportControls.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
		Me.dgvReportControls.ContextMenuStrip = Me.cmReportControls
		Me.dgvReportControls.Location = New System.Drawing.Point(3, 6)
		Me.dgvReportControls.MultiSelect = False
		Me.dgvReportControls.Name = "dgvReportControls"
		Me.dgvReportControls.ReadOnly = True
		Me.dgvReportControls.RowHeadersVisible = False
		Me.dgvReportControls.RowTemplate.Height = 18
		Me.dgvReportControls.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
		Me.dgvReportControls.ShowCellToolTips = False
		Me.dgvReportControls.Size = New System.Drawing.Size(727, 486)
		Me.dgvReportControls.TabIndex = 12
		'
		'cmReportControls
		'
		Me.cmReportControls.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cmsiAddNewToolStripMenuItem, Me.cmsiEditToolStripMenuItem, Me.cmsiDeleteToolStripMenuItem})
		Me.cmReportControls.Margin = New System.Windows.Forms.Padding(0, 25, 0, 0)
		Me.cmReportControls.Name = "cmSetChildRelationships"
		Me.cmReportControls.ShowItemToolTips = False
		Me.cmReportControls.Size = New System.Drawing.Size(124, 70)
		Me.cmReportControls.Text = "Modify Report Controls"
		'
		'cmsiAddNewToolStripMenuItem
		'
		Me.cmsiAddNewToolStripMenuItem.Name = "cmsiAddNewToolStripMenuItem"
		Me.cmsiAddNewToolStripMenuItem.Size = New System.Drawing.Size(123, 22)
		Me.cmsiAddNewToolStripMenuItem.Text = "Add New"
		'
		'cmsiEditToolStripMenuItem
		'
		Me.cmsiEditToolStripMenuItem.Name = "cmsiEditToolStripMenuItem"
		Me.cmsiEditToolStripMenuItem.Size = New System.Drawing.Size(123, 22)
		Me.cmsiEditToolStripMenuItem.Text = "Edit"
		'
		'cmsiDeleteToolStripMenuItem
		'
		Me.cmsiDeleteToolStripMenuItem.Name = "cmsiDeleteToolStripMenuItem"
		Me.cmsiDeleteToolStripMenuItem.Size = New System.Drawing.Size(123, 22)
		Me.cmsiDeleteToolStripMenuItem.Text = "Delete"
		'
		'Graphical
		'
		Me.Graphical.AutoScroll = True
		Me.Graphical.Controls.Add(Me.cboGridLines)
		Me.Graphical.Controls.Add(Me.lblUnits_AlignControls)
		Me.Graphical.Controls.Add(Me.chkDisplayGridLines)
		Me.Graphical.Controls.Add(Me.tabControlForReportParams)
		Me.Graphical.Controls.Add(Me.cboColor_AlignControls)
		Me.Graphical.Controls.Add(Me.btnShowControls)
		Me.Graphical.Location = New System.Drawing.Point(4, 24)
		Me.Graphical.Name = "Graphical"
		Me.Graphical.Padding = New System.Windows.Forms.Padding(3)
		Me.Graphical.Size = New System.Drawing.Size(731, 494)
		Me.Graphical.TabIndex = 0
		Me.Graphical.Text = "Graphical"
		Me.Graphical.UseVisualStyleBackColor = True
		'
		'cboGridLines
		'
		Me.cboGridLines.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.cboGridLines.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cboGridLines.FormattingEnabled = True
		Me.cboGridLines.Items.AddRange(New Object() {"25", "50", "100", "150", "200", "250", "300"})
		Me.cboGridLines.Location = New System.Drawing.Point(341, 4)
		Me.cboGridLines.Name = "cboGridLines"
		Me.cboGridLines.Size = New System.Drawing.Size(53, 23)
		Me.cboGridLines.TabIndex = 25
		Me.cboGridLines.Visible = False
		'
		'lblUnits_AlignControls
		'
		Me.lblUnits_AlignControls.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.lblUnits_AlignControls.AutoSize = True
		Me.lblUnits_AlignControls.Location = New System.Drawing.Point(305, 7)
		Me.lblUnits_AlignControls.Name = "lblUnits_AlignControls"
		Me.lblUnits_AlignControls.Size = New System.Drawing.Size(37, 15)
		Me.lblUnits_AlignControls.TabIndex = 21
		Me.lblUnits_AlignControls.Text = "Units:"
		Me.lblUnits_AlignControls.Visible = False
		'
		'chkDisplayGridLines
		'
		Me.chkDisplayGridLines.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.chkDisplayGridLines.AutoSize = True
		Me.chkDisplayGridLines.Location = New System.Drawing.Point(410, 7)
		Me.chkDisplayGridLines.Name = "chkDisplayGridLines"
		Me.chkDisplayGridLines.RightToLeft = System.Windows.Forms.RightToLeft.Yes
		Me.chkDisplayGridLines.Size = New System.Drawing.Size(81, 19)
		Me.chkDisplayGridLines.TabIndex = 24
		Me.chkDisplayGridLines.Text = "Grid Lines:"
		Me.chkDisplayGridLines.UseVisualStyleBackColor = True
		'
		'tabControlForReportParams
		'
		Me.tabControlForReportParams.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
			Or System.Windows.Forms.AnchorStyles.Left) _
			Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.tabControlForReportParams.Controls.Add(Me.TabPage1)
		Me.tabControlForReportParams.Controls.Add(Me.TabPage2)
		Me.tabControlForReportParams.Location = New System.Drawing.Point(6, 30)
		Me.tabControlForReportParams.Name = "tabControlForReportParams"
		Me.tabControlForReportParams.SelectedIndex = 0
		Me.tabControlForReportParams.Size = New System.Drawing.Size(585, 483)
		Me.tabControlForReportParams.TabIndex = 10
		'
		'TabPage1
		'
		Me.TabPage1.Location = New System.Drawing.Point(4, 24)
		Me.TabPage1.Name = "TabPage1"
		Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
		Me.TabPage1.Size = New System.Drawing.Size(577, 455)
		Me.TabPage1.TabIndex = 0
		Me.TabPage1.Text = "TabPage1"
		Me.TabPage1.UseVisualStyleBackColor = True
		'
		'TabPage2
		'
		Me.TabPage2.Location = New System.Drawing.Point(4, 24)
		Me.TabPage2.Name = "TabPage2"
		Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
		Me.TabPage2.Size = New System.Drawing.Size(577, 455)
		Me.TabPage2.TabIndex = 1
		Me.TabPage2.Text = "TabPage2"
		Me.TabPage2.UseVisualStyleBackColor = True
		'
		'tabReportPropertiesView
		'
		Me.tabReportPropertiesView.Controls.Add(Me.grpReportPropertiesView)
		Me.tabReportPropertiesView.Location = New System.Drawing.Point(4, 24)
		Me.tabReportPropertiesView.Name = "tabReportPropertiesView"
		Me.tabReportPropertiesView.Padding = New System.Windows.Forms.Padding(3)
		Me.tabReportPropertiesView.Size = New System.Drawing.Size(716, 570)
		Me.tabReportPropertiesView.TabIndex = 0
		Me.tabReportPropertiesView.Text = "ReportPropertiesView"
		Me.tabReportPropertiesView.UseVisualStyleBackColor = True
		'
		'grpReportPropertiesView
		'
		Me.grpReportPropertiesView.Controls.Add(Me.dgvReportsView)
		Me.grpReportPropertiesView.Dock = System.Windows.Forms.DockStyle.Fill
		Me.grpReportPropertiesView.Location = New System.Drawing.Point(3, 3)
		Me.grpReportPropertiesView.Name = "grpReportPropertiesView"
		Me.grpReportPropertiesView.Size = New System.Drawing.Size(710, 566)
		Me.grpReportPropertiesView.TabIndex = 1
		Me.grpReportPropertiesView.TabStop = False
		Me.grpReportPropertiesView.Text = "Report Properties View"
		'
		'dgvReportsView
		'
		Me.dgvReportsView.AllowUserToAddRows = False
		Me.dgvReportsView.AllowUserToDeleteRows = False
		Me.dgvReportsView.AllowUserToResizeRows = False
		Me.dgvReportsView.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
			Or System.Windows.Forms.AnchorStyles.Left) _
			Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.dgvReportsView.BackgroundColor = System.Drawing.Color.White
		Me.dgvReportsView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
		Me.dgvReportsView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.PropertyName, Me.PropertyValue})
		DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
		DataGridViewCellStyle8.BackColor = System.Drawing.Color.Gainsboro
		DataGridViewCellStyle8.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText
		DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
		DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
		DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
		Me.dgvReportsView.DefaultCellStyle = DataGridViewCellStyle8
		Me.dgvReportsView.Location = New System.Drawing.Point(14, 27)
		Me.dgvReportsView.Name = "dgvReportsView"
		Me.dgvReportsView.ReadOnly = True
		Me.dgvReportsView.RowHeadersVisible = False
		Me.dgvReportsView.RowTemplate.Height = 18
		Me.dgvReportsView.Size = New System.Drawing.Size(674, 509)
		Me.dgvReportsView.TabIndex = 0
		'
		'PropertyName
		'
		Me.PropertyName.HeaderText = "PropertyName"
		Me.PropertyName.Name = "PropertyName"
		Me.PropertyName.ReadOnly = True
		Me.PropertyName.Width = 200
		'
		'PropertyValue
		'
		Me.PropertyValue.HeaderText = "PropertyValue"
		Me.PropertyValue.Name = "PropertyValue"
		Me.PropertyValue.ReadOnly = True
		Me.PropertyValue.Width = 300
		'
		'pnlGridLegend
		'
		Me.pnlGridLegend.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
		Me.pnlGridLegend.Controls.Add(Me.lblOptionalValue)
		Me.pnlGridLegend.Controls.Add(Me.lblRequiredValue)
		Me.pnlGridLegend.Controls.Add(Me.lblReadOnlyValue)
		Me.pnlGridLegend.Location = New System.Drawing.Point(541, 607)
		Me.pnlGridLegend.Name = "pnlGridLegend"
		Me.pnlGridLegend.Size = New System.Drawing.Size(427, 15)
		Me.pnlGridLegend.TabIndex = 20
		'
		'lblOptionalValue
		'
		Me.lblOptionalValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.lblOptionalValue.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblOptionalValue.ForeColor = System.Drawing.Color.Black
		Me.lblOptionalValue.Location = New System.Drawing.Point(184, 2)
		Me.lblOptionalValue.Name = "lblOptionalValue"
		Me.lblOptionalValue.Size = New System.Drawing.Size(77, 16)
		Me.lblOptionalValue.TabIndex = 2
		Me.lblOptionalValue.Text = "Optional value"
		Me.lblOptionalValue.Visible = False
		'
		'lblRequiredValue
		'
		Me.lblRequiredValue.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
		Me.lblRequiredValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.lblRequiredValue.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblRequiredValue.ForeColor = System.Drawing.Color.Black
		Me.lblRequiredValue.Location = New System.Drawing.Point(95, 2)
		Me.lblRequiredValue.Name = "lblRequiredValue"
		Me.lblRequiredValue.Size = New System.Drawing.Size(81, 16)
		Me.lblRequiredValue.TabIndex = 1
		Me.lblRequiredValue.Text = "Required value"
		Me.lblRequiredValue.Visible = False
		'
		'lblReadOnlyValue
		'
		Me.lblReadOnlyValue.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
		Me.lblReadOnlyValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.lblReadOnlyValue.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblReadOnlyValue.ForeColor = System.Drawing.Color.Black
		Me.lblReadOnlyValue.Location = New System.Drawing.Point(0, 2)
		Me.lblReadOnlyValue.Name = "lblReadOnlyValue"
		Me.lblReadOnlyValue.Size = New System.Drawing.Size(86, 16)
		Me.lblReadOnlyValue.TabIndex = 1
		Me.lblReadOnlyValue.Text = "Read only value"
		Me.lblReadOnlyValue.Visible = False
		'
		'pnlTreeLegend
		'
		Me.pnlTreeLegend.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
		Me.pnlTreeLegend.Controls.Add(Me.Label1)
		Me.pnlTreeLegend.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.pnlTreeLegend.Location = New System.Drawing.Point(4, 607)
		Me.pnlTreeLegend.Name = "pnlTreeLegend"
		Me.pnlTreeLegend.Size = New System.Drawing.Size(455, 19)
		Me.pnlTreeLegend.TabIndex = 0
		'
		'Label1
		'
		Me.Label1.AutoSize = True
		Me.Label1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label1.ForeColor = System.Drawing.Color.Red
		Me.Label1.Location = New System.Drawing.Point(5, 0)
		Me.Label1.Name = "Label1"
		Me.Label1.Size = New System.Drawing.Size(47, 13)
		Me.Label1.TabIndex = 0
		Me.Label1.Text = "Inactive"
		'
		'pnlButtons
		'
		Me.pnlButtons.BackColor = System.Drawing.SystemColors.Control
		Me.pnlButtons.Controls.Add(Me.pnlSeparatorLine)
		Me.pnlButtons.Controls.Add(Me.pnlButtonsRight)
		Me.pnlButtons.Controls.Add(Me.pnlButtonsCenter)
		Me.pnlButtons.Controls.Add(Me.pnlButtonsLeft)
		Me.pnlButtons.Dock = System.Windows.Forms.DockStyle.Bottom
		Me.pnlButtons.Location = New System.Drawing.Point(0, 626)
		Me.pnlButtons.Name = "pnlButtons"
		Me.pnlButtons.Size = New System.Drawing.Size(1154, 60)
		Me.pnlButtons.TabIndex = 18
		'
		'pnlSeparatorLine
		'
		Me.pnlSeparatorLine.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
			Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.pnlSeparatorLine.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.pnlSeparatorLine.Location = New System.Drawing.Point(0, 0)
		Me.pnlSeparatorLine.Name = "pnlSeparatorLine"
		Me.pnlSeparatorLine.Size = New System.Drawing.Size(1152, 1)
		Me.pnlSeparatorLine.TabIndex = 0
		'
		'pnlButtonsRight
		'
		Me.pnlButtonsRight.Controls.Add(Me.btnRefresh)
		Me.pnlButtonsRight.Controls.Add(Me.btnCopyToProduction)
		Me.pnlButtonsRight.Dock = System.Windows.Forms.DockStyle.Right
		Me.pnlButtonsRight.Location = New System.Drawing.Point(780, 0)
		Me.pnlButtonsRight.Name = "pnlButtonsRight"
		Me.pnlButtonsRight.Size = New System.Drawing.Size(374, 60)
		Me.pnlButtonsRight.TabIndex = 3
		'
		'btnRefresh
		'
		Me.btnRefresh.Enabled = False
		Me.btnRefresh.Location = New System.Drawing.Point(248, 32)
		Me.btnRefresh.Name = "btnRefresh"
		Me.btnRefresh.Size = New System.Drawing.Size(120, 24)
		Me.btnRefresh.TabIndex = 3
		Me.btnRefresh.Text = "Refresh"
		Me.btnRefresh.UseVisualStyleBackColor = True
		'
		'btnCopyToProduction
		'
		Me.btnCopyToProduction.Enabled = False
		Me.btnCopyToProduction.Location = New System.Drawing.Point(247, 4)
		Me.btnCopyToProduction.Name = "btnCopyToProduction"
		Me.btnCopyToProduction.Size = New System.Drawing.Size(120, 24)
		Me.btnCopyToProduction.TabIndex = 2
		Me.btnCopyToProduction.Text = "Copy to Production..."
		Me.btnCopyToProduction.UseVisualStyleBackColor = True
		'
		'pnlButtonsCenter
		'
		Me.pnlButtonsCenter.BackColor = System.Drawing.SystemColors.Control
		Me.pnlButtonsCenter.Controls.Add(Me.btnCopyItem)
		Me.pnlButtonsCenter.Controls.Add(Me.btnCancel)
		Me.pnlButtonsCenter.Controls.Add(Me.btnSave)
		Me.pnlButtonsCenter.Controls.Add(Me.btnEdit)
		Me.pnlButtonsCenter.Controls.Add(Me.btnDelete)
		Me.pnlButtonsCenter.Controls.Add(Me.btnInsert)
		Me.pnlButtonsCenter.Location = New System.Drawing.Point(191, 2)
		Me.pnlButtonsCenter.Name = "pnlButtonsCenter"
		Me.pnlButtonsCenter.Size = New System.Drawing.Size(278, 55)
		Me.pnlButtonsCenter.TabIndex = 2
		'
		'btnCopyItem
		'
		Me.btnCopyItem.Enabled = False
		Me.btnCopyItem.Location = New System.Drawing.Point(3, 1)
		Me.btnCopyItem.Name = "btnCopyItem"
		Me.btnCopyItem.Size = New System.Drawing.Size(78, 24)
		Me.btnCopyItem.TabIndex = 0
		Me.btnCopyItem.Text = "Copy item"
		Me.btnCopyItem.UseVisualStyleBackColor = True
		'
		'btnCancel
		'
		Me.btnCancel.Enabled = False
		Me.btnCancel.Location = New System.Drawing.Point(171, 31)
		Me.btnCancel.Name = "btnCancel"
		Me.btnCancel.Size = New System.Drawing.Size(78, 24)
		Me.btnCancel.TabIndex = 5
		Me.btnCancel.Text = "Cancel"
		Me.btnCancel.UseVisualStyleBackColor = True
		'
		'btnSave
		'
		Me.btnSave.Enabled = False
		Me.btnSave.Location = New System.Drawing.Point(87, 31)
		Me.btnSave.Name = "btnSave"
		Me.btnSave.Size = New System.Drawing.Size(78, 24)
		Me.btnSave.TabIndex = 4
		Me.btnSave.Text = "Save"
		Me.btnSave.UseVisualStyleBackColor = True
		'
		'btnEdit
		'
		Me.btnEdit.Enabled = False
		Me.btnEdit.Location = New System.Drawing.Point(3, 31)
		Me.btnEdit.Name = "btnEdit"
		Me.btnEdit.Size = New System.Drawing.Size(78, 24)
		Me.btnEdit.TabIndex = 3
		Me.btnEdit.Text = "Edit"
		Me.btnEdit.UseVisualStyleBackColor = True
		'
		'btnDelete
		'
		Me.btnDelete.Enabled = False
		Me.btnDelete.Location = New System.Drawing.Point(171, 1)
		Me.btnDelete.Name = "btnDelete"
		Me.btnDelete.Size = New System.Drawing.Size(78, 24)
		Me.btnDelete.TabIndex = 2
		Me.btnDelete.Text = "Delete"
		Me.btnDelete.UseVisualStyleBackColor = True
		'
		'btnInsert
		'
		Me.btnInsert.Enabled = False
		Me.btnInsert.Location = New System.Drawing.Point(87, 1)
		Me.btnInsert.Name = "btnInsert"
		Me.btnInsert.Size = New System.Drawing.Size(78, 24)
		Me.btnInsert.TabIndex = 1
		Me.btnInsert.Text = "Insert"
		Me.btnInsert.UseVisualStyleBackColor = True
		'
		'pnlButtonsLeft
		'
		Me.pnlButtonsLeft.Controls.Add(Me.btnOpenAllFolders)
		Me.pnlButtonsLeft.Controls.Add(Me.btnCloseAllFolders)
		Me.pnlButtonsLeft.Controls.Add(Me.btnMoveUp)
		Me.pnlButtonsLeft.Controls.Add(Me.btnMoveDown)
		Me.pnlButtonsLeft.Dock = System.Windows.Forms.DockStyle.Left
		Me.pnlButtonsLeft.Location = New System.Drawing.Point(0, 0)
		Me.pnlButtonsLeft.Name = "pnlButtonsLeft"
		Me.pnlButtonsLeft.Size = New System.Drawing.Size(185, 60)
		Me.pnlButtonsLeft.TabIndex = 1
		'
		'btnOpenAllFolders
		'
		Me.btnOpenAllFolders.Location = New System.Drawing.Point(12, 1)
		Me.btnOpenAllFolders.Name = "btnOpenAllFolders"
		Me.btnOpenAllFolders.Size = New System.Drawing.Size(78, 24)
		Me.btnOpenAllFolders.TabIndex = 0
		Me.btnOpenAllFolders.Text = "Open Folders"
		Me.btnOpenAllFolders.UseVisualStyleBackColor = True
		'
		'btnCloseAllFolders
		'
		Me.btnCloseAllFolders.Location = New System.Drawing.Point(12, 31)
		Me.btnCloseAllFolders.Name = "btnCloseAllFolders"
		Me.btnCloseAllFolders.Size = New System.Drawing.Size(78, 24)
		Me.btnCloseAllFolders.TabIndex = 3
		Me.btnCloseAllFolders.Text = "Close Folders"
		Me.btnCloseAllFolders.UseVisualStyleBackColor = True
		'
		'btnMoveUp
		'
		Me.btnMoveUp.Location = New System.Drawing.Point(96, 1)
		Me.btnMoveUp.Name = "btnMoveUp"
		Me.btnMoveUp.Size = New System.Drawing.Size(78, 24)
		Me.btnMoveUp.TabIndex = 1
		Me.btnMoveUp.Text = "Move Up"
		Me.btnMoveUp.UseVisualStyleBackColor = True
		'
		'btnMoveDown
		'
		Me.btnMoveDown.Location = New System.Drawing.Point(96, 31)
		Me.btnMoveDown.Name = "btnMoveDown"
		Me.btnMoveDown.Size = New System.Drawing.Size(78, 24)
		Me.btnMoveDown.TabIndex = 4
		Me.btnMoveDown.Text = "Move Down"
		Me.btnMoveDown.UseVisualStyleBackColor = True
		'
		'StatusStrip1
		'
		Me.StatusStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
		Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblEditingStatus, Me.lblCopyItemBuffer})
		Me.StatusStrip1.Location = New System.Drawing.Point(0, 686)
		Me.StatusStrip1.Name = "StatusStrip1"
		Me.StatusStrip1.Size = New System.Drawing.Size(1154, 24)
		Me.StatusStrip1.TabIndex = 13
		Me.StatusStrip1.Text = "StatusStrip1"
		'
		'lblEditingStatus
		'
		Me.lblEditingStatus.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
		Me.lblEditingStatus.BorderSides = CType((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right), System.Windows.Forms.ToolStripStatusLabelBorderSides)
		Me.lblEditingStatus.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
		Me.lblEditingStatus.Name = "lblEditingStatus"
		Me.lblEditingStatus.Size = New System.Drawing.Size(117, 19)
		Me.lblEditingStatus.Text = "Available for editing"
		'
		'lblCopyItemBuffer
		'
		Me.lblCopyItemBuffer.ForeColor = System.Drawing.Color.DimGray
		Me.lblCopyItemBuffer.Name = "lblCopyItemBuffer"
		Me.lblCopyItemBuffer.Size = New System.Drawing.Size(1022, 19)
		Me.lblCopyItemBuffer.Spring = True
		Me.lblCopyItemBuffer.Text = "CopyItem buffer is Empty"
		Me.lblCopyItemBuffer.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'tmrControlBlink
		'
		Me.tmrControlBlink.Interval = 200
		'
		'tmrBlinkEdit
		'
		Me.tmrBlinkEdit.Interval = 40000
		'
		'tvwDARTTng
		'
		Me.tvwDARTTng.AllowDrop = True
		Me.tvwDARTTng.ContextMenuStrip = Me.cmTreeNodeOperations
		Me.tvwDARTTng.Dock = System.Windows.Forms.DockStyle.Fill
		Me.tvwDARTTng.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.tvwDARTTng.FullRowSelect = True
		Me.tvwDARTTng.HideSelection = False
		Me.tvwDARTTng.Location = New System.Drawing.Point(0, 0)
		Me.tvwDARTTng.Name = "tvwDARTTng"
		Me.tvwDARTTng.PathSeparator = "_"
		Me.tvwDARTTng.Size = New System.Drawing.Size(363, 600)
		Me.tvwDARTTng.TabIndex = 22
		'
		'btnControlEdit
		'
		Me.btnControlEdit.Location = New System.Drawing.Point(166, 16)
		Me.btnControlEdit.MouseOverBackColor = System.Drawing.Color.Empty
		Me.btnControlEdit.MouseOverCursor = Nothing
		Me.btnControlEdit.MouseOverFont = Nothing
		Me.btnControlEdit.MouseOverForeColor = System.Drawing.Color.Empty
		Me.btnControlEdit.MouseOverImage = Nothing
		Me.btnControlEdit.MouseOverText = Nothing
		Me.btnControlEdit.Name = "btnControlEdit"
		Me.btnControlEdit.Size = New System.Drawing.Size(75, 23)
		Me.btnControlEdit.TabIndex = 15
		Me.btnControlEdit.Text = "Edit"
		Me.btnControlEdit.UseVisualStyleBackColor = True
		'
		'cboColor_AlignControls
		'
		Me.cboColor_AlignControls.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.cboColor_AlignControls.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
		Me.cboColor_AlignControls.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cboColor_AlignControls.FormattingEnabled = True
		Me.cboColor_AlignControls.Location = New System.Drawing.Point(162, 4)
		Me.cboColor_AlignControls.Name = "cboColor_AlignControls"
		Me.cboColor_AlignControls.Size = New System.Drawing.Size(121, 24)
		Me.cboColor_AlignControls.TabIndex = 23
		Me.cboColor_AlignControls.Visible = False
		'
		'btnShowControls
		'
		Me.btnShowControls.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.btnShowControls.Location = New System.Drawing.Point(498, 3)
		Me.btnShowControls.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
		Me.btnShowControls.MouseOverCursor = Nothing
		Me.btnShowControls.MouseOverFont = Nothing
		Me.btnShowControls.MouseOverForeColor = System.Drawing.Color.Empty
		Me.btnShowControls.MouseOverImage = Nothing
		Me.btnShowControls.MouseOverText = Nothing
		Me.btnShowControls.Name = "btnShowControls"
		Me.btnShowControls.Size = New System.Drawing.Size(85, 23)
		Me.btnShowControls.TabIndex = 17
		Me.btnShowControls.Text = "Show Controls"
		Me.btnShowControls.UseVisualStyleBackColor = True
		'
		'frmDARTTngTree
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
		Me.ClientSize = New System.Drawing.Size(1156, 737)
		Me.Controls.Add(Me.pnlPrimaryContent)
		Me.Controls.Add(Me.ToolStrip1)
		Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
		Me.MinimumSize = New System.Drawing.Size(990, 400)
		Me.Name = "frmDARTTngTree"
		Me.Text = "DART Pro Report Tree"
		Me.ToolStrip1.ResumeLayout(False)
		Me.ToolStrip1.PerformLayout()
		Me.pnlPrimaryContent.ResumeLayout(False)
		Me.pnlPrimaryContent.PerformLayout()
		Me.splTreeProps.Panel1.ResumeLayout(False)
		Me.splTreeProps.Panel2.ResumeLayout(False)
		CType(Me.splTreeProps, System.ComponentModel.ISupportInitialize).EndInit()
		Me.splTreeProps.ResumeLayout(False)
		Me.pnlCommittingChanges.ResumeLayout(False)
		Me.cmTreeNodeOperations.ResumeLayout(False)
		Me.pnlUsedReportNumbers.ResumeLayout(False)
		CType(Me.dgvUsedReportNumbers, System.ComponentModel.ISupportInitialize).EndInit()
		Me.tcReportProperties.ResumeLayout(False)
		Me.tabTreeNodeProperties.ResumeLayout(False)
		CType(Me.dgvImages, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.dgvImagesFolderClosed, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.dgvTreeProperties, System.ComponentModel.ISupportInitialize).EndInit()
		Me.pnlItemControls.ResumeLayout(False)
		Me.pnlItemControls.PerformLayout()
		Me.tabReportControls.ResumeLayout(False)
		Me.grpRepControlsEdit.ResumeLayout(False)
		Me.tcReportControls.ResumeLayout(False)
		Me.Grid.ResumeLayout(False)
		CType(Me.dgvReportControls, System.ComponentModel.ISupportInitialize).EndInit()
		Me.cmReportControls.ResumeLayout(False)
		Me.Graphical.ResumeLayout(False)
		Me.Graphical.PerformLayout()
		Me.tabControlForReportParams.ResumeLayout(False)
		Me.tabReportPropertiesView.ResumeLayout(False)
		Me.grpReportPropertiesView.ResumeLayout(False)
		CType(Me.dgvReportsView, System.ComponentModel.ISupportInitialize).EndInit()
		Me.pnlGridLegend.ResumeLayout(False)
		Me.pnlTreeLegend.ResumeLayout(False)
		Me.pnlTreeLegend.PerformLayout()
		Me.pnlButtons.ResumeLayout(False)
		Me.pnlButtonsRight.ResumeLayout(False)
		Me.pnlButtonsCenter.ResumeLayout(False)
		Me.pnlButtonsLeft.ResumeLayout(False)
		Me.StatusStrip1.ResumeLayout(False)
		Me.StatusStrip1.PerformLayout()
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub
    Public WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents pnlPrimaryContent As System.Windows.Forms.Panel
    Friend WithEvents splTreeProps As System.Windows.Forms.SplitContainer
    Friend WithEvents pnlCommittingChanges As System.Windows.Forms.Panel
    Friend WithEvents pbCommittingChanges As System.Windows.Forms.ProgressBar
    Friend WithEvents lblCommittingChanges As System.Windows.Forms.Label
    Friend WithEvents tvwDARTTng As DDTToolbox.ExtTreeView
    Friend WithEvents pnlGridLegend As System.Windows.Forms.Panel
    Friend WithEvents pnlTreeLegend As System.Windows.Forms.Panel
    Friend WithEvents pnlButtons As System.Windows.Forms.Panel
    Friend WithEvents pnlSeparatorLine As System.Windows.Forms.Panel
    Friend WithEvents pnlButtonsRight As System.Windows.Forms.Panel
    Friend WithEvents btnRefresh As System.Windows.Forms.Button
    Friend WithEvents btnCopyToProduction As System.Windows.Forms.Button
    Friend WithEvents pnlButtonsCenter As System.Windows.Forms.Panel
    Friend WithEvents btnCopyItem As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnEdit As System.Windows.Forms.Button
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents btnInsert As System.Windows.Forms.Button
    Friend WithEvents pnlButtonsLeft As System.Windows.Forms.Panel
    Friend WithEvents btnOpenAllFolders As System.Windows.Forms.Button
    Friend WithEvents btnCloseAllFolders As System.Windows.Forms.Button
    Friend WithEvents btnMoveUp As System.Windows.Forms.Button
    Friend WithEvents btnMoveDown As System.Windows.Forms.Button
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents lblEditingStatus As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents TreeImageList As DDT_ImageList
    Friend WithEvents tcReportProperties As System.Windows.Forms.TabControl
    Friend WithEvents tabReportPropertiesView As System.Windows.Forms.TabPage
    Friend WithEvents tabReportControls As System.Windows.Forms.TabPage
    Friend WithEvents tabTreeNodeProperties As System.Windows.Forms.TabPage
    Friend WithEvents pnlItemControls As System.Windows.Forms.Panel
    Friend WithEvents chkSchedulingEnabled As System.Windows.Forms.CheckBox
    Friend WithEvents lblChangeItemTypeNotAllowed As System.Windows.Forms.Label
    Friend WithEvents chkHelpButton As System.Windows.Forms.CheckBox
    'Friend WithEvents chkHidden As System.Windows.Forms.CheckBox
    Friend WithEvents chkActive As System.Windows.Forms.CheckBox
    Friend WithEvents pnlUsedReportNumbers As System.Windows.Forms.Panel
    Friend WithEvents lblUsedReportNumbers As System.Windows.Forms.Label
    Friend WithEvents dgvUsedReportNumbers As System.Windows.Forms.DataGridView
    Friend WithEvents UsedRptNums As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ReportID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lstUsedReportNumbers As System.Windows.Forms.ListBox
    Friend WithEvents dgvImages As System.Windows.Forms.DataGridView
    Friend WithEvents dgvReportControls As System.Windows.Forms.DataGridView
    Friend WithEvents dgvReportsView As System.Windows.Forms.DataGridView
    Friend WithEvents dgvTreeProperties As System.Windows.Forms.DataGridView
    Friend WithEvents ReportProperty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ReportValue As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FolderEditType As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PrefEditType As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ReportEditType As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btnControlDelete As System.Windows.Forms.Button
    Friend WithEvents btnControlADD As System.Windows.Forms.Button
    Friend WithEvents tcReportControls As System.Windows.Forms.TabControl
    Friend WithEvents Graphical As System.Windows.Forms.TabPage
    Friend WithEvents Grid As System.Windows.Forms.TabPage
    Friend WithEvents rbReport As System.Windows.Forms.RadioButton
    Friend WithEvents rbFolder As System.Windows.Forms.RadioButton
    Friend WithEvents dgvImagesFolderClosed As System.Windows.Forms.DataGridView
    Friend WithEvents ImgClosed As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents ImageTypeClosed As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ImageIDClosed As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ImageListIndexClosed As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IsFolderClosed As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents grpRepControlsEdit As System.Windows.Forms.GroupBox
    Friend WithEvents btnControlEdit As DDTToolbox.ExtButton
    'Friend WithEvents chkIsSecure As System.Windows.Forms.CheckBox
    Friend WithEvents cboItemTypeSelect As System.Windows.Forms.ComboBox
    Friend WithEvents PropertyName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PropertyValue As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents grpReportPropertiesView As System.Windows.Forms.GroupBox
    Friend WithEvents cmReportControls As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents lblReportControlMessage As System.Windows.Forms.Label
    Friend WithEvents tmrControlBlink As System.Windows.Forms.Timer
    Friend WithEvents Img As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents ImageType As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ImageID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ImageListIndex As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IsFolder As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents cmTreeNodeOperations As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents MoveUpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MoveDownToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CopyToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeleteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents InsertToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmsiAddNewToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmsiEditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmsiDeleteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lblCopyItemBuffer As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents cboGridLines As System.Windows.Forms.ComboBox
    Friend WithEvents lblUnits_AlignControls As System.Windows.Forms.Label
    Friend WithEvents chkDisplayGridLines As System.Windows.Forms.CheckBox
    Friend WithEvents tabControlForReportParams As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents cboColor_AlignControls As DDTToolbox.clsColorComboBox
    Friend WithEvents btnShowControls As DDTToolbox.ExtButton
    Friend WithEvents tmrBlinkEdit As System.Windows.Forms.Timer
    Friend WithEvents lblOptionalValue As System.Windows.Forms.Label
    Friend WithEvents lblRequiredValue As System.Windows.Forms.Label
    Friend WithEvents lblReadOnlyValue As System.Windows.Forms.Label
    Friend WithEvents ToolStripLblEditing As System.Windows.Forms.ToolStripLabel
    Friend WithEvents lblDragNode As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
