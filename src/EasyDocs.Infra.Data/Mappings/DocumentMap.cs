using EasyDocs.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EasyDocs.Infra.Data.Mappings;

public sealed class DocumentMap : IEntityTypeConfiguration<Document>
{
    public void Configure(EntityTypeBuilder<Document> builder)
    {
        builder.HasKey(d => d.Id);

        builder.HasOne(d => d.Licensee)
            .WithMany(l => l.Documents)
            .HasForeignKey(d => d.LicenseeId);

        builder.HasOne(d => d.Company)
            .WithMany(c => c.Documents)
            .HasForeignKey(d => d.CompanyId);

        builder.HasOne(d => d.DocumentType)
            .WithMany(dt => dt.Documents)
            .HasForeignKey(d => d.DocumentTypeId);

        builder.OwnsOne(d => d.Description, description =>
        {
            description.Property(desc => desc.Text)
            .HasColumnType("varchar(150)")
            .HasColumnName("Description");
        });

        builder.OwnsOne(d => d.Source, source =>
        {
            source.Property(s => s.Text)
            .HasColumnType("varchar(250)")
            .HasColumnName("Source");
        });

        builder.Property(d => d.File)
            .IsRequired(false);
    }
}