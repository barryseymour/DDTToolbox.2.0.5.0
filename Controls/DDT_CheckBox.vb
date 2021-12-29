Imports System.ComponentModel
Imports System.Data.SqlClient

Public Class DDT_CheckBox
    Inherits DDT_BaseControl

    Public WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Public ReportCtrlID As Integer

#Region " Windows Form Designer generated code "
    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    Public Sub New(ByVal checkboxLabel As String, ByVal Location_X As Integer, ByVal Location_Y As Integer, ByVal RptCtrlID As Integer, _
        Optional ByVal chkState As Boolean = False, Optional ByVal checkboxOrientation As Drawing.ContentAlignment = ContentAlignment.MiddleLeft, _
        Optional ByVal anchor As AnchorStyles = AnchorStyles.Left + AnchorStyles.Top, Optional ByVal dock As DockStyle = DockStyle.None)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        Me.ReportControlID = RptCtrlID
        With Me.CheckBox1
            .Text = checkboxLabel
            .Checked = chkState
            .CheckAlign = checkboxOrientation '16 for left, 64 for right
            Me.Left = Location_X
            Me.Top = Location_Y
            Me.Anchor = anchor
            Me.Dock = dock
        End With
    End Sub

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.SuspendLayout()
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.BackColor = System.Drawing.Color.Transparent
        Me.CheckBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CheckBox1.Location = New System.Drawing.Point(0, 0)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(98, 32)
        Me.CheckBox1.TabIndex = 0
        Me.CheckBox1.Text = "CheckBox1"
        Me.CheckBox1.UseVisualStyleBackColor = False
        '
        'DDT_CheckBox
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoSize = True
        Me.Controls.Add(Me.CheckBox1)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "DDT_CheckBox"
        Me.Size = New System.Drawing.Size(98, 32)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

End Class
