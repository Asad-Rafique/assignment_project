using System.ComponentModel.DataAnnotations;

namespace assignment_project.Data
{
    
    
        public class Mark
        {
            [Key]
            public int MarkId { get; set; }
            public int EnrolledCid { get; set; }
            public string Enrolled { get; set; }
            // Additional mark-related properties
        }

    
}
