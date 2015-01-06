<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLoginGetty
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmLoginGetty))
        Me.fadeIn = New System.Windows.Forms.Timer(Me.components)
        Me.frm_pnl = New System.Windows.Forms.Panel()
        Me.pnl_reset = New System.Windows.Forms.Panel()
        Me.PictureBox5 = New System.Windows.Forms.PictureBox()
        Me.txt_rp_user = New System.Windows.Forms.TextBox()
        Me.btn_cancel = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txt_rp_ans = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cb_rp_question = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.btn_change = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.txt_uname = New System.Windows.Forms.TextBox()
        Me.txt_pword = New System.Windows.Forms.TextBox()
        Me.link_forgot = New System.Windows.Forms.LinkLabel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.lbl_station = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.__Status = New System.Windows.Forms.Label()
        Me.__Version = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btn_login = New System.Windows.Forms.Button()
        Me.frm_pnl.SuspendLayout()
        Me.pnl_reset.SuspendLayout()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'fadeIn
        '
        '
        'frm_pnl
        '
        Me.frm_pnl.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.frm_pnl.BackColor = System.Drawing.Color.White
        Me.frm_pnl.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.frm_pnl.Controls.Add(Me.pnl_reset)
        Me.frm_pnl.Controls.Add(Me.Label2)
        Me.frm_pnl.Controls.Add(Me.Label1)
        Me.frm_pnl.Controls.Add(Me.PictureBox4)
        Me.frm_pnl.Controls.Add(Me.PictureBox3)
        Me.frm_pnl.Controls.Add(Me.txt_uname)
        Me.frm_pnl.Controls.Add(Me.txt_pword)
        Me.frm_pnl.Controls.Add(Me.link_forgot)
        Me.frm_pnl.Controls.Add(Me.PictureBox1)
        Me.frm_pnl.Controls.Add(Me.lbl_station)
        Me.frm_pnl.Controls.Add(Me.Panel3)
        Me.frm_pnl.Controls.Add(Me.btn_login)
        Me.frm_pnl.Location = New System.Drawing.Point(169, 109)
        Me.frm_pnl.Name = "frm_pnl"
        Me.frm_pnl.Size = New System.Drawing.Size(387, 242)
        Me.frm_pnl.TabIndex = 20
        '
        'pnl_reset
        '
        Me.pnl_reset.BackColor = System.Drawing.Color.White
        Me.pnl_reset.Controls.Add(Me.PictureBox5)
        Me.pnl_reset.Controls.Add(Me.txt_rp_user)
        Me.pnl_reset.Controls.Add(Me.btn_cancel)
        Me.pnl_reset.Controls.Add(Me.Label3)
        Me.pnl_reset.Controls.Add(Me.txt_rp_ans)
        Me.pnl_reset.Controls.Add(Me.Label6)
        Me.pnl_reset.Controls.Add(Me.cb_rp_question)
        Me.pnl_reset.Controls.Add(Me.Label7)
        Me.pnl_reset.Controls.Add(Me.btn_change)
        Me.pnl_reset.Location = New System.Drawing.Point(0, 40)
        Me.pnl_reset.Name = "pnl_reset"
        Me.pnl_reset.Size = New System.Drawing.Size(387, 202)
        Me.pnl_reset.TabIndex = 40
        Me.pnl_reset.Visible = False
        '
        'PictureBox5
        '
        Me.PictureBox5.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox5.BackgroundImage = Global.Getty2013.My.Resources.Resources._6_social_person2
        Me.PictureBox5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox5.Location = New System.Drawing.Point(33, 4)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(25, 25)
        Me.PictureBox5.TabIndex = 52
        Me.PictureBox5.TabStop = False
        '
        'txt_rp_user
        '
        Me.txt_rp_user.Font = New System.Drawing.Font("Bookman Old Style", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_rp_user.Location = New System.Drawing.Point(33, 33)
        Me.txt_rp_user.Name = "txt_rp_user"
        Me.txt_rp_user.Size = New System.Drawing.Size(326, 25)
        Me.txt_rp_user.TabIndex = 1
        Me.txt_rp_user.TabStop = False
        '
        'btn_cancel
        '
        Me.btn_cancel.BackColor = System.Drawing.Color.DodgerBlue
        Me.btn_cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_cancel.Font = New System.Drawing.Font("Bookman Old Style", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_cancel.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.btn_cancel.Location = New System.Drawing.Point(280, 161)
        Me.btn_cancel.Name = "btn_cancel"
        Me.btn_cancel.Size = New System.Drawing.Size(79, 28)
        Me.btn_cancel.TabIndex = 5
        Me.btn_cancel.TabStop = False
        Me.btn_cancel.Text = "Cancel"
        Me.btn_cancel.UseVisualStyleBackColor = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Bookman Old Style", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(30, 113)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(52, 16)
        Me.Label3.TabIndex = 15
        Me.Label3.Text = "Answer"
        '
        'txt_rp_ans
        '
        Me.txt_rp_ans.Font = New System.Drawing.Font("Bookman Old Style", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_rp_ans.Location = New System.Drawing.Point(33, 130)
        Me.txt_rp_ans.Name = "txt_rp_ans"
        Me.txt_rp_ans.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txt_rp_ans.Size = New System.Drawing.Size(326, 25)
        Me.txt_rp_ans.TabIndex = 3
        Me.txt_rp_ans.TabStop = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Bookman Old Style", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(30, 65)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(173, 16)
        Me.Label6.TabIndex = 14
        Me.Label6.Text = "Select your secret question"
        '
        'cb_rp_question
        '
        Me.cb_rp_question.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_rp_question.Font = New System.Drawing.Font("Bookman Old Style", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cb_rp_question.FormattingEnabled = True
        Me.cb_rp_question.Items.AddRange(New Object() {"What is your Mother's maiden name ?", "What is your last 4 digits of employee ID ?", "What is your last 4 digits of SSS ID ?", "What is your birthdate ?", "Who is your crush ?"})
        Me.cb_rp_question.Location = New System.Drawing.Point(33, 82)
        Me.cb_rp_question.Name = "cb_rp_question"
        Me.cb_rp_question.Size = New System.Drawing.Size(326, 26)
        Me.cb_rp_question.TabIndex = 2
        Me.cb_rp_question.TabStop = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Bookman Old Style", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label7.Location = New System.Drawing.Point(59, 13)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(69, 16)
        Me.Label7.TabIndex = 13
        Me.Label7.Text = "Username"
        '
        'btn_change
        '
        Me.btn_change.BackColor = System.Drawing.Color.DodgerBlue
        Me.btn_change.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_change.Font = New System.Drawing.Font("Bookman Old Style", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_change.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.btn_change.Location = New System.Drawing.Point(194, 161)
        Me.btn_change.Name = "btn_change"
        Me.btn_change.Size = New System.Drawing.Size(79, 28)
        Me.btn_change.TabIndex = 4
        Me.btn_change.TabStop = False
        Me.btn_change.Text = "Submit"
        Me.btn_change.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Bookman Old Style", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(59, 144)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 16)
        Me.Label2.TabIndex = 54
        Me.Label2.Text = "Password"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Bookman Old Style", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(59, 87)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(69, 16)
        Me.Label1.TabIndex = 53
        Me.Label1.Text = "Username"
        '
        'PictureBox4
        '
        Me.PictureBox4.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox4.BackgroundImage = Global.Getty2013.My.Resources.Resources._6_social_person2
        Me.PictureBox4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox4.Location = New System.Drawing.Point(32, 78)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(25, 25)
        Me.PictureBox4.TabIndex = 52
        Me.PictureBox4.TabStop = False
        '
        'PictureBox3
        '
        Me.PictureBox3.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox3.BackgroundImage = Global.Getty2013.My.Resources.Resources._10_device_access_accounts
        Me.PictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox3.Location = New System.Drawing.Point(32, 135)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(25, 25)
        Me.PictureBox3.TabIndex = 52
        Me.PictureBox3.TabStop = False
        '
        'txt_uname
        '
        Me.txt_uname.BackColor = System.Drawing.SystemColors.Window
        Me.txt_uname.Font = New System.Drawing.Font("Bookman Old Style", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_uname.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txt_uname.Location = New System.Drawing.Point(32, 106)
        Me.txt_uname.Name = "txt_uname"
        Me.txt_uname.Size = New System.Drawing.Size(324, 25)
        Me.txt_uname.TabIndex = 1
        '
        'txt_pword
        '
        Me.txt_pword.BackColor = System.Drawing.SystemColors.Window
        Me.txt_pword.Font = New System.Drawing.Font("Bookman Old Style", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_pword.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txt_pword.Location = New System.Drawing.Point(32, 163)
        Me.txt_pword.Name = "txt_pword"
        Me.txt_pword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txt_pword.Size = New System.Drawing.Size(324, 25)
        Me.txt_pword.TabIndex = 2
        '
        'link_forgot
        '
        Me.link_forgot.ActiveLinkColor = System.Drawing.Color.DeepSkyBlue
        Me.link_forgot.AutoSize = True
        Me.link_forgot.LinkColor = System.Drawing.Color.DodgerBlue
        Me.link_forgot.Location = New System.Drawing.Point(59, 207)
        Me.link_forgot.Name = "link_forgot"
        Me.link_forgot.Size = New System.Drawing.Size(95, 13)
        Me.link_forgot.TabIndex = 4
        Me.link_forgot.TabStop = True
        Me.link_forgot.Text = "Forgot Password ?"
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.BackgroundImage = Global.Getty2013.My.Resources.Resources._10_device_access_secure
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox1.Location = New System.Drawing.Point(32, 200)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(25, 25)
        Me.PictureBox1.TabIndex = 21
        Me.PictureBox1.TabStop = False
        '
        'lbl_station
        '
        Me.lbl_station.AutoSize = True
        Me.lbl_station.BackColor = System.Drawing.Color.Transparent
        Me.lbl_station.Font = New System.Drawing.Font("Bookman Old Style", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_station.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lbl_station.Location = New System.Drawing.Point(29, 49)
        Me.lbl_station.Name = "lbl_station"
        Me.lbl_station.Size = New System.Drawing.Size(113, 18)
        Me.lbl_station.TabIndex = 45
        Me.lbl_station.Text = "Station Number"
        Me.lbl_station.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.Transparent
        Me.Panel3.BackgroundImage = Global.Getty2013.My.Resources.Resources.bgblack
        Me.Panel3.Controls.Add(Me.__Status)
        Me.Panel3.Controls.Add(Me.__Version)
        Me.Panel3.Controls.Add(Me.Panel1)
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(387, 37)
        Me.Panel3.TabIndex = 18
        '
        '__Status
        '
        Me.__Status.Font = New System.Drawing.Font("Bookman Old Style", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.__Status.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.__Status.Location = New System.Drawing.Point(106, 11)
        Me.__Status.Name = "__Status"
        Me.__Status.Size = New System.Drawing.Size(117, 23)
        Me.__Status.TabIndex = 53
        Me.__Status.Visible = False
        '
        '__Version
        '
        Me.__Version.Font = New System.Drawing.Font("Bookman Old Style", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.__Version.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.__Version.Location = New System.Drawing.Point(201, 11)
        Me.__Version.Name = "__Version"
        Me.__Version.Size = New System.Drawing.Size(179, 23)
        Me.__Version.TabIndex = 17
        Me.__Version.Text = "Label4"
        Me.__Version.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.BackgroundImage = Global.Getty2013.My.Resources.Resources.logo_main4
        Me.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel1.Location = New System.Drawing.Point(5, 6)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(95, 26)
        Me.Panel1.TabIndex = 16
        '
        'btn_login
        '
        Me.btn_login.BackColor = System.Drawing.Color.DodgerBlue
        Me.btn_login.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_login.Font = New System.Drawing.Font("Bookman Old Style", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_login.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.btn_login.Location = New System.Drawing.Point(284, 197)
        Me.btn_login.Name = "btn_login"
        Me.btn_login.Size = New System.Drawing.Size(72, 28)
        Me.btn_login.TabIndex = 3
        Me.btn_login.Text = "Login"
        Me.btn_login.UseVisualStyleBackColor = False
        '
        'frmLoginGetty
        '
        Me.AllowDrop = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(741, 534)
        Me.ControlBox = False
        Me.Controls.Add(Me.frm_pnl)
        Me.DoubleBuffered = True
        Me.ForeColor = System.Drawing.Color.Black
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximumSize = New System.Drawing.Size(1600, 1200)
        Me.Name = "frmLoginGetty"
        Me.Opacity = 0.0R
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Welcome"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.frm_pnl.ResumeLayout(False)
        Me.frm_pnl.PerformLayout()
        Me.pnl_reset.ResumeLayout(False)
        Me.pnl_reset.PerformLayout()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents frm_pnl As System.Windows.Forms.Panel
    Friend WithEvents txt_pword As System.Windows.Forms.TextBox
    Friend WithEvents txt_uname As System.Windows.Forms.TextBox
    Friend WithEvents btn_login As System.Windows.Forms.Button
    Friend WithEvents lbl_station As System.Windows.Forms.Label
    Friend WithEvents fadeIn As System.Windows.Forms.Timer
    Friend WithEvents pnl_reset As System.Windows.Forms.Panel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txt_rp_ans As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cb_rp_question As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txt_rp_user As System.Windows.Forms.TextBox
    Friend WithEvents btn_change As System.Windows.Forms.Button
    Friend WithEvents btn_cancel As System.Windows.Forms.Button
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents link_forgot As System.Windows.Forms.LinkLabel
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox5 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents __Version As System.Windows.Forms.Label
    Friend WithEvents __Status As System.Windows.Forms.Label

End Class
