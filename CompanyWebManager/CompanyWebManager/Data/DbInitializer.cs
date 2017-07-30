using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CompanyWebManager.Models;
using CompanyWebManager.DataContexts;

namespace CompanyWebManager.Data
{
    public class DbInitializer
    {
        public static void Initialize(ApplicationDb context)
        {
            context.Database.EnsureCreated();

            if (!context.Voivodeships.Any())
            {
                var voivodeships = new Voivodeship[]
                {
                    new Voivodeship { Name = "Dolnośląskie" },
                    new Voivodeship { Name = "Kujawsko-pomorskie" },
                    new Voivodeship { Name = "Lubelskie" },
                    new Voivodeship { Name = "Lubuskie" },
                    new Voivodeship { Name = "Łódzkie" },
                    new Voivodeship { Name = "Małopolskie" },
                    new Voivodeship { Name = "Mazowieckie" },
                    new Voivodeship { Name = "Opolskie" },
                    new Voivodeship { Name = "Podkarpackie" },
                    new Voivodeship { Name = "Podlaskie" },
                    new Voivodeship { Name = "Pomorskie" },
                    new Voivodeship { Name = "Śląskie" },
                    new Voivodeship { Name = "Świętokrzyskie" },
                    new Voivodeship { Name = "Warmińsko-mazurskie" },
                    new Voivodeship { Name = "Wielkopolskie" },
                    new Voivodeship { Name = "Zachodniopomorskie" }
                };

                foreach (Voivodeship v in voivodeships)
                {
                    context.Voivodeships.Add(v);
                }

                context.SaveChanges();
            }

            if (!context.Countries.Any())
            {

                var countries = new Country[]
                {
                    new Country {CountryCode = "AF", Name = "Afghanistan"},
                    new Country {CountryCode = "AL", Name = "Albania"},
                    new Country {CountryCode = "DZ", Name = "Algeria"},
                    new Country {CountryCode = "DS", Name = "American Samoa"},
                    new Country {CountryCode = "AD", Name = "Andorra"},
                    new Country {CountryCode = "AO", Name = "Angola"},
                    new Country {CountryCode = "AI", Name = "Anguilla"},
                    new Country {CountryCode = "AQ", Name = "Antarctica"},
                    new Country {CountryCode = "AG", Name = "Antigua and Barbuda"},
                    new Country {CountryCode = "AR", Name = "Argentina"},
                    new Country {CountryCode = "AM", Name = "Armenia"},
                    new Country {CountryCode = "AW", Name = "Aruba"},
                    new Country {CountryCode = "AU", Name = "Australia"},
                    new Country {CountryCode = "AT", Name = "Austria"},
                    new Country {CountryCode = "AZ", Name = "Azerbaijan"},
                    new Country {CountryCode = "BS", Name = "Bahamas"},
                    new Country {CountryCode = "BH", Name = "Bahrain"},
                    new Country {CountryCode = "BD", Name = "Bangladesh"},
                    new Country {CountryCode = "BB", Name = "Barbados"},
                    new Country {CountryCode = "BY", Name = "Belarus"},
                    new Country {CountryCode = "BE", Name = "Belgium"},
                    new Country {CountryCode = "BZ", Name = "Belize"},
                    new Country {CountryCode = "BJ", Name = "Benin"},
                    new Country {CountryCode = "BM", Name = "Bermuda"},
                    new Country {CountryCode = "BT", Name = "Bhutan"},
                    new Country {CountryCode = "BO", Name = "Bolivia"},
                    new Country {CountryCode = "BA", Name = "Bosnia and Herzegovina"},
                    new Country {CountryCode = "BW", Name = "Botswana"},
                    new Country {CountryCode = "BV", Name = "Bouvet Island"},
                    new Country {CountryCode = "BR", Name = "Brazil"},
                    new Country {CountryCode = "IO", Name = "British Indian Ocean Territory"},
                    new Country {CountryCode = "BN", Name = "Brunei Darussalam"},
                    new Country {CountryCode = "BG", Name = "Bulgaria"},
                    new Country {CountryCode = "BF", Name = "Burkina Faso"},
                    new Country {CountryCode = "BI", Name = "Burundi"},
                    new Country {CountryCode = "KH", Name = "Cambodia"},
                    new Country {CountryCode = "CM", Name = "Cameroon"},
                    new Country {CountryCode = "CA", Name = "Canada"},
                    new Country {CountryCode = "CV", Name = "Cape Verde"},
                    new Country {CountryCode = "KY", Name = "Cayman Islands"},
                    new Country {CountryCode = "CF", Name = "Central African Republic"},
                    new Country {CountryCode = "TD", Name = "Chad"},
                    new Country {CountryCode = "CL", Name = "Chile"},
                    new Country {CountryCode = "CN", Name = "China"},
                    new Country {CountryCode = "CX", Name = "Christmas Island"},
                    new Country {CountryCode = "CC", Name = "Cocos (Keeling) Islands"},
                    new Country {CountryCode = "CO", Name = "Colombia"},
                    new Country {CountryCode = "KM", Name = "Comoros"},
                    new Country {CountryCode = "CG", Name = "Congo"},
                    new Country {CountryCode = "CK", Name = "Cook Islands"},
                    new Country {CountryCode = "CR", Name = "Costa Rica"},
                    new Country {CountryCode = "HR", Name = "Croatia (Hrvatska)"},
                    new Country {CountryCode = "CU", Name = "Cuba"},
                    new Country {CountryCode = "CY", Name = "Cyprus"},
                    new Country {CountryCode = "CZ", Name = "Czech Republic"},
                    new Country {CountryCode = "DK", Name = "Denmark"},
                    new Country {CountryCode = "DJ", Name = "Djibouti"},
                    new Country {CountryCode = "DM", Name = "Dominica"},
                    new Country {CountryCode = "DO", Name = "Dominican Republic"},
                    new Country {CountryCode = "TP", Name = "East Timor"},
                    new Country {CountryCode = "EC", Name = "Ecuador"},
                    new Country {CountryCode = "EG", Name = "Egypt"},
                    new Country {CountryCode = "SV", Name = "El Salvador"},
                    new Country {CountryCode = "GQ", Name = "Equatorial Guinea"},
                    new Country {CountryCode = "ER", Name = "Eritrea"},
                    new Country {CountryCode = "EE", Name = "Estonia"},
                    new Country {CountryCode = "ET", Name = "Ethiopia"},
                    new Country {CountryCode = "FK", Name = "Falkland Islands (Malvinas)"},
                    new Country {CountryCode = "FO", Name = "Faroe Islands"},
                    new Country {CountryCode = "FJ", Name = "Fiji"},
                    new Country {CountryCode = "FI", Name = "Finland"},
                    new Country {CountryCode = "FR", Name = "France"},
                    new Country {CountryCode = "FX", Name = "France, Metropolitan"},
                    new Country {CountryCode = "GF", Name = "French Guiana"},
                    new Country {CountryCode = "PF", Name = "French Polynesia"},
                    new Country {CountryCode = "TF", Name = "French Southern Territories"},
                    new Country {CountryCode = "GA", Name = "Gabon"},
                    new Country {CountryCode = "GM", Name = "Gambia"},
                    new Country {CountryCode = "GE", Name = "Georgia"},
                    new Country {CountryCode = "DE", Name = "Germany"},
                    new Country {CountryCode = "GH", Name = "Ghana"},
                    new Country {CountryCode = "GI", Name = "Gibraltar"},
                    new Country {CountryCode = "GK", Name = "Guernsey"},
                    new Country {CountryCode = "GR", Name = "Greece"},
                    new Country {CountryCode = "GL", Name = "Greenland"},
                    new Country {CountryCode = "GD", Name = "Grenada"},
                    new Country {CountryCode = "GP", Name = "Guadeloupe"},
                    new Country {CountryCode = "GU", Name = "Guam"},
                    new Country {CountryCode = "GT", Name = "Guatemala"},
                    new Country {CountryCode = "GN", Name = "Guinea"},
                    new Country {CountryCode = "GW", Name = "Guinea-Bissau"},
                    new Country {CountryCode = "GY", Name = "Guyana"},
                    new Country {CountryCode = "HT", Name = "Haiti"},
                    new Country {CountryCode = "HM", Name = "Heard and Mc Donald Islands"},
                    new Country {CountryCode = "HN", Name = "Honduras"},
                    new Country {CountryCode = "HK", Name = "Hong Kong"},
                    new Country {CountryCode = "HU", Name = "Hungary"},
                    new Country {CountryCode = "IS", Name = "Iceland"},
                    new Country {CountryCode = "IN", Name = "India"},
                    new Country {CountryCode = "IM", Name = "Isle of Man"},
                    new Country {CountryCode = "ID", Name = "Indonesia"},
                    new Country {CountryCode = "IR", Name = "Iran (Islamic Republic of)"},
                    new Country {CountryCode = "IQ", Name = "Iraq"},
                    new Country {CountryCode = "IE", Name = "Ireland"},
                    new Country {CountryCode = "IL", Name = "Israel"},
                    new Country {CountryCode = "IT", Name = "Italy"},
                    new Country {CountryCode = "CI", Name = "Ivory Coast"},
                    new Country {CountryCode = "JE", Name = "Jersey"},
                    new Country {CountryCode = "JM", Name = "Jamaica"},
                    new Country {CountryCode = "JP", Name = "Japan"},
                    new Country {CountryCode = "JO", Name = "Jordan"},
                    new Country {CountryCode = "KZ", Name = "Kazakhstan"},
                    new Country {CountryCode = "KE", Name = "Kenya"},
                    new Country {CountryCode = "KI", Name = "Kiribati"},
                    new Country {CountryCode = "KP", Name = "Korea, Democratic People''s Republic of"},
                    new Country {CountryCode = "KR", Name = "Korea, Republic of"},
                    new Country {CountryCode = "XK", Name = "Kosovo"},
                    new Country {CountryCode = "KW", Name = "Kuwait"},
                    new Country {CountryCode = "KG", Name = "Kyrgyzstan"},
                    new Country {CountryCode = "LA", Name = "Lao People''s Democratic Republic"},
                    new Country {CountryCode = "LV", Name = "Latvia"},
                    new Country {CountryCode = "LB", Name = "Lebanon"},
                    new Country {CountryCode = "LS", Name = "Lesotho"},
                    new Country {CountryCode = "LR", Name = "Liberia"},
                    new Country {CountryCode = "LY", Name = "Libyan Arab Jamahiriya"},
                    new Country {CountryCode = "LI", Name = "Liechtenstein"},
                    new Country {CountryCode = "LT", Name = "Lithuania"},
                    new Country {CountryCode = "LU", Name = "Luxembourg"},
                    new Country {CountryCode = "MO", Name = "Macau"},
                    new Country {CountryCode = "MK", Name = "Macedonia"},
                    new Country {CountryCode = "MG", Name = "Madagascar"},
                    new Country {CountryCode = "MW", Name = "Malawi"},
                    new Country {CountryCode = "MY", Name = "Malaysia"},
                    new Country {CountryCode = "MV", Name = "Maldives"},
                    new Country {CountryCode = "ML", Name = "Mali"},
                    new Country {CountryCode = "MT", Name = "Malta"},
                    new Country {CountryCode = "MH", Name = "Marshall Islands"},
                    new Country {CountryCode = "MQ", Name = "Martinique"},
                    new Country {CountryCode = "MR", Name = "Mauritania"},
                    new Country {CountryCode = "MU", Name = "Mauritius"},
                    new Country {CountryCode = "TY", Name = "Mayotte"},
                    new Country {CountryCode = "MX", Name = "Mexico"},
                    new Country {CountryCode = "FM", Name = "Micronesia, Federated States of"},
                    new Country {CountryCode = "MD", Name = "Moldova, Republic of"},
                    new Country {CountryCode = "MC", Name = "Monaco"},
                    new Country {CountryCode = "MN", Name = "Mongolia"},
                    new Country {CountryCode = "ME", Name = "Montenegro"},
                    new Country {CountryCode = "MS", Name = "Montserrat"},
                    new Country {CountryCode = "MA", Name = "Morocco"},
                    new Country {CountryCode = "MZ", Name = "Mozambique"},
                    new Country {CountryCode = "MM", Name = "Myanmar"},
                    new Country {CountryCode = "NA", Name = "Namibia"},
                    new Country {CountryCode = "NR", Name = "Nauru"},
                    new Country {CountryCode = "NP", Name = "Nepal"},
                    new Country {CountryCode = "NL", Name = "Netherlands"},
                    new Country {CountryCode = "AN", Name = "Netherlands Antilles"},
                    new Country {CountryCode = "NC", Name = "New Caledonia"},
                    new Country {CountryCode = "NZ", Name = "New Zealand"},
                    new Country {CountryCode = "NI", Name = "Nicaragua"},
                    new Country {CountryCode = "NE", Name = "Niger"},
                    new Country {CountryCode = "NG", Name = "Nigeria"},
                    new Country {CountryCode = "NU", Name = "Niue"},
                    new Country {CountryCode = "NF", Name = "Norfolk Island"},
                    new Country {CountryCode = "MP", Name = "Northern Mariana Islands"},
                    new Country {CountryCode = "NO", Name = "Norway"},
                    new Country {CountryCode = "OM", Name = "Oman"},
                    new Country {CountryCode = "PK", Name = "Pakistan"},
                    new Country {CountryCode = "PW", Name = "Palau"},
                    new Country {CountryCode = "PS", Name = "Palestine"},
                    new Country {CountryCode = "PA", Name = "Panama"},
                    new Country {CountryCode = "PG", Name = "Papua New Guinea"},
                    new Country {CountryCode = "PY", Name = "Paraguay"},
                    new Country {CountryCode = "PE", Name = "Peru"},
                    new Country {CountryCode = "PH", Name = "Philippines"},
                    new Country {CountryCode = "PN", Name = "Pitcairn"},
                    new Country {CountryCode = "PL", Name = "Poland"},
                    new Country {CountryCode = "PT", Name = "Portugal"},
                    new Country {CountryCode = "PR", Name = "Puerto Rico"},
                    new Country {CountryCode = "QA", Name = "Qatar"},
                    new Country {CountryCode = "RE", Name = "Reunion"},
                    new Country {CountryCode = "RO", Name = "Romania"},
                    new Country {CountryCode = "RU", Name = "Russian Federation"},
                    new Country {CountryCode = "RW", Name = "Rwanda"},
                    new Country {CountryCode = "KN", Name = "Saint Kitts and Nevis"},
                    new Country {CountryCode = "LC", Name = "Saint Lucia"},
                    new Country {CountryCode = "VC", Name = "Saint Vincent and the Grenadines"},
                    new Country {CountryCode = "WS", Name = "Samoa"},
                    new Country {CountryCode = "SM", Name = "San Marino"},
                    new Country {CountryCode = "ST", Name = "Sao Tome and Principe"},
                    new Country {CountryCode = "SA", Name = "Saudi Arabia"},
                    new Country {CountryCode = "SN", Name = "Senegal"},
                    new Country {CountryCode = "RS", Name = "Serbia"},
                    new Country {CountryCode = "SC", Name = "Seychelles"},
                    new Country {CountryCode = "SL", Name = "Sierra Leone"},
                    new Country {CountryCode = "SG", Name = "Singapore"},
                    new Country {CountryCode = "SK", Name = "Slovakia"},
                    new Country {CountryCode = "SI", Name = "Slovenia"},
                    new Country {CountryCode = "SB", Name = "Solomon Islands"},
                    new Country {CountryCode = "SO", Name = "Somalia"},
                    new Country {CountryCode = "ZA", Name = "South Africa"},
                    new Country {CountryCode = "GS", Name = "South Georgia South Sandwich Islands"},
                    new Country {CountryCode = "ES", Name = "Spain"},
                    new Country {CountryCode = "LK", Name = "Sri Lanka"},
                    new Country {CountryCode = "SH", Name = "St. Helena"},
                    new Country {CountryCode = "PM", Name = "St. Pierre and Miquelon"},
                    new Country {CountryCode = "SD", Name = "Sudan"},
                    new Country {CountryCode = "SR", Name = "Suriname"},
                    new Country {CountryCode = "SJ", Name = "Svalbard and Jan Mayen Islands"},
                    new Country {CountryCode = "SZ", Name = "Swaziland"},
                    new Country {CountryCode = "SE", Name = "Sweden"},
                    new Country {CountryCode = "CH", Name = "Switzerland"},
                    new Country {CountryCode = "SY", Name = "Syrian Arab Republic"},
                    new Country {CountryCode = "TW", Name = "Taiwan"},
                    new Country {CountryCode = "TJ", Name = "Tajikistan"},
                    new Country {CountryCode = "TZ", Name = "Tanzania, United Republic of"},
                    new Country {CountryCode = "TH", Name = "Thailand"},
                    new Country {CountryCode = "TG", Name = "Togo"},
                    new Country {CountryCode = "TK", Name = "Tokelau"},
                    new Country {CountryCode = "TO", Name = "Tonga"},
                    new Country {CountryCode = "TT", Name = "Trinidad and Tobago"},
                    new Country {CountryCode = "TN", Name = "Tunisia"},
                    new Country {CountryCode = "TR", Name = "Turkey"},
                    new Country {CountryCode = "TM", Name = "Turkmenistan"},
                    new Country {CountryCode = "TC", Name = "Turks and Caicos Islands"},
                    new Country {CountryCode = "TV", Name = "Tuvalu"},
                    new Country {CountryCode = "UG", Name = "Uganda"},
                    new Country {CountryCode = "UA", Name = "Ukraine"},
                    new Country {CountryCode = "AE", Name = "United Arab Emirates"},
                    new Country {CountryCode = "GB", Name = "United Kingdom"},
                    new Country {CountryCode = "US", Name = "United States"},
                    new Country {CountryCode = "UM", Name = "United States minor outlying islands"},
                    new Country {CountryCode = "UY", Name = "Uruguay"},
                    new Country {CountryCode = "UZ", Name = "Uzbekistan"},
                    new Country {CountryCode = "VU", Name = "Vanuatu"},
                    new Country {CountryCode = "VA", Name = "Vatican City State"},
                    new Country {CountryCode = "VE", Name = "Venezuela"},
                    new Country {CountryCode = "VN", Name = "Vietnam"},
                    new Country {CountryCode = "VG", Name = "Virgin Islands (British)"},
                    new Country {CountryCode = "VI", Name = "Virgin Islands (U.S.)"},
                    new Country {CountryCode = "WF", Name = "Wallis and Futuna Islands"},
                    new Country {CountryCode = "EH", Name = "Western Sahara"},
                    new Country {CountryCode = "YE", Name = "Yemen"},
                    new Country {CountryCode = "ZR", Name = "Zaire"},
                    new Country {CountryCode = "ZM", Name = "Zambia"},
                    new Country {CountryCode = "ZW", Name = "Zimbabwe"}
                };


                foreach (Country c in countries)
                {
                    context.Countries.Add(c);
                }
                context.SaveChanges();
            }


            if (!context.Addresses.Any())
            {
                var addresses = new Address[]
                {
                    new Address { Street = "Testowa 1/11", Town = "Bydgoszcz", PostalCode = "85-333", VoivodeshipID = 1, CountryID =  1},
                    new Address { Street = "Testowa 2/122", Town = "warszawa", PostalCode = "22-333", VoivodeshipID = 5, CountryID = 177 },
                    new Address { Street = "Testowa 3", Town = "paterek", PostalCode = "89-100", VoivodeshipID = 2, CountryID = 178 },
                    new Address { Street = "Simple Street 1", Town = "new york", PostalCode = "", VoivodeshipID = 4, CountryID = 230 },
                    new Address { Street = "Simple Street 2", Town = "dallas", PostalCode = "", VoivodeshipID = 3, CountryID = 231 },
                };

                foreach (Address a in addresses)
                {
                    context.Addresses.Add(a);
                }

                context.SaveChanges();
            }

            if (!context.Owners.Any())
            {
                var owners = new Owner[]
                {
                    new  Owner { FirstName = "Pawel", LastName = "Testowy", Created = DateTime.Now, AddressID = 1 },
                    new  Owner { FirstName = "janusz", LastName = "januszowy", Created = DateTime.Parse("2017-07-17"), AddressID = 2 },
                    new  Owner { FirstName = "grazyna", LastName = "poplecka", Created = DateTime.Parse("2017-07-15"), AddressID = 3}
                };

                foreach (Owner o in owners)
                {
                    context.Owners.Add(o);
                }
                context.SaveChanges();
            }

            if (!context.Companies.Any())
            {
                var companies = new Company[]
                {
                    new Company { Name = "TestowaFirma1", Trade = "IT", OwnerID = 1, AddressID = 4},
                    new Company { Name = "TestowaFirma2", Trade = "IT", OwnerID = 2, AddressID = 5}

                };

                foreach (Company c in companies)
                {
                    context.Companies.Add(c);
                }

                context.SaveChanges();
            }

            if (!context.Emails.Any())
            {
                var emails = new Email[]
                {
                    new Email
                    {
                        Sender = "test@test.pl",
                        Subject = "test",
                        OwnerID = 1,
                        Message = "czesc, co tam?",
                        ReceivedTime = DateTime.Parse("2017-07-17 12:20:22"),
                        Saved = true
                    },
                    new Email
                    {
                        Sender = "test@wp.pl",
                        Subject = "test2",
                        OwnerID = 1,
                        Message = "czesc, co tam?",
                        ReceivedTime = DateTime.Parse("2017-07-17 12:20:22"),
                        Saved = true
                    },
                    new Email
                    {
                        Sender = "test@test.pl",
                        Subject = "test3",
                        OwnerID = 1,
                        Message = "czesc, co tam?",
                        ReceivedTime = DateTime.Parse("2017-07-17 12:20:22"),
                        Saved = true
                    },
                    new Email
                    {
                        Sender = "test@test.pl",
                        Subject = "test4",
                        OwnerID = 1,
                        Message = "czesc, co tam?",
                        ReceivedTime = DateTime.Parse("2017-07-17 12:20:22"),
                        Saved = true
                    },
                    new Email
                    {
                        Sender = "test@test.pl",
                        Subject = "test5",
                        OwnerID = 1,
                        Message = "czesc, co tam?",
                        ReceivedTime = DateTime.Parse("2017-07-17 12:20:22"),
                        Saved = true
                    },
                    new Email
                    {
                        Sender = "test@test.pl",
                        Subject = "test6",
                        OwnerID = 1,
                        Message = "czesc, co tam?",
                        ReceivedTime = DateTime.Parse("2017-07-17 12:20:22"),
                        Saved = true
                    },
                    new Email
                    {
                        Sender = "test@test.pl",
                        Subject = "test7",
                        OwnerID = 1,
                        Message = "czesc, co tam?",
                        ReceivedTime = DateTime.Parse("2017-07-17 12:20:22"),
                        Saved = true
                    },
                    new Email
                    {
                        Sender = "test@test.pl",
                        Subject = "test8",
                        OwnerID = 1,
                        Message = "czesc, co tam?",
                        ReceivedTime = DateTime.Parse("2017-07-17 12:20:22"),
                        Saved = true
                    },
                    new Email
                    {
                        Sender = "test@test.pl",
                        Subject = "test9",
                        OwnerID = 1,
                        Message = "czesc, co tam?",
                        ReceivedTime = DateTime.Parse("2017-07-17 12:20:22"),
                        Saved = true
                    },
                    new Email
                    {
                        Sender = "test@test.pl",
                        Subject = "test10",
                        OwnerID = 1,
                        Message = "czesc, co tam?",
                        ReceivedTime = DateTime.Parse("2017-07-17 12:20:22"),
                        Saved = true
                    },
                    new Email
                    {
                        Sender = "test@test.pl",
                        Subject = "test11",
                        OwnerID = 1,
                        Message = "czesc, co tam?",
                        ReceivedTime = DateTime.Parse("2017-07-17 12:20:22"),
                        Saved = true
                    },
                    new Email
                    {
                        Sender = "test@test.pl",
                        Subject = "test12",
                        OwnerID = 1,
                        Message = "czesc, co tam?",
                        ReceivedTime = DateTime.Parse("2017-07-17 12:20:22"),
                        Saved = true
                    },
                    new Email
                    {
                        Sender = "test@test.pl",
                        Subject = "test13",
                        OwnerID = 1,
                        Message = "czesc, co tam?",
                        ReceivedTime = DateTime.Parse("2017-07-17 12:20:22"),
                        Saved = true
                    },
                    new Email
                    {
                        Sender = "test@test.pl",
                        Subject = "test14",
                        OwnerID = 1,
                        Message = "czesc, co tam?",
                        ReceivedTime = DateTime.Parse("2017-07-17 12:20:22"),
                        Saved = true
                    },
                    new Email
                    {
                        Sender = "test@test.pl",
                        Subject = "test15",
                        OwnerID = 1,
                        Message = "czesc, co tam?",
                        ReceivedTime = DateTime.Parse("2017-07-17 12:20:22"),
                        Saved = true
                    },
                    new Email
                    {
                        Sender = "test@test.pl",
                        Subject = "test16",
                        OwnerID = 1,
                        Message = "czesc, co tam?",
                        ReceivedTime = DateTime.Parse("2017-07-17 12:20:22"),
                        Saved = true
                    }
                };

                foreach (Email email in emails)
                {
                    context.Emails.Add(email);
                }

                context.SaveChanges();
            }
        }
    }
}
