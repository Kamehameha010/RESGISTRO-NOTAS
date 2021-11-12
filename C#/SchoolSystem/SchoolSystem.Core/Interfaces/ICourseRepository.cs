using System.Collections.Generic;
using SchoolSystem.Core.Entities;

namespace SchoolSystem.Core.Interfaces
{
    public interface ICourseRepository : ICreate<Course>, IUpdate<Course>, IRead<Course>, IDelete
    {
        IEnumerable<Course> GetCourses();
    }
}