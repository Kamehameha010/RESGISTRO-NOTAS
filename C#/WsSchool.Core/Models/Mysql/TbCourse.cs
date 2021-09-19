using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace WsSchool.Core.Models.Mysql
{
    public partial class TbCourse
    {
        public TbCourse()
        {
            TbGradebook = new HashSet<TbGradebook>();
        }

        public int CourseId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int? CourseStatusId { get; set; }

        public virtual TbCourseStatus CourseStatus { get; set; }
        public virtual ICollection<TbGradebook> TbGradebook { get; set; }
    }
}
