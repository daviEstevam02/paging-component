namespace EasyDocs.Application.ViewModels.Documents;

public sealed record PostDocumentViewModel
{
    public Guid UserId { get; set; }
    public Guid LicenseeId { get; set; }
    public Guid CompanyId { get; set; }
    public Guid DocumentTypeId { get; set; }
    public string Description { get; set; } = string.Empty;
    public string Source { get; set; } = string.Empty;
    public byte[]? File { get; set; }
    public bool SpecificAccess { get; set; }
}