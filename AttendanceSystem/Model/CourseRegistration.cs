using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceSystem.Model
{
    [Table("CourseRegistration")]
    public class CourseRegistration
    {
        [Key]
        public int Id { get; set; }
        public int SessionSemesterId { get; set; }
        public int StudentId { get; set; }
        public int LevelId { get; set; }
        public int CourseId { get; set; }
        public int RegisteredBy { get; set; }
        public DateTime DateRegistered { get; set; }
    }
}
