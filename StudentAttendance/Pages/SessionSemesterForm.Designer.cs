namespace StudentAttendance.Pages
{
    partial class SessionSemesterForm
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
            this.txtSemester = new MaterialWinforms.Controls.MaterialSingleLineTextField.BaseTextBox();
            this.materialLabel2 = new MaterialWinforms.Controls.MaterialLabel();
            this.txtSession = new MaterialWinforms.Controls.MaterialSingleLineTextField.BaseTextBox();
            this.materialLabel1 = new MaterialWinforms.Controls.MaterialLabel();
            this.lblTitle = new MaterialWinforms.Controls.MaterialLabel();
            this.chkIsActive = new MaterialWinforms.Controls.MaterialCheckBox();
            this.cardAdd.SuspendLayout();
            this.SuspendLayout();
            // 
            // cardAdd
            // 
            this.cardAdd.Controls.Add(this.chkIsActive);
            this.cardAdd.Controls.Add(this.btnCancel);
            this.cardAdd.Controls.Add(this.btnSave);
            this.cardAdd.Controls.Add(this.lblId);
            this.cardAdd.Controls.Add(this.txtSemester);
            this.cardAdd.Controls.Add(this.materialLabel2);
            this.cardAdd.Controls.Add(this.txtSession);
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
            this.btnCancel.Location = new System.Drawing.Point(385, 250);
            this.btnCancel.MouseState = MaterialWinforms.MouseState.HOVER;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Primary = true;
            graphicsPath1.FillMode = System.Drawing.Drawing2D.FillMode.Alternate;
            this.btnCancel.ShadowBorder = graphicsPath1;
            this.btnCancel.Size = new System.Drawing.Size(92, 23);
            this.btnCancel.TabIndex = 18;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Depth = 0;
            this.btnSave.Elevation = 5;
            this.btnSave.Location = new System.Drawing.Point(261, 250);
            this.btnSave.MouseState = MaterialWinforms.MouseState.HOVER;
            this.btnSave.Name = "btnSave";
            this.btnSave.Primary = true;
            graphicsPath2.FillMode = System.Drawing.Drawing2D.FillMode.Alternate;
            this.btnSave.ShadowBorder = graphicsPath2;
            this.btnSave.Size = new System.Drawing.Size(104, 23);
            this.btnSave.TabIndex = 17;
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
            this.lblId.Location = new System.Drawing.Point(59, 224);
            this.lblId.MouseState = MaterialWinforms.MouseState.HOVER;
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(0, 24);
            this.lblId.TabIndex = 16;
            this.lblId.Visible = false;
            // 
            // txtSemester
            // 
            this.txtSemester.Hint = "Semester";
            this.txtSemester.Location = new System.Drawing.Point(261, 160);
            this.txtSemester.Name = "txtSemester";
            this.txtSemester.Size = new System.Drawing.Size(216, 22);
            this.txtSemester.TabIndex = 2;
            // 
            // materialLabel2
            // 
            this.materialLabel2.AutoSize = true;
            this.materialLabel2.Depth = 0;
            this.materialLabel2.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.materialLabel2.Location = new System.Drawing.Point(59, 159);
            this.materialLabel2.MouseState = MaterialWinforms.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(90, 24);
            this.materialLabel2.TabIndex = 15;
            this.materialLabel2.Text = "Semester";
            // 
            // txtSession
            // 
            this.txtSession.Hint = "Session";
            this.txtSession.Location = new System.Drawing.Point(261, 119);
            this.txtSession.Name = "txtSession";
            this.txtSession.Size = new System.Drawing.Size(216, 22);
            this.txtSession.TabIndex = 1;
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.materialLabel1.Location = new System.Drawing.Point(59, 118);
            this.materialLabel1.MouseState = MaterialWinforms.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(77, 24);
            this.materialLabel1.TabIndex = 13;
            this.materialLabel1.Text = "Session";
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
            this.lblTitle.Size = new System.Drawing.Size(204, 24);
            this.lblTitle.TabIndex = 12;
            this.lblTitle.Text = "Add Session/Semester";
            // 
            // chkIsActive
            // 
            this.chkIsActive.AutoSize = true;
            this.chkIsActive.Depth = 0;
            this.chkIsActive.Font = new System.Drawing.Font("Roboto", 10F);
            this.chkIsActive.Location = new System.Drawing.Point(261, 203);
            this.chkIsActive.Margin = new System.Windows.Forms.Padding(0);
            this.chkIsActive.MouseLocation = new System.Drawing.Point(-1, -1);
            this.chkIsActive.MouseState = MaterialWinforms.MouseState.HOVER;
            this.chkIsActive.Name = "chkIsActive";
            this.chkIsActive.Ripple = true;
            this.chkIsActive.Size = new System.Drawing.Size(88, 30);
            this.chkIsActive.TabIndex = 19;
            this.chkIsActive.Text = "Active?";
            this.chkIsActive.UseVisualStyleBackColor = true;
            // 
            // SessionSemesterForm
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(565, 377);
            this.Controls.Add(this.cardAdd);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SessionSemesterForm";
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
        private MaterialWinforms.Controls.MaterialSingleLineTextField.BaseTextBox txtSemester;
        private MaterialWinforms.Controls.MaterialLabel materialLabel2;
        private MaterialWinforms.Controls.MaterialSingleLineTextField.BaseTextBox txtSession;
        private MaterialWinforms.Controls.MaterialLabel lblId;
        private MaterialWinforms.Controls.MaterialRaisedButton btnCancel;
        private MaterialWinforms.Controls.MaterialRaisedButton btnSave;
        private MaterialWinforms.Controls.MaterialCheckBox chkIsActive;
    }
}
