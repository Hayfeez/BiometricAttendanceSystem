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
    public partial class DepartmentForm : MaterialForm
    {
        private readonly DepartmentRepo _deptRepo;

        public DepartmentForm(Department data = null)
        {
            InitializeComponent();
            _deptRepo = new DepartmentRepo();
            if (data != null)
            {
                lblId.Text = data.Id.ToString();
                txtDeptName.Text = data.DepartmentName;
                txtDeptCode.Text = data.DepartmentCode;
                lblTitle.Text = "Update Department";
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (PassedValidation())
                {
                    string response;
                    Department model = new Department
                    {
                        DepartmentName = txtDeptName.Text.ToTitleCase(),
                        DepartmentCode = txtDeptCode.Text.ToUpper(),
                    };
                    if (lblId.Text == string.Empty) //add
                    {
                        response = _deptRepo.AddDepartment(model);
                        if (response == string.Empty)
                        {
                            MessageBox.Show(this, "Department added successfully", "Success", MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                            ClearControls();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show(this, response, "Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else //update
                    {
                        model.Id = int.Parse(lblId.Text);
                        response = _deptRepo.UpdateDepartment(model);
                        if (response == string.Empty)
                        {
                            MessageBox.Show(this, "Department updated successfully", "Success", MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                            ClearControls();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show(this, response, "Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            txtDeptName.Text = "";
            txtDeptCode.Text = "";
        }

        private bool PassedValidation()
        {
            bool passed = false;
            if(txtDeptName.Text == "") 
                MessageBox.Show(this, "Department name is required", "Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (txtDeptCode.Text == "")
                MessageBox.Show(this, "Department code is required", "Required", MessageBoxButtons.OK,
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
