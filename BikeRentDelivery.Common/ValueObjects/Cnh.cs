using BikeRentDelivery.Common.Results;
using BikeRentDelivery.Common.Results.Errors;

namespace BikeRentDelivery.Common.ValueObjects;

public sealed record Cnh
{
    public string Number { get; }
    public CnhType Type { get; }
    public string? Image { get; }

    private Cnh() { }

    private Cnh(string number, CnhType type, string? image)
    {
        Number = number;
        Type = type;
        Image = image;
    }

    public static Result<Cnh> Create(string number, string type, string? image)
    {
        var isValidCnhType = Enum.TryParse(type, out CnhType cnhType);

        if (!isValidCnhType)
            return Result.Fail<Cnh>(CnhErrors.CnhIsInvalid);

        var cnhResult = Create(number, cnhType, image);

        if (!cnhResult.Success)
            return Result.Fail<Cnh>(cnhResult.Errors);

        return Result<Cnh>.Ok(cnhResult.Value);
    }

    public static Result<Cnh> Create(string number, CnhType cnhType, string? image)
    {
        number = FormatInput(number);

        if (string.IsNullOrWhiteSpace(number))
            return Result.Fail<Cnh>(CnhErrors.CnhIsRequired);

        if (!IsCnh(number))
            return Result.Fail<Cnh>(CnhErrors.CnhIsInvalid);

        var cnh = new Cnh(number, cnhType, image);

        return Result<Cnh>.Ok(cnh);
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

    private static bool IsCnh(string number)
    {
        if (number.Length != 11)
            return false;

        if (IsAllTheSameNumber(number))
            return false;

        var cnhWithoutCheckDigit = number.Substring(0, 9);

        var digit = CalculateCheckDigit(cnhWithoutCheckDigit);

        return number.EndsWith(digit.ToString());
    }

    private static bool IsAllTheSameNumber(string number)
    {
        return number.Distinct().Count() == 1;
    }

    private static int CalculateCheckDigit(string numberWithoutCheckDigit)
    {
        int sum = 0;

        for (int i = 0; i < numberWithoutCheckDigit.Length; i++)
            sum += int.Parse(numberWithoutCheckDigit[i].ToString()) * (9 - i);

        int remainder = sum % 11;

        return remainder < 2 ? 0 : 11 - remainder;
    }
}

public sealed record CnhErrors(string Code, string Message, ErrorType Type) : IError
{
    public static readonly Error CnhIsRequired =
        new("CNH.CnhIsRequired", "CNH is required", ErrorType.Validation);

    public static readonly Error CnhIsInvalid =
        new("CNH.CnhIsInvalid", "CNH is not a valid CNH", ErrorType.Validation);
}

public enum CnhType
{
    A = 0,
    B = 1,
    AB = 2
}