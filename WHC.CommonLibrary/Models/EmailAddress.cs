using WHC.CommonLibrary.Enumerations;

namespace WHC.CommonLibrary.Models;

public class EmailAddress
{
    public string Address { get; set; } = string.Empty;
    public EmailAddressType EmailAddressType { get; set; } = EmailAddressType.Other;
    
    public string ToDisplayString()
    {
        return $"{EmailAddressType}: {Address}";
    }
}