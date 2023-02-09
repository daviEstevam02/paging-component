using EasyDocs.Domain.Core.Events;
using EasyDocs.Domain.Core.Messaging;
using EasyDocs.Domain.Helpers;

namespace EasyDocs.Domain.Events.DocumentTypes;

public sealed class DocumentTypeDeletedEvent : Event
{
    public DocumentTypeDeletedEvent(
        Guid id,
        Guid userId,
        string username
     ) : base(EAction.Deleted, userId, username, EntitiesContexts.DOCUMENT_TYPES)
    {
        Id = id;
        AggregateId = id;
    }

    public Guid Id { get; private set; }
}