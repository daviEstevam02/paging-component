namespace EasyDocs.Application.ViewModels.UserDocuments
{
    public sealed class ResponseUserDocumentViewModel
    {
        public Guid Id { get; private set; }
        public Guid UserId { get; private set; }
        public Guid DocumentId { get; private set; }
        public Guid CompanyId { get; private set; }
        public Guid LicenseeId { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public string UpdatedAt { get; private set; }
        public string Status { get; private set; }
    }
}
