using EasyDocs.Domain.Core.Events;
using MediatR;

namespace EasyDocs.Domain.Core.Messaging;

public abstract class Event : Message, INotification
{
    protected Event()
    { }

    protected Event(EAction action, Guid userId) : base(action)
    {
        Timestamp = DateTime.Now;
        UserId = userId;
    }

    public DateTime Timestamp { get; private set; }
    public Guid UserId { get; protected set; }
}