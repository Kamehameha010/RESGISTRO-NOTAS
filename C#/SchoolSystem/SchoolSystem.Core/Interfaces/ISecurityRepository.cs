using System.Threading.Tasks;
using SchoolSystem.Core.Entities;

namespace SchoolSystem.Core.Interfaces
{
    public interface ISecurityRepository
    {
        Task<Security> CheckUserAsync(UserLogin model);

    }
}