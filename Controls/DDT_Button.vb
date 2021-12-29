Imports System.ComponentModel

Public Class DDT_Button
    Inherits Button

    Private mOldBackColor As Color      ' original button color
    Private mMO_BackColor As Color      ' MouseOver color
    Private mOldForeColor As Color      ' original button forecolor
    Private mMO_ForeColor As Color      ' MouseOver ForeColor
    Private mOldCursor As Cursor        ' original button cursor
    Private mMO_Cursor As Cursor        ' MouseOver Cursor
    Private mOldImage As Image          ' original button image
    Private mMO_Image As Image          ' MouseOver Image
    Private mOldFont As Font            ' original font
    Private mMO_Font As Font            ' MouseOver Font
    Private mOldText As String          ' original text
    Private mMO_Text As String          ' MouseOver Text

#Region "Necessary Designer Stuff"
    'Required by the Control Designer
    Private components As System.ComponentModel.IContainer

    ' NOTE: The following procedure is required by the Component Designer
    ' It can be modified using the Component Designer.  Do not modify it
    ' using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        components = New System.ComponentModel.Container()
    End Sub

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        MyBase.BackColor = Color.WhiteSmoke
        Me.MouseOverBackColor = MyBase.BackColor
    End Sub

    'Control overrides dispose to clean up the component list.
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
#End Region

    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
        MyBase.OnPaint(e)

        'Add your custom paint code here
    End Sub
    <Browsable(True), Category("Appearance"), DefaultValue(""), Description("Change Button TEXT on the MouseOver Event.")> _
    Property MouseOverText() As String
        Get
            MouseOverText = mMO_Text
        End Get
        Set(ByVal value As String)
            mMO_Text = value
        End Set
    End Property

    <Browsable(True), Category("Appearance"), Description("Change Button FONT on the MouseOver Event.")> _
    Property MouseOverFont() As Font
        Get
            MouseOverFont = mMO_Font
        End Get
        Set(ByVal value As Font)
            mMO_Font = value
        End Set
    End Property

    <Browsable(True), Category("Appearance"), Description("Change Button BackColor on the MouseOver Event.  Also, set specifically BackColor.  The default does not show at startup.  Looks like a Visual Studio Bug.")> _
    Property MouseOverBackColor() As Color
        Get
            MouseOverBackColor = mMO_BackColor
        End Get
        Set(ByVal Value As Color)
            mMO_BackColor = Value
        End Set
    End Property

    <Browsable(True), Category("Appearance"), Description("Change Button ForeColor on the MouseOver Event.")> _
    Property MouseOverForeColor() As Color
        Get
            MouseOverForeColor = mMO_ForeColor
        End Get
        Set(ByVal Value As Color)
            mMO_ForeColor = Value
        End Set
    End Property

    <Browsable(True), Category("Appearance"), Description("Change Button Cursor on the MouseOver Event.")> _
    Property MouseOverCursor() As Cursor
        Get
            MouseOverCursor = mMO_Cursor
        End Get
        Set(ByVal Value As Cursor)
            mMO_Cursor = Value
        End Set
    End Property

    <Browsable(True), Category("Appearance"), Description("Change Button Image on the MouseOver Event.")> _
    Property MouseOverImage() As Image
        Get
            MouseOverImage = mMO_Image
        End Get
        Set(ByVal value As Image)
            mMO_Image = value
        End Set
    End Property

End Class
