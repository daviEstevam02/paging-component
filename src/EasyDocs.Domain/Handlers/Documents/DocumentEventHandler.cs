using EasyDocs.Domain.Events.Documents;
using MediatR;

namespace EasyDocs.Domain.Handlers.Documents;

public sealed class DocumentEventHandler : 
    INotificationHandler<DocumentCreatedEvent>,
    INotificationHandler<DocumentUpdatedEvent>,
    INotificationHandler<DocumentDeletedEvent>
{
    public Task Handle(DocumentCreatedEvent notification, CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }

    public Task Handle(DocumentUpdatedEvent notification, CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }

    public Task Handle(DocumentDeletedEvent notification, CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}