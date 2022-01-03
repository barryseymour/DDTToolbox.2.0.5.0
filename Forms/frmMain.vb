Imports System.Data.SqlClient
Public Class frmMain
    Public formLoading As Boolean
    Public IsDARTTreeEditWindowOpen As Boolean
    Public IsManageReportsEditWindowOpen As Boolean
    Public WindowList As New System.Collections.Generic.List(Of clsListWin)
    Public Shared MyToolStripData As DataSet
    Private OrigSender As String = ""

    Public Dragging As Boolean
    Public mousex, mousey As Integer
    Private frmOpened As Boolean = False = 0 'LAshby 4/3/18 - added this variable

    Private Sub frmMain_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        formLoading = False
    End Sub

    Private Sub frmMain_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        WriteSettingsToINFFile()
        End
    End Sub

    Private Sub frmMain_KeyUp(ByVal sender As Object, ByVal c As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
        '--- Hot Keys for Windows Controls ---
        If Me.MdiChildren.GetLength(0) > 1 Then
            If c.Shift = True And c.Control = True Then
                If c.KeyValue = 67 Then         ' "C"
                    ddmiCascadeAllMdiChildren(sender, c)                'CASCADE
                ElseIf c.KeyValue = 72 Then     ' "H"
                    ddmiTileHorizontalAllMdiChildren(sender, c)         'TILE HORIZONTAL
                ElseIf c.KeyValue = 86 Then     ' "V"
                    ddmiTileVerticalAllMdiChildren(sender, c)           'TILE VERTICAL
                ElseIf c.KeyValue = 75 Then     ' "K"
                    ddmiCloseAllMdiChildren(sender, c)                  'CLOSE All
                ElseIf c.KeyValue = 77 Then     ' "M"
                    ddmiMinimizeAllMdiChildren(sender, c)               'MINIMIZE All
                ElseIf c.KeyValue = 82 Then     ' "R"
                    ddmiRestoreAllMdiChildren(sender, c)                'RESTORE All
                End If
            End If
        End If
    End Sub

    Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        formLoading = True
        lblStatusUser.Text = "Authenticated User : " + gDomainUserID
        Me.Text = AppName + " v" + AppVersion
        mnuWindowsOpen.Enabled = False

        initMyButtonToolStrip()

        '--- Add DropDown menu(s) to the MenuStrip, populated from a table in the database DDT_Common. ---
        BuildDropdown(MenuStrip1, HelpToolStripMenuItem, 1)
        BuildDropdown(MenuStrip1, "Links", 1)

        '--- Add a DropDown menu to the MenuStrip if the local file exists.  These links are stored locally. ---
        add_MyLinks(MenuStrip1)
    End Sub

    Private Sub mnuFileExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFileExit.Click
        Me.Close()
    End Sub

    Private Sub HandleNoConnectionsDefined()
        MessageBox.Show("Can't open this tool until at least one connection has been defined.", "No connections defined", MessageBoxButtons.OK)
        frmConnections.ShowDialog()
    End Sub

    '--- Default, Returns the index of an existing window.  If ReturnIndex = False then return a count of matching windows ---
    Private Function isInWindowsList(ByVal WindowName As String, Optional ByVal ReturnIndex As Boolean = True) As Integer
        Dim i As Integer
        Dim cnt As Integer = 0
        Dim parenPos1 As Integer
        Dim parenPos2 As Integer
        Dim checkName1 As String
        Dim checkName2 As String
        Dim wn As clsListWin

        parenPos1 = InStr(WindowName, "(")
        If parenPos1 > 0 Then
            checkName1 = Mid(WindowName, 1, parenPos1 - 1)
        Else
            checkName1 = Mid(WindowName, 1)
        End If

        For Each wn In WindowList
            parenPos2 = InStr(wn.WinName, "(")

            If parenPos2 > 0 Then
                checkName2 = Mid(wn.WinName, 1, parenPos2 - 1)
            Else
                checkName2 = Mid(wn.WinName, 1)
            End If

            If checkName1 = checkName2 Then
                If ReturnIndex = True Then
                    Return i
                Else
                    cnt += 1
                End If
            End If
        Next
        Return IIf(ReturnIndex = True, -1, cnt)
    End Function

    Private Sub showWindow(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim wn As clsListWin
        Dim itemIndex As Integer = sender.Owner.Items.IndexOf(sender)

        For Each wn In WindowList
            If wn.mIndex = itemIndex Then
                wn.FormObject.Select()
                If wn.FormObject.WindowState = FormWindowState.Minimized Then
                    wn.FormObject.WindowState = FormWindowState.Normal
                End If
            End If
        Next
    End Sub

    Public Sub buildWindowList()
        Dim frmAry As Form()
        Dim eHndlr As System.EventHandler = AddressOf showWindow

        Dim eDdmiCascadeHndlr As System.EventHandler = AddressOf ddmiCascadeAllMdiChildren
        Dim eDdmiTileHorizontalHndlr As System.EventHandler = AddressOf ddmiTileHorizontalAllMdiChildren
        Dim eDdmiTileVerticalHndlr As System.EventHandler = AddressOf ddmiTileVerticalAllMdiChildren
        Dim eDdmiCloseHndlr As System.EventHandler = AddressOf ddmiCloseAllMdiChildren
        Dim eDdmiMinimizeHndlr As System.EventHandler = AddressOf ddmiMinimizeAllMdiChildren
        Dim eDdmiRestoreHndlr As System.EventHandler = AddressOf ddmiRestoreAllMdiChildren
        Dim i As Integer
        Dim mIndex As Integer
        Dim winName As String
        Dim toolTip As String
        Dim cnt As Integer
        Dim ddBmenu As New ToolStripMenuItem("Windows Control")

        '--- clear existing items in dropdown ---
        mnuWindowsOpen.DropDownItems.Clear()
        '--- clear existing items in class ---
        WindowList.Clear()

        '--- Get array of Child forms ---
        frmAry = Me.MdiChildren

        '--- If there are no MDI Children then do nothing and exit the sub ---
        If Me.MdiChildren.GetLength(0) < 1 Then Exit Sub
        If IsNothing(Me.ActiveMdiChild) Then Exit Sub

        '--- Add some Menu Commands, only if there is more than 1 item in the list. ---
        If Me.MdiChildren.GetLength(0) > 1 Then
            mIndex = ddBmenu.DropDownItems.IndexOf(ddBmenu.DropDownItems.Add("CASCADE   (<CTRL+Click> No Form ReSizing)", mnuWindowsOpen.BackgroundImage, eDdmiCascadeHndlr))
            ddBmenu.DropDownItems(mIndex).ToolTipText = "HotKey = Ctrl+Shift+C  OR  Ctrl+Shift+Alt+C"
            mIndex = ddBmenu.DropDownItems.IndexOf(ddBmenu.DropDownItems.Add("TILE Horizontal", mnuWindowsOpen.BackgroundImage, eDdmiTileHorizontalHndlr))
            ddBmenu.DropDownItems(mIndex).ToolTipText = "HotKey = Ctrl+Shift+H"
            mIndex = ddBmenu.DropDownItems.IndexOf(ddBmenu.DropDownItems.Add("TILE Vertical", mnuWindowsOpen.BackgroundImage, eDdmiTileVerticalHndlr))
            ddBmenu.DropDownItems(mIndex).ToolTipText = "HotKey = Ctrl+Shift+V"
            ddBmenu.DropDownItems.Add("-")
            mIndex = ddBmenu.DropDownItems.IndexOf(ddBmenu.DropDownItems.Add("CLOSE ALL", mnuWindowsOpen.BackgroundImage, eDdmiCloseHndlr))
            ddBmenu.DropDownItems(mIndex).ToolTipText = "HotKey = Ctrl+Shift+K"
            mIndex = ddBmenu.DropDownItems.IndexOf(ddBmenu.DropDownItems.Add("MINIMIZE ALL", mnuWindowsOpen.BackgroundImage, eDdmiMinimizeHndlr))
            ddBmenu.DropDownItems(mIndex).ToolTipText = "HotKey = Ctrl+Shift+M"
            mIndex = ddBmenu.DropDownItems.IndexOf(ddBmenu.DropDownItems.Add("RESTORE ALL", mnuWindowsOpen.BackgroundImage, eDdmiRestoreHndlr))
            ddBmenu.DropDownItems(mIndex).ToolTipText = "HotKey = Ctrl+Shift+R"

            mIndex = mnuWindowsOpen.DropDownItems.Add(ddBmenu)
            mnuWindowsOpen.DropDownItems(mIndex).ForeColor = Color.Blue

            mnuWindowsOpen.DropDownItems.Add("-", mnuWindowsOpen.BackgroundImage, Nothing)
        End If

        '--- Scan through MDIChildren to create "Windows" pulldown menu ---
        For i = 0 To Me.MdiChildren.GetLength(0) - 1
            winName = frmAry(i).Text
            toolTip = frmAry(i).Name

            cnt = isInWindowsList(winName, False)   '--- Get count of window name currently in the list.
            If cnt > 0 Then                         '--- Then, increment window name based on count.
                winName = winName + "(-" + (cnt + 1).ToString + "-)"
            End If
            mIndex = mnuWindowsOpen.DropDownItems.IndexOf(mnuWindowsOpen.DropDownItems.Add(winName, mnuWindowsOpen.BackgroundImage, eHndlr))
            mnuWindowsOpen.DropDownItems(mIndex).ToolTipText = toolTip

            '--- Now save the information to WindowList (Collection of Class clsListWin) ---
            WindowList.Add(New clsListWin(winName, frmAry(i).Name, frmAry(i).Text, mIndex, i, toolTip, frmAry(i)))
        Next
    End Sub

    Private Sub mnuWindowsOpen_DropDownOpened(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuWindowsOpen.DropDownOpened
        Dim i As Integer
        '--- Show currently selected form by placing the forms icon to the left of the window item in the list ---
        For i = 0 To WindowList.Count - 1
            If Comparer.Equals(WindowList(i).FormObject, ActiveMdiChild) = True Then
                mnuWindowsOpen.DropDownItems(WindowList(i).mIndex).Image = WindowList(i).FormObject.Icon.ToBitmap
            End If
        Next
    End Sub

    Private Sub frmMain_MdiChildActivate(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.MdiChildActivate
        Timer1.Enabled = True
    End Sub

    Private Sub Timer1_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        '--- Only show the Windows pulldown if there's at least 1 item in the list. ---
        If Me.MdiChildren.GetLength(0) > 0 Then
            mnuWindowsOpen.Enabled = True
        Else
            mnuWindowsOpen.Enabled = False
        End If
        Timer1.Enabled = False
    End Sub

    Private Sub mnuWindowsOpen_DropDownOpening(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuWindowsOpen.DropDownOpening
        buildWindowList()
    End Sub

    Private Sub ddmiCascadeAllMdiChildren(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim winPosT As Integer = 0
        Dim winPosIncT As Integer = 30
        Dim winPosL As Integer = 0
        Dim winPosIncL As Integer = 25
        Dim fm As Form

        If (My.Computer.Keyboard.CtrlKeyDown And Not My.Computer.Keyboard.ShiftKeyDown) _
        Or (My.Computer.Keyboard.CtrlKeyDown And My.Computer.Keyboard.AltKeyDown And My.Computer.Keyboard.ShiftKeyDown) Then
            For Each fm In Me.MdiChildren
                If fm.WindowState <> FormWindowState.Minimized Then
                    fm.Top = winPosT
                    fm.Left = winPosL
                    winPosT += winPosIncT
                    winPosL += winPosIncL
                    fm.Select()
                    fm.WindowState = FormWindowState.Normal
                End If
            Next
        Else
            Me.LayoutMdi(MdiLayout.Cascade)
        End If
    End Sub

    Private Sub ddmiTileHorizontalAllMdiChildren(ByVal sender As System.Object, ByVal e As System.EventArgs)
        With Me
            .LayoutMdi(MdiLayout.TileHorizontal)
            '--- Wiggle the last MDI form to force the MDI parent to add the scroll bar if required.  VS seems to have a bug. ---
            With .MdiChildren(.MdiChildren.GetLength(0) - 1)
                .Top = .Top + 1
                .Top = .Top - 1
            End With
        End With
    End Sub

    Private Sub ddmiTileVerticalAllMdiChildren(ByVal sender As System.Object, ByVal e As System.EventArgs)
        With Me
            .LayoutMdi(MdiLayout.TileVertical)
            '--- Wiggle the last MDI form to force the MDI parent to add the scroll bar if required.  VS seems to have a bug. ---
            With .MdiChildren(.MdiChildren.GetLength(0) - 1)
                .Left = .Left + 1
                .Left = .Left - 1
            End With
        End With
    End Sub

    Private Sub ddmiCloseAllMdiChildren(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim fm As Form
        If Me.MdiChildren.GetLength(0) > 0 Then
            If MessageBox.Show("CLOSE ALL MDI CHILD WINDOWS!", "Close all MDI Child Windows.", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.OK Then
                For Each fm In Me.MdiChildren
                    fm.Close()
                Next
                mnuWindowsOpen.DropDownItems.Clear()
            End If
        End If
    End Sub

    Private Sub ddmiMinimizeAllMdiChildren(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim fm As Form
        If Me.MdiChildren.GetLength(0) > 0 Then
            For Each fm In Me.MdiChildren
                fm.WindowState = FormWindowState.Minimized
            Next
        End If
    End Sub

    Private Sub ddmiRestoreAllMdiChildren(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim fm As Form
        If Me.MdiChildren.GetLength(0) > 0 Then
            For Each fm In Me.MdiChildren
                fm.WindowState = FormWindowState.Normal
            Next
        End If
    End Sub

    Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick
        lblCurrentDateTime.Text = Now
    End Sub

#Region "Code related to 'MyTools Builder' "
    '--- Check for ToolStrip button already existing ---
    Private Function ExistingToolStripButton(ByVal bText As String) As Boolean
        Dim butItem As ToolStripItem
        For Each butItem In tsMyButtons.Items
            If butItem.Text = bText Then
                Return True
            End If
        Next
        Return False
    End Function

    Public Sub AddMyToolButton(ByVal buttonName As String, ByVal NickName As String, ByVal FullName As String, Optional ByVal AllowDuplicates As Boolean = False, Optional ByVal DisplayStyle As ToolStripItemDisplayStyle = ToolStripItemDisplayStyle.ImageAndText, Optional ByVal ButtonImage As Image = Nothing)
        '--- If no image is passed in, then, for now, use the same image for all buttons. ---
        If ButtonImage Is Nothing Then
            ButtonImage = imlToolbox.Images(0)
        End If

        If ExistingToolStripButton(buttonName) = False Or AllowDuplicates = True Then
            Dim mIndex As Integer
            Dim myHndler As System.EventHandler = Nothing

            mIndex = tsMyButtons.Items.IndexOf(tsMyButtons.Items.Add(buttonName, ButtonImage))
            tsMyButtons.Items(mIndex).ImageAlign = ContentAlignment.MiddleLeft
            tsMyButtons.Items(mIndex).TextAlign = ContentAlignment.MiddleLeft
            tsMyButtons.Items(mIndex).DisplayStyle = DisplayStyle
            tsMyButtons.Items(mIndex).Tag = NickName

            '--- Add a MouseDown handle for each ButtonItem. ---
            SetButtonHandle(tsMyButtons.Items(mIndex))
        End If
    End Sub

    Public Sub DeleteMyToolButton(ByVal buttonName As String)
        Dim butItem As ToolStripItem
        For Each butItem In tsMyButtons.Items
            If butItem.Tag = buttonName Then
                tsMyButtons.Items.Remove(butItem)
                Exit Sub
            End If
        Next
    End Sub

    Private Sub tsMyButtons_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles tsMyButtons.DragDrop
        Dim eData As String = e.Data.GetData(DataFormats.Text)
        Dim NickName As String = eData
        Dim FullName As String

        Dim dRow As DataRow
        For Each dRow In MyToolStripData.Tables("ValidButtons").Rows
            If NickName = dRow.Item("NickName").ToString Then
                FullName = dRow.Item("FullName").ToString
                AddMyToolButton(NickName, NickName, FullName, False)
            End If
        Next
    End Sub

    Public Sub initMyButtonToolStrip()
        Dim sql As String = "exec dbo.sToolbox_GetToolStripInitValues '" & gUserID & "'"
        Dim connectStr As String = gConnectionString
        MyToolStripData = CreateDataset(sql, connectStr, "ToolStripInit", MyToolStripData)
        Dim Docking As Integer
        Dim TextDirection As Integer
        Dim DefaultState As Integer
        Dim ButtonStyle As Integer
        Dim ImageIndex As Integer = 0

        Docking = DockStyle.Top
        TextDirection = ToolStripTextDirection.Horizontal
        DefaultState = 0
        ButtonStyle = ToolStripItemDisplayStyle.ImageAndText
        With MyToolStripData.Tables("ToolStripInit")
            If .Rows.Count = 0 Then
                '--- No DB rec for current user.  Set Default Values ---
                Docking = DockStyle.Top
                TextDirection = ToolStripTextDirection.Horizontal
                DefaultState = 0
                ButtonStyle = ToolStripItemDisplayStyle.ImageAndText
            Else
                Docking = .Rows(0).Item("Dock")
                TextDirection = .Rows(0).Item("TextDirection")
                DefaultState = .Rows(0).Item("DefaultState")
                ButtonStyle = .Rows(0).Item("ButtonStyle")
            End If

            tsMyButtons.Dock = Docking
            tsMyButtons.TextDirection = TextDirection

            If Docking = 1 Or Docking = 2 Then      ' TOP or Bottom
                tsMyButtons.LayoutStyle = ToolStripLayoutStyle.Flow
            Else                                    ' Left or Right
                tsMyButtons.LayoutStyle = ToolStripLayoutStyle.StackWithOverflow
            End If

            If DefaultState = 1 Then
                tsMyButtons.Visible = True
            Else
                tsMyButtons.Visible = False
            End If
        End With

        MyToolStripData = CreateDataset("SELECT * FROM dbo.tToolbox_ToolStrip WHERE Type = 'ButtonSetting'", connectStr, "ValidButtons", MyToolStripData)

        '--- Add saved buttons. ---
        sql = "exec dbo.sToolbox_GetToolStripUserButtons '" + gUserID + "', 1"

        MyToolStripData = CreateDataset(sql, connectStr, "UserButtons", MyToolStripData)
        If MyToolStripData.Tables("UserButtons").Rows.Count > 0 Then
            Dim dRow As DataRow
            With MyToolStripData.Tables("UserButtons")
                For Each dRow In .Rows
                    ImageIndex = dRow("ImageIndex")
                    Try
                        If IIf(IsDBNull(dRow("ButtonState")), 1, dRow("ButtonState")) = 1 Then
                            AddMyToolButton(IIf(IsDBNull(dRow("DisplayName")), dRow("NickName"), dRow("DisplayName")), dRow("NickName"), dRow("FullName"), False, ButtonStyle, imlToolbox.Images(ImageIndex))
                        End If
                    Catch ex As Exception
                        MessageBox.Show("Error adding a button to MyTools", "Error", MessageBoxButtons.OK)
                    End Try
                Next
            End With
            frmToolBuilder.SetButtonStyle(ButtonStyle)
        End If

        InitMyButtonsMouseDownHandles()
    End Sub

    Private Sub tsMyButtons_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles tsMyButtons.DragEnter
        e.Effect = DragDropEffects.Copy
    End Sub

    Private Sub tsMyButtons_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles tsMyButtons.ItemClicked
        Dim FunctionName As String
        Dim myHndler As System.EventHandler = Nothing

        Dim row As DataRow
        For Each row In MyToolStripData.Tables("ValidButtons").Rows
            If e.ClickedItem.Tag = row.Item("NickName").ToString Then
                FunctionName = row.Item("FunctionName").ToString

                Dim methInfo As System.Reflection.MethodInfo
                For Each methInfo In GetType(frmMain).GetMethods
                    If FunctionName = methInfo.Name Then
                        Dim param(1) As Object
                        Dim myType As Type = Me.GetType()
                        Dim myMethodInfo As Reflection.MethodInfo = myType.GetMethod(FunctionName)
                        param(0) = sender
                        param(1) = e
                        If Not myMethodInfo Is Nothing Then
                            myMethodInfo.Invoke(Me, param)
                        Else
                            MessageBox.Show("method [" & FunctionName & "] not found")
                        End If
                    End If
                Next
            End If
        Next
    End Sub
#Region "Set ToolStrip ButtonItem.MouseDown Handles"
    '--- Need ToolStripItem MouseDown event if I want to Drag button FROM toolbar ---
    Private Sub InitMyButtonsMouseDownHandles()
        Dim tsItem As ToolStripItem
        For Each tsItem In tsMyButtons.Items
            SetButtonHandle(tsItem)
        Next
    End Sub

    '--- Set the MouseDown handle for the ButtonItem ---
    Private Sub SetButtonHandle(ByVal ButtonItem As ToolStripItem)
        AddHandler ButtonItem.MouseDown, AddressOf tsMyButtonsItems_MouseDown
    End Sub

    '--- Initiate DragDrop for ButtonItems.  Don't know if I'll use this yet. ---
    Private Sub tsMyButtonsItems_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        If My.Computer.Keyboard.CtrlKeyDown = True Then
            Dim tsItem As ToolStripItem = tsMyButtons.GetItemAt(e.X, e.Y)

            DoDragDrop(tsItem, DragDropEffects.Copy)
            Dragging = True

            '04/03/2018 LAshby added this entire else block and the variable frmOpened, which calls a sub that opens child forms
        Else
            If frmOpened = False Then
                Call ToolstripMenuItem_Click(sender, e)
                frmOpened = True
            Else
                frmOpened = False
            End If
        End If
    End Sub
#End Region
#End Region

    Private Sub BuildDropdown(ByVal aMenu As Object, ByVal ToolStripMenu As Object, Optional ByVal ClearExistingMenu As Integer = 1)
        Dim connectStr As String = gConnectionString
        Dim ItemName As String = ""
        Dim ItemLink As String = ""
        Dim ItemToolTip As String = ""
        Dim SepCount As Integer = 0
        Dim MenuName As String = ""
        Dim MenuTitle As String = ""
        Dim dsHelpMenu As New DDT_Dataset
        Dim ddMenu As ToolStripMenuItem
        Dim isExistingObject As Boolean = False

        Try
            If ToolStripMenu.GetType.ToString.ToUpper = "System.String".ToUpper Or ToolStripMenu.GetType.ToString.ToUpper = "String".ToUpper Then
                MenuName = ToolStripMenu
                ddMenu = New ToolStripMenuItem(MenuName)
            ElseIf ToolStripMenu.GetType.ToString.ToUpper = "System.Windows.Forms.ToolStripMenuItem".ToUpper Then
                MenuName = DirectCast(ToolStripMenu, ToolStripMenuItem).Name
                ddMenu = ToolStripMenu
                If ClearExistingMenu = 2 Then
                    DirectCast(ToolStripMenu, ToolStripMenuItem).Dispose()
                End If
                isExistingObject = True
            Else
                ddMenu = Nothing
                MessageBox.Show("Invalid Dropdown Menu Name")
                Exit Sub
            End If

            dsHelpMenu.BuildTable("select * from DDT_Common.dbo.tToolbox_MenuItems where MenuName = '" + MenuName + "' Order by Sort", connectStr, "BuildMenu")
            If dsHelpMenu.Tables("BuildMenu").Rows.Count >= 1 Then
                MenuTitle = dsHelpMenu.Tables("BuildMenu").Rows(0).Item("MenuTitle").ToString
                If MenuTitle.Length > 0 Then
                    ddMenu.Text = MenuTitle
                Else
                    ddMenu.Text = MenuName
                End If
            End If

            If ClearExistingMenu = 1 Then
                If ddMenu.HasDropDownItems Then
                    ddMenu.DropDownItems.Clear()
                End If
            End If

            Dim mIndex As Integer
            Dim eOpenLinkHndlr As System.EventHandler = AddressOf OpenLink

            For Each row As DataRow In dsHelpMenu.Tables("BuildMenu").Rows
                ItemName = row.Item("ItemName").ToString
                ItemLink = row.Item("ItemLink").ToString
                ItemToolTip = row.Item("ToolTip").ToString
                If ItemName.ToUpper = "Separator".ToUpper Then
                    ddMenu.DropDownItems.Add("-")
                    SepCount += 1
                Else
                    mIndex = ddMenu.DropDownItems.IndexOf(ddMenu.DropDownItems.Add(ItemName, mnuWindowsOpen.BackgroundImage, eOpenLinkHndlr))
                    If ItemToolTip.Length > 0 Then
                        ddMenu.DropDownItems(mIndex).ToolTipText = ItemToolTip
                    Else
                        ddMenu.DropDownItems(mIndex).ToolTipText = ItemName
                    End If
                    ddMenu.DropDownItems(mIndex).Tag = ItemLink
                End If
            Next

            If Not isExistingObject Or ClearExistingMenu = 2 Then
                AddHandler ddMenu.Click, AddressOf MenuItem_Click   '<-- Had to add a click event handler if I want to dynamically rebuild on click.
                ddMenu.Name = MenuName
                aMenu.Items.Add(ddMenu)
            End If

        Catch ex As Exception
            DisplayUnexpectedGeneralError(ex)
        End Try
    End Sub

    Private Sub OpenLink(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim itemIndex As Integer = sender.Owner.Items.IndexOf(sender)
        Try
            Process.Start(sender.tag.ToString)
        Catch ex As Exception
            MessageBox.Show("Problem openning link in the Menu at index " + itemIndex.ToString + vbCrLf + vbCrLf + sender.tag.ToString)
        End Try
    End Sub

    Private Sub HelpToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HelpToolStripMenuItem.Click
        MenuItem_Click(sender, e)
    End Sub

    Private Sub MenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        BuildDropdown(MenuStrip1, sender, 1)
    End Sub

    Private Sub add_MyLinks(ByVal aMenu As Object)
        Dim mIndex As Integer = -1
        Dim eOpenLinkHndlr As System.EventHandler = AddressOf OpenLink
        Dim ItemName As String = ""
        Dim ItemLink As String = ""
        Dim appPath As String = Application.StartupPath
        Dim MyLinksFile As String = appPath + "\Toolbox_MyLinks.txt"
        Dim MenuName As String = "MyLinks"
        Dim ddMenu As New ToolStripMenuItem(MenuName)
        ddMenu.Text = MenuName

        Dim MyLinks As String = MyLinksFile
        If My.Computer.FileSystem.FileExists(MyLinks) Then
            Dim str As String = ""
            Dim strAry() As String
            Dim fileReader As System.IO.StreamReader
            fileReader = My.Computer.FileSystem.OpenTextFileReader(MyLinks)
            While Not fileReader.EndOfStream
                str = fileReader.ReadLine()
                strAry = str.Split("|")
                ItemName = strAry(0)
                ItemLink = strAry(1)
                mIndex = ddMenu.DropDownItems.IndexOf(ddMenu.DropDownItems.Add(ItemName, mnuWindowsOpen.BackgroundImage, eOpenLinkHndlr))
                ddMenu.DropDownItems(mIndex).Tag = ItemLink
            End While

            fileReader.Close()

            If mIndex >= 0 Then
                ddMenu.Name = MenuName
                aMenu.Items.Add(ddMenu)
            End If
        End If
    End Sub

    '--- Show the application installation path.  (path to the .exe file) ---
    Private Sub ShowAppPath()
        Try
            Dim AppPath As String = Application.StartupPath
            If MessageBox.Show("Show Application Path.  Click OK to open folder..." + vbCrLf + vbCrLf + AppPath, "Show App Path", MessageBoxButtons.OKCancel) = Windows.Forms.DialogResult.OK Then
                Process.Start(AppPath)
            End If
        Catch ex As Exception
            Debug.Print("Invalid application path")
        End Try
    End Sub

    Private Sub MenuStrip1_ItemClicked(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuStrip1.DoubleClick
        If My.Computer.Keyboard.CtrlKeyDown = True Then ShowAppPath()
    End Sub

    'The followiong sub replaced dozen of other subs in this form (LAshby 2/16/18)
    Public Sub ToolstripMenuItem_Click(sender As Object, e As EventArgs) Handles WFMReportTreeToolStripMenuItem.Click, _
        MyToolsToolStripMenuItem.Click, DARTTngReportTreeToolStripMenuItem.Click, ManageReportsToolStripMenuItem.Click, _
        SecurityloginAndPasswordTrackingToolStripMenuItem.Click, ScheduleReportMonitorToolStripMenuItem.Click, _
        DART_TNGImportMonitorToolStripMenuItem.Click, DARTTNGApplicationToolStripMenuItem1.Click, QARTSettingsToolStripMenuItem.Click, _
        DARTTNGRetrieveReportParamsToolStripMenuItem.Click, DevelopersToolStripMenuItem.Click, OptionsToolStripMenuItem.Click, _
        ManageServerConnectionsToolStripMenuItem.Click, ApplicationUsersToolStripMenuItem.Click

        Dim NewMDIChild As New Form

        '04/03/2018 LAshby - added sender.tostring statements to some of these statements to accommodate the buttons, which have different names
        If (sender.ToString = "Report Tree" And OrigSender = "Workforce Manager") Or sender.ToString = "WFM Tree" Then
            NewMDIChild = New frmWFMTree()
        ElseIf sender.ToString = "MyTools Builder" Or sender.ToString = "MyTools Bldr" Then
            NewMDIChild = New frmToolBuilder()
        ElseIf (sender.ToString = "Report Tree" And OrigSender = "DART") Or sender.ToString = "DART_TNG Tree" Then
            NewMDIChild = New frmDARTTngTree()
        ElseIf sender.ToString = "Manage Reports" Then
            NewMDIChild = New frmManageReports()
        ElseIf sender.ToString = "Security (login and password tracking)" Or sender.ToString = "Log/Pass Tracking" Then
            If ServerList.Length = 0 Then
                HandleNoConnectionsDefined()
            Else
                NewMDIChild = New frmLoginTracking()
            End If
        ElseIf sender.ToString = "Schedule Reports Monitor" Then
            NewMDIChild = New frmDART_TNGScheduledReports
            NewMDIChild.Width = Me.Width - 25
        ElseIf sender.ToString = "Import Monitor" Then
            If ServerList.Length = 0 Then
                HandleNoConnectionsDefined()
            Else
                NewMDIChild = New frmDART_TNGImport()
            End If
        ElseIf sender.ToString = "Application" Or sender.ToString = "DART Application" Then
            If ServerList.Length = 0 Then
                HandleNoConnectionsDefined()
            Else
                NewMDIChild = New frmDART_TNGApp
            End If
        ElseIf sender.ToString = "    QART" Or sender.ToString = "QART" Then
            If ServerList.Length = 0 Then
                HandleNoConnectionsDefined()
            Else
                NewMDIChild = New frmQAApp()
            End If
        ElseIf sender.ToString = "Retrieve Report Params" Then
            If ServerList.Length = 0 Then
                HandleNoConnectionsDefined()
            Else
                NewMDIChild = New frmDART_TNGRetrieveDARTReportParams()
            End If
        ElseIf sender.ToString = "Developers" Then
            If ServerList.Length = 0 Then
                HandleNoConnectionsDefined()
            Else
                NewMDIChild = New frmDevelopers()
            End If
        ElseIf sender.ToString = "Options..." Or sender.ToString = "Options" Then
            frmOptions.ShowDialog()
            NewMDIChild = Nothing
        ElseIf sender.ToString = "Manage server connections..." Or sender.ToString = "Manage SrvConns" Then
            frmConnections.ShowDialog()
            NewMDIChild = Nothing
        ElseIf sender.ToString = "Application Users" Then
            If ServerList.Length = 0 Then
                HandleNoConnectionsDefined()
            Else
                NewMDIChild = New frmApplicationUsers()
            End If
        End If

        If Not IsNothing(NewMDIChild) Then
            NewMDIChild.MdiParent = Me
            Me.Cursor = Cursors.WaitCursor
            NewMDIChild.Show()
        End If
        Me.Cursor = Cursors.Default

    End Sub

    Private Sub DARTToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DARTToolStripMenuItem.Click
        OrigSender = "DART"
    End Sub

    Private Sub WorkforceManagerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles WorkforceManagerToolStripMenuItem.Click
        OrigSender = "Workforce Manager"
    End Sub

	
End Class
