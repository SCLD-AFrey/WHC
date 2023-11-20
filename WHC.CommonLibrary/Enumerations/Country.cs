using WHC.CommonLibrary.Enumerations.Attributes;

namespace WHC.CommonLibrary.Enumerations;

        public enum Country
        {
            [CountryInfo(code = "xx", phoneCode = 0, name = "Other")]
            Other = -1,
            [CountryInfo(code = "af", phoneCode = 93, name = "Afghanistan")]
            Afghanistan = 0,
            [CountryInfo(code = "al", phoneCode = 355, name = "Albania")]
            Albania = 1,
            [CountryInfo(code = "dz", phoneCode = 213, name = "Algeria")]
            Algeria = 2,
            [CountryInfo(code = "ad", phoneCode = 376, name = "Andorra")]
            Andorra = 3,
            [CountryInfo(code = "ao", phoneCode = 244, name = "Angola")]
            Angola = 4,
            [CountryInfo(code = "aq", phoneCode = 672, name = "Antarctica")]
            Antarctica = 5,
            [CountryInfo(code = "ar", phoneCode = 54, name = "Argentina")]
            Argentina = 6,
            [CountryInfo(code = "am", phoneCode = 374, name = "Armenia")]
            Armenia = 7,
            [CountryInfo(code = "aw", phoneCode = 297, name = "Aruba")]
            Aruba = 8,
            [CountryInfo(code = "au", phoneCode = 61, name = "Australia")]
            Australia = 9,
            [CountryInfo(code = "at", phoneCode = 43, name = "Austria")]
            Austria = 10,
            [CountryInfo(code = "az", phoneCode = 994, name = "Azerbaijan")]
            Azerbaijan = 11,
            [CountryInfo(code = "bh", phoneCode = 973, name = "Bahrain")]
            Bahrain = 12,
            [CountryInfo(code = "bd", phoneCode = 880, name = "Bangladesh")]
            Bangladesh = 13,
            [CountryInfo(code = "by", phoneCode = 375, name = "Belarus")]
            Belarus = 14,
            [CountryInfo(code = "be", phoneCode = 32, name = "Belgium")]
            Belgium = 15,
            [CountryInfo(code = "bz", phoneCode = 501, name = "Belize")]
            Belize = 16,
            [CountryInfo(code = "bj", phoneCode = 229, name = "Benin")]
            Benin = 17,
            [CountryInfo(code = "bt", phoneCode = 975, name = "Bhutan")]
            Bhutan = 18,
            [CountryInfo(code = "bo", phoneCode = 591, name = "Plurinational State Of Bolivia")]
            Bolivia = 19,
            [CountryInfo(code = "ba", phoneCode = 387, name = "Bosnia And Herzegovina")]
            BosniaHerzegovina = 20,
            [CountryInfo(code = "bw", phoneCode = 267, name = "Botswana")]
            Botswana = 21,
            [CountryInfo(code = "br", phoneCode = 55, name = "Brazil")]
            Brazil = 22,
            [CountryInfo(code = "bn", phoneCode = 673, name = "Brunei Darussalam")]
            BruneiDarussalam = 23,
            [CountryInfo(code = "bg", phoneCode = 359, name = "Bulgaria")]
            Bulgaria = 24,
            [CountryInfo(code = "bf", phoneCode = 226, name = "Burkina Faso")]
            BurkinaFaso = 25,
            [CountryInfo(code = "mm", phoneCode = 95, name = "Myanmar")]
            Myanmar = 26,
            [CountryInfo(code = "bi", phoneCode = 257, name = "Burundi")]
            Burundi = 27,
            [CountryInfo(code = "kh", phoneCode = 855, name = "Cambodia")]
            Cambodia = 28,
            [CountryInfo(code = "cm", phoneCode = 237, name = "Cameroon")]
            Cameroon = 29,
            [CountryInfo(code = "ca", phoneCode = 1, name = "Canada")]
            Canada = 30,
            [CountryInfo(code = "cv", phoneCode = 238, name = "Cape Verde")]
            CapeVerde = 31,
            [CountryInfo(code = "cf", phoneCode = 236, name = "Central African Republic")]
            CentralAfricanRepublic = 32,
            [CountryInfo(code = "td", phoneCode = 235, name = "Chad")]
            Chad = 33,
            [CountryInfo(code = "cl", phoneCode = 56, name = "Chile")]
            Chile = 34,
            [CountryInfo(code = "cn", phoneCode = 86, name = "China")]
            China = 35,
            [CountryInfo(code = "cx", phoneCode = 61, name = "Christmas Island")]
            ChristmasIsland = 36,
            [CountryInfo(code = "cc", phoneCode = 61, name = "Cocos (keeling) Islands")]
            CocosIslands = 37,
            [CountryInfo(code = "co", phoneCode = 57, name = "Colombia")]
            Colombia = 38,
            [CountryInfo(code = "km", phoneCode = 269, name = "Comoros")]
            Comoros = 39,
            [CountryInfo(code = "cg", phoneCode = 242, name = "Congo")]
            Congo = 40,
            [CountryInfo(code = "cd", phoneCode = 243, name = "The Democratic Republic Of The Congo")]
            DemocraticRepublicCongo = 41,
            [CountryInfo(code = "ck", phoneCode = 682, name = "Cook Islands")]
            CookIslands = 42,
            [CountryInfo(code = "cr", phoneCode = 506, name = "Costa Rica")]
            CostaRica = 43,
            [CountryInfo(code = "hr", phoneCode = 385, name = "Croatia")]
            Croatia = 44,
            [CountryInfo(code = "cu", phoneCode = 53, name = "Cuba")]
            Cuba = 45,
            [CountryInfo(code = "cy", phoneCode = 357, name = "Cyprus")]
            Cyprus = 46,
            [CountryInfo(code = "cz", phoneCode = 420, name = "Czech Republic")]
            CzechRepublic = 47,
            [CountryInfo(code = "dk", phoneCode = 45, name = "Denmark")]
            Denmark = 48,
            [CountryInfo(code = "dj", phoneCode = 253, name = "Djibouti")]
            Djibouti = 49,
            [CountryInfo(code = "tl", phoneCode = 670, name = "Timor-leste")]
            Timorleste = 50,
            [CountryInfo(code = "ec", phoneCode = 593, name = "Ecuador")]
            Ecuador = 51,
            [CountryInfo(code = "eg", phoneCode = 20, name = "Egypt")]
            Egypt = 52,
            [CountryInfo(code = "sv", phoneCode = 503, name = "El Salvador")]
            ElSalvador = 53,
            [CountryInfo(code = "gq", phoneCode = 240, name = "Equatorial Guinea")]
            EquatorialGuinea = 54,
            [CountryInfo(code = "er", phoneCode = 291, name = "Eritrea")]
            Eritrea = 55,
            [CountryInfo(code = "ee", phoneCode = 372, name = "Estonia")]
            Estonia = 56,
            [CountryInfo(code = "et", phoneCode = 251, name = "Ethiopia")]
            Ethiopia = 57,
            [CountryInfo(code = "fk", phoneCode = 500, name = "Falkland Islands")]
            FalklandIslands4FverBritish = 82,
            [CountryInfo(code = "fo", phoneCode = 298, name = "Faroe Islands")]
            FaroeIslands = 58,
            [CountryInfo(code = "fj", phoneCode = 679, name = "Fiji")]
            Fiji = 59,
            [CountryInfo(code = "fi", phoneCode = 358, name = "Finland")]
            Finland = 60,
            [CountryInfo(code = "fr", phoneCode = 33, name = "France")]
            France = 61,
            [CountryInfo(code = "pf", phoneCode = 689, name = "French Polynesia")]
            FrenchPolynesia = 62,
            [CountryInfo(code = "ga", phoneCode = 241, name = "Gabon")]
            Gabon = 63,
            [CountryInfo(code = "gm", phoneCode = 220, name = "Gambia")]
            Gambia = 64,
            [CountryInfo(code = "ge", phoneCode = 995, name = "Georgia")]
            Georgia = 65,
            [CountryInfo(code = "de", phoneCode = 49, name = "Germany")]
            Germany = 66,
            [CountryInfo(code = "gh", phoneCode = 233, name = "Ghana")]
            Ghana = 67,
            [CountryInfo(code = "gi", phoneCode = 350, name = "Gibraltar")]
            Gibraltar = 68,
            [CountryInfo(code = "gr", phoneCode = 30, name = "Greece")]
            Greece = 69,
            [CountryInfo(code = "gl", phoneCode = 299, name = "Greenland")]
            Greenland = 70,
            [CountryInfo(code = "gt", phoneCode = 502, name = "Guatemala")]
            Guatemala = 71,
            [CountryInfo(code = "gn", phoneCode = 224, name = "Guinea")]
            Guinea = 72,
            [CountryInfo(code = "gw", phoneCode = 245, name = "Guinea-bissau")]
            Guineabissau = 73,
            [CountryInfo(code = "gy", phoneCode = 592, name = "Guyana")]
            Guyana = 74,
            [CountryInfo(code = "ht", phoneCode = 509, name = "Haiti")]
            Haiti = 75,
            [CountryInfo(code = "hn", phoneCode = 504, name = "Honduras")]
            Honduras = 76,
            [CountryInfo(code = "hk", phoneCode = 852, name = "Hong Kong")]
            HongKong = 77,
            [CountryInfo(code = "hu", phoneCode = 36, name = "Hungary")]
            Hungary = 78,
            [CountryInfo(code = "in", phoneCode = 91, name = "India")]
            India = 79,
            [CountryInfo(code = "id", phoneCode = 62, name = "Indonesia")]
            Indonesia = 80,
            [CountryInfo(code = "ir", phoneCode = 98, name = "Islamic Republic Of Iran")]
            Iran = 81,
            [CountryInfo(code = "iq", phoneCode = 964, name = "Iraq")]
            Iraq = 83,
            [CountryInfo(code = "ie", phoneCode = 353, name = "Ireland")]
            Ireland = 84,
            [CountryInfo(code = "im", phoneCode = 44, name = "Isle Of Man")]
            IsleOfMan = 85,
            [CountryInfo(code = "il", phoneCode = 972, name = "Israel")]
            Israel = 86,
            [CountryInfo(code = "it", phoneCode = 39, name = "Italy")]
            Italy = 87,
            [CountryInfo(code = "ci", phoneCode = 225, name = "Côte D'ivoire")]
            CoteDivoire = 88,
            [CountryInfo(code = "jp", phoneCode = 81, name = "Japan")]
            Japan = 89,
            [CountryInfo(code = "jo", phoneCode = 962, name = "Jordan")]
            Jordan = 90,
            [CountryInfo(code = "kz", phoneCode = 7, name = "Kazakhstan")]
            Kazakhstan = 91,
            [CountryInfo(code = "ke", phoneCode = 254, name = "Kenya")]
            Kenya = 91,
            [CountryInfo(code = "ki", phoneCode = 686, name = "Kiribati")]
            Kiribati = 93,
            [CountryInfo(code = "kw", phoneCode = 965, name = "Kuwait")]
            Kuwait = 94,
            [CountryInfo(code = "kg", phoneCode = 996, name = "Kyrgyzstan")]
            Kyrgyzstan = 95,
            [CountryInfo(code = "la", phoneCode = 856, name = "Lao People's Democratic Republic")]
            LaoPeoplesDR = 96,
            [CountryInfo(code = "lv", phoneCode = 371, name = "Latvia")]
            Latvia = 97,
            [CountryInfo(code = "lb", phoneCode = 961, name = "Lebanon")]
            Lebanon = 98,
            [CountryInfo(code = "ls", phoneCode = 266, name = "Lesotho")]
            Lesotho = 99,
            [CountryInfo(code = "lr", phoneCode = 231, name = "Liberia")]
            Liberia = 100,
            [CountryInfo(code = "ly", phoneCode = 218, name = "Libya")]
            Libya = 101,
            [CountryInfo(code = "li", phoneCode = 423, name = "Liechtenstein")]
            Liechtenstein = 102,
            [CountryInfo(code = "lt", phoneCode = 370, name = "Lithuania")]
            Lithuania = 103,
            [CountryInfo(code = "lu", phoneCode = 352, name = "Luxembourg")]
            Luxembourg = 104,
            [CountryInfo(code = "mo", phoneCode = 853, name = "Macao")]
            Macao = 105,
            [CountryInfo(code = "mk", phoneCode = 389, name = "Macedonia")]
            Macedonia = 106,
            [CountryInfo(code = "mg", phoneCode = 261, name = "Madagascar")]
            Madagascar = 107,
            [CountryInfo(code = "mw", phoneCode = 265, name = "Malawi")]
            Malawi = 108,
            [CountryInfo(code = "my", phoneCode = 60, name = "Malaysia")]
            Malaysia = 109,
            [CountryInfo(code = "mv", phoneCode = 960, name = "Maldives")]
            Maldives = 110,
            [CountryInfo(code = "ml", phoneCode = 223, name = "Mali")]
            Mali = 111,
            [CountryInfo(code = "mt", phoneCode = 356, name = "Malta")]
            Malta = 112,
            [CountryInfo(code = "mh", phoneCode = 692, name = "Marshall Islands")]
            MarshallIslands = 1,
            [CountryInfo(code = "mr", phoneCode = 222, name = "Mauritania")]
            Mauritania = 113,
            [CountryInfo(code = "mu", phoneCode = 230, name = "Mauritius")]
            Mauritius = 114,
            [CountryInfo(code = "yt", phoneCode = 262, name = "Mayotte")]
            Mayotte = 115,
            [CountryInfo(code = "mx", phoneCode = 52, name = "Mexico")]
            Mexico = 116,
            [CountryInfo(code = "fm", phoneCode = 691, name = "Federated States Of Micronesia")]
            Micronesia = 117,
            [CountryInfo(code = "md", phoneCode = 373, name = "Republic Of Moldova")]
            Moldova = 118,
            [CountryInfo(code = "mc", phoneCode = 377, name = "Monaco")]
            Monaco = 119,
            [CountryInfo(code = "mn", phoneCode = 976, name = "Mongolia")]
            Mongolia = 120,
            [CountryInfo(code = "me", phoneCode = 382, name = "Montenegro")]
            Montenegro = 121,
            [CountryInfo(code = "ma", phoneCode = 212, name = "Morocco")]
            Morocco = 122,
            [CountryInfo(code = "mz", phoneCode = 258, name = "Mozambique")]
            Mozambique = 123,
            [CountryInfo(code = "na", phoneCode = 264, name = "Namibia")]
            Namibia = 124,
            [CountryInfo(code = "nr", phoneCode = 674, name = "Nauru")]
            Nauru = 125,
            [CountryInfo(code = "np", phoneCode = 977, name = "Nepal")]
            Nepal = 126,
            [CountryInfo(code = "nl", phoneCode = 31, name = "Netherlands")]
            Netherlands = 127,
            [CountryInfo(code = "nc", phoneCode = 687, name = "New Caledonia")]
            NewCaledonia = 128,
            [CountryInfo(code = "nz", phoneCode = 64, name = "New Zealand")]
            NewZealand = 129,
            [CountryInfo(code = "ni", phoneCode = 505, name = "Nicaragua")]
            Nicaragua = 130,
            [CountryInfo(code = "ne", phoneCode = 227, name = "Niger")]
            Niger = 131,
            [CountryInfo(code = "ng", phoneCode = 234, name = "Nigeria")]
            Nigeria = 132,
            [CountryInfo(code = "nu", phoneCode = 683, name = "Niue")]
            Niue = 133,
            [CountryInfo(code = "kp", phoneCode = 850, name = "Democratic People's Republic Of Korea")]
            NorthKorea = 134,
            [CountryInfo(code = "no", phoneCode = 47, name = "Norway")]
            Norway = 135,
            [CountryInfo(code = "om", phoneCode = 968, name = "Oman")]
            Oman = 136,
            [CountryInfo(code = "pk", phoneCode = 92, name = "Pakistan")]
            Pakistan = 137,
            [CountryInfo(code = "pw", phoneCode = 680, name = "Palau")]
            Palau = 138,
            [CountryInfo(code = "pa", phoneCode = 507, name = "Panama")]
            Panama = 139,
            [CountryInfo(code = "pg", phoneCode = 675, name = "Papua New Guinea")]
            PapuaNewGuinea = 140,
            [CountryInfo(code = "py", phoneCode = 595, name = "Paraguay")]
            Paraguay = 141,
            [CountryInfo(code = "pe", phoneCode = 51, name = "Peru")]
            Peru = 142,
            [CountryInfo(code = "ph", phoneCode = 63, name = "Philippines")]
            Philippines = 142,
            [CountryInfo(code = "pn", phoneCode = 870, name = "Pitcairn")]
            Pitcairn = 143,
            [CountryInfo(code = "pl", phoneCode = 48, name = "Poland")]
            Poland = 144,
            [CountryInfo(code = "pt", phoneCode = 351, name = "Portugal")]
            Portugal = 145,
            [CountryInfo(code = "pr", phoneCode = 1, name = "Puerto Rico")]
            PuertoRico = 146,
            [CountryInfo(code = "qa", phoneCode = 974, name = "Qatar")]
            Qatar = 148,
            [CountryInfo(code = "ro", phoneCode = 40, name = "Romania")]
            Romania = 149,
            [CountryInfo(code = "ru", phoneCode = 7, name = "Russian Federation")]
            RussianFederation = 150,
            [CountryInfo(code = "rw", phoneCode = 250, name = "Rwanda")]
            Rwanda = 151,
            [CountryInfo(code = "bl", phoneCode = 590, name = "Saint Barthélemy")]
            SaintBarthélemy = 152,
            [CountryInfo(code = "ws", phoneCode = 685, name = "Samoa")]
            Samoa = 153,
            [CountryInfo(code = "sm", phoneCode = 378, name = "San Marino")]
            SanMarino = 154,
            [CountryInfo(code = "st", phoneCode = 239, name = "Sao Tome And Principe")]
            SaoTomeAndPrincipe = 155,
            [CountryInfo(code = "sa", phoneCode = 966, name = "Saudi Arabia")]
            SaudiArabia = 156,
            [CountryInfo(code = "sn", phoneCode = 221, name = "Senegal")]
            Senegal = 157,
            [CountryInfo(code = "rs", phoneCode = 381, name = "Serbia")]
            Serbia = 158,
            [CountryInfo(code = "sc", phoneCode = 248, name = "Seychelles")]
            Seychelles = 159,
            [CountryInfo(code = "sl", phoneCode = 232, name = "Sierra Leone")]
            SierraLeone = 160,
            [CountryInfo(code = "sg", phoneCode = 65, name = "Singapore")]
            Singapore = 161,
            [CountryInfo(code = "sk", phoneCode = 421, name = "Slovakia")]
            Slovakia = 162,
            [CountryInfo(code = "si", phoneCode = 386, name = "Slovenia")]
            Slovenia = 163,
            [CountryInfo(code = "sb", phoneCode = 677, name = "Solomon Islands")]
            SolomonIslands = 164,
            [CountryInfo(code = "so", phoneCode = 252, name = "Somalia")]
            Somalia = 165,
            [CountryInfo(code = "za", phoneCode = 27, name = "South Africa")]
            SouthAfrica = 166,
            [CountryInfo(code = "kr", phoneCode = 82, name = "Republic Of Korea")]
            SouthKorea = 167,
            [CountryInfo(code = "es", phoneCode = 34, name = "Spain")]
            Spain = 168,
            [CountryInfo(code = "lk", phoneCode = 94, name = "Sri Lanka")]
            SriLanka = 169,
            [CountryInfo(code = "sh", phoneCode = 290, name = "Saint Helena, Ascension And Tristan Da Cunha")]
            SaintHelena = 170,
            [CountryInfo(code = "pm", phoneCode = 508, name = "Saint Pierre And Miquelon")]
            SaintPierreMiquelon = 171,
            [CountryInfo(code = "sd", phoneCode = 249, name = "Sudan")]
            Sudan = 172,
            [CountryInfo(code = "sr", phoneCode = 597, name = "Suriname")]
            Suriname = 173,
            [CountryInfo(code = "sz", phoneCode = 268, name = "Swaziland")]
            Swaziland = 174,
            [CountryInfo(code = "se", phoneCode = 46, name = "Sweden")]
            Sweden = 175,
            [CountryInfo(code = "ch", phoneCode = 41, name = "Switzerland")]
            Switzerland = 176,
            [CountryInfo(code = "sy", phoneCode = 963, name = "Syrian Arab Republic")]
            SyrianArabRepublic = 177,
            [CountryInfo(code = "tw", phoneCode = 886, name = "Taiwan, Province Of China")]
            Taiwan = 178,
            [CountryInfo(code = "tj", phoneCode = 992, name = "Tajikistan")]
            Tajikistan = 179,
            [CountryInfo(code = "tz", phoneCode = 255, name = "United Republic Of Tanzania")]
            Tanzania = 180,
            [CountryInfo(code = "th", phoneCode = 66, name = "Thailand")]
            Thailand = 181,
            [CountryInfo(code = "tg", phoneCode = 228, name = "Togo")]
            Togo = 182,
            [CountryInfo(code = "tk", phoneCode = 690, name = "Tokelau")]
            Tokelau = 183,
            [CountryInfo(code = "to", phoneCode = 676, name = "Tonga")]
            Tonga = 184,
            [CountryInfo(code = "tn", phoneCode = 216, name = "Tunisia")]
            Tunisia = 185,
            [CountryInfo(code = "tr", phoneCode = 90, name = "Turkey")]
            Turkey = 186,
            [CountryInfo(code = "tm", phoneCode = 993, name = "Turkmenistan")]
            Turkmenistan87 = 1,
            [CountryInfo(code = "tv", phoneCode = 688, name = "Tuvalu")]
            Tuvalu = 188,
            [CountryInfo(code = "ae", phoneCode = 971, name = "United Arab Emirates")]
            UnitedArabEmirates = 189,
            [CountryInfo(code = "ug", phoneCode = 256, name = "Uganda")]
            Uganda = 190,
            [CountryInfo(code = "gb", phoneCode = 44, name = "United Kingdom")]
            UnitedKingdom = 191,
            [CountryInfo(code = "ua", phoneCode = 380, name = "Ukraine")]
            Ukraine = 192,
            [CountryInfo(code = "uy", phoneCode = 598, name = "Uruguay")]
            Uruguay = 193,
            [CountryInfo(code = "us", phoneCode = 1, name = "United States")]
            UnitedStates = 194,
            [CountryInfo(code = "uz", phoneCode = 998, name = "Uzbekistan")]
            Uzbekistan = 195,
            [CountryInfo(code = "vu", phoneCode = 678, name = "Vanuatu")]
            Vanuatu = 196,
            [CountryInfo(code = "va", phoneCode = 39, name = "Vatican City")]
            vaticanCity = 197,
            [CountryInfo(code = "va", phoneCode = 39, name = "Holy See")]
            HolySee = 198,
            [CountryInfo(code = "ve", phoneCode = 58, name = "Bolivarian Republic Of Venezuela")]
            Venezuela = 199,
            [CountryInfo(code = "vn", phoneCode = 84, name = "Viet Nam")]
            VietNam = 200,
            [CountryInfo(code = "wf", phoneCode = 681, name = "Wallis And Futuna")]
            WallisFutuna = 201,
            [CountryInfo(code = "ye", phoneCode = 967, name = "Yemen")]
            Yemen = 202,
            [CountryInfo(code = "zm", phoneCode = 260, name = "Zambia")]
            Zambia = 203,
            [CountryInfo(code = "zw", phoneCode = 263, name = "Zimbabwe")]
            Zimbabwe = 204,
        }