using BikeRentDelivery.Common.DomainEvents;

namespace BikeRentDelivery.Common.Entities;

public abstract class BaseEntity
{
    public Guid Id { get; }
    public DateTime CreatedAt { get; }

    private readonly List<IDomainEvent> _domainEvents = [];

    protected BaseEntity()
    {
        Id = Guid.NewGuid();
        CreatedAt = DateTime.Now;
    }

    public IReadOnlyList<IDomainEvent> GetDomainEvents()
        => _domainEvents.ToList();

    public void ClearDomainEvents()
        => _domainEvents.Clear();

    protected void RaiseDomainEvent(IDomainEvent domainEvent)
        => _domainEvents.Add(domainEvent);
}