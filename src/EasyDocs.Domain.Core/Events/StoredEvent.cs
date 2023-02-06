using EasyDocs.Domain.Core.Messaging;

namespace EasyDocs.Domain.Core.Events;

public class StoredEvent : Event
{
    protected StoredEvent() 
    { }

    public StoredEvent(Event theEvent, string user) 
        : base(theEvent.Action, theEvent.UserId)
    {
        Id = Guid.NewGuid();
        AggregateId = theEvent.AggregateId;
        User = user;
    }

    public Guid Id { get; private set; }
    public string User { get; private set; } = string.Empty;
}

public enum EAction
{
    Created  = 1, 
    Updated = 2, 
    Deleted = 3
}