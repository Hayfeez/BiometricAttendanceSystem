using AttendanceSystem.Model;
using AttendanceSystem.Model.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceSystem.Repository
{
   public class AttendanceRepo
    {
        public int SaveAttendance(int CourseId, int StudentId, int SemesterId, int markedBy)
        {
            try
            {
                using (var context = new BASContext())
                {
                    var dateMarked = DateTime.Now;
                    //get courseregId
                    var coursseRegId = context.CourseRegistrations.Single(a => a.CourseId == CourseId && a.SessionSemesterId == SemesterId && a.StudentId == StudentId).Id;
                    
                    if (context.Attendances.Any(a => a.CourseRegistrationId == coursseRegId && a.DateMarked.Date == dateMarked.Date))
                        return 0;

                    context.Attendances.Add(new Attendance { 
                        CourseRegistrationId = coursseRegId,
                        DateMarked = dateMarked,
                        MarkedBy = markedBy                        
                    });
                    if (context.SaveChanges() > 0) return 1;

                    return -1;

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<AttendanceViewModel> GetAttendanceByCourse(int courseId)
        {
            try
            {
                using (var context = new BASContext())
                {
                    var dt = (from att in context.Attendances
                              join reg in context.CourseRegistrations on att.CourseRegistrationId equals reg.Id
                              join st in context.Students on reg.StudentId equals st.Id
                              join c in context.Courses on reg.CourseId equals c.Id
                              join s in context.SessionSemesters on reg.SessionSemesterId equals s.Id
                              join le in context.Levels on reg.LevelId equals le.Id
                              join dep in context.Departments on st.DepartmentId equals dep.Id
                              join l in context.Staff on att.MarkedBy equals l.Id
                              where reg.CourseId == courseId
                              select new AttendanceViewModel
                              {
                                  Id = att.Id,
                                  StudentMatricNo = st.MatricNo,
                                  StudentName = string.Format("{0} {1} {2}", st.Lastname, st.Firstname, st.Othername),
                                  StudentLevel = le.Level,
                                  Course = c.CourseCode + " - " + c.CourseTitle ,
                                  DateMarked = att.DateMarked.Date,
                                  MarkedBy = string.Format("{0} {1} {2}", l.Lastname, l.Firstname, l.Othername),
                                  SessionSemester = string.Format("{0} - {1}", s.Session, s.Semester),
                                  DepartmentName = dep.DepartmentName,
                                  TimeIn = att.DateMarked.ToShortTimeString()
                              }
                              ).ToList();
                    return dt;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<AttendanceViewModel> GetTodayAttendanceByCourse(int courseId)
        {
            try
            {
                using (var context = new BASContext())
                {
                    var dt = (from att in context.Attendances
                              join reg in context.CourseRegistrations on att.CourseRegistrationId equals reg.Id
                              join st in context.Students on reg.StudentId equals st.Id
                             // join c in context.Courses on reg.CourseId equals c.Id
                             // join s in context.SessionSemesters on reg.SessionSemesterId equals s.Id
                            //  join le in context.Levels on reg.LevelId equals le.Id
                            //  join dep in context.Departments on st.DepartmentId equals dep.Id
                             // join l in context.Staff on att.MarkedBy equals l.Id
                              where reg.CourseId == courseId  && att.DateMarked.Date == DateTime.Now.Date
                              select new AttendanceViewModel
                              {
                                  Id = att.Id,
                                  StudentMatricNo = st.MatricNo,
                                  StudentName = string.Format("{0} {1} {2}", st.Lastname, st.Firstname, st.Othername),
                                  DateMarked = att.DateMarked.Date,
                                  TimeIn = att.DateMarked.ToShortTimeString()
                                 }
                              ).ToList();
                    return dt;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<AttendanceViewModel> GetAttendanceByStudent(int studentId)
        {
            try
            {
                using (var context = new BASContext())
                {
                    var dt = (from att in context.Attendances
                              join reg in context.CourseRegistrations on att.CourseRegistrationId equals reg.Id
                              join st in context.Students on reg.StudentId equals st.Id
                              join c in context.Courses on reg.CourseId equals c.Id
                              join s in context.SessionSemesters on reg.SessionSemesterId equals s.Id
                              join le in context.Levels on reg.LevelId equals le.Id
                              join dep in context.Departments on st.DepartmentId equals dep.Id
                              join l in context.Staff on att.MarkedBy equals l.Id
                              where reg.StudentId == studentId
                              select new AttendanceViewModel
                              {
                                  Id = att.Id,
                                  StudentMatricNo = st.MatricNo,
                                  StudentName = string.Format("{0} {1} {2}", st.Lastname, st.Firstname, st.Othername),
                                  StudentLevel = le.Level,
                                  Course = c.CourseCode + " - " + c.CourseTitle,
                                  DateMarked = att.DateMarked.Date,
                                  MarkedBy = string.Format("{0} {1} {2}", l.Lastname, l.Firstname, l.Othername),
                                  SessionSemester = string.Format("{0} - {1}", s.Session, s.Semester),
                                  DepartmentName = dep.DepartmentName,
                                  TimeIn = att.DateMarked.ToShortTimeString()
                              }
                              ).ToList();
                    return dt;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<AttendanceViewModel> GetAttendanceByStudentForCourse(int studentId, int courseId)
        {
            try
            {
                using (var context = new BASContext())
                {
                    var dt = (from att in context.Attendances
                              join reg in context.CourseRegistrations on att.CourseRegistrationId equals reg.Id
                              join st in context.Students on reg.StudentId equals st.Id
                              join c in context.Courses on reg.CourseId equals c.Id
                              join s in context.SessionSemesters on reg.SessionSemesterId equals s.Id
                              join le in context.Levels on reg.LevelId equals le.Id
                              join dep in context.Departments on st.DepartmentId equals dep.Id
                              join l in context.Staff on att.MarkedBy equals l.Id
                              where reg.StudentId == studentId && reg.CourseId == courseId
                              select new AttendanceViewModel
                              {
                                  Id = att.Id,
                                  StudentMatricNo = st.MatricNo,
                                  StudentName = string.Format("{0} {1} {2}", st.Lastname, st.Firstname, st.Othername),
                                  StudentLevel = le.Level,
                                  Course = c.CourseCode + " - " + c.CourseTitle,
                                  DateMarked = att.DateMarked.Date,
                                  MarkedBy = string.Format("{0} {1} {2}", l.Lastname, l.Firstname, l.Othername),
                                  SessionSemester = string.Format("{0} - {1}", s.Session, s.Semester),
                                  DepartmentName = dep.DepartmentName,
                                  TimeIn = att.DateMarked.ToShortTimeString()
                              }
                              ).ToList();
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
