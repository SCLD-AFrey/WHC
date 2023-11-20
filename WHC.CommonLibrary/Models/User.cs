using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using WHC.CommonLibrary.DataConn;
using WHC.CommonLibrary.Enumerations;
using WHC.CommonLibrary.Interfaces;
using WHC.CommonLibrary.Models.Address;
using WHC.CommonLibrary.Models.Login;
using WHC.CommonLibrary.Models.UserInfo;
using WHC.CommonLibrary.Services;

namespace WHC.CommonLibrary.Models;

public class User
{
    public int UserOid { get; init; }
    [Required]
    public string UserName = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string DisplayName => $"{LastName}, {FirstName}";
    
    public List<EmailAddress> EmailAddresses { get; set; } = new();
    public List<Role> Roles { get; set; } = new();
    public List<UsAddress> Addresses { get; set; } = new();
    public List<PhoneNumber> PhoneNumbers { get; set; } = new();
    public List<Credential> Credentials { get; set; } = new();
    public List<LoginAttempt> LoginAttempts { get; set; } = new();

    public User()
    {
    }
    
    public User(string p_userName)
    {
        IUserService userService = new UserService();
        UserName = p_userName;
        var user = userService.GetUser(p_userName);

        UserOid = user.UserOid;
        FirstName = user.FirstName;
        LastName = user.LastName;
        EmailAddresses = user.EmailAddresses;
        Roles = user.Roles;
        Addresses = user.Addresses;
        PhoneNumbers = user.PhoneNumbers;
        Credentials = user.Credentials;
        LoginAttempts = user.LoginAttempts;
    }
    public User(int p_userOid)
    {        
        IUserService userService = new UserService();
        UserOid = p_userOid;
        var user = userService.GetUser(p_userOid);

        UserOid = user.UserOid;
        FirstName = user.FirstName;
        LastName = user.LastName;
        EmailAddresses = user.EmailAddresses;
        Roles = user.Roles;
        Addresses = user.Addresses;
        PhoneNumbers = user.PhoneNumbers;
        Credentials = user.Credentials;
        LoginAttempts = user.LoginAttempts;
    }

    public override string ToString()
    {
        return $"{UserName} - {LastName}, {FirstName} [{UserOid}]";
    }
    
    //----------- Password ----------------
    internal void AddCredential(string p_password)
    {
        var encryptionService = new EncryptionService();
        Credentials.Add(new Credential
        {
            PasswordHash = encryptionService.GeneratePasswordHash(p_password, out var salt),
            Salt = salt
        });
    }
    
    //----------- Email Addresses ----------------

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
    
    //----------- Roles ----------------

    internal void AddRole(Role p_role)
    {
        Roles.Add(p_role);
    } 
    internal void RemoveRole(Role p_role)
    {
        Roles.Remove(p_role);
    }
    
    //----------- Addresses ----------------
    
    internal void AddAddress(UsAddress p_address)
    {
        Addresses.Add(p_address);
    }
    internal void RemoveAddress(UsAddress p_address)
    {
        Addresses.Remove(p_address);
    }
    
    //----------- Phone Numbers ----------------
    
    internal void AddPhoneNumber(PhoneNumber p_phone)
    {
        PhoneNumbers.Add(p_phone);
    }
    internal void RemovePhoneNumber(PhoneNumber p_phone)
    {
        PhoneNumbers.Remove(p_phone);
    }
    
    //----------- Credentials ----------------
    
    internal void AddCredential(Credential p_credential)
    {
        Credentials.Add(p_credential);
    }
    
    internal Credential? GetCurrentCredential()
    {
        return Credentials.MaxBy(p_x => p_x.Updated) ?? null;
    }
    
    //----------- Login Attempt ----------------
    
    internal void AddLoginAttempt(LoginAttempt p_loginAttempt)
    {
        LoginAttempts.Add(p_loginAttempt);
    }
    
}