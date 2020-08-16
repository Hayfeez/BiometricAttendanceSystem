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
using StudentAttendance.Classes;
using StudentAttendance.Pages;

namespace StudentAttendance.Forms
{
    public partial class Container : MaterialForm
    {
       // private readonly MaterialSkinManager MaterialWinformsManager;
       
        #region Pages
        private PgDashboard _dashboardPage;
        private SessionSemesterList _sessionPage;
        private DepartmentList _deptPage;
        private CoursesList _coursePage;


        #endregion

        public Container()
        {
            if (LoggedInUser.UserId == 0)
            {   
                FrmLogin loginForm = new FrmLogin();
                loginForm.Show();
            }
            else
            {
                InitializeComponent();
                MaterialSkinBase.InitializeForm(this); // Initialize MaterialWinformsManager
                foreach (MaterialFlatButton button in this.MenuControls())
                {
                    button.Capitalized = false;
                }
                lblFullname.Text = LoggedInUser.Fullname;
                lblAdmin.Text = LoggedInUser.IsAdmin ? "Admin" : "";
            }
        }
        
        private List<MaterialFlatButton> MenuControls()
        {
            var btns = new List<MaterialFlatButton>();

            btns.Add(btnDashboard);
            btns.Add(btnCourseMgt);
            btns.Add(btnAttendance);
            btns.Add(btnDept);
            btns.Add(btnReport);
            btns.Add(btnSemester);
            btns.Add(btnSettings);
            btns.Add(btnUserMgt);

            return btns;
        }

        private void ShowPage(Control page)
        {
            if (page != null)
            {
                if (cardMain.Size != page.Size)
                {
                    //page.Size = pnlMain.Size;
                    page.Width = cardMain.Width;
                    page.Height = cardMain.Height - 20;
                }

                cardMain.Controls.Clear();
                cardMain.Controls.Add(page);
            }
        }

        private void ShowSubMenu(MaterialFlatButton btnSender, MaterialContextMenuStrip submenu)
        {
            Point ptLowerLeft = new Point(10, (btnSender.Height + 10));
            ptLowerLeft = btnSender.PointToScreen(ptLowerLeft);
            submenu.Show(ptLowerLeft);
        }

        private void SetActiveMenu(MaterialFlatButton btn)
        {
            if (btn != null)
            {
                //clear all at first
                foreach (MaterialFlatButton button in this.MenuControls())
                {
                    button.Selected = false;
                    button.Capitalized = false;
                    button.ForeColor = Color.Black;
                }

                // set active
                btn.ForeColor = Color.Aqua;
                btn.Selected = true;
                btn.Capitalized = true;

            }
        }

        private void Container_Load(object sender, EventArgs e)
        {
            ShowDashboard();
        }

        private void ShowDashboard()
        {
            //_dashboardPage ??= new PgDashboard();
            _dashboardPage = new PgDashboard();
            ShowPage(_dashboardPage);

            SetActiveMenu(btnDashboard);
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            ShowDashboard();
        }

        private void btnDept_Click(object sender, EventArgs e)
        {
            ShowPage(new DepartmentList());
            SetActiveMenu(btnDept);
        }

        private void btnSemester_Click(object sender, EventArgs e)
        {
            ShowPage(new SessionSemesterList());
            SetActiveMenu(btnSemester);
        }

        private void btnCourseMgt_Click(object sender, EventArgs e)
        {
            ShowSubMenu((MaterialFlatButton)sender, subMenuCourse);
        }
        private void btnCourseMgt_MouseHover(object sender, EventArgs e)
        {
            btnCourseMgt.PerformClick();
        }

        private void mniCourse_Click(object sender, EventArgs e)
        {
            ShowPage(new CoursesList());
            SetActiveMenu(btnCourseMgt);
        }

        private void mniCourseReg_Click(object sender, EventArgs e)
        {

            SetActiveMenu(btnCourseMgt);
        }

        private void mniCourseLec_Click(object sender, EventArgs e)
        {

            SetActiveMenu(btnCourseMgt);
        }

        private void btnUserMgt_MouseHover(object sender, EventArgs e)
        {
            btnUserMgt.PerformClick();
        }

        private void btnUserMgt_Click(object sender, EventArgs e)
        {
            ShowSubMenu((MaterialFlatButton)sender, subMenuUser);
        }

        private void mniStudent_Click(object sender, EventArgs e)
        {

            SetActiveMenu(btnUserMgt);
        }

        private void mniStaff_Click(object sender, EventArgs e)
        {

            SetActiveMenu(btnUserMgt);
        }
        private void btnSettings_Click(object sender, EventArgs e)
        {
            SetActiveMenu(btnSettings);
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            SetActiveMenu(btnReport);
        }

        private void btnAttendance_Click(object sender, EventArgs e)
        {
            SetActiveMenu(btnAttendance);
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void subMenuCourse_MouseLeave(object sender, EventArgs e)
        {
            subMenuCourse.Hide();
        }

        private void subMenuUser_MouseLeave(object sender, EventArgs e)
        {
            subMenuUser.Hide();
        }

        private void Container_SizeChanged(object sender, EventArgs e)
        {
            ShowDashboard();
        }
    }
}
