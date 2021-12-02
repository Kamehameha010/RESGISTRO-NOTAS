using System;
using System.Threading.Tasks;
using SchoolSystem.Core.Entities;
using SchoolSystem.Core.Interfaces;
using SchoolSystem.Infrastructure.Data;

namespace SchoolSystem.Infrastructure.Repositories
{
    public class UnitWork : IUnitWork
    {
#pragma warning disable CS0649
        private readonly SchoolDBContext _context;
        private readonly ICourseRepository _course;
        private readonly IGradebookRepository _courseGradebook;
        private readonly ITeacherRepository _teacher;
        private readonly IStudentRepository _student;
        private readonly IRepository<User> _user;
        private readonly IRepository<Rol> _rol;
        private readonly ISecurityRepository _security;

#pragma warning restore CS0649
        public UnitWork(SchoolDBContext context) => _context = context;

        public ICourseRepository Courses => _course ?? new CourseRepository(_context);

        public IRepository<User> Users => _user ?? new BaseRepository<User>(_context);

        public IStudentRepository Students => _student ?? new StudentRepository(_context);

        public ITeacherRepository Teachers => _teacher ?? new TeacherRepository(_context);

        public IGradebookRepository CourseGradebooks => _courseGradebook ?? new GradebookRepository(_context);

        public IRepository<Rol> Roles => _rol ?? new BaseRepository<Rol>(_context);

        public ISecurityRepository securitt => _security ?? new SecurityRepository(_context);

        public void Save() => _context.SaveChanges();
        public async Task SaveAsync() => await _context.SaveChangesAsync();


        public void Dispose()
        {
            _context?.Dispose();
            GC.SuppressFinalize(this);
        }
        public async ValueTask DisposeAsync()
        {
            await _context.DisposeAsync();
            GC.SuppressFinalize(this);
        }


    }
}