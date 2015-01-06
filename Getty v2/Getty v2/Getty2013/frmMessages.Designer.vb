<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMessages
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMessages))
        Me.fadeIn = New System.Windows.Forms.Timer(Me.components)
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lbl_user_id = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lbl_campaign = New System.Windows.Forms.Label()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.Panel8 = New System.Windows.Forms.Panel()
        Me.load = New System.Windows.Forms.Timer(Me.components)
        Me.pnl_minimize = New System.Windows.Forms.Panel()
        Me.Panel10 = New System.Windows.Forms.Panel()
        Me.TrayIcon = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.updatingTime = New System.Windows.Forms.Timer(Me.components)
        Me.lbl_img_title = New System.Windows.Forms.Label()
        Me.OpenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.checkSchedule = New System.Windows.Forms.Timer(Me.components)
        Me.shutdownCount = New System.Windows.Forms.Timer(Me.components)
        Me.localStamp = New System.Windows.Forms.Timer(Me.components)
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.lbl_show_time = New System.Windows.Forms.Label()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.__Status = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.pnl_hide = New System.Windows.Forms.Panel()
        Me.pnl_disp_lock = New System.Windows.Forms.Panel()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.PictureBox5 = New System.Windows.Forms.PictureBox()
        Me.load_start = New System.Windows.Forms.Panel()
        Me.__Error = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btn_resume = New System.Windows.Forms.Button()
        Me.btn_pause = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.pnl_blk_disp = New System.Windows.Forms.Panel()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lbl_from = New System.Windows.Forms.Label()
        Me.lbl_to = New System.Windows.Forms.Label()
        Me.lbl_date = New System.Windows.Forms.Label()
        Me.lbl_title = New System.Windows.Forms.Label()
        Me.lbl_msg_read = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btn_profile = New System.Windows.Forms.Button()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.lbl_wait = New System.Windows.Forms.Label()
        Me.lv_inbox = New System.Windows.Forms.ListView()
        Me.__Center = New System.Windows.Forms.Label()
        Me.updateInbox = New System.Windows.Forms.Timer(Me.components)
        Me.timeStampOL = New System.Windows.Forms.Timer(Me.components)
        Me.PictureBox7 = New System.Windows.Forms.PictureBox()
        Me.pnl_exit = New System.Windows.Forms.Panel()
        Me.GettyTime = New System.Windows.Forms.Timer(Me.components)
        Me.logsChecker = New System.Windows.Forms.Timer(Me.components)
        Me.extractHistory = New System.Windows.Forms.Timer(Me.components)
        Me.pb_sysinfo = New System.Windows.Forms.PictureBox()
        Me.Panel3.SuspendLayout()
        Me.pnl_minimize.SuspendLayout()
        Me.MenuStrip.SuspendLayout()
        Me.Panel4.SuspendLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnl_hide.SuspendLayout()
        Me.pnl_disp_lock.SuspendLayout()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pb_sysinfo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'fadeIn
        '
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Consolas", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label4.Location = New System.Drawing.Point(485, 13)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(0, 14)
        Me.Label4.TabIndex = 13
        Me.Label4.Visible = False
        '
        'lbl_user_id
        '
        Me.lbl_user_id.AutoSize = True
        Me.lbl_user_id.BackColor = System.Drawing.Color.Transparent
        Me.lbl_user_id.Font = New System.Drawing.Font("Bookman Old Style", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_user_id.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lbl_user_id.Location = New System.Drawing.Point(76, 54)
        Me.lbl_user_id.Name = "lbl_user_id"
        Me.lbl_user_id.Size = New System.Drawing.Size(111, 16)
        Me.lbl_user_id.TabIndex = 11
        Me.lbl_user_id.Text = "getty.sampleuser"
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.Transparent
        Me.Panel3.BackgroundImage = Global.Getty2013.My.Resources.Resources.bgblack
        Me.Panel3.Controls.Add(Me.Panel1)
        Me.Panel3.Location = New System.Drawing.Point(4, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(105, 37)
        Me.Panel3.TabIndex = 17
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
        'lbl_campaign
        '
        Me.lbl_campaign.AutoSize = True
        Me.lbl_campaign.BackColor = System.Drawing.Color.Transparent
        Me.lbl_campaign.Font = New System.Drawing.Font("Bookman Old Style", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_campaign.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.lbl_campaign.Location = New System.Drawing.Point(147, 13)
        Me.lbl_campaign.Name = "lbl_campaign"
        Me.lbl_campaign.Size = New System.Drawing.Size(120, 14)
        Me.lbl_campaign.TabIndex = 16
        Me.lbl_campaign.Text = "Fortune Builders"
        Me.lbl_campaign.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel6
        '
        Me.Panel6.BackColor = System.Drawing.Color.LightGray
        Me.Panel6.Location = New System.Drawing.Point(-9, 37)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(10, 686)
        Me.Panel6.TabIndex = 20
        '
        'Panel7
        '
        Me.Panel7.BackColor = System.Drawing.Color.LightGray
        Me.Panel7.Location = New System.Drawing.Point(562, 39)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(10, 686)
        Me.Panel7.TabIndex = 21
        '
        'Panel8
        '
        Me.Panel8.BackColor = System.Drawing.Color.LightGray
        Me.Panel8.Location = New System.Drawing.Point(-24, 557)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(593, 10)
        Me.Panel8.TabIndex = 20
        '
        'load
        '
        Me.load.Interval = 1
        '
        'pnl_minimize
        '
        Me.pnl_minimize.BackColor = System.Drawing.Color.Transparent
        Me.pnl_minimize.Controls.Add(Me.Panel10)
        Me.pnl_minimize.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pnl_minimize.Location = New System.Drawing.Point(482, 9)
        Me.pnl_minimize.Name = "pnl_minimize"
        Me.pnl_minimize.Size = New System.Drawing.Size(20, 20)
        Me.pnl_minimize.TabIndex = 25
        '
        'Panel10
        '
        Me.Panel10.BackColor = System.Drawing.Color.Gainsboro
        Me.Panel10.Location = New System.Drawing.Point(5, 14)
        Me.Panel10.Name = "Panel10"
        Me.Panel10.Size = New System.Drawing.Size(10, 1)
        Me.Panel10.TabIndex = 26
        '
        'TrayIcon
        '
        Me.TrayIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info
        Me.TrayIcon.BalloonTipText = "Click here to (Open) application."
        Me.TrayIcon.BalloonTipTitle = "Getty v1.0.3"
        Me.TrayIcon.Icon = CType(resources.GetObject("TrayIcon.Icon"), System.Drawing.Icon)
        Me.TrayIcon.Visible = True
        '
        'updatingTime
        '
        Me.updatingTime.Interval = 5000
        '
        'lbl_img_title
        '
        Me.lbl_img_title.AutoSize = True
        Me.lbl_img_title.BackColor = System.Drawing.Color.Transparent
        Me.lbl_img_title.Font = New System.Drawing.Font("Consolas", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_img_title.ForeColor = System.Drawing.Color.Black
        Me.lbl_img_title.Location = New System.Drawing.Point(427, 13)
        Me.lbl_img_title.Name = "lbl_img_title"
        Me.lbl_img_title.Size = New System.Drawing.Size(14, 14)
        Me.lbl_img_title.TabIndex = 31
        Me.lbl_img_title.Text = "0"
        Me.lbl_img_title.Visible = False
        '
        'OpenToolStripMenuItem
        '
        Me.OpenToolStripMenuItem.Name = "OpenToolStripMenuItem"
        Me.OpenToolStripMenuItem.Size = New System.Drawing.Size(103, 22)
        Me.OpenToolStripMenuItem.Text = "Op&en"
        '
        'MenuStrip
        '
        Me.MenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OpenToolStripMenuItem})
        Me.MenuStrip.Name = "MenuStrip"
        Me.MenuStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.MenuStrip.Size = New System.Drawing.Size(104, 26)
        '
        'checkSchedule
        '
        Me.checkSchedule.Interval = 10000
        '
        'shutdownCount
        '
        Me.shutdownCount.Interval = 1800000
        '
        'localStamp
        '
        Me.localStamp.Interval = 65000
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.White
        Me.Panel4.Controls.Add(Me.Panel8)
        Me.Panel4.Controls.Add(Me.Label9)
        Me.Panel4.Controls.Add(Me.lbl_show_time)
        Me.Panel4.Controls.Add(Me.PictureBox3)
        Me.Panel4.Controls.Add(Me.Label8)
        Me.Panel4.Controls.Add(Me.__Status)
        Me.Panel4.Controls.Add(Me.PictureBox1)
        Me.Panel4.Controls.Add(Me.pnl_hide)
        Me.Panel4.Controls.Add(Me.__Error)
        Me.Panel4.Controls.Add(Me.Label1)
        Me.Panel4.Controls.Add(Me.btn_resume)
        Me.Panel4.Controls.Add(Me.btn_pause)
        Me.Panel4.Controls.Add(Me.Panel2)
        Me.Panel4.Controls.Add(Me.btn_profile)
        Me.Panel4.Controls.Add(Me.lbl_user_id)
        Me.Panel4.Controls.Add(Me.PictureBox2)
        Me.Panel4.Controls.Add(Me.lbl_wait)
        Me.Panel4.Controls.Add(Me.lv_inbox)
        Me.Panel4.Cursor = System.Windows.Forms.Cursors.Default
        Me.Panel4.Location = New System.Drawing.Point(0, 37)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(565, 557)
        Me.Panel4.TabIndex = 59
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Bookman Old Style", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label9.Location = New System.Drawing.Point(36, 84)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(41, 16)
        Me.Label9.TabIndex = 69
        Me.Label9.Text = "Time:"
        '
        'lbl_show_time
        '
        Me.lbl_show_time.AutoSize = True
        Me.lbl_show_time.BackColor = System.Drawing.Color.Transparent
        Me.lbl_show_time.Font = New System.Drawing.Font("Bookman Old Style", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_show_time.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lbl_show_time.Location = New System.Drawing.Point(79, 84)
        Me.lbl_show_time.Name = "lbl_show_time"
        Me.lbl_show_time.Size = New System.Drawing.Size(0, 16)
        Me.lbl_show_time.TabIndex = 68
        '
        'PictureBox3
        '
        Me.PictureBox3.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox3.BackgroundImage = Global.Getty2013.My.Resources.Resources._10_device_access_time
        Me.PictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox3.Location = New System.Drawing.Point(8, 77)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(25, 25)
        Me.PictureBox3.TabIndex = 67
        Me.PictureBox3.TabStop = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Bookman Old Style", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label8.Location = New System.Drawing.Point(36, 24)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(52, 16)
        Me.Label8.TabIndex = 66
        Me.Label8.Text = "Status:"
        '
        '__Status
        '
        Me.__Status.AutoSize = True
        Me.__Status.BackColor = System.Drawing.Color.Transparent
        Me.__Status.Font = New System.Drawing.Font("Bookman Old Style", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.__Status.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.__Status.Location = New System.Drawing.Point(87, 24)
        Me.__Status.Name = "__Status"
        Me.__Status.Size = New System.Drawing.Size(48, 16)
        Me.__Status.TabIndex = 65
        Me.__Status.Text = "Status"
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.BackgroundImage = Global.Getty2013.My.Resources.Resources._10_device_access_network_cell
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox1.Location = New System.Drawing.Point(8, 17)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(25, 25)
        Me.PictureBox1.TabIndex = 64
        Me.PictureBox1.TabStop = False
        '
        'pnl_hide
        '
        Me.pnl_hide.Controls.Add(Me.pnl_disp_lock)
        Me.pnl_hide.Controls.Add(Me.load_start)
        Me.pnl_hide.Location = New System.Drawing.Point(7, 138)
        Me.pnl_hide.Name = "pnl_hide"
        Me.pnl_hide.Size = New System.Drawing.Size(550, 334)
        Me.pnl_hide.TabIndex = 22
        '
        'pnl_disp_lock
        '
        Me.pnl_disp_lock.Controls.Add(Me.Label7)
        Me.pnl_disp_lock.Controls.Add(Me.PictureBox5)
        Me.pnl_disp_lock.Location = New System.Drawing.Point(140, 89)
        Me.pnl_disp_lock.Name = "pnl_disp_lock"
        Me.pnl_disp_lock.Size = New System.Drawing.Size(272, 116)
        Me.pnl_disp_lock.TabIndex = 2
        Me.pnl_disp_lock.Visible = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Bookman Old Style", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label7.Location = New System.Drawing.Point(94, 52)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(122, 16)
        Me.Label7.TabIndex = 55
        Me.Label7.Text = "Resume to Unlock."
        '
        'PictureBox5
        '
        Me.PictureBox5.BackgroundImage = Global.Getty2013.My.Resources.Resources._10_device_access_secure
        Me.PictureBox5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox5.Location = New System.Drawing.Point(58, 43)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(30, 30)
        Me.PictureBox5.TabIndex = 1
        Me.PictureBox5.TabStop = False
        '
        'load_start
        '
        Me.load_start.BackColor = System.Drawing.Color.Silver
        Me.load_start.Location = New System.Drawing.Point(0, 0)
        Me.load_start.Name = "load_start"
        Me.load_start.Size = New System.Drawing.Size(62, 5)
        Me.load_start.TabIndex = 0
        '
        '__Error
        '
        Me.__Error.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.__Error.ForeColor = System.Drawing.Color.Red
        Me.__Error.Location = New System.Drawing.Point(7, 478)
        Me.__Error.Name = "__Error"
        Me.__Error.Size = New System.Drawing.Size(338, 70)
        Me.__Error.TabIndex = 62
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Bookman Old Style", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(36, 54)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 16)
        Me.Label1.TabIndex = 58
        Me.Label1.Text = "User:"
        '
        'btn_resume
        '
        Me.btn_resume.BackColor = System.Drawing.Color.SandyBrown
        Me.btn_resume.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_resume.Font = New System.Drawing.Font("Bookman Old Style", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_resume.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.btn_resume.Image = Global.Getty2013.My.Resources.Resources._9_av_play
        Me.btn_resume.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_resume.Location = New System.Drawing.Point(454, 478)
        Me.btn_resume.Name = "btn_resume"
        Me.btn_resume.Size = New System.Drawing.Size(100, 30)
        Me.btn_resume.TabIndex = 28
        Me.btn_resume.Text = "    Resume"
        Me.btn_resume.UseVisualStyleBackColor = False
        Me.btn_resume.Visible = False
        '
        'btn_pause
        '
        Me.btn_pause.BackColor = System.Drawing.Color.SandyBrown
        Me.btn_pause.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_pause.Font = New System.Drawing.Font("Bookman Old Style", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_pause.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.btn_pause.Image = Global.Getty2013.My.Resources.Resources._9_av_pause
        Me.btn_pause.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_pause.Location = New System.Drawing.Point(454, 478)
        Me.btn_pause.Name = "btn_pause"
        Me.btn_pause.Size = New System.Drawing.Size(100, 30)
        Me.btn_pause.TabIndex = 23
        Me.btn_pause.Text = "     Pause"
        Me.btn_pause.UseVisualStyleBackColor = False
        Me.btn_pause.Visible = False
        '
        'Panel2
        '
        Me.Panel2.AutoScroll = True
        Me.Panel2.BackColor = System.Drawing.Color.White
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.pnl_blk_disp)
        Me.Panel2.Controls.Add(Me.Label6)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.lbl_from)
        Me.Panel2.Controls.Add(Me.lbl_to)
        Me.Panel2.Controls.Add(Me.lbl_date)
        Me.Panel2.Controls.Add(Me.lbl_title)
        Me.Panel2.Controls.Add(Me.lbl_msg_read)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Location = New System.Drawing.Point(7, 281)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(549, 189)
        Me.Panel2.TabIndex = 8
        '
        'pnl_blk_disp
        '
        Me.pnl_blk_disp.BackColor = System.Drawing.Color.White
        Me.pnl_blk_disp.Location = New System.Drawing.Point(2, 3)
        Me.pnl_blk_disp.Name = "pnl_blk_disp"
        Me.pnl_blk_disp.Size = New System.Drawing.Size(542, 181)
        Me.pnl_blk_disp.TabIndex = 12
        '
        'Label6
        '
        Me.Label6.AccessibleRole = System.Windows.Forms.AccessibleRole.TitleBar
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Bookman Old Style", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.DimGray
        Me.Label6.Location = New System.Drawing.Point(17, 39)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(42, 16)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "From:"
        '
        'Label3
        '
        Me.Label3.AccessibleRole = System.Windows.Forms.AccessibleRole.TitleBar
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Bookman Old Style", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.DimGray
        Me.Label3.Location = New System.Drawing.Point(20, 75)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(26, 16)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "To:"
        '
        'lbl_from
        '
        Me.lbl_from.AccessibleRole = System.Windows.Forms.AccessibleRole.TitleBar
        Me.lbl_from.AutoSize = True
        Me.lbl_from.BackColor = System.Drawing.Color.Transparent
        Me.lbl_from.Font = New System.Drawing.Font("Bookman Old Style", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_from.ForeColor = System.Drawing.Color.Black
        Me.lbl_from.Location = New System.Drawing.Point(66, 38)
        Me.lbl_from.Name = "lbl_from"
        Me.lbl_from.Size = New System.Drawing.Size(38, 16)
        Me.lbl_from.TabIndex = 9
        Me.lbl_from.Text = "From"
        '
        'lbl_to
        '
        Me.lbl_to.AccessibleRole = System.Windows.Forms.AccessibleRole.TitleBar
        Me.lbl_to.AutoSize = True
        Me.lbl_to.BackColor = System.Drawing.Color.Transparent
        Me.lbl_to.Font = New System.Drawing.Font("Bookman Old Style", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_to.ForeColor = System.Drawing.Color.Black
        Me.lbl_to.Location = New System.Drawing.Point(67, 73)
        Me.lbl_to.Name = "lbl_to"
        Me.lbl_to.Size = New System.Drawing.Size(22, 16)
        Me.lbl_to.TabIndex = 8
        Me.lbl_to.Text = "To"
        '
        'lbl_date
        '
        Me.lbl_date.AccessibleRole = System.Windows.Forms.AccessibleRole.TitleBar
        Me.lbl_date.AutoSize = True
        Me.lbl_date.BackColor = System.Drawing.Color.Transparent
        Me.lbl_date.Font = New System.Drawing.Font("Bookman Old Style", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_date.ForeColor = System.Drawing.Color.Black
        Me.lbl_date.Location = New System.Drawing.Point(68, 56)
        Me.lbl_date.Name = "lbl_date"
        Me.lbl_date.Size = New System.Drawing.Size(34, 16)
        Me.lbl_date.TabIndex = 7
        Me.lbl_date.Text = "date"
        '
        'lbl_title
        '
        Me.lbl_title.AccessibleRole = System.Windows.Forms.AccessibleRole.TitleBar
        Me.lbl_title.AutoSize = True
        Me.lbl_title.BackColor = System.Drawing.Color.Transparent
        Me.lbl_title.Font = New System.Drawing.Font("Bookman Old Style", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_title.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lbl_title.Location = New System.Drawing.Point(16, 15)
        Me.lbl_title.Name = "lbl_title"
        Me.lbl_title.Size = New System.Drawing.Size(35, 18)
        Me.lbl_title.TabIndex = 6
        Me.lbl_title.Text = "title"
        '
        'lbl_msg_read
        '
        Me.lbl_msg_read.AutoSize = True
        Me.lbl_msg_read.BackColor = System.Drawing.Color.Transparent
        Me.lbl_msg_read.Font = New System.Drawing.Font("Bookman Old Style", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_msg_read.Location = New System.Drawing.Point(19, 106)
        Me.lbl_msg_read.Name = "lbl_msg_read"
        Me.lbl_msg_read.Size = New System.Drawing.Size(60, 16)
        Me.lbl_msg_read.TabIndex = 5
        Me.lbl_msg_read.Text = "message"
        '
        'Label2
        '
        Me.Label2.AccessibleRole = System.Windows.Forms.AccessibleRole.TitleBar
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Bookman Old Style", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.DimGray
        Me.Label2.Location = New System.Drawing.Point(18, 56)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(40, 16)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "Sent:"
        '
        'btn_profile
        '
        Me.btn_profile.BackColor = System.Drawing.Color.DodgerBlue
        Me.btn_profile.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_profile.Font = New System.Drawing.Font("Bookman Old Style", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_profile.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.btn_profile.Image = Global.Getty2013.My.Resources.Resources._6_social_person3
        Me.btn_profile.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_profile.Location = New System.Drawing.Point(351, 478)
        Me.btn_profile.Name = "btn_profile"
        Me.btn_profile.Size = New System.Drawing.Size(100, 30)
        Me.btn_profile.TabIndex = 54
        Me.btn_profile.Text = "      Profile"
        Me.btn_profile.UseVisualStyleBackColor = False
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox2.BackgroundImage = Global.Getty2013.My.Resources.Resources._6_social_person1
        Me.PictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox2.Location = New System.Drawing.Point(8, 47)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(25, 25)
        Me.PictureBox2.TabIndex = 15
        Me.PictureBox2.TabStop = False
        '
        'lbl_wait
        '
        Me.lbl_wait.AutoSize = True
        Me.lbl_wait.Font = New System.Drawing.Font("Bookman Old Style", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_wait.Location = New System.Drawing.Point(218, 203)
        Me.lbl_wait.Name = "lbl_wait"
        Me.lbl_wait.Size = New System.Drawing.Size(133, 16)
        Me.lbl_wait.TabIndex = 63
        Me.lbl_wait.Text = "Loading messages ..."
        '
        'lv_inbox
        '
        Me.lv_inbox.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lv_inbox.Location = New System.Drawing.Point(7, 139)
        Me.lv_inbox.Name = "lv_inbox"
        Me.lv_inbox.Size = New System.Drawing.Size(549, 137)
        Me.lv_inbox.TabIndex = 9
        Me.lv_inbox.UseCompatibleStateImageBehavior = False
        '
        '__Center
        '
        Me.__Center.BackColor = System.Drawing.Color.Transparent
        Me.__Center.Font = New System.Drawing.Font("Bookman Old Style", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.__Center.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.__Center.Location = New System.Drawing.Point(378, 9)
        Me.__Center.Name = "__Center"
        Me.__Center.Size = New System.Drawing.Size(41, 20)
        Me.__Center.TabIndex = 60
        Me.__Center.Text = "Label8"
        Me.__Center.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.__Center.Visible = False
        '
        'updateInbox
        '
        Me.updateInbox.Interval = 90000
        '
        'timeStampOL
        '
        Me.timeStampOL.Interval = 60000
        '
        'PictureBox7
        '
        Me.PictureBox7.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox7.BackgroundImage = Global.Getty2013.My.Resources.Resources._6_social_group1
        Me.PictureBox7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox7.Location = New System.Drawing.Point(115, 5)
        Me.PictureBox7.Name = "PictureBox7"
        Me.PictureBox7.Size = New System.Drawing.Size(27, 28)
        Me.PictureBox7.TabIndex = 58
        Me.PictureBox7.TabStop = False
        '
        'pnl_exit
        '
        Me.pnl_exit.BackColor = System.Drawing.Color.Transparent
        Me.pnl_exit.BackgroundImage = Global.Getty2013.My.Resources.Resources._1_navigation_cancel3
        Me.pnl_exit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pnl_exit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pnl_exit.Location = New System.Drawing.Point(534, 9)
        Me.pnl_exit.Name = "pnl_exit"
        Me.pnl_exit.Size = New System.Drawing.Size(20, 20)
        Me.pnl_exit.TabIndex = 27
        '
        'GettyTime
        '
        Me.GettyTime.Interval = 1000
        '
        'logsChecker
        '
        Me.logsChecker.Interval = 60000
        '
        'extractHistory
        '
        Me.extractHistory.Interval = 100000
        '
        'pb_sysinfo
        '
        Me.pb_sysinfo.BackColor = System.Drawing.Color.Transparent
        Me.pb_sysinfo.BackgroundImage = Global.Getty2013.My.Resources.Resources.ver
        Me.pb_sysinfo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pb_sysinfo.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pb_sysinfo.Location = New System.Drawing.Point(508, 9)
        Me.pb_sysinfo.Name = "pb_sysinfo"
        Me.pb_sysinfo.Size = New System.Drawing.Size(20, 20)
        Me.pb_sysinfo.TabIndex = 72
        Me.pb_sysinfo.TabStop = False
        '
        'frmMessages
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.IndianRed
        Me.BackgroundImage = Global.Getty2013.My.Resources.Resources.bgblack
        Me.ClientSize = New System.Drawing.Size(563, 594)
        Me.Controls.Add(Me.pb_sysinfo)
        Me.Controls.Add(Me.Panel7)
        Me.Controls.Add(Me.PictureBox7)
        Me.Controls.Add(Me.pnl_exit)
        Me.Controls.Add(Me.lbl_campaign)
        Me.Controls.Add(Me.__Center)
        Me.Controls.Add(Me.lbl_img_title)
        Me.Controls.Add(Me.pnl_minimize)
        Me.Controls.Add(Me.Panel6)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Label4)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmMessages"
        Me.Opacity = 0.0R
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = " Messages"
        Me.Panel3.ResumeLayout(False)
        Me.pnl_minimize.ResumeLayout(False)
        Me.MenuStrip.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnl_hide.ResumeLayout(False)
        Me.pnl_disp_lock.ResumeLayout(False)
        Me.pnl_disp_lock.PerformLayout()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pb_sysinfo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents fadeIn As System.Windows.Forms.Timer
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lbl_user_id As System.Windows.Forms.Label
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Friend WithEvents Panel7 As System.Windows.Forms.Panel
    Friend WithEvents Panel8 As System.Windows.Forms.Panel
    Friend WithEvents load As System.Windows.Forms.Timer
    Friend WithEvents lbl_campaign As System.Windows.Forms.Label
    Friend WithEvents pnl_minimize As System.Windows.Forms.Panel
    Friend WithEvents Panel10 As System.Windows.Forms.Panel
    Friend WithEvents TrayIcon As System.Windows.Forms.NotifyIcon
    Friend WithEvents updatingTime As System.Windows.Forms.Timer
    Friend WithEvents lbl_img_title As System.Windows.Forms.Label
    Friend WithEvents btn_resume As System.Windows.Forms.Button
    Friend WithEvents OpenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuStrip As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents btn_pause As System.Windows.Forms.Button
    Friend WithEvents checkSchedule As System.Windows.Forms.Timer
    Friend WithEvents shutdownCount As System.Windows.Forms.Timer
    Friend WithEvents pnl_exit As System.Windows.Forms.Panel
    Friend WithEvents btn_profile As System.Windows.Forms.Button
    Friend WithEvents localStamp As System.Windows.Forms.Timer
    Friend WithEvents PictureBox7 As System.Windows.Forms.PictureBox
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents pnl_hide As System.Windows.Forms.Panel
    Friend WithEvents pnl_disp_lock As System.Windows.Forms.Panel
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents PictureBox5 As System.Windows.Forms.PictureBox
    Friend WithEvents load_start As System.Windows.Forms.Panel
    Friend WithEvents lv_inbox As System.Windows.Forms.ListView
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents pnl_blk_disp As System.Windows.Forms.Panel
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lbl_from As System.Windows.Forms.Label
    Friend WithEvents lbl_to As System.Windows.Forms.Label
    Friend WithEvents lbl_date As System.Windows.Forms.Label
    Friend WithEvents lbl_title As System.Windows.Forms.Label
    Friend WithEvents lbl_msg_read As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents __Center As System.Windows.Forms.Label
    Friend WithEvents __Error As System.Windows.Forms.Label
    Friend WithEvents updateInbox As System.Windows.Forms.Timer
    Friend WithEvents lbl_wait As System.Windows.Forms.Label
    Friend WithEvents timeStampOL As System.Windows.Forms.Timer
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents __Status As System.Windows.Forms.Label
    Friend WithEvents GettyTime As System.Windows.Forms.Timer
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents lbl_show_time As System.Windows.Forms.Label
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents logsChecker As System.Windows.Forms.Timer
    Friend WithEvents extractHistory As System.Windows.Forms.Timer
    Friend WithEvents pb_sysinfo As System.Windows.Forms.PictureBox
End Class
