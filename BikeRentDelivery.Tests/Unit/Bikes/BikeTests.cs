using BikeRentDelivery.Common.ValueObjects;
using BikeRentDelivery.Domain.Bikes;

namespace BikeRentDelivery.Tests.Unit.Bikes;

public class BikeTests
{
    [Theory]
    [InlineData("MCY-3143")]
    [InlineData("MZO8570")]
    [InlineData("ZXC4G25")]
    public void GivenValidData_ThenShouldBeSuccess_WhenCreateBike(string licensePlate)
    {
        // Arrange
        var bikeBuilder = new BikeBuilder()
            .WithLicensePlate(licensePlate);

        // Act
        var result = bikeBuilder.Build();

        // Assert
        result.Success.Should().BeTrue();
        result.Value.Should().NotBeNull();
    }

    [Theory]
    [InlineData("FGF-438E")]
    [InlineData("ABC659T")]
    [InlineData("1234567")]
    [InlineData("FHC7T5F")]
    [InlineData("ABCDEFG")]
    public void GivenInvalidLicensePlate_ThenShouldNotBeSuccess_WhenCreateBike(string licensePlate)
    {
        // Arrange
        var bikeBuilder =
            new BikeBuilder()
            .WithLicensePlate(licensePlate);

        // Act
        var result = bikeBuilder.Build();

        // Assert
        result.Success.Should().BeFalse();
        result.Errors.Should().NotBeNull();
        result.Errors.Should().Contain(LicensePlateErrors.LicensePlateIsInvalid);
    }

    [Fact]
    public void GivenInvalidYear_ThenShouldNotBeSuccess_WhenCreateBike()
    {
        // Arrange
        var bikeBuilder =
            new BikeBuilder()
            .WithYear(DateTime.Today.AddYears(2).Year);

        // Act
        var result = bikeBuilder.Build();

        // Assert
        result.Success.Should().BeFalse();
        result.Errors.Should().NotBeNull();
        result.Errors.Should().Contain(BikeErrors.IsInvalidYear);
    }
}