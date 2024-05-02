using BikeRentDelivery.Common.Results;
using BikeRentDelivery.Common.ValueObjects;
using BikeRentDelivery.Domain.Users;

namespace BikeRentDelivery.Tests.Unit.Users;

public class UserBuilder
{
    private string _name = "John Doe";
    private DateTime _birthDate = new DateTime(1990, 1, 1);
    private string _cnpj = "27.186.269/0001-60";
    private string _cnhNumber = "12085661438";
    private CnhType _cnhType = CnhType.A;
    private string? _cnhImage;
    private string _email = "john@example.com";
    private string _password = "I5ZLIbU*";
    private const string Role = "user";

    public static UserBuilder Create()
    {
        var userBuilder = new UserBuilder();

        return userBuilder;
    }

    public UserBuilder WithBirthDate(DateTime birthDate)
    {
        _birthDate = birthDate;

        return this;
    }

    public UserBuilder WithCnpj(string cnpj)
    {
        _cnpj = cnpj;

        return this;
    }

    public UserBuilder WithCnh(string number, CnhType type, string? image = null)
    {
        _cnhNumber = number;
        _cnhType = type;
        _cnhImage = image;

        return this;
    }

    public UserBuilder WithEmail(string email)
    {
        _email = email;

        return this;
    }

    public UserBuilder WithPassword(string password)
    {
        _password = password;

        return this;
    }

    public Result<User> Build()
    {
        return
            User.Create(
                _name,
                _birthDate,
                _cnpj,
                _cnhNumber,
                _cnhType.ToString(),
                _cnhImage,
                _email,
                _password,
                Role);
    }
}