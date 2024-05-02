using BikeRentDelivery.Common.Results;
using BikeRentDelivery.Common.Results.Errors;

namespace BikeRentDelivery.Common.ValueObjects;

public sealed record Cnpj
{
    public string Number { get; } = string.Empty;

    private Cnpj() { }

    private Cnpj(string number)
    {
        Number = number;
    }

    public static Result<Cnpj> Create(string number)
    {
        number = FormatInput(number);

        if (string.IsNullOrWhiteSpace(number))
            return Result.Fail<Cnpj>(CnpjErrors.CnpjIsRequired);

        if (!IsCnpj(number))
            return Result.Fail<Cnpj>(CnpjErrors.CnpjIsInvalid);

        var cnpj = new Cnpj(number);

        return Result<Cnpj>.Ok(cnpj);
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

    private static bool IsCnpj(string number)
    {
        if (number.Length != 14)
            return false;

        if (IsAllTheSameNumber(number))
            return false;

        int[] digit1Multipliers = { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
        int[] digit2Multipliers = { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
                
        int digit1 = CalculateCheckDigit(number, digit1Multipliers);
        int digit2 = CalculateCheckDigit(number, digit2Multipliers);

        string digit = string.Empty;
        digit += digit1.ToString();
        digit += digit2.ToString();

        return number.EndsWith(digit);
    }

    private static bool IsAllTheSameNumber(string number)
    {
        return number.Distinct().Count() == 1;
    }

    private static int CalculateCheckDigit(string number, int[] multipliers)
    {
        int sum = 0;

        for (int i = 0; i < multipliers.Length; i++)
            sum += int.Parse(number[i].ToString()) * multipliers[i];

        int remainder = sum % 11;

        return (remainder < 2) ? 0 : 11 - remainder;
    }
}

public sealed record CnpjErrors(string Code, string Message, ErrorType Type) : IError
{
    public static readonly Error CnpjIsRequired =
        new("CNPJ.CnpjIsRequired", "CNPJ is required", ErrorType.Validation);

    public static readonly Error CnpjIsInvalid =
        new("CNPJ.CnpjIsInvalid", "CNPJ is not a valid CNPJ", ErrorType.Validation);
}