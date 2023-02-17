using EasyDocs.Domain.Enums;

namespace EasyDocs.Application.ViewModels.Users;

public sealed class PostUserViewModel
{
    public Guid CompanyId { get; set; }
    public Guid LicenseeId { get; set; }
    public Guid UserTypeId { get; set; }
    public string LinkCode { get; set; }
    public EDocumentGroup DocumentGroup { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
}