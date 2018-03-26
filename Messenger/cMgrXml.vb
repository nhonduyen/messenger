Imports System.Xml
Imports System.Xml.Linq.XDocument
Imports System.Xml.Schema

Public Class cMgrXml

    Public Sub Create(ByVal xmlFile As String, ByVal root As String)
        Try
            Dim xmlSetting As XmlWriterSettings = New XmlWriterSettings()
            xmlSetting.Indent = True
            xmlSetting.NewLineOnAttributes = True
            Dim xmlAdd As XmlWriter = XmlWriter.Create(xmlFile, xmlSetting)
            xmlAdd.WriteStartDocument()

            xmlAdd.WriteStartElement(root)

            xmlAdd.WriteEndElement()

            xmlAdd.WriteEndDocument()

            xmlAdd.Flush()
            xmlAdd.Close()
        Catch ex As Exception
        End Try
    End Sub

    'Group Management
    Public Sub AddGroup(ByVal xmlFile As String, ByVal group As String)
        Try
            Dim xmlAddGroup As New XmlDocument
            xmlAddGroup.Load(xmlFile)

            Dim newGroup As XmlElement = xmlAddGroup.CreateElement("group")
            newGroup.SetAttribute("name", group)
            xmlAddGroup.DocumentElement.AppendChild(newGroup)

            Dim xmlTextWrite As XmlTextWriter = New XmlTextWriter(xmlFile, Nothing)
            xmlTextWrite.Formatting = Formatting.Indented
            xmlAddGroup.WriteContentTo(xmlTextWrite)
            xmlTextWrite.Close()

        Catch ex As Exception
        End Try
    End Sub

    Public Sub RenameGroup(ByVal xmlFile As String, ByVal oldGroup As String, ByVal newGroup As String)
        Try
            Dim xml As New XmlDocument
            xml.Load(xmlFile)

            Dim checkXmlNode As XmlNode = xml.SelectSingleNode("/Contacts/group[@name='" & oldGroup & "']")
            If Not checkXmlNode Is Nothing Then
                checkXmlNode.Attributes("name").Value = newGroup
            End If
            xml.Save(xmlFile)
        Catch ex As Exception
        End Try
    End Sub

    Public Sub RemoveGroup(ByVal xmlFile As String, ByVal group As String)
        Try
            Dim xmlRemove As New XmlDocument
            xmlRemove.Load(xmlFile)

            Dim myNode As XmlNode = xmlRemove.SelectSingleNode("/Contacts/group[@name='" & group & "']")

            If Not myNode Is Nothing Then
                myNode.ParentNode.RemoveChild(myNode)
                xmlRemove.Save(xmlFile)
            End If
        Catch ex As Exception
        End Try
    End Sub

    Public Sub ReadGroups(ByVal xmlFile As String, ByVal cbx As ComboBox, ByVal treeview As TreeView)
        cbx.Items.Clear()
        treeview.Nodes.Clear()
        Try
            Dim xmlRead As XmlReader = XmlReader.Create(xmlFile)
            While xmlRead.Read
                If xmlRead.Name = "group" Then
                    Dim attribute As String = xmlRead("name")
                    If attribute IsNot Nothing Then
                        cbx.Items.Add(attribute)
                        treeview.Nodes.Add(attribute)
                    End If
                End If
            End While
            xmlRead.Close()
        Catch ex As Exception
        End Try
    End Sub

    Public Sub ReadGroupsDept(ByVal xmlFile As String, ByVal cbx As ComboBox, ByVal treeview As TreeView)
        treeview.Nodes.Clear()
        Try
            Dim xmlAddGroup As New XmlDocument
            xmlAddGroup.Load(xmlFile)
            For i = 0 To cbx.Items.Count - 1
                treeview.Nodes.Add(cbx.Items(i).ToString)
                Dim myNode As XmlNode = xmlAddGroup.SelectSingleNode("/Contacts/group[@name='" & cbx.Items(i).ToString & "']")
                If myNode Is Nothing Then
                    Dim newGroup As XmlElement = xmlAddGroup.CreateElement("group")
                    newGroup.SetAttribute("name", cbx.Items(i).ToString)
                    xmlAddGroup.DocumentElement.AppendChild(newGroup)
                End If              
            Next
            Dim xmlTextWrite As XmlTextWriter = New XmlTextWriter(xmlFile, Nothing)
            xmlTextWrite.Formatting = Formatting.Indented
            xmlAddGroup.WriteContentTo(xmlTextWrite)
            xmlTextWrite.Close()
        Catch ex As Exception
        End Try
    End Sub

    Public Sub ReadGroupsDept(ByVal xmlFile As String, ByVal cbx As ComboBox)
        cbx.Items.Clear()

        Try
            Dim xmlRead As XmlReader = XmlReader.Create(xmlFile)
            While xmlRead.Read
                If xmlRead.Name = "group" Then
                    Dim attribute As String = xmlRead("name")
                    If attribute IsNot Nothing Then
                        cbx.Items.Add(attribute)
                    End If
                End If
            End While
            xmlRead.Close()
        Catch ex As Exception
        End Try
    End Sub

    Public Sub ReadGroups(ByVal xmlFile As String, ByVal ListDept As List(Of String), ByVal treeview As TreeView)
        ListDept.Clear()
        treeview.Nodes.Clear()
        Try
            Dim xmlRead As XmlReader = XmlReader.Create(xmlFile)
            While xmlRead.Read
                If xmlRead.Name = "group" Then
                    Dim attribute As String = xmlRead("name")
                    If attribute IsNot Nothing Then
                        ListDept.Add(attribute)
                        treeview.Nodes.Add(attribute)
                    End If
                End If
            End While
            xmlRead.Close()
        Catch ex As Exception
        End Try
    End Sub

    Public Sub ReadGroups(ByVal xmlFile As String, ByVal cbx As ComboBox)
        cbx.Items.Clear()
        Try
            Dim xmlRead As XmlReader = XmlReader.Create(xmlFile)
            While xmlRead.Read
                If xmlRead.Name = "group" Then
                    Dim attribute As String = xmlRead("name")
                    If attribute IsNot Nothing Then
                        If Not cbx.Items.Contains(attribute) Then
                            cbx.Items.Add(attribute)
                        End If
                    End If
                End If
            End While
        Catch
        End Try
    End Sub

    Function FindGroup(ByVal xmlFile As String, ByVal ip As String) As String
        Dim group As String = ""
        Try
            Dim xmlRemove As New XmlDocument
            xmlRemove.Load(xmlFile)
            Dim myNode As XmlNode = xmlRemove.SelectSingleNode("/Contacts/group/contact[@IP='" & ip & "']")
            If Not myNode Is Nothing Then
                group = myNode.ParentNode.Attributes.ItemOf("name").InnerText
            Else
                group = ""
            End If
        Catch ex As Exception
        End Try
        Return group
    End Function

    'Contact Management
    Public Sub AddContact(ByVal xmlFile As String, ByVal group As String, ByVal ip As String, ByVal nickname As String)

        Try
            Dim xmlAdd As New XmlDocument
            xmlAdd.Load(xmlFile)

            'Checking Containt Of Ip On Your List Contacts
            Dim checkNode As XmlNode = xmlAdd.SelectSingleNode("/Contacts/group/contact[@IP='" & ip & "']")
            If Not checkNode Is Nothing Then
                MessageBox.Show("This Contact Is Contain On Your Contacts! You Can Move To Other Groups.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                'Checking Containt Of Group
                Dim myNode As XmlNode = xmlAdd.SelectSingleNode("/Contacts/group[@name='" & group & "']")
                If myNode Is Nothing Then
                    MessageBox.Show("This Group Is Not Contain On Your List, Please Make New Group", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    Dim newContact As XmlElement = xmlAdd.CreateElement("contact")
                    newContact.SetAttribute("IP", ip)
                    Dim fn As XmlElement = xmlAdd.CreateElement("NAME")
                    fn.InnerText = nickname
                    newContact.AppendChild(fn)
                    myNode.AppendChild(newContact)

                    Dim xmlTextWrite As XmlTextWriter = New XmlTextWriter(xmlFile, Nothing)
                    xmlTextWrite.Formatting = Formatting.Indented
                    xmlAdd.WriteContentTo(xmlTextWrite)
                    xmlTextWrite.Close()
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub



    Public Sub RemoveContact(ByVal xmlFile As String, ByVal ip As String)
        Try
            Dim xmlRemove As New XmlDocument
            xmlRemove.Load(xmlFile)
            Dim myNode As XmlNode = xmlRemove.SelectSingleNode("/Contacts/group/contact[@IP='" & ip & "']")
            If Not myNode Is Nothing Then
                myNode.ParentNode.RemoveChild(myNode)
                xmlRemove.Save(xmlFile)
            End If
        Catch ex As Exception
        End Try
    End Sub

    Public Sub ReplaceNickname(ByVal xmlFile As String, ByVal group As String, ByVal ip As String, ByVal newNickName As String)
        Try
            RemoveContact(xmlFile, ip)
            AddContact(xmlFile, group, ip, newNickName)
        Catch ex As Exception
        End Try
    End Sub

    Public Sub ReplaceNicknameDept(ByVal xmlFile As String, ByVal group As String, ByVal ip As String, ByVal newNickName As String)
        Try
            Dim xmlReplace As New XmlDocument
            xmlReplace.Load(xmlFile)
            Dim myNode As XmlNode = xmlReplace.SelectSingleNode("/Contacts/group/contact[@IP='" & ip & "']/NICKNAME")
            If Not myNode Is Nothing Then
                myNode.ParentNode.RemoveChild(myNode)
                Dim myNode_ As XmlNode = xmlReplace.SelectSingleNode("/Contacts/group/contact[@IP='" & ip & "']")
                Dim fn As XmlElement = xmlReplace.CreateElement("NICKNAME")
                fn.InnerText = newNickName
                myNode_.AppendChild(fn)

                xmlReplace.Save(xmlFile)
            End If
        Catch ex As Exception
        End Try
    End Sub

    Public Sub ReadYourContact(ByVal xmlFile As String, ByVal lList As List(Of String), ByVal group As String)
        Try
            Dim xmlRead As New XmlDocument
            xmlRead.Load(xmlFile)
            For Each nodes As XmlNode In xmlRead.DocumentElement.SelectNodes("/Contacts/group[@name = '" & group & "']/contact")
                Dim ip As String = nodes.Attributes.ItemOf("IP").InnerText
                lList.Add(ip)
            Next
        Catch ex As Exception
        End Try
    End Sub

    Public Sub ReadYourContact(ByVal xmlFile As String, ByVal treeview As TreeView, ByVal cbx As ComboBox)

        Try
            Dim xmlRead As New XmlDocument
            xmlRead.Load(xmlFile)

            For i As Integer = 0 To cbx.Items.Count - 1
                For Each nodes As XmlNode In xmlRead.DocumentElement.SelectNodes("/Contacts/group[@name = '" & cbx.Items(i).ToString & "']/contact")
                    Dim node As New TreeNode(nodes.SelectSingleNode("NAME").InnerText)

                    Dim name As String = ""
                    Dim phone As String = ""
                    Dim mobile As String = ""
                    Dim dept As String = ""
                    ReadDeptContact(FILE_DEPTCONTACT, nodes.Attributes.ItemOf("IP").InnerText, name, phone, mobile, dept, frmSetting.cbxDept)

                    Dim tip As String = ""
                    If (name.Trim <> "") Then
                        tip = tip + " NAME : " + name + vbCrLf
                    End If
                    If (dept.Trim <> "") Then
                        tip = tip + " DEPT : " + dept + vbCrLf
                    End If
                    If (mobile.Trim <> "") Then
                        tip = tip + " MOBILE : " + mobile + vbCrLf
                    End If
                    If (phone.Trim <> "") Then
                        tip = tip + " PHONE : " + phone + vbCrLf
                    End If

                    tip = tip + " IP : " + nodes.Attributes.ItemOf("IP").InnerText
                    node.ToolTipText = tip
                    'node.ToolTipText = " NAME : " + name + vbCrLf + " DEPT : " + dept + vbCrLf + " MOBILE : " + mobile + vbCrLf + " PHONE : " + phone + vbCrLf + " IP : " + nodes.Attributes.ItemOf("IP").InnerText

                    If bOnlineContact = True Then   'Show List Contacts Online
                        If dictContacts.ContainsKey(nodes.Attributes.ItemOf("IP").InnerText) Then
                            node.ImageIndex = 1
                            node.SelectedImageIndex = 1
                            treeview.Nodes.Item(i).Nodes.AddRange(New TreeNode() {node})
                        End If
                    Else                            'Show All Contacts
                        If dictContacts.ContainsKey(nodes.Attributes.ItemOf("IP").InnerText) Then
                            node.ImageIndex = 1
                            node.SelectedImageIndex = 1
                        Else
                            node.ImageIndex = 0
                            node.SelectedImageIndex = 0
                        End If
                        treeview.Nodes.Item(i).Nodes.AddRange(New TreeNode() {node})
                    End If

                Next
            Next
        Catch ex As Exception
        End Try
    End Sub


    Public Sub ReadYourContact_(ByVal xmlFile As String, ByVal treeview As TreeView, ByVal cbx As ComboBox)

        Try
            Dim xmlRead As New XmlDocument
            xmlRead.Load(xmlFile)

            For i As Integer = 0 To cbx.Items.Count - 1
                For Each nodes As XmlNode In xmlRead.DocumentElement.SelectNodes("/Contacts/group[@name = '" & cbx.Items(i).ToString & "']/contact")
                    Dim node As New TreeNode(nodes.SelectSingleNode("NICKNAME").InnerText)

                    Dim name As String = nodes.SelectSingleNode("NAME").InnerText
                    Dim phone As String = nodes.SelectSingleNode("PHONE").InnerText
                    Dim mobile As String = nodes.SelectSingleNode("MOBILE").InnerText

                    Dim tip As String = ""
                    If (name.Trim <> "") Then
                        tip = tip + " NAME : " + name + vbCrLf
                    End If
                    If (mobile.Trim <> "") Then
                        tip = tip + " MOBILE : " + mobile + vbCrLf
                    End If
                    If (phone.Trim <> "") Then
                        tip = tip + " PHONE : " + phone + vbCrLf
                    End If

                    tip = tip + " IP : " + nodes.Attributes.ItemOf("IP").InnerText
                    node.ToolTipText = tip



                    'node.ToolTipText = " NAME : " + nodes.SelectSingleNode("NAME").InnerText + vbCrLf + " PHONE : " + nodes.SelectSingleNode("PHONE").InnerText + vbCrLf + " MOBILE : " + nodes.SelectSingleNode("MOBILE").InnerText + vbCrLf + " IP : " + nodes.Attributes.ItemOf("IP").InnerText

                    If bOnlineContact = True Then   'Show List Contacts Online
                        If dictContacts.ContainsKey(nodes.Attributes.ItemOf("IP").InnerText) Then
                            node.ImageIndex = 1
                            node.SelectedImageIndex = 1
                            treeview.Nodes.Item(i).Nodes.AddRange(New TreeNode() {node})
                        End If
                    Else                            'Show All Contacts
                        If dictContacts.ContainsKey(nodes.Attributes.ItemOf("IP").InnerText) Then
                            node.ImageIndex = 1
                            node.SelectedImageIndex = 1
                        Else
                            node.ImageIndex = 0
                            node.SelectedImageIndex = 0
                        End If
                        treeview.Nodes.Item(i).Nodes.AddRange(New TreeNode() {node})
                    End If

                Next
            Next
        Catch ex As Exception
        End Try
    End Sub


    Public Sub ReadYourContact(ByVal xmlFile As String, ByVal treeview As TreeView, ByVal ListDept As List(Of String))

        Try
            Dim xmlRead As New XmlDocument
            xmlRead.Load(xmlFile)

            For i As Integer = 0 To ListDept.Count - 1
                For Each nodes As XmlNode In xmlRead.DocumentElement.SelectNodes("/Contacts/group[@name = '" & ListDept.Item(i).ToString & "']/contact")
                    Dim node As New TreeNode(nodes.SelectSingleNode("NICKNAME").InnerText)

                    Dim name As String = nodes.SelectSingleNode("NAME").InnerText
                    Dim phone As String = nodes.SelectSingleNode("PHONE").InnerText
                    Dim mobile As String = nodes.SelectSingleNode("MOBILE").InnerText

                    Dim tip As String = ""
                    If (name.Trim <> "") Then
                        tip = tip + " NAME : " + name + vbCrLf
                    End If
                    If (mobile.Trim <> "") Then
                        tip = tip + " MOBILE : " + mobile + vbCrLf
                    End If
                    If (phone.Trim <> "") Then
                        tip = tip + " PHONE : " + phone + vbCrLf
                    End If

                    tip = tip + " IP : " + nodes.Attributes.ItemOf("IP").InnerText
                    node.ToolTipText = tip



                    'node.ToolTipText = " NAME : " + nodes.SelectSingleNode("NAME").InnerText + vbCrLf + " PHONE : " + nodes.SelectSingleNode("PHONE").InnerText + vbCrLf + " MOBILE : " + nodes.SelectSingleNode("MOBILE").InnerText + vbCrLf + " IP : " + nodes.Attributes.ItemOf("IP").InnerText

                    If bOnlineContact = True Then   'Show List Contacts Online
                        If dictContacts.ContainsKey(nodes.Attributes.ItemOf("IP").InnerText) Then
                            node.ImageIndex = 1
                            node.SelectedImageIndex = 1
                            treeview.Nodes.Item(i).Nodes.AddRange(New TreeNode() {node})
                        End If
                    Else                            'Show All Contacts
                        If dictContacts.ContainsKey(nodes.Attributes.ItemOf("IP").InnerText) Then
                            node.ImageIndex = 1
                            node.SelectedImageIndex = 1
                        Else
                            node.ImageIndex = 0
                            node.SelectedImageIndex = 0
                        End If
                        treeview.Nodes.Item(i).Nodes.AddRange(New TreeNode() {node})
                    End If

                Next
            Next
        Catch ex As Exception
        End Try
    End Sub

    Public Sub ReadYourContact(ByVal xmlFile As String, ByVal cbx As ComboBox, ByVal dict As Dictionary(Of String, String))

        Try
            Dim xmlRead As New XmlDocument
            xmlRead.Load(xmlFile)

            For i As Integer = 0 To cbx.Items.Count - 1
                For Each nodes As XmlNode In xmlRead.DocumentElement.SelectNodes("/Contacts/group[@name = '" & cbx.Items(i).ToString & "']/contact")
                    dict.Add(nodes.Attributes.ItemOf("IP").InnerText, nodes.SelectSingleNode("NAME").InnerText)
                Next
            Next
        Catch ex As Exception
        End Try
    End Sub

    Public Sub SearchContact(ByVal xmlFile As String, ByVal treeview As TreeView, ByVal cbx As ComboBox, ByVal tbx As TextBox)
        Try
            Dim xmlRead As New XmlDocument
            xmlRead.Load(xmlFile)

            For i As Integer = 0 To cbx.Items.Count - 1
                For Each nodes As XmlNode In xmlRead.DocumentElement.SelectNodes("/Contacts/group[@name = '" & cbx.Items(i).ToString & "']/contact")
                    If nodes.SelectSingleNode("NAME").InnerText.ToLower.Contains(tbx.Text.ToLower.Trim) Then
                        Dim node As New TreeNode(nodes.SelectSingleNode("NAME").InnerText)
                        node.ToolTipText = " IP : " + nodes.Attributes.ItemOf("IP").InnerText
                        If bOnlineContact = True Then   'Show List Contacts Online
                            If dictContacts.ContainsKey(nodes.Attributes.ItemOf("IP").InnerText) Then
                                node.ImageIndex = 1
                                node.SelectedImageIndex = 1
                                treeview.Nodes.Item(i).Nodes.AddRange(New TreeNode() {node})
                            End If
                        Else                            'Show All Contacts
                            If dictContacts.ContainsKey(nodes.Attributes.ItemOf("IP").InnerText) Then
                                node.ImageIndex = 1
                                node.SelectedImageIndex = 1
                            Else
                                node.ImageIndex = 0
                                node.SelectedImageIndex = 0
                            End If
                            treeview.Nodes.Item(i).Nodes.AddRange(New TreeNode() {node})
                        End If

                    End If

                Next
            Next
        Catch ex As Exception
        End Try
    End Sub

    Public Sub SearchContact(ByVal xmlFile As String, ByVal treeview As TreeView, ByVal ListDept As List(Of String), ByVal tbx As TextBox)
        Try
            Dim xmlRead As New XmlDocument
            xmlRead.Load(xmlFile)

            For i As Integer = 0 To ListDept.Count - 1
                For Each nodes As XmlNode In xmlRead.DocumentElement.SelectNodes("/Contacts/group[@name = '" & ListDept.Item(i).ToString & "']/contact")
                    If nodes.SelectSingleNode("NAME").InnerText.ToLower.Contains(tbx.Text.ToLower.Trim) Then
                        Dim node As New TreeNode(nodes.SelectSingleNode("NAME").InnerText)

                        Dim name As String = nodes.SelectSingleNode("NAME").InnerText
                        Dim dept As String = ListDept(i).ToString
                        Dim phone As String = nodes.SelectSingleNode("PHONE").InnerText
                        Dim mobile As String = nodes.SelectSingleNode("MOBILE").InnerText

                        Dim tip As String = ""
                        If (name.Trim <> "") Then
                            tip = tip + " NAME : " + name + vbCrLf
                        End If
                        If (dept.Trim <> "") Then
                            tip = tip + " DEPT : " + name + vbCrLf
                        End If
                        If (mobile.Trim <> "") Then
                            tip = tip + " MOBILE : " + mobile + vbCrLf
                        End If
                        If (phone.Trim <> "") Then
                            tip = tip + " PHONE : " + phone + vbCrLf
                        End If

                        tip = tip + " IP : " + nodes.Attributes.ItemOf("IP").InnerText
                        node.ToolTipText = tip


                        'node.ToolTipText = " NAME : " + nodes.SelectSingleNode("NAME").InnerText + vbCrLf + " PHONE : " + nodes.SelectSingleNode("PHONE").InnerText + vbCrLf + " MOBILE : " + nodes.SelectSingleNode("MOBILE").InnerText + vbCrLf + " IP : " + nodes.Attributes.ItemOf("IP").InnerText

                        If bOnlineContact = True Then   'Show List Contacts Online
                            If dictContacts.ContainsKey(nodes.Attributes.ItemOf("IP").InnerText) Then
                                node.ImageIndex = 1
                                node.SelectedImageIndex = 1
                                treeview.Nodes.Item(i).Nodes.AddRange(New TreeNode() {node})
                            End If
                        Else                            'Show All Contacts
                            If dictContacts.ContainsKey(nodes.Attributes.ItemOf("IP").InnerText) Then
                                node.ImageIndex = 1
                                node.SelectedImageIndex = 1
                            Else
                                node.ImageIndex = 0
                                node.SelectedImageIndex = 0
                            End If
                            treeview.Nodes.Item(i).Nodes.AddRange(New TreeNode() {node})
                        End If

                    End If

                Next
            Next
        Catch ex As Exception
        End Try
    End Sub

    'Setting Management
    Public Sub AddNickName(ByVal xmlFile As String, ByVal name As String)
        Try
            Dim xmlAdd As New XmlDocument
            xmlAdd.Load(xmlFile)
            Dim myNode As XmlNode = xmlAdd.SelectSingleNode("/Setting/NickName")

            If myNode Is Nothing Then
                Dim nickName As XmlElement = xmlAdd.CreateElement("NickName")
                nickName.SetAttribute("Nick", name)
                xmlAdd.DocumentElement.AppendChild(nickName)

                Dim xmlTextWrite As XmlTextWriter = New XmlTextWriter(xmlFile, Nothing)
                xmlTextWrite.Formatting = Formatting.Indented
                xmlAdd.WriteContentTo(xmlTextWrite)
                xmlTextWrite.Close()
            End If
        Catch ex As Exception
        End Try
    End Sub

    Public Sub ReadNickName(ByVal xmlFile As String, ByVal textbox As TextBox)
        Try
            Dim xmlRead As XmlReader = XmlReader.Create(xmlFile)
            While xmlRead.Read
                If xmlRead.Name = "NickName" Then
                    Dim attribute As String = xmlRead("Nick")
                    If attribute IsNot Nothing Then
                        textbox.Text = attribute
                    End If
                End If
            End While
            xmlRead.Close()
        Catch ex As Exception
        End Try
    End Sub

    Public Function ReadNickName(ByVal xmlFile As String) As String
        Dim nickname As String = ""
        Try
            Dim xmlRead As XmlReader = XmlReader.Create(xmlFile)
            While xmlRead.Read
                If xmlRead.Name = "NickName" Then
                    Dim attribute As String = xmlRead("Nick")
                    If attribute IsNot Nothing Then
                        nickname = attribute
                    End If
                End If
            End While
            xmlRead.Close()
        Catch ex As Exception
        End Try
        Return nickname
    End Function

    Public Sub RemoveNickName(ByVal xmlFile As String)
        Try
            Dim xmlRemove As New XmlDocument
            xmlRemove.Load(xmlFile)
            Dim myNode As XmlNode = xmlRemove.SelectSingleNode("/Setting/NickName")
            If Not myNode Is Nothing Then
                myNode.ParentNode.RemoveChild(myNode)
                xmlRemove.Save(xmlFile)
            End If
        Catch ex As Exception
        End Try
    End Sub

    Public Sub ReplaceNickName(ByVal xmlFile As String, ByVal textbox As TextBox)
        Try
            RemoveNickName(xmlFile)
            AddNickName(xmlFile, textbox.Text.Trim)
        Catch ex As Exception
        End Try
    End Sub
    '-----------
    Public Sub AddSaveFilePath(ByVal xmlFile As String, ByVal filepath As String)
        Try
            Dim xmlAdd As New XmlDocument
            xmlAdd.Load(xmlFile)
            Dim myNode As XmlNode = xmlAdd.SelectSingleNode("/Setting/FilePath")

            If myNode Is Nothing Then
                Dim path As XmlElement = xmlAdd.CreateElement("FilePath")
                path.SetAttribute("Path", filepath)
                xmlAdd.DocumentElement.AppendChild(path)

                Dim xmlTextWrite As XmlTextWriter = New XmlTextWriter(xmlFile, Nothing)
                xmlTextWrite.Formatting = Formatting.Indented
                xmlAdd.WriteContentTo(xmlTextWrite)
                xmlTextWrite.Close()
            End If
        Catch ex As Exception
        End Try
    End Sub

    Public Sub ReadFilePath(ByVal xmlFile As String, ByVal tbx As TextBox)
        Try
            Dim xmlRead As XmlReader = XmlReader.Create(xmlFile)
            While xmlRead.Read
                If xmlRead.Name = "FilePath" Then
                    Dim attribute As String = xmlRead("Path")
                    If attribute IsNot Nothing Then
                        tbx.Text = attribute
                    End If
                End If
            End While
            xmlRead.Close()
        Catch ex As Exception
        End Try
    End Sub

    Public Function ReadFilePath(ByVal xmlFile As String) As String
        Dim curPath As String = ""
        Try
            Dim xmlRead As XmlReader = XmlReader.Create(xmlFile)
            While xmlRead.Read
                If xmlRead.Name = "FilePath" Then
                    Dim attribute As String = xmlRead("Path")
                    If attribute IsNot Nothing Then
                        curPath = attribute
                    End If
                End If
            End While
            xmlRead.Close()
        Catch ex As Exception
        End Try
        Return curPath
    End Function

    Public Sub RemoveFilePath(ByVal xmlFile As String)
        Try
            Dim xmlRemove As New XmlDocument
            xmlRemove.Load(xmlFile)
            Dim myNode As XmlNode = xmlRemove.SelectSingleNode("/Setting/FilePath")
            If Not myNode Is Nothing Then
                myNode.ParentNode.RemoveChild(myNode)
                xmlRemove.Save(xmlFile)
            End If
        Catch ex As Exception
        End Try
    End Sub

    Public Sub ReplaceFilePath(ByVal xmlFile As String, ByVal textbox As TextBox)
        Try
            RemoveFilePath(xmlFile)
            AddSaveFilePath(xmlFile, textbox.Text.Trim)
        Catch ex As Exception
        End Try
    End Sub

    Public Sub AddElement_(ByVal xmlFile As String, ByVal element As String)
        Try
            Dim xmlAdd As New XmlDocument
            xmlAdd.Load(xmlFile)
            Dim myNode As XmlNode = xmlAdd.SelectSingleNode("/Setting/" + element)

            If myNode Is Nothing Then
                Dim Element_ As XmlElement = xmlAdd.CreateElement(element)
                Element_.SetAttribute("boolean", "true")
                xmlAdd.DocumentElement.AppendChild(Element_)

                Dim xmlTextWrite As XmlTextWriter = New XmlTextWriter(xmlFile, Nothing)
                xmlTextWrite.Formatting = Formatting.Indented
                xmlAdd.WriteContentTo(xmlTextWrite)
                xmlTextWrite.Close()
            End If
        Catch ex As Exception
        End Try
    End Sub

    Public Function CheckElement_(ByVal xmlFile As String, ByVal element As String) As Boolean
        Dim bCheck As Boolean
        Try
            Dim xmlCheck As New XmlDocument
            xmlCheck.Load(xmlFile)
            Dim myNode As XmlNode = xmlCheck.SelectSingleNode("/Setting/" + element)

            If myNode Is Nothing Then
                bCheck = False
            Else
                bCheck = True
            End If
        Catch ex As Exception
        End Try
        Return bCheck
    End Function

    Public Sub RemoveElement_(ByVal xmlFile As String, ByVal element As String)
        Try
            Dim xmlRemove As New XmlDocument
            xmlRemove.Load(xmlFile)
            Dim myNode As XmlNode = xmlRemove.SelectSingleNode("/Setting/" + element)
            If Not myNode Is Nothing Then
                myNode.ParentNode.RemoveChild(myNode)
                xmlRemove.Save(xmlFile)
            End If
        Catch ex As Exception
        End Try
    End Sub

    'History Management
    Public Sub AddHistory(ByVal xmlFile As String, ByVal code As String, ByVal filename As String, ByVal pcname As String, ByVal size As String, ByVal status As String, ByVal date_ As String, ByVal type As String)

        Try
            Dim xmlAdd As New XmlDocument
            xmlAdd.Load(xmlFile)

            'Checking Containt Of Ip On Your List Contacts
            Dim checkNode As XmlNode = xmlAdd.SelectSingleNode("/History/HFile[@code='" & code & "']")
            If Not checkNode Is Nothing Then
                '
            Else
                'Checking Containt Of Group

                Dim newHistory As XmlElement = xmlAdd.CreateElement("HFile")
                newHistory.SetAttribute("code", code)

                Dim fn As XmlElement = xmlAdd.CreateElement("FileName")
                fn.InnerText = filename
                newHistory.AppendChild(fn)

                Dim fn1 As XmlElement = xmlAdd.CreateElement("PCName")
                fn1.InnerText = pcname
                newHistory.AppendChild(fn1)

                Dim fn2 As XmlElement = xmlAdd.CreateElement("Size")
                fn2.InnerText = size
                newHistory.AppendChild(fn2)

                Dim fn3 As XmlElement = xmlAdd.CreateElement("Status")
                fn3.InnerText = status
                newHistory.AppendChild(fn3)

                Dim fn4 As XmlElement = xmlAdd.CreateElement("Date")
                fn4.InnerText = date_
                newHistory.AppendChild(fn4)

                Dim fn5 As XmlElement = xmlAdd.CreateElement("Type")
                fn5.InnerText = type
                newHistory.AppendChild(fn5)

                xmlAdd.DocumentElement.AppendChild(newHistory)

                Dim xmlTextWrite As XmlTextWriter = New XmlTextWriter(xmlFile, Nothing)
                xmlTextWrite.Formatting = Formatting.Indented
                xmlAdd.WriteContentTo(xmlTextWrite)
                xmlTextWrite.Close()

            End If
        Catch ex As Exception
        End Try
    End Sub

    Public Sub RemoveHistory(ByVal xmlFile As String, ByVal code As String)
        Try
            Dim xmlRemove As New XmlDocument
            xmlRemove.Load(xmlFile)
            Dim myNode As XmlNode = xmlRemove.SelectSingleNode("/History/HFile[@code='" & code & "']")
            If Not myNode Is Nothing Then
                myNode.ParentNode.RemoveChild(myNode)
                xmlRemove.Save(xmlFile)
            End If
        Catch ex As Exception
        End Try
    End Sub

    Public Sub RemoveHistory(ByVal xmlFile As String)
        Try
            Dim xmlRemove As New XmlDocument
            xmlRemove.Load(xmlFile)
            Dim myNode As XmlNode = xmlRemove.SelectSingleNode("/History/HFile")
            If Not myNode Is Nothing Then
                myNode.ParentNode.RemoveAll()
                xmlRemove.Save(xmlFile)
            End If
        Catch ex As Exception
        End Try
    End Sub

    Public Function CountRow(ByVal xmlFile As String, ByVal type_ As String) As Integer
        Dim nRow As Integer = 0
        Dim xmlRead As New XmlDocument
        xmlRead.Load(xmlFile)
        Dim type As String
        For Each nodes As XmlNode In xmlRead.DocumentElement.SelectNodes("/History/HFile")
            type = nodes.SelectSingleNode("Type").InnerText
            If type = type_ Then
                nRow = nRow + 1
            End If
        Next
        Return nRow
    End Function

    Public Sub ReadHistory(ByVal xmlFile As String, ByVal gridRecv As DataGridView, ByVal gridSend As DataGridView)
        Dim code As String
        Dim filename As String
        Dim pcname As String
        Dim size As String
        Dim status As String
        Dim date_ As String
        Dim type As String

        Try
            Dim xmlRead As New XmlDocument
            xmlRead.Load(xmlFile)

            For Each nodes As XmlNode In xmlRead.DocumentElement.SelectNodes("/History/HFile")

                code = nodes.Attributes.ItemOf("code").InnerText
                filename = nodes.SelectSingleNode("FileName").InnerText
                pcname = nodes.SelectSingleNode("PCName").InnerText
                size = nodes.SelectSingleNode("Size").InnerText
                status = nodes.SelectSingleNode("Status").InnerText
                date_ = nodes.SelectSingleNode("Date").InnerText
                type = nodes.SelectSingleNode("Type").InnerText

                If type = "Send" Then
                    Dim row As String() = {filename, pcname, size, status, date_, code}
                    gridSend.Rows.Add(row)
                ElseIf type = "Recv" Then
                    Dim row As String() = {filename, pcname, size, status, date_, code}
                    gridRecv.Rows.Add(row)
                End If

            Next
        Catch ex As Exception
        End Try
    End Sub

    'Connecting Management
    Public Sub AddElement(ByVal xmlFile As String, ByVal element As String)
        Try
            Dim xmlAddElement As New XmlDocument
            xmlAddElement.Load(xmlFile)
            Dim myNode As XmlNode = xmlAddElement.SelectSingleNode("/Setting/" + element)
            If myNode Is Nothing Then
                Dim newElement As XmlElement = xmlAddElement.CreateElement(element)
                xmlAddElement.DocumentElement.AppendChild(newElement)

                Dim xmlTextWrite As XmlTextWriter = New XmlTextWriter(xmlFile, Nothing)
                xmlTextWrite.Formatting = Formatting.Indented
                xmlAddElement.WriteContentTo(xmlTextWrite)
                xmlTextWrite.Close()
            End If
        Catch ex As Exception
        End Try
    End Sub

    'Add Connecting
    Public Sub AddConnecting(ByVal xmlFile As String, ByVal ip As String, ByVal name As String)
        Try
            Dim xmlAddConnecting As New XmlDocument
            xmlAddConnecting.Load(xmlFile)

            Dim myNode As XmlNode = xmlAddConnecting.SelectSingleNode("/Setting/Connecting/contact[@IP='" & ip & "']")
            If myNode Is Nothing Then
                myNode = xmlAddConnecting.SelectSingleNode("/Setting/Connecting")
                Dim newContact As XmlElement = xmlAddConnecting.CreateElement("contact")
                newContact.SetAttribute("IP", ip)
                Dim fn As XmlElement = xmlAddConnecting.CreateElement("NAME")
                fn.InnerText = name
                newContact.AppendChild(fn)
                myNode.AppendChild(newContact)

                Dim xmlTextWrite As XmlTextWriter = New XmlTextWriter(xmlFile, Nothing)
                xmlTextWrite.Formatting = Formatting.Indented
                xmlAddConnecting.WriteContentTo(xmlTextWrite)
                xmlTextWrite.Close()
            End If

        Catch
        End Try
    End Sub
    ' --------------------------------
    Public Sub RemoveIpUpdate(ByVal xmlFile As String)
        Try
            Dim xmlRemove As New XmlDocument
            xmlRemove.Load(xmlFile)

            Dim myNode As XmlNode = xmlRemove.SelectSingleNode("/Setting/IpUpdate")

            If Not myNode Is Nothing Then
                myNode.ParentNode.RemoveChild(myNode)
                xmlRemove.Save(xmlFile)
            End If
        Catch ex As Exception
        End Try
    End Sub

    Public Sub ReadIpUpdate(ByVal xmlFile As String)

        Try
            Dim xmlRead As XmlReader = XmlReader.Create(xmlFile)
            While xmlRead.Read
                If xmlRead.Name = "IpAdress" Then
                    Dim attribute As String = xmlRead("IP")
                    If attribute IsNot Nothing Then
                        AddIpUpdate(FILE_SETTING, attribute)
                    End If
                End If
            End While
            xmlRead.Close()
        Catch ex As Exception
        End Try
    End Sub



    Public Sub AddIpUpdate(ByVal xmlFile As String, ByVal ip As String)
        Try
            Dim xmlAddIpUpdate As New XmlDocument
            xmlAddIpUpdate.Load(xmlFile)
            Dim myNode_ As XmlNode = xmlAddIpUpdate.SelectSingleNode("/Setting/IpUpdate/IpAdress[@IP='" & ip & "']")
            If myNode_ Is Nothing Then
                Dim myNode As XmlNode = xmlAddIpUpdate.SelectSingleNode("/Setting/IpUpdate")
                Dim newContact As XmlElement = xmlAddIpUpdate.CreateElement("IpAdress")
                newContact.SetAttribute("IP", ip)
                myNode.AppendChild(newContact)

                Dim xmlTextWrite As XmlTextWriter = New XmlTextWriter(xmlFile, Nothing)
                xmlTextWrite.Formatting = Formatting.Indented
                xmlAddIpUpdate.WriteContentTo(xmlTextWrite)
                xmlTextWrite.Close()
            End If
        Catch ex As Exception
        End Try
    End Sub

    Public Sub ReadIpUpdate(ByVal xmlFile As String, ByVal list As List(Of String))
        Try
            Dim xmlRead As New XmlDocument
            xmlRead.Load(xmlFile)
            For Each nodes As XmlNode In xmlRead.DocumentElement.SelectNodes("/Setting/IpUpdate/IpAdress")
                Dim ip As String = nodes.Attributes.ItemOf("IP").InnerText
                list.Add(ip)
            Next
        Catch ex As Exception
        End Try
    End Sub

    'Search Contact For Connecting
    Public Sub ReadYourContact(ByVal xmlFile As String, ByVal cbx As ComboBox, ByVal tbx As TextBox)

        Try
            Dim xmlRead As New XmlDocument
            xmlRead.Load(xmlFile)

            Dim myNode As XmlNode = xmlRead.SelectSingleNode("/Setting/Connecting/contact[@IP='" & cbx.Text & "']")

            If Not myNode Is Nothing Then
                tbx.Text = myNode.SelectSingleNode("NAME").InnerText
            Else
                tbx.Text = ""
            End If

        Catch ex As Exception
        End Try
    End Sub

    Public Sub ReadYourContact(ByVal xmlFile As String, ByVal cbx As ComboBox)
        Try
            Dim xmlRead As New XmlDocument
            xmlRead.Load(xmlFile)
            For Each nodes As XmlNode In xmlRead.DocumentElement.SelectNodes("/Setting/Connecting/contact")
                Dim ip As String = nodes.Attributes.ItemOf("IP").InnerText
                cbx.Items.Add(ip)
            Next
        Catch ex As Exception
        End Try
    End Sub

    'Version
    Public Sub AddVersion(ByVal xmlFile As String, ByVal version As String)
        Try
            Dim xmlAdd As New XmlDocument
            xmlAdd.Load(xmlFile)
            Dim myNode As XmlNode = xmlAdd.SelectSingleNode("/Setting/Version")

            If myNode Is Nothing Then
                Dim nickName As XmlElement = xmlAdd.CreateElement("Version")
                nickName.SetAttribute("Version", version)
                xmlAdd.DocumentElement.AppendChild(nickName)

                Dim xmlTextWrite As XmlTextWriter = New XmlTextWriter(xmlFile, Nothing)
                xmlTextWrite.Formatting = Formatting.Indented
                xmlAdd.WriteContentTo(xmlTextWrite)
                xmlTextWrite.Close()
            End If
        Catch ex As Exception
        End Try
    End Sub

    Public Function ReadVersion(ByVal xmlFile As String) As String
        Dim nickname As String = ""
        Try
            Dim xmlRead As XmlReader = XmlReader.Create(xmlFile)
            While xmlRead.Read
                If xmlRead.Name = "Version" Then
                    Dim attribute As String = xmlRead("Version")
                    If attribute IsNot Nothing Then
                        nickname = attribute
                    End If
                End If
            End While
            xmlRead.Close()
        Catch ex As Exception
        End Try
        Return nickname
    End Function

    Public Sub RemoveVersion(ByVal xmlFile As String)
        Try
            Dim xmlRemove As New XmlDocument
            xmlRemove.Load(xmlFile)
            Dim myNode As XmlNode = xmlRemove.SelectSingleNode("/Setting/Version")
            If Not myNode Is Nothing Then
                myNode.ParentNode.RemoveChild(myNode)
                xmlRemove.Save(xmlFile)
            End If
        Catch ex As Exception
        End Try
    End Sub

    Public Sub ReplaceVersion(ByVal xmlFile As String, ByVal version As String)
        Try
            RemoveVersion(xmlFile)
            AddVersion(xmlFile, version)
        Catch ex As Exception
        End Try
    End Sub


    'Write Log
    Public Sub WriteLog(ByVal xmlFile As String, ByVal text As String)
        Try
            Dim xmlAdd As New XmlDocument
            xmlAdd.Load(xmlFile)
            Dim time As String = Date.Now.ToString
            'Checking Containt Of Ip On Your List Contacts
            Dim checkNode As XmlNode = xmlAdd.SelectSingleNode("/Log/Update[@info='" & time & "']")
            If Not checkNode Is Nothing Then
                '
            Else
                Dim newHistory As XmlElement = xmlAdd.CreateElement("Update")
                newHistory.SetAttribute("info", time & "  " & text)

                xmlAdd.DocumentElement.AppendChild(newHistory)

                Dim xmlTextWrite As XmlTextWriter = New XmlTextWriter(xmlFile, Nothing)
                xmlTextWrite.Formatting = Formatting.Indented
                xmlAdd.WriteContentTo(xmlTextWrite)
                xmlTextWrite.Close()
            End If
        Catch ex As Exception

        End Try
    End Sub


    'Read Dept Contact To Setting
    Public Sub ReadDeptContact(ByVal xmlFile As String, ByVal ip As String, ByVal tbxName As TextBox, ByVal tbxPhone As TextBox, _
                               ByVal tbxMobile As TextBox, ByVal cbxDept As ComboBox)

        Try
            Dim xmlRead As New XmlDocument
            xmlRead.Load(xmlFile)

            For i As Integer = 0 To cbxDept.Items.Count - 1
                For Each nodes As XmlNode In xmlRead.DocumentElement.SelectNodes("/Contacts/group[@name = '" & cbxDept.Items(i).ToString & "']/contact")
                    If nodes.Attributes.ItemOf("IP").InnerText = ip Then
                        tbxName.Text = nodes.SelectSingleNode("NAME").InnerText
                        tbxMobile.Text = nodes.SelectSingleNode("MOBILE").InnerText
                        tbxPhone.Text = nodes.SelectSingleNode("PHONE").InnerText
                        cbxDept.Text = cbxDept.Items(i).ToString
                        Exit For
                    End If
                Next
            Next

        Catch ex As Exception
        End Try

    End Sub

    Public Sub ReadDeptContact(ByVal xmlFile As String, ByVal ip As String, ByRef tbxName As String, ByRef tbxPhone As String, _
                               ByRef tbxMobile As String, ByRef tbxDept As String, ByVal cbxDept As ComboBox)

        Try
            Dim xmlRead As New XmlDocument
            xmlRead.Load(xmlFile)

            For i As Integer = 0 To cbxDept.Items.Count - 1
                For Each nodes As XmlNode In xmlRead.DocumentElement.SelectNodes("/Contacts/group[@name = '" & cbxDept.Items(i).ToString & "']/contact")
                    If nodes.Attributes.ItemOf("IP").InnerText = ip Then
                        tbxName = nodes.SelectSingleNode("NAME").InnerText
                        tbxMobile = nodes.SelectSingleNode("MOBILE").InnerText
                        tbxPhone = nodes.SelectSingleNode("PHONE").InnerText
                        tbxDept = cbxDept.Items(i).ToString
                        Exit For
                    End If
                Next
            Next

        Catch ex As Exception
        End Try

    End Sub

    Public Sub AddContact(ByVal xmlFile As String, ByVal group As String, ByVal ip As String, ByVal tbxNickName As String, ByVal tbxFullName As String, ByVal tbxMobile As String, ByVal tbxPhone As String)

        Try
            Dim xmlAdd As New XmlDocument
            xmlAdd.Load(xmlFile)

            'Checking Containt Of Ip On Your List Contacts
            Dim checkNode As XmlNode = xmlAdd.SelectSingleNode("/Contacts/group/contact[@IP='" & ip & "']")
            If Not checkNode Is Nothing Then
                'MessageBox.Show("This Contact Is Contain On Your Contacts! You Can Move To Other Groups.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                'Checking Containt Of Group
                Dim myNode As XmlNode = xmlAdd.SelectSingleNode("/Contacts/group[@name='" & group & "']")
                If myNode Is Nothing Then
                    'MessageBox.Show("This Group Is Not Contain On Your List, Please Make New Group", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    If group = "" Or tbxFullName = "" Then
                        Return
                    End If
                    AddGroup(FILE_DEPTCONTACT, group)
                    Dim newContact As XmlElement = xmlAdd.CreateElement("contact")
                    newContact.SetAttribute("IP", ip)

                    Dim fn As XmlElement = xmlAdd.CreateElement("NICKNAME")
                    fn.InnerText = tbxNickName
                    newContact.AppendChild(fn)

                    Dim fn0 As XmlElement = xmlAdd.CreateElement("NAME")
                    fn0.InnerText = tbxFullName
                    newContact.AppendChild(fn0)

                    Dim fn1 As XmlElement = xmlAdd.CreateElement("PHONE")
                    fn1.InnerText = tbxPhone
                    newContact.AppendChild(fn1)


                    Dim fn2 As XmlElement = xmlAdd.CreateElement("MOBILE")
                    fn2.InnerText = tbxMobile
                    newContact.AppendChild(fn2)


                    myNode.AppendChild(newContact)

                    Dim xmlTextWrite As XmlTextWriter = New XmlTextWriter(xmlFile, Nothing)
                    xmlTextWrite.Formatting = Formatting.Indented
                    xmlAdd.WriteContentTo(xmlTextWrite)
                    xmlTextWrite.Close()
                Else
                    'If tbxFullName = "" Then
                    '    Return
                    'End If
                    Dim newContact As XmlElement = xmlAdd.CreateElement("contact")
                    newContact.SetAttribute("IP", ip)

                    Dim fn As XmlElement = xmlAdd.CreateElement("NICKNAME")
                    fn.InnerText = tbxNickName
                    newContact.AppendChild(fn)

                    Dim fn0 As XmlElement = xmlAdd.CreateElement("NAME")
                    fn0.InnerText = tbxFullName
                    newContact.AppendChild(fn0)

                    Dim fn1 As XmlElement = xmlAdd.CreateElement("PHONE")
                    fn1.InnerText = tbxPhone
                    newContact.AppendChild(fn1)


                    Dim fn2 As XmlElement = xmlAdd.CreateElement("MOBILE")
                    fn2.InnerText = tbxMobile
                    newContact.AppendChild(fn2)


                    myNode.AppendChild(newContact)

                    Dim xmlTextWrite As XmlTextWriter = New XmlTextWriter(xmlFile, Nothing)
                    xmlTextWrite.Formatting = Formatting.Indented
                    xmlAdd.WriteContentTo(xmlTextWrite)
                    xmlTextWrite.Close()
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Public Sub ReplaceDeptContact(ByVal ip As String, ByVal tbxNickName As String, ByVal cbxDept As String, ByVal tbxFullName As String, ByVal tbxMobile As String, ByVal tbxPhone As String)
        Try
            RemoveContact(FILE_DEPTCONTACT, ip)
            AddContact(FILE_DEPTCONTACT, cbxDept, ip, tbxNickName, tbxFullName, tbxMobile, tbxPhone)
        Catch ex As Exception
        End Try
    End Sub


End Class
