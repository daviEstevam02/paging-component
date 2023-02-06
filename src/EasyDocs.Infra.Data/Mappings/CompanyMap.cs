using EasyDocs.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EasyDocs.Infra.Data.Mappings;

public sealed class CompanyMap : IEntityTypeConfiguration<Company>
{
    public void Configure(EntityTypeBuilder<Company> builder)
    {
        builder.HasKey(c => c.Id);

        builder.HasOne(c => c.Licensee)
            .WithMany(l => l.Companies)
            .HasForeignKey(c => c.LicenseeId);

        builder.OwnsOne(c => c.FantasyName, fantasyName =>
        {
            fantasyName.Property(f => f.Name)
            .HasColumnType("varchar(100)")
            .HasColumnName("FantasyName");
        });

        builder.OwnsOne(c => c.LegalName, legalName =>
        {
            legalName.Property(l => l.Name)
            .HasColumnType("varchar(200)")
            .HasColumnName("LegalName");
        });

        builder.OwnsOne(c => c.Address, address =>
        {
            address.Property(a => a.Country)
            .HasColumnType("varchar(100)")
            .HasColumnName("Country");

            address.Property(a => a.State)
            .HasColumnType("varchar(2)")
            .HasColumnName("State");

            address.Property(a => a.City)
            .HasColumnType("varchar(200)")
            .HasColumnName("City");

            address.Property(a => a.Neighborhood)
            .HasColumnType("varchar(200)")
            .HasColumnName("Neighborhood");

            address.Property(a => a.Street)
            .HasColumnType("varchar(200)")
            .HasColumnName("Street");

            address.Property(a => a.Number)
            .HasColumnType("varchar(10)")
            .HasColumnName("Number");

            address.Property(a => a.Compliment)
            .HasColumnType("varchar(200)")
            .HasColumnName("Compliment");
        });

        builder.OwnsOne(c => c.Contact, contact =>
        {
            contact.Property(c => c.Number)
            .HasColumnType("varchar(22)")
            .HasColumnName("Contact");
        });

        builder.OwnsOne(c => c.Cnpj, cnpj =>
        {
            cnpj.Property(c => c.Number)
            .HasColumnType("varchar(14)")
            .HasColumnName("Cnpj");
        });
    }
}