Imports System.Data.SqlClient
Imports System.IO
Imports System.ComponentModel
Imports DDTToolbox.CodeUtilities
Imports DDTToolbox.DDT_Dataset

Public Class frmDART_TNGScheduledReports
    Private CurrentSelectedIndex As Integer = 0
    Private iniReportPath As String = My.Application.Info.DirectoryPath.ToString + "\cboReportPath.ini"
    Private gScheduledReportsPath As String
    Private SpltrOffset As Integer = 100
    Private Settings As DataRow()

	Private Sub frmDART_TNGScheduledReports_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pnlPrimaryContent.Visible = False
        LoadForm(Me, e) 'LAshby 2/27/18 created new routine in modGeneral to replace redundant frmLoad code in most forms

		If btnConnect.Enabled Then
			btnConnect_Click(sender, e)
		End If
    End Sub

#Region "Control Handles"

    Private Sub btnConnect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConnect.Click

        Dim GoodConn As Boolean
        gCurrentServer = cboServer.Items(cboServer.SelectedIndex)

        GoodConn = ChangeConnection(Me, e) 'LAshby 2/27/18 created new routine in modGeneral to replace redundant btnConnect_Click code in most forms
        If GoodConn = True Then
            btnConnect.ToolTipText = "Disconnect from a SQL Server database server"
            PopulateForm()
        Else
            btnConnect.ToolTipText = "Connect to a SQL Server database server"
        End If

    End Sub

    Private Sub PopulateForm()
        GetScheduleReportSettings()
        GetPackageData(gDatabaseConnection)
        Me.SetTodaysPackages()

        Me.Width = Screen.PrimaryScreen.WorkingArea.Width
        Me.Left = 1
        Me.WindowState = FormWindowState.Maximized
        splScheduledReports.Panel2Collapsed = True

        chkDetails_CheckedChanged(Nothing, Nothing)
        BuildScheduleReportsLocationDropdown()
        gScheduledReportsPath = cboReportPath.Text
        cboTmrInterval_SelectedIndexChanged(Nothing, Nothing)    '<-- Set AutoRefresh Interval.
        btnRefresh_Click(Nothing, Nothing)
        chkAutoScroll.Checked = True
        chkAutoRefresh.Checked = True
    End Sub

    Private Sub rbTodaysPackages_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbTodaysPackages.CheckedChanged
        SetTodaysPackages()
    End Sub

    Private Sub rbAllPackages_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbAllPackages.CheckedChanged
        SetAllPackages()
    End Sub

    Private Sub btnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefresh.Click
        CallFromType = "Sub"
        CallFrom = "btnRefresh_Click"
        Cursor = Cursors.WaitCursor
        Try
            '--- Reset Row Back Color ---
            For Each pRow As DataGridViewRow In dgvPackages.Rows
                dgvPackages.Rows(pRow.Index).DefaultCellStyle.BackColor = dgvPackages.RowsDefaultCellStyle.BackColor()
            Next
            Application.DoEvents()
            GetPackageData(gDatabaseConnection)
            chkAllColumns_CheckedChanged(Nothing, Nothing)
            HighlightExecuted()
        Catch ex As Exception
            EmailErrorAlert(gDatabaseConnection, ex.Message, gUserID, gApplicationName, gApplicationVersion, gUserID, CallFromType, CallFrom, gWorkstationID, gOsName)
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub chkAllColumns_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAllColumns.CheckedChanged
        CallFromType = "Sub"
        CallFrom = "chkAllColumns_CheckedChanged"
        Try
            If rbTodaysPackages.Checked Then
                SetTodaysPackages()
            ElseIf rbAllPackages.Checked Then
                SetAllPackages()
            Else
                'Unplanned Button
            End If
        Catch ex As Exception
            EmailErrorAlert(gDatabaseConnection, ex.Message, gUserID, gApplicationName, gApplicationVersion, gUserID, CallFromType, CallFrom, gWorkstationID, gOsName)
        End Try
    End Sub

    Private Sub chkDetails_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkDetails.CheckedChanged
        splScheduledReports.Panel2Collapsed = Not chkDetails.Checked
        If Not splScheduledReports.Panel2Collapsed Then
            PopulateDetailGrids()
        End If
    End Sub

    Private Sub chkAutoRefresh_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAutoRefresh.CheckedChanged
        If chkAutoRefresh.Checked Then
            btnRefresh.PerformClick()
            SetStatusLabel2("Monitoring Schedule Report Process...")
            tmrRefresh.Enabled = True
            grpPackages.Enabled = False
            grpRuntimeOptions.Enabled = False
            tmrProcessBox.Enabled = True
            Label1.Visible = True
        Else

            grpPackages.Enabled = True
            grpRuntimeOptions.Enabled = True
            tmrRefresh.Enabled = False
            SetStatusLabel2("Monitoring Off")
            tmrProcessBox.Enabled = False
            Label1.Visible = False
            cboReportPath.Enabled = False
        End If
    End Sub

    Private Sub cboTmrInterval_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTmrInterval.SelectedIndexChanged
        tmrRefresh.Interval = CInt(cboTmrInterval.Text) * 1000
    End Sub

    Private Sub tmrRefresh_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrRefresh.Tick
        Try
            GetPackageData(gDatabaseConnection, True)
            Dim CountExec As Integer = 0
            Dim ScID As Integer
            Dim drProcessing() As DataRow
            For Each dr As DataRow In dsSR.Tables("TodaysPackages").Rows
                If dr.Item("ExecutionStatus") = "PENDING" Then
                    ScID = dr.Item("ScheduleID")
                    drProcessing = dsSR.Tables("TodaysPackagesUpdated").Select("ScheduleID=" + ScID.ToString)
                    For Each dgvRow As DataGridViewRow In dgvPackages.Rows
                        If dgvRow.Cells("ScheduleID").Value = ScID Then
                            If drProcessing(0).Item("ExecutionStatus").ToString = "EXECUTED" Then
                                If dgvRow.Displayed = False And chkAutoScroll.Checked Then
                                    dgvPackages.FirstDisplayedScrollingRowIndex = dgvRow.Index - dgvPackages.DisplayedRowCount(False) + 2
                                End If
                                dgvRow.Cells("ExecutionStatus").Value = drProcessing(0).Item("ExecutionStatus").ToString
                                dgvRow.DefaultCellStyle.BackColor = Color.Yellow
                            End If
                        End If
                    Next
                End If
            Next
            SetReportPendingCount(CountExec)
        Catch ex As Exception
        End Try
        Application.DoEvents()
    End Sub

