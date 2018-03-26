Public Class frmSendRecv

    Dim code As String

    Private xml As New cMgrXml

    Private Sub frmSendRecv_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        init()
    End Sub
    Public Sub init()
        gridSend.Rows.Clear()
        gridRecv.Rows.Clear()
        xml.ReadHistory(FILE_HISTORY, gridRecv, gridSend)
    End Sub
    Private Sub frmSendRecv_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        'e.Cancel = True
        'Me.Hide()
    End Sub

    Private Sub gridSend_CellMouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles gridSend.CellMouseDown
        Try
            If e.Button = Windows.Forms.MouseButtons.Left Then
                code = gridSend.Item(5, e.RowIndex).Value
            End If
        Catch ex As Exception

        End Try
       
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        If code <> "" Then
            xml.RemoveHistory(FILE_HISTORY, code)
            code = ""
            init()
        Else
            MessageBox.Show("Please Click On Row You Want To Delete!", "Info", MessageBoxButtons.OK)
        End If
    End Sub

    Private Sub btnDeleteAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeleteAll.Click
        Try
            xml.RemoveHistory(FILE_HISTORY)
            init()
        Catch ex As Exception

        End Try

    End Sub

    Private Sub gridRecv_CellMouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles gridRecv.CellMouseDown
        Try
            If e.Button = Windows.Forms.MouseButtons.Left Then
                code = gridRecv.Item(5, e.RowIndex).Value
            End If
        Catch ex As Exception

        End Try
    End Sub
End Class