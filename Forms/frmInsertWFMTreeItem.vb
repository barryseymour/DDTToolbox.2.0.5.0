Public Class frmInsertWFMTreeItem
    Public Result As String

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        If rdoInsertBlankItem.Checked Then
            Result += "insert;"
            gInsertReport = True
        End If

        If rdoPasteItemFromClipboard.Checked Then
            Result += "paste;"
        End If

        If rdoInsertBefore.Checked Then
            Result += "before"
        End If

        If rdoInsertAfter.Checked Then
            Result += "after"
        End If

        If rdoInsertIn.Checked Then
            Result += "in"
        End If

        Me.Close()
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Result = "cancel"
        Me.Close()
    End Sub

	Private Sub frmInsertWFMTreeItem_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
		Me.Icon = frmMain.Icon ' Barry
		rdoPasteItemFromClipboard.Enabled = Not frmWFMTree.CopyNode Is Nothing
		rdoPasteItemFromClipboard.Checked = rdoPasteItemFromClipboard.Enabled

		Dim selectedItemIsFolder As Boolean = (Strings.Left(frmWFMTree.InsertType, 6).ToUpper = "FOLDER")
		Dim folderInsertNotAllowed As Boolean = (frmWFMTree.InsertType.ToUpper = "FOLDER-NO INSERT")

		rdoInsertBefore.Text = "Insert BEFORE selected " + IIf(selectedItemIsFolder, "folder", "item")
		rdoInsertIn.Enabled = selectedItemIsFolder And Not folderInsertNotAllowed

		If selectedItemIsFolder And Not folderInsertNotAllowed Then
			rdoInsertIn.Checked = True
		Else
			rdoInsertBefore.Checked = True
		End If

		Me.CancelButton = btnCancel
	End Sub

End Class