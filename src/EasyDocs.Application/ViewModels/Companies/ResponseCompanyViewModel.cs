using EasyDocs.Application.ViewModels.Licensees;

namespace EasyDocs.Application.ViewModels.Companies;

public sealed class ResponseCompanyViewModel
{
    public Guid Id { get;  set; }
    public ResponseLicenseeViewModel Licensee { get; set; } = null!;
    public string FantasyName { get; set; } = string.Empty;
    public string LegalName { get; set; } = string.Empty;
    public string Country { get; set; } = string.Empty;
    public string State { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string Neighborhood { get; set; } = string.Empty;
    public string Street { get; set; } = string.Empty;
    public string Number { get; set; } = string.Empty;
    public string Compliment { get; set; } = string.Empty;
    public string Contact { get; set; } = string.Empty;
    public string Cnpj { get; set; } = string.Empty;
    public bool IsHeadquarter { get; set; }
    public DateTime CreatedAt { get; set; }
    public string UpdatedAt { get; set; }
    public string Status { get; set; }
}