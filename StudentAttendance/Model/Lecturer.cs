using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentAttendance.Model
{
    [Table("Lecturer")]
    public class Lecturer
    {
       
        [Key]
        public int Id { get; set; }
        public string StaffNo { get; set; }
        public string Firstname { get; set; }
        public string Othername { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public int? DepartmentId { get; set; }
        public int? TitleId { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; }
        public bool PasswordChanged { get; set; }
        public bool IsSuperAdmin { get; set; }
        public bool IsDeleted { get; set; }
    }
}
