Imports System.Data.SqlClient
Imports System.ComponentModel

Public Class DDT_DataGridView
    Inherits DDT_BaseControl

#Region "Declared Variables"
    Private NoData As Boolean = False
    Private _SQLCommandType As CommandType = CommandType.Text
    Private _SQLCommandString As String
    Private _DisplayColumn As String
    Private _ValueColumn As String
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
    Private _ControlOrder As Integer
    Private userSelectedDataInDilimitedFormat As String
    Private UseUserProvidedData As Boolean
    Private Schedule_ID As Integer
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents mnuSelectAll As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuDeselectAll As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents btnRefreshData As System.Windows.Forms.Button
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Public WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ValueDescription As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ParentID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EmployeeNumber As System.Windows.Forms.DataGridViewTextBoxColumn
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DDT_DataGridView))
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuSelectAll = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuDeselectAll = New System.Windows.Forms.ToolStripMenuItem()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.ValueDescription = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ParentID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EmployeeNumber = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnRefreshData = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.ContextMenuStrip1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
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
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.DataGridView1)
        Me.GroupBox1.Controls.Add(Me.btnRefreshData)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(316, 344)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "GroupBox1"
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.AllowUserToResizeColumns = False
        Me.DataGridView1.AllowUserToResizeRows = False
        Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.ColumnHeadersVisible = False
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ValueDescription, Me.ParentID, Me.EmployeeNumber})
        Me.DataGridView1.Location = New System.Drawing.Point(13, 23)
        Me.DataGridView1.MultiSelect = False
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(402, 138)
        Me.DataGridView1.TabIndex = 24
        '
        'ValueDescription
        '
        Me.ValueDescription.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.ValueDescription.HeaderText = "Organizations"
        Me.ValueDescription.Name = "ValueDescription"
        Me.ValueDescription.ReadOnly = True
        Me.ValueDescription.Width = 5
        '
        'ParentID
        '
        Me.ParentID.HeaderText = "ParentID"
        Me.ParentID.Name = "ParentID"
        Me.ParentID.ReadOnly = True
        Me.ParentID.Visible = False
        '
        'EmployeeNumber
        '
        Me.EmployeeNumber.HeaderText = "EmployeeNumber"
        Me.EmployeeNumber.Name = "EmployeeNumber"
        Me.EmployeeNumber.ReadOnly = True
        Me.EmployeeNumber.Visible = False
        '
        'btnRefreshData
        '
        Me.btnRefreshData.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnRefreshData.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnRefreshData.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRefreshData.Image = CType(resources.GetObject("btnRefreshData.Image"), System.Drawing.Image)
        Me.btnRefreshData.Location = New System.Drawing.Point(47, 110)
        Me.btnRefreshData.Name = "btnRefreshData"
        Me.btnRefreshData.Size = New System.Drawing.Size(149, 65)
        Me.btnRefreshData.TabIndex = 23
        Me.btnRefreshData.Visible = False
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label1.Location = New System.Drawing.Point(9, 223)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(244, 24)
        Me.Label1.TabIndex = 19
        Me.Label1.Text = "Label1"
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label2.Location = New System.Drawing.Point(9, 247)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(244, 24)
        Me.Label2.TabIndex = 21
        Me.Label2.Text = "Label2"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'DDT_DataGridView
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "DDT_DataGridView"
        Me.Size = New System.Drawing.Size(316, 344)
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Declared Properties"

    <Browsable(True), Category("Data"), Description("The dataset name that fills the DataGridView.")> _
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

    <Browsable(True), Category("Data"), DefaultValue(""), Description("SQL command used to fill the DataGridView.  This is usually a stored procedure.")> _
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

#End Region

End Class
