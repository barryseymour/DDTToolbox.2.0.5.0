Public Class frmDARTTngEditReportControls
    Private currentControlID As Integer

	Private Sub frmDARTTngEditReportControls_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
		Me.Icon = frmMain.Icon ' Barry
		Me.CancelButton = btnCancel
	End Sub

    Private Sub FillDataFields()
        For Each dRow As DataRow In frmDARTTngTree.dsroot.Tables("trControls").Rows
            If dRow.Item("ControlsID") = cboControlsID.SelectedValue Then
                txtControlTitle.Text = dRow.Item("ControlTitle").ToString
                For Each cRow As DataRow In frmDARTTngTree.dsroot.Tables("trControls_Master").Rows
                    If cRow.Item("Controls_MasterID") = dRow.Item("Controls_MasterID") Then
                        txtControlName.Text = cRow.Item("ControlName").ToString
                    End If
                Next
            End If
        Next
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Dispose()
    End Sub

    Private Sub cboControlsID_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboControlsID.KeyDown
        e.SuppressKeyPress = True
    End Sub

    Private Sub cboControlsID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboControlsID.SelectedIndexChanged
        If IsNumeric(cboControlsID.SelectedValue) = True Then
            FillDataFields()
        End If
    End Sub

    Private Sub frmDARTTngEditReportControls_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click

    End Sub

    Private Sub ValidateChildID()
        Dim validItem As Boolean = False
        '--- Look for current DisplayValue matches a valid selection ---
        For Each tItem As DataRowView In cboChildIDs.Items
            If IIf(IsDBNull(tItem.Item(1)), "", tItem.Item(1)) = cboChildIDs.Text Then
                validItem = True
                Exit For
            End If
        Next

        If validItem = False Then
            '--- If current text is not in the DisplayValue list, check the value (int) list for a match ---
            For Each tItem As DataRowView In cboChildIDs.Items
                If tItem.Item(0) = cboChildIDs.Text Then
                    cboChildIDs.SelectedValue = tItem.Item(0)
                    Exit Sub
                End If
            Next
            cboChildIDs.SelectedValue = ""      '<- if no match found, set to NullString (clear the field).
        End If
    End Sub

    Private Sub cboChildIDs_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboChildIDs.Leave
    End Sub

    Private Sub cboChildIDs_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboChildIDs.SelectedIndexChanged
    End Sub

    Private Sub cboChildIDs_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cboChildIDs.Validating
        ValidateChildID()
    End Sub
End Class