Imports System.Windows.Forms.ApplicationContext
Imports MySql.Data.MySqlClient
Imports Microsoft.Win32
Imports System.Net
Imports System
Imports System.IO

Public Class frmMessages
    Dim drag As Boolean
    Dim mousex As Integer
    Dim mousey As Integer
    Public count_img_pos As Integer = 0
    Public count_curr As Integer = 1
    Public count_pos As Integer = 1
    Public count_banner As Integer = 0
    Public disp_img_banner As Integer = 0
    Public first_disp As Integer = 0
    Public slide_count As Integer = 0
    Public en_chck_mes As Integer = 0
    Public yax As Integer = 0
    Public get_rs_secs As Integer
    Public start_schedule As Integer
    Public sched_type As String = ""
    Public get_hour_st As Integer
    Public get_min_st As Integer
    Public get_hour_en As Integer
    Public get_min_en As Integer
    Public get_end_date As Integer
    Public date_sched_begin As String
    Public load_ano As Integer = 0

    Private Sub frmMessages_FormClosing(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dim Cancel As Boolean = eventArgs.Cancel
        Dim UnloadMode As System.Windows.Forms.CloseReason = eventArgs.CloseReason
        If UnloadMode = CloseReason.UserClosing Then
            Cancel = cmd_close
        End If
        eventArgs.Cancel = Cancel
        ForceDBClose()
    End Sub

    Private Sub frmMessages_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        AddHandler SystemEvents.SessionEnding, AddressOf SessionEnding
        __Center.Text = GettyVersion()
        lbl_campaign.Text = usr_campaign
        lbl_user_id.Text = user_id
        updateInbox.Start()
        fadeIn.Start()
        load.Start()
        localStamp.Start()
        timeStampOL.Start()
        LogLocalStamp(last_rec_id)
        UpdatePauseButton()
        GettyTime.Start()
        fillInbox()
        'logsChecker.Start()
        extractHistory.Start()
    End Sub

    Public Sub UpdatePauseButton()
        If last_pause_rec_id = 0 Then
            btn_pause.Visible = True
            btn_resume.Visible = False
        Else
            btn_resume.Visible = True
            btn_pause.Visible = False
        End If
    End Sub

    Public Sub PowerModeChanged(ByVal sender As System.Object, ByVal e As Microsoft.Win32.PowerModeChangedEventArgs)
        Select Case e.Mode
            Case Microsoft.Win32.PowerModes.Resume
                'windows is resuming from sleep
            Case Microsoft.Win32.PowerModes.Suspend
                'goodnite windows
        End Select
    End Sub

    Public Sub SessionEnding(ByVal sender As Object, ByVal e As SessionEndingEventArgs)
        If e.Reason = SessionEndReasons.SystemShutdown Or e.Reason = SessionEndReasons.Logoff Then
            addToHistoryLogged(user_id, "shutdown", "")
            closeGetty()
        End If
    End Sub

    Public Sub checkLockUnlock(ByVal sender As Object, ByVal e As SessionSwitchEventArgs)
        If e.Reason = SessionSwitchReason.SessionLock Then
            pauseBreak("start")
        Else
            pauseBreak("end")
        End If
    End Sub

    Protected Overrides ReadOnly Property CreateParams() As System.Windows.Forms.CreateParams
        Get
            Const DROPSHADOW = &H20000
            Dim cParam As CreateParams = MyBase.CreateParams
            cParam.ClassStyle = cParam.ClassStyle Or DROPSHADOW
            Return cParam
        End Get
    End Property

    Private Sub frmMessages_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseDown
        drag = True
        mousex = Windows.Forms.Cursor.Position.X - Me.Left
        mousey = Windows.Forms.Cursor.Position.Y - Me.Top
    End Sub

    Private Sub frmMessages_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseMove
        If drag Then
            Me.Top = Windows.Forms.Cursor.Position.Y - mousey
            Me.Left = Windows.Forms.Cursor.Position.X - mousex
        End If
    End Sub

    Private Sub frmMessages_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseUp
        drag = False
    End Sub

    Private Sub fadeIn_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fadeIn.Tick
        If Me.Opacity < 100 Then
            Me.Opacity += 0.3
        Else
            fadeIn.Stop()
        End If
    End Sub

    Private Sub load_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles load.Tick
        If yax < 550 Then
            yax += 7
            load_start.Location = New Point(yax, 0)
        Else
            pnl_hide.Hide()
            load.Stop()
        End If
    End Sub

    Private Sub btn_pause_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_pause.Click
        btn_pause.Enabled = False
        frmPauses.ShowDialog(Me)
    End Sub

    Private Sub btn_resume_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_resume.Click
        If MsgBox("Do you want to RESUME break ?", vbQuestion + vbYesNo, "System Message") = vbYes Then
            addToHistoryLogged(user_id, "pause", "resume")
            Dim dateAdded As String = addToCheckerLogged(user_id, "resume", "")
            Try
                If EnsureDBOpen() Then
                    Dim isupdated As Boolean = execNonQuery("UPDATE tbl_record_log SET dt_stamp_end='" & dateAdded & "' WHERE rec_id='" & last_pause_rec_id & "' AND campaign='" & cmp_id & "'")
                    'UpdateEndTime(dateAdded, last_pause_rec_id)
                    If isupdated = True Then
                        DeleteLogStamp(last_pause_rec_id)
                        last_pause_rec_id = 0
                        UpdatePauseButton()
                        enableForm()
                    Else
                        MsgBox("Updating record failed, please try again.", vbExclamation, "System Message")
                    End If
                Else
                    techSupportCritical()
                End If
            Finally
                ForceDBClose()
            End Try
        End If

        If last_pause_rec_id = 0 Then
            btn_pause.Enabled = True
        End If
    End Sub

    Sub enableForm()
        pnl_minimize.Show()
        pnl_hide.Hide()
        pnl_exit.Show()
        pnl_disp_lock.Visible = False
        btn_profile.Enabled = True
    End Sub

    Sub disableForm()
        pnl_minimize.Hide()
        pnl_hide.Show()
        pnl_exit.Hide()
        pnl_disp_lock.Visible = True
        btn_profile.Enabled = False
    End Sub

    Public Sub pauseBreak(ByVal time As String)
        Try
            If Not EnsureDBOpen() Then
                Return
            End If
            If time.Equals("start") Then
                If last_pause_rec_id = 0 Then
                    last_pause_rec_id = execLastID("INSERT INTO tbl_record_log (dt_stamp,dt_stamp_end,username,station,campaign,status,ip,log_reason,this_site) VALUES('" & DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") & "','','" & user_id & "','" & Environment.MachineName.ToString & "','" & cmp_id & "','" & pause_break & "','" & ip & "','" & DateAndTime.Now.DayOfWeek.ToString & "','','" & conn_location & "')")
                    If last_pause_rec_id <> 0 Then
                        LogLocalStamp(last_pause_rec_id)
                        btn_pause.SendToBack()
                        pnl_hide.Show()
                    End If
                End If
            ElseIf time.Equals("end") Then
                UpdateEndTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), last_pause_rec_id)
                btn_resume.SendToBack()
                pnl_hide.Hide()
                enableForm()
                last_pause_rec_id = 0
            End If
        Finally
            ForceDBClose()
        End Try
    End Sub

    Private Sub pnl_minimize_Click(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pnl_minimize.Click
        TrayIcon.ShowBalloonTip(1)
        Me.Hide()
    End Sub

    Private Sub TrayIcon_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles TrayIcon.Click
        Me.Show()
    End Sub

    Private Sub OpenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenToolStripMenuItem.Click
        Me.Show()
    End Sub

    Private Sub updatingTime_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles updatingTime.Tick
        Try
            If EnsureDBOpen() Then
                UpdateEndTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), last_rec_id)
            End If
        Catch
        Finally
            ForceDBClose()
        End Try
    End Sub

    Private Sub AboutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        MsgBox("Ca Telemarketing Inc. " & DateTime.Now.Year, vbInformation, "About")
    End Sub


    Private Sensitivity As Integer = 20

    Private Sub Panel2_MouseWheel(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Panel2.MouseWheel
        If Panel2.Bounds.Contains(e.Location) Then
            Dim vScrollPosition As Integer = Panel2.VerticalScroll.Value
            vScrollPosition -= Math.Sign(e.Delta) * Sensitivity
            vScrollPosition = Math.Max(0, vScrollPosition)
            vScrollPosition = Math.Min(vScrollPosition, Me.VerticalScroll.Maximum)
            Panel2.AutoScrollPosition = New Point(Panel2.AutoScrollPosition.X, _
                                        vScrollPosition)
            Panel2.Invalidate()
        End If
    End Sub

    Private Sub Panel2_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles Panel2.MouseEnter
        Panel2.Select()
    End Sub

    Private Sub btn_refresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    End Sub

    Private Sub checkSchedule_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles checkSchedule.Tick
        Dim curr_hour As String = Date.Now.ToString("HH:mm:ss").Substring(0, 2)
        Dim curr_minute As String = Date.Now.ToString("HH:mm:ss").Substring(3, 2)
        Dim minute As String
        Dim hour As String

        If schedule_start.Length = 8 Then
            hour = schedule_end.Substring(0, 2)
        End If

        If schedule_end.Length = 8 Then
            minute = schedule_end.Substring(3, 2)
        End If

        If curr_hour.Equals(hour) = True And curr_minute.Equals(minute) = True Then
            checkSchedule.Stop()
            shutdownCount.Start()
        End If
    End Sub

    Private Sub shutdownCount_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles shutdownCount.Tick
        closeGetty()
    End Sub

    Private Sub pnl_exit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles pnl_exit.Click
        If MsgBox("Do you want to exit application ?", vbQuestion + vbYesNo, "Exit") = vbYes Then
            addToHistoryLogged(user_id, "logged_out", "")
            closeGetty()
        End If
    End Sub

    Private Sub btn_profile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_profile.Click
        frmSettings.Show()
    End Sub

    Private Sub localStamp_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles localStamp.Tick
        LogLocalStamp(last_rec_id)
        If last_pause_rec_id <> 0 Then
            LogLocalStamp(last_pause_rec_id)
        End If
    End Sub

    ' Message functions

    Public Sub newMessages()
        Try
            If EnsureDBOpen() Then
                Dim getMessage As String = getField("SELECT date_assigned FROM tbl_agents WHERE agent='" & user_id & "' AND this_site='" & conn_location & "'", "date_assigned")
                Dim explodeDate As Array = Split(getMessage, "/")
                Dim fDate As String = ""
                If Len(explodeDate(0)) = 1 Then
                    fDate = explodeDate(2) & "-0" & explodeDate(0) & "-" & explodeDate(1)
                Else
                    fDate = explodeDate(2) & "-" & explodeDate(0) & "-" & explodeDate(1)
                End If

                Dim query As String = "SELECT COUNT(m.message_id) FROM tbl_messages AS m INNER JOIN tbl_recipients AS r ON m.message_id = r.messages_id WHERE DATE(m.message_datecreated) >= '" & fDate & "' AND r.user_username='" & user_id & "' AND m.messages_read NOT LIKE '%" & user_id & "%' AND m.user_id <> '0'"
                Dim cmd As New MySqlCommand(query, sqlcon)
                With cmd
                    .CommandText = query
                    .Connection = sqlcon
                End With
                Dim rs = cmd.ExecuteScalar

                If rs > 0 Then
                    Label4.Text = "(" & rs & ")"
                Else
                    Label4.Text = ""
                End If
            End If
        Catch
        Finally
            ForceDBClose()
        End Try
    End Sub

    Public Sub checkNewMessages()
        Try
            If EnsureDBOpen() Then
                Dim getMessage As String = getField("SELECT date_assigned FROM tbl_agents WHERE agent='" & user_id & "' AND this_site='" & conn_location & "'", "date_assigned")
                Dim explodeDate As Array = Split(getMessage, "/")
                Dim fDate As String = ""
                If Len(explodeDate(0)) = 1 Then
                    fDate = explodeDate(2) & "-0" & explodeDate(0) & "-" & explodeDate(1)
                Else
                    fDate = explodeDate(2) & "-" & explodeDate(0) & "-" & explodeDate(1)
                End If
                Dim rs As Integer = 0

                Dim query As String = "SELECT COUNT(m.message_id) FROM tbl_messages AS m INNER JOIN tbl_recipients AS r ON m.message_id = r.messages_id WHERE DATE(m.message_datecreated) >= '" & fDate & "' AND r.user_username='" & user_id & "' AND m.user_id <> '0'"
                Dim cmd As New MySqlCommand(query, sqlcon)
                With cmd
                    .CommandText = query
                    .Connection = sqlcon
                End With
                rs = cmd.ExecuteScalar

                If rs > countAllMessages Then
                    countAllMessages = 0
                    displayMessages()
                    newMessages()
                ElseIf rs < countAllMessages Then
                    countAllMessages = 0
                    displayMessages()
                    newMessages()
                End If
            End If
        Catch
        Finally
            ForceDBClose()
        End Try
    End Sub

    Public Sub displayMessages()
        Try
            If EnsureDBOpen() Then
                lv_inbox.FullRowSelect = True
                lv_inbox.View = View.Details
                lv_inbox.Items.Clear()
                lv_inbox.Columns.Clear()
                lv_inbox.Columns.Add("ID", 60, HorizontalAlignment.Left)
                lv_inbox.Columns.Add("Date", 140, HorizontalAlignment.Left)
                lv_inbox.Columns.Add("Title", 320, HorizontalAlignment.Left)

                Dim getMessage As String = getField("SELECT date_assigned FROM tbl_agents WHERE agent='" & user_id & "' AND this_site='" & conn_location & "'", "date_assigned")
                Dim explodeDate As Array = Split(getMessage, "/")
                Dim fDate As String = ""
                If Len(explodeDate(0)) = 1 Then
                    fDate = explodeDate(2) & "-0" & explodeDate(0) & "-" & explodeDate(1)
                Else
                    fDate = explodeDate(2) & "-" & explodeDate(0) & "-" & explodeDate(1)
                End If

                Dim query As String = "SELECT * FROM tbl_messages AS m INNER JOIN tbl_recipients AS r ON m.message_id = r.messages_id WHERE DATE(m.message_datecreated) >= '" & fDate & "' AND r.user_username='" & user_id & "' AND m.user_id <> '0' ORDER BY 1 DESC"

                Dim adapter As MySqlDataAdapter
                adapter = New MySqlDataAdapter(query, sqlcon)
                Dim ds = New DataSet
                adapter.Fill(ds, "message_content")
                Dim newMes As Integer = 0
                For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                    'If InStr(ds.Tables(0).Rows(i).Item("messages_read").ToString, user_id) = 0 Then

                    Dim mes_date As Array = Split(ds.Tables(0).Rows(i).Item("message_datecreated").ToString, " ")
                    Dim date_par1 As DateTime = DateTime.Parse(mes_date(0))
                    Dim date_par2 As DateTime = DateTime.Parse(DateTime.Now.ToString("MM/dd/yyyy"))

                    If ds.Tables(0).Rows(i).Item("user_id").ToString = "1" And date_par1 >= date_par2 Then
                        If ds.Tables(0).Rows(i).Item("recipient_read").ToString.Equals("0") Then
                            With lv_inbox.Items.Add(ds.Tables(0).Rows(i).Item("message_id").ToString)
                                .SubItems.Add(ds.Tables(0).Rows(i).Item("message_datecreated").ToString).Font = New Font(lv_inbox.Font, FontStyle.Bold)
                                .SubItems.Add(ds.Tables(0).Rows(i).Item("message_title").ToString).Font = New Font(lv_inbox.Font, FontStyle.Bold)
                            End With

                            If ds.Tables(0).Rows(i).Item("message_priority").ToString = "2" And first_disp = 1 Then

                                Dim wwContent As String = WordWrap(ds.Tables(0).Rows(i).Item("message_content").ToString, 60)
                                frmHighPriorityMsg.lbl_msg_read.Text = wwContent
                                frmHighPriorityMsg.lbl_title.Text = ds.Tables(0).Rows(i).Item("message_title").ToString
                                Dim getFrom As String = getField("SELECT user_username FROM tbl_users WHERE user_id='" & ds.Tables(0).Rows(i).Item("user_id").ToString & "' AND this_site='" & conn_location & "'", "user_username")

                                frmHighPriorityMsg.lbl_from.Text = getFrom
                                frmHighPriorityMsg.lbl_date.Text = ds.Tables(0).Rows(i).Item("message_datecreated").ToString
                                frmHighPriorityMsg.lbl_to.Text = ds.Tables(0).Rows(i).Item("user_username").ToString
                                frmHighPriorityMsg.msg_id.Text = ds.Tables(0).Rows(i).Item("message_id").ToString
                                frmHighPriorityMsg.Show()

                            ElseIf ds.Tables(0).Rows(i).Item("message_priority").ToString = "1" And first_disp = 1 Then
                                frmNewMsg.Show()
                            End If
                            newMes += 1
                        Else
                            With lv_inbox.Items.Add(ds.Tables(0).Rows(i).Item("message_id").ToString)
                                .SubItems.Add(ds.Tables(0).Rows(i).Item("message_datecreated").ToString)
                                .SubItems.Add(ds.Tables(0).Rows(i).Item("message_title").ToString)
                            End With
                        End If
                    ElseIf ds.Tables(0).Rows(i).Item("user_id").ToString <> "1" Then
                        If ds.Tables(0).Rows(i).Item("recipient_read").ToString.Equals("0") Then
                            With lv_inbox.Items.Add(ds.Tables(0).Rows(i).Item("message_id").ToString)
                                .SubItems.Add(ds.Tables(0).Rows(i).Item("message_datecreated").ToString).Font = New Font(lv_inbox.Font, FontStyle.Bold)
                                .SubItems.Add(ds.Tables(0).Rows(i).Item("message_title").ToString).Font = New Font(lv_inbox.Font, FontStyle.Bold)
                            End With

                            If ds.Tables(0).Rows(i).Item("message_priority").ToString = "2" And first_disp = 1 Then

                                Dim wwContent As String = WordWrap(ds.Tables(0).Rows(i).Item("message_content").ToString, 60)
                                frmHighPriorityMsg.lbl_msg_read.Text = wwContent
                                frmHighPriorityMsg.lbl_title.Text = ds.Tables(0).Rows(i).Item("message_title").ToString
                                Dim getFrom As String = getField("SELECT user_username FROM tbl_users WHERE user_id='" & ds.Tables(0).Rows(i).Item("user_id").ToString & "' AND this_site='" & conn_location & "'", "user_username")

                                frmHighPriorityMsg.lbl_from.Text = getFrom
                                frmHighPriorityMsg.lbl_date.Text = ds.Tables(0).Rows(i).Item("message_datecreated").ToString
                                frmHighPriorityMsg.lbl_to.Text = ds.Tables(0).Rows(i).Item("user_username").ToString
                                frmHighPriorityMsg.msg_id.Text = ds.Tables(0).Rows(i).Item("message_id").ToString
                                frmHighPriorityMsg.Show()

                            ElseIf ds.Tables(0).Rows(i).Item("message_priority").ToString = "1" And first_disp = 1 Then
                                frmNewMsg.Show()
                            End If
                            newMes += 1
                        Else
                            With lv_inbox.Items.Add(ds.Tables(0).Rows(i).Item("message_id").ToString)
                                .SubItems.Add(ds.Tables(0).Rows(i).Item("message_datecreated").ToString)
                                .SubItems.Add(ds.Tables(0).Rows(i).Item("message_title").ToString)
                            End With
                        End If
                    End If

                    For Each lvi As ListViewItem In lv_inbox.Items
                        lvi.UseItemStyleForSubItems = False
                    Next

                    countAllMessages += 1

                Next

                If newMes > 0 Then
                    Label4.Text = "(" & newMes & ")"
                Else
                    Label4.Text = ""
                End If
                lv_inbox.View = View.Details
                lbl_wait.SendToBack()
            End If
        Catch
        Finally
            ForceDBClose()
        End Try
    End Sub

    ' read message
    Private Sub lv_inbox_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lv_inbox.Click
        Try
            If EnsureDBOpen() Then
                If Me.lv_inbox.SelectedIndices.Count > 0 Then
                    Dim Pos As Integer = Me.lv_inbox.SelectedIndices(0)
                    Me.lv_inbox.Items.Item(Me.lv_inbox.SelectedIndices(0)).SubItems(1).Font = New System.Drawing.Font("Microsoft Sans Serif", 8)
                    Me.lv_inbox.Items.Item(Me.lv_inbox.SelectedIndices(0)).SubItems(2).Font = New System.Drawing.Font("Microsoft Sans Serif", 8)
                End If

                Dim id As Integer = lv_inbox.Items(lv_inbox.SelectedIndices(0)).Text
                Dim query As String = "SELECT * FROM tbl_messages AS m INNER JOIN tbl_recipients AS r ON m.message_id = r.messages_id WHERE r.user_username='" & user_id & "' AND m.message_id='" & id & "' AND this_site='" & conn_location & "'"
                Dim adapter As MySqlDataAdapter
                adapter = New MySqlDataAdapter(query, sqlcon)
                Dim ds = New DataSet
                adapter.Fill(ds, "message_content")

                lbl_msg_read.Text = WordWrap(ds.Tables(0).Rows(0).Item("message_content").ToString)
                lbl_msg_read.Text += Environment.NewLine + Environment.NewLine + Environment.NewLine
                lbl_title.Text = ds.Tables(0).Rows(0).Item("message_title").ToString
                lbl_date.Text = ds.Tables(0).Rows(0).Item("message_datecreated").ToString
                lbl_to.Text = ds.Tables(0).Rows(0).Item("user_username").ToString
                Dim aut_id As String = ds.Tables(0).Rows(0).Item("user_id").ToString
                Dim author As String = getField("SELECT user_username FROM tbl_users WHERE user_id='" & aut_id & "'", "user_username")
                lbl_from.Text = author

                'check if the user is already read the message
                Dim check_user = checkExist("SELECT COUNT(message_id) FROM tbl_messages WHERE message_id='" & id & "' AND this_site='" & conn_location & "'")
                If check_user > 0 Then
                    If ds.Tables(0).Rows(0).Item("recipient_read").ToString = "0" Then
                        updateQuery("UPDATE tbl_recipients SET recipient_read='1' WHERE messages_id='" & id & "' AND user_username='" & user_id & "'")
                    End If
                End If

                newMessages()
                pnl_blk_disp.Hide()

            End If
        Catch
        Finally
            ForceDBClose()
        End Try
    End Sub

    Private Sub updateInbox_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles updateInbox.Tick
        fillInbox()
    End Sub

    Public Sub fillInbox()
        Try
            If EnsureDBOpen() Then
                If first_disp = 0 Then
                    displayMessages()
                    first_disp = 1
                Else
                    'newMessages()
                    checkNewMessages()
                End If

                lbl_wait.Visible = False
                If en_chck_mes = 0 Then
                    btn_pause.Visible = True
                    btn_resume.Visible = True
                    If caption_pause_break.Equals("r") = True Then
                        btn_resume.BringToFront()
                        pnl_minimize.Hide()
                        disableForm()
                        pnl_hide.Show()
                    Else
                        btn_pause.BringToFront()
                    End If
                    en_chck_mes = 1
                End If
            End If
        Catch
        Finally
            ForceDBClose()
        End Try
    End Sub


    ' write to local logs
    Sub firstLocalStamp()
        Dim Writer As New System.IO.StreamWriter(locstamp)
        Writer.WriteLine(last_rec_id & " " & DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") & " " & user_id & " " & Environment.MachineName & " " & cmp_id & " logged " & ip & " " & DateAndTime.Now.DayOfWeek.ToString & " " & "OK")
        Writer.Close()
    End Sub

    Private Sub timeStampOL_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles timeStampOL.Tick
        Dim Writer As New System.IO.StreamWriter(locstamp)
        Writer.WriteLine(last_rec_id & " " & DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") & " " & user_id & " " & Environment.MachineName & " " & cmp_id & " logged " & ip & " " & DateAndTime.Now.DayOfWeek.ToString & " " & "OK")
        Writer.Close()
    End Sub

    Private Sub GettyTime_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GettyTime.Tick
        Dim hour As Integer = DateTime.Now.ToString("HH:mm:ss").Substring(0, 2)
        Dim min As Integer = DateTime.Now.ToString("HH:mm:ss").Substring(3, 2)

        If min < 10 Then
            lbl_show_time.Text = convertTimeFormat(hour) & ":0" & min & " " & DateTime.Now.ToString("tt")
        Else
            lbl_show_time.Text = convertTimeFormat(hour) & ":" & min & " " & DateTime.Now.ToString("tt")
        End If
    End Sub

    Public Sub isRecorded()
        


        'Try
        '    If EnsureDBOpen() Then
        '        Dim if_has_logged As Integer = checkExist("SELECT rec_id FROM tbl_record_log WHERE username='" & user_id & "' AND dt_stamp_end='0000-00-00 00:00:00' AND status='logged' ORDER BY rec_id DESC LIMIT 1")
        '        If if_has_logged = 0 Then
        '            Me.Hide()
        '            frmTerminate.Show()
        '        End If
        '    End If
        'Catch
        'Finally
        '    ForceDBClose()
        'End Try
    End Sub

    Private Sub logsChecker_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles logsChecker.Tick
        isRecorded()
    End Sub

    Public Sub DownloadFile( _
     ByVal address As String, _
     ByVal fileName As String _
    )
        Dim myStringWebResource As String = Nothing
        ' Create a new WebClient instance. 
        Dim myWebClient As New WebClient()
        ' Concatenate the domain with the Web resource filename. Because DownloadFile  
        'requires a fully qualified resource name, concatenate the domain with the Web resource file name.
        Try
            myStringWebResource = address + fileName
            ' The DownloadFile() method downloads the Web resource and saves it into the current file-system folder.
            myWebClient.DownloadFile(myStringWebResource, fileName)
            'MsgBox("File downloaded!", vbInformation, "System Message")
        Catch ex As Exception
        End Try
    End Sub

    Private Sub extractHistory_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles extractHistory.Tick
        If conn_location = "Quezon" Then
            DownloadFile("http://stage.cticrm.local:8086/Getty/gtymsg" & "/", Environment.MachineName & ".txt")
        ElseIf conn_location = "Cavite" Then
            DownloadFile("http://172.16.32.76:8086/Getty/gtymsg" & "/", Environment.MachineName & ".txt")
        ElseIf conn_location = "Honduras" Then
            DownloadFile("http://getty.collective.lan:8086/Getty/gtymsg" & "/", Environment.MachineName & ".txt")
        End If

        If System.IO.File.Exists("C:\CollectiveSolution\Getty\1.0\" & Environment.MachineName & ".txt") = True Then
            Dim getall As String = ""
            Dim file As String = historyLogs
            Dim Reader As New System.IO.StreamReader(file, True)
            Dim count_explode As Integer = 1
            Do While Reader.Peek() <> -1
                Dim words = Reader.ReadLine()
                Dim boom = words.Split(New Char() {" "c})
                If words <> "" Then
                    For Each boo In boom
                        getall += "'" & boo & "',"
                    Next
                End If

                execNonQuery("INSERT INTO _AGENT_HISTORY (username,date,time,station,status,reason) VALUES(" & getall.Remove(getall.Length - 1) & ")")
                getall = ""
                count_explode = 1
            Loop
            Reader.Close()
            System.IO.File.Delete("C:\CollectiveSolution\Getty\1.0\" & Environment.MachineName & ".txt")
        End If
    End Sub

    Private Sub pb_sysinfo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pb_sysinfo.Click
        frmSysAbout.ShowDialog(Me)
    End Sub

End Class