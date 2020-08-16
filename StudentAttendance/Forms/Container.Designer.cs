namespace StudentAttendance.Forms
{
    partial class Container
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Drawing.Drawing2D.GraphicsPath graphicsPath1 = new System.Drawing.Drawing2D.GraphicsPath();
            System.Drawing.Drawing2D.GraphicsPath graphicsPath3 = new System.Drawing.Drawing2D.GraphicsPath();
            System.Drawing.Drawing2D.GraphicsPath graphicsPath2 = new System.Drawing.Drawing2D.GraphicsPath();
            System.Drawing.Drawing2D.GraphicsPath graphicsPath4 = new System.Drawing.Drawing2D.GraphicsPath();
            this.actionBar = new MaterialWinforms.Controls.MaterialActionBar();
            this.materialActionBarButton1 = new MaterialWinforms.Controls.MaterialActionBarButton();
            this.materialActionBarButton2 = new MaterialWinforms.Controls.MaterialActionBarButton();
            this.pnlUser = new MaterialWinforms.Controls.MaterialPanel();
            this.cardMenu = new MaterialWinforms.Controls.MaterialCard();
            this.btnDashboard = new MaterialWinforms.Controls.MaterialFlatButton();
            this.btnLogout = new MaterialWinforms.Controls.MaterialFlatButton();
            this.materialDivider2 = new MaterialWinforms.Controls.MaterialDivider();
            this.lblAdmin = new MaterialWinforms.Controls.MaterialLabel();
            this.btnAttendance = new MaterialWinforms.Controls.MaterialFlatButton();
            this.btnReport = new MaterialWinforms.Controls.MaterialFlatButton();
            this.btnSettings = new MaterialWinforms.Controls.MaterialFlatButton();
            this.btnDept = new MaterialWinforms.Controls.MaterialFlatButton();
            this.btnUserMgt = new MaterialWinforms.Controls.MaterialFlatButton();
            this.btnCourseMgt = new MaterialWinforms.Controls.MaterialFlatButton();
            this.btnSemester = new MaterialWinforms.Controls.MaterialFlatButton();
            this.lblFullname = new MaterialWinforms.Controls.MaterialLabel();
            this.materialDivider1 = new MaterialWinforms.Controls.MaterialDivider();
            this.avatarUser = new MaterialWinforms.Controls.MaterialAvatarView();
            this.subMenuCourse = new MaterialWinforms.Controls.MaterialContextMenuStrip();
            this.mniCourse = new System.Windows.Forms.ToolStripMenuItem();
            this.mniCourseReg = new System.Windows.Forms.ToolStripMenuItem();
            this.mniCourseLec = new System.Windows.Forms.ToolStripMenuItem();
            this.subMenuUser = new MaterialWinforms.Controls.MaterialContextMenuStrip();
            this.mniStudent = new System.Windows.Forms.ToolStripMenuItem();
            this.mniStaff = new System.Windows.Forms.ToolStripMenuItem();
            this.cardMain = new MaterialWinforms.Controls.MaterialCard();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.actionBar.SuspendLayout();
            this.cardMenu.SuspendLayout();
            this.subMenuCourse.SuspendLayout();
            this.subMenuUser.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // actionBar
            // 
            this.actionBar.ActionBarButtons.Add(this.materialActionBarButton1);
            this.actionBar.ActionBarButtons.Add(this.materialActionBarButton2);
            this.actionBar.ActionBarMenu = null;
            this.actionBar.Controls.Add(this.materialActionBarButton1);
            this.actionBar.Controls.Add(this.materialActionBarButton2);
            this.actionBar.Depth = 0;
            this.actionBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.actionBar.Elevation = 10;
            this.actionBar.IntegratedSearchBar = false;
            this.actionBar.Location = new System.Drawing.Point(0, 24);
            this.actionBar.MouseState = MaterialWinforms.MouseState.HOVER;
            this.actionBar.Name = "actionBar";
            this.actionBar.SearchBarFilterIcon = true;
            graphicsPath1.FillMode = System.Drawing.Drawing2D.FillMode.Alternate;
            this.actionBar.ShadowBorder = graphicsPath1;
            this.actionBar.Size = new System.Drawing.Size(1341, 42);
            this.actionBar.TabIndex = 2;
            // 
            // materialActionBarButton1
            // 
            this.materialActionBarButton1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialActionBarButton1.Depth = 0;
            this.materialActionBarButton1.Image = null;
            this.materialActionBarButton1.Location = new System.Drawing.Point(1252, 0);
            this.materialActionBarButton1.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialActionBarButton1.MouseState = MaterialWinforms.MouseState.HOVER;
            this.materialActionBarButton1.Name = "materialActionBarButton1";
            this.materialActionBarButton1.Size = new System.Drawing.Size(42, 42);
            this.materialActionBarButton1.TabIndex = 0;
            this.materialActionBarButton1.Text = "materialActionBarButton1";
            // 
            // materialActionBarButton2
            // 
            this.materialActionBarButton2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialActionBarButton2.Depth = 0;
            this.materialActionBarButton2.Image = null;
            this.materialActionBarButton2.Location = new System.Drawing.Point(1294, 0);
            this.materialActionBarButton2.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialActionBarButton2.MouseState = MaterialWinforms.MouseState.HOVER;
            this.materialActionBarButton2.Name = "materialActionBarButton2";
            this.materialActionBarButton2.Size = new System.Drawing.Size(42, 42);
            this.materialActionBarButton2.TabIndex = 0;
            this.materialActionBarButton2.Text = "materialActionBarButton2";
            // 
            // pnlUser
            // 
            this.pnlUser.AutoScroll = true;
            this.pnlUser.Depth = 0;
            this.pnlUser.Location = new System.Drawing.Point(3, 3);
            this.pnlUser.MouseState = MaterialWinforms.MouseState.HOVER;
            this.pnlUser.Name = "pnlUser";
            this.pnlUser.Size = new System.Drawing.Size(197, 168);
            this.pnlUser.TabIndex = 0;
            // 
            // cardMenu
            // 
            this.cardMenu.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cardMenu.Controls.Add(this.btnDashboard);
            this.cardMenu.Controls.Add(this.btnLogout);
            this.cardMenu.Controls.Add(this.materialDivider2);
            this.cardMenu.Controls.Add(this.lblAdmin);
            this.cardMenu.Controls.Add(this.btnAttendance);
            this.cardMenu.Controls.Add(this.btnReport);
            this.cardMenu.Controls.Add(this.btnSettings);
            this.cardMenu.Controls.Add(this.btnDept);
            this.cardMenu.Controls.Add(this.btnUserMgt);
            this.cardMenu.Controls.Add(this.btnCourseMgt);
            this.cardMenu.Controls.Add(this.btnSemester);
            this.cardMenu.Controls.Add(this.lblFullname);
            this.cardMenu.Controls.Add(this.materialDivider1);
            this.cardMenu.Controls.Add(this.avatarUser);
            this.cardMenu.Depth = 0;
            this.cardMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cardMenu.Elevation = 5;
            this.cardMenu.LargeTitle = false;
            this.cardMenu.Location = new System.Drawing.Point(20, 20);
            this.cardMenu.Margin = new System.Windows.Forms.Padding(20);
            this.cardMenu.MouseState = MaterialWinforms.MouseState.HOVER;
            this.cardMenu.Name = "cardMenu";
            this.cardMenu.Padding = new System.Windows.Forms.Padding(5, 25, 5, 5);
            graphicsPath3.FillMode = System.Drawing.Drawing2D.FillMode.Alternate;
            this.cardMenu.ShadowBorder = graphicsPath3;
            this.cardMenu.Size = new System.Drawing.Size(295, 790);
            this.cardMenu.TabIndex = 0;
            this.cardMenu.Title = "";
            // 
            // btnDashboard
            // 
            this.btnDashboard.Accent = false;
            this.btnDashboard.AutoSize = true;
            this.btnDashboard.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnDashboard.Capitalized = true;
            this.btnDashboard.Depth = 0;
            this.btnDashboard.IconImage = global::StudentAttendance.Properties.Resources.dashboard;
            this.btnDashboard.Image = global::StudentAttendance.Properties.Resources.dashboard;
            this.btnDashboard.Location = new System.Drawing.Point(41, 184);
            this.btnDashboard.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnDashboard.MouseState = MaterialWinforms.MouseState.HOVER;
            this.btnDashboard.Name = "btnDashboard";
            this.btnDashboard.Primary = false;
            this.btnDashboard.Selected = false;
            this.btnDashboard.Size = new System.Drawing.Size(98, 36);
            this.btnDashboard.TabIndex = 14;
            this.btnDashboard.Text = "Home";
            this.btnDashboard.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDashboard.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDashboard.UseVisualStyleBackColor = true;
            this.btnDashboard.Click += new System.EventHandler(this.btnDashboard_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.Accent = false;
            this.btnLogout.AutoSize = true;
            this.btnLogout.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnLogout.Capitalized = true;
            this.btnLogout.Depth = 0;
            this.btnLogout.IconImage = global::StudentAttendance.Properties.Resources.signout;
            this.btnLogout.Image = global::StudentAttendance.Properties.Resources.signout;
            this.btnLogout.Location = new System.Drawing.Point(143, 700);
            this.btnLogout.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnLogout.MouseState = MaterialWinforms.MouseState.HOVER;
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Primary = false;
            this.btnLogout.Selected = false;
            this.btnLogout.Size = new System.Drawing.Size(120, 36);
            this.btnLogout.TabIndex = 9;
            this.btnLogout.Text = "Log out";
            this.btnLogout.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLogout.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // materialDivider2
            // 
            this.materialDivider2.Depth = 0;
            this.materialDivider2.Location = new System.Drawing.Point(14, 690);
            this.materialDivider2.MouseState = MaterialWinforms.MouseState.HOVER;
            this.materialDivider2.Name = "materialDivider2";
            this.materialDivider2.Size = new System.Drawing.Size(327, 1);
            this.materialDivider2.TabIndex = 13;
            this.materialDivider2.Text = "materialDivider2";
            // 
            // lblAdmin
            // 
            this.lblAdmin.AutoSize = true;
            this.lblAdmin.Depth = 0;
            this.lblAdmin.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblAdmin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.lblAdmin.Location = new System.Drawing.Point(139, 71);
            this.lblAdmin.MouseState = MaterialWinforms.MouseState.HOVER;
            this.lblAdmin.Name = "lblAdmin";
            this.lblAdmin.Size = new System.Drawing.Size(65, 24);
            this.lblAdmin.TabIndex = 0;
            this.lblAdmin.Text = "Admin";
            // 
            // btnAttendance
            // 
            this.btnAttendance.Accent = false;
            this.btnAttendance.AutoSize = true;
            this.btnAttendance.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnAttendance.Capitalized = true;
            this.btnAttendance.Depth = 0;
            this.btnAttendance.IconImage = global::StudentAttendance.Properties.Resources.calendar_check;
            this.btnAttendance.Image = global::StudentAttendance.Properties.Resources.calendar_check;
            this.btnAttendance.Location = new System.Drawing.Point(41, 554);
            this.btnAttendance.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnAttendance.MouseState = MaterialWinforms.MouseState.HOVER;
            this.btnAttendance.Name = "btnAttendance";
            this.btnAttendance.Primary = false;
            this.btnAttendance.Selected = false;
            this.btnAttendance.Size = new System.Drawing.Size(206, 36);
            this.btnAttendance.TabIndex = 8;
            this.btnAttendance.Text = "Take Attendance";
            this.btnAttendance.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAttendance.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAttendance.UseVisualStyleBackColor = true;
            this.btnAttendance.Click += new System.EventHandler(this.btnAttendance_Click);
            // 
            // btnReport
            // 
            this.btnReport.Accent = false;
            this.btnReport.AutoSize = true;
            this.btnReport.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnReport.Capitalized = true;
            this.btnReport.Depth = 0;
            this.btnReport.IconImage = global::StudentAttendance.Properties.Resources.pie_report;
            this.btnReport.Image = global::StudentAttendance.Properties.Resources.pie_report;
            this.btnReport.Location = new System.Drawing.Point(41, 498);
            this.btnReport.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnReport.MouseState = MaterialWinforms.MouseState.HOVER;
            this.btnReport.Name = "btnReport";
            this.btnReport.Primary = false;
            this.btnReport.Selected = false;
            this.btnReport.Size = new System.Drawing.Size(113, 36);
            this.btnReport.TabIndex = 7;
            this.btnReport.Text = "Report";
            this.btnReport.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnReport.UseVisualStyleBackColor = true;
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // btnSettings
            // 
            this.btnSettings.Accent = false;
            this.btnSettings.AutoSize = true;
            this.btnSettings.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnSettings.Capitalized = true;
            this.btnSettings.Depth = 0;
            this.btnSettings.IconImage = global::StudentAttendance.Properties.Resources.cogs;
            this.btnSettings.Image = global::StudentAttendance.Properties.Resources.cogs;
            this.btnSettings.Location = new System.Drawing.Point(41, 442);
            this.btnSettings.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnSettings.MouseState = MaterialWinforms.MouseState.HOVER;
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Primary = false;
            this.btnSettings.Selected = false;
            this.btnSettings.Size = new System.Drawing.Size(129, 36);
            this.btnSettings.TabIndex = 6;
            this.btnSettings.Text = "Settings";
            this.btnSettings.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSettings.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSettings.UseVisualStyleBackColor = true;
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // btnDept
            // 
            this.btnDept.Accent = false;
            this.btnDept.AutoSize = true;
            this.btnDept.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnDept.Capitalized = true;
            this.btnDept.Depth = 0;
            this.btnDept.IconImage = global::StudentAttendance.Properties.Resources.school;
            this.btnDept.Image = global::StudentAttendance.Properties.Resources.school;
            this.btnDept.Location = new System.Drawing.Point(41, 238);
            this.btnDept.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnDept.MouseState = MaterialWinforms.MouseState.HOVER;
            this.btnDept.Name = "btnDept";
            this.btnDept.Primary = false;
            this.btnDept.Selected = false;
            this.btnDept.Size = new System.Drawing.Size(161, 36);
            this.btnDept.TabIndex = 2;
            this.btnDept.Text = "Department";
            this.btnDept.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDept.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDept.UseVisualStyleBackColor = true;
            this.btnDept.Click += new System.EventHandler(this.btnDept_Click);
            // 
            // btnUserMgt
            // 
            this.btnUserMgt.Accent = false;
            this.btnUserMgt.AutoSize = true;
            this.btnUserMgt.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnUserMgt.Capitalized = true;
            this.btnUserMgt.Depth = 0;
            this.btnUserMgt.IconImage = global::StudentAttendance.Properties.Resources.user;
            this.btnUserMgt.Image = global::StudentAttendance.Properties.Resources.user;
            this.btnUserMgt.Location = new System.Drawing.Point(41, 390);
            this.btnUserMgt.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnUserMgt.MouseState = MaterialWinforms.MouseState.HOVER;
            this.btnUserMgt.Name = "btnUserMgt";
            this.btnUserMgt.Primary = false;
            this.btnUserMgt.Selected = false;
            this.btnUserMgt.Size = new System.Drawing.Size(214, 36);
            this.btnUserMgt.TabIndex = 5;
            this.btnUserMgt.Text = "User Management";
            this.btnUserMgt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUserMgt.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnUserMgt.UseVisualStyleBackColor = true;
            this.btnUserMgt.Click += new System.EventHandler(this.btnUserMgt_Click);
            this.btnUserMgt.MouseHover += new System.EventHandler(this.btnUserMgt_MouseHover);
            // 
            // btnCourseMgt
            // 
            this.btnCourseMgt.Accent = false;
            this.btnCourseMgt.AutoSize = true;
            this.btnCourseMgt.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnCourseMgt.Capitalized = true;
            this.btnCourseMgt.Depth = 0;
            this.btnCourseMgt.IconImage = global::StudentAttendance.Properties.Resources.book;
            this.btnCourseMgt.Image = global::StudentAttendance.Properties.Resources.book;
            this.btnCourseMgt.Location = new System.Drawing.Point(41, 340);
            this.btnCourseMgt.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnCourseMgt.MouseState = MaterialWinforms.MouseState.HOVER;
            this.btnCourseMgt.Name = "btnCourseMgt";
            this.btnCourseMgt.Primary = false;
            this.btnCourseMgt.Selected = false;
            this.btnCourseMgt.Size = new System.Drawing.Size(237, 36);
            this.btnCourseMgt.TabIndex = 4;
            this.btnCourseMgt.Text = "Course Management";
            this.btnCourseMgt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCourseMgt.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCourseMgt.UseVisualStyleBackColor = true;
            this.btnCourseMgt.Click += new System.EventHandler(this.btnCourseMgt_Click);
            this.btnCourseMgt.MouseHover += new System.EventHandler(this.btnCourseMgt_MouseHover);
            // 
            // btnSemester
            // 
            this.btnSemester.Accent = false;
            this.btnSemester.AutoSize = true;
            this.btnSemester.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnSemester.Capitalized = true;
            this.btnSemester.Depth = 0;
            this.btnSemester.IconImage = global::StudentAttendance.Properties.Resources.folder;
            this.btnSemester.Image = global::StudentAttendance.Properties.Resources.folder;
            this.btnSemester.Location = new System.Drawing.Point(41, 291);
            this.btnSemester.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnSemester.MouseState = MaterialWinforms.MouseState.HOVER;
            this.btnSemester.Name = "btnSemester";
            this.btnSemester.Primary = false;
            this.btnSemester.Selected = false;
            this.btnSemester.Size = new System.Drawing.Size(212, 36);
            this.btnSemester.TabIndex = 3;
            this.btnSemester.Text = "Session/Semester";
            this.btnSemester.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSemester.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSemester.UseVisualStyleBackColor = true;
            this.btnSemester.Click += new System.EventHandler(this.btnSemester_Click);
            // 
            // lblFullname
            // 
            this.lblFullname.AutoSize = true;
            this.lblFullname.Depth = 0;
            this.lblFullname.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblFullname.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.lblFullname.Location = new System.Drawing.Point(139, 27);
            this.lblFullname.MouseState = MaterialWinforms.MouseState.HOVER;
            this.lblFullname.Name = "lblFullname";
            this.lblFullname.Size = new System.Drawing.Size(88, 24);
            this.lblFullname.TabIndex = 0;
            this.lblFullname.Text = "Fullname";
            // 
            // materialDivider1
            // 
            this.materialDivider1.Depth = 0;
            this.materialDivider1.Location = new System.Drawing.Point(19, 135);
            this.materialDivider1.MouseState = MaterialWinforms.MouseState.HOVER;
            this.materialDivider1.Name = "materialDivider1";
            this.materialDivider1.Size = new System.Drawing.Size(322, 1);
            this.materialDivider1.TabIndex = 1;
            this.materialDivider1.Text = "materialDivider1";
            // 
            // avatarUser
            // 
            this.avatarUser.Avatar = global::StudentAttendance.Properties.Resources.maleuser;
            this.avatarUser.AvatarLetter = null;
            this.avatarUser.Depth = 0;
            this.avatarUser.Elevation = 5;
            this.avatarUser.Location = new System.Drawing.Point(18, 12);
            this.avatarUser.MouseState = MaterialWinforms.MouseState.HOVER;
            this.avatarUser.Name = "avatarUser";
            graphicsPath2.FillMode = System.Drawing.Drawing2D.FillMode.Alternate;
            this.avatarUser.ShadowBorder = graphicsPath2;
            this.avatarUser.Size = new System.Drawing.Size(101, 101);
            this.avatarUser.TabIndex = 0;
            // 
            // subMenuCourse
            // 
            this.subMenuCourse.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.subMenuCourse.Depth = 0;
            this.subMenuCourse.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.subMenuCourse.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mniCourse,
            this.mniCourseReg,
            this.mniCourseLec});
            this.subMenuCourse.MouseState = MaterialWinforms.MouseState.HOVER;
            this.subMenuCourse.Name = "materialContextMenuStrip1";
            this.subMenuCourse.Size = new System.Drawing.Size(208, 76);
            this.subMenuCourse.MouseLeave += new System.EventHandler(this.subMenuCourse_MouseLeave);
            // 
            // mniCourse
            // 
            this.mniCourse.BackColor = System.Drawing.Color.White;
            this.mniCourse.Name = "mniCourse";
            this.mniCourse.Size = new System.Drawing.Size(207, 24);
            this.mniCourse.Text = "Course";
            this.mniCourse.Click += new System.EventHandler(this.mniCourse_Click);
            // 
            // mniCourseReg
            // 
            this.mniCourseReg.BackColor = System.Drawing.Color.White;
            this.mniCourseReg.Name = "mniCourseReg";
            this.mniCourseReg.Size = new System.Drawing.Size(207, 24);
            this.mniCourseReg.Text = "Course Registration";
            this.mniCourseReg.Click += new System.EventHandler(this.mniCourseReg_Click);
            // 
            // mniCourseLec
            // 
            this.mniCourseLec.BackColor = System.Drawing.Color.White;
            this.mniCourseLec.Name = "mniCourseLec";
            this.mniCourseLec.Size = new System.Drawing.Size(207, 24);
            this.mniCourseLec.Text = "Lecturer\'s Courses";
            this.mniCourseLec.Click += new System.EventHandler(this.mniCourseLec_Click);
            // 
            // subMenuUser
            // 
            this.subMenuUser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.subMenuUser.Depth = 0;
            this.subMenuUser.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.subMenuUser.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mniStudent,
            this.mniStaff});
            this.subMenuUser.MouseState = MaterialWinforms.MouseState.HOVER;
            this.subMenuUser.Name = "materialContextMenuStrip1";
            this.subMenuUser.Size = new System.Drawing.Size(136, 52);
            this.subMenuUser.MouseLeave += new System.EventHandler(this.subMenuUser_MouseLeave);
            // 
            // mniStudent
            // 
            this.mniStudent.BackColor = System.Drawing.Color.White;
            this.mniStudent.Name = "mniStudent";
            this.mniStudent.Size = new System.Drawing.Size(135, 24);
            this.mniStudent.Text = "Students";
            this.mniStudent.Click += new System.EventHandler(this.mniStudent_Click);
            // 
            // mniStaff
            // 
            this.mniStaff.BackColor = System.Drawing.Color.White;
            this.mniStaff.Name = "mniStaff";
            this.mniStaff.Size = new System.Drawing.Size(135, 24);
            this.mniStaff.Text = "Staff";
            this.mniStaff.Click += new System.EventHandler(this.mniStaff_Click);
            // 
            // cardMain
            // 
            this.cardMain.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cardMain.Depth = 0;
            this.cardMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cardMain.Elevation = 5;
            this.cardMain.LargeTitle = false;
            this.cardMain.Location = new System.Drawing.Point(395, 20);
            this.cardMain.Margin = new System.Windows.Forms.Padding(20);
            this.cardMain.MouseState = MaterialWinforms.MouseState.HOVER;
            this.cardMain.Name = "cardMain";
            this.cardMain.Padding = new System.Windows.Forms.Padding(5, 25, 5, 5);
            graphicsPath4.FillMode = System.Drawing.Drawing2D.FillMode.Alternate;
            this.cardMain.ShadowBorder = graphicsPath4;
            this.cardMain.Size = new System.Drawing.Size(926, 790);
            this.cardMain.TabIndex = 3;
            this.cardMain.Title = null;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 3F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 72F));
            this.tableLayoutPanel1.Controls.Add(this.cardMenu, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.cardMain, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 66);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1341, 830);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(338, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(34, 824);
            this.panel1.TabIndex = 4;
            // 
            // Container
            // 
            this.ActionBar = this.actionBar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1341, 896);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.actionBar);
            this.Name = "Container";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Student Attendance System";
            this.Load += new System.EventHandler(this.Container_Load);
            this.SizeChanged += new System.EventHandler(this.Container_SizeChanged);
            this.actionBar.ResumeLayout(false);
            this.cardMenu.ResumeLayout(false);
            this.cardMenu.PerformLayout();
            this.subMenuCourse.ResumeLayout(false);
            this.subMenuUser.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private MaterialWinforms.Controls.MaterialActionBar actionBar;
        private MaterialWinforms.Controls.MaterialPanel pnlUser;
        private MaterialWinforms.Controls.MaterialActionBarButton materialActionBarButton1;
        private MaterialWinforms.Controls.MaterialActionBarButton materialActionBarButton2;
        private MaterialWinforms.Controls.MaterialCard cardMenu;
        private MaterialWinforms.Controls.MaterialFlatButton btnDept;
        private MaterialWinforms.Controls.MaterialFlatButton btnUserMgt;
        private MaterialWinforms.Controls.MaterialFlatButton btnCourseMgt;
        private MaterialWinforms.Controls.MaterialFlatButton btnSemester;
        private MaterialWinforms.Controls.MaterialLabel lblFullname;
        private MaterialWinforms.Controls.MaterialDivider materialDivider1;
        private MaterialWinforms.Controls.MaterialAvatarView avatarUser;
        private MaterialWinforms.Controls.MaterialFlatButton btnAttendance;
        private MaterialWinforms.Controls.MaterialFlatButton btnReport;
        private MaterialWinforms.Controls.MaterialFlatButton btnSettings;
        private MaterialWinforms.Controls.MaterialContextMenuStrip subMenuCourse;
        private System.Windows.Forms.ToolStripMenuItem mniCourse;
        private System.Windows.Forms.ToolStripMenuItem mniCourseReg;
        private System.Windows.Forms.ToolStripMenuItem mniCourseLec;
        private MaterialWinforms.Controls.MaterialContextMenuStrip subMenuUser;
        private System.Windows.Forms.ToolStripMenuItem mniStudent;
        private System.Windows.Forms.ToolStripMenuItem mniStaff;
        private MaterialWinforms.Controls.MaterialLabel lblAdmin;
        private MaterialWinforms.Controls.MaterialFlatButton btnLogout;
        private MaterialWinforms.Controls.MaterialDivider materialDivider2;
        private MaterialWinforms.Controls.MaterialCard cardMain;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private MaterialWinforms.Controls.MaterialFlatButton btnDashboard;
    }
}