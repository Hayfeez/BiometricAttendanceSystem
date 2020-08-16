using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentAttendance.Model.ViewModels
{
    public class CourseViewModel
    {
        public int Id { get; set; }
        public string Department { get; set; }
        public string CourseTitle { get; set; }
        public string CourseCode { get; set; }
    }
}
