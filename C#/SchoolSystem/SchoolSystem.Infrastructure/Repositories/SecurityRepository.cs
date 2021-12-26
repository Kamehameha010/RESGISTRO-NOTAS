using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SchoolSystem.Core.Entities;
using SchoolSystem.Core.Interfaces;
using SchoolSystem.Infrastructure.Data;

namespace SchoolSystem.Infrastructure.Repositories
{
    public class SecurityRepository : ISecurityRepository
    {
#nullable enable
        private readonly SchoolDBContext _context;
        public SecurityRepository(SchoolDBContext context) => _context = context;
        public async Task<Security>? CheckUserAsync(UserLogin model) =>
        await _context.User.Where(p => p.Username.Equals(model.Username) && p.Password.Equals(model.Password))
            .Select(x => new Security
            {
                FullName = $"{x.Name} {x.Lastname}",
                Username = x.Username,
                Rol = ( _context.Rol.Where(d => d.RolId == x.RolId).FirstOrDefault()).Name
            }).FirstOrDefaultAsync();

#nullable disable

    }
}