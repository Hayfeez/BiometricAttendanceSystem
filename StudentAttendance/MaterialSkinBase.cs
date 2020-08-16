
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialWinforms;
using MaterialWinforms.Controls;

namespace StudentAttendance
{
    public static class MaterialSkinBase
    {
        public static MaterialSkinManager InitializeForm(MaterialForm form)
        {
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(form);
            
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Cyan500, Primary.Cyan700, Primary.Cyan300, Accent.LightBlue200, TextShade.BLACK);
            //materialSkinManager.FORM_PADDING = 5;
            return materialSkinManager;

        }
    }
}
