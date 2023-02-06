using EasyDocs.Domain.Core.Messaging;

namespace EasyDocs.Domain.Core.Events;

public class StoredEvent : Event
{
    protected StoredEvent() { }

    public StoredEvent(Event theEvent, string entity, EAction action, Guid userId, string user)
    {
        Id = Guid.NewGuid();
        AggregateId = theEvent.AggregateId;
        MessageType = theEvent.MessageType;
        Entity = entity;
        Action= action;
        UserId = userId;
        User = user;
    }

    public Guid Id { get; private set; }
    public string Entity { get; private set; } = string.Empty;
    public EAction Action { get; private set; } 
    public Guid UserId { get; private set; }
    public string User { get; private set; } = string.Empty;
}

public enum EAction
{
    Created  = 1, 
    Updated = 2, 
    Deleted = 3
}