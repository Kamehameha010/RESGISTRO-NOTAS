using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolSystem.Core.Entities;

namespace SchoolSystem.Infrastructure.Data.Configuration
{
    internal sealed class CourseStatusConfiguration : IEntityTypeConfiguration<CourseStatus>
    {
        public void Configure(EntityTypeBuilder<CourseStatus> builder)
        {
            builder.HasKey(e => e.CourseStatusId)
                    .HasName("tb_course_status_pkey");

            builder.ToTable("tb_course_status");

            builder.Property(e => e.CourseStatusId)
                .HasColumnName("coursestatusid")
                .UseIdentityAlwaysColumn();

            builder.Property(e => e.Code)
                .IsRequired()
                .HasColumnName("code")
                .HasMaxLength(45);

            builder.Property(e => e.Description)
                .IsRequired()
                .HasColumnName("description")
                .HasMaxLength(45);
        }
    }
}