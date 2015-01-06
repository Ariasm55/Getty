Public Class frmForceLogin

    Dim drag As Boolean
    Dim mousex As Integer
    Dim mousey As Integer

    Private Sub frmForceLogin_FormClosing(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dim Cancel As Boolean = eventArgs.Cancel
        Dim UnloadMode As System.Windows.Forms.CloseReason = eventArgs.CloseReason
        If UnloadMode = CloseReason.UserClosing Then
            'Prevent it closing
            Cancel = cmd_close
        End If
        'Allow it to close if it wasn't the user's action
        eventArgs.Cancel = Cancel
        ForceDBClose()
    End Sub

    Private Sub frmForceLogin_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cmd_close = True
    End Sub

    Protected Overrides ReadOnly Property CreateParams() As System.Windows.Forms.CreateParams
        Get
            Const DROPSHADOW = &H20000
            Dim cParam As CreateParams = MyBase.CreateParams
            cParam.ClassStyle = cParam.ClassStyle Or DROPSHADOW
            Return cParam
        End Get
    End Property

    Private Sub btn_send_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_send.Click
        If txt_reason.Text <> "" Then
            Try
                If EnsureDBOpen() Then
                    execNonQuery("INSERT INTO tbl_force_log (administrator,station,reason,date_issue,this_site) VALUES('" & user_id & "','" & Environment.MachineName & "','" & txt_reason.Text & "','" & DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") & "','" & conn_location & "')")
                    cmd_close = False
                    Me.Close()
                    cmd_close = True
                Else
                    techSupportCritical()
                End If
            Finally
                ForceDBClose()
            End Try
        Else
            MsgBox("Please type your reason.", vbExclamation, "System Message")
        End If
    End Sub
End Class