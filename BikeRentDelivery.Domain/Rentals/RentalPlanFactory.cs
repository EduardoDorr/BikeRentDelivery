using BikeRentDelivery.Common.Results;
using BikeRentDelivery.Domain.Rentals.Plans;

namespace BikeRentDelivery.Domain.Rentals;

internal static class RentalPlanFactory
{
    public static Result<IRentalPlan> CreatePlan(RentalPlan plan, DateTime startDate, DateTime expectedEndDate)
    {
        return plan switch
        {
            RentalPlan.Plan7Days => Result.Ok<IRentalPlan>(new RentalPlan7Days(startDate, expectedEndDate)),
            RentalPlan.Plan15Days => Result.Ok<IRentalPlan>(new RentalPlan15Days(startDate, expectedEndDate)),
            RentalPlan.Plan30Days => Result.Ok<IRentalPlan>(new RentalPlan30Days(startDate, expectedEndDate)),
            RentalPlan.Plan45Days => Result.Ok<IRentalPlan>(new RentalPlan45Days(startDate, expectedEndDate)),
            RentalPlan.Plan50Days => Result.Ok<IRentalPlan>(new RentalPlan50Days(startDate, expectedEndDate)),
            _ => Result.Fail<IRentalPlan>(RentalErrors.IsInvalidRentalPlan),
        };
    }
}