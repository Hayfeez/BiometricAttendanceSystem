namespace AttendanceSystem.Pages
{
    partial class PgDashboard
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pnlUp = new System.Windows.Forms.Panel();
            this.pnlDown = new System.Windows.Forms.Panel();
            this.pnlDate = new System.Windows.Forms.Panel();
            this.lblDate = new MaterialSkin.Controls.MaterialLabel();
            this.lblSession = new MaterialSkin.Controls.MaterialLabel();
            this.pnlSession = new System.Windows.Forms.Panel();
            this.lblSemeseter = new MaterialSkin.Controls.MaterialLabel();
            this.pnlSemester = new System.Windows.Forms.Panel();
            this.lblCourses = new MaterialSkin.Controls.MaterialLabel();
            this.pnlCourses = new System.Windows.Forms.Panel();
            this.lblNoOfCourses = new MaterialSkin.Controls.MaterialLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            this.pnlMain.SuspendLayout();
            this.pnlUp.SuspendLayout();
            this.pnlDown.SuspendLayout();
            this.pnlDate.SuspendLayout();
            this.pnlSession.SuspendLayout();
            this.pnlSemester.SuspendLayout();
            this.pnlCourses.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.pnlDown);
            this.pnlMain.Controls.Add(this.pnlUp);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(1278, 604);
            this.pnlMain.TabIndex = 0;
            // 
            // pnlUp
            // 
            this.pnlUp.Controls.Add(this.pnlCourses);
            this.pnlUp.Controls.Add(this.pnlSession);
            this.pnlUp.Controls.Add(this.pnlSemester);
            this.pnlUp.Controls.Add(this.pnlDate);
            this.pnlUp.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlUp.Location = new System.Drawing.Point(0, 0);
            this.pnlUp.Name = "pnlUp";
            this.pnlUp.Size = new System.Drawing.Size(1278, 128);
            this.pnlUp.TabIndex = 0;
            // 
            // pnlDown
            // 
            this.pnlDown.Controls.Add(this.panel2);
            this.pnlDown.Controls.Add(this.panel1);
            this.pnlDown.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDown.Location = new System.Drawing.Point(0, 128);
            this.pnlDown.Name = "pnlDown";
            this.pnlDown.Size = new System.Drawing.Size(1278, 476);
            this.pnlDown.TabIndex = 1;
            // 
            // pnlDate
            // 
            this.pnlDate.BackColor = System.Drawing.Color.White;
            this.pnlDate.Controls.Add(this.lblDate);
            this.pnlDate.Location = new System.Drawing.Point(62, 22);
            this.pnlDate.Name = "pnlDate";
            this.pnlDate.Size = new System.Drawing.Size(232, 100);
            this.pnlDate.TabIndex = 0;
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Depth = 0;
            this.lblDate.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblDate.Location = new System.Drawing.Point(67, 33);
            this.lblDate.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(48, 24);
            this.lblDate.TabIndex = 0;
            this.lblDate.Text = "Date";
            // 
            // lblSession
            // 
            this.lblSession.AutoSize = true;
            this.lblSession.Depth = 0;
            this.lblSession.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblSession.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblSession.Location = new System.Drawing.Point(67, 33);
            this.lblSession.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblSession.Name = "lblSession";
            this.lblSession.Size = new System.Drawing.Size(77, 24);
            this.lblSession.TabIndex = 0;
            this.lblSession.Text = "Session";
            // 
            // pnlSession
            // 
            this.pnlSession.BackColor = System.Drawing.Color.White;
            this.pnlSession.Controls.Add(this.lblSession);
            this.pnlSession.Location = new System.Drawing.Point(361, 22);
            this.pnlSession.Name = "pnlSession";
            this.pnlSession.Size = new System.Drawing.Size(232, 100);
            this.pnlSession.TabIndex = 1;
            // 
            // lblSemeseter
            // 
            this.lblSemeseter.AutoSize = true;
            this.lblSemeseter.Depth = 0;
            this.lblSemeseter.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblSemeseter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblSemeseter.Location = new System.Drawing.Point(66, 33);
            this.lblSemeseter.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblSemeseter.Name = "lblSemeseter";
            this.lblSemeseter.Size = new System.Drawing.Size(90, 24);
            this.lblSemeseter.TabIndex = 0;
            this.lblSemeseter.Text = "Semester";
            // 
            // pnlSemester
            // 
            this.pnlSemester.BackColor = System.Drawing.Color.White;
            this.pnlSemester.Controls.Add(this.lblSemeseter);
            this.pnlSemester.Location = new System.Drawing.Point(668, 22);
            this.pnlSemester.Name = "pnlSemester";
            this.pnlSemester.Size = new System.Drawing.Size(232, 100);
            this.pnlSemester.TabIndex = 1;
            // 
            // lblCourses
            // 
            this.lblCourses.AutoSize = true;
            this.lblCourses.Depth = 0;
            this.lblCourses.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblCourses.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblCourses.Location = new System.Drawing.Point(54, 19);
            this.lblCourses.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblCourses.Name = "lblCourses";
            this.lblCourses.Size = new System.Drawing.Size(132, 24);
            this.lblCourses.TabIndex = 0;
            this.lblCourses.Text = "No of Courses";
            // 
            // pnlCourses
            // 
            this.pnlCourses.BackColor = System.Drawing.Color.White;
            this.pnlCourses.Controls.Add(this.lblNoOfCourses);
            this.pnlCourses.Controls.Add(this.lblCourses);
            this.pnlCourses.Location = new System.Drawing.Point(966, 22);
            this.pnlCourses.Name = "pnlCourses";
            this.pnlCourses.Size = new System.Drawing.Size(232, 100);
            this.pnlCourses.TabIndex = 1;
            // 
            // lblNoOfCourses
            // 
            this.lblNoOfCourses.AutoSize = true;
            this.lblNoOfCourses.Depth = 0;
            this.lblNoOfCourses.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblNoOfCourses.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblNoOfCourses.Location = new System.Drawing.Point(109, 57);
            this.lblNoOfCourses.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblNoOfCourses.Name = "lblNoOfCourses";
            this.lblNoOfCourses.Size = new System.Drawing.Size(21, 24);
            this.lblNoOfCourses.TabIndex = 1;
            this.lblNoOfCourses.Text = "0";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.materialLabel1);
            this.panel1.Location = new System.Drawing.Point(62, 71);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(471, 370);
            this.panel1.TabIndex = 2;
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel1.Location = new System.Drawing.Point(67, 33);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(233, 24);
            this.materialLabel1.TabIndex = 0;
            this.materialLabel1.Text = "No of Registered Students";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.materialLabel2);
            this.panel2.Location = new System.Drawing.Point(727, 71);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(471, 370);
            this.panel2.TabIndex = 3;
            // 
            // materialLabel2
            // 
            this.materialLabel2.AutoSize = true;
            this.materialLabel2.Depth = 0;
            this.materialLabel2.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel2.Location = new System.Drawing.Point(67, 33);
            this.materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(170, 24);
            this.materialLabel2.TabIndex = 0;
            this.materialLabel2.Text = "Attendance Record";
            // 
            // PgDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlMain);
            this.Name = "PgDashboard";
            this.Size = new System.Drawing.Size(1278, 604);
            this.pnlMain.ResumeLayout(false);
            this.pnlUp.ResumeLayout(false);
            this.pnlDown.ResumeLayout(false);
            this.pnlDate.ResumeLayout(false);
            this.pnlDate.PerformLayout();
            this.pnlSession.ResumeLayout(false);
            this.pnlSession.PerformLayout();
            this.pnlSemester.ResumeLayout(false);
            this.pnlSemester.PerformLayout();
            this.pnlCourses.ResumeLayout(false);
            this.pnlCourses.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Panel pnlDown;
        private System.Windows.Forms.Panel pnlUp;
        private System.Windows.Forms.Panel pnlDate;
        private MaterialSkin.Controls.MaterialLabel lblDate;
        private System.Windows.Forms.Panel pnlCourses;
        private MaterialSkin.Controls.MaterialLabel lblNoOfCourses;
        private MaterialSkin.Controls.MaterialLabel lblCourses;
        private System.Windows.Forms.Panel pnlSession;
        private MaterialSkin.Controls.MaterialLabel lblSession;
        private System.Windows.Forms.Panel pnlSemester;
        private MaterialSkin.Controls.MaterialLabel lblSemeseter;
        private System.Windows.Forms.Panel panel2;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private System.Windows.Forms.Panel panel1;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
    }
}
