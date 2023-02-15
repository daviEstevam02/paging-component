namespace EasyDocs.Application.ViewModels.UserDocuments
{
    public sealed class ResponseUserDocumentViewModel
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid DocumentId { get; set; }
        public Guid CompanyId { get; set; }
        public Guid LicenseeId { get;  set; }
        public DateTime CreatedAt { get; set; }
        public string UpdatedAt { get; set; }
        public string Status { get; set; }
    }
}
