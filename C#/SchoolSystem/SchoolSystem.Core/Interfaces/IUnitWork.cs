using System;
using System.Threading.Tasks;
using SchoolSystem.Core.Entities;

namespace SchoolSystem.Core.Interfaces
{
    public interface IUnitWork : IDisposable, IAsyncDisposable
    {
        ICourseRepository Courses { get; }
        IRepository<User> Users { get; }
        ISecurityRepository securitt { get; }
        IStudentRepository Students { get; }
        ITeacherRepository Teachers { get; }
        IRepository<CourseGradebook> CourseGradebooks { get; }
        IRepository<Rol> Roles { get; }

        void Save();
        Task SaveAsync();
    }
}