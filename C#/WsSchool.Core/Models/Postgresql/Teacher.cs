using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace WsSchool.Core.Models.Postgresql
{
    public partial class Teacher
    {
        public Teacher()
        {
            TbGradebook = new HashSet<Gradebook>();
        }

        public int Teacherid { get; set; }
        public int? Personid { get; set; }
        public string Subject { get; set; }

        public virtual Person Person { get; set; }
        public virtual ICollection<Gradebook> TbGradebook { get; set; }
    }
}
