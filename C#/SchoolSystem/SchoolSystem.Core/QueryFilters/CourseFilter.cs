namespace SchoolSystem.Core.QueryFilters
{
    public class CourseFilter
    {
        public int? StudentId { get; set; }
        public int? TeacherId { get; set; }
        public string Name { get; set; }
        public int? CourseId { get; set; }
        public string CourseName { get; set; }

    }
}