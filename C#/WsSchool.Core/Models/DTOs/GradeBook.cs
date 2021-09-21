namespace WsSchool.Core.Models.DTOs
{
    public class GradeBook
    { 
        public int GradebookId { get; set; }
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
