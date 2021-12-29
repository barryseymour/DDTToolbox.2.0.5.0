Imports DDTToolbox.modGeneral

Public Class frmDevelopers
    Private sqlCmd As System.Data.SqlClient.SqlCommand
    Private currentMode As Integer
    Private currentIndex As Integer
    Const ADDmode = 1
    Const EDITmode = 2
    Const DELETEmode = 3

    Private Sub btnConnect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConnect.Click
        Dim GoodConn As Boolean
        gCurrentServer = cboServer.Items(cboServer.SelectedIndex)

        GoodConn = ChangeConnection(Me, e) 'LAshby 2/27/18 created new routine in modGeneral to replace redundant btnConnect_Click code in most forms
        If GoodConn = True Then
            btnConnect.ToolTipText = "Disconnect from a SQL Server database server"
            If FillDataGrid() >= 0 Then
                getCurrentRowValues()
            End If
        Else
            btnConnect.ToolTipText = "Connect to a SQL Server database server"
            clearEditFields()
        End If
    End Sub

    Private Sub frmDevelopers_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        HandleControls(False)
    End Sub

    Private Sub frmDevelopers_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pnlPrimaryContent.Visible = False
        LoadForm(Me, e) 'LAshby 2/27/18 created new routine in modGeneral to replace redundant frmLoad code in most forms

        If btnConnect.Enabled Then
            btnConnect_Click(sender, e)
        End If

        getCurrentRowValues()
        HandleControls(False)
        Me.Width = dgvDevelopers.Width + 15
        Me.Height = dgvDevelopers.Height + pnlBottom.Height + 20
        ResizeControls()
    End Sub

    Private Sub ResizeControls()
        If Me.Width >= frmMain.Width Then Me.Width = frmMain.Width - 15
        If Me.Height >= frmMain.Height - 87 Then Me.Height = frmMain.Height - 87

        With pnlPrimaryContent
            .Width = Me.Width - 15
            .Height = Me.Height - 15
            pnlBottom.Width = .Width
            pnlBottom.Top = .Top + (.Height - pnlBottom.Height) - 68
            dgvDevelopers.Height = .Height - pnlBottom.Height - 40
            pnlEditControlsCtrls.Left = (.Width / 2) - (pnlEditControlsCtrls.Width / 2)
            If pnlEditControlsCtrls.Left < .Left Then pnlEditControlsCtrls.Left = .Left
        End With
    End Sub

    Private Function FillDataGrid() As Integer
        Me.Cursor = Cursors.WaitCursor
        Dim recCount As Integer = dgvDevelopers.RowCount

        Dim adapter As New SqlClient.SqlDataAdapter
        Try
            dgvDevelopers.DataSource = Nothing
            Dim sql As String = "exec dbo.sToolbox_GetDeveloperInfo "

            gDatabaseConnection = New System.Data.SqlClient.SqlConnection(gConnectionString)

            sqlCmd = New System.Data.SqlClient.SqlCommand
            sqlCmd.CommandTimeout = 0
            sqlCmd.CommandText = Sql
            sqlCmd.CommandType = CommandType.Text
            sqlCmd.Connection = gDatabaseConnection
            adapter.SelectCommand = sqlCmd

            Dim table As DataTable = dsroot.Tables("Developers")
            If (dsroot.Tables.CanRemove(table)) Then
                dsroot.Tables.Remove(table)
            End If
            adapter.Fill(dsroot, "Developers")
            dgvDevelopers.DataSource = dsroot.Tables("Developers")
            sql = ""
            recCount = dgvDevelopers.RowCount
            pnlBottom.Visible = True
        Catch sqlex As SqlClient.SqlException
            recCount = -1
            clearEditFields()
            pnlBottom.Visible = False
            DisplayUnexpectedSQLException(sqlex)
        End Try

        Me.Cursor = Cursors.Default
        Return recCount
    End Function

    Private Sub frmDevelopers_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        ResizeControls()
    End Sub

    Private Sub dgvDevelopers_CellMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvDevelopers.CellMouseClick
        HandleControls(False)
        getCurrentRowValues()

    End Sub

    Private Sub getCurrentRowValues()
        Try
            Dim index As Integer = dgvDevelopers.CurrentRow.Index
            If dgvDevelopers.SelectedRows.Count > 0 Then

                txtTPID.Text = dgvDevelopers.Item("TPID", index).Value.ToString
                txtFullname.Text = dgvDevelopers.Item("FullName", index).Value.ToString
                txtTitle.Text = dgvDevelopers.Item("Title", index).Value.ToString
                txtTelephone.Text = dgvDevelopers.Item("Telephone", index).Value.ToString
                txtSortOrder.Text = dgvDevelopers.Item("SortOrder", index).Value.ToString
                Me.Refresh()
            Else
                clearEditFields()
            End If
        Catch ex As Exception
            MsgBox("An unexpected Error occured In the DataGrid." & vbCrLf & vbCrLf & "Error Message: " & ex.Message, MsgBoxStyle.Critical, "Error in DataGrid")
        End Try
    End Sub

    Private Sub HandleControls(ByVal SetEditMode As Boolean)
        txtTPID.Enabled = True
        txtTPID.ReadOnly = Not SetEditMode
        txtFullname.Enabled = True
        txtFullname.ReadOnly = Not SetEditMode
        txtTitle.Enabled = True
        txtTitle.ReadOnly = Not SetEditMode
        txtTelephone.Enabled = True
        txtTelephone.ReadOnly = Not SetEditMode
        txtSortOrder.Enabled = True
        txtSortOrder.ReadOnly = Not SetEditMode
        cmdSave.Enabled = SetEditMode
        cmdCancel.Enabled = SetEditMode
        dgvDevelopers.Enabled = Not SetEditMode

        cmdAdd.Enabled = Not SetEditMode
        cmdEdit.Enabled = IIf(dgvDevelopers.SelectedRows.Count > 0, Not SetEditMode, False)
        cmdDelete.Enabled = IIf(dgvDevelopers.SelectedRows.Count > 0, Not SetEditMode, False)
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub clearEditFields()
        txtTPID.Text = ""
        txtFullname.Text = ""
        txtTitle.Text = ""
        txtTelephone.Text = ""
        txtSortOrder.Text = ""
    End Sub

    Private Function getNewDgvRowIndex() As Integer
        Dim i As Integer
        Dim maxID As Integer
        Dim maxIdIndex As Integer
        maxID = 0

        For i = 0 To dgvDevelopers.Rows.Count - 1
            If dgvDevelopers.Item(0, i).Value > maxID Then
                maxID = dgvDevelopers.Item(0, i).Value
                maxIdIndex = i
            End If
        Next

        getNewDgvRowIndex = maxIdIndex
    End Function

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        Dim Sql As String

        If currentMode = ADDmode Then
            Sql = "INSERT INTO dbo.tsDeveloperIDs "
            Sql = Sql & "(TPID,FullName,Title,Telephone,SortOrder) "
            Sql = Sql & "VALUES "
            Sql = Sql & "('" & FixQuotes(txtTPID.Text) & "',"
            Sql = Sql & " '" & FixQuotes(txtFullname.Text) & "',"
            Sql = Sql & " '" & FixQuotes(txtTitle.Text) & "',"
            Sql = Sql & " '" & FixQuotes(txtTelephone.Text) & "',"
            Sql = Sql & " " & FixQuotes(txtSortOrder.Text) & ")"

            Using conn As New SqlClient.SqlConnection(gConnectionString)
                Dim cmd As New SqlClient.SqlCommand(Sql, conn)
                Try
                    conn.Open()
                    cmd.ExecuteScalar()
                Catch ex As Exception
                    Console.WriteLine(ex.Message)
                    MsgBox(ex.Message)
                End Try
            End Using
            FillDataGrid()
            currentIndex = getNewDgvRowIndex()
            dgvDevelopers.Item(1, currentIndex).Selected = True

        ElseIf currentMode = EDITmode Then
            Sql = ""
            Sql = Sql & "UPDATE tsDeveloperIDs "
            Sql = Sql & "SET    TPID = '" & FixQuotes(txtTPID.Text) & "',"
            Sql = Sql & "       FullName = '" & FixQuotes(txtFullname.Text) & "',"
            Sql = Sql & "       Title = '" & FixQuotes(txtTitle.Text) & "',"
            Sql = Sql & "       Telephone = '" & FixQuotes(txtTelephone.Text) & "',"
            Sql = Sql & "       SortOrder = " & txtSortOrder.Text & ""
            Sql = Sql & "WHERE  ID = " & dgvDevelopers.SelectedRows(0).Cells("ID").Value.ToString

            Using conn As New SqlClient.SqlConnection(gConnectionString)
                Dim cmd As New SqlClient.SqlCommand(Sql, conn)
                Try
                    conn.Open()
                    cmd.ExecuteScalar()
                Catch ex As Exception
                    Console.WriteLine(ex.Message)
                    MsgBox("Some SQL Error")
                End Try
            End Using

            currentIndex = dgvDevelopers.CurrentRow.Index
            FillDataGrid()
            dgvDevelopers.ClearSelection()
            dgvDevelopers.Item(1, currentIndex).Selected = True     'This way kept the selection after an edit.  The others didn't.
        End If

        HandleControls(False)
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub cmdAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAdd.Click
        currentMode = ADDmode
        HandleControls(True)
        dgvDevelopers.ClearSelection()
        clearEditFields()
    End Sub

    Private Sub cmdEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEdit.Click
        currentMode = EDITmode
        getCurrentRowValues()
        HandleControls(True)
    End Sub

    Private Sub cmdDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDelete.Click
        Dim Sql As String
        Dim message As String

        currentMode = DELETEmode
        message = "Are you sure you want to Delete the current record?  (ID=" + dgvDevelopers.SelectedRows(0).Cells("ID").Value.ToString + ")"
        If (MsgBox(message, MsgBoxStyle.YesNo) = MsgBoxResult.Yes) Then
            currentIndex = dgvDevelopers.CurrentRow.Index
            Sql = "DELETE from dbo.tsDeveloperIDs WHERE id = '" + dgvDevelopers.SelectedRows(0).Cells("ID").Value.ToString + "'"

            Using conn As New SqlClient.SqlConnection(gConnectionString)
                Dim cmd As New SqlClient.SqlCommand(Sql, conn)
                Try
                    conn.Open()
                    cmd.ExecuteScalar()
                Catch ex As Exception
                    Console.WriteLine(ex.Message)
                    MsgBox("Some SQL Error")
                End Try
            End Using
            FillDataGrid()
            dgvDevelopers.ClearSelection()
            clearEditFields()
            HandleControls(False)
        End If
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        HandleControls(False)
        getCurrentRowValues()
    End Sub

    Private Sub dgvDevelopers_Sorted(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvDevelopers.Sorted
        dgvDevelopers.ClearSelection()
        clearEditFields()
    End Sub

    Private Sub dgvDevelopers_CellMouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvDevelopers.CellMouseDoubleClick
        If e.RowIndex >= 0 Then
            cmdEdit_Click(sender, e)
        End If
    End Sub

End Class