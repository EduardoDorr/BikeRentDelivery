namespace BikeRentDelivery.Domain.Rentals.Plans;

internal abstract class RentalPlanBase : IRentalPlan
{
    public DateTime EndDate { get; private set; }
    public decimal RentalCost { get; private set; }
    public decimal LateFeeCost { get; private set; }
    public decimal AdditionalCost { get; private set; }

    protected abstract int NumberOfDays { get; }
    protected abstract decimal PricePerDay { get; }
    protected abstract decimal LateFeePerDay { get; }
    protected virtual decimal AdditionalPerDay { get; } = 50.0m;

    protected RentalPlanBase(DateTime startDate, DateTime expectedEndDate)
    {
        CalculateEndDate(startDate);
        CalculateCosts(startDate, expectedEndDate);
    }

    private void CalculateEndDate(DateTime startDate)
    {
        EndDate = startDate.AddDays(NumberOfDays);
    }

    protected virtual void CalculateCosts(DateTime startDate, DateTime expectedEndDate)
    {
        var expectedNumberOfDays = (int)expectedEndDate.Subtract(startDate).TotalDays;

        var differenceNumberOfDays = NumberOfDays - expectedNumberOfDays;

        RentalCost = differenceNumberOfDays >= 0
            ? expectedNumberOfDays * PricePerDay
            : NumberOfDays * PricePerDay;

        if (differenceNumberOfDays == 0)
            return;

        if (differenceNumberOfDays > 0)
            LateFeeCost = (differenceNumberOfDays * PricePerDay) * LateFeePerDay;
        else
            AdditionalCost = Math.Abs(differenceNumberOfDays) * AdditionalPerDay;
    }
}

internal interface IRentalPlan
{
    DateTime EndDate { get; }
    decimal RentalCost { get; }
    decimal LateFeeCost { get; }
    decimal AdditionalCost { get; }
}