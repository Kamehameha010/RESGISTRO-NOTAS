using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SchoolSystem.Core.Entities
{
    public partial class Student 
    {
        public Student()
        {
            CourseGradebooks = new HashSet<CourseGradebook>();
        }

        public int StudentId { get; set; }
        public int? UserId { get; set; }
        public string Classroom { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<CourseGradebook> CourseGradebooks { get; set; }
    }
}
