using EasyDocs.Domain.Entities;
using EasyDocs.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EasyDocs.Infra.Data.Mappings;

public sealed class UserMap : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(u => u.Id);

        builder.Ignore(u => u.Notifications);

        builder.HasOne(u => u.Client)
            .WithMany(l => l.Users)
            .HasForeignKey(u => u.ClientId);

        builder.OwnsOne(u => u.Username, username =>
        {
            username.Property(un => un.Nickname)
            .HasColumnType("varchar(30)")
            .HasColumnName("Username");

            username.Ignore(un => un.Notifications);
        });

        builder.OwnsOne(u => u.Email, email =>
        {
            email.Property(e => e.Address)
            .HasColumnType("varchar(100)")
            .HasColumnName("Email");

            email.Ignore(e => e.Notifications);
        });

        builder.OwnsOne(u => u.Password, password =>
        {
            password.Property(p => p.PasswordTyped)
            .HasColumnType("varchar(16)")
            .HasColumnName("Password");

            password.Ignore(p => p.Notifications);
        });
    }
}