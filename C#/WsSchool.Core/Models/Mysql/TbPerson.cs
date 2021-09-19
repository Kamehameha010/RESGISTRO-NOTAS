using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace WsSchool.Core.Models.Mysql
{
    public partial class TbPerson
    {
        public TbPerson()
        {
            TbStudent = new HashSet<TbStudent>();
            TbTeacher = new HashSet<TbTeacher>();
        }

        public int PersonId { get; set; }
        public int? Nid { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public int LoginId { get; set; }

        public virtual TbLogin Login { get; set; }
        public virtual ICollection<TbStudent> TbStudent { get; set; }
        public virtual ICollection<TbTeacher> TbTeacher { get; set; }
    }
}
