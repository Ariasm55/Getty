Imports Microsoft.Win32
Imports System.IO
Imports MySql.Data.MySqlClient

Public Class frmRecon
    Dim drag As Boolean
    Dim mousex As Integer
    Dim mousey As Integer
    Public countdown As Integer = 5
    Public sqlcon As MySqlConnection

    Private Sub frmRecon_FormClosing(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dim Cancel As Boolean = eventArgs.Cancel
        Dim UnloadMode As System.Windows.Forms.CloseReason = eventArgs.CloseReason
        If UnloadMode = CloseReason.UserClosing Then
            'Prevent it closing
            Cancel = cmd_close
        End If
        'Allow it to close if it wasn't the user's action
        eventArgs.Cancel = Cancel
    End Sub

    Private Sub frmRecon_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseDown
        drag = True
        mousex = Windows.Forms.Cursor.Position.X - Me.Left
        mousey = Windows.Forms.Cursor.Position.Y - Me.Top
    End Sub

    Private Sub frmRecon_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseMove
        If drag Then
            Me.Top = Windows.Forms.Cursor.Position.Y - mousey
            Me.Left = Windows.Forms.Cursor.Position.X - mousex
        End If
    End Sub

    Private Sub frmRecon_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseUp
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

    Private Sub frmMessages_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        AddHandler SystemEvents.SessionSwitch, AddressOf checkLockUnlock
        cmd_close = True
        Timer1.Start()
        lbl_count.Text = countdown
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If countdown <> 1 Then
            countdown -= 1
            lbl_count.Text = countdown
        Else
            Timer1.Stop()
            pnl_attempt.Visible = True
            Timer2.Start()
        End If
    End Sub

    Sub zreconnect()
        sqlcon.Open()
        frmMessages.Show()
        insertLocalLogs()
        sqlcon.Close()
        sqlcon.Dispose()
    End Sub

    Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick
        Try
            reconnect()
        Catch ex As Exception
            pnl_attempt.Visible = False
            countdown = 5
            lbl_count.Text = countdown
        End Try
        Timer2.Stop()
        Timer1.Start()
    End Sub

    Public Sub checkLockUnlock(ByVal sender As Object, ByVal e As SessionSwitchEventArgs)
        If e.Reason = SessionSwitchReason.SessionLock Then
            pauseBreak("start")
        Else
            pauseBreak("end")
        End If
    End Sub

    Public Sub pauseBreak(ByVal time As String)
        getAddress()
        If time.Equals("start") Then
            LogLocalLog("pause")
            caption_pause_break = "r"
            btn_local_pause.Text = "Resume"
        ElseIf time.Equals("end") Then
            LogLocalLog("resume")
            btn_local_pause.Text = "Pause"
            caption_pause_break = "p"
        End If
    End Sub

    Sub zinsertLocalLogs()
        Dim getall As String = ""
        Dim getstatus As String = ""
        Dim getuser As String = ""
        Dim getstation As String = ""
        Dim getdatetime As String = ""
        Dim gettypepause As String = ""
        Using Reader As New System.IO.StreamReader(loclogs, True)
            Dim count_explode As Integer = 1
            Do While Reader.Peek() <> -1
                Dim words = Reader.ReadLine()
                Dim boom = words.Split(New Char() {" "c})

                For Each boo In boom
                    If count_explode = 1 Then
                        getdatetime += boo
                        getall += "'" & boo & " "
                    ElseIf count_explode = 2 Then
                        getdatetime += " " & boo
                        getall += boo & "',"
                    ElseIf count_explode = 3 Then
                        getuser = boo
                        getall += "'','" & boo & "',"
                    ElseIf count_explode = 4 Then
                        getstation = boo
                        getall += "'" & boo & "',"
                    ElseIf count_explode = 6 Then
                        getstatus = boo
                        getall += "'" & boo & "',"
                    ElseIf count_explode = 9 Then
                        gettypepause += boo
                    Else
                        getall += "'" & boo & "',"
                    End If
                    count_explode += 1
                Next

                If getstatus = "resume" Then
                    execNonQuery("update tbl_record_log set dt_stamp_end='" & getdatetime & "' where username='" & getuser & "' and station='" & getstation & "' and dt_stamp_end='0000-00-00 00:00:00' and status='pause' and this_site='" & conn_location & "'")
                ElseIf getstatus = "logged" Then
                    Dim query As String = "update tbl_record_log set dt_stamp_end='" & getdatetime & "' where username='" & getuser & "' and station='" & getstation & "' and dt_stamp_end='0000-00-00 00:00:00' and status='logged' and this_site='" & conn_location & "'"
                Else
                    execNonQuery("insert into tbl_record_log values(''," & getall.Remove(getall.Length - 1) & ",'" & gettypepause & "','" & conn_location & "')")
                End If

                getall = ""
                getdatetime = ""
                count_explode = 1
            Loop
            Reader.Close()
        End Using
        Try
            System.IO.File.Delete(loclogs)
        Catch
        End Try
    End Sub

    Private Sub btn_local_pause_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_local_pause.Click

        frmLocalPauses.Show()
        'Dim path As String = loclogs
        'If System.IO.File.Exists(path) = False Then
        '    System.IO.File.Create(path).Dispose()
        'End If

        'If btn_local_pause.Text = "Pause" Then
        '    If MsgBox("Do you want to (PAUSE) break ?", vbQuestion + vbYesNo) = vbYes Then
        '        Dim file As String = path
        '        Dim Writer As New System.IO.StreamWriter(file, True)
        '        Writer.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") & " " & user_id & " " & Environment.MachineName & " " & cmp_id & " pause " & ip & " " & DateAndTime.Now.DayOfWeek.ToString)
        '        Writer.Close()
        '        caption_pause_break = "r"
        '        btn_local_pause.Text = "Resume"
        '        btn_local_out.Enabled = False
        '    End If
        'ElseIf btn_local_pause.Text = "Resume" Then
        '    If MsgBox("Do you want to (RESUME) break ?", vbQuestion + vbYesNo) = vbYes Then
        '        Dim file As String = path
        '        Dim Writer As New System.IO.StreamWriter(file, True)
        '        Writer.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") & " " & user_id & " " & Environment.MachineName & " " & cmp_id & " resume " & ip & " " & DateAndTime.Now.DayOfWeek.ToString)
        '        Writer.Close()
        '        btn_local_pause.Text = "Pause"
        '        caption_pause_break = "p"
        '        btn_local_out.Enabled = True
        '    End If
        'End If
    End Sub

    Private Sub btn_local_out_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_local_out.Click
        If System.IO.File.Exists(loclogs) = False Then
            System.IO.File.Create(loclogs).Dispose()
        End If
        If MsgBox("Do you want to exit application ?", vbQuestion + vbYesNo) = vbYes Then
            LogLocalLog("logged")
            cmd_close = False
            Me.Close()
            cmd_close = True
        End If
    End Sub
End Class