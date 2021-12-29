Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports System.Reflection
Imports System.Data.SqlClient
Imports DDTToolbox.CodeUtilities

Public Class frmDARTTngTree

#Region "Public Variables & constants"
    Public Shared CopyNode As DARTTreeNode
    Public Shared InsertType As String
    Public Shared connStr As String
    Public Shared dsroot As New DataSet
#End Region

#Region "Private Variables & Constants"
    Private server As String
    Private sqlConnection As System.Data.SqlClient.SqlConnection
    Private sqlCmd As System.Data.SqlClient.SqlCommand
    Private InitialBuild As Boolean = True
    Private DARTTreeViewBuilt As Boolean
    Private CurrDPVersion As Decimal
    Private DraggedNode As New DARTTreeNode
    Private SaveNode As New DARTTreeNode
    Private lastInsertRect As Rectangle
    Private lastDragOverPt As Point
    Private editmode As Integer
    Private NewReportsFolderNodeIndexToStr As String
    Private DroppingInNewReports As Boolean
    Private InsertingNewNode As Boolean
    Private TreeDirty As Boolean = False
    Private LockedForEditingBy As String
    Private LockedForEditingTime As String
    Private EditingAllowed As Boolean
    Private PreEditNodeID As String
    Private NewNode As DARTTreeNode

    Private Const isClosed = 0
    Private Const isOpened = 1

    Private Const notEditing = 0
    Private Const adding = 1
    Private Const editing = 2

    Private dgvImagesClicked As Boolean
    Private dgvImages1Clicked As Boolean

    Private EmpNumber As String

    Private UserEdits_TREE As Boolean
    Private UserEdits_CONTROL As Boolean
    Private UserEdits_NodesMoved As Boolean

    Private ControlBlinkCounter As Integer = 0
    Private ControlBlinkMax As Integer = 0
    Private ControlBlinkObj As Object
    Private ControlBlinkState As Boolean
    Private ControlBlinkOrigBackColor As Color
    Private ControlBlinkTempBackColor As Color = Color.Yellow

    Private paramContainer As Control
    Private TabName As String
    Private lblReportPanel As Label

    Private ChildIDsMap() As Integer
    Private ContainerIDsMap() As Integer
    Private CopyNode_ControlsContainChildIDs As Boolean = False
    Private CopyNode_NewInsert As Boolean
    Public CopyNodeNewReportNum As Integer
