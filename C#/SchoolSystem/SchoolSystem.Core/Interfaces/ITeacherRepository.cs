using System.Collections;
using SchoolSystem.Core.Entities;
using SchoolSystem.Core.QueryFilters;

namespace SchoolSystem.Core.Interfaces
{
    public interface ITeacherRepository : ICreate<Teacher>, IUpdate<Teacher>, IRead<Teacher>
    {
        IEnumerable GetTeachers();
        IEnumerable GetCoursesbyTeacher(GradebookFilter filter);
    }
}