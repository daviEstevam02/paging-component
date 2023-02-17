using EasyDocs.Application.ViewModels.Companies;
using EasyDocs.Domain.ValueObjects;

namespace EasyDocs.Application.ViewModels.UserTypes;

public sealed class ResponseUserTypeViewModel
{
    public Guid Id { get; set; }
    public ResponseCompanyViewModel Company { get; set; }
    public string ErpUserType { get; set; }
    public string Description { get; set; }
    public Role Roles { get; set; } = null!;
    public DateTime CreatedAt { get; set; }
    public string UpdatedAt { get; set; }
    public string Status { get; set; }
}