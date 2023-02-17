using EasyDocs.Domain.Core.Commands;
using EasyDocs.Domain.Enums;
using EasyDocs.Domain.ValueObjects;

namespace EasyDocs.Domain.Commands.Users;

public sealed class UpdateUserCommand : Command
{
    public UpdateUserCommand(
        Guid id, 
        Guid licenseeId, 
        Guid companyId, 
        Guid userTypeId, 
        string linkCode, 
        EDocumentGroup documentGroup,
        string username,
        string email,
        string password,
        Guid userId)
    {
        Id = id;
        UserId = userId;
        LicenseeId = licenseeId;
        CompanyId = companyId;
        UserTypeId = userTypeId;
        LinkCode = linkCode;
        DocumentGroup = documentGroup;
        Username = username;
        Email = email;
        Password = password;
    }

    public Guid Id { get; private set; }
    public Guid LicenseeId { get; private set; }
    public Guid CompanyId { get; private set; }
    public Guid UserTypeId { get; private set; }
    public string LinkCode { get; private set; }
    public EDocumentGroup DocumentGroup { get; private set; }
    public string Username { get; private set; }
    public string Email { get; private set; }
    public string Password { get; private set; }

    #region Fail Fast Validations
    public override void Validate()
    {
        throw new NotImplementedException();
    }
    #endregion
}