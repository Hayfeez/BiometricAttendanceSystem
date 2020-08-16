namespace StudentAttendance.Forms
{
    partial class FrmLogin
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
            System.Drawing.Drawing2D.GraphicsPath graphicsPath2 = new System.Drawing.Drawing2D.GraphicsPath();
            System.Drawing.Drawing2D.GraphicsPath graphicsPath1 = new System.Drawing.Drawing2D.GraphicsPath();
            this.materialCard1 = new MaterialWinforms.Controls.MaterialCard();
            this.txtPassword = new MaterialWinforms.Controls.MaterialSingleLineTextField.BaseTextBox();
            this.btnLogin = new MaterialWinforms.Controls.MaterialRaisedButton();
            this.txtEmail = new MaterialWinforms.Controls.MaterialSingleLineTextField.BaseTextBox();
            this.txtTitle = new MaterialWinforms.Controls.MaterialLabel();
            this.materialCard1.SuspendLayout();
            this.SuspendLayout();
            // 
            // materialCard1
            // 
            this.materialCard1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.materialCard1.Controls.Add(this.txtTitle);
            this.materialCard1.Controls.Add(this.txtEmail);
            this.materialCard1.Controls.Add(this.txtPassword);
            this.materialCard1.Controls.Add(this.btnLogin);
            this.materialCard1.Depth = 0;
            this.materialCard1.Elevation = 5;
            this.materialCard1.LargeTitle = false;
            this.materialCard1.Location = new System.Drawing.Point(527, 69);
            this.materialCard1.MouseState = MaterialWinforms.MouseState.HOVER;
            this.materialCard1.Name = "materialCard1";
            this.materialCard1.Padding = new System.Windows.Forms.Padding(5, 25, 5, 5);
            graphicsPath2.FillMode = System.Drawing.Drawing2D.FillMode.Alternate;
            this.materialCard1.ShadowBorder = graphicsPath2;
            this.materialCard1.Size = new System.Drawing.Size(419, 411);
            this.materialCard1.TabIndex = 0;
            this.materialCard1.Title = "";
            // 
            // txtPassword
            // 
            this.txtPassword.Hint = "Password";
            this.txtPassword.Location = new System.Drawing.Point(113, 192);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(273, 22);
            this.txtPassword.TabIndex = 3;
            // 
            // btnLogin
            // 
            this.btnLogin.Depth = 0;
            this.btnLogin.Elevation = 5;
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.Location = new System.Drawing.Point(113, 243);
            this.btnLogin.MouseState = MaterialWinforms.MouseState.HOVER;
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Primary = true;
            graphicsPath1.FillMode = System.Drawing.Drawing2D.FillMode.Alternate;
            this.btnLogin.ShadowBorder = graphicsPath1;
            this.btnLogin.Size = new System.Drawing.Size(273, 27);
            this.btnLogin.TabIndex = 1;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // txtEmail
            // 
            this.txtEmail.Hint = "Email";
            this.txtEmail.Location = new System.Drawing.Point(113, 129);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(273, 22);
            this.txtEmail.TabIndex = 2;
            // 
            // txtTitle
            // 
            this.txtTitle.AutoSize = true;
            this.txtTitle.Depth = 0;
            this.txtTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold);
            this.txtTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.txtTitle.Location = new System.Drawing.Point(173, 56);
            this.txtTitle.MouseState = MaterialWinforms.MouseState.HOVER;
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(112, 36);
            this.txtTitle.TabIndex = 0;
            this.txtTitle.Text = "LOGIN";
            // 
            // FrmLogin
            // 
            this.AcceptButton = this.btnLogin;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(976, 531);
            this.Controls.Add(this.materialCard1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmLogin";
            this.Sizable = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.materialCard1.ResumeLayout(false);
            this.materialCard1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private MaterialWinforms.Controls.MaterialCard materialCard1;
        private MaterialWinforms.Controls.MaterialRaisedButton btnLogin;
        private MaterialWinforms.Controls.MaterialSingleLineTextField.BaseTextBox txtPassword;
        private MaterialWinforms.Controls.MaterialSingleLineTextField.BaseTextBox txtEmail;
        private MaterialWinforms.Controls.MaterialLabel txtTitle;
    }
}