using EasyDocs.Application.Interfaces;
using EasyDocs.Application.Services;
using EasyDocs.Domain.Interfaces;
using EasyDocs.Infra.Data.Context;
using EasyDocs.Infra.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace EasyDocs.Infra.CrossCutting.IoC;

public static class NativeInjector
{
    public static void RegisterServices(IServiceCollection services)
    {
        RegisterApplicationServices(services);
        RegisterInfrastructureServices(services);
    }

    private static void RegisterApplicationServices(IServiceCollection services)
    {
        services.AddScoped<IUserServices, UserServices>();
    }

    private static void RegisterInfrastructureServices(IServiceCollection services)
    {
        services.AddScoped<EasyDocsContext>();
        services.AddScoped<IUserRepository, UserRepository>();
    }
}