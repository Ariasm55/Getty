Imports MySql.Data.MySqlClient

Public Class frmInfo
    Public attempt As Integer = 0
    Dim drag As Boolean
    Dim mousex As Integer
    Dim mousey As Integer

    Private Sub frmInfo_FormClosing(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
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

    Private Sub frmInfo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cmd_close = True
    End Sub

    Protected Overrides ReadOnly Property CreateParams() As System.Windows.Forms.CreateParams
        Get
            Const DROPSHADOW = &H20000
            Dim cParam As CreateParams = MyBase.CreateParams
            cParam.ClassStyle = cParam.ClassStyle Or DROPSHADOW
            Return cParam
        End Get
    End Property

    Private Sub btn_submit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_submit.Click
        submitInfo()
    End Sub

    Private Sub txt_ans_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_ans.KeyUp
        If e.KeyCode = Keys.Enter Then
            If attempt <> 1 Then
                attempt = 1
                submitInfo()
            Else
                attempt = 0
            End If
        End If
    End Sub

    Sub submitInfo()
        If cb_question.SelectedIndex.ToString.Equals("-1") Then
            MsgBox("Please select a question.", vbExclamation, "System Message")
        Else
            If txt_ans.Text <> "" Then
                Try
                    If Not EnsureDBOpen() Then
                        techSupportCritical()
                        Return
                    End If
                    Dim question As String = cb_question.Text
                    Dim ins As Boolean = execNonQuery("INSERT INTO tbl_info_respas (user_id,question,answer) VALUES('" & usr_unqid & "','" & question.Replace("'", "\'") & "','" & txt_ans.Text & "')")
                    If ins = True Then
                        frmResetPwd.Show()
                        cmd_close = False
                        Me.Close()
                        cmd_close = True
                    Else
                        ForceDBClose()
                        MsgBox("Saving information has an error.", vbCritical, "Error")
                    End If
                Finally
                    ForceDBClose()
                End Try
            Else
                MsgBox("Please type your answer.", vbExclamation, "System Message")
            End If
        End If
    End Sub
End Class