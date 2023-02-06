using EasyDocs.Domain.Core.Entities;
using EasyDocs.Domain.Enums;
using EasyDocs.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore.Scaffolding;

namespace EasyDocs.Domain.Entities;

public sealed class UserTypes : Entity
{
    private UserTypes()
    { }

    public UserTypes(
        Guid licenseeId,
        Guid companyId,
        EErpUsersTypes erpUserType,
        Description description,
        Role roles
        )
    {
        LicenseeId = licenseeId;
        CompanyId = companyId;
        ErpUserType = erpUserType;
        Description = description;
        Roles = roles;

        AddNotifications(Description, Roles);
    }

    public Guid LicenseeId { get; private set; }
    public Guid CompanyId { get; private set; }
    public EErpUsersTypes ErpUserType { get; private set; }
    public Description Description { get; private set; } = null!;
    public Role Roles { get; private set; } = null!;

    public Licensee Licensee { get; private set; } = null!;
    public Company Company { get; private set; } = null!;
}