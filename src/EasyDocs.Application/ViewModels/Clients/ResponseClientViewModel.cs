namespace EasyDocs.Application.ViewModels.Clients;

public sealed class ResponseClientViewModel
{
    public Guid Id { get; set; }
    public string Description { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public string Status { get; set; }
}