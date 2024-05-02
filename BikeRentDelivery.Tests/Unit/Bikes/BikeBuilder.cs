using BikeRentDelivery.Common.Results;
using BikeRentDelivery.Domain.Bikes;

namespace BikeRentDelivery.Tests.Unit.Bikes;

public class BikeBuilder
{
    private string _model = "CG 160 Titan";
    private string _licensePlate = "PKA7C11";
    private int _year = DateTime.Today.Year;

    public static BikeBuilder Create()
    {
        return new BikeBuilder();
    }

    public BikeBuilder WithLicensePlate(string licensePlate)
    {
        _licensePlate = licensePlate;

        return this;
    }

    public BikeBuilder WithYear(int year)
    {
        _year = year;

        return this;
    }

    public Result<Bike> Build()
    {
        return Bike.Create(_model, _licensePlate, _year);
    }
}