using System.ComponentModel.DataAnnotations;

namespace assignment_project.Data
{
    public class Student
    {
        [Key]
        public int Sid { get; set; }
        public string Sname { get; set; }
        public string Major { get; set; }
        public string Standing { get; set; }
        public object Enrollments { get; internal set; }
        //  public List<Enrollment> Enrollments { get; set; }

    }
}
