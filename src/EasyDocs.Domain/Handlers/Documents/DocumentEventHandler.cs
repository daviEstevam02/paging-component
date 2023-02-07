using EasyDocs.Domain.Events.Documents;
using MediatR;

namespace EasyDocs.Domain.Handlers.Documents;

public sealed class DocumentEventHandler : 
    INotificationHandler<DocumentCreatedEvent>
{
    public Task Handle(DocumentCreatedEvent notification, CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}