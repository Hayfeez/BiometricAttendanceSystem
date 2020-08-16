using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceSystem.Model.ViewModels
{
    public class AttendanceViewModel
    {
        public int Id { get; set; }
        public string SessionSemester { get; set; }
        public string Course { get; set; }
        public string DepartmentName { get; set; }
        public string StudentName { get; set; }
        public string StudentMatricNo { get; set; }
        public string MarkedBy { get; set; }
        public string StudentLevel { get; set; }
        public DateTime DateMarked { get; set; }

        public string TimeIn { get; set; }
    }
}
