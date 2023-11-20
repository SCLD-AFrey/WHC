using WHC.CommonLibrary.Enumerations;

namespace WHC.CommonLibrary.Models.Address;

public abstract class Address
{
    public int Oid { get; set; }
    public string StreetAddress1 { get; set; } = string.Empty;
    public string StreetAddress2 { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public Country Country { get; set; } = Country.Other;
}