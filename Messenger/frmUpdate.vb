Public Class frmUpdate
    Private client As New cUdpClient

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

        client.SendData(MgrMesSend(MES_UPDATE_CANCEL))
        Me.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If tbxFilePath.Text.Trim = "" Or tbxVersion.Text.Trim = "" Then
            Return
        End If

        czBuffSend = tbxVersion.Text.Trim
        client.SendData(MgrMesSend(MES_UPDATE))
        Me.Hide()
    End Sub

    Private Sub frmUpdate_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        client.Init()
    End Sub

    Private Sub tbxFilePath_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles tbxFilePath.MouseClick
        tbxFilePath.Text = ""
        ofdFileUpdate.Filter = " All File  |*.*"

        If (ofdFileUpdate.ShowDialog() = Windows.Forms.DialogResult.OK) Then
            tbxFilePath.Text = ofdFileUpdate.FileName
            czPathUpdate = ofdFileUpdate.FileName
        End If

    End Sub

    Private Sub frmUpdate_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        e.Cancel = True
        Me.Hide()
    End Sub
End Class