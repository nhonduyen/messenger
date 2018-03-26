Public Class frmDisplayImage
    Public imagePath As String
    Public ipSend As String
    Public nameSend As String
    Dim bm As Bitmap
    Private Sub frmDisplayImage_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            'load the picture into a bitmap.
            bm = New Bitmap(imagePath)
            ' display the results.
            ptbImage.Image = bm
            'ptbImage.SizeMode = PictureBoxSizeMode.AutoSize
        Catch ex As Exception
            MessageBox.Show("Have Problem When Take Picture!.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            'Me.Close()
        End Try

    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        bm.Dispose()
        Me.Close()
    End Sub

    Private Sub btnSend_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSend.Click
        bm.Dispose()
        czBuffSend = ""
        Dim fileDetail As IO.FileInfo
        Dim port As Integer
        Dim fileLength As Long

        fileDetail = My.Computer.FileSystem.GetFileInfo(imagePath)
        fileLength = fileDetail.Length
        port = OpenPort(listPort).ToString

        czBuffSend = fileDetail.Name + "|" + fileLength.ToString + "|" + port.ToString

        Dim frmSend As New frmSend
        frmSend.ip = ipSend
        frmSend.pcSend = nameSend
        frmSend.port = port
        frmSend.fileToSend = imagePath
        frmSend.Show()
        dFrmSendFile.Add(port.ToString, frmSend)
        cUdpServer.ReplyNonBroadcast(ipSend, MES_SEND_FILE)     '/////
        czBuffSend = ""

        'ptbImage.Image = Nothing

        Me.Close()
    End Sub
End Class