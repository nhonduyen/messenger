Module cMgrVariable

    'Define Pc Local
    Public czNickName As String
    Public czIpAdd As String
    Public czCurIp As String
    Public czBuffSend As String
    Public czBuffRecv As String
    Public czNewVersion As String
    'Define Pc Client
    Public czClientNickName As String
    Public czClientIpAdd As String
    Public czClientFileInfo As String
    Public czServerIpUpdate As String
    Public czPathUpdate As String
    'Define Port

    'Public Const Port_1 As Integer = 1160   'Send - Recv Broadcast
    Public Const Port_1 As Integer = 1138   'Send - Recv Broadcast
    Public Const Port_2 As Integer = 1139   'Send - Recv Message
    Public Const Port_3 As Integer = 1130   'Send - Recv File


    'Define Message

    Public MES_RECEIVED_UPDATE As String = "RECEIVED_UPDATE"
    Public MES_UPDATE As String = "UPDATE"
    Public MES_UPDATE_REP As String = "UPDATE_REP"
    Public MES_UPDATE_CANCEL As String = "UPDATE_CANCEL"

    Public MES_CONNECT As String = "CONNECT"
    Public MES_CONNECT_REP As String = "CONNECT_REP"

    Public MES_ONLINE As String = "ONLINE"
    Public MES_OFFLINE As String = "OFFLINE"
    Public MES_ONLINE_REP As String = "REPLY"   'Reply Online

    Public MES_CHANGE_NAME As String = "CHANGE_NAME"    'Change Nick Name
    Public MES_PER_INFO As String = "PER_INFO"    'Change Per Info
    Public MES_PER_INFO_REP As String = "PER_INFO_REP"    'Change Per Info rep



    Public MES_SEND_FILE As String = "SEND_FILE"
    Public MES_ACCEPT_FILE As String = "ACCEPT_FILE"
    Public MES_DECLINE_FILE As String = "DECLINE_FILE"

    Public MES_BUZZ As String = "BUZZ"
    Public MES_GROUP_BUZZ As String = "GROUP_BUZZ"

    Public MES_MESSENGE As String = "MESSENGE"
    Public MES_MESSENGE_GROUP As String = "MESSENGE_GROUP"
    Public MES_TEXT_CHANGE As String = "TEXT_CHANGE"
    Public MES_TEXT_CLEAR As String = "TEXT_CLEAR"
    Public MES_SENT As String = "SENT"

    Public MES_INVITE As String = "MES_INVITE"   ' MES_GROUP_CHAT_INVITE
    Public MES_INVITE_REP As String = "MES_INVITE_REP"
    Public MES_EXIT_GROUP As String = "MES_EXIT_GROUP"
    Public MES_REMOVE_GROUP As String = "MES_REMOVE_GROUP"      'MES FOR REMOVE FROM GROUP

    Public dFrmChat As New Dictionary(Of String, frmChat)
    Public dFrmChatGroup As New Dictionary(Of String, frmChatGroupClient)
    Public dFrmSendFile As New Dictionary(Of String, frmSend)
    Public lListDept As New List(Of String)
    'Define Global Variable 
    Public bClosing As Boolean = False  'Close Server
    Public bUpdateContacts As Boolean = False
    Public bOnlineContact As Boolean = False 'On - Off
    Public bSearch As Boolean = False
    Public bShowMessager As Boolean = False
    Public bAcceptFile As Boolean = False

    Public bConnected As Boolean = False
    Public bCurrConnected As Boolean = False
    'Public bConnectClose As Boolean = False
    Public bSoundOn As Boolean = False
    Public bRecvAuto As Boolean = False
    Public bUpdate As Boolean = False

    Public varIpTop As String = ""

    Public tempIp As String
    Public tempName As String

    Public flagAddContact As Integer = 0
    Public flagChatting As Boolean = False
    'Send Recv File
    Public listPath As New List(Of String)
    Public portClose As Integer
    'Public saveFilePath As String
    Public listPort As New List(Of Integer) 'Define list port for send file
    Public ipSendFile As String

    'Define Xml File
    Public FILE_CONTACTS As String = "Contacts.xml"
    Public FILE_SETTING As String = "Setting.xml"
    Public FILE_HISTORY As String = "History.xml"
    Public FILE_DEPTCONTACT As String = "DeptContacts.xml"
    Public FILE_LOG As String = "Log.xml"

    'Define Dictionary Of Contacts
    Public dictContacts As New Dictionary(Of String, String)
    Public dictPingContacts As New Dictionary(Of String, String)
    'Define List Send Messenger For Group
    Public listSendGroup As New List(Of String)

    'Define Varialbe For Chat Group
    Public bRoom As Boolean = False

    'Define List Ip For Update
    'Public listIp As New List(Of String)

    'Define Path Image Screen
    Public fileDirectory As String = ""

    'Function
    Public Function GetHostName() As String
        Dim strHostName As String
        strHostName = System.Net.Dns.GetHostName()
        Return strHostName
    End Function

    Public Function Ping() As Boolean
        Dim connected As Boolean                                                    'Setup an infinite loop
        Try
            If My.Computer.Network.Ping("127.0.0.1") Then
                connected = True
            Else
                connected = False
            End If

        Catch ex As Exception
        End Try
        Return connected
    End Function

    Public Function GetTimeSystem() As String
        Dim timesys As String = ""
        timesys = Now.ToString("yyyy/MM/dd HH:mm:ss fff")
        timesys = timesys.Replace("/", "")
        timesys = timesys.Replace(":", "")
        timesys = timesys.Replace(" ", "")
        timesys = timesys.Substring(0, 16)
        Return timesys
    End Function

    Public Function GetIpAdd() As String
        Dim strHostName As String
        Dim strIpAdd As String

        strHostName = GetHostName()
        strIpAdd = System.Net.Dns.GetHostByName(strHostName).AddressList(0).ToString
        Return strIpAdd
    End Function

    Public Function MgrMesSend(ByVal message As String) As String
        Dim strMesSend As String = ""
        Dim xml As New cMgrXml
        Dim nickname As String = ""
        nickname = xml.ReadNickName(FILE_SETTING)
        If nickname.Trim = "" Then
            nickname = GetHostName()
        End If
        'czNickName = frmSetting.tbxNickName.Text
        czIpAdd = GetIpAdd()

        strMesSend = czIpAdd + "@" + nickname + "@" + message + "@" + czBuffSend

        Return strMesSend
    End Function

    Public Function MgrMesSend(ByVal message As String, ByVal ip As String) As String
        Dim strMesSend As String = ""
        Dim xml As New cMgrXml
        Dim nickname As String = ""
        nickname = xml.ReadNickName(FILE_SETTING)
        If nickname.Trim = "" Then
            nickname = GetHostName()
        End If

        strMesSend = ip + "@" + czNickName + "@" + message + "@" + czBuffSend

        Return strMesSend
    End Function

    Public Function MgrMesSend(ByVal ip As String, ByVal name As String, ByVal message As String) As String
        Dim strMesSend As String = ""

        strMesSend = ip + "@" + name + "@" + message + "@" + czBuffSend

        Return strMesSend
    End Function

    Public Function MgrMesSendInvite(ByVal message As String, ByVal czbuff As String) As String

        Dim strMesSend As String = ""
        Dim xml As New cMgrXml
        Dim nickname As String = ""
        nickname = xml.ReadNickName(FILE_SETTING)
        If nickname.Trim = "" Then
            nickname = GetHostName()
        End If
        czIpAdd = GetIpAdd()

        strMesSend = czIpAdd + "@" + czNickName + "@" + message + "@" + czbuff

        Return strMesSend
    End Function

    Public Function MgrMesChatGroup(ByVal message As String, ByVal room As String) As String
        Dim strMesSend As String = ""
        Dim xml As New cMgrXml
        Dim nickname As String = ""
        nickname = xml.ReadNickName(FILE_SETTING)
        If nickname.Trim = "" Then
            nickname = GetHostName()
        End If

        strMesSend = room + "@" + czNickName + "|" + GetIpAdd() + "@" + message + "@" + czBuffSend

        Return strMesSend
    End Function

    'Init Port For Send File
    Public Function OpenPort(ByVal listPort As List(Of Integer)) As Integer
        'Define port from 12121
        Dim port As Integer = 12121

        While listPort.Contains(port) = True
            port = port + 1
        End While
        listPort.Add(port)
        Return port
    End Function

    'Change Size Type
    Public Function ChangeSizeType(ByVal fileSizeByte As String) As String
        Dim SizeType As String = ""
        Dim SizeBy As Long = Convert.ToDouble(fileSizeByte)
        If SizeBy > 1024 * 1024 * 1024 Then  ' To Mb
            SizeType = Format((SizeBy / (1024 * 1024 * 1024)), "0.0").ToString + " Gb"
        ElseIf SizeBy > 1024 * 1024 Then ' To Gb
            SizeType = Format((SizeBy / (1024 * 1024)), "0.0").ToString + " Mb"
        Else ' To Kb
            SizeType = Format((SizeBy / 1024), "0.0").ToString + " Kb"
        End If
        Return SizeType
    End Function
End Module
