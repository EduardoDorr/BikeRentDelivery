using BikeRentDelivery.Common.Results.Errors;

namespace BikeRentDelivery.Domain.Rentals;

public sealed record RentalErrors(string Code, string Message, ErrorType Type) : IError
{
    public static readonly Error CannotBeCreated =
        new("Rental.CannotBeCreated", "Something went wrong and the Rental cannot be created", ErrorType.Failure);

    public static readonly Error CannotBeUpdated =
        new("Rental.CannotBeUpdated", "Something went wrong and the Rental cannot be updated", ErrorType.Failure);

    public static readonly Error CannotBeDeleted =
        new("Rental.CannotBeDeleted", "Something went wrong and the Rental cannot be deleted", ErrorType.Failure);

    public static readonly Error NotFound =
        new("Rental.NotFound", "Could not find an active Rental", ErrorType.NotFound);

    public static readonly Error IsNotUnique =
        new("Rental.IsNotUnique", "The Rental's name is already taken", ErrorType.Conflict);

    public static readonly Error IsInvalidStartDate =
        new("Rental.IsInvalidStartDate", "Rental's Start Date must be later than or equal to today", ErrorType.Validation);

    public static readonly Error IsInvalidExpectedEndDate =
        new("Rental.IsInvalidExpectedEndDate", "Rental's Expected End Date must be later than Start Date", ErrorType.Validation);

    public static readonly Error IsInvalidRentalPlan =
        new("Rental.IsInvalidRentalPlan", "Rental's Plan is invalid", ErrorType.Validation);
}