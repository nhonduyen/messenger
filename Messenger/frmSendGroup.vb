Public Class frmSendGroup

    Public group As String
    Private xml As New cMgrXml
    Private listIp As New List(Of String)

    Private Sub frmSendGroup_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lblSenTo.Text = "Send To Group : " + group
        xml.ReadYourContact(FILE_CONTACTS, listIp, group)
    End Sub


    Private Sub btnSend_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSend.Click
        czBuffSend = rtbContent.Rtf
        For Each tempIp As String In listIp
            cUdpServer.ReplyNonBroadcast(tempIp, MES_MESSENGE)      '/////
        Next

        Me.Close()
    End Sub

    Private Sub frmSendGroup_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        listSendGroup.Remove(group.Trim)
    End Sub

    Private Sub rtbContent_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles rtbContent.KeyDown
        If rtbContent.Text.Trim = "" Then
            Return
        End If
        If e.KeyCode = Keys.Enter Then
            czBuffSend = rtbContent.Rtf
            For Each tempIp As String In listIp
                cUdpServer.ReplyNonBroadcast(tempIp, MES_MESSENGE)
            Next
        End If

    End Sub
End Class