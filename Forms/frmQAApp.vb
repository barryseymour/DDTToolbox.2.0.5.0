Public Class frmQAApp
    Private server As String
    Private sqlCmd As System.Data.SqlClient.SqlCommand
    Private editMode As String
    Private txtRoutingTemplateLocation_Revert As String
    Private txtVersionNotesFileLocation_Revert As String
    Private txtCurrentVersion_Revert As String
    Private txtSetupFileLocation_Revert As String
    Private cboAutoUpgrade_Revert As String

    Private Sub frmQAApp_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
            RetrieveData()
        End If
    End Sub

    Private Sub RetrieveData()
        gDatabaseConnection = New System.Data.SqlClient.SqlConnection(gConnectionString)
        sqlCmd = New System.Data.SqlClient.SqlCommand
        sqlCmd.CommandTimeout = 0
        sqlCmd.CommandType = CommandType.Text
        sqlCmd.CommandText = "exec QART.dbo.sQAApplicationSettingsGet"
        sqlCmd.Connection = gDatabaseConnection
        Dim reader As SqlClient.SqlDataReader
        Try
            gDatabaseConnection.Open()
            reader = sqlCmd.ExecuteReader
            reader.Read()
            txtRoutingTemplateLocation.Text = reader.GetSqlString(reader.GetOrdinal("RoutingSpreadsheetLocation")) + reader.GetSqlString(reader.GetOrdinal("RoutingSpreadsheetName"))
            txtSDGERoutingTemplateLocation.Text = reader.GetSqlString(reader.GetOrdinal("SDGERoutingSpreadsheetLocation")) + reader.GetSqlString(reader.GetOrdinal("SDGERoutingSpreadsheetName"))
            txtSDGERoutingDefaultEmailList.Text = reader.GetSqlString(reader.GetOrdinal("SDGERoutingDefaultEmailList"))
            txtVersionNotesFileLocation.Text = reader.GetSqlString(reader.GetOrdinal("VersionNotesFileName"))
            txtSetupFileLocation.Text = reader.GetSqlString(reader.GetOrdinal("SetupFile"))
            pnlPrimaryContent.Visible = True
        Catch sqlex As SqlClient.SqlException
            pnlPrimaryContent.Visible = False
            DisplayUnexpectedSQLException(sqlex)
            cboServer.Enabled = True
            btnConnect.Text = "Connect"
        Finally
            gDatabaseConnection.Close()
            sqlCmd = Nothing
        End Try

        editMode = "not editing"
        HandleControls()

    End Sub

    Private Function SaveData() As String
        Me.Cursor = Cursors.WaitCursor

        Dim sql As String = "exec QART.dbo.sQAApplicationSettingsSave '"
        Dim LastSlashPos As Integer = InStrRev(txtRoutingTemplateLocation.Text, "\")
        Dim fileName As String = Strings.Right(txtRoutingTemplateLocation.Text, Len(txtRoutingTemplateLocation.Text) - LastSlashPos)
        sql += fileName + "','"
        sql += Strings.Left(txtRoutingTemplateLocation.Text, Len(txtRoutingTemplateLocation.Text) - Len(fileName))
        sql += "','"
        sql += txtVersionNotesFileLocation.Text
        sql += "','"
        sql += txtSetupFileLocation.Text + "'"
        LastSlashPos = InStrRev(txtSDGERoutingTemplateLocation.Text, "\")
        fileName = Strings.Right(txtSDGERoutingTemplateLocation.Text, Len(txtSDGERoutingTemplateLocation.Text) - LastSlashPos)
        sql += ",'" + fileName + "','"
        sql += Strings.Left(txtSDGERoutingTemplateLocation.Text, Len(txtSDGERoutingTemplateLocation.Text) - Len(fileName))
        sql += "','" + txtSDGERoutingDefaultEmailList.Text + "'"

        gDatabaseConnection = New System.Data.SqlClient.SqlConnection(gConnectionString)
        sqlCmd = New System.Data.SqlClient.SqlCommand
        sqlCmd.CommandTimeout = 0
        sqlCmd.CommandType = CommandType.Text
        sqlCmd.CommandText = sql
        sqlCmd.Connection = gDatabaseConnection
        Try
            gDatabaseConnection.Open()
            sqlCmd.ExecuteNonQuery()
            Me.Cursor = Cursors.Default
            MessageBox.Show("Settings were successfully updated.", "Update successful", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return "success"
        Catch sqlex As SqlClient.SqlException
            Me.Cursor = Cursors.Default
            DisplayUnexpectedSQLException(sqlex)
            Return "failure"
        Finally
            gDatabaseConnection.Close()
            sqlCmd = Nothing
        End Try

    End Function

    Private Sub HandleControls()
        txtRoutingTemplateLocation.Enabled = True
        txtRoutingTemplateLocation.ReadOnly = (editMode <> "editing")
        btnRoutingTemplateLocation.Enabled = (editMode = "editing")
        txtSDGERoutingTemplateLocation.Enabled = True
        txtSDGERoutingTemplateLocation.ReadOnly = (editMode <> "editing")
        btnSDGERoutingTemplateLocation.Enabled = (editMode = "editing")
        txtSDGERoutingDefaultEmailList.Enabled = True
        txtSDGERoutingDefaultEmailList.ReadOnly = (editMode <> "editing")
        txtVersionNotesFileLocation.Enabled = True
        txtVersionNotesFileLocation.ReadOnly = (editMode <> "editing")
        btnVersionNotesFileLocation.Enabled = (editMode = "editing")
        txtSetupFileLocation.Enabled = True
        txtSetupFileLocation.ReadOnly = (editMode <> "editing")
        btnSetupFileLocation.Enabled = (editMode = "editing")
        btnEdit.Visible = (editMode = "not editing")
        btnSave.Visible = (editMode <> "not editing")
        btnCancel.Visible = (editMode <> "not editing")
        chkValidate.Visible = (editMode <> "not editing")
    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        editMode = "editing"
        HandleControls()

        txtRoutingTemplateLocation_Revert = txtRoutingTemplateLocation.Text
        txtVersionNotesFileLocation_Revert = txtVersionNotesFileLocation.Text
        txtSetupFileLocation_Revert = txtSetupFileLocation.Text
        txtRoutingTemplateLocation.Focus()
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim validated As Boolean = True

        If chkValidate.Checked Then
            If validated And Not My.Computer.FileSystem.FileExists(txtRoutingTemplateLocation.Text) Then
                validated = False
                MessageBox.Show("The Routing Template Spreadsheet file location '" + txtRoutingTemplateLocation.Text + "' does not exist.", "File not found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If

            If validated And Not My.Computer.FileSystem.FileExists(txtVersionNotesFileLocation.Text) Then
                validated = False
                MessageBox.Show("The Version Notes file location '" + txtVersionNotesFileLocation.Text + "' does not exist.", "File not found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        End If

        If validated Then
            If SaveData() = "success" Then
                editMode = "not editing"
            Else
                editMode = "editing"
            End If
            HandleControls()
        End If
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        txtRoutingTemplateLocation.Text = txtRoutingTemplateLocation_Revert
        txtVersionNotesFileLocation.Text = txtVersionNotesFileLocation_Revert
        txtSetupFileLocation.Text = txtSetupFileLocation_Revert

        editMode = "not editing"
        HandleControls()
    End Sub

    Private Sub btnRoutingSpreadsheetLocation_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRoutingTemplateLocation.Click
        With OpenFileDialog1
            .Title = "Locate Routing Template spreadsheet"
            .Filter = "Excel files (*.xls*)|*.xls"
            .FileName = txtRoutingTemplateLocation.Text
            .ShowReadOnly = False
            .ShowDialog()
            If .FileName <> "" Then txtRoutingTemplateLocation.Text = .FileName
        End With
    End Sub

    Private Sub btnVersionNotesFileLocation_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVersionNotesFileLocation.Click
        With OpenFileDialog1
            .Title = "Locate Version Notes file"
            .Filter = "All files (*.*)|*.*"
            .FileName = txtVersionNotesFileLocation.Text
            .ShowReadOnly = False
            .ShowDialog()
            If .FileName <> "" Then txtVersionNotesFileLocation.Text = .FileName
        End With
    End Sub

    Private Sub btnSetupFileLocation_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSetupFileLocation.Click
        With OpenFileDialog1
            .Title = "Locate SCG Setup file"
            .Filter = "All files (*.*)|*.*"
            .FileName = txtSetupFileLocation.Text
            .ShowReadOnly = False
            .ShowDialog()
            If .FileName <> "" Then txtSetupFileLocation.Text = .FileName
        End With
    End Sub

    Private Sub btnSDGERoutingTemplateLocation_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSDGERoutingTemplateLocation.Click
        With OpenFileDialog1
            .Title = "Locate SDGE Routing Template spreadsheet"
            .Filter = "Excel files (*.xls*)|*.xls"
            .FileName = txtSDGERoutingTemplateLocation.Text
            .ShowReadOnly = False
            .ShowDialog()
            If .FileName <> "" Then txtSDGERoutingTemplateLocation.Text = .FileName
        End With
    End Sub
End Class