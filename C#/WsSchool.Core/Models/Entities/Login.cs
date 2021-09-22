using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace WsSchool.Core.Models.Entities
{
    public partial class Login
    {
        public Login()
        {
            TbPerson = new HashSet<Person>();
        }

        public int LoginId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int? RolId { get; set; }

        public virtual Rol Rol { get; set; }
        public virtual ICollection<Person> TbPerson { get; set; }
    }
}
