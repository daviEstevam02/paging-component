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
        Guid clientId, 
        EDocumentGroup documentGroup,
        Description description
        ) : base(id)
    {
        ClientId = clientId;
        DocumentGroup = documentGroup;
        Description = description;

        AddNotifications(Description);
    }

    public Guid ClientId { get; private set; }
    public EDocumentGroup DocumentGroup { get; private set; }
    public Description Description { get; private set; } = null!;

    public Client Client { get; private set; } = null!;
    public IList<Document> Documents { get; private set; } = null!;
}