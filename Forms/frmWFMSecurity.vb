Public Class frmWFMSecurity
    Private sqlCmd As System.Data.SqlClient.SqlCommand
    Private bPersInfo As Boolean = False
    Private bStatusInfo As Boolean = False
    Private action As String = ""

    Private Sub frmWFMSecurity_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Me.Dispose()
    End Sub

    Public Sub frmWFMSecurity_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Text = "Workforce Manager User Security"
        LoadForm(Me, e) 'LAshby 2/27/18 created new routine in modGeneral to replace redundant frmLoad code in most forms

        loc.Visible = False

        'The server needs to be the same as the calling form
        If gLastConnection.ToUpper = "SQWDARTD001" Then
            cboServer.Text = "SQWDARTD001"
        ElseIf gLastConnection.ToUpper = "SQWDARTP001" Then
            cboServer.Text = "SQWDARTP001"
        End If

        If btnConnect.Enabled Then
            btnConnect_Click(sender, e)
        End If
    End Sub

    Private Sub RefreshScreen()
        PopulateScreen()
    End Sub

    Private Sub btnConnect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConnect.Click
        Dim GoodConn As Boolean
        GoodConn = ChangeConnection(Me, e) 'LAshby 2/27/18 created new routine in modGeneral to replace redundant btnConnect_Click code in most forms
        If GoodConn = True Then
            loc.Visible = True
            lblUser.Text = "User: " + WMFirstName + " " + WMLastName + " (" + WMUserID + ")"
            RefreshScreen()
        Else
            loc.Visible = False
        End If
    End Sub

    Private Sub btnExit_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub PopulateScreen()
        lblEditMode.Text = ""

        Dim strSQL As String = "exec dbo.sToolbox_GetWFMUserSecuritySettings '" & WMUserID & "'"
        gDatabaseConnection = New System.Data.SqlClient.SqlConnection(gConnectionString)

        Dim result As SqlClient.SqlDataReader
        Try
            result = ExecSqlDataReader(strSQL, gDatabaseConnection)
            If result.HasRows Then
                lblEditMode.Text = "Editing"
                While result.Read
                    bPersInfo = result.Item("PersonalInfoTab")
                    bStatusInfo = result.Item("StatusEdit")
                    If result.Item("PersonalInfoTab") = True Then
                        rbPersInfoYes.Checked = True
                    Else
                        rbPersInfoNo.Checked = True
                    End If
                    If result.Item("StatusEdit") = True Then
                        rbStatusYes.Checked = True
                    Else
                        rbStatusNo.Checked = True
                    End If
                End While
            Else
                'no existing record
                bPersInfo = False
                bStatusInfo = False
                rbPersInfoNo.Checked = True
                rbStatusNo.Checked = True
                btnDelete.Enabled = False
                lblEditMode.Text = "Adding"
            End If
        Catch sqlex As SqlClient.SqlException
            DisplayUnexpectedSQLException(sqlex)
        Finally
            gDatabaseConnection.Close()
        End Try
    End Sub

    Private Sub btnClose_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If lblEditMode.Text = "" Or lblEditMode.Text = "Adding" Then
            action = "A"
            btnClose.Enabled = False
            btnDelete.Enabled = False
            If rbStatusNo.Checked = True And rbPersInfoNo.Checked = True Then action = "D" 'override if both options are set to 'no'
            Call RecordUpdate(sender, e, action)
            RefreshScreen()
            btnCancel_Click(sender, e)
            Me.Close()
        ElseIf lblEditMode.Text = "Editing" Then
            action = "U"
            btnClose.Enabled = False
            btnDelete.Enabled = False
            If rbStatusNo.Checked = True And rbPersInfoNo.Checked = True Then action = "D" 'override if both options are set to 'no'
            Call RecordUpdate(sender, e, action)
            RefreshScreen()
            btnCancel_Click(sender, e)
            Me.Close()
        End If
    End Sub

    Public Sub New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        btnClose.Enabled = False
        btnDelete.Enabled = False
        action = "D"
        Call RecordUpdate(sender, e, action)
        MsgBox("Record deleted")
        RefreshScreen()
        btnCancel_Click(sender, e)
        lblEditMode.Text = ""
        Me.Close()
    End Sub

    Private Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        If lblEditMode.Text = "" Or lblEditMode.Text = "Adding" Then
            btnClose.Enabled = True
            btnDelete.Enabled = False
        Else
            lblEditMode.Text = ""
            btnClose.Enabled = True
            btnDelete.Enabled = True
        End If
        If bStatusInfo = False Then
            rbStatusNo.Checked = True
        Else
            rbStatusYes.Checked = True
        End If
        If bPersInfo = False Then
            rbPersInfoNo.Checked = True
        Else
            rbPersInfoYes.Checked = True
        End If
    End Sub

    Private Sub RecordUpdate(ByVal sender As Object, ByVal e As System.EventArgs, ByVal action As String)
        If lblEditMode.Text = "Adding" And action = "D" And sender.text.ToString = "Save" Then
            MsgBox("If both items are set to 'NO' then the record will not be added")
        ElseIf lblEditMode.Text = "Editing" And action = "D" And sender.text.ToString = "Save" Then
            MsgBox("If both items are set to 'NO' then the record will automatically be deleted")
        End If
        Dim sql As String = "exec dbo.sToolbox_UpdateWFMUserSecuritySettings "

        sql += "'" + WMUserID + "', "
        If rbPersInfoYes.Checked = True Then
            sql += "1, "
        Else
            sql += "0, "
        End If
        If rbStatusYes.Checked = True Then
            sql += "1, "
        Else
            sql += "0, "
        End If
        sql += "'" + action + "'"
        Try
            Call ExecSqlScalar(sql, gConnectionString)  '<--- FYI, the 'Call' statement discards any returned value from ExecSqlScalar.  In this specific case, there is no returned value so the returned string would be empty.
            If action = "A" Then
                MsgBox("Record Added")
            ElseIf action = "U" Then
                MsgBox("Record Updated")
            End If
        Catch sqlEx As SqlClient.SqlException
            DisplayUnexpectedSQLException(sqlEx)
        End Try
    End Sub

End Class