#End Region

    Private Sub GetScheduleReportSettings()
        CallFromType = "Sub"
        CallFrom = "GetScheduleReportSettings"

        Dim SQL As String = "exec dbo.sSchedule_GetReportSettings"
        Try
            dsSR.BuildTable(SQL, gDatabaseConnection.ConnectionString, "ScheduledReportsSettings")

            gScheduledReportsPath = dsSR.Tables("ScheduledReportsSettings").Rows(0).Item("ScheduledReportsPath")
            If Strings.Left(gScheduledReportsPath, 2) = "E:" Or Strings.Left(gScheduledReportsPath, 2) = "e:" Then
                gScheduledReportsPath = "\\" + gCurrentServer.ToLower + gScheduledReportsPath.Substring(2)
            End If
        Catch ex As Exception
            EmailErrorAlert(gDatabaseConnection, ex.Message, gUserID, gApplicationName, gApplicationVersion, gUserID, CallFromType, CallFrom, gWorkstationID, gOsName)
        End Try
    End Sub

    Private Sub GetPackageData(Optional ByVal conn As SqlConnection = Nothing, Optional ByVal ForProcessing As Boolean = False)
        CallFromType = "Sub"
        CallFrom = "GetPackageData"
        Try
            If ForProcessing Then
                dsSR.BuildTable("EXEC dbo.sSchedule_GetTodaysPackages 1, 0", gDatabaseConnection.ConnectionString, "TodaysPackagesUpdated")
            Else
                dsSR.BuildTable("EXEC dbo.sSchedule_GetTodaysPackages 1, 0", gDatabaseConnection.ConnectionString, "TodaysPackages")
                dsSR.BuildTable("EXEC dbo.sSchedule_GetTodaysPackages 1, 2", gDatabaseConnection.ConnectionString, "AllPackages")
            End If

        Catch ex As Exception
            EmailErrorAlert(conn, ex.Message, gUserID, gApplicationName, gApplicationVersion, gUserID, CallFromType, CallFrom, gWorkstationID, gOsName)
        End Try
    End Sub

    Private Sub SetTodaysPackages(Optional ByVal UseTodaysPackages As String = "TodaysPackages")
        CallFromType = "Sub"
        CallFrom = "SetTodaysPackages"
        Try
            Dim DisplayCols As String = ""
            If Not chkAllColumns.Checked Then
                DisplayCols = "ScheduleID:68;ExecutionStatus:90;ScheduleOwnerUserID:118;ScheduleName:150;NextExecutionDate:110;LastExecutionDate:115;RecurrenceFreqType:110;ReportID:55;ReportNumber:90;ReportName:150;SQLCommand:175;ReportFormat:90;PrimaryFileLocation:150"
            Else
                DisplayCols = "ScheduleID:68;ExecutionStatus:90;ApplicationID:75;TreeLevelID:68;ScheduleName:150;ScheduleStatus75;ScheduleOwnerUserID:118;RecurrenceFreqType:110;RecurrenceFreq1:110;RecurrenceFreq2:110;RecurrenceReportSpanType:150;RecurrenceReportSpan1:130;RecurrenceReportSpan2:130;RecurrenceStartDate:120;RecurrenceEndDate:120;RecurrenceTimesToExecute:150;CreatedDate:110;ModifiedDate:110;ExecutionCount:90;NextExecutionDate;LastExecutionDate:110;SortOrder:68;IsMultiWorkbook:90;TabIndex:68;TabName:75;ReportID:68;ReportName:150;ReportTitle:150;ReportNumber:100;SQLCommand:175;UseTabs:68;PrimaryFileLocation:150;ReportFileName:125;IsStatic:68;ReportFormat:90"
            End If
            SetDisplayedPackages(UseTodaysPackages, DisplayCols, False, "Packages that are Scheduled for Today")

        Catch ex As Exception
            EmailErrorAlert(gDatabaseConnection, ex.Message, gUserID, gApplicationName, gApplicationVersion, gUserID, CallFromType, CallFrom, gWorkstationID, gOsName)
        End Try
    End Sub

    Private Sub SetDisplayedPackages(ByVal PackageTableName As String, Optional ByVal DisplayCols As String = "", Optional ByVal AutoResizeColumns As Boolean = False, Optional ByVal SetLabel As String = "", Optional ByVal SetHighlightExecuted As Boolean = True)
        CallFromType = "Sub"
        CallFrom = "SetDisplayedPackages"
        Try
            PopulateGrid(dgvPackages, PackageTableName, DisplayCols, AutoResizeColumns)
            SetReportPendingCount()
            If SetHighlightExecuted Then HighlightExecuted()
            If SetLabel <> "" Then SetStatusLabel2(SetLabel)
        Catch ex As Exception
            EmailErrorAlert(gDatabaseConnection, ex.Message, gUserID, gApplicationName, gApplicationVersion, gUserID, CallFromType, CallFrom, gWorkstationID, gOsName)
        End Try
    End Sub

    Private Sub PopulateGrid(ByVal dgv As DataGridView, ByVal DS_TableName As String, Optional ByVal DisplayColumns As String = "", Optional ByVal AutoResizeColumns As Boolean = False)
        CallFromType = "Sub"
        CallFrom = "PopulateGrid"
        Try
            dgv.DataSource = Nothing
            dgv.DataSource = dsSR.Tables(DS_TableName)
            If AutoResizeColumns Then dgv.AutoResizeColumns()
            SelectColumnsToDisplayInGrid(dgv, DisplayColumns)
            dgv.ClearSelection()
        Catch ex As Exception
            EmailErrorAlert(gDatabaseConnection, ex.Message, gUserID, gApplicationName, gApplicationVersion, gUserID, CallFromType, CallFrom, gWorkstationID, gOsName)
        End Try
    End Sub

    Private Sub SetReportPendingCount(Optional CountExecOverride As Integer = 0)
        Dim CountExecuted As Integer = CountExecOverride
        Dim LabelText As String = ""
        If CountExecOverride = 0 Then
            For Each gr As DataGridViewRow In dgvPackages.Rows
                If gr.Cells("ExecutionStatus").Value = "EXECUTED" Then
                    CountExecuted += 1
                End If
            Next
        End If
        LabelText = CountExecuted.ToString + " of " + dgvPackages.Rows.Count.ToString + " Reports are Complete."
        SetStatusLabel1(LabelText)
    End Sub

    Private Sub HighlightExecuted()
        For Each row As DataGridViewRow In dgvPackages.Rows
            If row.Cells("ExecutionStatus").Value = "EXECUTED" Then
                row.DefaultCellStyle.BackColor = Color.Gainsboro
            End If
        Next
    End Sub

    Private Sub SetStatusLabel1(ByVal Text As String)
        ToolStripStatusLabel1.Text = Text
    End Sub

    Private Sub SetStatusLabel2(ByVal Text As String)
        ToolStripStatusLabel2.Text = Text
        If chkAllColumns.Checked Then ToolStripStatusLabel1.Text += "   [Showing all columns]"
    End Sub

    Private Sub SelectColumnsToDisplayInGrid(ByVal dgv As DataGridView, ByVal DisplayColumns As String, Optional ByVal Delimiter As String = ";")
        CallFromType = "Sub"
        CallFrom = "SelectColumnsToDisplayInGrid"
        Try
            '--- Select specific columns to display.   ---
            If DisplayColumns <> "" Then
                Dim DisplayColumnsArray() As String = DisplayColumns.Split(";")  '<-- Get columns to display
                HideAllColumnsInGrid(dgv)                           '<-- First, hide all columns
                For Each col As DataGridViewColumn In dgv.Columns   '<-- Now, go through each column and only display the Columns listed in DisplayColumns
                    For Each colName As String In DisplayColumnsArray
                        If InStr(colName, ":") > 0 Then
                            Dim colParams() As String = colName.Split(":")
                            If col.Name = colParams(0) Then
                                col.Visible = True
                                col.Width = CInt(colParams(1))
                            End If
                        Else
                            If col.Name = colName Then col.Visible = True
                        End If
                    Next
                Next
            End If
        Catch ex As Exception
            EmailErrorAlert(gDatabaseConnection, ex.Message, gUserID, gApplicationName, gApplicationVersion, gUserID, CallFromType, CallFrom, gWorkstationID, gOsName)
        End Try
    End Sub

    Private Sub HideAllColumnsInGrid(ByVal dgv As DataGridView, Optional ByVal HideColumns As Boolean = True)
        CallFromType = "Sub"
        CallFrom = "HideAllColumnsInGrid"
        Try
            For Each col As DataGridViewColumn In dgv.Columns
                col.Visible = Not HideColumns
            Next
        Catch ex As Exception
            EmailErrorAlert(gDatabaseConnection, ex.Message, gUserID, gApplicationName, gApplicationVersion, gUserID, CallFromType, CallFrom, gWorkstationID, gOsName)
        End Try
    End Sub

    Private Sub SetAllPackages(Optional ByVal UseAllPackages As String = "AllPackages")
        CallFromType = "Sub"
        CallFrom = "SetAllPackages"
        Try
            Dim DisplayCols As String = ""
            If Not chkAllColumns.Checked Then
                DisplayCols = "ScheduleID:68;ExecutionStatus:90;ScheduleOwnerUserID:118;ScheduleName:150;NextExecutionDate:110;LastExecutionDate:115;RecurrenceFreqType:110;ReportID:55;ReportNumber:90;ReportName:150;SQLCommand:175;ReportFormat:90;PrimaryFileLocation:150"
            Else
                DisplayCols = "ScheduleID:68;ExecutionStatus:90;ApplicationID:75;TreeLevelID:68;ScheduleName:150;ScheduleStatus75;ScheduleOwnerUserID:118;RecurrenceFreqType:110;RecurrenceFreq1:110;RecurrenceFreq2:110;RecurrenceReportSpanType:150;RecurrenceReportSpan1:130;RecurrenceReportSpan2:130;RecurrenceStartDate:120;RecurrenceEndDate:120;RecurrenceTimesToExecute:150;CreatedDate:110;ModifiedDate:110;ExecutionCount:90;NextExecutionDate;LastExecutionDate:110;SortOrder:68;IsMultiWorkbook:90;TabIndex:68;TabName:75;;ReportID:68;ReportName:150;ReportTitle:150;ReportNumber:100;SQLCommand:175;UseTabs:68;PrimaryFileLocation:150;ReportFileName:125;IsStatic:68;ReportFormat:90"
            End If
            SetDisplayedPackages(UseAllPackages, DisplayCols, False, "All Packages")
        Catch ex As Exception
            EmailErrorAlert(gDatabaseConnection, ex.Message, gUserID, gApplicationName, gApplicationVersion, gUserID, CallFromType, CallFrom, gWorkstationID, gOsName)
        End Try
    End Sub

    Private Sub PopulateDetailGrids(Optional ByVal ScheduleID As Integer = 0, Optional ByVal UserId As String = "") ', Optional ByVal UniqueUserID As String = "")
        CallFromType = "Sub"
        CallFrom = "PopulateDetailGrids"
        Cursor = Cursors.WaitCursor
        Try
            If Not splScheduledReports.Panel2Collapsed Then
                If dgvPackages.SelectedRows.Count > 0 Then
                    If ScheduleID = 0 Then
                        ScheduleID = dgvPackages.SelectedRows(0).Cells("ScheduleID").Value
                    End If
                    If UserId = "" Then
                        UserId = dgvPackages.SelectedRows(0).Cells("ScheduleOwnerUserID").Value
                    End If
                    GetScheduleEmailRecipientList(ScheduleID, UserId)
                    GetScheduleReportParams(ScheduleID)
                    PopulateGrid(dgvEmails, "EmailRecipientList", "LanID;Email", True)
                    PopulateGrid(dgvReportParams, "ReportParams", "", True)
                End If
            End If

        Catch ex As Exception
            EmailErrorAlert(gDatabaseConnection, ex.Message, gUserID, gApplicationName, gApplicationVersion, gUserID, CallFromType, CallFrom, gWorkstationID, gOsName)
        End Try
        Cursor = Cursors.Default
    End Sub

    Public Sub GetScheduleEmailRecipientList(ByVal ScheduleID As Integer, ByVal UserID As String)
        CallFromType = "Sub"
        CallFrom = "GetScheduleEmailRecipientList"
        Try
            Dim sql As String = "exec dbo.sSchedule_GetEmailList '" + UserID + "', " + ScheduleID.ToString
            dsSR.BuildTable(sql, gDatabaseConnection.ConnectionString, "EmailRecipientList")
        Catch ex As Exception
            EmailErrorAlert(gDatabaseConnection, ex.Message, gUserID, gApplicationName, gApplicationVersion, gUserID, CallFromType, CallFrom, gWorkstationID, gOsName)
        End Try
    End Sub

    Public Function GetScheduleReportParams(ByVal ScheduleID As Integer) As DataRow()
        CallFromType = "Sub"
        CallFrom = "GetScheduleReportParams"
        Dim errReturn As String = ""
        Dim dRows As DataRow() = Nothing
        Try
            Dim sql As String = "exec dbo.sSchedule_GetParams " + ScheduleID.ToString + ", 1"

            dsSR.BuildTable(sql, gDatabaseConnection.ConnectionString, "ReportParams", errReturn, False)
            If errReturn <> "" Then
            End If

            sql = "exec dbo.sSchedule_InsertToReportParams " + ScheduleID.ToString + ", 1"
            dsSR.BuildTable(sql, gDatabaseConnection.ConnectionString, "ReportParamsDates", errReturn, False)

            Dim nRow As Integer
            With dsSR.Tables("ReportParams")
                For Each drow As DataRow In dsSR.Tables("ReportParamsDates").Rows
                    nRow = .Rows.IndexOf(.Rows.Add)
                    .Rows(nRow).Item("ParamValue") = drow.Item("ParamValue")
                    .Rows(nRow).Item("ParamText") = drow.Item("ParamText")
                    .Rows(nRow).Item("ParamType") = drow.Item("ParamType")
                Next
            End With

            dRows = dsSR.Tables("ReportParams").Select
        Catch ex As Exception
            EmailErrorAlert(gDatabaseConnection, ex.Message, gUserID, gApplicationName, gApplicationVersion, gUserID, CallFromType, CallFrom, gWorkstationID, gOsName)
        End Try
        Return dRows
    End Function

    Private Sub ReadScheduleReportPathINI()
        CallFromType = "Sub"
        CallFrom = "ReadScheduleReportPathINI"
        '--- Get current connection information and build ConnectionStr ---
        Dim fileReader As System.IO.StreamReader = Nothing
        Dim str As String
        Dim equalPos As Integer = 0
        Try
            If File.Exists(iniReportPath) Then
                fileReader = My.Computer.FileSystem.OpenTextFileReader(iniReportPath)
                While Not fileReader.EndOfStream
                    str = fileReader.ReadLine()
                    '--- Allow for comment line ---
                    If Strings.Left(str, 1) = "'" Then Continue While
                    cboReportPath.Items.Add(str)
                End While
            End If
        Catch ex As Exception
            EmailErrorAlert(gDatabaseConnection, ex.Message, gUserID, gApplicationName, gApplicationVersion, gUserID, CallFromType, CallFrom, gWorkstationID, gOsName)
        End Try
        If fileReader IsNot Nothing Then fileReader.Close()
    End Sub

    Private Sub BuildScheduleReportsLocationDropdown()
        CallFromType = "Sub"
        CallFrom = "BuildScheduleReportsLocationDropdown"
        cboReportPath.Items.Clear()

        '--- First, Add the default path ---
        cboReportPath.Items.Add(gScheduledReportsPath)

        '--- Second, Add any additional paths saved locally ---
        ReadScheduleReportPathINI()

        '--- Set the current path to the first one in the list.  This would be the original default path. ---
        cboReportPath.SelectedIndex = 0
    End Sub

    Private Sub tmrProcessBox_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrProcessBox.Tick
        Select Case Label1.Text
            Case "-"
                Label1.Text = "\"
            Case "\"
                Label1.Text = "/"
            Case "/"
                Label1.Text = "-"
        End Select
    End Sub

    Private Sub dgvPackages_RowEnter(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvPackages.RowEnter
        PopulateDetailGrids()
    End Sub

    Private Sub splScheduledReports_Resize(sender As Object, e As System.EventArgs) Handles splScheduledReports.Resize
        Try
            If Me.WindowState <> FormWindowState.Minimized Then
                splScheduledReports.SplitterDistance = splScheduledReports.Height - SpltrOffset
            End If
        Catch ex As Exception
        End Try
    End Sub

End Class