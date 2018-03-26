<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRecvOption
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRecvOption))
        Me.grbRecvFrom = New System.Windows.Forms.GroupBox()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.tbxFileName = New System.Windows.Forms.TextBox()
        Me.pictureType = New System.Windows.Forms.PictureBox()
        Me.lblFileSize = New System.Windows.Forms.Label()
        Me.btnRecv = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.lblFileName = New System.Windows.Forms.Label()
        Me.progressBar = New System.Windows.Forms.ProgressBar()
        Me.btnSaveTo = New System.Windows.Forms.Button()
        Me.tbxSaveTo = New System.Windows.Forms.TextBox()
        Me.grbRecvComplete = New System.Windows.Forms.GroupBox()
        Me.lblFileSize_ = New System.Windows.Forms.Label()
        Me.tbxFileName_ = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.btnOpenFolder = New System.Windows.Forms.Button()
        Me.btnOpenFile = New System.Windows.Forms.Button()
        Me.fBrowseSaveTo = New System.Windows.Forms.FolderBrowserDialog()
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.ImageListType = New System.Windows.Forms.ImageList(Me.components)
        Me.rtbRep = New System.Windows.Forms.RichTextBox()
        Me.grbRecvFrom.SuspendLayout()
        CType(Me.pictureType, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grbRecvComplete.SuspendLayout()
        Me.SuspendLayout()
        '
        'grbRecvFrom
        '
        Me.grbRecvFrom.BackColor = System.Drawing.Color.White
        Me.grbRecvFrom.Controls.Add(Me.lblStatus)
        Me.grbRecvFrom.Controls.Add(Me.tbxFileName)
        Me.grbRecvFrom.Controls.Add(Me.pictureType)
        Me.grbRecvFrom.Controls.Add(Me.lblFileSize)
        Me.grbRecvFrom.Controls.Add(Me.btnRecv)
        Me.grbRecvFrom.Controls.Add(Me.btnCancel)
        Me.grbRecvFrom.Controls.Add(Me.lblFileName)
        Me.grbRecvFrom.Controls.Add(Me.progressBar)
        Me.grbRecvFrom.Controls.Add(Me.btnSaveTo)
        Me.grbRecvFrom.Controls.Add(Me.tbxSaveTo)
        Me.grbRecvFrom.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grbRecvFrom.Location = New System.Drawing.Point(5, 7)
        Me.grbRecvFrom.Name = "grbRecvFrom"
        Me.grbRecvFrom.Size = New System.Drawing.Size(514, 161)
        Me.grbRecvFrom.TabIndex = 7
        Me.grbRecvFrom.TabStop = False
        '
        'lblStatus
        '
        Me.lblStatus.BackColor = System.Drawing.Color.Transparent
        Me.lblStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStatus.Location = New System.Drawing.Point(10, 120)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(391, 35)
        Me.lblStatus.TabIndex = 10
        Me.lblStatus.Text = "Please wait while writing file!"
        Me.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblStatus.Visible = False
        '
        'tbxFileName
        '
        Me.tbxFileName.Location = New System.Drawing.Point(87, 25)
        Me.tbxFileName.Name = "tbxFileName"
        Me.tbxFileName.ReadOnly = True
        Me.tbxFileName.Size = New System.Drawing.Size(314, 21)
        Me.tbxFileName.TabIndex = 9
        '
        'pictureType
        '
        Me.pictureType.Location = New System.Drawing.Point(437, 45)
        Me.pictureType.Name = "pictureType"
        Me.pictureType.Size = New System.Drawing.Size(48, 48)
        Me.pictureType.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pictureType.TabIndex = 8
        Me.pictureType.TabStop = False
        '
        'lblFileSize
        '
        Me.lblFileSize.AutoSize = True
        Me.lblFileSize.Location = New System.Drawing.Point(435, 99)
        Me.lblFileSize.Name = "lblFileSize"
        Me.lblFileSize.Size = New System.Drawing.Size(54, 15)
        Me.lblFileSize.TabIndex = 7
        Me.lblFileSize.Text = "File Size"
        '
        'btnRecv
        '
        Me.btnRecv.Location = New System.Drawing.Point(9, 124)
        Me.btnRecv.Name = "btnRecv"
        Me.btnRecv.Size = New System.Drawing.Size(189, 28)
        Me.btnRecv.TabIndex = 5
        Me.btnRecv.Text = "Receive"
        Me.btnRecv.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(204, 124)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(198, 28)
        Me.btnCancel.TabIndex = 6
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'lblFileName
        '
        Me.lblFileName.AutoSize = True
        Me.lblFileName.Location = New System.Drawing.Point(8, 28)
        Me.lblFileName.Name = "lblFileName"
        Me.lblFileName.Size = New System.Drawing.Size(73, 15)
        Me.lblFileName.TabIndex = 6
        Me.lblFileName.Text = "File Name : "
        '
        'progressBar
        '
        Me.progressBar.Location = New System.Drawing.Point(10, 91)
        Me.progressBar.Name = "progressBar"
        Me.progressBar.Size = New System.Drawing.Size(391, 23)
        Me.progressBar.TabIndex = 4
        '
        'btnSaveTo
        '
        Me.btnSaveTo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSaveTo.Location = New System.Drawing.Point(9, 59)
        Me.btnSaveTo.Name = "btnSaveTo"
        Me.btnSaveTo.Size = New System.Drawing.Size(72, 23)
        Me.btnSaveTo.TabIndex = 3
        Me.btnSaveTo.Text = "Save To :"
        Me.btnSaveTo.UseVisualStyleBackColor = True
        '
        'tbxSaveTo
        '
        Me.tbxSaveTo.Location = New System.Drawing.Point(87, 60)
        Me.tbxSaveTo.Name = "tbxSaveTo"
        Me.tbxSaveTo.ReadOnly = True
        Me.tbxSaveTo.Size = New System.Drawing.Size(314, 21)
        Me.tbxSaveTo.TabIndex = 2
        '
        'grbRecvComplete
        '
        Me.grbRecvComplete.Controls.Add(Me.rtbRep)
        Me.grbRecvComplete.Controls.Add(Me.lblFileSize_)
        Me.grbRecvComplete.Controls.Add(Me.tbxFileName_)
        Me.grbRecvComplete.Controls.Add(Me.Label1)
        Me.grbRecvComplete.Controls.Add(Me.btnExit)
        Me.grbRecvComplete.Controls.Add(Me.btnOpenFolder)
        Me.grbRecvComplete.Controls.Add(Me.btnOpenFile)
        Me.grbRecvComplete.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grbRecvComplete.Location = New System.Drawing.Point(5, 10)
        Me.grbRecvComplete.Name = "grbRecvComplete"
        Me.grbRecvComplete.Size = New System.Drawing.Size(514, 161)
        Me.grbRecvComplete.TabIndex = 9
        Me.grbRecvComplete.TabStop = False
        Me.grbRecvComplete.Text = "   Receive Complete   "
        Me.grbRecvComplete.Visible = False
        '
        'lblFileSize_
        '
        Me.lblFileSize_.AutoSize = True
        Me.lblFileSize_.Location = New System.Drawing.Point(32, 66)
        Me.lblFileSize_.Name = "lblFileSize_"
        Me.lblFileSize_.Size = New System.Drawing.Size(80, 16)
        Me.lblFileSize_.TabIndex = 5
        Me.lblFileSize_.Text = "File Size     : "
        '
        'tbxFileName_
        '
        Me.tbxFileName_.Location = New System.Drawing.Point(118, 32)
        Me.tbxFileName_.Name = "tbxFileName_"
        Me.tbxFileName_.ReadOnly = True
        Me.tbxFileName_.Size = New System.Drawing.Size(387, 22)
        Me.tbxFileName_.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(32, 35)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(79, 16)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "File Name : "
        '
        'btnExit
        '
        Me.btnExit.Location = New System.Drawing.Point(348, 119)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(158, 28)
        Me.btnExit.TabIndex = 2
        Me.btnExit.Text = "Cancel"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'btnOpenFolder
        '
        Me.btnOpenFolder.Location = New System.Drawing.Point(180, 119)
        Me.btnOpenFolder.Name = "btnOpenFolder"
        Me.btnOpenFolder.Size = New System.Drawing.Size(158, 28)
        Me.btnOpenFolder.TabIndex = 1
        Me.btnOpenFolder.Text = "Open Folder"
        Me.btnOpenFolder.UseVisualStyleBackColor = True
        '
        'btnOpenFile
        '
        Me.btnOpenFile.Location = New System.Drawing.Point(11, 119)
        Me.btnOpenFile.Name = "btnOpenFile"
        Me.btnOpenFile.Size = New System.Drawing.Size(158, 27)
        Me.btnOpenFile.TabIndex = 0
        Me.btnOpenFile.Text = "Open File"
        Me.btnOpenFile.UseVisualStyleBackColor = True
        '
        'ImageListType
        '
        Me.ImageListType.ImageStream = CType(resources.GetObject("ImageListType.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageListType.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageListType.Images.SetKeyName(0, "excel")
        Me.ImageListType.Images.SetKeyName(1, "exe")
        Me.ImageListType.Images.SetKeyName(2, "iso")
        Me.ImageListType.Images.SetKeyName(3, "pdf")
        Me.ImageListType.Images.SetKeyName(4, "rar")
        Me.ImageListType.Images.SetKeyName(5, "unknow")
        Me.ImageListType.Images.SetKeyName(6, "word")
        Me.ImageListType.Images.SetKeyName(7, "ptt")
        '
        'rtbRep
        '
        Me.rtbRep.Location = New System.Drawing.Point(13, 88)
        Me.rtbRep.Name = "rtbRep"
        Me.rtbRep.Size = New System.Drawing.Size(492, 27)
        Me.rtbRep.TabIndex = 6
        Me.rtbRep.Text = ""
        '
        'frmRecvOption
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(522, 179)
        Me.Controls.Add(Me.grbRecvComplete)
        Me.Controls.Add(Me.grbRecvFrom)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmRecvOption"
        Me.Text = "Receive Detail"
        Me.grbRecvFrom.ResumeLayout(False)
        Me.grbRecvFrom.PerformLayout()
        CType(Me.pictureType, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grbRecvComplete.ResumeLayout(False)
        Me.grbRecvComplete.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grbRecvFrom As System.Windows.Forms.GroupBox
    Friend WithEvents btnSaveTo As System.Windows.Forms.Button
    Friend WithEvents tbxSaveTo As System.Windows.Forms.TextBox
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnRecv As System.Windows.Forms.Button
    Friend WithEvents fBrowseSaveTo As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents lblFileName As System.Windows.Forms.Label
    Friend WithEvents progressBar As System.Windows.Forms.ProgressBar
    Friend WithEvents lblFileSize As System.Windows.Forms.Label
    Friend WithEvents pictureType As System.Windows.Forms.PictureBox
    Friend WithEvents grbRecvComplete As System.Windows.Forms.GroupBox
    Friend WithEvents lblFileSize_ As System.Windows.Forms.Label
    Friend WithEvents tbxFileName_ As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnExit As System.Windows.Forms.Button
    Friend WithEvents btnOpenFolder As System.Windows.Forms.Button
    Friend WithEvents btnOpenFile As System.Windows.Forms.Button
    Friend WithEvents FolderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents tbxFileName As System.Windows.Forms.TextBox
    Friend WithEvents ImageListType As System.Windows.Forms.ImageList
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents rtbRep As System.Windows.Forms.RichTextBox
End Class
