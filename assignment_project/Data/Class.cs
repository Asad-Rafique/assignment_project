using System.ComponentModel.DataAnnotations;

namespace assignment_project.Data
{
    public class Class
    {
        [Key]
        public int Cid { get; set; }
        public string Name { get; set; }
        public string RoomNumber { get; set; }
        public int Fid { get; set; }
        public Faculty Teacher { get; set; }
        public object Enrollments { get; internal set; }
        //  public List<Enrollment> Enrollments { get; set; }

    }
}
