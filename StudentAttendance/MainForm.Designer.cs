namespace StudentAttendance
{
    partial class MainForm
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
            System.Drawing.Drawing2D.GraphicsPath graphicsPath4 = new System.Drawing.Drawing2D.GraphicsPath();
            System.Drawing.Drawing2D.GraphicsPath graphicsPath1 = new System.Drawing.Drawing2D.GraphicsPath();
            System.Drawing.Drawing2D.GraphicsPath graphicsPath2 = new System.Drawing.Drawing2D.GraphicsPath();
            this.SideDrawerList = new MaterialWinforms.Controls.MaterialContextMenuStrip();
            this.menuItemHome = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemDept = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemSession = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemCourse = new MaterialWinforms.Controls.MaterialToolStripMenuItem();
            this.subMenuCourse = new MaterialWinforms.Controls.MaterialToolStripMenuItem();
            this.subMenuCourseReg = new MaterialWinforms.Controls.MaterialToolStripMenuItem();
            this.subMenuLecturerCourse = new MaterialWinforms.Controls.MaterialToolStripMenuItem();
            this.menuItemUser = new MaterialWinforms.Controls.MaterialToolStripMenuItem();
            this.subMenuLecturer = new System.Windows.Forms.ToolStripMenuItem();
            this.subMenuStudent = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemReport = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemAttendance = new System.Windows.Forms.ToolStripMenuItem();
            this.actionBar = new MaterialWinforms.Controls.MaterialActionBar();
            this.materialActionBarButton1 = new MaterialWinforms.Controls.MaterialActionBarButton();
            this.materialActionBarButton2 = new MaterialWinforms.Controls.MaterialActionBarButton();
            this.sideMenu = new MaterialWinforms.Controls.MaterialSideDrawer();
            this.pnlUser = new MaterialWinforms.Controls.MaterialPanel();
            this.pnlMain = new MaterialWinforms.Controls.MaterialPanel();
            this.materialCard1 = new MaterialWinforms.Controls.MaterialCard();
            this.SideDrawerList.SuspendLayout();
            this.actionBar.SuspendLayout();
            this.pnlMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // SideDrawerList
            // 
            this.SideDrawerList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.SideDrawerList.Depth = 0;
            this.SideDrawerList.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.SideDrawerList.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemHome,
            this.menuItemDept,
            this.menuItemSession,
            this.menuItemCourse,
            this.menuItemUser,
            this.menuItemSettings,
            this.menuItemReport,
            this.menuItemAttendance});
            this.SideDrawerList.MouseState = MaterialWinforms.MouseState.HOVER;
            this.SideDrawerList.Name = "materialContextMenuStrip1";
            this.SideDrawerList.Size = new System.Drawing.Size(216, 208);
            // 
            // menuItemHome
            // 
            this.menuItemHome.Name = "menuItemHome";
            this.menuItemHome.Size = new System.Drawing.Size(215, 24);
            this.menuItemHome.Text = "Home";
            // 
            // menuItemDept
            // 
            this.menuItemDept.Name = "menuItemDept";
            this.menuItemDept.Size = new System.Drawing.Size(215, 24);
            this.menuItemDept.Text = "Department";
            // 
            // menuItemSession
            // 
            this.menuItemSession.Name = "menuItemSession";
            this.menuItemSession.Size = new System.Drawing.Size(215, 24);
            this.menuItemSession.Text = "Session/Semester";
            // 
            // menuItemCourse
            // 
            this.menuItemCourse.AutoSize = false;
            this.menuItemCourse.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.subMenuCourse,
            this.subMenuCourseReg,
            this.subMenuLecturerCourse});
            this.menuItemCourse.Name = "menuItemCourse";
            this.menuItemCourse.Size = new System.Drawing.Size(120, 30);
            this.menuItemCourse.Text = "Course Management";
            // 
            // subMenuCourse
            // 
            this.subMenuCourse.AutoSize = false;
            this.subMenuCourse.Name = "subMenuCourse";
            this.subMenuCourse.Size = new System.Drawing.Size(120, 30);
            this.subMenuCourse.Text = "Courses";
            // 
            // subMenuCourseReg
            // 
            this.subMenuCourseReg.AutoSize = false;
            this.subMenuCourseReg.Name = "subMenuCourseReg";
            this.subMenuCourseReg.Size = new System.Drawing.Size(120, 30);
            this.subMenuCourseReg.Text = "Course Registration";
            // 
            // subMenuLecturerCourse
            // 
            this.subMenuLecturerCourse.AutoSize = false;
            this.subMenuLecturerCourse.Name = "subMenuLecturerCourse";
            this.subMenuLecturerCourse.Size = new System.Drawing.Size(120, 30);
            this.subMenuLecturerCourse.Text = "Lecturer\'s Courses";
            // 
            // menuItemUser
            // 
            this.menuItemUser.AutoSize = false;
            this.menuItemUser.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.subMenuLecturer,
            this.subMenuStudent});
            this.menuItemUser.Name = "menuItemUser";
            this.menuItemUser.Size = new System.Drawing.Size(120, 30);
            this.menuItemUser.Text = "User Management";
            // 
            // subMenuLecturer
            // 
            this.subMenuLecturer.Name = "subMenuLecturer";
            this.subMenuLecturer.Size = new System.Drawing.Size(151, 26);
            this.subMenuLecturer.Text = "Lecturers";
            // 
            // subMenuStudent
            // 
            this.subMenuStudent.Name = "subMenuStudent";
            this.subMenuStudent.Size = new System.Drawing.Size(151, 26);
            this.subMenuStudent.Text = "Students";
            // 
            // menuItemSettings
            // 
            this.menuItemSettings.Name = "menuItemSettings";
            this.menuItemSettings.Size = new System.Drawing.Size(215, 24);
            this.menuItemSettings.Text = "Settings";
            // 
            // menuItemReport
            // 
            this.menuItemReport.Name = "menuItemReport";
            this.menuItemReport.Size = new System.Drawing.Size(215, 24);
            this.menuItemReport.Text = "Report";
            // 
            // menuItemAttendance
            // 
            this.menuItemAttendance.Name = "menuItemAttendance";
            this.menuItemAttendance.Size = new System.Drawing.Size(215, 24);
            this.menuItemAttendance.Text = "Take Attendance";
            // 
            // actionBar
            // 
            this.actionBar.ActionBarButtons.Add(this.materialActionBarButton1);
            this.actionBar.ActionBarButtons.Add(this.materialActionBarButton2);
            this.actionBar.ActionBarMenu = this.SideDrawerList;
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
            graphicsPath4.FillMode = System.Drawing.Drawing2D.FillMode.Alternate;
            this.actionBar.ShadowBorder = graphicsPath4;
            this.actionBar.Size = new System.Drawing.Size(1153, 42);
            this.actionBar.TabIndex = 2;
            // 
            // materialActionBarButton1
            // 
            this.materialActionBarButton1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialActionBarButton1.Depth = 0;
            this.materialActionBarButton1.Image = null;
            this.materialActionBarButton1.Location = new System.Drawing.Point(1008, 0);
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
            this.materialActionBarButton2.Location = new System.Drawing.Point(1050, 0);
            this.materialActionBarButton2.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialActionBarButton2.MouseState = MaterialWinforms.MouseState.HOVER;
            this.materialActionBarButton2.Name = "materialActionBarButton2";
            this.materialActionBarButton2.Size = new System.Drawing.Size(42, 42);
            this.materialActionBarButton2.TabIndex = 0;
            this.materialActionBarButton2.Text = "materialActionBarButton2";
            // 
            // sideMenu
            // 
            this.sideMenu.AutoScroll = true;
            this.sideMenu.Depth = 0;
            this.sideMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sideMenu.Elevation = 10;
            this.sideMenu.HiddenOnStart = false;
            this.sideMenu.HideSideDrawer = false;
            this.sideMenu.Location = new System.Drawing.Point(0, 66);
            this.sideMenu.MaximumSize = new System.Drawing.Size(210, 10000);
            this.sideMenu.MouseState = MaterialWinforms.MouseState.HOVER;
            this.sideMenu.Name = "sideMenu";
            this.sideMenu.Padding = new System.Windows.Forms.Padding(0, 50, 0, 0);
            this.sideMenu.SelectOnClick = false;
            graphicsPath1.FillMode = System.Drawing.Drawing2D.FillMode.Alternate;
            this.sideMenu.ShadowBorder = graphicsPath1;
            this.sideMenu.SideDrawer = this.SideDrawerList;
            this.sideMenu.SideDrawerFixiert = false;
            this.sideMenu.SideDrawerUnterActionBar = false;
            this.sideMenu.Size = new System.Drawing.Size(210, 682);
            this.sideMenu.TabIndex = 3;
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
            // pnlMain
            // 
            this.pnlMain.AutoScroll = true;
            this.pnlMain.Controls.Add(this.materialCard1);
            this.pnlMain.Depth = 0;
            this.pnlMain.Location = new System.Drawing.Point(210, 66);
            this.pnlMain.MouseState = MaterialWinforms.MouseState.HOVER;
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(943, 682);
            this.pnlMain.TabIndex = 4;
            this.pnlMain.Click += new System.EventHandler(this.pnlMain_Click);
            // 
            // materialCard1
            // 
            this.materialCard1.Depth = 0;
            this.materialCard1.Elevation = 5;
            this.materialCard1.LargeTitle = false;
            this.materialCard1.Location = new System.Drawing.Point(138, 91);
            this.materialCard1.MouseState = MaterialWinforms.MouseState.HOVER;
            this.materialCard1.Name = "materialCard1";
            this.materialCard1.Padding = new System.Windows.Forms.Padding(5, 25, 5, 5);
            graphicsPath2.FillMode = System.Drawing.Drawing2D.FillMode.Alternate;
            this.materialCard1.ShadowBorder = graphicsPath2;
            this.materialCard1.Size = new System.Drawing.Size(297, 311);
            this.materialCard1.TabIndex = 3;
            this.materialCard1.Title = "Card 1";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1153, 748);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.sideMenu);
            this.Controls.Add(this.actionBar);
            this.Name = "MainForm";
            this.Text = "Attendance System";
            this.SideDrawerList.ResumeLayout(false);
            this.actionBar.ResumeLayout(false);
            this.pnlMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private MaterialWinforms.Controls.MaterialContextMenuStrip SideDrawerList;
        private MaterialWinforms.Controls.MaterialToolStripMenuItem menuItemUser;
        private System.Windows.Forms.ToolStripMenuItem subMenuLecturer;
        private System.Windows.Forms.ToolStripMenuItem subMenuStudent;
        private MaterialWinforms.Controls.MaterialToolStripMenuItem menuItemCourse;
        private MaterialWinforms.Controls.MaterialToolStripMenuItem subMenuCourse;
        private MaterialWinforms.Controls.MaterialToolStripMenuItem subMenuCourseReg;
        private MaterialWinforms.Controls.MaterialToolStripMenuItem subMenuLecturerCourse;
        private System.Windows.Forms.ToolStripMenuItem menuItemHome;
        private System.Windows.Forms.ToolStripMenuItem menuItemDept;
        private System.Windows.Forms.ToolStripMenuItem menuItemSettings;
        private System.Windows.Forms.ToolStripMenuItem menuItemSession;
        private System.Windows.Forms.ToolStripMenuItem menuItemReport;
        private System.Windows.Forms.ToolStripMenuItem menuItemAttendance;
        private MaterialWinforms.Controls.MaterialActionBar actionBar;
        private MaterialWinforms.Controls.MaterialSideDrawer sideMenu;
        private MaterialWinforms.Controls.MaterialPanel pnlUser;
        private MaterialWinforms.Controls.MaterialPanel pnlMain;
        private MaterialWinforms.Controls.MaterialCard materialCard1;
        private MaterialWinforms.Controls.MaterialActionBarButton materialActionBarButton1;
        private MaterialWinforms.Controls.MaterialActionBarButton materialActionBarButton2;
    }
}