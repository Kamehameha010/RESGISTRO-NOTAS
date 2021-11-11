using System.Threading.Tasks;
using SchoolSystem.Core.Entities;

namespace SchoolSystem.Core.Interfaces
{
    public interface ISecurityRepository
    {
#nullable enable
        Task<Security>? CheckUserAsync(userLogin model);
#nullable disable
    }
}