using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceSystem.BaseClass
{
    public static class LoggedInUser
    {
        public static int UserId { get; set; }
        public static string Fullname { get; set; }
        public static string Email { get; set; }
        public static bool IsAdmin { get; set; }
        public static bool PasswordChanged { get; set; }
        public static bool IsSuperAdmin { get; set; }
    }
}
