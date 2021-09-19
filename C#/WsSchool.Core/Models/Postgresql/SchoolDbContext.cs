using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace WsSchool.Core.Models.Postgresql
{
    public partial class SchoolDbContext : DbContext
    {
        public SchoolDbContext()
        {
        }

        public SchoolDbContext(DbContextOptions<SchoolDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Course> Course { get; set; }
        public virtual DbSet<CourseStatus> CourseStatus { get; set; }
        public virtual DbSet<Gradebook> Gradebook { get; set; }
        public virtual DbSet<Login> Login { get; set; }
        public virtual DbSet<Person> Person { get; set; }
        public virtual DbSet<Rol> Rol { get; set; }
        public virtual DbSet<Student> Student { get; set; }
        public virtual DbSet<Teacher> Teacher { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           /*  if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseNpgsql("Host=127.0.0.1;Database=schooldb;Username=joel;Password=1234");
            } */
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>(entity =>
            {
                entity.HasKey(e => e.Courseid)
                    .HasName("tb_course_pkey");

                entity.ToTable("tb_course");

                entity.Property(e => e.Courseid)
                    .HasColumnName("courseid")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasColumnName("code")
                    .HasMaxLength(45);

                entity.Property(e => e.Coursestatusid).HasColumnName("coursestatusid");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(45);

                entity.HasOne(d => d.Coursestatus)
                    .WithMany(p => p.TbCourse)
                    .HasForeignKey(d => d.Coursestatusid)
                    .HasConstraintName("tb_course_coursestatusid_fkey");
            });

            modelBuilder.Entity<CourseStatus>(entity =>
            {
                entity.HasKey(e => e.Coursestatusid)
                    .HasName("tb_course_status_pkey");

                entity.ToTable("tb_course_status");

                entity.Property(e => e.Coursestatusid)
                    .HasColumnName("coursestatusid")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasColumnName("code")
                    .HasMaxLength(45);

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasMaxLength(45);
            });

            modelBuilder.Entity<Gradebook>(entity =>
            {
                entity.HasKey(e => e.Gradebookid)
                    .HasName("tb_gradebook_pkey");

                entity.ToTable("tb_gradebook");

                entity.Property(e => e.Gradebookid)
                    .HasColumnName("gradebookid")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Average)
                    .HasColumnName("average")
                    .HasColumnType("numeric(3,2)");

                entity.Property(e => e.Courseid).HasColumnName("courseid");

                entity.Property(e => e.Q1)
                    .HasColumnName("q1")
                    .HasColumnType("numeric(3,2)");

                entity.Property(e => e.Q2)
                    .HasColumnName("q2")
                    .HasColumnType("numeric(3,2)");

                entity.Property(e => e.Q3)
                    .HasColumnName("q3")
                    .HasColumnType("numeric(3,2)");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.Studentid).HasColumnName("studentid");

                entity.Property(e => e.Teacherid).HasColumnName("teacherid");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.TbGradebook)
                    .HasForeignKey(d => d.Courseid)
                    .HasConstraintName("tb_gradebook_courseid_fkey");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.TbGradebook)
                    .HasForeignKey(d => d.Studentid)
                    .HasConstraintName("tb_gradebook_studentid_fkey");

                entity.HasOne(d => d.Teacher)
                    .WithMany(p => p.TbGradebook)
                    .HasForeignKey(d => d.Teacherid)
                    .HasConstraintName("tb_gradebook_teacherid_fkey");
            });

            modelBuilder.Entity<Login>(entity =>
            {
                entity.HasKey(e => e.Loginid)
                    .HasName("tb_login_pkey");

                entity.ToTable("tb_login");

                entity.HasIndex(e => e.Username)
                    .HasName("tb_login_username_key")
                    .IsUnique();

                entity.Property(e => e.Loginid)
                    .HasColumnName("loginid")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Passsword)
                    .IsRequired()
                    .HasColumnName("passsword")
                    .HasMaxLength(100);

                entity.Property(e => e.Rolid).HasColumnName("rolid");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasColumnName("username")
                    .HasMaxLength(45);

                entity.HasOne(d => d.Rol)
                    .WithMany(p => p.TbLogin)
                    .HasForeignKey(d => d.Rolid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("tb_login_rolid_fkey");
            });

            modelBuilder.Entity<Person>(entity =>
            {
                entity.HasKey(e => e.Personid)
                    .HasName("tb_person_pkey");

                entity.ToTable("tb_person");

                entity.HasIndex(e => e.Nid)
                    .HasName("tb_person_nid_key")
                    .IsUnique();

                entity.Property(e => e.Personid)
                    .HasColumnName("personid")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasColumnName("address")
                    .HasMaxLength(45);

                entity.Property(e => e.Lastname)
                    .HasColumnName("lastname")
                    .HasMaxLength(45);

                entity.Property(e => e.Loginid).HasColumnName("loginid");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(45);

                entity.Property(e => e.Nid).HasColumnName("nid");

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasColumnName("phone_number")
                    .HasMaxLength(45);

                entity.HasOne(d => d.Login)
                    .WithMany(p => p.TbPerson)
                    .HasForeignKey(d => d.Loginid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("tb_person_loginid_fkey");
            });

            modelBuilder.Entity<Rol>(entity =>
            {
                entity.HasKey(e => e.Rolid)
                    .HasName("tb_rol_pkey");

                entity.ToTable("tb_rol");

                entity.Property(e => e.Rolid)
                    .HasColumnName("rolid")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(45);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(45);
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasKey(e => e.Studentid)
                    .HasName("tb_student_pkey");

                entity.ToTable("tb_student");

                entity.Property(e => e.Studentid)
                    .HasColumnName("studentid")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Classroom)
                    .IsRequired()
                    .HasColumnName("classroom")
                    .HasMaxLength(45);

                entity.Property(e => e.Personid).HasColumnName("personid");

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.TbStudent)
                    .HasForeignKey(d => d.Personid)
                    .HasConstraintName("tb_student_personid_fkey");
            });

            modelBuilder.Entity<Teacher>(entity =>
            {
                entity.HasKey(e => e.Teacherid)
                    .HasName("tb_teacher_pkey");

                entity.ToTable("tb_teacher");

                entity.Property(e => e.Teacherid)
                    .HasColumnName("teacherid")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Personid).HasColumnName("personid");

                entity.Property(e => e.Subject)
                    .HasColumnName("subject")
                    .HasMaxLength(45);

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.TbTeacher)
                    .HasForeignKey(d => d.Personid)
                    .HasConstraintName("tb_teacher_personid_fkey");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
