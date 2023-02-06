using MediatR;

namespace EasyDocs.Domain.Core.Messaging;

public abstract class Event : Message, INotification
{
    protected Event()
    {
        Timestamp = DateTime.Now;
    }

    public DateTime Timestamp { get; private set; }
}