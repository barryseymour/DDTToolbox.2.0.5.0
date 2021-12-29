Imports System.Data.SqlClient
Imports System.ComponentModel

Public Class DDT_ListBox
    Inherits DDT_BaseControl

#Region "Declared Variables"
    Private NoData As Boolean = False
    Private _SQLCommandType As CommandType = CommandType.Text
    Private _SQLCommandString As String = ""
    Private _DisplayColumn As String = ""
    Private _ValueColumn As String = ""
    Private loadSavedData As Boolean = True
    Private useReportIDToGetData, loadDataOnCreation As Boolean
    Private displayRefreshButtonWhenParentChanges As Boolean
    Private IsOkToGetData As Boolean = True
    Private UseForMultipleWorkbooks As Boolean = False
    Private IsSelectedIndexChanged_Event_Suppressed As Boolean = False
    Private minSelectableItems, maxSelectableItems As Integer
    Public SelectAllItemsOnCreate As Boolean = False
    Private ExtraDataSetName As String
    Private _DataBaseConnection As New SqlConnection
    Private _DataSetName As String
    Private _DataForListBox As New DataTable
    Private IsChild As Boolean = False
    Private sc As New SqlCommand
    Private da As New SqlDataAdapter
    Private _ControlOrder As Integer = 0
    Private userSelectedDataInDilimitedFormat As String
    Private UseUserProvidedData As Boolean
    Private Schedule_ID As Integer
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Public WithEvents CheckedListBox1 As System.Windows.Forms.CheckedListBox
    Public WithEvents btnNone As System.Windows.Forms.Button
    Protected WithEvents btnAll As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Public WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnMore As System.Windows.Forms.Button
    Friend WithEvents mnuSelectAll As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuDeselectAll As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents btnRefreshData As System.Windows.Forms.Button
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
#End Region

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        NoData = True
    End Sub

    'This constructor queries the database for the content
    Public Sub New(ByVal ReportControlID As Integer, ByVal ReportID As Integer, ByVal UseReportIDToGetData As Boolean, _
            ByVal SQLCmdString As String, ByVal SQLCmdType As CommandType, ByVal SQLConnection As SqlConnection, _
            ByVal DisplayColumnString As String, ByVal ValueColumnString As String, ByVal Title As String, _
            ByVal Location_X As Integer, ByVal Location_Y As Integer, _
            ByVal ControlWidth As Integer, ByVal ControlHeight As Integer, _
            ByVal ControlName As String, ByVal ControlID As Integer, _
            ByVal IsExtraButtonOn As Boolean, ByVal ExtraButtonText As String, _
            Optional ByVal ExtraButtonDataSetName As String = "", _
            Optional ByVal loadDataOnCreation As Boolean = True, _
            Optional ByVal DisplayRefreshButtonWhenParentChanges As Boolean = False, _
            Optional ByVal SelectAllItemsOnCreation As Boolean = False, _
            Optional ByVal IndexOrder As Integer = 0, _
            Optional ByVal checkedValues As String = "", _
            Optional ByVal ColumnWidth As Integer = 0, _
            Optional ByVal IsMultiColumn As Boolean = False, _
            Optional ByVal IsLabel2On As Boolean = False, _
            Optional ByVal Label2Text As String = "", _
            Optional ByVal MinSelectableItems As Integer = 0, _
            Optional ByVal MaxSelectableItems As Integer = 0, _
            Optional ByVal MultiWorkbook As Boolean = False, _
            Optional ByVal ParentControl As DDT_BaseControl = Nothing, _
            Optional ByVal SchedID As Integer = 0)

        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        If Not ParentControl Is Nothing Then
            myParents.Add(ParentControl)
            ParentControl.myChildren.Add(Me)
        End If

        ExtraDataSetName = ExtraButtonDataSetName
        Me.ReportControlID = ReportControlID
        Me.ReportID = ReportID
        Me.useReportIDToGetData = UseReportIDToGetData
        SQLCommandString = SQLCmdString
        SQLCommandType = SQLCmdType
        UseUserProvidedData = False
        DataBaseConnection = SQLConnection
        DisplayColumn = DisplayColumnString
        ValueColumn = ValueColumnString
        ControlTitle = Title
        Schedule_ID = SchedID
        Me.Name = ControlName
        Me.IndexOrder = IndexOrder
        Me.ControlID = ControlID
        Me.btnMore.Visible = IsExtraButtonOn
        Me.btnMore.Text = IIf(IsDBNull(ExtraButtonText), "", ExtraButtonText)
        UseForMultipleWorkbooks = MultiWorkbook
        Me.Location = New Point(Location_X, Location_Y)
        If ControlWidth > 0 Then SetControlWidth = ControlWidth
        If ControlHeight > 0 Then Me.Height = ControlHeight
        Me.loadDataOnCreation = loadDataOnCreation
        Me.SelectAllItemsOnCreate = SelectAllItemsOnCreation
        Me.displayRefreshButtonWhenParentChanges = DisplayRefreshButtonWhenParentChanges
        IsOkToGetData = Not DisplayRefreshButtonWhenParentChanges
        With CheckedListBox1
            .MultiColumn = IsMultiColumn
            .Height = IIf(IsLabel2On, Me.Height - 78, Me.Height - 56)
            If ColumnWidth > 0 Then .ColumnWidth = ColumnWidth
            .Anchor = AnchorStyles.Top + AnchorStyles.Left + AnchorStyles.Right + AnchorStyles.Bottom
        End With
        With Label1
            .Location = New Point(8, CheckedListBox1.Height + CheckedListBox1.Location.Y + 7)
            .Anchor = AnchorStyles.Bottom + AnchorStyles.Left
        End With
        With Label2
            .Visible = IsLabel2On
            .Text = Label2Text
            .Location = New Point(Label1.Location.X, Label1.Location.Y + 22)
            .Anchor = AnchorStyles.Bottom + AnchorStyles.Left
        End With

        Me.minSelectableItems = MinSelectableItems
        Me.maxSelectableItems = MaxSelectableItems
        NoData = False
    End Sub

    'This constructor queries the database for the content
    Public Sub New(ByVal ReportControlID As Integer, ByVal ReportID As Integer, ByVal UseReportIDToGetData As Boolean, _
            ByVal data As String, ByVal SQLConnection As SqlConnection, _
            ByVal DisplayColumnString As String, ByVal ValueColumnString As String, ByVal Title As String, _
            ByVal Location_X As Integer, ByVal Location_Y As Integer, _
            ByVal ControlWidth As Integer, ByVal ControlHeight As Integer, _
            ByVal ControlName As String, ByVal ControlID As Integer, _
            ByVal IsExtraButtonOn As Boolean, ByVal ExtraButtonText As String, _
            Optional ByVal ExtraButtonDataSetName As String = "", _
            Optional ByVal loadDataOnCreation As Boolean = True, _
            Optional ByVal DisplayRefreshButtonWhenParentChanges As Boolean = False, _
            Optional ByVal SelectAllItemsOnCreation As Boolean = False, _
            Optional ByVal IndexOrder As Integer = 0, _
            Optional ByVal checkedValues As String = "", _
            Optional ByVal ColumnWidth As Integer = 0, _
            Optional ByVal IsMultiColumn As Boolean = False, _
            Optional ByVal IsLabel2On As Boolean = False, _
            Optional ByVal Label2Text As String = "", _
            Optional ByVal MinSelectableItems As Integer = 0, _
            Optional ByVal MaxSelectableItems As Integer = 0, _
            Optional ByVal MultiWorkbook As Boolean = False, _
            Optional ByVal IsThisAChild As Boolean = False, _
            Optional ByVal ParentControl As DDT_BaseControl = Nothing, _
            Optional ByVal SchedID As Integer = 0)

        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        Me.ReportControlID = ReportControlID
        If Not ParentControl Is Nothing Then
            myParents.Add(ParentControl)
            ParentControl.myChildren.Add(Me)
        End If
        Me.ReportID = ReportID
        Me.useReportIDToGetData = UseReportIDToGetData
        ExtraDataSetName = ExtraButtonDataSetName
        UseUserProvidedData = False
        DataForListBox = dsroot.Tables(data)
        DisplayColumn = DisplayColumnString
        ValueColumn = ValueColumnString
        ControlTitle = Title
        IsChild = IsThisAChild
        UseForMultipleWorkbooks = MultiWorkbook
        Schedule_ID = SchedID
        Me.Name = ControlName
        Me.IndexOrder = IndexOrder
        Me.ControlID = ControlID
        Me.btnMore.Visible = IsExtraButtonOn
        Me.btnMore.Text = IIf(IsDBNull(ExtraButtonText), "", ExtraButtonText)
        DataBaseConnection = SQLConnection
        DataSetName = data
        Me.Location = New Point(Location_X, Location_Y)
        If ControlWidth > 0 Then SetControlWidth = ControlWidth
        If ControlHeight > 0 Then Me.Height = ControlHeight
        Me.loadDataOnCreation = loadDataOnCreation
        Me.SelectAllItemsOnCreate = SelectAllItemsOnCreation
        Me.displayRefreshButtonWhenParentChanges = DisplayRefreshButtonWhenParentChanges
        IsOkToGetData = Not DisplayRefreshButtonWhenParentChanges
        With CheckedListBox1
            .MultiColumn = IsMultiColumn
            .Height = IIf(IsLabel2On, Me.Height - 78, Me.Height - 56)
            If ColumnWidth > 0 Then .ColumnWidth = ColumnWidth
            .Anchor = AnchorStyles.Top + AnchorStyles.Left + AnchorStyles.Right + AnchorStyles.Bottom
        End With
        With Label1
            .Location = New Point(8, CheckedListBox1.Height + CheckedListBox1.Location.Y + 7)
            .Anchor = AnchorStyles.Bottom + AnchorStyles.Left
        End With
        With Label2
            .Visible = IsLabel2On
            .Text = Label2Text
            .Location = New Point(Label1.Location.X, Label1.Location.Y + 22)
            .Anchor = AnchorStyles.Bottom + AnchorStyles.Left
        End With

        Me.minSelectableItems = MinSelectableItems
        Me.maxSelectableItems = MaxSelectableItems
        NoData = False
    End Sub

    Public Sub New(ByVal ReportControlID As Integer, ByVal ReportID As Integer, ByVal data As DataTable, _
            ByVal DisplayColumnString As String, ByVal ValueColumnString As String, ByVal Title As String, _
            ByVal Location_X As Integer, ByVal Location_Y As Integer, _
            ByVal ControlWidth As Integer, ByVal ControlHeight As Integer, _
            ByVal ControlName As String, ByVal ControlID As Integer, _
            ByVal IsExtraButtonOn As Boolean, ByVal ExtraButtonText As String, _
            Optional ByVal checkedValues As String = "", _
            Optional ByVal IndexOrder As Integer = 0, _
            Optional ByVal ColumnWidth As Integer = 0, _
            Optional ByVal IsMultiColumn As Boolean = False, _
            Optional ByVal loadDataOnCreation As Boolean = True, _
            Optional ByVal DisplayRefreshButtonWhenParentChanges As Boolean = False, _
            Optional ByVal SelectAllItemsOnCreation As Boolean = False, _
            Optional ByVal IsLabel2On As Boolean = False, _
            Optional ByVal Label2Text As String = "", _
            Optional ByVal MinSelectableItems As Integer = 0, _
            Optional ByVal MaxSelectableItems As Integer = 0)

        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        Me.ReportControlID = ReportControlID
        Me.ReportID = ReportID
        UseUserProvidedData = True
        DataForListBox = data
        DisplayColumn = DisplayColumnString
        ValueColumn = ValueColumnString
        ControlTitle = Title
        Me.Name = ControlName
        Me.IndexOrder = IndexOrder
        Me.ControlID = ControlID
        Me.btnMore.Visible = IsExtraButtonOn
        Me.btnMore.Text = IIf(IsDBNull(ExtraButtonText), "", ExtraButtonText)

        Me.Location = New Point(Location_X, Location_Y)
        If ControlWidth > 0 Then SetControlWidth = ControlWidth
        If ControlHeight > 0 Then Me.Height = ControlHeight
        Me.loadDataOnCreation = loadDataOnCreation
        Me.SelectAllItemsOnCreate = SelectAllItemsOnCreation
        Me.displayRefreshButtonWhenParentChanges = DisplayRefreshButtonWhenParentChanges
        IsOkToGetData = Not DisplayRefreshButtonWhenParentChanges
        With CheckedListBox1
            .MultiColumn = IsMultiColumn
            .Height = IIf(IsLabel2On, Me.Height - 78, Me.Height - 56)
            If ColumnWidth > 0 Then .ColumnWidth = ColumnWidth
            .Anchor = AnchorStyles.Top + AnchorStyles.Left + AnchorStyles.Right + AnchorStyles.Bottom
        End With
        With Label1
            .Location = New Point(8, CheckedListBox1.Height + CheckedListBox1.Location.Y + 7)
            .Anchor = AnchorStyles.Bottom + AnchorStyles.Left
        End With
        With Label2
            .Visible = IsLabel2On
            .Text = Label2Text
            .Location = New Point(Label1.Location.X, Label1.Location.Y + 22)
            .Anchor = AnchorStyles.Bottom + AnchorStyles.Left
        End With
        Me.minSelectableItems = MinSelectableItems
        Me.maxSelectableItems = MaxSelectableItems
        NoData = False
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DDT_ListBox))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnRefreshData = New System.Windows.Forms.Button()
        Me.btnMore = New System.Windows.Forms.Button()
        Me.CheckedListBox1 = New System.Windows.Forms.CheckedListBox()
        Me.btnNone = New System.Windows.Forms.Button()
        Me.btnAll = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuSelectAll = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuDeselectAll = New System.Windows.Forms.ToolStripMenuItem()
        Me.GroupBox1.SuspendLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnRefreshData)
        Me.GroupBox1.Controls.Add(Me.btnMore)
        Me.GroupBox1.Controls.Add(Me.CheckedListBox1)
        Me.GroupBox1.Controls.Add(Me.btnNone)
        Me.GroupBox1.Controls.Add(Me.btnAll)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(271, 146)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "GroupBox1"
        '
        'btnRefreshData
        '
        Me.btnRefreshData.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnRefreshData.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnRefreshData.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRefreshData.Image = CType(resources.GetObject("btnRefreshData.Image"), System.Drawing.Image)
        Me.btnRefreshData.Location = New System.Drawing.Point(40, 24)
        Me.btnRefreshData.Name = "btnRefreshData"
        Me.btnRefreshData.Size = New System.Drawing.Size(128, 56)
        Me.btnRefreshData.TabIndex = 23
        Me.btnRefreshData.Visible = False
        '
        'btnMore
        '
        Me.btnMore.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnMore.Location = New System.Drawing.Point(197, 78)
        Me.btnMore.Name = "btnMore"
        Me.btnMore.Size = New System.Drawing.Size(61, 23)
        Me.btnMore.TabIndex = 22
        Me.btnMore.Text = "SB500"
        Me.btnMore.UseVisualStyleBackColor = True
        '
        'CheckedListBox1
        '
        Me.CheckedListBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CheckedListBox1.CheckOnClick = True
        Me.CheckedListBox1.HorizontalScrollbar = True
        Me.CheckedListBox1.Location = New System.Drawing.Point(11, 20)
        Me.CheckedListBox1.Name = "CheckedListBox1"
        Me.CheckedListBox1.Size = New System.Drawing.Size(179, 55)
        Me.CheckedListBox1.Sorted = True
        Me.CheckedListBox1.TabIndex = 20
        '
        'btnNone
        '
        Me.btnNone.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnNone.Location = New System.Drawing.Point(197, 49)
        Me.btnNone.Name = "btnNone"
        Me.btnNone.Size = New System.Drawing.Size(61, 23)
        Me.btnNone.TabIndex = 18
        Me.btnNone.Text = "None"
        '
        'btnAll
        '
        Me.btnAll.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAll.Location = New System.Drawing.Point(197, 20)
        Me.btnAll.Name = "btnAll"
        Me.btnAll.Size = New System.Drawing.Size(61, 23)
        Me.btnAll.TabIndex = 17
        Me.btnAll.Text = "All"
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label2.Location = New System.Drawing.Point(8, 114)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(209, 21)
        Me.Label2.TabIndex = 21
        Me.Label2.Text = "Label2"
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label1.Location = New System.Drawing.Point(8, 93)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(209, 21)
        Me.Label1.TabIndex = 19
        Me.Label1.Text = "Label1"
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuSelectAll, Me.mnuDeselectAll})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(138, 48)
        '
        'mnuSelectAll
        '
        Me.mnuSelectAll.Name = "mnuSelectAll"
        Me.mnuSelectAll.Size = New System.Drawing.Size(137, 22)
        Me.mnuSelectAll.Text = "Select All"
        '
        'mnuDeselectAll
        '
        Me.mnuDeselectAll.Name = "mnuDeselectAll"
        Me.mnuDeselectAll.Size = New System.Drawing.Size(137, 22)
        Me.mnuDeselectAll.Text = "Select None"
        '
        'DDT_ListBox
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "DDT_ListBox"
        Me.Size = New System.Drawing.Size(271, 146)
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

