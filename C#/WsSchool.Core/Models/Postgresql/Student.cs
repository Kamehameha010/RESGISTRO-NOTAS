using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace WsSchool.Core.Models.Postgresql
{
    public partial class Student
    {
        public Student()
        {
            TbGradebook = new HashSet<Gradebook>();
        }

        public int Studentid { get; set; }
        public int? Personid { get; set; }
        public string Classroom { get; set; }

        public virtual Person Person { get; set; }
        public virtual ICollection<Gradebook> TbGradebook { get; set; }
    }
}
