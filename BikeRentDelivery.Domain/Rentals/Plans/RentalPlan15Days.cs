namespace BikeRentDelivery.Domain.Rentals.Plans;

internal class RentalPlan15Days : RentalPlanBase
{
    protected override int NumberOfDays => 15;
    protected override decimal PricePerDay => 28.00m;
    protected override decimal LateFeePerDay => 0.4m;

    public RentalPlan15Days(DateTime startDate, DateTime expectedEndDate)
        : base(startDate, expectedEndDate) { }
}