using EasyDocs.Domain.Core.Entities;
using EasyDocs.Domain.ValueObjects;

namespace EasyDocs.Domain.Entities;

public sealed class Licensee : Entity
{
    private Licensee() 
    { }

    public Licensee(Guid id, Description description)
        : base(id)
    {
        Description = description;

        AddNotifications(Description);
    }

    public Description Description { get; private set; } = null!;
}