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
using StudentAttendance.Model.ViewModels;
using StudentAttendance.Repository;

namespace StudentAttendance.Pages
{
    public partial class CoursesList : MaterialUserControl
    {
        private DataTable repData;
        private readonly CourseRepo _courseRepo;
        private int deptId = 0;
        public CoursesList()
        {
            InitializeComponent();
            _courseRepo = new CourseRepo();
            DropdownControls.BindDepartments(ref drpdownDept, true);
        }

        private void Form_Load(object sender, EventArgs e)
        {
            LoadCourses(deptId);
            Base.AddEditDeleteToGrid(ref grdData);
        }

        private void LoadCourses(int deptId)
        {
            try
            {
                List<CourseViewModel> data = deptId == 0 ?  _courseRepo.GetAllCourses() : _courseRepo.GetAllDepartmentCourses(deptId);

                if (data != null)
                {
                    grdData.DataSource = data;
                    if (grdData.Rows.Count > 0)
                    {
                        grdData.Columns["Id"].Visible = false;
                    }
                    else
                    {
                        //var dt = new DataTable();
                        //grdData.Columns.Clear();
                        //dt.Columns.Add("Message", typeof(string));
                        //dt.Rows.Add("No items found");
                        //grdData.DataSource = dt;
                       // MessageBox.Show(this, "No record found", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    repData = data.ConvertToDataTable();  //save records in datatable for searching, export etc
                    Base.ResizeGrid(ref grdData);

                }
            }
            catch (Exception e)
            {
                MessageBox.Show(this, e.Message, "Error occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnAddNew_Click(object sender, EventArgs e)
        {
            var addForm = new CoursesForm();
            addForm.ShowDialog();
            LoadCourses(deptId);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            var i = Base.SearchGrid(repData, txtSearch.Text.Trim());
            if (i != null)
            {
                grdData.DataSource = i;
                grdData.Refresh();
            }
        }

        private void grdData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var d = (DataGridView)sender;
                string df = d.SelectedCells[0].Value.ToString();
                //edit column 
                if (df == "Edit")
                {
                    int id = int.Parse(grdData.Rows[e.RowIndex].Cells["id"].Value.ToString());
                    var course = _courseRepo.GetCourse(id);
                    if (course != null)
                    {
                        var updateForm = new CoursesForm(course);
                        updateForm.ShowDialog();
                        //grdData.Refresh();
                        LoadCourses(deptId);
                    }

                }

                //delete column
                if (df == "Delete")      //(e.ColumnIndex == 1)
                {
                    DialogResult result1 = MessageBox.Show("Are you sure you want to delete this record?",
                        "Confirm Delete",
                        MessageBoxButtons.YesNo);
                    if (result1 == DialogResult.Yes)
                    {
                        int id = int.Parse(grdData.Rows[e.RowIndex].Cells["id"].Value.ToString());
                        string response = _courseRepo.DeleteCourse(id);
                        if (response == string.Empty)
                            MessageBox.Show(this, "Course deleted successfully", "Success", MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                        else
                            MessageBox.Show(this, response, "Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        LoadCourses(deptId);
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Error occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            deptId = int.Parse(drpdownDept.SelectedValue.ToString());
            if (deptId != -1)
                LoadCourses(deptId);
        }

   
    }
}
