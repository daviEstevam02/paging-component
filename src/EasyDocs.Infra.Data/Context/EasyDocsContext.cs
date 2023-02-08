using EasyDocs.Domain.Core.Entities;
using EasyDocs.Domain.Core.Mediator;
using EasyDocs.Domain.Core.Messaging;
using EasyDocs.Domain.Core.Transactions;
using EasyDocs.Domain.Entities;
using EasyDocs.Infra.Data.Extensions;
using Flunt.Notifications;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace EasyDocs.Infra.Data.Context;

public class EasyDocsContext : DbContext, IUnitOfWork
{
    private readonly IMediatorHandler _mediatorHandler;

    public EasyDocsContext(DbContextOptions<EasyDocsContext> options, IMediatorHandler mediatorHandler) 
        : base(options)
    {
        _mediatorHandler = mediatorHandler; 
        ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        ChangeTracker.AutoDetectChangesEnabled = false;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Ignore<List<Notification>>();
        modelBuilder.Ignore<Event>();

        modelBuilder.ConfigureMappings();
        base.OnModelCreating(modelBuilder);
    }

    public DbSet<Licensee> Licensees { get; set; }
    public DbSet<Company> Companies { get; set; }
    public DbSet<UserType> UserTypes { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<DocumentType> DocumentTypes { get; set; }
    public DbSet<Document> Documents { get; set; }
    public DbSet<UserDocument> UserDocuments { get; set; }

    public async Task<bool> Commit()
    {
        await _mediatorHandler.PublishDomainEvents(this).ConfigureAwait(false);

        return await SaveChangesAsync() > 0;
    }
}

public static class MediatorExtension
{
    public static async Task PublishDomainEvents<T>(this IMediatorHandler mediator, T ctx) where T : DbContext
    {
        var domainEntities = ctx.ChangeTracker
            .Entries<Entity>()
            .Where(x => x.Entity.DomainEvents != null && x.Entity.DomainEvents.Any());

        var domainEvents = domainEntities
            .SelectMany(x => x.Entity.DomainEvents)
            .ToList();

        domainEntities.ToList()
            .ForEach(entity => entity.Entity.ClearDomainEvents());

        var tasks = domainEvents
            .Select(async (domainEvent) => {
                await mediator.PublishEvent(domainEvent);
            });

        await Task.WhenAll(tasks);
    }
}