using EasyDocs.Domain.Core.Events;

namespace EasyDocs.Domain.Core.Messaging;

public abstract class Message
{
    protected Message()
    { }

    protected Message(EAction action)
    {
        Entity = GetType().Name;
        Action = action;
    }

    public Guid AggregateId { get; protected set; }
    public string Entity { get; protected set; } = string.Empty;
    public EAction Action { get; protected set; }
}