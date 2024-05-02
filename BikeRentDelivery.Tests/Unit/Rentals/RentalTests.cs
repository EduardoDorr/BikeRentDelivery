using BikeRentDelivery.Domain.Rentals;

namespace BikeRentDelivery.Tests.Unit.Rentals;

public class RentalTests
{
    [Fact]
    public void GivenValidaData_ThenShouldBeSuccess_WhenCreateRental()
    {
        // Arrange
        var rentalBuilder = new RentalBuilder();

        // Act
        var result = rentalBuilder.Build();

        // Assert
        result.Success.Should().BeTrue();
        result.Value.Should().NotBeNull();
        result.Value.RentalCost.Should().Be(210.0m);
        result.Value.LateFeeCost.Should().Be(0.0m);
        result.Value.AdditionalCost.Should().Be(0.0m);
        result.Value.Status.Should().Be(RentalStatus.Active);
    }

    [Fact]
    public void GivenValidaDataWithEarlierExpectedEndDate_ThenShouldBeSuccessWithLateFeeCost_WhenCreateRental()
    {
        // Arrange
        var startDate = DateTime.Today;
        var expectedEndDate = startDate.AddDays(5);
        var rentalBuilder =
            new RentalBuilder()
            .WithRentalPlan(RentalPlan.Plan7Days)
            .WithDates(startDate, expectedEndDate);

        // Act
        var result = rentalBuilder.Build();

        // Assert
        result.Success.Should().BeTrue();
        result.Value.Should().NotBeNull();
        result.Value.RentalCost.Should().Be(150.0m);
        result.Value.LateFeeCost.Should().Be(12.0m);
        result.Value.AdditionalCost.Should().Be(0.0m);
        result.Value.Status.Should().Be(RentalStatus.Active);
    }

    [Fact]
    public void GivenValidaDataWithLateExpectedEndDate_ThenShouldBeSuccessWithAdditionalCost_WhenCreateRental()
    {
        // Arrange
        var startDate = DateTime.Today;
        var expectedEndDate = startDate.AddDays(9);
        var rentalBuilder =
            new RentalBuilder()
            .WithRentalPlan(RentalPlan.Plan7Days)
            .WithDates(startDate, expectedEndDate);

        // Act
        var result = rentalBuilder.Build();

        // Assert
        result.Success.Should().BeTrue();
        result.Value.Should().NotBeNull();
        result.Value.RentalCost.Should().Be(210.0m);
        result.Value.LateFeeCost.Should().Be(0.0m);
        result.Value.AdditionalCost.Should().Be(100.0m);
        result.Value.Status.Should().Be(RentalStatus.Active);
    }

    [Fact]
    public void GivenInvalidStartDate_ThenShouldNotBeSuccess_WhenCreateRental()
    {
        // Arrange
        var startDate = DateTime.Today.AddDays(-1);
        var rentalBuilder =
            new RentalBuilder()
            .WithDates(startDate, startDate.AddDays(2));

        // Act
        var result = rentalBuilder.Build();

        // Assert
        result.Success.Should().BeFalse();
        result.Errors.Should().NotBeNull();
        result.Errors.Should().Contain(RentalErrors.IsInvalidStartDate);
    }

    [Fact]
    public void GivenInvalidExpectedEndDate_ThenShouldNotBeSuccess_WhenCreateRental()
    {
        // Arrange
        var startDate = DateTime.Today;
        var rentalBuilder =
            new RentalBuilder()
            .WithDates(startDate, startDate);

        // Act
        var result = rentalBuilder.Build();

        // Assert
        result.Success.Should().BeFalse();
        result.Errors.Should().NotBeNull();
        result.Errors.Should().Contain(RentalErrors.IsInvalidExpectedEndDate);
    }
}