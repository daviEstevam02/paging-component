using EasyDocs.Application.ViewModels.Companies;

namespace EasyDocs.Application.ViewModels.Documents;

public sealed class ResponseOneDocumentViewModel
{
    public Guid Id { get; set; }
    public ResponseCompanyViewModel Company { get; set; }
    public ResponseDocumentTypeDocumentViewModel DocumentType { get; set; }
    public string Description { get; set; }
    public string Source { get; set; }
    public DateTime ExpirationDate { get; set; }
    public byte[]? File { get; set; }
    public bool SpecificAccess { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public string Status { get; set; }
}