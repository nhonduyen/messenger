Public Class frmConnect
    Private xml As New cMgrXml
    Private client As New cUdpClient
    Dim nDisplay As Integer = 0

    Private Sub btnConnect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConnect.Click
        If cbxConnectingIp.Text.Trim = "" Then
            MessageBox.Show("Please put in an IP to connect!")
            Return
        End If
        lblConnecting.Text = "Connecting ."
        Dim message As String = MgrMesSend(MES_CONNECT)
        client.Connect(cbxConnectingIp.Text.Trim, message)
        tmrConnect.Start()
        lblConnecting.Visible = True
    End Sub


    Private Sub cbxConnectingIp_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbxConnectingIp.TextChanged
        xml.ReadYourContact(FILE_SETTING, cbxConnectingIp, tbxNickName)
    End Sub

    Private Sub frmConnect_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim a As Integer
        Dim b As Integer
        a = frmMain.Location.X - 341
        b = frmMain.Location.Y
        Me.Location = New Point(a, b)

        xml.ReadYourContact(FILE_SETTING, cbxConnectingIp)
        lblConnecting.Text = "Connecting ."
    End Sub

    Private Sub tmrConnect_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrConnect.Tick
        If nDisplay <> 8 Then
            lblConnecting.Text = lblConnecting.Text + "."
            nDisplay = nDisplay + 1
        Else
            nDisplay = 0
            tmrConnect.Stop()
            MessageBox.Show("Can not connect to " + cbxConnectingIp.Text, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Close()
        End If

    End Sub

    Public Sub CloseForm()
        tmrConnect.Stop()
        Me.Close()
    End Sub

    Private Sub frmConnect_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        tmrConnect.Stop()
    End Sub

    Private Sub cbxConnectingIp_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cbxConnectingIp.KeyUp
        If (e.KeyCode = Keys.Enter) Then
            If cbxConnectingIp.Text.Trim = "" Then
                MessageBox.Show("Please put in an IP to connect!")
                Return
            End If
            Dim message As String = MgrMesSend(MES_CONNECT)
            client.Connect(cbxConnectingIp.Text.Trim, message)
            tmrConnect.Start()
            lblConnecting.Visible = True
        End If
    End Sub
End Class