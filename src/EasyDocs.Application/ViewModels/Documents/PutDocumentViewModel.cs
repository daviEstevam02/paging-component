namespace EasyDocs.Application.ViewModels.Documents;

public sealed class PutDocumentViewModel
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid LicenseeId { get; set; }
    public Guid CompanyId { get; set; }
    public Guid DocumentTypeId { get; set; }
    public string Description { get; set; }
    public string Source { get; set; }
    public DateTime ExpirationDate { get; set; }
    public byte[]? File { get; set; }
    public bool SpecificAccess { get; set; }
}