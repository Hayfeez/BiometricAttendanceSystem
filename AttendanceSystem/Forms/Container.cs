using AttendanceSystem.BaseClass;
using AttendanceSystem.Pages;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AttendanceSystem.Forms
{
    public partial class Container : MaterialForm
    {
        #region Pages
        private PgDashboard _dashboard;
        private PgCourse _course;


        #endregion
        public Container()
        {
            InitializeComponent();
            MaterialSkinBase.InitializeForm(this);
            if (LoggedInUser.UserId == 0)
            {
                FrmLogin loginForm = new FrmLogin();
                loginForm.Show();
            }

            //FrmAttendance markAttendance = new FrmAttendance(1, "New course");
            //markAttendance.Show();
        }

        private void ShowPage(Control page)
        {
            if (pnlPage.Size != page.Size)
            {
                //page.Size = pnlAll.Size;
                page.Width = pnlPage.Width;
                page.Height = pnlPage.Height - 20;
            }

            pnlPage.Controls.Clear();
            pnlPage.Controls.Add(page);
        }

        private void showCourseSubMenu()
        {
            try
            {
                courseSubMenu.Left = btnCourses.Left + btnCourses.Width;
                courseSubMenu.Top = btnCourses.Top;
                courseSubMenu.Show(btnCourses.Left + btnCourses.Width, btnCourses.Top);
            }
            catch (Exception)
            {

                throw;
            }
        }
        private void Container_Shown(object sender, EventArgs e)
        {
            btnDashboard.PerformClick();
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            if (_dashboard == null) _dashboard = new PgDashboard();

            ShowPage(_dashboard);
        }

        private void btnCourses_MouseHover(object sender, EventArgs e)
        {
            showCourseSubMenu();
        }

        private void btnCourses_Click(object sender, EventArgs e)
        {
            showCourseSubMenu();
        }

        private void btnCourse_Click(object sender, EventArgs e)
        {
            if (_course == null) _course = new PgCourse();

            ShowPage(_course);
        }
    }
}
