using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolSystem.Core.Entities;

namespace SchoolSystem.Infrastructure.Data.Configuration
{
    internal sealed class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(e => e.UserId)
                    .HasName("tb_user_pkey");

            builder.ToTable("tb_user");

            builder.HasIndex(e => new { e.Nid, e.Username })
                .HasName("tb_user_nid_username_key")
                .IsUnique();

            builder.Property(e => e.UserId)
                .HasColumnName("userid")
                .UseIdentityAlwaysColumn();

            builder.Property(e => e.Address)
                .IsRequired()
                .HasColumnName("address")
                .HasMaxLength(45);

            builder.Property(e => e.Lastname)
                .HasColumnName("lastname")
                .HasMaxLength(45);

            builder.Property(e => e.Name)
                .IsRequired()
                .HasColumnName("name")
                .HasMaxLength(45);

            builder.Property(e => e.Nid).HasColumnName("nid");

            builder.Property(e => e.Password)
                .IsRequired()
                .HasColumnName("passsword")
                .HasMaxLength(100);

            builder.Property(e => e.Phone)
                .IsRequired()
                .HasColumnName("phone")
                .HasMaxLength(45);

            builder.Property(e => e.RolId).HasColumnName("rolid");

            builder.Property(e => e.Username)
                .IsRequired()
                .HasColumnName("username")
                .HasMaxLength(45);

            builder.HasOne(d => d.Rol)
                .WithMany(p => p.Users)
                .HasForeignKey(d => d.RolId)
                .HasConstraintName("tb_user_rolid_fkey");
        }
    }
}