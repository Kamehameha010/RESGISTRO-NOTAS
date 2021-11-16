using System.Collections.Generic;
using SchoolSystem.Core.Interfaces;
using SchoolSystem.Infrastructure.Data;
using SchoolSystem.Core.ReportEntities;
using SchoolSystem.Core.QueryFilters;
using System.Linq;

namespace SchoolSystem.Infrastructure.Services
{
    public class ReportService : ICourseReport
    {
#nullable enable
        private readonly SchoolDBContext _context;
        public ReportService(SchoolDBContext context) => _context = context;

        public IEnumerable<CourseReport> CourseReports(CourseReportFilter filters)
        {
            var courses = _context.Course.ToList();

            if (!string.IsNullOrEmpty(filters.Course))
            {
                courses.Where(x => x.Code.ToLower().Contains(filters.Course.ToLower())
                || x.Name.ToLower().Contains(filters.Course.ToLower()));
            }
            return courses.GroupJoin(_context.CourseGradebook,
                course => course.CourseId,
                gradebook => gradebook.CourseId,
                (course, CourseGradebooks) =>
                new CourseReport
                {
                    CourseName = course.Name,
                    Average = filters.NeedAverage ? CourseGradebooks.Average(x => x.Average) : null,
                    CourseStatusNotes = filters.NeedStatus ?
                    CourseGradebooks.GroupBy(x => x.Status).Select(k =>
                    new CourseStatusNotes
                    {
                        Status = k.Key ? "Approved" : "Disapproved",
                        Percentaje = (k.Count() * 100) / CourseGradebooks.Count()
                    }) : null
                }
            );
        }
#nullable disable
    }
}