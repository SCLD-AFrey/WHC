using WHC.CommonLibrary.Enumerations;

namespace WHC.CommonLibrary.Models.Address;

public class EmailAddress
{
    public int Oid { get; set; }
    public string Address { get; set; } = string.Empty;
    public AddressType AddressType { get; set; } = AddressType.Other;
    
    public string ToDisplayString()
    {
        return $"{AddressType}: {Address}";
    }
}