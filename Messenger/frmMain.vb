Imports System.IO
Imports System.Threading
Imports System.Net
Imports System.Net.Sockets
Imports System.Text
Imports System.Security.AccessControl
Imports System.Deployment.Application
Imports System.Xml

Public Class frmMain

    Private client As New cUdpClient
    Private xml As New cMgrXml

    Dim oldIp As String = ""
    Dim oldGroupName As String = ""
    Dim tempFolderPath As String = ""
    Dim listPathSend As New List(Of String)
    Dim first_time As Boolean = True

    Private dictMyContact As New Dictionary(Of String, String)

    Private Shared WM_QUERYENDSESSION As Integer = &H11
    Private Shared systemShutdown As Boolean = False

    Private networdThread As Thread
    Private updateNicknameThread As Thread

    Private Delegate Sub ClearContact()
    Private Delegate Sub UpdateYourContact()

    Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If UBound(Diagnostics.Process.GetProcessesByName(Diagnostics.Process.GetCurrentProcess.ProcessName)) > 0 Then
            MsgBox("Messenger is already running!", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Messenger is already running")
            End
        End If

        Dim x As Integer
        Dim y As Integer

        x = Screen.PrimaryScreen.WorkingArea.Width - 250
        y = Screen.PrimaryScreen.WorkingArea.Height - 540
        Me.Location = New Point(x, y)

        Me.MaximumSize = New System.Drawing.Size(400, Screen.PrimaryScreen.WorkingArea.Height)
        Me.MinimumSize = New System.Drawing.Size(250, 540)

        czCurIp = GetIpAdd()
        Try
            init()
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try


        'init server
        cUdpServer.Main = Me

        bCurrConnected = Ping()

        Dim startThread As ThreadStart = New ThreadStart(AddressOf NetwordConnect)
        networdThread = New Thread(startThread)
        'thread.IsBackground = True
        networdThread.Start()

        Dim updateThread As ThreadStart = New ThreadStart(AddressOf updateNickname)
        updateNicknameThread = New Thread(updateThread)
        ''thread.IsBackground = True
        updateNicknameThread.Start()

        If (bCurrConnected = True) Then
            cUdpServer.Init()
            'UpdateIpSend()
            ''init client and send message
            client.Init()
            client.SendData(MgrMesSend(MES_ONLINE))
            client.SendData(MgrMesSend(MES_PER_INFO))

        End If


        tmr.Start()
    End Sub


    ''---Ping To All Pc ---

    'Private Sub PingAll()
    '    While (True)
    '        Thread.Sleep(15000)
    '        client.SendData(MgrMesSend(MES_ONLINE))

    '        Try
    '            For Each contact In dictPingContacts
    '                Dim checkTime As String = GetTimeSystem() - contact.Value

    '                If Convert.ToDouble(GetTimeSystem() - contact.Value) > 1500 And contact.Key <> GetIpAdd() Then

    '                    dictPingContacts.Remove(contact.Key)
    '                    If dictContacts.Remove(contact.Key) = True Then
    '                        If bRoom = True Then
    '                            frmGroupChat.UpdatePatner()
    '                        End If
    '                        BeginInvoke(New UpdateAllContact_(AddressOf UpdateAllContacts))
    '                        'Console.WriteLine(checkTime)
    '                        'Console.WriteLine(contact.Key)
    '                    End If
    '                End If
    '            Next

    '        Catch ex As Exception
    '            Console.WriteLine(ex.ToString)
    '        End Try
    '        'End If

    '    End While
    'End Sub

    Private Sub updateNickname()
        While (True)
            Thread.Sleep(2000)
            BeginInvoke(New UpdateYourContact(AddressOf ReadYourContact))


        End While

    End Sub

    Private Sub ReadYourContact()
        dictMyContact.Clear()
        'xml.ReadGroups(FILE_CONTACTS, frmAddContact.cbxGroups)

        xml.ReadYourContact(FILE_CONTACTS, frmAddContact.cbxGroups, dictMyContact)
        Dim dictTemp As New Dictionary(Of String, String)
        dictTemp = dictContacts

        For Each ele In dictTemp
            For Each e In dictMyContact
                If e.Key = ele.Key Then
                    If e.Value <> ele.Value Then
                        Dim groupName As String = ""
                        groupName = xml.FindGroup(FILE_CONTACTS, e.Key)
                        If groupName <> "" Then
                            xml.ReplaceNickname(FILE_CONTACTS, groupName, e.Key, ele.Value)
                            UpdateYourContacts()
                            'Exit For
                        End If
                    End If
                End If
            Next
        Next

    End Sub

    Private Sub NetwordConnect()
        While (True)
            Thread.Sleep(1000)
            bConnected = Ping()
            If (bConnected = False And bCurrConnected <> bConnected) Then
                bCurrConnected = bConnected
                oldIp = czCurIp   '''''
                tmr.Stop()
                cUdpServer.Close()
                client.Close()
                BeginInvoke(New ClearContact(AddressOf ClearContact_))
                MessageBox.Show("LAN Network Is Not Connect", "Messenger Information")

            End If

            If (bConnected = True And bCurrConnected <> bConnected) Then

                Thread.Sleep(8000)

                cUdpServer.Init()
                ''init client and send message

                bCurrConnected = bConnected

                client.Init()
                If (oldIp <> GetIpAdd()) And oldIp <> "" Then
                    MessageBox.Show("Your IP Changed From " + oldIp + " To " + GetIpAdd(), "Messenger Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
                client.SendData(MgrMesSend(MES_OFFLINE, oldIp))   '''''
                client.SendData(MgrMesSend(MES_ONLINE))
                client.SendData(MgrMesSend(MES_PER_INFO))
                'UpdateIpSend()

                tmr.Start()
            End If

            If czCurIp <> GetIpAdd() Then
                bConnected = False
            End If
            If czCurIp <> GetIpAdd() And bConnected = False And GetIpAdd() <> "127.0.0.1" Then 'and getipadd <> "127.0.0.1"
                oldIp = czCurIp
                tmr.Stop()
                cUdpServer.Close()
                client.Close()
                BeginInvoke(New ClearContact(AddressOf ClearContact_))
                Thread.Sleep(2000)
                MessageBox.Show("Your IP Changed From " + oldIp + " To " + GetIpAdd() + ". Please Wait Some Second For Messenger Get Contacts.", "Messenger Information", MessageBoxButtons.OK, MessageBoxIcon.Information)

                czCurIp = GetIpAdd()
            End If

            If czCurIp = GetIpAdd() And bConnected = False Then
                Thread.Sleep(6000)

                cUdpServer.Init()
                ''init client and send message

                client.Init()
                client.SendData(MgrMesSend(MES_OFFLINE, oldIp))
                client.SendData(MgrMesSend(MES_ONLINE))
                client.SendData(MgrMesSend(MES_PER_INFO))

                'UpdateIpSend()
                tmr.Start()
            End If

        End While
    End Sub

    Private Sub tmr_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmr.Tick
        'If first_time = True Then
        'first_time = False
        'Else
        client.SendData(MgrMesSend(MES_ONLINE))

        Try
            For Each contact In dictPingContacts
                Dim checkTime As String = GetTimeSystem() - contact.Value

                If Convert.ToDouble(GetTimeSystem() - contact.Value) > 1500 And contact.Key <> GetIpAdd() Then

                    dictPingContacts.Remove(contact.Key)
                    If dictContacts.Remove(contact.Key) = True Then
                        If bRoom = True Then
                            frmGroupChat.UpdatePatner()
                        End If
                        UpdateAllContacts()
                        'Console.WriteLine(checkTime)
                        'Console.WriteLine(contact.Key)
                    End If
                End If
            Next

        Catch ex As Exception
            'Console.WriteLine(ex.ToString)
        End Try
        'End If


    End Sub

    Private Sub ClearContact_()
        tYourContact.Nodes.Clear()
        tAllContacts.Nodes.Item(0).Nodes.Clear()
    End Sub

    Protected Overrides Sub WndProc(ByRef m As System.Windows.Forms.Message)
        If m.Msg = WM_QUERYENDSESSION Then
            'MessageBox.Show("logoff, shutdown, or reboot")
            systemShutdown = True
        End If
        ' If this is WM_QUERYENDSESSION, the closing event should be raised in the base WndProc.
        MyBase.WndProc(m)
    End Sub


    Private Sub frmMain_FormClosing(ByVal sender As System.Object, _
                                    ByVal e As System.Windows.Forms.FormClosingEventArgs) _
                                Handles MyBase.FormClosing
        'If (e.CloseReason = CloseReason.TaskManagerClosing) Then

        '    e.Cancel = True
        'End If

        If (systemShutdown) Then
            ' Reset the variable because the user might cancel the shutdown.
            systemShutdown = False
            client.SendData(MgrMesSend(MES_OFFLINE))
            If (Directory.Exists(tempFolderPath + "\temp")) Then
                Directory.Delete(tempFolderPath + "\temp", True)
            End If


            Threading.Thread.Sleep(1000)
            Try
                If bRoom = True Then
                    frmGroupChat.frmChatClose()
                End If

                If dFrmChatGroup.Count > 0 Then
                    For Each pair In dFrmChatGroup
                        pair.Value.frmClose()
                    Next
                End If
            Catch ex As Exception
            End Try
            e.Cancel = False
        Else
            e.Cancel = True
            Me.Hide()
        End If

    End Sub


    Private Sub init()
        'init xml file
        If File.Exists(FILE_CONTACTS) = False Then
            xml.Create(FILE_CONTACTS, "Contacts")
        End If
        If File.Exists(FILE_DEPTCONTACT) = False Then
            xml.Create(FILE_DEPTCONTACT, "Contacts")
        End If
        If GetIpAdd() = "172.25.215.60" Then
            If File.Exists(FILE_LOG) = False Then
                xml.Create(FILE_LOG, "Log")
            End If
        End If
        If File.Exists(FILE_CONTACTS) = False Then
            xml.Create(FILE_CONTACTS, "Contacts")
        End If

        If File.Exists(FILE_SETTING) = False Then
            xml.Create(FILE_SETTING, "Setting")
            'Run with windows start
            xml.AddElement_(FILE_SETTING, "RunStart")
            xml.AddElement_(FILE_SETTING, "RecvFile")
            My.Computer.Registry.LocalMachine.OpenSubKey("SOFTWARE\Microsoft\Windows\CurrentVersion\Run", True).SetValue(Application.ProductName, Application.ExecutablePath)
        End If

        If File.Exists(FILE_HISTORY) = False Then
            xml.Create(FILE_HISTORY, "History")
        End If

        'If File.Exists(FILE_DEPTCONTACT) = False Then
        '    xml.Create(FILE_DEPTCONTACT, "Contacts")
        'End If

        If xml.CheckElement_(FILE_SETTING, "Sound") = True Then
            bSoundOn = True
        Else
            bSoundOn = False
        End If

        If xml.CheckElement_(FILE_SETTING, "RecvFile") = True Then
            bRecvAuto = True
        Else
            bRecvAuto = False
        End If

        'Add NickName As Pc Name
        czNickName = GetHostName()
        xml.AddNickName(FILE_SETTING, czNickName)

        'Add File Path
        Dim curPath As String = xml.ReadFilePath(FILE_SETTING)
        If (curPath = "") Or Not Directory.Exists(curPath) Then
            xml.RemoveFilePath(curPath)
            Dim appPath As String = Application.ExecutablePath()
            Dim saveFilePath As String = appPath.Substring(0, 3) + "Message File"
            If (Not Directory.Exists(saveFilePath)) Then
                Directory.CreateDirectory(saveFilePath)
            End If
            xml.AddSaveFilePath(FILE_SETTING, saveFilePath)
        End If


        'Add Temp Folder
        tempFolderPath = Application.StartupPath
        If (Not Directory.Exists(tempFolderPath + "\temp")) Then
            Directory.CreateDirectory(tempFolderPath + "\temp")
        Else
            'Directory.Delete(tempFolderPath + "\temp", True)
            'Directory.CreateDirectory(tempFolderPath + "\temp")
        End If

        'Add Connecting Element
        xml.AddElement(FILE_SETTING, "Connecting")

        'Add Ip Element
        xml.AddElement(FILE_SETTING, "IpUpdate")

        'Load icon
        tAllContacts.ImageList = images
        tAllContacts.ImageIndex = 1
        tAllContacts.SelectedImageIndex = 1
        tYourContact.ImageList = images
        tYourContact.ImageIndex = 2
        tYourContact.SelectedImageIndex = 2

        tDeptContacts.ImageList = images
        tDeptContacts.ImageIndex = 2
        tDeptContacts.SelectedImageIndex = 2

        'xml.ReadGroups(FILE_DEPTCONTACT, frmSetting.cbxDept)
        xml.ReadDeptContact(FILE_DEPTCONTACT, GetIpAdd, frmSetting.tbxFullName, frmSetting.tbxPhone, frmSetting.tbxMobile, frmSetting.cbxDept)

        xml.ReadGroups(FILE_CONTACTS, frmAddContact.cbxGroups, tYourContact)
        xml.ReadYourContact(FILE_CONTACTS, tYourContact, frmAddContact.cbxGroups)

        'xml.ReadGroups(FILE_DEPTCONTACT, lListDept, tDeptContacts)
        'xml.ReadYourContact(FILE_DEPTCONTACT, tDeptContacts, lListDept)
        xml.ReadGroupsDept(FILE_DEPTCONTACT, frmSetting.cbxDept, tDeptContacts)
        'xml.ReadYourContact(FILE_DEPTCONTACT, tDeptContacts, lListDept)
        xml.ReadYourContact_(FILE_DEPTCONTACT, tDeptContacts, frmSetting.cbxDept)
          
        'czBuffSend = frmSetting.tbxFullName.Text + "|" + frmSetting.tbxMobile.Text + "|" + frmSetting.tbxPhone.Text + "|" + frmSetting.cbxDept.Text
        client.SendData(MgrMesSend(MES_PER_INFO_REP))
    End Sub

    Public Sub UpdateIpSend(ByVal ip As String)
        Dim message As String = MgrMesSend(MES_ONLINE)
        client.Connect(ip, message)
    End Sub
    'Public Sub UpdateIpSend()
    '    listIp.Clear()
    '    xml.ReadIpUpdate(FILE_SETTING, listIp)

    '    Try
    '        For Each l In listIp
    '            Dim message As String = MgrMesSend(MES_ONLINE)
    '            client.Connect(l.ToString, message)
    '        Next
    '    Catch ex As Exception

    '    End Try
    'End Sub

    Public Sub CheckUpdate(ByVal newVersion As String)
        'Dim oldVersion As String = xml.ReadVersion(FILE_SETTING)
        Dim oldVersion As String = Application.ProductVersion
        If (oldVersion = "") Or (oldVersion <> newVersion) Then
            btnCheckUpdate.Visible = True

        End If
    End Sub

    Public Sub SendUpdate(ByVal ip As String, ByVal namePc As String)
        Try

            Dim fileDetail As IO.FileInfo

            Dim port As Integer
            Dim fileLength As Long

            If (czPathUpdate <> "") Then

                fileDetail = My.Computer.FileSystem.GetFileInfo(czPathUpdate)
                fileLength = fileDetail.Length
                port = OpenPort(listPort).ToString

                czBuffSend = fileDetail.Name + "|" + fileLength.ToString + "|" + port.ToString

                Dim frmSend As New frmSend
                frmSend.ip = ip
                frmSend.pcSend = namePc
                frmSend.port = port
                frmSend.fileToSend = czPathUpdate
                frmSend.Show()
                dFrmSendFile.Add(port.ToString, frmSend)
                cUdpServer.ReplyNonBroadcast(ip, MES_SEND_FILE)             '/////
                czBuffSend = ""
            Else
                Return
                'frmUpdate.Show()
            End If
        Catch ex As Exception

        End Try

    End Sub

    Public Sub MesRecvMgr(ByVal message As String)
        If message.Trim = "" Then
            Return
        End If
        Try
            czClientIpAdd = message.Split("@")(0).ToString
            czClientNickName = message.Split("@")(1).ToString
            Dim mes As String = message.Split("@")(2).ToString
            'czBuffRecv = message.Split("@")(3).ToString.Trim
            czBuffRecv = message.Substring(czClientIpAdd.Length + czClientNickName.Length + mes.Length + 3)



            Select Case mes
                Case MES_ONLINE
                    cUdpServer.ReplyNonBroadcast(czClientIpAdd, MES_ONLINE_REP)     '//////

                    ''send mes has update
                    If frmUpdate.tbxFilePath.Text.Trim = "" Or frmUpdate.tbxVersion.Text.Trim = "" Then
                    Else
                        czBuffSend = frmUpdate.tbxVersion.Text.Trim
                        cUdpServer.ReplyNonBroadcast(czClientIpAdd, MES_UPDATE)
                    End If

                    If dictContacts.ContainsKey(czClientIpAdd) = False Then
                        dictContacts.Add(czClientIpAdd, czClientNickName)
                        UpdateAllContacts()
                        If bRoom = True Then
                            frmGroupChat.UpdatePatner()
                        End If
                    End If

                    If (dictPingContacts.ContainsKey(czClientIpAdd)) = False Then
                        dictPingContacts.Add(czClientIpAdd, GetTimeSystem)
                    End If
                    If (dictPingContacts.ContainsKey(czClientIpAdd)) = True Then
                        dictPingContacts.Remove(czClientIpAdd)
                        dictPingContacts.Add(czClientIpAdd, GetTimeSystem)
                    End If



                    Exit Select

                Case MES_PER_INFO
                    czBuffSend = frmSetting.tbxFullName.Text + "|" + frmSetting.tbxMobile.Text + "|" + frmSetting.tbxPhone.Text + "|" + frmSetting.cbxDept.Text
                    cUdpServer.ReplyNonBroadcast(czClientIpAdd, MES_PER_INFO_REP)
                    Exit Select
                Case MES_PER_INFO_REP

                    Dim strFullname As String = czBuffRecv.Split("|")(0)
                    Dim strPhone As String = czBuffRecv.Split("|")(2)
                    Dim strMobile As String = czBuffRecv.Split("|")(1)
                    Dim strGroup As String = czBuffRecv.Split("|")(3)
                    xml.ReplaceDeptContact(czClientIpAdd, czClientNickName, strGroup, strFullname, strMobile, strPhone)
                    UpdateAllContacts()
                    'UpdateDeptContacts()

                    Exit Select

                Case MES_ONLINE_REP
                    If dictContacts.ContainsKey(czClientIpAdd) = False Then
                        dictContacts.Add(czClientIpAdd, czClientNickName)
                        UpdateAllContacts()
                    End If

                    Exit Select


                Case MES_UPDATE
                    '
                    czServerIpUpdate = czClientIpAdd
                    czNewVersion = czBuffRecv
                    CheckUpdate(czNewVersion)
                    Exit Select
                Case MES_UPDATE_CANCEL
                    '
                    btnCheckUpdate.Visible = False

                    Exit Select

                Case MES_UPDATE_REP

                    SendUpdate(czClientIpAdd, czClientNickName)

                    Exit Select

                Case MES_RECEIVED_UPDATE
                    'Write Log
                    xml.WriteLog(FILE_LOG, czClientIpAdd + "  " + czClientNickName + "  " + czBuffRecv)
                    Exit Select

                Case MES_OFFLINE
                    If dictContacts.ContainsKey(czClientIpAdd) Then
                        dictContacts.Remove(czClientIpAdd)
                        UpdateAllContacts()
                    End If

                    If bRoom = True Then
                        frmGroupChat.UpdatePatner()
                    End If
                    Exit Select
                Case MES_CHANGE_NAME
                    ChangeName(czClientIpAdd, czClientNickName)
                    UpdateAllContacts()

                    Exit Select
                Case MES_INVITE
                    frmConfirmGroup.ip = czClientIpAdd
                    frmConfirmGroup.nick = czClientNickName
                    frmConfirmGroup.czGroupUser = czBuffRecv
                    frmConfirmGroup.lblAsk.Text = "Do You Want To Join " + czClientNickName + "'s Group Chat?"
                    frmConfirmGroup.lblRoom.Text = ("R_" + czClientIpAdd)
                    frmConfirmGroup.Show()
                    frmConfirmGroup.TopMost = True
                Case MES_INVITE_REP
                    If bRoom = True Then
                        frmGroupChat.UpdateGroupUser(czClientIpAdd, czClientNickName, czBuffRecv)
                    Else
                        If dFrmChatGroup.ContainsKey(czBuffRecv) Then
                            For Each pair In dFrmChatGroup
                                If pair.Key = czBuffRecv Then
                                    pair.Value.listPartner.Add(czClientNickName + "<" + czClientIpAdd + ">")
                                    pair.Value.UpdatePartner()
                                End If
                            Next
                        End If
                    End If

                Case MES_EXIT_GROUP
                    If dFrmChatGroup.ContainsKey(czBuffRecv) Then
                        For Each pair In dFrmChatGroup
                            If pair.Key = czBuffRecv Then
                                If pair.Value.listPartner.Contains(czClientNickName + "<" + czClientIpAdd + ">") Then
                                    pair.Value.listPartner.Remove(czClientNickName + "<" + czClientIpAdd + ">")
                                    pair.Value.UpdatePartner()
                                End If
                            End If
                        Next
                    Else
                        If bRoom = True Then
                            frmGroupChat.UpdateGroupUser(czClientIpAdd)
                        End If
                    End If

                Case MES_MESSENGE
                    If dFrmChat.ContainsKey(czClientIpAdd) = True Then
                        For Each pair In dFrmChat
                            If pair.Key = czClientIpAdd Then
                                pair.Value.fRecvMes = message
                                pair.Value.RecvMessager()
                            End If
                        Next
                    Else
                        Dim frm As New frmChat
                        frm.fRecvMes = message
                        frm.Text = czClientNickName + " - " + czClientIpAdd
                        frm.ip = czClientIpAdd
                        frm.namePc = czClientNickName
                        frm.Show()
                        dFrmChat.Add(czClientIpAdd, frm)

                        For Each pair In dFrmChat
                            If pair.Key = varIpTop Then
                                pair.Value.TopMost = True
                                pair.Value.TopMost = False
                            End If
                        Next

                    End If

                    Exit Select
                Case MES_SEND_FILE
                    Dim frmReOption As New frmRecvOption
                    frmReOption.ipSend = czClientIpAdd
                    frmReOption.pcSend = czClientNickName
                    frmReOption.Show()
                    If bRecvAuto = True Then
                        frmReOption.Visible = False
                    Else
                        frmReOption.TopMost = True
                    End If
                    If bUpdate = True Then
                        frmReOption.Visible = False
                    End If

                    Exit Select
                Case MES_MESSENGE_GROUP
                    If bRoom = True Then
                        If frmGroupChat.Text = czClientIpAdd Then
                            If czClientNickName.Split("|")(1) <> GetIpAdd() Then
                                frmGroupChat.fRecvMes = message
                                frmGroupChat.RecvMessager()
                            End If
                        End If
                    End If
                    If dFrmChatGroup.ContainsKey(czClientIpAdd) Then
                        If czClientNickName.Split("|")(1) <> GetIpAdd() Then
                            For Each pair In dFrmChatGroup
                                If pair.Key = czClientIpAdd Then
                                    pair.Value.fRecvMes = message
                                    pair.Value.RecvMessager()
                                End If
                            Next
                        End If
                    End If
                Case MES_REMOVE_GROUP
                    If dFrmChatGroup.ContainsKey(czClientIpAdd.Split("|")(0)) Then
                        For Each pair In dFrmChatGroup
                            If pair.Key = czClientIpAdd.Split("|")(0) Then
                                If czClientIpAdd.Split("|")(1) = GetIpAdd() Then
                                    pair.Value.RemoveByAdmin()
                                Else
                                    pair.Value.listPartner.Remove(czClientNickName + "<" + czClientIpAdd + ">")
                                    pair.Value.UpdatePartner()
                                End If
                            End If
                        Next
                    End If
                Case MES_GROUP_BUZZ

                    If bRoom = True Then
                        If frmGroupChat.Text = czClientIpAdd Then
                            If czClientNickName.Split("|")(1) <> GetIpAdd() Then
                                frmGroupChat.fRecvMes = message
                                frmGroupChat.RecvMessager()
                            End If
                        End If
                    End If
                    If dFrmChatGroup.ContainsKey(czClientIpAdd) Then
                        If czClientNickName.Split("|")(1) <> GetIpAdd() Then
                            For Each pair In dFrmChatGroup
                                If pair.Key = czClientIpAdd Then
                                    pair.Value.fRecvMes = message
                                    pair.Value.RecvMessager()
                                End If
                            Next
                        End If
                    End If
                Case MES_TEXT_CHANGE
                    If dFrmChat.ContainsKey(czClientIpAdd) = True Then
                        For Each pair In dFrmChat
                            If pair.Key = czClientIpAdd Then
                                pair.Value.fRecvMes = message
                                pair.Value.RecvMessager()
                            End If
                        Next
                    End If
                    Exit Select
                Case MES_TEXT_CLEAR
                    If dFrmChat.ContainsKey(czClientIpAdd) = True Then
                        For Each pair In dFrmChat
                            If pair.Key = czClientIpAdd Then
                                pair.Value.fRecvMes = message
                                pair.Value.RecvMessager()
                            End If
                        Next
                    End If
                    Exit Select
                Case MES_SENT
                    If dFrmChat.ContainsKey(czClientIpAdd) = True Then
                        For Each pair In dFrmChat
                            If pair.Key = czClientIpAdd Then
                                pair.Value.fRecvMes = message
                                pair.Value.RecvMessager()
                            End If
                        Next
                    End If

                    Exit Select
                Case MES_BUZZ
                    If dFrmChat.ContainsKey(czClientIpAdd) = True Then
                        For Each pair In dFrmChat
                            If pair.Key = czClientIpAdd Then
                                pair.Value.fRecvMes = message
                                pair.Value.RecvMessager()
                            End If
                        Next
                    Else
                        Dim frm As New frmChat
                        frm.fRecvMes = message
                        frm.Text = czClientNickName + " - " + czClientIpAdd
                        frm.ip = czClientIpAdd
                        frm.namePc = czClientNickName
                        frm.Show()
                        dFrmChat.Add(czClientIpAdd, frm)
                        For Each pair In dFrmChat
                            If pair.Key = varIpTop Then
                                pair.Value.TopMost = True
                                pair.Value.TopMost = False
                            End If
                        Next
                    End If
                    Exit Select

                Case MES_DECLINE_FILE
                    portClose = Convert.ToInt32(czBuffRecv)
                    For Each pair In dFrmSendFile
                        If pair.Key = czBuffRecv.Trim Then
                            pair.Value.CancelFile()
                        End If
                    Next

                    'MessageBox.Show(czClientNickName + " dec           line your file!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Select

                Case MES_CONNECT
                    cUdpServer.ReplyNonBroadcast(czClientIpAdd, MES_CONNECT_REP)        '///////
                    xml.AddIpUpdate(FILE_SETTING, czClientIpAdd)
                    Exit Select

                Case MES_CONNECT_REP
                    frmConnect.CloseForm()
                    If dFrmChat.ContainsKey(czClientIpAdd) = True Then

                    Else
                        Dim frm As New frmChat
                        frm.Text = czClientNickName + " - " + czClientIpAdd
                        frm.ip = czClientIpAdd
                        frm.namePc = czClientNickName
                        frm.Show()
                        dFrmChat.Add(czClientIpAdd, frm)
                        xml.AddConnecting(FILE_SETTING, czClientIpAdd, czClientNickName)
                        xml.AddIpUpdate(FILE_SETTING, czClientIpAdd)
                    End If
                    Exit Select
            End Select
        Catch ex As Exception

        End Try
        
    End Sub


    Public Sub UpdateAllContacts()
        If bSearch = True Then

        Else
            tAllContacts.Nodes.Item(0).Nodes.Clear()
            Dim sortedDict = (From entry In dictContacts Order By entry.Value Ascending).ToDictionary(Function(pair) pair.Key, Function(pair) pair.Value)
            'dictContacts.Values.OrderBy(
            For Each pair In sortedDict
                Dim node As New TreeNode(pair.Value.ToString)
                Dim name As String = ""
                Dim phone As String = ""
                Dim mobile As String = ""
                Dim dept As String = ""
                xml.ReadDeptContact(FILE_DEPTCONTACT, pair.Key, name, phone, mobile, dept, frmSetting.cbxDept)

                Dim tip As String = ""
                If (name.Trim <> "") Then
                    tip = tip + " NAME : " + name + vbCrLf
                End If
                If (dept.Trim <> "") Then
                    tip = tip + " DEPT : " + dept + vbCrLf
                End If
                If (mobile.Trim <> "") Then
                    tip = tip + " MOBILE : " + mobile + vbCrLf
                End If
                If (phone.Trim <> "") Then
                    tip = tip + " PHONE : " + phone + vbCrLf
                End If

                tip = tip + " IP : " + pair.Key.ToString

                'node.ToolTipText = " NAME : " + name + vbCrLf + " DEPT : " + dept + vbCrLf + " MOBILE : " + mobile + vbCrLf + " PHONE : " + phone + vbCrLf + " IP : " + pair.Key.ToString
                node.ToolTipText = tip
                    node.ImageIndex = 1
                    node.SelectedImageIndex = 1
                    tAllContacts.Nodes.Item(0).Nodes.AddRange(New TreeNode() {node})
            Next
            tAllContacts.ExpandAll()
            UpdateYourContacts()
            UpdateDeptContacts()
        End If

    End Sub

    Public Sub UpdateYourContacts()
        If bSearch = True Then

        Else
            tYourContact.Nodes.Clear()
            xml.ReadGroups(FILE_CONTACTS, frmAddContact.cbxGroups, tYourContact)
            xml.ReadYourContact(FILE_CONTACTS, tYourContact, frmAddContact.cbxGroups)
            tYourContact.ExpandAll()
        End If
    End Sub

    Public Sub UpdateDeptContacts()
        If bSearch = True Then

        Else
            tDeptContacts.Nodes.Clear()
            xml.ReadGroupsDept(FILE_DEPTCONTACT, frmSetting.cbxDept, tDeptContacts)
            'xml.ReadGroups(FILE_DEPTCONTACT, lListDept, tDeptContacts)
            'xml.ReadYourContact(FILE_DEPTCONTACT, tDeptContacts, lListDept)
            xml.ReadYourContact_(FILE_DEPTCONTACT, tDeptContacts, frmSetting.cbxDept)
            tDeptContacts.ExpandAll()
        End If
    End Sub

    Private Sub tAllContact_NodeMouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeNodeMouseClickEventArgs) Handles tAllContacts.NodeMouseClick
        Try
            If e.Button = Windows.Forms.MouseButtons.Right Then
                tAllContacts.SelectedNode = e.Node
                If (Not tAllContacts.SelectedNode Is Nothing) Then
                    If tAllContacts.SelectedNode.Text <> tAllContacts.Nodes.Item(0).Text Then
                        ContextMenuStripAllContact.Show(Me.tAllContacts, e.Location)
                        Dim temp() As String = tAllContacts.SelectedNode.ToolTipText.ToString.Split(":")
                        Dim ip_temp As String = temp(temp.Count - 1).ToString.Trim
                        tempIp = ip_temp
                        tempName = tAllContacts.SelectedNode.Text
                    End If
                End If
            End If
        Catch ex As Exception

        End Try      
    End Sub

    Private Sub tYourContact_NodeMouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeNodeMouseClickEventArgs) Handles tYourContact.NodeMouseClick
        Try
            If e.Button = Windows.Forms.MouseButtons.Right Then
                tYourContact.SelectedNode = e.Node
                If (Not tYourContact.SelectedNode Is Nothing) Then
                    If e.Node.Parent Is Nothing Then
                        MoveToGroupToolStripMenuItem.Enabled = False
                        ChatToolStripMenuItem.Text = "Send Message To Group"
                        DeleteToolStripMenuItem.Text = "Delete Group"
                        RenameGroupToolStripMenuItem.Enabled = True
                        SendFileToolStripMenuItem.Enabled = False
                    Else
                        ChatToolStripMenuItem.Text = "Send Message"
                        RenameGroupToolStripMenuItem.Enabled = False
                        ChatToolStripMenuItem.Enabled = True
                        SendFileToolStripMenuItem.Enabled = True
                        Dim temp() As String = tYourContact.SelectedNode.ToolTipText.Split(":")
                        Dim ip_temp As String = temp(temp.Count - 1).ToString.Trim
                        If dictContacts.ContainsKey(ip_temp) Then
                            'ChatToolStripMenuItem.Enabled = True
                            'SendFileToolStripMenuItem.Enabled = True
                        Else
                            ChatToolStripMenuItem.Enabled = False
                            SendFileToolStripMenuItem.Enabled = False
                        End If
                        MoveToGroupToolStripMenuItem.Enabled = True

                        DeleteToolStripMenuItem.Text = "Delete"

                        'SendFileToolStripMenuItem.Enabled = True
                    End If
                    ContextMenuStripMyContact.Show(Me.tYourContact, e.Location)
                End If
            End If
        Catch ex As Exception

        End Try
        
    End Sub

    'Delete Group Or Delete Contact
    Private Sub DeleteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteToolStripMenuItem.Click
        Try
            If DeleteToolStripMenuItem.Text = "Delete" Then
                Dim temp() As String = tYourContact.SelectedNode.ToolTipText.ToString.Split(":")
                Dim ip_temp As String = temp(temp.Count - 1).ToString.Trim
                xml.RemoveContact(FILE_CONTACTS, ip_temp)
            Else
                xml.RemoveGroup(FILE_CONTACTS, tYourContact.SelectedNode.Text)
                If frmAddContact.cbxGroups.Items.Contains(tYourContact.SelectedNode.Text) Then
                    frmAddContact.cbxGroups.Items.Remove(tYourContact.SelectedNode.Text)
                End If
            End If
            UpdateYourContacts()
        Catch ex As Exception

        End Try       
    End Sub

    'Add An Contact From All Contacts
    Private Sub AddToMyContact_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddToMyContact.Click
        flagAddContact = 0
        frmAddContact.ShowDialog()
    End Sub

    'Move Group : Remove After Add New Contact. -----Notice
    Private Sub MoveToGroupToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MoveToGroupToolStripMenuItem.Click
        Try
            Dim temp() As String = tYourContact.SelectedNode.ToolTipText.ToString.Split(":")
            Dim ip_temp As String = temp(temp.Count - 1).ToString.Trim
            tempIp = ip_temp
            tempName = tYourContact.SelectedNode.Text

            'xml.RemoveContact(FILE_CONTACTS, tempIp)
            flagAddContact = 0
            frmAddContact.ShowDialog()
            UpdateYourContacts()
        Catch ex As Exception

        End Try
    End Sub

    'Add New Group
    Private Sub NewGroupToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewGroupToolStripMenuItem.Click
        Try
            Dim newGroup As String = "New Group"
            Dim num As Integer = 1
            While (frmAddContact.cbxGroups.Items.Contains(newGroup))
                newGroup = "New Group " & num
                num = num + 1
            End While
            frmAddContact.cbxGroups.Items.Add(newGroup)
            xml.AddGroup(FILE_CONTACTS, newGroup)
            UpdateYourContacts()
        Catch ex As Exception

        End Try

    End Sub

    'Function Change Nick Name
    Public Sub ChangeName(ByVal ip As String, ByVal newNickName As String)
        Dim oldName As String = ""
        For Each pair In dictContacts
            If pair.Key = ip Then
                oldName = pair.Value
                Exit For
            End If
        Next
        dictContacts.Remove(ip)
        dictContacts.Add(ip, newNickName)
        Dim groupName As String = ""
        groupName = xml.FindGroup(FILE_CONTACTS, ip)
        If groupName <> "" Then
            xml.ReplaceNickname(FILE_CONTACTS, groupName, ip, newNickName)
        End If

        groupName = xml.FindGroup(FILE_DEPTCONTACT, ip)
        If groupName <> "" Then
            xml.ReplaceNicknameDept(FILE_DEPTCONTACT, groupName, ip, newNickName)
        End If


        'strInformation = oldName + " Change Name To " + newName
    End Sub

    Public Sub ChangeNickName()
        client.SendData(MgrMesSend(MES_CHANGE_NAME))
       
    End Sub

    Public Sub ChangePersonalInfo()
        czBuffSend = frmSetting.tbxFullName.Text + "|" + frmSetting.tbxMobile.Text + "|" + frmSetting.tbxPhone.Text + "|" + frmSetting.cbxDept.Text
        client.SendData(MgrMesSend(MES_PER_INFO_REP))

    End Sub

    Private Sub tYourContact_NodeMouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeNodeMouseClickEventArgs) Handles tYourContact.NodeMouseDoubleClick
        Try
            If e.Node.Parent Is Nothing Then
                Return
            End If
            If tYourContact.SelectedNode Is Nothing Then
                Return
            End If
            Dim temp() As String = tYourContact.SelectedNode.ToolTipText.ToString.Split(":")
            Dim ip_temp As String = temp(temp.Count - 1).ToString.Trim
            If dictContacts.ContainsKey(ip_temp) Then
                If dFrmChat.ContainsKey(ip_temp) = True Then
                    For Each pair In dFrmChat
                        If pair.Key = ip_temp Then
                            If (pair.Value.WindowState = FormWindowState.Minimized) Then
                                pair.Value.WindowState = FormWindowState.Normal
                            End If

                            pair.Value.TopMost = True
                            pair.Value.TopMost = False

                        End If
                    Next
                Else

                    Dim frm As New frmChat

                    frm.Text = tYourContact.SelectedNode.Text + " - " + ip_temp
                    frm.ip = ip_temp
                    frm.namePc = tYourContact.SelectedNode.Text
                    frm.Show()
                    dFrmChat.Add(ip_temp, frm)
                End If

            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub llblSetting_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llblSetting.LinkClicked

        frmSetting.ShowDialog()

    End Sub



    Private Sub btnAddContact_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddContact.Click
        flagAddContact = 1
        frmAddContact.ShowDialog()
    End Sub

    Private Sub btnConnect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConnect.Click
        frmConnect.ShowDialog()
    End Sub


    Private Sub MessagerToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MessagerToolStripMenuItem.Click
        MessagerToolStripMenuItem.ForeColor = Color.Black

    End Sub

    Private Sub OnOffList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OnOffList.Click
        If OnOffList.Text = "Online List" Then
            OnOffList.Text = "All List"
            bOnlineContact = True
        Else
            OnOffList.Text = "Online List"
            bOnlineContact = False
        End If
        UpdateYourContacts()
        UpdateDeptContacts()
    End Sub

    Private Sub RenameGroupToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RenameGroupToolStripMenuItem.Click
        Try
            oldGroupName = tYourContact.SelectedNode.Text
            tYourContact.LabelEdit = True
            tYourContact.SelectedNode.BeginEdit()
        Catch ex As Exception

        End Try

    End Sub

    Private Sub tYourContact_AfterLabelEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.NodeLabelEditEventArgs) Handles tYourContact.AfterLabelEdit
        Try
            If Not e.Label Is Nothing Then
                If e.Label.Length > 0 Then
                    If e.Label.IndexOf(New Char() {"@"c, "."c, ","c, "!"c}) = -1 Then
                        e.Node.EndEdit(False)
                    Else
                        e.CancelEdit = True
                        MessageBox.Show("Invalid tree node label." & _
                 Microsoft.VisualBasic.ControlChars.Cr & _
                 "The invalid characters are: '@','.', ',', '!'", _
                 "Node Label Edit")
                        e.Node.BeginEdit()
                    End If
                Else
                    e.CancelEdit = True
                    MessageBox.Show("Invalid tree node label." & _
               Microsoft.VisualBasic.ControlChars.Cr & _
               "The label cannot be blank", "Node Label Edit")
                    e.Node.BeginEdit()
                End If
                xml.RenameGroup(FILE_CONTACTS, oldGroupName, e.Label)
                If frmAddContact.cbxGroups.Items.Contains(oldGroupName) Then
                    frmAddContact.cbxGroups.Items.Remove(oldGroupName)
                End If
            End If

           
        Catch ex As Exception

        End Try
        
    End Sub


    Private Sub tbxSearch_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbxSearch.TextChanged
        Try
            If tabContact.SelectedTab.Name = "tabMyContact" Then
                If tbxSearch.Text.Trim = "" Then
                    bSearch = False
                    UpdateYourContacts()

                Else
                    bSearch = True
                    tYourContact.Nodes.Clear()
                    xml.ReadGroups(FILE_CONTACTS, frmAddContact.cbxGroups, tYourContact)
                    xml.SearchContact(FILE_CONTACTS, tYourContact, frmAddContact.cbxGroups, tbxSearch)
                    tYourContact.ExpandAll()
                End If
            ElseIf tabContact.SelectedTab.Name = "deptContact" Then
                If tbxSearch.Text.Trim = "" Then
                    bSearch = False
                    UpdateDeptContacts()

                Else
                    bSearch = True
                    tDeptContacts.Nodes.Clear()
                    xml.ReadGroups(FILE_DEPTCONTACT, lListDept, tDeptContacts)
                    xml.SearchContact(FILE_DEPTCONTACT, tDeptContacts, lListDept, tbxSearch)
                    tDeptContacts.ExpandAll()
                End If
            Else
                If tbxSearch.Text.Trim = "" Then
                    bSearch = False
                    UpdateAllContacts()
                Else
                    bSearch = True
                    tAllContacts.Nodes.Item(0).Nodes.Clear()
                    For Each pair In dictContacts
                        If pair.Value.ToLower.Contains(tbxSearch.Text.ToLower.Trim) Then
                            Dim node As New TreeNode(pair.Value.ToString)
                            node.ToolTipText = " IP : " + pair.Key.ToString
                            node.ImageIndex = 1
                            node.SelectedImageIndex = 1
                            tAllContacts.Nodes.Item(0).Nodes.AddRange(New TreeNode() {node})
                        End If
                    Next

                    tAllContacts.ExpandAll()
                End If
            End If
        Catch ex As Exception

        End Try
        

    End Sub


    Private Sub ExitToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        client.SendData(MgrMesSend(MES_OFFLINE))
        If (Directory.Exists(tempFolderPath + "\temp")) Then
            Directory.Delete(tempFolderPath + "\temp", True)
        End If

        Threading.Thread.Sleep(1000)
        Try
            If bRoom = True Then
                frmGroupChat.frmChatClose()
            End If

            If dFrmChatGroup.Count > 0 Then
                For Each pair In dFrmChatGroup
                    pair.Value.frmClose()
                Next
            End If
        Catch ex As Exception

        End Try

        End
        'Application.Exit()
    End Sub

    Private Sub MessagerToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MessagerToolStripMenuItem1.Click
        'bShowMessager = True
        Me.Show()
    End Sub

    Private Sub SettingToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SettingToolStripMenuItem.Click
        frmSetting.Show()
    End Sub

    Private Sub ConnectToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConnectToolStripMenuItem.Click
        frmConnect.Show()
    End Sub

    Private Sub SendRecvFileToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SendRecvFileToolStripMenuItem.Click
        frmSendRecv.Show()
    End Sub

    Private Sub SendFileToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SendFileToolStripMenuItem.Click
        Try
            Dim temp_() As String = tYourContact.SelectedNode.ToolTipText.ToString.Split(":")
            Dim ip_temp As String = temp_(temp_.Count - 1).ToString.Trim
            tempIp = ip_temp
            tempName = tYourContact.SelectedNode.Text
            czBuffSend = ""
            ofdSendFile.Filter = " All File  |*.*"
            Dim fileDetail As IO.FileInfo

            Dim port As Integer
            Dim fileLength As Long
            If (ofdSendFile.ShowDialog() = Windows.Forms.DialogResult.OK) Then

                For Each temp As String In ofdSendFile.FileNames

                    fileDetail = My.Computer.FileSystem.GetFileInfo(temp)
                    fileLength = fileDetail.Length
                    port = OpenPort(listPort).ToString

                    czBuffSend = fileDetail.Name + "|" + fileLength.ToString + "|" + port.ToString

                    Dim frmSend As New frmSend
                    'frmSend.ip = czClientIpAdd
                    'frmSend.pcSend = czClientNickName
                    frmSend.ip = tempIp
                    frmSend.pcSend = tempName
                    frmSend.port = port
                    frmSend.fileToSend = temp
                    frmSend.Show()
                    dFrmSendFile.Add(port.ToString, frmSend)
                    cUdpServer.ReplyNonBroadcast(tempIp, MES_SEND_FILE)     '/////
                    czBuffSend = ""
                Next

            Else
            End If
        Catch ex As Exception

        End Try


    End Sub

    Private Sub SendFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SendFile.Click
        Dim temp_() As String = tAllContacts.SelectedNode.ToolTipText.ToString.Split(":")
        Dim ip_temp As String = temp_(temp_.Count - 1).ToString.Trim
        tempIp = ip_temp
        tempName = tAllContacts.SelectedNode.Text
        czBuffSend = ""
        ofdSendFile.Filter = " All File  |*.*"
        Dim fileDetail As IO.FileInfo

        Dim port As Integer
        Dim fileLength As Long
        If (ofdSendFile.ShowDialog() = Windows.Forms.DialogResult.OK) Then

            For Each temp As String In ofdSendFile.FileNames

                fileDetail = My.Computer.FileSystem.GetFileInfo(temp)
                fileLength = fileDetail.Length
                port = OpenPort(listPort).ToString

                czBuffSend = fileDetail.Name + "|" + fileLength.ToString + "|" + port.ToString

                Dim frmSend As New frmSend
                frmSend.ip = tempIp
                frmSend.pcSend = tempName
                frmSend.port = port
                frmSend.fileToSend = temp
                frmSend.Show()
                dFrmSendFile.Add(port.ToString, frmSend)
                cUdpServer.ReplyNonBroadcast(tempIp, MES_SEND_FILE)     '///////
                czBuffSend = ""
            Next

        Else
        End If
    End Sub



    Private Sub MenuStripHeader_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles MenuStripHeader.ItemClicked

    End Sub

    Private Sub Chat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Chat.Click

        Dim temp() As String = tAllContacts.SelectedNode.ToolTipText.ToString.Split(":")
        Dim ip_temp As String = temp(temp.Count - 1).ToString.Trim
        If dictContacts.ContainsKey(ip_temp) Then
            If dFrmChat.ContainsKey(ip_temp) = True Then
                For Each pair In dFrmChat
                    If pair.Key = czClientIpAdd Then
                        pair.Value.TopMost = True
                        pair.Value.TopMost = False
                    End If
                Next
            Else
                Dim frm As New frmChat
                frm.Show()
                frm.Text = tAllContacts.SelectedNode.Text + " - " + ip_temp
                frm.ip = ip_temp
                frm.namePc = tAllContacts.SelectedNode.Text
                dFrmChat.Add(ip_temp, frm)
            End If

        End If
    End Sub

    Private Sub ChatToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChatToolStripMenuItem.Click
        'If e.Node.Parent Is Nothing Then
        '    Return
        'End If
        Try
            If ChatToolStripMenuItem.Text = "Send Message" Then 'Send Message To Group
                Dim temp() As String = tYourContact.SelectedNode.ToolTipText.ToString.Split(":")
                Dim ip_temp As String = temp(temp.Count - 1).ToString.Trim
                If dictContacts.ContainsKey(ip_temp) Then
                    If dFrmChat.ContainsKey(ip_temp) = True Then
                        For Each pair In dFrmChat
                            If pair.Key = czClientIpAdd Then
                                'pair.Value.MaximizeBox = True
                                pair.Value.TopMost = True
                                pair.Value.TopMost = False
                            End If
                        Next
                    Else
                        Dim frm As New frmChat
                        frm.Text = tYourContact.SelectedNode.Text + " - " + ip_temp
                        frm.ip = ip_temp
                        frm.namePc = tYourContact.SelectedNode.Text
                        frm.Show()
                        dFrmChat.Add(ip_temp, frm)
                    End If
                Else

                End If
            Else
                If listSendGroup.Contains(tYourContact.SelectedNode.Text) = True Then
                Else

                    Dim frm As New frmSendGroup
                    frm.group = tYourContact.SelectedNode.Text.Trim
                    frm.Show()
                    frm.Text = "Group " + tYourContact.SelectedNode.Text
                    listSendGroup.Add(tYourContact.SelectedNode.Text)
                End If
            End If

        Catch ex As Exception

        End Try


    End Sub

    Private Sub tAllContacts_NodeMouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeNodeMouseClickEventArgs) Handles tAllContacts.NodeMouseDoubleClick
        If e.Node.Parent Is Nothing Then
            Return
        End If
        If tAllContacts.SelectedNode Is Nothing Then
            Return
        End If
        Dim temp() As String = tAllContacts.SelectedNode.ToolTipText.ToString.Split(":")
        Dim ip_temp As String = temp(temp.Count - 1).ToString.Trim
        Try
            If dictContacts.ContainsKey(ip_temp) Then
                If dFrmChat.ContainsKey(ip_temp) = True Then
                    For Each pair In dFrmChat
                        If pair.Key = ip_temp Then
                            If (pair.Value.WindowState = FormWindowState.Minimized) Then
                                pair.Value.WindowState = FormWindowState.Normal
                            End If
                            pair.Value.TopMost = True
                            pair.Value.TopMost = False
                        End If
                    Next
                Else
                    Dim frm As New frmChat
                    frm.Text = tAllContacts.SelectedNode.Text + " - " + ip_temp
                    frm.ip = ip_temp
                    frm.namePc = tAllContacts.SelectedNode.Text
                    frm.Show()
                    dFrmChat.Add(ip_temp, frm)
                End If

            End If
            'If dictContacts.ContainsKey(tAllContacts.SelectedNode.ToolTipText.ToString.Split(":")(5).Trim) Then
            '    If dFrmChat.ContainsKey(tAllContacts.SelectedNode.ToolTipText.ToString.Split(":")(5).Trim) = True Then
            '        For Each pair In dFrmChat
            '            If pair.Key = tAllContacts.SelectedNode.ToolTipText.ToString.Split(":")(5).Trim Then
            '                If (pair.Value.WindowState = FormWindowState.Minimized) Then
            '                    pair.Value.WindowState = FormWindowState.Normal
            '                End If
            '                pair.Value.TopMost = True
            '                pair.Value.TopMost = False
            '            End If
            '        Next
            '    Else
            '        Dim frm As New frmChat
            '        frm.Text = tAllContacts.SelectedNode.Text + " - " + tAllContacts.SelectedNode.ToolTipText.ToString.Split(":")(5).Trim
            '        frm.ip = tAllContacts.SelectedNode.ToolTipText.ToString.Split(":")(5).Trim
            '        frm.namePc = tAllContacts.SelectedNode.Text
            '        frm.Show()
            '        dFrmChat.Add(tAllContacts.SelectedNode.ToolTipText.ToString.Split(":")(5).Trim, frm)
            '    End If

            'End If
        Catch ex As Exception

        End Try

    End Sub


    Private Sub NotifyIcon_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        If e.Button = Windows.Forms.MouseButtons.Right Then
        Else
            Me.TopMost = True
            Me.Show()
            Me.TopMost = False
            'If bShowMessager = True Then
            '    bShowMessager = False
            '    Me.Hide()
            'Else
            '    bShowMessager = True
            '    Me.TopMost = True
            '    Me.Show()
            '    Me.TopMost = False
            'End If
        End If

    End Sub

    Private Sub SendToGroup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub About_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles About.Click
        frmAbout.Show()
    End Sub

    'Sub frmMain_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles Me.KeyPress
    '    If e.KeyChar = ChrW(112) Then   'F1
    '        frmConnect.Show()
    '    End If

    '    If e.KeyChar = ChrW(113) Then   'F2
    '        frmAddContact.Show()
    '    End If
    'End Sub

    Private Sub frmMain_Layout(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LayoutEventArgs) Handles MyBase.Layout
        Me.ResizeRedraw = False
        If Me.Width < 250 Then
            Me.Width = 250
        End If
        If Me.Height < 540 Then
            Me.Height = 540
        End If
    End Sub


    Private Sub tabContact_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tabContact.SelectedIndexChanged
        tbxSearch_TextChanged(sender, e)
    End Sub

    Private Sub ChatGroupToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChatGroupToolStripMenuItem.Click
        If bRoom = False Then
            bRoom = True
            frmGroupChat.Text = "R_" + GetIpAdd()
            frmGroupChat.Show()
        End If
    End Sub

    Private Sub Help_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Help.Click
        Try

            Dim myFileName As String = "HowToUseMessenger.doc"
            IO.File.WriteAllBytes(myFileName, My.Resources.HowToUseMessenger)
            If IO.File.Exists(myFileName) Then
                Process.Start(myFileName)
            End If
        Catch ex As Exception
            MessageBox.Show("Can not open document!", "Infomation")
        End Try

    End Sub



    Private Sub btnCheckUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCheckUpdate.Click
        btnCheckUpdate.Visible = False
        If MessageBox.Show("Messenger has release version " + czNewVersion + ". Do you want to update?", "Update Information", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = DialogResult.OK Then

            Dim message As String = MgrMesSend(MES_UPDATE_REP)
            client.Connect(czServerIpUpdate, message)

            bUpdate = True

        Else
            bUpdate = False

        End If
        'xml.ReplaceVersion(FILE_SETTING, czNewVersion)
    End Sub

    Private Sub tDeptContacts_NodeMouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeNodeMouseClickEventArgs) Handles tDeptContacts.NodeMouseDoubleClick
        Try
            If e.Node.Parent Is Nothing Then
                Return
            End If
            If tDeptContacts.SelectedNode Is Nothing Then
                Return
            End If
            Dim temp() As String = tDeptContacts.SelectedNode.ToolTipText.ToString.Split(":")
            Dim ip_temp As String = temp(temp.Count - 1).ToString.Trim
            If dictContacts.ContainsKey(ip_temp) Then
                If dFrmChat.ContainsKey(ip_temp) = True Then
                    For Each pair In dFrmChat
                        If pair.Key = ip_temp Then
                            If (pair.Value.WindowState = FormWindowState.Minimized) Then
                                pair.Value.WindowState = FormWindowState.Normal
                            End If

                            pair.Value.TopMost = True
                            pair.Value.TopMost = False

                        End If
                    Next
                Else

                    Dim frm As New frmChat

                    frm.Text = tDeptContacts.SelectedNode.Text + " - " + ip_temp
                    frm.ip = ip_temp
                    frm.namePc = tDeptContacts.SelectedNode.Text
                    frm.Show()
                    dFrmChat.Add(ip_temp, frm)
                End If

            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub tDeptContacts_NodeMouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeNodeMouseClickEventArgs) Handles tDeptContacts.NodeMouseClick
        Try
            If e.Button = Windows.Forms.MouseButtons.Right Then
                tDeptContacts.SelectedNode = e.Node
                If (Not tDeptContacts.SelectedNode Is Nothing) Then
                    If e.Node.Parent Is Nothing Then
                       
                    Else
                        Dim temp() As String = tDeptContacts.SelectedNode.ToolTipText.Split(":")
                        Dim ip_temp As String = temp(temp.Count - 1).ToString.Trim
                        If dictContacts.ContainsKey(ip_temp) Then
                            SendMessageToolStripMenuItem.Enabled = True
                            SendFileToolStripMenuItem1.Enabled = True
                        Else
                            SendMessageToolStripMenuItem.Enabled = False
                            SendFileToolStripMenuItem1.Enabled = False
                        End If
                        ContextMenuStripDeptContact.Show(Me.tDeptContacts, e.Location)
                    End If

                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub SendMessageToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SendMessageToolStripMenuItem.Click
        Try
            Dim temp() As String = tDeptContacts.SelectedNode.ToolTipText.Split(":")
            Dim ip_temp As String = temp(temp.Count - 1).ToString.Trim
            If dictContacts.ContainsKey(ip_temp) Then
                If dFrmChat.ContainsKey(ip_temp) = True Then
                    For Each pair In dFrmChat
                        If pair.Key = czClientIpAdd Then
                            pair.Value.TopMost = True
                            pair.Value.TopMost = False
                        End If
                    Next
                Else
                    Dim frm As New frmChat
                    frm.Show()
                    frm.Text = tDeptContacts.SelectedNode.Text + " - " + ip_temp
                    frm.ip = ip_temp
                    frm.namePc = tDeptContacts.SelectedNode.Text
                    dFrmChat.Add(ip_temp, frm)
                End If
            End If
        Catch ex As Exception

        End Try
       
    End Sub

    Private Sub SendFileToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SendFileToolStripMenuItem1.Click
        Dim temp_() As String = tDeptContacts.SelectedNode.ToolTipText.Split(":")
        Dim ip_temp As String = temp_(temp_.Count - 1).ToString.Trim
        tempIp = ip_temp
        tempName = tDeptContacts.SelectedNode.Text
        czBuffSend = ""
        ofdSendFile.Filter = " All File  |*.*"
        Dim fileDetail As IO.FileInfo

        Dim port As Integer
        Dim fileLength As Long
        If (ofdSendFile.ShowDialog() = Windows.Forms.DialogResult.OK) Then

            For Each temp As String In ofdSendFile.FileNames

                fileDetail = My.Computer.FileSystem.GetFileInfo(temp)
                fileLength = fileDetail.Length
                port = OpenPort(listPort).ToString

                czBuffSend = fileDetail.Name + "|" + fileLength.ToString + "|" + port.ToString

                Dim frmSend As New frmSend
                frmSend.ip = tempIp
                frmSend.pcSend = tempName
                frmSend.port = port
                frmSend.fileToSend = temp
                frmSend.Show()
                dFrmSendFile.Add(port.ToString, frmSend)
                cUdpServer.ReplyNonBroadcast(tempIp, MES_SEND_FILE)     '///////
                czBuffSend = ""
            Next

        Else
        End If
    End Sub
End Class

'172.25.219
