using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialWinforms.Controls;
using StudentAttendance.Classes;
using StudentAttendance.Model;
using StudentAttendance.Repository;

namespace StudentAttendance.Pages
{
    public partial class CoursesForm : MaterialForm
    {
        private readonly CourseRepo _courseRepo;

        public CoursesForm(Course data = null)
        {
            InitializeComponent();
            _courseRepo = new CourseRepo();
            DropdownControls.BindDepartments(ref drpdownDept);

            if (data != null)
            {
                lblId.Text = data.Id.ToString();
                txtCourseTitle.Text = data.CourseTitle;
                txtCourseCode.Text = data.CourseCode;
                drpdownDept.SelectedValue = data.DepartmentId;
                drpdownDept.Enabled = false;
                lblTitle.Text = "Update Course";
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (PassedValidation())
                {
                    var model = new Course()
                    {
                        DepartmentId = int.Parse(drpdownDept.SelectedValue.ToString()),
                        CourseTitle = txtCourseTitle.Text.ToTitleCase(),
                        CourseCode = txtCourseCode.Text.ToUpper()
                    };

                    string response;
                    if (lblId.Text == string.Empty) //add
                    {
                        response = _courseRepo.AddCourse(model);
                        if (response == string.Empty)
                        {
                            MessageBox.Show(this, "Course added successfully", "Success",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                            ClearControls();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show(this, response, "Failed", MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                        }
                    }
                    else //update
                    {
                        model.Id = int.Parse(lblId.Text);
                        response = _courseRepo.UpdateCourse(model);
                        if (response == string.Empty)
                        {
                            MessageBox.Show(this, "Course updated successfully", "Success",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                            ClearControls();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show(this, response, "Failed", MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Error occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

    

        private void ClearControls()
        {
            lblId.Text = string.Empty;
            txtCourseTitle.Text = "";
            txtCourseCode.Text = "";
            drpdownDept.SelectedValue = -1;
        }

        private bool PassedValidation()
        {
            bool passed = false;
            if (drpdownDept.SelectedValue.ToString() == "-1")
                MessageBox.Show(this, "Department is required", "Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (txtCourseTitle.Text == "") 
                MessageBox.Show(this, "Course Title is required", "Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (txtCourseCode.Text == "")
                MessageBox.Show(this, "Course Code is required", "Required", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            else 
                passed = true;

            return passed;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ClearControls();
            this.Hide();
        }

     
    }


   
}
