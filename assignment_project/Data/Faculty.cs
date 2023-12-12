using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace assignment_project.Data
{
    public class Faculty
    {
        [Key]
        public int Fid { get; set; }
        public string Fname { get; set; }
        public int DeptId { get; set; }
        public string Standing { get; set; }
        public object Classes { get; internal set; }
        // public List<Class> Classes { get; set; }
    }
}
