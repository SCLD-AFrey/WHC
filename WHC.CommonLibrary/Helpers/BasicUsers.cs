using WHC.CommonLibrary.Enumerations;
using WHC.CommonLibrary.Models;
using WHC.CommonLibrary.Models.Address;
using WHC.CommonLibrary.Models.UserInfo;

namespace WHC.CommonLibrary.Helpers;

public static class BasicUsers
{
    public static List<Role> Roles()
    {
        return new List<Role>()
        {
            new Role()
            {
                Name = "Admin",
                Description = "Administrator"
            },
            new Role()
            {
                Name = "PowerUser",
                Description = "Power User"
            },
            new Role()
            {
                Name = "Editor",
                Description = "Edit User"
            },
            new Role()
            {
                Name = "Basic",
                Description = "Basic User"
            }
        };
    }
    
    public static User AdminUser()
    {
        return new User()
        {
            UserName = "admin",
            FirstName = "Admin",
            LastName = "User",
            EmailAddresses = new List<EmailAddress>()
            {
                new EmailAddress()
                {
                    Address = @"arthur.frey@gmail.com", AddressType = AddressType.Work
                }
            }
        };
    }
    public static User BasicUser()
    {
        return new User()
        {
            UserName = "basic",
            FirstName = "Basic",
            LastName = "User",
            EmailAddresses = new List<EmailAddress>()
            {
                new EmailAddress()
                {
                    Address = @"arthur.frey@gmail.com", AddressType = AddressType.Work
                }
            }
        };
    }
    
}