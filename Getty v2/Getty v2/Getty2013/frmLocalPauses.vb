Public Class frmLocalPauses

    Dim drag As Boolean
    Dim mousex As Integer
    Dim mousey As Integer

    Private Sub frmLocalPauses_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.ShowInTaskbar = False
    End Sub

    Private Sub frmLocalPauses_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseDown
        drag = True
        mousex = Windows.Forms.Cursor.Position.X - Me.Left
        mousey = Windows.Forms.Cursor.Position.Y - Me.Top
    End Sub

    Private Sub frmLocalPauses_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseMove
        If drag Then
            Me.Top = Windows.Forms.Cursor.Position.Y - mousey
            Me.Left = Windows.Forms.Cursor.Position.X - mousex
        End If
    End Sub

    Private Sub frmLocalPauses_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseUp
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

    Private Sub btn_local_pause_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_local_pause.Click
        Dim path As String = loclogs
        If btn_local_pause.Text = "Pause" Then
            If MsgBox("Do you want to (PAUSE) break ?", vbQuestion + vbYesNo) = vbYes Then
                LogLocalLog("pause")
                caption_pause_break = "r"
                btn_local_pause.Text = "Resume"
            End If
        ElseIf btn_local_pause.Text = "Resume" Then
            If MsgBox("Do you want to (RESUME) break ?", vbQuestion + vbYesNo) = vbYes Then
                LogLocalLog("resume")
                btn_local_pause.Text = "Pause"
                caption_pause_break = "p"
            End If
        End If
    End Sub
End Class