namespace StudentAttendance.Pages
{
    partial class SessionSemesterList
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
            this.cardList = new MaterialWinforms.Controls.MaterialCard();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.grdData = new System.Windows.Forms.DataGridView();
            this.pnlListTop = new System.Windows.Forms.Panel();
            this.txtSearch = new MaterialWinforms.Controls.MaterialSingleLineTextField.BaseTextBox();
            this.btnSearch = new MaterialWinforms.Controls.MaterialRaisedButton();
            this.btnAddNew = new MaterialWinforms.Controls.MaterialRaisedButton();
            this.lblListTitle = new MaterialWinforms.Controls.MaterialLabel();
            this.cardList.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdData)).BeginInit();
            this.pnlListTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // cardList
            // 
            this.cardList.Controls.Add(this.tableLayoutPanel1);
            this.cardList.Depth = 0;
            this.cardList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cardList.Elevation = 5;
            this.cardList.LargeTitle = true;
            this.cardList.Location = new System.Drawing.Point(0, 0);
            this.cardList.MouseState = MaterialWinforms.MouseState.HOVER;
            this.cardList.Name = "cardList";
            this.cardList.Padding = new System.Windows.Forms.Padding(5, 25, 5, 5);
            graphicsPath3.FillMode = System.Drawing.Drawing2D.FillMode.Alternate;
            this.cardList.ShadowBorder = graphicsPath3;
            this.cardList.Size = new System.Drawing.Size(1279, 576);
            this.cardList.TabIndex = 1;
            this.cardList.Title = "";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.grdData, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.pnlListTop, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(5, 25);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1269, 546);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // grdData
            // 
            this.grdData.AllowUserToAddRows = false;
            this.grdData.AllowUserToDeleteRows = false;
            this.grdData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdData.Location = new System.Drawing.Point(3, 112);
            this.grdData.Name = "grdData";
            this.grdData.ReadOnly = true;
            this.grdData.RowHeadersWidth = 51;
            this.grdData.RowTemplate.Height = 24;
            this.grdData.Size = new System.Drawing.Size(1263, 431);
            this.grdData.TabIndex = 2;
            this.grdData.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdData_CellContentClick);
            // 
            // pnlListTop
            // 
            this.pnlListTop.Controls.Add(this.txtSearch);
            this.pnlListTop.Controls.Add(this.btnSearch);
            this.pnlListTop.Controls.Add(this.btnAddNew);
            this.pnlListTop.Controls.Add(this.lblListTitle);
            this.pnlListTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlListTop.Location = new System.Drawing.Point(3, 3);
            this.pnlListTop.Name = "pnlListTop";
            this.pnlListTop.Size = new System.Drawing.Size(1263, 103);
            this.pnlListTop.TabIndex = 1;
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Hint = "Search";
            this.txtSearch.Location = new System.Drawing.Point(537, 77);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(183, 22);
            this.txtSearch.TabIndex = 11;
            // 
            // btnSearch
            // 
            this.btnSearch.Depth = 0;
            this.btnSearch.Elevation = 5;
            this.btnSearch.Location = new System.Drawing.Point(726, 76);
            this.btnSearch.MouseState = MaterialWinforms.MouseState.HOVER;
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Primary = true;
            graphicsPath1.FillMode = System.Drawing.Drawing2D.FillMode.Alternate;
            this.btnSearch.ShadowBorder = graphicsPath1;
            this.btnSearch.Size = new System.Drawing.Size(134, 23);
            this.btnSearch.TabIndex = 10;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnAddNew
            // 
            this.btnAddNew.Depth = 0;
            this.btnAddNew.Elevation = 5;
            this.btnAddNew.Location = new System.Drawing.Point(25, 80);
            this.btnAddNew.MouseState = MaterialWinforms.MouseState.HOVER;
            this.btnAddNew.Name = "btnAddNew";
            this.btnAddNew.Primary = true;
            graphicsPath2.FillMode = System.Drawing.Drawing2D.FillMode.Alternate;
            this.btnAddNew.ShadowBorder = graphicsPath2;
            this.btnAddNew.Size = new System.Drawing.Size(232, 23);
            this.btnAddNew.TabIndex = 9;
            this.btnAddNew.Text = "Add Session/Semester";
            this.btnAddNew.UseVisualStyleBackColor = true;
            this.btnAddNew.Click += new System.EventHandler(this.btnAddNew_Click);
            // 
            // lblListTitle
            // 
            this.lblListTitle.AutoSize = true;
            this.lblListTitle.Depth = 0;
            this.lblListTitle.Enabled = false;
            this.lblListTitle.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblListTitle.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblListTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.lblListTitle.Location = new System.Drawing.Point(21, 14);
            this.lblListTitle.MouseState = MaterialWinforms.MouseState.HOVER;
            this.lblListTitle.Name = "lblListTitle";
            this.lblListTitle.Size = new System.Drawing.Size(175, 24);
            this.lblListTitle.TabIndex = 8;
            this.lblListTitle.Text = "Session/Semesters";
            // 
            // SessionSemesterList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cardList);
            this.Name = "SessionSemesterList";
            this.Size = new System.Drawing.Size(1279, 576);
            this.Load += new System.EventHandler(this.Form_Load);
            this.cardList.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdData)).EndInit();
            this.pnlListTop.ResumeLayout(false);
            this.pnlListTop.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private MaterialWinforms.Controls.MaterialCard cardList;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView grdData;
        private System.Windows.Forms.Panel pnlListTop;
        private MaterialWinforms.Controls.MaterialSingleLineTextField.BaseTextBox txtSearch;
        private MaterialWinforms.Controls.MaterialRaisedButton btnSearch;
        private MaterialWinforms.Controls.MaterialRaisedButton btnAddNew;
        private MaterialWinforms.Controls.MaterialLabel lblListTitle;
    }
}
