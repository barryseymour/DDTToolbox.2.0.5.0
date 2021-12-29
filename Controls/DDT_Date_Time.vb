Imports System.ComponentModel

Public Class DDT_Date_Time
    Inherits DDT_BaseControl

    Public ShouldLabelBeOn As Boolean = True
    Private IsKeysPressed As Boolean = False
    Friend WithEvents grpDateTime As System.Windows.Forms.GroupBox
    Friend WithEvents lblDateTime As System.Windows.Forms.Label
    Public WithEvents dtpTime As System.Windows.Forms.DateTimePicker
    Public WithEvents dtpDate As System.Windows.Forms.DateTimePicker

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
    End Sub

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    Public Sub New(ByVal ReportControlID As Integer, ByVal ReportID As Integer, ByVal Location_X As Integer, ByVal Location_Y As Integer, _
            ByVal ControlWidth As Integer, ByVal ControlHeight As Integer, _
            ByVal ControlName As String, ByVal ControlID As Integer, ByVal Title As String, _
            ByVal IndexOrder As Integer, _
            ByVal IsLabelOn As Boolean, ByVal Label As String, _
            ByVal FormatType As DateTimePickerFormat, ByVal CustomFormat As String)

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
        lblDateTime.Text = Label
        Me.Name = ControlName
        Me.ControlID = ControlID
        ControlTitle = Title
        Me.IndexOrder = IndexOrder
        dtpDate.Value = StartDate
        dtpTime.Value = TimeOfDay.ToLocalTime
        dtpDate.Format = FormatType
        If FormatType = DateTimePickerFormat.Custom Then
            dtpDate.CustomFormat = CustomFormat
        End If
    End Sub

    Public Sub New(ByVal ReportControlID As Integer, ByVal ReportID As Integer, ByVal Location_X As Integer, ByVal Location_Y As Integer, _
            ByVal ControlWidth As Integer, ByVal ControlHeight As Integer, ByVal ControlName As String, ByVal ControlID As Integer, _
            ByVal Title As String, ByVal IndexOrder As Integer, ByVal IsLabelOn As Boolean, ByVal Label As String, ByVal MaxDaysSpan As Integer, _
            ByVal DefaultStartDate As DateTime, ByVal DefaultEndDate As DateTime, ByVal MinDate As DateTime, ByVal MaxDate As DateTime, _
            Optional ByVal Tag As String = "", Optional ByVal TextAlign As String = "", Optional ByVal FontName As String = "", _
            Optional ByVal FontSize As Integer = 8, Optional ByVal FontBold As Boolean = False, Optional ByVal FontItalic As Boolean = False, _
            Optional ByVal FontUnderline As Boolean = False, Optional ByVal FontColor As String = "", Optional ByVal BackColor As String = "", _
            Optional ByVal ForeColor As String = "")

        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        Dim fontStyle As FontStyle = Drawing.FontStyle.Regular
        Dim CurrTime As DateTime = Format(TimeOfDay, "HH:00 tt")
        'Add any initialization after the InitializeComponent() call
        Me.ReportControlID = ReportControlID
        Me.ReportID = ReportID
        Me.Location = New Point(Location_X, Location_Y)
        If ControlWidth > 0 Then Me.Width = ControlWidth
        If ControlHeight > 0 Then Me.Height = ControlHeight
        ShouldLabelBeOn = IsLabelOn
        lblDateTime.Text = Label
        Me.Name = ControlName
        Me.ControlID = ControlID
        ControlTitle = Title
        Me.IndexOrder = IndexOrder
        dtpDate.MinDate = MinDate
        dtpDate.MaxDate = MaxDate
        dtpDate.Value = StartDate
        dtpDate.Format = DateTimePickerFormat.Short
        dtpTime.Value = CDate(StartDate + " " + CurrTime)
        dtpTime.Format = DateTimePickerFormat.Custom
        dtpTime.CustomFormat = "HH:mm tt"
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
        lblDateTime.ForeColor = IIf(FontColor = "", Color.Black, Color.FromName(FontColor))
    End Sub

    Public Sub New(ByVal ReportControlID As Integer, ByVal ReportID As Integer, ByVal Location_X As Integer, ByVal Location_Y As Integer, _
            ByVal ControlWidth As Integer, ByVal ControlHeight As Integer, _
            ByVal ControlName As String, ByVal ControlID As Integer, ByVal Title As String, _
            ByVal IndexOrder As Integer, _
            ByVal IsLabelOn As Boolean, ByVal Label As String, _
            ByVal FormatType As DateTimePickerFormat, ByVal CustomFormat As String, _
            ByVal DefaultStartDate As DateTime)

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
        'If IsLabelOn = False Then C1Sizer1.Grid.Rows.Item(1).Size = 0 'Turn off the label

        lblDateTime.Text = Label
        Me.Name = ControlName
        Me.ControlID = ControlID
        ControlTitle = Title
        Me.IndexOrder = IndexOrder
        dtpTime.Value = TimeOfDay.ToLocalTime
        dtpDate.Value = StartDate
        dtpDate.Format = FormatType
        If FormatType = DateTimePickerFormat.Custom Then
            dtpDate.CustomFormat = CustomFormat
        End If
    End Sub

    'UserControl overrides dispose to clean up the component list.
    'Protected Overrides Sub Dispose(ByVal disposing As Boolean)
    '    Try
    '        If disposing AndAlso components IsNot Nothing Then
    '            components.Dispose()
    '        End If
    '    Finally
    '        MyBase.Dispose(disposing)
    '    End Try
    'End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.grpDateTime = New System.Windows.Forms.GroupBox()
        Me.lblDateTime = New System.Windows.Forms.Label()
        Me.dtpTime = New System.Windows.Forms.DateTimePicker()
        Me.dtpDate = New System.Windows.Forms.DateTimePicker()
        Me.grpDateTime.SuspendLayout()
        Me.SuspendLayout()
        '
        'grpDateTime
        '
        Me.grpDateTime.Controls.Add(Me.lblDateTime)
        Me.grpDateTime.Controls.Add(Me.dtpTime)
        Me.grpDateTime.Controls.Add(Me.dtpDate)
        Me.grpDateTime.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grpDateTime.Location = New System.Drawing.Point(0, 0)
        Me.grpDateTime.Name = "grpDateTime"
        Me.grpDateTime.Size = New System.Drawing.Size(245, 72)
        Me.grpDateTime.TabIndex = 0
        Me.grpDateTime.TabStop = False
        Me.grpDateTime.Text = "Date / Time"
        '
        'lblDateTime
        '
        Me.lblDateTime.AutoSize = True
        Me.lblDateTime.Location = New System.Drawing.Point(17, 48)
        Me.lblDateTime.Name = "lblDateTime"
        Me.lblDateTime.Size = New System.Drawing.Size(98, 15)
        Me.lblDateTime.TabIndex = 2
        Me.lblDateTime.Text = "Custom Message"
        '
        'dtpTime
        '
        Me.dtpTime.CustomFormat = "HH:00 tt"
        Me.dtpTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpTime.Location = New System.Drawing.Point(145, 19)
        Me.dtpTime.Name = "dtpTime"
        Me.dtpTime.ShowUpDown = True
        Me.dtpTime.Size = New System.Drawing.Size(86, 23)
        Me.dtpTime.TabIndex = 1
        '
        'dtpDate
        '
        Me.dtpDate.CustomFormat = "ddd MM/dd/yyyy"
        Me.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpDate.Location = New System.Drawing.Point(20, 19)
        Me.dtpDate.Name = "dtpDate"
        Me.dtpDate.Size = New System.Drawing.Size(119, 23)
        Me.dtpDate.TabIndex = 0
        '
        'DDT_Date_Time
        '
        Me.BackColor = System.Drawing.Color.Transparent
        Me.Controls.Add(Me.grpDateTime)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "DDT_Date_Time"
        Me.Size = New System.Drawing.Size(245, 72)
        Me.grpDateTime.ResumeLayout(False)
        Me.grpDateTime.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

#End Region

    <Browsable(True), Category("Appearance"), DefaultValue(False), Description("Title of the control, which is the group box title.")> _
    Public Property ControlTitle() As String
        Get
            Return grpDateTime.Text
        End Get
        Set(ByVal Value As String)
            grpDateTime.Text = Value
        End Set
    End Property

End Class
