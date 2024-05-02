using BikeRentDelivery.Common.Results.Errors;

namespace BikeRentDelivery.Domain.Bikes;

public sealed record BikeErrors(string Code, string Message, ErrorType Type) : IError
{
    public static readonly Error CannotBeCreated =
        new("Bike.CannotBeCreated", "Something went wrong and the Bike cannot be created", ErrorType.Failure);

    public static readonly Error CannotBeUpdated =
        new("Bike.CannotBeUpdated", "Something went wrong and the Bike cannot be updated", ErrorType.Failure);

    public static readonly Error CannotBeDeleted =
        new("Bike.CannotBeDeleted", "Something went wrong and the Bike cannot be deleted", ErrorType.Failure);

    public static readonly Error NotFound =
        new("Bike.NotFound", "Could not find an active Bike", ErrorType.NotFound);

    public static readonly Error IsInvalidYear =
        new("Bike.IsInvalidYear", "The Bike's Year is an invalid year", ErrorType.Validation);

    public static readonly Error IsNotUnique =
        new("Bike.IsNotUnique", "The Bike's License Plate is already taken", ErrorType.Conflict);
}