Imports MySql.Data.MySqlClient
Imports System.Net

Module functions
    ' break caption
    Public caption_pause_break As String = ""
    ' form close
    Public cmd_close As Boolean
    ' connection variables


    'Public conn_location As String = "Honduras"
    'Public conn_location As String = "Cavite"

    ' Site location
    Public conn_location As String = "Quezon"

    ' Port
    Public srv_port As String = ""

    ' DB name
    Public srv_db As String = "getty"

    ' DB username
    Public srv_root As String = ""

    ' DB password
    Public srv_dbpass As String = ""



    ' user unique id
    Public usr_unqid As String = ""
    Public id As String = ""
    ' sched time
    Public sched_st As String = ""
    Public sched_en As String = ""
    Public sched_date As String = ""
    ' username
    Public user_id As String = ""
    ' pc name
    Public pc_station As String = ""
    ' campaign
    Public usr_campaign As String = ""
    ' campaign id
    Public cmp_id As Integer = 0
    ' ip address
    Public ip As String
    ' get team id
    Public team_id As String = ""
    ' get team name
    Public team_name As String = ""
    ' get agent schedule
    Public schedule_start As String = ""
    Public schedule_end As String = ""
    ' privileges
    Public usr_privileges As Integer = 0
    ' messages counter
    Public last_pause_rec_id As Long = 0
    Public last_rec_id As Long = 0
    Public pause_break As String = "pause"
    Public logged As String = "logged"
    Public countAllMessages As Integer = 0
    Public firstTimeStamp As String = ""
    ' session var
    Public break_value As Integer = 0
    ' local logs path
    Public loclogs As String = "C:\CollectiveSolution\Getty\1.0\local_logs.txt"
    Public locstamp As String = "C:\CollectiveSolution\Getty\1.0\timestamp.txt"
    Public ensureData As String = "C:\CollectiveSolution\Getty\ensure.txt"
    Public historyLogs As String = "C:\CollectiveSolution\Getty\history.txt"
    Public success_logged As Integer = 0

    'system info
    Public sysver As String = "1.0.4 BETA"

    Public Const LOG_DIR = "C:\CollectiveSolution\Getty\1.0"
    Private m_isOffline As Boolean = True
    Public Const OFFLINE_ID As Integer = 777777

    Public Function GettyVersion() As String
        'Dim assembly = System.Reflection.Assembly.GetExecutingAssembly()
        'Dim version = assembly.GetName().Version
        'Return conn_location & " v" & version.ToString()
        Return conn_location & " v" & sysver
    End Function

    Public Sub Offline(ByVal is_offline As Boolean)
        m_isOffline = is_offline
        Dim status = IIf(is_offline, "OFFLINE", "ONLINE")
        ServerStatus(status)
        frmMessages.__Status.ForeColor = IIf(is_offline, Color.Red, Color.Green)
    End Sub

    Public Sub ServerStatus(ByVal status As String)
        frmMessages.__Status.ForeColor = Color.Black
        frmMessages.__Status.Text = status
        frmMessages.__Status.Refresh()
        frmLoginGetty.__Status.Text = status
        frmLoginGetty.__Status.Refresh()
        System.Threading.Thread.Sleep(100)
    End Sub

    Public Function IsOffline() As Boolean
        Return m_isOffline
    End Function


    Public Function DBHost() As String
        If conn_location = "Quezon" Then
            Return "172.16.1.80"
            'Return "172.16.0.76"
            'Return "jonellstaging.collectivesolution.net"
        End If
        If conn_location = "Cavite" Then
            Return "172.16.32.76"
        End If
        If conn_location = "Honduras" Then
            Return "10.54.0.76"
        End If
        Return "127.0.0.1"
    End Function

    Public Function MD5(ByVal input As String) As String
        Dim x As New System.Security.Cryptography.MD5CryptoServiceProvider()
        Dim bs As Byte() = System.Text.Encoding.UTF8.GetBytes(input)
        bs = x.ComputeHash(bs)
        Dim s As New System.Text.StringBuilder()
        For Each b As Byte In bs
            s.Append(b.ToString("x2").ToLower())
        Next
        Dim hash As String = s.ToString()
        Return hash
    End Function

    Public Function execNonQuery(ByVal query As String) As Boolean
        Dim is_ok As Boolean = False
        Try
            If EnsureDBOpen() Then
                Dim cmdup As New MySqlCommand(query, sqlcon)
                is_ok = cmdup.ExecuteNonQuery()
            End If
        Catch
        End Try
        Return is_ok
    End Function

    Public Function execScalarString(ByVal query As String) As String
        Dim v As Object = execScalar(query)
        If (v Is Nothing) Then
            Return ""
        End If
        Return v.ToString()
    End Function

    Public Sub techSupportCritical(Optional ByVal msg As String = "")
        If msg = "" Then
            msg = "Cannot connect to server, please try again or contact techsupport."
        End If
        MsgBox(msg, MsgBoxStyle.OkOnly, "System Message")
    End Sub

    Public Function execScalar(ByVal query As String) As Object
        Dim is_ok As Boolean = False
        Dim d As Object = Nothing
        Try
            If EnsureDBOpen() Then
                Dim cmd As New MySqlCommand(query, sqlcon)
                d = cmd.ExecuteScalar()
                is_ok = True
            End If
        Catch
            techSupportCritical()
        End Try
        Return d
    End Function

    Public Function query1stRow(ByVal sql As String) As DataRow
        Dim ds = query(sql)
        If Not ds Is Nothing And ds.Tables.Count > 0 And ds.Tables(0).Rows.Count > 0 Then
            Return ds.Tables(0).Rows(0)
        End If
        Return Nothing
    End Function

    Public Function execLastID(ByVal query As String, Optional ByVal is_silent As Boolean = False) As Long
        Dim last_id As Long = 0
        Try
            If EnsureDBOpen() Then
                Dim cmd As New MySqlCommand(query, sqlcon)
                If cmd.ExecuteNonQuery() = 1 Then
                    last_id = cmd.LastInsertedId
                Else
                    last_id = 0
                End If
            End If
        Catch
        End Try
        Return last_id
    End Function

    Public Sub setIPAddress()
        Dim ipAddress As IPAddress
        Dim ipHostInfo As IPHostEntry = Dns.Resolve(Dns.GetHostName())
        ipAddress = ipHostInfo.AddressList(0)
        ip = ipAddress.ToString
    End Sub

    Public Sub ForceDBPause()
        System.Threading.Thread.Sleep(1000)
    End Sub

    Public Sub UpdateEndTime(ByVal dt As String, ByVal rec_id As Integer)
        Dim updatedRec As Boolean = execNonQuery("UPDATE tbl_record_log SET dt_stamp_end='" & dt & "' WHERE rec_id='" & rec_id & "' AND (dt_stamp_end IS NULL OR dt_stamp_end = '0000-00-00 00:00:00')")
        If updatedRec = True Then
            DeleteLogStamp(last_pause_rec_id)
            last_pause_rec_id = 0
            frmMessages.UpdatePauseButton()
            frmMessages.enableForm()
        End If
    End Sub

    Public Sub DeleteLogStamp(ByVal rec_id As Integer)
        Try
            System.IO.File.Delete(LocalStampFile(rec_id))
        Catch
        End Try
    End Sub

    Public Sub MarkOffline(ByVal u_id As String)
        execNonQuery("DELETE FROM tbl_users_ol WHERE username='" & u_id & "'")
    End Sub

    Public Sub closeGetty()
        Try
            If EnsureDBOpen() Then
                UpdateEndTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), last_rec_id)
                FixLogout(user_id)
                'MarkOffline(user_id)
            End If
        Catch
        Finally
            Try
                cmd_close = False
                frmMessages.Close()
                frmSettings.Close()
            Catch
            End Try
            ForceDBClose(True)
        End Try
    End Sub

    Public Function execScalarInt(ByVal que As String) As Integer
        Dim v As Object = execScalar(que)
        If (v Is Nothing) Then
            Return 0
        End If
        Return Integer.Parse(v.ToString())
    End Function

    Public Function query(ByVal sql As String) As DataSet
        Dim ds = New DataSet()
        Dim is_ok As Boolean = False
        Try
            If EnsureDBOpen() Then
                Dim cmdup As New MySqlCommand(sql, sqlcon)
                Dim adapter As New MySqlDataAdapter()
                adapter.SelectCommand = cmdup
                adapter.Fill(ds)
                is_ok = True
            End If
        Catch
        End Try
        If Not is_ok Then
            ds = Nothing
        End If
        Return ds
    End Function


    Function WordWrap(ByVal Text As String, Optional ByVal MaxLineLen As Integer = 70)
        Dim i As Integer
        For i = 1 To Len(Text) / MaxLineLen
            Text = Mid(Text, 1, MaxLineLen * i - 1) & Replace(Text, " ", vbCrLf, MaxLineLen * i, 1, vbTextCompare)
        Next i
        WordWrap = Text
    End Function

    Public Function LocalStampFile(ByVal rec_id As Long) As String
        Return IIf(String.IsNullOrWhiteSpace(user_id), "", System.IO.Path.Combine(LOG_DIR, user_id & "_" & rec_id & ".txt"))
    End Function

    Public Sub afterLogin(ByVal user_name As String, ByVal station As String, ByVal firstTimeStamp As String)
        Try
            If EnsureDBOpen() Then
                'firstTimeStamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")

                'MsgBox("INSERT INTO tbl_record_log (rec_id,dt_stamp,dt_stamp_end,username,station,campaign,status,ip,dt_stamp_day,log_reason,this_site) VALUES('','" & firstTimeStamp & "','','" & user_name & "','" & Environment.MachineName & "','" & cmp_id & "','" & logged & "','" & ip & "','" & DateAndTime.Now.DayOfWeek.ToString & "','','" & conn_location & "')")
                last_rec_id = execLastID("INSERT INTO tbl_record_log (dt_stamp,dt_stamp_end,username,station,campaign,status,ip,dt_stamp_day,log_reason,this_site) VALUES('" & firstTimeStamp & "',0,'" & user_name & "','" & Environment.MachineName & "','" & cmp_id & "','" & logged & "','" & ip & "','" & DateAndTime.Now.DayOfWeek.ToString & "','','" & conn_location & "')")

                If last_rec_id <> 0 Then
                    addToHistoryLogged(user_id, "logged", "")
                    user_id = user_name
                    usr_unqid = execScalarString("SELECT user_id FROM tbl_users WHERE user_username='" & user_id & "' LIMIT 1")
                    pc_station = station
                    frmMessages.lbl_campaign.Text = usr_campaign
                    frmMessages.lbl_user_id.Text = usr_unqid
                    team_name = execScalarString("SELECT team_name FROM tbl_teams WHERE team_id='" & team_id & "' LIMIT 1")
                    Dim sql_chck As Integer = execScalarInt("SELECT COUNT(*) FROM tbl_info_respas WHERE user_id='" & usr_unqid & "'")

                    If sql_chck <> 0 Then
                        execNonQuery("UPDATE tbl_record_log SET dt_stamp_end='" & firstTimeStamp & "' WHERE username='" & user_id & "' AND status='pause' AND dt_stamp_end='0000-00-00 00:00:00' LIMIT 1")
                        frmMessages.Show()
                    Else
                        frmInfo.Show()
                    End If
                Else
                    MsgBox("Login failed", vbExclamation, "System Message")
                End If
            Else
                techSupportCritical()
            End If
        Catch
        Finally
            ForceDBClose()
        End Try
    End Sub

    Public Sub LogLocalStamp(ByVal rec_id As Long)
        If rec_id = 0 Then
            Return
        End If
        Dim ts_file = LocalStampFile(rec_id)
        If String.IsNullOrWhiteSpace(ts_file) Then
            Return
        End If
        Dim is_ok = False
        For n As Integer = 1 To 3
            Try
                Using w As New System.IO.StreamWriter(ts_file)
                    w.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                    w.Close()
                End Using
                is_ok = System.IO.File.Exists(ts_file)
                Exit For
            Catch
            End Try
            System.Threading.Thread.Sleep(1000)
        Next
        If Not is_ok Then
            techSupportCritical("Warning: Cannot write to local timestamp log, please contact tech support.")
        End If
    End Sub


    Public Sub FixLogout(ByVal current_user_id As String)
        Dim ts_file_ary = System.IO.Directory.GetFiles(LOG_DIR, "*.txt")
        For Each ts_file As String In ts_file_ary
            If Not EnsureDBOpen() Then
                Return
            End If
            Dim ary = System.IO.Path.GetFileNameWithoutExtension(ts_file).Split("_".ToCharArray())
            If (ary.Count >= 2) Then
                Dim u_id = ary(0)
                Dim rec_id = ary(1)
                If Not String.IsNullOrWhiteSpace(u_id) And Not String.IsNullOrWhiteSpace(rec_id) Then
                    Using r = New System.IO.StreamReader(ts_file)
                        Do While r.Peek() <> -1
                            Dim row = r.ReadLine()
                            If String.IsNullOrWhiteSpace(row) Then
                                Continue Do
                            End If
                            Try
                                Dim ary0 = row.Split("|".ToCharArray())
                                Dim ts = ary0(0)
                                UpdateEndTime(ts, rec_id)
                            Catch
                            End Try
                        Loop
                        r.Close()
                    End Using
                    If u_id <> current_user_id Then
                        MarkOffline(u_id)
                    End If
                End If
            End If
            Try
                System.IO.File.Delete(ts_file)
            Catch
            End Try
        Next
    End Sub

    Function convertTimeFormat(ByVal time As Integer)
        Dim new_format As Integer = 0
        If time >= 1 And time <= 12 Then
            Return time
        ElseIf time >= 13 And time <> 0 Then
            If time = 13 Then
                new_format = 1
            ElseIf time = 14 Then
                new_format = 2
            ElseIf time = 15 Then
                new_format = 3
            ElseIf time = 16 Then
                new_format = 4
            ElseIf time = 17 Then
                new_format = 5
            ElseIf time = 18 Then
                new_format = 6
            ElseIf time = 19 Then
                new_format = 7
            ElseIf time = 20 Then
                new_format = 8
            ElseIf time = 21 Then
                new_format = 9
            ElseIf time = 22 Then
                new_format = 10
            ElseIf time = 23 Then
                new_format = 11
            ElseIf time = 14 Then
                new_format = 12
            End If

            Return new_format
        Else
            Return 12
        End If
    End Function

    Function timePeriod(ByVal time As Integer)
        Dim new_period As String = ""
        If time >= 1 And time <= 12 Then
            Return "AM"
        Else
            If time = 13 Then
                new_period = "PM"
            ElseIf time = 14 Then
                new_period = "PM"
            ElseIf time = 15 Then
                new_period = "PM"
            ElseIf time = 16 Then
                new_period = "PM"
            ElseIf time = 17 Then
                new_period = "PM"
            ElseIf time = 18 Then
                new_period = "PM"
            ElseIf time = 19 Then
                new_period = "PM"
            ElseIf time = 20 Then
                new_period = "PM"
            ElseIf time = 21 Then
                new_period = "PM"
            ElseIf time = 22 Then
                new_period = "PM"
            ElseIf time = 23 Then
                new_period = "PM"
            ElseIf time = 0 Then
                new_period = "AM"
            End If

            Return new_period
        End If
    End Function

    Public Function addToHistoryLogged(ByVal user As String, ByVal status As String, ByVal reason As String) As String
        Dim file As String = historyLogs
        Dim Writer As New System.IO.StreamWriter(file, True)
        Writer.WriteLine(user & " " & DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") & " " & Environment.MachineName & " " & status & " " & reason)
        Writer.Close()
    End Function

    Public Function addToCheckerLogged(ByVal user As String, ByVal status As String, ByVal reason As String)
        Dim dateIns As String = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
        Dim file As String = ensureData
        Dim Writer As New System.IO.StreamWriter(file)
        Writer.WriteLine(user & " " & dateIns & " " & cmp_id & " " & Environment.MachineName & " " & status & " " & reason)
        Writer.Close()

        Return dateIns
    End Function

    ' old functions

    Public Function insertQuery(ByVal query As String) As String
        Try
            Dim cmdup As New MySqlCommand(query, sqlcon)
            With cmdup
                .CommandText = query
                .Connection = sqlcon
                .ExecuteNonQuery()
            End With

            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function getField(ByVal query As String, ByVal field As String) As String
        Try
            Dim cmdup As New MySqlCommand(query, sqlcon)
            Dim adapter As MySqlDataAdapter
            adapter = New MySqlDataAdapter(query, sqlcon)
            Dim ds = New DataSet
            adapter.Fill(ds, "users_id")
            Return ds.Tables(0).Rows(0).Item(field).ToString
        Catch ex As Exception
            Return 0
        End Try
    End Function

    Public Function checkExist(ByVal que As String)
        If sqlcon.State = False Then
            sqlcon.Open()
        End If
        Dim cmd As New MySqlCommand(que, sqlcon)
        Dim rows As Integer = cmd.ExecuteScalar()
        Return rows
        sqlcon.Close()
    End Function

    Public Function updateQuery(ByVal query As String) As String
        Try
            If sqlcon.State = False Then
                sqlcon.Open()
            End If

            Dim cmdup As New MySqlCommand(query, sqlcon)
            With cmdup
                .CommandText = query
                .Connection = sqlcon
                .ExecuteNonQuery()
            End With

            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
End Module
