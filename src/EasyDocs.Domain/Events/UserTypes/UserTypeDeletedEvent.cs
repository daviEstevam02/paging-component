using EasyDocs.Domain.Core.Events;
using EasyDocs.Domain.Core.Messaging;
using EasyDocs.Domain.Helpers;

namespace EasyDocs.Domain.Events.UserTypes;

public sealed class UserTypeDeletedEvent : Event
{
    public UserTypeDeletedEvent(
        Guid id,
        Guid userId,
        string username
     ) : base(EAction.Deleted, userId, username, EntitiesContexts.USER_TYPES)
    {
        Id = id;
        AggregateId = id;
    }

    public Guid Id { get; private set; }
}