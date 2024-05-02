namespace BikeRentDelivery.Common.Entities;

public interface IDeletableEntity
{
    public bool IsDeleted { get; }
}