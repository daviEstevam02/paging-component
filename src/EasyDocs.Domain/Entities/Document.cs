using EasyDocs.Domain.Core.Entities;
using EasyDocs.Domain.ValueObjects;

namespace EasyDocs.Domain.Entities;

public sealed class Document : Entity
{
    private Document()
    { }

    public Document(
        Guid id,
        Guid clientId,
        Guid documentTypeId,
        Description description,
        Source source,
        DateTime expirationDate,
        byte[]? file,
        bool specificAccess
        ) : base(id)
    {
        ClientId = clientId;
        DocumentTypeId = documentTypeId;
        Description = description;
        Source = source;
        ExpirationDate = expirationDate;
        File = file;
        SpecificAccess = specificAccess;

        AddNotifications(Description, Source);
    }

    public Guid ClientId { get; private set; }
    public Guid DocumentTypeId { get; private set; }
    public Description Description { get; private set; } = null!;
    public Source Source { get; private set; } = null!;
    public DateTime ExpirationDate { get; private set; }
    public byte[]? File { get; private set; }
    public bool SpecificAccess { get; private set; }

    public DocumentType DocumentType { get; private set; } = null!;
    public Client Client { get; private set; } = null!;
    public IList<UserDocument> UserDocuments { get; private set; } = null!;
}