using WHC.CommonLibrary.Enumerations;

namespace WHC.CommonLibrary.Models.Address;

public class UsAddress : Address
{
    public USState State { get; set; } = USState.XX;
    public ZipCode ZipCode { get; set; } = new(string.Empty);
}