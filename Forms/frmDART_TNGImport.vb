Imports System.Data

Public Class frmDART_TNGImport
    Private sqlCmd As System.Data.SqlClient.SqlCommand
    Private modifyingBadZipDirectory As Boolean
    Private modifyingErrorLogDirectory As Boolean
    Private saveBadZipDirectory As String
    Private saveErrorLogDirectory As String
    Private modifyingImportedThruDate As Boolean
    Private saveImportedThruDate As String
    Private ErrorLogCount As Integer

    Private Sub frmDARTImport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Cursor = Cursors.WaitCursor  ' Barry

        pnlPrimaryContent.Visible = False
        LoadForm(Me, e) 'LAshby 2/27/18 created new routine in modGeneral to replace redundant frmLoad code in most forms

        dtpStartDate.Text = Now.AddDays(-1).ToShortDateString
        dtpStartTime.Text = Now.AddDays(-1).ToLongTimeString

        dtpEndDate.Text = Now.ToShortDateString
        dtpEndTime.Text = Now.ToLongTimeString
        If btnConnect.Enabled Then
            btnConnect_Click(sender, e)
        End If
        HandleFormResize()
        Timer1.Enabled = True

        Me.Cursor = Cursors.Default ' Barry
    End Sub

    Private Sub btnConnect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConnect.Click
        Dim GoodConn As Boolean
        GoodConn = ChangeConnection(Me, e) 'LAshby 2/27/18 created new routine in modGeneral to replace redundant btnConnect_Click code in most forms
        If GoodConn = True Then
            PopulateForm()
        End If
    End Sub

    Private Sub PopulateForm()
        ReadDDIMImportSettings()
        RefreshData()
        'PopulateImportLogGrid()
        'PopulateReportTypes()
        'PopulatePostImportCalcsGrid()
        'PopulateMonthlyCompilesGrid()
    End Sub

    Private Sub RefreshData()
        Me.Cursor = Cursors.WaitCursor
        RefreshBadZipFiles() ' Modified for DART Upgrade 2021
        RefreshImportedThruDate()
        RefreshErrorLogFiles()  ' Modified for DART Upgrade 2021
        PopulateImportLogGrid()
        PopulateReportTypes()
        PopulatePostImportCalcsGrid()
        PopulateMonthlyCompilesGrid()
        HandleControls()
        Me.Cursor = Cursors.Default

    End Sub

    Private Sub ReadDDIMImportSettings()
        Me.Cursor = Cursors.WaitCursor

        txtBadZipDirectory.Text = ""
        sqlCmd = New System.Data.SqlClient.SqlCommand
        sqlCmd.CommandTimeout = 0
        sqlCmd.CommandText = "DARTPro.dbo.sDDIM_ImportSettingsGet"
        sqlCmd.CommandType = CommandType.Text
        sqlCmd.Connection = gDatabaseConnection
        Dim reader As SqlClient.SqlDataReader
        Try
            gDatabaseConnection.Open()
            reader = sqlCmd.ExecuteReader()
            reader.Read()
            If reader.HasRows Then
                If reader.GetSqlString(reader.GetOrdinal("BadZipDirectory")).IsNull Then
                    txtBadZipDirectory.Text = ""
                Else
                    If Microsoft.VisualBasic.Left(reader.GetSqlString(reader.GetOrdinal("BadZipDirectory")).ToString, 2) = "\\" Then
                        txtBadZipDirectory.Text = reader.GetSqlString(reader.GetOrdinal("BadZipDirectory"))
                    Else
                        txtBadZipDirectory.Text = "\\" & cboServer.Text & reader.GetSqlString(reader.GetOrdinal("BadZipDirectory")).ToString.Substring(2, Len(reader.GetSqlString(reader.GetOrdinal("BadZipDirectory")).ToString) - 2)
                    End If
                End If
                If reader.GetSqlString(reader.GetOrdinal("ErrorLogDirectory")).IsNull Then
                    txtErrorLogDirectory.Text = ""
                Else
                    txtErrorLogDirectory.Text = reader.GetSqlString(reader.GetOrdinal("ErrorLogDirectory"))

                    If Microsoft.VisualBasic.Left(reader.GetSqlString(reader.GetOrdinal("ErrorLogDirectory")).ToString, 2) = "\\" Then
                        txtErrorLogDirectory.Text = reader.GetSqlString(reader.GetOrdinal("ErrorLogDirectory"))
                    Else
                        txtErrorLogDirectory.Text = "\\" & cboServer.Text & reader.GetSqlString(reader.GetOrdinal("ErrorLogDirectory")).ToString.Substring(2, Len(reader.GetSqlString(reader.GetOrdinal("ErrorLogDirectory")).ToString) - 2)
                    End If
                End If
            Else
                Me.Cursor = Cursors.Default
                MessageBox.Show("An error occurred while executing the procedure 'sDDIMImportSettingsGet' which retrieves data utilized by DDIM (DART Data Import Manager)." + vbNewLine + vbNewLine + "Please be sure that the table tDDIMImportSettings and the stored procedure sDDIMImportSettingsGet both exist on this server.", "Can't obtain import info", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txtBadZipDirectory.Text = "< error >"
            End If
        Catch sqlex As SqlClient.SqlException
            DisplayUnexpectedSQLException(sqlex)
        Finally
            gDatabaseConnection.Close()
            sqlCmd = Nothing
        End Try

        Me.Cursor = Cursors.Default
    End Sub



    Private Sub RefreshBadZipFiles()

        '2021.09.21: Modified to include the file count in a try/catch block. Added a With statement for code clarity - Barry Seymour
        If gDatabaseConnection.DataSource Like "SQWDART?001" Then
            'We're using a SQL 2019 server behind the DMZ. We can't see the shared folder. Make a SQL Call
            Dim reader As SqlClient.SqlDataReader
            Dim FileCount As Integer = 0

            sqlCmd = New System.Data.SqlClient.SqlCommand
            With sqlCmd
                .CommandTimeout = 0
                .CommandText = "DDT_Common.dbo.sDDIM_FileCount"
                .CommandType = CommandType.StoredProcedure
                .Parameters.AddWithValue("@FileType", "BadZip")
                .Connection = gDatabaseConnection
            End With

            Try
                gDatabaseConnection.Open()
                reader = sqlCmd.ExecuteReader()
                reader.Read()
                If reader.HasRows Then
                    FileCount = reader.GetSqlInt32(1)  ' get the value of the second column in the result set 
                Else
                    FileCount = 0
                End If

            Catch MyEx As Exception
                MessageBox.Show(caption:="Error in RefreshBadZipFiles", text:="Error in frmDART_TNGImport.RefreshBadZipFiles: " & MyEx.Message, buttons:=MessageBoxButtons.OK, icon:=MessageBoxIcon.Exclamation)
            Finally
                gDatabaseConnection.Close()
            End Try


        ElseIf gDatabaseConnection.DataSource Like "SQWDART?01" Then
            'We're using a SQL 2016 server with available file shares. We can get the file count right from the server.
            Try
                With My.Computer.FileSystem

                    If Not .DirectoryExists(txtBadZipDirectory.Text) Then
                        MessageBox.Show(Me, "Unable to access 'Bad Zip' Directory " & txtBadZipDirectory.Text & ".", "Can't Access Directory", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Else
                        lblBadZipDirectoryFileCount.Text = "Files found in bad zip directory : " + .GetFiles(txtBadZipDirectory.Text).Count.ToString()

                        If .GetFiles(txtBadZipDirectory.Text).Count = 0 Then
                            statusBadzipFiles.ImageIndex = 0
                            tbpgOther.ImageIndex = 0
                        Else
                            statusBadzipFiles.ImageIndex = 1
                            tbpgOther.ImageIndex = 1
                        End If
                    End If
                End With ' My.Computer.FileSystem

            Catch ex As Exception
                DisplayUnexpectedGeneralError(ex)
            End Try

        End If


    End Sub

    Private Sub RefreshErrorLogFiles()
        '2021.09.21: If on a NEW 00 server, execute SQL to get the log file count.
        If gDatabaseConnection.DataSource Like "SQWDART?001" Then ' SQL 2019, behind the DMZ
            'We're using a SQL 2019 server behind the DMZ. We can't see the shared folder. Make a SQL Call
            Dim reader As SqlClient.SqlDataReader
            Dim FileCount As Integer = 0

            sqlCmd = New System.Data.SqlClient.SqlCommand
            With sqlCmd
                .CommandTimeout = 0
                .CommandText = "DDT_Common.dbo.sDDIM_FileCount"
                .CommandType = CommandType.StoredProcedure
                .Parameters.AddWithValue("@FileType", "ErrorLogs")
                .Connection = gDatabaseConnection
            End With

            Try
                gDatabaseConnection.Open()
                reader = sqlCmd.ExecuteReader()
                reader.Read()
                If reader.HasRows Then
                    FileCount = reader.GetSqlInt32(1)  ' get the value of the second column in the result set 
                Else
                    FileCount = 0
                End If

            Catch MyEx As Exception
                MessageBox.Show(caption:="Error in RefreshBadZipFiles", text:="Error in frmDART_TNGImport.RefreshBadZipFiles: " & MyEx.Message, buttons:=MessageBoxButtons.OK, icon:=MessageBoxIcon.Exclamation)
            Finally
                gDatabaseConnection.Close()
            End Try

        ElseIf gDatabaseConnection.DataSource Like "SQWDART?01" Then ' SQL 2016. Read the folder.
            Try
                ErrorLogCount = 0
                For Each foundFile As String In My.Computer.FileSystem.GetFiles(txtErrorLogDirectory.Text)
                    Dim aFileName = Strings.Right(foundFile, foundFile.Length - InStrRev(foundFile, "\"))
                    If Strings.Left(aFileName, 10) = "importerrs" And Strings.Right(aFileName, 4) = ".log" Then ErrorLogCount += 1
                Next

                If ErrorLogCount = 0 Then
                    statusErrorLog.ImageIndex = 0
                    tbpgOther.ImageIndex = 0
                Else
                    statusErrorLog.ImageIndex = 1
                    tbpgOther.ImageIndex = 1
                End If
                lblErrorLogDirectoryFileCount.Text = "Files found in error log directory : " + ErrorLogCount.ToString()
            Catch ex As Exception
                DisplayUnexpectedGeneralError(ex)
            End Try

        End If

    End Sub

    Private Sub HandleControls()
        btnBadZipDirectoryRefresh.Enabled = Not modifyingBadZipDirectory
        tabImportMonitor.Enabled = (Not modifyingBadZipDirectory And txtBadZipDirectory.TextLength > 0)

        btnErrorLogDirectoryRefresh.Enabled = Not modifyingErrorLogDirectory
        btnErrorLogDirectoryExplore.Enabled = (Not modifyingErrorLogDirectory And txtErrorLogDirectory.TextLength > 0)

        lblImportedThruWorkOfDate.Visible = Not modifyingImportedThruDate
        dtpImportedThruWorkOfDate.Visible = modifyingImportedThruDate
        btnOverrideImportedThruWorkOfDateCancel.Visible = modifyingImportedThruDate
        btnOverrideImportedThruWorkOfDateRefresh.Enabled = Not modifyingImportedThruDate
        btnRefresh.Enabled = Not modifyingBadZipDirectory And Not modifyingImportedThruDate
    End Sub

    Private Sub txtBadZipDirectory_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        HandleControls()
    End Sub

    Private Sub btnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefresh.Click
        RefreshData()
    End Sub


    Private Sub RefreshImportedThruDate()
        sqlCmd = New System.Data.SqlClient.SqlCommand
        With sqlCmd
            .CommandTimeout = 0
            .CommandText = "DARTPro.dbo.sGetImportStatus"
            .CommandType = CommandType.StoredProcedure
            .Connection = gDatabaseConnection
        End With
        Try
            gDatabaseConnection.Open()
            Dim reader As SqlClient.SqlDataReader
            reader = sqlCmd.ExecuteReader()
            reader.Read()
            If reader.HasRows Then
                If reader.GetSqlDateTime(reader.GetOrdinal("ImportedThruWorkDate")).IsNull Then
                    lblImportedThruWorkOfDate.Text = ""
                Else
                    Dim aDate As Date
                    aDate = reader.GetSqlDateTime(reader.GetOrdinal("ImportedThruWorkDate"))
                    lblImportedThruWorkOfDate.Text = aDate.ToShortDateString
                End If
                dtpImportedThruWorkOfDate.Text = lblImportedThruWorkOfDate.Text
            Else
                Me.Cursor = Cursors.Default
                MessageBox.Show("An error occurred while executing the procedure 'sGetImportStatus' which retrieves data utilized by DDIM (DART Data Import Manager)." + vbNewLine + vbNewLine + "Please be sure that the table tDDIMImportSettings and the stored procedure sDDIMImportSettingsGet both exist on this server.", "Can't obtain import info", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                lblImportedThruWorkOfDate.Text = "< error >"
                dtpImportedThruWorkOfDate.Text = ""
            End If
        Catch sqlex As SqlClient.SqlException
            DisplayUnexpectedSQLException(sqlex)
        Finally
            gDatabaseConnection.Close()
            sqlCmd = Nothing
        End Try
    End Sub

    Private Sub HandleImportedThruDateSave()
        Me.Cursor = Cursors.WaitCursor
        sqlCmd = New System.Data.SqlClient.SqlCommand
        sqlCmd.CommandText = "exec DARTPro.dbo.sUpdateImportStatusDate '" + lblImportedThruWorkOfDate.Text + "'"
        sqlCmd.CommandType = CommandType.Text
        sqlCmd.Connection = gDatabaseConnection
        Try
            gDatabaseConnection.Open()
            sqlCmd.ExecuteNonQuery()
        Catch sqlex As SqlClient.SqlException
            Me.Cursor = Cursors.Default
            DisplayUnexpectedSQLException(sqlex)
        Finally
            gDatabaseConnection.Close()
            sqlCmd = Nothing
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub btnOverrideImportedThruWorkOfDate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOverrideImportedThruWorkOfDate.Click
        modifyingImportedThruDate = Not modifyingImportedThruDate
        If modifyingImportedThruDate Then
            btnOverrideImportedThruWorkOfDate.Text = "Save"
            saveImportedThruDate = lblImportedThruWorkOfDate.Text
        Else
            btnOverrideImportedThruWorkOfDate.Text = "Override"
            lblImportedThruWorkOfDate.Text = dtpImportedThruWorkOfDate.Text
            HandleImportedThruDateSave()
        End If
        HandleControls()
    End Sub

    Private Sub btnOverrideImportedThruWorkOfDateCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOverrideImportedThruWorkOfDateCancel.Click
        modifyingImportedThruDate = False
        btnOverrideImportedThruWorkOfDate.Text = "Override"
        lblImportedThruWorkOfDate.Text = saveImportedThruDate
        dtpImportedThruWorkOfDate.Text = saveImportedThruDate
        HandleControls()
    End Sub

    Private Sub lblImportedThruWorkOfDate_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblImportedThruWorkOfDate.TextChanged
        If lblImportedThruWorkOfDate.Text = "" Then
            statusImportedThruDate.ImageIndex = 1
        Else
            If Now.AddDays(-1).ToShortDateString = lblImportedThruWorkOfDate.Text Then
                statusImportedThruDate.ImageIndex = 0
            Else
                statusImportedThruDate.ImageIndex = 1
            End If
        End If
        tbpgOther.ImageIndex = statusImportedThruDate.ImageIndex
    End Sub

    Private Sub PopulateImportLogGrid()
        Me.Cursor = Cursors.WaitCursor

        Dim adapter As New SqlClient.SqlDataAdapter
        Dim sql As String = ""
        Try
            dgvImportReportTypes.DataSource = Nothing
            If rdoLogRelativeToFileCreation.Checked = True Then
                sql = "exec DARTPro.dbo.sGetImportFileStats '" & dtpStartDate.Value.ToShortDateString + " " + dtpStartTime.Value.ToLongTimeString & "','" & dtpEndDate.Value.ToShortDateString + " " + dtpEndTime.Value.ToLongTimeString & "', 0"
            Else
                sql = "exec DARTPro.dbo.sGetImportFileStats '" & dtpStartDate.Value.ToShortDateString + " " + dtpStartTime.Value.ToLongTimeString & "','" & dtpEndDate.Value.ToShortDateString + " " + dtpEndTime.Value.ToLongTimeString & "', 1"
            End If

            sqlCmd = New System.Data.SqlClient.SqlCommand
            sqlCmd.CommandTimeout = 0
            sqlCmd.CommandText = sql
            sqlCmd.CommandType = CommandType.Text
            sqlCmd.Connection = gDatabaseConnection
            adapter.SelectCommand = sqlCmd

            Dim table As DataTable = dsroot.Tables("ImportStats")
            If (dsroot.Tables.CanRemove(table)) Then
                dsroot.Tables.Remove(table)
            End If
            adapter.Fill(dsroot, "ImportStats")
            dgvImportLog.DataSource = dsroot.Tables("ImportStats")
            sql = ""
        Catch sqlex As SqlClient.SqlException
            DisplayUnexpectedSQLException(sqlex)
        Finally
            gDatabaseConnection.Close()
        End Try

        Dim i As Integer
        Dim TotalElapsedTime As Long
        Dim TotalSize As Long
        Dim TotalErrors As Long

        With dgvImportLog
            While i <= .Rows.Count - 1
                TotalElapsedTime += .Rows(i).Cells("ImportElapsedSeconds").Value
                TotalSize += .Rows(i).Cells("TextFileSize").Value
                TotalErrors += .Rows(i).Cells("ErrorCount").Value
                i += 1
            End While
        End With

        lblImportLogRecordCount.Text = "[Files : " + dgvImportLog.Rows.Count.ToString + "]"

        Dim tempElapsedSeconds As Long = TotalElapsedTime
        Dim TotalHours As Integer = tempElapsedSeconds \ 3600
        tempElapsedSeconds += -TotalHours * 3600
        Dim TotalMinutes As Integer = tempElapsedSeconds \ 60
        Dim TotalSeconds As Integer = tempElapsedSeconds Mod 60

        lblImportLogRecordCount.Text += "   [Elapsed time : " + TotalHours.ToString + "h " + TotalMinutes.ToString + "m " + TotalSeconds.ToString + "s]" '(CInt(TotalElapsedTime / 3600)).ToString + "h " + (CInt(TotalElapsedTime / 60) Mod 60).ToString + "m " + (TotalElapsedTime Mod 60).ToString + "s]"
        lblImportLogRecordCount.Text += "   [Size : " + Format(TotalSize / 1024 / 1024, "0.00") + " MB]"
        lblImportLogRecordCount.Text += "   [Errors : " + TotalErrors.ToString + "]"

        HandleControls()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub PopulatePostImportCalcsGrid()
        Me.Cursor = Cursors.WaitCursor
        Dim ProcessType As String = "PostImportCalcs"

        Dim adapter As New SqlClient.SqlDataAdapter
        Dim sql As String = ""
        Try
            dgvPostImportCalcs.DataSource = Nothing
            sql = "DDT_Common.dbo.sToolbox_GetPostImportProcesses '" & ProcessType & "'"

            sqlCmd = New System.Data.SqlClient.SqlCommand
            sqlCmd.CommandTimeout = 0
            sqlCmd.CommandText = sql
            sqlCmd.CommandType = CommandType.Text
            sqlCmd.Connection = gDatabaseConnection
            adapter.SelectCommand = sqlCmd

            Dim table As DataTable = dsroot.Tables("PostImportProcesses")
            If (dsroot.Tables.CanRemove(table)) Then
                dsroot.Tables.Remove(table)
            End If
            adapter.Fill(dsroot, "PostImportProcesses")
            dgvPostImportCalcs.DataSource = dsroot.Tables("PostImportProcesses")
            sql = ""

            'Color non-logged items yellow
            For Each dgvRow As DataGridViewRow In dgvPostImportCalcs.Rows
                If dgvRow.Cells("LogDate").Value.ToString = "" Then
                    dgvRow.DefaultCellStyle.BackColor = Color.Yellow
                Else
                    dgvRow.DefaultCellStyle.BackColor = Color.White
                End If
            Next

        Catch sqlex As SqlClient.SqlException
            DisplayUnexpectedSQLException(sqlex)
        Finally
            gDatabaseConnection.Close()
        End Try

        HandleControls()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub PopulateMonthlyCompilesGrid()
        Me.Cursor = Cursors.WaitCursor
        Dim ProcessType As String = "Compiles"

        Dim adapter As New SqlClient.SqlDataAdapter
        Dim sql As String = ""
        Try
            dgvCompiles.DataSource = Nothing
            sql = "DDT_Common.dbo.sToolbox_GetPostImportProcesses '" & ProcessType & "'"

            sqlCmd = New System.Data.SqlClient.SqlCommand
            sqlCmd.CommandTimeout = 0
            sqlCmd.CommandText = sql
            sqlCmd.CommandType = CommandType.Text
            sqlCmd.Connection = gDatabaseConnection
            adapter.SelectCommand = sqlCmd

            Dim table As DataTable = dsroot.Tables("MonthlyCompiles")
            If (dsroot.Tables.CanRemove(table)) Then
                dsroot.Tables.Remove(table)
            End If
            adapter.Fill(dsroot, "MonthlyCompiles")
            dgvCompiles.DataSource = dsroot.Tables("MonthlyCompiles")
            sql = ""


            'Color non-logged items yellow
            For Each dgvRow As DataGridViewRow In dgvCompiles.Rows
                If dgvRow.Cells("LogDate").Value.ToString = "" Then
                    dgvRow.DefaultCellStyle.BackColor = Color.Yellow
                Else
                    dgvRow.DefaultCellStyle.BackColor = Color.White
                End If
            Next

        Catch sqlex As SqlClient.SqlException
            DisplayUnexpectedSQLException(sqlex)
        Finally
            gDatabaseConnection.Close()
        End Try

        HandleControls()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub btnRefreshStatus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOverrideImportedThruWorkOfDateRefresh.Click
        RefreshImportedThruDate()
    End Sub

    Private Sub btnBadZipDirectoryRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBadZipDirectoryRefresh.Click
        RefreshBadZipFiles()
    End Sub

    Private Sub frmDARTImport_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        HandleFormResize()
    End Sub

    Private Sub HandleFormResize()
        tabImportMonitor.Width = Me.Width - 6 '14
        tabImportMonitor.Height = Me.Height - 72

        tabImportsAndCalcs.Width = tabImportMonitor.Width - 28 '13
        tabImportsAndCalcs.Height = tabImportMonitor.Height - 101 '91

        dgvImportLog.Width = tabImportsAndCalcs.Width - 8
        dgvImportLog.Height = tabImportsAndCalcs.Height - 47

        btnViewUnzipLog.Top = dgvImportLog.Top + dgvImportLog.Height
        btnViewUnzipLog.Left = dgvImportLog.Left + dgvImportLog.Width - btnViewUnzipLog.Width

        dgvImportReportTypes.Width = tabImportMonitor.Width - 10
        dgvImportReportTypes.Height = tabImportMonitor.Height - 32

        lblImportLogRecordCount.Top = dgvImportLog.Top + dgvImportLog.Height + 5

        btnRefresh.Left = Me.Width - (btnRefresh.Width + 12)
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs)
        btnRefresh_Click(sender, e)
    End Sub

    Private Sub btnRefreshImportLog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefreshImportLog.Click
        If chkRefreshToNow.Checked Then btnImportLogNow_Click(sender, e)
        PopulateImportLogGrid()
    End Sub

    Private Sub dgvImportLog_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dgvImportLog.CellFormatting
        If dgvImportLog.Columns(e.ColumnIndex).Name = "colBytesRead" Then
            If Not (e.Value = 0 And dgvImportLog.Rows(e.RowIndex).Cells("colFileSize").Value = 1) And Not (Strings.Left(dgvImportLog.Rows(e.RowIndex).Cells("colImportType").Value.ToString, 10) = "Call Ahead" And dgvImportLog.Rows(e.RowIndex).Cells("colFileSize").Value = 567 And e.Value = 490) Then
                If CDec(e.Value) / CDec(dgvImportLog.Rows(e.RowIndex).Cells("colFileSize").Value) < 0.99 Then
                    e.CellStyle.BackColor = Color.Red
                End If
            End If
        End If

        If dgvImportLog.Columns(e.ColumnIndex).Name = "colErrors" Then
            If e.Value > 0 Then
                e.CellStyle.BackColor = Color.Red
            End If
        End If
    End Sub

    Private Sub btnImportLogNow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImportLogNow.Click
        dtpEndDate.Text = Now.ToShortDateString
        dtpEndTime.Text = Now.ToLongTimeString
    End Sub

    Private Sub Timer1_Tick_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        RefreshData()
    End Sub

    Private Sub PopulateReportTypes()
        Me.Cursor = Cursors.WaitCursor

        Dim adapter As New SqlClient.SqlDataAdapter
        Try
            dgvImportReportTypes.DataSource = Nothing
            Dim sql As String = "exec DARTPro.dbo.sDARTImportReportTypesRetrieve"

            sqlCmd = New System.Data.SqlClient.SqlCommand
            sqlCmd.CommandTimeout = 0
            sqlCmd.CommandText = sql
            sqlCmd.CommandType = CommandType.Text
            sqlCmd.Connection = gDatabaseConnection
            adapter.SelectCommand = sqlCmd

            Dim table As DataTable = dsroot.Tables("ReportTypes")
            If (dsroot.Tables.CanRemove(table)) Then
                dsroot.Tables.Remove(table)
            End If
            adapter.Fill(dsroot, "ReportTypes")
            dgvImportReportTypes.DataSource = dsroot.Tables("ReportTypes")
            sql = ""
        Catch sqlex As SqlClient.SqlException
            DisplayUnexpectedSQLException(sqlex)
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub dgvImportLog_DataBindingComplete(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewBindingCompleteEventArgs) Handles dgvImportLog.DataBindingComplete
        dgvImportLog.ClearSelection()
    End Sub

    Private Sub dgvImportReportTypes_DataBindingComplete(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewBindingCompleteEventArgs) Handles dgvImportReportTypes.DataBindingComplete
        dgvImportReportTypes.ClearSelection()
    End Sub

    Private Sub dgvCompiles_DataBindingComplete(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewBindingCompleteEventArgs) Handles dgvCompiles.DataBindingComplete
        dgvCompiles.ClearSelection()
    End Sub

    Private Sub dgvPostImportCalcs_DataBindingComplete(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewBindingCompleteEventArgs)
        dgvPostImportCalcs.ClearSelection()
    End Sub

    Private Sub btnErrorLogDirectoryRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnErrorLogDirectoryRefresh.Click
        RefreshErrorLogFiles()
    End Sub

    Private Sub ExploreButtonHandler(ByVal sender As Button, ByVal e As System.EventArgs) Handles btnBadZipDirectoryExplore.Click, btnErrorLogDirectoryExplore.Click
        'With the 2021 DART Upgrade project, servers are on the DMZ and cannot share files.
        'The functionality to explore server directories has changed. For new servers, the RemoteDesktop SSH client must be installed.
        'For old servers, Explorer.exe is sufficient.
        'This function was created to handle both button click events with a single code block. 
        '       - Barry Seymour Sept 2021

        If gDatabaseConnection.DataSource.ToUpper Like "SQWDART?001" Then
            'New Server. Use RemoteDesktop
            Dim RemoteDesktop As String = "c:\windows\system32\mstsc.exe"
            Dim MsgText As String

            MsgText = "You must use Remote Desktop to access files on the server. Click OK to run Remote Desktop."
            If MessageBox.Show(Me, MsgText, "Remote Desktop Required", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) = DialogResult.Cancel Then Return

            If My.Computer.FileSystem.FileExists(RemoteDesktop) Then
                Process.Start(RemoteDesktop)
            Else
                MsgText = "Error in frmDART_TNGImport.ExploreButtonHandler: The Remote Desktop Application was not found."
                MessageBox.Show(Me, MsgText, "Remote Desktop Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation)
            End If

        ElseIf gDatabaseConnection.DataSource.ToUpper Like "SQWDART?01" Then
            'Old Server. You can just explore the folder.
            Dim ExploreFolder As String = Nothing
            'which button was clicked?
            If sender Is btnBadZipDirectoryExplore Then
                ExploreFolder = txtBadZipDirectory.Text
            ElseIf sender Is btnErrorLogDirectoryExplore Then
                ExploreFolder = txtErrorLogDirectory.Text
            End If

            'Explore the folder
            Process.Start("explorer.exe", ExploreFolder)
        Else
            MessageBox.Show("Unknown Server", "Error in frmDART_TNGImport.ExploreButtonHandler: The server " & gDatabaseConnection.DataSource & " is not recognized.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If

    End Sub

End Class