Public Class frmOptions

    Private Sub frmOptions_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim i As Integer
        cboDefaultConnection.Items.Clear()

        For i = 0 To ServerList.GetUpperBound(0)
            If ServerList(i) <> "" Then
                cboDefaultConnection.Items.Add(ServerList(i))
            End If
        Next

        With UserSettings
            chkAutoCenterMainWindow.Checked = .MainWindowAutoCenter

            If .DefaultConnectionType = 1 Then
                rdoUseLastConnection.Checked = 1
                cboDefaultConnection.Visible = False
            Else
                rdoUseDefaultConnection.Checked = 1
                cboDefaultConnection.Visible = True
            End If

            If cboDefaultConnection.Items.Count > 0 Then
                rdoUseDefaultConnection.Enabled = True
                lblNoConnectionsDefined.Enabled = False
                lblNoConnectionsDefined.Visible = False
                If UserSettings.DefaultConnectionType = 2 Then
                    i = 0
                    Dim found As Boolean = False
                    While i <= cboDefaultConnection.Items.Count - 1
                        If cboDefaultConnection.Items(i) = .DefaultConnectionName Then
                            found = True
                            cboDefaultConnection.SelectedIndex = i
                        End If
                        i += 1
                    End While
                Else
                    cboDefaultConnection.SelectedIndex = 0
                End If
            Else
                rdoUseDefaultConnection.Enabled = False
                lblNoConnectionsDefined.Enabled = False
                lblNoConnectionsDefined.Visible = True
            End If
        End With
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        With UserSettings
            If rdoUseLastConnection.Checked Then
                .DefaultConnectionType = 1
                .DefaultConnectionName = ""
            Else
                .DefaultConnectionType = 2
                If cboDefaultConnection.Items.Count > 0 Then
                    .DefaultConnectionName = cboDefaultConnection.Items(cboDefaultConnection.SelectedIndex)
                Else
                    .DefaultConnectionName = ""
                End If
            End If
            .MainWindowAutoCenter = chkAutoCenterMainWindow.Checked
        End With
        Me.Close()
    End Sub

    Private Sub rdoUseLastConnection_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoUseLastConnection.CheckedChanged
        cboDefaultConnection.Visible = rdoUseDefaultConnection.Checked
    End Sub
End Class