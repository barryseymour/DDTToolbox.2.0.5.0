Public Class frmVersionNotes

    Private Sub frmVersionNotes_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        gVersionNotesWindowsVisible = True
    End Sub

    Private Sub frmVersionNotes_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        gVersionNotesWindowsVisible = False
    End Sub

    Private Sub frmVersionNotes_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            rtbVersionNotes.LoadFile(VersionNotesFile)
        Catch ex As System.Exception
            DisplayUnexpectedGeneralError(ex)
        End Try
    End Sub
End Class