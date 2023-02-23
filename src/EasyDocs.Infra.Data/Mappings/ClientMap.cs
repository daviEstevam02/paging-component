using EasyDocs.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EasyDocs.Infra.Data.Mappings;

public sealed class ClientMap : IEntityTypeConfiguration<Client>
{
    public void Configure(EntityTypeBuilder<Client> builder)
    {
        builder.HasKey(c => c.Id);

        builder.OwnsOne(c => c.Description, description =>
        {
            description.Property(desc => desc.Text)
            .HasColumnType("varchar(150)")
            .HasColumnName("Description");

            description.Ignore(d => d.Notifications);
        });
    }
}