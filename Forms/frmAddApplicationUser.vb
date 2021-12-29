Public Class frmAddApplicationUser
    Public Result As String
    Public ResultType As String
    Public ResultValue As String

    Private Sub DisplayTextBox(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoLookupByEmployeeNumber.CheckedChanged
        HandleOKButtonState(sender, e)
    End Sub

    Private Sub HandleOKButtonState(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtEmployeeNumber.TextChanged
        btnOK.Enabled = (rdoLookupByEmployeeNumber.Checked And txtEmployeeNumber.Text.Trim <> "")
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        ResultType = "employeeid"
        ResultValue = txtEmployeeNumber.Text.Trim
        Result = "ok"
        Me.Hide()
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Result = "cancel"
        Me.Hide()
    End Sub

    Private Sub frmAddApplicationUser_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        txtEmployeeNumber.SelectAll()
        txtEmployeeNumber.Focus()
    End Sub

    Private Sub btnPaste_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPaste.Click
        txtEmployeeNumber.Text = My.Computer.Clipboard.GetText
    End Sub

End Class