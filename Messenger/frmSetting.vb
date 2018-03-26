Imports System.Text.RegularExpressions
Imports MSBuild.ExtensionPack.Computer
Imports IWshRuntimeLibrary
Imports System.IO

Public Class frmSetting

    Private xml As New cMgrXml
    Dim foldername As String
    Dim bRunStart As Boolean
    Dim bSound As Boolean
    Dim bRecvFile As Boolean
    Dim oldNickName As String
    Dim oldName As String
    Dim oldPhone As String
    Dim oldMobile As String
    Dim oldGroup As String

    Private Sub frmSetting_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load '


        Dim a As Integer
        Dim b As Integer
        a = frmMain.Location.X - 385
        b = frmMain.Location.Y
        Me.Location = New Point(a, b)

        If GetIpAdd() = "" Then

        End If

        init()
        If GetIpAdd() = "172.25.215.60" Then 'Or GetIpAdd() = "172.25.215.102"
            btnAdmin.Visible = True
        Else
            btnAdmin.Visible = False
        End If
        cbxDept.SelectedIndex = 0
    End Sub

    Public Sub init()
        tbxIpAddress.Text = GetIpAdd()
        xml.ReadNickName(FILE_SETTING, tbxNickName)

        xml.ReadFilePath(FILE_SETTING, tbxBrowse)

        If xml.CheckElement_(FILE_SETTING, "RunStart") = True Then
            ckxStartup.Checked = True
            bRunStart = True
        Else
            ckxStartup.Checked = False
            bRunStart = False
        End If

        If xml.CheckElement_(FILE_SETTING, "Sound") = True Then
            ckxSoundRecvMessage.Checked = True
            bSound = True
        Else
            ckxSoundRecvMessage.Checked = False
            bSound = False
        End If

        If xml.CheckElement_(FILE_SETTING, "RecvFile") = True Then
            ckbRecvFile.Checked = True
            bRecvFile = True
        Else
            ckbRecvFile.Checked = False
            bRecvFile = False
        End If

        oldNickName = tbxNickName.Text.Trim

        If cbxDept.Items.Count = 0 Then
            cbxDept.Items.Add("Other")
            'xml.AddGroup(FILE_DEPTCONTACT, "Other")
        End If

        oldGroup = cbxDept.Text
        oldMobile = tbxMobile.Text
        oldName = tbxFullName.Text
        oldPhone = tbxPhone.Text

    End Sub

    Private Sub btnUserOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUserOk.Click
        If tbxNickName.Text.Contains("@") Or tbxNickName.Text.Contains("|") Or tbxNickName.Text.Trim = "" Then
            MessageBox.Show("NickName Non Accept '@','|' character Or NULL")
            Return
        End If

        If tbxFullName.Text.Contains("@") Or tbxFullName.Text.Contains("|") Then
            MessageBox.Show("Fullname Non Accept '@','|' character")
            Return
        End If
        If tbxMobile.Text.Contains("@") Or tbxFullName.Text.Contains("|") Then
            MessageBox.Show("Mobile Non Accept '@','|' character")
            Return
        End If
        If tbxPhone.Text.Contains("@") Or tbxFullName.Text.Contains("|") Then
            MessageBox.Show("Phone Non Accept '@','|' character")
            Return
        End If


        While cbxDept.Text = ""
            MessageBox.Show("Please choose your dept", "Messager Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End While

        If (oldGroup = cbxDept.Text And oldName = tbxFullName.Text.Trim And oldMobile = tbxMobile.Text And oldPhone = tbxPhone.Text) Then
        Else
            xml.ReplaceDeptContact(GetIpAdd, tbxNickName.Text, cbxDept.Text, tbxFullName.Text, tbxMobile.Text, tbxPhone.Text)
            frmMain.ChangePersonalInfo()
        End If

        If (tbxNickName.Text.Trim = oldNickName) Then
            Me.Close()

        Else
            xml.ReplaceNickname(FILE_SETTING, tbxNickName)
            'xml.ReadNickName(FILE_SETTING, tbxNickName)
            frmMain.ChangeNickName()
            'MessageBox.Show("Change Your Nick Name Success!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
        Me.Close()
    End Sub

    Private Sub btnUserCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUserCancel.Click
        tbxIpAddress.Text = GetIpAdd()
        xml.ReadNickName(FILE_SETTING, tbxNickName)
        Me.Close()
    End Sub

    Private Sub btnProOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProOk.Click

        If bRunStart = False And ckxStartup.Checked = True Then
            'xml.AddElement_(FILE_SETTING, "RunStart")
            'My.Computer.Registry.LocalMachine.OpenSubKey("SOFTWARE\Microsoft\Windows\CurrentVersion\Run", True).SetValue(Application.ProductName, Application.ExecutablePath)
            'bRunStart = True

            Try
                'Dim startup As String = Environment.GetFolderPath(Environment.SpecialFolder.Startup)
                'Try
                '    My.Computer.FileSystem.DeleteFile(startup & "\Messenger.exe")
                'Catch exc As Exception
                'End Try
                'IO.File.Copy(Application.ExecutablePath, startup & "\Messenger.exe")

                CreateStartupFolderShorcut()

            Catch ex As Exception

                'MsgBox(startup)

            End Try


        ElseIf bRunStart = False And ckxStartup.Checked = False Then
            'xml.RemoveElement_(FILE_SETTING, "RunStart")
            'My.Computer.Registry.LocalMachine.OpenSubKey("SOFTWARE\Microsoft\Windows\CurrentVersion\Run", True).DeleteValue(Application.ProductName)
            'bRunStart = False
            Try
                'Dim startup As String = Environment.GetFolderPath(Environment.SpecialFolder.Startup)
                'My.Computer.FileSystem.DeleteFile(startup & "\Messenger.exe")

                DeleteStartupFolderShortcut(Application.ProductName + ".lnk")
            Catch ex As Exception

                ' MsgBox(ex.Message)

            End Try
        End If



        If bSound = False And ckxSoundRecvMessage.Checked = True Then
            xml.AddElement_(FILE_SETTING, "Sound")
            bSound = True
            bSoundOn = True
        ElseIf bSound = True And ckxSoundRecvMessage.Checked = False Then
            xml.RemoveElement_(FILE_SETTING, "Sound")
            bSound = False
            bSoundOn = False
        End If

        If bRecvFile = False And ckbRecvFile.Checked = True Then
            xml.AddElement_(FILE_SETTING, "RecvFile")
            bSound = True
            bRecvAuto = True
        ElseIf bRecvFile = True And ckbRecvFile.Checked = False Then
            xml.RemoveElement_(FILE_SETTING, "RecvFile")
            bSound = False
            bRecvAuto = False
        End If

        Me.Close()
    End Sub

    Private Sub btnBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowse.Click

        Dim result As DialogResult = folderFilePath.ShowDialog()

        If (result = DialogResult.OK) Then
            foldername = folderFilePath.SelectedPath
            tbxBrowse.Text = foldername
            xml.ReplaceFilePath(FILE_SETTING, tbxBrowse)
            My.Settings.Save()
        End If

    End Sub

    Private Sub btnProCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProCancel.Click
        Me.Close()
    End Sub


    Private Sub btnIpUpdateOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
        'Try
        '    xml.RemoveIpUpdate(FILE_SETTING)
        '    xml.AddElement(FILE_SETTING, "IpUpdate")
        '    xml.ReadIpUpdate(tbxIpFile.Text.Trim)
        '    'MessageBox.Show("Please Restart <Exit Then Open Messenger> This Program For Success Your Updating! Thank You.", "Infomation")

        '    Me.Close()
        'Catch ex As Exception
        '    MessageBox.Show("Your File Type Is Not Correct!", "Information")
        'End Try

    End Sub

    Private Sub btnIpUpdateCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub tbxIp_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Char.IsDigit(e.KeyChar) Or e.KeyChar = "." Or Asc(e.KeyChar) = Keys.Delete Or _
          Asc(e.KeyChar) = Keys.Right Or Asc(e.KeyChar) = Keys.Left Or Asc(e.KeyChar) = Keys.Delete Or Asc(e.KeyChar) = Keys.Back Then
            Return
        End If
        e.Handled = True
    End Sub
    'Private Sub tbxIp_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbxIp.LostFocus

    '    Dim rx As New Regex("^(?:(?:25[0-5]|2[0-4]\d|[01]\d\d|\d?\d)(?(?=\.?\d)\.)){4}$")

    '    If Not rx.IsMatch(tbxIp.Text) Then
    '        MessageBox.Show("The IP address is not in proper format!")
    '        tbxIp.SelectAll()
    '    End If

    'End Sub




    Private Sub btnAdmin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdmin.Click
        frmUpdate.Show()
    End Sub



    Private Sub TabControl1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabControl1.SelectedIndexChanged
        If TabControl1.SelectedIndex = 1 Then
            Me.Size = New Size(Me.Size.Width, 265)
            Me.TabControl1.Size = New Size(352, 210)
            Me.tabUser.Size = New Size(344, 148)
            Me.btnAdmin.Location = New Point(12, 260)
            Me.btnUserOk.Location = New Point(206, 260)
            Me.btnUserCancel.Location = New Point(267, 260)
            GroupBox1.Visible = False
        Else

            Me.Size = New Size(Me.Size.Width, 365)
            Me.TabControl1.Size = New Size(352, 320)
            Me.tabUser.Size = New Size(344, 260)
            Me.btnAdmin.Location = New Point(15, 260)
            Me.btnUserOk.Location = New Point(206, 260)
            Me.btnUserCancel.Location = New Point(267, 260)
            GroupBox1.Visible = True
            xml.ReadDeptContact(FILE_DEPTCONTACT, GetIpAdd(), tbxFullName, tbxPhone, tbxMobile, cbxDept)
        End If
    End Sub

    Public Function CreateStartupFolderShorcut()
        Dim WshShell As New WshShellClass
        Dim shortcut As IWshRuntimeLibrary.IWshShortcut
        Dim startUpFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.Startup)

        shortcut = CType(WshShell.CreateShortcut(startUpFolderPath + "\\" + Application.ProductName + ".lnk"), IWshRuntimeLibrary.IWshShortcut)

        shortcut.TargetPath = Application.ExecutablePath
        shortcut.WorkingDirectory = Application.StartupPath
        shortcut.Description = "Launch My Application"
        shortcut.IconLocation = Application.StartupPath + "\icons\messenger .ico"
        shortcut.Save()

    End Function

    Public Function DeleteStartupFolderShortcut(ByVal targetExeName As String)
        Dim startUpFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.Startup)

        Dim di = New DirectoryInfo(startUpFolderPath)
        Dim files As FileInfo() = di.GetFiles("*.lnk")

        For Each _fileInfo In files
            Dim shortcutTargetFile As String = GetShortcutTargetFile(_fileInfo.FullName)
            If shortcutTargetFile.EndsWith(targetExeName, StringComparison.InvariantCultureIgnoreCase) Then
                System.IO.File.Delete(_fileInfo.FullName)
            End If

        Next

    End Function

    Public Function GetShortcutTargetFile(ByVal shortcutFileName As String)
        Dim pathOnly = Path.GetDirectoryName(shortcutFileName)
        Dim filenameOnly = Path.GetFileName(shortcutFileName)

        Dim shell As Shell32.Shell
        shell = New Shell32.ShellClass()
        Dim folder = shell.NameSpace(pathOnly)
        Dim folderItem = folder.ParseName(filenameOnly)
        If Not folderItem Is Nothing Then
            Dim _link As Shell32.ShellLinkObject
            _link = CType(folderItem.GetLink, Shell32.ShellLinkObject)
            Return _link.Path
        End If

        Return ""
    End Function

End Class