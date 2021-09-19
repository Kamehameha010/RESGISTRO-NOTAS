using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace WsSchool.Core.Models.Mysql
{
    public partial class TbRol
    {
        public TbRol()
        {
            TbLogin = new HashSet<TbLogin>();
        }

        public int RolId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<TbLogin> TbLogin { get; set; }
    }
}
