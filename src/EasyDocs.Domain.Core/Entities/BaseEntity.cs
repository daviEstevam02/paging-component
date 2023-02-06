using NetDevPack.Domain;

namespace EasyDocs.Domain.Core.Entities;

public abstract class BaseEntity : Entity, IAggregateRoot
{
    protected BaseEntity()
    { }

    protected BaseEntity(Guid id)
    {
        Id = id;
        Status = EStatus.Active;
        CreatedAt = DateTime.Now.ToLocalTime();
        UpdatedAt = DateTime.Now.ToLocalTime();
    }

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