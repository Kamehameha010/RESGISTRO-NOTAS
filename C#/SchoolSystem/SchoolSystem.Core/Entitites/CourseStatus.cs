﻿using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SchoolSystem.Core.Entities
{
    public partial class CourseStatus
    {
        public CourseStatus()
        {
            Courses = new HashSet<Course>();
        }

        public int CourseStatusId { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Course> Courses { get; set; }
    }
}
