
Public Class frmToolBuilder
    Public FirstActivated As Boolean = True
    Private EditNamePressed As Boolean = False

    Private Sub frmToolBuilder_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        HighlightUsedRows(Color.White, Color.Aqua, True)
    End Sub

    '--------------------------------------------------------------------------
    '--- Recursively get all menu items under the MenuHeader Item,          ---
    '--- and add MouseDown Handler.                                         ---
    ' 2/2/2010 MG : Modified to NOT add handler when item HasDropDownItems  ---
    '--------------------------------------------------------------------------
    Private Sub AddHandler_MouseDown_ToAllSubMenuItems(ByVal menus As ToolStripItemCollection)
        Dim c As ToolStripItem
        Dim t As ToolStripMenuItem

        For Each c In menus
            Debug.Print(c.Text)
            If c.GetType Is GetType(ToolStripMenuItem) Then
                t = c
                If t.HasDropDownItems Then
                    AddHandler_MouseDown_ToAllSubMenuItems(t.DropDownItems)
                Else
                    AddHandler c.MouseDown, AddressOf MenuItem_MouseDown
                End If
            End If
        Next
    End Sub

    '--- Get a Menu Header item ---
    Private Function GetMenuHeaderItem(ByVal mName As String) As ToolStripMenuItem
        Dim mItem As ToolStripMenuItem

        For Each mItem In frmMain.MenuStrip1.Items
            If mItem.Text = mName Then
                Return mItem
            End If
        Next

        Return Nothing
    End Function

    '--- Create MouseDown Event used for all MenuItems ---
    Private Sub MenuItem_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        If My.Computer.Keyboard.CtrlKeyDown = True Then
            DoDragDrop(sender.text, DragDropEffects.Copy)
        End If
    End Sub

    Private Sub InitFormSize()
        Dim dgvToolsWidth As Integer = 0
        Dim col As DataGridViewColumn
        For Each col In dgvTools.Columns
            dgvToolsWidth += col.Width
        Next
        Me.Width = grpToolBuild.Left + dgvToolsWidth + 50
        Me.Height = (dgvTools.RowTemplate.Height * dgvTools.Rows.Count) + (grpToolBuild.Height - dgvTools.Height) + 75
        Me.Top = frmMain.ClientRectangle.Top
        If Me.Height > frmMain.ClientRectangle.Height - 90 Then
            Me.Height = frmMain.ClientRectangle.Height - 90
        End If

    End Sub

    Private Sub frmToolBuilder_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
		Me.Icon = frmMain.Icon ' Barry
		initToolPalette()
        cboDocking.Text = frmMain.tsMyButtons.Dock.ToString
        cboTextDirection.Text = frmMain.tsMyButtons.TextDirection.ToString

        ''--- Since all are set to the same value, just get the info from the first one. ---
        If frmMain.tsMyButtons.Items.Count > 0 Then
            cboButtonStyle.Text = frmMain.tsMyButtons.Items(0).DisplayStyle.ToString
        End If

        '--- Get all methods from which to choose.  This needs to be filtered a bit better.  ---
        Dim methInfo As System.Reflection.MethodInfo
        For Each methInfo In GetType(frmMain).GetMethods
            If Microsoft.VisualBasic.Right(methInfo.Name, 6) = "_Click" Then
                cboClickFunctions.Items.Add(methInfo.Name)
            End If
        Next

        '--- Take the MenuHeader Item and then add MouseDown Handlers to all items under it. ---
        '--- GetAllSubMenuItems adds MouseDown Handlers
        AddHandler_MouseDown_ToAllSubMenuItems(GetMenuHeaderItem("Tools").DropDownItems)

        InitFormSize()
    End Sub

    Private Sub initToolPalette()
        Dim isVisible As Boolean = frmMain.tsMyButtons.Visible
        PopulateGrid()
        ckShowTools.Checked = frmMain.tsMyButtons.Visible
        SetDocking()
        SetTextDirection()

        '--- populate "Available Icons" grid ---
        dgvImages.Rows.Clear()
        Dim rIndex As Integer
        Dim i As Integer
        For i = 0 To frmMain.imlToolbox.Images.Count - 1
            rIndex = dgvImages.Rows.Add()
            dgvImages.Rows(rIndex).Cells("ImageIndex").Value = rIndex
            dgvImages.Rows(rIndex).Cells("Image").Value = frmMain.imlToolbox.Images(rIndex)
        Next

        Debug.Print(frmMain.MyToolStripData.Tables("ToolStripInit").Rows(0).Item("ButtonStyle").ToString)
        Dim DispStyle As ToolStripItemDisplayStyle = frmMain.MyToolStripData.Tables("ToolStripInit").Rows(0).Item("ButtonStyle")
        SetButtonStyle(DispStyle)

    End Sub

    Private Sub PopulateGrid()
        Dim DS As DataSet = CreateDataset("exec dbo.sToolbox_GetToolStripUserButtons '" + IIf(Strings.Left(gDomainUserID, 5).ToUpper = "CORP\", Mid(gDomainUserID, 6), gDomainUserID) + "', 0", gConnectionString, "ButtonSettings")

        dgvTools.DataSource = DS.Tables("ButtonSettings")

        dgvTools.Columns("NickName").ReadOnly = True
        dgvTools.Columns("FullName").ReadOnly = True
        DS.Dispose()

    End Sub

    Private Sub dgvTools_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dgvTools.MouseDown
        If My.Computer.Keyboard.CtrlKeyDown = True Then
            DoDragDrop(dgvTools.CurrentRow.Cells("NickName").Value, DragDropEffects.Copy)
        End If
    End Sub

    Private Sub ckShowTools_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ckShowTools.CheckedChanged
        If FirstActivated = False Then
            If ckShowTools.Checked = True Then
                frmMain.tsMyButtons.Visible = True
            Else
                frmMain.tsMyButtons.Visible = False
            End If
        End If
        FirstActivated = False
    End Sub

    Private Sub cboDocking_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDocking.SelectedIndexChanged
        SetDocking()
    End Sub

    Private Sub cboTextDirection_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTextDirection.SelectedIndexChanged
        SetTextDirection()
    End Sub

    Private Sub cboButtonStyle_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboButtonStyle.SelectedIndexChanged
        SetButtonStyle()
    End Sub

    Private Sub SetDocking()
        If cboDocking.Text = "TOP" Then
            frmMain.tsMyButtons.Dock = DockStyle.Top
            frmMain.tsMyButtons.LayoutStyle = ToolStripLayoutStyle.Flow
        ElseIf cboDocking.Text = "Bottom" Then
            frmMain.tsMyButtons.Dock = DockStyle.Bottom
            frmMain.tsMyButtons.LayoutStyle = ToolStripLayoutStyle.Flow
        ElseIf cboDocking.Text = "Left" Then
            frmMain.tsMyButtons.Dock = DockStyle.Left
            frmMain.tsMyButtons.LayoutStyle = ToolStripLayoutStyle.VerticalStackWithOverflow
        ElseIf cboDocking.Text = "Right" Then
            frmMain.tsMyButtons.Dock = DockStyle.Right
            frmMain.tsMyButtons.LayoutStyle = ToolStripLayoutStyle.VerticalStackWithOverflow
        End If
    End Sub

    Private Function GetDockingSetting() As Integer
        If cboDocking.Text = "TOP" Then
            Return DockStyle.Top
        ElseIf cboDocking.Text = "Bottom" Then
            Return DockStyle.Bottom
        ElseIf cboDocking.Text = "Left" Then
            Return DockStyle.Left
        ElseIf cboDocking.Text = "Right" Then
            Return DockStyle.Right
        End If
    End Function

    Private Sub SetTextDirection()
        If cboTextDirection.Text = "Inherit" Then
            frmMain.tsMyButtons.TextDirection = ToolStripTextDirection.Inherit
        ElseIf cboTextDirection.Text = "Horizontal" Then
            frmMain.tsMyButtons.TextDirection = ToolStripTextDirection.Horizontal
        ElseIf cboTextDirection.Text = "Vertical90" Then
            frmMain.tsMyButtons.TextDirection = ToolStripTextDirection.Vertical90
        ElseIf cboTextDirection.Text = "Vertical270" Then
            frmMain.tsMyButtons.TextDirection = ToolStripTextDirection.Vertical270
        End If
    End Sub

    Private Function GetTextDirectionSetting() As Integer
        If cboTextDirection.Text = "Inherit" Then
            Return ToolStripTextDirection.Inherit
        ElseIf cboTextDirection.Text = "Horizontal" Then
            Return ToolStripTextDirection.Horizontal
        ElseIf cboTextDirection.Text = "Vertical90" Then
            Return ToolStripTextDirection.Vertical90
        ElseIf cboTextDirection.Text = "Vertical270" Then
            Return ToolStripTextDirection.Vertical270
        End If
    End Function

    Public Function SetButtonStyle(Optional ByVal DisplayStyle As ToolStripItemDisplayStyle = ToolStripItemDisplayStyle.None) As ToolStripItemDisplayStyle
        If DisplayStyle = ToolStripItemDisplayStyle.None Then
            If cboButtonStyle.Text = "Text" Then
                DisplayStyle = ToolStripItemDisplayStyle.Text
            ElseIf cboButtonStyle.Text = "Image" Then
                DisplayStyle = ToolStripItemDisplayStyle.Image
            Else
                DisplayStyle = ToolStripItemDisplayStyle.ImageAndText
            End If
        Else
            Select Case DisplayStyle
                Case ToolStripItemDisplayStyle.Text
                    cboButtonStyle.Text = "Text"
                Case ToolStripItemDisplayStyle.Image
                    cboButtonStyle.Text = "Image"
                Case ToolStripItemDisplayStyle.ImageAndText
                    cboButtonStyle.Text = "ImageAndText"
            End Select
        End If

        Dim tsItem As ToolStripItem
        For Each tsItem In frmMain.tsMyButtons.Items
            tsItem.DisplayStyle = DisplayStyle
        Next
        frmMain.MyToolStripData.Tables("ToolStripInit").Rows(0).Item("ButtonStyle") = DisplayStyle
        Return DisplayStyle
    End Function

    Private Function GetButtonStyle() As Integer
        If cboButtonStyle.Text = "Text" Then
            Return ToolStripItemDisplayStyle.Text
        ElseIf cboButtonStyle.Text = "Image" Then
            Return ToolStripItemDisplayStyle.Image
        ElseIf cboButtonStyle.Text = "ImageAndText" Then
            Return ToolStripItemDisplayStyle.ImageAndText
        Else
            Return ToolStripItemDisplayStyle.None
        End If
    End Function

    Private Sub btnSaveTool_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveTool.Click
        SaveMyButtons()
    End Sub

    '--- Return ID of new item. ---
    Private Function SaveMyButtons() As Integer
        Dim Sql As String
        Dim SaveStatus As Integer = 0
        Dim aryUserIdFull() As String = My.User.Name.Split("\")
        Dim myUserID As String = aryUserIdFull(UBound(aryUserIdFull))
        Dim NickName As String
        Dim DisplayName As String
        Dim FullName As String
        Dim ButtonState As Integer
        Dim ButtonOrder As Integer = 0          '<--- Used to save the order of Button location on the toolbar into the database.
        Dim AddressOfHandle As Integer = 0
        Dim FunctionName As String = "none"
        Dim ImageIndex As Integer = 0
        Dim DS As New DataSet
        DS = CreateDataset("SELECT * FROM dbo.tToolbox_ToolStrip WHERE Type = 'ButtonSetting'", gConnectionString, "ValidButtons")


        If MessageBox.Show("Save the Current Tool Bar.", "ToolStrip Save", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = Windows.Forms.DialogResult.OK Then

            '--- First, Delete any existing button record for the specific user ---
            Sql = "DELETE FROM dbo.tToolbox_ToolStrip WHERE Type = 'UserButton' and UserID = '" & myUserID & "'"
            ExecSqlScalar(Sql, gConnectionString)


            Dim tsItem As ToolStripItem
            Dim rItem As DataGridViewRow
            For Each rItem In dgvTools.Rows
                ButtonState = 0
                Debug.Print(rItem.Cells("NickName").Value.ToString)
                NickName = rItem.Cells("NickName").Value.ToString
                DisplayName = rItem.Cells("DisplayName").Value.ToString
                For Each tsItem In frmMain.tsMyButtons.Items
                    If tsItem.Tag.ToString = rItem.Cells("NickName").Value.ToString Then
                        Debug.Print(tsItem.Tag.ToString)
                        ButtonState = 1
                        ButtonOrder = frmMain.tsMyButtons.Items.IndexOf(tsItem)
                        Exit For
                    End If
                Next
                If ButtonState = 0 And rItem.Cells("NickName").Value.ToString <> rItem.Cells("DisplayName").Value.ToString Then
                    ButtonState = 2
                    ButtonOrder = 99
                End If
                If ButtonState > 0 Then
                    FullName = rItem.Cells("FullName").Value
                    Dim rValButtons As DataRow
                    For Each rValButtons In DS.Tables("ValidButtons").Rows
                        If rValButtons.Item("NickName").ToString = NickName Then
                            FunctionName = rValButtons.Item("FunctionName").ToString
                            ImageIndex = rValButtons.Item("ImageIndex")
                            Exit For
                        End If
                    Next

                    '--- Now, Insert new button settings for User ---
                    Sql = "INSERT INTO dbo.tToolbox_ToolStrip (Type, NickName, DisplayName, FullName, UserID, FunctionName, ImageIndex, ButtonState, ButtonOrder) "
                    Sql += "VALUES ('UserButton', '" & FixQuotes(NickName) & "', '" & FixQuotes(DisplayName) & "', '" & FixQuotes(FullName) & "', '"
                    Sql += myUserID & "', '" & FunctionName & "', '" & ImageIndex & "', " & ButtonState.ToString & ", " & ButtonOrder.ToString & ") "
                    Debug.Print(Sql)
                    ExecSqlScalar(Sql, gConnectionString)
                End If
            Next

            '--- Save ToolStrip (ToolStripInit) location, style and orientation. ---
            Sql = "DELETE FROM dbo.tToolbox_ToolStrip WHERE Type = 'ToolStripInit' and UserID = '" & myUserID & "'"
            ExecSqlScalar(Sql, gConnectionString)

            Dim Docking As Integer = GetDockingSetting()
            Dim TextDirection As Integer = GetTextDirectionSetting()
            Dim ButtonStyle As Integer = GetButtonStyle()
            Sql = "INSERT INTO dbo.tToolbox_ToolStrip (Type, Dock, TextDirection, ButtonStyle, UserID, DefaultState) "
            Sql += "VALUES "
            Sql += "('ToolStripInit', '" & Docking.ToString & "', '" & TextDirection.ToString & "', '" & ButtonStyle.ToString & "', '" & myUserID & "', '" & IIf(ckShowTools.Checked = True, 1, 0) & "')"

            ExecSqlScalar(Sql, gConnectionString)

        End If
        Return SaveStatus
    End Function

    Private Sub HighlightRow_ByNickName(ByVal Name As String, ByVal HighlightColor As Color)
        Dim dRow As DataGridViewRow
        '--- Second, Apply Highlight color to Named row ---
        For Each dRow In dgvTools.Rows
            If dRow.Cells("NickName").Value = Name Then
                dRow.DefaultCellStyle.BackColor = HighlightColor
            End If
        Next
    End Sub

    Public Sub HighlightUsedRows(ByVal NormalColor As Color, ByVal HighlightColor As Color, Optional ByVal ClearSelection As Boolean = True)
        Dim dRow As DataGridViewRow
        '--- First, Normalize all rows color. ---
        For Each dRow In dgvTools.Rows
            dRow.DefaultCellStyle.BackColor = NormalColor
            dRow.DefaultCellStyle.ForeColor = Color.Black
        Next

        Dim MyButton As ToolStripItem
        For Each MyButton In frmMain.tsMyButtons.Items
            HighlightRow_ByNickName(MyButton.Tag, HighlightColor)
        Next

        If ClearSelection = True Then dgvTools.ClearSelection()

        Me.dgvTools.Refresh()
    End Sub

    Public Sub btnAddTool_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddTool.Click
        If dgvTools.SelectedRows.Count > 0 Then
            Dim ButtonName As String
            Dim DisplayName As String
            Dim FullName As String
            Dim selRow As DataGridViewRow
            Dim ButtonImageIndex As Integer = 0
            For Each selRow In dgvTools.SelectedRows
                ButtonName = selRow.Cells("NickName").Value.ToString
                DisplayName = selRow.Cells("DisplayName").Value.ToString
                FullName = selRow.Cells("FullName").Value.ToString
                Dim validButton As DataRow
                For Each validButton In frmMain.MyToolStripData.Tables("ValidButtons").Rows
                    If FullName = validButton.Item("FullName") And ButtonName = validButton.Item("NickName") Then
                        ButtonImageIndex = validButton.Item("ImageIndex")
                    End If
                Next
                Try
                    frmMain.AddMyToolButton(DisplayName, ButtonName, FullName, False, GetButtonStyle, frmMain.imlToolbox.Images(ButtonImageIndex))
                Catch ex As Exception
                    Debug.Print(Err.Number.ToString + ": " + ex.Message)
                    Select Case Err.Number
                        Case 5
                            MessageBox.Show("It looks like the ImageIndex (" + ButtonImageIndex.ToString + ") is invalid.  Adding button with default ImageIndex (0)", "Invalid ImageIndex", MessageBoxButtons.OK)
                            frmMain.AddMyToolButton(DisplayName, ButtonName, FullName, False, GetButtonStyle, frmMain.imlToolbox.Images(0))
                        Case Else
                            MessageBox.Show("The button was not add due to the following error." + vbCrLf + vbCrLf + ex.Message, "Error", MessageBoxButtons.OK)
                    End Select

                End Try
            Next

            HighlightUsedRows(Color.White, Color.Aqua, True)
        End If

    End Sub

    Private Sub btnRemoveTool_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemoveTool.Click
        If dgvTools.SelectedRows.Count > 0 Then
            Dim ButtonName As String
            Dim selRow As DataGridViewRow
            For Each selRow In dgvTools.SelectedRows
                ButtonName = selRow.Cells("NickName").Value.ToString
                frmMain.DeleteMyToolButton(ButtonName)
            Next

            HighlightUsedRows(Color.White, Color.Aqua, True)
        End If
    End Sub

    Private Sub dgvTools_CellMouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvTools.CellMouseDoubleClick
        If My.Computer.Keyboard.CtrlKeyDown = True Then
            btnRemoveTool.PerformClick()
        Else
            btnAddTool.PerformClick()
        End If
    End Sub

    Private Sub EditMyToolNames()
        Dim dgvRow As DataGridViewRow
        For Each dgvRow In dgvTools.Rows
            If dgvRow.DefaultCellStyle.BackColor = Color.Aqua Then
                dgvRow.ReadOnly = False
                dgvRow.DefaultCellStyle.ForeColor = Color.Black
            Else
                dgvRow.ReadOnly = True
                dgvRow.DefaultCellStyle.ForeColor = Color.Gray
            End If
        Next
    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        EditMyToolNames()
    End Sub

    Private Sub dgvTools_Sorted(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvTools.Sorted
        HighlightUsedRows(Color.White, Color.Aqua, True)
    End Sub

    Private Sub lstMenuItems_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles lstMenuItems.DragDrop
        Dim eData As String = e.Data.GetData(DataFormats.Text)
        lstMenuItems.Items.Add(eData)
    End Sub

    Private Sub lstMenuItems_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles lstMenuItems.DragEnter
        e.Effect = DragDropEffects.Copy
    End Sub

    Private Sub btnRemoveTool_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles btnRemoveTool.DragDrop
        Dim ButtonName As String = e.Data.GetData(DataFormats.Text)

        Dim dRow As DataRow
        For Each dRow In frmMain.MyToolStripData.Tables("UserButtons").Rows
            If dRow("NickName").ToString = ButtonName Then
                Debug.Print(ButtonName)
                If MessageBox.Show("Delete Button [" & ButtonName & "]", "Delete Button", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = Windows.Forms.DialogResult.OK Then
                    frmMain.DeleteMyToolButton(ButtonName)
                    HighlightUsedRows(Color.White, Color.Aqua, True)
                End If
            End If
        Next
    End Sub

    Private Sub btnRemoveTool_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles btnRemoveTool.DragEnter
        e.Effect = DragDropEffects.Copy
    End Sub

    Private Sub lstMenuItems_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lstMenuItems.MouseDown
        If My.Computer.Keyboard.CtrlKeyDown = True Then
            DoDragDrop(sender.text, DragDropEffects.Copy)
        End If
    End Sub

    Private Sub HandleControls_NewPressed(ByVal AddNew As Boolean)
        If AddNew = True Then
            btnNew.Text = "Save"
        Else
            btnNew.Text = "New"
        End If
        dgvTools.Visible = Not AddNew
        lblNickName.Visible = AddNew
        txtNickName.Visible = AddNew
        lblFullName.Visible = AddNew
        txtFullName.Visible = AddNew
        lblFunctionName.Visible = AddNew
        cboClickFunctions.Visible = AddNew
        btnAddTool.Visible = Not AddNew
        btnRemoveTool.Visible = Not AddNew
        btnCancel.Visible = AddNew
        txtNewToolNotice.Visible = AddNew
        dgvImages.Visible = AddNew

        btnNew.Visible = AddNew
    End Sub

    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
        If btnNew.Text = "New" Then
            HandleControls_NewPressed(True)
        Else
            HandleControls_NewPressed(False)
            If txtNickName.Text = "" Then
                MessageBox.Show("Must enter a Name for the Button.", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If
            If txtFullName.Text = "" Then
                MessageBox.Show("Must enter a FullName from MenuStrip.  (You can drag this name by holding ctrl and dragging from MenuStrip.", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If
            If cboClickFunctions.Text = "" Then
                MessageBox.Show("Please select a method to run for the button.", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If

            Dim AddNewStr As String = "Add new ValidButton with the following information;" & vbCrLf & vbCrLf & "NickName=" & txtNickName.Text & vbCrLf & "FullName=" & txtFullName.Text & vbCrLf & "FunctionName=" & cboClickFunctions.Text
            If MessageBox.Show(AddNewStr, "Add New ValidButton", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk) = Windows.Forms.DialogResult.OK Then
                '--- Now that we have all the info needed, go ahead and save the New ButtonSetting ---
                Dim Sql As String
                Sql = "INSERT INTO dbo.tToolbox_ToolStrip (Type, NickName, DisplayName, FullName, FunctionName, ImageIndex) "
                Sql += "VALUES ('ButtonSetting', '" & FixQuotes(txtNickName.Text) & "', '" & FixQuotes(txtNickName.Text) & "', '" & FixQuotes(txtFullName.Text) & "', '"
                Sql += FixQuotes(cboClickFunctions.Text) & "', '" & dgvImages.SelectedRows.Item(0).Cells("ImageIndex").Value & "') "
                ExecSqlScalar(Sql, gConnectionString)
            Else
                '--- User pressed Cancel ---
            End If

            '--- Clear Fields ---
            txtNickName.Text = ""
            txtFullName.Text = ""
            cboClickFunctions.Text = ""
        End If
    End Sub

    Private Function FindItemInMenuByText(ByRef menus As ToolStripItemCollection, ByVal tsItemText As String) As ToolStripItem
        Dim c As ToolStripItem
        Dim t As ToolStripMenuItem
        Dim item As ToolStripItem

        For Each c In menus
            Debug.Print(c.Name)
            Debug.Print(c.Text)
            If c.Text = tsItemText Then
                Return c
            End If
            If c.GetType Is GetType(ToolStripMenuItem) Then
                t = c
                item = FindItemInMenuByText(t.DropDownItems, tsItemText)
                If Not item Is Nothing Then
                    Return item
                End If
            End If
        Next
        Return Nothing
    End Function

    Private Sub FillFieldFromDragEvent(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs)
        Dim MenuItemDragged As String = e.Data.GetData(DataFormats.Text)
        txtNickName.Text = MenuItemDragged
        txtFullName.Text = MenuItemDragged
    End Sub

    Private Sub txtFullName_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles txtFullName.DragDrop
        FillFieldFromDragEvent(sender, e)
    End Sub

    Private Sub txtFullName_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles txtFullName.DragEnter
        e.Effect = DragDropEffects.Copy
    End Sub

    Private Sub cboClickFunctions_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles cboClickFunctions.DragDrop
        FillFieldFromDragEvent(sender, e)
    End Sub

    Private Sub cboClickFunctions_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles cboClickFunctions.DragEnter
        e.Effect = DragDropEffects.Copy
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        HandleControls_NewPressed(False)
    End Sub

    Private Sub txtNickName_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles txtNickName.DragDrop
        FillFieldFromDragEvent(sender, e)
    End Sub

    Private Sub txtNickName_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles txtNickName.DragEnter
        e.Effect = DragDropEffects.Copy
    End Sub

    Private Sub grpToolBuild_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles grpToolBuild.Click
        If My.Computer.Keyboard.CtrlKeyDown = True And My.Computer.Keyboard.AltKeyDown = True And My.Computer.Keyboard.ShiftKeyDown = True Then
            btnNew.Visible = True
        End If
    End Sub

    Private Sub dgvTools_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvTools.CellDoubleClick
        If My.Computer.Keyboard.AltKeyDown = True Then
            If MessageBox.Show("Reset all DisplayName's to NickName's", "Reset Names", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.OK Then

                Debug.Print(sender.CurrentCell.OwningColumn.HeaderText)
                Dim sql As String = "exec dbo.sToolbox_GetToolStripUserButtons '" & gUserID.ToUpper & "', 2"
                Debug.Print(sql)
                ExecSqlScalar(sql, gConnectionString)

                PopulateGrid()
            End If
        End If
    End Sub

    Private Sub dgvTools_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvTools.CellValueChanged
        Debug.Print(dgvTools.Item("NickName", e.RowIndex).Value)
        Debug.Print(dgvTools.Item("DisplayName", e.RowIndex).Value)

        For Each tsItem As ToolStripItem In frmMain.tsMyButtons.Items
            If tsItem.Tag = dgvTools.Item("NickName", e.RowIndex).Value Then
                tsItem.Text = dgvTools.Item("DisplayName", e.RowIndex).Value
            End If
        Next
    End Sub

End Class