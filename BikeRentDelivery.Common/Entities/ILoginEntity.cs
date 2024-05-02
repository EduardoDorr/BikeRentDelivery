using BikeRentDelivery.Common.ValueObjects;

namespace BikeRentDelivery.Common.Entities;

public interface ILoginEntity
{
    public Password Password { get; }
}