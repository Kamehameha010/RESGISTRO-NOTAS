using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace WsSchool.Core.Models.Mysql
{
    public partial class Person
    {
        public Person()
        {
            TbStudent = new HashSet<Student>();
            TbTeacher = new HashSet<Teacher>();
        }

        public int PersonId { get; set; }
        public int? Nid { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public int? LoginId { get; set; }

        public virtual Login Login { get; set; }
        public virtual ICollection<Student> TbStudent { get; set; }
        public virtual ICollection<Teacher> TbTeacher { get; set; }
    }
}
