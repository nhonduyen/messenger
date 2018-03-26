Imports System
Imports System.Net
Imports System.Net.Sockets
Imports System.Text
Imports System.Threading

Public NotInheritable Class cUdpServer
    Private Sub New()
    End Sub
    Private Shared recvClient As UdpClient                         'Client for handling incoming data
    Private Shared recvThread As Thread
    Private Delegate Sub MgrMesRecv(ByVal mes As String)

    Public Shared Property Main() As frmMain
        Get
            Return m_Main
        End Get
        Set(ByVal value As frmMain)
            m_Main = value
        End Set
    End Property
    Private Shared m_Main As frmMain

    Public Shared Sub Init()
        Try
            recvClient = New UdpClient(Port_1)
            recvClient.EnableBroadcast = True
            Dim receivingThread As ThreadStart = New ThreadStart(AddressOf Receiver)
            recvThread = New Thread(receivingThread)
            recvThread.IsBackground = True
            recvThread.Start()
        Catch ex As Exception
            'MessageBox.Show("An other application run with port " + Port_1.ToString, "Error", MessageBoxButtons.OK)
        End Try
        

    End Sub


    Private Shared Sub Receiver()
        Dim endPoint As IPEndPoint = New IPEndPoint(IPAddress.Any, Port_1)  'Listen for incoming data from any IP address on the specified port (i personally select 9653)
        While (True)                                                        'Setup an infinite loop

            'frmMain.MesRecvMgr(mes)
            Try
                Dim data() As Byte                                              'buffer for storing incoming bytes
                data = recvClient.Receive(endPoint)                             'Receive incoming bytes 
                Dim mes As String = Encoding.Unicode.GetString(data)          'Convert bytes back to string

                Main.BeginInvoke(New MgrMesRecv(AddressOf Main.MesRecvMgr), mes)
            Catch ex As Exception

            End Try

            If bClosing = True Then                                         'Exit sub if form is closing
                Exit Sub
            End If
        End While
    End Sub



    Public Shared Sub Close()
        recvClient.Close()
        recvThread.Abort()
    End Sub



    Public Shared Sub Reply(ByVal clientIpAdd As String, ByVal message As String)
        Try
            Dim MesRep As String = MgrMesSend(message)
            Dim dataSend() As Byte
            Dim myUdpClient As UdpClient
            myUdpClient = New UdpClient(clientIpAdd, Port_1)
            myUdpClient.EnableBroadcast = True

            dataSend = Encoding.Unicode.GetBytes(MesRep)

            myUdpClient.Send(dataSend, dataSend.Length)
            myUdpClient.Close()
        Catch ex As Exception
            'MessageBox.Show("Can not repply", "", MessageBoxButtons.OK)
        End Try
    End Sub

    Public Shared Sub ReplyNonBroadcast(ByVal clientIpAdd As String, ByVal message As String)
        Try
            Dim MesRep As String = MgrMesSend(message)
            Dim dataSend() As Byte
            Dim myUdpClient As UdpClient
            myUdpClient = New UdpClient(clientIpAdd, Port_1)
            myUdpClient.EnableBroadcast = False

            dataSend = Encoding.Unicode.GetBytes(MesRep)

            myUdpClient.Send(dataSend, dataSend.Length)
            myUdpClient.Close()
        Catch ex As Exception
            'MessageBox.Show("Can not repply", clientIpAdd, MessageBoxButtons.OK)
        End Try
    End Sub

    Public Shared Sub SendInvite(ByVal clientIpAdd As String, ByVal message As String, ByVal czBuff As String)  'For group chat
        Try
            Dim MesRep As String = MgrMesSendInvite(message, czBuff)
            Dim dataSend() As Byte
            Dim myUdpClient As UdpClient
            myUdpClient = New UdpClient(clientIpAdd, Port_1)
            myUdpClient.EnableBroadcast = False

            dataSend = Encoding.Unicode.GetBytes(MesRep)

            myUdpClient.Send(dataSend, dataSend.Length)
            myUdpClient.Close()
        Catch ex As Exception
            'MessageBox.Show("Can not repply", "", MessageBoxButtons.OK)
        End Try
    End Sub

    Public Shared Sub ReplyInvite(ByVal clientIpAdd As String, ByVal message As String, ByVal czBuff As String)  'For group chat
        Try
            Dim MesRep As String = MgrMesSendInvite(message, czBuff)
            Dim dataSend() As Byte
            Dim myUdpClient As UdpClient
            myUdpClient = New UdpClient(clientIpAdd, Port_1)
            myUdpClient.EnableBroadcast = False

            dataSend = Encoding.Unicode.GetBytes(MesRep)

            myUdpClient.Send(dataSend, dataSend.Length)
            myUdpClient.Close()
        Catch ex As Exception
            'MessageBox.Show("Can not repply", "", MessageBoxButtons.OK)
        End Try
    End Sub

    Public Shared Sub ChatGroup(ByVal clientIpAdd As String, ByVal message As String, ByVal room As String)
        Try
            Dim MesRep As String = MgrMesChatGroup(message, room)
            Dim dataSend() As Byte
            Dim myUdpClient As UdpClient
            myUdpClient = New UdpClient(clientIpAdd, Port_1)
            'myUdpClient.EnableBroadcast = True
            myUdpClient.EnableBroadcast = False

            dataSend = Encoding.Unicode.GetBytes(MesRep)

            myUdpClient.Send(dataSend, dataSend.Length)
            myUdpClient.Close()
        Catch ex As Exception
            'MessageBox.Show("Can not repply", "", MessageBoxButtons.OK)
        End Try
    End Sub

End Class