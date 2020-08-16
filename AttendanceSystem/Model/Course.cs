using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceSystem.Model
{
    [Table("Course")]
    public class Course
    {
        [Key]
        public int Id { get; set; }
        public int DepartmentId { get; set; }
        public string CourseTitle { get; set; }
        public string CourseCode { get; set; }
        public bool IsDeleted { get; set; }
    }
}
