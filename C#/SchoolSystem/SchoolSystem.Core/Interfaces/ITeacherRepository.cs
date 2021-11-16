using System.Collections;
using SchoolSystem.Core.Entities;
using SchoolSystem.Core.QueryFilters;

namespace SchoolSystem.Core.Interfaces
{
    public interface ITeacherRepository : ICreate<Teacher>, IUpdate<Teacher>, IRead<Teacher>
    {
        IEnumerable GetTeaches();
        IEnumerable GetCoursesbyTeacher(CourseFilter filter);
    }
}