using EasyDocs.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EasyDocs.Infra.Data.Mappings;

public sealed class UserTypeMap : IEntityTypeConfiguration<UserType>
{
    public void Configure(EntityTypeBuilder<UserType> builder)
    {
        builder.HasKey(ut => ut.Id);

        builder.HasOne(ut => ut.Licensee)
            .WithMany(l => l.UserTypes)
            .HasForeignKey(ut => ut.LicenseeId);

        builder.HasOne(ut => ut.Company)
            .WithMany(c => c.UserTypes)
            .HasForeignKey(ut => ut.CompanyId);

        builder.OwnsOne(ut => ut.Description, description =>
        {
            description.Property(d => d.Text)
            .HasColumnType("varchar(150)")
            .HasColumnName("Description");
        });

        builder.OwnsOne(ut => ut.Roles, roles =>
        {
            roles.Property(r => r.CanWrite)
            .HasColumnType("boolean")
            .HasColumnName("CanWrite");

            roles.Property(r => r.CanRead)
           .HasColumnType("boolean")
           .HasColumnName("CanRead");

            roles.Property(r => r.CanUpdate)
           .HasColumnType("boolean")
           .HasColumnName("CanUpdate");

            roles.Property(r => r.CanDelete)
           .HasColumnType("boolean")
           .HasColumnName("CanDelete");
        });
    }
}