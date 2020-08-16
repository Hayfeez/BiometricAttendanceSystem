using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentAttendance.Model
{
    [Table("PersonTitle")]
    public class PersonTitle
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsDeleted { get; set; }
    }
}
