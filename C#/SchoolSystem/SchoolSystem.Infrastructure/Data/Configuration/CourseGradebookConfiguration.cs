using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolSystem.Core.Entities;

namespace SchoolSystem.Infrastructure.Data.Configuration
{
    internal sealed class CourseGradebookConfiguration : IEntityTypeConfiguration<CourseGradebook>
    {
        public void Configure(EntityTypeBuilder<CourseGradebook> builder)
        {
            builder.HasKey(e => e.CourseGradebookId)
                    .HasName("tb_course_gradebook_pkey");

            builder.ToTable("tb_course_gradebook");

            builder.Property(e => e.CourseGradebookId)
                .HasColumnName("coursegradebookid")
                .UseIdentityAlwaysColumn();

            builder.Property(e => e.Average)
                .HasColumnName("average")
                .HasColumnType("numeric(3,2)");

            builder.Property(e => e.CourseId).HasColumnName("courseid");

            builder.Property(e => e.Q1)
                .HasColumnName("q1")
                .HasColumnType("numeric(3,2)");

            builder.Property(e => e.Q2)
                .HasColumnName("q2")
                .HasColumnType("numeric(3,2)");

            builder.Property(e => e.Q3)
                .HasColumnName("q3")
                .HasColumnType("numeric(3,2)");

            builder.Property(e => e.Status).HasColumnName("status");

            builder.Property(e => e.StudentId).HasColumnName("studentid");

            builder.Property(e => e.TeacherId).HasColumnName("teacherid");

            builder.HasOne(d => d.Course)
                .WithMany(p => p.CourseGradebooks)
                .HasForeignKey(d => d.CourseId)
                .HasConstraintName("tb_course_gradebook_courseid_fkey");

            builder.HasOne(d => d.Student)
                .WithMany(p => p.CourseGradebooks)
                .HasForeignKey(d => d.StudentId)
                .HasConstraintName("tb_course_gradebook_studentid_fkey");

            builder.HasOne(d => d.Teacher)
                .WithMany(p => p.CourseGradebooks)
                .HasForeignKey(d => d.TeacherId)
                .HasConstraintName("tb_course_gradebook_teacherid_fkey");
        }
    }
}