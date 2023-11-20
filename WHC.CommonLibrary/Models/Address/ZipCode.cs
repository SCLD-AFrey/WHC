using System.Text.RegularExpressions;

namespace WHC.CommonLibrary.Models.Address;

public class ZipCode
{
    public ZipCode(string zipCode)
    {
        if (IsValidZipCode(zipCode))
        {
            Value = zipCode;
        }
        else
        {
            throw new ArgumentException("Invalid ZIP code format.");
        }
    }

    public string Value { get; }

    private bool IsValidZipCode(string zipCode)
    {
        return Regex.IsMatch(zipCode, @"^\d{5}(?:-\d{4})?$");
    }

    public override string ToString()
    {
        return Value;
    }
}
