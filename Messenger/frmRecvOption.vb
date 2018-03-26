Imports System.Threading
Imports System.Net
Imports System.Net.Sockets
Imports System.IO
Imports System.Text
Imports System.Diagnostics

Public Class frmRecvOption

    Public ipSend As String
    Public pcSend As String
    Public czBuffReceive As String
    Public nClose As Integer

    'Private server As New cUdpServer
    Private xml As New cMgrXml

    Private connectDone As New AutoResetEvent(False)
    Private receiveDone As New ManualResetEvent(False)
    Private connected As Boolean = False
    Private _ipAddress As IPAddress
    Private _port As Integer

    Private Delegate Sub Statushandler()
    Private Delegate Sub ProgressChangeHandler()
    Private Delegate Sub FileReceiveDoneHandler()
    Private Delegate Sub ConnectDoneHandler()
    Private Delegate Sub EnableConnectButtonHandler()
    Private Delegate Sub SetProgressLengthHandler(ByVal len As Integer)
    Private mProgress As ProgressBar
    Private nLength As Integer = 0
    Dim progressLen As Integer

    Private fileName As String
    Private m_fileSavePath As String = "C:/"
    Private fileLen As Long
    Dim SavePath As String = ""

    Dim threadClient As Thread

    Private Sub frmRecvOption_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        rtbRep.Visible = False

        czBuffReceive = czBuffRecv
        czBuffRecv = ""
        grbRecvFrom.Text = "Receive From : " + pcSend + " - " + ipSend
        grbRecvComplete.Text = "Receive From : " + pcSend + " - " + ipSend

        _ipAddress = IPAddress.Parse(ipSend)

        'lblFileName.Text = "File Name : " + czBuffReceive.Split("|")(0)
        Try
            lblFileSize.Text = ChangeSizeType(czBuffReceive.Split("|")(1))
            tbxFileName.Text = czBuffReceive.Split("|")(0)


            _port = czBuffReceive.Split("|")(2)


            xml.ReadFilePath(FILE_SETTING, tbxSaveTo)
            tbxSaveTo.Text = tbxSaveTo.Text
            If tbxSaveTo.Text.Trim = "" Or Not Directory.Exists(tbxSaveTo.Text.Trim) Then
                Dim appPath As String = Application.ExecutablePath()
                Dim saveFilePath As String = appPath.Substring(0, 3) + "Message File"
                If (Not Directory.Exists(saveFilePath)) Then
                    Directory.CreateDirectory(saveFilePath)
                End If
                xml.AddSaveFilePath(FILE_SETTING, saveFilePath)
                xml.ReadFilePath(FILE_SETTING, tbxSaveTo)
                tbxSaveTo.Text = tbxSaveTo.Text
                m_fileSavePath = tbxSaveTo.Text.Trim
            Else
                m_fileSavePath = tbxSaveTo.Text.Trim
            End If


            If m_fileSavePath.Substring(m_fileSavePath.LastIndexOf("\")).Trim = "" Then
                m_fileSavePath = m_fileSavePath.Replace("\", "")
            End If
            tbxFileName_.Text = m_fileSavePath + "\" + czBuffReceive.Split("|")(0)
            m_fileSavePath = m_fileSavePath
            lblFileSize_.Text = "File Size : " + ChangeSizeType(czBuffReceive.Split("|")(1))
        Catch ex As Exception

        End Try

        Try
            Dim type As String = tbxFileName_.Text.Substring(tbxFileName_.Text.LastIndexOf(".") + 1)
            type = SetType(type)
            pictureType.Image = ImageListType.Images(Type)
        Catch ex As Exception
            'pictureType.Image = ImageListType.Images("unknow")
        End Try

        Me.TopMost = False


        'Threading.Thread.Sleep(3000)
        'btnCancel.Enabled = False
        If bRecvAuto = True Or bUpdate = True Then
            threadClient = New Thread(New ThreadStart(AddressOf StartClient))
            threadClient.IsBackground = True
            threadClient.Start()

        Else

        End If
        
    End Sub

    Public Function SetType(ByVal type As String)
        'Dim tempType As String = ""
        If type = "doc" Or type = "docx" Then
            type = "word"
        ElseIf type = "xls" Or type = "xlsx" Then
            type = "excel"
        ElseIf type = "pptx" Or type = "ppt" Then
            type = "ptt"
        ElseIf type = "zip" Or type = "rar" Then
            type = "rar"
        ElseIf type = "pdf" Then
            type = "pdf"
        ElseIf type = "iso" Then
            type = "iso"
        ElseIf type = "exe" Then
            type = "exe"
        Else
            type = "unknow"
        End If
        Return type
    End Function


    Public Sub StartClient()
        connected = False
        If _ipAddress Is Nothing Then
            'Address is nothing
            Return
        End If

        Dim remoteEP As New IPEndPoint(_ipAddress, _port)

        ' Use IPv4 as the network protocol,if you want to support IPV6 protocol, you can update here.
        Dim clientSocket As New Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)

        ' Begin to connect the server.
        clientSocket.BeginConnect(remoteEP, New AsyncCallback(AddressOf ConnectCallback), clientSocket)
        connectDone.WaitOne()

        If connected Then

            ' Begin to receive the file after connecting to server successfully.
            Receive(clientSocket)
            receiveDone.WaitOne()

            ' Notify the user whether receive the file completely.
            BeginInvoke(New FileReceiveDoneHandler(AddressOf FileReceiveDone))

            ' Close the socket.
            clientSocket.Shutdown(SocketShutdown.Both)
            clientSocket.Close()

        Else
            'Thread.CurrentThread.Abort()
            threadClient.Abort()
        End If
    End Sub

    Private Sub ConnectCallback(ByVal ar As IAsyncResult)
        Try
            Dim clientSocket As Socket = DirectCast(ar.AsyncState, Socket)

            clientSocket.EndConnect(ar)
        Catch
            connectDone.[Set]()
            Return
        End Try

        connected = True
        connectDone.[Set]()
    End Sub

    Private Sub ReceiveFileInfo(ByVal clientSocket As Socket)
        ' Get the filename length from the server.
        Dim fileNameLenByte As Byte() = New Byte(3) {}
        Try
            clientSocket.Receive(fileNameLenByte)
        Catch
            If Not clientSocket.Connected Then
                HandleDisconnectException()
            End If
        End Try
        Dim fileNameLen As Integer = BitConverter.ToInt32(fileNameLenByte, 0)

        ' Get the filename from the server.
        Dim fileNameByte As Byte() = New Byte(fileNameLen - 1) {}

        Try
            clientSocket.Receive(fileNameByte)
        Catch
            If Not clientSocket.Connected Then
                HandleDisconnectException()
            End If
        End Try

        fileName = Encoding.Unicode.GetString(fileNameByte, 0, fileNameLen)

        SavePath = m_fileSavePath
        m_fileSavePath = m_fileSavePath & "\" & fileName

        If File.Exists(m_fileSavePath) Then
            Dim num As Integer = 1
            Dim SecondFileName As String = fileName.Substring(fileName.LastIndexOf("."))
            Dim fileDetail As IO.FileInfo = My.Computer.FileSystem.GetFileInfo(m_fileSavePath)
            Dim lengh As Integer = fileDetail.Name.Length
            While File.Exists(m_fileSavePath)
                fileName = fileName.Substring(0, lengh - 4) + "(" & num & ")" + SecondFileName
                m_fileSavePath = SavePath & "\" & fileName
                num = num + 1
            End While
        End If

        ' Get the file length from the server.
        Dim fileLenByte As Byte() = New Byte(7) {}
        clientSocket.Receive(fileLenByte)
        fileLen = BitConverter.ToInt64(fileLenByte, 0)
    End Sub

    ''' <summary>
    ''' Receive the file send by the server.
    ''' </summary>
    ''' <param name="clientSocket"></param>
    Private Sub Receive(ByVal clientSocket As Socket)
        Dim state As New StateObject()
        state.workSocket = clientSocket

        ReceiveFileInfo(clientSocket)

        progressLen = CInt(fileLen / StateObject.BufferSize + 1)
        Dim length As Object() = New Object(0) {}
        length(0) = progressLen
        Me.Invoke(New SetProgressLengthHandler(AddressOf Me.SetProgressLength), length)

        ' Begin to receive the file from the server.
        Try
            clientSocket.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0, New AsyncCallback(AddressOf ReceiveCallback), state)
        Catch
            If Not clientSocket.Connected Then
                HandleDisconnectException()
            End If
        End Try
    End Sub

    ''' <summary>
    ''' Callback when receive a file chunk from the server successfully.
    ''' </summary>
    ''' <param name="ar"></param>
    Private Sub ReceiveCallback(ByVal ar As IAsyncResult)
        Dim state As StateObject = DirectCast(ar.AsyncState, StateObject)
        Dim clientSocket As Socket = state.workSocket
        Dim writer As BinaryWriter

        If Not clientSocket.Connected Then
            HandleDisconnectException()
        End If

        Dim bytesRead As Integer = clientSocket.EndReceive(ar)

        If bytesRead > 0 Then
            nLength = nLength + 1
            If nLength = progressLen Then
                Me.BeginInvoke(New Statushandler(AddressOf Me.Status))
            End If
            'If the file doesn't exist, create a file with the filename got from server. If the file exists, append to the file.
            If Not File.Exists(m_fileSavePath) Then
                writer = New BinaryWriter(File.Open(m_fileSavePath, FileMode.Create, FileAccess.Write, FileShare.ReadWrite))
            Else
                writer = New BinaryWriter(File.Open(m_fileSavePath, FileMode.Append, FileAccess.Write, FileShare.ReadWrite))
            End If

            writer.Write(state.buffer, 0, bytesRead)

            writer.Flush()
            writer.Close()

            ' Notify the progressBar to change the position.
            Try
                Me.BeginInvoke(New ProgressChangeHandler(AddressOf Me.ProgressChanged))
            Catch ex As Exception
                HandleDisconnectException()
            End Try


            ' Recursively receive the rest file.
            Try
                clientSocket.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0, New AsyncCallback(AddressOf ReceiveCallback), state)
            Catch
                If Not clientSocket.Connected Then
                    'Disconnect To Server
                    MessageBox.Show("Disconnect!")
                    HandleDisconnectException()
                    Me.Close()
                End If
            End Try
        Else
            ' Signal if all the file received.
            receiveDone.[Set]()

        End If
    End Sub


    ''''Handle the exception when disconnect from the server.
    Private Sub HandleDisconnectException()
        'MessageBox.Show(My.Resources.DisconnectMsg)
        Thread.CurrentThread.Abort()
        'threadClient.Abort()
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        czBuffSend = _port.ToString
        nClose = 1
        cUdpServer.ReplyNonBroadcast(ipSend, MES_DECLINE_FILE)      '//////
        Me.Close()
    End Sub

    Private Sub btnRecv_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRecv.Click
        'btnCancel.Enabled = False
        threadClient = New Thread(New ThreadStart(AddressOf StartClient))
        threadClient.IsBackground = True
        threadClient.Start()

    End Sub



    Private Sub btnSaveTo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveTo.Click
        If fBrowseSaveTo.ShowDialog() = DialogResult.OK Then
            tbxSaveTo.Text = fBrowseSaveTo.SelectedPath
        Else
        End If
        m_fileSavePath = tbxSaveTo.Text.Trim
        If m_fileSavePath.Substring(m_fileSavePath.LastIndexOf("\")).Trim = "" Then
            m_fileSavePath = m_fileSavePath.Replace("\", "")
            tbxFileName_.Text = m_fileSavePath + "\" + czBuffReceive.Split("|")(0)
        End If
        SavePath = m_fileSavePath
    End Sub


    ''''Receive the file completely.

    Public Sub FileReceiveDone()
        Dim date_ As String
        Dim code As String

        code = DateTime.Now.ToString("dd MM yy hh:mm:ss.fffffff")
        date_ = DateTime.Now.ToString
        xml.AddHistory(FILE_HISTORY, code, fileName, pcSend + "(" + ipSend + ")", fileLen, "Received", date_, "Recv")
        frmSendRecv.init()
        If bUpdate = False Then
            rtbRep.Text = "Received File Success : " + tbxFileName.Text
            czBuffSend = rtbRep.Rtf
            cUdpServer.ReplyNonBroadcast(ipSend, MES_MESSENGE)
        End If




        'czBuffSend = " Received New Update Version"
        'cUdpServer.ReplyNonBroadcast(ipSend, MES_RECEIVED_UPDATE)
        grbRecvComplete.Visible = True
        If bRecvAuto = True Then
            Me.Visible = True
            Me.TopMost = True
        End If
        If bUpdate = True Then
            Me.Visible = False
            bUpdate = False
            Try
                czBuffSend = "Received New Version " + tbxFileName.Text
                cUdpServer.ReplyNonBroadcast(ipSend, MES_RECEIVED_UPDATE)
                System.Diagnostics.Process.Start(m_fileSavePath)
                End
            Catch ex As Exception
                MessageBox.Show("Can not open update file! You can run manual in path " + m_fileSavePath, "Messenger Update Information")
            End Try

        End If
        lblStatus.Visible = False
        nClose = 1

    End Sub


    ''''Connect to the server successfully.

    ''''Set the progress length of the progressBar
    Public Sub SetProgressLength(ByVal len As Integer)
        progressBar.Minimum = 0
        progressBar.Maximum = len
        progressBar.Value = 0
        progressBar.[Step] = 1
    End Sub


    ''''Change the position of the progressBar
    Public Sub ProgressChanged()
        progressBar.PerformStep()
    End Sub

    Public Sub Status()
        lblStatus.Visible = True
        'progressBar.Visible = False
    End Sub

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        nClose = 1
        Me.Close()
    End Sub

    Private Sub btnOpenFolder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOpenFolder.Click

        Dim MyProcess As New Process()
        MyProcess.StartInfo.FileName = "explorer.exe"
        MyProcess.StartInfo.Arguments = SavePath
        MyProcess.Start()
        MyProcess.WaitForExit()
        MyProcess.Close()
        MyProcess.Dispose()
        nClose = 1
        Me.Close()
    End Sub

    Private Sub btnOpenFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOpenFile.Click
        Try
            System.Diagnostics.Process.Start(m_fileSavePath)
        Catch ex As Exception

        End Try
        nClose = 1
        Me.Close()
    End Sub

    Private Sub frmRecvOption_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If nClose = 1 Then

        Else
            czBuffSend = _port.ToString
            cUdpServer.ReplyNonBroadcast(ipSend, MES_DECLINE_FILE)      '/////
        End If

    End Sub
End Class

