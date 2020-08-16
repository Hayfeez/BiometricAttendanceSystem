using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceSystem.Model
{
    public class BASContext : DbContext
    {

        public BASContext() : base("name=BASContext") {
            Database.SetInitializer<BASContext>(null);
        }

       
        public DbSet<Lecturer> Staff { get; set; }
        public DbSet<StudentDetail> Students { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseRegistration> CourseRegistrations { get; set; }
        public DbSet<PersonTitle> Titles { get; set; }
        public DbSet<SessionSemester> SessionSemesters { get; set; }
        public DbSet<StudentFinger> StudentFingers { get; set; }
        public DbSet<StudentLevel> Levels { get; set; }
        public DbSet<Department> Departments { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // if Database does not pluralize table names
            //modelBuilder.Conventions
            //    .Remove<PluralizingTableNameConvention>();
            modelBuilder.Entity<Lecturer>().ToTable("Lecturer");
            modelBuilder.Entity<StudentDetail>().ToTable("StudentDetail");
            modelBuilder.Entity<Attendance>().ToTable("Attendance");
            modelBuilder.Entity<Course>().ToTable("Course");
            modelBuilder.Entity<Department>().ToTable("Department");
            modelBuilder.Entity<CourseRegistration>().ToTable("CourseRegistration");
            modelBuilder.Entity<PersonTitle>().ToTable("PersonTitle");
            modelBuilder.Entity<SessionSemester>().ToTable("SessionSemester");
            modelBuilder.Entity<StudentFinger>().ToTable("StudentFinger");
            modelBuilder.Entity<StudentLevel>().ToTable("StudentLevel");
        }
    }
}
