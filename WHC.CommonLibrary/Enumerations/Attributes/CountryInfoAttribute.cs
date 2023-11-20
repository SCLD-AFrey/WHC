namespace WHC.CommonLibrary.Enumerations.Attributes;

public class CountryInfoAttribute : Attribute
{
    public String code = null!;
    public string name = null!;
    public Int16 phoneCode { get; set; }
}