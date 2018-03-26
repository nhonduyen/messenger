<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
    'Me.Hide()
    'Me.NotifyIcon.Text = "Form1 is running in the background"
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
        Dim NotifyIcon As System.Windows.Forms.NotifyIcon
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Dim TreeNode1 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("All Contact")
        Me.ContextMenuStripNotify = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.MessagerToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.SettingToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SendRecvFileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ConnectToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.tabContact = New System.Windows.Forms.TabControl()
        Me.tabMyContact = New System.Windows.Forms.TabPage()
        Me.btnAddContact = New System.Windows.Forms.Button()
        Me.btnConnect = New System.Windows.Forms.Button()
        Me.tYourContact = New System.Windows.Forms.TreeView()
        Me.tabAllContact = New System.Windows.Forms.TabPage()
        Me.tAllContacts = New System.Windows.Forms.TreeView()
        Me.deptContact = New System.Windows.Forms.TabPage()
        Me.tDeptContacts = New System.Windows.Forms.TreeView()
        Me.llblSetting = New System.Windows.Forms.LinkLabel()
        Me.images = New System.Windows.Forms.ImageList(Me.components)
        Me.ContextMenuStripMyContact = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ChatToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SendFileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MoveToGroupToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RenameGroupToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NewGroupToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ContextMenuStripAllContact = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.Chat = New System.Windows.Forms.ToolStripMenuItem()
        Me.SendFile = New System.Windows.Forms.ToolStripMenuItem()
        Me.AddToMyContact = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStripHeader = New System.Windows.Forms.MenuStrip()
        Me.MessagerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OnOffList = New System.Windows.Forms.ToolStripMenuItem()
        Me.ChatGroupToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.About = New System.Windows.Forms.ToolStripMenuItem()
        Me.Help = New System.Windows.Forms.ToolStripMenuItem()
        Me.tbxSearch = New System.Windows.Forms.TextBox()
        Me.ofdSendFile = New System.Windows.Forms.OpenFileDialog()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.tmr = New System.Windows.Forms.Timer(Me.components)
        Me.btnCheckUpdate = New System.Windows.Forms.Button()
        Me.ContextMenuStripDeptContact = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.SendMessageToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SendFileToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        NotifyIcon = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.ContextMenuStripNotify.SuspendLayout()
        Me.tabContact.SuspendLayout()
        Me.tabMyContact.SuspendLayout()
        Me.tabAllContact.SuspendLayout()
        Me.deptContact.SuspendLayout()
        Me.ContextMenuStripMyContact.SuspendLayout()
        Me.ContextMenuStripAllContact.SuspendLayout()
        Me.MenuStripHeader.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStripDeptContact.SuspendLayout()
        Me.SuspendLayout()
        '
        'NotifyIcon
        '
        NotifyIcon.ContextMenuStrip = Me.ContextMenuStripNotify
        NotifyIcon.Icon = CType(resources.GetObject("NotifyIcon.Icon"), System.Drawing.Icon)
        NotifyIcon.Text = "Messenger"
        NotifyIcon.Visible = True
        AddHandler NotifyIcon.MouseClick, AddressOf Me.NotifyIcon_MouseClick
        '
        'ContextMenuStripNotify
        '
        Me.ContextMenuStripNotify.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MessagerToolStripMenuItem1, Me.SettingToolStripMenuItem, Me.SendRecvFileToolStripMenuItem, Me.ConnectToolStripMenuItem, Me.ToolStripSeparator1, Me.ExitToolStripMenuItem})
        Me.ContextMenuStripNotify.Name = "ContextMenuStripNotify"
        Me.ContextMenuStripNotify.Size = New System.Drawing.Size(150, 120)
        '
        'MessagerToolStripMenuItem1
        '
        Me.MessagerToolStripMenuItem1.Name = "MessagerToolStripMenuItem1"
        Me.MessagerToolStripMenuItem1.Size = New System.Drawing.Size(149, 22)
        Me.MessagerToolStripMenuItem1.Text = "Messager"
        '
        'SettingToolStripMenuItem
        '
        Me.SettingToolStripMenuItem.Name = "SettingToolStripMenuItem"
        Me.SettingToolStripMenuItem.Size = New System.Drawing.Size(149, 22)
        Me.SettingToolStripMenuItem.Text = "Setting"
        '
        'SendRecvFileToolStripMenuItem
        '
        Me.SendRecvFileToolStripMenuItem.Name = "SendRecvFileToolStripMenuItem"
        Me.SendRecvFileToolStripMenuItem.Size = New System.Drawing.Size(149, 22)
        Me.SendRecvFileToolStripMenuItem.Text = "Send Recv File"
        '
        'ConnectToolStripMenuItem
        '
        Me.ConnectToolStripMenuItem.Name = "ConnectToolStripMenuItem"
        Me.ConnectToolStripMenuItem.Size = New System.Drawing.Size(149, 22)
        Me.ConnectToolStripMenuItem.Text = "Connect"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(146, 6)
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(149, 22)
        Me.ExitToolStripMenuItem.Text = "Exit"
        '
        'tabContact
        '
        Me.tabContact.AccessibleRole = System.Windows.Forms.AccessibleRole.None
        Me.tabContact.Alignment = System.Windows.Forms.TabAlignment.Bottom
        Me.tabContact.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tabContact.Controls.Add(Me.tabMyContact)
        Me.tabContact.Controls.Add(Me.tabAllContact)
        Me.tabContact.Controls.Add(Me.deptContact)
        Me.tabContact.Location = New System.Drawing.Point(-4, 83)
        Me.tabContact.Multiline = True
        Me.tabContact.Name = "tabContact"
        Me.tabContact.SelectedIndex = 0
        Me.tabContact.Size = New System.Drawing.Size(238, 381)
        Me.tabContact.TabIndex = 3
        '
        'tabMyContact
        '
        Me.tabMyContact.BackColor = System.Drawing.SystemColors.Control
        Me.tabMyContact.Controls.Add(Me.btnAddContact)
        Me.tabMyContact.Controls.Add(Me.btnConnect)
        Me.tabMyContact.Controls.Add(Me.tYourContact)
        Me.tabMyContact.Location = New System.Drawing.Point(4, 4)
        Me.tabMyContact.Name = "tabMyContact"
        Me.tabMyContact.Padding = New System.Windows.Forms.Padding(3)
        Me.tabMyContact.Size = New System.Drawing.Size(230, 355)
        Me.tabMyContact.TabIndex = 0
        Me.tabMyContact.Text = "  My Contact  "
        '
        'btnAddContact
        '
        Me.btnAddContact.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnAddContact.FlatAppearance.BorderSize = 0
        Me.btnAddContact.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAddContact.Image = CType(resources.GetObject("btnAddContact.Image"), System.Drawing.Image)
        Me.btnAddContact.Location = New System.Drawing.Point(5, 323)
        Me.btnAddContact.Name = "btnAddContact"
        Me.btnAddContact.Size = New System.Drawing.Size(106, 26)
        Me.btnAddContact.TabIndex = 4
        Me.btnAddContact.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAddContact.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnAddContact.UseVisualStyleBackColor = True
        '
        'btnConnect
        '
        Me.btnConnect.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnConnect.FlatAppearance.BorderSize = 0
        Me.btnConnect.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnConnect.Image = CType(resources.GetObject("btnConnect.Image"), System.Drawing.Image)
        Me.btnConnect.Location = New System.Drawing.Point(119, 323)
        Me.btnConnect.Name = "btnConnect"
        Me.btnConnect.Size = New System.Drawing.Size(106, 26)
        Me.btnConnect.TabIndex = 5
        Me.btnConnect.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnConnect.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnConnect.UseVisualStyleBackColor = True
        '
        'tYourContact
        '
        Me.tYourContact.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tYourContact.BackColor = System.Drawing.SystemColors.Control
        Me.tYourContact.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.tYourContact.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tYourContact.Location = New System.Drawing.Point(4, 13)
        Me.tYourContact.Name = "tYourContact"
        Me.tYourContact.ShowNodeToolTips = True
        Me.tYourContact.Size = New System.Drawing.Size(217, 295)
        Me.tYourContact.TabIndex = 0
        '
        'tabAllContact
        '
        Me.tabAllContact.BackColor = System.Drawing.SystemColors.Control
        Me.tabAllContact.Controls.Add(Me.tAllContacts)
        Me.tabAllContact.Location = New System.Drawing.Point(4, 4)
        Me.tabAllContact.Name = "tabAllContact"
        Me.tabAllContact.Padding = New System.Windows.Forms.Padding(3)
        Me.tabAllContact.Size = New System.Drawing.Size(230, 355)
        Me.tabAllContact.TabIndex = 1
        Me.tabAllContact.Text = "  All Contact  "
        '
        'tAllContacts
        '
        Me.tAllContacts.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tAllContacts.BackColor = System.Drawing.SystemColors.Control
        Me.tAllContacts.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.tAllContacts.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tAllContacts.Location = New System.Drawing.Point(4, 15)
        Me.tAllContacts.Name = "tAllContacts"
        TreeNode1.Name = "nAllContact"
        TreeNode1.NodeFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        TreeNode1.Text = "All Contact"
        Me.tAllContacts.Nodes.AddRange(New System.Windows.Forms.TreeNode() {TreeNode1})
        Me.tAllContacts.ShowNodeToolTips = True
        Me.tAllContacts.Size = New System.Drawing.Size(221, 314)
        Me.tAllContacts.TabIndex = 1
        '
        'deptContact
        '
        Me.deptContact.BackColor = System.Drawing.SystemColors.Control
        Me.deptContact.Controls.Add(Me.tDeptContacts)
        Me.deptContact.Location = New System.Drawing.Point(4, 4)
        Me.deptContact.Name = "deptContact"
        Me.deptContact.Padding = New System.Windows.Forms.Padding(3)
        Me.deptContact.Size = New System.Drawing.Size(230, 355)
        Me.deptContact.TabIndex = 2
        Me.deptContact.Text = " Dept Contact"
        '
        'tDeptContacts
        '
        Me.tDeptContacts.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tDeptContacts.BackColor = System.Drawing.SystemColors.Control
        Me.tDeptContacts.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.tDeptContacts.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tDeptContacts.Location = New System.Drawing.Point(6, 6)
        Me.tDeptContacts.Name = "tDeptContacts"
        Me.tDeptContacts.ShowNodeToolTips = True
        Me.tDeptContacts.Size = New System.Drawing.Size(217, 336)
        Me.tDeptContacts.TabIndex = 1
        '
        'llblSetting
        '
        Me.llblSetting.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.llblSetting.AutoSize = True
        Me.llblSetting.BackColor = System.Drawing.Color.Transparent
        Me.llblSetting.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.llblSetting.ForeColor = System.Drawing.Color.Black
        Me.llblSetting.LinkColor = System.Drawing.Color.Black
        Me.llblSetting.Location = New System.Drawing.Point(18, 58)
        Me.llblSetting.Name = "llblSetting"
        Me.llblSetting.Size = New System.Drawing.Size(72, 16)
        Me.llblSetting.TabIndex = 4
        Me.llblSetting.TabStop = True
        Me.llblSetting.Text = " << Setting "
        '
        'images
        '
        Me.images.ImageStream = CType(resources.GetObject("images.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.images.TransparentColor = System.Drawing.Color.Transparent
        Me.images.Images.SetKeyName(0, "offline.ico")
        Me.images.Images.SetKeyName(1, "online.ico")
        Me.images.Images.SetKeyName(2, "none.ico")
        '
        'ContextMenuStripMyContact
        '
        Me.ContextMenuStripMyContact.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ChatToolStripMenuItem, Me.SendFileToolStripMenuItem, Me.DeleteToolStripMenuItem, Me.MoveToGroupToolStripMenuItem, Me.RenameGroupToolStripMenuItem, Me.NewGroupToolStripMenuItem})
        Me.ContextMenuStripMyContact.Name = "ContextMenuStripMyContact"
        Me.ContextMenuStripMyContact.Size = New System.Drawing.Size(158, 136)
        '
        'ChatToolStripMenuItem
        '
        Me.ChatToolStripMenuItem.Name = "ChatToolStripMenuItem"
        Me.ChatToolStripMenuItem.Size = New System.Drawing.Size(157, 22)
        Me.ChatToolStripMenuItem.Text = "Send Message"
        '
        'SendFileToolStripMenuItem
        '
        Me.SendFileToolStripMenuItem.Name = "SendFileToolStripMenuItem"
        Me.SendFileToolStripMenuItem.Size = New System.Drawing.Size(157, 22)
        Me.SendFileToolStripMenuItem.Text = "Send File"
        '
        'DeleteToolStripMenuItem
        '
        Me.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem"
        Me.DeleteToolStripMenuItem.Size = New System.Drawing.Size(157, 22)
        Me.DeleteToolStripMenuItem.Text = "Delete"
        '
        'MoveToGroupToolStripMenuItem
        '
        Me.MoveToGroupToolStripMenuItem.Name = "MoveToGroupToolStripMenuItem"
        Me.MoveToGroupToolStripMenuItem.Size = New System.Drawing.Size(157, 22)
        Me.MoveToGroupToolStripMenuItem.Text = "Move To Group"
        '
        'RenameGroupToolStripMenuItem
        '
        Me.RenameGroupToolStripMenuItem.Name = "RenameGroupToolStripMenuItem"
        Me.RenameGroupToolStripMenuItem.Size = New System.Drawing.Size(157, 22)
        Me.RenameGroupToolStripMenuItem.Text = "Rename Group"
        '
        'NewGroupToolStripMenuItem
        '
        Me.NewGroupToolStripMenuItem.Name = "NewGroupToolStripMenuItem"
        Me.NewGroupToolStripMenuItem.Size = New System.Drawing.Size(157, 22)
        Me.NewGroupToolStripMenuItem.Text = "New Group"
        '
        'ContextMenuStripAllContact
        '
        Me.ContextMenuStripAllContact.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Chat, Me.SendFile, Me.AddToMyContact})
        Me.ContextMenuStripAllContact.Name = "ContextMenuStripAllContact"
        Me.ContextMenuStripAllContact.Size = New System.Drawing.Size(179, 70)
        '
        'Chat
        '
        Me.Chat.Name = "Chat"
        Me.Chat.Size = New System.Drawing.Size(178, 22)
        Me.Chat.Text = "Send Message"
        '
        'SendFile
        '
        Me.SendFile.Name = "SendFile"
        Me.SendFile.Size = New System.Drawing.Size(178, 22)
        Me.SendFile.Text = "Send File"
        '
        'AddToMyContact
        '
        Me.AddToMyContact.Name = "AddToMyContact"
        Me.AddToMyContact.Size = New System.Drawing.Size(178, 22)
        Me.AddToMyContact.Text = "Add To My Contact"
        '
        'MenuStripHeader
        '
        Me.MenuStripHeader.AutoSize = False
        Me.MenuStripHeader.BackColor = System.Drawing.Color.Transparent
        Me.MenuStripHeader.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MessagerToolStripMenuItem, Me.HelpToolStripMenuItem})
        Me.MenuStripHeader.Location = New System.Drawing.Point(0, 0)
        Me.MenuStripHeader.Name = "MenuStripHeader"
        Me.MenuStripHeader.Size = New System.Drawing.Size(234, 30)
        Me.MenuStripHeader.TabIndex = 5
        Me.MenuStripHeader.Text = "MenuStrip1"
        '
        'MessagerToolStripMenuItem
        '
        Me.MessagerToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OnOffList, Me.ChatGroupToolStripMenuItem})
        Me.MessagerToolStripMenuItem.ForeColor = System.Drawing.Color.Black
        Me.MessagerToolStripMenuItem.Name = "MessagerToolStripMenuItem"
        Me.MessagerToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.M), System.Windows.Forms.Keys)
        Me.MessagerToolStripMenuItem.Size = New System.Drawing.Size(69, 26)
        Me.MessagerToolStripMenuItem.Text = "Messager"
        '
        'OnOffList
        '
        Me.OnOffList.ForeColor = System.Drawing.Color.Black
        Me.OnOffList.Name = "OnOffList"
        Me.OnOffList.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.F), System.Windows.Forms.Keys)
        Me.OnOffList.Size = New System.Drawing.Size(177, 22)
        Me.OnOffList.Text = "Online List"
        '
        'ChatGroupToolStripMenuItem
        '
        Me.ChatGroupToolStripMenuItem.Name = "ChatGroupToolStripMenuItem"
        Me.ChatGroupToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.G), System.Windows.Forms.Keys)
        Me.ChatGroupToolStripMenuItem.Size = New System.Drawing.Size(177, 22)
        Me.ChatGroupToolStripMenuItem.Text = "Chat Group"
        '
        'HelpToolStripMenuItem
        '
        Me.HelpToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.About, Me.Help})
        Me.HelpToolStripMenuItem.ForeColor = System.Drawing.Color.Black
        Me.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
        Me.HelpToolStripMenuItem.Size = New System.Drawing.Size(44, 26)
        Me.HelpToolStripMenuItem.Text = "Help"
        '
        'About
        '
        Me.About.Name = "About"
        Me.About.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.F11), System.Windows.Forms.Keys)
        Me.About.Size = New System.Drawing.Size(191, 22)
        Me.About.Text = "About"
        '
        'Help
        '
        Me.Help.Name = "Help"
        Me.Help.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.F12), System.Windows.Forms.Keys)
        Me.Help.Size = New System.Drawing.Size(191, 22)
        Me.Help.Text = "How to use?"
        '
        'tbxSearch
        '
        Me.tbxSearch.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbxSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbxSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbxSearch.Location = New System.Drawing.Point(115, 57)
        Me.tbxSearch.Name = "tbxSearch"
        Me.tbxSearch.Size = New System.Drawing.Size(115, 22)
        Me.tbxSearch.TabIndex = 6
        '
        'ofdSendFile
        '
        Me.ofdSendFile.Multiselect = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox1.BackgroundImage = CType(resources.GetObject("PictureBox1.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox1.Location = New System.Drawing.Point(0, 464)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(234, 47)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 6
        Me.PictureBox1.TabStop = False
        '
        'tmr
        '
        Me.tmr.Interval = 15000
        '
        'btnCheckUpdate
        '
        Me.btnCheckUpdate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCheckUpdate.BackColor = System.Drawing.Color.Transparent
        Me.btnCheckUpdate.BackgroundImage = Global.Messenger.My.Resources.Resources.bells
        Me.btnCheckUpdate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnCheckUpdate.FlatAppearance.BorderSize = 0
        Me.btnCheckUpdate.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.MenuHighlight
        Me.btnCheckUpdate.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.MenuHighlight
        Me.btnCheckUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCheckUpdate.ForeColor = System.Drawing.Color.Black
        Me.btnCheckUpdate.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCheckUpdate.Location = New System.Drawing.Point(155, 7)
        Me.btnCheckUpdate.Name = "btnCheckUpdate"
        Me.btnCheckUpdate.Size = New System.Drawing.Size(70, 26)
        Me.btnCheckUpdate.TabIndex = 7
        Me.btnCheckUpdate.Text = "Update"
        Me.btnCheckUpdate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCheckUpdate.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnCheckUpdate.UseVisualStyleBackColor = False
        Me.btnCheckUpdate.Visible = False
        '
        'ContextMenuStripDeptContact
        '
        Me.ContextMenuStripDeptContact.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SendMessageToolStripMenuItem, Me.SendFileToolStripMenuItem1})
        Me.ContextMenuStripDeptContact.Name = "ContextMenuStripDeptContact"
        Me.ContextMenuStripDeptContact.Size = New System.Drawing.Size(150, 48)
        '
        'SendMessageToolStripMenuItem
        '
        Me.SendMessageToolStripMenuItem.Name = "SendMessageToolStripMenuItem"
        Me.SendMessageToolStripMenuItem.Size = New System.Drawing.Size(149, 22)
        Me.SendMessageToolStripMenuItem.Text = "Send Message"
        '
        'SendFileToolStripMenuItem1
        '
        Me.SendFileToolStripMenuItem1.Name = "SendFileToolStripMenuItem1"
        Me.SendFileToolStripMenuItem1.Size = New System.Drawing.Size(149, 22)
        Me.SendFileToolStripMenuItem1.Text = "Send File"
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.Messenger.My.Resources.Resources.main
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(234, 502)
        Me.Controls.Add(Me.btnCheckUpdate)
        Me.Controls.Add(Me.llblSetting)
        Me.Controls.Add(Me.tbxSearch)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.MenuStripHeader)
        Me.Controls.Add(Me.tabContact)
        Me.DoubleBuffered = True
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStripHeader
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmMain"
        Me.ShowInTaskbar = True
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Messenger"
        Me.ContextMenuStripNotify.ResumeLayout(False)
        Me.tabContact.ResumeLayout(False)
        Me.tabMyContact.ResumeLayout(False)
        Me.tabAllContact.ResumeLayout(False)
        Me.deptContact.ResumeLayout(False)
        Me.ContextMenuStripMyContact.ResumeLayout(False)
        Me.ContextMenuStripAllContact.ResumeLayout(False)
        Me.MenuStripHeader.ResumeLayout(False)
        Me.MenuStripHeader.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStripDeptContact.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tabContact As System.Windows.Forms.TabControl
    Friend WithEvents tabMyContact As System.Windows.Forms.TabPage
    Friend WithEvents btnConnect As System.Windows.Forms.Button
    Friend WithEvents btnAddContact As System.Windows.Forms.Button
    Friend WithEvents tYourContact As System.Windows.Forms.TreeView
    Friend WithEvents tabAllContact As System.Windows.Forms.TabPage
    Friend WithEvents tAllContacts As System.Windows.Forms.TreeView
    Friend WithEvents llblSetting As System.Windows.Forms.LinkLabel
    Friend WithEvents images As System.Windows.Forms.ImageList
    Friend WithEvents ContextMenuStripMyContact As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ChatToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SendFileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeleteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MoveToGroupToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RenameGroupToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NewGroupToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ContextMenuStripAllContact As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents Chat As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SendFile As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AddToMyContact As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuStripHeader As System.Windows.Forms.MenuStrip
    Friend WithEvents MessagerToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OnOffList As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HelpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tbxSearch As System.Windows.Forms.TextBox
    Friend WithEvents ContextMenuStripNotify As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents MessagerToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SettingToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SendRecvFileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ConnectToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ofdSendFile As System.Windows.Forms.OpenFileDialog
    Friend WithEvents About As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Help As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents ChatGroupToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tmr As System.Windows.Forms.Timer
    Friend WithEvents btnCheckUpdate As System.Windows.Forms.Button
    Friend WithEvents deptContact As System.Windows.Forms.TabPage
    Friend WithEvents tDeptContacts As System.Windows.Forms.TreeView
    Friend WithEvents ContextMenuStripDeptContact As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents SendMessageToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SendFileToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem

End Class
