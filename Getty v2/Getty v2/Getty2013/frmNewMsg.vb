Public Class frmNewMsg
    Private oe As Integer = 0
    Private x As Integer = 5
    Private y As Integer = 5
    Private vibrate As Integer = 35
    Public count As Integer = 0

    Private Sub frmNewMsg_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.BringToFront()
        Timer1.Start()
        Timer2.Start()
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

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Timer1.Stop()
        Me.Close()
    End Sub

    Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick
        Me.Location = New Point(Screen.PrimaryScreen.WorkingArea.Width - Me.Width - x, Screen.PrimaryScreen.WorkingArea.Height - Me.Height - y)

        If oe = 1 Then
            x += vibrate
            oe = 0
            vibrate -= 5
        Else
            x -= vibrate
            oe = 1
        End If

        If x = 0 Then
            Timer2.Stop()
            x = 5
            y = 5
            count = 0
            Timer3.Start()
        End If

        count += 1
    End Sub

    Private Sub Timer3_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer3.Tick
        If count <> 200 Then
            count += 1
        Else
            Me.Location = New Point(Screen.PrimaryScreen.WorkingArea.Width - Me.Width - x, Screen.PrimaryScreen.WorkingArea.Height - Me.Height - y)
            x -= 2
        End If
    End Sub
End Class