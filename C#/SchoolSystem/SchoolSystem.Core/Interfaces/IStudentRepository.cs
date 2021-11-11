using System.Collections;
using System.Threading.Tasks;
using SchoolSystem.Core.Entities;

namespace SchoolSystem.Core.Interfaces
{
    public interface IStudentRepository : ICreate<Student>, IUpdate<Student>, IRead<Student>
    {
        IEnumerable GetUsers();
    }
}