using EasyDocs.Application.ViewModels.Companies;

namespace EasyDocs.Application.ViewModels.DocumentTypes;

public sealed class ResponseDocumentTypeViewModel
{
    public Guid Id { get; set; }
    public ResponseCompanyViewModel Company { get; set; }
    public string DocumentGroup { get; set; }
    public string Description { get; set; }
    public DateTime CreatedAt { get; set; }
    public string UpdatedAt { get; set; }
    public string Status { get; set; }
}