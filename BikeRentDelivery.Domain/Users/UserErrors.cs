using BikeRentDelivery.Common.Results.Errors;

namespace BikeRentDelivery.Domain.Users;

public sealed record UserErrors(string Code, string Message, ErrorType Type) : IError
{
    public static readonly Error CannotBeCreated =
        new("User.CannotBeCreated", "Something went wrong and the User cannot be created", ErrorType.Failure);

    public static readonly Error CannotBeUpdated =
        new("User.CannotBeUpdated", "Something went wrong and the User cannot be updated", ErrorType.Failure);

    public static readonly Error CannotBeDeleted =
        new("User.CannotBeDeleted", "Something went wrong and the User cannot be deleted", ErrorType.Failure);

    public static readonly Error NotFound =
        new("User.NotFound", "Could not find an active User", ErrorType.NotFound);

    public static readonly Error IsNotEligibleForDriverLicense =
        new("User.IsNotEligibleForDriverLicense", "User is not eligible for a driver licence", ErrorType.Validation);

    public static readonly Error IsNotUnique =
        new("User.IsNotUnique", "The User's CPNJ, or CNH or Email is already taken", ErrorType.Conflict);
}