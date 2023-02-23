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
        Guid clientId
        ) : base(id)
    {
        UserId = userId;
        DocumentId = documentId;
        ClientId = clientId;
    }

    public Guid UserId { get; private set; }
    public Guid DocumentId { get; private set; }
    public Guid ClientId { get; private set; }

    public Client Client { get; private set; } = null!;
    public User User { get; private set; } = null!;
    public Document Document { get; private set; } = null!;
}