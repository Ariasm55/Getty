Imports System.Runtime.InteropServices
Imports System.Reflection
Imports MySql.Data.MySqlClient
Imports System.Net.NetworkInformation
Imports System.Net
Imports System
Imports System.IO
Imports System.Text.RegularExpressions

Public Class frmLoginGetty

    Public attempt As Integer = 0
    Public attempt_frgt As Integer = 0
    Public forgot As Integer = 0
    Public tmp_srv_ip As String = ""
    Public tmp_srv_dbname As String = ""
    Public tmp_srv_root As String = ""
    Public tmp_srv_pass As String = ""
    Public dateAdded As String = ""

    Private Sub frmLoginGetty_FormClosing(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
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

    Private Sub frmLoginGetty_HandleCreated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.HandleCreated
        KeyboardJammer.Jam()
    End Sub

    Private Sub frmLoginGetty_HandleDestroyed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.HandleDestroyed
        KeyboardJammer.UnJam()
    End Sub

    Private Sub frmLoginGetty_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        __Version.Text = GettyVersion()
        checkLocalFile(locstamp)
        checkHistoryLogs(ensureData)
        checkHistoryLogs(historyLogs)
        txt_uname.Focus()
        cmd_close = True
        lbl_station.Text = Environment.MachineName
        frm_pnl.BringToFront()
        fadeIn.Start()
    End Sub

    Private Sub fadeIn_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fadeIn.Tick
        If Me.Opacity < 100 Then
            Me.Opacity += 0.4
        Else
            fadeIn.Stop()
        End If
    End Sub

    Private Sub btn_login_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_login.Click
        login()
    End Sub

    Private Sub txt_pword_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_pword.KeyUp
        If e.KeyCode = Keys.Enter Then
            If attempt <> 1 Then
                attempt = 1
                login()
            Else
                attempt = 0
            End If
        End If
    End Sub

    Function CheckForAlphaCharacters(ByVal StringToCheck As String)
        For i = 0 To StringToCheck.Length - 1
            If Not Char.IsLetter(StringToCheck.Chars(i)) Then
                If Not Char.IsWhiteSpace(StringToCheck.Chars(i)) Then
                    Return False
                End If
            End If
        Next

        Return True 'Return true if all elements are characters
    End Function

    Public Sub login()
        Try

            Dim agent_trim = LCase(txt_uname.Text).Trim()
            Dim pwd_trim = txt_pword.Text

            ' trim string
            Dim agent As String = Regex.Replace(agent_trim, "[^A-Za-z0-9\-/.]", "")
            Dim pwd As String = pwd_trim

            If agent = "" Or pwd = "" Then
                MsgBox("Login failed.", vbExclamation, "System Message")
                txt_pword.Clear()
                txt_pword.Focus()
                Return
            End If

            addToHistoryLogged(agent, "attempt", "")

            If EnsureDBOpen() Then
                Dim is_exist As Integer = execScalarInt("SELECT COUNT(*) FROM tbl_users WHERE user_username='" & agent & "' AND user_password='" & MD5(pwd) & "' AND archived='0'")

                If is_exist = 0 Then
                    MsgBox("Login failed.", vbExclamation, "System Message")
                    txt_pword.Clear()
                    txt_pword.Focus()
                    Return
                Else
                    usr_privileges = execScalarInt("SELECT user_privileges FROM tbl_users WHERE user_username='" & agent & "' AND user_password='" & MD5(pwd) & "' AND archived='0'")
                    If usr_privileges = 1 Then
                        user_id = agent
                        frmForceLogin.Show()
                        cmd_close = False
                        Me.Close()
                        cmd_close = True
                    ElseIf usr_privileges = 5 Then
                        Dim row = query1stRow("SELECT campaign_id,team_id FROM tbl_agents WHERE agent='" & agent & "' AND this_site='" & conn_location & "' AND archived='0'")
                        If row Is Nothing Then
                            MsgBox("You're not a member of any campaign.", vbExclamation, "System Message")
                            txt_pword.Clear()
                            txt_pword.Focus()
                            Return
                        Else
                            user_id = agent
                            cmp_id = row("campaign_id")
                            team_id = row("team_id")

                            If cmp_id = 0 Then
                                MsgBox("You're not a member of any campaign.", vbExclamation, "System Message")
                                txt_pword.Clear()
                                txt_pword.Focus()
                                Return
                            ElseIf team_id = 0 Then
                                MsgBox("You're not a member of any team.", vbExclamation, "System Message")
                                txt_pword.Clear()
                                txt_pword.Focus()
                                Return
                            Else

                                setIPAddress()
                                FixLogout(user_id)
                                usr_campaign = execScalarString("SELECT campaign_name FROM tbl_campaigns WHERE campaign_id='" & cmp_id & "' AND archived='0'")

                                If usr_campaign.Equals("") Then
                                    MsgBox("Login failed. 2", vbExclamation, "System Message")
                                    txt_pword.Clear()
                                    txt_pword.Focus()
                                Else

                                    execNonQuery("UPDATE tbl_record_log SET dt_stamp_end='" & DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") & "' WHERE username='" & agent & "' status='pause' AND this_site='" & conn_location & "'")

                                    Dim get_old_id As Integer = execScalarInt("SELECT rec_id FROM tbl_record_log WHERE username='" & agent & "' AND dt_stamp_end='0000-00-00 00:00:00' AND log_reason='' AND status='logged' AND this_site='" & conn_location & "'")

                                    If get_old_id <> 0 Then
                                        frmReason.lbl_id.Text = get_old_id
                                        frmReason.Show()
                                        cmd_close = False
                                        Me.Close()
                                        cmd_close = True
                                    Else
                                        dateAdded = addToCheckerLogged(agent, "logged", "")
                                        afterLogin(agent, Environment.MachineName, dateAdded)
                                        cmd_close = False
                                        Me.Close()
                                        cmd_close = True
                                    End If

                                End If
                            End If
                        End If
                    End If
                End If
            Else
                techSupportCritical()
            End If
        Finally
            ForceDBClose()
        End Try
    End Sub

    Private Sub btn_cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cancel.Click
        pnl_reset.Visible = False
        clearText()
        txt_uname.Focus()
        ForceDBClose()
    End Sub

    Private Sub btn_change_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_change.Click
        forgotPwd()
    End Sub

    Public Sub forgotPwd()
        Try
            If EnsureDBOpen() Then
                Dim qstion As String = cb_rp_question.Text
                Dim trim_user As String = LCase(txt_rp_user.Text)
                Dim user As String = Regex.Replace(trim_user, "[^A-Za-z0-9\-/.]", "")

                Dim check_user As Integer = execScalarInt("SELECT COUNT(*) FROM tbl_users WHERE user_username='" & user & "'")
                If check_user > 0 Then

                    Dim get_id = execScalarString("SELECT user_id FROM tbl_users WHERE user_username='" & user & "' LIMIT 1")
                    Dim check_rp_info As Integer = execScalarInt("SELECT COUNT(*) FROM tbl_info_respas WHERE user_id='" & get_id & "' AND question='" & qstion.Replace("'", "\'") & "' AND answer='" & txt_rp_ans.Text & "'")
                    If check_rp_info > 0 Then
                        usr_unqid = get_id
                        updatePwd()
                    Else
                        ForceDBClose()
                        MsgBox("Invalid information.", vbExclamation, "System Message")
                        pnl_reset.Visible = False
                        clearText()
                    End If
                Else
                    ForceDBClose()
                    MsgBox("Account does not exist!", vbExclamation, "System Message")
                    pnl_reset.Visible = False
                    clearText()
                End If
                attempt = 0
                txt_uname.Focus()
            Else
                techSupportCritical()
            End If
        Finally
            ForceDBClose()
        End Try
    End Sub

    Public Sub updatePwd()
        Try
            If Not EnsureDBOpen() Then
                techSupportCritical()
                Return
            End If
            Dim getpass As String = execScalarString("SELECT def_pwd FROM tbl_updater_path WHERE this_site='" & conn_location & "' LIMIT 1")
            Dim encpwd As String = MD5(getpass)
            Dim insert As Boolean = execNonQuery("UPDATE tbl_users SET user_password='" & encpwd & "' WHERE user_id='" & usr_unqid & "' AND archived='0'")
            ForceDBClose()
            If insert = True Then
                MsgBox("Your password has been reset to default.", vbInformation, "System Message")
                pnl_reset.Visible = False
            Else
                MsgBox("Password reset failed.", vbCritical, "Error")
            End If
        Finally
            ForceDBClose()
        End Try
    End Sub

    Sub clearText()
        txt_uname.Clear()
        txt_pword.Clear()
        txt_rp_ans.Clear()
        txt_rp_user.Clear()
    End Sub

    Private Sub txt_rp_ans_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_rp_ans.KeyUp
        If e.KeyCode = Keys.Enter Then
            forgotPwd()
        End If
    End Sub


    Private Sub link_forgot_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles link_forgot.LinkClicked
        pnl_reset.Visible = True
        txt_rp_user.Focus()
    End Sub

    ' old functions
    Sub checkLocalFile(ByVal textFile As String)
        If System.IO.File.Exists(textFile) = False Then
            System.IO.File.Create(textFile).Dispose()
        Else
            insertLogs()
        End If

        If System.IO.File.Exists(locstamp) = False Then
            System.IO.File.Create(locstamp).Dispose()
        End If
    End Sub

    Sub checkHistoryLogs(ByVal textFile As String)
        If System.IO.File.Exists(textFile) = False Then
            System.IO.File.Create(textFile).Dispose()
        End If
    End Sub

    Sub insertLogs()
        Try
            If EnsureDBOpen() Then
                Dim getall As String = ""
                Dim getstatus As String = ""
                Dim getuser As String = ""
                Dim getstation As String = ""
                Dim getdatetime As String = ""
                Dim file As String = locstamp
                Dim Reader As New System.IO.StreamReader(file, True)
                Dim count_explode As Integer = 1
                Do While Reader.Peek() <> -1
                    Dim words = Reader.ReadLine()
                    Dim boom = words.Split(New Char() {" "c})
                    If words <> "" Then
                        For Each boo In boom
                            If count_explode = 2 Then
                                getdatetime += boo
                                getall += "'" & boo & " "
                            ElseIf count_explode = 3 Then
                                getdatetime += " " & boo
                                getall += boo & "',"
                            ElseIf count_explode = 4 Then
                                getuser = boo
                                getall += "'','" & boo & "',"
                            ElseIf count_explode = 5 Then
                                getstation = boo
                                getall += "'" & boo & "',"
                            ElseIf count_explode = 7 Then
                                getstatus = boo
                                getall += "'" & boo & "',"
                            Else
                                getall += "'" & boo & "',"
                            End If
                            count_explode += 1
                        Next
                    End If

                    If getstatus = "resume" Then
                        Dim query As String = "UPDATE tbl_record_log SET dt_stamp_end='" & getdatetime & "' WHERE username='" & getuser & "' AND station='" & getstation & "' AND dt_stamp_end='0000-00-00 00:00:00' AND status='pause' AND this_site='" & conn_location & "'"
                        updateQuery(query)
                    ElseIf getstatus = "logged" Then
                        Dim query As String = "UPDATE tbl_record_log SET dt_stamp_end='" & getdatetime & "' WHERE username='" & getuser & "' AND station='" & getstation & "' AND dt_stamp_end='0000-00-00 00:00:00' AND status='logged' AND log_reason='' AND this_site='" & conn_location & "'"
                        insertQuery(query)
                    Else
                        Dim query As String = "INSERT INTO tbl_record_log (dt_stamp,dt_stamp_end,username,station,campaign,status,ip,dt_stamp_day,log_reason,this_site) VALUES(" & getall.Remove(getall.Length - 1) & ",'','" & conn_location & "')"
                        insertQuery(query)
                    End If

                    getall = ""
                    getdatetime = ""
                    count_explode = 1
                Loop
                Reader.Close()
                System.IO.File.Delete(locstamp)
            Else
                techSupportCritical()
            End If
        Finally
            ForceDBClose()
        End Try
    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub
End Class