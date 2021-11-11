using System.Collections;
using SchoolSystem.Core.Entities;

namespace SchoolSystem.Core.Interfaces
{
    public interface ITeacherRepository : ICreate<Teacher>, IUpdate<Teacher>, IRead<Teacher>
    {
        IEnumerable GetTeaches();
    }
}