using EasyDocs.Domain.Core.Entities;
using EasyDocs.Domain.ValueObjects;

namespace EasyDocs.Domain.Entities;

public sealed class Client : Entity
{
    private Client() // Empty constructor for EF
    { }

    public Client(Guid id, Description description, CNPJ cnpj)
        : base(id)
    {
        Description = description;
        Cnpj = cnpj;

        AddNotifications(Description);
    }

    public Description Description { get; private set; } = null!;
    public CNPJ Cnpj { get; private set; } = null!;

    public IList<DocumentType> DocumentTypes { get; set; } = null!;
    public IList<User> Users { get; set; } = null!;
    public IList<Document> Documents { get; set; } = null!;
    public IList<UserDocument> UserDocuments { get; set; } = null!;
}