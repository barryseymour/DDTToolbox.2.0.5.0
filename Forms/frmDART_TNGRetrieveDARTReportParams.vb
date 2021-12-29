Imports System.Data.SqlClient

Public Class frmDART_TNGRetrieveDARTReportParams
    Private sqlCmd As System.Data.SqlClient.SqlCommand

    Private Sub frmRetrieveDARTReportParams_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pnlPrimaryContent.Visible = False
        LoadForm(Me, e) 'LAshby 2/27/18 created new routine in modGeneral to replace redundant frmLoad code in most forms

        If btnConnect.Enabled Then
            btnConnect_Click(sender, e)
        End If
    End Sub

    Private Sub btnConnect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConnect.Click
        Dim GoodConn As Boolean
        GoodConn = ChangeConnection(Me, e) 'LAshby 2/27/18 created new routine in modGeneral to replace redundant btnConnect_Click code in most forms
        If GoodConn = True Then
            PopulateForm()
        Else
            dgvParameters.Rows.Clear()
            txtUniqueUserID.Text = ""
        End If
    End Sub

    Private Sub PopulateForm()
        Me.cboChoseServer.Enabled = False
        Me.btnCopyForTesting.Enabled = False
    End Sub

    Private Sub txtUniqueUserID_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtUniqueUserID.TextChanged
        btnRetrieveParameters.Enabled = (txtUniqueUserID.Text.Length > 0)
    End Sub

    Private Sub PopulateGrid()
        Me.Cursor = Cursors.WaitCursor
        If Not chkAppendResults.Checked Then
            dgvParameters.Rows.Clear()
            dgvParameters.Refresh()
        End If
        sqlCmd = New System.Data.SqlClient.SqlCommand
        sqlCmd.CommandTimeout = 0
        sqlCmd.CommandText = "exec dbo.sToolbox_DebugUserError '" + txtUniqueUserID.Text.Trim + "'"
        sqlCmd.CommandType = CommandType.Text
        sqlCmd.Connection = gDatabaseConnection
        Dim reader As SqlDataReader
        Try
            gDatabaseConnection.Open()
            reader = sqlCmd.ExecuteReader()
            Dim rowPos As Integer = 0
            While reader.Read
                With dgvParameters
                    .Rows.Insert(rowPos)
                    .Rows(rowPos).Cells("colUserID").Value = reader.GetSqlString(reader.GetOrdinal("UserID"))
                    .Rows(rowPos).Cells("colParamType").Value = reader.GetSqlString(reader.GetOrdinal("ParamType"))
                    .Rows(rowPos).Cells("colParamValue").Value = reader.GetSqlString(reader.GetOrdinal("ParamValue"))
                    .Rows(rowPos).Cells("colParamText").Value = reader.GetSqlString(reader.GetOrdinal("ParamText"))
                    rowPos += 1
                End With
            End While
        Catch sqlex As SqlClient.SqlException
            Me.Cursor = Cursors.Default
            DisplayUnexpectedSQLException(sqlex)
        Finally
            gDatabaseConnection.Close()
            sqlCmd = Nothing
            Me.Cursor = Cursors.Default
        End Try

    End Sub

    Private Sub btnRetrieveParameters_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRetrieveParameters.Click
        PopulateGrid()
        If dgvParameters.RowCount > 0 Then
            btnCopyForTesting.Enabled = True
            cboChoseServer.Enabled = True
            cboChoseServer.Text = cboServer.Text
        Else
            btnCopyForTesting.Enabled = False
            cboChoseServer.Enabled = False
            cboChoseServer.SelectedIndex = -1
        End If
    End Sub

    Private Sub btnCopyForTesting_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCopyForTesting.Click
        If cboChoseServer.SelectedIndex = -1 Then
            MsgBox("Must select a server for which to copy results", MsgBoxStyle.Critical, "Server not selected")
            cboServer.Focus()
        Else
            Dim ReturnValue As Integer = 0
            Dim sqlCmd = New System.Data.SqlClient.SqlCommand("DARTPro.dbo.sCopyReportParameters", gDatabaseConnection)
            sqlCmd.CommandTimeout = 0
            sqlCmd.CommandType = CommandType.StoredProcedure
            sqlCmd.Parameters.Add(New SqlParameter("@UserID", Me.dgvParameters.CurrentRow.Cells("colUserID").Value.ToString))
            sqlCmd.Parameters.Add(New SqlParameter("@ServerSource", cboServer.Text))
            sqlCmd.Parameters.Add(New SqlParameter("@ServerDestination", cboChoseServer.Text))
            Dim Reader As SqlDataReader = Nothing
            Try
                gDatabaseConnection.Open()
                Reader = sqlCmd.ExecuteReader(CommandBehavior.CloseConnection)
                Reader.Read()
                ReturnValue = Reader.GetSqlInt32(0)
                If ReturnValue > 0 Then
                    MsgBox("Successfully copied " & ReturnValue & " records for UserID " & Me.dgvParameters.CurrentRow.Cells("colUserID").Value.ToString & " to server " & cboChoseServer.Text & " from server " & cboServer.Text & ".", _
                            MsgBoxStyle.Information, "Records inserted successfully")
                Else
                    MsgBox("No records copied for UserID " & Me.dgvParameters.CurrentRow.Cells("colUserID").Value.ToString & " to server " & cboChoseServer.Text & " from server " & cboServer.Text & ".", _
                            MsgBoxStyle.Exclamation, "Records insertion failed")
                End If
            Catch sqlex As SqlException
                DisplayUnexpectedSQLException(sqlex)
            Finally
                Try
                    Reader.Close()
                Catch readerex As NullReferenceException
                Finally
                    gDatabaseConnection.Close()
                End Try
            End Try
        End If
    End Sub

    Private Sub GetTodaysUserIDsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GetTodaysUserIDsToolStripMenuItem.Click
        Dim ValueForToday As String = ""
        Dim iYear As Integer = Today.Year
        Dim iMonth As Integer = Today.Month
        Dim iDay As Integer = Today.Day

        ValueForToday = gUserID.ToString + iYear.ToString + PadValue(iMonth.ToString, 2) + PadValue(iDay.ToString, 2)
        txtUniqueUserID.Text = ValueForToday + "%"
    End Sub
End Class