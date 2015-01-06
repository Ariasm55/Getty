<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class bgworker
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Start_Button = New System.Windows.Forms.Button()
        Me.Stop_Button = New System.Windows.Forms.Button()
        Me.Bground_work = New System.ComponentModel.BackgroundWorker()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.Lbl_Status = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Start_Button
        '
        Me.Start_Button.Location = New System.Drawing.Point(175, 36)
        Me.Start_Button.Name = "Start_Button"
        Me.Start_Button.Size = New System.Drawing.Size(75, 23)
        Me.Start_Button.TabIndex = 0
        Me.Start_Button.Text = "Start"
        Me.Start_Button.UseVisualStyleBackColor = True
        '
        'Stop_Button
        '
        Me.Stop_Button.Location = New System.Drawing.Point(256, 36)
        Me.Stop_Button.Name = "Stop_Button"
        Me.Stop_Button.Size = New System.Drawing.Size(75, 23)
        Me.Stop_Button.TabIndex = 1
        Me.Stop_Button.Text = "Stop"
        Me.Stop_Button.UseVisualStyleBackColor = True
        '
        'Bground_work
        '
        Me.Bground_work.WorkerReportsProgress = True
        Me.Bground_work.WorkerSupportsCancellation = True
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(133, 134)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(100, 23)
        Me.ProgressBar1.TabIndex = 2
        '
        'Lbl_Status
        '
        Me.Lbl_Status.AutoSize = True
        Me.Lbl_Status.Location = New System.Drawing.Point(162, 102)
        Me.Lbl_Status.Name = "Lbl_Status"
        Me.Lbl_Status.Size = New System.Drawing.Size(39, 13)
        Me.Lbl_Status.TabIndex = 3
        Me.Lbl_Status.Text = "Label1"
        '
        'bgworker
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(358, 190)
        Me.Controls.Add(Me.Lbl_Status)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.Stop_Button)
        Me.Controls.Add(Me.Start_Button)
        Me.Name = "bgworker"
        Me.Text = "bgworker"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Start_Button As System.Windows.Forms.Button
    Friend WithEvents Stop_Button As System.Windows.Forms.Button
    Friend WithEvents Bground_work As System.ComponentModel.BackgroundWorker
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents Lbl_Status As System.Windows.Forms.Label
End Class
