using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using WsSchool.Core.Interfaces;
using WsSchool.Core.Models.Entities;
using WsSchool.Core.Models.Mysql;

namespace WsSchool.Core.Repository
{

    public class UnitWork : IUnitWork
    {
        private readonly SchoolDbContext _context;
        private readonly IRepository<Person> _person;
        private readonly IRepository<Course> _course;
        private readonly IRepository<Gradebook> _gradeBook;
        private readonly IRepository<Student> _student;
        private readonly IRepository<Teacher> _teacher;
        private readonly IRepository<Login> _login;

        public UnitWork(SchoolDbContext context)
        {
            _context = context;
        }
        public async Task SaveAsync() => await _context?.SaveChangesAsync();
        public void Save() => _context.SaveChanges();

        public async ValueTask DisposeAsync()
        {
            await _context.DisposeAsync();
            GC.SuppressFinalize(this);
        }

        
        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public IRepository<Person> Person => _person ?? new GenericRepository<Person>(_context);
        public IRepository<Course> Course => _course ?? new GenericRepository<Course>(_context);
        public IRepository<Gradebook> GradeBook => _gradeBook ?? new GenericRepository<Gradebook>(_context);
        public IRepository<Student> Student => _student ?? new GenericRepository<Student>(_context);
        public IRepository<Teacher> Teacher => _teacher ?? new GenericRepository<Teacher>(_context);
        public IRepository<Login> Login => _login ?? new GenericRepository<Login>(_context);


    }
}
