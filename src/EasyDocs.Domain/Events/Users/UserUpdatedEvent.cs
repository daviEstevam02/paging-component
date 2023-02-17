using EasyDocs.Domain.Core.Events;
using EasyDocs.Domain.Core.Messaging;
using EasyDocs.Domain.Enums;
using EasyDocs.Domain.Helpers;
using EasyDocs.Domain.ValueObjects;

namespace EasyDocs.Domain.Events.Users;

public sealed class UserUpdatedEvent : Event
{
    public UserUpdatedEvent(
        Guid id,
        Guid licenseeId,
        Guid companyId,
        Guid userTypeId,
        string linkCode,
        EDocumentGroup documentGroup,
        Username userUsername,
        Email email,
        Password password,
        Guid userId,
        string username
        ) : base(EAction.Updated, userId, username, EntitiesContexts.USERS)
    {
        AggregateId = id;
        Id = id;
        LicenseeId = licenseeId;
        CompanyId = companyId;
        UserTypeId = userTypeId;
        LinkCode = linkCode;
        DocumentGroup = documentGroup;
        UserUsername = userUsername;
        Email = email;
        Password = password;
    }

    public Guid Id { get; private set; }
    public Guid LicenseeId { get; private set; }
    public Guid CompanyId { get; private set; }
    public Guid UserTypeId { get; private set; }
    public string LinkCode { get; set; } = string.Empty;
    public EDocumentGroup DocumentGroup { get; private set; }
    public Username UserUsername { get; private set; } = null!;
    public Email Email { get; private set; } = null!;
    public Password Password { get; private set; } = null!;
}