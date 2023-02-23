using EasyDocs.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EasyDocs.Infra.Data.Mappings;

public sealed class DocumentTypeMap : IEntityTypeConfiguration<DocumentType>
{
    public void Configure(EntityTypeBuilder<DocumentType> builder)
    {
        builder.HasKey(dt => dt.Id);

        builder.Ignore(dt => dt.Notifications);

        builder.HasOne(dt => dt.Client)
            .WithMany(l => l.DocumentTypes)
            .HasForeignKey(dt => dt.ClientId);

        builder.OwnsOne(dt => dt.Description, description =>
        {
            description.Property(d => d.Text)
            .HasColumnType("varchar(150)")
            .HasColumnName("Description");

            description.Ignore(d => d.Notifications);
        });
    }
}