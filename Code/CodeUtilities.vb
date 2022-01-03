Imports System.Data.SqlClient
Imports System.Collections
Imports Microsoft.Office.Interop
Imports Outlook = Microsoft.Office.Interop.Outlook

Module CodeUtilities

    Public Sub DisplayUnexpectedSQLException(ByVal ex As SqlClient.SqlException)
        MessageBox.Show("An unexpected SQL Server database error has occurred." & vbCrLf & vbCrLf & "Error code : " & ex.ErrorCode.ToString & Constants.vbNewLine & "Message : " & ex.Message & vbCrLf & "Number : " & ex.Number, "Unexpected SQL error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Sub

    Public Sub DisplayUnexpectedGeneralError(ByVal ex As System.Exception)
        MessageBox.Show("An unexpected error has occurred." & vbCrLf & vbCrLf _
        & "Error message : " & ex.Message & vbCrLf & "Source : " & ex.Source.ToString _
        & vbCrLf & "TargetSite : " & ex.TargetSite.ToString, _
        "Unexpected error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Sub

    Public Sub ReadSettingsFromINFFile()

        'Set default values before reading INF file
        With UserSettings
            .DefaultConnectionType = 1
            .DefaultConnectionName = Nothing

            Dim myFile As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" + INFFilename
            If My.Computer.FileSystem.FileExists(myFile) Then
                Dim MainWindowInfoFound As Boolean
                Dim i As Integer
                Dim str As String
                Dim label As String
                Dim itemValue As String
                Dim charPos As Integer
                Dim lowerResolutionFound As Boolean
                Dim fileReader As System.IO.StreamReader
                fileReader = My.Computer.FileSystem.OpenTextFileReader(myFile)
                While Not fileReader.EndOfStream
                    str = fileReader.ReadLine()
                    If Left(str, 11) = "ServerList=" Then
                        str = str.Substring(11)
                        If str <> Nothing Then
                            Dim strArray1() As String = str.Split(";")
                            ReDim ServerList(-1)
                            For i = 0 To strArray1.GetUpperBound(0)
                                ReDim Preserve ServerList(i)
                                ServerList(i) = strArray1(i)
                            Next
                        End If
                    End If
                    If Left(str, 22) = "DefaultConnectionType=" Then
                        .DefaultConnectionType = Right(str, 1)
                    End If
                    If Left(str, 22) = "DefaultConnectionName=" Then
                        .DefaultConnectionName = str.Substring(22)
                    End If
                    If Left(str, 15) = "LastConnection=" Then
                        gLastConnection = str.Substring(15)
                    End If
                    If Left(str, 15) = "MainWindowInfo=" Then
                        MainWindowInfoFound = True
                        str = str.Substring(15)
                        If str <> "" Then
                            Dim strArray2() As String = str.Split(";")
                            For i = 0 To strArray2.GetUpperBound(0)
                                str = strArray2(i)
                                charPos = InStr(str, ":")
                                label = Left(str, charPos)
                                itemValue = Right(str, Len(str) - charPos)
                                With frmMain
                                    Select Case label
                                        Case "X:"
                                            .Left = CInt(itemValue)
                                        Case "Y:"
                                            .Top = CInt(itemValue)
                                        Case "H:"
                                            .Height = CInt(itemValue)
                                            If .Height > My.Computer.Screen.Bounds.Height Then
                                                lowerResolutionFound = True
                                                .Height = My.Computer.Screen.Bounds.Height
                                            End If
                                        Case "W:"
                                            .Width = CInt(itemValue)
                                            If .Width > My.Computer.Screen.Bounds.Width Then
                                                lowerResolutionFound = True
                                                .Width = My.Computer.Screen.Bounds.Width
                                            End If
                                        Case "WindowState:"
                                            If itemValue = "Normal" Or itemValue = "Minimized" Then
                                                .WindowState = FormWindowState.Normal
                                            Else
                                                .WindowState = FormWindowState.Maximized
                                            End If
                                        Case "AutoCenter:"
                                            If itemValue = "True" Then
                                                .StartPosition = FormStartPosition.CenterScreen
                                                UserSettings.MainWindowAutoCenter = True
                                            Else
                                                .StartPosition = FormStartPosition.Manual
                                                UserSettings.MainWindowAutoCenter = False
                                            End If
                                    End Select
                                End With
                            Next
                            If lowerResolutionFound Then
                                frmMain.StartPosition = FormStartPosition.CenterScreen
                            End If
                        End If
                    End If

                End While
                fileReader.Close()

                If Not MainWindowInfoFound Then
                    frmMain.Height = 768
                    frmMain.Width = 1024
                    frmMain.StartPosition = FormStartPosition.CenterScreen
                    .MainWindowAutoCenter = True
                End If
            End If
        End With

    End Sub

    Public Sub WriteSettingsToINFFile()
        Dim str As String
        Dim i As Integer
        Dim myFile As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" + INFFilename
        Dim fileWriter As System.IO.StreamWriter
        fileWriter = My.Computer.FileSystem.OpenTextFileWriter(myFile, False)

        str = "ServerList="
        For i = 0 To ServerList.GetUpperBound(0)
            If i > 0 Then str += ";"
            str += ServerList(i)
        Next
        fileWriter.WriteLine(str)

        str = "DefaultConnectionType=" + UserSettings.DefaultConnectionType.ToString
        fileWriter.WriteLine(str)

        str = "DefaultConnectionName=" + UserSettings.DefaultConnectionName
        fileWriter.WriteLine(str)

        With frmMain
            str = "MainWindowInfo="
            If frmMain.WindowState = FormWindowState.Normal Then
                str += "X:" + .Location.X.ToString + ";"
                str += "Y:" + .Location.Y.ToString + ";"
                str += "H:" + .Height.ToString + ";"
                str += "W:" + .Width.ToString + ";"
            Else
                str += "X:" + .RestoreBounds.X.ToString + ";"
                str += "Y:" + .RestoreBounds.Y.ToString + ";"
                str += "H:" + .RestoreBounds.Height.ToString + ";"
                str += "W:" + .RestoreBounds.Width.ToString + ";"
            End If
            str += "WindowState:" + .WindowState.ToString + ";"
            str += "AutoCenter:" + UserSettings.MainWindowAutoCenter.ToString
        End With
        fileWriter.WriteLine(str)

        str = "LastVersionRun=" + AppVersion
        fileWriter.WriteLine(str)

        str = "LastConnection=" + gLastConnection
        fileWriter.WriteLine(str)

        fileWriter.Close()
    End Sub

    Public Sub CreateEmailMessage(ByVal Recipient As String, ByVal ccRecipient As String, ByVal Subject As String, ByVal msg As String, ByVal msgType As String)
		'Dim Signature As String
		Dim MyOutlookApp As Outlook.Application
        Dim MyOutlookMailItem As Outlook.MailItem

		'2018.10.26 Barry
		'	Two Changes:
		'	1.	Modified to get a reference to the running instance of Outlook, if possible.
		'	2.	Took out the code that retrieved HTMLBody from the newly-created email message.
		'		Outlook no longer permits retrieving that information. 
		'		The result is a new email without your signature, which is actually not a big deal.
		'		The user can manually add their sig at the end of the email message should they so desire.
		'---------------------------------------------------------------------------------------------------------

		Try
			If Not IsNothing(Process.GetProcessesByName("OUTLOOK")) Then ' get a reference to the current running copy of Outlook
				MyOutlookApp = System.Runtime.InteropServices.Marshal.GetActiveObject("Outlook.Application")
			Else ' launch an instance of Outlook
				MyOutlookApp = New Outlook.Application()
			End If

			'Create a new email
			MyOutlookMailItem = MyOutlookApp.CreateItem(Interop.Outlook.OlItemType.olMailItem)

			With MyOutlookMailItem
				.To = Recipient
				.CC = ccRecipient
				.Subject = Subject
				.HTMLBody = msg
				.Display()
			End With

		Catch ex As System.Exception
			DisplayUnexpectedGeneralError(ex)
		Finally
			MyOutlookApp = Nothing
			MyOutlookMailItem = Nothing
		End Try

	End Sub

    Public Function StringIsInteger(ByVal aStr As String) As Boolean
        Dim isInteger As Boolean = True
        Dim i As Integer = 0
        While i <= Len(aStr) - 1 And isInteger
            If Asc(aStr.Substring(i, 1)) < 48 Or Asc(aStr.Substring(i, 1)) > 57 Then
                isInteger = False
            Else
                i += 1
            End If
        End While

        Return isInteger
    End Function

    Public Sub CenterForm(ByVal FormObj As Form, ByVal parrentObj As Object, Optional ByVal offsetWidth As Integer = 0, Optional ByVal offsetHeight As Integer = 0, Optional ByVal DoWidth As Boolean = True, Optional ByVal DoHeight As Boolean = True)
        If DoWidth = True Then
            If FormObj.Width > parrentObj.Width - offsetWidth Then
                FormObj.Left = 0
            Else
                FormObj.Left = (parrentObj.Width / 2) - (FormObj.Width / 2) + offsetWidth
            End If
        End If

        If DoHeight = True Then
            If FormObj.Height > parrentObj.Height - offsetHeight Then
                FormObj.Top = parrentObj.Top
            Else
                FormObj.Top = (parrentObj.Height / 2) - (FormObj.Height / 2) + offsetHeight
            End If
        End If
    End Sub

    Public Sub SelectGridRowByID(ByVal GridObj As Object, ByVal IdColName As String, ByVal IdNum As Integer)
        Dim i As Integer
        For i = 1 To GridObj.Rows.Count - 1
            If GridObj.Rows(i).Cells(IdColName).Value = IdNum Then
                GridObj.ClearSelection()
                GridObj.Rows(i).Cells(0).Selected = True
            End If
        Next
    End Sub

    Public Function ExecSqlScalar(ByVal sqlString As String, ByVal SqlConnStr As String, Optional ShowError As Boolean = True) As String
        Dim ReturnValue As String
        Using conn As New SqlClient.SqlConnection(SqlConnStr)
            Dim cmd As New SqlClient.SqlCommand(sqlString, conn)
            Try
                conn.Open()
                ReturnValue = cmd.ExecuteScalar()
            Catch sqlex As SqlClient.SqlException
                If ShowError Then DisplayUnexpectedSQLException(sqlex)
                ReturnValue = Nothing
            End Try
        End Using
        Return ReturnValue
    End Function

    Public Function ExecSqlDataReader(ByVal sqlString As String, ByRef SqlConn As SqlClient.SqlConnection) As System.Data.SqlClient.SqlDataReader
        Dim dReader As SqlClient.SqlDataReader
        Dim cmd As New SqlClient.SqlCommand(sqlString, SqlConn)
        Try
            SqlConn.Open()
            dReader = cmd.ExecuteReader

        Catch sqlex As SqlClient.SqlException
            DisplayUnexpectedSQLException(sqlex)
            dReader = Nothing
        Finally
            cmd.Dispose()
        End Try

        Return dReader
    End Function

    ''' <summary>
    ''' Return a Data Table from SQL
    ''' </summary>
    ''' <param name="SqlString"></param>
    ''' <param name="ConnectionString"></param>
    ''' <param name="CommandTimeout"></param>
    ''' <returns>DataTable</returns>
    ''' <remarks>Mike Giordano</remarks>
    Public Function ExecSqlDataTable(ByVal SqlString As String, ByVal ConnectionString As String, Optional ByVal CommandTimeout As Integer = 0) As DataTable
        Dim aTable As New DataTable
        Dim SqlDataAd As New System.Data.SqlClient.SqlDataAdapter(SqlString, ConnectionString)
        SqlDataAd.SelectCommand.CommandTimeout = CommandTimeout
        SqlDataAd.Fill(aTable)

        Return aTable
    End Function

    Public Function CreateDataset(ByVal SqlStr As String, ByVal ConnectionStr As String, Optional ByVal TableName As String = "", Optional ByVal ExistingDataset As DataSet = Nothing) As DataSet


        Dim SqlDataAd As New System.Data.SqlClient.SqlDataAdapter(SqlStr, ConnectionStr)

        Dim dSet As New DataSet
        If TableName = Nothing Then
            SqlDataAd.Fill(dSet)
        Else
            If Not ExistingDataset Is Nothing Then
                dSet = ExistingDataset.Copy
                ExistingDataset.Dispose()
            End If
            If dSet.Tables(TableName) IsNot Nothing Then
                dSet.Tables.Remove(TableName)
            End If
            Try
                dSet.Tables.Add(TableName)
                SqlDataAd.Fill(dSet.Tables(TableName))

            Catch ex As Exception
                MessageBox.Show("Error: " + ex.Message, "Error was found.", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
        SqlDataAd.Dispose()

        Return dSet
    End Function

    Public Function FormatPhoneNumber(ByVal phnNumber As String, Optional ByVal ReturnType As Integer = 0)
        Dim trimChars As String = " ()-."           ' Formatting characters to be removed
        Dim tmpStr As String = phnNumber
        Dim numToParse As String = ""
        Dim ReturnFormat As String = ""

        Dim c1 As Char
        Dim c2 As Char
        Dim found As Boolean = False

        '--- Remove initial 1 if found ---
        If Left(tmpStr, 1) = "1" Then tmpStr = Mid(tmpStr, 2)

        '--- Remove all existing formatting characters ---
        For Each c1 In tmpStr.ToCharArray
            found = False
            For Each c2 In trimChars.ToCharArray
                If c1 = c2 Then
                    found = True
                    Exit For
                End If
            Next
            If found = False Then
                numToParse += c1
            End If
        Next

        Select Case ReturnType
            Case 0
                ReturnFormat = "({0}) {1}-{2}"
            Case 1
                ReturnFormat = "{0}-{1}-{2}"
            Case 2
                ReturnFormat = "{0}.{1}.{2}"

        End Select

        If numToParse = "" Then
            Return ""
        Else
            Return String.Format(ReturnFormat, numToParse.Substring(0, 3), numToParse.Substring(3, 3), numToParse.Substring(6))
        End If
    End Function

    Public Function convert_BitmapToIcon(ByVal bm As Bitmap) As Icon
        Dim ico As Icon
        Dim ptr As IntPtr = bm.GetHicon

        ico = Icon.FromHandle(ptr)
        Return ico
    End Function


    ''' <summary>
    ''' <para>TextIN - mimmic the SQL IN function</para>
    ''' <para>example:   TextIN( "AA", "AA,BB,CC") returns True</para>
    ''' <para>           TextIN(  "A", "AA,BB,CC") returns False</para>
    ''' </summary>
    ''' <param name="StrValue"></param>
    ''' <param name="ListOfValues"></param>
    ''' <param name="Delimiter"></param>
    ''' <returns>Boolean (True or False)</returns>
    ''' <remarks>--- April 23, 2008 MSG ---</remarks>
    Public Function TextIN(ByVal StrValue As String, ByVal ListOfValues As String, Optional ByVal Delimiter As Char = ",") As Boolean
        Return DirectCast(ListOfValues.Split(Delimiter), IList).Contains(StrValue)
    End Function

    ''' <summary>
    ''' This function uses the RichMessageBox control.
    ''' </summary>
    ''' <param name="TextMessageOrPath"></param>
    ''' <param name="FormCaption"></param>
    ''' <param name="FormBackColor"></param>
    ''' <param name="TextBackColor"></param>
    ''' <param name="TextForeColor"></param>
    ''' <param name="FormSize"></param>
    ''' <param name="FontSize"></param>
    ''' <param name="MessageBoxBorderStyle"></param>
    ''' <param name="iconStyle"></param>
    ''' <param name="buttons"></param>
    ''' <param name="DefaultButton"></param>
    ''' <param name="MessageboxScrollBars"></param>
    ''' <param name="MessageboxFadeStyle"></param>
    ''' <param name="MessageboxFadeDuration"></param>
    ''' <returns></returns>

    Public Function RichMessageBoxShow(ByVal TextMessageOrPath As String, _
        ByVal FormCaption As String, _
        ByVal FormBackColor As System.Drawing.Color, _
        ByVal TextBackColor As System.Drawing.Color, _
        ByVal TextForeColor As System.Drawing.Color, _
        ByVal FormSize As Size, _
        Optional ByVal FontSize As Integer = 10, _
        Optional ByVal MessageBoxBorderStyle As BorderStyle = BorderStyle.None, _
        Optional ByVal iconStyle As RichMessageBoxIcon = RichMessageBoxIcon.Information, _
        Optional ByVal buttons As RichMessageBoxButtons = RichMessageBoxButtons.OK, _
        Optional ByVal DefaultButton As RichMessageboxDefaultButton = RichMessageboxDefaultButton.None, _
        Optional ByVal MessageboxScrollBars As ScrollBars = ScrollBars.Vertical, _
        Optional ByVal MessageboxFadeStyle As RichMessageboxFadeStyle = RichMessageboxFadeStyle.None, _
        Optional ByVal MessageboxFadeDuration As Integer = 50) _
        As CustomDialogResult

        Dim rmb As System.Windows.Forms.RichMessageBox

        If Not IO.File.Exists(TextMessageOrPath) Then
            '--- Plain Text input ---
            rmb = New System.Windows.Forms.RichMessageBox(TextMessageOrPath, FormCaption, iconStyle, buttons, DefaultButton)
        Else
            '--- Using a Rich Text File ---
            Dim args As RichTextArgs = New RichTextArgs(TextMessageOrPath, RichTextBoxStreamType.RichText)
            rmb = New System.Windows.Forms.RichMessageBox(args, FormCaption, iconStyle, buttons, DefaultButton)
        End If

        rmb.MessageFont = New Font("Arial", FontSize, FontStyle.Regular)
        rmb.BackColor = FormBackColor
        rmb.Size = FormSize
        rmb.MessageBackcolor = TextBackColor
        rmb.MessageForeColor = TextForeColor
        rmb.MessageBorderStyle = MessageBoxBorderStyle
        rmb.MessageScrollBars = MessageboxScrollBars
        rmb.FadeStyle = MessageboxFadeStyle
        rmb.FadeDuration = MessageboxFadeDuration

        Try
            Dim resp As CustomDialogResult = rmb.ShowDialog()
            Return resp
        Catch ex As Exception
            MessageBox.Show("Unable to show the RichMessageBox:  " & Environment.NewLine & ex.Message)
        End Try

    End Function

    Public Sub DrawLine(ByVal obj As Object, ByVal x1 As Integer, ByVal y1 As Integer, ByVal x2 As Integer, ByVal y2 As Integer, ByVal PenColor As Color, ByVal PenWidth As Integer)
        If IsDBNull(obj) Or obj Is Nothing Then Exit Sub
        Dim g As Graphics = obj.CreateGraphics
        Dim myPen As New Pen(PenColor)
        myPen.Width = 5
        g.DrawLine(myPen, x1, y1, x2, y2)
    End Sub

    Public Sub DrawLine(ByVal frm As Form, ByVal pntBegin As Point, ByVal pntEnd As Point, ByVal penColor As Color, Optional ByVal penWidth As Integer = 1, Optional ByVal penDashStyle As Drawing2D.DashStyle = Drawing2D.DashStyle.Solid)
        If IsDBNull(frm) Or frm Is Nothing Then Exit Sub
        Dim g As Graphics
        Dim myPen As New Pen(penColor)
        myPen.Width = penWidth
        myPen.DashStyle = penDashStyle

        g = Graphics.FromHwnd(frm.Handle)

        g.DrawLine(myPen, pntBegin, pntEnd)
    End Sub

    Public Sub DrawLine(ByVal obj As Object, ByVal pntBegin As Point, ByVal pntEnd As Point, ByVal penColor As Color, Optional ByVal penWidth As Integer = 1, Optional ByVal penDashStyle As Drawing2D.DashStyle = Drawing2D.DashStyle.Solid)
        If IsDBNull(obj) Or obj Is Nothing Then Exit Sub
        Dim g As Graphics = obj.CreateGraphics
        Dim myPen As New Pen(penColor)
        myPen.Width = penWidth
        myPen.DashStyle = penDashStyle

        g.DrawLine(myPen, pntBegin, pntEnd)
    End Sub

    '--- Get a Menu Header item ---
    Public Function GetMenuStripHeaderItem2(ByVal Menu As MenuStrip, ByVal MenuItemName As String) As Object
        Dim mItem As Object

        For Each mItem In frmMain.MenuStrip1.Items
            If mItem.Text = MenuItemName Then
                Return mItem
            End If
        Next

        Return Nothing
    End Function
    '--- Get a Menu Header item ---
    Public Function GetMenuStripHeaderItem(ByVal Menu As MenuStrip, ByVal MenuItemName As String) As ToolStripMenuItem
        Dim mItem As ToolStripMenuItem

        For Each mItem In frmMain.MenuStrip1.Items
            If mItem.Text = MenuItemName Then
                Return mItem
            End If
        Next

        Return Nothing
    End Function

    Public Function GetSubMenuItemCollection( _
    ByVal menus As ToolStripItemCollection, _
    Optional ByVal iLevel As Integer = 0, _
    Optional ByVal WritePathToTag As Boolean = False) As List(Of ToolStripItem)
        Dim c As ToolStripItem
        Dim t As ToolStripMenuItem
        Dim tsItems As New List(Of ToolStripItem)

        For Each c In menus
            If WritePathToTag Then c.Tag = BuildItemPath(c, "\")
            tsItems.Add(c)

            If c.GetType Is GetType(ToolStripMenuItem) Then
                t = c
                If t.HasDropDownItems Then
                    Dim iLst As List(Of ToolStripItem)
                    iLst = GetSubMenuItemCollection(t.DropDownItems, iLevel + 1, True)
                    For Each iLi As ToolStripItem In iLst
                        tsItems.Add(iLi)
                    Next
                End If
            End If
        Next
        Return tsItems
    End Function

    Public Function BuildItemPath(ByVal tsItem As ToolStripItem, ByVal SepChar As String) As String
        Dim tItem As ToolStripItem = tsItem
        Dim path As String = ""
        While tItem IsNot Nothing
            path = tItem.Text + SepChar + path
            tItem = tItem.OwnerItem
        End While

        '--- Remove final SepChar ---
        path = path.Substring(0, path.Length - SepChar.Length)

        Return path
    End Function

    Public Function PadValue(ByVal Number As String, ByVal Length As Integer, Optional ByVal PadWith As String = "0") As String
        While Number.Length < Length
            Number = PadWith + Number
        End While
        Return Number
    End Function

    Public Sub ShowTempMessageBox(Message As String, BoxTitle As String, Optional msTime As Integer = 5000, Optional BoxHeight As Integer = 200, Optional BoxWidth As Integer = 500)
        Dim frmMsgbox As New Form
        Dim lblMessage As New Label
        Dim fnt As Font = New Font("Segoe UI", 9, System.Drawing.FontStyle.Bold)

        frmMsgbox.Height = BoxHeight            '<-- Set Form Height
        frmMsgbox.Width = BoxWidth              '<-- Set Form Width
        frmMsgbox.Text = BoxTitle               '<-- Set Form Title
        frmMsgbox.ControlBox = False            '<-- No controls..  Form will close automatically when time (msTime) expires.

        lblMessage.Parent = frmMsgbox                           '<-- Make Form the Parent of the Label
        lblMessage.Dock = DockStyle.Fill                        '<-- Make Label fill entire Form.
        lblMessage.Text = Message                               '<-- Set the Label text from Message string
        lblMessage.Font = fnt                                   '<-- Use this font rather than the default.  Even spaces.
        lblMessage.BorderStyle = BorderStyle.None               '<-- No Label border
        lblMessage.BackColor = SystemColors.Control             '<-- Set the background color of the Label to the standard Control color
        lblMessage.TextAlign = ContentAlignment.MiddleCenter    '<-- Center all text in the box

        frmMsgbox.Show()
        Application.DoEvents()

        System.Threading.Thread.Sleep(msTime) '<-- Wait some time (in milliseconds) then dispose of message box.

        frmMsgbox.Dispose()
    End Sub

End Module

