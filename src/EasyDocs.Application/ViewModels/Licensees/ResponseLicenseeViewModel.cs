namespace EasyDocs.Application.ViewModels.Licensees;

public sealed record ResponseLicenseeViewModel
{
    public Guid Id { get; set; }
    public string Description { get; set; } = string.Empty;
}