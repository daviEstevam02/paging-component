using EasyDocs.Domain.Core.Commands;
using EasyDocs.Domain.Enums;
using Flunt.Validations;

namespace EasyDocs.Domain.Commands.UserTypes;

public sealed class CreateUserTypeCommand : Command
{
    public CreateUserTypeCommand(
        Guid licenseeId,
        Guid companyId, EErpUsersTypes erpUserType,
        string description,
        bool canRead,
        bool canWrite,
        bool canUpdate,
        bool canDelete,
        Guid userId)
    {
        UserId = userId;
        LicenseeId = licenseeId;
        CompanyId = companyId;
        ErpUserType = erpUserType;
        Description = description;
        CanRead = canRead;
        CanWrite = canWrite;
        CanUpdate = canUpdate;
        CanDelete = canDelete;
    }

    public Guid LicenseeId { get; private set; }
    public Guid CompanyId { get; private set; }
    public EErpUsersTypes ErpUserType { get; private set; }
    public string Description { get; private set; }
    public bool CanRead { get; private set; }
    public bool CanWrite { get; private set; }
    public bool CanUpdate { get; private set; }
    public bool CanDelete { get; private set; }

    #region Fast Fail Validations
    public override void Validate()
    {
        ValidateDescription();
    }

    public void ValidateDescription()
    {
        AddNotifications(new Contract<CreateUserTypeCommand>()
           .Requires()
           .IsNotNullOrEmpty(Description, "CreateUserTypesCommand.Description", "A descrição não pode ser vazia.")
           .IsNotNullOrWhiteSpace(Description, "CreateUserTypesCommand.Description", "A descrição não pode ser vazia.")
           .IsLowerOrEqualsThan(3, Description.Length, "CreateUserTypesCommand.Description", "A descrição não deve conter menos de 3 caracteres.")
           .IsGreaterOrEqualsThan(150, Description.Length, "CreateUserTypesCommand.Description", "A descrição não deve conter mais de 150 caracteres.")
           );
    }
    #endregion
}