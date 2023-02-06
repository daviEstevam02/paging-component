using Flunt.Notifications;

namespace EasyDocs.Domain.Core.Entities;

public abstract class Entity : Notifiable<Notification>, IAggregateRoot
{
    protected Entity()
    { }

    protected Entity(Guid id)
    {
        Id = id;
        Status = EStatus.Active;
        CreatedAt = DateTime.Now.ToLocalTime();
        UpdatedAt = DateTime.Now.ToLocalTime();
    }

    public Guid Id { get; private set; }
    public EStatus Status { get; protected set; }
    public DateTime CreatedAt { get; protected set; }
    public DateTime UpdatedAt { get; protected set; }

    protected void Activate() => Status = EStatus.Active;
    protected void Deactivate() => Status = EStatus.Inactive;
    protected void Update() => UpdatedAt = DateTime.Now.ToLocalTime();
}

public enum EStatus
{
    Inactive,
    Active
}