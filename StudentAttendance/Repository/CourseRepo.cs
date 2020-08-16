
using StudentAttendance.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentAttendance.Model.ViewModels;

namespace StudentAttendance.Repository
{
    public class CourseRepo
    {
        public string AddCourse(Course newCourse)
        {
            try
            {
                using (var context = new BASContext())
                {
                    if (context.Courses.Any(a => a.CourseCode == newCourse.CourseCode || a.CourseTitle == newCourse.CourseTitle && a.DepartmentId == newCourse.DepartmentId && !a.IsDeleted))
                        return "Course with this Title or Course Code exists";

                    context.Courses.Add(newCourse);
                    if (context.SaveChanges() > 0) return "";
                    return "Course could not be added";

                }                    
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string DeleteCourse(int courseId)
        {
            using (var context = new BASContext())
            {
                if (context.CourseRegistrations.Any(a => a.CourseId == courseId))
                    return "Course cannot be deleted because it has course registration records";

                var course = context.Courses.SingleOrDefault(a => a.Id == courseId);
                if (course != null)
                {
                    //context.Staff.Remove(staff);
                    course.IsDeleted = true;
                    if (context.SaveChanges() > 0) return "";
                    return "Course could not be deleted";
                }

                return "Course not found";
            }                            
            
        }

        public List<CourseViewModel> GetAllCourses()
        {
            try
            {
                using (var context = new BASContext())
                {
                    var d = (from c in context.Courses
                        where !c.IsDeleted
                        join dp in context.Departments on c.DepartmentId equals dp.Id
                        select new CourseViewModel()
                        {
                            Department = dp.DepartmentName,
                            Id = c.Id,
                            CourseCode = c.CourseCode,
                            CourseTitle = c.CourseTitle
                        }).ToList();

                    return d;                   
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<CourseViewModel> GetAllDepartmentCourses(int departmentId)
        {
            try
            {
                using (var context = new BASContext())
                {
                    var d = (from c in context.Courses
                        where !c.IsDeleted && c.DepartmentId == departmentId
                        join dp in context.Departments on c.DepartmentId equals dp.Id
                        select new CourseViewModel()
                        {
                            Department = dp.DepartmentName,
                            Id = c.Id,
                            CourseCode = c.CourseCode,
                            CourseTitle = c.CourseTitle
                        }).ToList();

                    return d;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Course GetCourse(int courseId)
        {
            try
            {
                using (var context = new BASContext())
                {
                    return context.Courses.SingleOrDefault(a => a.Id == courseId  && !a.IsDeleted);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }       

        public string UpdateCourse(Course course)
        {
            using (var context = new BASContext())
            {
                var oldCourse = context.Courses.SingleOrDefault(a => a.Id == course.Id && !a.IsDeleted);
                if (oldCourse == null)
                    return "Course not found";

                if (context.Courses.Any(a => a.CourseTitle == course.CourseTitle || a.CourseCode == course.CourseCode  && !a.IsDeleted && a.Id != course.Id))
                    return "Course with this Title or Course Code exists";

                //oldCourse.DepartmentId = course.DepartmentId;
                oldCourse.CourseCode = course.CourseCode;
                oldCourse.CourseTitle = course.CourseTitle;

                if (context.SaveChanges() > 0) return "";
                return "No changes made";
            }
        }

    }
}
