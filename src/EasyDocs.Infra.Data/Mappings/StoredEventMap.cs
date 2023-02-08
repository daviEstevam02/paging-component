using EasyDocs.Domain.Core.Events;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EasyDocs.Infra.Data.Mappings;

public sealed class StoredEventMap : IEntityTypeConfiguration<StoredEvent>
{
    public void Configure(EntityTypeBuilder<StoredEvent> builder)
    {
        builder.Property(e => e.Timestamp)
            .HasColumnName("AppliedAt");

        builder.Property(e => e.Entity)
            .HasColumnName("Context");

        builder.Property(e => e.Username)
            .HasColumnName("AppliedBy");

        builder.Property(e => e.Action)
            .HasConversion<string>()
            .HasColumnType("varchar(50)");

        builder.Ignore(e => e.Notifications);
    }
}