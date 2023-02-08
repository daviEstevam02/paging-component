using EasyDocs.Domain.Core.Events;
using Flunt.Notifications;

namespace EasyDocs.Domain.Core.Messaging;

public abstract class Message : Notifiable<Notification>
{
    protected Message()
    { }

    protected Message(string entity, EAction action)
    {
        Entity = entity;
        Action = action;
    }

    public Guid AggregateId { get; protected set; }
    public string Entity { get; protected set; } = string.Empty;
    public EAction Action { get; protected set; }
}