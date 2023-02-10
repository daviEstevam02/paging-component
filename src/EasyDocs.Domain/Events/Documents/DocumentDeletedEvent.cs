using EasyDocs.Domain.Core.Events;
using EasyDocs.Domain.Core.Messaging;
using EasyDocs.Domain.Helpers;

namespace EasyDocs.Domain.Events.Documents;

public sealed class DocumentDeletedEvent : Event
{
    public DocumentDeletedEvent(
        Guid id,
        Guid userId,
        string username
        ) : base(EAction.Deleted, userId, username, EntitiesContexts.DOCUMENTS)
    {
        Id = id;
        AggregateId = id;
    }

    public Guid Id { get; private set; }
}