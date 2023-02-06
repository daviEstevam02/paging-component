using EasyDocs.Domain.Core.Entities;
using EasyDocs.Domain.Enums;
using EasyDocs.Domain.ValueObjects;

namespace EasyDocs.Domain.Entities;

public sealed class User : Entity
{
	private User()
	{ }

    public Guid LicenseeId { get; private set; }
    public Guid CompanyId { get; private set; }
    public Guid UserTypeId { get; private set; }
    public EDocumentGroup DocumentGroup { get; private set; }
    public Username Username { get; private set; }
    public Email Email { get; private set; }
    public Password Password { get; private set; }

    public Licensee Licensee { get; private set; } = null!;
    public Company Company { get; private set; } = null!;
    public UserType UserType { get; private set; } = null!;
}