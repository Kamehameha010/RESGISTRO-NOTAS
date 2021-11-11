using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SchoolSystem.Core.Entities
{
    public partial class Course 
    {
        public Course()
        {
            CourseGradebooks = new HashSet<CourseGradebook>();
        }

        public int CourseId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int? CourseStatusId { get; set; }

        public virtual CourseStatus CourseStatus { get; set; }
        public virtual ICollection<CourseGradebook> CourseGradebooks { get; set; }
    }
}
