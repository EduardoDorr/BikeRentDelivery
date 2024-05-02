using BikeRentDelivery.Common.Results;
using BikeRentDelivery.Common.Entities;
using BikeRentDelivery.Common.ValueObjects;
using BikeRentDelivery.Domain.Rentals;
using BikeRentDelivery.Domain.Notifications;

namespace BikeRentDelivery.Domain.Users;

public sealed class User : BaseEntity, ILoginEntity, IUpdatableEntity, IDeletableEntity
{
    public string Name { get; private set; }
    public DateTime BirthDate { get; private set; }
    public Cnpj Cnpj { get; private set; }
    public Cnh Cnh { get; private set; }
    public Email Email { get; private set; }
    public Password Password { get; private set; }
    public string Role { get; private set; }
    public DateTime? UpdatedAt { get; }
    public bool IsDeleted { get; }

    public List<Rental> Rentals { get; private set; } = [];
    public List<Notification> Notifications { get; private set; } = [];

    private User() { }

    private User(
        string name,
        DateTime birthDate,
        Cnpj cnpj,
        Cnh cnh,
        Email email,
        Password password,
        string role)
    {
        Name = name;
        BirthDate = birthDate;
        Cnpj = cnpj;
        Cnh = cnh;
        Email = email;
        Password = password;
        Role = role;
    }

    public static Result<User> Create(
        string name,
        DateTime birthDate,
        string cnpj,
        string cnhNumber,
        string cnhType,
        string? cnhImage,
        string email,
        string password,
        string role)
    {
        var cnpjResult = Cnpj.Create(cnpj);

        if (!cnpjResult.Success)
            return Result.Fail<User>(cnpjResult.Errors);

        var cnhResult = Cnh.Create(cnhNumber, cnhType, cnhImage);

        if (!cnhResult.Success)
            return Result.Fail<User>(cnhResult.Errors);

        var emailResult = Email.Create(email);

        if (!emailResult.Success)
            return Result.Fail<User>(emailResult.Errors);

        var passwordResult = Password.Create(password);

        if (!passwordResult.Success)
            return Result.Fail<User>(passwordResult.Errors);

        var isEligibleResult = IsEligibleForDriverLicense(birthDate);

        if (!isEligibleResult.Success)
            return Result.Fail<User>(isEligibleResult.Errors);

        var user =
            new User(name,
                     birthDate,
                     cnpjResult.Value,
                     cnhResult.Value,
                     emailResult.Value,
                     passwordResult.Value,
                     role);

        return Result<User>.Ok(user);
    }

    public Result Update(string name, DateTime birthDate, string email)
    {
        var emailResult = Email.Create(email);

        if (!emailResult.Success)
            return Result.Fail(emailResult.Errors);

        var isEligibleResult = IsEligibleForDriverLicense(birthDate);

        if (!isEligibleResult.Success)
            return Result.Fail(isEligibleResult.Errors);

        Name = name;
        BirthDate = birthDate;
        Email = emailResult.Value;

        return Result.Ok();
    }

    private static Result IsEligibleForDriverLicense(DateTime birthDate, int legalAge = 18)
    {
        var todayEightenYearsAgo = DateTime.Today.AddYears(-legalAge);

        var isEligible = birthDate.Date.CompareTo(todayEightenYearsAgo) <= 0;

        if (!isEligible)
            return Result.Fail(UserErrors.IsNotEligibleForDriverLicense);

        return Result.Ok();
    }
}