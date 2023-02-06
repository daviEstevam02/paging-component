using EasyDocs.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EasyDocs.Infra.Data.Mappings;

public sealed class UserDocumentMap : IEntityTypeConfiguration<UserDocument>
{
    public void Configure(EntityTypeBuilder<UserDocument> builder)
    {
        builder.HasKey(ud => new { ud.UserId, ud.DocumentId });

        builder.HasOne(ud => ud.Licensee)
            .WithMany(l => l.UserDocuments)
            .HasForeignKey(ud => ud.LicenseeId);

        builder.HasOne(ud => ud.Company)
            .WithMany(c => c.UserDocuments)
            .HasForeignKey(ud => ud.CompanyId);

        builder.HasOne(ud => ud.User)
            .WithMany(u => u.UserDocuments)
            .HasForeignKey(ud => ud.UserId);

        builder.HasOne(ud => ud.Document)
            .WithMany(d => d.UserDocuments)
            .HasForeignKey(ud => ud.DocumentId);
    }
}