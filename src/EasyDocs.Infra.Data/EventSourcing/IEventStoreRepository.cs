using EasyDocs.Domain.Core.Events;

namespace EasyDocs.Infra.Data.EventSourcing;

public interface IEventStoreRepository : IDisposable
{
    void Store(StoredEvent theEvent);
    Task<IList<StoredEvent>> GetByAggregateId(Guid aggregateId);
    Task<IList<StoredEvent>> GetByEntity(string entity);
}