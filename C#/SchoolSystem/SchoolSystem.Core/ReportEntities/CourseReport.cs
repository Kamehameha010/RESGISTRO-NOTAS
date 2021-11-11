using System.Collections.Generic;

namespace SchoolSystem.Core.ReportEntities
{
    public class CourseReport
    {
#nullable enable

        public string? CourseName { get; set; }
        public decimal? Average { get; set; }
        public IEnumerable<CourseStatusNotes>? CourseStatusNotes { get; set; }

    }
#nullable disable
    public class CourseStatusNotes
    {
        public decimal Percentaje { get; set; }
        public string Status { get; set; }
    }
}