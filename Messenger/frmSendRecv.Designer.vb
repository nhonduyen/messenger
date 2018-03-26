<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSendRecv
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSendRecv))
        Me.tabHistory = New System.Windows.Forms.TabControl()
        Me.tRecv = New System.Windows.Forms.TabPage()
        Me.gridRecv = New System.Windows.Forms.DataGridView()
        Me.FileNameReceive = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ReceiveFrom = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SizeRecv = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.StatusRecv = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DeteRecv = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CodeRecv = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tSend = New System.Windows.Forms.TabPage()
        Me.gridSend = New System.Windows.Forms.DataGridView()
        Me.FileNameSend = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SendTo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SizeSend = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.StatusSend = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DateSend = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CodeSend = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnDeleteAll = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.tabHistory.SuspendLayout()
        Me.tRecv.SuspendLayout()
        CType(Me.gridRecv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tSend.SuspendLayout()
        CType(Me.gridSend, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tabHistory
        '
        Me.tabHistory.Controls.Add(Me.tRecv)
        Me.tabHistory.Controls.Add(Me.tSend)
        Me.tabHistory.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tabHistory.Location = New System.Drawing.Point(8, 15)
        Me.tabHistory.Multiline = True
        Me.tabHistory.Name = "tabHistory"
        Me.tabHistory.SelectedIndex = 0
        Me.tabHistory.Size = New System.Drawing.Size(1008, 369)
        Me.tabHistory.TabIndex = 0
        '
        'tRecv
        '
        Me.tRecv.Controls.Add(Me.gridRecv)
        Me.tRecv.Location = New System.Drawing.Point(4, 25)
        Me.tRecv.Name = "tRecv"
        Me.tRecv.Padding = New System.Windows.Forms.Padding(3)
        Me.tRecv.Size = New System.Drawing.Size(1000, 340)
        Me.tRecv.TabIndex = 0
        Me.tRecv.Text = "       Receive        "
        Me.tRecv.UseVisualStyleBackColor = True
        '
        'gridRecv
        '
        Me.gridRecv.BackgroundColor = System.Drawing.Color.White
        Me.gridRecv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gridRecv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.FileNameReceive, Me.ReceiveFrom, Me.SizeRecv, Me.StatusRecv, Me.DeteRecv, Me.CodeRecv})
        Me.gridRecv.Location = New System.Drawing.Point(6, 6)
        Me.gridRecv.MultiSelect = False
        Me.gridRecv.Name = "gridRecv"
        Me.gridRecv.ReadOnly = True
        Me.gridRecv.Size = New System.Drawing.Size(990, 331)
        Me.gridRecv.TabIndex = 0
        '
        'FileNameReceive
        '
        Me.FileNameReceive.HeaderText = "File Name Receive"
        Me.FileNameReceive.Name = "FileNameReceive"
        Me.FileNameReceive.ReadOnly = True
        Me.FileNameReceive.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.FileNameReceive.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.FileNameReceive.Width = 400
        '
        'ReceiveFrom
        '
        Me.ReceiveFrom.HeaderText = "Receive From"
        Me.ReceiveFrom.Name = "ReceiveFrom"
        Me.ReceiveFrom.ReadOnly = True
        Me.ReceiveFrom.Width = 200
        '
        'SizeRecv
        '
        Me.SizeRecv.HeaderText = "Size"
        Me.SizeRecv.Name = "SizeRecv"
        Me.SizeRecv.ReadOnly = True
        '
        'StatusRecv
        '
        Me.StatusRecv.HeaderText = "Status"
        Me.StatusRecv.Name = "StatusRecv"
        Me.StatusRecv.ReadOnly = True
        '
        'DeteRecv
        '
        Me.DeteRecv.HeaderText = "Date"
        Me.DeteRecv.Name = "DeteRecv"
        Me.DeteRecv.ReadOnly = True
        Me.DeteRecv.Width = 140
        '
        'CodeRecv
        '
        Me.CodeRecv.HeaderText = ""
        Me.CodeRecv.Name = "CodeRecv"
        Me.CodeRecv.ReadOnly = True
        Me.CodeRecv.Width = 5
        '
        'tSend
        '
        Me.tSend.Controls.Add(Me.gridSend)
        Me.tSend.Location = New System.Drawing.Point(4, 25)
        Me.tSend.Name = "tSend"
        Me.tSend.Padding = New System.Windows.Forms.Padding(3)
        Me.tSend.Size = New System.Drawing.Size(1000, 340)
        Me.tSend.TabIndex = 1
        Me.tSend.Text = "          Send          "
        Me.tSend.UseVisualStyleBackColor = True
        '
        'gridSend
        '
        Me.gridSend.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ControlLight
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.gridSend.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.gridSend.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gridSend.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.FileNameSend, Me.SendTo, Me.SizeSend, Me.StatusSend, Me.DateSend, Me.CodeSend})
        Me.gridSend.Location = New System.Drawing.Point(5, 5)
        Me.gridSend.MultiSelect = False
        Me.gridSend.Name = "gridSend"
        Me.gridSend.ReadOnly = True
        Me.gridSend.Size = New System.Drawing.Size(990, 331)
        Me.gridSend.TabIndex = 1
        '
        'FileNameSend
        '
        Me.FileNameSend.HeaderText = "File Name Send"
        Me.FileNameSend.Name = "FileNameSend"
        Me.FileNameSend.ReadOnly = True
        Me.FileNameSend.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.FileNameSend.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.FileNameSend.Width = 400
        '
        'SendTo
        '
        Me.SendTo.HeaderText = "Send To"
        Me.SendTo.Name = "SendTo"
        Me.SendTo.ReadOnly = True
        Me.SendTo.Width = 200
        '
        'SizeSend
        '
        Me.SizeSend.HeaderText = "Size"
        Me.SizeSend.Name = "SizeSend"
        Me.SizeSend.ReadOnly = True
        '
        'StatusSend
        '
        Me.StatusSend.HeaderText = "Status"
        Me.StatusSend.Name = "StatusSend"
        Me.StatusSend.ReadOnly = True
        '
        'DateSend
        '
        Me.DateSend.HeaderText = "Date"
        Me.DateSend.Name = "DateSend"
        Me.DateSend.ReadOnly = True
        Me.DateSend.Width = 140
        '
        'CodeSend
        '
        Me.CodeSend.HeaderText = ""
        Me.CodeSend.Name = "CodeSend"
        Me.CodeSend.ReadOnly = True
        Me.CodeSend.Width = 5
        '
        'btnDeleteAll
        '
        Me.btnDeleteAll.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDeleteAll.Location = New System.Drawing.Point(126, 390)
        Me.btnDeleteAll.Name = "btnDeleteAll"
        Me.btnDeleteAll.Size = New System.Drawing.Size(102, 44)
        Me.btnDeleteAll.TabIndex = 6
        Me.btnDeleteAll.Text = "Delete All"
        Me.btnDeleteAll.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDelete.Location = New System.Drawing.Point(8, 390)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(102, 44)
        Me.btnDelete.TabIndex = 5
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'frmSendRecv
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ClientSize = New System.Drawing.Size(1020, 446)
        Me.Controls.Add(Me.btnDeleteAll)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.tabHistory)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSendRecv"
        Me.Text = "Send Recv History"
        Me.tabHistory.ResumeLayout(False)
        Me.tRecv.ResumeLayout(False)
        CType(Me.gridRecv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tSend.ResumeLayout(False)
        CType(Me.gridSend, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tabHistory As System.Windows.Forms.TabControl
    Friend WithEvents tRecv As System.Windows.Forms.TabPage
    Friend WithEvents tSend As System.Windows.Forms.TabPage
    Friend WithEvents btnDeleteAll As System.Windows.Forms.Button
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents gridRecv As System.Windows.Forms.DataGridView
    Friend WithEvents gridSend As System.Windows.Forms.DataGridView
    Friend WithEvents FileNameReceive As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ReceiveFrom As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SizeRecv As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents StatusRecv As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DeteRecv As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CodeRecv As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FileNameSend As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SendTo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SizeSend As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents StatusSend As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DateSend As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CodeSend As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
