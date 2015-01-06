Imports MySql.Data.MySqlClient
Imports System.Net.NetworkInformation

Public Class frmSettings

    Public attempt As Integer = 0
    Dim drag As Boolean
    Dim mousex As Integer
    Dim mousey As Integer

    Private Sub frmSettings_FormClosing(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
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

    Private Sub frmSettings_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Not EnsureDBOpen() Then
            techSupportCritical()
            cmd_close = False
            Me.Close()
            cmd_close = True
            Return
        End If
        cmd_close = True
        displayProfile()
        Me.ShowInTaskbar = False
    End Sub

    Private Sub frmSettings_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseDown
        drag = True
        mousex = Windows.Forms.Cursor.Position.X - Me.Left
        mousey = Windows.Forms.Cursor.Position.Y - Me.Top
    End Sub

    Private Sub frmSettings_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseMove
        If drag Then
            Me.Top = Windows.Forms.Cursor.Position.Y - mousey
            Me.Left = Windows.Forms.Cursor.Position.X - mousex
        End If
    End Sub

    Private Sub frmSettings_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseUp
        drag = False
    End Sub

    Protected Overrides ReadOnly Property CreateParams() As System.Windows.Forms.CreateParams
        Get
            Const DROPSHADOW = &H20000
            Dim cParam As CreateParams = MyBase.CreateParams
            cParam.ClassStyle = cParam.ClassStyle Or DROPSHADOW
            Return cParam
        End Get
    End Property

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        cmd_close = False
        Me.Close()
        cmd_close = True
    End Sub

    Public Sub displayProfile()
        If EnsureDBOpen() Then
            txt_campaign.Text = usr_campaign
            txt_username.Text = user_id
            txt_workstation.Text = Environment.MachineName
            txt_fname.Text = execScalarString("SELECT profile_fname FROM tbl_profiles WHERE user_username='" & user_id & "'")
            txt_lname.Text = execScalarString("SELECT profile_lname FROM tbl_profiles WHERE user_username='" & user_id & "'")
            txt_empid.Text = execScalarString("SELECT profile_empid FROM tbl_profiles WHERE user_username='" & user_id & "'")
            txt_teamname.Text = team_name
        End If
        If IsOffline() Then
            techSupportCritical()
            cmd_close = False
            Me.Close()
            cmd_close = True
        End If
    End Sub

    Private Sub btn_save_set_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_save_set.Click
        changePwd()
    End Sub

    Public Sub changePwd()
        If txt_set_pwd.Text <> "" Or txt_set_pwdconf.Text <> "" Then
            If Not EnsureDBOpen() Then
                techSupportCritical()
                Return
            End If
            Dim curr_pwd As String = MD5(txt_set_old.Text)
            Dim check As Integer = execScalarInt("SELECT COUNT(*) FROM tbl_users WHERE user_password='" & curr_pwd & "' AND this_site='" & conn_location & "'")
            If check > 0 Then
                If txt_set_pwd.Text = txt_set_pwdconf.Text Then
                    If Len(txt_set_pwd.Text) < 6 Then
                        MsgBox("Minimum of 6 characters length for password.", vbExclamation, "System Message")
                    Else
                        Dim encpwd As String = MD5(txt_set_pwd.Text)
                        Dim insert As Boolean = execNonQuery("UPDATE tbl_users SET user_password='" & encpwd & "' WHERE user_id='" & usr_unqid & "' AND this_site='" & conn_location & "'")
                        If insert = True Then
                            MsgBox("Password has been reset!", vbInformation, "System Message")
                            cmd_close = False
                            Me.Close()
                            cmd_close = True
                        Else
                            MsgBox("Reset password failed.", vbCritical, "Error")
                        End If
                    End If
                Else
                    MsgBox("Password doesn't match!", vbExclamation, "System Message")
                End If
            Else
                MsgBox("Incorrect old password!", vbExclamation, "System Message")
            End If
            ForceDBClose()
        Else
            MsgBox("Fill-up all fields.", vbExclamation, "System Message")
        End If
        clearText()
    End Sub

    Public Sub clearText()
        txt_set_pwd.Clear()
        txt_set_pwdconf.Clear()
        txt_set_pwd.Focus()
    End Sub

    Private Sub txt_set_pwdconf_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_set_pwdconf.KeyUp
        If e.KeyCode = Keys.Enter Then
            If attempt <> 1 Then
                attempt = 1
                changePwd()
            Else
                attempt = 0
            End If
        End If
    End Sub
End Class