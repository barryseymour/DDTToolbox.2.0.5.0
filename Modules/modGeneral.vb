Imports System.Data.SqlClient
Imports Microsoft.VisualBasic.FileIO
Imports System.Math
''' <summary>
''' General functions, globals,and Enums. Global variables are:
''' <list type="bullet">
''' <item><description>dsroot - This is the main dataset.</description></item>
''' <item><description>gSaveUserPreferences - Indicates whether the user wants his preferences saved.</description></item>
''' </list>
''' </summary>
''' <remarks>Joey Cruz</remarks>
Public Module modGeneral
    'We should consider putting all these settings into a table same as we do DART
    Public INFFilename As String = "DDTToolboxSettings.inf"
    Public AppName = "DDT Toolbox"
    Public AppVersion As String = My.Application.Info.Version.Major.ToString + "." + My.Application.Info.Version.Minor.ToString + "." + My.Application.Info.Version.Build.ToString + "." + My.Application.Info.Version.MinorRevision.ToString
    Public gWorkstationID As String = My.Computer.Name
    Public gOsPlatform As String = My.Computer.Info.OSPlatform
    Public gOsName As String = My.Computer.Info.OSFullName
    Public dsroot As New DataSet
    Public Prod_Server As String = ""
    Public Dev_Server As String = ""
    Public QA_Server As String = ""
    Public ServerAttempts As Integer = 0
    Public CallFromType As String = ""
    Public CallFrom As String = ""
    Public gErrorMsg As String = "There has been a problem with the DDT Toolbox."
    Public gError As Boolean 'Global Error Flag
    Public gServerFileName As String = ""
    Public DoNotReposition As Boolean = False
    Public ScheduleWithDates As Boolean
    Public SchedType As New ArrayList()
    Public SchedText As New ArrayList()
    Public SchedValues As New ArrayList()
    Public SchedRptCtrls As New ArrayList()
    Public SpecialID As Integer = 0
    Public dsSR As New DDT_Dataset  '<-- I added this global dataset for Schedule Reports.
    Public thisNode As TreeNode
    Public StartDate As Date = Nothing
    Public EndDate As Date = Nothing
    Public currentIndex As Integer = 0
    Public currTabName As String
    Public DateType As String = ""
    Public Declare Function GetInputState Lib "user32" () As Int32
    Public HelpFile As String = ""
    Public PrevID As Integer = -1
    Public ServerList(-1) As String
    Public gLastConnection As String
    Public gUserID As String
    Public gDomainUserID As String
    Public UserSettings As New clsUserSettings
    Public gShowVersionNotesOnStartup As Boolean
    Public gSourceNodeText As String
    Public gDestinationFolderText As String
    Public gSelectedAppUserType As String
    Public CallingForm As String = Nothing
    Public WMFirstName As String = Nothing
    Public WMLastName As String = Nothing
    Public WMUserID As String = Nothing
    Public gServer As String = "SQWDARTD001" 'this is used for the tree and  manage reports and will always be the development server
    Public gCurrentServer As String = "SQWDARTP001"
    Public gDirPrimary As String = "\\servername\ApplicationSupport\DART\Support"
    Public gInsertReport As Boolean
    Public gConnectionString As String = "Connect Timeout = 0; Initial Catalog=DDT_Common;Data Source=" + gCurrentServer + ";Integrated Security=SSPI;"
    Public gApplicationName As String = My.Application.Info.Title.ToString
    Public gApplicationVersion As String = My.Application.Info.Version.Major.ToString + "." + My.Application.Info.Version.Minor.ToString
    Public gDatabaseConnection As New SqlConnection

    Public Enum DDT_ActionType
        ViewReport
        Schedule
        Reschedule
        SaveChanges
        Help
    End Enum

    Public Enum DDT_NodeType
        Folder
        Report
        Schedule
    End Enum

    Public Enum DDT_ReportStatus
        Active
        Inactive
    End Enum

    Public Enum DDT_DateType As Short
        MinDate = 0
        MaxDate = 1
        DefaultStartDate = 2
        DefaultEndDate = 3
    End Enum

    Public Enum UserRole As Short
        User = 0
        PowerUser = 1
        Developer = 2
    End Enum

    'Constants for gSchedulingMode
    Public Const gcAdding As Integer = 1
    Public Const gcEditing As Integer = 2

    ''' <summary>
    ''' This function removes the first occurrence of a particular string from within another string.
    ''' </summary>
    ''' <param name="OriginalString"></param>
    ''' <param name="StringToRemove"></param>
    ''' <returns>String</returns>
    ''' <remarks>by Joey Cruz</remarks>
    Public Function StripFirstOccurrence(ByVal OriginalString As String, ByVal StringToRemove As String) As String
        StripFirstOccurrence = OriginalString.Remove(OriginalString.IndexOf(StringToRemove), StringToRemove.Length)
    End Function

    ''' <summary>
    ''' This function looks for a an occurrence of a string within another string.
    ''' </summary>
    ''' <param name="OriginalString"></param>
    ''' <param name="StringToFind"></param>
    ''' <returns>Boolean - True if found.</returns>
    ''' <remarks>by Joey Cruz</remarks>
    Public Function DoesStringContainSubString(ByVal OriginalString As String, ByVal StringToFind As String) As Boolean
        If OriginalString Is Nothing Then Return False
        DoesStringContainSubString = (OriginalString.IndexOf(StringToFind) > -1)
    End Function

    ''' <summary>
    ''' This function removes every occurrence of a particular string from within another string.
    ''' </summary>
    ''' <param name="OriginalString"></param>
    ''' <param name="StringToRemove"></param>
    ''' <returns>String</returns>
    ''' <remarks>by Joey Cruz</remarks>
    Public Function StripEveryOccurrence(ByVal OriginalString As String, ByVal StringToRemove As String) As String
        StripEveryOccurrence = Replace(OriginalString, StringToRemove, "")
    End Function

    Public Function GetClassName(ByVal FullClassPath As String) As String
        Dim positionOfLastDot As Integer
        positionOfLastDot = FullClassPath.LastIndexOf(".")
        Return FullClassPath.Substring(positionOfLastDot + 1)
    End Function

    Public Function IsDARTClass(ByVal FullClassPath As String) As Boolean
        Dim positionOfLastDot As Integer
        positionOfLastDot = FullClassPath.LastIndexOf(".")
        If FullClassPath.Substring(positionOfLastDot + 1).StartsWith("DDT") Then
            Return True
        Else
            Return False
        End If
    End Function

    ''' <summary>
    ''' This function fixes a string to allow single quotes to be passed to SQL Server.
    ''' </summary>
    ''' <remarks>
    ''' This function was carried over from DART Pro written in VB6.
    ''' </remarks>
    Public Function FixQuotes(ByVal stringToCheck As String) As String
        'Dim stringToProcess As String = ""
        'Dim quotePos As Integer
        CallFromType = "Function"
        CallFrom = "FixQuotes"

        '07/13/2018 (LAshby) - added this new abbreviated code
        Try
            If IsNothing(stringToCheck) OrElse IsDBNull(stringToCheck) Then Return "" Else Return stringToCheck.Replace("'", "''")
        Catch ex As Exception
            Debug.Print("Unhandled Error in FixQuotes: " & ex.Message)
            Return ""
        End Try

        'Try
        '    If Len(stringToCheck) = 0 Then
        '        FixQuotes = stringToCheck
        '    Else
        '        '--- see if quote contained in string
        '        If InStr(stringToCheck, "'") = 0 Then
        '            FixQuotes = stringToCheck
        '        Else
        '            '--- loop through field replacing single quotes with
        '            '--- two single quotes
        '            For quotePos = 1 To Len(stringToCheck)
        '                If Mid$(stringToCheck, quotePos, 1) = "'" Then
        '                    stringToProcess = stringToProcess & "''"
        '                Else
        '                    stringToProcess = stringToProcess & Mid$(stringToCheck, quotePos, 1)
        '                End If
        '            Next quotePos
        '            FixQuotes = stringToProcess
        '        End If
        '    End If
        'Catch ex As Exception
        '    EmailErrorAlert(gDatabaseConnection, ex.Message, gUserID, gApplicationName, gApplicationVersion, gUserID, CallFromType, CallFrom, gWorkstationID, gOsName)
        '    FixQuotes = stringToProcess
        'End Try
    End Function

    ''' <summary>
    ''' Transforms a string into AnchorStyles.
    ''' </summary>
    ''' <param name="anchorStyle">String</param>
    ''' <returns>AnchorSthles</returns>
    ''' <remarks>by Joey Cruz</remarks>
    Public Function GetAnchorStyles(ByVal anchorStyle As String) As AnchorStyles
        Dim anchor As AnchorStyles = Nothing
        CallFromType = "Function"
        CallFrom = "GetAnchorStyles"

        Try
            Select Case anchorStyle
                Case "Left"
                    anchor = AnchorStyles.Left
                Case "Right"
                    anchor = AnchorStyles.Right
                Case "Top"
                    anchor = AnchorStyles.Top
                Case "Bottom"
                    anchor = AnchorStyles.Bottom
                Case "Top, Left"
                    anchor = AnchorStyles.Top + AnchorStyles.Left
                Case "Top, Right"
                    anchor = AnchorStyles.Top + AnchorStyles.Right
                Case "Top, Left, Right"
                    anchor = AnchorStyles.Top + AnchorStyles.Left + AnchorStyles.Right
                Case "Bottom, Left"
                    anchor = AnchorStyles.Bottom + AnchorStyles.Left
                Case "Bottom, Right"
                    anchor = AnchorStyles.Bottom + AnchorStyles.Right
                Case "Bottom, Left, Right"
                    anchor = AnchorStyles.Bottom + AnchorStyles.Left + AnchorStyles.Right
                Case "None"
                    anchor = AnchorStyles.None
                Case Else
                    anchor = AnchorStyles.None
            End Select
        Catch ex As Exception
            EmailErrorAlert(gDatabaseConnection, ex.Message, gUserID, gApplicationName, gApplicationVersion, gUserID, CallFromType, CallFrom, gWorkstationID, gOsName)
        End Try
        GetAnchorStyles = anchor
    End Function

    ''' <summary>
    ''' Transforms a string docking style into dockstyle.
    ''' </summary>
    ''' <param name="dockingStyle">String</param>
    ''' <returns>DockStyle</returns>
    ''' <remarks>by Joey Cruz</remarks>
    Public Function GetDockStyles(ByVal dockingStyle As String) As DockStyle
        Dim dock As DockStyle = DockStyle.None
        CallFromType = "Function"
        CallFrom = "GetDockStyles"

        Try
            Select Case dockingStyle
                Case "Fill"
                    dock = DockStyle.Fill
                Case "Top"
                    dock = DockStyle.Top
                Case "Left"
                    dock = DockStyle.Left
                Case "Right"
                    dock = DockStyle.Right
                Case "Bottom"
                    dock = DockStyle.Bottom
                Case "None"
                    dock = DockStyle.None
                Case Else
                    dock = DockStyle.None
            End Select
        Catch ex As Exception
            EmailErrorAlert(gDatabaseConnection, ex.Message, gUserID, gApplicationName, gApplicationVersion, gUserID, CallFromType, CallFrom, gWorkstationID, gOsName)
        End Try
        GetDockStyles = dock
    End Function

    ''' <summary>
    ''' Recursively scan a TreeView to find and return the node (DARTTreeNode) having the given FindKey from anywhere in the Tree.   Example call: aNode = GetNodeByKey(aTreeView, "ReportID=" + aNode.ReportID.ToString, True)
    ''' </summary>
    ''' <param name="aTreeView">TreeView Control.</param>
    ''' <param name="FindKey">FindKey can be: "ReportID=", "ReportNumber=", "ReportName=", "ReportFullName=", "NodeName=", "FullPath=", "Name=", "ItemTypeID=", "NodeID=", "TreeLevelID="</param>
    ''' <param name="DoSelect">If TRUE, the returning node will also be selected in the TreeView.</param>
    ''' <param name="arrNodes">This optional parameter is used to pass in the nodes to search.  If not used, node search will begin at the top of the TreeView.</param>
    ''' <returns>DARTTreeNode</returns>
    ''' <remarks>by Mike Giordano (2/2/2008)</remarks>
    Public Function GetNodeByKey(ByVal aTreeView As TreeView, ByVal FindKey As String, _
    Optional ByVal DoSelect As Boolean = False, _
    Optional ByRef arrNodes As TreeNodeCollection = Nothing) As DARTTreeNode
        Dim found As Boolean = False
        Dim foundNode As DARTTreeNode = Nothing
        Dim intParam As Integer = 0
        Dim strParam As String = ""
        Dim eqlPos As Integer = InStr(FindKey, "=")
        Dim FindKeyType As String = FindKey.Substring(0, eqlPos)
        Dim FindKeyValue As String = FindKey.Substring(eqlPos)
        CallFromType = "Function"
        CallFrom = "GetNodeByKey"

        Try
            If arrNodes Is Nothing Then
                arrNodes = aTreeView.Nodes
            End If

            Dim aNode As DARTTreeNode = Nothing
            For Each aNode In arrNodes
                Select Case FindKeyType
                    Case "ReportID="
                        If aNode.ReportID.ToString = FindKeyValue Then
                            found = True
                            Exit For
                        End If
                    Case "ReportNumber="
                        If aNode.ReportNumber = FindKeyValue Then
                            found = True
                            Exit For
                        End If
                    Case "ReportName="
                        If aNode.ReportName = FindKeyValue Then
                            found = True
                            Exit For
                        End If
                    Case "ReportFullName="
                        If aNode.ReportFullName = FindKeyValue Then
                            found = True
                            Exit For
                        End If
                    Case "NodeName="
                        If aNode.NodeName = FindKeyValue Then
                            found = True
                            Exit For
                        End If
                    Case "FullPath="
                        If aNode.FullPath = FindKeyValue Then
                            found = True
                            Exit For
                        End If
                    Case "Name="
                        If aNode.Name = FindKeyValue Then
                            found = True
                            Exit For
                        End If
                    Case "ItemTypeID="
                        If aNode.ItemTypeID = FindKeyValue Then
                            found = True
                            Exit For
                        End If
                    Case "NodeID="
                        If aNode.NodeID = FindKeyValue Then
                            found = True
                            Exit For
                        End If
                    Case "TreeLevelID="
                        If aNode.TreeLevelID = FindKeyValue Then
                            found = True
                            Exit For
                        End If

                End Select
                If aNode.ItemType = "F" And aNode.Nodes.Count > 0 Then
                    Dim tmpNode As DARTTreeNode = GetNodeByKey(aTreeView, FindKey, DoSelect, aNode.Nodes)
                    If tmpNode IsNot Nothing Then
                        foundNode = tmpNode         '<--- Ensure that the node gets passed up the chain of recursive calls
                        Exit For
                    End If
                End If
            Next

            If found = True Then foundNode = aNode

            If DoSelect = True And found = True Then
                aTreeView.SelectedNode = foundNode
                aTreeView.SelectedNode.EnsureVisible()
            End If
        Catch ex As Exception
            EmailErrorAlert(gDatabaseConnection, ex.Message, gUserID, gApplicationName, gApplicationVersion, gUserID, CallFromType, CallFrom, gWorkstationID, gOsName)
        End Try

        Return foundNode
    End Function
    ''' <summary>
    ''' Recursively scan a TreeView to find and return the node (WFMTreeNode) having the given FindKey from anywhere in the Tree.   Example call: aNode = WFMGetNodeByKey(aTreeView, "ReportID=" + aNode.ReportID.ToString, True)
    ''' </summary>
    ''' <param name="aTreeView">TreeView Control.</param>
    ''' <param name="FindKey">FindKey can be: "ReportID=", "ReportNumber=", "ReportName=", "ReportFullName=", "NodeName=", "FullPath=", "Name=", "ItemTypeID=", "NodeID=", "TreeLevelID="</param>
    ''' <param name="DoSelect">If TRUE, the returning node will also be selected in the TreeView.</param>
    ''' <param name="arrNodes">This optional parameter is used to pass in the nodes to search.  If not used, node search will begin at the top of the TreeView.</param>
    ''' <returns>WFMTreeNode</returns>
    ''' <remarks>by Mike Giordano (2/2/2008)</remarks>
    Public Function GetWFMNodeByKey(ByVal aTreeView As TreeView, ByVal FindKey As String, _
    Optional ByVal DoSelect As Boolean = False, _
    Optional ByRef arrNodes As TreeNodeCollection = Nothing) As WFMTreeNode
        Dim found As Boolean = False
        Dim foundNode As WFMTreeNode = Nothing
        Dim intParam As Integer = 0
        Dim strParam As String = ""
        Dim eqlPos As Integer = InStr(FindKey, "=")
        Dim FindKeyType As String = FindKey.Substring(0, eqlPos)
        Dim FindKeyValue As String = FindKey.Substring(eqlPos)
        CallFromType = "Function"
        CallFrom = "WFMGetNodeByKey"

        Try
            If arrNodes Is Nothing Then
                arrNodes = aTreeView.Nodes
            End If

            Dim aNode As WFMTreeNode = Nothing
            For Each aNode In arrNodes
                Select Case FindKeyType
                    Case "ReportID="
                        If aNode.ReportID.ToString = FindKeyValue Then
                            found = True
                            Exit For
                        End If
                    Case "ReportNumber="
                        If aNode.ReportNumber = FindKeyValue Then
                            found = True
                            Exit For
                        End If
                    Case "ReportName="
                        If aNode.ReportName = FindKeyValue Then
                            found = True
                            Exit For
                        End If
                    Case "ReportFullName="
                        If aNode.ReportFullName = FindKeyValue Then
                            found = True
                            Exit For
                        End If
                    Case "NodeName="
                        If aNode.NodeName = FindKeyValue Then
                            found = True
                            Exit For
                        End If
                    Case "FullPath="
                        If aNode.FullPath = FindKeyValue Then
                            found = True
                            Exit For
                        End If
                    Case "Name="
                        If aNode.Name = FindKeyValue Then
                            found = True
                            Exit For
                        End If
                    Case "ItemTypeID="
                        If aNode.ItemTypeID = FindKeyValue Then
                            found = True
                            Exit For
                        End If
                    Case "NodeID="
                        If aNode.NodeID = FindKeyValue Then
                            found = True
                            Exit For
                        End If
                    Case "TreeLevelID="
                        If aNode.TreeLevelID = FindKeyValue Then
                            found = True
                            Exit For
                        End If

                End Select
                If aNode.ItemType = "F" And aNode.Nodes.Count > 0 Then
                    Dim tmpNode As WFMTreeNode = GetWFMNodeByKey(aTreeView, FindKey, DoSelect, aNode.Nodes)
                    If tmpNode IsNot Nothing Then
                        foundNode = tmpNode         '<--- Ensure that the node gets passed up the chain of recursive calls
                        Exit For
                    End If
                End If
            Next

            If found = True Then foundNode = aNode

            If DoSelect = True And found = True Then
                aTreeView.SelectedNode = foundNode
                aTreeView.SelectedNode.EnsureVisible()
            End If
        Catch ex As Exception
            EmailErrorAlert(gDatabaseConnection, ex.Message, gUserID, gApplicationName, gApplicationVersion, gUserID, CallFromType, CallFrom, gWorkstationID, gOsName)
        End Try

        Return foundNode
    End Function

    Public Sub SelectText(ByRef lTextBox As System.Windows.Forms.TextBox)
        With lTextBox
            .SelectionStart = 0
            .SelectionLength = Len(lTextBox.Text)
        End With
    End Sub

    Public Sub ShowMessage(ByVal message As String, ByVal title As String)
        MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Sub

    Public Sub RepositionControls(ByVal ParameterContainer As Control, Optional ByVal RepositionTopAlso As Boolean = False)
        CallFromType = "Sub"
        CallFrom = "RepositionControls"

        Try
            Dim currControl As Control
            Dim prevControl As Control = Nothing
            Dim ParamWidth As Integer = ParameterContainer.Width
            Dim widthBetCtrls As Integer = 10

            If RepositionTopAlso Then
                For Each currControl In ParameterContainer.Controls
                    If prevControl Is Nothing Then
                        currControl.Left = (ParamWidth - currControl.Width) / 2
                    Else
                        If prevControl.Top = currControl.Top Then
                            prevControl.Left = (ParamWidth - (currControl.Width + prevControl.Width + widthBetCtrls)) / 2
                            currControl.Left = (prevControl.Left + prevControl.Width + widthBetCtrls)
                        Else
                            If currControl.Top < (prevControl.Top + prevControl.Height) Then
                                currControl.Top = (prevControl.Top + prevControl.Height + 5)
                            End If
                            currControl.Left = (ParamWidth - currControl.Width) / 2
                        End If
                    End If
                    prevControl = currControl
                Next
            Else
                For Each currControl In ParameterContainer.Controls
                    If currControl.Left = -1 Or prevControl Is Nothing Then
                        currControl.Left = (ParamWidth - currControl.Width) / 2
                    ElseIf prevControl.Top = currControl.Top Then
                        prevControl.Left = (ParamWidth - (currControl.Width + prevControl.Width + widthBetCtrls)) / 2
                        currControl.Left = (prevControl.Left + prevControl.Width + widthBetCtrls)
                    Else
                        currControl.Left = (ParamWidth - currControl.Width) / 2
                    End If
                    If currControl.Anchor = AnchorStyles.None Then currControl.Anchor = AnchorStyles.Top
                    prevControl = currControl
                Next
            End If

        Catch ex As Exception
            EmailErrorAlert(gDatabaseConnection, ex.Message, gUserID, gApplicationName, gApplicationVersion, gUserID, CallFromType, CallFrom, gWorkstationID, gOsName)
        End Try
    End Sub

    Public Sub EmailErrorAlert(ByVal conn As SqlConnection, ByVal errorDescription As String, ByVal tpid As String, ByVal AppName As String, _
        ByVal AppVer As String, ByVal UniqueID As String, ByVal WithInProc As String, ByVal ProcName As String, ByVal WorkStationID As String, ByVal OperSystem As String)

        Dim sql As String = "dbo.sSendDeveloperEMailAlert "
        Dim message As String = ""
        Dim subject As String = AppName & " " & AppVer & " - Error Alert !!!"

        Try
            message += "ErrDescription : " & errorDescription & vbNewLine & vbNewLine
            message += "Error From : " & WithInProc & " " & ProcName & vbNewLine
            message += "UniqueUserID : " & UniqueID

            sql += "'" & FixQuotes(message) & "','" & tpid & "','" & AppName & "','" & AppVer & "'"
            ExecuteCommandReturnQueryStatus(sql, conn)
        Catch ex As Exception
            '--- if an error occured in here, don't send email.  move on... ---
        End Try
    End Sub

    Public Function ConvertStringArrayToDataRows(ByVal StringArray() As Object) As DataRow()
        Dim dRows(StringArray.Length - 1) As DataRow
        Dim dTbl As New DataTable
        Try
            dTbl.Columns.Add("aString")
            For i As Integer = 0 To StringArray.Length - 1
                dRows(i) = dTbl.NewRow
                dRows(i).Item(0) = StringArray(i)
            Next
        Catch 'ex As Exception
            dRows = Nothing
        End Try
        Return dRows
    End Function

    Public Function OpenFile(ByVal FileToOpen As String) As Boolean
        CallFromType = "Function"
        CallFrom = "OpenFile"

        'Opens a file, similiar to double clicking on a file in explorer.
        'Does not check for existence.
        Try
            Dim myProcesses As New System.Diagnostics.Process
            myProcesses.StartInfo.UseShellExecute = True
            myProcesses.StartInfo.FileName = FileToOpen
            myProcesses.Start()
            Return True
        Catch ex As Exception
            EmailErrorAlert(gDatabaseConnection, ex.Message, gUserID, gApplicationName, gApplicationVersion, gUserID, CallFromType, CallFrom, gWorkstationID, gOsName)
            Return False
        End Try
    End Function

    Public Function ValidateServerConnection(conn As SqlConnection) As String
        Dim CallFromType As String = "Function"
        Dim CallFrom As String = "ValidateServerConnection"
        Dim sql As String = "select @@SERVERNAME"
        Dim status As String
        Dim cmd As New SqlCommand
        Dim ErrorMessage As String = ""
        Try
            With cmd
                .CommandType = CommandType.Text
                .CommandTimeout = 0
                .CommandText = sql
                .Connection = conn
                If Not .Connection.State = ConnectionState.Open Then .Connection.Open()
                status = CBool(.ExecuteNonQuery())
                If Not GetInputState = 0 Then Application.DoEvents()
                If .Connection.State = ConnectionState.Open Then .Connection.Close()
            End With
        Catch ex As Exception
            ErrorMessage = "There was an error connecting to the DART server.  Please contact the DART Team." + vbCrLf + vbCrLf _
            + "ConnectionString: " + conn.ConnectionString _
            + ex.Message
            MessageBox.Show(ErrorMessage, "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            status = False
        End Try
        Return (status)
    End Function

    Public Function ValidateConnection(ByVal server As String) As String
        Dim result As String

        'LAshby added these next two lines in v1.90
        If gDatabaseConnection.State = ConnectionState.Open Then
            gDatabaseConnection.Close()
        End If
        If server Like "*001" Then server &= ".corp.se.sempra.com"
        gConnectionString = "Data Source=" + server + ";Initial Catalog=DDT_Common;Integrated Security=True;Connect Timeout=30"
        gDatabaseConnection.ConnectionString = gConnectionString

        Dim sqlConnection As New SqlConnection(gConnectionString)
        Dim sqlCmd As New SqlCommand
        'If user is a DART developer than he/she is a toolboxo user
        sqlCmd.CommandText = "	SELECT dbo.fsIsDeveloper('" + gUserID + "',1)  "
        sqlCmd.CommandType = CommandType.Text
        sqlCmd.Connection = sqlConnection
        Try
            sqlConnection.Open()
            result = sqlCmd.ExecuteScalar
            If result = "1" Then
                result = "valid user"
            Else
                result = "The user '" + gUserID + "' is not an authorized user of this application."
            End If
        Catch sqlex As SqlClient.SqlException
            Select Case sqlex.Number
                Case 53
                    result = "Can't establish a connection with the server '" + server + "'."
                Case 18456
                    result = My.User.Name + " is not an authorized SQL Server login on the server " + server + "'."
                Case Else
                    result = sqlex.Message
            End Select
        Finally
            sqlConnection.Close()
            sqlConnection = Nothing
            sqlCmd = Nothing
        End Try
        Return result
    End Function

    Public Sub GetServerSettings()
        CallFromType = "Sub"
        CallFrom = "GetServerSettings"

        Dim aStr As String = ""
        Dim equalPos As Integer = 0
        Dim itemStr As String = ""
        Dim tempStr As String = ""
        Dim Index As Integer = 0
        Dim pipePos As Integer = 0

        Try
            Using parser As New TextFieldParser(gServerFileName)
                While Not parser.EndOfData
                    ' Read in the fields for the current line
                    aStr = parser.ReadLine
                    ' Add code here to use data in fields variable.

                    If Len(aStr) > 0 Then
                        equalPos = InStr(1, aStr, "=")
                        If equalPos > 1 Then
                            itemStr = UCase(LSet(aStr, equalPos - 1))
                            Select Case itemStr
                                Case "PRODUCTION"
                                    Prod_Server = Replace(aStr, itemStr & "=", "")
                                Case "DEVELOPMENT"
                                    Dev_Server = Replace(aStr, itemStr & "=", "")
                                Case "TESTING"
                                    QA_Server = Replace(aStr, itemStr & "=", "")
                                Case "SERVERATTEMPTS"
                                    ServerAttempts = CInt(Replace(aStr, itemStr & "=", ""))
                            End Select
                        End If
                    End If
                End While
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error reading INI file.  Please contact the DART Team.")
        End Try
    End Sub
    Public Function CheckForINIFIle() As Boolean
        CheckForINIFIle = My.Computer.FileSystem.FileExists(gServerFileName)
    End Function

    Public Function ExecuteCommandReturnQueryStatus(ByVal sql As String, ByVal conn As SqlConnection) As Boolean

        Dim cmd As New SqlCommand
        Try
            Dim rowsAffected As Integer = 0
            With cmd
                .CommandType = CommandType.Text
                .CommandTimeout = 0
                .CommandText = sql
                .Connection = conn
                If Not .Connection.State = ConnectionState.Open Then .Connection.Open()
                ExecuteCommandReturnQueryStatus = CBool(.ExecuteNonQuery())
                If Not GetInputState = 0 Then Application.DoEvents()
            End With
        Catch ex As Exception
            gError = True
            EmailErrorAlert(gDatabaseConnection, ex.Message, gUserID, gApplicationName, gApplicationVersion, gUserID, CallFromType, CallFrom, gWorkstationID, gOsName)
            ExecuteCommandReturnQueryStatus = False
        Finally
            If Not cmd.Connection.State = ConnectionState.Closed Then cmd.Connection.Close()
        End Try
    End Function

    ''' <summary>
    ''' Builds the dataset.
    ''' </summary>
    ''' <param name="conn">SQL Connection</param>
    ''' <param name="SQLCommand">SQL Command</param>
    ''' <param name="TableName">Name of Table to add to the dataset.</param>
    ''' <param name="dSet">Name of the dataset.</param>
    ''' <remarks>by Joey Cruz</remarks>
    Public Sub BuildDataSet(ByVal conn As SqlConnection, ByVal SQLCommand As String, ByVal TableName As String, Optional ByVal dSet As DataSet = Nothing)
        CallFromType = "Sub"
        CallFrom = "BuildDataSet"

        Try
            If dSet Is Nothing Then dSet = dsroot
            If TableName Is Nothing Then Exit Sub
            Dim myAdapter As New SqlDataAdapter(SQLCommand, conn)
            If dSet.Tables(TableName) IsNot Nothing Then
                dSet.Tables.Remove(TableName)
            End If
            dSet.Tables.Add(TableName)
            conn.Open()
            myAdapter.Fill(dSet.Tables(TableName))
            conn.Close()
            myAdapter.Dispose()
            myAdapter = Nothing
        Catch ex As Exception
            If Not conn.State = ConnectionState.Closed Then conn.Close()
            EmailErrorAlert(gDatabaseConnection, ex.Message, gUserID, gApplicationName, gApplicationVersion, gUserID, CallFromType, CallFrom, gWorkstationID, gOsName)
        Finally
            If Not conn.State = ConnectionState.Closed Then conn.Close()
        End Try
    End Sub

    Public Sub BuildDataSet_TOOLBOX(ByVal conn As SqlConnection, ByVal SQLCommand As String, ByVal TableName As String, Optional ByVal dSet As DataSet = Nothing)
        CallFromType = "Sub"
        CallFrom = "BuildDataSet"

        Try
            If dSet Is Nothing Then dSet = dsroot
            If TableName Is Nothing Then Exit Sub
            Dim myAdapter As New SqlDataAdapter(SQLCommand, conn)
            If dSet.Tables(TableName) IsNot Nothing Then
                dSet.Tables.Remove(TableName)
            End If
            dSet.Tables.Add(TableName)
            conn.Open()
            myAdapter.Fill(dSet.Tables(TableName))
            conn.Close()
            myAdapter.Dispose()
            myAdapter = Nothing
        Catch ex As Exception
            If Not conn.State = ConnectionState.Closed Then conn.Close()
        Finally
            If Not conn.State = ConnectionState.Closed Then conn.Close()
        End Try
    End Sub

    Public Function ParseStrings(ByVal StringToParse As String, ByVal conn As SqlConnection, Optional ByVal delimiter As String = ";") As DataTable
        Dim da As SqlDataAdapter = Nothing
        Dim sql As String

        Try
            sql = "SELECT * FROM dbo.ftParseString(" & StringToParse & ", '" & delimiter & "')"
            da = New SqlDataAdapter(sql, conn)
            Dim AddTbletoDS As New DBClass
            AddTbletoDS.DBClass_BuildDataSet(sql, "ParsedString", dsroot)
            conn.Close()
            Return dsroot.Tables("ParsedString")
        Catch ex As Exception

            MsgBox(gErrorMsg & vbCrLf & vbCrLf & "Error: " & vbCrLf & ex.Message & vbCrLf & vbCrLf & "Program Error Location: " + vbCrLf & System.Reflection.MethodBase.GetCurrentMethod().ToString)
            gError = True
            Return Nothing
        End Try
    End Function

    Public Function RetrieveScheduleParams(ByVal conn As SqlConnection, ByVal SchedID As Integer, Optional ByVal RptCtrlID As Integer = 0) As DataRow()
        CallFromType = "Function"
        CallFrom = "RetrieveScheduleParams"

        Dim sql As String = "EXEC dbo.sSchedule_GetParams " & SchedID
        BuildDataSet(conn, sql, "ScheduleParams", dsroot)
        Dim SD As DataRow()

        Try
            If RptCtrlID = 0 Then
                SD = dsroot.Tables("ScheduleParams").Select()
            Else
                SD = dsroot.Tables("ScheduleParams").Select("Report_ControlID=" & RptCtrlID.ToString)
            End If
            Dim i As Integer = 0

            For Each sr As DataRow In SD
                SchedType.Add(sr("ParamType"))
                SchedText.Add(sr("ParamText"))
                SchedValues.Add(sr("ParamValue"))
                SchedRptCtrls.Add(sr("Report_ControlID"))
            Next
            If SD.Length > 0 Then
                Return SD
            Else
                Return Nothing
            End If
        Catch ex As Exception
            EmailErrorAlert(conn, ex.Message, gUserID, gApplicationName, gApplicationVersion, gUserID, CallFromType, CallFrom, gWorkstationID, gOsName)
            Return Nothing
        End Try
    End Function

    Public Function ReturnDataTable(ByVal sqlQuery As String, ByVal conn As SqlConnection) As DataTable
        CallFromType = "Function"
        CallFrom = "ReturnDataTable"

        Dim dt As New DataTable
        Dim cmd As New SqlCommand
        Dim da As New SqlDataAdapter

        Try
            With cmd
                .Connection = conn
                .CommandType = CommandType.Text
                .CommandText = sqlQuery
                .CommandTimeout = 0
                If Not .Connection.State = ConnectionState.Open Then .Connection.Open()
                da.SelectCommand = cmd
                da.Fill(dt)
                If Not GetInputState = 0 Then Application.DoEvents()
                If .Connection.State = ConnectionState.Open Then .Connection.Close()
            End With

            Return dt
        Catch ex As Exception
            If Not cmd.Connection.State = ConnectionState.Closed Then cmd.Connection.Close()
            EmailErrorAlert(conn, ex.Message, gUserID, gApplicationName, gApplicationVersion, gUserID, CallFromType, CallFrom, gWorkstationID, gOsName)
            Return Nothing
        Finally
            If Not cmd.Connection.State = ConnectionState.Closed Then cmd.Connection.Close()
        End Try
    End Function

    'Lynn 2/27/18 - created to replace this code on most forms.
    Public Sub LoadForm(ByVal sender As System.Object, ByVal e As System.EventArgs)
        sender.pnlPrimaryContent.Visible = False
        sender.Icon = frmMain.Icon ' Barry
        Dim i As Integer
        For i = 0 To ServerList.GetUpperBound(0)
            If ServerList(i) <> "" Then
                sender.cboServer.Items.Add(ServerList(i))

                If sender.GetType.Name = "frmDART_TNGRetrieveDARTReportParams" Then
                    sender.cboChoseServer.Items.Add(ServerList(i))
                End If
            End If
        Next
        Dim numServers As Integer = sender.cboServer.Items.Count
        If numServers > 0 Then
            If UserSettings.DefaultConnectionType = 1 Then
                If gLastConnection <> "" Then
                    Dim found As Boolean = False
                    i = 0
                    While i <= numServers - 1 And Not found
                        If sender.cboServer.Items(i) = gLastConnection Then
                            found = True
                            sender.cboServer.SelectedIndex = i
                        End If
                        i += 1
                    End While
                    If Not found Then sender.cboServer.SelectedIndex = 0
                Else
                    sender.cboServer.SelectedIndex = 0
                End If
            Else
                i = 0
                Dim found As Boolean = False
                While i <= sender.cboServer.Items.Count - 1 And Not found
                    If sender.cboServer.Items(i) = UserSettings.DefaultConnectionName Then
                        found = True
                        sender.cboServer.SelectedIndex = i
                    End If
                    i += 1
                End While
                If Not found Then sender.cboServer.SelectedIndex = 0
            End If
        Else
            sender.cboServer.SelectedIndex = -1
            sender.btnConnect.Enabled = False
        End If

        If sender.GetType.Name = "frmDART_TNGRetrieveDARTReportParams" Then
            sender.cboChoseServer.SelectedIndex = -1
        End If

        sender.Tag = sender.Text
        sender.Text = sender.Tag + " [no connection]"

    End Sub

    'Lynn 2/27/18 - created to replace the btnConnect_Click code on most forms.
    Public Function ChangeConnection(ByVal sender As System.Object, ByVal e As System.EventArgs) As Boolean
        If sender.btnConnect.Text = "Connect" Then
            sender.Cursor = Cursors.WaitCursor
            Dim server As String = sender.cboServer.Items(sender.cboServer.SelectedIndex)
            Dim result = ValidateConnection(server)
            If result = "valid user" Then
                sender.pnlPrimaryContent.Visible = True
                sender.Text = sender.Tag + " [" + server + "]"
                sender.cboServer.Enabled = False
                sender.btnConnect.Text = "Disconnect"
                gLastConnection = server
                sender.Cursor = Cursors.Default
                Return True
            Else
                sender.Cursor = Cursors.Default
                Return False
                MessageBox.Show(result, "Connection failed", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        Else
            sender.pnlPrimaryContent.Visible = False
            sender.Text = sender.Tag + " [no connection]"
            sender.cboServer.Enabled = True
            sender.btnConnect.Text = "Connect"
            sender.Cursor = Cursors.Default
            Return False
        End If
    End Function

End Module
