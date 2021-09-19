using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace WsSchool.Core.Models.Mysql
{
    public partial class TbStudent
    {
        public TbStudent()
        {
            TbGradebook = new HashSet<TbGradebook>();
        }

        public int StudentId { get; set; }
        public int? PersonId { get; set; }
        public string Classroom { get; set; }

        public virtual TbPerson Person { get; set; }
        public virtual ICollection<TbGradebook> TbGradebook { get; set; }
    }
}
