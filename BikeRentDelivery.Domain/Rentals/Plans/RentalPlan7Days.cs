namespace BikeRentDelivery.Domain.Rentals.Plans;

internal class RentalPlan7Days : RentalPlanBase
{
    protected override int NumberOfDays => 7;
    protected override decimal PricePerDay => 30.00m;
    protected override decimal LateFeePerDay => 0.2m;

    public RentalPlan7Days(DateTime startDate, DateTime expectedEndDate)
        : base(startDate, expectedEndDate) { }
}