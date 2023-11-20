using WHC.CommonLibrary.Enumerations;

namespace WHC.CommonLibrary.Models.Address;

public class PhoneNumber
{
    public int Oid { get; set; }
    public string Number { get; set; } = string.Empty;
    public PhoneType Type { get; set; } = PhoneType.Other;
    public Country Country { get; set; } = Country.Other;
}