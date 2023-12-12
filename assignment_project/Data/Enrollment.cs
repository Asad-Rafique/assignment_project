using System.ComponentModel.DataAnnotations;

namespace assignment_project.Data
{
    public class Enrollment
    {
        [Key]

        public int id { get; set; }
        public int Cid { get; set; }
        public Class Class { get; set; }
        public int Sid { get; set; }
        public Student Student { get; set; }
       // public List<Mark> Marks { get; set; }

    }
}
