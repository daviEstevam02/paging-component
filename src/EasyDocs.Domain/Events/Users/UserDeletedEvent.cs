using EasyDocs.Domain.Core.Events;
using EasyDocs.Domain.Core.Messaging;
using EasyDocs.Domain.Helpers;

namespace EasyDocs.Domain.Events.Users;

public sealed class UserDeletedEvent : Event
{
    public UserDeletedEvent(
        Guid id,
        Guid userId,
        string username
        ) : base(EAction.Deleted, userId, username, EntitiesContexts.USERS)
    {
        Id = id;
        AggregateId = id;
    }

    public Guid Id { get; private set; }
}