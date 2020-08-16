using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceSystem.BaseClass
{
    public class DataHolder
    {
        public long CorpsID { get; set; }
        public string FullName { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public Bitmap Passport { get; set; }
        public Bitmap LeftFinger { get; set; }
        public Bitmap RightFinger { get; set; }
        public Bitmap LeftFingerConfirm { get; set; }
        public Bitmap RightFingerConfirm { get; set; }
        public int Mode { get; set; } = 1;
    }
}
