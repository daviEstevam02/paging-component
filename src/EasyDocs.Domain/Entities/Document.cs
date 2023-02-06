using EasyDocs.Domain.Core.Entities;
using EasyDocs.Domain.Enums;
using EasyDocs.Domain.ValueObjects;

namespace EasyDocs.Domain.Entities;

public sealed class Document : Entity
{
    private Document()
    { }

    public Guid LicenseeId { get; private set; }
    public Guid CompanyId { get; private set; }
    public Guid DocumentTypeId { get; private set; }
    public Description Description { get; private set; } = null!;
    public Source Source { get; private set; } = null!;
    public string File { get; private set; } = string.Empty;
    public bool SpecificAccess { get; set; }

    public DocumentType DocumentType { get; private set; } = null!;
    public Company Company { get; private set; } = null!;
    public Licensee Licensee { get; private set; } = null!;
}