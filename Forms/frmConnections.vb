Public Class frmConnections
    Dim editMode As Integer
    Const notEditing = 0
    Const editing = 1
    Const adding = 2

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Dim i As Integer
        ReDim ServerList(-1)
        If listConnections.Items.Count > 0 Then
            For i = 0 To listConnections.Items.Count - 1
                ReDim Preserve ServerList(i)
                ServerList(i) = listConnections.Items(i)
            Next
        End If
        Me.Dispose()
    End Sub

    Private Sub frmConnections_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        If listConnections.Items.Count = 0 Then
            btnAdd_Click(sender, e)
        End If
    End Sub

    Private Sub frmConnections_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim i As Integer
        For i = 0 To ServerList.GetUpperBound(0)
            If ServerList(i) <> "" Then
                listConnections.Items.Add(ServerList(i))
            End If
        Next
        If listConnections.Items.Count > 0 Then
            listConnections.SelectedItem = listConnections.Items(0)
        End If
        editMode = notEditing
        HandleControls()
    End Sub

    Private Sub HandleControls()
        btnAdd.Enabled = (editMode = notEditing)
        btnEdit.Enabled = (editMode = notEditing) And listConnections.SelectedItems.Count = 1
        btnDelete.Enabled = (editMode = notEditing) And listConnections.SelectedItems.Count = 1
        grpEditConnection.Visible = (editMode <> notEditing)
        grpMinimumRequirements.Visible = (editMode = notEditing)
        btnClose.Enabled = (editMode = notEditing)
    End Sub

    Public Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        editMode = adding
        HandleControls()
        grpEditConnection.Text = "Add new connection"
        txtConnectionName.Text = ""
        txtConnectionName.SelectAll()
        txtConnectionName.Focus()
    End Sub


    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        editMode = editing
        HandleControls()
        grpEditConnection.Text = "Edit existing connection"
        txtConnectionName.Text = listConnections.SelectedItem.ToString
        txtConnectionName.SelectAll()
        txtConnectionName.Focus()
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        editMode = notEditing
        HandleControls()
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim str As String = txtConnectionName.Text.Trim

        'Insure that txtConnectionName is not blank
        If str = "" Then
            MessageBox.Show(UCase(lblConnectionName.Text) + " field cannot be left blank.", "Invalid input", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtConnectionName.SelectAll()
            Exit Sub
        End If

        'Insure that txtConnectionName <> any entries already in the list if adding
        'or any item in the list besides the selected item if editing
        Dim index As Integer = 0
        Dim found As Boolean = False
        If listConnections.Items.Count > 0 Then
            Do While index <= listConnections.Items.Count - 1 And Not found
                If (editMode = adding And UCase(listConnections.Items(index).ToString) = UCase(str)) Or (editMode = editing And UCase(listConnections.Items(index).ToString) = UCase(str) And index <> listConnections.SelectedIndex) Then
                    found = True
                    MessageBox.Show("The " + lblConnectionName.Text + " '" + str + "' " + "already exists in the list.", "Duplicate value", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    txtConnectionName.SelectAll()
                    Exit Sub
                End If
                index += 1
            Loop
        End If

        'Insure that a connection can be made to the server
        Me.Cursor = Cursors.WaitCursor
        Me.Refresh()

        lblEstablishingConnection.Visible = True
        Me.Refresh()
        Dim result = ValidateConnection(str)
        Me.Cursor = Cursors.Default
        lblEstablishingConnection.Visible = False
        Me.Refresh()

        If result = "valid user" Then
            If editMode = adding Then
                listConnections.Items.Add(str)
            Else
                listConnections.Items(listConnections.SelectedIndex) = str
            End If

            index = 0
            found = False
            Do While index <= listConnections.Items.Count - 1 And Not found
                If listConnections.Items(index).ToString = str Then
                    found = True
                    listConnections.SelectedItem = listConnections.Items(index)
                End If
                index += 1
            Loop

            editMode = notEditing
            HandleControls()
        Else
            MessageBox.Show(result, "Connection failed", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            lblEstablishingConnection.Visible = False
            txtConnectionName.SelectAll()
        End If

    End Sub

    Private Sub listConnections_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles listConnections.Click
        HandleControls()
    End Sub

    Private Sub listConnections_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles listConnections.DoubleClick
        btnEdit_Click(sender, e)
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Dim aResponse As Integer = MessageBox.Show("Delete the connection '" + listConnections.Items(listConnections.SelectedIndex) + "'?", "Delete connection", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
        If aResponse = vbYes Then
            listConnections.Items.RemoveAt(listConnections.SelectedIndex)
            HandleControls()
        End If
    End Sub
End Class