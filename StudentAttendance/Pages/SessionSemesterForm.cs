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
    public partial class SessionSemesterForm : MaterialForm
    {
        private readonly SessionSemesterRepo _semesterRepo;

        public SessionSemesterForm(SessionSemester data = null)
        {
            InitializeComponent();
            _semesterRepo = new SessionSemesterRepo();
            if (data != null)
            {
                lblId.Text = data.Id.ToString();
                txtSession.Text = data.Session;
                txtSemester.Text = data.Semester;
                chkIsActive.Checked = data.IsActive;
                lblTitle.Text = "Update Session/Semester";
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (PassedValidation())
                {
                    var model = new SessionSemester()
                    {
                        Session = txtSession.Text.ToTitleCase(),
                        Semester = txtSemester.Text.ToTitleCase(),
                        IsActive = chkIsActive.Checked
                    };

                    if (model.IsActive)
                    {
                        DialogResult result1 = MessageBox.Show(
                            "Are you sure you want to make this the active session/semester?",
                            "Confirm Active",
                            MessageBoxButtons.YesNo);
                        if (result1 == DialogResult.Yes)
                        {
                            PerformSave(model);
                        }
                    }
                    else
                    {
                        PerformSave(model);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Error occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void PerformSave(SessionSemester model)
        {
            string response;
            if (lblId.Text == string.Empty) //add
            {
                response = _semesterRepo.AddSessionSemester(model);
                if (response == string.Empty)
                {
                    MessageBox.Show(this, "Session/Semester added successfully", "Success",
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
                response = _semesterRepo.UpdateSessionSemester(model);
                if (response == string.Empty)
                {
                    MessageBox.Show(this, "Session/Semester updated successfully", "Success",
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

        private void ClearControls()
        {
            lblId.Text = string.Empty;
            txtSession.Text = "";
            txtSemester.Text = "";
            chkIsActive.Checked = false;
        }

        private bool PassedValidation()
        {
            bool passed = false;
            if(txtSession.Text == "") 
                MessageBox.Show(this, "Session is required", "Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (txtSemester.Text == "")
                MessageBox.Show(this, "Semester is required", "Required", MessageBoxButtons.OK,
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
