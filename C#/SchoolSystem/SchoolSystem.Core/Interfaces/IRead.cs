using System.Threading.Tasks;

namespace SchoolSystem.Core.Interfaces
{

    public interface IRead<T>
    {
        Task<T> FindAsync(int id);
    }
}