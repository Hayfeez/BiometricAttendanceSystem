using StudentAttendance.Model;
using StudentAttendance.Model.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentAttendance.Repository
{
    public class StudentRepo
    {
        public string AddStudent(StudentDetail newStudent)
        {
            try
            {
                using (var context = new BASContext())
                {
                    if (context.Students.Any(a => a.MatricNo == newStudent.MatricNo || a.Email == newStudent.Email && !a.IsDeleted))
                        return "Student with this Matric number or Email address exists";

                    context.Students.Add(newStudent);
                    if (context.SaveChanges() > 0) return "";
                    return "Student could not be added";

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string AddBulkStudent(List<BulkStudent> data, int levelId)
        {
            try
            {
                using (var context = new BASContext())
                {
                    return "";

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string DeleteStudent(int studentId)
        {
            using (var context = new BASContext())
            {
                if (context.CourseRegistrations.Any(a => a.StudentId == studentId))
                    return "Student cannot be deleted because (s)he has registered for a course";

                var student = context.Students.SingleOrDefault(a => a.Id == studentId);
                if (student != null)
                {
                    student.IsDeleted = true;
                    if (context.SaveChanges() > 0) return "";
                    return "Student could not be deleted";
                }

                return "Student not found";
            }

        }

        public string GraduateStudent(int studentId)
        {
            using (var context = new BASContext())
            {
                
                var student = context.Students.SingleOrDefault(a => a.Id == studentId);
                if (student != null)
                {
                    student.IsGraduated = true;
                    if (context.SaveChanges() > 0) return "";
                    return "Operation could not be performed";
                }

                return "Student not found";
            }

        }

        public List<StudentDetail> GetAllStudents(bool isGraduate = false)
        {
            try
            {
                using (var context = new BASContext())
                {
                    return context.Students.Where(a => !a.IsDeleted && a.IsGraduated == isGraduate).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<StudentDetail> GetAllDepartmentStudents(int departmentId, bool isGraduate = false)
        {
            try
            {
                using (var context = new BASContext())
                {
                    return context.Students.Where(a => !a.IsDeleted && a.DepartmentId == departmentId && a.IsGraduated == isGraduate).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public StudentDetail GetStudent(int studentId)
        {
            try
            {
                using (var context = new BASContext())
                {
                    return context.Students.SingleOrDefault(a => a.Id == studentId && !a.IsDeleted);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string UpdateStudent(StudentDetail student)
        {
            using (var context = new BASContext())
            {
                var oldStudent = context.Students.SingleOrDefault(a => a.Id == student.Id && !a.IsDeleted);
                if (oldStudent == null)
                    return "Student not found";

                if (context.Students.Any(a => a.MatricNo == student.MatricNo || a.Email == student.Email && !a.IsDeleted && a.Id != student.Id))
                    return "Student with this Matric number or Email address exists";

                oldStudent.Email = student.Email;
                oldStudent.Firstname = student.Firstname;
                oldStudent.Lastname = student.Lastname;
                oldStudent.Othername = student.Othername;
                oldStudent.MatricNo = student.MatricNo;
                oldStudent.PhoneNo = student.PhoneNo;
                oldStudent.DepartmentId = student.DepartmentId;
                
                if (context.SaveChanges() > 0) return "";
                return "Student details could not be updated";
            }
        }
    }
}
