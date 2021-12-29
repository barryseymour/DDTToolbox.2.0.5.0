<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmVersionNotes
    Inherits System.Windows.Forms.Form

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmVersionNotes))
        Me.rtbVersionNotes = New System.Windows.Forms.RichTextBox()
        Me.SuspendLayout()
        '
        'rtbVersionNotes
        '
        Me.rtbVersionNotes.BackColor = System.Drawing.Color.White
        Me.rtbVersionNotes.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.rtbVersionNotes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rtbVersionNotes.Location = New System.Drawing.Point(0, 0)
        Me.rtbVersionNotes.Name = "rtbVersionNotes"
        Me.rtbVersionNotes.ReadOnly = True
        Me.rtbVersionNotes.Size = New System.Drawing.Size(540, 497)
        Me.rtbVersionNotes.TabIndex = 0
        Me.rtbVersionNotes.Text = ""
        '
        'frmVersionNotes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(540, 497)
        Me.Controls.Add(Me.rtbVersionNotes)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmVersionNotes"
        Me.Text = "Version Notes"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents rtbVersionNotes As System.Windows.Forms.RichTextBox
End Class
