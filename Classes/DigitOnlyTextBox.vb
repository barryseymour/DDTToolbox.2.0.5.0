Public Class DigitOnlyTextBox
    Inherits ExtTextBox

    ' Restricts the entry of characters to digits (including hex),
    ' the negative sign, the e decimal point, and editing keystrokes (backspace).
    Protected Overrides Sub OnKeyPress(ByVal e As KeyPressEventArgs)
        MyBase.OnKeyPress(e)

        If [Char].IsDigit(e.KeyChar) Then
            ' Digits are OK
        ElseIf e.KeyChar = vbBack Then
            ' Backspace key is OK
        Else
            ' Swallow this invalid key and beep
            e.Handled = True
            Beep()
        End If
    End Sub
End Class
