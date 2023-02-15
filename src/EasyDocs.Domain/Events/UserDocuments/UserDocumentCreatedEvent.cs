using EasyDocs.Domain.Core.Events;
using EasyDocs.Domain.Core.Messaging;
using EasyDocs.Domain.Helpers;

namespace EasyDocs.Domain.Events.UserDocuments;

public sealed class UserDocumentCreatedEvent : Event
{
    public UserDocumentCreatedEvent(
        Guid id,
        Guid userId, 
        Guid documentId, 
        Guid companyId, 
        Guid licenseeId,
        string username
        ) : base(EAction.Created, userId, username, EntitiesContexts.USER_DOCUMENTS)
    {
        Id = id;
        AggregateId = id;
        UserId = userId;
        DocumentId = documentId;
        CompanyId = companyId;
        LicenseeId = licenseeId;
    }

    public Guid Id { get; private set; }
    public Guid UserId { get; private set; }
    public Guid DocumentId { get; private set; }
    public Guid CompanyId { get; private set; }
    public Guid LicenseeId { get; private set; }
}
