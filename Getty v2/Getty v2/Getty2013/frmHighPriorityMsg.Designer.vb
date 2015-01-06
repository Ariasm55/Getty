<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmHighPriorityMsg
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmHighPriorityMsg))
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lbl_from = New System.Windows.Forms.Label()
        Me.lbl_to = New System.Windows.Forms.Label()
        Me.lbl_date = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lbl_title = New System.Windows.Forms.Label()
        Me.msg_id = New System.Windows.Forms.Label()
        Me.btn_read = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.cb_read = New System.Windows.Forms.CheckBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.lbl_msg_read = New System.Windows.Forms.Label()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.lbl_campaign = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel4.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label6
        '
        Me.Label6.AccessibleRole = System.Windows.Forms.AccessibleRole.TitleBar
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Bookman Old Style", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.DimGray
        Me.Label6.Location = New System.Drawing.Point(17, 42)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(42, 16)
        Me.Label6.TabIndex = 25
        Me.Label6.Text = "From:"
        '
        'Label3
        '
        Me.Label3.AccessibleRole = System.Windows.Forms.AccessibleRole.TitleBar
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Bookman Old Style", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.DimGray
        Me.Label3.Location = New System.Drawing.Point(18, 76)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(26, 16)
        Me.Label3.TabIndex = 24
        Me.Label3.Text = "To:"
        '
        'lbl_from
        '
        Me.lbl_from.AccessibleRole = System.Windows.Forms.AccessibleRole.TitleBar
        Me.lbl_from.AutoSize = True
        Me.lbl_from.BackColor = System.Drawing.Color.Transparent
        Me.lbl_from.Font = New System.Drawing.Font("Bookman Old Style", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_from.ForeColor = System.Drawing.Color.Black
        Me.lbl_from.Location = New System.Drawing.Point(66, 41)
        Me.lbl_from.Name = "lbl_from"
        Me.lbl_from.Size = New System.Drawing.Size(38, 16)
        Me.lbl_from.TabIndex = 23
        Me.lbl_from.Text = "From"
        '
        'lbl_to
        '
        Me.lbl_to.AccessibleRole = System.Windows.Forms.AccessibleRole.TitleBar
        Me.lbl_to.AutoSize = True
        Me.lbl_to.BackColor = System.Drawing.Color.Transparent
        Me.lbl_to.Font = New System.Drawing.Font("Bookman Old Style", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_to.ForeColor = System.Drawing.Color.Black
        Me.lbl_to.Location = New System.Drawing.Point(67, 76)
        Me.lbl_to.Name = "lbl_to"
        Me.lbl_to.Size = New System.Drawing.Size(22, 16)
        Me.lbl_to.TabIndex = 22
        Me.lbl_to.Text = "To"
        '
        'lbl_date
        '
        Me.lbl_date.AccessibleRole = System.Windows.Forms.AccessibleRole.TitleBar
        Me.lbl_date.AutoSize = True
        Me.lbl_date.BackColor = System.Drawing.Color.Transparent
        Me.lbl_date.Font = New System.Drawing.Font("Bookman Old Style", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_date.ForeColor = System.Drawing.Color.Black
        Me.lbl_date.Location = New System.Drawing.Point(68, 59)
        Me.lbl_date.Name = "lbl_date"
        Me.lbl_date.Size = New System.Drawing.Size(34, 16)
        Me.lbl_date.TabIndex = 21
        Me.lbl_date.Text = "date"
        '
        'Label2
        '
        Me.Label2.AccessibleRole = System.Windows.Forms.AccessibleRole.TitleBar
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Bookman Old Style", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.DimGray
        Me.Label2.Location = New System.Drawing.Point(18, 59)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(40, 16)
        Me.Label2.TabIndex = 26
        Me.Label2.Text = "Sent:"
        '
        'lbl_title
        '
        Me.lbl_title.AccessibleRole = System.Windows.Forms.AccessibleRole.TitleBar
        Me.lbl_title.AutoSize = True
        Me.lbl_title.BackColor = System.Drawing.Color.Transparent
        Me.lbl_title.Font = New System.Drawing.Font("Bookman Old Style", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_title.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lbl_title.Location = New System.Drawing.Point(16, 14)
        Me.lbl_title.Name = "lbl_title"
        Me.lbl_title.Size = New System.Drawing.Size(40, 19)
        Me.lbl_title.TabIndex = 27
        Me.lbl_title.Text = "title"
        '
        'msg_id
        '
        Me.msg_id.AutoSize = True
        Me.msg_id.BackColor = System.Drawing.Color.Transparent
        Me.msg_id.Location = New System.Drawing.Point(411, 9)
        Me.msg_id.Name = "msg_id"
        Me.msg_id.Size = New System.Drawing.Size(39, 13)
        Me.msg_id.TabIndex = 28
        Me.msg_id.Text = "Label1"
        Me.msg_id.Visible = False
        '
        'btn_read
        '
        Me.btn_read.BackColor = System.Drawing.Color.DodgerBlue
        Me.btn_read.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_read.Font = New System.Drawing.Font("Bookman Old Style", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_read.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.btn_read.Location = New System.Drawing.Point(371, 307)
        Me.btn_read.Name = "btn_read"
        Me.btn_read.Size = New System.Drawing.Size(79, 28)
        Me.btn_read.TabIndex = 52
        Me.btn_read.Text = "OK"
        Me.btn_read.UseVisualStyleBackColor = False
        Me.btn_read.Visible = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.cb_read)
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Controls.Add(Me.btn_read)
        Me.Panel1.Controls.Add(Me.lbl_date)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.lbl_to)
        Me.Panel1.Controls.Add(Me.lbl_title)
        Me.Panel1.Controls.Add(Me.lbl_from)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Panel4)
        Me.Panel1.Location = New System.Drawing.Point(-1, 36)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(464, 346)
        Me.Panel1.TabIndex = 53
        '
        'cb_read
        '
        Me.cb_read.AutoSize = True
        Me.cb_read.Location = New System.Drawing.Point(14, 314)
        Me.cb_read.Name = "cb_read"
        Me.cb_read.Size = New System.Drawing.Size(116, 17)
        Me.cb_read.TabIndex = 56
        Me.cb_read.Text = "I read the message"
        Me.cb_read.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.BackgroundImage = Global.Getty2013.My.Resources.Resources.impmsg
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox1.Location = New System.Drawing.Point(405, 7)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(45, 44)
        Me.PictureBox1.TabIndex = 54
        Me.PictureBox1.TabStop = False
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.LightGray
        Me.Panel2.Location = New System.Drawing.Point(-3, 344)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(467, 10)
        Me.Panel2.TabIndex = 53
        '
        'Panel4
        '
        Me.Panel4.AutoScroll = True
        Me.Panel4.BackColor = System.Drawing.Color.White
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel4.Controls.Add(Me.lbl_msg_read)
        Me.Panel4.Location = New System.Drawing.Point(14, 102)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(437, 199)
        Me.Panel4.TabIndex = 55
        '
        'lbl_msg_read
        '
        Me.lbl_msg_read.AutoSize = True
        Me.lbl_msg_read.BackColor = System.Drawing.Color.Transparent
        Me.lbl_msg_read.Font = New System.Drawing.Font("Bookman Old Style", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_msg_read.Location = New System.Drawing.Point(13, 16)
        Me.lbl_msg_read.Name = "lbl_msg_read"
        Me.lbl_msg_read.Size = New System.Drawing.Size(110, 16)
        Me.lbl_msg_read.TabIndex = 13
        Me.lbl_msg_read.Text = "message content"
        '
        'Panel7
        '
        Me.Panel7.BackColor = System.Drawing.Color.LightGray
        Me.Panel7.Location = New System.Drawing.Point(461, 37)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(10, 426)
        Me.Panel7.TabIndex = 53
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.LightGray
        Me.Panel3.Location = New System.Drawing.Point(-9, 37)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(10, 438)
        Me.Panel3.TabIndex = 54
        '
        'lbl_campaign
        '
        Me.lbl_campaign.AutoSize = True
        Me.lbl_campaign.BackColor = System.Drawing.Color.Transparent
        Me.lbl_campaign.Font = New System.Drawing.Font("Bookman Old Style", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_campaign.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.lbl_campaign.Location = New System.Drawing.Point(12, 12)
        Me.lbl_campaign.Name = "lbl_campaign"
        Me.lbl_campaign.Size = New System.Drawing.Size(132, 14)
        Me.lbl_campaign.TabIndex = 55
        Me.lbl_campaign.Text = "Important Message"
        Me.lbl_campaign.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'frmHighPriorityMsg
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.IndianRed
        Me.BackgroundImage = Global.Getty2013.My.Resources.Resources.bgblack
        Me.ClientSize = New System.Drawing.Size(462, 381)
        Me.Controls.Add(Me.lbl_campaign)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel7)
        Me.Controls.Add(Me.msg_id)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmHighPriorityMsg"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Important Message"
        Me.TopMost = True
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lbl_from As System.Windows.Forms.Label
    Friend WithEvents lbl_to As System.Windows.Forms.Label
    Friend WithEvents lbl_date As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lbl_title As System.Windows.Forms.Label
    Friend WithEvents msg_id As System.Windows.Forms.Label
    Friend WithEvents btn_read As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel7 As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents lbl_campaign As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents lbl_msg_read As System.Windows.Forms.Label
    Friend WithEvents cb_read As System.Windows.Forms.CheckBox
End Class
