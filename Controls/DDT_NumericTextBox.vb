Public Class DDT_NumericTextBox
    Inherits DDT_BaseControl

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    Public Sub New(ByVal lblString As String)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        Me.lblNumeric.Text = lblString
    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    Public WithEvents txtNumeric As System.Windows.Forms.TextBox
    Public WithEvents lblNumeric As System.Windows.Forms.Label

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.txtNumeric = New System.Windows.Forms.TextBox()
        Me.lblNumeric = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'txtNumeric
        '
        Me.txtNumeric.Location = New System.Drawing.Point(47, 5)
        Me.txtNumeric.Name = "txtNumeric"
        Me.txtNumeric.Size = New System.Drawing.Size(94, 23)
        Me.txtNumeric.TabIndex = 5
        '
        'lblNumeric
        '
        Me.lblNumeric.AutoSize = True
        Me.lblNumeric.Location = New System.Drawing.Point(8, 8)
        Me.lblNumeric.Name = "lblNumeric"
        Me.lblNumeric.Size = New System.Drawing.Size(35, 15)
        Me.lblNumeric.TabIndex = 6
        Me.lblNumeric.Text = "Label"
        '
        'DDT_NumericTextBox
        '
        Me.Controls.Add(Me.lblNumeric)
        Me.Controls.Add(Me.txtNumeric)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "DDT_NumericTextBox"
        Me.Size = New System.Drawing.Size(149, 31)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
#End Region

End Class
