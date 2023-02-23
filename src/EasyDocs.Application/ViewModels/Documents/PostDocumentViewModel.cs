using Microsoft.AspNetCore.Http;

namespace EasyDocs.Application.ViewModels.Documents;

public sealed record PostDocumentViewModel
{
    public Guid UserId { get; set; }
    public Guid ClientId { get; set; }
    public Guid DocumentTypeId { get; set; }
    public string Description { get; set; } = string.Empty;
    public string Source { get; set; } = string.Empty;
    public DateTime ExpirationDate { get; set; }
    public IFormFile? File { get; set; }
    public bool SpecificAccess { get; set; }
}