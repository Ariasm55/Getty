Imports MySql.Data.MySqlClient

Public Class frmHighPriorityMsg

    Private Sub frmHighPriorityMsg_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.ShowInTaskbar = False
    End Sub

    Protected Overrides ReadOnly Property CreateParams() As System.Windows.Forms.CreateParams
        Get
            Const DROPSHADOW = &H20000
            Dim cParam As CreateParams = MyBase.CreateParams
            cParam.ClassStyle = cParam.ClassStyle Or DROPSHADOW
            Return cParam
        End Get
    End Property

    Private Sub cb_read_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cb_read.CheckedChanged
        If cb_read.Checked = True Then
            btn_read.Visible = True
        Else
            btn_read.Visible = False
        End If
    End Sub

    Private Sub btn_read_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_read.Click
        'Dim check_user = checkExist("SELECT COUNT(*) FROM tbl_messages WHERE message_id='" & msg_id.Text & "' AND this_site='" & conn_location & "'")
        'If check_user > 0 Then
        'Dim getreaders As String = getField("SELECT messages_read FROM tbl_messages WHERE message_id='" & msg_id.Text & "' AND this_site='" & conn_location & "'", "messages_read")
        'Dim concat_readers = getreaders & user_id & ","
        'updateQuery("UPDATE tbl_messages SET messages_read='" & concat_readers & "' WHERE message_id='" & msg_id.Text & "' AND this_site='" & conn_location & "'")
        'End If

        Try
            If EnsureDBOpen() Then
                Dim query As String = "SELECT * FROM tbl_messages AS m INNER JOIN tbl_recipients AS r ON m.message_id = r.messages_id WHERE r.user_username='" & user_id & "' AND m.message_id='" & msg_id.Text & "' AND this_site='" & conn_location & "'"
                Dim adapter As MySqlDataAdapter
                adapter = New MySqlDataAdapter(query, sqlcon)
                Dim ds = New DataSet
                adapter.Fill(ds, "message_content")

                Dim check_user = checkExist("SELECT COUNT(*) FROM tbl_messages WHERE message_id='" & msg_id.Text & "' AND this_site='" & conn_location & "'")
                If check_user > 0 Then
                    If ds.Tables(0).Rows(0).Item("recipient_read").ToString = "0" Then
                        updateQuery("UPDATE tbl_recipients SET recipient_read='1' WHERE messages_id='" & msg_id.Text & "' AND user_username='" & user_id & "'")
                    End If
                End If

                frmMessages.displayMessages()

                cmd_close = False
                Me.Close()
                cmd_close = True
            Else
                techSupportCritical()
            End If
        Finally
            ForceDBClose()
        End Try
        
    End Sub
End Class