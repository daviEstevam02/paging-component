using EasyDocs.Domain.Core.Events;
using EasyDocs.Domain.Core.Messaging;

namespace EasyDocs.Infra.Data.EventSourcing;

public class SqlEventStore : IEventStore
{
    private readonly IEventStoreRepository _eventStoreRepository;

    public SqlEventStore(IEventStoreRepository eventStoreRepository)
    {
        _eventStoreRepository = eventStoreRepository;
    }

    public void Save<T>(T theEvent) where T : Event
    {
        var storedEvent = new StoredEvent(
            theEvent);

        _eventStoreRepository.Store(storedEvent);
    }
}