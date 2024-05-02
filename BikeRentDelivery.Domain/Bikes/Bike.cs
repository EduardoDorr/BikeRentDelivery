using BikeRentDelivery.Common.Results;
using BikeRentDelivery.Common.Entities;
using BikeRentDelivery.Common.ValueObjects;
using BikeRentDelivery.Domain.Rentals;

namespace BikeRentDelivery.Domain.Bikes;

public sealed class Bike : BaseEntity, IUpdatableEntity, IDeletableEntity
{
    public string Model { get; private set; }
    public LicensePlate LicensePlate { get; private set; }
    public int Year { get; private set; }
    public DateTime? UpdatedAt { get; }
    public bool IsDeleted { get; }

    public List<Rental> Rentals { get; private set; } = [];

    private Bike() { }

    private Bike(
        string model,
        LicensePlate licensePlate,
        int year)
    {
        Model = model;
        LicensePlate = licensePlate;
        Year = year;
    }

    public static Result<Bike> Create(
        string model,
        string licensePlate,
        int year)
    {
        var licensePlateResult = LicensePlate.Create(licensePlate);

        if (!licensePlateResult.Success)
            return Result.Fail<Bike>(licensePlateResult.Errors);

        var isValidYearResult = IsValidYear(year);

        if (!isValidYearResult.Success)
            return Result.Fail<Bike>(isValidYearResult.Errors);

        var user =
            new Bike(model,
                     licensePlateResult.Value,
                     year);

        return Result<Bike>.Ok(user);
    }

    public Result Update(string licensePlate)
    {
        var licensePlateResult = LicensePlate.Create(licensePlate);

        if (!licensePlateResult.Success)
            return Result.Fail(licensePlateResult.Errors);

        LicensePlate = licensePlateResult.Value;

        return Result.Ok();
    }

    private static Result IsValidYear(int year)
    {
        var isValid = year <= (DateTime.Today.Year + 1);

        if (!isValid)
            return Result.Fail(BikeErrors.IsInvalidYear);

        return Result.Ok();
    }
}