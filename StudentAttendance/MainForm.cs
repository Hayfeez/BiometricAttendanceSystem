using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialWinforms;
using MaterialWinforms.Controls;

namespace StudentAttendance
{
    public partial class MainForm : MaterialForm
    {
        private readonly MaterialSkinManager MaterialWinformsManager;
        public MainForm()
        {
            InitializeComponent();

            // Initialize MaterialWinformsManager
            MaterialWinformsManager = MaterialSkinManager.Instance;
            MaterialWinformsManager.AddFormToManage(this);
        }


        private void pnlMain_Click(object sender, EventArgs e)
        {

        }
    }
}
