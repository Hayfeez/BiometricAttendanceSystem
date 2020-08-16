using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceSystem.Model
{
    [Table("StudentFinger")]
    public class StudentFinger
    {
        [Key]
        public int Id { get; set; }
        public int StudentId { get; set; }
        public byte[] FingerTemplate { get; set; }
        [NotMapped]
        public Bitmap FingerTemplateBitmap { get; set; }
    }
}
