namespace EasyDocs.Application.ViewModels.UserDocuments;

public sealed class PostUserDocumentViewModel
{
    public Guid UserId { get; private set; }
    public Guid DocumentId { get; private set; }
    public Guid CompanyId { get; private set; }
    public Guid LicenseeId { get; private set; }
}
