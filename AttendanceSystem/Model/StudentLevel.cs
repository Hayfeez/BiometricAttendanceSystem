using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceSystem.Model
{
    [Table("StudentLevel")]
    public class StudentLevel
    {
        [Key]
        public int Id { get; set; }
        public string Level { get; set; }
        //public int LevelRank { get; set; }
        public bool IsDeleted { get; set; }
    }
}
