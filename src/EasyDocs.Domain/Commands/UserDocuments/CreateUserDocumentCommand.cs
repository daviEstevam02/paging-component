using EasyDocs.Domain.Core.Commands;

namespace EasyDocs.Domain.Commands.UserDocuments
{
    public sealed class CreateUserDocumentCommand : Command
    {
        public CreateUserDocumentCommand(
            Guid id,
            Guid userId,
            Guid documentId,
            Guid companyId,
            Guid licensseId
            )
        {
            Id = id;
            UserId = userId;
            DocumentId = documentId;
            CompanyId = companyId;
            LicenseeId = licensseId;
        }

        public Guid Id { get; private set; }
        public Guid UserId { get; private set; }
        public Guid DocumentId { get; private set; }

        public Guid CompanyId  { get; private set; }
        public Guid LicenseeId { get; private set; }

        #region Fail Fast Validations
        public override void Validate()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
