using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace WsSchool.Core.Models.Mysql
{
    public partial class TbGradebook
    {
        public int GradebookId { get; set; }
        public int? StudentId { get; set; }
        public decimal? Q1 { get; set; }
        public decimal? Q2 { get; set; }
        public decimal? Q3 { get; set; }
        public decimal? Average { get; set; }
        public int? TeacherId { get; set; }
        public int? CourseId { get; set; }
        public byte? State { get; set; }

        public virtual TbCourse Course { get; set; }
        public virtual TbStudent Student { get; set; }
        public virtual TbTeacher Teacher { get; set; }
    }
}
