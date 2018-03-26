Imports System.Threading
Imports System.Net
Imports System.Net.Sockets
Imports System.Text
Imports System.IO

Public Class frmSend
    Private Const c_clientSockets As Integer = 100
    Private Const c_bufferSize As Integer = 5242880
    Private Delegate Sub SetProgressLengthHandler(ByVal len As Integer)
    Public port As Integer
    Public ip As String
    Public pcSend As String
    Public fileToSend As String
    Private HasStartup As Boolean = False
    Private signal As Integer
    Dim listenerThread As Thread
    Dim fileDetail As IO.FileInfo
    Private xml As New cMgrXml
    Dim nClose As Integer
    Private allDone As New ManualResetEvent(False)
    Private sendDone As New ManualResetEvent(False)
    Private waitClose As New ManualResetEvent(False)
    'Private Delegate Sub AddClientHandler(ByVal IpEndPoint As IPEndPoint)
    Private Delegate Sub CompleteSendHandler()
    Private Delegate Sub RemoveItemHandler(ByVal ipAddress As String)
    Private Delegate Sub EnableSendHandler()
    Private Delegate Sub ProgressChangeHandler()

    Private Clients As IList(Of Socket) = New List(Of Socket)()

    Private Sub frmSend_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        grbSendDetail.Text = "Send To : " + pcSend + " - " + ip
        lblFileName.Text = "File Name : " + fileToSend


        fileDetail = My.Computer.FileSystem.GetFileInfo(fileToSend)
        lblFileSize.Text = "File size : " + ChangeSizeType(fileDetail.Length.ToString)

        listenerThread = New Thread(New ThreadStart(AddressOf StartListening))
        listenerThread.IsBackground = True
        listenerThread.Start()

    End Sub


    Public Sub StartListening()
        Dim localEndPoint As New IPEndPoint(IPAddress.Any, port)

        ' Use IPv4 as the network protocol,if you want to support IPV6 protocol, you can update here.
        Dim listener As New Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)

        Try
            listener.Bind(localEndPoint)
        Catch ex As SocketException
            MessageBox.Show(ex.Message)
            Return
        End Try

        listener.Listen(c_clientSockets)


        allDone.Reset()
        listener.BeginAccept(New AsyncCallback(AddressOf AcceptCallback), listener)
        allDone.WaitOne()

        listenerThread.Abort()
        'Thread.CurrentThread.Abort()
    End Sub


    Private Sub AcceptCallback(ByVal ar As IAsyncResult)
        Dim listener As Socket = DirectCast(ar.AsyncState, Socket)
        Dim handler As Socket = listener.EndAccept(ar)

        Dim ipEndPoint As IPEndPoint = TryCast(handler.RemoteEndPoint, IPEndPoint)

        Clients.Add(handler)
        Send()

        allDone.[Set]()

        
    End Sub

    ''' <summary>
    ''' Send file information to clients.
    ''' </summary>
    Public Sub SendFileInfo()
        Dim fileName As String = fileToSend.Replace("\", "/")


        While fileName.IndexOf("/") > -1
            fileName = fileName.Substring(fileName.IndexOf("/") + 1)
        End While

        Dim fileInfo As New IO.FileInfo(fileToSend)
        Dim fileLen As Long = fileInfo.Length

        Dim fileLenByte As Byte() = BitConverter.GetBytes(fileLen)

        Dim fileNameByte As Byte() = Encoding.Unicode.GetBytes(fileName)

        Dim clientData As Byte() = New Byte(4 + fileNameByte.Length + 7) {}

        Dim fileNameLen As Byte() = BitConverter.GetBytes(fileNameByte.Length)

        fileNameLen.CopyTo(clientData, 0)
        fileNameByte.CopyTo(clientData, 4)
        fileLenByte.CopyTo(clientData, 4 + fileNameByte.Length)

        ' Send the file name and length to the clients. 
        If Clients.Count > 0 Then
            Dim handler As Socket = Clients.Item(0)
            Try
                handler.Send(clientData)
            Catch
                If Not handler.Connected Then

                End If
            End Try
        End If


    End Sub

    Public Sub Send()
        Dim readBytes As Integer = 0
        Dim buffer As Byte() = New Byte(c_bufferSize - 1) {}


        ' Send file information to the clients.
        SendFileInfo()

        Dim fileDetail As IO.FileInfo
        fileDetail = My.Computer.FileSystem.GetFileInfo(fileToSend)
        Dim progressLen As Integer = CInt(fileDetail.Length / StateObject.BufferSize + 1)
        Dim length As Object() = New Object(0) {}
        length(0) = progressLen
        Me.Invoke(New SetProgressLengthHandler(AddressOf Me.SetProgressLength), length)

        ' Blocking read file and send to the clients asynchronously.
        Using stream As New FileStream(fileToSend, FileMode.Open, FileAccess.Read, FileShare.ReadWrite)
            Do
                sendDone.Reset()
                signal = 0
                stream.Flush()
                readBytes = stream.Read(buffer, 0, c_bufferSize)

                If Clients.Count = 0 Then
                    sendDone.[Set]()
                End If

                If Clients.Count > 0 Then
                    Dim handler As Socket = Clients.Item(0)

                    Try
                        handler.BeginSend(buffer, 0, readBytes, SocketFlags.None, New AsyncCallback(AddressOf SendCallback), handler)
                        Me.BeginInvoke(New ProgressChangeHandler(AddressOf Me.ProgressChanged))
                    Catch
                        If Not handler.Connected Then

                            signal += 1

                            ' Signal if all the clients are disconnected.
                            If signal >= Clients.Count Then
                                sendDone.[Set]()
                            End If

                            'Me.Close()
                        End If
                    End Try
                End If
                sendDone.WaitOne()

            Loop While readBytes > 0
        End Using

        ' Disconnect all the connection when the file has send to the clients completely.
        ClientDisconnect()

        CompleteSendFile()


    End Sub


    Private Sub SendCallback(ByVal ar As IAsyncResult)
        SyncLock Me
            Dim handler As Socket = Nothing
            Try

                handler = DirectCast(ar.AsyncState, Socket)
                signal += 1

                Dim bytesSent As Integer = handler.EndSend(ar)

                ' Close the socket when all the data has sent to the client.
                If bytesSent = 0 Then

                    handler.Shutdown(SocketShutdown.Both)
                    handler.Close()
                End If

            Catch argEx As ArgumentException
                MessageBox.Show("Can not connect, messenger will close sending process!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Catch generatedExceptionName As SocketException
                ' Close the socket if the client disconnected

                handler.Shutdown(SocketShutdown.Both)
                handler.Close()
                MessageBox.Show("Connection has problem or your partner cancel receive file processing!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.Close()
            Finally
                ' Signal when the file chunk has sent to all the clients successfully. 
                If signal >= Clients.Count Then
                    sendDone.[Set]()
                End If
            End Try

        End SyncLock
    End Sub


    Private Sub ClientDisconnect() 
        Clients.Clear()
    End Sub


    Private Sub CompleteSendFile()
        Me.BeginInvoke(New CompleteSendHandler(AddressOf Me.CloseForm))

    End Sub


    Private Sub RemoveClientItem(ByVal ipAddressList As IList(Of [String]))

    End Sub

    Public Sub CloseForm()
        allDone.Reset()
        allDone.Close()

        Try
            Dim date_ As String
            Dim code As String

            Dim fileLength As Long
            fileLength = fileDetail.Length
            code = DateTime.Now.ToString("dd MM yy hh:mm:ss.fffffff")
            date_ = DateTime.Now.ToString
            xml.AddHistory(FILE_HISTORY, code, fileDetail.Name, pcSend + "(" + ip + ")", fileLength.ToString, "Sent", date_, "Send")
            frmSendRecv.init()
        Catch ex As Exception

        End Try


        Me.Close()
    End Sub


    Public Sub CancelFile()
        MessageBox.Show("Client cancel receive file!", "Info")
        Me.Close()
    End Sub

    Private Sub frmSend_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        e.Cancel = True
        Me.Hide()
    End Sub


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

End Class