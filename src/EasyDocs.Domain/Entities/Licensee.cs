using EasyDocs.Domain.Core.Entities;
using EasyDocs.Domain.ValueObjects;

namespace EasyDocs.Domain.Entities;

public sealed class Licensee : Entity
{
    private Licensee() 
    { }

    public Licensee(
        Guid id, 
        Description description
        ) : base(id)
    {
        Description = description;

        AddNotifications(Description);
    }

    public Description Description { get; private set; } = null!;

    public List<Company> Companies { get; private set; } = null!;
    public List<Document> Documents { get; private set; } = null!;
    public List<DocumentType> DocumentTypes { get; private set; } = null!;
    public List<User> Users { get; private set; } = null!;
    public List<UserDocument> UserDocuments { get; private set; } = null!;
    public List<UserType> UserTypes { get; private set; } = null!;
}