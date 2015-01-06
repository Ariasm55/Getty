Public Class frmUndertime

    Private Sub frmUndertime_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub btn_reason_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_reason.Click
        Try
            If EnsureDBOpen() Then
                If txt_u_reason.Text <> "" Then
                    execNonQuery("UPDATE tbl_record_log SET dt_stamp_end='" & DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") & "', log_reason='Undertime: " & txt_u_reason.Text & "' WHERE rec_id='" & last_rec_id & "' AND this_site='" & conn_location & "'")
                    frmSettings.Close()
                    cmd_close = False
                    frmMessages.Close()
                    Me.Close()
                Else
                    MsgBox("Please type your reason.", vbExclamation, "System Message")
                End If
            End If
        Catch
        Finally
            ForceDBClose()
        End Try
        
    End Sub
End Class