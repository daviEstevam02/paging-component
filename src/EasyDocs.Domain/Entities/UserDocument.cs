using EasyDocs.Domain.Core.Entities;

namespace EasyDocs.Domain.Entities;

public sealed class UserDocument : Entity
{
    private UserDocument() 
    { }

    public UserDocument(
        Guid id, 
        Guid userId, 
        Guid documentId, 
        Guid companyId, 
        Guid licenseeId
        ) : base(id)
    {
        UserId = userId;
        DocumentId = documentId;
        CompanyId = companyId;
        LicenseeId = licenseeId;
    }

    public Guid UserId { get; private set; }
    public Guid DocumentId { get; private set; }
    public Guid CompanyId { get; private set; }
    public Guid LicenseeId { get; private set; }

    public Licensee Licensee { get; private set; } = null!;
    public Company Company { get; private set; } = null!;
    public User User { get; private set; } = null!;
    public Document Document { get; private set; } = null!;
}