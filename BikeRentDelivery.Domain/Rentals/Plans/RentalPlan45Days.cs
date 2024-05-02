namespace BikeRentDelivery.Domain.Rentals.Plans;

internal class RentalPlan45Days : RentalPlanBase
{
    protected override int NumberOfDays => 45;
    protected override decimal PricePerDay => 20.00m;
    protected override decimal LateFeePerDay => 0.8m;

    public RentalPlan45Days(DateTime startDate, DateTime expectedEndDate)
        : base(startDate, expectedEndDate) { }
}