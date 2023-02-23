using EasyDocs.Domain.Entities;
using EasyDocs.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EasyDocs.Infra.Data.Mappings;

public sealed class DocumentMap : IEntityTypeConfiguration<Document>
{
    public void Configure(EntityTypeBuilder<Document> builder)
    {
        builder.HasKey(d => d.Id);

        builder.Ignore(d => d.Notifications);

        builder.HasOne(d => d.Client)
            .WithMany(l => l.Documents)
            .HasForeignKey(d => d.ClientId);

        builder.HasOne(d => d.DocumentType)
            .WithMany(dt => dt.Documents)
            .HasForeignKey(d => d.DocumentTypeId);

        builder.OwnsOne(d => d.Description, description =>
        {
            description.Property(desc => desc.Text)
            .HasColumnType("varchar(150)")
            .HasColumnName("Description");

            description.Ignore(d => d.Notifications);
        });

        builder.OwnsOne(d => d.Source, source =>
        {
            source.Property(s => s.Text)
            .HasColumnType("varchar(250)")
            .HasColumnName("Source");

            source.Ignore(s => s.Notifications);
        });

        builder.Property(d => d.File)
            .IsRequired(false);
    }
}