using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace WsSchool.Core.Models.Postgresql
{
    public partial class Login
    {
        public Login()
        {
            TbPerson = new HashSet<Person>();
        }

        public int Loginid { get; set; }
        public string Username { get; set; }
        public string Passsword { get; set; }
        public int Rolid { get; set; }

        public virtual Rol Rol { get; set; }
        public virtual ICollection<Person> TbPerson { get; set; }
    }
}
