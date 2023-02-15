namespace EasyDocs.Application.ViewModels.UserDocuments;

public sealed class PostUserDocumentViewModel
{
    public Guid UserId { get; set; }
    public Guid DocumentId { get; set; }
    public Guid CompanyId { get; set; }
    public Guid LicenseeId { get; set; }
}
