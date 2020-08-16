namespace StudentAttendance.Pages
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
            System.Drawing.Drawing2D.GraphicsPath graphicsPath1 = new System.Drawing.Drawing2D.GraphicsPath();
            this.materialCard1 = new MaterialWinforms.Controls.MaterialCard();
            this.materialComboBox1 = new MaterialWinforms.Controls.MaterialComboBox();
            this.materialColorPicker1 = new MaterialWinforms.Controls.MaterialColorPicker();
            this.materialDrawerItem1 = new MaterialWinforms.Controls.MaterialDrawerItem();
            this.materialDropDownDatePicker1 = new MaterialWinforms.Controls.MaterialDropDownDatePicker();
            this.materialDropDownColorPicker1 = new MaterialWinforms.Controls.MaterialDropDownColorPicker();
            this.materialCard1.SuspendLayout();
            this.SuspendLayout();
            // 
            // materialCard1
            // 
            this.materialCard1.Controls.Add(this.materialDropDownColorPicker1);
            this.materialCard1.Controls.Add(this.materialDropDownDatePicker1);
            this.materialCard1.Controls.Add(this.materialDrawerItem1);
            this.materialCard1.Controls.Add(this.materialColorPicker1);
            this.materialCard1.Controls.Add(this.materialComboBox1);
            this.materialCard1.Depth = 0;
            this.materialCard1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.materialCard1.Elevation = 5;
            this.materialCard1.LargeTitle = false;
            this.materialCard1.Location = new System.Drawing.Point(0, 0);
            this.materialCard1.MouseState = MaterialWinforms.MouseState.HOVER;
            this.materialCard1.Name = "materialCard1";
            this.materialCard1.Padding = new System.Windows.Forms.Padding(5, 25, 5, 5);
            graphicsPath1.FillMode = System.Drawing.Drawing2D.FillMode.Alternate;
            this.materialCard1.ShadowBorder = graphicsPath1;
            this.materialCard1.Size = new System.Drawing.Size(1246, 841);
            this.materialCard1.TabIndex = 0;
            this.materialCard1.Title = null;
            // 
            // materialComboBox1
            // 
            this.materialComboBox1.Depth = 0;
            this.materialComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.materialComboBox1.FormattingEnabled = true;
            this.materialComboBox1.Location = new System.Drawing.Point(224, 189);
            this.materialComboBox1.MouseState = MaterialWinforms.MouseState.HOVER;
            this.materialComboBox1.Name = "materialComboBox1";
            this.materialComboBox1.Size = new System.Drawing.Size(121, 28);
            this.materialComboBox1.TabIndex = 0;
            // 
            // materialColorPicker1
            // 
            this.materialColorPicker1.Depth = 0;
            this.materialColorPicker1.Location = new System.Drawing.Point(313, 374);
            this.materialColorPicker1.MouseState = MaterialWinforms.MouseState.HOVER;
            this.materialColorPicker1.Name = "materialColorPicker1";
            this.materialColorPicker1.Size = new System.Drawing.Size(248, 425);
            this.materialColorPicker1.TabIndex = 1;
            this.materialColorPicker1.Text = "materialColorPicker1";
            this.materialColorPicker1.Value = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(64)))), ((int)(((byte)(129)))));
            // 
            // materialDrawerItem1
            // 
            this.materialDrawerItem1.Accent = false;
            this.materialDrawerItem1.AutoSize = true;
            this.materialDrawerItem1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialDrawerItem1.Depth = 0;
            this.materialDrawerItem1.IconImage = null;
            this.materialDrawerItem1.Location = new System.Drawing.Point(528, 189);
            this.materialDrawerItem1.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialDrawerItem1.MouseState = MaterialWinforms.MouseState.HOVER;
            this.materialDrawerItem1.Name = "materialDrawerItem1";
            this.materialDrawerItem1.Primary = false;
            this.materialDrawerItem1.Selected = false;
            this.materialDrawerItem1.Size = new System.Drawing.Size(215, 36);
            this.materialDrawerItem1.TabIndex = 2;
            this.materialDrawerItem1.Text = "materialDrawerItem1";
            this.materialDrawerItem1.UseVisualStyleBackColor = true;
            // 
            // materialDropDownDatePicker1
            // 
            this.materialDropDownDatePicker1.AnchorSize = new System.Drawing.Size(121, 21);
            this.materialDropDownDatePicker1.BackColor = System.Drawing.SystemColors.Control;
            this.materialDropDownDatePicker1.Date = new System.DateTime(2020, 5, 2, 16, 47, 50, 10);
            this.materialDropDownDatePicker1.Depth = 0;
            this.materialDropDownDatePicker1.DockSide = MaterialWinforms.Controls.DropDownControl.eDockSide.Left;
            this.materialDropDownDatePicker1.Location = new System.Drawing.Point(735, 463);
            this.materialDropDownDatePicker1.MouseState = MaterialWinforms.MouseState.HOVER;
            this.materialDropDownDatePicker1.Name = "materialDropDownDatePicker1";
            this.materialDropDownDatePicker1.Size = new System.Drawing.Size(121, 21);
            this.materialDropDownDatePicker1.TabIndex = 3;
            // 
            // materialDropDownColorPicker1
            // 
            this.materialDropDownColorPicker1.AnchorSize = new System.Drawing.Size(121, 21);
            this.materialDropDownColorPicker1.BackColor = System.Drawing.SystemColors.Control;
            this.materialDropDownColorPicker1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(64)))), ((int)(((byte)(129)))));
            this.materialDropDownColorPicker1.Depth = 0;
            this.materialDropDownColorPicker1.DockSide = MaterialWinforms.Controls.DropDownControl.eDockSide.Left;
            this.materialDropDownColorPicker1.Location = new System.Drawing.Point(964, 248);
            this.materialDropDownColorPicker1.MouseState = MaterialWinforms.MouseState.HOVER;
            this.materialDropDownColorPicker1.Name = "materialDropDownColorPicker1";
            this.materialDropDownColorPicker1.Size = new System.Drawing.Size(121, 21);
            this.materialDropDownColorPicker1.TabIndex = 4;
            // 
            // PgDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.materialCard1);
            this.Name = "PgDashboard";
            this.Size = new System.Drawing.Size(1246, 841);
            this.materialCard1.ResumeLayout(false);
            this.materialCard1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private MaterialWinforms.Controls.MaterialCard materialCard1;
        private MaterialWinforms.Controls.MaterialDropDownColorPicker materialDropDownColorPicker1;
        private MaterialWinforms.Controls.MaterialDropDownDatePicker materialDropDownDatePicker1;
        private MaterialWinforms.Controls.MaterialDrawerItem materialDrawerItem1;
        private MaterialWinforms.Controls.MaterialColorPicker materialColorPicker1;
        private MaterialWinforms.Controls.MaterialComboBox materialComboBox1;
    }
}
