using System.Collections;
using System.Collections.Generic;
using SchoolSystem.Core.Entities;
using SchoolSystem.Core.Entities.Results;
using SchoolSystem.Core.QueryFilters;

namespace SchoolSystem.Core.Interfaces
{
    public interface IGradebookRepository : ICreate<CourseGradebook>, IUpdate<CourseGradebook>
    {
        IEnumerable<TeacherResult> GetGradebookByTeacher(GradebookFilter filter);
        IEnumerable GetGradebookByStudent(GradebookFilter filter);
    }
}