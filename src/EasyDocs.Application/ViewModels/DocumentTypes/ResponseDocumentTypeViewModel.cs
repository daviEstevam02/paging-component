using EasyDocs.Application.ViewModels.Companies;

namespace EasyDocs.Application.ViewModels.DocumentTypes;

public sealed class ResponseDocumentTypeViewModel
{
    public Guid Id { get; private set; }
    public ResponseCompanyViewModel Company { get; private set; }
    public string DocumentGroup { get; private set; }
    public string Description { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public string UpdatedAt { get; private set; }
    public string Status { get; private set; }
}