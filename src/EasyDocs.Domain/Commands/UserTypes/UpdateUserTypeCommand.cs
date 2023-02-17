using EasyDocs.Domain.Core.Commands;
using EasyDocs.Domain.Enums;
using Flunt.Validations;

namespace EasyDocs.Domain.Commands.UserTypes;

public sealed class UpdateUserTypeCommand : Command
{

    public UpdateUserTypeCommand(
        Guid id,
        Guid licenseeId,
        Guid companyId,
        EErpUsersTypes erpUserType,
        string description,
        bool canRead,
        bool canWrite,
        bool canUpdate,
        bool canDelete,
        Guid userId)
    {
        Id = id;
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

    public Guid Id { get; private set; }
    public Guid LicenseeId { get; private set; }
    public Guid CompanyId { get; private set; }
    public EErpUsersTypes ErpUserType { get; private set; }
    public string Description { get; private set; }
    public bool CanRead { get; private set; }
    public bool CanWrite { get; private set; }
    public bool CanUpdate { get; private set; }
    public bool CanDelete { get; private set; }

    #region Fail Fast Validations
    public override void Validate()
        => ValidateDescription();

    public void ValidateDescription()
        => AddNotifications(new Contract<UpdateUserTypeCommand>()
           .Requires()
           .IsNotNullOrEmpty(Description, "UpdateUserTypeCommand.Description", "A descrição não pode ser vazia.")
           .IsNotNullOrWhiteSpace(Description, "UpdateUserTypeCommand.Description", "A descrição não pode ser vazia.")
           .IsLowerOrEqualsThan(3, Description.Length, "UpdateUserTypeCommand.Description", "A descrição não deve conter menos de 3 caracteres.")
           .IsGreaterOrEqualsThan(150, Description.Length, "UpdateUserTypeCommand.Description", "A descrição não deve conter mais de 150 caracteres.")
           );

    #endregion
}