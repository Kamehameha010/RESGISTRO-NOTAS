using System;
using System.Threading.Tasks;
using WsSchool.Core.Models.Entities;

namespace WsSchool.Core.Interfaces
{
    public interface IUnitWork : IAsyncDisposable, IDisposable
    {
        void Save();
        Task SaveAsync();
        public IRepository<Person> Person { get; }
        public IRepository<Course> Course { get; }
        public IRepository<Gradebook> GradeBook { get; }
        public IRepository<Student> Student { get; }
        public IRepository<Teacher> Teacher { get; }
        public IRepository<User> User { get; }
    }
}
