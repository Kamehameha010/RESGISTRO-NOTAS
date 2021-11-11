using System.Collections;
using System.Threading.Tasks;
using SchoolSystem.Core.Entities;
using SchoolSystem.Core.Interfaces;
using SchoolSystem.Infrastructure.Data;

namespace SchoolSystem.Infrastructure.Repositories
{
    public class TeacherRepository : ITeacherRepository
    {
        private readonly SchoolDBContext _context;
        public TeacherRepository(SchoolDBContext context) => _context = context;
        public async Task AddAsync(Teacher model) => await _context.Teacher.AddAsync(model);

        public async Task<Teacher> FindAsync(int id) => await _context.Teacher.FindAsync(id);

        public IEnumerable GetTeaches() => _context.ViewTeacher;

        public void Update(Teacher model) => _context.Teacher.Update(model);
    }
}