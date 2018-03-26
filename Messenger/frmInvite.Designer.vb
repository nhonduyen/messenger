<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmInvite
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmInvite))
        Me.btnSend = New System.Windows.Forms.Button()
        Me.tbxNickName = New System.Windows.Forms.TextBox()
        Me.cbxInviteIp = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnSend
        '
        Me.btnSend.BackColor = System.Drawing.SystemColors.Highlight
        Me.btnSend.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSend.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.btnSend.Location = New System.Drawing.Point(259, 13)
        Me.btnSend.Name = "btnSend"
        Me.btnSend.Size = New System.Drawing.Size(66, 52)
        Me.btnSend.TabIndex = 7
        Me.btnSend.Text = "Send"
        Me.btnSend.UseVisualStyleBackColor = False
        '
        'tbxNickName
        '
        Me.tbxNickName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbxNickName.Location = New System.Drawing.Point(54, 43)
        Me.tbxNickName.Name = "tbxNickName"
        Me.tbxNickName.ReadOnly = True
        Me.tbxNickName.Size = New System.Drawing.Size(191, 22)
        Me.tbxNickName.TabIndex = 6
        '
        'cbxInviteIp
        '
        Me.cbxInviteIp.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbxInviteIp.FormattingEnabled = True
        Me.cbxInviteIp.Location = New System.Drawing.Point(54, 13)
        Me.cbxInviteIp.Name = "cbxInviteIp"
        Me.cbxInviteIp.Size = New System.Drawing.Size(191, 24)
        Me.cbxInviteIp.TabIndex = 5
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.SystemColors.Window
        Me.Label1.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label1.Location = New System.Drawing.Point(3, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(47, 13)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "IP        : "
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.SystemColors.Window
        Me.Label2.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label2.Location = New System.Drawing.Point(3, 48)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(47, 13)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "NAME : "
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.Window
        Me.Panel1.Controls.Add(Me.cbxInviteIp)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.tbxNickName)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.btnSend)
        Me.Panel1.Location = New System.Drawing.Point(3, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(335, 77)
        Me.Panel1.TabIndex = 10
        '
        'frmInvite
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BackColor = System.Drawing.SystemColors.Highlight
        Me.ClientSize = New System.Drawing.Size(342, 83)
        Me.Controls.Add(Me.Panel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmInvite"
        Me.Text = "Invite"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnSend As System.Windows.Forms.Button
    Friend WithEvents tbxNickName As System.Windows.Forms.TextBox
    Friend WithEvents cbxInviteIp As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
End Class
