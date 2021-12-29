Public Class frmManageReports
    Private dsRpts As DataSet = Nothing
    Private dsInfo As DataSet = Nothing
    Private dtReportNameTitle As DataTable = Nothing
    Private server As String = gServer
    Private connStr As String = "Data Source=" + server + ";Initial Catalog=DDT_Common;Integrated Security=True"
    Private Editing As Boolean = False
    Private Adding As Boolean
    Private HandlingControls As Boolean
    Private EditingAllowed As Boolean
    Private sqlConnection As System.Data.SqlClient.SqlConnection
    Private sqlCmd As System.Data.SqlClient.SqlCommand
    Private LockedForEditingBy As String
    Private LockedForEditingTime As String
    Private currReportID As Integer
    Private OriginalFormTitleText As String
    Private dsCopyCurrentRecord As New DataSet
    Private RptDirPrimary As String
    Private Property lblEditingStatus As Object

    Private Sub frmManageReports_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        tmrEditAvailability.Enabled = False
    End Sub

    Private Sub frmManageReports_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If Editing Or Adding Then
            Dim aResponse As DialogResult = RichMessageBoxShow("Are you sure you want to close the Manage Reports window without saving changes?",
                            "CHANGES NOT SAVED", Color.Azure, Color.Azure, Color.Black,
                            New Size(400, 100), 12, BorderStyle.None,
                            RichMessageBoxIcon.Question, RichMessageBoxButtons.YesNo,
                            RichMessageboxDefaultButton.Button2, ScrollBars.Vertical,
                            RichMessageboxFadeStyle.FadeOutOnly)
            If aResponse = System.Windows.Forms.DialogResult.No Then
                e.Cancel = True
            Else
                btnCancel_Click(Nothing, Nothing)
            End If
        End If
    End Sub

	Private Sub frmManageReports_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
		Me.Icon = frmMain.Icon ' Barry

		lblServerConnection.Text = "Server Connection: " & server
		dsInfo = CreateDataset("SELECT *, convert(varchar(5), ReportFormatID) + '   ( ' + ReportFormat + ' )' as IDandName FROM dbo.trReportFormats", connStr, "ReportFormats")
		dsInfo = CreateDataset("SELECT * FROM dbo.tsDeveloperIDs", connStr, "DDTDevelopers", dsInfo)
		dsInfo = CreateDataset("SELECT * FROM dbo.trReports_UserAccessLevels ORDER BY AccessLevel", connStr, "ReportAccessLevel", dsInfo)

		Me.Top = 20
		Me.Left = 20
		Me.Height = frmMain.Height - 110 - IIf(frmMain.tsMyButtons.Visible = True, frmMain.tsMyButtons.Height, 0)
		Me.Width = frmMain.Width - 50

		'--- Setup table for CopyReport button ---
		dsCopyCurrentRecord.Tables.Add("CopyReport")
		dsCopyCurrentRecord.Tables("CopyReport").Columns.Add("PropertyName")
		dsCopyCurrentRecord.Tables("CopyReport").Columns.Add("PropertyValue")


		BuildReportsDataset()				'<-- Create 2 datasets: Reports (allFields) and ReportsNameAndDesc (someFields)
		PopulateReportsGrid()				'<-- Use datasets to populate the reports grid
		CheckEditingStatus()				'<-- Check the availability of the Reports table for Edit
		DisplaySelectedReportProperties()	'<-- Display the currently selected report in the properties grid.

		'--- Editing is off at startup ---
		HandleControlsForEdit(False)

		'--- This Timer will check EditStatus every 60 sec ---
		tmrEditAvailability.Enabled = True

		'--- Set this at run time.  If set at designtime, it gets lost periodically when any change is made to the form. ---
		Me.CancelButton = btnCancel
		Me.WindowState = FormWindowState.Maximized
	End Sub

    Private Sub HandleControlsForEdit(ByVal EditMode As Boolean)
        '--- Flag to not run code in CheckedChanged event ---
        HandlingControls = True
        ckIsStatic.Enabled = EditMode
        ckUseTabs.Enabled = EditMode

        For Each dgvRow As DataGridViewRow In dgvReportProperties.Rows

            dgvRow.Cells("PropertyName").Style.BackColor = Color.AliceBlue
            Select Case dgvRow.Cells("PropertyName").Value
                Case "IsStatic"
                    dgvRow.Visible = False
                    dgvRow.Cells("PropertyValue").ReadOnly = True
                    ckIsStatic.Checked = dgvRow.Cells("PropertyValue").Value
                    dgvRow.Cells("PropertyValue").Style.BackColor = Color.LightGray
                Case "TreeLevelID"
                    dgvRow.Visible = True
                    dgvRow.Cells("PropertyValue").ReadOnly = True
                    dgvRow.Cells("PropertyValue").Style.BackColor = Color.LightGray
                Case "UseTabs"
                    dgvRow.Visible = False
                    dgvRow.Cells("PropertyValue").ReadOnly = True
                    ckUseTabs.Checked = dgvRow.Cells("PropertyValue").Value
                    dgvRow.Cells("PropertyValue").Style.BackColor = Color.LightGray
                Case "ReportID", "CreationDate", "ModifiedDate"
                    dgvRow.Cells("PropertyValue").Style.BackColor = Color.LightGray
                    dgvRow.Cells("PropertyValue").ReadOnly = True
                Case "CreatedBy_EmpNum", "ModifiedBy_EmpNum"
                    dgvRow.Cells("PropertyValue").Style.BackColor = Color.LightGray
                    dgvRow.Cells("PropertyValue").ReadOnly = True
                    If Editing = True Then
                        dgvRow.Cells("PropertyValue").Value = Strings.Left(dgvRow.Cells("PropertyValue").Value, 5)
                    End If
                Case "LeadDeveloper"
                    If Editing = True Then
                        dgvRow.Cells("PropertyValue").Value = Strings.Left(dgvRow.Cells("PropertyValue").Value, 5)
                        dgvRow.Cells("PropertyValue").Style.BackColor = Color.White
                        dgvRow.Cells("PropertyValue").ReadOnly = False
                    Else
                        dgvRow.Cells("PropertyValue").Style.BackColor = Color.WhiteSmoke
                        dgvRow.Cells("PropertyValue").ReadOnly = True
                    End If
                    If InStr(dgvRow.Cells("PropertyValue").Value, "Not a Recognized DART Developer Name") > 0 Then
                        dgvRow.Cells("PropertyValue").Style.BackColor = Color.Orange
                    End If
                Case Else
                    If Editing = True Then
                        dgvRow.Cells("PropertyValue").Style.BackColor = Color.White
                        dgvRow.Cells("PropertyValue").ReadOnly = False
                    Else
                        dgvRow.Cells("PropertyValue").Style.BackColor = Color.WhiteSmoke
                        dgvRow.Cells("PropertyValue").ReadOnly = True
                    End If
            End Select
        Next

        dgvReports.Enabled = Not EditMode

        btnCancel.Enabled = EditMode
        btnAddReport.Enabled = Not EditMode
        btnDeleteReport.Enabled = Editing
        btnDeleteReport.Visible = (Editing And Not Adding)
        btnCopy.Enabled = (Not Editing And Not Adding)
        btnPaste.Enabled = (Adding And dsCopyCurrentRecord.Tables("CopyReport").Rows.Count > 0)

        AddToolStripMenuItem.Enabled = btnAddReport.Enabled
        EditToolStripMenuItem.Enabled = btnEditReport.Enabled
        CopyToolStripMenuItem.Enabled = btnCopy.Enabled

        '--- Handle edit button text ---
        If Editing = True Then
            btnEditReport.Text = "Save"
        Else
            btnEditReport.Text = "Edit"
        End If

        HandlingControls = False
    End Sub

    Private Sub BuildReportsDataset()
        If dsRpts IsNot Nothing Then dsRpts.Clear()
        'mburts - get ready
        dsRpts = CreateDataset("DDT_Common.dbo.sToolbox_ManageReports_GetReports 0", connStr, "Reports")                     '<-- This one returns everything.
        dsRpts = CreateDataset("DDT_Common.dbo.sToolbox_ManageReports_GetReports 1", connStr, "ReportsNameAndDesc", dsRpts)  '<-- This one returns only ReportID, ReportName & ReportDesc
        dsRpts = CreateDataset("DDT_Common.dbo.sToolbox_Application_GetInfo ''", connStr, "Applications", dsRpts)  '<-- TThis returns the applications (DART/WFM)
        SetTablePrimaryKey(dsRpts.Tables("Reports"), dsRpts.Tables("Reports").Columns.Item("ReportID"))
        SetTablePrimaryKey(dsRpts.Tables("ReportsNameAndDesc"), dsRpts.Tables("ReportsNameAndDesc").Columns.Item("ReportID"))
        SetTablePrimaryKey(dsRpts.Tables("Applications"), dsRpts.Tables("Applications").Columns.Item("ApplicationID"))
    End Sub
    Private Sub SetTablePrimaryKey(ByVal dTable As DataTable, ByVal PkColumn1 As DataColumn _
                                                            , Optional ByVal PkColumn2 As DataColumn = Nothing _
                                                            , Optional ByVal PkColumn3 As DataColumn = Nothing)
        Dim dc(2) As DataColumn
        dc(0) = IIf(PkColumn1 IsNot Nothing, PkColumn1, Nothing)
        dc(1) = IIf(PkColumn1 IsNot Nothing, PkColumn2, Nothing)
        dc(2) = IIf(PkColumn1 IsNot Nothing, PkColumn3, Nothing)
        dTable.PrimaryKey = dc
    End Sub

    Private Sub PopulateReportsGrid()
        With dgvReports
            .DataSource = dsRpts.Tables("ReportsNameAndDesc")
            .AutoResizeColumns()
            .ReadOnly = True
            .AllowUserToOrderColumns = True
        End With
    End Sub

    Private Sub BuildReportPropertiesByID(ByVal ReportID As Integer)
        Dim rowNum As Integer = 0
        Dim i As Integer
        Dim cRow As DataRow     '<-- Current Row
        Dim SqlStr2 As String
        Dim EmpName As String = Nothing
        Dim IsDeveloper As Boolean = False

        cRow = dsRpts.Tables("Reports").Rows.Find(ReportID)
        dgvReportProperties.Rows.Clear()

        For i = 0 To dsRpts.Tables("Reports").Columns.Count - 1
            dgvReportProperties.Rows.Add()
            dgvReportProperties.Rows(i).Cells("PropertyName").Value = dsRpts.Tables("Reports").Columns(i).ColumnName.ToString
            dgvReportProperties.Rows(i).Cells("PropertyName").Style.BackColor = Color.Gray

            Select Case dgvReportProperties.Rows(i).Cells("PropertyName").Value
                Case "ReportFormatID"
                    dgvReportProperties.Rows(i).Cells("PropertyValue") = New DataGridViewComboBoxCell()
                    With DirectCast(dgvReportProperties.Rows(i).Cells("PropertyValue"), DataGridViewComboBoxCell)
                        .Items.Clear()
                        .DataSource = dsInfo.Tables("ReportFormats")
                        .DisplayMember = dsInfo.Tables("ReportFormats").Columns("IDandName").ToString
                        .ValueMember = dsInfo.Tables("ReportFormats").Columns("ReportFormatID").ToString
                        .Value = cRow.Item("ReportFormatID")
                    End With
                Case "AccessTypeID"
                    dgvReportProperties.Rows(i).Cells("PropertyValue") = New DataGridViewComboBoxCell()
                    With DirectCast(dgvReportProperties.Rows(i).Cells("PropertyValue"), DataGridViewComboBoxCell)
                        .Items.Clear()
                        .DataSource = dsInfo.Tables("ReportAccessLevel")
                        .DisplayMember = dsInfo.Tables("ReportAccessLevel").Columns("Description").ToString
                        .ValueMember = dsInfo.Tables("ReportAccessLevel").Columns("AccessLevel").ToString
                        .Value = cRow.Item("AccessTypeID")
                    End With
                Case "ApplicationID"
                    dgvReportProperties.Rows(i).Cells("PropertyValue") = New DataGridViewComboBoxCell()
                    With DirectCast(dgvReportProperties.Rows(i).Cells("PropertyValue"), DataGridViewComboBoxCell)
                        .Items.Clear()
                        .DataSource = dsRpts.Tables("Applications")
                        .DisplayMember = dsRpts.Tables("Applications").Columns("ApplicationAbrv").ToString
                        .ValueMember = dsRpts.Tables("Applications").Columns("ApplicationID").ToString
                        .Value = cRow.Item("ApplicationID")
                    End With
                Case "ModifiedBy_EmpNum", "CreatedBy_EmpNum", "LeadDeveloper"
                    If cRow.Item(i).ToString = Nothing Then
                        dgvReportProperties.Rows(i).Cells("PropertyValue").Value = ""
                    Else
                        SqlStr2 = "SELECT FullName_First + convert(varchar(50), dbo.fsIsDeveloper(LAN_User_ID, 1)) FROM dbo.tEmployees_GeneralInfo WHERE EmployeeNumber = '" + cRow.Item(i).ToString + "'"

                        EmpName = ExecSqlScalar(SqlStr2, connStr)               '<-- A digit is added to tell whether or not EmpName is a Developer.
                        If EmpName Is Nothing Then
                            IsDeveloper = False
                            EmpName = "?? INVALID # ??"
                        Else
                            If Strings.Right(EmpName, 1) = "1" Then
                                IsDeveloper = True
                            Else
                                IsDeveloper = False
                            End If
                            EmpName = Mid(EmpName, 1, Strings.Len(EmpName) - 1)     '<-- Now, Strip the digit off the end
                        End If
                        dgvReportProperties.Rows(i).Cells("PropertyValue").Value = cRow.Item(i).ToString + "    (" + IIf(IsDeveloper = False, EmpName + " -- Not a Recognized DART Developer Name", EmpName) + ")"
                    End If
                Case "IsStatic"
                    If cRow.Item(i).ToString = "False" Then
                        dgvReportProperties.Rows(i).Cells("PropertyValue").Value = "False"
                    Else
                        dgvReportProperties.Rows(i).Cells("PropertyValue").Value = "True"
                    End If
                Case "UseTabs"
                    If cRow.Item(i).ToString = "False" Then
                        dgvReportProperties.Rows(i).Cells("PropertyValue").Value = "False"
                    Else
                        dgvReportProperties.Rows(i).Cells("PropertyValue").Value = "True"
                    End If
                Case Else
                    dgvReportProperties.Rows(i).Cells("PropertyValue").Value = cRow.Item(i).ToString
            End Select
        Next

        HandleControlsForEdit(Editing)
        dgvReportProperties.ClearSelection()

    End Sub

    Private Sub BuildReportPropertiesNewReport()
        Dim i As Integer
        dgvReportProperties.Rows.Clear()

        For i = 0 To dsRpts.Tables("Reports").Columns.Count - 1
            dgvReportProperties.Rows.Add()
            dgvReportProperties.Rows(i).Cells("PropertyValue").Value = Nothing
            dgvReportProperties.Rows(i).Cells("PropertyName").Value = dsRpts.Tables("Reports").Columns(i).ColumnName.ToString

            Select Case dgvReportProperties.Rows(i).Cells("PropertyName").Value
                Case "IsStatic"
                    dgvReportProperties.Rows(i).Cells("PropertyValue").Value = False
                    ckIsStatic.Checked = 0
                Case "UseTabs"
                    dgvReportProperties.Rows(i).Cells("PropertyValue").Value = False
                    ckUseTabs.Checked = 0
                Case "ReportID"
                    dgvReportProperties.Rows(i).Cells("PropertyValue").Value = 0
                Case "DirectoryPrimary"
                    dgvReportProperties.Rows(i).Cells("PropertyValue").Value = gDirPrimary
                Case "ReportFormatID"
                    dgvReportProperties.Rows(i).Cells("PropertyValue") = New DataGridViewComboBoxCell()
                    With DirectCast(dgvReportProperties.Rows(i).Cells("PropertyValue"), DataGridViewComboBoxCell)
                        .Items.Clear()
                        .DataSource = dsInfo.Tables("ReportFormats")
                        .DisplayMember = dsInfo.Tables("ReportFormats").Columns("IDandName").ToString
                        .ValueMember = dsInfo.Tables("ReportFormats").Columns("ReportFormatID").ToString
                        .Value = dsInfo.Tables("ReportFormats").Rows(0).Item("ReportFormatID")             '<-- Default to the top one.
                    End With
                Case "ApplicationID"
                    dgvReportProperties.Rows(i).Cells("PropertyValue") = New DataGridViewComboBoxCell()
                    With DirectCast(dgvReportProperties.Rows(i).Cells("PropertyValue"), DataGridViewComboBoxCell)
                        .Items.Clear()
                        .DataSource = dsRpts.Tables("Applications")
                        .DisplayMember = dsRpts.Tables("Applications").Columns("ApplicationAbrv").ToString
                        .ValueMember = dsRpts.Tables("Applications").Columns("ApplicationID").ToString
                    End With
                Case "AccessTypeID"
                    dgvReportProperties.Rows(i).Cells("PropertyValue") = New DataGridViewComboBoxCell()
                    With DirectCast(dgvReportProperties.Rows(i).Cells("PropertyValue"), DataGridViewComboBoxCell)
                        .Items.Clear()
                        .DataSource = dsInfo.Tables("ReportAccessLevel")
                        .DisplayMember = dsInfo.Tables("ReportAccessLevel").Columns("Description").ToString
                        .ValueMember = dsInfo.Tables("ReportAccessLevel").Columns("AccessLevel").ToString
                    End With
            End Select
        Next

        dgvReportProperties.ClearSelection()
    End Sub

    Private Sub DisplaySelectedReportProperties()
        BuildReportPropertiesByID(dgvReports.CurrentRow.Cells("ReportID").Value)
    End Sub
    Private Sub dgvReports_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvReports.CellDoubleClick
        EditRecord()
    End Sub
    Private Sub ResizeControls()
        If dgvReportProperties.Columns.Count > 0 Then
            With dgvReportProperties
                .Columns("PropertyValue").Width = .Width - .Columns("PropertyName").Width - 5
            End With
        End If
    End Sub

    Private Sub frmManageReports_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        ResizeControls()
    End Sub

    Private Sub frmManageReports_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        ResizeControls()
    End Sub

    Private Sub EditRecord(Optional ByVal AddingNewRecord As Boolean = False)
        If Editing = False Then
            CheckEditingStatus()
            If EditingAllowed = True Then
                BlinkEditText(True)
                SetEditStatusState("dirty")     '< Set EditStatus table to LOCKED state
                Editing = True
                If AddingNewRecord = True Then
                    Adding = True
                    currReportID = 0
                    dgvReports.ClearSelection()
                    BuildReportPropertiesNewReport()
                Else
                    Adding = False
                    currReportID = dgvReports.CurrentRow.Cells("ReportID").Value

                    '--- Make sure we have the most current data ---
                    BuildReportsDataset()
                    PopulateReportsGrid()               '<-- Use datasets to populate the reports grid
                    SelectGridRowByID(dgvReports, "ReportID", currReportID)
                End If
            Else
                EditNotAllowedMessage()
            End If
        Else
            '----- THE FACTS ARE IN.  NOW IT'S TIME TO SAVE THE RECORD -----
            Dim retReportID As String
            Dim SqlStr As String = Nothing
            Dim SqlStr2 As String = Nothing
            '--- building the SQL command string to be executed ---
            'mburts
            SqlStr = "exec dbo.sToolbox_UpdateReports "

            For Each propRow As DataGridViewRow In dgvReportProperties.Rows
                Select Case propRow.Cells("PropertyName").Value.ToString.ToUpper
                    Case "CREATEDBY_EMPNUM"
                        If Adding = True Then
                            SqlStr2 = "SELECT EmployeeNumber FROM dbo.tEmployees_GeneralInfo WHERE LAN_User_ID = '" + Mid(My.User.Name, InStr(My.User.Name, "\") + 1) + "'"
                            propRow.Cells("PropertyValue").Value = ExecSqlScalar(SqlStr2, connStr)
                        End If
                    Case "MODIFIEDBY_EMPNUM"
                        SqlStr2 = "SELECT EmployeeNumber FROM dbo.tEmployees_GeneralInfo WHERE LAN_User_ID = '" + Mid(My.User.Name, InStr(My.User.Name, "\") + 1) + "'"
                        propRow.Cells("PropertyValue").Value = Strings.Left(ExecSqlScalar(SqlStr2, connStr), 5)
                    Case "ReportID"
                        Stop
                End Select

                If propRow.Cells("PropertyValue").Value Is Nothing Or IsDBNull(propRow.Cells("PropertyValue").Value) Then
                    SqlStr += "' ',"
                Else
                    Select Case propRow.Cells("PropertyValue").Value.ToString.ToUpper
                        Case "TRUE"
                            SqlStr += "1, "
                        Case "FALSE"
                            SqlStr += "0, "
                        Case Else
                            SqlStr += "'" + FixQuotes(propRow.Cells("PropertyValue").Value.ToString) + "', "
                    End Select

                End If
            Next
            Dim pos As Integer = InStrRev(SqlStr, ",")
            SqlStr = Strings.Left(SqlStr, pos - 1)      '<Remove the last comma

            '--- Execute function to SAVE report records ---
            retReportID = ExecSqlScalar(SqlStr, connStr)
            If retReportID = "" Then retReportID = "ERROR: Unknown Error"

            If Strings.Left(retReportID, 5).ToUpper = "ERROR" Then
                RichMessageBoxShow(retReportID, "ERROR returned from SQL", Color.Azure, Color.Azure, Color.Black, New Size(400, 100), 12, BorderStyle.None, RichMessageBoxIcon._Error, RichMessageBoxButtons.OK, RichMessageboxDefaultButton.Button1, ScrollBars.Vertical, RichMessageboxFadeStyle.FadeOutOnly)
                Exit Sub
            End If

            BuildReportsDataset()
            PopulateReportsGrid()

            SelectGridRowByID(dgvReports, "ReportID", retReportID)

            '--- Reset Edit State ---
            SetEditStatusState("")      '< Set EditStatus table to UNLocked State
            frmMain.IsManageReportsEditWindowOpen = False

            Editing = False
            Adding = False
            BlinkEditText(False)
        End If

        CheckEditingStatus()
        HandleControlsForEdit(Editing)
        If AddingNewRecord = True Then
        Else
            DisplaySelectedReportProperties()
        End If
    End Sub

    Private Sub btnEditReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEditReport.Click
        EditRecord()
    End Sub

    Private Sub CancelEditRecord()
        Editing = False
        Adding = False

        SetEditStatusState("")
        HandleControlsForEdit(False)
        DisplaySelectedReportProperties()
        BlinkEditText(False)
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        CancelEditRecord()
    End Sub

    Private Sub SetDgvPropertyValue(ByVal PropertyName As String, ByVal PropertyValue As Object)
        For Each dRow As DataGridViewRow In dgvReportProperties.Rows
            If dRow.Cells("PropertyName").Value = PropertyName Then
                dRow.Cells("PropertyValue").Value = PropertyValue
            End If
        Next
    End Sub

    Private Sub ckIsStatic_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ckIsStatic.CheckedChanged
        If Not HandlingControls Then
            SetDgvPropertyValue("IsStatic", ckIsStatic.Checked)
        End If
    End Sub

    Private Sub ckUseTabs_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ckUseTabs.CheckedChanged
        If Not HandlingControls Then
            SetDgvPropertyValue("UseTabs", ckUseTabs.Checked)
        End If
    End Sub

    Private Sub btnAddReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddReport.Click
        EditRecord(True)
    End Sub

    Private Sub CheckEditingStatus()
        Dim sql As String
        Try
            Dim aMsg As String = "--------------------------------------------------------------------------" + vbCrLf + vbCrLf _
                               + "--- The current connection string listed below is not currently valid. ---" + vbCrLf + vbCrLf _
                               + "--- The network may be down or your VPN connection may have timed out. ---" + vbCrLf + vbCrLf _
                               + "--------------------------------------------------------------------------" + vbCrLf + vbCrLf + vbCrLf _
                               + "----------" + vbCrLf + vbCrLf _
                               + connStr.ToString + vbCrLf + vbCrLf _
                               + "----------" + vbCrLf + vbCrLf + vbCrLf _
                               + "THIS MESSAGEBOX WILL SELF DESTRUCT IN A FEW SECONDS."
            Dim returnValue As String = Nothing
            sql = "EXEC DDT_Common.dbo.sToolbox_GetConnectedServerName"

            returnValue = ExecSqlScalar(sql, connStr, False)
            If returnValue = "" Then
                ShowTempMessageBox(aMsg, "Connection Issue", 10000, 400, 800)
                Exit Sub
            End If
        Catch ex As Exception

        End Try

        Dim EditingAllowedOnEntry As Boolean = EditingAllowed
        sql = "exec DDT_Common.dbo.sToolbox_GetReports_EditStatus"
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
                LockedForEditingBy = reader.GetSqlString(reader.GetOrdinal("UserName")).ToString.Trim
                LockedForEditingTime = reader.GetSqlDateTime(reader.GetOrdinal("LockTime"))

                If LockedForEditingBy.Trim = "Available for editing" Then
                    EditingAllowed = True
                Else
                    If LockedForEditingBy = Strings.Right(My.User.Name, Len(My.User.Name) - InStrRev(My.User.Name, "\")) Then
                        EditingAllowed = True
                    Else
                        EditingAllowed = False
                    End If
                End If
            Else
                EditingAllowed = True
            End If
        Catch sqlex As SqlClient.SqlException
            DisplayUnexpectedSQLException(sqlex)
        Finally
            sqlConnection.Close()
        End Try

    End Sub

    Private Sub lblEditingStatus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim EditingAllowedOnEntry As Boolean = EditingAllowed

        Me.Cursor = Cursors.WaitCursor
        CheckEditingStatus()
        Me.Cursor = Cursors.Default
        If EditingAllowed And Not EditingAllowedOnEntry Then
            EditingReenabled()
        End If
    End Sub

    Private Sub EditingReenabled()
        MessageBox.Show("Editing of the Reports table has been reenabled. The Reports table will be reloaded after pressing OK.", "Editing permitted", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Me.Update()
        BuildReportsDataset()       'Re-build datasets 
        PopulateReportsGrid()
        DisplaySelectedReportProperties()
    End Sub

    Private Sub EditNotAllowedMessage()
        MessageBox.Show("Editing of the Reports table is not currently allowed because it is being modified by " + LockedForEditingBy + ".", "Changes not allowed", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    End Sub

    Private Sub SetEditStatusState(ByVal state As String)
        If state = "dirty" Then
            Dim user As String = Strings.Right(My.User.Name, Len(My.User.Name) - InStrRev(My.User.Name, "\"))
            Dim sql As String = "exec DDT_Common.dbo.sToolbox_UpdateReports_EditStatus '" + user + "'"
            Try
                sqlCmd.CommandType = CommandType.Text
                sqlCmd.CommandText = sql
                sqlCmd.Connection = sqlConnection
                sqlConnection.Open()
                sqlCmd.ExecuteNonQuery()
                dgvReports.DefaultCellStyle.BackColor = Color.LightSteelBlue
            Catch sqlex As SqlClient.SqlException
                DisplayUnexpectedSQLException(sqlex)
            Finally
                sqlConnection.Close()
            End Try
        Else
            dgvReports.DefaultCellStyle.BackColor = Color.White
            Dim sql As String = "exec DDT_Common.dbo.sToolbox_UpdateReports_EditStatus ''"
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
        HandleControlsForEdit(Editing)
    End Sub

    Private Sub tmrEditAvailability_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrEditAvailability.Tick
        CheckEditingStatus()
    End Sub

    Private Sub dgvReports_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvReports.CellEnter
        BuildReportPropertiesByID(dgvReports.Rows(e.RowIndex).Cells("ReportID").Value)
    End Sub

    Private Sub DeleteReport(ByVal ReportID As Integer)
        Try
            Dim aMessage As String = Nothing
            If MessageBox.Show("Are You Sure You Want to Delete Report ID = " + ReportID.ToString, "Deleting a Report", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                Dim ReturnMessage As String = Nothing
                ReturnMessage = ExecSqlScalar("exec sToolbox_UpdateReports_Delete " + ReportID.ToString, connStr)
                If ReturnMessage = "SUCCESS" Then
                    Editing = False
                    SetEditStatusState("")      '< Set EditStatus table to UNLocked State
                    CheckEditingStatus()
                    HandleControlsForEdit(Editing)
                    BuildReportsDataset()
                    PopulateReportsGrid()

                    MessageBox.Show("Report (ReportID=" + ReportID.ToString + ") has been Deleted.", "Report Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    dgvReports.Rows(0).Selected = True      'Select 1st row
                    BlinkEditText(False)
                Else
                    '--- Report the Problem then stay in edit mode ---
                    MessageBox.Show(ReturnMessage, "Problem Deleting Report", MessageBoxButtons.OK, MessageBoxIcon.Information)

                End If
            End If
        Catch ex As DataException
            MsgBox("Error During Report Delete " & ex.Message)
        End Try
    End Sub

    Private Sub btnDeleteReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeleteReport.Click
        DeleteReport(dgvReports.CurrentRow.Cells("ReportID").Value)
    End Sub
    Private Sub btnCopy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCopy.Click
        CopyCurrentRecord()
    End Sub

    Private Sub CopyCurrentRecord()
        dsCopyCurrentRecord.Tables("CopyReport").Clear()

        With dgvReportProperties

            For i As Integer = 0 To dgvReportProperties.Rows.Count - 1
                dsCopyCurrentRecord.Tables("CopyReport").Rows.Add()
                dsCopyCurrentRecord.Tables("CopyReport").Rows(i).Item("PropertyName") = .Rows(i).Cells("PropertyName").Value.ToString
                Select Case .Rows(i).Cells("PropertyName").Value()
                    Case "LeadDeveloper", "CreatedBy_EmpNum", "ModifiedBy_EmpNum"
                        dsCopyCurrentRecord.Tables("CopyReport").Rows(i).Item("PropertyValue") _
                            = Strings.Left(.Rows(i).Cells("PropertyValue").Value.ToString, 5)
                    Case "ReportName"
                        dsCopyCurrentRecord.Tables("CopyReport").Rows(i).Item("PropertyValue") _
                           = .Rows(i).Cells("PropertyValue").Value.ToString
                    Case Else
                        dsCopyCurrentRecord.Tables("CopyReport").Rows(i).Item("PropertyValue") _
                            = .Rows(i).Cells("PropertyValue").Value.ToString
                End Select
            Next
        End With
        InsertCopyRecord()
        btnPaste.Enabled = True
        btnCancel.Enabled = True
        btnEditReport.Enabled = False
        btnCopy.Enabled = False
    End Sub

    Private Sub InsertCopyRecord()
        With dgvReportProperties
            For i As Integer = 0 To .Rows.Count - 1
                Select Case .Rows(i).Cells("PropertyName").Value
                    Case "ReportID"
                        .Rows(i).Cells("PropertyValue").Value = 0
                    Case "CreatedBy_EmpNum", "ModifiedBy_EmpNum", "CreationDate", "ModifiedDate"
                    Case "ReportFormatID"
                        For Each rw As DataRowView In DirectCast(.Rows(i).Cells("PropertyValue"), DataGridViewComboBoxCell).Items
                            If dsCopyCurrentRecord.Tables("CopyReport").Rows(i).Item("PropertyValue").ToString = rw.Item(0).ToString Then
                                DirectCast(.Rows(i).Cells("PropertyValue"), DataGridViewComboBoxCell).Value = rw.Item(0)
                                Exit For
                            End If
                        Next
                    Case "ReportTitle"
                        .Rows(i).Cells("PropertyValue").Value = "Copy of " + dsCopyCurrentRecord.Tables("CopyReport").Rows(i).Item("PropertyValue").ToString
                        .Rows(i).Cells("PropertyValue").Style.BackColor = Color.Yellow
                    Case "LeadDeveloper"
                        .Rows(i).Cells("PropertyValue").Value = dsCopyCurrentRecord.Tables("CopyReport").Rows(i).Item("PropertyValue")
                    Case "ReportNumber", "ReportName"
                        .Rows(i).Cells("PropertyValue").Value = "Copy of " + dsCopyCurrentRecord.Tables("CopyReport").Rows(i).Item("PropertyValue").ToString
                        .Rows(i).Cells("PropertyValue").Style.BackColor = Color.Yellow
                    Case Else
                        .Rows(i).Cells("PropertyValue").Value = dsCopyCurrentRecord.Tables("CopyReport").Rows(i).Item("PropertyValue")
                End Select
            Next
        End With
        dgvReportProperties.Refresh()
        Editing = True
        btnEditReport.Text = "Save"
    End Sub

    Private Sub btnPaste_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPaste.Click
        'InsertCopyRecord()
        btnEditReport.Enabled = True
        Adding = True
        EditRecord()
    End Sub

    Private Sub AddToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddToolStripMenuItem.Click
        btnAddReport_Click(Nothing, Nothing)
    End Sub

    Private Sub EditToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditToolStripMenuItem.Click
        btnEditReport_Click(Nothing, Nothing)
    End Sub

    Private Sub CopyToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CopyToolStripMenuItem.Click
        btnCopy_Click(Nothing, Nothing)
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

    Private Sub dgvReports_CellFormatting(sender As Object, e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dgvReports.CellFormatting
        Dim drv As DataRowView
        Dim c As Color
        If e.RowIndex >= 0 Then
            If e.RowIndex <= dsRpts.Tables("ReportsNameAndDesc").Rows.Count - 1 Then
                drv = dsRpts.Tables("ReportsNameAndDesc").DefaultView.Item(e.RowIndex)

                If IsNumeric(drv.Item("TreeLevelID")) Then
                    c = Color.White
                Else
                    c = Color.Pink
                End If
            End If
        End If
        e.CellStyle.BackColor = c
    End Sub

    Private Sub dgvReportProperties_DataError(sender As Object, e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgvReportProperties.DataError
        If (e.Context _
            = (DataGridViewDataErrorContexts.Formatting Or DataGridViewDataErrorContexts.PreferredSize)) Then
            e.ThrowException = False
        End If
    End Sub

End Class