using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace WsSchool.Core.Models.Mysql
{
    public partial class TbCourseStatus
    {
        public TbCourseStatus()
        {
            TbCourse = new HashSet<TbCourse>();
        }

        public int CourseStatusId { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }

        public virtual ICollection<TbCourse> TbCourse { get; set; }
    }
}
