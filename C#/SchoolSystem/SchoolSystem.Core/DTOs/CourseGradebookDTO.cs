namespace SchoolSystem.Core.DTOs
{
    public class CourseGradebookDTO
    {
        public int CourseGradebookId { get; set; }
        public int? StudentId { get; set; }
        public decimal Q1 { get; set; }
        public decimal Q2 { get; set; }
        public decimal Q3 { get; set; }
        public decimal? Average { get; set; }
        public int? TeacherId { get; set; }
        public int? CourseId { get; set; }
        public bool? Status { get; set; }

    }
}