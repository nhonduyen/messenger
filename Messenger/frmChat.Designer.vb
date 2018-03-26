
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmChat
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmChat))
        Me.ToolStripChat = New System.Windows.Forms.ToolStrip()
        Me.tsbFont = New System.Windows.Forms.ToolStripButton()
        Me.tsbTakeScreenPicture = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButtonBuzz = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButtonAttact = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripLabel = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnSend = New System.Windows.Forms.Button()
        Me.FontDialogChat = New System.Windows.Forms.FontDialog()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.ofdSendFile = New System.Windows.Forms.OpenFileDialog()
        Me.tbar_SendMessage = New System.Windows.Forms.ToolBar()
        Me.tbBtn_Emoticons = New System.Windows.Forms.ToolBarButton()
        Me.cmenu_Emotions = New System.Windows.Forms.ContextMenu()
        Me.lImages = New System.Windows.Forms.ImageList(Me.components)
        Me.cmsHistoryChat = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.CopyToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmsChat = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.CopyToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripClear = New System.Windows.Forms.ToolStripButton()
        Me.rtbHistoryChat = New Messenger.Messager.Controls.ExRichTextBox()
        Me.rtbChat = New Messenger.Messager.Controls.ExRichTextBox()
        Me.ToolStripChat.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.cmsHistoryChat.SuspendLayout()
        Me.cmsChat.SuspendLayout()
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
        Me.ToolStripChat.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbFont, Me.tsbTakeScreenPicture, Me.ToolStripButtonBuzz, Me.ToolStripSeparator1, Me.ToolStripButtonAttact, Me.ToolStripLabel, Me.ToolStripLabel1, Me.ToolStripClear})
        Me.ToolStripChat.Location = New System.Drawing.Point(3, 313)
        Me.ToolStripChat.Name = "ToolStripChat"
        Me.ToolStripChat.Size = New System.Drawing.Size(533, 48)
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
        'tsbTakeScreenPicture
        '
        Me.tsbTakeScreenPicture.AutoSize = False
        Me.tsbTakeScreenPicture.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbTakeScreenPicture.Image = CType(resources.GetObject("tsbTakeScreenPicture.Image"), System.Drawing.Image)
        Me.tsbTakeScreenPicture.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.tsbTakeScreenPicture.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbTakeScreenPicture.Margin = New System.Windows.Forms.Padding(2)
        Me.tsbTakeScreenPicture.Name = "tsbTakeScreenPicture"
        Me.tsbTakeScreenPicture.Size = New System.Drawing.Size(35, 35)
        Me.tsbTakeScreenPicture.Text = "Take Screen Picture"
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
        'ToolStripButtonAttact
        '
        Me.ToolStripButtonAttact.AutoSize = False
        Me.ToolStripButtonAttact.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButtonAttact.Image = CType(resources.GetObject("ToolStripButtonAttact.Image"), System.Drawing.Image)
        Me.ToolStripButtonAttact.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripButtonAttact.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButtonAttact.Margin = New System.Windows.Forms.Padding(2)
        Me.ToolStripButtonAttact.Name = "ToolStripButtonAttact"
        Me.ToolStripButtonAttact.Size = New System.Drawing.Size(55, 35)
        Me.ToolStripButtonAttact.Text = "Attact File"
        '
        'ToolStripLabel
        '
        Me.ToolStripLabel.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripLabel.ForeColor = System.Drawing.Color.White
        Me.ToolStripLabel.Name = "ToolStripLabel"
        Me.ToolStripLabel.Size = New System.Drawing.Size(0, 45)
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(0, 45)
        Me.ToolStripLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ToolStripLabel1.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.btnSend)
        Me.Panel1.Controls.Add(Me.rtbChat)
        Me.Panel1.Location = New System.Drawing.Point(3, 366)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(604, 68)
        Me.Panel1.TabIndex = 9
        '
        'btnSend
        '
        Me.btnSend.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSend.BackColor = System.Drawing.SystemColors.Highlight
        Me.btnSend.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSend.ForeColor = System.Drawing.Color.White
        Me.btnSend.Location = New System.Drawing.Point(534, 7)
        Me.btnSend.Name = "btnSend"
        Me.btnSend.Size = New System.Drawing.Size(61, 50)
        Me.btnSend.TabIndex = 1
        Me.btnSend.Text = "Send"
        Me.btnSend.UseVisualStyleBackColor = False
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
        Me.Panel2.Controls.Add(Me.lblStatus)
        Me.Panel2.Controls.Add(Me.rtbHistoryChat)
        Me.Panel2.Location = New System.Drawing.Point(3, 4)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(604, 302)
        Me.Panel2.TabIndex = 12
        '
        'lblStatus
        '
        Me.lblStatus.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblStatus.BackColor = System.Drawing.Color.Transparent
        Me.lblStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStatus.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.lblStatus.Location = New System.Drawing.Point(0, 278)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblStatus.Size = New System.Drawing.Size(602, 17)
        Me.lblStatus.TabIndex = 1
        Me.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ofdSendFile
        '
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
        Me.tbar_SendMessage.Location = New System.Drawing.Point(559, 326)
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
        'cmsHistoryChat
        '
        Me.cmsHistoryChat.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CopyToolStripMenuItem1})
        Me.cmsHistoryChat.Name = "cmsHistoryChat"
        Me.cmsHistoryChat.Size = New System.Drawing.Size(111, 26)
        '
        'CopyToolStripMenuItem1
        '
        Me.CopyToolStripMenuItem1.Name = "CopyToolStripMenuItem1"
        Me.CopyToolStripMenuItem1.Size = New System.Drawing.Size(110, 22)
        Me.CopyToolStripMenuItem1.Text = "Copy"
        '
        'cmsChat
        '
        Me.cmsChat.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CopyToolStripMenuItem, Me.PaToolStripMenuItem, Me.CutToolStripMenuItem})
        Me.cmsChat.Name = "cmsChat"
        Me.cmsChat.Size = New System.Drawing.Size(111, 70)
        '
        'CopyToolStripMenuItem
        '
        Me.CopyToolStripMenuItem.Name = "CopyToolStripMenuItem"
        Me.CopyToolStripMenuItem.Size = New System.Drawing.Size(110, 22)
        Me.CopyToolStripMenuItem.Text = "Copy"
        '
        'PaToolStripMenuItem
        '
        Me.PaToolStripMenuItem.Name = "PaToolStripMenuItem"
        Me.PaToolStripMenuItem.Size = New System.Drawing.Size(110, 22)
        Me.PaToolStripMenuItem.Text = "Paste"
        '
        'CutToolStripMenuItem
        '
        Me.CutToolStripMenuItem.Name = "CutToolStripMenuItem"
        Me.CutToolStripMenuItem.Size = New System.Drawing.Size(110, 22)
        Me.CutToolStripMenuItem.Text = "Cut"
        '
        'ToolStripClear
        '
        Me.ToolStripClear.AutoSize = False
        Me.ToolStripClear.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripClear.Image = CType(resources.GetObject("ToolStripClear.Image"), System.Drawing.Image)
        Me.ToolStripClear.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripClear.Name = "ToolStripClear"
        Me.ToolStripClear.Size = New System.Drawing.Size(23, 45)
        Me.ToolStripClear.Text = "ToolStripClear"
        Me.ToolStripClear.ToolTipText = "Clear History Chat"
        '
        'rtbHistoryChat
        '
        Me.rtbHistoryChat.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rtbHistoryChat.BackColor = System.Drawing.Color.White
        Me.rtbHistoryChat.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.rtbHistoryChat.HiglightColor = Messenger.Messager.Controls.ExRichTextBox.RtfColor.White
        Me.rtbHistoryChat.Location = New System.Drawing.Point(0, 0)
        Me.rtbHistoryChat.Name = "rtbHistoryChat"
        Me.rtbHistoryChat.ReadOnly = True
        Me.rtbHistoryChat.Size = New System.Drawing.Size(600, 267)
        Me.rtbHistoryChat.TabIndex = 0
        Me.rtbHistoryChat.TabStop = False
        Me.rtbHistoryChat.Text = ""
        Me.rtbHistoryChat.TextColor = Messenger.Messager.Controls.ExRichTextBox.RtfColor.Black
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
        Me.rtbChat.Size = New System.Drawing.Size(533, 66)
        Me.rtbChat.TabIndex = 0
        Me.rtbChat.Text = ""
        Me.rtbChat.TextColor = Messenger.Messager.Controls.ExRichTextBox.RtfColor.Black
        '
        'frmChat
        '
        Me.AcceptButton = Me.btnSend
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Highlight
        Me.ClientSize = New System.Drawing.Size(610, 438)
        Me.Controls.Add(Me.tbar_SendMessage)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.ToolStripChat)
        Me.Controls.Add(Me.Panel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmChat"
        Me.Text = "frmChat"
        Me.ToolStripChat.ResumeLayout(False)
        Me.ToolStripChat.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.cmsHistoryChat.ResumeLayout(False)
        Me.cmsChat.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ToolStripChat As System.Windows.Forms.ToolStrip
    Friend WithEvents tsbFont As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbTakeScreenPicture As System.Windows.Forms.ToolStripButton
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btnSend As System.Windows.Forms.Button
    'Friend WithEvents rtbChat As System.Windows.Forms.RichTextBox
    Friend WithEvents rtbChat As Messager.Controls.ExRichTextBox
    'Friend WithEvents rtbHistoryChat As System.Windows.Forms.RichTextBox
    Friend WithEvents rtbHistoryChat As Messager.Controls.ExRichTextBox
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButtonAttact As System.Windows.Forms.ToolStripButton
    Friend WithEvents FontDialogChat As System.Windows.Forms.FontDialog
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents ToolStripLabel As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ofdSendFile As System.Windows.Forms.OpenFileDialog
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents ToolStripButtonBuzz As System.Windows.Forms.ToolStripButton
    Friend WithEvents lImages As System.Windows.Forms.ImageList

    Private tbar_SendMessage As System.Windows.Forms.ToolBar
    Private tbBtn_Emoticons As System.Windows.Forms.ToolBarButton
    Private cmenu_Emotions As System.Windows.Forms.ContextMenu
    Friend WithEvents cmsHistoryChat As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents CopyToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmsChat As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents CopyToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripClear As System.Windows.Forms.ToolStripButton
End Class
