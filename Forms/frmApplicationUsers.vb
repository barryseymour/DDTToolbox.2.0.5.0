Imports System.Data
Imports DDTToolbox.modGeneral

Public Class frmApplicationUsers
    Inherits System.Windows.Forms.Form

    Private sqlCmd As System.Data.SqlClient.SqlCommand
    Private SelectCmdStoredProcName As String
    Private editmode As Integer
    Private saveSearchButtonState As Boolean
    Private saveNextButtonState As Boolean
    Private Const notEditing = 0
    Private Const adding = 1
    Private Const editing = 2
    Private isUser As Integer
    Private AddGroupString As String
    Public Shared dsRoot As New DDT_Dataset
    Private saveUserID = ""

    Private Sub btnConnect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConnect.Click
        Dim GoodConn As Boolean
        GoodConn = ChangeConnection(Me, e) 'LAshby 2/27/18 created new routine in modGeneral to replace redundant btnConnect_Click code in most forms
        If GoodConn = True Then
            PopulatePendingTable()
            PopulateGrid()
        End If
    End Sub

    Private Sub frmTNGUsers_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        pnlPrimaryContent.Visible = False
        isUser = 1
        LoadForm(Me, e) 'LAshby 2/27/18 created new routine in modGeneral to replace redundant frmLoad code in most forms

        sqlCmd = New System.Data.SqlClient.SqlCommand
        sqlCmd.CommandTimeout = 0

        sqlCmd.CommandType = CommandType.Text
        sqlCmd.Connection = gDatabaseConnection

        SelectCmdStoredProcName = "exec dbo.sToolbox_ApplicationUsers_Retrieve"

        If btnConnect.Enabled Then
            btnConnect_Click(sender, e)
        End If

		cboSearchPart.SelectedIndex = 0
		Me.WindowState = FormWindowState.Maximized

    End Sub

    Private Sub PopulateGrid()
        Try
            dsRoot.BuildTable(SelectCmdStoredProcName, gConnectionString, "Users")
            dgvUsers.DataSource = dsRoot.Tables("Users")
            FormatGrid()

            lblUserCount.Text = dgvUsers.Rows.Count.ToString + " record(s)"
            editmode = Not editing

            Dim savedSearchColumn As String = cboSearchColumn.Text
            cboSearchColumn.Items.Clear()

            Dim i As Integer
            While i <= dgvUsers.Columns.Count - 1
                cboSearchColumn.Items.Add(dgvUsers.Columns(i).HeaderText)
                i += 1
            End While

            If savedSearchColumn = "" Then
                cboSearchColumn.Text = "LastName"
            Else
                cboSearchColumn.Text = savedSearchColumn
            End If
        Catch ex As Exception
            pnlPrimaryContent.Visible = False
            DisplayUnexpectedGeneralError(ex)
        End Try

        ShowPermissions()
        HandleControls("PopulateGrid")

    End Sub

    Private Sub FormatGrid()
        With dgvUsers
            .Columns("EmployeeNumber").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("FirstName").Frozen = True
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        End With
    End Sub

    Public Sub HandleControls(ByVal sender As String)
        btnConnect.Enabled = (editmode = notEditing)
        btnPending.Enabled = True
        cmCancelPending.Items(0).Visible = False
        Select Case sender
            Case "PopulateGrid"
                btnEdit.Enabled = True
                btnAdd.Enabled = True
                btnSave.Enabled = False
                btnCancel.Enabled = False
                btnRefresh.Enabled = True
                btnNewUserEmail.Enabled = True
                dgvUserPermissionsTo.ReadOnly = True
                dgvUsers.Enabled = True
                lblEditMode.Text = ""
                btnCopyTo.Enabled = False
                btnCopyAllTo.Enabled = False
                btnCopyFrom.Enabled = False
                btnCopyAllFrom.Enabled = False
                btnSearch.Enabled = True
                btnNext.Enabled = True
                txtSearch.Enabled = True And dgvUsers.Rows.Count > 0
                cboSearchPart.Enabled = True And dgvUsers.Rows.Count > 0
                cboSearchColumn.Enabled = True And dgvUsers.Rows.Count > 0
                chkSearchMatchCase.Enabled = True And dgvUsers.Rows.Count > 0
                btnConnect.Enabled = True
            Case "DisplayData"
                btnEdit.Enabled = True
                btnAdd.Enabled = True
                btnSave.Enabled = False
                btnCancel.Enabled = False
                btnRefresh.Enabled = True
                btnNewUserEmail.Enabled = True
                dgvUserPermissionsTo.ReadOnly = True
                dgvUsers.Enabled = True
                lblEditMode.Text = ""
                btnCopyTo.Enabled = False
                btnCopyAllTo.Enabled = False
                btnCopyFrom.Enabled = False
                btnCopyAllFrom.Enabled = False
                btnSearch.Enabled = True
                btnNext.Enabled = True
                btnConnect.Enabled = True
            Case "Add"
                btnAdd.Enabled = False
                btnEdit.Enabled = False
                btnSave.Enabled = True
                btnCancel.Enabled = True
                btnRefresh.Enabled = True
                btnNewUserEmail.Enabled = True
                dgvUserPermissionsTo.ReadOnly = False
                dgvUsers.Enabled = False
                lblEditMode.Text = "Adding record"
                btnCopyTo.Enabled = True
                btnCopyAllTo.Enabled = True
                btnCopyFrom.Enabled = True
                btnCopyAllFrom.Enabled = True
                btnSearch.Enabled = False
                btnNext.Enabled = False
            Case "Edit"
                btnEdit.Enabled = False
                btnAdd.Enabled = False
                btnSave.Enabled = True
                btnCancel.Enabled = True
                btnRefresh.Enabled = False
                btnNewUserEmail.Enabled = False
                dgvUserPermissionsTo.ReadOnly = False
                dgvUsers.Enabled = False
                lblEditMode.Text = "Editing record"
                btnCopyTo.Enabled = True
                btnCopyAllTo.Enabled = True
                btnCopyFrom.Enabled = True
                btnCopyAllFrom.Enabled = True
                btnSearch.Enabled = False
                btnNext.Enabled = False
                cmCancelPending.Items(0).Visible = True
            Case ("Cancel")
                btnAdd.Enabled = True
                btnEdit.Enabled = True
                btnSave.Enabled = False
                btnCancel.Enabled = False
                btnRefresh.Enabled = True
                btnNewUserEmail.Enabled = True
                dgvUserPermissionsTo.ReadOnly = True
                dgvUsers.Enabled = True
                lblEditMode.Text = ""
                btnCopyTo.Enabled = False
                btnCopyAllTo.Enabled = False
                btnCopyFrom.Enabled = False
                btnCopyAllFrom.Enabled = False
                btnSearch.Enabled = True
                btnNext.Enabled = True
            Case "Save"
        End Select
    End Sub

    Private Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        editmode = notEditing
        DisplayData(dgvUsers.CurrentRow.Index)
        HandleControls("Cancel")
        txtUserID.ReadOnly = True
        txtFirstName.ReadOnly = True
        txtLastName.ReadOnly = True
    End Sub

    Private Sub DisplayData(ByVal aRow As Integer)
        With dgvUsers
            txtUserID.Text = .Rows(aRow).Cells("UserID").Value
            txtFirstName.Text = .Rows(aRow).Cells("FirstName").Value
            txtLastName.Text = .Rows(aRow).Cells("LastName").Value
            txtEmployeeNum.Text = .Rows(aRow).Cells("EmployeeNumber").Value
            txtTitle.Text = .Rows(aRow).Cells("MyInfo_JobName").Value
            txtWITSLocation.Text = .Rows(aRow).Cells("MyInfo_LocationName").Value
            txtWITSCompany.Text = .Rows(aRow).Cells("MyInfo_Company").Value
            txtWITSOrganization.Text = .Rows(aRow).Cells("MyInfo_OrganizationName").Value
            lblJobType.Text = .Rows(aRow).Cells("JobType").Value.ToString
        End With
        ShowPermissions()
        HandleControls("DisplayData")
    End Sub

    Private Sub dgvUsers_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvUsers.CellDoubleClick
        isUser = 1
        editmode = editing
        btnEdit_Click(sender, e)
    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        txtUserID.Focus()
        Me.AcceptButton = btnSave
        editmode = editing
        HandleControls("Edit")
        ShowPermissions()
    End Sub

    Private Sub FindRecord(ByVal searchType As String)
        Me.Cursor = Cursors.WaitCursor
        Dim aRow As Integer
        Dim found As Boolean = False
        Dim searchText As String = txtSearch.Text
        Dim compareText As String

        If searchType = "search" Then
            aRow = 0
        Else
            'searchType = "next"
            aRow = dgvUsers.CurrentRow.Index + 1
        End If

        While aRow <= dgvUsers.Rows.Count - 1 And Not found

            compareText = dgvUsers.Rows(aRow).Cells(cboSearchColumn.Text).Value.ToString

            If Not chkSearchMatchCase.Checked Then
                compareText = compareText.ToUpper
                searchText = searchText.ToUpper
            End If

            Select Case cboSearchPart.Text
                Case "in any part"
                    found = (InStr(compareText, searchText) > 0)
                Case "from the beginning"
                    found = (Strings.Left(compareText, searchText.Length) = searchText)
                Case "at the end"
                    found = (Strings.Right(compareText, searchText.Length) = searchText)
                Case "as an exact match"
                    found = (compareText = searchText)
            End Select

            If found Then
                dgvUsers.CurrentCell = dgvUsers.Rows(aRow).Cells(cboSearchColumn.Text)
                btnNext.Enabled = True
            Else
                aRow += 1
            End If
        End While

        Me.Cursor = Cursors.Default

        If Not found Then
            If searchType = "search" Then
                MessageBox.Show("The search value '" + txtSearch.Text + "' was not found in the " + cboSearchColumn.Text + " column.", "Value not found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                Dim aResponse As DialogResult = MessageBox.Show("End of list encountered. Would you like to continue from the top of the list?", "Value not found", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If aResponse = System.Windows.Forms.DialogResult.Yes Then
                    HandleSearchButton()
                End If
            End If
        End If
    End Sub

    Private Sub HandleNextButton(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNext.Click
        FindRecord("next")
    End Sub

    Private Sub HandleSearchButton()
        FindRecord("search")
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        HandleSearchButton()
        If btnNext.Enabled Then Me.AcceptButton = btnNext
    End Sub

    Private Sub frmTNGUsers_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        grpUserInfo.Top = Me.Height - grpUserInfo.Height - 65
        dgvUsers.Width = Me.Width - 8
        dgvUsers.Height = Me.Height - grpUserInfo.Height - pnlUserActions.Height - 63
        pnlUserActions.Top = dgvUsers.Top + dgvUsers.Height
        grpUserInfo.Width = Me.Width - 26
    End Sub

    Private Sub btnRefresh_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRefresh.Click
        Me.Cursor = Cursors.WaitCursor
        PopulateGrid()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub btnAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Dim SQL As String = ""
        dgvUsers.ClearSelection()
        editmode = adding

        txtUserID.Text = ""
        txtFirstName.Text = ""
        txtLastName.Text = ""
        txtEmployeeNum.Text = ""
        txtTitle.Text = ""
        txtWITSLocation.Text = ""
        txtWITSCompany.Text = ""
        txtWITSOrganization.Text = ""
        txtUserID.ReadOnly = True
        txtUserID.Focus()

        frmAddApplicationUser.ShowDialog()

        Dim foundRecord As Boolean

        If frmAddApplicationUser.Result.ToUpper = "OK" Then
            Me.Cursor = Cursors.WaitCursor
            SQL = "exec dbo.sToolbox_ApplicationUser_Profile_Retrieve "
            If frmAddApplicationUser.ResultType.ToUpper = "EMPLOYEEID" Then
                SQL += "2,'"
            End If
            SQL += frmAddApplicationUser.ResultValue + "'"

            gDatabaseConnection = New System.Data.SqlClient.SqlConnection(gConnectionString)

            Dim result As SqlClient.SqlDataReader
            Try
                result = ExecSqlDataReader(SQL, gDatabaseConnection)
                If result.HasRows Then
                    result.Read()
                    If result.GetSqlString(result.GetOrdinal("Status")).Value <> "" Or result.GetSqlString(result.GetOrdinal("Type")).ToString = "Contractor" Then
                        'no active record found in ddtcommon.dbo.tEmployees_GeneralInfo
                        txtUserID.Text = result.GetSqlString(result.GetOrdinal("UserID"))
                        txtFirstName.Text = result.GetSqlString(result.GetOrdinal("FirstName"))
                        txtLastName.Text = result.GetSqlString(result.GetOrdinal("LastName"))
                        txtEmployeeNum.Text = result.GetSqlString(result.GetOrdinal("EmployeeNum"))
                        txtWITSCompany.Text = result.GetSqlString(result.GetOrdinal("MyInfoCompany"))
                        txtWITSOrganization.Text = result.GetSqlString(result.GetOrdinal("MyInfoOrganization"))
                        txtTitle.Text = result.GetSqlString(result.GetOrdinal("MyInfoTitle"))
                        txtWITSLocation.Text = result.GetSqlString(result.GetOrdinal("MyInfoLocation"))
                    End If
                End If
            Catch sqlex As SqlClient.SqlException
                Me.Cursor = Cursors.Default
                DisplayUnexpectedSQLException(sqlex)
            Finally
                gDatabaseConnection.Close()
                Me.Cursor = Cursors.Default
            End Try
        End If

        foundRecord = txtUserID.Text.Trim <> "" Or txtEmployeeNum.Text.Trim <> "" Or txtFirstName.Text.Trim <> "" Or txtLastName.Text.Trim <> ""

        If Not foundRecord Then
            Me.Cursor = Cursors.Default
            Dim aStr As String = "No 'Active' records found in dbo.tEmployees_GeneralInfo for "
            If frmAddApplicationUser.Result.ToUpper = "OK" Then
                If frmAddApplicationUser.ResultType.ToUpper = "EMPLOYEEID" Then
                    aStr += "Employee #"
                End If
                isUser = False
                aStr += "" + frmAddApplicationUser.ResultValue + "."
                MessageBox.Show(aStr, "Record not found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        Else
            'Check to make sure UserID doesn't already exist in the grid
            Me.Cursor = Cursors.WaitCursor

            SQL = "select dbo.fsDoesApplicationUserExist('" + txtUserID.Text + "')"
            Try
                isUser = ExecSqlScalar(SQL, gConnectionString)
            Catch sqlex As SqlClient.SqlException
                Me.Cursor = Cursors.Default
                DisplayUnexpectedSQLException(sqlex)
            Finally
                Me.Cursor = Cursors.Default
            End Try

        End If

        frmAddApplicationUser.Dispose()

        If isUser Then 'already in the data grid
            Dim aResult As DialogResult = MessageBox.Show("Employee #" + txtEmployeeNum.Text + " already exists. You will be directed to that record in read mode.", "User exists", MessageBoxButtons.OK, MessageBoxIcon.Question)

            Dim index As Integer
            Dim found As Boolean
            While index <= dgvUsers.Rows.Count - 1 And Not found
                If dgvUsers.Rows(index).Cells("UserID").Value = txtUserID.Text Then
                    found = True
                    dgvUsers.Rows(index).Selected = True
                    dgvUsers.CurrentCell = dgvUsers.Rows(index).Cells("UserID")
                End If
                index += 1
            End While
            txtFirstName.ReadOnly = True
            txtLastName.ReadOnly = True
            txtUserID.ReadOnly = True

            editmode = notEditing

        Else 'does not exist in the data grid
            txtFirstName.ReadOnly = foundRecord
            txtLastName.ReadOnly = foundRecord
            txtUserID.SelectAll()
            Me.AcceptButton = btnSave
        End If
        ShowPermissions()

        HandleControls("Add")

    End Sub

    Private Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Me.Cursor = Cursors.WaitCursor

        CleanPendingTable()

        If txtUserID.Text.Trim = "" Then
            MessageBox.Show("The UserID field cannot be left blank.", "Required field", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtUserID.Focus()
            Exit Sub
        ElseIf txtUserID.Text.Length > 25 Then
            MessageBox.Show("The UserID field cannot exceed 25 characters.", "Required field", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtUserID.Focus()
            Exit Sub
        End If

        If SaveADUser() > 0 Then
            'Note:  If UserID changes, we have decided not to update all of the associated UserLog records with new UserID
            'Same applies to the ReportsLog
            saveUserID = txtUserID.Text
            SelectCmdStoredProcName = "exec dbo.sToolbox_ApplicationUsers_Retrieve"
            PopulateGrid()
            Dim found As Boolean
            Dim counter As Integer = 0
            While Not found
                If dgvUsers.Rows(counter).Cells("UserID").Value.ToString.ToUpper = saveUserID.ToString.ToUpper Then
                    found = True
                    dgvUsers.CurrentCell = dgvUsers.Rows(counter).Cells("UserID")
                Else
                    counter += 1
                End If
            End While
            editmode = notEditing
            DisplayData(dgvUsers.CurrentRow.Index)
            HandleControls("Save")
            txtUserID.ReadOnly = True
            txtFirstName.ReadOnly = True
            txtLastName.ReadOnly = True

            PopulatePendingTable()
            ColorForPendingEntries(dgvUserPermissionsTo, txtUserID.Text)
        Else
            MessageBox.Show("You must have at least one ADGroup assigned before saving.")
        End If

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub dgvUsers_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvUsers.RowEnter
        isUser = 1
        DisplayData(e.RowIndex)
    End Sub

	Private Sub btnNewUserEmail_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNewUserEmail.Click

		Dim msg As String = "<!DOCTYPE HTML PUBLIC " + Chr(34) + "-//W3C//DTD HTML 4.0 Transitional//EN" + Chr(34) + ">"
		msg += "<HTML><HEAD><TITLE>Message</TITLE>"
		msg += "<META http-equiv=Content-Type content=" + Chr(34) + "text/html; charset=iso-8859-1" + Chr(34) + ">"
		msg += "<META http-equiv=Content-Type content=" + Chr(34) + "text/html; charset=iso-8859-1" + Chr(34) + ">"
		msg += "<META http-equiv=Content-Type content=" + Chr(34) + "text/html; charset=iso-8859-1" + Chr(34) + ">"
		msg += "<META http-equiv=Content-Type content=" + Chr(34) + "text/html; charset=iso-8859-1" + Chr(34) + ">"
		msg += "<META content=" + Chr(34) & "MSHTML 6.00.2800.1400" + Chr(34) + "name=GENERATOR></HEAD>"
		msg += "<BODY>"
		msg += "<P><FONT face=tahoma size=2>You have been added to the following Active Directory groups: </FONT><BR><BR>"
		With dsRoot.Tables("Pending")
			For Each dRow As DataRow In dsRoot.Tables("Pending").Rows
				If dRow.Item("UserID").ToString.ToUpper = saveUserID.ToUpper Then
					If dRow.Item("RequestType").ToString = "ADD" And dRow.Item("Status").ToString = "SEND" Then
						msg += "<FONT face=tahoma size=2>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + dRow.Item("ADGroup").ToString + "</FONT><BR>"
					End If
				End If
			Next
		End With
		msg += "<BR>To log in to the application(s), please use the following information.</FONT><BR><BR>"
		msg += "<FONT face=tahoma size=2>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Logon ID&nbsp;&nbsp: " + txtUserID.Text.Trim + "</FONT><BR>"
		msg += "<FONT face=tahoma size=2>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Password : your Windows password (case sensitive) </FONT><BR>"
		msg += "<FONT face=tahoma size=2>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Domain&nbsp;&nbsp&nbsp;&nbsp;: CORP </FONT><BR><BR>"
		msg += "<FONT face=tahoma size=2>It may take up to 24 hours before your account is fully activated and you can log in successfully. If after 24 hours you are still not able to log in, please contact the DART Development Team via email at SV-DART@semprautilities.com. </FONT><BR><BR>"
		msg += "<FONT face=tahoma size=2>If the application is not currently installed on your workstation, it should be automatically installed within the next 24 hours. If after 24 hours the application is still not available on your workstation, please contact the DART Development Team via email at SV-DART@semprautilities.com. Please be sure to include the asset tag # of your workstation in the email.</FONT>"
		msg += "</BODY></HTML>"

		Dim recipient As String = dgvUsers.CurrentRow.Cells("Email").Value
		Dim Subject As String = ""
		Subject = "Application Access Granted"

		CreateEmailMessage(recipient, "", Subject, msg, "HTML")

	End Sub

    Private Sub txtSearch_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSearch.TextChanged
        btnSearch.Enabled = (txtSearch.Text.Length > 0)
        btnNext.Enabled = False
        Me.AcceptButton = btnSearch
    End Sub

    Function SaveADUser() As Integer
        Dim action As String = ""
        Dim sql As String = ""

        'Get the permissions we want to remove first (left grid)
        action = "REMOVE"

        Dim dgvRow As DataGridViewRow

        If dgvUserPermissionsFrom.RowCount > 0 Then
            For Each dgvRow In dgvUserPermissionsFrom.Rows
                sql = "exec dbo.sToolbox_ADUser_Update "
                sql += "'" + FixQuotes(txtUserID.Text.Trim) + "', "
                sql += "'" + dgvRow.Cells(0).Value.ToString + "', "
                sql += "'" + action + "'"
                Try
                    Call ExecSqlScalar(sql, gConnectionString)  '<--- FYI, the 'Call' statement discards any returned value from ExecSqlScalar.  In this specific case, there is no returned value so the returned string would be empty.
                Catch sqlEx As SqlClient.SqlException
                    DisplayUnexpectedSQLException(sqlEx)
                Finally
                End Try
            Next dgvRow
        End If

        'Get the permissions we want to add (right grid)
        action = "ADD"
        If dgvUserPermissionsTo.RowCount > 0 Then
            For Each dgvRow In dgvUserPermissionsTo.Rows
                sql = "exec dbo.sToolbox_ADUser_Update "
                sql += "'" + FixQuotes(txtUserID.Text.Trim) + "', "
                sql += "'" + dgvRow.Cells(0).Value.ToString + "', "
                sql += "'" + action + "'"
                Try
                    Call ExecSqlScalar(sql, gConnectionString)  '<--- FYI, the 'Call' statement discards any returned value from ExecSqlScalar.  In this specific case, there is no returned value so the returned string would be empty.
                Catch sqlEx As SqlClient.SqlException
                    DisplayUnexpectedSQLException(sqlEx)
                Finally
                End Try
            Next dgvRow
        End If

        '--- The ADD RowCount must be greater than 0 before a SAVE can be completed. ---
        Return dgvUserPermissionsTo.RowCount
    End Function

    Private Sub CopyFromGridtoGrid() Handles btnCopyTo.Click, btnCopyFrom.Click, btnCopyAllTo.Click, btnCopyAllFrom.Click
        Dim i As Integer
        If grpAvailablePermissions.ContainsFocus = True Or btnCopyTo.ContainsFocus = True Then
            AddGroupString = dgvUserPermissionsFrom.CurrentRow.Cells(0).Value.ToString
            dgvUserPermissionsTo.Rows.Add(AddGroupString)
            If dgvUserPermissionsFrom.RowCount > 0 Then
                dgvUserPermissionsFrom.Rows.Remove(dgvUserPermissionsFrom.CurrentRow)
            End If
        ElseIf grpCurrentPermission.ContainsFocus = True Or btnCopyFrom.ContainsFocus = True Then
            AddGroupString = dgvUserPermissionsTo.CurrentRow.Cells(0).Value.ToString
            dgvUserPermissionsFrom.Rows.Add(AddGroupString)
            If dgvUserPermissionsTo.RowCount > 0 Then
                dgvUserPermissionsTo.Rows.Remove(dgvUserPermissionsTo.CurrentRow)
            End If
        ElseIf btnCopyAllTo.ContainsFocus = True Then
            For i = 0 To dgvUserPermissionsFrom.RowCount + 1
                If dgvUserPermissionsFrom.RowCount > 0 Then
                    Dim curRow As Integer = dgvUserPermissionsFrom.CurrentCell.RowIndex
                    Dim myRow As DataGridViewRow = dgvUserPermissionsFrom.CurrentRow
                    dgvUserPermissionsFrom.Rows.Remove(myRow)
                    dgvUserPermissionsTo.Rows.Add(myRow.Cells(0).Value.ToString)
                End If
            Next
        ElseIf btnCopyAllFrom.ContainsFocus = True Then
            For i = 0 To dgvUserPermissionsTo.RowCount + 1
                If dgvUserPermissionsTo.RowCount > 0 Then
                    Dim curRow As Integer = dgvUserPermissionsTo.CurrentCell.RowIndex
                    Dim myRow As DataGridViewRow = dgvUserPermissionsTo.CurrentRow
                    dgvUserPermissionsTo.Rows.Remove(myRow)
                    dgvUserPermissionsFrom.Rows.Add(myRow.Cells(0).Value.ToString)
                End If
            Next
        End If
        lblAvailADGroups.Text = dgvUserPermissionsFrom.Rows.Count.ToString + " groups(s)"
        lblCurrentADGroups.Text = dgvUserPermissionsTo.Rows.Count.ToString + " groups(s)"
    End Sub

    Private Sub HandleGridDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvUserPermissionsTo.CellDoubleClick, dgvUserPermissionsFrom.CellDoubleClick
        If editmode > notEditing Then CopyFromGridtoGrid()
    End Sub

    Private Sub RemovePendingGroup(dgvRow As DataGridViewRow)
        Dim ADGroup As String = dgvRow.Cells("ADGroup").Value.ToString
        Dim CurrentUserID As String = txtUserID.Text
        Dim PendingGroup As String = ""
        Dim MsgStr As String = ""
        Dim PendingID As String = ""
        For Each dRow As DataRow In dsRoot.Tables("Pending").Rows

            PendingGroup = dRow.Item("ADGroup").ToString
            If ADGroup = PendingGroup And CurrentUserID.ToUpper = dRow.Item("UserID").ToString.ToUpper And dRow.Item("Status").ToString.ToUpper = "SEND" Then
                '--- Remove the Pending item ---
                PendingID = dRow.Item("ID").ToString
                MsgStr = "REMOVE PENDING " + vbCrLf _
                    + "--------------------------------------------------------------------------------" + vbCrLf _
                    + "ADGroup: """ + PendingGroup + """" + vbCrLf _
                    + "UserID: """ + CurrentUserID + """" + vbCrLf _
                    + "RequestType: """ + dRow.Item("RequestType").ToString + """" + vbCrLf _
                    + "ID:""" + PendingID + """"
                If MessageBox.Show(MsgStr, "REMOVE PENDING", MessageBoxButtons.OKCancel) = Windows.Forms.DialogResult.OK Then
                    Try
                        DeletePendingID(PendingID, gConnectionString)
                        PopulatePendingTable()
                        PopulateGrid()
                        btnSave.PerformClick()
                        ShowPermissions()
                        Application.DoEvents()
                    Catch sqlex As SqlClient.SqlException
                        MessageBox.Show(sqlex.Message)
                    End Try
                End If
            End If
        Next
    End Sub

    Public Shared Sub DeletePendingID(PendingID As Integer, ConnectionString As String)
        Dim SQL As String = "DELETE dbo.tsApplicationAccessStatus WHERE Status = 'SEND' And ID = " + PendingID.ToString
        Try
            ExecSqlScalar(SQL, ConnectionString)
        Catch ex As Exception
            MessageBox.Show("Error Deleting Pending item in tsApplicationAccessStatus where ID = " + PendingID.ToString)
        End Try
    End Sub

    Private Sub CleanPendingTable()
        Dim CurrentUserID As String = txtUserID.Text
        Dim PendingGroup As String = ""
        Dim GroupFound As Boolean
        Try
            With dsRoot.Tables("Pending")
                For Each dRow As DataRow In dsRoot.Tables("Pending").Rows
                    PendingGroup = dRow.Item("ADGroup").ToString
                    If CurrentUserID.ToUpper = dRow.Item("UserID").ToString.ToUpper _
                        And dRow.Item("Status").ToString.ToUpper = "SEND" Then
                        If dRow.Item("RequestType").ToString.ToUpper = "ADD" Then
                            For Each dgvRow As DataGridViewRow In dgvUserPermissionsTo.Rows
                                If PendingGroup = dgvRow.Cells("ADGroup").Value.ToString Then
                                    GroupFound = True
                                End If
                            Next
                        End If

                        If Not GroupFound Then
                            '--- if the group isn't found, then ADD needs to be deleted. ---
                            DeletePendingID(dRow.Item("ID"), gConnectionString)
                        End If
                    End If
                Next
            End With
        Catch ex As Exception
            Debug.Print(ex.Message)
        End Try

    End Sub

    Public Sub ShowPermissions() Handles dgvUsers.DoubleClick

        Me.Cursor = Cursors.WaitCursor
        Dim adapter As New SqlClient.SqlDataAdapter
        Dim GroupName As String
        Dim RequestType As String = ""

        dgvUserPermissionsTo.Rows.Clear()
        Dim sql As String = "exec dbo.sToolbox_GetUserDomainAccountsGroups '" + txtUserID.Text + "'"
        gDatabaseConnection = New System.Data.SqlClient.SqlConnection(gConnectionString)

        Dim result As SqlClient.SqlDataReader

        Try
            result = ExecSqlDataReader(sql, gDatabaseConnection)
            If result.HasRows Then
                While result.Read
                    GroupName = result.Item("GroupName")
                    dgvUserPermissionsTo.Rows.Add(result.GetSqlString(result.GetOrdinal("GroupName")))
                End While

                ColorForPendingEntries(dgvUserPermissionsTo, txtUserID.Text)
            End If
        Catch sqlex As SqlClient.SqlException
            DisplayUnexpectedSQLException(sqlex)
        Finally
            gDatabaseConnection.Close()
        End Try
        lblCurrentADGroups.Text = dgvUserPermissionsTo.Rows.Count.ToString + " groups(s)"
        dgvUserPermissionsTo.ClearSelection()

        dgvUserPermissionsFrom.Rows.Clear()
        sql = "exec dbo.sToolbox_GetADGroupsAvailable  'Group', " + "'" + txtUserID.Text + "'"
        gDatabaseConnection = New System.Data.SqlClient.SqlConnection(gConnectionString)

        Try
            result = ExecSqlDataReader(sql, gDatabaseConnection)
            If result.HasRows Then
                While result.Read
                    dgvUserPermissionsFrom.Rows.Add(result.GetSqlString(result.GetOrdinal("ADGroup")))
                End While
            End If
        Catch sqlex As SqlClient.SqlException
            DisplayUnexpectedSQLException(sqlex)
        Finally
            gDatabaseConnection.Close()
            sqlCmd = Nothing
        End Try
        lblAvailADGroups.Text = dgvUserPermissionsFrom.Rows.Count.ToString + " groups(s)"

        Me.Cursor = Cursors.Default

    End Sub

    Private Sub ColorForPendingEntries(dgv As DataGridView, UserID As String)
        Try
            Dim RequestType As String = ""
            For Each dgvR As DataGridViewRow In dgv.Rows
                For Each dRow As DataRow In dsRoot.Tables("Pending").Rows
                    'If dRow.Item("UserID").ToString.ToUpper = gUserID.ToUpper Then
                    If dRow.Item("UserID").ToString.ToUpper = UserID.ToUpper Then
                        If dgvR.Cells("ADGroup").Value.ToString = dRow.Item("ADGroup").ToString Then
                            RequestType = dRow.Item("RequestType").ToString
                            If dRow.Item("Status").ToString.ToUpper = "SEND" Then
                                RequestType = dRow.Item("RequestType").ToString
                                Select Case RequestType
                                    Case "REMOVE"
                                        dgvR.DefaultCellStyle.ForeColor = Color.Red
                                        dgvR.DefaultCellStyle.BackColor = Color.Yellow
                                    Case "ADD"
                                        dgvR.DefaultCellStyle.ForeColor = Color.Green
                                        dgvR.DefaultCellStyle.BackColor = Color.Cyan
                                End Select
                                dgvR.Tag = dRow.Item("ID")
                                dgvR.ContextMenuStrip = cmCancelPending
                            End If
                            If dRow.Item("Status").ToString.ToUpper = "SENT" Then
                                Select Case RequestType
                                    Case "REMOVE"
                                        dgvR.DefaultCellStyle.ForeColor = Color.Red

                                    Case "ADD"
                                        dgvR.DefaultCellStyle.ForeColor = Color.Green
                                End Select

                            End If
                        End If
                    End If
                Next
            Next

        Catch ex As Exception
            Debug.Print(ex.Message)
        End Try
    End Sub

    Private Sub btnPending_Click(sender As Object, e As System.EventArgs) Handles btnPending.Click
        PopulatePendingTable()
        frmPending.ShowDialog()
        ShowPermissions()
        If dgvUserPermissionsTo.Rows.Count = 0 Then
            PopulateGrid()
        End If
    End Sub

    Public Shared Sub PopulatePendingTable()
        Dim sql As String = "SELECT ID, UserID, ADGroup, RequestType, Status, SubmitDate, DATEDIFF(dd, submitdate,getdate()) ElapsedDays FROM dbo.tsApplicationAccessStatus ORDER BY UserID, ADGroup"
        dsRoot.BuildTable(sql, gConnectionString, "Pending")
    End Sub

    Private Sub CancelPendingToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles CancelPendingToolStripMenuItem.Click
        RemovePendingGroup(dgvUserPermissionsTo.CurrentRow)
    End Sub

    Private Sub btnWFM_Click(sender As Object, e As EventArgs) Handles btnWFM.Click

        CallingForm = "frmAppUsers"

        WMUserID = txtUserID.Text.Trim.ToString
        WMLastName = txtLastName.Text.Trim.ToString
        WMFirstName = txtFirstName.Text.Trim.ToString

        Dim NewMDIChild As New frmWFMSecurity()
        NewMDIChild.MdiParent = frmMain
        Me.Cursor = Cursors.WaitCursor
        NewMDIChild.Show()
        Me.Cursor = Cursors.Default

    End Sub

    Private Sub btnNodeSecurity_Click(sender As Object, e As EventArgs) Handles btnNodeSecurity.Click

        CallingForm = "frmAppUsers"

        'Node...we are using these following variables just because they've been already been established for another button.  Same net result so not changing name of global variable
        WMUserID = txtUserID.Text.Trim.ToString
        WMLastName = txtLastName.Text.Trim.ToString
        WMFirstName = txtFirstName.Text.Trim.ToString

        Dim NewMDIChild As New frmNodeSecurity()
        NewMDIChild.MdiParent = frmMain
        Me.Cursor = Cursors.WaitCursor
        NewMDIChild.Show()
        Me.Cursor = Cursors.Default

    End Sub
End Class