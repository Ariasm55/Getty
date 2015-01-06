Public Class frmSelectShift

    Protected Overrides ReadOnly Property CreateParams() As System.Windows.Forms.CreateParams
        Get
            Const DROPSHADOW = &H20000
            Dim cParam As CreateParams = MyBase.CreateParams
            cParam.ClassStyle = cParam.ClassStyle Or DROPSHADOW
            Return cParam
        End Get
    End Property

    Private Sub frmSelectShift_FormClosing(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dim Cancel As Boolean = eventArgs.Cancel
        Dim UnloadMode As System.Windows.Forms.CloseReason = eventArgs.CloseReason
        If UnloadMode = CloseReason.UserClosing Then
            Cancel = cmd_close
        End If
        eventArgs.Cancel = Cancel
        ForceDBClose()
    End Sub

    Private Sub btn_restart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_restart.Click
        close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        close()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        close()
    End Sub

    Private Sub frmSelectShift_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cmd_close = True
    End Sub

    Sub close()
        frmMessages.Show()
        cmd_close = False
        Me.close()
        cmd_close = True
    End Sub
End Class