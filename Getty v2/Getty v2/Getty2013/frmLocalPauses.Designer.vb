<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLocalPauses
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
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.btn_cancel = New System.Windows.Forms.Button()
        Me.btn_local_pause = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cb_sel_pause = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.LightGray
        Me.Panel5.Location = New System.Drawing.Point(-2, -9)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(289, 10)
        Me.Panel5.TabIndex = 34
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.LightGray
        Me.Panel1.Location = New System.Drawing.Point(-2, 142)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(289, 10)
        Me.Panel1.TabIndex = 35
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.LightGray
        Me.Panel4.Location = New System.Drawing.Point(283, -4)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(10, 150)
        Me.Panel4.TabIndex = 36
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.LightGray
        Me.Panel2.Location = New System.Drawing.Point(-9, -4)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(10, 150)
        Me.Panel2.TabIndex = 37
        '
        'btn_cancel
        '
        Me.btn_cancel.BackColor = System.Drawing.Color.DodgerBlue
        Me.btn_cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_cancel.Font = New System.Drawing.Font("Bookman Old Style", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_cancel.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.btn_cancel.Location = New System.Drawing.Point(185, 103)
        Me.btn_cancel.Name = "btn_cancel"
        Me.btn_cancel.Size = New System.Drawing.Size(87, 28)
        Me.btn_cancel.TabIndex = 66
        Me.btn_cancel.Text = "Cancel"
        Me.btn_cancel.UseVisualStyleBackColor = False
        '
        'btn_local_pause
        '
        Me.btn_local_pause.BackColor = System.Drawing.Color.DodgerBlue
        Me.btn_local_pause.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_local_pause.Font = New System.Drawing.Font("Bookman Old Style", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_local_pause.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.btn_local_pause.Location = New System.Drawing.Point(92, 103)
        Me.btn_local_pause.Name = "btn_local_pause"
        Me.btn_local_pause.Size = New System.Drawing.Size(87, 28)
        Me.btn_local_pause.TabIndex = 65
        Me.btn_local_pause.Text = "Proceed"
        Me.btn_local_pause.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Bookman Old Style", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(12, 27)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(126, 16)
        Me.Label2.TabIndex = 64
        Me.Label2.Text = "Select type of break"
        '
        'cb_sel_pause
        '
        Me.cb_sel_pause.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_sel_pause.Font = New System.Drawing.Font("Bookman Old Style", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cb_sel_pause.FormattingEnabled = True
        Me.cb_sel_pause.Items.AddRange(New Object() {"Short Break", "Bath Break", "Lunch Break", "Tech Issue(Internal)", "Tech Issue(External)", "Admin", "Coaching(IFS)", "Coaching(QA)", "Coaching(Performance)", "Coaching(Others)", "Trng(Trainee)", "Trng(Up train)", "TL Task"})
        Me.cb_sel_pause.Location = New System.Drawing.Point(12, 46)
        Me.cb_sel_pause.Name = "cb_sel_pause"
        Me.cb_sel_pause.Size = New System.Drawing.Size(260, 26)
        Me.cb_sel_pause.TabIndex = 63
        Me.cb_sel_pause.TabStop = False
        '
        'frmLocalPauses
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(284, 143)
        Me.Controls.Add(Me.btn_cancel)
        Me.Controls.Add(Me.btn_local_pause)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cb_sel_pause)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel5)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmLocalPauses"
        Me.Text = "frmLocalPauses"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents btn_cancel As System.Windows.Forms.Button
    Friend WithEvents btn_local_pause As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cb_sel_pause As System.Windows.Forms.ComboBox
End Class
