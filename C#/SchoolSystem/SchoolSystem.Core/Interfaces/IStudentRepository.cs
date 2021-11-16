using System.Collections;
using System.Collections.Generic;
using SchoolSystem.Core.Entities;
using SchoolSystem.Core.QueryFilters;

namespace SchoolSystem.Core.Interfaces
{
    public interface IStudentRepository : ICreate<Student>, IUpdate<Student>, IRead<Student>
    {
        IEnumerable<ViewStudentUser> GetStudents();
#nullable enable
        IEnumerable GetStudentCourse(CourseFilter filter);
#nullable disable
    }
}