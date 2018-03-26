<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSetting
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSetting))
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.tabUser = New System.Windows.Forms.TabPage()
        Me.btnAdmin = New System.Windows.Forms.Button()
        Me.btnUserOk = New System.Windows.Forms.Button()
        Me.btnUserCancel = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.tbxIpAddress = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.tbxNickName = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.tabProgram = New System.Windows.Forms.TabPage()
        Me.btnProOk = New System.Windows.Forms.Button()
        Me.btnProCancel = New System.Windows.Forms.Button()
        Me.grbReceiveFile = New System.Windows.Forms.GroupBox()
        Me.ckbRecvFile = New System.Windows.Forms.CheckBox()
        Me.btnBrowse = New System.Windows.Forms.Button()
        Me.tbxBrowse = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ckxSoundRecvMessage = New System.Windows.Forms.CheckBox()
        Me.ckxStartup = New System.Windows.Forms.CheckBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.cbxDept = New System.Windows.Forms.ComboBox()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.tbxFullName = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.tbxPhone = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.tbxMobile = New System.Windows.Forms.TextBox()
        Me.folderFilePath = New System.Windows.Forms.FolderBrowserDialog()
        Me.OpenFileIpUpdate = New System.Windows.Forms.OpenFileDialog()
        Me.TabControl1.SuspendLayout()
        Me.tabUser.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.tabProgram.SuspendLayout()
        Me.grbReceiveFile.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.tabUser)
        Me.TabControl1.Controls.Add(Me.tabProgram)
        Me.TabControl1.Location = New System.Drawing.Point(10, 12)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(352, 320)
        Me.TabControl1.TabIndex = 1
        '
        'tabUser
        '
        Me.tabUser.Controls.Add(Me.btnAdmin)
        Me.tabUser.Controls.Add(Me.btnUserOk)
        Me.tabUser.Controls.Add(Me.btnUserCancel)
        Me.tabUser.Controls.Add(Me.Label3)
        Me.tabUser.Controls.Add(Me.Panel2)
        Me.tabUser.Controls.Add(Me.Panel1)
        Me.tabUser.Controls.Add(Me.Label4)
        Me.tabUser.Location = New System.Drawing.Point(4, 22)
        Me.tabUser.Name = "tabUser"
        Me.tabUser.Padding = New System.Windows.Forms.Padding(3)
        Me.tabUser.Size = New System.Drawing.Size(344, 294)
        Me.tabUser.TabIndex = 0
        Me.tabUser.Text = "     User     "
        Me.tabUser.UseVisualStyleBackColor = True
        '
        'btnAdmin
        '
        Me.btnAdmin.BackColor = System.Drawing.SystemColors.Highlight
        Me.btnAdmin.ForeColor = System.Drawing.Color.White
        Me.btnAdmin.Location = New System.Drawing.Point(12, 260)
        Me.btnAdmin.Name = "btnAdmin"
        Me.btnAdmin.Size = New System.Drawing.Size(55, 23)
        Me.btnAdmin.TabIndex = 10
        Me.btnAdmin.Text = "Admin"
        Me.btnAdmin.UseVisualStyleBackColor = False
        '
        'btnUserOk
        '
        Me.btnUserOk.BackColor = System.Drawing.SystemColors.Highlight
        Me.btnUserOk.ForeColor = System.Drawing.Color.White
        Me.btnUserOk.Location = New System.Drawing.Point(203, 260)
        Me.btnUserOk.Name = "btnUserOk"
        Me.btnUserOk.Size = New System.Drawing.Size(55, 23)
        Me.btnUserOk.TabIndex = 9
        Me.btnUserOk.Text = "Ok"
        Me.btnUserOk.UseVisualStyleBackColor = False
        '
        'btnUserCancel
        '
        Me.btnUserCancel.BackColor = System.Drawing.SystemColors.Highlight
        Me.btnUserCancel.ForeColor = System.Drawing.Color.White
        Me.btnUserCancel.Location = New System.Drawing.Point(264, 260)
        Me.btnUserCancel.Name = "btnUserCancel"
        Me.btnUserCancel.Size = New System.Drawing.Size(55, 23)
        Me.btnUserCancel.TabIndex = 8
        Me.btnUserCancel.Text = "Cancel"
        Me.btnUserCancel.UseVisualStyleBackColor = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(13, 26)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(236, 13)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "application will update to all contacts on your list."
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.SystemColors.Highlight
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.tbxIpAddress)
        Me.Panel2.Controls.Add(Me.Label5)
        Me.Panel2.Location = New System.Drawing.Point(25, 84)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(307, 22)
        Me.Panel2.TabIndex = 6
        '
        'tbxIpAddress
        '
        Me.tbxIpAddress.BackColor = System.Drawing.Color.LightCyan
        Me.tbxIpAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbxIpAddress.Enabled = False
        Me.tbxIpAddress.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbxIpAddress.ForeColor = System.Drawing.Color.Blue
        Me.tbxIpAddress.Location = New System.Drawing.Point(83, -1)
        Me.tbxIpAddress.Name = "tbxIpAddress"
        Me.tbxIpAddress.Size = New System.Drawing.Size(223, 22)
        Me.tbxIpAddress.TabIndex = 1
        Me.tbxIpAddress.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(3, 2)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(64, 15)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Ip Address"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.Highlight
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.tbxNickName)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Location = New System.Drawing.Point(25, 54)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(307, 22)
        Me.Panel1.TabIndex = 5
        '
        'tbxNickName
        '
        Me.tbxNickName.BackColor = System.Drawing.Color.LightCyan
        Me.tbxNickName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbxNickName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbxNickName.ForeColor = System.Drawing.Color.Blue
        Me.tbxNickName.Location = New System.Drawing.Point(83, -1)
        Me.tbxNickName.Name = "tbxNickName"
        Me.tbxNickName.Size = New System.Drawing.Size(223, 22)
        Me.tbxNickName.TabIndex = 1
        Me.tbxNickName.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(3, 2)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(68, 15)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Nick Name"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 9)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(247, 13)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "You can change your nick name, after you change"
        '
        'tabProgram
        '
        Me.tabProgram.Controls.Add(Me.btnProOk)
        Me.tabProgram.Controls.Add(Me.btnProCancel)
        Me.tabProgram.Controls.Add(Me.grbReceiveFile)
        Me.tabProgram.Controls.Add(Me.ckxSoundRecvMessage)
        Me.tabProgram.Controls.Add(Me.ckxStartup)
        Me.tabProgram.Location = New System.Drawing.Point(4, 22)
        Me.tabProgram.Name = "tabProgram"
        Me.tabProgram.Padding = New System.Windows.Forms.Padding(3)
        Me.tabProgram.Size = New System.Drawing.Size(344, 294)
        Me.tabProgram.TabIndex = 1
        Me.tabProgram.Text = "  Program  "
        Me.tabProgram.UseVisualStyleBackColor = True
        '
        'btnProOk
        '
        Me.btnProOk.BackColor = System.Drawing.SystemColors.Highlight
        Me.btnProOk.ForeColor = System.Drawing.Color.White
        Me.btnProOk.Location = New System.Drawing.Point(222, 152)
        Me.btnProOk.Name = "btnProOk"
        Me.btnProOk.Size = New System.Drawing.Size(55, 23)
        Me.btnProOk.TabIndex = 11
        Me.btnProOk.Text = "Ok"
        Me.btnProOk.UseVisualStyleBackColor = False
        '
        'btnProCancel
        '
        Me.btnProCancel.BackColor = System.Drawing.SystemColors.Highlight
        Me.btnProCancel.ForeColor = System.Drawing.Color.White
        Me.btnProCancel.Location = New System.Drawing.Point(283, 152)
        Me.btnProCancel.Name = "btnProCancel"
        Me.btnProCancel.Size = New System.Drawing.Size(55, 23)
        Me.btnProCancel.TabIndex = 10
        Me.btnProCancel.Text = "Cancel"
        Me.btnProCancel.UseVisualStyleBackColor = False
        '
        'grbReceiveFile
        '
        Me.grbReceiveFile.Controls.Add(Me.ckbRecvFile)
        Me.grbReceiveFile.Controls.Add(Me.btnBrowse)
        Me.grbReceiveFile.Controls.Add(Me.tbxBrowse)
        Me.grbReceiveFile.Controls.Add(Me.Label1)
        Me.grbReceiveFile.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grbReceiveFile.Location = New System.Drawing.Point(6, 62)
        Me.grbReceiveFile.Name = "grbReceiveFile"
        Me.grbReceiveFile.Size = New System.Drawing.Size(335, 84)
        Me.grbReceiveFile.TabIndex = 2
        Me.grbReceiveFile.TabStop = False
        Me.grbReceiveFile.Text = "Receive File"
        '
        'ckbRecvFile
        '
        Me.ckbRecvFile.AutoSize = True
        Me.ckbRecvFile.Checked = True
        Me.ckbRecvFile.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ckbRecvFile.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckbRecvFile.Location = New System.Drawing.Point(13, 57)
        Me.ckbRecvFile.Name = "ckbRecvFile"
        Me.ckbRecvFile.Size = New System.Drawing.Size(120, 19)
        Me.ckbRecvFile.TabIndex = 12
        Me.ckbRecvFile.Text = "Auto Receive File"
        Me.ckbRecvFile.UseVisualStyleBackColor = True
        '
        'btnBrowse
        '
        Me.btnBrowse.Location = New System.Drawing.Point(263, 26)
        Me.btnBrowse.Name = "btnBrowse"
        Me.btnBrowse.Size = New System.Drawing.Size(57, 23)
        Me.btnBrowse.TabIndex = 2
        Me.btnBrowse.Text = "Browse"
        Me.btnBrowse.UseVisualStyleBackColor = True
        '
        'tbxBrowse
        '
        Me.tbxBrowse.Location = New System.Drawing.Point(68, 27)
        Me.tbxBrowse.Name = "tbxBrowse"
        Me.tbxBrowse.ReadOnly = True
        Me.tbxBrowse.Size = New System.Drawing.Size(184, 21)
        Me.tbxBrowse.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(7, 28)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(54, 15)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "File path"
        '
        'ckxSoundRecvMessage
        '
        Me.ckxSoundRecvMessage.AutoSize = True
        Me.ckxSoundRecvMessage.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckxSoundRecvMessage.Location = New System.Drawing.Point(19, 39)
        Me.ckxSoundRecvMessage.Name = "ckxSoundRecvMessage"
        Me.ckxSoundRecvMessage.Size = New System.Drawing.Size(191, 19)
        Me.ckxSoundRecvMessage.TabIndex = 1
        Me.ckxSoundRecvMessage.Text = "Sound when receive message"
        Me.ckxSoundRecvMessage.UseVisualStyleBackColor = True
        '
        'ckxStartup
        '
        Me.ckxStartup.AutoSize = True
        Me.ckxStartup.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckxStartup.Location = New System.Drawing.Point(19, 16)
        Me.ckxStartup.Name = "ckxStartup"
        Me.ckxStartup.Size = New System.Drawing.Size(155, 19)
        Me.ckxStartup.TabIndex = 0
        Me.ckxStartup.Text = "Run at Windows startup"
        Me.ckxStartup.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.White
        Me.GroupBox1.Controls.Add(Me.Panel6)
        Me.GroupBox1.Controls.Add(Me.Panel3)
        Me.GroupBox1.Controls.Add(Me.Panel4)
        Me.GroupBox1.Controls.Add(Me.Panel5)
        Me.GroupBox1.Location = New System.Drawing.Point(18, 151)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(338, 134)
        Me.GroupBox1.TabIndex = 16
        Me.GroupBox1.TabStop = False
        '
        'Panel6
        '
        Me.Panel6.BackColor = System.Drawing.SystemColors.Highlight
        Me.Panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel6.Controls.Add(Me.Label9)
        Me.Panel6.Controls.Add(Me.cbxDept)
        Me.Panel6.Location = New System.Drawing.Point(20, 103)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(184, 22)
        Me.Panel6.TabIndex = 15
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(3, 2)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(33, 15)
        Me.Label9.TabIndex = 0
        Me.Label9.Text = "Dept"
        '
        'cbxDept
        '
        Me.cbxDept.DisplayMember = "OTHER"
        Me.cbxDept.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxDept.FormattingEnabled = True
        Me.cbxDept.Items.AddRange(New Object() {"OTHER", "ICT", "ACCOUTING", "GA", "HR", "LOGISTICS", "MAINTENANCE", "PRD_SCRAP", "PROD_SHIPPING_YARD", "PROD_QUANLITY", "PRODUCTION", "PRODUCTION_1", "PRODUCTION_2", "PURCHASE", "SAFETY", "FACTORY_#1", "FACTORY_#2"})
        Me.cbxDept.Location = New System.Drawing.Point(83, 0)
        Me.cbxDept.Name = "cbxDept"
        Me.cbxDept.Size = New System.Drawing.Size(99, 21)
        Me.cbxDept.TabIndex = 15
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.SystemColors.Highlight
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.tbxFullName)
        Me.Panel3.Controls.Add(Me.Label6)
        Me.Panel3.Location = New System.Drawing.Point(21, 17)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(307, 22)
        Me.Panel3.TabIndex = 12
        '
        'tbxFullName
        '
        Me.tbxFullName.BackColor = System.Drawing.Color.LightCyan
        Me.tbxFullName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbxFullName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbxFullName.ForeColor = System.Drawing.Color.Blue
        Me.tbxFullName.Location = New System.Drawing.Point(83, -1)
        Me.tbxFullName.Name = "tbxFullName"
        Me.tbxFullName.Size = New System.Drawing.Size(223, 22)
        Me.tbxFullName.TabIndex = 1
        Me.tbxFullName.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(3, 2)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(64, 15)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Full Name"
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.SystemColors.Highlight
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel4.Controls.Add(Me.tbxPhone)
        Me.Panel4.Controls.Add(Me.Label7)
        Me.Panel4.Location = New System.Drawing.Point(20, 45)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(307, 22)
        Me.Panel4.TabIndex = 13
        '
        'tbxPhone
        '
        Me.tbxPhone.BackColor = System.Drawing.Color.LightCyan
        Me.tbxPhone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbxPhone.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbxPhone.ForeColor = System.Drawing.Color.Blue
        Me.tbxPhone.Location = New System.Drawing.Point(83, -1)
        Me.tbxPhone.Name = "tbxPhone"
        Me.tbxPhone.Size = New System.Drawing.Size(223, 22)
        Me.tbxPhone.TabIndex = 1
        Me.tbxPhone.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(3, 2)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(43, 15)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "Phone"
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.SystemColors.Highlight
        Me.Panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel5.Controls.Add(Me.Label8)
        Me.Panel5.Controls.Add(Me.tbxMobile)
        Me.Panel5.Location = New System.Drawing.Point(20, 74)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(307, 22)
        Me.Panel5.TabIndex = 14
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(3, 2)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(45, 15)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "Mobile"
        '
        'tbxMobile
        '
        Me.tbxMobile.BackColor = System.Drawing.Color.LightCyan
        Me.tbxMobile.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbxMobile.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbxMobile.ForeColor = System.Drawing.Color.Blue
        Me.tbxMobile.Location = New System.Drawing.Point(83, -1)
        Me.tbxMobile.Name = "tbxMobile"
        Me.tbxMobile.Size = New System.Drawing.Size(223, 22)
        Me.tbxMobile.TabIndex = 1
        Me.tbxMobile.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'frmSetting
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ClientSize = New System.Drawing.Size(369, 338)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.TabControl1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSetting"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Setting"
        Me.TabControl1.ResumeLayout(False)
        Me.tabUser.ResumeLayout(False)
        Me.tabUser.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.tabProgram.ResumeLayout(False)
        Me.tabProgram.PerformLayout()
        Me.grbReceiveFile.ResumeLayout(False)
        Me.grbReceiveFile.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.Panel6.ResumeLayout(False)
        Me.Panel6.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents tabUser As System.Windows.Forms.TabPage
    Friend WithEvents btnUserOk As System.Windows.Forms.Button
    Friend WithEvents btnUserCancel As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents tbxIpAddress As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents tbxNickName As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents tabProgram As System.Windows.Forms.TabPage
    Friend WithEvents btnProOk As System.Windows.Forms.Button
    Friend WithEvents btnProCancel As System.Windows.Forms.Button
    Friend WithEvents grbReceiveFile As System.Windows.Forms.GroupBox
    Friend WithEvents btnBrowse As System.Windows.Forms.Button
    Friend WithEvents tbxBrowse As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ckxSoundRecvMessage As System.Windows.Forms.CheckBox
    Friend WithEvents ckxStartup As System.Windows.Forms.CheckBox
    Friend WithEvents folderFilePath As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents OpenFileIpUpdate As System.Windows.Forms.OpenFileDialog
    Friend WithEvents ckbRecvFile As System.Windows.Forms.CheckBox
    Friend WithEvents btnAdmin As System.Windows.Forms.Button
    Friend WithEvents cbxDept As System.Windows.Forms.ComboBox
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents tbxMobile As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents tbxPhone As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents tbxFullName As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
End Class
