using BikeRentDelivery.Common.ValueObjects;
using BikeRentDelivery.Domain.Users;

namespace BikeRentDelivery.Tests.Unit.Users;

public class UserTests
{
    [Fact]
    public void GivenValidaData_ThenShouldBeSuccess_WhenCreateUser()
    {
        // Arrange
        var userBuilder = new UserBuilder();

        // Act
        var result = userBuilder.Build();

        // Assert
        result.Success.Should().BeTrue();
        result.Value.Should().NotBeNull();
    }

    [Fact]
    public void GivenInvalidBirthDate_ThenShouldNotBeSuccess_WhenCreateUser()
    {
        // Arrange
        var userBuilder =
            new UserBuilder()
            .WithBirthDate(new DateTime(2010, 1, 1));

        // Act
        var result = userBuilder.Build();

        // Assert
        result.Success.Should().BeFalse();
        result.Errors.Should().NotBeNull();
        result.Errors.First().Should().BeEquivalentTo(UserErrors.IsNotEligibleForDriverLicense);
    }

    [Fact]
    public void GivenInvalidCnpj_ThenShouldNotBeSuccess_WhenCreateUser()
    {
        // Arrange
        var userBuilder =
            new UserBuilder()
            .WithCnpj("15.654.341/0001-25");

        // Act
        var result = userBuilder.Build();

        // Assert
        result.Success.Should().BeFalse();
        result.Errors.Should().NotBeNull();
        result.Errors.First().Should().BeEquivalentTo(CnpjErrors.CnpjIsInvalid);
    }

    [Fact]
    public void GivenInvalidCnh_ThenShouldNotBeSuccess_WhenCreateUser()
    {
        // Arrange
        var userBuilder =
            new UserBuilder()
            .WithCnh("41572169624", CnhType.A);

        // Act
        var result = userBuilder.Build();

        // Assert
        result.Success.Should().BeFalse();
        result.Errors.Should().NotBeNull();
        result.Errors.First().Should().BeEquivalentTo(CnhErrors.CnhIsInvalid);
    }

    [Theory]
    [InlineData("plainaddress")]
    [InlineData("Abc.example.com")]
    [InlineData(".email@example.com")]
    [InlineData("email.@example.com")]
    [InlineData("A@b@c@example.com")]
    [InlineData("Joe Smith <email@example.com>")]
    [InlineData("email@example.com (Joe Smith)")]
    [InlineData("this\\ still\\\"notallowed@example.com")]
    [InlineData("email..email@example.com")]
    [InlineData("email@example")]
    [InlineData("email@111.222.333.44444")]
    [InlineData("email@example..com")]
    [InlineData("あいうえお@example..com")]
    public void GivenInvalidEmail_ThenShouldNotBeSuccess_WhenCreateUser(string email)
    {
        // Arrange
        var userBuilder =
            new UserBuilder()
            .WithEmail(email);

        // Act
        var result = userBuilder.Build();

        // Assert
        result.Success.Should().BeFalse();
        result.Errors.Should().NotBeNull();
        result.Errors.First().Should().BeEquivalentTo(EmailErrors.EmailIsInvalidFormat);
    }

    [Fact]
    public void GivenInvalidPassword_ThenShouldNotBeSuccess_WhenCreateUser()
    {
        // Arrange
        var userBuilder =
            new UserBuilder()
            .WithPassword("abc");

        // Act
        var result = userBuilder.Build();

        // Assert
        result.Success.Should().BeFalse();
        result.Errors.Should().NotBeNull();
        result.Errors.First().Should().BeEquivalentTo(PasswordErrors.PasswordIsInvalid);
    }
}