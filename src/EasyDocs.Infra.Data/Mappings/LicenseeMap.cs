using EasyDocs.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EasyDocs.Infra.Data.Mappings;

public sealed class LicenseeMap : IEntityTypeConfiguration<Licensee>
{
    public void Configure(EntityTypeBuilder<Licensee> builder)
    {
        builder.HasKey(l => l.Id);

        builder.OwnsOne(l => l.Description, description =>
        {
            description.Property(d => d.Text)
            .HasColumnType("varchar(150)")
            .HasColumnName("Description");
        });
    }
}