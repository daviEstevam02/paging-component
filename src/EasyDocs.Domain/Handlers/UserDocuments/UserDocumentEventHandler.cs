using EasyDocs.Domain.Events.UserDocuments;
using MediatR;

namespace EasyDocs.Domain.Handlers.UserDocuments;

public sealed class UserDocumentEventHandler :
    INotificationHandler<UserDocumentCreatedEvent>,
    INotificationHandler<UserDocumentUpdateEvent>,
    INotificationHandler<UserDocumentDeletedEvent>

{
    public Task Handle(UserDocumentCreatedEvent notification, CancellationToken cancellationToken)
    {
        return Task.CompletedTask;

    }

    public Task Handle(UserDocumentUpdateEvent notification, CancellationToken cancellationToken)
    {
        return Task.CompletedTask;

    }

    public Task Handle(UserDocumentDeletedEvent notification, CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}
