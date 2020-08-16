using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceSystem.BaseClass
{
    public static class Settings
    {
        public static int NoOfFinger = 2;
        public static string DefaultPassword = "12345678";
        public static string SuperAdminNo = "000001";
        public static string SuperAdminPassword = "password123";
        public static string SuperAdminEmail = "admin";
        public static string SuperAdminFirstname = "Admin";
        public static string SuperAdminLastname = "Admin";

        public static List<string> GetTitles()
        {
            List<string> titles = new List<string>();
            titles.Add("Mr.");
            titles.Add("Dr.");
            titles.Add("Miss");
            titles.Add("Mrs");
            titles.Add("Dr.(Miss)");
            titles.Add("Dr.(Mrs)");
            titles.Add("Prof.");
            titles.Add("Prof.(Mrs)");

            return titles;
        }

        public static List<string> GetLevels()
        {
            List<string> levels = new List<string>();
            levels.Add("100");
            levels.Add("200");
            levels.Add("300");
            levels.Add("400");
            levels.Add("500");
            levels.Add("600");

            return levels;
        }
    }
}
