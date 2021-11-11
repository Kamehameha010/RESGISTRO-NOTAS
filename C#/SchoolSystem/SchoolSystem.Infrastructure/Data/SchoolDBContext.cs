using System.Reflection;
using Microsoft.EntityFrameworkCore;
using SchoolSystem.Core.Entities;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SchoolSystem.Infrastructure.Data
{
    public partial class SchoolDBContext : DbContext
    {
        public SchoolDBContext()
        {
        }

        public SchoolDBContext(DbContextOptions<SchoolDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Course> Course { get; set; }
        public virtual DbSet<CourseGradebook> CourseGradebook { get; set; }
        public virtual DbSet<CourseStatus> CourseStatus { get; set; }
        public virtual DbSet<Rol> Rol { get; set; }
        public virtual DbSet<Student> Student { get; set; }
        public virtual DbSet<Teacher> Teacher { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<ViewStudentUser> ViewStudent { get; set; }
        public virtual DbSet<ViewTeacherUser> ViewTeacher { get; set; }

        /* protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("Host=127.0.0.1;Database=SchoolDB;Username=joel;Password=1234");
            }
        } */
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        }

    }
}
