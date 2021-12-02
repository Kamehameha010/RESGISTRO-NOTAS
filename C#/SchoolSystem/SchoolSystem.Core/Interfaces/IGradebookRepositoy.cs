using System.Collections;
using System.Collections.Generic;
using SchoolSystem.Core.Entities;
using SchoolSystem.Core.Entities.Results;

namespace SchoolSystem.Core.Interfaces
{
    public interface IGradebookRepository : ICreate<CourseGradebook>, IUpdate<CourseGradebook>
    {
        IEnumerable<TeacherResult> GetGradebookTeacher(int teacherId);
    }
}