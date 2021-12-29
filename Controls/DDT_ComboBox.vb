Imports System.Data.SqlClient
Imports System.ComponentModel

Public Class DDT_ComboBox
    Inherits DDTToolbox.DDT_BaseControl

    Private _sqlCmdType As CommandType = CommandType.Text
    Private _SQLCommandString As String
    Private _DisplayColumn As String
    Private _ValueColumn As String
    Private _ControlTitle As String = "DDT Combo Box Control"
    Private useReportIDToGetData As Boolean

    Private _DataBaseConnection As New SqlConnection
    Private dt As New DataTable
    Private sc As New SqlCommand
    Private da As New SqlDataAdapter
    Private selected As Integer = 0

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    Public Sub New(ByVal ReportControlID As Integer, ByVal ReportID As Integer, ByVal UseReportIDToGetData As Boolean, _
        ByVal cmdString As String, ByVal cmdType As CommandType, _
        ByVal conn As SqlConnection, ByVal DisplayColumnString As String, _
        ByVal ValueColumnString As String, ByVal Title As String, _
        ByVal Location_X As Integer, ByVal Location_Y As Integer, _
        ByVal ControlWidth As Integer, ByVal ControlHeight As Integer, _
        ByVal ControlID As Integer, ByVal ControlName As String, _
        ByVal IndexOrder As Integer, ByVal indexSelected As Integer)

        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        Me.ReportControlID = ReportControlID
        Me.ReportID = ReportID
        Me.useReportIDToGetData = UseReportIDToGetData
        _SQLCommandString = cmdString
        _sqlCmdType = cmdType
        _DataBaseConnection = conn
        DisplayColumn = DisplayColumnString
        ValueColumn = ValueColumnString
        Me.Location = New Point(Location_X, Location_Y)
        If ControlWidth > 0 Then SetControlWidth = ControlWidth
        If ControlHeight > 0 Then SetControlHeight = ControlHeight
        Me.ControlTitle = Title
        Me.ControlID = ControlID
        Me.Name = ControlName
        Me.IndexOrder = IndexOrder
        Me.useReportIDToGetData = UseReportIDToGetData
        selected = indexSelected
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
    Public WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Public WithEvents cbo As System.Windows.Forms.ComboBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cbo = New System.Windows.Forms.ComboBox()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cbo)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(280, 48)
        Me.GroupBox1.TabIndex = 11
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Combo Box"
        '
        'cbo
        '
        Me.cbo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cbo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo.Location = New System.Drawing.Point(3, 19)
        Me.cbo.Name = "cbo"
        Me.cbo.Size = New System.Drawing.Size(274, 23)
        Me.cbo.TabIndex = 0
        '
        'DDT_ComboBox
        '
        Me.AutoScroll = True
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "DDT_ComboBox"
        Me.Size = New System.Drawing.Size(280, 48)
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Declared Properties"

    <Browsable(True), Category("Layout"), Description("Set the width of the control.  This also changes the width of the embeded controls.")> _
    Public WriteOnly Property SetControlWidth() As Integer
        Set(ByVal Value As Integer)
            'set the width of the control
            Me.Width = Value

            'set the width of embeded controls as a percentage of the control
            Me.GroupBox1.Width = Value * 0.976
            Me.cbo.Width = Value * 0.891
        End Set
    End Property

    <Browsable(True), Category("Layout"), Description("Set the height of the control.  This also changes the height of the embeded controls.")> _
    Public WriteOnly Property SetControlHeight() As Integer
        Set(ByVal Value As Integer)
            'set the width of the control
            Me.Height = Value

            'set the width of embeded controls as a percentage of the control
            Me.GroupBox1.Height = Value * 0.859
            Me.cbo.Height = Value * 0.375
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

    <Browsable(True), Category("Data"), DefaultValue("Display"), Description("The column name that contains the data to display.  The user sees the contents of this field.")> _
    Public Property DisplayColumn() As String
        Get
            Return _DisplayColumn
        End Get
        Set(ByVal Value As String)
            _DisplayColumn = Value
        End Set
    End Property

    <Browsable(True), Category("Data"), DefaultValue("Value"), Description("The column name that is used for the id field. The user does not see the contents of this field.  It binds the display and the id fields.")> _
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
            Return _ControlTitle
        End Get
        Set(ByVal Value As String)
            _ControlTitle = Value
        End Set
    End Property
#End Region

    'This method should be set before showing the form
    Public Sub SetSQLCommandSettings(Optional ByVal SQLCommandString As String = "", Optional ByVal SQLCommandType As CommandType = CommandType.Text, _
        Optional ByVal SQLConnection As SqlConnection = Nothing)
        Try
            'Add any initialization after the InitializeComponent() call

            _SQLCommandString = SQLCommandString
            _sqlCmdType = SQLCommandType
            _DataBaseConnection = SQLConnection
        Catch ex As Exception
            EmailErrorAlert(_DataBaseConnection, ex.Message, gUserID, gApplicationName, gApplicationVersion, gUserID, CallFromType, CallFrom, gWorkstationID, gOsName)
        End Try
    End Sub

End Class
