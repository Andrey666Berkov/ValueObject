using System.Text.RegularExpressions;
using CSharpFunctionalExtensions;

namespace ConsoleApp;

public class PhoneNumber : ValueObject
{
    private const string phoneRegex = @"^((8|\+7)[\- ]?)?(\(?\d{3}\)?[\- ]?)?[\d\- ]{7,10}$";

    public string Number { get; }

    private PhoneNumber(string number)
    {
        Number = number;
    }

    public static Result<PhoneNumber, Error> Create(string input)
    {
        if (string.IsNullOrWhiteSpace(input))
            return Errors.General.ValueIsInvalid();

        if (Regex.IsMatch(input, phoneRegex) == false)
            return Errors.General.ValueIsInvalid();

        return new PhoneNumber(input);
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Number;
    }
}