using EasyDocs.Domain.Core.Entities;
using EasyDocs.Domain.Enums;
using EasyDocs.Domain.ValueObjects;

namespace EasyDocs.Domain.Entities;

public sealed class DocumentType : Entity
{
    private DocumentType() 
    { }

    public DocumentType(
        Guid id,
        Guid licenseeId, 
        Guid companyId,
        EDocumentGroup documentGroup,
        Description description
        ) : base(id)
    {
        LicenseeId = licenseeId;
        CompanyId = companyId;
        DocumentGroup = documentGroup;
        Description = description;

        AddNotifications(Description);
    }

    public Guid LicenseeId { get; private set; }
    public Guid CompanyId { get; private set; }
    public EDocumentGroup DocumentGroup { get; private set; }
    public Description Description { get; private set; } = null!;

    public Company Company { get; private set; } = null!;
    public Licensee Licensee { get; private set; } = null!;
    public IList<Document> Documents { get; private set; } = null!;
}