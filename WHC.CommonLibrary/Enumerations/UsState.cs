using System.ComponentModel;

namespace WHC.CommonLibrary.Enumerations;

public enum USState
{
    [Description("Other/Unknown")]
    XX = 0,
    
    [Description("Alabama")]
    AL = 1,

    [Description("Alaska")]
    AK = 2,

    [Description("Arizona")]
    AZ = 3,

    [Description("Arkansas")]
    AR = 4,

    [Description("California")]
    CA = 5,

    [Description("Colorado")]
    CO = 6,

    [Description("Connecticut")]
    CT = 7,

    [Description("Delaware")]
    DE = 8,

    [Description("Florida")]
    FL = 9,

    [Description("Georgia")]
    GA = 10,

    [Description("Hawaii")]
    HI = 11,

    [Description("Idaho")]
    ID = 12,

    [Description("Illinois")]
    IL = 13,

    [Description("Indiana")]
    IN = 14,

    [Description("Iowa")]
    IA = 15,

    [Description("Kansas")]
    KS = 16,

    [Description("Kentucky")]
    KY = 17,

    [Description("Louisiana")]
    LA = 18,

    [Description("Maine")]
    ME = 19,

    [Description("Maryland")]
    MD = 20,

    [Description("Massachusetts")]
    MA = 21,

    [Description("Michigan")]
    MI = 22,

    [Description("Minnesota")]
    MN = 23,

    [Description("Mississippi")]
    MS = 24,

    [Description("Missouri")]
    MO = 25,

    [Description("Montana")]
    MT = 26,

    [Description("Nebraska")]
    NE = 27,

    [Description("Nevada")]
    NV = 28,

    [Description("New Hampshire")]
    NH = 29,

    [Description("New Jersey")]
    NJ = 30,

    [Description("New Mexico")]
    NM = 31,

    [Description("New York")]
    NY = 32,

    [Description("North Carolina")]
    NC = 33,

    [Description("North Dakota")]
    ND = 34,

    [Description("Ohio")]
    OH = 35,

    [Description("Oklahoma")]
    OK = 36,

    [Description("Oregon")]
    OR = 37,

    [Description("Pennsylvania")]
    PA = 38,

    [Description("Rhode Island")]
    RI = 39,

    [Description("South Carolina")]
    SC = 40,

    [Description("South Dakota")]
    SD = 41,

    [Description("Tennessee")]
    TN = 42,

    [Description("Texas")]
    TX = 43,

    [Description("Utah")]
    UT = 44,

    [Description("Vermont")]
    VT = 45,

    [Description("Virginia")]
    VA = 46,

    [Description("Washington")]
    WA = 47,

    [Description("West Virginia")]
    WV = 48,

    [Description("Wisconsin")]
    WI = 49,

    [Description("Wyoming")]
    WY = 50,

    // U.S. Territories
    [Description("American Samoa")]
    AS = 51,

    [Description("Guam")]
    GU = 52,

    [Description("Northern Mariana Islands")]
    MP = 53,

    [Description("Puerto Rico")]
    PR = 54,

    [Description("U.S. Virgin Islands")]
    VI = 55,

    [Description("District of Columbia")]
    DC = 56 // Although not a state or a territory, often included in such lists
}
