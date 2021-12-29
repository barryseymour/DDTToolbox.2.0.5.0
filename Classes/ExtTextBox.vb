Public Class ExtTextBox
    Inherits System.Windows.Forms.TextBox

    Private Sub ExtTextBox_Focus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.GotFocus
        Me.SelectAll()
    End Sub

End Class
