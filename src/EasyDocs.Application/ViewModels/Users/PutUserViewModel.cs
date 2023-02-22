using EasyDocs.Domain.Enums;

namespace EasyDocs.Application.ViewModels.Users;

public sealed class PutUserViewModel
{
    public Guid UserId { get; set; }
    public Guid Id { get; set; }
    public Guid CompanyId { get; set; }
    public Guid LicenseeId { get; set; }
    public Guid UserTypeId { get; set; }
    public string LinkCode { get; set; }
    public EDocumentGroup DocumentGroup { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
}  