using BikeRentDelivery.Common.Results;
using BikeRentDelivery.Domain.Rentals;

namespace BikeRentDelivery.Tests.Unit.Rentals;

public class RentalBuilder
{
    private Guid _bikeId = Guid.NewGuid();
    private Guid _userId = Guid.NewGuid();
    private RentalPlan _rentalPlan = RentalPlan.Plan7Days;
    private DateTime _startDate = DateTime.Today;
    private DateTime _expectedEndDate = DateTime.Today.AddDays(7);

    public static RentalBuilder Create()
    {
        var userBuilder = new RentalBuilder();

        return userBuilder;
    }

    public RentalBuilder WithRentalPlan(RentalPlan rentalPlan)
    {
        _rentalPlan = rentalPlan;

        return this;
    }

    public RentalBuilder WithDates(DateTime startDate, DateTime expectedEndDate)
    {
        _startDate = startDate;
        _expectedEndDate = expectedEndDate;

        return this;
    }

    public Result<Rental> Build()
    {
        return
            Rental.Create(
                _bikeId,
                _userId,
                _rentalPlan,
                _startDate,
                _expectedEndDate);
    }
}