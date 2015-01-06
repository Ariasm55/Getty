Public Class frmTerminate

    Protected Overrides ReadOnly Property CreateParams() As System.Windows.Forms.CreateParams
        Get
            Const DROPSHADOW = &H20000
            Dim cParam As CreateParams = MyBase.CreateParams
            cParam.ClassStyle = cParam.ClassStyle Or DROPSHADOW
            Return cParam
        End Get
    End Property

    Private Sub frmMessages_FormClosing(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dim Cancel As Boolean = eventArgs.Cancel
        Dim UnloadMode As System.Windows.Forms.CloseReason = eventArgs.CloseReason
        If UnloadMode = CloseReason.UserClosing Then
            Cancel = cmd_close
        End If
        eventArgs.Cancel = Cancel
        ForceDBClose()
    End Sub

    Private Sub btn_restart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_restart.Click
        cmd_close = False
        frmMessages.Close()
        Me.Close()
    End Sub

    Private Sub frmTerminate_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cmd_close = True
        addToHistoryLogged(user_id, "terminated", "")
        AutoTerminate.Start()
    End Sub

    Private Sub AutoTerminate_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AutoTerminate.Tick
        cmd_close = False
        frmMessages.Close()
        Me.Close()
    End Sub
End Class