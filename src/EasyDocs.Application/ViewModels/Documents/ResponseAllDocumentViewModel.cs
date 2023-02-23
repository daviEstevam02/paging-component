using EasyDocs.Application.ViewModels.Clients;
using EasyDocs.Application.ViewModels.DocumentTypes;

namespace EasyDocs.Application.ViewModels.Documents;

public sealed class ResponseAllDocumentViewModel
{
    public Guid Id { get; set; }
    public ResponseClientViewModel Client { get; set; }
    public ResponseDocumentTypeDocumentViewModel DocumentType { get; set; }
    public string Description { get; set; }
    public string Source { get; set; }
    public DateTime ExpirationDate { get; set; }
    public bool SpecificAccess { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public string Status { get; set; }
}
