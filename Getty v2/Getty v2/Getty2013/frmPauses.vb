Imports MySql.Data.MySqlClient

Public Class frmPauses

    Dim drag As Boolean
    Dim mousex As Integer
    Dim mousey As Integer

    Private Sub frmPauses_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        displayPausesType()
    End Sub

    Protected Overrides ReadOnly Property CreateParams() As System.Windows.Forms.CreateParams
        Get
            Const DROPSHADOW = &H20000
            Dim cParam As CreateParams = MyBase.CreateParams
            cParam.ClassStyle = cParam.ClassStyle Or DROPSHADOW
            Return cParam
        End Get
    End Property

    Private Sub btn_proc_pause_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_proc_pause.Click
        btn_proc_pause.Enabled = False
        If cb_sel_pause.Text <> "" Then
            Dim breakR As String = cb_sel_pause.Text
            Dim reason As String = breakR.Replace(" ", "")
            addToHistoryLogged(user_id, "pause", reason)
            Dim dateAdded As String = addToCheckerLogged(user_id, "pause", reason)

            Try
                last_pause_rec_id = 0
                If EnsureDBOpen() Then

                    Dim has_record As Integer = execNonQuery("SELECT rec_id FROM tbl_record_log WHERE username='" & user_id & "' AND dt_stamp_end='0000-00-00 00:00:00' AND status='logged' ORDER BY 1 DESC")
                    If has_record = 0 Then
                        last_rec_id = execLastID("INSERT INTO tbl_record_log (dt_stamp,dt_stamp_end,username,station,campaign,status,ip,dt_stamp_day,log_reason,this_site) VALUES('" & DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") & "',0,'" & user_id & "','" & Environment.MachineName.ToString & "','" & cmp_id & "','" & logged & "','" & ip & "','" & DateAndTime.Now.DayOfWeek.ToString & "','','" & conn_location & "')")
                        If last_rec_id <> 0 Then
                            LogLocalStamp(last_rec_id)
                        End If
                    End If

                    last_pause_rec_id = execLastID("INSERT INTO tbl_record_log (dt_stamp,dt_stamp_end,username,station,campaign,status,ip,dt_stamp_day,log_reason,this_site) VALUES('" & dateAdded & "',0,'" & user_id & "','" & Environment.MachineName.ToString & "','" & cmp_id & "','" & pause_break & "','" & ip & "','" & DateAndTime.Now.DayOfWeek.ToString & "','" & cb_sel_pause.Text & "','" & conn_location & "')")
                    If last_pause_rec_id <> 0 Then
                        'MsgBox(last_pause_rec_id)
                        LogLocalStamp(last_pause_rec_id)
                        frmMessages.UpdatePauseButton()
                        frmMessages.disableForm()
                    Else
                        addToHistoryLogged(user_id, "failed", reason)
                        MsgBox("Saving record failed, please try again.", vbExclamation, "System Message")
                    End If
                Else
                    techSupportCritical()
                End If
            Finally
                ForceDBClose()
            End Try
        Else
            MsgBox("Please select type of pause.", vbExclamation, "System Message")
        End If

        btn_proc_pause.Enabled = True
        frmMessages.btn_pause.Enabled = True
        Me.Close()
    End Sub

    Private Sub btn_cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cancel.Click
        frmMessages.btn_pause.Enabled = True
        Me.Close()
    End Sub

    Public Sub displayPausesType()
        If cb_sel_pause.Items.Count = 0 Then
            Try
                If Not EnsureDBOpen() Then
                    techSupportCritical()
                    Me.Close()
                    Return
                End If
                Dim ds = query("SELECT pause_reason FROM tbl_pauses")
                If Not ds Is Nothing Then
                    Dim dt = ds.Tables(0)
                    For i As Integer = 0 To dt.Rows.Count - 1
                        cb_sel_pause.Items.Add(dt.Rows(i).Item("pause_reason").ToString())
                    Next
                End If
            Finally
                ForceDBClose()
            End Try
        End If
        If cb_sel_pause.Items.Count > 0 Then
            cb_sel_pause.SelectedIndex = -1
        End If
    End Sub
End Class