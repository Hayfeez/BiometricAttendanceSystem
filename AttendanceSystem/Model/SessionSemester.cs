using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceSystem.Model
{
    [Table("SessionSemester")]
    public class SessionSemester
    {
        [Key]
        public int Id { get; set; }
        public string Session { get; set; }
        public string Semester { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
    }
}
