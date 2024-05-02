using BikeRentDelivery.Common.Results;
using BikeRentDelivery.Common.Entities;
using BikeRentDelivery.Domain.Bikes;
using BikeRentDelivery.Domain.Users;
using BikeRentDelivery.Domain.Orders;

namespace BikeRentDelivery.Domain.Rentals;

public sealed class Rental : BaseEntity, IUpdatableEntity, IDeletableEntity
{
    public Guid BikeId { get; private set; }
    public Guid UserId { get; private set; }
    public RentalPlan Plan { get; private set; }
    public RentalStatus Status { get; private set; }
    public DateTime StartDate { get; private set; }
    public DateTime EndDate { get; private set; }
    public DateTime ExpectedEndDate { get; private set; }
    public decimal RentalCost { get; private set; }
    public decimal LateFeeCost { get; private set; }
    public decimal AdditionalCost { get; private set; }
    public DateTime? UpdatedAt { get; }
    public bool IsDeleted { get; }

    public Bike Bike { get; private set; }
    public User User { get; private set; }
    public List<Order> Orders { get; private set; }

    private Rental() { }

    private Rental(
        Guid bikeId,
        Guid userId,
        RentalPlan rentalPlan,
        DateTime startDate,
        DateTime endDate,
        DateTime expectedEndDate,
        decimal rentalCost,
        decimal lateFeeCost,
        decimal additionalCost)
    {
        BikeId = bikeId;
        UserId = userId;
        Plan = rentalPlan;
        StartDate = startDate;
        EndDate = endDate;
        ExpectedEndDate = expectedEndDate;
        RentalCost = rentalCost;
        LateFeeCost = lateFeeCost;
        AdditionalCost = additionalCost;

        Status = RentalStatus.Active;
    }

    public static Result<Rental> Create(
        Guid bikeId,
        Guid userId,
        RentalPlan rentalPlan,
        DateTime startDate,
        DateTime expectedEndDate)
    {
        var isValidStartDate = IsValidStartDate(startDate);

        if (!isValidStartDate)
            return Result.Fail<Rental>(RentalErrors.IsInvalidStartDate);

        var isValidExpectedEndDate = IsValidExpectedEndDate(expectedEndDate, startDate);

        if (!isValidExpectedEndDate)
            return Result.Fail<Rental>(RentalErrors.IsInvalidExpectedEndDate);

        var rentalPlanResult = RentalPlanFactory.CreatePlan(rentalPlan, startDate, expectedEndDate);

        if (!rentalPlanResult.Success)
            return Result.Fail<Rental>(rentalPlanResult.Errors);

        var endDate = rentalPlanResult.Value.EndDate;
        var rentalCost = rentalPlanResult.Value.RentalCost;
        var lateFeeCost = rentalPlanResult.Value.LateFeeCost;
        var additionalCost = rentalPlanResult.Value.AdditionalCost;

        var rental =
            new Rental(
                bikeId,
                userId,
                rentalPlan,
                startDate,
                endDate,
                expectedEndDate,
                rentalCost,
                lateFeeCost,
                additionalCost);

        return Result<Rental>.Ok(rental);
    }

    public void Update(string name, string description, int duration)
    {
        
    }

    private static bool IsValidStartDate(DateTime startDate) =>
        startDate.Date.CompareTo(DateTime.Today) >= 0;

    private static bool IsValidExpectedEndDate(DateTime expectedEndDate, DateTime startDate) =>
        expectedEndDate.Date.CompareTo(startDate) > 0;
}