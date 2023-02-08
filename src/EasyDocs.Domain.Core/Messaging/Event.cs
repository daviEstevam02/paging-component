using EasyDocs.Domain.Core.Events;
using MediatR;

namespace EasyDocs.Domain.Core.Messaging;

public abstract class Event : Message, INotification
{
    protected Event()
    { }

    protected Event(EAction action, Guid userId, string username, string entity) : base(entity, action)
    {
        Timestamp = DateTime.Now;
        UserId = userId;
        Username = username;
    }

    public DateTime Timestamp { get; private set; }
    public Guid UserId { get; protected set; }
    public string Username { get; protected set; } = string.Empty;
}