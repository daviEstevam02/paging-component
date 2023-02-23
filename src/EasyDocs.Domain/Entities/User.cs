using EasyDocs.Domain.Core.Entities;
using EasyDocs.Domain.Enums;
using EasyDocs.Domain.ValueObjects;

namespace EasyDocs.Domain.Entities;

public sealed class User : Entity
{
    private User()
	{ }

    public User(
        Guid id, 
        Guid clientId, 
        EUserTypes userType, 
        string linkCode,
        EDocumentGroup documentGroup, 
        Username username, 
        Email email, 
        Password password
        ) : base(id)
    {
        ClientId = clientId;
        UserType = userType;
        LinkCode = linkCode;
        DocumentGroup = documentGroup;
        Username = username;
        Email = email;
        Password = password;

        AddNotifications(Username, Email, Password);
    }

    public Guid ClientId { get; private set; }
    public EUserTypes UserType { get; private set; }
    public string LinkCode { get; private set; } = string.Empty;
    public EDocumentGroup DocumentGroup { get; private set; }
    public Username Username { get; private set; } = null!;
    public Email Email { get; private set; } = null!;
    public Password Password { get; private set; } = null!;

    public Client Client { get; private set; } = null!;
    public IList<UserDocument> UserDocuments { get; private set; } = null!;
}