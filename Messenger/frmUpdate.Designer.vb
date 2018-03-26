<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmUpdate
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
        Me.Button1 = New System.Windows.Forms.Button()
        Me.tbxFilePath = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tbxVersion = New System.Windows.Forms.TextBox()
        Me.ofdFileUpdate = New System.Windows.Forms.OpenFileDialog()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(245, 77)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 26)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Update"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'tbxFilePath
        '
        Me.tbxFilePath.Location = New System.Drawing.Point(72, 24)
        Me.tbxFilePath.Name = "tbxFilePath"
        Me.tbxFilePath.Size = New System.Drawing.Size(340, 20)
        Me.tbxFilePath.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 27)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(54, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "File Path :"
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(337, 77)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 26)
        Me.Button2.TabIndex = 3
        Me.Button2.Text = "Cancel"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(11, 50)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(54, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Version   :"
        '
        'tbxVersion
        '
        Me.tbxVersion.Location = New System.Drawing.Point(72, 47)
        Me.tbxVersion.Name = "tbxVersion"
        Me.tbxVersion.Size = New System.Drawing.Size(340, 20)
        Me.tbxVersion.TabIndex = 4
        '
        'frmUpdate
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(424, 115)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.tbxVersion)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.tbxFilePath)
        Me.Controls.Add(Me.Button1)
        Me.Name = "frmUpdate"
        Me.Text = "frmUpdate"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents tbxFilePath As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents tbxVersion As System.Windows.Forms.TextBox
    Friend WithEvents ofdFileUpdate As System.Windows.Forms.OpenFileDialog
End Class
