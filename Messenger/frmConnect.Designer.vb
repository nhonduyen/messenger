<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmConnect
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmConnect))
        Me.cbxConnectingIp = New System.Windows.Forms.ComboBox()
        Me.tbxNickName = New System.Windows.Forms.TextBox()
        Me.btnConnect = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tmrConnect = New System.Windows.Forms.Timer(Me.components)
        Me.lblConnecting = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'cbxConnectingIp
        '
        Me.cbxConnectingIp.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbxConnectingIp.FormattingEnabled = True
        Me.cbxConnectingIp.Location = New System.Drawing.Point(13, 29)
        Me.cbxConnectingIp.Name = "cbxConnectingIp"
        Me.cbxConnectingIp.Size = New System.Drawing.Size(151, 24)
        Me.cbxConnectingIp.TabIndex = 0
        '
        'tbxNickName
        '
        Me.tbxNickName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbxNickName.Location = New System.Drawing.Point(170, 30)
        Me.tbxNickName.Name = "tbxNickName"
        Me.tbxNickName.Size = New System.Drawing.Size(148, 22)
        Me.tbxNickName.TabIndex = 1
        '
        'btnConnect
        '
        Me.btnConnect.Location = New System.Drawing.Point(240, 58)
        Me.btnConnect.Name = "btnConnect"
        Me.btnConnect.Size = New System.Drawing.Size(78, 23)
        Me.btnConnect.TabIndex = 2
        Me.btnConnect.Text = "Connect"
        Me.btnConnect.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(115, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Connecting IP Address"
        '
        'tmrConnect
        '
        Me.tmrConnect.Interval = 1000
        '
        'lblConnecting
        '
        Me.lblConnecting.AutoSize = True
        Me.lblConnecting.Location = New System.Drawing.Point(11, 63)
        Me.lblConnecting.Name = "lblConnecting"
        Me.lblConnecting.Size = New System.Drawing.Size(67, 13)
        Me.lblConnecting.TabIndex = 4
        Me.lblConnecting.Text = "Connecting ."
        Me.lblConnecting.Visible = False
        '
        'frmConnect
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ClientSize = New System.Drawing.Size(324, 84)
        Me.Controls.Add(Me.lblConnecting)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnConnect)
        Me.Controls.Add(Me.tbxNickName)
        Me.Controls.Add(Me.cbxConnectingIp)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmConnect"
        Me.Text = "Connect"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cbxConnectingIp As System.Windows.Forms.ComboBox
    Friend WithEvents tbxNickName As System.Windows.Forms.TextBox
    Friend WithEvents btnConnect As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents tmrConnect As System.Windows.Forms.Timer
    Friend WithEvents lblConnecting As System.Windows.Forms.Label
End Class
