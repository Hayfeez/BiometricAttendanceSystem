using StudentAttendance.Model;
using StudentAttendance.Model.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentAttendance.Repository
{
   public class CourseRegRepo
    {
        public int SaveCourseReg(CourseRegistration model)
        {
            try
            {
                using (var context = new BASContext())
                {
                    if (context.CourseRegistrations.Any(a => a.StudentId == model.StudentId && a.CourseId == model.CourseId && a.SessionSemesterId == model.SessionSemesterId))
                        return 0;

                    context.CourseRegistrations.Add(model);
                    if (context.SaveChanges() > 0) return 1;

                    return -1;

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<CourseRegistration> GetCoursesByStudent(int studentId, int semesterId)
        {
            try
            {
                using (var context = new BASContext())
                {
                    var dt = (from att in context.CourseRegistrations
                              where att.StudentId == studentId && att.SessionSemesterId == semesterId
                              select att).ToList();
                    return dt;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<CourseRegistration> GetStudentsByCourses(int courseId, int semesterId)
        {
            try
            {
                using (var context = new BASContext())
                {
                    var dt = (from att in context.CourseRegistrations
                              where att.CourseId == courseId && att.SessionSemesterId == semesterId
                              select att).ToList();
                    return dt;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
