using System.Threading.Tasks;

namespace SchoolSystem.Core.Interfaces
{
    public interface IDelete
    {
        Task DeleteAsync(int id);
    }
}