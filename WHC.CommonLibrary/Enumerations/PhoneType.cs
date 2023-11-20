using System.ComponentModel;

namespace WHC.CommonLibrary.Enumerations;

public enum PhoneType
{
    [Description("Home")]
    Home,
    [Description("Work")]
    Work,
    [Description("Mobile")]
    Mobile,
    [Description("Fax")]
    Fax,
    [Description("Other")]
    Other
}