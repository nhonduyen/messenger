Public Class frmAddContact
    Private xml As New cMgrXml
    Private Sub frmAddContact_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim a As Integer
        Dim b As Integer
        a = frmMain.Location.X - 385
        b = frmMain.Location.Y
        Me.Location = New Point(a, b)

        If flagAddContact = 0 Then
            tbxName.ReadOnly = True
            tbxIp.ReadOnly = True
            tbxName.Text = tempName
            tbxIp.Text = tempIp

            If cbxGroups.Items.Count > 0 Then
                cbxGroups.Text = cbxGroups.Items(0).ToString
            End If
        Else
            tbxName.Text = ""
            tbxIp.Text = ""
            tbxName.ReadOnly = False
            tbxIp.ReadOnly = False
        End If
    End Sub

    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click
        If flagAddContact = 1 Then
            tempIp = tbxIp.Text
            tempName = tbxName.Text
        End If
        xml.RemoveContact(FILE_CONTACTS, tempIp)
        xml.AddContact(FILE_CONTACTS, cbxGroups.Text, tempIp, tempName)
        frmMain.UpdateYourContacts()
        Me.Close()
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnNewGroup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNewGroup.Click
        If cbxGroups.Items.Contains(cbxGroups.Text.Trim) Then
            MessageBox.Show("This Group Is Contain Already!", "Infomation", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            cbxGroups.Items.Add(cbxGroups.Text.Trim)
            xml.AddGroup(FILE_CONTACTS, cbxGroups.Text.Trim)
        End If
    End Sub


End Class