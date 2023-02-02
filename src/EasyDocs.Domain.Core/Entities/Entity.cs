using Flunt.Notifications;

namespace EasyDocs.Domain.Core.Entities;

public abstract class Entity : Notifiable<Notification>
{
    protected Entity() 
    { }

    public Entity(Guid id)
    {
        Id = id;
        CreatedAt = DateTime.Now.ToLocalTime();
        UpdatedAt = CreatedAt;
        Status = EStatus.Active;
    }

    public Guid Id { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime UpdatedAt { get; private set; }
    public EStatus Status { get; private set; }

    public void Update() => UpdatedAt = DateTime.Now.ToLocalTime();
    public void Activate() => Status = EStatus.Active;
    public void Deactivate() => Status = EStatus.Inactive;
}

public enum EStatus
{
    Inactive,
    Active
}