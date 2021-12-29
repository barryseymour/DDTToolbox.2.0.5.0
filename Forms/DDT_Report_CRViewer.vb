'Public Class frmReportViewer
'    Inherits System.Windows.Forms.Form

'    Private OpenedCrystalReportsList As ArrayList

'#Region " Windows Form Designer generated code "

'    Public Sub New()
'        MyBase.New()

'        'This call is required by the Windows Form Designer.
'        InitializeComponent()

'        'Add any initialization after the InitializeComponent() call

'    End Sub

'    Public Sub New(ByVal CrystalReportsList As ArrayList)
'        MyBase.New()

'        'This call is required by the Windows Form Designer.
'        InitializeComponent()

'        'Add any initialization after the InitializeComponent() call
'        OpenedCrystalReportsList = CrystalReportsList
'    End Sub

'    'Form overrides dispose to clean up the component list.
'    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
'        If disposing Then
'            If Not (components Is Nothing) Then
'                components.Dispose()
'            End If
'        End If
'        MyBase.Dispose(disposing)
'    End Sub

'    'Required by the Windows Form Designer
'    Private components As System.ComponentModel.IContainer

'    'NOTE: The following procedure is required by the Windows Form Designer
'    'It can be modified using the Windows Form Designer.  
'    'Do not modify it using the code editor.
'    Public WithEvents CrystalReportViewer1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
'    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
'        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmReportViewer))
'        Me.CrystalReportViewer1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer
'        Me.SuspendLayout()
'        '
'        'CrystalReportViewer1
'        '
'        Me.CrystalReportViewer1.ActiveViewIndex = -1
'        Me.CrystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
'        'Me.CrystalReportViewer1.DisplayGroupTree = False
'        Me.CrystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
'        Me.CrystalReportViewer1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
'        Me.CrystalReportViewer1.Location = New System.Drawing.Point(0, 0)
'        Me.CrystalReportViewer1.Name = "CrystalReportViewer1"
'        Me.CrystalReportViewer1.Size = New System.Drawing.Size(813, 606)
'        Me.CrystalReportViewer1.TabIndex = 0

'        '
'        'frmReportViewer
'        '
'        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
'        Me.ClientSize = New System.Drawing.Size(813, 606)
'        Me.Controls.Add(Me.CrystalReportViewer1)
'        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
'        Me.Name = "frmReportViewer"
'        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
'        Me.Text = "Crystal Reports Viewer"
'        Me.ResumeLayout(False)

'    End Sub

'#End Region

'    Private Sub frmReportViewer_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
'        'Remove this report from the global report list.
'        'This list is referenced when creating the report -> "ViewReport_Crystal"
'        Dim currentReport As frmReportViewer = CType(sender, frmReportViewer)

'        OpenedCrystalReportsList.Remove(currentReport)
'    End Sub
'End Class
