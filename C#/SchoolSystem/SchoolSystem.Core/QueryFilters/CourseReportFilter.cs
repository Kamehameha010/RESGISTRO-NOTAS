namespace SchoolSystem.Core.QueryFilters
{

    public class CourseReportFilter
    {
        public string Course { get; set; }
        public bool NeedAverage { get; set; } = false;
        public bool NeedStatus { get; set; } = false;

    }
#nullable disable

}