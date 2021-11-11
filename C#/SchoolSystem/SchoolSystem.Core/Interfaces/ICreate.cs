using System.Threading.Tasks;

namespace SchoolSystem.Core.Interfaces
{
    public interface ICreate<T>
    {
        Task AddAsync(T model);
    }
}