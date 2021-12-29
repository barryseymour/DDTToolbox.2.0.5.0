Public Class ExtButton
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

    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
        MyBase.OnPaint(e)

        'Add your custom paint code here
    End Sub

    Property MouseOverText() As String
        Get
            MouseOverText = mMO_Text
        End Get
        Set(ByVal value As String)
            mMO_Text = value
        End Set
    End Property

    Property MouseOverFont() As Font
        Get
            MouseOverFont = mMO_Font
        End Get
        Set(ByVal value As Font)
            mMO_Font = value
        End Set
    End Property

    Property MouseOverBackColor() As Color
        Get
            MouseOverBackColor = mMO_BackColor
        End Get
        Set(ByVal Value As Color)
            mMO_BackColor = Value
        End Set
    End Property

    Property MouseOverForeColor() As Color
        Get
            MouseOverForeColor = mMO_ForeColor
        End Get
        Set(ByVal Value As Color)
            mMO_ForeColor = Value
        End Set
    End Property

    Property MouseOverCursor() As Cursor
        Get
            MouseOverCursor = mMO_Cursor
        End Get
        Set(ByVal Value As Cursor)
            mMO_Cursor = Value
        End Set
    End Property

    Property MouseOverImage() As Image
        Get
            MouseOverImage = mMO_Image
        End Get
        Set(ByVal value As Image)
            mMO_Image = value
        End Set
    End Property

    Private Sub XB_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.MouseEnter
        mOldBackColor = MyBase.BackColor
        Me.BackColor = mMO_BackColor

        mOldForeColor = MyBase.ForeColor
        Me.ForeColor = mMO_ForeColor

        mOldCursor = MyBase.Cursor
        Me.Cursor = mMO_Cursor

        mOldImage = MyBase.Image
        Me.Image = mMO_Image

        mOldFont = MyBase.Font
        Me.Font = mMO_Font

        If mMO_Text <> "" Then
            mOldText = Me.Text
            Me.Text = mMO_Text
        End If
    End Sub

    Private Sub XB_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.MouseLeave
        '--- Restore original back color ---
        Me.BackColor = mOldBackColor

        '--- Restore original fore color ---
        Me.ForeColor = mOldForeColor

        '--- Restore original cursor ---
        Me.Cursor = mOldCursor

        '--- Restore original image ---
        Me.Image = mOldImage

        '--- Restore original font ---
        Me.Font = mOldFont

        '--- Restore original font ---
        If mMO_Text <> "" Then
            Me.Text = mOldText
        End If
    End Sub

    '--- Return the rectangle around the button ---
    Public Function GetButtonRect() As Rectangle
        Return New Rectangle(Location:=Me.Location, Size:=Me.Size)
    End Function

    '--- Draw a rectangle around the button ---
    Public Sub DrawButtonRect(ByVal penColor As Color, Optional ByVal penWidth As Integer = 1, Optional ByVal penDashStyle As Drawing2D.DashStyle = Drawing2D.DashStyle.Solid)
        Dim myGraphics As Graphics
        Dim myPen As New Pen(penColor)
        myPen.Width = penWidth
        myPen.DashStyle = penDashStyle

        myGraphics = Graphics.FromHwnd(Me.Parent.Handle)
        myGraphics.DrawRectangle(pen:=myPen, rect:=GetButtonRect())
    End Sub
End Class
