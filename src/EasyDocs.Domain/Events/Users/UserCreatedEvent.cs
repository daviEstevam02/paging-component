using EasyDocs.Domain.Core.Events;
using EasyDocs.Domain.Core.Messaging;
using EasyDocs.Domain.Enums;
using EasyDocs.Domain.Helpers;
using EasyDocs.Domain.ValueObjects;

namespace EasyDocs.Domain.Events.Users;

public sealed class UserCreatedEvent : Event
{
    public UserCreatedEvent(
        Guid id, 
        Guid clientId, 
        EUserTypes userType, 
        string linkCode, 
        EDocumentGroup documentGroup, 
        Username userUsername, 
        Email email, 
        Password password,
        Guid userId,
        string username
        ) : base(EAction.Created, userId, username, EntitiesContexts.USERS)
    {
        AggregateId = id;
        Id = id;
        ClientId = clientId;
        UserType = userType;
        LinkCode = linkCode;
        DocumentGroup = documentGroup;
        UserUsername = userUsername;
        Email = email;
        Password = password;
    }

    public Guid Id { get; private set; }
    public Guid ClientId { get; private set; }
    public EUserTypes UserType { get; private set; }
    public string LinkCode { get; set; }
    public EDocumentGroup DocumentGroup { get; private set; }
    public Username UserUsername { get; private set; }
    public Email Email { get; private set; }
    public Password Password { get; private set; }
}