using EasyDocs.Domain.Events.UserTypes;
using MediatR;

namespace EasyDocs.Domain.Handlers.UserTypes;

public sealed class UserTypeEventHandler :
  INotificationHandler<UserTypeCreatedEvent>,
  INotificationHandler<UserTypeUpdatedEvent>,
  INotificationHandler<UserTypeDeletedEvent>
{
    public Task Handle(UserTypeCreatedEvent notification, CancellationToken cancellationToken)
        => Task.CompletedTask;
    

    public Task Handle(UserTypeUpdatedEvent notification, CancellationToken cancellationToken)
        => Task.CompletedTask;

    public Task Handle(UserTypeDeletedEvent notification, CancellationToken cancellationToken)
        => Task.CompletedTask;
}