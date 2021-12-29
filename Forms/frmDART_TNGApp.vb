Imports System.IO

Public Class frmDART_TNGApp
	Private sqlCmd As System.Data.SqlClient.SqlCommand
	Private editMode As Boolean = False
	Private BulletinsPath As String
	Private SampleScheduledPath As String
	Private Validation As Boolean = True
	Private BulletinFlag As Boolean = False


    Private Sub frmDART_TNGLoad(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadForm(Me, e) 'LAshby 2/27/18 created new routine in modGeneral to replace redundant frmLoad code in most forms

        If btnConnect.Enabled Then
            btnConnect_Click(sender, e)
        End If
    End Sub

    Private Sub btnConnect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConnect.Click
		Dim GoodConn As Boolean
		GoodConn = ChangeConnection(Me, e) 'LAshby 2/27/18 created new routine in modGeneral to replace redundant btnConnect_Click code in most forms
		If GoodConn = True Then
			PopulateScreen()
		End If
	End Sub

	Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
		Me.Close()
	End Sub

	Private Sub PopulateScreen()

		Dim strSQL As String = ""
		Dim i As Integer = 0

		Me.Cursor = Cursors.WaitCursor

		Me.Text = "DART Pro Application"

		strSQL = "exec dbo.sToolbox_GetApplication 1"

		sqlCmd = New System.Data.SqlClient.SqlCommand
		sqlCmd.CommandTimeout = 0
		sqlCmd.CommandType = CommandType.Text
		sqlCmd.CommandText = strSQL
		sqlCmd.Connection = gDatabaseConnection

		Dim result As SqlClient.SqlDataReader
		Try
			gDatabaseConnection.Open()
			result = sqlCmd.ExecuteReader
			If result.HasRows Then
				While result.Read
					If result("ServerState") = 1 Then
						cboServerState.Text = "Yes"
					Else
						cboServerState.Text = "No"
					End If

					txtBulletins.Text = result("MessagePath")
					BulletinsPath = result("MessagePath")
					txtSampleScheduled.Text = result("ScheduledReportsPath")
					SampleScheduledPath = result("ScheduledReportsPath")
					txtUnavailableMessage.Text = result("ServerDownMessage")

					If result("RunScheduledReports") = True Then
						cboRunScheduled.Text = "Yes"
					Else
						cboRunScheduled.Text = "No"
					End If
					If result("SendEmails") = True Then
						cboSendEmails.Text = "Yes"
					Else
						cboSendEmails.Text = "No"
					End If
					If result("UpdateSchedule") = True Then
						cboUpdateSchedule.Text = "Yes"
					Else
						cboUpdateSchedule.Text = "No"
					End If
					If result("DeleteExistingAtStart") = True Then
						cboDeleteExisting.Text = "Yes"
					Else
						cboRunScheduled.Text = "No"
					End If

					BulletinFlag = IIf(result("ShowBulletinBoard") = 0, False, True)
					SetBulletinBoardBtn()

				End While
			End If

		Catch sqlex As SqlClient.SqlException
			DisplayUnexpectedSQLException(sqlex)
		Finally
			gDatabaseConnection.Close()
			sqlCmd = Nothing
			result = Nothing
		End Try

		HandleControls()

		Me.Cursor = Cursors.Default

	End Sub

	Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
		If btnEdit.Text = "Save" Then
			Validation = True
			ValidateScreen()
			If Validation = True Then
				SaveChanges()
				btnEdit.Text = "Edit"
				btnCancel.Enabled = False
				editMode = False
				HandleControls()
			End If
		Else
			btnEdit.Text = "Save"
			btnCancel.Enabled = True
			editMode = True
			HandleControls()
		End If
	End Sub
	Private Sub ValidateScreen()
		ErrorProvider1.Clear()
		'This block of code applies to validation on DARTPro
		If txtBulletins.Text = "" Then
			ErrorProvider1.SetError(txtBulletins, "Path cannot be blank")
			Validation = False
		End If
		If txtSampleScheduled.Text = "" Then
			ErrorProvider1.SetError(txtSampleScheduled, "Path cannot be blank")
			Validation = False
		End If
		If Microsoft.VisualBasic.Right(txtBulletins.Text, 1).ToString <> "\" Then
			ErrorProvider1.SetError(txtBulletins, "Path requires a \ at the end of the string")
			Validation = False
		End If
		If Microsoft.VisualBasic.Right(txtSampleScheduled.Text, 1).ToString <> "\" Then
			ErrorProvider1.SetError(txtSampleScheduled, "Path requires a \ at the end of the string")
			Validation = False
		End If
		If txtBulletins.Text = "" Then
			ErrorProvider1.SetError(txtBulletins, "Path cannot be blank")
			Validation = False
		End If
		If txtSampleScheduled.Text = "" Then
			ErrorProvider1.SetError(txtSampleScheduled, "Path cannot be blank")
			Validation = False
		End If

	End Sub
	Private Sub SaveChanges()
		Me.Cursor = Cursors.WaitCursor
		Try
			Dim sql As String = "exec dbo.sToolbox_SaveApplication 1,"
			If cboServerState.Text = "Yes" Then
				sql += "1,"
			Else
				sql += "0,"
			End If
			sql += "'" & FixQuotes(txtUnavailableMessage.Text) & "',"
			sql += "'" & FixQuotes(txtBulletins.Text) & "',"
			sql += "'" & FixQuotes(txtSampleScheduled.Text) & "',"
			If cboRunScheduled.Text = "Yes" Then
				sql += "1,"
			Else
				sql += "0,"
			End If
			If cboSendEmails.Text = "Yes" Then
				sql += "1,"
			Else
				sql += "0,"
			End If
			If cboUpdateSchedule.Text = "Yes" Then
				sql += "1,"
			Else
				sql += "0,"
			End If
			If cboDeleteExisting.Text = "Yes" Then
				sql += "1"
			Else
				sql += "0"
			End If
			gDatabaseConnection = New SqlClient.SqlConnection(gConnectionString)
			gDatabaseConnection.Open()
			sqlCmd = New SqlClient.SqlCommand(sql, gDatabaseConnection)
			sqlCmd.CommandTimeout = 300
			sqlCmd.ExecuteNonQuery()
		Catch ex As Exception
			Me.Cursor = Cursors.Default
			DisplayUnexpectedSQLException(ex)
		Finally
			gDatabaseConnection.Close()
			sqlCmd = Nothing
			Me.Cursor = Cursors.Default
		End Try

		Me.Cursor = Cursors.Default

	End Sub
	Private Sub HandleControls()
		Me.Text = "DART Pro Application"
		lblSampleScheduled.Text = "Scheduled Reports"
		lblBB.Text = "To edit the DART Pro Bulletin Board, take the following steps:"

		If editMode = True Then
			btnCancel.Enabled = True
		Else
			btnCancel.Enabled = False
		End If

		If editMode = False Then
			For Each ctrl As Control In grpAvailability.Controls
				ctrl.Enabled = False
			Next
			For Each ctrl As Control In grpSupportDecisions.Controls
				ctrl.Enabled = False
			Next
			For Each ctrl As Control In grpScheduledReports.Controls
				ctrl.Enabled = False
			Next
		Else
			For Each ctrl As Control In grpAvailability.Controls
				ctrl.Enabled = True
			Next
			For Each ctrl As Control In grpSupportDecisions.Controls
				ctrl.Enabled = True
			Next
			For Each ctrl As Control In grpScheduledReports.Controls
				ctrl.Enabled = True
			Next
		End If
	End Sub

	Private Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
		editMode = False
		PopulateScreen()
		btnEdit.Text = "Edit"
	End Sub

	Private Sub btnBulletins_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBulletins.Click
		OpenFD.InitialDirectory = BulletinsPath
		OpenFD.ShowDialog()
	End Sub

	Private Sub btnSampleScheduled_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSampleScheduled.Click
		OpenFD.InitialDirectory = SampleScheduledPath
		OpenFD.ShowDialog()
	End Sub

	Private Sub btnEditBulletinBoard_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEditBulletinBoard.Click
		'2019.07.24 Barry - Eliminated the whole 'edit backup copy' bs. We just edit the file.
		'If the file is not found, a dummy file is created.
		'------------------------------------------------------------------------------------------------------------------------------------

		Dim WordProcess As Process
		Dim BulletinBoardFile As String = BulletinsPath & "BulletinBoard.htm"
		Dim Instructions As String = Label22.Text

		Try
			If Not File.Exists(BulletinBoardFile) Then ' create it.
				If MessageBox.Show("Bulletin Board File was not found. You'll have to create a new BulletinBoard.htm file in Word. " & vbCrLf & vbCrLf & "Would you like to open the containing folder?", "File Not Found", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
					Process.Start("Explorer.exe", BulletinsPath)
				End If
			Else
				'Me.Cursor = Cursors.WaitCursor
				WordProcess = Process.Start("winword.exe", BulletinBoardFile)
				'WordProcess.WaitForExit()	' makes winword act like a modal dialog
				'Me.Cursor = Cursors.Default
				'Me.Focus()
			End If

		Catch ex As System.IO.FileLoadException
			MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
		End Try

	End Sub

	Private Sub SetBulletinFlags(ByVal ApplicationID As Integer, ByVal Flag As Integer)
		Dim strSQL As String = ""

		Me.Cursor = Cursors.WaitCursor

		strSQL = "EXEC dbo.sBulletinBoard " & ApplicationID.ToString & "," & Flag.ToString

		Try
			gDatabaseConnection = New SqlClient.SqlConnection(gConnectionString)
			gDatabaseConnection.Open()
			sqlCmd = New SqlClient.SqlCommand(strSQL, gDatabaseConnection)
			sqlCmd.CommandTimeout = 300
			sqlCmd.ExecuteNonQuery()
		Catch sqlex As SqlClient.SqlException
			DisplayUnexpectedSQLException(sqlex)
		Finally
			gDatabaseConnection.Close()
			sqlCmd = Nothing
		End Try

		Me.Cursor = Cursors.Default

	End Sub

	Private Sub btnFlags_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFlags.Click
		SetBulletinFlags(1, IIf(BulletinFlag, 0, 1))
		BulletinFlag = Not BulletinFlag

		'Setting Text/Color
		SetBulletinBoardBtn()
	End Sub

	Private Sub SetBulletinBoardBtn()
		Dim fnt As Font

		If BulletinFlag Then
			'--- Bulletin Board is currently ON.  Ready BUTTON for TURN OFF mode.
			fnt = New Font("Microsoft Segoe UI", 8.25, FontStyle.Bold)
			btnFlags.Text = "BULLETIN BOARD FLAG IS ON"
			btnFlags.BackColor = Color.Green
			btnFlags.ForeColor = Color.White
			btnFlags.Font = fnt							'--> Button font Bold/Regular
		Else
			'--- Bulletin Board is currently OFF.  Ready BUTTON for TURN ON mode.
			fnt = New Font("Microsoft Segoe UI", 8.25, FontStyle.Bold)
			btnFlags.Text = "BULLETIN BOARD FLAG IS OFF"
			btnFlags.BackColor = Color.Red
			btnFlags.ForeColor = Color.White
			btnFlags.Font = fnt							'--> Button font Bold/Regular
		End If
	End Sub

End Class