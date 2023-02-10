using EasyDocs.Domain.Core.Events;
using EasyDocs.Domain.Core.Messaging;
using EasyDocs.Domain.Helpers;
using EasyDocs.Domain.ValueObjects;

namespace EasyDocs.Domain.Events.Documents;

public sealed class DocumentUpdatedEvent : Event
{
    public DocumentUpdatedEvent(
       Guid id,
       Guid licenseeId,
       Guid companyId,
       Guid documentTypeId,
       Description description,
       Source source,
       DateTime expirationDate,
       byte[]? file,
       bool specificAccess,
       Guid userId,
       string username
       ) : base(EAction.Updated, userId, username, EntitiesContexts.DOCUMENTS)
    {
        AggregateId = id;
        Id = id;
        LicenseeId = licenseeId;
        CompanyId = companyId;
        DocumentTypeId = documentTypeId;
        Description = description;
        Source = source;
        ExpirationDate = expirationDate;
        File = file;
        SpecificAccess = specificAccess;
    }

    public Guid Id { get; set; }
    public Guid LicenseeId { get; private set; }
    public Guid CompanyId { get; private set; }
    public Guid DocumentTypeId { get; private set; }
    public Description Description { get; private set; }
    public Source Source { get; private set; }
    public DateTime ExpirationDate { get; private set; }
    public byte[]? File { get; private set; }
    public bool SpecificAccess { get; private set; }
}