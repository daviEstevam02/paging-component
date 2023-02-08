using EasyDocs.Domain.Core.Commands;
using Flunt.Validations;

namespace EasyDocs.Domain.Commands.Documents;

public sealed class CreateDocumentCommand : Command
{
    public CreateDocumentCommand(
        Guid licenseeId, 
        Guid companyId, 
        Guid documentTypeId, 
        string description,
        string source, 
        DateTime expirationDate,
        byte[]? file, 
        bool specificAccess,
        Guid userId
        )
    {
        LicenseeId = licenseeId;
        CompanyId = companyId;
        DocumentTypeId = documentTypeId;
        Description = description;
        Source = source;
        File = file;
        SpecificAccess = specificAccess;
        UserId = userId;
    }

    public Guid UserId { get; private set; }
    public Guid Id { get; private set; }
    public Guid LicenseeId { get; private set; }
    public Guid CompanyId { get; private set; }
    public Guid DocumentTypeId { get; private set; }
    public string Description { get; private set; }
    public string Source { get; private set; }
    public DateTime ExpirationDate { get; private set; }
    public byte[]? File { get; private set; }
    public bool SpecificAccess { get; private set; }

    #region Fail Fast Validations
    public override void Validate()
    {
        ValidateDescription();
        ValidateSource();
    }

    public void ValidateDescription()
    {
        AddNotifications(new Contract<CreateDocumentCommand>()
            .Requires()
            .IsNotNullOrEmpty(Description, "CreateDocumentCommand.Description", "A descrição não pode ser vazia.")
            .IsNotNullOrWhiteSpace(Description, "CreateDocumentCommand.Description", "A descrição não pode ser vazia.")
            .IsLowerOrEqualsThan(3, Description.Length, "CreateDocumentCommand.Description", "A descrição não deve conter menos de 3 caracteres.")
            .IsGreaterOrEqualsThan(150, Description.Length, "CreateDocumentCommand.Description", "A descrição não deve conter mais de 150 caracteres.")
            );
    }

    public void ValidateSource()
    {
        AddNotifications(new Contract<CreateDocumentCommand>()
           .Requires()
           .IsNotNullOrEmpty(Source, "CreateDocumentCommand.Source", "A origem não pode ser vazia.")
           .IsNotNullOrWhiteSpace(Source, "CreateDocumentCommand.Source", "A origem não pode ser vazia.")
           .IsLowerOrEqualsThan(3, Source.Length, "CreateDocumentCommand.Source", "A origem não deve conter menos de 3 caracteres.")
           );
    }

    #endregion
}