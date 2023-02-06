using EasyDocs.Domain.Core.Entities;
using EasyDocs.Domain.Enums;
using EasyDocs.Domain.ValueObjects;

namespace EasyDocs.Domain.Entities;

public sealed class UserType : Entity
{
    private UserType()
    { }

    public UserType(
        Guid id,
        Guid licenseeId,
        Guid companyId,
        EErpUsersTypes erpUserType,
        Description description,
        Role roles
        ) : base(id)
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
    public IList<User> Users { get; private set; } = null!;
}