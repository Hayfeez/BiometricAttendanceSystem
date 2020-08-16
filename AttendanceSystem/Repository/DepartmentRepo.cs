
using AttendanceSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceSystem.Repository
{
    public class DepartmentRepo
    {
        public string AddDepartment(Department newDepartment)
        {
            try
            {
                using (var context = new BASContext())
                {
                    if (context.Departments.Any(a => a.DepartmentCode == newDepartment.DepartmentCode || a.DepartmentName == newDepartment.DepartmentName  && !a.IsDeleted))
                        return "Department with this name or Department Code exists";

                    context.Departments.Add(newDepartment);
                    if (context.SaveChanges() > 0) return "Department added successfully";
                    return "Department could not be added";

                }                    
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string DeleteDepartment(int DepartmentId)
        {
            using (var context = new BASContext())
            {
                if (context.Courses.Any(a => a.DepartmentId == DepartmentId))
                    return "Department cannot be deleted because it has courses";

                var Department = context.Departments.SingleOrDefault(a => a.Id == DepartmentId);
                if (Department != null)
                {
                    Department.IsDeleted = true;
                    if (context.SaveChanges() > 0) return "Department deleted successfully";
                    return "Department could not be deleted";
                }

                return "Department not found";
            }                            
            
        }

        public List<Department> GetAllDepartments()
        {
            try
            {
                using (var context = new BASContext())
                {                    
                    return context.Departments.Where(a => !a.IsDeleted).ToList();                   
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Department GetDepartment(int DepartmentId)
        {
            try
            {
                using (var context = new BASContext())
                {
                    return context.Departments.SingleOrDefault(a => a.Id == DepartmentId  && !a.IsDeleted);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }       

        public string UpdateDepartment(Department Department)
        {
            using (var context = new BASContext())
            {
                var oldDepartment = context.Departments.SingleOrDefault(a => a.Id == Department.Id && !a.IsDeleted);
                if (oldDepartment == null)
                    return "Department not found";

                if (context.Departments.Any(a => a.DepartmentName == Department.DepartmentName || a.DepartmentCode == Department.DepartmentCode  && !a.IsDeleted && a.Id != Department.Id))
                    return "Department with this Name or Department Code exists";

                oldDepartment.DepartmentCode = Department.DepartmentCode;
                oldDepartment.DepartmentName = Department.DepartmentName;

                if (context.SaveChanges() > 0) return "Department details updated successfully";
                return "Department details could not be updated";
            }
        }

    }
}
