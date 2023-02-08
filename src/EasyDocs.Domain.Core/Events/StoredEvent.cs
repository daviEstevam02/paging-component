using EasyDocs.Domain.Core.Messaging;

namespace EasyDocs.Domain.Core.Events;

public class StoredEvent : Event
{
    protected StoredEvent() 
    { }

    public StoredEvent(Event theEvent) 
        : base(theEvent.Action, theEvent.UserId, theEvent.Username, theEvent.Entity)
    {
        Id = Guid.NewGuid();
        AggregateId = theEvent.AggregateId;
    }

    public Guid Id { get; private set; }
}

public enum EAction
{
    Created  = 1, 
    Updated = 2, 
    Deleted = 3
}