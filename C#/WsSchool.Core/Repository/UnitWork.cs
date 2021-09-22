using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using WsSchool.Core.Interfaces;
using WsSchool.Core.Models.Entities;

namespace WsSchool.Core.Repository
{

    public class UnitWork : IUnitWork
    {
        private readonly DbContext _context;
        private readonly IRepository<Person> _person;
        private readonly IRepository<Course> _course;
        private readonly IRepository<Gradebook> _gradeBook;
        private readonly IRepository<Student> _student;
        private readonly IRepository<Teacher> _teacher;
        private readonly IRepository<Login> _login;

        public UnitWork(DbContext context)
        {
            _context = context;
            _person = new GenericRepository<Person>(_context);
            _course = new GenericRepository<Course>(_context);
            _gradeBook = new GenericRepository<Gradebook>(_context);
            _student = new GenericRepository<Student>(_context);
            _teacher = new GenericRepository<Teacher>(_context);
            _login = new GenericRepository<Login>(_context);
        }
        public async Task SaveAsync() => await _context?.SaveChangesAsync();
        public async ValueTask DisposeAsync()
        {
            await _context.DisposeAsync();
            GC.SuppressFinalize(this);
        }

        public IRepository<Person> Person { get => _person; }
        public IRepository<Course> Course { get => _course; }
        public IRepository<Gradebook> GreadeBook { get => _gradeBook; }
        public IRepository<Student> Student { get => _student; }
        public IRepository<Teacher> Teacher { get => _teacher; }
        public IRepository<Login> Login { get => _login; }

    }
}
