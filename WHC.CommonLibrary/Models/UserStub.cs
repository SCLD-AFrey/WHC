using WHC.CommonLibrary.Enumerations;

namespace WHC.CommonLibrary.Models;

public class UserStub
{
    public int UserId { get; init; }
    public string UserName { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string DisplayName => $"{LastName}, {FirstName}";

    public List<EmailAddress> EmailAddresses { get; set; } = new();

    public Credential Credential { get; set; } = new();
    
    public UserStub(int p_userId)
    {
        UserId = p_userId;
    }
    
    public void UpdatePassword(string p_password)
    {
        var encryptionService = new EncryptionService();
        Credential = new Credential
        {
            PasswordHash = encryptionService.GeneratePasswordHash(p_password, out var salt),
            Salt = salt
        };
    }

    public void AddEmail(EmailAddress p_emailAddress)
    {
        EmailAddresses.Add(p_emailAddress);
    }
    public void AddEmail(string p_emailAddress, EmailAddressType p_emailAddressType)
    {
        EmailAddresses.Add(new EmailAddress
        {
            Address = p_emailAddress,
            EmailAddressType = p_emailAddressType
        });
    }
    public void RemoveEmail(EmailAddress p_emailAddress)
    {
        EmailAddresses.Remove(p_emailAddress);
    }

    public override string ToString()
    {
        return $"{UserName} - {LastName}, {FirstName} [{UserId}]";
    }
}