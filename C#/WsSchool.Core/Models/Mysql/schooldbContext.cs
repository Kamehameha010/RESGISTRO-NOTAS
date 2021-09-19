using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace WsSchool.Core.Models.Mysql
{
    public partial class schooldbContext : DbContext
    {
        public schooldbContext()
        {
        }

        public schooldbContext(DbContextOptions<schooldbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TbCourse> TbCourse { get; set; }
        public virtual DbSet<TbCourseStatus> TbCourseStatus { get; set; }
        public virtual DbSet<TbGradebook> TbGradebook { get; set; }
        public virtual DbSet<TbLogin> TbLogin { get; set; }
        public virtual DbSet<TbPerson> TbPerson { get; set; }
        public virtual DbSet<TbRol> TbRol { get; set; }
        public virtual DbSet<TbStudent> TbStudent { get; set; }
        public virtual DbSet<TbTeacher> TbTeacher { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySQL("server=127.0.0.1;port=3306;user=kame;password=1234;database=schooldb");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TbCourse>(entity =>
            {
                entity.HasKey(e => e.CourseId)
                    .HasName("PRIMARY");

                entity.ToTable("tb_course");

                entity.HasIndex(e => e.Code)
                    .HasName("code_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.CourseStatusId)
                    .HasName("FK_COURSE_STATUS_idx");

                entity.Property(e => e.CourseId).HasColumnName("courseId");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasColumnName("code")
                    .HasMaxLength(20);

                entity.Property(e => e.CourseStatusId).HasColumnName("courseStatusId");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(45);

                entity.HasOne(d => d.CourseStatus)
                    .WithMany(p => p.TbCourse)
                    .HasForeignKey(d => d.CourseStatusId)
                    .HasConstraintName("FK_COURSE_STATUS");
            });

            modelBuilder.Entity<TbCourseStatus>(entity =>
            {
                entity.HasKey(e => e.CourseStatusId)
                    .HasName("PRIMARY");

                entity.ToTable("tb_course_status");

                entity.HasIndex(e => e.Code)
                    .HasName("code_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.CourseStatusId).HasColumnName("courseStatusId");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasColumnName("code")
                    .HasMaxLength(45);

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(45);
            });

            modelBuilder.Entity<TbGradebook>(entity =>
            {
                entity.HasKey(e => e.GradebookId)
                    .HasName("PRIMARY");

                entity.ToTable("tb_gradebook");

                entity.HasIndex(e => e.CourseId)
                    .HasName("FK_GRADE_COURSE_idx");

                entity.HasIndex(e => e.StudentId)
                    .HasName("FK_GRADE_STUDENT_idx");

                entity.HasIndex(e => e.TeacherId)
                    .HasName("FK_GRADE_TEACHER_idx");

                entity.Property(e => e.GradebookId).HasColumnName("gradebookId");

                entity.Property(e => e.Average)
                    .HasColumnName("average")
                    .HasColumnType("decimal(3,2)");

                entity.Property(e => e.CourseId).HasColumnName("courseId");

                entity.Property(e => e.Q1).HasColumnType("decimal(3,2)");

                entity.Property(e => e.Q2).HasColumnType("decimal(3,2)");

                entity.Property(e => e.Q3).HasColumnType("decimal(3,2)");

                entity.Property(e => e.State)
                    .HasColumnName("state")
                    .HasColumnType("tinyint");

                entity.Property(e => e.StudentId).HasColumnName("studentId");

                entity.Property(e => e.TeacherId).HasColumnName("teacherId");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.TbGradebook)
                    .HasForeignKey(d => d.CourseId)
                    .HasConstraintName("FK_GRADE_COURSE");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.TbGradebook)
                    .HasForeignKey(d => d.StudentId)
                    .HasConstraintName("FK_GRADE_STUDENT");

                entity.HasOne(d => d.Teacher)
                    .WithMany(p => p.TbGradebook)
                    .HasForeignKey(d => d.TeacherId)
                    .HasConstraintName("FK_GRADE_TEACHER");
            });

            modelBuilder.Entity<TbLogin>(entity =>
            {
                entity.HasKey(e => e.LoginId)
                    .HasName("PRIMARY");

                entity.ToTable("tb_login");

                entity.HasIndex(e => e.RolId)
                    .HasName("FK_LOGIN_ROL_idx");

                entity.Property(e => e.LoginId).HasColumnName("loginId");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasMaxLength(45);

                entity.Property(e => e.PersonId).HasColumnName("personId");

                entity.Property(e => e.RolId).HasColumnName("rolId");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasColumnName("username")
                    .HasMaxLength(45);

                entity.HasOne(d => d.Rol)
                    .WithMany(p => p.TbLogin)
                    .HasForeignKey(d => d.RolId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LOGIN_ROL");
            });

            modelBuilder.Entity<TbPerson>(entity =>
            {
                entity.HasKey(e => e.PersonId)
                    .HasName("PRIMARY");

                entity.ToTable("tb_person");

                entity.HasIndex(e => e.LoginId)
                    .HasName("FK_PERSON_LOGIN_idx");

                entity.HasIndex(e => e.Nid)
                    .HasName("nid_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.PersonId).HasColumnName("personId");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasColumnName("address")
                    .HasMaxLength(45);

                entity.Property(e => e.Lastname)
                    .HasColumnName("lastname")
                    .HasMaxLength(45);

                entity.Property(e => e.LoginId).HasColumnName("loginId");

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
                    .HasForeignKey(d => d.LoginId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PERSON_LOGIN");
            });

            modelBuilder.Entity<TbRol>(entity =>
            {
                entity.HasKey(e => e.RolId)
                    .HasName("PRIMARY");

                entity.ToTable("tb_rol");

                entity.Property(e => e.RolId).HasColumnName("rolId");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(45);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(45);
            });

            modelBuilder.Entity<TbStudent>(entity =>
            {
                entity.HasKey(e => e.StudentId)
                    .HasName("PRIMARY");

                entity.ToTable("tb_student");

                entity.HasIndex(e => e.PersonId)
                    .HasName("FK_STUDENT_PERSON_idx");

                entity.Property(e => e.StudentId).HasColumnName("studentId");

                entity.Property(e => e.Classroom)
                    .IsRequired()
                    .HasColumnName("classroom")
                    .HasMaxLength(45);

                entity.Property(e => e.PersonId).HasColumnName("personId");

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.TbStudent)
                    .HasForeignKey(d => d.PersonId)
                    .HasConstraintName("FK_STUDENT_PERSON");
            });

            modelBuilder.Entity<TbTeacher>(entity =>
            {
                entity.HasKey(e => e.TeacherId)
                    .HasName("PRIMARY");

                entity.ToTable("tb_teacher");

                entity.HasIndex(e => e.PersonId)
                    .HasName("FK_TEACHER_PERSON_idx");

                entity.Property(e => e.TeacherId).HasColumnName("teacherId");

                entity.Property(e => e.PersonId).HasColumnName("personId");

                entity.Property(e => e.Subject)
                    .HasColumnName("subject")
                    .HasMaxLength(45);

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.TbTeacher)
                    .HasForeignKey(d => d.PersonId)
                    .HasConstraintName("FK_TEACHER_PERSON");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
