using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceSystem.Model
{
    [Table("Attendance")]
    public class Attendance
    {
       [Key]
        public int Id { get; set; }
        public int CourseRegistrationId { get; set; }        
        public int MarkedBy { get; set; }
        public DateTime DateMarked { get; set; }


    }
}
