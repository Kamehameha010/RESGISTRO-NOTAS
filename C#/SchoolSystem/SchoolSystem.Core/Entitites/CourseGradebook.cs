// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SchoolSystem.Core.Entities
{
    public partial class CourseGradebook
    {
        public int CourseGradebookId { get; set; }
        public int? StudentId { get; set; }
        public decimal Q1 { get; set; }
        public decimal Q2 { get; set; }
        public decimal Q3 { get; set; }
        public decimal? Average { get; set; }
        public int? TeacherId { get; set; }
        public int? CourseId { get; set; }
        public bool Status { get; set; } = false;

        public virtual Course Course { get; set; }
        public virtual Student Student { get; set; }
        public virtual Teacher Teacher { get; set; }
    }
}
