using EasyDocs.Domain.Enums;
using EasyDocs.Domain.ValueObjects;

namespace EasyDocs.Application.ViewModels.Users;

public sealed class ResponseUserTypeUserViewModel
{
    public Guid Id { get; set; }
    public string ErpUserType { get; set; }
    public string Description { get; set; }
    public Role Roles { get; set; }
    public DateTime CreatedAt { get; set; }
    public string UpdatedAt { get; set; }
    public string Status { get; set; }
}