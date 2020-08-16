namespace AttendanceSystem.Pages
{
    partial class PgCourse
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlAdd = new System.Windows.Forms.Panel();
            this.pnlList = new System.Windows.Forms.Panel();
            this.txtCourseTitle = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.txtCourseCode = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.txtOperation = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.cbActive = new MaterialSkin.Controls.MaterialCheckBox();
            this.btnClear = new MaterialSkin.Controls.MaterialFlatButton();
            this.btnSave = new MaterialSkin.Controls.MaterialRaisedButton();
            this.materialSingleLineTextField1 = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.metroGrid1 = new MetroFramework.Controls.MetroGrid();
            this.dpDept = new MetroFramework.Controls.MetroComboBox();
            this.pnlAdd.SuspendLayout();
            this.pnlList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.metroGrid1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlAdd
            // 
            this.pnlAdd.Controls.Add(this.dpDept);
            this.pnlAdd.Controls.Add(this.btnSave);
            this.pnlAdd.Controls.Add(this.btnClear);
            this.pnlAdd.Controls.Add(this.cbActive);
            this.pnlAdd.Controls.Add(this.txtOperation);
            this.pnlAdd.Controls.Add(this.txtCourseCode);
            this.pnlAdd.Controls.Add(this.txtCourseTitle);
            this.pnlAdd.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlAdd.Location = new System.Drawing.Point(0, 0);
            this.pnlAdd.Name = "pnlAdd";
            this.pnlAdd.Size = new System.Drawing.Size(462, 592);
            this.pnlAdd.TabIndex = 0;
            // 
            // pnlList
            // 
            this.pnlList.Controls.Add(this.metroGrid1);
            this.pnlList.Controls.Add(this.materialSingleLineTextField1);
            this.pnlList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlList.Location = new System.Drawing.Point(462, 0);
            this.pnlList.Name = "pnlList";
            this.pnlList.Size = new System.Drawing.Size(757, 592);
            this.pnlList.TabIndex = 1;
            // 
            // txtCourseTitle
            // 
            this.txtCourseTitle.Depth = 0;
            this.txtCourseTitle.Hint = "Course Title";
            this.txtCourseTitle.Location = new System.Drawing.Point(109, 189);
            this.txtCourseTitle.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtCourseTitle.Name = "txtCourseTitle";
            this.txtCourseTitle.PasswordChar = '\0';
            this.txtCourseTitle.SelectedText = "";
            this.txtCourseTitle.SelectionLength = 0;
            this.txtCourseTitle.SelectionStart = 0;
            this.txtCourseTitle.Size = new System.Drawing.Size(252, 28);
            this.txtCourseTitle.TabIndex = 2;
            this.txtCourseTitle.UseSystemPasswordChar = false;
            // 
            // txtCourseCode
            // 
            this.txtCourseCode.Depth = 0;
            this.txtCourseCode.Hint = "Course Code";
            this.txtCourseCode.Location = new System.Drawing.Point(109, 248);
            this.txtCourseCode.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtCourseCode.Name = "txtCourseCode";
            this.txtCourseCode.PasswordChar = '\0';
            this.txtCourseCode.SelectedText = "";
            this.txtCourseCode.SelectionLength = 0;
            this.txtCourseCode.SelectionStart = 0;
            this.txtCourseCode.Size = new System.Drawing.Size(252, 28);
            this.txtCourseCode.TabIndex = 3;
            this.txtCourseCode.UseSystemPasswordChar = false;
            // 
            // txtOperation
            // 
            this.txtOperation.Depth = 0;
            this.txtOperation.Enabled = false;
            this.txtOperation.Hint = "";
            this.txtOperation.Location = new System.Drawing.Point(36, 64);
            this.txtOperation.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtOperation.Name = "txtOperation";
            this.txtOperation.PasswordChar = '\0';
            this.txtOperation.SelectedText = "";
            this.txtOperation.SelectionLength = 0;
            this.txtOperation.SelectionStart = 0;
            this.txtOperation.Size = new System.Drawing.Size(209, 28);
            this.txtOperation.TabIndex = 0;
            this.txtOperation.TabStop = false;
            this.txtOperation.Text = "Add New Course";
            this.txtOperation.UseSystemPasswordChar = false;
            // 
            // cbActive
            // 
            this.cbActive.AutoSize = true;
            this.cbActive.Checked = true;
            this.cbActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbActive.Depth = 0;
            this.cbActive.Font = new System.Drawing.Font("Roboto", 10F);
            this.cbActive.Location = new System.Drawing.Point(109, 308);
            this.cbActive.Margin = new System.Windows.Forms.Padding(0);
            this.cbActive.MouseLocation = new System.Drawing.Point(-1, -1);
            this.cbActive.MouseState = MaterialSkin.MouseState.HOVER;
            this.cbActive.Name = "cbActive";
            this.cbActive.Ripple = true;
            this.cbActive.Size = new System.Drawing.Size(88, 30);
            this.cbActive.TabIndex = 4;
            this.cbActive.Text = "Active?";
            this.cbActive.UseVisualStyleBackColor = true;
            // 
            // btnClear
            // 
            this.btnClear.AutoSize = true;
            this.btnClear.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnClear.Depth = 0;
            this.btnClear.Location = new System.Drawing.Point(226, 358);
            this.btnClear.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnClear.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnClear.Name = "btnClear";
            this.btnClear.Primary = false;
            this.btnClear.Size = new System.Drawing.Size(78, 36);
            this.btnClear.TabIndex = 6;
            this.btnClear.Text = "Cancel";
            this.btnClear.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Depth = 0;
            this.btnSave.Location = new System.Drawing.Point(109, 361);
            this.btnSave.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnSave.Name = "btnSave";
            this.btnSave.Primary = true;
            this.btnSave.Size = new System.Drawing.Size(110, 29);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // materialSingleLineTextField1
            // 
            this.materialSingleLineTextField1.Depth = 0;
            this.materialSingleLineTextField1.Enabled = false;
            this.materialSingleLineTextField1.Hint = "";
            this.materialSingleLineTextField1.Location = new System.Drawing.Point(27, 64);
            this.materialSingleLineTextField1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialSingleLineTextField1.Name = "materialSingleLineTextField1";
            this.materialSingleLineTextField1.PasswordChar = '\0';
            this.materialSingleLineTextField1.SelectedText = "";
            this.materialSingleLineTextField1.SelectionLength = 0;
            this.materialSingleLineTextField1.SelectionStart = 0;
            this.materialSingleLineTextField1.Size = new System.Drawing.Size(236, 28);
            this.materialSingleLineTextField1.TabIndex = 0;
            this.materialSingleLineTextField1.TabStop = false;
            this.materialSingleLineTextField1.Text = "Courses";
            this.materialSingleLineTextField1.UseSystemPasswordChar = false;
            // 
            // metroGrid1
            // 
            this.metroGrid1.AllowUserToResizeRows = false;
            this.metroGrid1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.metroGrid1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.metroGrid1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.metroGrid1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.metroGrid1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.metroGrid1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.metroGrid1.DefaultCellStyle = dataGridViewCellStyle5;
            this.metroGrid1.EnableHeadersVisualStyles = false;
            this.metroGrid1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.metroGrid1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.metroGrid1.Location = new System.Drawing.Point(27, 137);
            this.metroGrid1.Name = "metroGrid1";
            this.metroGrid1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.metroGrid1.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.metroGrid1.RowHeadersWidth = 51;
            this.metroGrid1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.metroGrid1.RowTemplate.Height = 24;
            this.metroGrid1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.metroGrid1.Size = new System.Drawing.Size(704, 452);
            this.metroGrid1.TabIndex = 1;
            // 
            // dpDept
            // 
            this.dpDept.FormattingEnabled = true;
            this.dpDept.ItemHeight = 24;
            this.dpDept.Location = new System.Drawing.Point(109, 137);
            this.dpDept.Name = "dpDept";
            this.dpDept.Size = new System.Drawing.Size(252, 30);
            this.dpDept.TabIndex = 1;
            this.dpDept.UseSelectable = true;
            // 
            // PgCourse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlList);
            this.Controls.Add(this.pnlAdd);
            this.Name = "PgCourse";
            this.Size = new System.Drawing.Size(1219, 592);
            this.pnlAdd.ResumeLayout(false);
            this.pnlAdd.PerformLayout();
            this.pnlList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.metroGrid1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlAdd;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtCourseTitle;
        private System.Windows.Forms.Panel pnlList;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtOperation;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtCourseCode;
        private MaterialSkin.Controls.MaterialCheckBox cbActive;
        private MaterialSkin.Controls.MaterialRaisedButton btnSave;
        private MaterialSkin.Controls.MaterialFlatButton btnClear;
        private MetroFramework.Controls.MetroComboBox dpDept;
        private MetroFramework.Controls.MetroGrid metroGrid1;
        private MaterialSkin.Controls.MaterialSingleLineTextField materialSingleLineTextField1;
    }
}
