using EasyDocs.Infra.Data.Mappings;
using Microsoft.EntityFrameworkCore;

namespace EasyDocs.Infra.Data.Extensions;

public static class ModelBuilderExtensions
{
    public static void ConfigureMappings(this ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new LicenseeMap());
        modelBuilder.ApplyConfiguration(new CompanyMap());
        modelBuilder.ApplyConfiguration(new UserTypeMap());
        modelBuilder.ApplyConfiguration(new UserMap());
        modelBuilder.ApplyConfiguration(new DocumentTypeMap());
        modelBuilder.ApplyConfiguration(new DocumentMap());
        modelBuilder.ApplyConfiguration(new UserDocumentMap());
    }
}