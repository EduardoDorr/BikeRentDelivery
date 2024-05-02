namespace BikeRentDelivery.Domain.Rentals.Plans;

internal class RentalPlan30Days : RentalPlanBase
{
    protected override int NumberOfDays => 30;
    protected override decimal PricePerDay => 22.00m;
    protected override decimal LateFeePerDay => 0.6m;

    public RentalPlan30Days(DateTime startDate, DateTime expectedEndDate)
        : base(startDate, expectedEndDate) { }
}