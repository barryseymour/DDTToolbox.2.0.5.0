Public Class frmLoginTracking
    Private currentMode As Integer
    Private currentIndex As Integer
    Private currentRow As String
    Private sqlCmd As System.Data.SqlClient.SqlCommand
    Const AddMode = 1
    Const EditMode = 2
    Const DeleteMode = 3

	Private Sub frmLoginTracking_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pnlPrimaryContent.Visible = False
        LoadForm(Me, e) 'LAshby 2/27/18 created new routine in modGeneral to replace redundant frmLoad code in most forms

		If btnConnect.Enabled Then
			btnConnect_Click(sender, e)
		End If
	End Sub

    Private Sub btnConnect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConnect.Click
        Dim GoodConn As Boolean
        gCurrentServer = cboServer.Items(cboServer.SelectedIndex)

        GoodConn = ChangeConnection(Me, e) 'LAshby 2/27/18 created new routine in modGeneral to replace redundant btnConnect_Click code in most forms
        If GoodConn = True Then
                PopulateGrid()
        End If
    End Sub

    Private Sub PopulateGrid()
        Me.Cursor = Cursors.WaitCursor

        Dim adapter As New SqlClient.SqlDataAdapter
        Try
            dgvLoginTracking.DataSource = Nothing
            Dim sql As String = "exec dbo.sToolbox_LoginTracking_Get"
            gDatabaseConnection = New System.Data.SqlClient.SqlConnection(gConnectionString)

            sqlCmd = New System.Data.SqlClient.SqlCommand
            sqlCmd.CommandTimeout = 0
            sqlCmd.CommandText = sql
            sqlCmd.CommandType = CommandType.Text
            sqlCmd.Connection = gDatabaseConnection
            adapter.SelectCommand = sqlCmd

            Dim table As DataTable = dsroot.Tables("LoginTracking")
            If (dsroot.Tables.CanRemove(table)) Then
                dsroot.Tables.Remove(table)
            End If
            adapter.Fill(dsroot, "LoginTracking")
            dgvLoginTracking.DataSource = dsroot.Tables("LoginTracking")
            dgvLoginTracking.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells
            sql = ""
        Catch sqlex As SqlClient.SqlException
            DisplayUnexpectedSQLException(sqlex)
        End Try

        dgvLoginTracking.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None
        DisplayRecordCount()
        getCurrentRowValues()
        HandleControls(False)
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub frmLoginTracking_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        Dim topPos = Me.Height - lblRecordCount.Height - 65
        lblRecordCount.Top = topPos
        dgvLoginTracking.Height = topPos - 5
        dgvLoginTracking.Width = Me.Width - pnlControls.Width - 12

        pnlControls.Width = Me.Width - dgvLoginTracking.Width - 12
    End Sub

    Private Sub dgvLoginTracking_CellMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvLoginTracking.CellMouseClick
        HandleControls(False)
        getCurrentRowValues()
    End Sub

    Private Sub getCurrentRowValues()
        Try
            If dgvLoginTracking.SelectedRows.Count > 0 Then
                Dim index As Integer = dgvLoginTracking.CurrentRow.Index
                txtProcess.Text = dgvLoginTracking.Item(1, index).Value.ToString
                txtLogin.Text = dgvLoginTracking.Item(2, index).Value.ToString
                txtPassword.Text = dgvLoginTracking.Item(3, index).Value.ToString
                txtDescription.Text = dgvLoginTracking.Item(4, index).Value.ToString
            Else
                clearEditFields()
            End If
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            DisplayUnexpectedSQLException(ex)
        End Try
    End Sub

    Private Sub clearEditFields()
        txtProcess.Text = ""
        txtLogin.Text = ""
        txtPassword.Text = ""
        txtDescription.Text = ""
        txtProcess.Focus()
    End Sub

    Public Sub HandleControls(ByVal SetEditMode As Boolean)
        txtProcess.ReadOnly = Not SetEditMode
        txtLogin.ReadOnly = Not SetEditMode
        txtPassword.ReadOnly = Not SetEditMode
        txtDescription.ReadOnly = Not SetEditMode

        btnSaveRecord.Enabled = SetEditMode
        btnCancel.Enabled = SetEditMode
        dgvLoginTracking.Enabled = Not SetEditMode

        btnAddRecord.Enabled = IIf(dgvLoginTracking.SelectedRows.Count > 0, Not SetEditMode, True)
        btnEditRecord.Enabled = IIf(dgvLoginTracking.SelectedRows.Count > 0, Not SetEditMode, False)
        btnDeleteRecord.Enabled = IIf(dgvLoginTracking.SelectedRows.Count > 0, Not SetEditMode, False)
    End Sub

    Private Sub btnAddRecord_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddRecord.Click
        currentMode = AddMode
        HandleControls(True)
        clearEditFields()
        EditingMode()
        Timer1.Enabled = True
    End Sub

    Private Sub btnEditRecord_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEditRecord.Click
        currentMode = EditMode
        HandleControls(True)
        txtProcess.Focus()
        EditingMode()
        Timer1.Enabled = True
    End Sub

    Private Sub btnDeleteRecord_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeleteRecord.Click
        currentMode = DeleteMode
        txtProcess.Focus()
        Dim sql As String
        Dim aResponse As DialogResult = MessageBox.Show("Delete record?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If aResponse = DialogResult.Yes Then
            Me.Cursor = Cursors.WaitCursor
            currentIndex = dgvLoginTracking.CurrentRow.Index
            sql = "dbo.sToolbox_LoginTracking_Delete " + dgvLoginTracking.SelectedRows(0).Cells("ID").Value.ToString
            
            Dim conn As New SqlClient.SqlConnection(gConnectionString)
            Dim cmd As New SqlClient.SqlCommand(sql, conn)
            Try
                conn.Open()
                cmd.ExecuteNonQuery()
            Catch ex As Exception
                Me.Cursor = Cursors.Default
                DisplayUnexpectedSQLException(ex)
            Finally
                conn.Close()
            End Try
            PopulateGrid()
        Else
        End If
    End Sub
    
    Private Sub btnSaveRecord_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveRecord.Click
        Dim ID As Integer
        Dim sql As String
        If txtProcess.Text.Trim = "" Then
            MessageBox.Show("Can't leave the Process field blank", "Blank entry", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtProcess.Focus()
            Exit Sub
        End If
        Me.Cursor = Cursors.WaitCursor
        sql = "exec dbo.sToolbox_LoginTracking_Add_Update "
        sql += "@Process='" + txtProcess.Text + "',"
        sql += "@Login='" + txtLogin.Text + "',"
        sql += "@Password='" + txtPassword.Text + "',"
        sql += "@Description='" + txtDescription.Text + "'"
        If currentMode = EditMode Then
            EditingMode()
            sql += ",@ID = " & dgvLoginTracking.SelectedRows(0).Cells("ID").Value.ToString
            currentRow = dgvLoginTracking.Item(1, 0).ToString
        Else
            EditingMode()
            dgvLoginTracking.ClearSelection()
        End If

        Dim conn As New SqlClient.SqlConnection(gConnectionString)
        Dim cmd As New SqlClient.SqlCommand(sql, conn)

        Try
            conn.Open()
            ID = cmd.ExecuteScalar()
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            DisplayUnexpectedSQLException(ex)
        Finally
            conn.Close()
        End Try

        HandleControls(False)
        PopulateGrid()
        Dim found As Boolean
        Dim aRow As Integer
        While aRow <= dgvLoginTracking.Rows.Count - 1 And Not found
            If dgvLoginTracking.Rows(aRow).Cells("ID").Value = ID Then
                found = True
                dgvLoginTracking.CurrentCell = dgvLoginTracking.Rows(aRow).Cells(1)
                dgvLoginTracking.Rows(aRow).Selected = True
            End If
            aRow += 1
        End While
        getCurrentRowValues()
        lblEditingMode.Text = ""
        dgvLoginTracking.Focus()
        Timer1.Enabled = False
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        getCurrentRowValues()
        HandleControls(False)
        lblEditingMode.Text = ""
        dgvLoginTracking.Focus()
        txtProcess.Focus()
        Timer1.Enabled = False
    End Sub

    Private Sub dgvLoginTracking_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvLoginTracking.DoubleClick
        btnEditRecord_Click(sender, e)
    End Sub

    Private Sub DisplayRecordCount()
        lblRecordCount.Text = "Record count:  " + dgvLoginTracking.Rows.Count.ToString
    End Sub

    Private Sub EditingMode()
        If currentMode = EditMode Then
            lblEditingMode.Text = "Currently editing record."
        End If

        If currentMode = AddMode Then
            lblEditingMode.Text = "Currently adding record."
        End If
    End Sub

    Private Sub txtProcess_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtProcess.Enter
        txtProcess.SelectAll()
    End Sub

    Private Sub txtLogin_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtLogin.Enter
        txtLogin.SelectAll()
    End Sub

    Private Sub txtPassword_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPassword.Enter
        txtPassword.SelectAll()
    End Sub

    Private Sub txtDescription_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDescription.Enter
        txtDescription.SelectAll()
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        lblEditingMode.Visible = Not lblEditingMode.Visible
    End Sub

    Private Sub dgvLoginTracking_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvLoginTracking.SelectionChanged
        getCurrentRowValues()
    End Sub
End Class