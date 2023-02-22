using EasyDocs.Application.ViewModels.Companies;

namespace EasyDocs.Application.ViewModels.Users;

public sealed class ResponseUserViewModel
{
    public Guid Id { get; set; }
    public ResponseCompanyViewModel Company { get; set; }
    public ResponseUserTypeUserViewModel UserType { get; set; }
    public string LinkCode { get; set; }
    public string DocumentGroup { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public string Status { get; set; }
}