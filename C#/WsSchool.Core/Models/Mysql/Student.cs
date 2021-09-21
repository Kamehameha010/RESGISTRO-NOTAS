using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace WsSchool.Core.Models.Mysql
{
    public partial class Student
    {
        public Student()
        {
            TbGradebook = new HashSet<Gradebook>();
        }

        public int StudentId { get; set; }
        public int? PersonId { get; set; }
        public string Classroom { get; set; }

        public virtual Person Person { get; set; }
        public virtual ICollection<Gradebook> TbGradebook { get; set; }
    }
}
