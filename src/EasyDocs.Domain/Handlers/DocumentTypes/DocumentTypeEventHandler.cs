using EasyDocs.Domain.Events.DocumentTypes;
using MediatR;

namespace EasyDocs.Domain.Handlers.DocumentTypes;

public sealed class DocumentTypeEventHandler :
  INotificationHandler<DocumentTypeCreatedEvent>,
  INotificationHandler<DocumentTypeUpdatedEvent>,
  INotificationHandler<DocumentTypeDeletedEvent>
{
    public Task Handle(DocumentTypeUpdatedEvent notification, CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }

    public Task Handle(DocumentTypeCreatedEvent notification, CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }

    public Task Handle(DocumentTypeDeletedEvent notification, CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}