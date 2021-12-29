Imports System.Data
Imports DDTToolbox.modGeneral
Imports System.Data.SqlClient

Public Class frmNodeSecurity
    Inherits System.Windows.Forms.Form

    Public Shared dsRoot As New DDT_Dataset
    Private AppID As Int16

    Private Sub btnConnect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConnect.Click
        Dim GoodConn As Boolean
        gCurrentServer = cboServer.Items(cboServer.SelectedIndex)

        GoodConn = ChangeConnection(Me, e) 'LAshby 2/27/18 created new routine in modGeneral to replace redundant btnConnect_Click code in most forms
        If GoodConn = True Then
            'We are just using these WM variables since they were globally established and serve our purpose
            lblUserInfo.Text = "User: " + WMFirstName + " " + WMLastName + " (" + WMUserID + ")"
            PopulateGrids()
        End If
    End Sub

    Private Sub frmNodeSecurity_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        pnlPrimaryContent.Visible = False
        LoadForm(Me, e) 'LAshby 2/27/18 created new routine in modGeneral to replace redundant frmLoad code in most forms

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

    Private Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Me.Cursor = Cursors.WaitCursor
        Dim selectedData As String = ""
        Dim value As String = ""
        Dim delimiter As String = ";"

        If dgvSecureNodes.RowCount > 0 Then
            For i As Integer = 0 To dgvSecureNodes.Rows.Count - 1
                For Each row As DataGridViewRow In dgvSecureNodes.Rows
                    selectedData += dgvSecureNodes.Rows(i).Cells(0).Value.ToString + delimiter
                    Exit For
                Next
            Next
        End If

        'Procedure will determine if node needs to be added, deleted or kept
        Dim sqlConnection As New SqlConnection(gConnectionString)
        Dim sqlCmd As New SqlCommand

        sqlCmd.CommandText = "exec dbo.sToolbox_UpdateNodeSecurity '" & WMUserID & "', '" & selectedData & "'"
        sqlCmd.CommandType = CommandType.Text
        sqlCmd.Connection = sqlConnection
        sqlConnection.Open()
        sqlCmd.ExecuteNonQuery()

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub CopyFromGridtoGrid() Handles btnCopyTo.Click, btnCopyFrom.Click

        Dim i As Integer
        If grpAvailableNodes.ContainsFocus = True Or btnCopyTo.ContainsFocus = True Then
            Try
                'Add into the MyPermissions dataset
                Dim NewRow As DataRow
                NewRow = dsRoot.Tables("MyPermissions").NewRow
                NewRow("TreeLevelID") = dgvAvailableNodes.CurrentRow.Cells(0).Value.ToString
                NewRow("ItemType") = dgvAvailableNodes.CurrentRow.Cells(1).Value.ToString
                NewRow("NodeName") = dgvAvailableNodes.CurrentRow.Cells(2).Value.ToString
                NewRow("NodeSort") = dgvAvailableNodes.CurrentRow.Cells(3).Value.ToString
                dsRoot.Tables("MyPermissions").Rows.Add(NewRow)
            Catch ex As Exception
                MessageBox.Show("Message" & ex.ToString & "Failed to add new row to DataTable ")
            End Try

            dsRoot.Tables("MyPermissions").DefaultView.Sort = "NodeSort ASC"

            'Refresh the right datagrid with the refreshed dataset
            dgvSecureNodes.DataSource = Nothing
            If dsRoot.Tables("MyPermissions").Rows.Count > 0 Then
                dgvSecureNodes.DataSource = dsRoot.Tables("MyPermissions")
            End If

            'Remove the value from the left datagrid
            Dim x As String = "", y As String = ""
            For i = 0 To dsRoot.Tables("AvailableNodes").Rows.Count - 1
                x = dsRoot.Tables("AvailableNodes").Rows(i).Item("TreeLevelID").ToString()
                y = dgvAvailableNodes.CurrentRow.Cells(0).Value.ToString()
                If x = y Then
                    dsRoot.Tables("AvailableNodes").Rows.RemoveAt(i)
                    dgvAvailableNodes.DataSource = Nothing
                    dgvAvailableNodes.DataSource = dsRoot.Tables("AvailableNodes")
                    Exit For
                End If
            Next
        ElseIf grpSecureNodes.ContainsFocus = True Or btnCopyFrom.ContainsFocus = True Then
            Try
                'Add into the AvailableNodes dataset
                Dim NewRow As DataRow
                NewRow = dsRoot.Tables("AvailableNodes").NewRow
                NewRow("TreeLevelID") = dgvSecureNodes.CurrentRow.Cells(0).Value.ToString
                NewRow("ItemType") = dgvSecureNodes.CurrentRow.Cells(1).Value.ToString
                NewRow("NodeName") = dgvSecureNodes.CurrentRow.Cells(2).Value.ToString
                NewRow("NodeSort") = dgvSecureNodes.CurrentRow.Cells(3).Value.ToString
                dsRoot.Tables("AvailableNodes").Rows.Add(NewRow)
            Catch ex As Exception
                MessageBox.Show("Message" & ex.ToString & "Failed to add new row to DataTable ")
            End Try

            dsRoot.Tables("AvailableNodes").DefaultView.Sort = "NodeSort ASC"

            'Refresh the left datagrid with the refreshed dataset
            dgvAvailableNodes.DataSource = Nothing
            If dsRoot.Tables("AvailableNodes").Rows.Count > 0 Then
                dgvAvailableNodes.DataSource = dsRoot.Tables("AvailableNodes")
            End If

            'Remove the value from the right datagrid
            Dim x As String = "", y As String = ""
            For i = 0 To dsRoot.Tables("MyPermissions").Rows.Count - 1
                x = dsRoot.Tables("MyPermissions").Rows(i).Item("TreeLevelID").ToString()
                y = dgvSecureNodes.CurrentRow.Cells(0).Value.ToString()
                If x = y Then
                    dsRoot.Tables("MyPermissions").Rows.RemoveAt(i)
                    dgvSecureNodes.DataSource = Nothing
                    dgvSecureNodes.DataSource = dsRoot.Tables("MyPermissions")
                    Exit For
                End If
            Next
        End If
        lblAvailNodes.Text = dgvAvailableNodes.Rows.Count.ToString + " Node(s)"
        lblCurrentNodes.Text = dgvSecureNodes.Rows.Count.ToString + " Node(s)"
    End Sub

    Private Sub PopulateGrids()
        If rbDART.Checked = True Then
            AppID = 1
        Else
            AppID = 2
        End If

        Dim Sql As String = "exec dbo.sToolbox_GetNodeSecurity '" & WMUserID & "', " & AppID & ", 'S'"
        BuildDataSet(gDatabaseConnection, Sql, "MyPermissions", dsRoot)
        Sql = "exec dbo.sToolbox_GetNodeSecurity '" & WMUserID & "', " & AppID & ", 'A'"
        BuildDataSet(gDatabaseConnection, Sql, "AvailableNodes", dsRoot)

        'Available Nodes - we will remove items from this side if they have special permissions
        dgvAvailableNodes.DataSource = Nothing
        If dsRoot.Tables("AvailableNodes") Is Nothing = False Then
            If dsRoot.Tables("AvailableNodes").Rows.Count > 0 Then
                dgvAvailableNodes.DataSource = dsRoot.Tables("AvailableNodes")
            End If
        End If

        'This user has special permissions to certain nodes so show them on the right side of the screen
        dgvSecureNodes.DataSource = Nothing
        If dsRoot.Tables("MyPermissions") Is Nothing = False Then
            If dsRoot.Tables("MyPermissions").Rows.Count > 0 Then
                dgvSecureNodes.DataSource = dsRoot.Tables("MyPermissions")
            End If
        End If

        lblAvailNodes.Text = dgvAvailableNodes.Rows.Count.ToString + " Node(s)"
        lblCurrentNodes.Text = dgvSecureNodes.Rows.Count.ToString + " Node(s)"
    End Sub

    Private Sub rbDART_CheckedChanged(sender As Object, e As EventArgs) Handles rbDART.CheckedChanged, rbWFM.CheckedChanged, btnCancel.Click
        PopulateGrids()
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

End Class