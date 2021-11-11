using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using SchoolSystem.Core.Entities;
using SchoolSystem.Core.Interfaces;
using SchoolSystem.Infrastructure.Data;

namespace SchoolSystem.Infrastructure.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly SchoolDBContext _context;
        public StudentRepository(SchoolDBContext context) => _context = context;
        public async Task AddAsync(Student model) => await _context.Student.AddAsync(model);
        public async Task<Student> FindAsync(int id) => await _context.Student.FindAsync(id);
        public IEnumerable GetUsers() => _context.ViewStudent;

        public void Update(Student model) => _context.Student.Update(model);

    }
}