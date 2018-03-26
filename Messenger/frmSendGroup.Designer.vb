<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSendGroup
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSendGroup))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnSend = New System.Windows.Forms.Button()
        Me.rtbContent = New System.Windows.Forms.RichTextBox()
        Me.lblSenTo = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.btnSend)
        Me.Panel1.Controls.Add(Me.rtbContent)
        Me.Panel1.Controls.Add(Me.lblSenTo)
        Me.Panel1.Location = New System.Drawing.Point(4, 5)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(466, 116)
        Me.Panel1.TabIndex = 0
        '
        'btnSend
        '
        Me.btnSend.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSend.ForeColor = System.Drawing.Color.Blue
        Me.btnSend.Location = New System.Drawing.Point(373, 34)
        Me.btnSend.Name = "btnSend"
        Me.btnSend.Size = New System.Drawing.Size(87, 73)
        Me.btnSend.TabIndex = 2
        Me.btnSend.Text = "Send"
        Me.btnSend.UseVisualStyleBackColor = True
        '
        'rtbContent
        '
        Me.rtbContent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.rtbContent.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rtbContent.Location = New System.Drawing.Point(13, 34)
        Me.rtbContent.Margin = New System.Windows.Forms.Padding(5)
        Me.rtbContent.Name = "rtbContent"
        Me.rtbContent.Size = New System.Drawing.Size(357, 73)
        Me.rtbContent.TabIndex = 1
        Me.rtbContent.Text = ""
        '
        'lblSenTo
        '
        Me.lblSenTo.AutoSize = True
        Me.lblSenTo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSenTo.Location = New System.Drawing.Point(9, 9)
        Me.lblSenTo.Name = "lblSenTo"
        Me.lblSenTo.Size = New System.Drawing.Size(130, 20)
        Me.lblSenTo.TabIndex = 0
        Me.lblSenTo.Text = "Send To Group : "
        '
        'frmSendGroup
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BackColor = System.Drawing.SystemColors.Highlight
        Me.ClientSize = New System.Drawing.Size(474, 124)
        Me.Controls.Add(Me.Panel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmSendGroup"
        Me.Text = "frmSendGroup"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btnSend As System.Windows.Forms.Button
    Friend WithEvents rtbContent As System.Windows.Forms.RichTextBox
    Friend WithEvents lblSenTo As System.Windows.Forms.Label
End Class
