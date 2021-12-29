Public NotInheritable Class frmSplashScreen

    Private Sub frmSplashScreen_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Application title
        ApplicationTitle.Text = AppName
        Version.Text = AppVersion

        'Copyright info
        Copyright.Text = My.Application.Info.Copyright

        gDomainUserID = My.User.Name
        gUserID = Strings.Right(gDomainUserID, gDomainUserID.Length - InStrRev(gDomainUserID, "\"))
        ReadSettingsFromINFFile()
        frmMain.Show()

        Me.Dispose()

    End Sub

End Class
