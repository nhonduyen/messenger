Public Class frmConfirmGroup
    Public ip As String
    Public nick As String
    Public czGroupUser As String
    Public flag As Integer
    Private Sub btnYes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnYes.Click
        flag = 1
        If dFrmChatGroup.ContainsKey("R_" + ip) = True Then

        Else
            Dim frm As New frmChatGroupClient
            If czGroupUser.Trim <> "" Then
                czGroupUser.Remove(czGroupUser.LastIndexOf("|"))
                Dim ips As String() = czGroupUser.Split("|")
                For Each ip_ As String In ips
                    If ip_.Trim <> "" Then
                        frm.listPartner.Add(ip_)
                    End If
                Next

            End If
            frm.listPartner.Add(nick + "<" + ip + ">")
            frm.Text = "R_" + ip
            frm.Show()
            dFrmChatGroup.Add("R_" + ip, frm)


        End If
        Me.Close()
    End Sub

    Private Sub btnNo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNo.Click
        flag = 1
        cUdpServer.SendInvite(ip, MES_INVITE_REP, "N")
        Me.Close()
    End Sub

    Private Sub frmConfirmGroup_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If flag <> 1 Then
            cUdpServer.SendInvite(ip, MES_INVITE_REP, "N")
        End If
    End Sub

End Class