#End Region

    Private Sub frmDARTTngTreeTabs_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If TreeDirty Then
            If e.CloseReason = CloseReason.UserClosing Then
                Dim aResponse As DialogResult = RichMessageBoxShow("Are you sure you want to close the DART Tng Tree toolbox window without saving changes?", _
                                "CHANGES NOT SAVED", Color.Azure, Color.Azure, Color.Black, _
                                New Size(400, 100), 12, BorderStyle.None, _
                                RichMessageBoxIcon.Question, RichMessageBoxButtons.YesNo, _
                                RichMessageboxDefaultButton.Button2, ScrollBars.Vertical, _
                                RichMessageboxFadeStyle.FadeOutOnly)
                If aResponse = System.Windows.Forms.DialogResult.No Then
                    e.Cancel = True
                Else
                    btnCancel_Click(Nothing, Nothing)
                End If
            Else
                CheckEditingStatus()
                If EditingAllowed Then
                    Dim aResponse As DialogResult = RichMessageBoxShow("Do you want to save the pending changes to the DART Tng Tree?", _
                                "Pending changes", Color.Azure, Color.Azure, Color.Black, New Size(400, 100), 12, _
                                BorderStyle.None, RichMessageBoxIcon.Question, RichMessageBoxButtons.YesNoCancel, _
                                RichMessageboxDefaultButton.Button3, ScrollBars.Vertical, _
                                RichMessageboxFadeStyle.FadeOutOnly)
                    If aResponse = System.Windows.Forms.DialogResult.Yes Then
                        SaveCurrentTreeNode(DirectCast(tvwDARTTng.SelectedNode, DARTTreeNode))
                    ElseIf aResponse = System.Windows.Forms.DialogResult.No Then
                        btnCancel_Click(Nothing, Nothing)
                    Else
                        e.Cancel = True
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub BuildReportsTable()
        BuildDataSet(sqlConnection, "exec dbo.sToolbox_GetReportsInfo 0, 1", "Reports", dsroot)
        BuildDataSet(sqlConnection, "exec dbo.sToolbox_GetReportsInfo 1, 1", "ReportsComBoBox", dsroot)
        dsroot.Tables("Reports").Columns.Add("IdName")
        SetTablePrimaryKey(dsroot.Tables("Reports"), dsroot.Tables("Reports").Columns("ReportID"))
    End Sub

	Private Sub frmDartTngTree_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

		Me.Icon = frmMain.Icon
		Me.WindowState = FormWindowState.Maximized
		server = gServer
		connStr = "Data Source=" + server + ";Initial Catalog=DDT_Common;Integrated Security=True"
		sqlConnection = New System.Data.SqlClient.SqlConnection(connStr)
		Me.Tag = Me.Text
		Me.Text = Me.Tag + " [" + server + "]"
		Me.Height = frmMain.Height - 100 - IIf(frmMain.tsMyButtons.Visible = True, frmMain.tsMyButtons.Height, 0)
		Me.Width = frmMain.Width - 50
		Me.Top = 10
		Me.Left = 10

		dsroot.Clear()
		dsroot.Tables.Clear()

		dsroot.Tables.Add("CopyNode_ReportControls")

		BuildDataSet(sqlConnection, "exec dbo.sToolbox_BuildImageData F", "ImageDataFolders", dsroot)
		BuildDataSet(sqlConnection, "exec dbo.sToolbox_BuildImageData R", "ImageDataReports", dsroot)
		BuildDataSet(sqlConnection, "SELECT * FROM DDT_Common.dbo.tToolbox_DARTTngReportProperties ORDER BY Sort", "PropList", dsroot)

		'--- Build the table of Reports ---
		BuildReportsTable()

		Dim i As Integer = 1
		For Each dr As DataRow In dsroot.Tables("Reports").Rows
			dr.Item("IdName") = dr.Item("ReportNumber").ToString + " -- " + dr.Item("ReportName").ToString + "  <ReportID=" + dr.Item("ReportID").ToString + ">"
			i += 1
		Next
		BuildDataSet(sqlConnection, "exec dbo.sToolbox_GetFoldersInfo 1", "Folders", dsroot)
		dsroot.Tables("Folders").Columns.Add("IdName")
		SetTablePrimaryKey(dsroot.Tables("Folders"), dsroot.Tables("Folders").Columns("FolderID"))
		For Each dr As DataRow In dsroot.Tables("Folders").Rows
			dr.Item("IdName") = "<" + dr.Item("FolderID").ToString + ">   " + dr.Item("FolderName").ToString
			i += 1
		Next

		BuildDataSet(sqlConnection, "exec dbo.sBuildTree 1", "sBuildTree", dsroot)
		SetTablePrimaryKey(dsroot.Tables("sBuildTree"), dsroot.Tables("sBuildTree").Columns("TreeLevelID"))

		Dim SqlStr As String
		SqlStr = "select EmployeeNumber from dbo.tEmployees_generalInfo where LAN_User_ID = '" + Mid(My.User.Name.ToString, 6) + "'"
		EmpNumber = ExecSqlScalar(SqlStr, connStr)
		lblEditingStatus.Text = "Available for editing"

		pnlPrimaryContent.Visible = True

		BuildReportPropertyColumns()
		CheckEditingStatus()
		Call BuildTreeView()
		RefreshUsedReportNumList()
		editmode = notEditing

		HandleControls()
		BuildControlsTab(DirectCast(tvwDARTTng.TopNode, DARTTreeNode).TreeLevelID)

		Me.CancelButton = btnCancel
		dgvImagesClicked = False
		UserEdits_TREE = False
		UserEdits_CONTROL = False
		UserEdits_NodesMoved = False
		ResizeControls()

		tvwDARTTng.AllowDrop = True

		'--- Some default settings ---
		cboColor_AlignControls.SelectedIndex = 80
		cboGridLines.SelectedIndex = 2
		ControlBlinkOrigBackColor = Color.White
	End Sub

    Private Sub BuildControlsTab(ByVal TreeLevelID As Integer, Optional ByVal FromCopy As Boolean = False)
        Dim ReportControlsTableName As String = "ReportControls"
        Try
            BuildDataSet(sqlConnection, "exec dbo.sToolbox_GetReportControls " + TreeLevelID.ToString, ReportControlsTableName, dsroot)
            If dsroot.Tables(ReportControlsTableName).Columns.Count <= 0 Then
                MessageBox.Show("Could not populate dgvReportControls grid.  Exiting sub...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try

        '--- Add a column used to determine if row has been edited. ---
        dsroot.Tables(ReportControlsTableName).Columns.Add("Edited")
        dgvReportControls.DataSource = dsroot.Tables(ReportControlsTableName)
        dgvReportControls.Columns("UseDefaultProperties").HeaderText = "Use Default Properties"
        dgvReportControls.Columns("UseForMultipleWorkbooks").HeaderText = "Use For Multiple Wrkbooks"
        dgvReportControls.Columns("ChildControlID").HeaderText = "Child Control ID"
        dgvReportControls.Columns("ControlTitle").HeaderText = "Control Title"
        dgvReportControls.Columns("ControlName").HeaderText = "Control Name"
        dgvReportControls.Columns("Report_ControlID").HeaderText = "Report Control ID"
        dgvReportControls.Columns("ReportID").HeaderText = "Report ID"
        dgvReportControls.Columns("TreeLevelID").HeaderText = "Tree Level ID"
        dgvReportControls.Columns("ApplicationID").HeaderText = "App ID"
        dgvReportControls.Columns("IndexOrder").HeaderText = "Index Order"
        dgvReportControls.Columns("ControlsID").HeaderText = "Controls ID"
        dgvReportControls.Columns("TabIndex").HeaderText = "Tab Index"
        dgvReportControls.Columns("LocationX").HeaderText = "Location X"
        dgvReportControls.Columns("LocationY").HeaderText = "Location Y"
        dgvReportControls.Columns("ContainerID").HeaderText = "Container ID"
        dgvReportControls.Columns("TextboxLocationX").HeaderText = "Textbox Location X"
        dgvReportControls.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.True
        dgvReportControls.AutoResizeColumns()
        dgvReportControls.Columns("Report_ControlID").Width = 50
        dgvReportControls.Columns("Report_ControlID").Frozen = True
        dgvReportControls.Columns("ApplicationID").Width = 35
        dgvReportControls.Columns("ReportID").Width = 50
        dgvReportControls.Columns("TreeLevelID").Width = 50
        dgvReportControls.Columns("ControlsID").Width = 50
        dgvReportControls.Columns("TabIndex").Width = 40
        dgvReportControls.Columns("IndexOrder").Width = 40
        dgvReportControls.Columns("Width").Width = 45
        dgvReportControls.Columns("Height").Width = 45
        dgvReportControls.Columns("LocationX").Width = 55
        dgvReportControls.Columns("LocationY").Width = 55
        dgvReportControls.Columns("ChildControlID").Width = 45
        dgvReportControls.Columns("Edited").Width = 20
        dgvReportControls.Columns("Edited").Visible = False
        dgvReportControls.Columns("UseDefaultProperties").Width = 60
        dgvReportControls.Columns("UseForMultipleWorkbooks").Width = 60
        dgvReportControls.Columns("ContainerID").Width = 55
        dgvReportControls.Columns("TextboxLocationX").Width = 55

        '--- Make these 2 a bit bigger than what AutoResize sets them ---
        dgvReportControls.Columns("ControlName").Width = dgvReportControls.Columns("ControlName").Width + 10
        dgvReportControls.Columns("ControlTitle").Width = dgvReportControls.Columns("ControlTitle").Width + 10

        '--- Set max col size ---
        For Each col As DataGridViewColumn In dgvReportControls.Columns
            If col.Width > 400 Then col.Width = 400
        Next

        DisplayControls()
    End Sub

    Private Sub BuildReportsViewTab(ByVal ReportID As Integer)
        grpReportPropertiesView.Text = "Report Properties View"
        dgvReportsView.Rows.Clear()
        Try
            If ReportID <> 0 Then
                Dim dRow As DataRow = dsroot.Tables("Reports").Rows.Find(ReportID)

                If dRow.Table.Rows.Count > 0 Then
                    grpReportPropertiesView.Text += "    ( ReportID = " + dRow.Item("ReportID").ToString + " )"
                    For i As Integer = 0 To dsroot.Tables("Reports").Columns.Count - 1
                        If dsroot.Tables("Reports").Columns(i).ColumnName = "ImageID" Then Exit For
                        dgvReportsView.Rows.Add()
                        dgvReportsView.Item("PropertyName", i).Value = dsroot.Tables("Reports").Columns(i).ColumnName
                        dgvReportsView.Item("PropertyValue", i).Value = dRow(i).ToString
                    Next
                Else
                    grpReportPropertiesView.Text += "     < folder >"
                    dgvReportsView.Rows.Clear()
                End If
            End If

        Catch ex As Exception
        End Try
    End Sub

    Private Sub ResizeControls()
        dgvTreeProperties.Columns("ReportValue").Width = dgvTreeProperties.Width - dgvTreeProperties.Columns("ReportProperty").Width - 20
        pnlGridLegend.Left = IIf(splTreeProps.SplitterDistance + pnlUsedReportNumbers.Width + 100 < pnlTreeLegend.Left + pnlTreeLegend.Width, pnlTreeLegend.Left + pnlTreeLegend.Width, splTreeProps.SplitterDistance + pnlUsedReportNumbers.Width + 100)
    End Sub

    '--- Scan tree to determine if ReportID is currently used in the Tree. ---
    Private Function ReportIdInTree(ByVal ReportID As Integer, ByVal aTreeView As TreeView, Optional ByRef theNodes As TreeNodeCollection = Nothing) As Boolean
        Dim Result As Boolean = False
        If theNodes Is Nothing Then
            theNodes = aTreeView.Nodes
        End If

        For Each aNode As DARTTreeNode In theNodes
            If aNode.ReportID = ReportID Then Return True

            If aNode.ItemType = "F" And aNode.Nodes.Count > 0 Then
                Result = ReportIdInTree(ReportID, aTreeView, aNode.Nodes)
                If Result = True Then Exit For
            End If
        Next

        Return Result
    End Function

    Private Sub RefreshUsedReportNumList()
        If dsroot.Tables("UsedReportNumbers") IsNot Nothing Then
            dsroot.Tables("UsedReportNumbers").Clear()
        End If
        'LAshby (4/20/18) Added application ID to the next line of code to eliminate WFM reports showing in this datagrid
        BuildDataSet(sqlConnection, "SELECT ReportNumber, ReportID FROM dbo.trReports WHERE ApplicationID = 1 ORDER BY ReportNumber", "UsedReportNumbers", dsroot)
        Dim usedReportsDR As DataRow() = dsroot.Tables("UsedReportNumbers").Select
        Dim urR As DataRow
        Dim aRow As Integer

        dgvUsedReportNumbers.Rows.Clear()
        Dim RepID As Integer = 0
        For Each urR In usedReportsDR
            aRow = dgvUsedReportNumbers.Rows.Add(urR.Item("ReportNumber").ToString)
            RepID = urR.Item("ReportID").ToString
            dgvUsedReportNumbers.Item("ReportID", aRow).Value = RepID
            If ReportIdInTree(RepID, tvwDARTTng) = False Then
                '--- Change back color to indicate ReportID not yet used in Tree ---
                dgvUsedReportNumbers.Rows(aRow).DefaultCellStyle.BackColor = Color.Pink
            End If
        Next
        dgvUsedReportNumbers.ClearSelection()
    End Sub

    Private Sub BuildTreeView()
        BuildTree_ToolBox(tvwDARTTng, TreeImageList, 1)
        InitialBuild = False
        TreeDirty = False
        '--- Needed to select 1st node in tree ---
        tvwDARTTng.SelectedNode = tvwDARTTng.TopNode
    End Sub
    Private Sub BuildTree_ToolBox(ByVal tvw As TreeView, ByVal img As DDT_ImageList, Optional ByVal ApplicationID As Integer = 1)
        BuildDataSet(sqlConnection, "dbo.sBuildTree " & ApplicationID, "DARTTree", dsroot)
        Dim drdata As DataRow() = dsroot.Tables("DARTTree").Select("TreeLevelID_Parent=-1")
        Dim r As DataRow
        CallFromType = "Sub"
        CallFrom = "BuildTree"

        Try
            With tvw
                .BeginUpdate()
                .Nodes.Clear()
                .ImageList = img.ImageList
                If Not drdata.Length <= 0 Then
                    For Each r In drdata
                        Dim iFolderID As Integer = r("TreeLevelID")
                        Dim myNode As DARTTreeNode = GetTreeNodeDetails_ToolBox(r)
                        With myNode
                            .ImageIndex = r("ImageID") - 1
                            .Text = r("NodeName")
                            .Name = r("NodeID")
                            .SelectedImageIndex = r("ImageIDExpanded") - 1
                            .ForeColor = ReturnForeColor(.ReportStatus, True)
                        End With
                        .Nodes.Add(myNode)
                        AddNodes_ToolBox(myNode, iFolderID)
                    Next
                End If
                .CollapseAll()
                .EndUpdate()
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            drdata = Nothing
        End Try
    End Sub
    Public Function GetTreeNodeDetails_ToolBox(ByVal rowItem As DataRow) As DARTTreeNode
        CallFromType = "Function"
        CallFrom = "GetTreeNodeDetails"

        Try
            Dim myNode As New DARTTreeNode
            With myNode
                .CommandString = IIf(IsDBNull(rowItem.Item("CommandString")), "", rowItem.Item("CommandString"))
                .NodeType = IIf(rowItem.Item("ItemType") = "R", DDT_NodeType.Report, DDT_NodeType.Folder)
                .ItemType = rowItem.Item("ItemType")
                .NodeName = rowItem.Item("NodeName")
                .NodeID = rowItem.Item("NodeID")
                .NodeType = IIf(LSet(.NodeID, 18) = "Scheduled Reports_", DDT_NodeType.Schedule, .NodeType)
                .TreeLevelID = rowItem.Item("TreeLevelID")
                .TreeLevelID_Parent = rowItem.Item("TreeLevelID_Parent")
                .ReportID = rowItem.Item("ReportID")
                .Text = rowItem.Item("ReportName")
                .ReportName = rowItem.Item("ReportName")
                .ReportFullName = .ReportName
                .ReportTitle = rowItem.Item("ReportTitle")
                .ReportFormatID = rowItem.Item("ReportFormatID")
                .HelpFile = IIf(IsDBNull(rowItem.Item("HelpFile")), "", rowItem.Item("HelpFile"))
                .IsStatic = rowItem.Item("IsStatic")
                .UseTabs = rowItem.Item("UseTabs")
                .ImageIndex = rowItem.Item("ImageID") - 1
                .SelectedImageIndex = rowItem.Item("ImageIDExpanded") - 1
                .ImageID = .ImageIndex
                .ImageIDExpanded = .SelectedImageIndex
                .ReportFormat = rowItem.Item("ReportFormat")
                .ReportFileName = rowItem.Item("ReportFileName")
                .ReportNumber = IIf(IsDBNull(rowItem("ReportNumber")), "", rowItem("ReportNumber"))
                .ReportDescription = IIf(IsDBNull(rowItem("ReportDescription")), "", rowItem("ReportDescription"))
                .PrimaryLocation = IIf(IsDBNull(rowItem("DirectoryPrimary")), "", rowItem("DirectoryPrimary"))
                .SpecialID = rowItem("SpecialID")
                .TabIndex = rowItem("TabIndex")
                HelpFile = .HelpFile
                If rowItem("IsActive") = True Then
                    .ReportStatus = DDT_ReportStatus.Active
                Else
                    .ReportStatus = DDT_ReportStatus.Inactive
                End If

                'Extended for Tree Editing
                .HelpEnabled = IIf(IsDBNull(rowItem.Item("HelpEnabled")), False, rowItem.Item("HelpEnabled"))
                .ScheduleEnabled = IIf(IsDBNull(rowItem.Item("ScheduleEnabled")), False, rowItem.Item("ScheduleEnabled"))
                .ItemTypeID = IIf(IsDBNull(rowItem.Item("ItemTypeID")), 0, rowItem.Item("ItemTypeID"))
                .CreationDate = IIf(IsDBNull(rowItem.Item("CreationDate")), Nothing, rowItem.Item("CreationDate"))
                .ModifiedDate = IIf(IsDBNull(rowItem.Item("ModifiedDate")), Nothing, rowItem.Item("ModifiedDate"))
                .ModifiedBy_EmpNum = IIf(IsDBNull(rowItem.Item("ModifiedBy_EmpNum")), "", rowItem.Item("ModifiedBy_EmpNum"))
                .ImageType = IIf(IsDBNull(rowItem.Item("ImageType")), "", rowItem.Item("ImageType"))
                .SortOrder = IIf(IsDBNull(rowItem.Item("SortOrder")), 0, rowItem.Item("SortOrder"))
            End With
            Return myNode
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function
    Public Sub AddNodes_ToolBox(ByVal ParentNode As TreeNode, ByVal iParentID As Integer)
        Dim drdata As DataRow() = dsroot.Tables("DARTTree").Select("TreeLevelID_Parent=" & iParentID)
        Dim r As DataRow

        Try
            If Not drdata.Length <= 0 Then

                For Each r In drdata
                    Dim iNodeID As Integer = r("TreeLevelID")
                    Dim myNode As DARTTreeNode = GetTreeNodeDetails_ToolBox(r)

                    With myNode
                        .ImageIndex = r("ImageID") - 1
                        .Text = r("NodeName")
                        .Name = r("NodeID")
                        .SelectedImageIndex = r("ImageIDExpanded") - 1
                        .ForeColor = ReturnForeColor(.ReportStatus, True)
                    End With
                    ParentNode.Nodes.Add(myNode)
                    AddNodes_ToolBox(myNode, iNodeID)
                Next
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        drdata = Nothing
    End Sub
    Public Sub AddNodes_ToolBox(ByVal ParentNode As TreeNode, ByVal iParentFolderID As Integer, ByVal stype As String)
        'This procedure adds the nodes to the treeview passed by reference
        Dim drData As DataRow() = dsroot.Tables("Favorites").Select("TreeLevelID_Parent=" & iParentFolderID)
        Dim r As DataRow
        Dim saveParentID As Integer = 0
        CallFromType = "Sub"
        CallFrom = "AddNodes"

        Try
            If Not drData.Length <= 0 Then
                For Each r In drData
                    Dim iNodeID As Integer = r("TreeLevelID")
                    Dim myNode As DARTTreeNode = GetTreeNodeDetails(r)
                    With myNode
                        .ImageIndex = r("ImageID") - 1
                        .Text = r("NodeName")
                        .Name = r("NodeID")
                        .SelectedImageIndex = r("ImageIDExpanded") - 1
                        .Tag = r("ReportID")
                    End With
                    If stype = "F" Then
                        If r("ItemType") = "F" Then ParentNode.Nodes.Add(myNode) 'LAshby - new code to replace line above
                    Else
                        ParentNode.Nodes.Add(myNode) 'LAshby - new code to replace line above
                    End If
                    If myNode.SpecialID = SpecialID Then thisNode = myNode
                    AddNodes(myNode, iNodeID, stype)
                Next
            End If
        Catch ex As Exception
            EmailErrorAlert(gDatabaseConnection, ex.Message, gUserID, gApplicationName, gApplicationVersion, gUserID, CallFromType, CallFrom, gWorkstationID, gOsName)
        Finally
            drData = Nothing
        End Try
    End Sub

    Private Sub HandleControls()
        Try
            If tvwDARTTng.Nodes.Count > 0 Then

                Dim thisNode As DARTTreeNode = tvwDARTTng.SelectedNode
                Dim nodeLvlCount As Integer = 0
                If tvwDARTTng.SelectedNode.Parent Is Nothing Then
                    nodeLvlCount = tvwDARTTng.Nodes.Count
                Else
                    nodeLvlCount = tvwDARTTng.SelectedNode.Parent.Nodes.Count
                End If
                'mburts
                cboItemTypeSelect.Enabled = (editmode = adding Or editmode = editing)
                btnOpenAllFolders.Enabled = (editmode = notEditing)
                btnCloseAllFolders.Enabled = (editmode = notEditing)
                btnMoveUp.Enabled = EditingAllowed And (editmode = notEditing) And Not tvwDARTTng.SelectedNode Is Nothing _
                    And Not tvwDARTTng.SelectedNode.Index = 0
                cmTreeNodeOperations.Items("MoveUpToolStripMenuItem").Enabled = btnMoveUp.Enabled

                Dim nodeCount As Integer
                If tvwDARTTng.SelectedNode.Parent Is Nothing Then
                    nodeCount = tvwDARTTng.Nodes.Count
                Else
                    nodeCount = tvwDARTTng.SelectedNode.Parent.Nodes.Count
                End If

                tvwDARTTng.Enabled = (editmode = notEditing)
                dgvTreeProperties.Enabled = True
                btnMoveDown.Enabled = EditingAllowed And (editmode = notEditing) And Not tvwDARTTng.SelectedNode Is Nothing And tvwDARTTng.SelectedNode.Index < nodeLvlCount - 1
                cmTreeNodeOperations.Items("MoveDownToolStripMenuItem").Enabled = btnMoveDown.Enabled

                dgvUsedReportNumbers.Enabled = (editmode = notEditing)

                btnCopyItem.Enabled = EditingAllowed And ((Not tvwDARTTng.SelectedNode Is Nothing And editmode = notEditing And Strings.Left(DirectCast(tvwDARTTng.SelectedNode, DARTTreeNode).ItemType, 6).ToUpper <> "FOLDER") And Not UserEdits_NodesMoved)
                cmTreeNodeOperations.Items("CopyToolStripMenuItem").Enabled = btnCopyItem.Enabled
                btnInsert.Enabled = EditingAllowed And (editmode = notEditing) And Not UserEdits_NodesMoved
                cmTreeNodeOperations.Items("InsertToolStripMenuItem").Enabled = btnInsert.Enabled

                btnDelete.Enabled = EditingAllowed And (Not tvwDARTTng.SelectedNode Is Nothing And editmode = notEditing) 'And chkAllowDelete.Checked
                cmTreeNodeOperations.Items("DeleteToolStripMenuItem").Enabled = btnDelete.Enabled

                btnSave.Enabled = EditingAllowed And (editmode <> notEditing Or UserEdits_NodesMoved)
                btnCancel.Enabled = EditingAllowed And ((editmode <> notEditing) Or UserEdits_NodesMoved)
                btnEdit.Enabled = EditingAllowed And (Not tvwDARTTng.SelectedNode Is Nothing And editmode = notEditing And Not UserEdits_NodesMoved)
                BlinkEditText(Not btnEdit.Enabled)  ' <--- If in Edit mode, then Blink EDIT Text ---
                cmTreeNodeOperations.Items("EditToolStripMenuItem").Enabled = btnEdit.Enabled

                btnCopyToProduction.Enabled = EditingAllowed And (editmode = notEditing)
                btnRefresh.Enabled = (editmode = notEditing) And Not TreeDirty

                chkActive.Enabled = (editmode <> notEditing)
                chkHelpButton.Enabled = (editmode <> notEditing) 'And thisNode.ItemType <> "F")  'LAshby 4/29/15--who cares if it's a folder....won't ever assign a help file to a folder!!!!
                chkSchedulingEnabled.Enabled = (editmode <> notEditing) And thisNode.ItemType <> "F" 'LAshby 4/29/15

                '--- ReportCONTROLS buttons ---
                btnControlADD.Enabled = (editmode <> notEditing) And DirectCast(tvwDARTTng.SelectedNode, DARTTreeNode).ItemType = "R" And tvwDARTTng.SelectedNode.Text <> "NEW ITEM"
                btnControlEdit.Enabled = (editmode <> notEditing) And DirectCast(tvwDARTTng.SelectedNode, DARTTreeNode).ItemType = "R" And tvwDARTTng.SelectedNode.Text <> "NEW ITEM" And dgvReportControls.SelectedRows.Count > 0
                btnControlDelete.Enabled = (editmode <> notEditing) And DirectCast(tvwDARTTng.SelectedNode, DARTTreeNode).ItemType = "R" And tvwDARTTng.SelectedNode.Text <> "NEW ITEM" And dgvReportControls.SelectedRows.Count > 0
                cmReportControls.Items("cmsiAddNewToolStripMenuItem").Enabled = btnControlADD.Enabled
                cmReportControls.Items("cmsiEditToolStripMenuItem").Enabled = btnControlEdit.Enabled
                cmReportControls.Items("cmsiDeleteToolStripMenuItem").Enabled = btnControlDelete.Enabled

                If tvwDARTTng.SelectedNode.Text = "NEW ITEM" Then
                    lblReportControlMessage.Text = "To Edit Controls, First Save the TreeNode"
                    lblReportControlMessage.ForeColor = Color.Red
                Else
                    lblReportControlMessage.Text = "Edit Report Controls"
                    lblReportControlMessage.ForeColor = Color.Blue
                End If

                Dim FolderWithChildren As Boolean = (editmode = editing) And dgvImages.CurrentRow.Cells("IsFolder").Value = 0 And SaveNode.Nodes.Count > 0
                If FolderWithChildren Then
                    lblChangeItemTypeNotAllowed.Text = "(can't change because folder contains child items)"
                End If
                lblChangeItemTypeNotAllowed.Visible = FolderWithChildren ' Or FolderInNewReports

                rbFolder.Enabled = (editmode = adding)
                rbReport.Enabled = (editmode = adding)

                lblReportControlMessage.Visible = (editmode <> notEditing)

                If editmode <> notEditing Then
                    '--- Set state of DataGridView for Tree ---
                    For Each dgvRow As DataGridViewRow In dgvTreeProperties.Rows
                        If dgvRow.Cells(1).Style.BackColor = lblReadOnlyValue.BackColor Then
                            Call SetPropertyValueEditState(dgvRow.Cells(0).Value, False)
                        Else
                            Call SetPropertyValueEditState(dgvRow.Cells(0).Value, True)
                        End If
                    Next
                Else
                    For Each dgvRow As DataGridViewRow In dgvTreeProperties.Rows
                        Call SetPropertyValueEditState(dgvRow.Cells(0).Value, False)
                    Next
                End If
            End If
        Catch ex As Exception
        End Try

    End Sub

    Private Sub BuildReportPropertyColumns()
        Dim AddRow As Integer = 0
        Dim PropDr As DataRow() = dsroot.Tables("PropList").Select
        Dim pr As DataRow

        For Each pr In PropDr
            AddRow = dgvTreeProperties.Rows.Add()
            dgvTreeProperties.Item("ReportProperty", AddRow).Value = pr("Property")
            dgvTreeProperties.Item("FolderEditType", AddRow).Value = pr("FolderEditType")
            dgvTreeProperties.Item("ReportEditType", AddRow).Value = pr("ReportEditType")
        Next
    End Sub

    Private Sub tvwDARTTng_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles tvwDARTTng.AfterSelect
        Dim myNode As DARTTreeNode = DirectCast(tvwDARTTng.SelectedNode, DARTTreeNode)        '--> Cast TreeNode to DARTTreeNode
        Me.Cursor = Cursors.WaitCursor
        If Not DroppingInNewReports Then
            HandleNodeClick(e.Node)
        End If
        HandleControls()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub BuildItemTypeSelector(ByVal dsTable As String, ByVal dsColDispMem As String, ByVal dsColValMem As String, Optional ByVal value As String = Nothing)
        cboItemTypeSelect.DataSource = Nothing
        cboItemTypeSelect.DataSource = dsroot.Tables(dsTable)
        cboItemTypeSelect.DisplayMember = dsroot.Tables(dsTable).Columns(dsColDispMem).ColumnName
        cboItemTypeSelect.ValueMember = dsroot.Tables(dsTable).Columns(dsColValMem).ColumnName
        If value <> Nothing Then cboItemTypeSelect.SelectedValue = value
    End Sub

    Private Sub BuildDgvTypeSelecter(ByVal dgv As DataGridView, ByVal type As String)
        Dim curRow As Integer = 0
        Dim ImageDr As DataRow() '= dsroot.Tables(table).Select
        Dim fld1, fld2, fld3 As String

        dgv.Rows.Clear()
        If type = "O" Then
            ImageDr = dsroot.Tables("ImageDataFolders").Select
            fld1 = "Img"
            fld2 = "ImageType"
            fld3 = "ImageID"
        ElseIf type = "C" Then
            ImageDr = dsroot.Tables("ImageDataFolders").Select
            fld1 = "ImgClosed"
            fld2 = "ImageTypeClosed"
            fld3 = "ImageIDClosed"
        Else
            ImageDr = dsroot.Tables("ImageDataReports").Select
            fld1 = "Img"
            fld2 = "ImageType"
            fld3 = "ImageID"
        End If

        For Each ir As DataRow In ImageDr
            dgv.Rows.Add()
            dgv.Rows(curRow).Cells(fld1).Value = TreeImageList.ImageList.Images(ir("ImageID") - 1)  'ImageID in the ImageList is the index (1 based).
            dgv.Rows(curRow).Cells(fld2).Value = ir("ImageType")
            dgv.Rows(curRow).Cells(fld3).Value = ir("ImageID") - 1
            curRow += 1
        Next
    End Sub

    Private Sub SetItemTypeSelectors(ByVal type As String)
        If type = "F" Then
            dgvImagesFolderClosed.Visible = True

            BuildDgvTypeSelecter(dgvImages, "O")
            BuildDgvTypeSelecter(dgvImagesFolderClosed, "C")
        Else    ' "R"
            dgvImages.Visible = True
            dgvImagesFolderClosed.Visible = False

            BuildDgvTypeSelecter(dgvImages, "R")
        End If
    End Sub

    Private Sub HandleNodeClick(ByVal myNode As DARTTreeNode)
        Dim Message_unKnownDataLocation As String = "???  NOT FOUND IN NODE.  ???"
        Dim aRow As Integer = 0
        Dim i As Integer

        chkActive.Checked = myNode.IsNodeActive
        chkActive.Checked = myNode.ReportStatus = DDT_ReportStatus.Active    'LAshby-new code to replace line above
        If myNode.ItemType = "R" Then
            chkSchedulingEnabled.Checked = myNode.ScheduleEnabled
        Else
            chkSchedulingEnabled.Checked = False
        End If
        chkHelpButton.Checked = myNode.HelpEnabled

        If myNode.ItemType = "R" Then
            rbFolder.Checked = False
            rbReport.Checked = True

            SetItemTypeSelectors("R")
        Else
            rbFolder.Checked = True
            rbReport.Checked = False

            SetItemTypeSelectors("F")
        End If

        DisplayProperties(myNode)

        '--- Populate the Properties DataGridView ---
        With dgvTreeProperties
            For i = 0 To .Rows.Count - 1
                Select Case .Rows(i).Cells("ReportProperty").Value
                    Case "TreeLevelID"
                        dgvTreeProperties.Item("ReportValue", i).Value = myNode.TreeLevelID
                    Case "TreeLevelID_Parent"
                        dgvTreeProperties.Item("ReportValue", i).Value = myNode.TreeLevelID_Parent
                    Case "ItemType"
                        dgvTreeProperties.Item("ReportValue", i).Value = myNode.ItemType
                    Case "ItemTypeID"
                        dgvTreeProperties.Item("ReportValue", i).Value = myNode.ItemTypeID
                        If myNode.ItemType = "F" Then
                            BuildItemTypeSelector("Folders", "IdName", "FolderID", myNode.ItemTypeID.ToString)
                        Else
                            BuildItemTypeSelector("Reports", "IdName", "ReportID", myNode.ItemTypeID.ToString)
                        End If
                    Case "NodeName"
                        dgvTreeProperties.Item("ReportValue", i).Value = myNode.NodeName
                    Case "NodeID"
                        dgvTreeProperties.Item("ReportValue", i).Value = myNode.NodeID
                    Case "ReportFormatID"
                        dgvTreeProperties.Item("ReportValue", i).Value = myNode.ReportFormatID
                    Case "IsStatic"
                        dgvTreeProperties.Item("ReportValue", i).Value = myNode.IsStatic
                    Case "UseTabs"
                        dgvTreeProperties.Item("ReportValue", i).Value = myNode.UseTabs
                    Case "ImageID"
                        dgvTreeProperties.Item("ReportValue", i).Value = myNode.ImageID
                    Case "ImageIDExpanded"
                        dgvTreeProperties.Item("ReportValue", i).Value = myNode.ImageIDExpanded
                    Case "ImageType"  ' In sBuildTree but, NOT FOUND IN NODE
                        dgvTreeProperties.Item("ReportValue", i).Value = Message_unKnownDataLocation
                    Case "ReportID"
                        If myNode.ReportID <> 0 Then
                            .Rows(i).Cells("ReportValue") = New DataGridViewComboBoxCell
                            DirectCast(.Rows(i).Cells("ReportValue"), DataGridViewComboBoxCell).Items.Clear()
                            With DirectCast(.Rows(i).Cells("ReportValue"), DataGridViewComboBoxCell)
                                .DataSource = dsroot.Tables("Reports")
                                .DisplayMember = dsroot.Tables("Reports").Columns("IdName").ToString
                                .ValueMember = dsroot.Tables("Reports").Columns("ReportID").ToString
                                .Value = myNode.ReportID
                            End With
                        End If
                    Case "ReportName"
                        dgvTreeProperties.Item("ReportValue", i).Value = myNode.ReportName
                    Case "ReportNumber"
                        dgvTreeProperties.Item("ReportValue", i).Value = myNode.ReportNumber
                    Case "ReportTitle"  ' In sBuildTree but, NOT FOUND IN NODE
                        dgvTreeProperties.Item("ReportValue", i).Value = Message_unKnownDataLocation
                    Case "ReportFileName"
                        dgvTreeProperties.Item("ReportValue", i).Value = myNode.ReportFileName
                    Case "ReportDescription"
                        dgvTreeProperties.Item("ReportValue", i).Value = myNode.ReportDescription
                    Case "DirectoryPrimary"
                        dgvTreeProperties.Item("ReportValue", i).Value = myNode.PrimaryLocation
                    Case "CommandString"  ' In sBuildTree but, NOT FOUND IN NODE
                        dgvTreeProperties.Item("ReportValue", i).Value = myNode.CommandString
                    Case "HelpFile"
                        dgvTreeProperties.Item("ReportValue", i).Value = myNode.HelpFile
                    Case "NodeName"
                        dgvTreeProperties.Item("ReportValue", i).Value = myNode.HelpFile
                    Case "ReportFormat"
                        dgvTreeProperties.Item("ReportValue", i).Value = myNode.ReportFormat
                    Case "SpecialID"
                        dgvTreeProperties.Item("ReportValue", i).Value = myNode.SpecialID
                    Case "TabIndex"
                        dgvTreeProperties.Item("ReportValue", i).Value = myNode.TabIndex
                    Case "FullPath"
                        dgvTreeProperties.Item("ReportValue", i).Value = myNode.FullPath
                    Case "Level"
                        dgvTreeProperties.Item("ReportValue", i).Value = myNode.Level
                    Case "LeadDeveloper"
                        dgvTreeProperties.Item("ReportValue", i).Value = Message_unKnownDataLocation
                    Case "CreatedBy_EmpNum"
                        dgvTreeProperties.Item("ReportValue", i).Value = Message_unKnownDataLocation
                    Case "CreationDate"
                        dgvTreeProperties.Item("ReportValue", i).Value = myNode.CreationDate
                    Case "ModifiedBy_EmpNum"
                        dgvTreeProperties.Item("ReportValue", i).Value = myNode.ModifiedBy_EmpNum
                    Case "ModifiedDate"
                        dgvTreeProperties.Item("ReportValue", i).Value = myNode.ModifiedDate
                    Case "ApplicationID"
                        dgvTreeProperties.Item("ReportValue", i).Value = Message_unKnownDataLocation
                    Case "SortOrder"
                        dgvTreeProperties.Item("ReportValue", i).Value = myNode.SortOrder
                    Case "Base Report Item ID"
                        dgvTreeProperties.Item("ReportValue", i).Value = 0
                End Select
            Next
        End With

        BuildControlsTab(DirectCast(tvwDARTTng.SelectedNode, DARTTreeNode).TreeLevelID)

        '--- !!!NOTE!!!  ImageID in node is 1 less (0 based) than ImageID comming from the DataBase (DDTCommon.dbo.ftBuildImageList) (1 based) ---
        For r As Integer = 0 To dgvImages.Rows.Count - 1
            If myNode.ItemType = "F" Then
                If dgvImages.Rows(r).Cells("ImageID").Value = myNode.ImageIDExpanded Then
                    dgvImages.Rows(r).Selected = True
                    dgvImages.FirstDisplayedScrollingRowIndex = r
                    Exit For
                End If
            Else
                If dgvImages.Rows(r).Cells("ImageID").Value = myNode.ImageID Then
                    dgvImages.Rows(r).Selected = True
                    dgvImages.FirstDisplayedScrollingRowIndex = r
                    Exit For
                End If
            End If
        Next
        If myNode.ItemType = "F" Then
            For r As Integer = 0 To dgvImagesFolderClosed.Rows.Count - 1
                If dgvImagesFolderClosed.Rows(r).Cells("ImageIDClosed").Value = myNode.ImageID Then
                    dgvImagesFolderClosed.Rows(r).Selected = True
                    dgvImagesFolderClosed.FirstDisplayedScrollingRowIndex = r
                    Exit For
                End If
            Next
        End If

        '--- Populate the ReportPropertiesView Tab with the selected report info ---
        BuildReportsViewTab(DirectCast(tvwDARTTng.SelectedNode, DARTTreeNode).ReportID)
    End Sub

    Private Sub splTreeProps_SplitterMoved(ByVal sender As System.Object, ByVal e As System.Windows.Forms.SplitterEventArgs) Handles splTreeProps.SplitterMoved
        If dgvTreeProperties.Rows.Count > 0 Then
            ResizeControls()
        End If
    End Sub

    Private Sub frmDartTngTree_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        ResizeControls()
    End Sub

    Private Sub btnOpenAllFolders_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOpenAllFolders.Click
        tvwDARTTng.BeginUpdate()
        tvwDARTTng.ExpandAll()
        tvwDARTTng.EndUpdate()
        tvwDARTTng.SelectedNode = tvwDARTTng.Nodes(0)
        tvwDARTTng.SelectedNode.EnsureVisible()
    End Sub

    Private Sub btnCloseAllFolders_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCloseAllFolders.Click
        tvwDARTTng.BeginUpdate()
        tvwDARTTng.CollapseAll()
        tvwDARTTng.EndUpdate()
        tvwDARTTng.SelectedNode = tvwDARTTng.Nodes(0)
        tvwDARTTng.SelectedNode.EnsureVisible()
    End Sub

    Private Sub DisplayProperties(ByVal myNode As DARTTreeNode)
        Dim i As Integer
        Dim isFolder As Boolean = IIf(myNode.ItemType = "F", True, False)
        Dim isReport As Boolean = IIf(myNode.ItemType = "R", True, False)

        With dgvTreeProperties
            Dim propertyType As String
            For i = 0 To .Rows.Count - 1
                propertyType = Nothing
                If isFolder Then
                    If .Rows(i).Cells("FolderEditType").Value Is Nothing Then
                        propertyType = Nothing
                    Else
                        propertyType = .Rows(i).Cells("FolderEditType").Value.ToString
                    End If
                Else
                    If .Rows(i).Cells("ReportEditType").Value Is Nothing Then
                        propertyType = Nothing
                    Else
                        propertyType = .Rows(i).Cells("ReportEditType").Value.ToString
                    End If
                End If
                .Rows(i).Visible = (propertyType.ToUpper = "READ ONLY") Or _
                                    (propertyType.ToUpper = "READ_ONLY") Or _
                                    (.Rows(i).Cells("ReportProperty").Value = "Item Name")
                Select Case propertyType.ToUpper
                    Case "READ_ONLY", "READ ONLY"
                        .Rows(i).Cells("ReportValue").Style.BackColor = lblReadOnlyValue.BackColor
                    Case "MANDATORY"
                        .Rows(i).Cells("ReportValue").Style.BackColor = lblRequiredValue.BackColor
                    Case Else
                        .Rows(i).Cells("ReportValue").Style.BackColor = lblOptionalValue.BackColor
                End Select
            Next
        End With
    End Sub

    Private Sub dgvUsedReportNumbers_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvUsedReportNumbers.CellDoubleClick
        If editmode <> editing Then
            Dim aNode As DARTTreeNode = GetNodeByKey(tvwDARTTng, "ReportID=" + dgvUsedReportNumbers.Item("ReportID", dgvUsedReportNumbers.CurrentRow.Index).Value.ToString, True)
        End If
    End Sub

    Private Sub frmDartTngTree_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        ResizeControls()
    End Sub

    Private Sub EditRecord()
        Try
            Me.Cursor = Cursors.WaitCursor
            CheckEditingStatus()
            If EditingAllowed Then
                '----------------------------------------------------------------------------------------------------------------------
                'Added this in v1.10 to immediately lock down the table for editing instead of waiting for a record to be saved. 
                SetTreeDataState("dirty")
                '----------------------------------------------------------------------------------------------------------------------
                SaveNode = tvwDARTTng.SelectedNode
                PreEditNodeID = SaveNode.NodeID
                editmode = editing
                HandleControls()
                'mburts
                dgvReportControls.ClearSelection()
            Else
                EditNotAllowedMessage()
            End If
            Me.Cursor = Cursors.Default
        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        EditRecord()
    End Sub

    Private Sub SetTreeDataState(ByVal state As String)
        If state = "dirty" Then
            tvwDARTTng.BackColor = Color.LightSteelBlue
            TreeDirty = True
            Dim user As String = Strings.Right(My.User.Name, Len(My.User.Name) - InStrRev(My.User.Name, "\"))
            Dim sql As String = "exec DDT_Common.dbo.sToolbox_UpdateTreeLevels_EditStatus '" + user + "', 1"
            Try
                sqlCmd.CommandType = CommandType.Text
                sqlCmd.CommandText = sql
                sqlCmd.Connection = sqlConnection
                sqlConnection.Open()
                sqlCmd.ExecuteNonQuery()
            Catch sqlex As SqlClient.SqlException
                DisplayUnexpectedSQLException(sqlex)
            Finally
                sqlConnection.Close()
            End Try
        Else
            tvwDARTTng.BackColor = Color.White
            TreeDirty = False
            Dim sql As String = "exec DDT_Common.dbo.sToolbox_UpdateTreeLevels_EditStatus NULL, 1"
            Try
                sqlCmd.CommandType = CommandType.Text
                sqlCmd.CommandText = sql
                sqlCmd.Connection = sqlConnection
                sqlConnection.Open()
                sqlCmd.ExecuteNonQuery()
            Catch sqlex As SqlClient.SqlException
                DisplayUnexpectedSQLException(sqlex)
            Finally
                sqlConnection.Close()
            End Try
        End If

        CheckEditingStatus()
        HandleControls()
    End Sub

    Private Sub EditNotAllowedMessage()
        MessageBox.Show("Editing of the DART Tree is not currently allowed because it is being modified by " + LockedForEditingBy + ".", "Changes not allowed", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        editmode = notEditing
        HandleControls()
    End Sub

    Private Sub CheckEditingStatus()
        Dim EditingAllowedOnEntry As Boolean = EditingAllowed
        Dim sql As String = "exec DDT_Common.dbo.sToolbox_GetTreeLevels_EditStatus 1"
        sqlConnection = New System.Data.SqlClient.SqlConnection(connStr)
        sqlCmd = New System.Data.SqlClient.SqlCommand

        Try
            sqlCmd.CommandType = CommandType.Text
            sqlCmd.CommandText = sql
            sqlCmd.Connection = sqlConnection
            Dim reader As SqlClient.SqlDataReader
            sqlConnection.Open()
            reader = sqlCmd.ExecuteReader()
            reader.Read()
            If reader.HasRows Then
                LockedForEditingBy = reader.GetSqlString(reader.GetOrdinal("UserName"))
                LockedForEditingTime = reader.GetSqlDateTime(reader.GetOrdinal("LockTime"))
                If LockedForEditingBy = "Available for editing" Then
                    lblEditingStatus.ForeColor = Color.Green
                    lblEditingStatus.Text = LockedForEditingBy
                    EditingAllowed = True
                Else
                    If LockedForEditingBy.ToUpper = Strings.Right(My.User.Name.ToUpper, Len(My.User.Name) - InStrRev(My.User.Name, "\")) Then
                        lblEditingStatus.ForeColor = Color.Green
                        lblEditingStatus.Text = "Editing enabled : You locked out other users at " + LockedForEditingTime
                        EditingAllowed = True
                    Else
                        lblEditingStatus.ForeColor = Color.Red
                        lblEditingStatus.Text = "Locked for editing by " + LockedForEditingBy + " at " + LockedForEditingTime
                        EditingAllowed = False
                    End If
                End If
            Else
                lblEditingStatus.ForeColor = Color.Green
                lblEditingStatus.Text = LockedForEditingBy
                EditingAllowed = True
            End If

        Catch sqlex As SqlClient.SqlException
            DisplayUnexpectedSQLException(sqlex)
        Finally
            sqlConnection.Close()
        End Try

        HandleControls()
    End Sub

    Private Sub lblEditingStatus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblEditingStatus.Click
        Dim EditingAllowedOnEntry As Boolean = EditingAllowed

        Me.Cursor = Cursors.WaitCursor
        CheckEditingStatus()
        Me.Cursor = Cursors.Default
        If EditingAllowed And Not EditingAllowedOnEntry Then
            EditingReenabled()
        End If
    End Sub

    Private Sub EditingReenabled()
        MessageBox.Show("Editing of the DART Tree has been reenabled. The DART Tree will be reloaded after pressing OK.", "Editing permitted", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Me.Update()
        InitialBuild = True
        BuildTreeView()
        RefreshUsedReportNumList()
    End Sub

    Private Sub btnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefresh.Click
        Dim aNode As DARTTreeNode
        Dim RepBtnSelected As Boolean = rbReport.Checked
        Dim SaveSelectedIndex = cboItemTypeSelect.SelectedIndex
        aNode = tvwDARTTng.SelectedNode
        BuildTreeView()
        RefreshUsedReportNumList()
        BuildReportsTable()
        GetNodeByKey(tvwDARTTng, "TreeLevelID=" + aNode.TreeLevelID.ToString, True)
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Try
            If UserEdits_TREE Or UserEdits_NodesMoved Or UserEdits_CONTROL Then
                Dim Canceled_A_Save As Boolean = (sender Is Nothing)
                Dim MessageBoxResult As Integer = 0
                If (UserEdits_TREE = True Or UserEdits_CONTROL) And Not Canceled_A_Save Then
                    MessageBoxResult = RichMessageBoxShow("User EDITS have been made.  Pressing [OK] will loose any changes made and reload the tree." _
                                       + vbCrLf + "[Cancel] to resume edit.", "Cancel EDITS", _
                                        Color.Azure, Color.Azure, Color.Black, New Size(400, 100), 12, BorderStyle.None, RichMessageBoxIcon.Warning, _
                                        RichMessageBoxButtons.OKCancel, RichMessageboxDefaultButton.Button2, ScrollBars.Vertical, RichMessageboxFadeStyle.FadeOutOnly, 50)
                End If
                If MessageBoxResult = Windows.Forms.DialogResult.Cancel Then
                    Exit Sub
                Else
                    If MessageBoxResult = Windows.Forms.DialogResult.OK Or UserEdits_NodesMoved Or UserEdits_CONTROL Then
                        Me.Cursor = Cursors.WaitCursor
                        If SaveNode.Text = "" Or UserEdits_NodesMoved Then SaveNode = tvwDARTTng.SelectedNode
                        editmode = notEditing
                        BuildTreeView()

                        GetNodeByKey(tvwDARTTng, "TreeLevelID=" + SaveNode.TreeLevelID.ToString, True)
                        BuildControlsTab(DirectCast(tvwDARTTng.SelectedNode, DARTTreeNode).TreeLevelID)
                        BuildReportsViewTab(DirectCast(tvwDARTTng.SelectedNode, DARTTreeNode).ReportID)
                        UserEdits_TREE = False
                        UserEdits_CONTROL = False
                        UserEdits_NodesMoved = False
                        CopyNode_NewInsert = False       'reset this for next insert.
                    Else
                        Exit Sub
                    End If
                End If

            End If
            Me.Cursor = Cursors.WaitCursor
            CheckEditingStatus()
            SetTreeDataState("")
            If EditingAllowed Then
                editmode = notEditing
            Else
                EditNotAllowedMessage()
            End If
            UserEdits_TREE = False
            UserEdits_CONTROL = False
            UserEdits_NodesMoved = False
            CopyNode_NewInsert = False       'reset this for next insert.

            HandleControls()
            Me.Cursor = Cursors.Default
        Catch ex As Exception
        End Try
    End Sub

    Private Sub SaveCurrentControls(ByVal ResultTreeLevelID As Integer, ResultReportID As Integer)
        Try
            Dim ControlEditingType As Integer
            Dim SqlStr As String
            Dim result As String
            With dgvReportControls
                For Each dr As DataGridViewRow In .Rows
                    ControlEditingType = IIf(IsDBNull(dr.Cells("Edited").Value) = True, 0, dr.Cells("Edited").Value)
                    If ControlEditingType = 1 Then
                        result = Nothing
                        With dr
                            SqlStr = "exec dbo.sToolbox_UpdateReportControls "
                            SqlStr += .Cells("Report_ControlID").Value.ToString + ", "
                            SqlStr += .Cells("ApplicationID").Value.ToString + ", "
                            If ResultReportID <> 0 Then
                                SqlStr += ResultReportID.ToString + ", "
                            Else
                                SqlStr += .Cells("ReportID").Value.ToString + ", "
                            End If

                            SqlStr += ResultTreeLevelID.ToString + ", "
                            SqlStr += .Cells("ControlsID").Value.ToString + ", "
                            SqlStr += .Cells("IndexOrder").Value.ToString + ", "
                            SqlStr += .Cells("TabIndex").Value.ToString + ", "
                            SqlStr += "'" + .Cells("TabName").Value.ToString + "', "
                            If IsDBNull(.Cells("UseDefaultProperties").Value) Then
                                SqlStr += "0, "
                            Else
                                SqlStr += IIf(.Cells("UseDefaultProperties").Value = True, "1", "0") + ", "
                            End If
                            If IsDBNull(.Cells("UseForMultipleWorkbooks").Value) Then
                                SqlStr += "0, "
                            Else
                                SqlStr += IIf(.Cells("UseForMultipleWorkbooks").Value = True, "1", "0") + ", "
                            End If
                            SqlStr += .Cells("Width").Value.ToString + ", "
                            SqlStr += .Cells("Height").Value.ToString + ", "
                            SqlStr += .Cells("LocationX").Value.ToString + ", "
                            SqlStr += .Cells("LocationY").Value.ToString + ", "
                            SqlStr += IIf(.Cells("ChildControlID").Value.ToString = "", "0", "'" + .Cells("ChildControlID").Value.ToString + "'") + ", "
                            SqlStr += IIf(.Cells("ContainerID").Value.ToString = "", "0", "'" + .Cells("ContainerID").Value.ToString + "'")
                        End With

                        result = ExecSqlScalar(SqlStr, connStr)
                        If result = "" Then result = "ERROR: Unknown Error"

                        If Strings.Left(result, 5).ToUpper = "ERROR" Then
                            MessageBox.Show(result, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Exit Sub
                        End If
                    ElseIf ControlEditingType = 2 Then
                        '--- DELETE a Control ---
                        SqlStr = "exec dbo.sToolbox_UpdateReportControls_Delete "
                        SqlStr += dr.Cells("Report_ControlID").Value.ToString

                        result = ExecSqlScalar(SqlStr, connStr)
                        If result <> "" Then result = "ERROR: Unknown Error"

                        If Strings.Left(result, 5).ToUpper = "ERROR" Then
                            MessageBox.Show(result, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Exit Sub
                        End If
                    End If

                Next
            End With
        Catch ex As Exception
            MsgBox("Error While Copying Tree =>" & vbCrLf & vbCrLf & "Error: " & vbCrLf & ex.Message & vbCrLf & vbCrLf & "Program Error Location: " + vbCrLf & System.Reflection.MethodBase.GetCurrentMethod().ToString)
        End Try
    End Sub

    Private Sub SaveCurrentTreeNode(ByVal NodeToSave As DARTTreeNode)
        CheckEditingStatus()
        Dim tmpCurrNode As DARTTreeNode = NodeToSave
        If EditingAllowed Then
            'mburts
            If UserEdits_TREE = False And UserEdits_CONTROL = False And UserEdits_NodesMoved = False Then
                RichMessageBoxShow("No changes made... Nothing to save... Continue Edit Mode", "No Changes Made", Color.Azure, Color.Azure, _
                    Color.Black, New Size(400, 100), 12, BorderStyle.None, RichMessageBoxIcon.Information, RichMessageBoxButtons.OKCancel, _
                    RichMessageboxDefaultButton.Button1, , RichMessageboxFadeStyle.Both, 50)
                'Exit Sub
            End If

            '--- Do Some Validation - Insure data not missing and in proper formats ---
            Dim ItemTypeID As String = GetReportPropertyValue("ItemTypeID").Trim
            If ItemTypeID = 0 Then
                RichMessageBoxShow("The record cannot be saved without selecting a report that is not already in the Report Tree." _
                                    + vbCrLf + "Select a report from the DropDown List that is not in the Report Tree.", "Validation Error", Color.Azure, Color.Azure, _
                    Color.Black, New Size(500, 200), 12, BorderStyle.None, RichMessageBoxIcon._Stop, RichMessageBoxButtons.OK, _
                    RichMessageboxDefaultButton.Button1, , RichMessageboxFadeStyle.FadeOutOnly, 25)

                BlinkControl(cboItemTypeSelect, 8, 100)
                Exit Sub
            End If
            Dim itemName As String = GetReportPropertyValue("Item Name").Trim
            If itemName = Nothing Then
                RichMessageBoxShow("The ITEM NAME field cannot be left blank.", "Validation error", Color.Azure, Color.Azure, _
                    Color.Black, New Size(400, 100), 12, BorderStyle.None, RichMessageBoxIcon.Exclamation, RichMessageBoxButtons.OKCancel, _
                    RichMessageboxDefaultButton.Button1, , RichMessageboxFadeStyle.FadeOutOnly, 65)

                SelectReportValueCell("Item name")
                dgvTreeProperties.BeginEdit(True)
                Exit Sub
            End If

            '--- Ok, now SAVE the Tree info ---
            Dim SqlStr As String = Nothing
            'mburts
            With DirectCast(tvwDARTTng.SelectedNode, DARTTreeNode)
                SqlStr = "exec dbo.sToolbox_UpdateTreeLevels "
                SqlStr += GetReportPropertyValue("TreeLevelID") + ","
                If DirectCast(tvwDARTTng.SelectedNode, DARTTreeNode).TreeLevelID_Parent.ToString = Nothing Then
                    SqlStr += "0" + ","
                Else
                    SqlStr += DirectCast(tvwDARTTng.SelectedNode, DARTTreeNode).TreeLevelID_Parent.ToString + ","
                End If
                SqlStr += "'" + IIf(rbFolder.Checked, "F", "R") + "',"
                SqlStr += GetReportPropertyValue("ItemTypeID") + ","
                SqlStr += IIf(chkActive.Checked = True, "1", "0") + ","
                SqlStr += "1,"
                SqlStr += "'" + EmpNumber.ToString + "',"
                SqlStr += IIf(chkHelpButton.Checked = True, "1", "0") + ","
                SqlStr += IIf(chkSchedulingEnabled.Checked = True, "1", "0") + ","
                If .PrevNode Is Nothing Then
                    SqlStr += "0" + ","
                Else
                    SqlStr += DirectCast(.PrevNode, DARTTreeNode).TreeLevelID.ToString + ","
                End If
                SqlStr += "1"
            End With

            Dim ResultTreeLevelID As Integer = GetReportPropertyValue("TreeLevelID")
            Dim ResultReportID As Integer = 0
            Dim ChildIDsUsed As Boolean = False
            Dim GroupIDsUsed As Boolean = False
            Dim xSize As Integer = 400
            Dim ySize As Integer = 100
            If ContainerIDsMap IsNot Nothing And UserEdits_CONTROL Then
                For i As Integer = 0 To UBound(ContainerIDsMap) - 1
                    If ContainerIDsMap(i) >= 0 Then
                        GroupIDsUsed = True
                        Exit For
                    End If
                Next
            End If
            If ChildIDsMap IsNot Nothing And UserEdits_CONTROL Then
                For i As Integer = 0 To UBound(ChildIDsMap) - 1
                    If ChildIDsMap(i) >= 0 Then
                        ChildIDsUsed = True
                        Exit For
                    End If
                Next
            End If

            Dim msgText As String = "Save NODE modifications to the database." + vbCrLf + vbCrLf
            msgText += "[OK] to proceed" + vbCrLf + IIf(UserEdits_NodesMoved, "[Cancel] will exit Edit mode.", "[Cancel] to continue Edit")

            If RichMessageBoxShow(msgText, _
            "Save Changes", Color.Azure, Color.Azure, Color.Black, New Size(xSize, ySize), 10, BorderStyle.None, RichMessageBoxIcon.Information, RichMessageBoxButtons.OKCancel, _
            RichMessageboxDefaultButton.Button1, ScrollBars.Vertical, RichMessageboxFadeStyle.FadeOutOnly, 50) _
            = CustomDialogResult.Cancel Then
                If UserEdits_NodesMoved Then
                    btnCancel_Click(Nothing, Nothing)
                End If
                Exit Sub
            End If
            Dim result As String
            'Call DB to Save Changes
            result = ExecSqlScalar(SqlStr, connStr)
            If result = Nothing Then result = "ERROR: Unknown Error"

            If Strings.Left(result, 5).ToUpper = "ERROR" Then
                MessageBox.Show(result, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            Else
                ResultTreeLevelID = CInt(result)
            End If

            Dim ControlEditingType As Integer = 0
            If UserEdits_CONTROL Then
                '--- Now, save any Controls Modifications. ---
                SaveCurrentControls(ResultTreeLevelID, CopyNodeNewReportNum)
            End If

            BuildTreeView()

            SetTreeDataState("")
            editmode = notEditing
            HandleControls()

            Call GetNodeByKey(tvwDARTTng, "TreeLevelID=" + ResultTreeLevelID.ToString, True)

            If CopyNode_NewInsert And (ChildIDsUsed Or GroupIDsUsed) Then
                SetChildIDMapping()
                SaveCurrentControls(ResultTreeLevelID, CopyNodeNewReportNum)
            End If

            ChildIDsUsed = False
            GroupIDsUsed = False
            CopyNode_NewInsert = False

            '--- After save, restore some settings ---
            UserEdits_TREE = False
            UserEdits_CONTROL = False
            UserEdits_NodesMoved = False
            CopyNode_ControlsContainChildIDs = False

            RefreshUsedReportNumList()
            cboItemTypeSelect.BackColor = Color.White
            cboItemTypeSelect.ForeColor = Color.Black
        End If

    End Sub
    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        SaveCurrentTreeNode(tvwDARTTng.SelectedNode)
    End Sub
    Private Sub SelectReportValueCell(ByVal PropertyName As String)
        Dim i As Integer = 0
        Dim found As Boolean = False
        With dgvTreeProperties
            While i <= .Rows.Count - 1 And Not found
                If .Rows(i).Cells("ReportProperty").Value.ToString.ToUpper = PropertyName.ToUpper Then
                    found = True
                Else
                    i += 1
                End If
            End While
            If found Then .Rows(i).Cells("ReportValue").Selected = True
        End With
    End Sub

    Private Sub tvwDARTTng_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tvwDARTTng.DoubleClick
        If DirectCast(tvwDARTTng.SelectedNode, DARTTreeNode).ItemType = "R" Then
            EditRecord()
        End If
    End Sub

    '--- 2008/07/02 MSG
    '--- This subroutine was written to keep track of ChildID and ContainerID positions within an array inorder to reset them later, when copied to new records. ---
    Private Sub BuildChildIDMapping()
        Dim currChildID As Integer = 0
        Dim currContainerID As Integer = 0
        Dim SearchChildID As Integer = 0
        Dim SearchContainerID As Integer = 0
        Dim i As Integer
        Dim arraySize As Integer = dgvReportControls.Rows.Count - 1
        If arraySize <= 0 Then Exit Sub

        '--- Initialize Arrays ---
        ReDim ChildIDsMap(arraySize)
        ReDim ContainerIDsMap(arraySize)
        For i = 0 To arraySize
            ChildIDsMap(i) = -1
            ContainerIDsMap(i) = -1
        Next

        Dim index As Integer = 0
        For Each dr As DataGridViewRow In dgvReportControls.Rows
            '--- Create ChildID Mapping ---
            If IsNumeric(dr.Cells("ChildControlID").Value) Then
                currChildID = dr.Cells("ChildControlID").Value
                If currChildID > 0 Then
                    CopyNode_ControlsContainChildIDs = True
                    '--- Scan again to get ChildID position and set map value ---
                    For i = index + 1 To arraySize
                        If IsNumeric(dgvReportControls.Rows(i).Cells("Report_ControlID").Value) Then
                            SearchChildID = dgvReportControls.Rows(i).Cells("Report_ControlID").Value
                            If currChildID = SearchChildID Then
                                ChildIDsMap(index) = i
                            End If
                        End If
                    Next
                End If
            End If
            '--- Create ContainerID Mapping ---
            If IsNumeric(dr.Cells("ContainerID").Value) Then
                currContainerID = dr.Cells("ContainerID").Value
                If currContainerID > 0 Then
                    '--- Scan again to get ContainerID position and set map value ---
                    For i = index - 1 To 0 Step -1
                        If IsNumeric(dgvReportControls.Rows(i).Cells("Report_ControlID").Value) Then
                            SearchContainerID = dgvReportControls.Rows(i).Cells("Report_ControlID").Value
                            If currContainerID = SearchContainerID Then
                                ContainerIDsMap(index) = i
                            End If
                        End If
                    Next
                End If
            End If
            index += 1
        Next
    End Sub

    Private Sub SetChildIDMapping()
        Dim i As Integer
        Dim arraySize As Integer = dgvReportControls.Rows.Count - 1
        If arraySize <= 0 Then Exit Sub

        For i = 0 To arraySize
            If ChildIDsMap(i) > 0 Then
                dgvReportControls.Rows(i).Cells("ChildControlID").Value = dgvReportControls.Rows(ChildIDsMap(i)).Cells("Report_ControlID").Value
                dgvReportControls.Rows(i).Cells("Edited").Value = 1
            End If
        Next

        For i = 0 To arraySize
            If ContainerIDsMap(i) > 0 Then
                dgvReportControls.Rows(i).Cells("ContainerID").Value = dgvReportControls.Rows(ContainerIDsMap(i)).Cells("Report_ControlID").Value
                dgvReportControls.Rows(i).Cells("Edited").Value = 1
            End If
        Next
    End Sub

    Private Sub CopyReportControls()
        CopyNode_ControlsContainChildIDs = False
        With dsroot.Tables("CopyNode_ReportControls")
            .Columns.Clear()
            .Clear()
            If dgvReportControls.Rows.Count > 0 Then
                '--- Create COLUMNS in Table ---
                For Each dgCol As DataGridViewColumn In dgvReportControls.Columns
                    .Columns.Add(dgCol.Name)
                Next

                Dim rIndex As Integer
                '--- Add DATA ROWS to rable ---
                For Each dgRow As DataGridViewRow In dgvReportControls.Rows
                    '--- Add row and save index to new row ---
                    rIndex = .Rows.IndexOf(.Rows.Add())

                    '--- With new row, add data to each column ---
                    For i As Integer = 0 To .Columns.Count - 1
                        If .Columns(i).ToString = "ReportID" Or .Columns(i).ToString = "Report_ControlID" Then
                            .Rows(rIndex).Item(i) = "0"
                        Else
                            .Rows(rIndex).Item(i) = dgRow.Cells(i).Value
                        End If
                    Next
                Next

                '--- The mapping that's being build is currently only being used to note that ChildIDs were present ---
                BuildChildIDMapping()
            End If
        End With

    End Sub
    Private Sub btnCopyItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCopyItem.Click
        Try
            CopyNode = DirectCast(tvwDARTTng.SelectedNode, DARTTreeNode)
            CopyNodeNewReportNum = ExecSqlScalar("SELECT IDENT_CURRENT('dbo.trreports') + IDENT_INCR('dbo.trreports')", connStr)
            Dim result As String = ExecSqlScalar("exec dbo.sToolbox_CopyReportsTables '" & CopyNode.ItemTypeID & "', '" & CopyNodeNewReportNum & "', '" & CopyNode.TreeLevelID & "'", connStr)
            lblCopyItemBuffer.Text = CopyNode.Text
            lblCopyItemBuffer.ForeColor = Color.Blue
            CopyNode_NewInsert = False
            CopyReportControls()
        Catch ex As Exception
            MsgBox("Error While Coping Report", ex.Message)
        End Try
    End Sub

#Region "Functions"
    Function SetReportPropertyValue(ByVal PropertyName As String, ByVal Value As String) As String
        Dim aResult As String = "property not found"
        Dim i As Integer = 0
        Dim found As Boolean = False

        With dgvTreeProperties
            While i <= .Rows.Count - 1 And Not found
                If .Rows(i).Cells("ReportProperty").Value.ToString.ToUpper = PropertyName.ToUpper Then
                    aResult = "FOUND"
                    .Rows(i).Cells("ReportValue").Value = Value
                    found = True
                Else
                    i += 1
                End If
            End While
        End With

        Return aResult
    End Function

    Function GetReportPropertyValue(ByVal PropertyName As String) As String
        Dim aResult As String = "property not found"
        Dim i As Integer = 0
        Dim found As Boolean = False

        With dgvTreeProperties
            While i <= .Rows.Count - 1 And Not found
                If .Rows(i).Cells("ReportProperty").Value.ToString.ToUpper = PropertyName.ToUpper Then
                    aResult = .Rows(i).Cells("ReportValue").FormattedValue.ToString.Trim
                    found = True
                Else
                    i += 1
                End If
            End While
        End With
        Return aResult
    End Function

    Function SetPropertyValueEditState(ByVal PropertyName As String, ByVal EditEnable As Boolean) As String
        Dim aResult As String = "property not found"
        Dim i As Integer = 0
        Dim found As Boolean = False

        With dgvTreeProperties
            While i <= .Rows.Count - 1 And Not found
                If .Rows(i).Cells("ReportProperty").Value.ToString.ToUpper = PropertyName.ToUpper Then
                    .Rows(i).Cells("ReportValue").ReadOnly = Not EditEnable
                    aResult = "FOUND"
                    found = True
                Else
                    i += 1
                End If
            End While
        End With

        Return aResult
    End Function

    Private Function GetNodeMapping(ByVal NodePath As String) As String

        Dim nodeNames() As String = Split(NodePath, "_")
        Dim level1 As Integer
        Dim level2 As Integer
        Dim level3 As Integer
        Dim level4 As Integer
        Dim level5 As Integer
        Dim level6 As Integer
        Dim found As Boolean
        Dim resultStr As String = ""

        Dim totalNodes As Integer = nodeNames.GetLength(0)
        Try
            With tvwDARTTng
                If totalNodes >= 1 Then
                    found = False
                    level1 = 0
                    While level1 <= .Nodes.Count - 1 And Not found
                        If nodeNames(0) = .Nodes(level1).Text Then
                            found = True
                            If resultStr <> "" Then resultStr += ";"
                            resultStr += level1.ToString
                        Else
                            level1 += 1
                        End If
                    End While
                End If

                If totalNodes >= 2 Then
                    found = False
                    level2 = 0
                    While level2 <= .Nodes(level1).Nodes.Count - 1 And Not found
                        If nodeNames(1) = .Nodes(level1).Nodes(level2).Text Then
                            found = True
                            If resultStr <> "" Then resultStr += ";"
                            resultStr += level2.ToString
                        Else
                            level2 += 1
                        End If
                    End While
                End If

                If totalNodes >= 3 Then
                    found = False
                    level3 = 0
                    While level3 <= .Nodes(level1).Nodes(level2).Nodes.Count - 1 And Not found
                        If nodeNames(2) = .Nodes(level1).Nodes(level2).Nodes(level3).Text Then
                            found = True
                            If resultStr <> "" Then resultStr += ";"
                            resultStr += level3.ToString
                        Else
                            level3 += 1
                        End If
                    End While
                End If

                If totalNodes >= 4 Then
                    found = False
                    level4 = 0
                    While level4 <= .Nodes(level1).Nodes(level2).Nodes(level3).Nodes.Count - 1 And Not found
                        If nodeNames(3) = .Nodes(level1).Nodes(level2).Nodes(level3).Nodes(level4).Text Then
                            found = True
                            If resultStr <> "" Then resultStr += ";"
                            resultStr += level4.ToString
                        Else
                            level4 += 1
                        End If
                    End While
                End If

                If totalNodes >= 5 Then
                    found = False
                    level5 = 0
                    While level5 <= .Nodes(level1).Nodes(level2).Nodes(level3).Nodes(level4).Nodes.Count - 1 And Not found
                        If nodeNames(4) = .Nodes(level1).Nodes(level2).Nodes(level3).Nodes(level4).Nodes(level5).Text Then
                            found = True
                            If resultStr <> Nothing Then resultStr += ";"
                            resultStr += level5.ToString
                        Else
                            level5 += 1
                        End If
                    End While
                End If

                If totalNodes >= 6 Then
                    found = False
                    level6 = 0
                    While level6 <= .Nodes(level1).Nodes(level2).Nodes(level3).Nodes(level4).Nodes(level5).Nodes.Count - 1 And Not found
                        If nodeNames(5) = .Nodes(level1).Nodes(level2).Nodes(level3).Nodes(level4).Nodes(level5).Nodes(level6).Text Then
                            found = True
                            If resultStr <> "" Then resultStr += ";"
                            resultStr += level6.ToString
                        Else
                            level6 += 1
                        End If
                    End While
                End If

            End With
            Return resultStr
        Catch ex As DataException
            resultStr = Nothing
            Return resultStr
        End Try
    End Function

#End Region
    Private Sub EditControls(ByVal AddMode As Boolean)

        If dgvReportControls.SelectedRows.Count <= 0 And AddMode = False Then
            MessageBox.Show("Must first select a row before attempting to edit", "Need to select a row", MessageBoxButtons.OK)
            Exit Sub
        End If

        '--- Create tables used in edit form ---
        BuildDataSet(sqlConnection, _
"select *, CM.ControlName from dbo.trControls C (nolock) inner join dbo.trControls_Master CM (nolock) ON C.Controls_MasterID = CM.Controls_MasterID Order By ControlTitle", "trControls", dsroot)
        BuildDataSet_TOOLBOX(sqlConnection, "select * from dbo.trControls_Master", "trControls_Master", dsroot)


        '--- Add a Column to the table ---
        dsroot.Tables("trControls").Columns.Add("MyControlName")
        '--- populate the new column with a descriptive name ---
        For Each dRow As DataRow In dsroot.Tables("trControls").Rows
            dRow.Item("MyControlName") = "<ID=" + dRow.Item("ControlsID").ToString + ">   [" _
                        + dRow.Item("ControlName").ToString + "]   " + dRow.Item("ControlTitle").ToString _
                        + dRow.Item("MyControlName") + "  (" + dRow.Item("Tag").ToString + ")"
        Next

        '--- Set some default values and some initializations ---
        With frmDARTTngEditReportControls
            .txtReportControlID.ReadOnly = True
            .txtApplicationID.Text = 1
            .txtApplicationID.ReadOnly = True
            .txtReportID.Text = DirectCast(tvwDARTTng.SelectedNode, DARTTreeNode).ReportID
            .txtReportID.ReadOnly = True
            .txtTreeLevelID.Text = DirectCast(tvwDARTTng.SelectedNode, DARTTreeNode).TreeLevelID
            .txtTreeLevelID.ReadOnly = True
            .txtControlTitle.ReadOnly = True
            .txtControlName.ReadOnly = True

            If AddMode Then
                .txtReportControlID.Text = "0"
                .txtWidth.Text = 0
                .txtHeight.Text = 0
                .txtLocationX.Text = 0
                .txtLocationY.Text = 0
                .txtIndexOrder.Text = 0
                .chkUseDefaultProperties.Checked = False
                .chkUseForMultipleWorkbooks.Checked = False
                .cboChildIDs.SelectedValue = ""
                .cboContainerID.SelectedValue = ""
            Else
                .txtReportControlID.Text = dgvReportControls.SelectedRows.Item(0).Cells("Report_ControlID").Value.ToString
                .txtWidth.Text = dgvReportControls.SelectedRows.Item(0).Cells("Width").Value
                .txtHeight.Text = dgvReportControls.SelectedRows.Item(0).Cells("Height").Value
                .txtLocationX.Text = dgvReportControls.SelectedRows.Item(0).Cells("LocationX").Value
                .txtLocationY.Text = dgvReportControls.SelectedRows.Item(0).Cells("LocationY").Value
                .txtIndexOrder.Text = dgvReportControls.SelectedRows.Item(0).Cells("IndexOrder").Value
                .chkUseDefaultProperties.Checked = IIf(IsDBNull(dgvReportControls.SelectedRows.Item(0).Cells("UseDefaultProperties").Value), False, dgvReportControls.SelectedRows.Item(0).Cells("UseDefaultProperties").Value)
                .chkUseForMultipleWorkbooks.Checked = IIf(IsDBNull(dgvReportControls.SelectedRows.Item(0).Cells("UseForMultipleWorkbooks").Value), False, dgvReportControls.SelectedRows.Item(0).Cells("UseForMultipleWorkbooks").Value)
                .cboChildIDs.SelectedValue = dgvReportControls.SelectedRows.Item(0).Cells("ChildControlID").Value.ToString
                .cboContainerID.SelectedValue = dgvReportControls.SelectedRows.Item(0).Cells("ContainerID").Value.ToString
            End If

            .cboControlsID.DataSource = dsroot.Tables("trControls")
            .cboControlsID.DisplayMember = dsroot.Tables("trControls").Columns("MyControlName").ToString
            .cboControlsID.ValueMember = dsroot.Tables("trControls").Columns("ControlsID").ToString

            If AddMode Then
                .cboControlsID.SelectionStart = 0
                .cboControlsID.SelectionLength = 0
                .cboControlsID.Text = ""
            Else
                .cboControlsID.SelectedValue = dgvReportControls.SelectedRows.Item(0).Cells("ControlsID").Value.ToString
                .cboControlsID.Text = dgvReportControls.SelectedRows.Item(0).Cells("ControlsID").Value.ToString
            End If

            Dim i As Integer = 0
            Dim j As Integer = 0
            Dim k As Integer = 1
            Dim found As Boolean
            Dim ds As New DataSet
            ds.Tables.Add("UsedTabNames")
            ds.Tables.Add("UsedTabIndexes")
            ds.Tables.Add("ChildIDs")
            ds.Tables.Add("ContainerIDs")
            ds.Tables("UsedTabIndexes").Columns.Add("UsedTabIndex")
            ds.Tables("UsedTabNames").Columns.Add("UsedTabName")
            ds.Tables("ChildIDs").Columns.Add("ChildID")
            ds.Tables("ChildIDs").Columns.Add("ChildIDName")
            ds.Tables("ChildIDs").Rows.Add("") '<-- ADD a blank row
            ds.Tables("ContainerIDs").Columns.Add("ContainerID")
            ds.Tables("ContainerIDs").Columns.Add("ContainerName")
            ds.Tables("ContainerIDs").Rows.Add("") '<-- ADD a blank row

            '--- Scan all DataGridView Rows ---
            For Each dgvr As DataGridViewRow In dgvReportControls.Rows
                found = False
                For Each dr As DataRow In ds.Tables("UsedTabNames").Rows
                    If dr.Item("UsedTabName").ToString = dgvr.Cells("TabName").Value.ToString Then
                        found = True
                        Exit For
                    End If
                Next
                If found = False Then
                    ds.Tables("UsedTabNames").Rows.Add()
                    ds.Tables("UsedTabNames").Rows(i).Item("UsedTabName") = dgvr.Cells("TabName").Value
                    i += 1
                End If

                found = False
                For Each dr As DataRow In ds.Tables("UsedTabIndexes").Rows
                    If dr.Item("UsedTabIndex").ToString = dgvr.Cells("TabIndex").Value.ToString Then
                        found = True
                        Exit For
                    End If

                Next
                If found = False Then
                    ds.Tables("UsedTabIndexes").Rows.Add()
                    ds.Tables("UsedTabIndexes").Rows(j).Item("UsedTabIndex") = dgvr.Cells("TabIndex").Value
                    j += 1
                End If

                If Not AddMode Then
                    '--- Add Containers to table ---
                    If dgvr.Cells("ControlName").Value.ToString = "DDT_GroupedControls" _
                    And dgvReportControls.SelectedRows.Item(0).Cells("TabIndex").Value.ToString = dgvr.Cells("TabIndex").Value.ToString _
                    And dgvReportControls.SelectedRows.Item(0).Cells("indexOrder").Value > dgvr.Cells("indexOrder").Value _
                    Then
                        ds.Tables("ContainerIDs").Rows.Add()
                        ds.Tables("ContainerIDs").Rows(k).Item("ContainerID") = dgvr.Cells("Report_ControlID").Value
                        ds.Tables("ContainerIDs").Rows(k).Item("ContainerName") = _
                                            "[" + dgvr.Cells("Report_ControlID").Value.ToString + "]  --  <" _
                                            + dgvr.Cells("ControlName").Value.ToString + ">"
                        k += 1
                    End If
                End If

                '--------------------------------------
                If Not AddMode Then
                    With dgvReportControls
                        If .SelectedRows.Item(0).Cells("TabIndex").Value.ToString = dgvr.Cells("TabIndex").Value.ToString _
                        And .SelectedRows.Item(0).Cells("Report_ControlID").Value <> dgvr.Cells("Report_ControlID").Value _
                        And dgvr.Cells("indexOrder").Value > .SelectedRows.Item(0).Cells("indexOrder").Value Then
                            Dim rowNum As Integer = _
                            ds.Tables("ChildIDs").Rows.IndexOf(ds.Tables("ChildIDs").Rows.Add())
                            ds.Tables("ChildIDs").Rows(rowNum).Item("ChildIDName") = _
                                                            "[" + dgvr.Cells("Report_ControlID").Value.ToString _
                                                            + "]  --  <" + dgvr.Cells("ControlTitle").Value.ToString _
                                                            + ">  <" + dgvr.Cells("ControlName").Value.ToString + ">"
                            ds.Tables("ChildIDs").Rows(rowNum).Item("ChildID") = dgvr.Cells("Report_ControlID").Value.ToString
                        End If
                    End With
                End If
            Next

            If AddMode Then
            Else
                .cboChildIDs.DataSource = ds.Tables("ChildIDs")
                .cboChildIDs.DisplayMember = ds.Tables("ChildIDs").Columns("ChildIDName").ToString
                .cboChildIDs.ValueMember = ds.Tables("ChildIDs").Columns("ChildID").ToString
                .cboChildIDs.SelectedValue = dgvReportControls.SelectedRows.Item(0).Cells("ChildControlID").Value

                .cboContainerID.DataSource = ds.Tables("ContainerIDs")
                .cboContainerID.DisplayMember = ds.Tables("ContainerIDs").Columns("ContainerName").ToString
                .cboContainerID.ValueMember = ds.Tables("ContainerIDs").Columns("ContainerID").ToString
                .cboContainerID.SelectedValue = dgvReportControls.SelectedRows.Item(0).Cells("ContainerID").Value
            End If

            .cboTabName.DataSource = ds.Tables("UsedTabNames")
            .cboTabName.DisplayMember = ds.Tables("UsedTabNames").Columns("UsedTabName").ToString
            .cboTabName.ValueMember = ds.Tables("UsedTabNames").Columns("UsedTabName").ToString
            If AddMode Then
                .cboTabName.SelectionStart = 0
                .cboTabName.SelectionLength = 0
                .cboTabName.Text = ""
            Else
                .cboTabName.SelectedValue = dgvReportControls.SelectedRows.Item(0).Cells("TabName").Value.ToString
                .cboTabName.Text = dgvReportControls.SelectedRows.Item(0).Cells("TabName").Value.ToString
            End If

            .cboTabIndex.DataSource = ds.Tables("UsedTabIndexes")
            .cboTabIndex.DisplayMember = ds.Tables("UsedTabIndexes").Columns("UsedTabIndex").ToString
            .cboTabIndex.ValueMember = ds.Tables("UsedTabIndexes").Columns("UsedTabIndex").ToString
            If AddMode Then
                .cboTabIndex.SelectionStart = 0
                .cboTabIndex.SelectionLength = 0
                .cboTabIndex.Text = ""
            Else
                .cboTabIndex.SelectedValue = dgvReportControls.SelectedRows.Item(0).Cells("TabIndex").Value.ToString
                .cboTabIndex.Text = dgvReportControls.SelectedRows.Item(0).Cells("TabIndex").Value.ToString
            End If

        End With

        Dim result As Integer = frmDARTTngEditReportControls.ShowDialog

        '--- If OK pressed, then ADD/EDIT the row ---
        If result = DialogResult.OK Then
            UserEdits_CONTROL = True

            Dim rowIndex As Integer

            With dsroot.Tables("ReportControls")
                If AddMode Then
                    rowIndex = .Rows.IndexOf(.Rows.Add)
                Else
                    rowIndex = dgvReportControls.SelectedRows(0).Index
                End If

                .Rows(rowIndex).Item("Report_ControlID") = frmDARTTngEditReportControls.txtReportControlID.Text.ToString
                .Rows(rowIndex).Item("ApplicationID") = frmDARTTngEditReportControls.txtApplicationID.Text.ToString
                .Rows(rowIndex).Item("ReportID") = frmDARTTngEditReportControls.txtReportID.Text
                .Rows(rowIndex).Item("TreeLevelID") = frmDARTTngEditReportControls.txtTreeLevelID.Text
                .Rows(rowIndex).Item("ControlsID") = frmDARTTngEditReportControls.cboControlsID.SelectedValue
                .Rows(rowIndex).Item("ControlTitle") = frmDARTTngEditReportControls.txtControlTitle.Text
                .Rows(rowIndex).Item("ControlName") = frmDARTTngEditReportControls.txtControlName.Text
                .Rows(rowIndex).Item("IndexOrder") = IIf(frmDARTTngEditReportControls.txtIndexOrder.Text = "", 0, frmDARTTngEditReportControls.txtIndexOrder.Text)
                .Rows(rowIndex).Item("TabIndex") = IIf(frmDARTTngEditReportControls.cboTabIndex.Text = "", 0, frmDARTTngEditReportControls.cboTabIndex.Text)
                .Rows(rowIndex).Item("TabName") = frmDARTTngEditReportControls.cboTabName.Text
                .Rows(rowIndex).Item("UseDefaultProperties") = frmDARTTngEditReportControls.chkUseDefaultProperties.Checked
                .Rows(rowIndex).Item("UseForMultipleWorkbooks") = frmDARTTngEditReportControls.chkUseForMultipleWorkbooks.Checked
                .Rows(rowIndex).Item("Width") = IIf(frmDARTTngEditReportControls.txtWidth.Text = "", 0, frmDARTTngEditReportControls.txtWidth.Text)
                .Rows(rowIndex).Item("Height") = IIf(frmDARTTngEditReportControls.txtHeight.Text = "", 0, frmDARTTngEditReportControls.txtHeight.Text)
                .Rows(rowIndex).Item("LocationX") = IIf(frmDARTTngEditReportControls.txtLocationX.Text = "", 0, frmDARTTngEditReportControls.txtLocationX.Text)
                .Rows(rowIndex).Item("LocationY") = IIf(frmDARTTngEditReportControls.txtLocationY.Text = "", 0, frmDARTTngEditReportControls.txtLocationY.Text)
                .Rows(rowIndex).Item("ChildControlID") = IIf(frmDARTTngEditReportControls.cboChildIDs.SelectedValue = "", DBNull.Value, frmDARTTngEditReportControls.cboChildIDs.SelectedValue)
                .Rows(rowIndex).Item("ContainerID") = IIf(frmDARTTngEditReportControls.cboContainerID.SelectedValue = "", DBNull.Value, frmDARTTngEditReportControls.cboContainerID.SelectedValue)
                .Rows(rowIndex).Item("Edited") = 1
            End With

            dgvReportControls.DataSource = dsroot.Tables("ReportControls")

            '--- Display controls on Graphical tab page to include changes just made in the routine. ---
            DisplayControls()
        End If

    End Sub

    Private Sub btnControlADD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnControlADD.Click
        EditControls(True)
    End Sub

    Private Sub btnControlDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnControlDelete.Click
        If dgvReportControls.SelectedRows.Count > 0 Then
            dgvReportControls.SelectedRows.Item(0).DefaultCellStyle.BackColor = Color.Gray
            dgvReportControls.SelectedRows.Item(0).Cells("Edited").Value = 2        '<-- OK, i guess 2 will mean DELETE ---

            With dgvReportControls.DefaultCellStyle
                dgvReportControls.SelectedRows.Item(0).DefaultCellStyle.Font = New Font("Segoe UI", .Font.Size, FontStyle.Italic)
                dgvReportControls.SelectedRows.Item(0).DefaultCellStyle.SelectionBackColor = Color.Gray
            End With
            UserEdits_CONTROL = True
        End If
    End Sub

    Private Sub btnInsert_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInsert.Click
        Try
            CheckEditingStatus()
            If EditingAllowed Then
                UserEdits_TREE = True
                InsertType = IIf(Strings.Left(DirectCast(tvwDARTTng.SelectedNode, DARTTreeNode).ItemType, 6).ToUpper = "F", "folder", "item")
                If InsertType.ToUpper = "FOLDER" Then
                    If Strings.Left(tvwDARTTng.SelectedNode.FullPath, 9).ToUpper = "FAVORITES" _
                    Or Strings.Left(tvwDARTTng.SelectedNode.FullPath, 17).ToUpper = "SCHEDULED REPORTS" Then
                        InsertType += "-no insert"

                        RichMessageBoxShow("At this time, insert into this folder is not allowed.", "Insert not currently allowed", Color.White, Color.White, Color.Blue, New Size(400, 100), 12, BorderStyle.None, RichMessageBoxIcon.Asterisk, RichMessageBoxButtons.OK, RichMessageboxDefaultButton.Button1, ScrollBars.Vertical, RichMessageboxFadeStyle.FadeOutOnly)
                        Exit Sub
                    End If
                End If
                frmInsertDARTTngTreeItem.ShowDialog()
                Dim insertChoice As String = frmInsertDARTTngTreeItem.Result

                frmInsertDARTTngTreeItem.Dispose()
                If insertChoice <> "cancel" Then
                    Dim insertOptions() As String = Split(insertChoice, ";")
                    Dim NodeToInsert As New DARTTreeNode

                    Dim InsertAtNode As DARTTreeNode = DirectCast(tvwDARTTng.SelectedNode, DARTTreeNode)
                    Dim destNodeMap() As String = Split(GetNodeMapping(InsertAtNode.FullPath), ";")

                    Dim destItemType As String = IIf(InsertAtNode.ItemType = "F", "Folder", "Item")
                    Dim parentIndex As Integer = IIf(destItemType = "Folder", destNodeMap.GetLength(0) - 1, destNodeMap.GetLength(0) - 2)

                    NodeToInsert.Text = "NEW ITEM"

                    'Insert the node
                    Dim folderDropChoice = insertOptions(1)
                    Select Case parentIndex
                        Case 0
                            If destItemType = "Folder" Then
                                If folderDropChoice = "in" Then
                                    NodeToInsert.TreeLevelID_Parent = InsertAtNode.TreeLevelID
                                    tvwDARTTng.Nodes(CInt(destNodeMap(0))).Nodes.Add(NodeToInsert)
                                Else
                                    tvwDARTTng.Nodes.Insert(InsertAtNode.Index, NodeToInsert)
                                End If
                            Else
                                If folderDropChoice = "before" Then
                                    tvwDARTTng.Nodes(CInt(destNodeMap(0))).Nodes.Insert(InsertAtNode.Index, NodeToInsert)
                                Else
                                    If InsertAtNode.Index < InsertAtNode.Parent.Nodes.Count - 1 Then
                                        '--- Add 1 to the index to insert after selected node.
                                        tvwDARTTng.Nodes(CInt(destNodeMap(0))).Nodes.Insert(InsertAtNode.Index + 1, NodeToInsert)
                                    Else
                                        '--- Node at end of list under current parrent.  Therefore, do an ADD. ---
                                        tvwDARTTng.Nodes(CInt(destNodeMap(0))).Nodes.Add(NodeToInsert)
                                    End If
                                End If
                            End If
                        Case 1
                            If destItemType = "Folder" Then
                                If folderDropChoice = "in" Then
                                    NodeToInsert.TreeLevelID_Parent = InsertAtNode.TreeLevelID
                                    tvwDARTTng.Nodes(CInt(destNodeMap(0))).Nodes(CInt(destNodeMap(1))).Nodes.Add(NodeToInsert)
                                Else
                                    tvwDARTTng.Nodes(CInt(destNodeMap(0))).Nodes.Insert(InsertAtNode.Index, NodeToInsert)
                                End If
                            Else
                                If folderDropChoice = "before" Then
                                    tvwDARTTng.Nodes(CInt(destNodeMap(0))).Nodes(CInt(destNodeMap(1))).Nodes.Insert(InsertAtNode.Index, NodeToInsert)
                                Else
                                    If InsertAtNode.Index < InsertAtNode.Parent.Nodes.Count - 1 Then
                                        '--- Add 1 to the index to insert after selected node.
                                        tvwDARTTng.Nodes(CInt(destNodeMap(0))).Nodes(CInt(destNodeMap(1))).Nodes.Insert(InsertAtNode.Index + 1, NodeToInsert)
                                    Else
                                        '--- Node at end of list under current parrent.  Therefore, do an ADD. ---
                                        tvwDARTTng.Nodes(CInt(destNodeMap(0))).Nodes(CInt(destNodeMap(1))).Nodes.Add(NodeToInsert)
                                    End If
                                End If
                            End If
                        Case 2
                            If destItemType = "Folder" Then
                                If folderDropChoice = "in" Then
                                    NodeToInsert.TreeLevelID_Parent = InsertAtNode.TreeLevelID
                                    tvwDARTTng.Nodes(CInt(destNodeMap(0))).Nodes(CInt(destNodeMap(1))).Nodes(CInt(destNodeMap(2))).Nodes.Add(NodeToInsert)
                                Else
                                    tvwDARTTng.Nodes(CInt(destNodeMap(0))).Nodes(CInt(destNodeMap(1))).Nodes.Insert(InsertAtNode.Index, NodeToInsert)
                                End If
                            Else
                                If folderDropChoice = "before" Then
                                    tvwDARTTng.Nodes(CInt(destNodeMap(0))).Nodes(CInt(destNodeMap(1))).Nodes(CInt(destNodeMap(2))).Nodes.Insert(InsertAtNode.Index, NodeToInsert)
                                Else
                                    If InsertAtNode.Index < InsertAtNode.Parent.Nodes.Count - 1 Then
                                        '--- Add 1 to the index to insert after selected node.
                                        tvwDARTTng.Nodes(CInt(destNodeMap(0))).Nodes(CInt(destNodeMap(1))).Nodes(CInt(destNodeMap(2))).Nodes.Insert(InsertAtNode.Index + 1, NodeToInsert)
                                    Else
                                        '--- Node at end of list under current parrent.  Therefore, do an ADD. ---
                                        tvwDARTTng.Nodes(CInt(destNodeMap(0))).Nodes(CInt(destNodeMap(1))).Nodes(CInt(destNodeMap(2))).Nodes.Add(NodeToInsert)
                                    End If
                                End If
                            End If
                        Case 3
                            If destItemType = "Folder" Then
                                If folderDropChoice = "in" Then
                                    NodeToInsert.TreeLevelID_Parent = InsertAtNode.TreeLevelID
                                    tvwDARTTng.Nodes(CInt(destNodeMap(0))).Nodes(CInt(destNodeMap(1))).Nodes(CInt(destNodeMap(2))).Nodes(CInt(destNodeMap(3))).Nodes.Add(NodeToInsert)
                                Else
                                    tvwDARTTng.Nodes(CInt(destNodeMap(0))).Nodes(CInt(destNodeMap(1))).Nodes(CInt(destNodeMap(2))).Nodes.Insert(InsertAtNode.Index, NodeToInsert)
                                End If
                            Else
                                If folderDropChoice = "before" Then
                                    tvwDARTTng.Nodes(CInt(destNodeMap(0))).Nodes(CInt(destNodeMap(1))).Nodes(CInt(destNodeMap(2))).Nodes(CInt(destNodeMap(3))).Nodes.Insert(InsertAtNode.Index, NodeToInsert)
                                Else
                                    If InsertAtNode.Index < InsertAtNode.Parent.Nodes.Count - 1 Then
                                        '--- Add 1 to the index to insert after selected node.
                                        tvwDARTTng.Nodes(CInt(destNodeMap(0))).Nodes(CInt(destNodeMap(1))).Nodes(CInt(destNodeMap(2))).Nodes(CInt(destNodeMap(3))).Nodes.Insert(InsertAtNode.Index + 1, NodeToInsert)
                                    Else
                                        '--- Node at end of list under current parrent.  Therefore, do an ADD. ---
                                        tvwDARTTng.Nodes(CInt(destNodeMap(0))).Nodes(CInt(destNodeMap(1))).Nodes(CInt(destNodeMap(2))).Nodes(CInt(destNodeMap(3))).Nodes.Add(NodeToInsert)
                                    End If
                                End If
                            End If
                        Case 4
                            If destItemType = "Folder" Then
                                If folderDropChoice = "in" Then
                                    NodeToInsert.TreeLevelID_Parent = InsertAtNode.TreeLevelID
                                    tvwDARTTng.Nodes(CInt(destNodeMap(0))).Nodes(CInt(destNodeMap(1))).Nodes(CInt(destNodeMap(2))).Nodes(CInt(destNodeMap(3))).Nodes(CInt(destNodeMap(4))).Nodes.Add(NodeToInsert)
                                Else
                                    tvwDARTTng.Nodes(CInt(destNodeMap(0))).Nodes(CInt(destNodeMap(1))).Nodes(CInt(destNodeMap(2))).Nodes(CInt(destNodeMap(3))).Nodes.Insert(InsertAtNode.Index, NodeToInsert)
                                End If
                            Else
                                If folderDropChoice = "before" Then
                                    tvwDARTTng.Nodes(CInt(destNodeMap(0))).Nodes(CInt(destNodeMap(1))).Nodes(CInt(destNodeMap(2))).Nodes(CInt(destNodeMap(3))).Nodes(CInt(destNodeMap(4))).Nodes.Insert(InsertAtNode.Index, NodeToInsert)
                                Else
                                    If InsertAtNode.Index < InsertAtNode.Parent.Nodes.Count - 1 Then
                                        '--- Add 1 to the index to insert after selected node.
                                        tvwDARTTng.Nodes(CInt(destNodeMap(0))).Nodes(CInt(destNodeMap(1))).Nodes(CInt(destNodeMap(2))).Nodes(CInt(destNodeMap(3))).Nodes(CInt(destNodeMap(4))).Nodes.Insert(InsertAtNode.Index + 1, NodeToInsert)
                                    Else
                                        '--- Node at end of list under current parrent.  Therefore, do an ADD. ---
                                        tvwDARTTng.Nodes(CInt(destNodeMap(0))).Nodes(CInt(destNodeMap(1))).Nodes(CInt(destNodeMap(2))).Nodes(CInt(destNodeMap(3))).Nodes(CInt(destNodeMap(4))).Nodes.Add(NodeToInsert)
                                    End If
                                End If
                            End If
                        Case 5
                            If destItemType = "Folder" Then
                                If folderDropChoice = "in" Then
                                    NodeToInsert.TreeLevelID_Parent = InsertAtNode.TreeLevelID
                                    tvwDARTTng.Nodes(CInt(destNodeMap(0))).Nodes(CInt(destNodeMap(1))).Nodes(CInt(destNodeMap(2))).Nodes(CInt(destNodeMap(3))).Nodes(CInt(destNodeMap(4))).Nodes(CInt(destNodeMap(5))).Nodes.Add(NodeToInsert)
                                Else
                                    tvwDARTTng.Nodes(CInt(destNodeMap(0))).Nodes(CInt(destNodeMap(1))).Nodes(CInt(destNodeMap(2))).Nodes(CInt(destNodeMap(3))).Nodes(CInt(destNodeMap(4))).Nodes.Insert(InsertAtNode.Index, NodeToInsert)
                                End If
                            Else
                                If folderDropChoice = "before" Then
                                    tvwDARTTng.Nodes(CInt(destNodeMap(0))).Nodes(CInt(destNodeMap(1))).Nodes(CInt(destNodeMap(2))).Nodes(CInt(destNodeMap(3))).Nodes(CInt(destNodeMap(4))).Nodes(CInt(destNodeMap(5))).Nodes.Insert(InsertAtNode.Index, NodeToInsert)
                                Else
                                    If InsertAtNode.Index < InsertAtNode.Parent.Nodes.Count - 1 Then
                                        '--- Add 1 to the index to insert after selected node.
                                        tvwDARTTng.Nodes(CInt(destNodeMap(0))).Nodes(CInt(destNodeMap(1))).Nodes(CInt(destNodeMap(2))).Nodes(CInt(destNodeMap(3))).Nodes(CInt(destNodeMap(4))).Nodes(CInt(destNodeMap(5))).Nodes.Insert(InsertAtNode.Index + 1, NodeToInsert)
                                    Else
                                        '--- Node at end of list under current parrent.  Therefore, do an ADD. ---
                                        tvwDARTTng.Nodes(CInt(destNodeMap(0))).Nodes(CInt(destNodeMap(1))).Nodes(CInt(destNodeMap(2))).Nodes(CInt(destNodeMap(3))).Nodes(CInt(destNodeMap(4))).Nodes(CInt(destNodeMap(5))).Nodes.Add(NodeToInsert)
                                    End If
                                End If
                            End If
                    End Select

                    InsertingNewNode = True

                    tvwDARTTng.SelectedNode = NodeToInsert

                    InsertingNewNode = False
                    SetTreeDataState("dirty")

                    With DirectCast(tvwDARTTng.SelectedNode, DARTTreeNode)
                        If insertOptions(0) = "paste" Then
                            ''if we are in the New Reports structure we need to add the Base Report ID
                            .Text = "Copy of " + CopyNode.Text
                            .NodeID = .FullPath
                            .Name = .NodeID.Substring(InStrRev(.NodeID, "_"))
                            .ImageID = CopyNode.ImageID
                            .ImageIDExpanded = CopyNode.ImageIDExpanded
                            .ImageIndex = CopyNode.ImageIndex
                            .SelectedImageIndex = CopyNode.SelectedImageIndex
                            .NodeFont = CopyNode.NodeFont
                            .CommandString = CopyNode.CommandString
                            .HelpFile = CopyNode.HelpFile
                            .ScheduleEnabled = True

                            'LAshby 2/24/16
                            If destItemType = "Folder" Then
                                .TreeLevelID_Parent = InsertAtNode.TreeLevelID
                            Else
                                .TreeLevelID_Parent = InsertAtNode.TreeLevelID_Parent
                            End If

                            .Name = CopyNode.Name
                            .NodeName = CopyNode.NodeName
                            .PrimaryLocation = CopyNode.PrimaryLocation
                            .TreeLevelID = 0
                            .ItemTypeID = CopyNodeNewReportNum
                            .UseTabs = CopyNode.UseTabs
                            .ControlIDs = CopyNode.ControlIDs
                        Else
                            .ScheduleEnabled = True
                            If folderDropChoice <> "in" Then .TreeLevelID_Parent = InsertAtNode.TreeLevelID_Parent
                        End If
                    End With

                    SaveNode = tvwDARTTng.SelectedNode

                    rbReport.Checked = True
                    editmode = adding
                    HandleNodeClick(tvwDARTTng.SelectedNode)
                    If insertOptions(0) = "paste" Then
                        BuildControlsTab(CopyNode.TreeLevelID, True)
                        '--- clear grid fields ---
                        For Each dRow As DataRow In dsroot.Tables("ReportControls").Rows
                            UserEdits_CONTROL = True
                            dRow.Item("Report_ControlID") = 0
                            dRow.Item("ChildControlID") = 0
                            dRow.Item("ContainerID") = 0
                            dRow.Item("TreeLevelID") = 0
                            dRow.Item("Edited") = 1
                        Next
                    End If

                    HandleControls()

                    '--- Add a couple of things to the Properties Grid ---
                    SetReportPropertyValue("CreationDate", Now.ToString)
                    SetReportPropertyValue("ModifiedDate", Now.ToString)
                    SetReportPropertyValue("ModifiedBy_EmpNum", EmpNumber)
                    If insertOptions(0) = "paste" Then
                        SetReportPropertyValue("ItemTypeID", CopyNodeNewReportNum)
                    End If

                    CopyNode_NewInsert = True
                    BlinkControl(cboItemTypeSelect, 4, 100)
                End If
            Else
                EditNotAllowedMessage()
            End If
        Catch ex As Exception
        End Try

    End Sub

    Private Sub rb_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbReport.CheckedChanged, rbFolder.CheckedChanged
        If rbReport.Checked = True Then
            SetItemTypeSelectors("R")
            DirectCast(tvwDARTTng.SelectedNode, DARTTreeNode).ItemType = "R"
            BuildItemTypeSelector("Reports", "IdName", "ReportID")
        Else
            SetItemTypeSelectors("F")

            DirectCast(tvwDARTTng.SelectedNode, DARTTreeNode).ItemType = "F"
            BuildItemTypeSelector("Folders", "IdName", "FolderID")
        End If
        DisplayProperties(tvwDARTTng.SelectedNode)

    End Sub
    '--- Set primary key (up to 3) for given table ---
    Private Sub SetTablePrimaryKey(ByVal dTable As DataTable, ByVal PkColumn1 As DataColumn _
                                                            , Optional ByVal PkColumn2 As DataColumn = Nothing _
                                                            , Optional ByVal PkColumn3 As DataColumn = Nothing)
        Dim dc(2) As DataColumn
        dc(0) = IIf(PkColumn1 IsNot Nothing, PkColumn1, Nothing)
        dc(1) = IIf(PkColumn1 IsNot Nothing, PkColumn2, Nothing)
        dc(2) = IIf(PkColumn1 IsNot Nothing, PkColumn3, Nothing)
        dTable.PrimaryKey = dc
    End Sub

    Private Sub btnControlEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnControlEdit.Click
        EditControls(False)
    End Sub

    Private Sub tvwDARTTng_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles tvwDARTTng.DragDrop
        CheckEditingStatus()
        If EditingAllowed Then
            SetTreeDataState("dirty")

            Dim NewNode As DARTTreeNode
            Dim ParentSPID As Integer = 0
            Dim DestinationNode As DARTTreeNode
            Dim message As String = Nothing
            Dim tree As TreeView = CType(sender, TreeView)
            Dim pt As New Point(e.X, e.Y)
            pt = tree.PointToClient(pt)
            lblDragNode.Visible = False
            DestinationNode = tree.GetNodeAt(pt)
            NewNode = tree.SelectedNode

            DestinationNode.SpecialID = 0

            Dim Dest As Integer = DestinationNode.SpecialID
            If e.Effect = DragDropEffects.Move Then
                NewNode.Remove()
            End If
            If DestinationNode.NodeType = DDT_NodeType.Folder Then
                ParentSPID = Dest
            Else
                ParentSPID = CType(DestinationNode.Parent, DARTTreeNode).SpecialID
                If DestinationNode.PrevNode Is Nothing Then
                    PrevID = 0
                Else
                    PrevID = CType(DestinationNode.PrevNode, DARTTreeNode).SpecialID
                End If
            End If

            If DestinationNode.ItemType = "F" Then
                DestinationNode.Nodes.Add(NewNode)
                NewNode.TreeLevelID_Parent = DestinationNode.TreeLevelID
            Else
                DestinationNode.Parent.Nodes.Insert(DestinationNode.Index, NewNode)
                NewNode.TreeLevelID_Parent = DestinationNode.TreeLevelID_Parent
            End If
            '--- Need to set the parentId in case it's been moved to another folder. ---
            NewNode.EnsureVisible()
            tree.SelectedNode = DirectCast(NewNode, System.Windows.Forms.TreeNode)

            UserEdits_NodesMoved = True
            SaveCurrentTreeNode(NewNode)
        Else
            EraseSelectionRectangle()
            lblDragNode.Visible = False
            EditNotAllowedMessage()
        End If

    End Sub

    Public Sub EraseSelectionRectangle()
        Dim g As Graphics = tvwDARTTng.CreateGraphics()
        Dim erasePen As New Pen(Color.White)
        erasePen.DashStyle = Drawing2D.DashStyle.Dot
        g.DrawRectangle(erasePen, lastInsertRect)
    End Sub

    Private Sub tvwDARTtng_DragOver1(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) _
    Handles tvwDARTTng.DragOver
        Try
            Dim DraggedItemIsFolder = (Strings.Left(DraggedNode.ItemType, 6).ToUpper = "FOLDER")
            Dim tree As TreeView = CType(sender, TreeView)
            Dim g As Graphics = tvwDARTTng.CreateGraphics()
            Dim insertPen As New Pen(Color.Crimson)
            insertPen.DashStyle = Drawing2D.DashStyle.Dot

            'Erasing here insures we don't encounter problems if scroll dragging occurs
            EraseSelectionRectangle()

            If TypeOf sender Is TreeView Then

                Dim tv As TreeView = CType(sender, TreeView)
                Dim pt As Point = tv.PointToClient(New Point(e.X, e.Y))
                Dim delta As Integer = tv.Height - pt.Y

                'Insure scrolldown of treeview contents if necessary
                If delta < tv.Height / 2 And delta > 0 Then
                    Dim tn As TreeNode = tv.GetNodeAt(pt.X, pt.Y)

                End If

                'Insure scrollup of treeview contents if necessary
                If delta > tv.Height / 2 And delta < tv.Height Then
                    Dim tn As TreeNode = tv.GetNodeAt(pt.X, pt.Y)

                End If

                Dim position As New Point(e.X, e.Y)
                position = tv.PointToClient(position)
                Dim dropNode As DARTTreeNode = DirectCast(tv.GetNodeAt(position), DARTTreeNode)
                Dim DropNodeIsDraggedFolderChild As Boolean = (DraggedItemIsFolder And InStr(dropNode.FullPath, DraggedNode.FullPath) > 0)
                If Not dropNode Is Nothing Then
                    If dropNode.FullPath = DraggedNode.FullPath _
                    Or (dropNode.NodeType = DDT_NodeType.Folder _
                    And (dropNode.Text = "Favorites" Or dropNode.Text = "Scheduled Reports")) Then
                        lblDragNode.Visible = False
                        e.Effect = DragDropEffects.None
                    Else
                        Dim insertRect As Rectangle = dropNode.Bounds
                        If insertRect <> lastInsertRect Then
                            EraseSelectionRectangle()
                        End If
                        If Strings.Left(dropNode.ItemType, 6) <> "Folder" Then
                            insertRect.Size = New Size(insertRect.Width, 1)
                            g.DrawRectangle(insertPen, insertRect)
                            lastInsertRect = insertRect
                        Else
                            insertRect.Size = New Size(insertRect.Width, insertRect.Height)
                            g.DrawRectangle(insertPen, insertRect)
                            lastInsertRect = insertRect
                        End If
                        With lblDragNode
                            .ImageIndex = DraggedNode.SelectedImageIndex
                            .Text = Space(6) + DraggedNode.Text
                            Dim textWidth As Size = TextRenderer.MeasureText(Space(6) + DraggedNode.Text, lblDragNode.Font)
                            .Width = textWidth.Width + 5
                            .Height = 18
                            .Left = pt.X + 30
                            .Top = pt.Y + 5
                            .Visible = True
                        End With
                        e.Effect = DragDropEffects.Move
                    End If
                End If

            End If
        Catch ex As DataException
        End Try
    End Sub

    Private Sub tvwDARTTng_DragOver(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs)
        Dim gr As Graphics = tvwDARTTng.CreateGraphics
        Dim insertPen As New Pen(Color.Black)
        insertPen.DashStyle = Drawing2D.DashStyle.Dot

        EraseSelectionRectangle()

        If TypeOf sender Is TreeView Then

            Dim tv As TreeView = CType(sender, TreeView)
            Dim pt As Point = tv.PointToClient(New Point(e.X, e.Y))
            Dim delta As Integer = tv.Height - pt.Y

            'Insure scrolldown of treeview contents if necessary
            If delta < tv.Height / 2 And delta > 0 Then
                Dim tn As TreeNode = tv.GetNodeAt(pt.X, pt.Y)
                If Not (tn.NextVisibleNode Is Nothing) Then
                    tn.NextVisibleNode.EnsureVisible()
                End If
            End If

            'Insure scrollup of treeview contents if necessary
            If delta > tv.Height / 2 And delta < tv.Height Then
                Dim tn As TreeNode = tv.GetNodeAt(pt.X, pt.Y)
                If Not (tn.PrevVisibleNode Is Nothing) Then
                    tn.PrevVisibleNode.EnsureVisible()
                End If
            End If

            Dim position As New Point(e.X, e.Y)
            position = tv.PointToClient(position)
            Dim dropNode As DARTTreeNode = DirectCast(tv.GetNodeAt(position), DARTTreeNode)
            Dim DraggedNode As DARTTreeNode = tv.SelectedNode
            If dropNode.NodeType = DDT_NodeType.Folder _
            And (dropNode.Text = "Favorites" Or dropNode.Text = "Scheduled Reports") Then
                '--- Do not allow Drop in the above folders ---
                e.Effect = DragDropEffects.None
            Else
                If Not dropNode Is Nothing Then
                    If dropNode.FullPath = DraggedNode.FullPath Then
                        lblDragNode.Visible = False
                        e.Effect = DragDropEffects.None
                    Else
                        Dim insertRect As Rectangle = dropNode.Bounds
                        If insertRect <> lastInsertRect Then
                            EraseSelectionRectangle()
                        End If
                        If dropNode.NodeType <> DDT_NodeType.Folder Then
                            insertRect.Size = New Size(insertRect.Width, 1)
                            gr.DrawRectangle(insertPen, insertRect)
                            lastInsertRect = insertRect
                        Else
                            insertRect.Size = New Size(insertRect.Width, insertRect.Height)
                            gr.DrawRectangle(insertPen, insertRect)
                            lastInsertRect = insertRect
                        End If
                        With lblDragNode
                            .ImageIndex = DraggedNode.SelectedImageIndex
                            .Text = Space(6) + DraggedNode.Text
                            Dim textWidth As Size = TextRenderer.MeasureText(Space(6) + DraggedNode.Text, lblDragNode.Font)
                            .Width = textWidth.Width + 5
                            .Height = 18
                            .Left = pt.X + tvwDARTTng.Left + 10
                            .Top = pt.Y + 5
                            .Visible = True
                        End With
                        e.Effect = DragDropEffects.Move
                    End If
                End If
            End If
        End If
    End Sub

    Public Sub tvwDARTTng_ItemDrag(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ItemDragEventArgs) _
    Handles tvwDARTTng.ItemDrag
        'Set the drag node and initiate the DragDrop 
        tvwDARTTng.DoDragDrop(e.Item, DragDropEffects.Move)
    End Sub

    Private Sub BlinkControl(ByVal ctrl As Object, ByVal NumBlinks As Integer, Optional ByVal interval As Integer = 200)
        If tmrControlBlink.Enabled = False Then
            ControlBlinkObj = ctrl
            ControlBlinkMax = NumBlinks * 2
            ControlBlinkCounter = 0
            ControlBlinkOrigBackColor = ControlBlinkObj.BackColor
            tmrControlBlink.Interval = interval
            tmrControlBlink.Enabled = True
        End If
    End Sub

    Private Sub tmrControlBlink_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrControlBlink.Tick
        ControlBlinkCounter += 1
        If ControlBlinkState = False Then
            ControlBlinkState = True
            ControlBlinkObj.BackColor = ControlBlinkTempBackColor
        Else
            ControlBlinkState = False
            ControlBlinkObj.BackColor = ControlBlinkOrigBackColor
        End If

        If ControlBlinkCounter >= ControlBlinkMax Then
            tmrControlBlink.Enabled = False
            ControlBlinkState = True
            ControlBlinkObj.visible = True
            ControlBlinkObj.BackColor = ControlBlinkOrigBackColor
        End If
    End Sub

    Private Sub tvwDARTTng_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles tvwDARTTng.MouseDown
        DraggedNode = DirectCast(tvwDARTTng.GetNodeAt(e.X, e.Y), DARTTreeNode)
        tvwDARTTng.SelectedNode = DraggedNode
    End Sub

    Private Sub btnMoveUp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMoveUp.Click
        CheckEditingStatus()
        If EditingAllowed Then
            SetTreeDataState("dirty")
            UserEdits_NodesMoved = True
            MoveNode("Up")
            SaveCurrentTreeNode(tvwDARTTng.SelectedNode)
            SetTreeDataState("")
            UserEdits_NodesMoved = False
        Else
            EditNotAllowedMessage()
        End If
    End Sub

    Private Sub btnMoveDown_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMoveDown.Click
        CheckEditingStatus()
        If EditingAllowed Then
            SetTreeDataState("dirty")
            UserEdits_NodesMoved = True
            MoveNode("Down")
            SaveCurrentTreeNode(tvwDARTTng.SelectedNode)
            SetTreeDataState("")
            UserEdits_NodesMoved = False
        Else
            EditNotAllowedMessage()
        End If
    End Sub
    Private Sub MoveNode(ByVal direction As String)
        Try
            Dim thisNode As DARTTreeNode = tvwDARTTng.SelectedNode
            Dim thisNodeParent As DARTTreeNode = tvwDARTTng.SelectedNode.Parent
            Dim nodeMap() As String = Split(GetNodeMapping(thisNode.FullPath), ";")

            Dim offset As Integer
            Select Case direction.ToUpper
                Case "UP"
                    offset = -1
                Case "DOWN"
                    offset = 1
            End Select
            If tvwDARTTng.SelectedNode.Parent.Level <> Nothing Then
                Dim parentNodeLevel As Integer = tvwDARTTng.SelectedNode.Parent.Level
            End If

            tvwDARTTng.SelectedNode.Remove()
            thisNodeParent.Nodes.Insert(thisNode.Index + offset, thisNode)
            tvwDARTTng.SelectedNode = thisNode
            tvwDARTTng.SelectedNode.EnsureVisible()
            tvwDARTTng.Focus()
            HandleNodeClick(tvwDARTTng.SelectedNode)
            HandleControls()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Try
            Dim SqlStr As String = "dbo.sToolbox_UpdateTreeLevels_Delete " + DirectCast(tvwDARTTng.SelectedNode, DARTTreeNode).TreeLevelID.ToString + ", " + EmpNumber.ToString
            Dim result As String
            Dim tmpCurrNode As DARTTreeNode = DirectCast(tvwDARTTng.SelectedNode, DARTTreeNode)
            Dim tmpPrevNode As DARTTreeNode = tmpCurrNode.PrevNode
            Dim tmpNextNode As DARTTreeNode = tmpCurrNode.NextNode
            Dim tmpParentNode As DARTTreeNode = tmpCurrNode.Parent
            Dim SelectedNodeHasChildren As Boolean = IIf(tmpCurrNode.Nodes.Count > 0, True, False)
            CheckEditingStatus()
            If EditingAllowed Then
                If SelectedNodeHasChildren Then
                    RichMessageBoxShow("Current node has children and cannot be deleted.", "Delete Not Allowed", Color.Azure, Color.Azure, Color.Black, New Size(400, 100), 12, BorderStyle.None, RichMessageBoxIcon.Exclamation, RichMessageBoxButtons.OK, RichMessageboxDefaultButton.Button1, ScrollBars.Vertical, RichMessageboxFadeStyle.FadeOutOnly)
                    Exit Sub
                End If
                If RichMessageBoxShow("Delete Node < [ID=" + tmpCurrNode.TreeLevelID.ToString + "]  " + tvwDARTTng.SelectedNode.Text + ">  ", _
                                    "DELETE NODE", Color.Azure, Color.Azure, Color.Black, New Size(400, 100), 12, BorderStyle.None, _
                                    RichMessageBoxIcon._Stop, RichMessageBoxButtons.OKCancel, RichMessageboxDefaultButton.Button2, _
                                    ScrollBars.Vertical, RichMessageboxFadeStyle.FadeOutOnly) _
                = Windows.Forms.DialogResult.OK Then

                    result = ExecSqlScalar(SqlStr, connStr)

                    SetTreeDataState("")
                    editmode = notEditing
                    BuildTreeView()
                    If tmpPrevNode IsNot Nothing Then
                        Call GetNodeByKey(tvwDARTTng, "TreeLevelID=" + DirectCast(tmpPrevNode, DARTTreeNode).TreeLevelID.ToString, True)
                        HandleNodeClick(DirectCast(tmpPrevNode, DARTTreeNode))
                    ElseIf tmpNextNode IsNot Nothing Then
                        Call GetNodeByKey(tvwDARTTng, "TreeLevelID=" + DirectCast(tmpNextNode, DARTTreeNode).TreeLevelID.ToString, True)
                        HandleNodeClick(DirectCast(tmpNextNode, DARTTreeNode))
                    Else
                        Call GetNodeByKey(tvwDARTTng, "TreeLevelID=" + DirectCast(tmpParentNode, DARTTreeNode).TreeLevelID.ToString, True)
                        HandleNodeClick(DirectCast(tmpParentNode, DARTTreeNode))
                    End If
                    HandleControls()
                Else
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub dgvTreeProperties_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvTreeProperties.CellEndEdit
        UserEdits_TREE = True
    End Sub

    Private Sub AnyCheckChange_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles chkActive.CheckedChanged, chkSchedulingEnabled.CheckedChanged, chkHelpButton.CheckedChanged

        Select Case sender.name.ToString
            Case "chkSchedulingEnabled"
                If chkSchedulingEnabled.Checked <> DirectCast(tvwDARTTng.SelectedNode, DARTTreeNode).ScheduleEnabled Then
                    UserEdits_TREE = True
                End If
            Case "chkHelpButton"
                If chkHelpButton.Checked <> DirectCast(tvwDARTTng.SelectedNode, DARTTreeNode).HelpEnabled Then
                    UserEdits_TREE = True
                End If
            Case "chkActive"
                If chkActive.Checked <> DirectCast(tvwDARTTng.SelectedNode, DARTTreeNode).IsActive Then
                    UserEdits_TREE = True
                End If
        End Select

    End Sub

    Private Sub chkActive_CheckStateChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _
    chkActive.CheckStateChanged, chkSchedulingEnabled.CheckStateChanged, chkHelpButton.CheckStateChanged
    End Sub

    Private Sub CopyToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CopyToolStripMenuItem.Click
        btnCopyItem_Click(Nothing, Nothing)
    End Sub

    Private Sub EditToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditToolStripMenuItem.Click
        btnEdit_Click(Nothing, Nothing)
    End Sub

    Private Sub DeleteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteToolStripMenuItem.Click
        btnDelete_Click(Nothing, Nothing)
    End Sub

    Private Sub MoveUpToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MoveUpToolStripMenuItem.Click
        btnMoveUp_Click(Nothing, Nothing)
    End Sub

    Private Sub MoveDownToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MoveDownToolStripMenuItem.Click
        btnMoveDown_Click(Nothing, Nothing)
    End Sub

    Private Sub InsertToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InsertToolStripMenuItem.Click
        btnInsert_Click(Nothing, Nothing)
    End Sub
#Region "Add Controls"

#End Region

    Private Sub myAddReportControls()
        Dim GroupedControlExists As Boolean = False
        Dim currTabPage As TabPage = Nothing

        For Each dgvr As DataGridViewRow In dgvReportControls.Rows
            Dim TabIndex As Integer = dgvr.Cells("TabIndex").Value
            Dim TabName As String = dgvr.Cells("TabName").Value.ToString
            Dim ControlName As String = dgvr.Cells("ControlName").Value.ToString

            Dim obj As Object = Nothing
            Select Case ControlName
                Case "DDT_DateRange"
                    obj = New DDT_DateRange
                    obj.ControlTitle = dgvr.Cells("ControlTitle").Value
                    obj.dtpDateEnd.Value = Today
                    obj.dtpDateStart.Value = Today
                Case "DDT_Date_Time"
                    obj = New DDT_Date_Time
                    obj.ControlTitle = dgvr.Cells("ControlTitle").Value
                    obj.dtpDate.Value = Today
                Case "DDT_SingleDate"
                    obj = New DDT_SingleDate
                    obj.ControlTitle = dgvr.Cells("ControlTitle").Value
                    obj.dtpDateSingle.Value = Today
                    obj.ShouldLabelBeOn = False
                Case "DDT_ListBox"
                    obj = New DDT_ListBox
                    obj.ControlTitle = dgvr.Cells("ControlTitle").Value
                Case "DDT_ComboBox"
                    obj = New DDT_ComboBox
                    obj.SetSQLCommandSettings()
                    obj.SQLCommandString = ""
                    obj.ControlTitle = dgvr.Cells("ControlTitle").Value
                    If dgvr.Cells("ControlTitle").Value = "Year" Then
                        obj.cbo.Items.Add(Now.Year.ToString)
                        obj.cbo.Items.Add((Now.Year - 1).ToString)
                        obj.cbo.Items.Add((Now.Year - 2).ToString)
                    Else
                        obj.cbo.Items.Add(" ")
                    End If
                Case "DDT_NumericTextBox"
                    obj = New DDT_NumericTextBox
                    obj.Text = ControlName

                Case "DDT_Label_TextBox_Label"
                    obj = New DDT_Label_TextBox_Label(True, True _
                    , "Label1Text :" _
                    , "Label2Text :", "??" _
                    , 25 _
                    , dgvr.Cells("TextboxLocationX").Value _
                    , dgvr.Cells("LocationX").Value _
                    , dgvr.Cells("LocationY").Value _
                    , dgvr.Cells("Width").Value _
                    , dgvr.Cells("Height").Value _
                    , "", dgvr.Cells("ControlTitle").Value.ToString, 0)
                Case "DDT_GroupedControls"
                    '--- sqlConnection is passed to allow the control to initialize successfully.  It used to allow 'Nothing' passed but not anymore.  So, only it's passed here to allow it to init correctly. ---
                    obj = New DDT_GroupedControls(dgvr.Cells("Report_ControlID").Value, dgvr.Cells("ReportID").Value, _
                    dgvr.Cells("ControlTitle").Value, sqlConnection, ControlName, dgvr.Cells("ControlsID").Value, _
                     dgvr.Cells("Height").Value, dgvr.Cells("Width").Value, dgvr.Cells("LocationX").Value, dgvr.Cells("LocationY").Value, False, "")
                    GroupedControlExists = True
                Case "DDT_CheckBox"
                    obj = New DDT_CheckBox
                    obj.Text = ControlName
                    obj.CheckBox1.Text = dgvr.Cells("ControlTitle").Value
                Case "Label"
                    obj = New Label
                    obj.Text = "Label Label Label Label Label Label Label Label Label Label Label Label Label Label Label Label"
                Case "DDT_Button"
                    obj = New DDT_Button
                    obj.Text = ControlName
                Case "DDT_TextBox"
                    obj = New DDT_TextBox
                    obj.Text = ControlName
                    obj.ControlTitle = dgvr.Cells("ControlTitle").Value
                Case "DDT_CheckBox_TextBox"
                    obj = New DDT_CheckBox_TextBox
                    obj.Text = ControlName
                    obj.ControlTitle = dgvr.Cells("ControlTitle").Value
                Case "DDT_CheckBox"
                    obj = New DDT_CheckBox
                    obj.Text = ControlName
                    obj.ControlTitle = dgvr.Cells("ControlTitle").Value
                Case "DDT_CheckBox_TextBox_Label"
                    obj = New DDT_CheckBox_TextBox_Label
                    obj.Text = ControlName
                    obj.ControlTitle = dgvr.Cells("ControlTitle").Value
                Case "DDT_ListBox"
                    obj = New DDT_ListBox
                    obj.Text = ControlName
                    obj.ControlTitle = dgvr.Cells("ControlTitle").Value
                Case "DDT_RadioButton"
                Case Else
                    RichMessageBoxShow("Unrecognized control name (" + ControlName + ")", "Unrecognized control name", Color.Azure, Color.Azure, Color.Black, New Size(500, 100), 12, BorderStyle.None, RichMessageBoxIcon._Error, RichMessageBoxButtons.OK, RichMessageboxDefaultButton.Button1, ScrollBars.Horizontal)
            End Select

            If obj IsNot Nothing Then

                Dim ContainerID As Integer = IIf(dgvr.Cells("ContainerID").Value.ToString = "", 0, dgvr.Cells("ContainerID").Value)
                obj.name = dgvr.Cells("Report_ControlID").Value.ToString
                obj.Height = dgvr.Cells("Height").Value
                obj.Width = dgvr.Cells("Width").Value
                obj.BringToFront()
                obj.Top = dgvr.Cells("LocationY").Value
                obj.Left = dgvr.Cells("LocationX").Value
                Try
                    With tabControlForReportParams

                        If TabName = "" Then
                            currTabPage = .TabPages(0)
                            If ContainerID > 0 Then
                                .TabPages(0).Controls(ContainerID.ToString).Controls.Add(obj)
                            Else
                                .TabPages(0).Controls.Add(obj)
                            End If
                        Else
                            currTabPage = .TabPages(TabName)
                            If ContainerID > 0 Then
                                .TabPages(TabName).Controls(ContainerID.ToString).Controls.Add(obj)
                            Else
                                .TabPages(TabName).Controls.Add(obj)
                            End If
                        End If
                    End With
                Catch ex As Exception
                    MsgBox("ERROR:" + ex.Message)
                End Try
                obj.bringtofront()
            End If
        Next
    End Sub

    Private Sub DisplayControls()
        AddTabs()
        myAddReportControls()
    End Sub

    Private Sub btnShowControls_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShowControls.Click
        DisplayControls()
    End Sub

    Private Sub AddTabs()
        Dim currTabname As String = ".....NoCurrentTabSet....."
        Dim currTabPage As TabPage

        tabControlForReportParams.TabPages.Clear()
        For Each dr As DataGridViewRow In dgvReportControls.Rows
            If IIf(IsDBNull(dr.Cells("Tabname").Value), "", dr.Cells("Tabname").Value.ToString) <> currTabname.ToString Then
                '--- CREATE A TAB ---

                tabControlForReportParams.TabPages.Add(dr.Cells("Tabname").Value.ToString, dr.Cells("Tabname").Value.ToString)

                '--- Get newly created tab page ---
                If dr.Cells("Tabname").Value.ToString = "" Then
                    tabControlForReportParams.TabPages(0).AutoScroll = True
                    currTabPage = tabControlForReportParams.TabPages(0)
                Else
                    tabControlForReportParams.TabPages(dr.Cells("Tabname").Value.ToString).AutoScroll = True
                    currTabPage = tabControlForReportParams.TabPages(dr.Cells("Tabname").Value.ToString)
                End If

                '--- Change some settings ---
                currTabPage.AllowDrop = True

                '--- Draw message label and line showing default Right Margin for DART ---
                Dim lblMessage As New Label
                lblMessage.Parent = currTabPage
                lblMessage.Text = "Use as Right Margin for placing controls ->"
                'lblMessage.Font = New Font("Arial", 6, FontStyle.Bold)
                lblMessage.Font = New Font("Segoe UI", 6, FontStyle.Bold)
                lblMessage.AutoSize = True
                lblMessage.Left = 605 - lblMessage.Width
                lblMessage.Top = 1
                lblMessage.ForeColor = Color.Red
                lblMessage.BringToFront()

                If chkDisplayGridLines.Checked = True Then
                    Dim xUnits As Integer = IIf(cboGridLines.SelectedItem Is Nothing, 100, cboGridLines.SelectedItem)
                    Dim lblArryV(600 / xUnits) As Label
                    Dim xValue As Integer = 0
                    Dim GridColor As Color = cboColor_AlignControls.SelectedItem
                    Dim i As Integer
                    For i = 0 To UBound(lblArryV) - 1
                        xValue = xUnits * (i + 1)
                        lblArryV(i) = New Label
                        lblArryV(i).Text = (xValue).ToString
                        lblArryV(i).AutoSize = True
                        lblArryV(i).Left = xValue
                        lblArryV(i).Top = 15
                        lblArryV(i).Parent = currTabPage
                        lblArryV(i).ForeColor = GridColor
                        lblArryV(i).BringToFront()
                        lblArryV(i).Left -= lblArryV(i).Text.Length / 2 * lblArryV(i).Font.Size
                    Next

                    Dim yUnits As Integer = IIf(cboGridLines.SelectedItem Is Nothing, 100, cboGridLines.SelectedItem)
                    Dim lblArryH(600 / yUnits) As Label
                    Dim yValue As Integer = 0
                    For i = 0 To UBound(lblArryH) - 1
                        yValue = yUnits * (i + 1)
                        lblArryH(i) = New Label
                        lblArryH(i).Text = (yValue).ToString
                        lblArryH(i).AutoSize = True
                        lblArryH(i).Left = 15
                        lblArryH(i).Top = yValue
                        lblArryH(i).Parent = currTabPage
                        lblArryH(i).ForeColor = GridColor
                        lblArryH(i).BringToFront()
                        lblArryH(i).Top -= lblArryH(i).Font.Height / 2
                    Next
                End If
            End If
            currTabname = dr.Cells("Tabname").Value.ToString
        Next
    End Sub

    Private Sub dgvReportControls_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvReportControls.CellDoubleClick
        If editmode <> notEditing Then
            EditControls(False)
        End If
    End Sub

    Private Sub dgvReportControls_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvReportControls.SelectionChanged
        HandleControls()
    End Sub

    Private Sub cmsiEditToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmsiEditToolStripMenuItem.Click
        EditControls(False)
    End Sub

    Private Sub cmsiAddNewToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmsiAddNewToolStripMenuItem.Click
        EditControls(True)
    End Sub

    Private Sub cmsiDeleteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmsiDeleteToolStripMenuItem.Click
        btnControlDelete_Click(Nothing, Nothing)
    End Sub

    Private Sub chkShowControlGrid_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkDisplayGridLines.CheckedChanged
        If chkDisplayGridLines.Checked = True Then
            cboColor_AlignControls.Visible = True
            lblUnits_AlignControls.Visible = True
            cboGridLines.Visible = True
            BlinkControl(btnShowControls, 5)
        Else
            cboColor_AlignControls.Visible = False
            lblUnits_AlignControls.Visible = False
            cboGridLines.Visible = False
        End If
    End Sub

    Private Sub BlinkEditText(ByVal Editing As Boolean)
        If Editing Then
            ToolStripLblEditing.Visible = True
            tmrBlinkEdit.Enabled = True
        Else
            tmrBlinkEdit.Enabled = False
            ToolStripLblEditing.Visible = False
        End If
    End Sub

    Private Sub tmrBlinkEdit_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrBlinkEdit.Tick
        If ToolStripLblEditing.ForeColor = Color.Red Then
            ToolStripLblEditing.ForeColor = Color.White
        Else
            ToolStripLblEditing.ForeColor = Color.Red
        End If
    End Sub

    Private Sub btnCopyToProduction_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCopyToProduction.Click
        frmCopyDARTtngTree.ShowDialog()
    End Sub

    Private Sub cboItemTypeSelect_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles cboItemTypeSelect.SelectedValueChanged
        If cboItemTypeSelect.SelectedValue IsNot Nothing Then
            If EditingAllowed = True And editmode = adding And cboItemTypeSelect.SelectedValue.ToString <> "System.Data.DataRowView" Then
                If DirectCast(tvwDARTTng.SelectedNode, DARTTreeNode).ItemType = "F" Then
                    Dim dr As DataRow = dsroot.Tables("Folders").Rows.Find(cboItemTypeSelect.SelectedValue)
                    If dr IsNot Nothing Then
                        SetReportPropertyValue("NodeName", dr.Item("FolderName").ToString)
                        SetReportPropertyValue("ItemTypeID", dr.Item("FolderID").ToString)

                        For r As Integer = 0 To dgvImages.Rows.Count - 1
                            If dgvImages.Rows(r).Cells("ImageID").Value = dr.Item("ImageIDExpandedIndex") - 1 Then
                                dgvImages.Rows(r).Selected = True
                                dgvImages.FirstDisplayedScrollingRowIndex = r
                                Exit For
                            End If
                        Next
                        For r As Integer = 0 To dgvImagesFolderClosed.Rows.Count - 1
                            If dgvImagesFolderClosed.Rows(r).Cells("ImageIDClosed").Value = dr.Item("ImageIDIndex") - 1 Then
                                dgvImagesFolderClosed.Rows(r).Selected = True
                                dgvImagesFolderClosed.FirstDisplayedScrollingRowIndex = r
                                Exit For
                            End If
                        Next
                    End If
                Else
                    Dim dr As DataRow = dsroot.Tables("Reports").Rows.Find(cboItemTypeSelect.SelectedValue)
                    If dr IsNot Nothing Then
                        If IsDBNull(dr.Item("TreeLevelID")) Then
                            SetReportPropertyValue("NodeName", dr.Item("ReportName").ToString)
                            'murts
                            SetReportPropertyValue("ItemTypeID", dr.Item("ReportID").ToString)
                            SetReportPropertyValue("ReportNumber", dr.Item("ReportNumber").ToString)
                            SetReportPropertyValue("CommandString", dr.Item("SQLCommand").ToString)

                            For r As Integer = 0 To dgvImages.Rows.Count - 1
                                If dgvImages.Rows(r).Cells("ImageID").Value = dr.Item("ImageIDIndex") - 1 Then
                                    dgvImages.Rows(r).Selected = True
                                    dgvImages.FirstDisplayedScrollingRowIndex = r
                                    Exit For
                                End If
                            Next
                        End If
                    End If
                End If
            End If

            If editmode <> notEditing And cboItemTypeSelect.SelectedValue IsNot Nothing And cboItemTypeSelect.SelectedValue.ToString <> "System.Data.DataRowView" Then
                '--- If there are existing controls, must have been an insert from copy.  Use controls but reset ReportID" ---
                If dgvReportControls.Rows.Count > 0 Then
                    '--- clear grid fields ---
                    For Each dRow As DataRow In dsroot.Tables("ReportControls").Rows
                        dRow.Item("ReportID") = cboItemTypeSelect.SelectedValue
                    Next
                End If
            End If
        End If
    End Sub
    Private Sub cboItemTypeSelect_SelectionChangeCommitted(sender As Object, e As System.EventArgs) Handles cboItemTypeSelect.SelectionChangeCommitted
        If cboItemTypeSelect.SelectedValue IsNot Nothing Then
            If EditingAllowed = True And editmode = adding And cboItemTypeSelect.SelectedValue.ToString <> "System.Data.DataRowView" Then
                'mburts
                If DirectCast(tvwDARTTng.SelectedNode, DARTTreeNode).ItemType = "F" Then
                    Dim dr As DataRow = dsroot.Tables("Folders").Rows.Find(cboItemTypeSelect.SelectedValue)
                    If dr IsNot Nothing Then
                        SetReportPropertyValue("NodeName", dr.Item("FolderName").ToString)
                        SetReportPropertyValue("ItemTypeID", dr.Item("FolderID").ToString)

                        For r As Integer = 0 To dgvImages.Rows.Count - 1
                            If dgvImages.Rows(r).Cells("ImageID").Value = dr.Item("ImageIDExpandedIndex") - 1 Then
                                dgvImages.Rows(r).Selected = True
                                dgvImages.FirstDisplayedScrollingRowIndex = r
                                Exit For
                            End If
                        Next
                        For r As Integer = 0 To dgvImagesFolderClosed.Rows.Count - 1
                            If dgvImagesFolderClosed.Rows(r).Cells("ImageIDClosed").Value = dr.Item("ImageIDIndex") - 1 Then
                                dgvImagesFolderClosed.Rows(r).Selected = True
                                dgvImagesFolderClosed.FirstDisplayedScrollingRowIndex = r
                                Exit For
                            End If
                        Next
                    End If
                Else
                    Dim dr As DataRow = dsroot.Tables("Reports").Rows.Find(cboItemTypeSelect.SelectedValue)
                    If dr IsNot Nothing Then
                        If IsDBNull(dr.Item("TreeLevelID")) Then

                            SetReportPropertyValue("NodeName", dr.Item("ReportName").ToString)
                            'murts
                            SetReportPropertyValue("ItemTypeID", dr.Item("ReportID").ToString)
                            SetReportPropertyValue("ReportNumber", dr.Item("ReportNumber").ToString)
                            SetReportPropertyValue("CommandString", dr.Item("SQLCommand").ToString)

                            For r As Integer = 0 To dgvImages.Rows.Count - 1
                                If dgvImages.Rows(r).Cells("ImageID").Value = dr.Item("ImageIDIndex") - 1 Then
                                    dgvImages.Rows(r).Selected = True
                                    dgvImages.FirstDisplayedScrollingRowIndex = r
                                    Exit For
                                End If
                            Next
                        End If
                    End If
                End If
            End If

            If editmode <> notEditing And cboItemTypeSelect.SelectedValue IsNot Nothing And cboItemTypeSelect.SelectedValue.ToString <> "System.Data.DataRowView" Then
                '--- If there are existing controls, must have been an insert from copy.  Use controls but reset ReportID" ---
                If dgvReportControls.Rows.Count > 0 Then
                    '--- clear grid fields ---
                    For Each dRow As DataRow In dsroot.Tables("ReportControls").Rows
                        dRow.Item("ReportID") = cboItemTypeSelect.SelectedValue
                    Next
                End If
            End If
        End If
    End Sub

    ''' <summary>
    ''' Used to return the forecolor of a tree item or list item for developers depending on the ReportStatus.
    ''' </summary>
    ''' <param name="ReportStatus">Status of Report (DDT_ReportStatus)</param>
    ''' <param name="IsDeveloper">Boolean variable if IsDeveloper.</param>
    ''' <returns>Color</returns>
    ''' <remarks>by Joey Cruz</remarks>
    Public Function ReturnForeColor(ByVal ReportStatus As DDT_ReportStatus, ByVal IsDeveloper As Boolean) As Color
        Select Case ReportStatus
            Case DDT_ReportStatus.Active
                ReturnForeColor = Color.Black
            Case Else
                ReturnForeColor = Color.Red
        End Select
    End Function

    Public Function GetTreeNodeDetails(ByVal rowItem As DataRow) As DARTTreeNode
        CallFromType = "Function"
        CallFrom = "GetTreeNodeDetails"

        Try
            Dim myNode As New DARTTreeNode
            With myNode
                .CommandString = IIf(IsDBNull(rowItem.Item("CommandString")), "", rowItem.Item("CommandString"))
                .NodeType = IIf(rowItem.Item("ItemType") = "R", DDT_NodeType.Report, DDT_NodeType.Folder)
                .ItemType = rowItem.Item("ItemType")
                .NodeName = rowItem.Item("NodeName")
                .NodeID = rowItem.Item("NodeID")
                .NodeType = IIf(LSet(.NodeID, 18) = "Scheduled Reports_", DDT_NodeType.Schedule, .NodeType)
                .TreeLevelID = rowItem.Item("TreeLevelID")
                .TreeLevelID_Parent = rowItem.Item("TreeLevelID_Parent")
                .ReportID = rowItem.Item("ReportID")
                .Text = rowItem.Item("ReportName")
                .ReportName = rowItem.Item("ReportName")
                .ReportFullName = .ReportName
                .ReportTitle = rowItem.Item("ReportTitle")
                .ReportFormatID = rowItem.Item("ReportFormatID")
                .IsActive = rowItem.Item("IsActive")
                .HelpFile = IIf(IsDBNull(rowItem.Item("HelpFile")), "", rowItem.Item("HelpFile"))
                .IsStatic = rowItem.Item("IsStatic")
                .UseTabs = rowItem.Item("UseTabs")
                .ImageIndex = rowItem.Item("ImageID") - 1
                .SelectedImageIndex = rowItem.Item("ImageIDExpanded") - 1
                .ImageID = .ImageIndex
                .ImageIDExpanded = .SelectedImageIndex
                .ReportFormat = rowItem.Item("ReportFormat")
                .ReportFileName = rowItem.Item("ReportFileName")
                .ReportNumber = IIf(IsDBNull(rowItem("ReportNumber")), "", rowItem("ReportNumber"))
                .ReportDescription = IIf(IsDBNull(rowItem("ReportDescription")), "", rowItem("ReportDescription"))
                .PrimaryLocation = IIf(IsDBNull(rowItem("DirectoryPrimary")), "", rowItem("DirectoryPrimary"))
                .SpecialID = rowItem("SpecialID")
                .TabIndex = rowItem("TabIndex")
                HelpFile = .HelpFile
                If rowItem("IsActive") = True Then
                    .ReportStatus = DDT_ReportStatus.Active
                Else
                    .ReportStatus = DDT_ReportStatus.Inactive
                End If

                'Extended for Tree Editing
                .HelpEnabled = IIf(IsDBNull(rowItem.Item("HelpEnabled")), False, rowItem.Item("HelpEnabled"))
                .ScheduleEnabled = IIf(IsDBNull(rowItem.Item("ScheduleEnabled")), False, rowItem.Item("ScheduleEnabled"))
                .ItemTypeID = IIf(IsDBNull(rowItem.Item("ItemTypeID")), 0, rowItem.Item("ItemTypeID"))
                .CreationDate = IIf(IsDBNull(rowItem.Item("CreationDate")), Nothing, rowItem.Item("CreationDate"))
                .ModifiedDate = IIf(IsDBNull(rowItem.Item("ModifiedDate")), Nothing, rowItem.Item("ModifiedDate"))
                .ModifiedBy_EmpNum = IIf(IsDBNull(rowItem.Item("ModifiedBy_EmpNum")), "", rowItem.Item("ModifiedBy_EmpNum"))
                .ImageType = IIf(IsDBNull(rowItem.Item("ImageType")), "", rowItem.Item("ImageType"))
                .SortOrder = IIf(IsDBNull(rowItem.Item("SortOrder")), 0, rowItem.Item("SortOrder"))
            End With
            Return myNode
        Catch ex As Exception
            EmailErrorAlert(gDatabaseConnection, ex.Message, gUserID, gApplicationName, gApplicationVersion, gUserID, CallFromType, CallFrom, gWorkstationID, gOsName)
            Return Nothing
        End Try
    End Function

    Public Sub AddNodes(ByVal ParentNode As TreeNode, ByVal iParentID As Integer)
        Dim drdata As DataRow() = dsroot.Tables("DARTTree").Select("TreeLevelID_Parent=" & iParentID)
        Dim r As DataRow
        CallFromType = "Sub"
        CallFrom = "AddNodes"

        Try
            If Not drdata.Length <= 0 Then

                For Each r In drdata
                    Dim iNodeID As Integer = r("TreeLevelID")
                    Dim myNode As DARTTreeNode = GetTreeNodeDetails(r)

                    With myNode
                        .ImageIndex = r("ImageID") - 1
                        .Text = r("NodeName")
                        .Name = r("NodeID")
                        .SelectedImageIndex = r("ImageIDExpanded") - 1
                        .ForeColor = ReturnForeColor(.ReportStatus, True)
                    End With
                    ParentNode.Nodes.Add(myNode)
                    AddNodes(myNode, iNodeID)
                Next
            End If
        Catch ex As Exception
            EmailErrorAlert(gDatabaseConnection, ex.Message, gUserID, gApplicationName, gApplicationVersion, gUserID, CallFromType, CallFrom, gWorkstationID, gOsName)
        End Try
        drdata = Nothing
    End Sub

    Public Sub AddNodes(ByVal ParentNode As TreeNode, ByVal iParentFolderID As Integer, ByVal stype As String)
        'This procedure adds the nodes to the treeview passed by reference
        Dim drData As DataRow() = dsroot.Tables("Favorites").Select("TreeLevelID_Parent=" & iParentFolderID)
        Dim r As DataRow
        Dim saveParentID As Integer = 0
        CallFromType = "Sub"
        CallFrom = "AddNodes"

        Try
            If Not drData.Length <= 0 Then
                For Each r In drData
                    Dim iNodeID As Integer = r("TreeLevelID")
                    Dim myNode As DARTTreeNode = GetTreeNodeDetails(r)
                    With myNode
                        .ImageIndex = r("ImageID") - 1
                        .Text = r("NodeName")
                        .Name = r("NodeID")
                        .SelectedImageIndex = r("ImageIDExpanded") - 1
                        .Tag = r("ReportID")
                    End With
                    If stype = "F" Then
                        If r("ItemType") = "F" Then ParentNode.Nodes.Add(myNode)
                    Else
                        ParentNode.Nodes.Add(myNode)
                    End If
                    If myNode.SpecialID = SpecialID Then thisNode = myNode
                    AddNodes(myNode, iNodeID, stype)
                Next
            End If
        Catch ex As Exception
            EmailErrorAlert(gDatabaseConnection, ex.Message, gUserID, gApplicationName, gApplicationVersion, gUserID, CallFromType, CallFrom, gWorkstationID, gOsName)
        Finally
            drData = Nothing
        End Try
    End Sub

    Public Function GetNodeByKey(ByVal aTreeView As TreeView, ByVal FindKey As String, _
Optional ByVal DoSelect As Boolean = False, _
Optional ByRef arrNodes As TreeNodeCollection = Nothing) As DARTTreeNode
        Dim found As Boolean = False
        Dim foundNode As DARTTreeNode = Nothing
        Dim intParam As Integer = 0
        Dim strParam As String = ""
        Dim eqlPos As Integer = InStr(FindKey, "=")
        Dim FindKeyType As String = FindKey.Substring(0, eqlPos)
        Dim FindKeyValue As String = FindKey.Substring(eqlPos)
        CallFromType = "Function"
        CallFrom = "GetNodeByKey"

        Try
            If arrNodes Is Nothing Then
                arrNodes = aTreeView.Nodes
            End If

            Dim aNode As DARTTreeNode = Nothing
            For Each aNode In arrNodes
                Select Case FindKeyType
                    Case "ReportID="
                        If aNode.ReportID.ToString = FindKeyValue Then
                            found = True
                            Exit For
                        End If
                    Case "ReportNumber="
                        If aNode.ReportNumber = FindKeyValue Then
                            found = True
                            Exit For
                        End If
                    Case "ReportName="
                        If aNode.ReportName = FindKeyValue Then
                            found = True
                            Exit For
                        End If
                    Case "ReportFullName="
                        If aNode.ReportFullName = FindKeyValue Then
                            found = True
                            Exit For
                        End If
                    Case "NodeName="
                        If aNode.NodeName = FindKeyValue Then
                            found = True
                            Exit For
                        End If
                    Case "FullPath="
                        If aNode.FullPath = FindKeyValue Then
                            found = True
                            Exit For
                        End If
                    Case "Name="
                        If aNode.Name = FindKeyValue Then
                            found = True
                            Exit For
                        End If
                    Case "ItemTypeID="
                        If aNode.ItemTypeID = FindKeyValue Then
                            found = True
                            Exit For
                        End If
                    Case "NodeID="
                        If aNode.NodeID = FindKeyValue Then
                            found = True
                            Exit For
                        End If
                    Case "TreeLevelID="
                        If aNode.TreeLevelID = FindKeyValue Then
                            found = True
                            Exit For
                        End If

                End Select
                If aNode.ItemType = "F" And aNode.Nodes.Count > 0 Then
                    Dim tmpNode As DARTTreeNode = GetNodeByKey(aTreeView, FindKey, DoSelect, aNode.Nodes)
                    If tmpNode IsNot Nothing Then
                        foundNode = tmpNode         '<--- Ensure that the node gets passed up the chain of recursive calls
                        Exit For
                    End If
                End If
            Next

            If found = True Then foundNode = aNode

            If DoSelect = True And found = True Then
                aTreeView.SelectedNode = foundNode
                aTreeView.SelectedNode.EnsureVisible()
            End If
        Catch ex As Exception
            EmailErrorAlert(gDatabaseConnection, ex.Message, gUserID, gApplicationName, gApplicationVersion, gUserID, CallFromType, CallFrom, gWorkstationID, gOsName)
        End Try

        Return foundNode
    End Function

End Class


