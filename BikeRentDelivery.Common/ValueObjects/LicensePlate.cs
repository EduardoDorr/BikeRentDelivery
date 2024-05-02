using System.Text.RegularExpressions;

using BikeRentDelivery.Common.Results;
using BikeRentDelivery.Common.Results.Errors;

namespace BikeRentDelivery.Common.ValueObjects;

public sealed record LicensePlate
{
    public string Number { get; } = string.Empty;

    private const string _pattern = @"^[A-Z]{3}[0-9][0-9A-Z][0-9]{2}$";

    private LicensePlate() { }

    private LicensePlate(string number)
    {
        Number = number;
    }

    public static Result<LicensePlate> Create(string number)
    {
        number = FormatInput(number);

        if (string.IsNullOrWhiteSpace(number))
            return Result.Fail<LicensePlate>(LicensePlateErrors.LicensePlateIsRequired);

        if (!IsLicensePlate(number))
            return Result.Fail<LicensePlate>(LicensePlateErrors.LicensePlateIsInvalid);

        var licensePlate = new LicensePlate(number);

        return Result<LicensePlate>.Ok(licensePlate);
    }

    public override string ToString()
    {
        return Number;
    }

    private static string FormatInput(string number)
    {
        return number.Trim()
                     .Replace(".", "")
                     .Replace("/", "")
                     .Replace("-", "");
    }

    private static bool IsLicensePlate(string number)
    {
        if (number.Length != 7)
            return false;

        if (!Regex.IsMatch(number, _pattern))
            return false;

        return true;
    }
}

public sealed record LicensePlateErrors(string Code, string Message, ErrorType Type) : IError
{
    public static readonly Error LicensePlateIsRequired =
        new("LicensePlate.LicensePlateIsRequired", "License Plate is required", ErrorType.Validation);

    public static readonly Error LicensePlateIsInvalid =
        new("LicensePlate.LicensePlateIsInvalid", "License Plate is not a valid License Plate", ErrorType.Validation);
}