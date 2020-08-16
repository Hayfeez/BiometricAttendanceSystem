namespace StudentAttendance.Pages
{
    partial class CoursesForm
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
            System.Drawing.Drawing2D.GraphicsPath graphicsPath3 = new System.Drawing.Drawing2D.GraphicsPath();
            System.Drawing.Drawing2D.GraphicsPath graphicsPath1 = new System.Drawing.Drawing2D.GraphicsPath();
            System.Drawing.Drawing2D.GraphicsPath graphicsPath2 = new System.Drawing.Drawing2D.GraphicsPath();
            this.cardAdd = new MaterialWinforms.Controls.MaterialCard();
            this.btnCancel = new MaterialWinforms.Controls.MaterialRaisedButton();
            this.btnSave = new MaterialWinforms.Controls.MaterialRaisedButton();
            this.lblId = new MaterialWinforms.Controls.MaterialLabel();
            this.txtCourseCode = new MaterialWinforms.Controls.MaterialSingleLineTextField.BaseTextBox();
            this.materialLabel2 = new MaterialWinforms.Controls.MaterialLabel();
            this.txtCourseTitle = new MaterialWinforms.Controls.MaterialSingleLineTextField.BaseTextBox();
            this.materialLabel1 = new MaterialWinforms.Controls.MaterialLabel();
            this.lblTitle = new MaterialWinforms.Controls.MaterialLabel();
            this.materialLabel3 = new MaterialWinforms.Controls.MaterialLabel();
            this.drpdownDept = new MaterialWinforms.Controls.MaterialComboBox();
            this.cardAdd.SuspendLayout();
            this.SuspendLayout();
            // 
            // cardAdd
            // 
            this.cardAdd.Controls.Add(this.drpdownDept);
            this.cardAdd.Controls.Add(this.materialLabel3);
            this.cardAdd.Controls.Add(this.btnCancel);
            this.cardAdd.Controls.Add(this.btnSave);
            this.cardAdd.Controls.Add(this.lblId);
            this.cardAdd.Controls.Add(this.txtCourseCode);
            this.cardAdd.Controls.Add(this.materialLabel2);
            this.cardAdd.Controls.Add(this.txtCourseTitle);
            this.cardAdd.Controls.Add(this.materialLabel1);
            this.cardAdd.Controls.Add(this.lblTitle);
            this.cardAdd.Depth = 0;
            this.cardAdd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cardAdd.Elevation = 5;
            this.cardAdd.LargeTitle = false;
            this.cardAdd.Location = new System.Drawing.Point(0, 24);
            this.cardAdd.MouseState = MaterialWinforms.MouseState.HOVER;
            this.cardAdd.Name = "cardAdd";
            this.cardAdd.Padding = new System.Windows.Forms.Padding(5, 25, 5, 5);
            graphicsPath3.FillMode = System.Drawing.Drawing2D.FillMode.Alternate;
            this.cardAdd.ShadowBorder = graphicsPath3;
            this.cardAdd.Size = new System.Drawing.Size(565, 353);
            this.cardAdd.TabIndex = 0;
            this.cardAdd.Title = null;
            // 
            // btnCancel
            // 
            this.btnCancel.Depth = 0;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Elevation = 5;
            this.btnCancel.Location = new System.Drawing.Point(386, 266);
            this.btnCancel.MouseState = MaterialWinforms.MouseState.HOVER;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Primary = true;
            graphicsPath1.FillMode = System.Drawing.Drawing2D.FillMode.Alternate;
            this.btnCancel.ShadowBorder = graphicsPath1;
            this.btnCancel.Size = new System.Drawing.Size(92, 23);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Depth = 0;
            this.btnSave.Elevation = 5;
            this.btnSave.Location = new System.Drawing.Point(262, 266);
            this.btnSave.MouseState = MaterialWinforms.MouseState.HOVER;
            this.btnSave.Name = "btnSave";
            this.btnSave.Primary = true;
            graphicsPath2.FillMode = System.Drawing.Drawing2D.FillMode.Alternate;
            this.btnSave.ShadowBorder = graphicsPath2;
            this.btnSave.Size = new System.Drawing.Size(104, 23);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.Depth = 0;
            this.lblId.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblId.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.lblId.Location = new System.Drawing.Point(60, 266);
            this.lblId.MouseState = MaterialWinforms.MouseState.HOVER;
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(0, 24);
            this.lblId.TabIndex = 16;
            this.lblId.Visible = false;
            // 
            // txtCourseCode
            // 
            this.txtCourseCode.Hint = "Course Code";
            this.txtCourseCode.Location = new System.Drawing.Point(262, 202);
            this.txtCourseCode.Name = "txtCourseCode";
            this.txtCourseCode.Size = new System.Drawing.Size(216, 22);
            this.txtCourseCode.TabIndex = 3;
            // 
            // materialLabel2
            // 
            this.materialLabel2.AutoSize = true;
            this.materialLabel2.Depth = 0;
            this.materialLabel2.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.materialLabel2.Location = new System.Drawing.Point(60, 201);
            this.materialLabel2.MouseState = MaterialWinforms.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(118, 24);
            this.materialLabel2.TabIndex = 0;
            this.materialLabel2.Text = "Course Code";
            // 
            // txtCourseTitle
            // 
            this.txtCourseTitle.Hint = "Course Title";
            this.txtCourseTitle.Location = new System.Drawing.Point(262, 161);
            this.txtCourseTitle.Name = "txtCourseTitle";
            this.txtCourseTitle.Size = new System.Drawing.Size(216, 22);
            this.txtCourseTitle.TabIndex = 2;
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.materialLabel1.Location = new System.Drawing.Point(60, 160);
            this.materialLabel1.MouseState = MaterialWinforms.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(111, 24);
            this.materialLabel1.TabIndex = 0;
            this.materialLabel1.Text = "Course Title";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Depth = 0;
            this.lblTitle.Enabled = false;
            this.lblTitle.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.lblTitle.Location = new System.Drawing.Point(55, 51);
            this.lblTitle.MouseState = MaterialWinforms.MouseState.HOVER;
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(108, 24);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Add Course";
            // 
            // materialLabel3
            // 
            this.materialLabel3.AutoSize = true;
            this.materialLabel3.Depth = 0;
            this.materialLabel3.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.materialLabel3.Location = new System.Drawing.Point(60, 107);
            this.materialLabel3.MouseState = MaterialWinforms.MouseState.HOVER;
            this.materialLabel3.Name = "materialLabel3";
            this.materialLabel3.Size = new System.Drawing.Size(108, 24);
            this.materialLabel3.TabIndex = 0;
            this.materialLabel3.Text = "Department";
            // 
            // drpdownDept
            // 
            this.drpdownDept.Depth = 0;
            this.drpdownDept.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.drpdownDept.FormattingEnabled = true;
            this.drpdownDept.Location = new System.Drawing.Point(262, 102);
            this.drpdownDept.MouseState = MaterialWinforms.MouseState.HOVER;
            this.drpdownDept.Name = "drpdownDept";
            this.drpdownDept.Size = new System.Drawing.Size(216, 28);
            this.drpdownDept.TabIndex = 1;
            // 
            // CoursesForm
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(565, 377);
            this.Controls.Add(this.cardAdd);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CoursesForm";
            this.Sizable = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.TopMost = true;
            this.cardAdd.ResumeLayout(false);
            this.cardAdd.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private MaterialWinforms.Controls.MaterialCard cardAdd;
        private MaterialWinforms.Controls.MaterialLabel materialLabel1;
        private MaterialWinforms.Controls.MaterialLabel lblTitle;
        private MaterialWinforms.Controls.MaterialSingleLineTextField.BaseTextBox txtCourseCode;
        private MaterialWinforms.Controls.MaterialLabel materialLabel2;
        private MaterialWinforms.Controls.MaterialSingleLineTextField.BaseTextBox txtCourseTitle;
        private MaterialWinforms.Controls.MaterialLabel lblId;
        private MaterialWinforms.Controls.MaterialRaisedButton btnCancel;
        private MaterialWinforms.Controls.MaterialRaisedButton btnSave;
        private MaterialWinforms.Controls.MaterialComboBox drpdownDept;
        private MaterialWinforms.Controls.MaterialLabel materialLabel3;
    }
}
