Imports System.Data.SqlClient

Public Class frmCopyDARTtngTree

    Private Sub btnCopy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCopy.Click

        Dim i As Integer
        Dim serverName As String
        Dim resultMsg As String

        Dim aMsg As String = "Are you sure you want to copy the DARTPro/WFM tables to the selected server(s)?"
        aMsg += vbNewLine + vbNewLine + "NOTE : A copy of the DARTPro/WFM tables will be made to the target server(s) prior to the copy with the date and time appended to the table name for recovery purposes."

        Dim aResponse As DialogResult = MessageBox.Show(aMsg, "Confirm copy", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If aResponse = System.Windows.Forms.DialogResult.Yes Then
            Me.Cursor = Cursors.WaitCursor
            btnCopy.Enabled = False
            btnDone.Enabled = False
            dgvServers.Enabled = False

            Dim itemsToProcess = dgvServers.Rows.Count - 1

            'Clear the status from previous run if it exists
            For i = 0 To itemsToProcess
                dgvServers.Rows(i).Cells("colResult").Value = ""
            Next

            For i = 0 To itemsToProcess
                serverName = dgvServers.Rows(i).Cells("colServer").Value
                If serverName Like "*001" Then serverName &= "corp.se.sempra.com"

                If dgvServers.Rows(i).Cells("colCheckBox").Value = 1 Then
                    Dim connStr As String = "Data Source=" + serverName + ";Initial Catalog=DARTPro;Integrated Security=True;Connect Timeout=30"
                    Dim sqlConnection As New SqlConnection(connStr)
                    Dim sqlCmd As New SqlCommand

                    sqlCmd.CommandText = "DDT_Common.dbo.sToolbox_CopyTreeLevelsFromDevelopment"

                    sqlCmd.CommandType = CommandType.Text
                    sqlCmd.Connection = sqlConnection
                    Try
                        sqlConnection.Open()
                        sqlCmd.ExecuteNonQuery()
                        resultMsg = "succeeded"
                    Catch sqlex As SqlClient.SqlException
                        resultMsg = "Error code : " + sqlex.ErrorCode.ToString + "     Error number : " + sqlex.Number.ToString + vbNewLine + sqlex.Message
                    Finally
                        sqlConnection.Close()
                        sqlConnection = Nothing
                        sqlCmd = Nothing
                    End Try
                Else
                    resultMsg = "skipped"
                End If
                dgvServers.BeginEdit(False)
                dgvServers.Rows(i).Cells("colCheckBox").Value = 0
                dgvServers.EndEdit()
                dgvServers.Rows(i).Cells("colResult").Value = resultMsg
            Next

            HandleControls() 'should disable Copy button since all items are now unchecked
            dgvServers.Enabled = True
            btnDone.Enabled = True

            Me.Cursor = Cursors.Default
        End If
    End Sub

    Private Sub btnDone_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDone.Click
        Me.Dispose()
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Dispose()
    End Sub

    Private Sub frmCopyDARTTNGTree_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim i As Integer
        Dim checked As Boolean
        Dim rowsAdded As Integer
        If ServerList.GetLength(0) > 0 Then
            For i = 0 To ServerList.GetUpperBound(0)
                If ServerList(i).ToUpper <> "SQWDARTD001" Then
                    checked = (ServerList(i).ToUpper = "SQWDARTP001")
                    dgvServers.Rows.Add()
                    dgvServers.Rows(rowsAdded).Cells("colServer").Value = ServerList(i)
                    If checked Then
                        dgvServers.Rows(rowsAdded).Cells("colCheckBox").Value = 1
                    Else
                        dgvServers.Rows(rowsAdded).Cells("colCheckBox").Value = 0
                    End If
                    rowsAdded += 1
                End If
            Next
        End If
        If dgvServers.Rows.Count > 0 Then dgvServers.Rows(0).Cells(0).Selected = False
        HandleControls()

    End Sub

    Private Sub HandleControls()
        Dim i As Integer
        Dim foundChecked As Boolean

        While i <= dgvServers.Rows.Count - 1 And Not foundChecked
            If dgvServers.Rows(i).Cells("colCheckBox").Value = 1 Then
                foundChecked = True
            End If
            i += 1
        End While
        btnCopy.Enabled = foundChecked
    End Sub

    Private Sub dgvServers_CellMouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvServers.CellMouseDown
        If e.ColumnIndex = 0 Then
            dgvServers.BeginEdit(False)
        End If
    End Sub

    Private Sub dgvServers_CellMouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvServers.CellMouseUp
        If e.ColumnIndex = 0 Then
            dgvServers.EndEdit()
            dgvServers.Rows(e.RowIndex).Cells(0).Selected = False
            HandleControls()
        End If
    End Sub


End Class