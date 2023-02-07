using EasyDocs.Domain.Core.Entities;
using EasyDocs.Domain.ValueObjects;
using Gooders.Shared.Core.Commands;

namespace EasyDocs.Domain.Commands.Documents;

public sealed class CreateDocumentCommand : Command
{
    public CreateDocumentCommand(
        Guid id, 
        Guid licenseeId, 
        Guid companyId, 
        Guid documentTypeId, 
        string description,
        string source, 
        byte[]? file, 
        bool specificAccess,
        Guid userId
        )
    {
        Id = id;
        LicenseeId = licenseeId;
        CompanyId = companyId;
        DocumentTypeId = documentTypeId;
        Description = description;
        Source = source;
        File = file;
        SpecificAccess = specificAccess;
        UserId = userId;
    }

    public Guid UserId { get; private set; }
    public Guid Id { get; private set; }
    public Guid LicenseeId { get; private set; }
    public Guid CompanyId { get; private set; }
    public Guid DocumentTypeId { get; private set; }
    public string Description { get; private set; } = null!;
    public string Source { get; private set; } = null!;
    public byte[]? File { get; private set; }
    public bool SpecificAccess { get; set; }

    public override void Validate()
    {
        throw new NotImplementedException();
    }
}