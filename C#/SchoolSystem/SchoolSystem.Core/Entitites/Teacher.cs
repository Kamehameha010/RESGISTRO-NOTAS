using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SchoolSystem.Core.Entities
{
    public partial class Teacher
    {
        public Teacher()
        {
            CourseGradebooks = new HashSet<CourseGradebook>();
        }

        public int TeacherId { get; set; }
        public int? UserId { get; set; }
        public string Subject { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<CourseGradebook> CourseGradebooks { get; set; }
    }
}
