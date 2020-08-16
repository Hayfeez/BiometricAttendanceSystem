using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceSystem.Model.ViewModels
{
    public class BulkStudent
    {
        public string MatricNo { get; set; }
        public string Lastname { get; set; }
        public string Firstname { get; set; }
        public string Othername { get; set; }
        public string Email { get; set; }
        public string PhoneNo { get; set; }
        public string Department { get; set; }
    }

    public class BulkStaff
    {
        public string StaffNo { get; set; }
        public string Lastname { get; set; }
        public string Firstname { get; set; }
        public string Othername { get; set; }
        public string Email { get; set; }
        public string Title { get; set; }
    }
}
