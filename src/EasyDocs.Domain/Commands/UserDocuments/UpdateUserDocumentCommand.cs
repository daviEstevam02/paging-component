using EasyDocs.Domain.Core.Commands;

namespace EasyDocs.Domain.Commands.UserDocuments;

public sealed class UpdateUserDocumentCommand : Command
{
    public UpdateUserDocumentCommand(Guid id, Guid userId, Guid documentId, Guid companyId, Guid licenseeId)
    {
        Id = id;
        UserId = userId;
        DocumentId = documentId;
        CompanyId = companyId;
        LicenseeId = licenseeId;
    }

    public Guid Id { get; private set; }
    public Guid UserId { get; private set; }
    public Guid DocumentId { get; private set; }
    public Guid CompanyId { get; private set; }
    public Guid LicenseeId { get; private set; }

    #region Fail Fast Validations
    public override void Validate()
    {
        throw new NotImplementedException();
    }
    #endregion
}
