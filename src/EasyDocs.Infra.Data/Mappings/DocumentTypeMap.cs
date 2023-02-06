using EasyDocs.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EasyDocs.Infra.Data.Mappings;

public sealed class DocumentTypeMap : IEntityTypeConfiguration<DocumentType>
{
    public void Configure(EntityTypeBuilder<DocumentType> builder)
    {
        builder.HasKey(dt => dt.Id);

        builder.HasOne(dt => dt.Licensee)
            .WithMany(l => l.DocumentTypes)
            .HasForeignKey(dt => dt.LicenseeId);

        builder.HasOne(dt => dt.Company)
            .WithMany(l => l.DocumentTypes)
            .HasForeignKey(dt => dt.CompanyId);

        builder.OwnsOne(dt => dt.Description, description =>
        {
            description.Property(d => d.Text)
            .HasColumnType("varchar(150)")
            .HasColumnName("Description");
        });
    }
}