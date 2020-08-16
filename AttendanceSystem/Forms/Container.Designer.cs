namespace AttendanceSystem.Forms
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
            this.pnlMenu = new System.Windows.Forms.Panel();
            this.btnDashboard = new MaterialSkin.Controls.MaterialFlatButton();
            this.txtUsername = new MaterialSkin.Controls.MaterialLabel();
            this.imgUserPhoto = new System.Windows.Forms.PictureBox();
            this.materialDivider1 = new MaterialSkin.Controls.MaterialDivider();
            this.pnlPage = new System.Windows.Forms.Panel();
            this.btnCourses = new MaterialSkin.Controls.MaterialFlatButton();
            this.courseSubMenu = new MaterialSkin.Controls.MaterialContextMenuStrip();
            this.btnCourse = new System.Windows.Forms.ToolStripMenuItem();
            this.btnCourseReg = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgUserPhoto)).BeginInit();
            this.courseSubMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMenu
            // 
            this.pnlMenu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.pnlMenu.BackColor = System.Drawing.Color.White;
            this.pnlMenu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlMenu.Controls.Add(this.btnCourses);
            this.pnlMenu.Controls.Add(this.btnDashboard);
            this.pnlMenu.Controls.Add(this.txtUsername);
            this.pnlMenu.Controls.Add(this.imgUserPhoto);
            this.pnlMenu.Location = new System.Drawing.Point(0, 79);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Size = new System.Drawing.Size(312, 537);
            this.pnlMenu.TabIndex = 0;
            // 
            // btnDashboard
            // 
            this.btnDashboard.AutoSize = true;
            this.btnDashboard.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnDashboard.BackColor = System.Drawing.Color.Transparent;
            this.btnDashboard.Depth = 0;
            this.btnDashboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDashboard.Location = new System.Drawing.Point(37, 153);
            this.btnDashboard.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnDashboard.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnDashboard.Name = "btnDashboard";
            this.btnDashboard.Primary = false;
            this.btnDashboard.Size = new System.Drawing.Size(114, 36);
            this.btnDashboard.TabIndex = 2;
            this.btnDashboard.Text = "Dashboard";
            this.btnDashboard.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDashboard.UseVisualStyleBackColor = false;
            this.btnDashboard.Click += new System.EventHandler(this.btnDashboard_Click);
            // 
            // txtUsername
            // 
            this.txtUsername.AutoSize = true;
            this.txtUsername.Depth = 0;
            this.txtUsername.Font = new System.Drawing.Font("Roboto", 11F);
            this.txtUsername.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtUsername.Location = new System.Drawing.Point(110, 18);
            this.txtUsername.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(183, 24);
            this.txtUsername.TabIndex = 1;
            this.txtUsername.Text = "Firstname Lastname";
            // 
            // imgUserPhoto
            // 
            this.imgUserPhoto.Location = new System.Drawing.Point(3, 3);
            this.imgUserPhoto.Name = "imgUserPhoto";
            this.imgUserPhoto.Size = new System.Drawing.Size(100, 93);
            this.imgUserPhoto.TabIndex = 0;
            this.imgUserPhoto.TabStop = false;
            // 
            // materialDivider1
            // 
            this.materialDivider1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialDivider1.Depth = 0;
            this.materialDivider1.Location = new System.Drawing.Point(6, 181);
            this.materialDivider1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialDivider1.Name = "materialDivider1";
            this.materialDivider1.Size = new System.Drawing.Size(300, 24);
            this.materialDivider1.TabIndex = 1;
            this.materialDivider1.Text = "materialDivider1";
            // 
            // pnlPage
            // 
            this.pnlPage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlPage.Location = new System.Drawing.Point(333, 79);
            this.pnlPage.Name = "pnlPage";
            this.pnlPage.Size = new System.Drawing.Size(922, 537);
            this.pnlPage.TabIndex = 2;
            // 
            // btnCourses
            // 
            this.btnCourses.AutoSize = true;
            this.btnCourses.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnCourses.BackColor = System.Drawing.Color.Transparent;
            this.btnCourses.Depth = 0;
            this.btnCourses.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCourses.Location = new System.Drawing.Point(37, 201);
            this.btnCourses.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnCourses.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnCourses.Name = "btnCourses";
            this.btnCourses.Primary = false;
            this.btnCourses.Size = new System.Drawing.Size(201, 36);
            this.btnCourses.TabIndex = 3;
            this.btnCourses.Text = "Course Management";
            this.btnCourses.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCourses.UseVisualStyleBackColor = false;
            this.btnCourses.Click += new System.EventHandler(this.btnCourses_Click);
            this.btnCourses.MouseHover += new System.EventHandler(this.btnCourses_MouseHover);
            // 
            // courseSubMenu
            // 
            this.courseSubMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.courseSubMenu.Depth = 0;
            this.courseSubMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.courseSubMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnCourse,
            this.btnCourseReg});
            this.courseSubMenu.MouseState = MaterialSkin.MouseState.HOVER;
            this.courseSubMenu.Name = "courseSubMenu";
            this.courseSubMenu.Size = new System.Drawing.Size(211, 80);
            // 
            // btnCourse
            // 
            this.btnCourse.Name = "btnCourse";
            this.btnCourse.Size = new System.Drawing.Size(210, 24);
            this.btnCourse.Text = "Courses";
            this.btnCourse.Click += new System.EventHandler(this.btnCourse_Click);
            // 
            // btnCourseReg
            // 
            this.btnCourseReg.Name = "btnCourseReg";
            this.btnCourseReg.Size = new System.Drawing.Size(210, 24);
            this.btnCourseReg.Text = "Course Registration";
            // 
            // Container
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1267, 616);
            this.Controls.Add(this.pnlPage);
            this.Controls.Add(this.materialDivider1);
            this.Controls.Add(this.pnlMenu);
            this.DoubleBuffered = false;
            this.ImeMode = System.Windows.Forms.ImeMode.On;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Container";
            this.Sizable = false;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Shown += new System.EventHandler(this.Container_Shown);
            this.pnlMenu.ResumeLayout(false);
            this.pnlMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgUserPhoto)).EndInit();
            this.courseSubMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMenu;
        private MaterialSkin.Controls.MaterialDivider materialDivider1;
        private MaterialSkin.Controls.MaterialFlatButton btnDashboard;
        private MaterialSkin.Controls.MaterialLabel txtUsername;
        private System.Windows.Forms.PictureBox imgUserPhoto;
        private System.Windows.Forms.Panel pnlPage;
        private MaterialSkin.Controls.MaterialFlatButton btnCourses;
        private MaterialSkin.Controls.MaterialContextMenuStrip courseSubMenu;
        private System.Windows.Forms.ToolStripMenuItem btnCourse;
        private System.Windows.Forms.ToolStripMenuItem btnCourseReg;
    }
}