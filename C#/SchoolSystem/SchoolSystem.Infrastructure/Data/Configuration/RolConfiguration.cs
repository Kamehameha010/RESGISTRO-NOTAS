using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolSystem.Core.Entities;

namespace SchoolSystem.Infrastructure.Data.Configuration
{
    internal sealed class RolConfiguration : IEntityTypeConfiguration<Rol>
    {
        public void Configure(EntityTypeBuilder<Rol> builder)
        {
            builder.HasKey(e => e.RolId)
                    .HasName("tb_rol_pkey");

            builder.ToTable("tb_rol");

            builder.Property(e => e.RolId)
                .HasColumnName("rolid")
                .UseIdentityAlwaysColumn();

            builder.Property(e => e.Description)
                .HasColumnName("description")
                .HasMaxLength(45);

            builder.Property(e => e.Name)
                .IsRequired()
                .HasColumnName("name")
                .HasMaxLength(45);
        }
    }
}