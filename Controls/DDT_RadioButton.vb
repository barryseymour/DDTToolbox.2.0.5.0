Imports System.ComponentModel
Imports System.Data.SqlClient

Public Class DDT_RadioButton
    Inherits DDTToolbox.DDT_BaseControl

#Region " Windows Form Designer generated code "
    Public WithEvents RadioButton As System.Windows.Forms.RadioButton
    Public ParamContainer As Control
    Public ReportCtrlID As Integer
    Private _IsChecked As Boolean = True
    Public TextParam(6) As ArrayList
    Public ValueParam(6) As ArrayList
    Public buttonControls(6) As ArrayList

    Public Property IsChecked() As Boolean
        Get
            Return _IsChecked
        End Get
        Set(ByVal value As Boolean)
            _IsChecked = value
        End Set
    End Property

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    Public Sub New(ByVal TextLabel As String, ByVal chkValue As Boolean, ByVal Location_X As Integer, ByVal Location_Y As Integer, _
        ByVal RptCtrlID As Integer, ByVal CheckAlignment As String, ByVal ParamCtrl As Control)
        MyBase.New()

        ReportCtrlID = RptCtrlID
        _IsChecked = CBool(chkValue)
        'This call is required by the Windows Form Designer.
        InitializeComponent()
        Me.RadioButton.Text = TextLabel
        Me.RadioButton.CheckAlign = IIf(CheckAlignment = "left", 16, 64)
        Me.Location = New Point(Location_X, Location_Y)
        ParamContainer = ParamCtrl
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.RadioButton = New System.Windows.Forms.RadioButton
        Me.SuspendLayout()
        '
        'RadioButton
        '
        Me.RadioButton.AutoSize = True
        Me.RadioButton.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RadioButton.Location = New System.Drawing.Point(0, 0)
        Me.RadioButton.Name = "RadioButton"
        Me.RadioButton.Size = New System.Drawing.Size(92, 22)
        Me.RadioButton.TabIndex = 0
        Me.RadioButton.TabStop = True
        Me.RadioButton.Text = "RadioButton1"
        Me.RadioButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.RadioButton.UseVisualStyleBackColor = True
        Me.RadioButton.Checked = _IsChecked
        '
        'DDT_RadioButton
        '
        Me.Controls.Add(Me.RadioButton)
        Me.Name = "DDT_RadioButton"
        Me.Size = New System.Drawing.Size(92, 22)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
#End Region

End Class
