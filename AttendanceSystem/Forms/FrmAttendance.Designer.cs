namespace AttendanceSystem.Forms
{
    partial class FrmAttendance
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
            this.gdvAttendance = new System.Windows.Forms.DataGridView();
            this.txtLog = new MetroFramework.Controls.MetroTextBox();
            this.fingerBox = new System.Windows.Forms.PictureBox();
            this.lblTodaysDate = new MaterialSkin.Controls.MaterialLabel();
            this.lblCourse = new MaterialSkin.Controls.MaterialLabel();
            this.lblUsername = new MaterialSkin.Controls.MaterialLabel();
            this.lblDashboard = new MaterialSkin.Controls.MaterialLabel();
            this.lblMsg = new MaterialSkin.Controls.MaterialLabel();
            this.StudentsName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StudentsMatricNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StudentsTimeIn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblSession = new MaterialSkin.Controls.MaterialLabel();
            ((System.ComponentModel.ISupportInitialize)(this.gdvAttendance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fingerBox)).BeginInit();
            this.SuspendLayout();
            // 
            // gdvAttendance
            // 
            this.gdvAttendance.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gdvAttendance.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.StudentsName,
            this.StudentsMatricNo,
            this.StudentsTimeIn});
            this.gdvAttendance.Location = new System.Drawing.Point(388, 134);
            this.gdvAttendance.Name = "gdvAttendance";
            this.gdvAttendance.Size = new System.Drawing.Size(413, 366);
            this.gdvAttendance.TabIndex = 0;
            // 
            // txtLog
            // 
            // 
            // 
            // 
            this.txtLog.CustomButton.Image = null;
            this.txtLog.CustomButton.Location = new System.Drawing.Point(161, 1);
            this.txtLog.CustomButton.Name = "";
            this.txtLog.CustomButton.Size = new System.Drawing.Size(219, 219);
            this.txtLog.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtLog.CustomButton.TabIndex = 1;
            this.txtLog.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtLog.CustomButton.UseSelectable = true;
            this.txtLog.CustomButton.Visible = false;
            this.txtLog.Lines = new string[0];
            this.txtLog.Location = new System.Drawing.Point(1, 279);
            this.txtLog.MaxLength = 32767;
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.PasswordChar = '\0';
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtLog.SelectedText = "";
            this.txtLog.SelectionLength = 0;
            this.txtLog.SelectionStart = 0;
            this.txtLog.ShortcutsEnabled = true;
            this.txtLog.Size = new System.Drawing.Size(381, 221);
            this.txtLog.TabIndex = 1;
            this.txtLog.UseSelectable = true;
            this.txtLog.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtLog.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // fingerBox
            // 
            this.fingerBox.Location = new System.Drawing.Point(234, 134);
            this.fingerBox.Name = "fingerBox";
            this.fingerBox.Size = new System.Drawing.Size(122, 139);
            this.fingerBox.TabIndex = 2;
            this.fingerBox.TabStop = false;
            // 
            // lblTodaysDate
            // 
            this.lblTodaysDate.AutoSize = true;
            this.lblTodaysDate.Depth = 0;
            this.lblTodaysDate.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblTodaysDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblTodaysDate.Location = new System.Drawing.Point(12, 72);
            this.lblTodaysDate.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblTodaysDate.Name = "lblTodaysDate";
            this.lblTodaysDate.Size = new System.Drawing.Size(54, 19);
            this.lblTodaysDate.TabIndex = 3;
            this.lblTodaysDate.Text = "Today:";
            // 
            // lblCourse
            // 
            this.lblCourse.AutoSize = true;
            this.lblCourse.Depth = 0;
            this.lblCourse.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblCourse.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblCourse.Location = new System.Drawing.Point(206, 72);
            this.lblCourse.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblCourse.Name = "lblCourse";
            this.lblCourse.Size = new System.Drawing.Size(65, 19);
            this.lblCourse.TabIndex = 4;
            this.lblCourse.Text = "Course: ";
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Depth = 0;
            this.lblUsername.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblUsername.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblUsername.Location = new System.Drawing.Point(613, 72);
            this.lblUsername.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(77, 19);
            this.lblUsername.TabIndex = 5;
            this.lblUsername.Text = "Username";
            // 
            // lblDashboard
            // 
            this.lblDashboard.AutoSize = true;
            this.lblDashboard.Depth = 0;
            this.lblDashboard.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblDashboard.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblDashboard.Location = new System.Drawing.Point(696, 72);
            this.lblDashboard.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblDashboard.Name = "lblDashboard";
            this.lblDashboard.Size = new System.Drawing.Size(105, 19);
            this.lblDashboard.TabIndex = 6;
            this.lblDashboard.Text = "Back to Home";
            // 
            // lblMsg
            // 
            this.lblMsg.AutoSize = true;
            this.lblMsg.Depth = 0;
            this.lblMsg.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblMsg.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblMsg.Location = new System.Drawing.Point(60, 85);
            this.lblMsg.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(0, 19);
            this.lblMsg.TabIndex = 7;
            // 
            // StudentsName
            // 
            this.StudentsName.HeaderText = "Name";
            this.StudentsName.Name = "StudentsName";
            // 
            // StudentsMatricNo
            // 
            this.StudentsMatricNo.HeaderText = "Matric Number";
            this.StudentsMatricNo.Name = "StudentsMatricNo";
            // 
            // StudentsTimeIn
            // 
            this.StudentsTimeIn.HeaderText = "Time In";
            this.StudentsTimeIn.Name = "StudentsTimeIn";
            // 
            // lblSession
            // 
            this.lblSession.AutoSize = true;
            this.lblSession.Depth = 0;
            this.lblSession.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblSession.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblSession.Location = new System.Drawing.Point(413, 72);
            this.lblSession.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblSession.Name = "lblSession";
            this.lblSession.Size = new System.Drawing.Size(0, 19);
            this.lblSession.TabIndex = 8;
            // 
            // FrmAttendance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 499);
            this.Controls.Add(this.lblSession);
            this.Controls.Add(this.lblMsg);
            this.Controls.Add(this.lblDashboard);
            this.Controls.Add(this.lblUsername);
            this.Controls.Add(this.lblCourse);
            this.Controls.Add(this.lblTodaysDate);
            this.Controls.Add(this.fingerBox);
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.gdvAttendance);
            this.Name = "FrmAttendance";
            ((System.ComponentModel.ISupportInitialize)(this.gdvAttendance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fingerBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView gdvAttendance;
        private MetroFramework.Controls.MetroTextBox txtLog;
        private System.Windows.Forms.PictureBox fingerBox;
        private MaterialSkin.Controls.MaterialLabel lblTodaysDate;
        private MaterialSkin.Controls.MaterialLabel lblCourse;
        private MaterialSkin.Controls.MaterialLabel lblUsername;
        private MaterialSkin.Controls.MaterialLabel lblDashboard;
        private MaterialSkin.Controls.MaterialLabel lblMsg;
        private System.Windows.Forms.DataGridViewTextBoxColumn StudentsName;
        private System.Windows.Forms.DataGridViewTextBoxColumn StudentsMatricNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn StudentsTimeIn;
        private MaterialSkin.Controls.MaterialLabel lblSession;
    }
}