using EasyDocs.Domain.Core.Commands;
using EasyDocs.Domain.Enums;
using Flunt.Validations;

namespace EasyDocs.Domain.Commands.DocumentTypes;

public sealed class CreateDocumentTypeCommand : Command
{
    public CreateDocumentTypeCommand(
        Guid id, 
        Guid licenseeId,
        Guid companyId, 
        EDocumentGroup documentGroup,
        string description,
        Guid userId
        )
    {
        Id = id;
        LicenseeId = licenseeId;
        CompanyId = companyId;
        DocumentGroup = documentGroup;
        Description = description;
        UserId = userId;
    }

    public Guid Id { get; private set; }
    public Guid LicenseeId { get; private set; }
    public Guid CompanyId { get; private set; }
    public EDocumentGroup DocumentGroup { get; private set; }
    public string Description { get; private set; } = string.Empty;

    #region Fail Fast Validations
    public override void Validate()
    {
        ValidateDescription();
    }

    public void ValidateDescription()
    {
        AddNotifications(new Contract<CreateDocumentTypeCommand>()
            .Requires()
            .IsNotNullOrEmpty(Description, "CreateDocumentTypeCommand.Description", "A descrição não pode ser vazia.")
            .IsNotNullOrWhiteSpace(Description, "CreateDocumentTypeCommand.Description", "A descrição não pode ser vazia.")
            .IsLowerOrEqualsThan(3, Description.Length, "CreateDocumentTypeCommand.Description", "A descrição não deve conter menos de 3 caracteres.")
            .IsGreaterOrEqualsThan(150, Description.Length, "CreateDocumentTypeCommand.Description", "A descrição não deve conter mais de 150 caracteres.")
            );
    }
    #endregion
}