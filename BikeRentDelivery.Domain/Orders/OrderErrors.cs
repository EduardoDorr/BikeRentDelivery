using BikeRentDelivery.Common.Results.Errors;

namespace BikeRentDelivery.Domain.Orders;

public sealed record OrderErrors(string Code, string Message, ErrorType Type) : IError
{
    public static readonly Error CannotBeCreated =
        new("Order.CannotBeCreated", "Something went wrong and the Order cannot be created", ErrorType.Failure);

    public static readonly Error CannotBeUpdated =
        new("Order.CannotBeUpdated", "Something went wrong and the Order cannot be updated", ErrorType.Failure);

    public static readonly Error CannotBeDeleted =
        new("Order.CannotBeDeleted", "Something went wrong and the Order cannot be deleted", ErrorType.Failure);

    public static readonly Error NotFound =
        new("Order.NotFound", "Could not find an active Order", ErrorType.NotFound);

    public static readonly Error IsInvalidValue =
        new("Order.IsInvalidValue", "Order's Value must be greater than 0", ErrorType.Validation);
}