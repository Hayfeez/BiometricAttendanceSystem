using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaterialWinforms.Controls;
using StudentAttendance.Model;
using StudentAttendance.Repository;

namespace StudentAttendance.Classes
{
    public static class DropdownControls
    {
        public static void BindDepartments(ref MaterialComboBox drpdownDept, bool includeAll = false)
        {
            var _deptRepo = new DepartmentRepo();
            var alldepts = _deptRepo.GetAllDepartments();

           
            if (includeAll)
                alldepts.Insert(0, new Department {Id = 0, DepartmentName = "All Departments"});
            else
                alldepts.Insert(0, new Department { Id = -1, DepartmentName = "Select Department" });

            drpdownDept.DataSource = alldepts;
            drpdownDept.DisplayMember = "DepartmentName";
            drpdownDept.ValueMember = "Id";
            drpdownDept.SelectedIndex = 0;
        }
    }
}
