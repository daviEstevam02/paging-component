using EasyDocs.Domain.Enums;

namespace EasyDocs.Application.ViewModels.UserTypes;

public sealed class PutUserTypeViewModel
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid LicenseeId { get; set; }
    public Guid CompanyId { get; set; }
    public EErpUsersTypes ErpUserType { get; set; }
    public string Description { get; set; }
    public bool CanRead { get; set; }
    public bool CanWrite { get; set; }
    public bool CanUpdate { get; set; }
    public bool CanDelete { get; set; }
}