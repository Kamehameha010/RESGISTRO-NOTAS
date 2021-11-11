using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolSystem.Core.Entities;

namespace SchoolSystem.Infrastructure.Data.Configuration
{
    internal sealed class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.HasKey(e => e.StudentId)
                    .HasName("tb_student_pkey");

            builder.ToTable("tb_student");

            builder.Property(e => e.StudentId)
                .HasColumnName("studentid")
                .UseIdentityAlwaysColumn();

            builder.Property(e => e.Classroom)
                .IsRequired()
                .HasColumnName("classroom")
                .HasMaxLength(45);

            builder.Property(e => e.UserId).HasColumnName("userid");

            builder.HasOne(d => d.User)
                .WithMany(p => p.Students)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("tb_student_userid_fkey");
        }
    }
}