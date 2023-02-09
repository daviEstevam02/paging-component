using EasyDocs.Domain.Core.Events;
using EasyDocs.Domain.Core.Messaging;
using EasyDocs.Domain.Enums;
using EasyDocs.Domain.Helpers;
using EasyDocs.Domain.ValueObjects;

namespace EasyDocs.Domain.Events.DocumentTypes;

public sealed class DocumentTypeCreatedEvent : Event
{
    public DocumentTypeCreatedEvent(
        Guid id, 
        Guid licenseeId, 
        Guid companyId, 
        EDocumentGroup documentGroup, 
        Description description,
        Guid userId,
        string username
        ) : base(EAction.Created, userId, username, EntitiesContexts.DOCUMENT_TYPES)
    {
        AggregateId = id;
        Id = id;
        LicenseeId = licenseeId;
        CompanyId = companyId;
        DocumentGroup = documentGroup;
        Description = description;
    }

    public Guid Id { get; private set; }
    public Guid LicenseeId { get; private set; }
    public Guid CompanyId { get; private set; }
    public EDocumentGroup DocumentGroup { get; private set; }
    public Description Description { get; private set; }
}