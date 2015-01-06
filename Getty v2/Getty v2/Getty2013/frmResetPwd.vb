Public Class frmResetPwd

    Public attempt As Integer = 0
    Dim drag As Boolean
    Dim mousex As Integer
    Dim mousey As Integer

    Private Sub frmResetPwd_FormClosing(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
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

    Protected Overrides ReadOnly Property CreateParams() As System.Windows.Forms.CreateParams
        Get
            Const DROPSHADOW = &H20000
            Dim cParam As CreateParams = MyBase.CreateParams
            cParam.ClassStyle = cParam.ClassStyle Or DROPSHADOW
            Return cParam
        End Get
    End Property

    Private Sub btn_change_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_change.Click
        changePassword()
    End Sub

    Private Sub txt_newconf_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_newconf.KeyUp
        If e.KeyCode = Keys.Enter Then
            If attempt <> 1 Then
                attempt = 1
                changePassword()
            Else
                attempt = 0
            End If
        End If
    End Sub

    Sub changePassword()
        If txt_newpwd.Text <> "" Or txt_newconf.Text <> "" Then
            If txt_newpwd.Text = txt_newconf.Text Then
                If Len(txt_newpwd.Text) < 6 Then
                    MsgBox("Minimum of 6 characters length for password.", vbExclamation, "System Message")
                Else
                    Try
                        If Not EnsureDBOpen() Then
                            techSupportCritical()
                            Return
                        End If
                        Dim encpwd As String = MD5(txt_newpwd.Text)
                        Dim insert As Boolean = execNonQuery("UPDATE tbl_users SET user_password='" & encpwd & "' WHERE user_id='" & usr_unqid & "' AND this_site='" & conn_location & "'")
                        If insert = True Then
                            ForceDBClose()
                            MsgBox("Password has been reset!", vbInformation, "System Message")
                            frmMessages.Show()
                            cmd_close = False
                            Me.Close()
                        Else
                            ForceDBClose()
                            MsgBox("Reset password failed.", vbCritical, "Error")
                        End If
                    Finally
                        ForceDBClose()
                    End Try
                End If
            Else
                MsgBox("Password doesn't match!", vbExclamation, "System Message")
            End If
        Else
            MsgBox("Fill-up all fields.", vbExclamation, "System Message")
        End If
        clrscr()
    End Sub

    Private Sub btn_skip_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_skip.Click
        If MsgBox("You don't want to change your default password ?", vbQuestion + vbYesNo, "Skip") = vbYes Then
            frmMessages.Show()
            cmd_close = False
            Me.Close()
            cmd_close = True
        End If
    End Sub

    Sub clrscr()
        txt_newpwd.Clear()
        txt_newconf.Clear()
        txt_newpwd.Focus()
    End Sub

    Private Sub frmResetPwd_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cmd_close = True
    End Sub
End Class