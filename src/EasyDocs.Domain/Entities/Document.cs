using EasyDocs.Domain.Core.Entities;
using EasyDocs.Domain.Enums;
using EasyDocs.Domain.ValueObjects;

namespace EasyDocs.Domain.Entities;

public sealed class Document : Entity
{
    private Document()
    { }

    public Document(
        Guid id, 
        Guid licenseeId, 
        Guid companyId, 
        Guid documentTypeId, 
        Description description, 
        Source source, 
        byte[]? file, 
        bool specificAccess
        ) : base(id)
    {
        LicenseeId = licenseeId;
        CompanyId = companyId;
        DocumentTypeId = documentTypeId;
        Description = description;
        Source = source;
        File = file;
        SpecificAccess = specificAccess;

        AddNotifications(Description, Source);
    }

    public Guid LicenseeId { get; private set; }
    public Guid CompanyId { get; private set; }
    public Guid DocumentTypeId { get; private set; }
    public Description Description { get; private set; } = null!;
    public Source Source { get; private set; } = null!;
    public byte[]? File { get; private set; }
    public bool SpecificAccess { get; set; }

    public DocumentType DocumentType { get; private set; } = null!;
    public Company Company { get; private set; } = null!;
    public Licensee Licensee { get; private set; } = null!;
    public IList<UserDocument> UserDocuments { get; private set; } = null!;
}