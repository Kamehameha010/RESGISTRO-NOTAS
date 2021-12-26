using System.Collections.Generic;
using SchoolSystem.Core.Entities;

namespace SchoolSystem.Core.Interfaces
{
    public interface IStudentRepository : ICreate<Student>, IUpdate<Student>, IRead<Student>
    {
        IEnumerable<ViewStudentUser> GetStudents();
    }
}