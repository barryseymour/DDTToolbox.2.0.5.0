Imports System.ComponentModel

Public Class DDT_CheckBox_TextBox
    Inherits DDT_BaseControl

    Private _IsAddMode As Boolean = True

    <Browsable(True), Category("Controls"), DefaultValue(False), Description("Used to indicate if the form is in ADD mode.")> _
    Public Property IsAddMode() As Boolean
        Get
            Return _IsAddMode
        End Get
        Set(ByVal Value As Boolean)

            'change the title of form
            If (Value) Then
                Text = "Add a New Company"
            Else
                Text = "Edit Company"
            End If

            _IsAddMode = Value
        End Set
    End Property

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Create a new constructor, which will set the values for the text property of the checkbox and the textbox
    Public Sub New(ByVal TagValue As String, ByVal CheckBox_TextValue As String, _
    ByVal TextBox_TextValue As String)

        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'set the property values
        Tag = TagValue
        CheckBox1.Text = CheckBox_TextValue
        DartTextBox1.Text = TextBox_TextValue
    End Sub

    'Create a new constructor, which will set the values for the text property of the checkbox and the textbox
    Public Sub New(ByVal TagValue As String, ByVal CheckBox_TextValue As String, _
        ByVal TextBox_TextValue As String, ByVal CheckBox_WidthValue As Integer, _
        ByVal TextBox_WidthValue As Integer)

        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'set the property values
        Tag = TagValue
        CheckBox1.Text = CheckBox_TextValue
        DartTextBox1.Text = TextBox_TextValue
        CheckBox1.Width = CheckBox_WidthValue
        DartTextBox1.Width = TextBox_WidthValue
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Public WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Public WithEvents DartTextBox1 As DDT_TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.DartTextBox1 = New DDTToolbox.DDT_TextBox()
        Me.SuspendLayout()
        '
        'CheckBox1
        '
        Me.CheckBox1.Location = New System.Drawing.Point(4, 2)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(100, 22)
        Me.CheckBox1.TabIndex = 0
        Me.CheckBox1.Text = "CheckBox1"
        '
        'DartTextBox1
        '
        Me.DartTextBox1.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.DartTextBox1.Enabled = False
        Me.DartTextBox1.Location = New System.Drawing.Point(113, 2)
        Me.DartTextBox1.Name = "DartTextBox1"
        Me.DartTextBox1.Size = New System.Drawing.Size(100, 23)
        Me.DartTextBox1.TabIndex = 2
        '
        'DDT_CheckBox_TextBox
        '
        Me.Controls.Add(Me.DartTextBox1)
        Me.Controls.Add(Me.CheckBox1)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "DDT_CheckBox_TextBox"
        Me.Size = New System.Drawing.Size(216, 24)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

End Class
