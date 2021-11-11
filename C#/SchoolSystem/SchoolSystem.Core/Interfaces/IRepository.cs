using System.Collections.Generic;

namespace SchoolSystem.Core.Interfaces
{
    public interface IRepository<T> : ICreate<T>, IUpdate<T>, IDelete, IRead<T>
    {
        IEnumerable<T> GetAll();
    }
}