using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentAttendance.Model.ViewModels
{
    public class Login
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class ChangePassword
    {
        public string Email { get; set; }
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
        public string ConfirmNewPassword { get; set; }
        public bool isReset { get; set; }
    }

    public class ForgotPassword
    {
        public string Email { get; set; }
    }
}
