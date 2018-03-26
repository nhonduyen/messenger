Imports System.Runtime.InteropServices
Imports System.IO
Imports System.Reflection
Imports Messenger.Messager.Controls


Public Class frmChat

    Public ip As String
    Public namePc As String
    Dim lListAttact As New List(Of String)
    Dim flagAttact As Integer = 0
    Private xml As New cMgrXml
    Private Typing() As String = {"/", "-", "\", "|"}
    Dim tempRtf As String
    Public fRecvMes As String = ""
    Dim nCnt As Integer
    Dim nFlag As Integer
    Dim nFlag1 As Integer
    Dim nickname As String = ""
    Public emoticons As Image() = New Image(18) {}
    Public newEmotions As New Dictionary(Of String, Image)
    Dim currentfolder As String = My.Computer.FileSystem.CurrentDirectory



    Private Sub frmChat_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing

        Try
            'rtbHistoryChat.SaveFile("C:\Program Files\Posco ICT Viet Nam\Messenger\History Chat" + ip.Trim + ".txt")
            rtbHistoryChat.SaveFile("" + currentfolder + "\History Chat\" + ip.Trim + ".txt")
        Catch _e As Exception

        End Try
        


        dFrmChat.Remove(ip)

    End Sub



    Public Sub frmChat_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ' lblHistory.Text = "history....."
     


        Try
            rtbHistoryChat.LoadFile("" + currentfolder + "\History Chat\" + ip.Trim + ".txt")
            'rtbHistoryChat.LoadFile("D:\" + ip.Trim + ".txt")
        Catch _e As Exception
        End Try
        Dim n As Integer = rtbHistoryChat.TextLength



        If bSoundOn = True Then
            My.Computer.Audio.Play(My.Resources.open, AudioPlayMode.Background)
        End If
        nickname = xml.ReadNickName(FILE_SETTING)
        If nickname.Trim = "" Then
            nickname = GetHostName()
        End If
        init()

        rtbChat.SelectionLength = 2
        If fRecvMes <> "" Then
            Dim tempIp As String = fRecvMes.Split("@")(0)
            If tempIp = ip Then
                Dim tempNick As String = fRecvMes.Split("@")(1)
                Dim tempMes As String = fRecvMes.Split("@")(2)
                If tempMes = MES_MESSENGE Then

                    Dim tempMessenge As String = fRecvMes.Substring(tempIp.Length + tempNick.Length + tempMes.Length + 3)
                    rtbHistoryChat.AppendTextAsRtf(tempNick + " [ " + DateTime.Now.ToLongTimeString() + " ] :   ", New Font(Me.Font, FontStyle.Bold), Messager.Controls.ExRichTextBox.RtfColor.Red, Messager.Controls.ExRichTextBox.RtfColor.White)
                    rtbHistoryChat.AppendRtf(tempMessenge)
                    rtbHistoryChat.AppendTextAsRtf("\n")
                    'rtbHistoryChat.Focus()
                    rtbHistoryChat.Select(rtbHistoryChat.TextLength, 0)
                    rtbHistoryChat.ScrollToCaret()
                    ' rtbHistoryChat.Focus()

                    'rtbChat.Focus()


                    cUdpServer.ReplyNonBroadcast(ip, MES_SENT)      '///////
                    lblStatus.Text = "received " + TimeOfDay.Now.ToString
                End If

                If tempMes = MES_BUZZ Then
                    rtbHistoryChat.AppendTextAsRtf(tempNick + " [ " + DateTime.Now.ToLongTimeString() + " ] :   ", New Font(Me.Font, FontStyle.Bold), Messager.Controls.ExRichTextBox.RtfColor.Red, Messager.Controls.ExRichTextBox.RtfColor.White)
                    rtbHistoryChat.AppendTextAsRtf("  BUZZ! " + vbCrLf, New Font(Me.Font, FontStyle.Bold Or FontStyle.Italic), Messager.Controls.ExRichTextBox.RtfColor.Blue, Messager.Controls.ExRichTextBox.RtfColor.White)
                    rtbHistoryChat.AppendTextAsRtf("\n")
                    'rtbHistoryChat.Focus()
                    rtbHistoryChat.Select(rtbHistoryChat.TextLength, 0)
                    rtbHistoryChat.ScrollToCaret()
                    'rtbHistoryChat.Focus()

                    'rtbChat.Focus()
                    lblStatus.Text = "received " + TimeOfDay.Now.ToString
                    If bSoundOn = True Then
                        My.Computer.Audio.Play(My.Resources.buzz, AudioPlayMode.Background)
                    End If

                End If
            End If
        End If
        

        If flagChatting = False Then
            Me.TopMost = True
        End If
        Me.TopMost = False

    End Sub

    Public Sub init()
        Try
            tbar_SendMessage.DropDownArrows = False

            emoticons(0) = Image.FromFile("Emoticons\1.gif")
            emoticons(1) = Image.FromFile("Emoticons\2.gif")
            emoticons(2) = Image.FromFile("Emoticons\3.gif")
            emoticons(3) = Image.FromFile("Emoticons\4.gif")
            emoticons(4) = Image.FromFile("Emoticons\5.gif")
            emoticons(5) = Image.FromFile("Emoticons\6.gif")
            emoticons(6) = Image.FromFile("Emoticons\7.gif")
            emoticons(7) = Image.FromFile("Emoticons\8.gif")
            emoticons(8) = Image.FromFile("Emoticons\9.gif")
            emoticons(9) = Image.FromFile("Emoticons\10.gif")
            emoticons(10) = Image.FromFile("Emoticons\11.gif")
            emoticons(11) = Image.FromFile("Emoticons\12.gif")
            emoticons(12) = Image.FromFile("Emoticons\13.gif")
            emoticons(13) = Image.FromFile("Emoticons\14.gif")
            emoticons(14) = Image.FromFile("Emoticons\15.gif")
            emoticons(15) = Image.FromFile("Emoticons\16.gif")
            emoticons(16) = Image.FromFile("Emoticons\17.gif")
            emoticons(17) = Image.FromFile("Emoticons\18.gif")
            emoticons(18) = Image.FromFile("Emoticons\19.gif")




            Dim _menuItem As EmoticonMenuItem

            Dim _count As Integer

            For Each _emoticon As Image In emoticons
                _menuItem = New EmoticonMenuItem(_emoticon)
                AddHandler _menuItem.Click, AddressOf Me.cmenu_Emoticons_Click
                If (_count Mod 5 = 0) Then
                    _menuItem.BarBreak = True
                End If

                cmenu_Emotions.MenuItems.Add(_menuItem)

                _count = _count + 1
            Next

            newEmotions.Add(":)", Image.FromFile("Emoticons\1.gif"))
            newEmotions.Add(":(", Image.FromFile("Emoticons\2.gif"))
            newEmotions.Add(";)", Image.FromFile("Emoticons\3.gif"))
            newEmotions.Add(":D", Image.FromFile("Emoticons\4.gif"))
            newEmotions.Add(":X", Image.FromFile("Emoticons\5.gif"))
            newEmotions.Add(":>", Image.FromFile("Emoticons\6.gif"))
            newEmotions.Add(":-P", Image.FromFile("Emoticons\7.gif"))
            newEmotions.Add(":-*", Image.FromFile("Emoticons\8.gif"))
            newEmotions.Add("=((", Image.FromFile("Emoticons\9.gif"))
            newEmotions.Add("X-(", Image.FromFile("Emoticons\10.gif"))
            newEmotions.Add("))", Image.FromFile("Emoticons\11.gif"))
            newEmotions.Add(":?", Image.FromFile("Emoticons\12.gif"))
            newEmotions.Add("B-)", Image.FromFile("Emoticons\13.gif"))
            newEmotions.Add(";-", Image.FromFile("Emoticons\14.gif"))
            newEmotions.Add("-(", Image.FromFile("Emoticons\15.gif"))
            newEmotions.Add(":*", Image.FromFile("Emoticons\16.gif"))
            newEmotions.Add(":h", Image.FromFile("Emoticons\17.gif"))
            newEmotions.Add("8>", Image.FromFile("Emoticons\18.gif"))
            newEmotions.Add("*<", Image.FromFile("Emoticons\19.gif"))
        Catch ex As Exception

        End Try
        

    End Sub

    Private Sub cmenu_Emoticons_Click(ByVal _sender As Object, ByVal _args As EventArgs)
        nFlag1 = 1
        Dim _item As EmoticonMenuItem = DirectCast(_sender, EmoticonMenuItem)
        Try
            rtbChat.InsertImage(_item.Images)
        Catch _e As Exception
            MessageBox.Show("Image Insert Error" & vbLf & vbLf + _e.ToString())
        End Try
    End Sub

    Private Sub tsbFont_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbFont.Click
        If DialogResult.OK = FontDialogChat.ShowDialog() Then
            SetFontType(rtbChat, FontDialogChat.Font, FontDialogChat.Color)
        End If
    End Sub

    Public Sub SetFontType(ByVal rtb As RichTextBox, ByVal font As Font, ByVal foreColor As Color)

        If rtb.SelectionLength > 0 Then
            Dim selStart As Integer = rtb.SelectionStart
            Dim selLength As Integer = rtb.SelectionLength
            Dim currFont As System.Drawing.Font

            Dim i As Integer
            For i = 0 To selLength - 1
                rtb.Select(selStart + i, 1)
                currFont = rtb.SelectionFont
                Try
                    rtb.SelectionFont = font
                    rtb.SelectionColor = foreColor

                Catch ex As Exception

                End Try

            Next

            rtb.Select(selStart, selLength)
        Else
            Try
                rtb.SelectionFont = font
                rtb.SelectionColor = foreColor
                rtb.Font = font
                rtb.ForeColor = foreColor
            Catch ex As Exception

            End Try
        End If
    End Sub

    Public Sub IsFileLocked(ByVal str As String)

    End Sub


    Private Sub btnSend_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSend.Click
        Try

            If flagAttact = 1 Then  '   Send File
                Dim fileDetail As IO.FileInfo


                Dim port As Integer
                Dim fileLength As Long
                For Each temp As String In lListAttact

                    fileDetail = My.Computer.FileSystem.GetFileInfo(temp)
                    fileLength = fileDetail.Length

                    ''

                    port = OpenPort(listPort).ToString

                    czBuffSend = fileDetail.Name + "|" + fileLength.ToString + "|" + port.ToString

                    Dim frmSend As New frmSend
                    frmSend.ip = ip
                    frmSend.pcSend = namePc
                    frmSend.port = port
                    frmSend.fileToSend = temp
                    frmSend.Show()
                    dFrmSendFile.Add(port.ToString, frmSend)
                    cUdpServer.ReplyNonBroadcast(ip, MES_SEND_FILE)             '/////
                    czBuffSend = ""

                Next
                lListAttact.Clear()
                flagAttact = 0
                ToolStripLabel1.Text = ""

            End If

            If rtbChat.Text.Trim = "" And nFlag1 = 0 Then  '   Send Messenge
                Return
            End If

            For Each emo In newEmotions
                If rtbChat.Text.Contains(emo.Key) Then
                    Dim idx = rtbChat.Text.IndexOf(emo.Key)
                    rtbChat.Select(idx, emo.Key.Length)
                    rtbChat.InsertImage(emo.Value)

                End If
            Next
            'rtbChat.Text = "  " + rtbChat.Text
            rtbHistoryChat.AppendTextAsRtf(nickname + " [ " + DateTime.Now.ToLongTimeString() + " ] :   ", New Font(Me.Font, FontStyle.Bold), Messager.Controls.ExRichTextBox.RtfColor.Blue, Messager.Controls.ExRichTextBox.RtfColor.White)
            rtbHistoryChat.AppendRtf(rtbChat.Rtf)
            rtbHistoryChat.AppendTextAsRtf("\n")
            'rtbHistoryChat.Focus()
            rtbHistoryChat.Select(rtbHistoryChat.TextLength, 0)
            rtbHistoryChat.ScrollToCaret()
            'rtbHistoryChat.Focus()

            czBuffSend = rtbChat.Rtf
            'rtbChat.Text = String.Empty
            rtbChat.Text = ""
            rtbChat.Focus()
            cUdpServer.ReplyNonBroadcast(ip, MES_MESSENGE)              '/////
            If bSoundOn = True Then
                My.Computer.Audio.Play(My.Resources.message, AudioPlayMode.Background)
            End If
            nFlag1 = 0
        Catch ex As Exception

        End Try

    End Sub

    Public Sub RecvMessager()
        If fRecvMes <> "" Then
            Dim tempIp As String = fRecvMes.Split("@")(0)
            If tempIp = ip Then
                Dim tempNick As String = fRecvMes.Split("@")(1)
                Dim tempMes As String = fRecvMes.Split("@")(2)
                If tempMes = MES_MESSENGE Then

                    Dim tempMessenge As String = fRecvMes.Substring(tempIp.Length + tempNick.Length + tempMes.Length + 3)
                    rtbHistoryChat.AppendTextAsRtf(tempNick + " [ " + DateTime.Now.ToLongTimeString() + " ] :   ", New Font(Me.Font, FontStyle.Bold), Messager.Controls.ExRichTextBox.RtfColor.Red, Messager.Controls.ExRichTextBox.RtfColor.White)
                    rtbHistoryChat.AppendRtf(tempMessenge)
                    rtbHistoryChat.AppendTextAsRtf("\n")
                    'rtbHistoryChat.Focus()
                    rtbHistoryChat.Select(rtbHistoryChat.TextLength, 0)
                    rtbHistoryChat.ScrollToCaret()
                    'rtbHistoryChat.Focus()
                    cUdpServer.ReplyNonBroadcast(ip, MES_SENT)          '/////
                    lblStatus.Text = "received " + TimeOfDay.Now.ToString
                    'rtbChat.Text = rtbChat.Text
                    'rtbChat.Focus()
                    If bSoundOn = True Then
                        My.Computer.Audio.Play(My.Resources.message, AudioPlayMode.Background)
                    End If
                    FlashWindow(Me.Handle)
                End If

                If tempMes = MES_TEXT_CHANGE Then
                    Static index As Integer = -1
                    index = index + 1
                    If index > Typing.GetUpperBound(0) Then
                        index = 0
                    End If
                    lblStatus.Text = tempNick & " is typing " & Typing(index)
                End If
                If tempMes = MES_TEXT_CLEAR Then
                    lblStatus.Text = ""
                End If
                If tempMes = MES_SENT Then
                    lblStatus.Text = "sent " + TimeOfDay.Now.ToString
                End If

                If tempMes = MES_BUZZ Then


                    rtbHistoryChat.AppendTextAsRtf(tempNick + " [ " + DateTime.Now.ToLongTimeString() + " ] :   ", New Font(Me.Font, FontStyle.Bold), Messager.Controls.ExRichTextBox.RtfColor.Red, Messager.Controls.ExRichTextBox.RtfColor.White)
                    rtbHistoryChat.AppendTextAsRtf("  BUZZ! " + vbCrLf, New Font(Me.Font, FontStyle.Bold Or FontStyle.Italic), Messager.Controls.ExRichTextBox.RtfColor.Blue, Messager.Controls.ExRichTextBox.RtfColor.White)
                    rtbHistoryChat.AppendTextAsRtf("\n")
                    'rtbHistoryChat.Focus()
                    rtbHistoryChat.Select(rtbHistoryChat.TextLength, 0)
                    rtbHistoryChat.ScrollToCaret()
                    'rtbHistoryChat.Focus()
                    'rtbChat.Focus()
                    lblStatus.Text = "received " + TimeOfDay.Now.ToString
                    If bSoundOn = True Then
                        My.Computer.Audio.Play(My.Resources.buzz, AudioPlayMode.Background)
                    End If
                    If Me.WindowState = FormWindowState.Minimized Then
                        Me.WindowState = FormWindowState.Normal
                    End If
                    BuzzEvent()
                    'FlashWindow(Me.Handle)
                End If

            End If

            fRecvMes = ""
        End If
    End Sub


    Private Sub ToolStripChat_DragDrop(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles ToolStripChat.DragDrop
        Dim files() As String = e.Data.GetData(DataFormats.FileDrop)
        For Each File As String In CType(files, String())
            If (Not lListAttact.Contains(File)) Then
                'lListAttact.Add(String.Join("", File))
                lListAttact.Add(File.ToString)
            End If

        Next
        ToolStripLabel1.ToolTipText = ""
        ToolStripLabel1.ForeColor = Color.Black

        For i = 0 To lListAttact.Count - 1
            ' If i = lListAttact.Count - 1 Then
            '    ToolStripLabel.Text = ToolStripLabel.Text + lListAttact.Item(i).ToString
            'Else
            ''ToolStripLabel.Text = lListAttact.Item(i).ToString + vbCrLf + ToolStripLabel.Text
            ToolStripLabel1.ToolTipText = lListAttact.Item(i).ToString + vbCrLf + ToolStripLabel1.ToolTipText
            '  End If
        Next
        Dim ints As Integer = lListAttact.Item(lListAttact.Count - 1).ToString.Length
        If (lListAttact.Item(lListAttact.Count - 1).ToString.Length > 45) Then
            ToolStripLabel1.Text = lListAttact.Item(lListAttact.Count - 1).ToString.Substring(0, 40) & " ..."
        Else

            ToolStripLabel1.Text = lListAttact.Item(lListAttact.Count - 1).ToString
        End If
        flagAttact = 1
    End Sub

    Private Sub ToolStripChat_DragEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles ToolStripChat.DragEnter
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            e.Effect = DragDropEffects.Copy
        End If
    End Sub

    Private Sub ToolStripButtonAttact_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButtonAttact.Click

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
                frmSend.ip = ip
                frmSend.pcSend = namePc
                frmSend.port = port
                frmSend.fileToSend = temp
                frmSend.Show()
                dFrmSendFile.Add(port.ToString, frmSend)
                cUdpServer.ReplyNonBroadcast(ip, MES_SEND_FILE)     '//////
                czBuffSend = ""
            Next
            ToolStripLabel.Text = ""

        Else
        End If
    End Sub

    Private Sub tsbTakeScreenPicture_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbTakeScreenPicture.Click
        Me.WindowState = System.Windows.Forms.FormWindowState.Minimized
        Threading.Thread.Sleep(100)
        Dim screenCapture As New frmCapture
        screenCapture.ipSend_ = ip
        screenCapture.nameSend_ = namePc
        screenCapture.ShowDialog()

    End Sub


    Private Sub rtbChat_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rtbChat.TextChanged
        If nFlag = 0 Then
            nFlag = 1
        Else
            If rtbChat.TextLength > 0 Then
                cUdpServer.ReplyNonBroadcast(ip, MES_TEXT_CHANGE)       '////////
                flagChatting = True
                varIpTop = ip
            Else
                cUdpServer.ReplyNonBroadcast(ip, MES_TEXT_CLEAR)        '///////
                flagChatting = False

            End If
        End If

    End Sub

    Private Sub rtbChat_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles rtbChat.KeyUp

        If (e.KeyCode = Keys.Enter) AndAlso e.Control Then

        ElseIf e.KeyCode = Keys.Enter Then
            e.Handled = False
            tempRtf = rtbChat.Rtf
            EnterSend()
        ElseIf e.KeyCode = Keys.F6 Then
            ToolStripButtonAttact_Click(sender, e)
        ElseIf e.KeyCode = Keys.F5 Then
            tsbTakeScreenPicture_Click(sender, e)
        ElseIf e.KeyCode = Keys.F4 Then
            ToolStripButtonBuzz_Click(sender, e)
        ElseIf e.KeyCode = Keys.F3 Then
            tsbFont_Click(sender, e)
        ElseIf e.KeyCode = Keys.Escape Then
            Me.Close()
        Else

            'e.Handled = True
        End If
    End Sub

    Public Sub EnterSend()
        If rtbChat.Text.Trim = "" Then  '   Send Messenge
            Return
        End If
        rtbHistoryChat.AppendTextAsRtf(nickname + " [ " + DateTime.Now.ToLongTimeString() + " ] :   ", New Font(Me.Font, FontStyle.Bold), Messager.Controls.ExRichTextBox.RtfColor.Blue, Messager.Controls.ExRichTextBox.RtfColor.White)
        rtbHistoryChat.AppendRtf(tempRtf)
        rtbHistoryChat.AppendTextAsRtf("\n")
        'rtbHistoryChat.Focus()
        rtbHistoryChat.Select(rtbHistoryChat.TextLength, 0)
        rtbHistoryChat.ScrollToCaret()
        'rtbHistoryChat.Focus()
        czBuffSend = tempRtf
        rtbChat.Text = ""
        rtbChat.Focus()
        cUdpServer.ReplyNonBroadcast(ip, MES_MESSENGE)      '///////////
        If bSoundOn = True Then
            My.Computer.Audio.Play(My.Resources.message, AudioPlayMode.Background)
        End If
    End Sub

    Private Sub ToolStripButtonBuzz_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButtonBuzz.Click

        rtbHistoryChat.AppendTextAsRtf(nickname + " [ " + DateTime.Now.ToLongTimeString() + " ] :   ", New Font(Me.Font, FontStyle.Bold), Messager.Controls.ExRichTextBox.RtfColor.Blue, Messager.Controls.ExRichTextBox.RtfColor.White)
        rtbHistoryChat.AppendTextAsRtf("  BUZZ !" + vbCrLf, New Font(Me.Font, FontStyle.Bold Or FontStyle.Italic), Messager.Controls.ExRichTextBox.RtfColor.Red, Messager.Controls.ExRichTextBox.RtfColor.White)
        rtbHistoryChat.AppendRtf("")
        rtbHistoryChat.AppendTextAsRtf("\n")
        'rtbHistoryChat.Focus()
        rtbHistoryChat.Select(rtbHistoryChat.TextLength, 0)
        rtbHistoryChat.ScrollToCaret()
        'rtbHistoryChat.Focus()

        rtbChat.Text = ""
        rtbChat.Focus()
        cUdpServer.ReplyNonBroadcast(ip, MES_BUZZ)      '/////
        If bSoundOn = True Then
            My.Computer.Audio.Play(My.Resources.buzz, AudioPlayMode.Background)
        End If
        BuzzEvent()

    End Sub

    Public Sub BuzzEvent()
        For nLoop As Integer = 0 To 105
            Select Case nCnt
                Case 0
                    Me.Location = New Point(Me.Location.X + 15, Me.Location.Y)
                    Exit Select
                Case 1
                    Me.Location = New Point(Me.Location.X, Me.Location.Y + 15)
                    Exit Select
                Case 2
                    Me.Location = New Point(Me.Location.X - 15, Me.Location.Y)
                    Exit Select
                Case 3
                    Me.Location = New Point(Me.Location.X, Me.Location.Y - 15)
                    Exit Select
            End Select
            nCnt += 1
            nCnt = nCnt Mod 4
        Next
    End Sub

    'Public Sub BuzzEvent()
    '    Dim WinLoc As Point = Me.Location
    '    Dim WinLocDef As Point = Me.Location

    '    For i = 0 To 50
    '        For x = 0 To 4
    '            Select Case x
    '                Case 0
    '                    WinLoc.X = WinLocDef.X + 10
    '                    Exit Select
    '                Case 1
    '                    WinLoc.X = WinLocDef.X - 10
    '                    Exit Select
    '                Case 2
    '                    WinLoc.Y = WinLocDef.Y - 10
    '                    Exit Select
    '                Case 3
    '                    WinLoc.Y = WinLocDef.Y + 10
    '                    Exit Select
    '                Case 4
    '                    WinLoc = WinLocDef
    '                    Exit Select
    '            End Select
    '            Me.Location = WinLoc
    '        Next
    '    Next
    '    Me.Location = WinLocDef
    'End Sub

#Region "FlashWindowEx_API"

    Public Const FLASHW_STOP As UInteger = 0
    Public Const FLASHW_CAPTION As Int32 = &H1
    Public Const FLASHW_TRAY As Int32 = &H2
    Public Const FLASHW_ALL As Int32 = (FLASHW_CAPTION Or FLASHW_TRAY)
    Public Const FLASHW_TIMERNOFG As Int32 = &HC

    Public Structure FLASHWINFO
        Public cbsize As Int32
        Public hwnd As IntPtr
        Public dwFlags As Int32
        Public uCount As Int32
        Public dwTimeout As Int32
    End Structure

    Public Declare Function FlashWindowEx Lib "user32.dll" (ByRef pfwi As FLASHWINFO) As Int32

    Private Sub FlashWindow(ByVal handle As IntPtr)
        Dim flash As New FLASHWINFO
        flash.cbsize = System.Runtime.InteropServices.Marshal.SizeOf(flash)
        flash.hwnd = handle
        flash.dwFlags = FLASHW_ALL Or FLASHW_TIMERNOFG
        FlashWindowEx(flash)
    End Sub

#End Region

    Private Function cmenu_Emotions_Click() As Object
        Throw New NotImplementedException
    End Function

    Private Sub PaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PaToolStripMenuItem.Click
        Try
            Dim iData As IDataObject = Clipboard.GetDataObject()
            If iData.GetDataPresent(DataFormats.Text) Then
                rtbChat.SelectedText = CType(iData.GetData(DataFormats.Text), String)
            Else
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub rtbChat_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles rtbChat.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
            cmsChat.Show(Me.rtbChat, e.Location)
        End If
    End Sub

    Private Sub CutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CutToolStripMenuItem.Click
        Try
            If rtbChat.SelectedText <> "" Then
                Clipboard.Clear()
                Clipboard.SetText(rtbChat.SelectedText)
                rtbChat.SelectedText = ""
            Else
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub CopyToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CopyToolStripMenuItem.Click
        Try
            If rtbChat.SelectedText <> "" Then
                Clipboard.Clear()
                Clipboard.SetText(rtbChat.SelectedText)
            Else
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub rtbHistoryChat_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles rtbHistoryChat.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
            cmsHistoryChat.Show(Me.rtbHistoryChat, e.Location)
        End If
    End Sub

    Private Sub CopyToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CopyToolStripMenuItem1.Click
        Try
            If rtbHistoryChat.SelectedText <> "" Then
                Clipboard.Clear()
                Clipboard.SetText(rtbHistoryChat.SelectedText)
            Else
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub rtbHistoryChat_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkClickedEventArgs) Handles rtbHistoryChat.LinkClicked
        Try
            System.Diagnostics.Process.Start(e.LinkText)
        Catch ex As Exception

        End Try

    End Sub

    
    
    Private Sub ToolStripClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripClear.Click
        'rtbHistoryChat.LoadFile("C:\Program Files\Posco ICT Viet Nam\Messenger\History Chat" + ip.Trim + ".txt")
        rtbHistoryChat.Clear()
    End Sub
End Class


