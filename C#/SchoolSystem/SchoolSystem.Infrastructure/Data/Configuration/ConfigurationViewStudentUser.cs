using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolSystem.Core.Entities;

namespace SchoolSystem.Infrastructure.Data.Configuration
{
    internal sealed class ConfigurationViewStudentUser : IEntityTypeConfiguration<ViewStudentUser>
    {

        public void Configure(EntityTypeBuilder<ViewStudentUser> builder)
        {
            builder.HasNoKey();

            builder.ToView("vwstudentuser");

            builder.Property(e => e.UserId)
                .HasColumnName("userid");

            builder.Property(e => e.Address)
                .HasColumnName("address")
                .HasMaxLength(45);

            builder.Property(e => e.Lastname)
                .HasColumnName("lastname")
                .HasMaxLength(45);

            builder.Property(e => e.Name)
                .HasColumnName("name")
                .HasMaxLength(45);

            builder.Property(e => e.Nid).HasColumnName("nid");

            builder.Property(e => e.Password)
                .HasColumnName("passsword")
                .HasMaxLength(100);

            builder.Property(e => e.Phone)
                .HasColumnName("phone")
                .HasMaxLength(45);

            builder.Property(e => e.RolId).HasColumnName("rolid");

            builder.Property(e => e.Username)
                .HasColumnName("username")
                .HasMaxLength(45);

            builder.Property(e => e.StudentId).HasColumnName("studentid");
            builder.Property(e => e.Classroom).HasColumnName("classroom");

        }
    }
}


