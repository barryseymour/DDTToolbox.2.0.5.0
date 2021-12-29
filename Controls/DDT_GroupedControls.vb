Imports System.Data.SqlClient
Imports System.ComponentModel

Public Class DDT_GroupedControls
    Inherits DDT_BaseControl

    Public WithEvents GroupBox As System.Windows.Forms.GroupBox

    Private _GroupTitle As String
    Private _NumberOfColumns As Integer
    Private _NumberOfRows As Integer
    Public conn As SqlConnection
    Private TPID As String
    Public ScheduleID As Integer
    Public ctrl As DDT_BaseControl
    Public UseReportID As Boolean
    Public NodeType As DDT_NodeType

    Public Sub New()
        MyBase.New()

        InitializeComponent()
    End Sub

    Public Sub New(ByVal ReportControlID As Integer, ByVal ReportID As Integer, _
                ByVal ControlTitle As String, ByVal SQLConn As SqlConnection, _
                ByVal ControlName As String, ByVal ControlID As Integer, _
                ByVal ControlHeight As Integer, ByVal ControlWidth As Integer, _
                ByVal Location_X As Integer, ByVal Location_Y As Integer, _
                ByVal UseReportIDToGetData As Boolean, ByVal UserID As String, _
                Optional ByVal ParentControl As DDT_BaseControl = Nothing, _
                Optional ByVal SchedID As Integer = 0)

        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        With Me
            .ReportControlID = ReportControlID
            .ReportID = ReportID
            .GroupBox.Text = ControlTitle
            .Size = New Drawing.Point(ControlWidth, ControlHeight)
            .Location = New Drawing.Point(Location_X, Location_Y)
            .Name = ControlName
            .ControlID = ControlID
        End With
        TPID = UserID
        conn = SQLConn
        ctrl = ParentControl
        ScheduleID = SchedID
        UseReportID = UseReportIDToGetData
        AddSubControls()
    End Sub

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.GroupBox = New System.Windows.Forms.GroupBox()
        Me.SuspendLayout()
        '
        'GroupBox
        '
        Me.GroupBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox.Name = "GroupBox"
        Me.GroupBox.Size = New System.Drawing.Size(275, 130)
        Me.GroupBox.TabIndex = 0
        Me.GroupBox.TabStop = False
        Me.GroupBox.Text = "GroupBox"
        '
        'DDT_GroupedControls
        '
        Me.Controls.Add(Me.GroupBox)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "DDT_GroupedControls"
        Me.Size = New System.Drawing.Size(275, 130)
        Me.ResumeLayout(False)

    End Sub

    Public Property GroupTitle() As String
        Get
            Return _GroupTitle
        End Get
        Set(ByVal value As String)
            _GroupTitle = value
        End Set
    End Property

    Public Property NumberOfColumns() As Integer
        Get
            Return _NumberOfColumns
        End Get
        Set(ByVal value As Integer)
            _NumberOfColumns = value
        End Set
    End Property

    Public Property NumberOfRows() As Integer
        Get
            Return _NumberOfRows
        End Get
        Set(ByVal value As Integer)
            _NumberOfRows = value
        End Set
    End Property

    Public Sub AddSubControls()
        CallFromType = "Sub"
        CallFrom = "AddSubControls"

        Dim paramContainer As Control = Me.GroupBox

        Me.Cursor = Cursors.WaitCursor
        'This procedure adds the actual report controls to the tabParams panel
        Try
            Dim Yesterday As DateTime = DateAdd(DateInterval.Day, -1, Today)
            Dim ctrl As New DDT_BaseControl
            Dim ReportControlsID As Integer = 0
            Dim ControlsID As Integer = 0
            Dim Controls_MasterID As Integer = 0
            Dim IndexOrder As Integer = 0
            Dim ControlTitle As String = ""
            Dim Tag As String = ""
            Dim Width As Integer = 0
            Dim Height As Integer = 0
            Dim LocationX As Integer = 0
            Dim LocationY As Integer = 0
            Dim SQLCommand As String = ""
            Dim ValueColumn As String = ""
            Dim DisplayColumn As String = ""
            Dim DefaultValue As String = ""
            Dim MinSelectableItems As Integer = 0
            Dim MaxSelectableItems As Integer = 0
            Dim UseReportID As Boolean = False
            Dim IsMultiColumn As Boolean = False
            Dim ColumnWidth As Integer = 0
            Dim LoadDataOnCreation As Boolean = False
            Dim DisplayRefreshButtonWhenParentChanges As Boolean = False
            Dim SelectAllItemsOnCreation As Boolean = False
            Dim IsLabel1On As Boolean = False
            Dim Label1Text As String = ""
            Dim TextAlign1 As String = ""
            Dim IsLabel2On As Boolean = False
            Dim Label2Text As String = ""
            Dim TextAlign2 As String = ""
            Dim FormatType As String = ""
            Dim CustomFormat As String = ""
            Dim DefaultDate As DateTime = Nothing
            Dim DefaultStartDate As DateTime = Nothing
            Dim DefaultEndDate As DateTime = Nothing
            Dim IsCacheData As Boolean = False
            Dim FontName As String = ""
            Dim FontSize As Integer = 0
            Dim FontBold As Boolean = False
            Dim FontItalic As Boolean = False
            Dim FontUnderline As Boolean = False
            Dim FontColor As String = ""
            Dim BackColor As String = ""
            Dim ForeColor As String = ""
            Dim DisplayExtraButton As Boolean = False
            Dim ExtraButtonText As String = ""
            Dim ExtraButtonDataSetName As String = ""
            Dim DataSetName As String = ""
            Dim ControlName As String = ""
            Dim MinimumDate As DateTime = Nothing
            Dim MaximumDate As DateTime = Nothing
            Dim MaxDays As Integer = 0
            Dim dtControls As New DataTable("Controls")
            Dim anchorStyle As String = "None"
            Dim dockingStyle As String = "None"
            Dim anchor As AnchorStyles = AnchorStyles.None
            Dim dock As DockStyle = DockStyle.None
            Dim ParentRptCtrlID As Integer = 0
            Dim ChildRptCtrlID As Integer = 0
            Dim IsChild As Boolean = False
            Dim ParentControl As DDT_BaseControl = Nothing
            Dim ControlLoopForMultipleWorkbooks As Boolean = False
            Dim txtBox1X As Integer = 0

            ScheduleWithDates = False
            DoNotReposition = False
            TabIndex += 1

            Dim sql As String = "dbo.sGetSubControlSettings " & Me.ReportControlID.ToString
            dtControls = ReturnDataTable(sql, conn)

            TabIndex -= 1
            If dtControls.Rows.Count = 0 Then Exit Sub
            paramContainer.MinimumSize = paramContainer.Size
            paramContainer.Visible = False
            paramContainer.Controls.Clear()
            currTabName = TabName

            If NodeType = DDT_NodeType.Schedule Then
                Dim SL As New DDT_SchedLabel
                SL.Top = -1
                SL.Left = -1
            End If

            For Each rowItem As DataRow In dtControls.Rows
                ParentControl = Nothing
                ReportControlsID = IIf(IsDBNull(rowItem("Report_ControlID")), 0, rowItem("Report_ControlID"))
                ControlsID = IIf(IsDBNull(rowItem("ControlsID")), 0, rowItem("ControlsID"))
                Controls_MasterID = IIf(IsDBNull(rowItem("Controls_MasterID")), 0, rowItem("Controls_MasterID"))
                IndexOrder = IIf(IsDBNull(rowItem("IndexOrder")), 0, rowItem("IndexOrder"))
                ControlTitle = IIf(IsDBNull(rowItem("ControlTitle")), "", rowItem("ControlTitle"))
                Tag = IIf(IsDBNull(rowItem("Tag")), "", rowItem("Tag"))
                Width = IIf(IsDBNull(rowItem("Width")), 0, rowItem("Width"))
                Height = IIf(IsDBNull(rowItem("Height")), 0, rowItem("Height"))
                LocationX = IIf(IsDBNull(rowItem("LocationX")), 0, rowItem("LocationX"))
                LocationY = IIf(IsDBNull(rowItem("LocationY")), 0, rowItem("LocationY"))
                SQLCommand = IIf(IsDBNull(rowItem("SQLCommand")), "", rowItem("SQLCommand"))
                ValueColumn = IIf(IsDBNull(rowItem("ValueColumn")), "", rowItem("ValueColumn"))
                DisplayColumn = IIf(IsDBNull(rowItem("DisplayColumn")), "", rowItem("DisplayColumn"))
                DefaultValue = IIf(IsDBNull(rowItem("DefaultValue")), "", rowItem("DefaultValue"))
                MinSelectableItems = IIf(IsDBNull(rowItem("MinSelectableItems")), 1, rowItem("MinSelectableItems"))
                MaxSelectableItems = IIf(IsDBNull(rowItem("MaxSelectableItems")), 0, rowItem("MaxSelectableItems"))
                UseReportID = IIf(IsDBNull(rowItem("UseReportID")), False, rowItem("UseReportID"))
                IsMultiColumn = IIf(IsDBNull(rowItem("IsMultiColumn")), False, rowItem("IsMultiColumn"))
                ColumnWidth = IIf(IsDBNull(rowItem("ColumnWidth")), 0, rowItem("ColumnWidth"))
                LoadDataOnCreation = IIf(IsDBNull(rowItem("LoadDataOnCreation")), False, rowItem("LoadDataOnCreation"))
                DisplayRefreshButtonWhenParentChanges = IIf(IsDBNull(rowItem("DisplayRefreshButtonWhenParentChanges")), False, rowItem("DisplayRefreshButtonWhenParentChanges"))
                SelectAllItemsOnCreation = IIf(IsDBNull(rowItem("SelectAllItemsOnCreation")), False, rowItem("SelectAllItemsOnCreation"))
                IsLabel1On = IIf(IsDBNull(rowItem("IsLabel1On")), False, rowItem("IsLabel1On"))
                Label1Text = IIf(IsDBNull(rowItem("Label1Text")), "", rowItem("Label1Text"))
                TextAlign1 = IIf(IsDBNull(rowItem("TextAlign1")), "", rowItem("TextAlign1"))
                IsLabel2On = IIf(IsDBNull(rowItem("IsLabel2On")), False, rowItem("IsLabel2On"))
                Label2Text = IIf(IsDBNull(rowItem("Label2Text")), "", rowItem("Label2Text"))
                TextAlign2 = IIf(IsDBNull(rowItem("TextAlign2")), "", rowItem("TextAlign2"))
                FormatType = IIf(IsDBNull(rowItem("FormatType")), "", rowItem("FormatType"))
                CustomFormat = IIf(IsDBNull(rowItem("CustomFormat")), "", rowItem("CustomFormat"))
                DefaultDate = IIf(IsDBNull(rowItem("DefaultDate")), Yesterday, rowItem("DefaultDate"))
                DefaultStartDate = IIf(IsDBNull(rowItem("DefaultStartDate")), Yesterday, rowItem("DefaultStartDate"))
                DefaultEndDate = IIf(IsDBNull(rowItem("DefaultEndDate")), Yesterday, rowItem("DefaultEndDate"))
                IsCacheData = IIf(IsDBNull(rowItem("IsCacheData")), False, rowItem("IsCacheData"))
                FontName = IIf(IsDBNull(rowItem("FontName")), "", rowItem("FontName"))
                FontSize = IIf(IsDBNull(rowItem("FontSize")), 0, rowItem("FontSize"))
                FontBold = IIf(IsDBNull(rowItem("FontBold")), False, rowItem("FontBold"))
                FontItalic = IIf(IsDBNull(rowItem("FontItalic")), False, rowItem("FontItalic"))
                FontUnderline = IIf(IsDBNull(rowItem("FontUnderline")), False, rowItem("FontUnderline"))
                FontColor = IIf(IsDBNull(rowItem("FontColor")), "", rowItem("FontColor"))
                BackColor = IIf(IsDBNull(rowItem("BackColor")), "", rowItem("BackColor"))
                ForeColor = IIf(IsDBNull(rowItem("ForeColor")), "", rowItem("ForeColor"))
                DisplayExtraButton = IIf(IsDBNull(rowItem("DisplayExtraButton")), False, rowItem("DisplayExtraButton"))
                ExtraButtonText = IIf(IsDBNull(rowItem("ExtraButtonText")), "", rowItem("ExtraButtonText"))
                DataSetName = IIf(IsDBNull(rowItem("DataSetName")), "", rowItem("DataSetName"))
                MinimumDate = IIf(IsDBNull(rowItem("MinimumDate")), DateAdd(DateInterval.Year, -5, Yesterday), rowItem("MinimumDate"))
                MaximumDate = IIf(IsDBNull(rowItem("MaximumDate")), Today, rowItem("MaximumDate"))
                MaxDays = IIf(IsDBNull(rowItem("MaxDays")), 0, rowItem("MaxDays"))
                ExtraButtonDataSetName = IIf(IsDBNull(rowItem("ExtraButtonDataSetName")), "", rowItem("ExtraButtonDataSetName"))
                ControlName = IIf(IsDBNull(rowItem("ControlName")), "", rowItem("ControlName"))
                dockingStyle = IIf(IsDBNull(rowItem("dock")), "None", rowItem("dock"))
                anchorStyle = IIf(IsDBNull(rowItem("anchor")), "None", rowItem("anchor"))
                anchor = GetAnchorStyles(anchorStyle)
                dock = GetDockStyles(dockingStyle)
                ParentRptCtrlID = IIf(IsDBNull(rowItem("MyParent_Report_ControlID")), -1, rowItem("MyParent_Report_ControlID"))
                ChildRptCtrlID = IIf(IsDBNull(rowItem("MyChild_Report_ControlID")), -1, rowItem("MyChild_Report_ControlID"))
                ControlLoopForMultipleWorkbooks = IIf(IsDBNull(rowItem("UseForMultipleWorkbooks")), False, rowItem("UseForMultipleWorkbooks"))
                txtBox1X = rowItem("TextBoxLocationX")
                IsChild = IIf(ParentRptCtrlID <> -1 And LoadDataOnCreation, True, False)

                If Mid(ControlName, 1, 3) = "DDT" Then
                    Dim dt As New DataTable
                    Dim cmdText As String

                    cmdText = "dbo.sGetParents " & ReportControlsID
                    cmdText = IIf(ScheduleID > 0, cmdText & ",1", cmdText)
                    dt.Clear()
                    dt = ReturnDataTable(cmdText, conn)

                    If dt.Rows.Count > 0 Then
                        For Each row As DataRow In dt.Rows
                            Dim ParentID As Integer = row("MyParent_Report_ControlID")
                            For Each anyCtrl As Control In paramContainer.Controls
                                If IsDARTClass(TypeDescriptor.GetClassName(anyCtrl)) Then
                                    ctrl = anyCtrl
                                    If DirectCast(anyCtrl, DDT_BaseControl).ReportControlID = ParentID Then
                                        ParentControl = ctrl
                                    Else
                                        ParentControl = Nothing
                                    End If
                                End If
                            Next
                        Next
                    End If
                End If

                Select Case ControlName
                    'Add DDT_DateRange
                    Case "DDT_DateRange"
                        If NodeType <> DDT_NodeType.Schedule Then
                            StartDate = IIf(StartDate = Nothing, Yesterday, StartDate)
                            EndDate = IIf(EndDate = Nothing, Yesterday, EndDate)
                            paramContainer.Controls.Add(New DDT_DateRange(ReportControlsID, ReportID, LocationX, _
                                                        LocationY, Width, Height, ControlName, ControlsID, ControlTitle, _
                                                        IndexOrder, IsLabel1On, Label1Text, MaxDays, DefaultStartDate, _
                                                        DefaultEndDate, MinimumDate, MaximumDate))
                        Else
                            ScheduleWithDates = True
                            DateType = ControlTitle
                        End If
                    Case "DDT_Date_Time"
                        'Add DDT_Date_Time
                        If NodeType <> DDT_NodeType.Schedule Then
                            StartDate = IIf(StartDate = Nothing, Yesterday, StartDate)
                            EndDate = IIf(EndDate = Nothing, Yesterday, EndDate)
                            paramContainer.Controls.Add(New DDT_Date_Time(ReportControlsID, ReportID, LocationX, _
                                                        LocationY, Width, Height, ControlName, ControlsID, ControlTitle, _
                                                         IndexOrder, IsLabel1On, Label1Text, MaxDays, DefaultStartDate, _
                                                         DefaultEndDate, MinimumDate, MaximumDate))
                        Else
                            ScheduleWithDates = True
                            DateType = ControlTitle
                        End If
                    Case "DDT_ComboBox"
                        'Add DDT_ComboBox
                        If NodeType <> DDT_NodeType.Schedule Then
                            paramContainer.Controls.Add(New DDT_ComboBox(ReportControlsID, ReportID, UseReportID, _
                                                        SQLCommand, CommandType.Text, conn, _
                                                        DisplayColumn, ValueColumn, ControlTitle, LocationX, LocationY, _
                                                        Width, Height, ControlsID, ControlName, IndexOrder, currentIndex))
                            If ControlTitle <> "Month / Year" And ControlTitle <> "Year" Then
                                DoNotReposition = True
                            End If
                        Else
                            If ControlTitle = "Month / Year" Or ControlTitle = "Year" Then
                                ScheduleWithDates = True
                                DateType = ControlTitle
                            Else
                                Dim cbo As New DDT_ComboBox(ReportControlsID, ReportID, UseReportID, _
                                                            SQLCommand, CommandType.Text, conn, _
                                                            DisplayColumn, ValueColumn, ControlTitle, LocationX, LocationY, _
                                                            Width, Height, ControlsID, ControlName, IndexOrder, currentIndex)
                                paramContainer.Controls.Add(cbo)
                                Dim cb As DataRow() = RetrieveScheduleParams(conn, ScheduleID, cbo.ReportControlID)
                                If cb IsNot Nothing Then
                                    For Each row As DataRow In cb
                                        If row("ParamType") = cbo.ControlTitle Then
                                            cbo.cbo.SelectedValue = row("ParamValue")
                                        End If
                                    Next
                                End If
                            End If
                        End If
                    Case "DDT_SingleDate"
                        If NodeType <> DDT_NodeType.Schedule Then
                            StartDate = IIf(StartDate = Nothing, Yesterday, StartDate)
                            EndDate = IIf(EndDate = Nothing, Yesterday, EndDate)
                            'Add DDT_SingleDate
                            paramContainer.Controls.Add(New DDT_SingleDate(ReportControlsID, ReportID, LocationX, _
                                                        LocationY, Width, Height, ControlName, ControlsID, ControlTitle, _
                                                         IndexOrder, IsLabel1On, Label1Text, MaxDays, DefaultStartDate, _
                                                         DefaultEndDate, MinimumDate, MaximumDate))
                        Else
                            ScheduleWithDates = True
                            DateType = ControlTitle
                        End If
                    Case "DDT_Label_TextBox_Label"
                        'paramContainer.Controls.Add(New DDT_Label_TextBox_Label(IsLabel1On, IsLabel2On, Label1Text, Label2Text, DefaultValue, _
                        '                                                        ColumnWidth, txtBox1X, LocationX, LocationY, Width, Height, _
                        '                                                        FormatType, ControlTitle, ReportControlsID))
                        '--- The ABOVE code was commented because it was always populating the control with the default value, which was incorrect on the Scheduling screen.
                        '--- The BELOW code was added to find/populate the correct value for the text box on the control.
                        '--- 7/31/2012 MSG
                        Dim ctrlValue As String = DefaultValue
                        Try
                            If ScheduleID > 0 Then
                                Dim rows As DataRow() = RetrieveScheduleParams(conn, ScheduleID, ReportControlsID)
                                If rows IsNot Nothing Then
                                    For Each row As DataRow In rows
                                        If row("ParamType") = ControlTitle Then
                                            ctrlValue = row("ParamValue")
                                        End If
                                    Next
                                End If
                            End If
                        Catch ex As Exception
                            '---
                        End Try
                        paramContainer.Controls.Add(New DDT_Label_TextBox_Label(IsLabel1On, IsLabel2On, Label1Text, Label2Text, ctrlValue, _
                                                                                ColumnWidth, txtBox1X, LocationX, LocationY, Width, Height, _
                                                                                FormatType, ControlTitle, ReportControlsID))

                    Case "DDT_NumericTextBox"
                        'Add DDT_NumericTextBox
                        Dim numTxtBox As New DDT_NumericTextBox(ControlTitle)
                        With numTxtBox
                            .Top = LocationY
                            .Left = LocationX
                            .Width = Width
                            .Height = Height
                            .Anchor = anchor
                            .Dock = dock
                        End With
                        paramContainer.Controls.Add(numTxtBox)
                        If ScheduleID > 0 Then
                            Dim nt As DataRow() = RetrieveScheduleParams(conn, ScheduleID, numTxtBox.ReportControlID)
                            If nt IsNot Nothing Then
                                For Each row As DataRow In nt
                                    If row("ParamText") = numTxtBox.lblNumeric.Text Then
                                        numTxtBox.txtNumeric.Text = row("ParamValue")
                                    End If
                                Next
                            End If
                        End If
                    Case "DDT_TextBox"
                        'Add DDT_TextBox
                        paramContainer.Controls.Add(New DDT_TextBox())
                    Case "DDT_CheckBox_TextBox"
                        'Add DDT_CheckBox_TextBox
                        paramContainer.Controls.Add(New DDT_CheckBox_TextBox())
                        DoNotReposition = True
                    Case "DDT_CheckBox_TextBox_Label"
                        'Add DDT_CheckBox_TextBox_Label
                        paramContainer.Controls.Add(New DDT_CheckBox_TextBox_Label())
                        DoNotReposition = True
                    Case "DDT_ListBox"
                        'Add DDT_ListBox 
                        If LoadDataOnCreation Then
                            If ScheduleID > 0 Then
                                SQLCommand = IIf(SQLCommand.Contains(" "), SQLCommand & ",", SQLCommand)
                                Dim sqlcmd As String = SQLCommand & " '" & TPID & "'," & ScheduleID
                                DataSetName += ScheduleID.ToString
                                BuildDataSet(conn, sqlcmd, DataSetName, dsroot)
                            End If
                            paramContainer.Controls.Add(New DDT_ListBox(ReportControlsID, ReportID, UseReportID, DataSetName, _
                                                        conn, DisplayColumn, ValueColumn, ControlTitle, LocationX, LocationY, _
                                                        Width, Height, ControlName, ControlsID, DisplayExtraButton, _
                                                        ExtraButtonText, ExtraButtonDataSetName, LoadDataOnCreation, DisplayRefreshButtonWhenParentChanges, _
                                                        SelectAllItemsOnCreation, IndexOrder, "", ColumnWidth, IsMultiColumn, _
                                                        IsLabel2On, Label2Text, MinSelectableItems, MaxSelectableItems, _
                                                        ControlLoopForMultipleWorkbooks, IsChild, ParentControl, ScheduleID))
                        Else
                            If ScheduleID > 0 Then
                                LoadDataOnCreation = True
                                DisplayRefreshButtonWhenParentChanges = False
                            End If
                            paramContainer.Controls.Add(New DDT_ListBox(ReportControlsID, ReportID, UseReportID, _
                                                        SQLCommand, CommandType.Text, conn, _
                                                        DisplayColumn, ValueColumn, ControlTitle, LocationX, LocationY, _
                                                        Width, Height, ControlName, ControlsID, DisplayExtraButton, _
                                                        ExtraButtonText, ExtraButtonDataSetName, LoadDataOnCreation, DisplayRefreshButtonWhenParentChanges, _
                                                        SelectAllItemsOnCreation, IndexOrder, "", ColumnWidth, IsMultiColumn, _
                                                        IsLabel2On, Label2Text, MinSelectableItems, MaxSelectableItems, ControlLoopForMultipleWorkbooks, ParentControl, _
                                                        ScheduleID))
                        End If
                    Case "DDT_RadioButton"
                        Dim rdobtn As New DDT_RadioButton(ControlTitle, DefaultValue, LocationX, LocationY, ReportControlsID, Tag, Me)
                        paramContainer.Controls.Add(rdobtn)

                        If ScheduleID > 0 Then
                            Dim cb As DataRow() = RetrieveScheduleParams(conn, ScheduleID, ReportControlsID)
                            For Each row As DataRow In cb
                                If row("ParamText") = rdobtn.RadioButton.Text Then
                                    rdobtn.RadioButton.Checked = row("ParamValue")
                                End If
                            Next
                        End If
                    Case "DDT_CheckBox"
                        Dim chkbox As New DDT_CheckBox(ControlTitle, LocationX, LocationY, ReportControlsID, DefaultValue, CInt(TextAlign1), _
                                                    anchor, dock)
                        paramContainer.Controls.Add(chkbox)
                        DoNotReposition = True

                        If ScheduleID > 0 Then
                            Dim cb As DataRow() = RetrieveScheduleParams(conn, ScheduleID, ReportControlsID)
                            For Each row As DataRow In cb
                                If row("ParamText") = chkbox.CheckBox1.Text Then
                                    chkbox.CheckBox1.Checked = row("ParamValue")
                                End If
                            Next
                        End If
                    Case Else
                        'Add Code for others
                        paramContainer.Controls.Add(ctrl)
                        If ScheduleID > 0 Then
                            Dim ctrlDR As DataRow() = RetrieveScheduleParams(conn, ScheduleID, ReportControlsID)
                            For Each row As DataRow In ctrlDR
                                If row("ParamText") = ctrl.Name Then
                                    ctrl.Text = row("ParamValue")
                                End If
                            Next
                        End If
                End Select
            Next

            paramContainer.Visible = True
        Catch ex As Exception
            EmailErrorAlert(conn, ex.Message, TPID, gApplicationName, gApplicationVersion, TPID, CallFromType, CallFrom, gWorkstationID, gOsName)
        End Try
        Me.Cursor = Cursors.Default
    End Sub
End Class
