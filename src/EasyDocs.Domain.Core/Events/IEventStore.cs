using EasyDocs.Domain.Core.Messaging;

namespace EasyDocs.Domain.Core.Events;

public interface IEventStore
{
    void Save<T>(T theEvent) where T : Event;
}