Public Class DDT_CheckBox_TextBox_Label
    Inherits DDT_CheckBox_TextBox

#Region " Windows Form Designer generated code "

    ''''''''''''''''''''' START CUSTOM CONSTRUCTORS '''''''''''''''''''''''''
    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Create a new constructor, which will set the values for the text property of the checkbox and the textbox
    Public Sub New(ByVal TagValue As String, ByVal Label_TextValue As String)

        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        Tag = TagValue
        Label1.Text = Label_TextValue
    End Sub
    'Create a new constructor, which will set the values for the text property of the checkbox and the textbox
    Public Sub New(ByVal TagValue As String, ByVal TextBox_TextValue As String, _
    ByVal Label_TextValue As String)

        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'set the property values
        Tag = TagValue
        DartTextBox1.Text = TextBox_TextValue
        Label1.Text = Label_TextValue
    End Sub
    'Create a new constructor, which will set the values for the text property of the checkbox and the textbox
    Public Sub New(ByVal TagValue As String, ByVal TextBox_TextValue As String, _
    ByVal Label_TextValue As String, ByVal WidthValue As Integer)

        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'set the property values
        Tag = TagValue
        DartTextBox1.Text = TextBox_TextValue
        Label1.Text = Label_TextValue
        Width = WidthValue
    End Sub


    'Create a new constructor, which will set the values for the text property of the checkbox and the textbox
    Public Sub New(ByVal TagValue As String, ByVal CheckBox_TextValue As String, _
        ByVal TextBox_TextValue As String, ByVal CheckBox_WidthValue As Integer, _
        ByVal TextBox_WidthValue As Integer, ByVal Label_TextValue As String)

        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'set the property values
        Tag = TagValue
        CheckBox1.Text = CheckBox_TextValue
        DartTextBox1.Text = TextBox_TextValue
        CheckBox1.Width = CheckBox_WidthValue
        DartTextBox1.Width = TextBox_WidthValue
        Label1.Text = Label_TextValue
    End Sub

    '''''''''''''''''' END CUSTOM CONSTRUCTORS '''''''''''''''''''''''''

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Public WithEvents Label1 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'CheckBox1
        '
        Me.CheckBox1.Location = New System.Drawing.Point(8, 1)
        Me.CheckBox1.Size = New System.Drawing.Size(16, 22)
        Me.CheckBox1.Text = ""
        '
        'DartTextBox1
        '
        Me.DartTextBox1.Location = New System.Drawing.Point(32, 1)
        Me.DartTextBox1.Size = New System.Drawing.Size(35, 23)
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(75, 1)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 15)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Label1"
        '
        'DDT_CheckBox_TextBox_Label
        '
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "DDT_CheckBox_TextBox_Label"
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.CheckBox1, 0)
        Me.Controls.SetChildIndex(Me.DartTextBox1, 0)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
#End Region

End Class
