Public Class frmInvite
    Private xml As New cMgrXml
    Public czGroupUserIp As String
    Private Sub btnSend_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSend.Click
        If cbxInviteIp.Text.Trim = "" Then
            MessageBox.Show("Please put in an IP to connect!")
            Return
        End If
        If frmGroupChat.dGroupUsers.ContainsKey(cbxInviteIp.Text.Trim) Then
            MessageBox.Show("This partner is containt on your group chat!")
            Me.Close()
            Return
        End If
        cUdpServer.SendInvite(cbxInviteIp.Text.Trim, MES_INVITE, czGroupUserIp)
        Me.Close()
    End Sub

    Private Sub cbxInviteIp_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbxInviteIp.TextChanged
        xml.ReadYourContact(FILE_SETTING, cbxInviteIp, tbxNickName)
    End Sub

    Private Sub frmInvite_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim a As Integer
        Dim b As Integer
        a = frmMain.Location.X - 385
        b = frmMain.Location.Y
        Me.Location = New Point(a, b)

        xml.ReadYourContact(FILE_SETTING, cbxInviteIp)
    End Sub

    Private Sub cbxInviteIp_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cbxInviteIp.KeyUp
        If (e.KeyCode = Keys.Enter) Then
            If cbxInviteIp.Text.Trim = "" Then
                MessageBox.Show("Please put in an IP to invite!")
                Return
            End If

            'Dim message As String = MgrMesSend(MES_CONNECT)
            'client.Connect(cbxConnectingIp.Text.Trim, message)

        End If
    End Sub
End Class