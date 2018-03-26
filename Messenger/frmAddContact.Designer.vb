<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAddContact
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAddContact))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tbxIp = New System.Windows.Forms.TextBox()
        Me.tbxName = New System.Windows.Forms.TextBox()
        Me.cbxGroups = New System.Windows.Forms.ComboBox()
        Me.btnNewGroup = New System.Windows.Forms.Button()
        Me.lblIp = New System.Windows.Forms.Label()
        Me.lblName = New System.Windows.Forms.Label()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnOk = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.SystemColors.Highlight
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(28, 75)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(58, 16)
        Me.Label1.TabIndex = 18
        Me.Label1.Text = "Groups  "
        '
        'tbxIp
        '
        Me.tbxIp.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.tbxIp.ForeColor = System.Drawing.Color.Blue
        Me.tbxIp.Location = New System.Drawing.Point(86, 46)
        Me.tbxIp.Name = "tbxIp"
        Me.tbxIp.Size = New System.Drawing.Size(174, 20)
        Me.tbxIp.TabIndex = 17
        '
        'tbxName
        '
        Me.tbxName.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.tbxName.ForeColor = System.Drawing.Color.Blue
        Me.tbxName.Location = New System.Drawing.Point(86, 21)
        Me.tbxName.Name = "tbxName"
        Me.tbxName.Size = New System.Drawing.Size(174, 20)
        Me.tbxName.TabIndex = 16
        '
        'cbxGroups
        '
        Me.cbxGroups.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cbxGroups.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbxGroups.ForeColor = System.Drawing.Color.Blue
        Me.cbxGroups.FormattingEnabled = True
        Me.cbxGroups.Location = New System.Drawing.Point(86, 72)
        Me.cbxGroups.Name = "cbxGroups"
        Me.cbxGroups.Size = New System.Drawing.Size(93, 24)
        Me.cbxGroups.TabIndex = 15
        '
        'btnNewGroup
        '
        Me.btnNewGroup.BackColor = System.Drawing.SystemColors.Highlight
        Me.btnNewGroup.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnNewGroup.ForeColor = System.Drawing.Color.White
        Me.btnNewGroup.Location = New System.Drawing.Point(185, 71)
        Me.btnNewGroup.Name = "btnNewGroup"
        Me.btnNewGroup.Size = New System.Drawing.Size(75, 26)
        Me.btnNewGroup.TabIndex = 14
        Me.btnNewGroup.Text = "New Group"
        Me.btnNewGroup.UseVisualStyleBackColor = False
        '
        'lblIp
        '
        Me.lblIp.AutoSize = True
        Me.lblIp.BackColor = System.Drawing.SystemColors.Highlight
        Me.lblIp.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIp.ForeColor = System.Drawing.Color.White
        Me.lblIp.Location = New System.Drawing.Point(28, 47)
        Me.lblIp.Name = "lblIp"
        Me.lblIp.Size = New System.Drawing.Size(65, 16)
        Me.lblIp.TabIndex = 13
        Me.lblIp.Text = "IP              :"
        '
        'lblName
        '
        Me.lblName.AutoSize = True
        Me.lblName.BackColor = System.Drawing.SystemColors.Highlight
        Me.lblName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblName.ForeColor = System.Drawing.Color.White
        Me.lblName.Location = New System.Drawing.Point(28, 22)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(66, 16)
        Me.lblName.TabIndex = 12
        Me.lblName.Text = "Name      :"
        '
        'btnCancel
        '
        Me.btnCancel.BackColor = System.Drawing.SystemColors.Highlight
        Me.btnCancel.ForeColor = System.Drawing.Color.White
        Me.btnCancel.Location = New System.Drawing.Point(166, 110)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(98, 30)
        Me.btnCancel.TabIndex = 11
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'btnOk
        '
        Me.btnOk.BackColor = System.Drawing.SystemColors.Highlight
        Me.btnOk.ForeColor = System.Drawing.Color.White
        Me.btnOk.Location = New System.Drawing.Point(41, 110)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(100, 30)
        Me.btnOk.TabIndex = 10
        Me.btnOk.Text = "OK"
        Me.btnOk.UseVisualStyleBackColor = False
        '
        'frmAddContact
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 152)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.tbxIp)
        Me.Controls.Add(Me.tbxName)
        Me.Controls.Add(Me.cbxGroups)
        Me.Controls.Add(Me.btnNewGroup)
        Me.Controls.Add(Me.lblIp)
        Me.Controls.Add(Me.lblName)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOk)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmAddContact"
        Me.Text = "Add Contact"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents tbxIp As System.Windows.Forms.TextBox
    Friend WithEvents tbxName As System.Windows.Forms.TextBox
    Friend WithEvents cbxGroups As System.Windows.Forms.ComboBox
    Friend WithEvents btnNewGroup As System.Windows.Forms.Button
    Friend WithEvents lblIp As System.Windows.Forms.Label
    Friend WithEvents lblName As System.Windows.Forms.Label
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnOk As System.Windows.Forms.Button
End Class
