Imports System.ComponentModel

Public Class DDT_Label_TextBox_Label
    Inherits DDTToolbox.DDT_BaseControl

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        InitializeComponent()
    End Sub

    'Create a new constructor, which will set the values for the text property of the checkbox and the textbox
    Public Sub New(ByVal label1Visible As Boolean, ByVal label2Visible As Boolean, ByVal label1Text As String, _
        ByVal label2Text As String, ByVal InitialValue As String, ByVal textBox1Width As Integer, _
        ByVal textBox1X As Integer, ByVal controlX As Integer, ByVal controlY As Integer, _
        ByVal ControlWidth As Integer, ByVal ControlHeight As Integer, ByVal FormatType As String, _
        ByVal CtrlTitle As String, ByVal ReportCtrlID As Integer)

        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'set the property values
        With Me
            With .Label1
                .Text = label1Text
                .Visible = label1Visible
                .Left = IIf(textBox1Width > 0, textBox1X - (Label1.Width + 6), 11)
            End With
            With .Label2
                .Text = label2Text
                .Visible = label2Visible
                .Left = textBox1X + textBox1Width + 6
            End With
            With .TextBox1
                .Visible = (textBox1Width > 0)
                .Text = InitialValue
                .Width = textBox1Width
                .Mask = FormatType
                .Left = textBox1X
            End With
            .Size = New Size(ControlWidth, IIf(ControlHeight = 0, .Height, ControlHeight))
            .Location = New Point(controlX, controlY)
            .ReportControlID = ReportCtrlID
            ControlTitle = CtrlTitle
        End With
    End Sub

    'UserControl overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Public WithEvents Label1 As System.Windows.Forms.Label
    Public WithEvents Label2 As System.Windows.Forms.Label
    Public WithEvents TextBox1 As System.Windows.Forms.MaskedTextBox

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.TextBox1 = New System.Windows.Forms.MaskedTextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.TextBox1)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(262, 30)
        Me.Panel1.TabIndex = 0
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(95, 6)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(62, 23)
        Me.TextBox1.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(170, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(83, 15)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Text for Label2"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(11, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(83, 15)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Text for Label1"
        '
        'DDT_Label_TextBox_Label
        '
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "DDT_Label_TextBox_Label"
        Me.Size = New System.Drawing.Size(262, 30)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private _CtrlTitle As String
    Private _RptControlID As Integer

    Public Property ControlTitle() As String
        Get
            Return _CtrlTitle
        End Get
        Set(ByVal value As String)
            _CtrlTitle = value
        End Set
    End Property

    Public Property RptControlID() As Integer
        Get
            Return _RptControlID
        End Get
        Set(ByVal value As Integer)
            _RptControlID = value
        End Set
    End Property

End Class
