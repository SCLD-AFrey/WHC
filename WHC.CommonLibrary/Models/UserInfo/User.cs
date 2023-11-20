using WHC.CommonLibrary.Enumerations;
using WHC.CommonLibrary.Models.Address;
using WHC.CommonLibrary.Services;

namespace WHC.CommonLibrary.Models.UserInfo;

public class User
{
    public int UserOid { get; init; }
    private string _userName = string.Empty;
    private List<EmailAddress> m_emailAddresses = new();
    private List<Role> m_roles = new();

    public string UserName
    {
        get => _userName;
        set => _userName = value.ToLowerInvariant();
    }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string DisplayName => $"{LastName}, {FirstName}";

    public List<EmailAddress> EmailAddresses
    {
        get => m_emailAddresses;
        set => m_emailAddresses = value;
    }

    public List<UsAddress> Addresses { get; set; } = new();
    public List<PhoneNumber> PhoneNumbers { get; set; } = new();
    public List<Credential> Credentials { get; set; } = new();

    public List<Role> Roles
    {
        get => m_roles;
        set => m_roles = value;
    }

    public User()
    {
    }
    
    internal void UpdatePassword(string p_password)
    {
        var encryptionService = new EncryptionService();
        Credentials.Add(new Credential
        {
            PasswordHash = encryptionService.GeneratePasswordHash(p_password, out var salt),
            Salt = salt
        });
    }

    internal void AddEmail(EmailAddress p_emailAddress)
    {
        EmailAddresses.Add(p_emailAddress);
    }
    internal void AddEmail(string p_emailAddress, AddressType p_emailAddressType)
    {
        EmailAddresses.Add(new EmailAddress
        {
            Address = p_emailAddress,
            AddressType = p_emailAddressType
        });
    }
    internal void RemoveEmail(EmailAddress p_emailAddress)
    {
        EmailAddresses.Remove(p_emailAddress);
    }

    public override string ToString()
    {
        return $"{UserName} - {LastName}, {FirstName} [{UserOid}]";
    }

    internal void AddRole(Role p_role)
    {
        Roles.Add(p_role);
    } 
    internal void RemoveRole(Role p_role)
    {
        Roles.Remove(p_role);
    }
}