using MaterialSkin.Controls;
using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AttendanceSystem.Repository;
using AttendanceSystem.Model.ViewModels;
using AttendanceSystem.BaseClass;

namespace AttendanceSystem.Forms
{
    public partial class FrmLogin : MaterialForm
    {
        private AuthRepo _authRepo;
        public FrmLogin()
        {
            InitializeComponent();
            MaterialSkinBase.InitializeForm(this);
            _authRepo = new AuthRepo();
            
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtEmail.Text == "" || txtPassword.Text == "")
                MessageBox.Show("Enter your username and password", "Enter Credentials", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else {
                var loginData = new Login { Email = txtEmail.Text.Trim(), Password = txtPassword.Text };
                var response = _authRepo.StaffLogin(loginData);
                if (response == null) MessageBox.Show("Invalid Credentials", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    LoggedInUser.Email = response.Email;
                    LoggedInUser.Fullname = $"{response.Lastname}, {response.Firstname} {response.Othername}";
                    LoggedInUser.IsAdmin = response.IsAdmin;
                    LoggedInUser.IsSuperAdmin = response.IsSuperAdmin;
                    LoggedInUser.PasswordChanged = response.PasswordChanged;
                    LoggedInUser.UserId = response.Id;

                    Container mainForm = new Container();
                    mainForm.Show();
                }
            }
        }
    }
}
