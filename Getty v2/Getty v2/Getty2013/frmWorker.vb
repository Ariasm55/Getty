Public Class frmWorker

    Private Sub frmWorker_Load(sender As System.Object, e As System.EventArgs)
        Button1.Text = "Start"
        Button2.Text = "Cancel"
        Label1.Text = ""
        Label2.Text = ""
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Button1.Enabled = False
        Button2.Enabled = True

        '' these properties should be set to True (at design-time or runtime) before calling the RunWorkerAsync
        '' to ensure that it supports Cancellation and reporting Progress
        BackgroundWorker1.WorkerSupportsCancellation = True
        BackgroundWorker1.WorkerReportsProgress = True

        '' call this method to start your asynchronous Task.
        BackgroundWorker1.RunWorkerAsync()
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        '' to cancel the task, just call the BackgroundWorker1.CancelAsync method.
        Button2.Enabled = False
        BackgroundWorker1.CancelAsync()
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        '' The asynchronous task you want to perform goes here
        '' the following is an example of how it typically goes.

        Const Max As Integer = 50

        For i = 1 To Max
            '' do something
            '' (I put a sleep to simulate time consumed)
            Threading.Thread.Sleep(100)

            '' report progress at regular intervals
            BackgroundWorker1.ReportProgress(CInt(100 * i / Max), "Running..." & i.ToString)

            '' check at regular intervals for CancellationPending
            If BackgroundWorker1.CancellationPending Then
                BackgroundWorker1.ReportProgress(CInt(100 * i / Max), "Cancelling...")
                Exit For
            End If
        Next

        '' any cleanup code go here
        '' ensure that you close all open resources before exitting out of this Method.
        '' try to skip off whatever is not desperately necessary if CancellationPending is True

        '' set the e.Cancel to True to indicate to the RunWorkerCompleted that you cancelled out
        If BackgroundWorker1.CancellationPending Then
            e.Cancel = True
            BackgroundWorker1.ReportProgress(100, "Cancelled.")
        End If
    End Sub

    Private Sub BackgroundWorker1_ProgressChanged(sender As Object, e As System.ComponentModel.ProgressChangedEventArgs) Handles BackgroundWorker1.ProgressChanged
        '' This event is fired when you call the ReportProgress method from inside your DoWork.
        '' Any visual indicators about the progress should go here.
        Label1.Text = CType(e.UserState, String)
        Label2.Text = e.ProgressPercentage.ToString & "% complete."
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        '' This event is fired when your BackgroundWorker exits.
        '' It may have exitted Normally after completing its task, 
        '' or because of Cancellation, or due to any Error.

        If e.Error IsNot Nothing Then
            '' if BackgroundWorker terminated due to error
            MessageBox.Show(e.Error.Message)
            Label1.Text = "Error occurred!"

        ElseIf e.Cancelled Then
            '' otherwise if it was cancelled
            MessageBox.Show("Task cancelled!")
            Label1.Text = "Task Cancelled!"

        Else
            '' otherwise it completed normally
            MessageBox.Show("Task completed!")
            Label1.Text = "Error completed!"
        End If

        Button1.Enabled = True
        Button2.Enabled = False
    End Sub
End Class