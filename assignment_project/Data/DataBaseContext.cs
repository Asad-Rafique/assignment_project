using Microsoft.EntityFrameworkCore;

namespace assignment_project.Data
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {
            

        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        // Add other DbSet properties for additional entities


        // In your Data/DataBaseContext.cs or similar
        public List<ClassInfo> GetClassesWithMoreThan100Students()
        {
            return Classes
                .Where(c =>
                {
                    return c.Enrollments.Count() > 100;
                })
                .Select(c => new ClassInfo { ClassName = c.Name, RoomNumber = c.RoomNumber })
                .ToList();
        }

        // Create a simple DTO (Data Transfer Object) to store the query result
        public class ClassInfo
        {
            public string ClassName { get; set; }
            public string RoomNumber { get; set; }
        }


        public List<StudentInfo> GetStudentsWithNoClassesInDept22()
        {
            return Students
                .Where(s => !s.Enrollments.Any(e => e.Class.Teacher.DeptId == 22))
                .Select(s => new StudentInfo { StudentId = s.Sid, Major = s.Major })
                .ToList();
        }

        public class StudentInfo
        {
            public int StudentId { get; set; }
            public string Major { get; set; }
        }




        public List<string> GetStudentsWithNoMarks()
        {
            return Students
                .Where(s => s.Enrollments.Any(e => e.Marks.Count() == 0))
                .Select(s => s.Sname)
                .ToList();
        }



        public List<MajorAverageAge> GetAverageAgePerMajor()
        {
            return Students
                .GroupBy(s => s.Major)
                .Select(g => new MajorAverageAge
                {
                    Major = g.Key,
                    AverageAge = g.Average(s =>  )
                }) 
                .ToList();
        }

        // Create a simple DTO (Data Transfer Object) to store the query result
        public class MajorAverageAge
        {
            public string Major { get; set; }
            public double AverageAge { get; set; }
        }

        public List<StudentEnrollmentCount> GetStudentsEnrolledInMoreThanTwoClasses()
        {
            return Students
                .Where(s => s.Enrollments.Count() > 2)
                .Select(s => new StudentEnrollmentCount
                {
                    StudentName = s.Sname,
                    EnrollmentsCount = s.Enrollments.Count()
                })
                .ToList();
        }

        // Create a simple DTO (Data Transfer Object) to store the query result
        public class StudentEnrollmentCount
        {
            public string StudentName { get; set; }
            public int EnrollmentsCount { get; set; }
        }

        public List<FacultyClassCount> GetFacultyClassCount()
        {
            return Faculties
                .Select(f => new FacultyClassCount
                {
                    FacultyName = f.Fname,
                    TotalClasses = f.Classes.Count()
                })
                .OrderByDescending(fc => fc.TotalClasses)
                .ToList();
        }

        // Create a simple DTO (Data Transfer Object) to store the query result
        public class FacultyClassCount
        {
            public string FacultyName { get; set; }
            public int TotalClasses { get; set; }
        }



        public List<string> GetStudentsInComputerScienceClasses()
        {
            return Students
                .Where(s => s.Enrollments.Any(e => e.Class.Teacher.DeptId == ))
                .Select(s => s.Sname)
                .ToList();
        }






    }
}
