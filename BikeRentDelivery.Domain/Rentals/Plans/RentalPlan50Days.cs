namespace BikeRentDelivery.Domain.Rentals.Plans;

internal class RentalPlan50Days : RentalPlanBase
{
    protected override int NumberOfDays => 50;
    protected override decimal PricePerDay => 18.00m;
    protected override decimal LateFeePerDay => 1.0m;

    public RentalPlan50Days(DateTime startDate, DateTime expectedEndDate)
        : base(startDate, expectedEndDate) { }
}