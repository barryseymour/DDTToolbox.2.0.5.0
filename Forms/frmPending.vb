Public Class frmPending
    Private ValidEditPendingRecords As Boolean = False
    Private Editing As Boolean = False

    Private Sub frmPending_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
		Me.Icon = frmMain.Icon ' Barry
		SetDataGrid(Editing)
        FormatGrid()
        HandleControls(False)
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        Me.Close()
    End Sub

    Private Sub FormatGrid()
        With dgvPending
            .Columns("RequestType").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Status").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("ElapsedDays").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            .ClearSelection()
        End With
    End Sub

    Private Sub btnEdit_Click(sender As System.Object, e As System.EventArgs) Handles btnEdit.Click
        Editing = Not Editing
        HandleControls(Editing)
    End Sub

    Private Sub btnDelete_Click(sender As System.Object, e As System.EventArgs) Handles btnDelete.Click
        Dim idList As New List(Of String)
        Dim msg As String = "Delete the following Pending IDs " + vbCrLf + vbCrLf

        idList.Clear()
        For Each selRow As DataGridViewRow In dgvPending.SelectedRows
            idList.Add(selRow.Cells("ID").Value.ToString)
        Next

        If idList.Count > 0 Then
            For Each Str As String In idList
                msg += Str + vbCrLf
            Next
            Try
                If MessageBox.Show(msg, "Delete Pending", MessageBoxButtons.OKCancel) = Windows.Forms.DialogResult.OK Then
                    For Each Str As String In idList
                        frmApplicationUsers.DeletePendingID(CInt(Str), gConnectionString)
                    Next
                End If

            Catch ex As Exception
                MessageBox.Show("Error Deleting Pending ADD/REMOVE")
            End Try

            '--- Exit editing mode ---
            Editing = False
            HandleControls(Editing)
        Else
            MessageBox.Show("No Rows Selected")
        End If
    End Sub

    Private Sub HandleControls(EditMode As Boolean)
        btnOK.Enabled = Not EditMode
        btnDelete.Visible = EditMode
        SetDataGrid(EditMode)
        If EditMode Then
            dgvPending.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        Else
            dgvPending.SelectionMode = DataGridViewSelectionMode.CellSelect
        End If
        If EditMode Then
            If dgvPending.Rows.Count = 0 Then
                MessageBox.Show("There are no Pending items to delete")
                btnDelete.Enabled = False
                HandleControls(False)
                Editing = False
            Else
                btnDelete.Enabled = True
            End If
        End If
        btnEdit.Enabled = ValidEditPendingRecords
        btnEdit.Text = IIf(EditMode, "Cancel", "Edit")
    End Sub

    Private Sub SetDataGrid(EditMode As Boolean)
        PopulateEditPending()   '<-- Always populate the EditPending table, even if it's not used right now.
        If EditMode Then
            dgvPending.DataSource = frmApplicationUsers.dsRoot.Tables("EditPending")
        Else
            frmApplicationUsers.PopulatePendingTable()
            dgvPending.DataSource = frmApplicationUsers.dsRoot.Tables("Pending")
        End If
        dgvPending.ClearSelection()
    End Sub

    Private Sub PopulateEditPending()
        Dim SQL As String = "SELECT ID, UserID, ADGroup, RequestType, Status FROM dbo.tsApplicationAccessStatus WHERE Status = 'SEND' ORDER BY UserID, ADGroup"
        frmApplicationUsers.dsRoot.BuildTable(SQL, gConnectionString, "EditPending")
        If frmApplicationUsers.dsRoot.Tables("EditPending").Rows.Count > 0 Then
            ValidEditPendingRecords = True
        Else
            ValidEditPendingRecords = False
        End If
    End Sub
End Class