using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolSystem.Core.Entities;

namespace SchoolSystem.Infrastructure.Data.Configuration
{
    internal sealed class CourseConfiguration : IEntityTypeConfiguration<Course>
    {

        public void Configure(EntityTypeBuilder<Course> builder)
        {

            builder.HasKey(e => e.CourseId)
                    .HasName("tb_course_pkey");

            builder.ToTable("tb_course");

            builder.Property(e => e.CourseId)
                .HasColumnName("courseid")
                .UseIdentityAlwaysColumn();

            builder.Property(e => e.Code)
                .IsRequired()
                .HasColumnName("code")
                .HasMaxLength(45);

            builder.Property(e => e.CourseStatusId).HasColumnName("coursestatusid");

            builder.Property(e => e.Name)
                .HasColumnName("name")
                .HasMaxLength(45);

            builder.HasOne(d => d.CourseStatus)
                .WithMany(p => p.Courses)
                .HasForeignKey(d => d.CourseStatusId)
                .HasConstraintName("tb_course_coursestatusid_fkey");
        }
    }
}