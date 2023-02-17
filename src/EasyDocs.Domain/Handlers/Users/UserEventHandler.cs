using EasyDocs.Domain.Events.Users;
using MediatR;

namespace EasyDocs.Domain.Handlers.Users;

public sealed class UserEventHandler :
    INotificationHandler<UserCreatedEvent>,
    INotificationHandler<UserUpdatedEvent>,
    INotificationHandler<UserDeletedEvent>
{
    public Task Handle(UserCreatedEvent notification, CancellationToken cancellationToken)
        => Task.CompletedTask;

    public Task Handle(UserUpdatedEvent notification, CancellationToken cancellationToken)
        => Task.CompletedTask;

    public Task Handle(UserDeletedEvent notification, CancellationToken cancellationToken)
        => Task.CompletedTask;
}