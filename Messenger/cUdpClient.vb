Imports System
Imports System.Net
Imports System.Net.Sockets
Imports System.Text
Imports System.IO


Public Class cUdpClient

    Private Const BroatcastAddress As String = "255.255.255.255"
    Private sendClient As UdpClient

  

    Public Sub Init()
        Try
            sendClient = New UdpClient(BroatcastAddress, Port_1)
            sendClient.EnableBroadcast = True
        Catch ex As Exception

        End Try
        
    End Sub

    Public Sub SendData(ByVal message As String)
        Try
            Dim data() As Byte = Encoding.Unicode.GetBytes(message)
            sendClient.Send(data, data.Length)
        Catch ex As Exception

        End Try
       
    End Sub

    Public Sub Close()
        sendClient.Close()
    End Sub

    Public Sub Connect(ByVal clientIpAdd As String, ByVal message As String)
        Try
            Dim dataSend() As Byte
            Dim myUdpClient As UdpClient
            myUdpClient = New UdpClient(clientIpAdd, Port_1)
            'myUdpClient.EnableBroadcast = True

            dataSend = Encoding.Unicode.GetBytes(message)

            myUdpClient.Send(dataSend, dataSend.Length)

            myUdpClient.Close()
        Catch ex As Exception
            'MessageBox.Show("Can not connect", clientIpAdd, MessageBoxButtons.OK)
        End Try
    End Sub
End Class