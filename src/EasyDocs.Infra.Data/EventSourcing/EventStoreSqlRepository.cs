using EasyDocs.Domain.Core.Events;
using EasyDocs.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace EasyDocs.Infra.Data.EventSourcing;

public class EventStoreSqlRepository : IEventStoreRepository
{
    private readonly EventStoreSqlContext _context;

    public EventStoreSqlRepository(EventStoreSqlContext context)
    {
        _context = context;
    }

    public async Task<IList<StoredEvent>> GetByAggregateId(Guid aggregateId)
        => await (from e in _context.StoredEvent where e.AggregateId == aggregateId select e).ToListAsync();

    public async Task<IList<StoredEvent>> GetByEntity(string entity)
        => await (from e in _context.StoredEvent where e.Entity.ToLower() == entity.ToLower() select e).ToListAsync();

    public void Store(StoredEvent theEvent)
    {
        _context.StoredEvent.Add(theEvent);
        _context.SaveChanges();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}