
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGroupChat
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmGroupChat))
        Me.ToolStripChat = New System.Windows.Forms.ToolStrip()
        Me.tsbFont = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButtonBuzz = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripLabel = New System.Windows.Forms.ToolStripLabel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnSend = New System.Windows.Forms.Button()
        Me.rtbChat = New Messenger.Messager.Controls.ExRichTextBox()
        Me.FontDialogChat = New System.Windows.Forms.FontDialog()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.rtbGroupUsers = New System.Windows.Forms.RichTextBox()
        Me.rtbHistoryChat = New Messenger.Messager.Controls.ExRichTextBox()
        Me.ofdSendFile = New System.Windows.Forms.OpenFileDialog()
        Me.tbar_SendMessage = New System.Windows.Forms.ToolBar()
        Me.tbBtn_Emoticons = New System.Windows.Forms.ToolBarButton()
        Me.cmenu_Emotions = New System.Windows.Forms.ContextMenu()
        Me.lImages = New System.Windows.Forms.ImageList(Me.components)
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.btnInvite = New System.Windows.Forms.Button()
        Me.tPatner = New System.Windows.Forms.TreeView()
        Me.tbxSearch = New System.Windows.Forms.TextBox()
        Me.contextPater = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.AddToRoomToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RemoveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripChat.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.contextPater.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStripChat
        '
        Me.ToolStripChat.AllowDrop = True
        Me.ToolStripChat.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ToolStripChat.AutoSize = False
        Me.ToolStripChat.BackColor = System.Drawing.Color.Transparent
        Me.ToolStripChat.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolStripChat.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStripChat.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbFont, Me.ToolStripButtonBuzz, Me.ToolStripSeparator1, Me.ToolStripLabel})
        Me.ToolStripChat.Location = New System.Drawing.Point(3, 364)
        Me.ToolStripChat.Name = "ToolStripChat"
        Me.ToolStripChat.Size = New System.Drawing.Size(642, 48)
        Me.ToolStripChat.TabIndex = 11
        Me.ToolStripChat.Text = "ToolStrip1"
        '
        'tsbFont
        '
        Me.tsbFont.AutoSize = False
        Me.tsbFont.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbFont.Font = New System.Drawing.Font("Lucida Calligraphy", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tsbFont.ForeColor = System.Drawing.Color.White
        Me.tsbFont.Image = CType(resources.GetObject("tsbFont.Image"), System.Drawing.Image)
        Me.tsbFont.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.tsbFont.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbFont.Margin = New System.Windows.Forms.Padding(2)
        Me.tsbFont.MergeAction = System.Windows.Forms.MergeAction.Replace
        Me.tsbFont.Name = "tsbFont"
        Me.tsbFont.Size = New System.Drawing.Size(35, 35)
        Me.tsbFont.Text = "F"
        Me.tsbFont.ToolTipText = "Font"
        '
        'ToolStripButtonBuzz
        '
        Me.ToolStripButtonBuzz.AutoSize = False
        Me.ToolStripButtonBuzz.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButtonBuzz.Image = CType(resources.GetObject("ToolStripButtonBuzz.Image"), System.Drawing.Image)
        Me.ToolStripButtonBuzz.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripButtonBuzz.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButtonBuzz.Name = "ToolStripButtonBuzz"
        Me.ToolStripButtonBuzz.Size = New System.Drawing.Size(32, 35)
        Me.ToolStripButtonBuzz.Text = "Buzz!"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Margin = New System.Windows.Forms.Padding(10, 0, 10, 0)
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 48)
        '
        'ToolStripLabel
        '
        Me.ToolStripLabel.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripLabel.ForeColor = System.Drawing.Color.White
        Me.ToolStripLabel.Name = "ToolStripLabel"
        Me.ToolStripLabel.Size = New System.Drawing.Size(0, 45)
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.btnSend)
        Me.Panel1.Controls.Add(Me.rtbChat)
        Me.Panel1.Location = New System.Drawing.Point(3, 415)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(713, 68)
        Me.Panel1.TabIndex = 9
        '
        'btnSend
        '
        Me.btnSend.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSend.BackColor = System.Drawing.SystemColors.Highlight
        Me.btnSend.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSend.ForeColor = System.Drawing.Color.White
        Me.btnSend.Location = New System.Drawing.Point(647, 8)
        Me.btnSend.Name = "btnSend"
        Me.btnSend.Size = New System.Drawing.Size(61, 50)
        Me.btnSend.TabIndex = 1
        Me.btnSend.Text = "Send"
        Me.btnSend.UseVisualStyleBackColor = False
        '
        'rtbChat
        '
        Me.rtbChat.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rtbChat.BackColor = System.Drawing.Color.White
        Me.rtbChat.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.rtbChat.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rtbChat.HiglightColor = Messenger.Messager.Controls.ExRichTextBox.RtfColor.White
        Me.rtbChat.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.rtbChat.Location = New System.Drawing.Point(-1, 0)
        Me.rtbChat.Name = "rtbChat"
        Me.rtbChat.Size = New System.Drawing.Size(642, 66)
        Me.rtbChat.TabIndex = 0
        Me.rtbChat.Text = ""
        Me.rtbChat.TextColor = Messenger.Messager.Controls.ExRichTextBox.RtfColor.Black
        '
        'FontDialogChat
        '
        Me.FontDialogChat.ShowColor = True
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel2.BackColor = System.Drawing.Color.White
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel2.Controls.Add(Me.rtbGroupUsers)
        Me.Panel2.Controls.Add(Me.rtbHistoryChat)
        Me.Panel2.Location = New System.Drawing.Point(3, 4)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(712, 351)
        Me.Panel2.TabIndex = 12
        '
        'rtbGroupUsers
        '
        Me.rtbGroupUsers.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rtbGroupUsers.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rtbGroupUsers.ForeColor = System.Drawing.Color.Blue
        Me.rtbGroupUsers.Location = New System.Drawing.Point(0, 298)
        Me.rtbGroupUsers.Name = "rtbGroupUsers"
        Me.rtbGroupUsers.ReadOnly = True
        Me.rtbGroupUsers.Size = New System.Drawing.Size(707, 47)
        Me.rtbGroupUsers.TabIndex = 1
        Me.rtbGroupUsers.Text = ""
        '
        'rtbHistoryChat
        '
        Me.rtbHistoryChat.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.rtbHistoryChat.BackColor = System.Drawing.Color.White
        Me.rtbHistoryChat.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.rtbHistoryChat.HiglightColor = Messenger.Messager.Controls.ExRichTextBox.RtfColor.White
        Me.rtbHistoryChat.Location = New System.Drawing.Point(0, 0)
        Me.rtbHistoryChat.Name = "rtbHistoryChat"
        Me.rtbHistoryChat.ReadOnly = True
        Me.rtbHistoryChat.Size = New System.Drawing.Size(709, 292)
        Me.rtbHistoryChat.TabIndex = 0
        Me.rtbHistoryChat.TabStop = False
        Me.rtbHistoryChat.Text = ""
        Me.rtbHistoryChat.TextColor = Messenger.Messager.Controls.ExRichTextBox.RtfColor.Black
        '
        'ofdSendFile
        '
        Me.ofdSendFile.FileName = "ofdSendFile"
        Me.ofdSendFile.Multiselect = True
        '
        'tbar_SendMessage
        '
        Me.tbar_SendMessage.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbar_SendMessage.AutoSize = False
        Me.tbar_SendMessage.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.tbBtn_Emoticons})
        Me.tbar_SendMessage.Dock = System.Windows.Forms.DockStyle.None
        Me.tbar_SendMessage.DropDownArrows = True
        Me.tbar_SendMessage.ImageList = Me.lImages
        Me.tbar_SendMessage.Location = New System.Drawing.Point(664, 375)
        Me.tbar_SendMessage.Name = "tbar_SendMessage"
        Me.tbar_SendMessage.ShowToolTips = True
        Me.tbar_SendMessage.Size = New System.Drawing.Size(28, 28)
        Me.tbar_SendMessage.TabIndex = 0
        '
        'tbBtn_Emoticons
        '
        Me.tbBtn_Emoticons.DropDownMenu = Me.cmenu_Emotions
        Me.tbBtn_Emoticons.ImageIndex = 0
        Me.tbBtn_Emoticons.Name = "tbBtn_Emoticons"
        Me.tbBtn_Emoticons.Style = System.Windows.Forms.ToolBarButtonStyle.DropDownButton
        Me.tbBtn_Emoticons.ToolTipText = "Emoticons"
        '
        'lImages
        '
        Me.lImages.ImageStream = CType(resources.GetObject("lImages.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.lImages.TransparentColor = System.Drawing.Color.Transparent
        Me.lImages.Images.SetKeyName(0, "4.gif")
        '
        'Panel3
        '
        Me.Panel3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel3.BackColor = System.Drawing.SystemColors.Window
        Me.Panel3.Controls.Add(Me.btnInvite)
        Me.Panel3.Controls.Add(Me.tPatner)
        Me.Panel3.Controls.Add(Me.tbxSearch)
        Me.Panel3.Location = New System.Drawing.Point(720, 4)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(200, 478)
        Me.Panel3.TabIndex = 18
        '
        'btnInvite
        '
        Me.btnInvite.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnInvite.BackColor = System.Drawing.SystemColors.MenuHighlight
        Me.btnInvite.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnInvite.ForeColor = System.Drawing.SystemColors.Window
        Me.btnInvite.Location = New System.Drawing.Point(4, 439)
        Me.btnInvite.Name = "btnInvite"
        Me.btnInvite.Size = New System.Drawing.Size(193, 30)
        Me.btnInvite.TabIndex = 2
        Me.btnInvite.Text = "Invite Partner"
        Me.btnInvite.UseVisualStyleBackColor = False
        '
        'tPatner
        '
        Me.tPatner.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tPatner.ItemHeight = 16
        Me.tPatner.Location = New System.Drawing.Point(3, 34)
        Me.tPatner.Margin = New System.Windows.Forms.Padding(5)
        Me.tPatner.Name = "tPatner"
        Me.tPatner.ShowNodeToolTips = True
        Me.tPatner.Size = New System.Drawing.Size(194, 397)
        Me.tPatner.TabIndex = 0
        '
        'tbxSearch
        '
        Me.tbxSearch.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbxSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbxSearch.Location = New System.Drawing.Point(4, 2)
        Me.tbxSearch.Name = "tbxSearch"
        Me.tbxSearch.Size = New System.Drawing.Size(194, 26)
        Me.tbxSearch.TabIndex = 1
        '
        'contextPater
        '
        Me.contextPater.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AddToRoomToolStripMenuItem, Me.RemoveToolStripMenuItem})
        Me.contextPater.Name = "contextPater"
        Me.contextPater.Size = New System.Drawing.Size(184, 48)
        '
        'AddToRoomToolStripMenuItem
        '
        Me.AddToRoomToolStripMenuItem.Name = "AddToRoomToolStripMenuItem"
        Me.AddToRoomToolStripMenuItem.Size = New System.Drawing.Size(183, 22)
        Me.AddToRoomToolStripMenuItem.Text = "Add To Room"
        '
        'RemoveToolStripMenuItem
        '
        Me.RemoveToolStripMenuItem.Name = "RemoveToolStripMenuItem"
        Me.RemoveToolStripMenuItem.Size = New System.Drawing.Size(183, 22)
        Me.RemoveToolStripMenuItem.Text = "Remove From Room"
        '
        'frmGroupChat
        '
        Me.AcceptButton = Me.btnSend
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Highlight
        Me.ClientSize = New System.Drawing.Size(923, 487)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.tbar_SendMessage)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.ToolStripChat)
        Me.Controls.Add(Me.Panel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmGroupChat"
        Me.Text = "R_"
        Me.ToolStripChat.ResumeLayout(False)
        Me.ToolStripChat.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.contextPater.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ToolStripChat As System.Windows.Forms.ToolStrip
    Friend WithEvents tsbFont As System.Windows.Forms.ToolStripButton
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btnSend As System.Windows.Forms.Button
    'Friend WithEvents rtbChat As System.Windows.Forms.RichTextBox
    Friend WithEvents rtbChat As Messager.Controls.ExRichTextBox
    'Friend WithEvents rtbHistoryChat As System.Windows.Forms.RichTextBox
    Friend WithEvents rtbHistoryChat As Messager.Controls.ExRichTextBox
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents FontDialogChat As System.Windows.Forms.FontDialog
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents ToolStripLabel As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ofdSendFile As System.Windows.Forms.OpenFileDialog
    Friend WithEvents ToolStripButtonBuzz As System.Windows.Forms.ToolStripButton
    Friend WithEvents lImages As System.Windows.Forms.ImageList

    Private tbar_SendMessage As System.Windows.Forms.ToolBar
    Private tbBtn_Emoticons As System.Windows.Forms.ToolBarButton
    Private cmenu_Emotions As System.Windows.Forms.ContextMenu
    Friend WithEvents rtbGroupUsers As System.Windows.Forms.RichTextBox
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents btnInvite As System.Windows.Forms.Button
    Friend WithEvents tPatner As System.Windows.Forms.TreeView
    Friend WithEvents tbxSearch As System.Windows.Forms.TextBox
    Friend WithEvents contextPater As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents AddToRoomToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RemoveToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
