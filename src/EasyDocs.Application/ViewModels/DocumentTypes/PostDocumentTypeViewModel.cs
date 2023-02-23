using EasyDocs.Domain.Enums;

namespace EasyDocs.Application.ViewModels.DocumentTypes;

public sealed class PostDocumentTypeViewModel
{
    public Guid UserId { get; set; }
    public Guid ClientId { get; set; }
    public EDocumentGroup DocumentGroup { get; set; }
    public string Description { get; set; } = string.Empty;
}