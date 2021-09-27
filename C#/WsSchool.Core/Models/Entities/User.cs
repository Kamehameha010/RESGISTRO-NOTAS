using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace WsSchool.Core.Models.Entities
{
    public partial class User
    {
        
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int? RolId { get; set; }
        public int? PersonId { get; set; }
        public virtual Rol Rol { get; set; }
        public virtual Person Person { get; set; }


    }
}
