Imports System.Runtime.InteropServices
Imports System.IO
Imports System.Reflection
Imports Messenger.Messager.Controls


Public Class frmChatGroupClient

    Dim nCnt As Integer
    Dim nFlag1 As Integer

    Public emoticons As Image() = New Image(18) {}
    Public newEmotions As New Dictionary(Of String, Image)

    Public listPartner As New List(Of String)
    Public fRecvMes As String = ""
    Dim nickname As String = ""
    Public nFlag As Integer
    Dim xml As New cMgrXml

    Private Sub frmChat_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If nFlag <> 1 Then
            For Each l In listPartner
                cUdpServer.ReplyInvite(l.Split("<")(1).Split(">")(0).Trim, MES_EXIT_GROUP, Me.Text)
            Next
            If dFrmChatGroup.ContainsKey(Me.Text) Then
                dFrmChatGroup.Remove(Me.Text)
            End If
        End If

    End Sub

    Public Sub frmClose()
        Try
            For Each l In listPartner
                cUdpServer.ReplyInvite(l.Split("<")(1).Split(">")(0).Trim, MES_EXIT_GROUP, Me.Text)
            Next
        Catch ex As Exception

        End Try
    End Sub


    Public Sub frmChat_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If bSoundOn = True Then
            My.Computer.Audio.Play(My.Resources.open, AudioPlayMode.Background)
        End If

        For Each l In listPartner
            cUdpServer.ReplyInvite(l.Split("<")(1).Split(">")(0).Trim, MES_INVITE_REP, Me.Text)
        Next

        nickname = xml.ReadNickName(FILE_SETTING)
        If nickname.Trim = "" Then
            nickname = GetHostName()
        End If

        init()
        UpdatePartner()
    End Sub

    Public Sub UpdatePartner()
        rtbListPartner.Text = ""
        For Each l In listPartner
            rtbListPartner.Text = rtbListPartner.Text + l + "   |   "
        Next
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


    Private Sub btnSend_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSend.Click
        Try
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
            'cUdpServer.ChatGroup("255.255.255.255", MES_MESSENGE_GROUP, Me.Text.Trim)
            For Each l In listPartner
                cUdpServer.ChatGroup(l.Split("<")(1).Split(">")(0).Trim, MES_MESSENGE_GROUP, Me.Text.Trim)
            Next
            If bSoundOn = True Then
                My.Computer.Audio.Play(My.Resources.message, AudioPlayMode.Background)
            End If
            nFlag1 = 0
        Catch ex As Exception

        End Try
    End Sub

    Public Sub RecvMessager()
        Try
            If fRecvMes <> "" Then
                Dim tempNick As String = fRecvMes.Split("@")(1)
                Dim tempMes As String = fRecvMes.Split("@")(2)
                If tempMes = MES_MESSENGE_GROUP Then
                    Dim tempMessenge As String = fRecvMes.Split("@")(3)

                    rtbHistoryChat.AppendTextAsRtf(tempNick.Split("|")(0) + " [ " + DateTime.Now.ToLongTimeString() + " ] :   ", New Font(Me.Font, FontStyle.Bold), Messager.Controls.ExRichTextBox.RtfColor.Red, Messager.Controls.ExRichTextBox.RtfColor.White)
                    rtbHistoryChat.AppendRtf(tempMessenge)
                    rtbHistoryChat.AppendTextAsRtf("\n")

                    rtbHistoryChat.Select(rtbHistoryChat.TextLength, 0)
                    rtbHistoryChat.ScrollToCaret()

                    If bSoundOn = True Then
                        My.Computer.Audio.Play(My.Resources.message, AudioPlayMode.Background)
                    End If
                    FlashWindow(Me.Handle)

                End If
                If tempMes = MES_GROUP_BUZZ Then
                    BuzzEvent()
                    rtbHistoryChat.AppendTextAsRtf(tempNick.Split("|")(0) + " [ " + DateTime.Now.ToLongTimeString() + " ] :   ", New Font(Me.Font, FontStyle.Bold), Messager.Controls.ExRichTextBox.RtfColor.Red, Messager.Controls.ExRichTextBox.RtfColor.White)
                    rtbHistoryChat.AppendTextAsRtf("  BUZZ! " + vbCrLf, New Font(Me.Font, FontStyle.Bold Or FontStyle.Italic), Messager.Controls.ExRichTextBox.RtfColor.Blue, Messager.Controls.ExRichTextBox.RtfColor.White)
                    rtbHistoryChat.AppendTextAsRtf("\n")

                    rtbHistoryChat.Select(rtbHistoryChat.TextLength, 0)
                    rtbHistoryChat.ScrollToCaret()

                    If bSoundOn = True Then
                        My.Computer.Audio.Play(My.Resources.buzz, AudioPlayMode.Background)
                    End If
                End If

            End If
        Catch ex As Exception

        End Try

    End Sub


    Public Sub ToolStripButtonBuzz_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButtonBuzz.Click

        rtbHistoryChat.AppendTextAsRtf(nickname + " [ " + DateTime.Now.ToLongTimeString() + " ] :   ", New Font(Me.Font, FontStyle.Bold), Messager.Controls.ExRichTextBox.RtfColor.Blue, Messager.Controls.ExRichTextBox.RtfColor.White)
        rtbHistoryChat.AppendTextAsRtf("  BUZZ !" + vbCrLf, New Font(Me.Font, FontStyle.Bold Or FontStyle.Italic), Messager.Controls.ExRichTextBox.RtfColor.Red, Messager.Controls.ExRichTextBox.RtfColor.White)
        rtbHistoryChat.AppendRtf("")
        rtbHistoryChat.AppendTextAsRtf("\n")

        rtbHistoryChat.Select(rtbHistoryChat.TextLength, 0)
        rtbHistoryChat.ScrollToCaret()

        rtbChat.Text = ""
        rtbChat.Focus()
        'cUdpServer.ChatGroup("255.255.255.255", MES_GROUP_BUZZ, Me.Text.Trim)         
        For Each l In listPartner
            cUdpServer.ChatGroup(l.Split("<")(1).Split(">")(0).Trim, MES_GROUP_BUZZ, Me.Text.Trim)
        Next
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
    'e.Handled = False
    Public Sub RemoveByAdmin()
        nFlag = 1
        rtbHistoryChat.AppendTextAsRtf(" You Are Have Been Remove From This Group By Admin, You Will Can Not Receive Message.", New Font(Me.Font, FontStyle.Bold), Messager.Controls.ExRichTextBox.RtfColor.Black, Messager.Controls.ExRichTextBox.RtfColor.White)
        'rtbHistoryChat.AppendRtf(tempMessenge)
        rtbHistoryChat.AppendTextAsRtf("\n")

        rtbHistoryChat.Select(rtbHistoryChat.TextLength, 0)
        rtbHistoryChat.ScrollToCaret()

        If bSoundOn = True Then
            My.Computer.Audio.Play(My.Resources.message, AudioPlayMode.Background)
        End If
        'Me.Close()
    End Sub
   
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

End Class


