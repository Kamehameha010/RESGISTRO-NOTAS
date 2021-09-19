using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace WsSchool.Core.Models.Mysql
{
    public partial class TbLogin
    {
        public TbLogin()
        {
            TbPerson = new HashSet<TbPerson>();
        }

        public int LoginId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int PersonId { get; set; }
        public int RolId { get; set; }

        public virtual TbRol Rol { get; set; }
        public virtual ICollection<TbPerson> TbPerson { get; set; }
    }
}
