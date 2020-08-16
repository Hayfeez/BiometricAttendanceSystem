using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialWinforms.Controls;
using StudentAttendance.Classes;
using StudentAttendance.Model.ViewModels;
using StudentAttendance.Repository;

namespace StudentAttendance.Forms
{
    public partial class FrmLogin : MaterialForm
    {
        private readonly AuthRepo _authRepo;
        public FrmLogin()
        {
            InitializeComponent();
            MaterialSkinBase.InitializeForm((this));
            _authRepo = new AuthRepo();
            

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtEmail.Text == "" || txtPassword.Text == "")
                MessageBox.Show("Enter your Email and password", "Enter Credentials", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //MaterialDialog.Show("Enter your Email and password", "Enter Credentials", MaterialDialog.Buttons.OK, MaterialDialog.Icon.Info);
            else
            {
                var loginData = new Login { Email = txtEmail.Text.Trim(), Password = txtPassword.Text };
                var response = _authRepo.StaffLogin(loginData);
                if (response == null) 
                    MessageBox.Show("Email or password is incorrect", "Invalid Credentials", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // MaterialDialog.Show("Email or password is incorrect", "Invalid Credentials", MaterialDialog.Buttons.OK, MaterialDialog.Icon.Error);
                else
                {
                    LoggedInUser.Email = response.Email;
                    LoggedInUser.Fullname = $"{response.Lastname}, {response.Firstname} {response.Othername}";
                    LoggedInUser.IsAdmin = response.IsAdmin;
                    LoggedInUser.IsSuperAdmin = response.IsSuperAdmin;
                    LoggedInUser.PasswordChanged = response.PasswordChanged;
                    LoggedInUser.UserId = response.Id;


                    this.Hide();
                    var mainForm = new Container();
                    mainForm.Closed += (s, args) => new FrmLogin().Show();  //event to close login form when mainForm is closed
                    mainForm.Show();
                }
            }
        }
    }
}