#End Region

#Region "Declared Properties"

    <Browsable(True), Category("Data"), Description("The dataset name that fills the list box.")> _
    Public Property DataSetName() As String
        Get
            Return _DataSetName
        End Get
        Set(ByVal value As String)
            _DataSetName = value
        End Set
    End Property

    <Browsable(True), Category("Data"), Description("SQL database connection object to connect to the database.")> _
    Public Property DataBaseConnection() As SqlConnection
        Get
            Return _DataBaseConnection
        End Get
        Set(ByVal Value As SqlConnection)
            _DataBaseConnection = Value
        End Set
    End Property

    <Browsable(True), Category("Data"), DefaultValue(""), Description("SQL command used to fill the listbox.  This is usually a stored procedure.")> _
    Public Property SQLCommandString() As String
        Get
            Return _SQLCommandString
        End Get
        Set(ByVal Value As String)
            _SQLCommandString = Value
        End Set
    End Property

    <Browsable(True), Category("Data"), Description("SQL command type.")> _
    Public Property SQLCommandType() As CommandType
        Get
            Return _SQLCommandType
        End Get
        Set(ByVal Value As CommandType)
            _SQLCommandType = Value
        End Set
    End Property

    <Browsable(True), Category("Data"), Description("Sets or gets the data table for the ListBox.")> _
    Public Property DataForListBox() As DataTable
        Get
            Return _DataForListBox
        End Get
        Set(ByVal Value As DataTable)
            _DataForListBox = Value
        End Set
    End Property

    <Browsable(True), Category("Data"), Description("The column name that contains the data to display.  The user sees the contents of this field.")> _
    Public Property DisplayColumn() As String
        Get
            Return _DisplayColumn
        End Get
        Set(ByVal Value As String)
            _DisplayColumn = Value
        End Set
    End Property

    <Browsable(True), Category("Data"), Description("The column name that is used for the id field. The user does not see the contents of this field.  It binds the display and the id fields.")> _
    Public Property ValueColumn() As String
        Get
            Return _ValueColumn
        End Get
        Set(ByVal Value As String)
            _ValueColumn = Value
        End Set
    End Property

    <Browsable(True), Category("Appearance"), DefaultValue("Title"), Description("Title of the control, which is the group box title.")> _
    Public Property ControlTitle() As String
        Get
            Return GroupBox1.Text
        End Get
        Set(ByVal Value As String)
            GroupBox1.Text = Value
        End Set
    End Property

    <Browsable(True), Category("Layout"), Description("The order of the control when linked with other controls.  The default is zero.")> _
    Public Property ControlOrder() As Integer
        Get
            Return _ControlOrder
        End Get
        Set(ByVal Value As Integer)
            _ControlOrder = Value
        End Set
    End Property

    <Browsable(True), Category("Control"), Description("The parent control for this control.")> _
    Public WriteOnly Property AddParentControl() As DDT_BaseControl
        'Get
        '    Return myParent
        'End Get
        Set(ByVal Value As DDT_BaseControl)
            myParents.Add(Value)
        End Set
    End Property

    <Browsable(True), Category("Control"), Description("The child control for this control.")> _
    Public WriteOnly Property AddChildControl() As DDT_BaseControl
        Set(ByVal Value As DDT_BaseControl)
            myChildren.Add(Value)
        End Set
    End Property

    <Browsable(True), Category("Layout"), Description("Set the width of the control.  This also changes the width of the embeded controls.")> _
    Public WriteOnly Property SetControlWidth() As Integer
        Set(ByVal Value As Integer)
            'set the width of the control
            Me.Width = Value
        End Set
    End Property

    <Browsable(True), Category("Layout"), Description("Set the height of the control.  This also changes the height of the embeded controls.")> _
    Public WriteOnly Property SetControlHeight() As Integer
        Set(ByVal Value As Integer)
            'set the width of the control
            Me.Height = Value
        End Set
    End Property

    <Browsable(True), Category("Appearance"), DefaultValue(True), Description("Turns on/off label 1.")> _
    Public Property TurnOn_Label1() As Boolean
        Set(ByVal Value As Boolean)
            If Not Value Then
                Me.Height -= Me.Label1.Height
            End If
            Me.Label1.Visible = Value
        End Set
        Get
            If Not Me.Label1.Visible Then
                Return False
            Else
                Return True
            End If
        End Get
    End Property

    <Browsable(True), Category("Appearance"), DefaultValue(False), Description("Turns on/off label 2.")> _
    Public Property TurnOn_Label2() As Boolean
        Set(ByVal Value As Boolean)
            If Not Value Then
                Me.Height -= Me.Label2.Height
            End If
            Me.Label2.Visible = Value
        End Set
        Get
            If Not Me.Label2.Visible Then
                Return False
            Else
                Return True
            End If
        End Get
    End Property

    <Browsable(True), Category("Appearance"), DefaultValue(False), Description("Turns the extra button visible.")> _
    Public Property TurnOn_Buttons() As Boolean
        Set(ByVal Value As Boolean)
            Me.btnMore.Visible = Value
        End Set
        Get
            If Not Me.btnMore.Visible Then
                Return False
            Else
                Return True
            End If
        End Get
    End Property
#End Region

End Class
