
using AttendanceSystem.Model;
using AttendanceSystem.Model.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceSystem.Repository
{
    public class AuthRepo
    {
        public string StaffChangePassword(ChangePassword pwd)
        {
            try
            {
                if (pwd.NewPassword != pwd.ConfirmNewPassword) return "New password and confirm new password must match";

                using (var context = new BASContext())
                {
                    var d = context.Staff.SingleOrDefault(a => a.Email == pwd.Email && a.Password == pwd.OldPassword);
                    if (d == null) return "Old Password is not valid";

                    d.Password = pwd.NewPassword;
                    d.PasswordChanged = true;
                    context.SaveChanges();
                    return "Password changed successfully";

                }                    
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string StaffSignOut()
        {
            return "";                
            
        }

        public ChangePassword StaffForgotPassword(ForgotPassword model)
        {
            try
            {
                using (var context = new BASContext())
                {
                    var d = context.Staff.SingleOrDefault(a => a.Email == model.Email);
                    if (d == null) return null;
                    return new ChangePassword
                    {
                        Email = d.Email,
                        isReset = true,
                        OldPassword = d.Password
                    };
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Lecturer StaffLogin(Login model)
        {
            try
            {
                using (var context = new BASContext())
                {
                    return context.Staff.SingleOrDefault(a => a.Email == model.Email  && a.Password == model.Password);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }       

    }
}
