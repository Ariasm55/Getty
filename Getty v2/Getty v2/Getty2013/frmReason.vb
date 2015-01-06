Public Class frmReason

    Dim drag As Boolean
    Dim mousex As Integer
    Dim mousey As Integer
    Public camp_name As String

    Private Sub frmReason_FormClosing(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
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

    Private Sub frmReason_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cmd_close = True
        getInfo()
    End Sub

    Protected Overrides ReadOnly Property CreateParams() As System.Windows.Forms.CreateParams
        Get
            Const DROPSHADOW = &H20000
            Dim cParam As CreateParams = MyBase.CreateParams
            cParam.ClassStyle = cParam.ClassStyle Or DROPSHADOW
            Return cParam
        End Get
    End Property


    Private Sub btn_reason_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_reason.Click
        If cb_reason.SelectedIndex.ToString.Equals("-1") Then
            MsgBox("Please select your reason.")
        Else
            Try
                If EnsureDBOpen() Then
                    execNonQuery("UPDATE tbl_record_log SET log_reason='" & cb_reason.Text & "', dt_stamp_end='" & DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") & "' WHERE username='" & lbl_username.Text & "' AND rec_id='" & lbl_id.Text & "' AND this_site='" & conn_location & "' AND status='logged'")
                    afterLogin(lbl_username.Text, lbl_pc.Text, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                    cmd_close = False
                    Me.Close()
                    cmd_close = True
                Else
                    techSupportCritical()
                End If
            Finally
                ForceDBClose()
            End Try
        End If
    End Sub

    Sub getInfo()
        Try
            If EnsureDBOpen() Then
                Dim row = query1stRow("SELECT username,station,dt_stamp,campaign FROM tbl_record_log WHERE rec_id='" & lbl_id.Text & "' LIMIT 1")
                If Not row Is Nothing Then
                    lbl_username.Text = row("username").ToString()
                    lbl_pc.Text = row("station").ToString()
                    lbl_time_in.Text = row("dt_stamp").ToString()
                    camp_name = row("campaign").ToString()
                    lbl_campaign.Text = execScalarString("SELECT campaign_name FROM tbl_campaigns WHERE this_site='" & conn_location & "' AND campaign_id='" & cmp_id & "' AND archived='0'")
                End If
            Else
                techSupportCritical()
            End If
        Finally
            ForceDBClose()
        End Try
    End Sub
End Class