using SchoolSystem.Core.QueryFilters;
using SchoolSystem.Core.ReportEntities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SchoolSystem.Core.Interfaces
{
    public interface ICourseReport
    {
       IEnumerable<CourseReport> CourseReports(CourseReportFilter filters);
    }
}