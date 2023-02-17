using EasyDocs.Domain.Core.Events;
using EasyDocs.Domain.Core.Messaging;
using EasyDocs.Domain.Enums;
using EasyDocs.Domain.Helpers;
using EasyDocs.Domain.ValueObjects;

namespace EasyDocs.Domain.Events.UserTypes;

public sealed class UserTypeCreatedEvent : Event
{
    public UserTypeCreatedEvent(
        Guid id, 
        Guid licenseeId, 
        Guid companyId, 
        EErpUsersTypes erpUserType, 
        Description description, 
        Role roles,
        Guid userId,
        string username
        ) : base(EAction.Created, userId, username, EntitiesContexts.USER_TYPES)
    {
        AggregateId = id;
        Id = id;
        LicenseeId = licenseeId;
        CompanyId = companyId;
        ErpUserType = erpUserType;
        Description = description;
        Roles = roles;
    }

    public Guid Id { get; private set; }
    public Guid LicenseeId { get; private set; }
    public Guid CompanyId { get; private set; }
    public EErpUsersTypes ErpUserType { get; private set; }
    public Description Description { get; private set; }
    public Role Roles { get; private set; }
}