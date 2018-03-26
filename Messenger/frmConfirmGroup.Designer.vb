<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmConfirmGroup
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmConfirmGroup))
        Me.lblAsk = New System.Windows.Forms.Label()
        Me.btnYes = New System.Windows.Forms.Button()
        Me.lblRoom = New System.Windows.Forms.Label()
        Me.btnNo = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'lblAsk
        '
        Me.lblAsk.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAsk.ForeColor = System.Drawing.Color.Blue
        Me.lblAsk.Location = New System.Drawing.Point(12, 21)
        Me.lblAsk.Name = "lblAsk"
        Me.lblAsk.Size = New System.Drawing.Size(573, 24)
        Me.lblAsk.TabIndex = 0
        Me.lblAsk.Text = "Do you want to join ... group chat?"
        Me.lblAsk.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnYes
        '
        Me.btnYes.BackColor = System.Drawing.SystemColors.Highlight
        Me.btnYes.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnYes.Location = New System.Drawing.Point(170, 114)
        Me.btnYes.Name = "btnYes"
        Me.btnYes.Size = New System.Drawing.Size(108, 39)
        Me.btnYes.TabIndex = 1
        Me.btnYes.Text = "YES"
        Me.btnYes.UseVisualStyleBackColor = False
        '
        'lblRoom
        '
        Me.lblRoom.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRoom.ForeColor = System.Drawing.Color.Blue
        Me.lblRoom.Location = New System.Drawing.Point(16, 53)
        Me.lblRoom.Name = "lblRoom"
        Me.lblRoom.Size = New System.Drawing.Size(569, 24)
        Me.lblRoom.TabIndex = 3
        Me.lblRoom.Text = "R_"
        Me.lblRoom.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnNo
        '
        Me.btnNo.BackColor = System.Drawing.SystemColors.Highlight
        Me.btnNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNo.Location = New System.Drawing.Point(314, 114)
        Me.btnNo.Name = "btnNo"
        Me.btnNo.Size = New System.Drawing.Size(108, 39)
        Me.btnNo.TabIndex = 4
        Me.btnNo.Text = "NO"
        Me.btnNo.UseVisualStyleBackColor = False
        '
        'frmConfirmGroup
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ClientSize = New System.Drawing.Size(597, 170)
        Me.Controls.Add(Me.btnNo)
        Me.Controls.Add(Me.lblRoom)
        Me.Controls.Add(Me.btnYes)
        Me.Controls.Add(Me.lblAsk)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmConfirmGroup"
        Me.Text = "Confirm Group Chat"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblAsk As System.Windows.Forms.Label
    Friend WithEvents btnYes As System.Windows.Forms.Button
    Friend WithEvents lblRoom As System.Windows.Forms.Label
    Friend WithEvents btnNo As System.Windows.Forms.Button
End Class
