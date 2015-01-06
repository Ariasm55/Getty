Public Class frmSysAbout

    Dim drag As Boolean
    Dim mousex As Integer
    Dim mousey As Integer

    Private Sub frmSysAbout_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lbl_version.Text = GettyVersion()
    End Sub

    Protected Overrides ReadOnly Property CreateParams() As System.Windows.Forms.CreateParams
        Get
            Const DROPSHADOW = &H20000
            Dim cParam As CreateParams = MyBase.CreateParams
            cParam.ClassStyle = cParam.ClassStyle Or DROPSHADOW
            Return cParam
        End Get
    End Property

    'Private Sub frmSysAbout_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseDown
    '    drag = True
    '    mousex = Windows.Forms.Cursor.Position.X - Me.Left
    '    mousey = Windows.Forms.Cursor.Position.Y - Me.Top
    'End Sub

    'Private Sub frmSysAbout_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseMove
    '    If drag Then
    '        Me.Top = Windows.Forms.Cursor.Position.Y - mousey
    '        Me.Left = Windows.Forms.Cursor.Position.X - mousex
    '    End If
    'End Sub

    'Private Sub frmSysAbout_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseUp
    '    drag = False
    'End Sub

    Private Sub btn_close_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_close.Click
        Me.Close()
    End Sub
End Class