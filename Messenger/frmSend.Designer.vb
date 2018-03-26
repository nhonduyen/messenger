<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSend
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSend))
        Me.grbSendDetail = New System.Windows.Forms.GroupBox()
        Me.lblFileSize = New System.Windows.Forms.Label()
        Me.lblFileName = New System.Windows.Forms.Label()
        Me.progressBar = New System.Windows.Forms.ProgressBar()
        Me.grbSendDetail.SuspendLayout()
        Me.SuspendLayout()
        '
        'grbSendDetail
        '
        Me.grbSendDetail.Controls.Add(Me.lblFileSize)
        Me.grbSendDetail.Controls.Add(Me.lblFileName)
        Me.grbSendDetail.Controls.Add(Me.progressBar)
        Me.grbSendDetail.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grbSendDetail.Location = New System.Drawing.Point(12, 12)
        Me.grbSendDetail.Name = "grbSendDetail"
        Me.grbSendDetail.Size = New System.Drawing.Size(407, 130)
        Me.grbSendDetail.TabIndex = 8
        Me.grbSendDetail.TabStop = False
        '
        'lblFileSize
        '
        Me.lblFileSize.AutoSize = True
        Me.lblFileSize.Location = New System.Drawing.Point(8, 46)
        Me.lblFileSize.Name = "lblFileSize"
        Me.lblFileSize.Size = New System.Drawing.Size(72, 15)
        Me.lblFileSize.TabIndex = 7
        Me.lblFileSize.Text = "File Size    : "
        '
        'lblFileName
        '
        Me.lblFileName.AutoSize = True
        Me.lblFileName.Location = New System.Drawing.Point(8, 26)
        Me.lblFileName.Name = "lblFileName"
        Me.lblFileName.Size = New System.Drawing.Size(73, 15)
        Me.lblFileName.TabIndex = 6
        Me.lblFileName.Text = "File Name : "
        '
        'progressBar
        '
        Me.progressBar.Location = New System.Drawing.Point(6, 92)
        Me.progressBar.Name = "progressBar"
        Me.progressBar.Size = New System.Drawing.Size(391, 23)
        Me.progressBar.TabIndex = 4
        '
        'frmSend
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ClientSize = New System.Drawing.Size(428, 154)
        Me.Controls.Add(Me.grbSendDetail)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmSend"
        Me.Text = "Send Detail"
        Me.grbSendDetail.ResumeLayout(False)
        Me.grbSendDetail.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grbSendDetail As System.Windows.Forms.GroupBox
    Friend WithEvents lblFileSize As System.Windows.Forms.Label
    Friend WithEvents lblFileName As System.Windows.Forms.Label
    Friend WithEvents progressBar As System.Windows.Forms.ProgressBar
End Class
