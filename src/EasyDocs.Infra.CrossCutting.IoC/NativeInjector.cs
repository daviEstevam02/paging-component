using EasyDocs.Application.Interfaces;
using EasyDocs.Application.Services;
using EasyDocs.Domain.Commands.Companies;
using EasyDocs.Domain.Commands.Documents;
using EasyDocs.Domain.Core.Events;
using EasyDocs.Domain.Core.Transactions;
using EasyDocs.Domain.Events.Companies;
using EasyDocs.Domain.Events.Documents;
using EasyDocs.Domain.Handlers.Companies;
using EasyDocs.Domain.Handlers.Documents;
using EasyDocs.Domain.Interfaces;
using EasyDocs.Infra.CrossCutting.Bus;
using EasyDocs.Infra.Data.Context;
using EasyDocs.Infra.Data.EventSourcing;
using EasyDocs.Infra.Data.Repositories;
using EasyDocs.Infra.Data.Transactions;
using Flunt.Notifications;
using Gooders.Shared.Core.Commands;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.ComponentModel.DataAnnotations;

namespace EasyDocs.Infra.CrossCutting.IoC;

public static class NativeInjector
{
    public static void RegisterServices(IServiceCollection services)
    {
        RegisterApplicationServices(services);
        RegisterInfrastructureServices(services);
        RegisterDomainServices(services);
    }

    private static void RegisterApplicationServices(IServiceCollection services)
    {
        services.AddScoped<ICompanyServices, CompanyServices>();
        services.AddScoped<IUserServices, UserServices>();
        services.AddScoped<IDocumentServices, DocumentServices>();
    }

    private static void RegisterInfrastructureServices(IServiceCollection services)
    {
        // Infra - Data
        services.AddScoped<EasyDocsContext>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        // Infra - Repositories
        services.AddScoped<ILicenseeRepository, LicenseeRepository>();
        services.AddScoped<ICompanyRepository, CompanyRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IDocumentRepository, DocumentRepository>();

        // Infra - Data EventSourcing
        services.AddScoped<EventStoreSqlContext>();
        services.AddScoped<IEventStoreRepository, EventStoreSqlRepository>();
        services.AddScoped<IEventStore, SqlEventStore>();
    }

    private static void RegisterDomainServices(IServiceCollection services)
    {
        // Domain Bus (Mediator)
        services.AddScoped<IMediatorHandler, InMemoryBus>();

        // Domain - Events
        services.AddScoped<INotificationHandler<CompanyCreatedEvent>, CompanyEventHandler>();
        services.AddScoped<INotificationHandler<DocumentCreatedEvent>, DocumentEventHandler>();

        // Domain - Commands
        services.AddScoped<IRequestHandler<CreateCompanyCommand, CommandResult>, CompanyCommandHandler>();
        services.AddScoped<IRequestHandler<CreateDocumentCommand, CommandResult>, DocumentCommandHandler>();
    }
}