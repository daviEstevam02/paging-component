using EasyDocs.Infra.Data.Context;
using Equinox.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace EasyDocs.WebApi.Configurations;

public static class DatabaseConfig
{
    public static void AddDatabaseConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        if (services is null) throw new ArgumentNullException(nameof(services));

        string easyDocsConnection = configuration.GetConnectionString("EasyDocsConnection")!;

        services.AddDbContext<EasyDocsContext>(options =>
        {
            options.UseMySql(easyDocsConnection, ServerVersion.AutoDetect(easyDocsConnection),
                options => options.EnableRetryOnFailure())
            .EnableSensitiveDataLogging();
        });

        string eventsConnection = configuration.GetConnectionString("EventStoreConnection")!;

        services.AddDbContext<EventStoreSqlContext>(options =>
        {
            options.UseMySql(eventsConnection, ServerVersion.AutoDetect(eventsConnection),
                options => options.EnableRetryOnFailure())
            .EnableSensitiveDataLogging();
        });
    }
}