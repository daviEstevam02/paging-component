using EasyDocs.Domain.Core.Messaging;
using Flunt.Notifications;

namespace EasyDocs.Domain.Core.Entities;

public abstract class Entity : Notifiable<Notification>, IAggregateRoot
{
    private List<Event>? _domainEvents;

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

    public IReadOnlyCollection<Event> DomainEvents => _domainEvents?.AsReadOnly()!;

    public void Activate()
    {
        if (IsValid) Status = EStatus.Active;
    }

    public void Deactivate()
    {
        if (IsValid) Status = EStatus.Inactive;
    }

    public void Update(DateTime createdAt)
    {
        if (IsValid)
        {
            CreatedAt = createdAt;
            UpdatedAt = DateTime.Now.ToLocalTime();
        }
    }

    public void AddDomainEvent(Event domainEvent)
    {
        _domainEvents ??= new List<Event>();
        _domainEvents.Add(domainEvent);
    }

    public void RemoveDomainEvent(Event domainEvent) => _domainEvents?.Remove(domainEvent);

    public void ClearDomainEvents() => _domainEvents?.Clear();
}

public enum EStatus
{
    Inactive,
    Active
}