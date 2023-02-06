using EasyDocs.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EasyDocs.Infra.Data.Mappings;

public sealed class UserMap : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(u => u.Id);

        builder.HasOne(u => u.Licensee)
            .WithMany(l => l.Users)
            .HasForeignKey(u => u.LicenseeId);

        builder.HasOne(u => u.Company)
            .WithMany(c => c.Users)
            .HasForeignKey(u => u.CompanyId);

        builder.HasOne(u => u.UserType)
            .WithMany(ut => ut.Users)
            .HasForeignKey(u => u.UserTypeId);

        builder.OwnsOne(u => u.Username, username =>
        {
            username.Property(un => un.Nickname)
            .HasColumnType("varchar(30)")
            .HasColumnName("Username");
        });

        builder.OwnsOne(u => u.Email, email =>
        {
            email.Property(e => e.Address)
            .HasColumnType("varchar(100)")
            .HasColumnName("Email");
        });

        builder.OwnsOne(u => u.Password, password =>
        {
            password.Property(p => p.PasswordTyped)
            .HasColumnType("varchar(16)")
            .HasColumnName("Password");
        });
    }
}