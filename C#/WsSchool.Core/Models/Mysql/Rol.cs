using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace WsSchool.Core.Models.Mysql
{
    public partial class Rol
    {
        public Rol()
        {
            TbLogin = new HashSet<Login>();
        }

        public int RolId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Login> TbLogin { get; set; }
    }
}
