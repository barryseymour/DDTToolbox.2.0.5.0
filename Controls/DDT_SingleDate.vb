Imports System.Data.SqlClient
Imports System.ComponentModel
Imports Microsoft.VisualBasic

Public Class DDT_SingleDate
    Inherits DDT_BaseControl

    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Public WithEvents dtpDateSingle As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Private NoParams As Boolean = True
    Public ShouldLabelBeOn As Boolean = True

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()
        NoParams = True
        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
    End Sub

    Public Sub New(ByVal ReportControlID As Integer, ByVal ReportID As Integer, ByVal Location_X As Integer, ByVal Location_Y As Integer, _
            ByVal ControlWidth As Integer, ByVal ControlHeight As Integer, ByVal ControlName As String, ByVal ControlID As Integer, _
            ByVal Title As String, ByVal IndexOrder As Integer, ByVal IsLabelOn As Boolean, ByVal Label As String, ByVal MaxDaysSpan As Integer, _
            ByVal DefaultStartDate As DateTime, ByVal DefaultEndDate As DateTime, ByVal MinDate As DateTime, ByVal MaxDate As DateTime, _
            Optional ByVal TypeOfFormat As String = "short", Optional ByVal CustomFormat As String = "", _
            Optional ByVal Tag As String = "", Optional ByVal TextAlign As String = "", Optional ByVal FontName As String = "", _
            Optional ByVal FontSize As Integer = 8, Optional ByVal FontBold As Boolean = False, Optional ByVal FontItalic As Boolean = False, _
            Optional ByVal FontUnderline As Boolean = False, Optional ByVal FontColor As String = "", Optional ByVal BackColor As String = "", _
            Optional ByVal ForeColor As String = "")
        MyBase.New()
        NoParams = False
        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call        
        Dim fontStyle As FontStyle = Drawing.FontStyle.Regular
        'Add any initialization after the InitializeComponent() call
        Me.ReportControlID = ReportControlID
        Me.ReportID = ReportID
        Me.Location = New Point(Location_X, Location_Y)
        If ControlWidth > 0 Then Me.Width = ControlWidth
        If ControlHeight > 0 Then Me.Height = ControlHeight
        ShouldLabelBeOn = IsLabelOn
        Label1.Text = Label
        Me.Name = ControlName
        Me.ControlID = ControlID
        ControlTitle = Title
        Me.IndexOrder = IndexOrder
        dtpDateSingle.MinDate = MinDate
        dtpDateSingle.MaxDate = MaxDate
        dtpDateSingle.Value = StartDate
        dtpDateSingle.Format = IIf(TypeOfFormat = "short", DateTimePickerFormat.Short, IIf(TypeOfFormat = "custom", DateTimePickerFormat.Custom, IIf(TypeOfFormat = "long", DateTimePickerFormat.Long, DateTimePickerFormat.Time)))
        If TypeOfFormat = "custom" Then dtpDateSingle.CustomFormat = CustomFormat
        Me.Tag = Tag
        If FontBold Then fontStyle = Drawing.FontStyle.Bold
        If FontItalic Then fontStyle = Drawing.FontStyle.Italic
        If FontUnderline Then fontStyle = Drawing.FontStyle.Underline
        If FontBold And FontItalic Then fontStyle = Drawing.FontStyle.Bold + Drawing.FontStyle.Italic
        If FontBold And FontUnderline Then fontStyle = Drawing.FontStyle.Bold + Drawing.FontStyle.Underline
        If FontUnderline And FontItalic Then fontStyle = Drawing.FontStyle.Underline + Drawing.FontStyle.Italic
        If FontBold And FontItalic And FontUnderline Then fontStyle = Drawing.FontStyle.Bold + Drawing.FontStyle.Underline + Drawing.FontStyle.Italic
        If FontName <> "" Then
            Me.Font = New Font(FontName, FontSize, fontStyle)
        End If
        Me.ForeColor = IIf(ForeColor = "", Color.Black, Color.FromName(ForeColor))
        Me.BackColor = IIf(BackColor = "", Color.Transparent, Color.FromName(BackColor))
        Label1.ForeColor = IIf(FontColor = "", Color.Black, Color.FromName(FontColor))
    End Sub

    Public Sub New(ByVal ReportControlID As Integer, ByVal ReportID As Integer, ByVal Location_X As Integer, ByVal Location_Y As Integer, _
            ByVal ControlWidth As Integer, ByVal ControlHeight As Integer, _
            ByVal ControlName As String, ByVal ControlID As Integer, ByVal Title As String, _
            ByVal IndexOrder As Integer, _
            ByVal IsLabelOn As Boolean, ByVal Label As String, _
            ByVal FormatType As DateTimePickerFormat, ByVal CustomFormat As String)

        MyBase.New()
        NoParams = False
        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        Me.ReportControlID = ReportControlID
        Me.ReportID = ReportID
        Me.Location = New Point(Location_X, Location_Y)
        If ControlWidth > 0 Then Me.Width = ControlWidth
        If ControlHeight > 0 Then Me.Height = ControlHeight
        ShouldLabelBeOn = IsLabelOn
        Label1.Text = Label
        Me.Name = ControlName
        Me.ControlID = ControlID
        ControlTitle = Title
        Me.IndexOrder = IndexOrder
        dtpDateSingle.Value = StartDate
        dtpDateSingle.Format = FormatType
        If FormatType = DateTimePickerFormat.Custom Then
            dtpDateSingle.CustomFormat = CustomFormat
        End If
    End Sub

    Public Sub New(ByVal ReportControlID As Integer, ByVal ReportID As Integer, ByVal Location_X As Integer, ByVal Location_Y As Integer, _
            ByVal ControlWidth As Integer, ByVal ControlHeight As Integer, _
            ByVal ControlName As String, ByVal ControlID As Integer, ByVal Title As String, _
            ByVal IndexOrder As Integer, _
            ByVal IsLabelOn As Boolean, ByVal Label As String, _
            ByVal FormatType As DateTimePickerFormat, ByVal CustomFormat As String, _
            ByVal DefaultStartDate As DateTime)

        MyBase.New()
        NoParams = False
        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        Me.ReportControlID = ReportControlID
        Me.ReportID = ReportID
        Me.Location = New Point(Location_X, Location_Y)
        If ControlWidth > 0 Then Me.Width = ControlWidth
        If ControlHeight > 0 Then Me.Height = ControlHeight
        ShouldLabelBeOn = IsLabelOn
        Label1.Text = Label
        Me.Name = ControlName
        Me.ControlID = ControlID
        ControlTitle = Title
        Me.IndexOrder = IndexOrder
        dtpDateSingle.Value = StartDate
        dtpDateSingle.Format = FormatType
        If FormatType = DateTimePickerFormat.Custom Then
            dtpDateSingle.CustomFormat = CustomFormat
        End If
    End Sub

    Public Sub New(ByVal ReportControlID As Integer, ByVal ReportID As Integer, ByVal Location_X As Integer, ByVal Location_Y As Integer, _
            ByVal ControlWidth As Integer, ByVal ControlHeight As Integer, _
            ByVal ControlName As String, ByVal ControlID As Integer, ByVal Title As String, _
            ByVal IndexOrder As Integer, _
            ByVal IsLabelOn As Boolean, ByVal Label As String, _
            ByVal FormatType As DateTimePickerFormat, ByVal CustomFormat As String, _
            ByVal DefaultStartDate As DateTime, ByVal MinDate As DateTime)

        MyBase.New()
        NoParams = False
        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        Me.ReportControlID = ReportControlID
        Me.ReportID = ReportID
        Me.Location = New Point(Location_X, Location_Y)
        If ControlWidth > 0 Then Me.Width = ControlWidth
        If ControlHeight > 0 Then Me.Height = ControlHeight
        ShouldLabelBeOn = IsLabelOn
        Label1.Text = Label
        Me.Name = ControlName
        Me.ControlID = ControlID
        ControlTitle = Title
        Me.IndexOrder = IndexOrder
        dtpDateSingle.Value = StartDate
        dtpDateSingle.MinDate = MinDate
        dtpDateSingle.Format = FormatType
        If FormatType = DateTimePickerFormat.Custom Then
            dtpDateSingle.CustomFormat = CustomFormat
        End If
    End Sub

    Public Sub New(ByVal ReportControlID As Integer, ByVal ReportID As Integer, ByVal Location_X As Integer, ByVal Location_Y As Integer, _
            ByVal ControlWidth As Integer, ByVal ControlHeight As Integer, _
            ByVal ControlName As String, ByVal ControlID As Integer, ByVal Title As String, _
            ByVal IndexOrder As Integer, _
            ByVal IsLabelOn As Boolean, ByVal Label As String, _
            ByVal FormatType As DateTimePickerFormat, ByVal CustomFormat As String, _
            ByVal DefaultStartDate As DateTime, ByVal MinDate As DateTime, ByVal MaxDate As DateTime)

        MyBase.New()
        NoParams = False
        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        Me.ReportControlID = ReportControlID
        Me.ReportID = ReportID
        Me.Location = New Point(Location_X, Location_Y)
        If ControlWidth > 0 Then Me.Width = ControlWidth
        If ControlHeight > 0 Then Me.Height = ControlHeight
        ShouldLabelBeOn = IsLabelOn
        Label1.Text = Label
        Me.Name = ControlName
        Me.ControlID = ControlID
        ControlTitle = Title
        Me.IndexOrder = IndexOrder
        dtpDateSingle.Value = StartDate
        dtpDateSingle.MinDate = MinDate
        dtpDateSingle.MaxDate = MaxDate
        dtpDateSingle.Format = FormatType
        If FormatType = DateTimePickerFormat.Custom Then
            dtpDateSingle.CustomFormat = CustomFormat
        End If
    End Sub

    'UserControl overrides dispose to clean up the component list.
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.dtpDateSingle = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.dtpDateSingle)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(144, 63)
        Me.GroupBox1.TabIndex = 14
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Date"
        '
        'dtpDateSingle
        '
        Me.dtpDateSingle.CustomFormat = "ddd MM/dd/yyyy"
        Me.dtpDateSingle.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpDateSingle.Location = New System.Drawing.Point(10, 17)
        Me.dtpDateSingle.Name = "dtpDateSingle"
        Me.dtpDateSingle.Size = New System.Drawing.Size(120, 23)
        Me.dtpDateSingle.TabIndex = 15
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(10, 41)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(120, 15)
        Me.Label1.TabIndex = 16
        Me.Label1.Text = "Label1"
        '
        'DDT_SingleDate
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "DDT_SingleDate"
        Me.Size = New System.Drawing.Size(144, 63)
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    <Browsable(True), Category("Appearance"), DefaultValue(False), Description("Title of the control, which is the group box title.")> _
    Public Property ControlTitle() As String
        Get
            Return GroupBox1.Text
        End Get
        Set(ByVal Value As String)
            GroupBox1.Text = Value
        End Set
    End Property
End Class
