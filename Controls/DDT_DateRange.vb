Imports System.ComponentModel

Public Class DDT_DateRange
    Inherits DDT_BaseControl

    Public MaxDaysSpan As Integer = 0
    Public ShouldLabelBeOn As Boolean = True
    Private MinStartDate As Date
    Private MaxEndDate As Date
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Public WithEvents dtpDateStart As System.Windows.Forms.DateTimePicker
    Public WithEvents dtpDateEnd As System.Windows.Forms.DateTimePicker
    Private IsKeysPressed As Boolean = False
    Public WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents cmsCopyDate As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents CopyToEndDate As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CopyToStartDate As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label2 As System.Windows.Forms.Label


#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
    End Sub

    Public Sub New(ByVal ReportControlID As Integer, ByVal ReportID As Integer, ByVal Location_X As Integer, ByVal Location_Y As Integer, _
            ByVal ControlWidth As Integer, ByVal ControlHeight As Integer, _
            ByVal ControlName As String, ByVal ControlID As Integer, ByVal Title As String, _
            ByVal IndexOrder As Integer, _
            ByVal IsLabelOn As Boolean, ByVal Label As String, _
            ByVal FormatType As DateTimePickerFormat, ByVal CustomFormat As String, _
            ByVal MaxDaysSpan As Integer)

        MyBase.New()

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
        dtpDateEnd.Format = FormatType
        dtpDateStart.Format = FormatType
        If FormatType = DateTimePickerFormat.Custom Then
            dtpDateStart.CustomFormat = CustomFormat
            dtpDateEnd.CustomFormat = CustomFormat
        End If
        Me.MaxDaysSpan = MaxDaysSpan
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

        'This call is required by the Windows Form Designer.
        InitializeComponent()

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
        dtpDateStart.Value = StartDate
        dtpDateEnd.Value = EndDate
        dtpDateStart.Format = IIf(TypeOfFormat = "short", DateTimePickerFormat.Short, IIf(TypeOfFormat = "custom", DateTimePickerFormat.Custom, IIf(TypeOfFormat = "long", DateTimePickerFormat.Long, DateTimePickerFormat.Time)))
        dtpDateEnd.Format = IIf(TypeOfFormat = "short", DateTimePickerFormat.Short, IIf(TypeOfFormat = "custom", DateTimePickerFormat.Custom, IIf(TypeOfFormat = "long", DateTimePickerFormat.Long, DateTimePickerFormat.Time)))
        If TypeOfFormat = "custom" Then
            dtpDateStart.CustomFormat = CustomFormat
            dtpDateEnd.CustomFormat = CustomFormat
        End If
        Me.MaxDaysSpan = MaxDaysSpan
        MinStartDate = MinDate
        MaxEndDate = MaxDate
        dtpDateStart.MinDate = MinDate
        dtpDateEnd.MinDate = MinDate
        dtpDateEnd.MaxDate = MaxDate
        dtpDateStart.MaxDate = MaxDate
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
            ByVal FormatType As DateTimePickerFormat, ByVal CustomFormat As String, _
            ByVal MaxDaysSpan As Integer, ByVal DefaultStartDate As DateTime, ByVal DefaultEndDate As DateTime)

        MyBase.New()

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
        dtpDateStart.Value = StartDate
        dtpDateEnd.Value = EndDate
        dtpDateEnd.Format = FormatType
        dtpDateStart.Format = FormatType
        dtpDateEnd.Format = FormatType
        If FormatType = DateTimePickerFormat.Custom Then
            dtpDateStart.CustomFormat = CustomFormat
            dtpDateEnd.CustomFormat = CustomFormat
        End If
        Me.MaxDaysSpan = MaxDaysSpan
    End Sub

    Public Sub New(ByVal ReportControlID As Integer, ByVal ReportID As Integer, ByVal Location_X As Integer, ByVal Location_Y As Integer, _
            ByVal ControlWidth As Integer, ByVal ControlHeight As Integer, _
            ByVal ControlName As String, ByVal ControlID As Integer, ByVal Title As String, _
            ByVal IndexOrder As Integer, _
            ByVal IsLabelOn As Boolean, ByVal Label As String, _
            ByVal FormatType As DateTimePickerFormat, ByVal CustomFormat As String, _
            ByVal MaxDaysSpan As Integer, ByVal DefaultStartDate As DateTime, ByVal DefaultEndDate As DateTime, _
            ByVal MinDate As DateTime)

        MyBase.New()

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
        dtpDateStart.Value = StartDate
        dtpDateEnd.Value = EndDate
        dtpDateStart.MinDate = MinDate
        dtpDateEnd.Format = FormatType
        dtpDateStart.Format = FormatType
        dtpDateEnd.Format = FormatType
        If FormatType = DateTimePickerFormat.Custom Then
            dtpDateStart.CustomFormat = CustomFormat
            dtpDateEnd.CustomFormat = CustomFormat
        End If
        Me.MaxDaysSpan = MaxDaysSpan

    End Sub

    Public Sub New(ByVal ReportControlID As Integer, ByVal ReportID As Integer, ByVal Location_X As Integer, ByVal Location_Y As Integer, _
            ByVal ControlWidth As Integer, ByVal ControlHeight As Integer, _
            ByVal ControlName As String, ByVal ControlID As Integer, ByVal Title As String, _
            ByVal IndexOrder As Integer, _
            ByVal IsLabelOn As Boolean, ByVal Label As String, _
            ByVal FormatType As DateTimePickerFormat, ByVal CustomFormat As String, _
            ByVal MaxDaysSpan As Integer, ByVal DefaultStartDate As DateTime, ByVal DefaultEndDate As DateTime, _
            ByVal MinDate As DateTime, ByVal MaxDate As DateTime)

        MyBase.New()

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
        MinStartDate = MinDate
        MaxEndDate = MaxDate
        dtpDateStart.Value = StartDate
        dtpDateEnd.Value = EndDate
        dtpDateStart.MinDate = MinDate
        dtpDateEnd.MaxDate = MaxDate
        dtpDateEnd.Format = FormatType
        dtpDateStart.Format = FormatType
        dtpDateEnd.Format = FormatType
        If FormatType = DateTimePickerFormat.Custom Then
            dtpDateStart.CustomFormat = CustomFormat
            dtpDateEnd.CustomFormat = CustomFormat
        End If
        Me.MaxDaysSpan = MaxDaysSpan
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
        Me.components = New System.ComponentModel.Container()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtpDateEnd = New System.Windows.Forms.DateTimePicker()
        Me.cmsCopyDate = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.CopyToEndDate = New System.Windows.Forms.ToolStripMenuItem()
        Me.CopyToStartDate = New System.Windows.Forms.ToolStripMenuItem()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dtpDateStart = New System.Windows.Forms.DateTimePicker()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.cmsCopyDate.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label1.Location = New System.Drawing.Point(6, 43)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(268, 22)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "Label1"
        '
        'dtpDateEnd
        '
        Me.dtpDateEnd.ContextMenuStrip = Me.cmsCopyDate
        Me.dtpDateEnd.CustomFormat = "ddd MM/dd/yyyy"
        Me.dtpDateEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpDateEnd.Location = New System.Drawing.Point(156, 17)
        Me.dtpDateEnd.Name = "dtpDateEnd"
        Me.dtpDateEnd.Size = New System.Drawing.Size(127, 23)
        Me.dtpDateEnd.TabIndex = 9
        '
        'cmsCopyDate
        '
        Me.cmsCopyDate.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CopyToEndDate, Me.CopyToStartDate})
        Me.cmsCopyDate.Name = "cmsCopyDate"
        Me.cmsCopyDate.Size = New System.Drawing.Size(171, 48)
        '
        'CopyToEndDate
        '
        Me.CopyToEndDate.Name = "CopyToEndDate"
        Me.CopyToEndDate.Size = New System.Drawing.Size(170, 22)
        Me.CopyToEndDate.Text = "Copy to End Date"
        '
        'CopyToStartDate
        '
        Me.CopyToStartDate.Name = "CopyToStartDate"
        Me.CopyToStartDate.Size = New System.Drawing.Size(170, 22)
        Me.CopyToStartDate.Text = "Copy to Start Date"
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.dtpDateStart)
        Me.GroupBox1.Controls.Add(Me.dtpDateEnd)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(286, 68)
        Me.GroupBox1.TabIndex = 11
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Date Range"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(138, 19)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(12, 15)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "-"
        '
        'dtpDateStart
        '
        Me.dtpDateStart.ContextMenuStrip = Me.cmsCopyDate
        Me.dtpDateStart.CustomFormat = "ddd MM/dd/yyyy"
        Me.dtpDateStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpDateStart.Location = New System.Drawing.Point(7, 17)
        Me.dtpDateStart.Name = "dtpDateStart"
        Me.dtpDateStart.Size = New System.Drawing.Size(127, 23)
        Me.dtpDateStart.TabIndex = 8
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'DDT_DateRange
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.Transparent
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "DDT_DateRange"
        Me.Size = New System.Drawing.Size(286, 68)
        Me.cmsCopyDate.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
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
