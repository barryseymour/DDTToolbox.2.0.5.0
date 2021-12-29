Imports System
Imports System.ComponentModel
Imports System.Windows.Forms

''' <summary>
''' ExtPanel gives extended functionality to the Panel class
''' </summary>
''' <remarks>Written by MSG</remarks>
Public Class ExtPanel
    Inherits Panel

    Private dragging As Boolean = False
    Private OffsetX As Integer
    Private OffsetY As Integer

    Private DragValidateOK As Boolean = False

    Public Sub New()
        '_AllowDragKey = New KeyChars
    End Sub

    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
        MyBase.OnPaint(e)

        'Add your custom paint code here
    End Sub

    Public Enum eKeyChars
        none = Keys.None
        Control = Keys.Control
        Shift = Keys.Shift
        Alt = Keys.Alt
        Control_Shift = Keys.Control + Keys.Shift
        Control_Shift_Alt = Keys.Control + Keys.Shift + Keys.Alt
        Control_Alt = Keys.Control + Keys.Alt
        Shift_Alt = Keys.Shift + Keys.Alt
    End Enum

#Region "Class Properties"
    Private _MouseOverFontOLD As Font
    Private _MouseOverFont As Font
    <Description("MouseOver Font"), Category("MouseOver")> _
    Property MouseOverFont() As Font
        Get
            Return _MouseOverFont
        End Get
        Set(ByVal value As Font)
            _MouseOverFont = value
        End Set
    End Property

    Private _MouseOverBackColorOLD As Color
    Private _MouseOverBackColor As Color
    <Description("MouseOver BackColor"), Category("MouseOver")> _
    Property MouseOverBackColor() As Color
        Get
            Return _MouseOverBackColor
        End Get
        Set(ByVal value As Color)
            _MouseOverBackColor = value
        End Set
    End Property

    Private _MouseOverForeColorOLD As Color
    Private _MouseOverForeColor As Color
    <Description("MouseOver ForeColor"), Category("MouseOver")> _
        Property MouseOverForeColor() As Color
        Get
            Return _MouseOverForeColor
        End Get
        Set(ByVal value As Color)
            _MouseOverForeColor = value
        End Set
    End Property

    Private _AllowDrag As Boolean
    Property AllowDrag() As Boolean
        Get
            Return _AllowDrag
        End Get
        Set(ByVal value As Boolean)
            _AllowDrag = value
        End Set
    End Property

    Private _AllowDragKey As eKeyChars
    Public Property AllowDragKey() As eKeyChars
        Get
            Return _AllowDragKey
        End Get
        Set(ByVal value As eKeyChars)
            _AllowDragKey = value
        End Set
    End Property

#End Region

#Region "Class MOUSE Subroutines"
    Private Sub PanelMouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.MouseEnter
        If _MouseOverBackColor.Name <> "0" Then
            _MouseOverBackColorOLD = Me.BackColor
            Me.BackColor = _MouseOverBackColor
        End If

        If _MouseOverForeColor.Name <> "0" Then
            _MouseOverForeColorOLD = Me.ForeColor
            Me.ForeColor = _MouseOverForeColor
        End If

        If _MouseOverFont IsNot Nothing Then
            _MouseOverFontOLD = Me.Font
            Me.Font = MouseOverFont
        End If
    End Sub

    Private Sub PanelMouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.MouseLeave
        If _MouseOverBackColor.Name <> "0" Then
            Me.BackColor = _MouseOverBackColorOLD
        End If

        If _MouseOverForeColor.Name <> "0" Then
            Me.ForeColor = _MouseOverForeColorOLD
        End If

        If _MouseOverFont IsNot Nothing Then
            Me.Font = _MouseOverFontOLD
        End If
    End Sub

    Public Sub PanelMouseDown(ByVal sender As Object, ByVal e As MouseEventArgs) Handles Me.MouseDown
        If _AllowDrag Then
            dragging = True
            OffsetX = e.X
            OffsetY = e.Y
        End If
    End Sub

    Public Sub PanelMouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseUp
        dragging = False
    End Sub

    Public Sub PanelMouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseMove
        If _AllowDrag Then
            If (ModifierKeys = _AllowDragKey And ModifierKeys <> Keys.None) Or _AllowDragKey = eKeyChars.none Then
                If dragging Then
                    sender.Left = e.X + sender.Left - OffsetX
                    sender.Top = e.Y + sender.Top - OffsetY
                End If
            End If
        End If
    End Sub
#End Region
End Class

