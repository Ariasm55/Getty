Public Class bgworker

    Dim m_CountTo As Integer = 0

    Private Sub bgworker_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Start_Button_Click(sender As System.Object, e As System.EventArgs) Handles Start_Button.Click
        'Set the count to 30
        m_CountTo = 10

        ' Disable the start button

        Start_Button.Enabled = False

        ' Enable to stop button

        Stop_Button.Enabled = True

        ' Start the Background Worker working

        Bground_work.RunWorkerAsync()
    End Sub

    Private Sub Stop_Button_Click(sender As System.Object, e As System.EventArgs) Handles Stop_Button.Click
        ' Is the Background Worker do some work?

        If Bground_work.IsBusy Then

            'If it supports cancellation, Cancel It

            If Bground_work.WorkerSupportsCancellation Then

                ' Tell the Background Worker to stop working.

                Bground_work.CancelAsync()

            End If

        End If

        ' Enable to Start Button

        Start_Button.Enabled = True

        ' Disable to Stop Button

        Stop_Button.Enabled = False

    End Sub

    Private Sub Bground_work_DoWork(sender As System.Object, e As System.ComponentModel.DoWorkEventArgs) Handles Bground_work.DoWork
        For i As Integer = 0 To m_CountTo

            ' Has the background worker be told to stop?

            If Bground_work.CancellationPending Then

                ' Set Cancel to True

                e.Cancel = True

                Exit For
            End If

            System.Threading.Thread.Sleep(1000) ' Sleep for 1 Second

            ' Report The progress of the Background Worker.

            Bground_work.ReportProgress(CInt((i / m_CountTo) * 100))
            'Me.Lbl_Status.Text = FormatPercent(i / m_CountTo, 2) ' Show Percentage
            SetLabelText_ThreadSafe(Lbl_Status, FormatPercent(i / m_CountTo, 2))
        Next

    End Sub

    Private Sub Bground_work_ProgressChanged(sender As Object, e As System.ComponentModel.ProgressChangedEventArgs) Handles Bground_work.ProgressChanged

        ' Update the progress bar

        ProgressBar1.Value = e.ProgressPercentage

    End Sub

    Private Sub Bground_work_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles Bground_work.RunWorkerCompleted

        If e.Cancelled Then

            Lbl_Status.Text = "Cancelled"

        Else

            Lbl_Status.Text = "Completed"

        End If

    End Sub

    Delegate Sub SetLabelText_Delegate(ByVal [Label] As Label, ByVal [text] As String)



    ' The delegates subroutine.

    Private Sub SetLabelText_ThreadSafe(ByVal [Label] As Label, ByVal [text] As String)

        ' InvokeRequired required compares the thread ID of the calling thread to the thread ID of the creating thread.

        ' If these threads are different, it returns true.

        If [Label].InvokeRequired Then

            Dim MyDelegate As New SetLabelText_Delegate(AddressOf SetLabelText_ThreadSafe)

            Me.Invoke(MyDelegate, New Object() {[Label], [text]})

        Else

            [Label].Text = [text]

        End If

    End Sub

End Class