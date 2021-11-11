using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolSystem.Core.Entities;

namespace SchoolSystem.Infrastructure.Data.Configuration
{
    internal sealed class TeacherConfiguration : IEntityTypeConfiguration<Teacher>
    {
        public void Configure(EntityTypeBuilder<Teacher> builder)
        {
            builder.HasKey(e => e.TeacherId)
                    .HasName("tb_teacher_pkey");

            builder.ToTable("tb_teacher");

            builder.Property(e => e.TeacherId)
                .HasColumnName("teacherid")
                .UseIdentityAlwaysColumn();

            builder.Property(e => e.Subject)
                .HasColumnName("subject")
                .HasMaxLength(45);

            builder.Property(e => e.UserId).HasColumnName("userid");

            builder.HasOne(d => d.User)
                .WithMany(p => p.Teachers)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("tb_teacher_userid_fkey");
        }
    }
}