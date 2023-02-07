using EasyDocs.Domain.Core.Entities;
using EasyDocs.Domain.Core.Events;
using EasyDocs.Domain.Core.Messaging;
using EasyDocs.Domain.Entities;
using EasyDocs.Domain.ValueObjects;

namespace EasyDocs.Domain.Events.Documents;

public sealed class DocumentCreatedEvent : Event
{
    public DocumentCreatedEvent(
        Guid id, 
        Guid licenseeId, 
        Guid companyId, 
        Guid documentTypeId, 
        Description description, 
        Source source, 
        byte[]? file, 
        bool specificAccess, 
        Guid userId
        ) : base(EAction.Created, userId)
    {
        AggregateId = id;
        Id = id;
        LicenseeId = licenseeId;
        CompanyId = companyId;
        DocumentTypeId = documentTypeId;
        Description = description;
        Source = source;
        File = file;
        SpecificAccess = specificAccess;
    }

    public Guid Id { get; set; }
    public Guid LicenseeId { get; private set; }
    public Guid CompanyId { get; private set; }
    public Guid DocumentTypeId { get; private set; }
    public Description Description { get; private set; } = null!;
    public Source Source { get; private set; } = null!;
    public byte[]? File { get; private set; }
    public bool SpecificAccess { get; private set; }
}