using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WHC.CommonLibrary.DataConn;
using WHC.CommonLibrary.Enumerations;
using WHC.CommonLibrary.Helpers;
using WHC.CommonLibrary.Interfaces;
using WHC.CommonLibrary.Models;
using WHC.CommonLibrary.Models.UserInfo;

namespace WHC.CommonLibrary.Services;

public class UserService : IUserService, IDisposable
{
    // ReSharper disable once PrivateFieldCanBeConvertedToLocalVariable
    private readonly ILogger<UserService> _logger;
    private readonly ApplicationContext _appContext;
    private readonly EncryptionService _encryptionService;

    public UserService()
    {
        _logger = new Logger<UserService>(new LoggerFactory());
        _appContext = new ApplicationContext();
        _encryptionService = new EncryptionService();
        _logger.LogInformation("User Service Initialized");
    }

    public CurrentUser CurrentUser { get; set; } = new CurrentUser();
    
    private User GetUserByUsername(string username)
    {
        return _appContext.Users
            .FirstOrDefault(u => u.UserName.Equals(username, StringComparison.OrdinalIgnoreCase)) ?? new User();
    }

    public void InitUsers()
    {
        if (!_appContext.Users.Any(p_x => p_x.UserName.ToLower() == Helpers.BasicUsers.AdminUser().UserName))
        {
            RegisterUser(Helpers.BasicUsers.AdminUser(), "password");
        }

        if (!_appContext.Users.Any(p_x => p_x.UserName.ToLower() == Helpers.BasicUsers.BasicUser().UserName))
        {
            RegisterUser(Helpers.BasicUsers.BasicUser(), "password");
        }
    }

    public LoginAttempt Login(LoginAttempt p_login)
    {
        if (!DoesUserExist(p_login.UserName))
        {
            return new FailedLoginAttempt()
            {
                Attempted = DateTime.Now,
                FailMessage = "User not found"
            };
        }
        
        var user = _appContext.Users.Include(p_x => p_x.Credentials).FirstOrDefault(p_x => p_x.UserName.ToLower() == p_login.UserName.ToLower());
        
        var cred = user!.Credentials.LastOrDefault();
        if (cred == null)
        {
            return new FailedLoginAttempt()
            {
                Attempted = DateTime.Now,
                User = user,
                FailMessage = "User has no credentials"
            };
        }

        var encryptionService = new EncryptionService();
        if (!encryptionService.VerifyPassword(p_login.Password, cred.PasswordHash, cred.Salt))
        {
            return new FailedLoginAttempt()
            {
                Attempted = DateTime.Now,
                User = user,
                FailMessage = "Invalid Password"
            };
        }

        return new SuccessfulLoginAttempt()
        {
            Attempted = DateTime.Now,
            User = user
        };
    }

    public void Logout()
    {
        //TODO - Implement Logout
    }

    public void DeleteUser(User p_user)
    {
        _appContext.Remove(p_user);
        _appContext.SaveChanges();
    }

    public void DeleteUser(int p_userId)
    {
        var user = _appContext.Users.FirstOrDefault(p_x => p_x.UserOid == p_userId);
        if (user == null) return;
        _appContext.Remove(user);
        _appContext.SaveChanges();
    }

    public void DeleteUser(string p_username)
    {
        var user = _appContext.Users.FirstOrDefault(p_x => p_x.UserName.ToLower() == p_username.ToLower());
        if (user == null) return;
        _appContext.Remove(user);
        _appContext.SaveChanges();
    }

    public void UpdateUser(User p_user)
    {
        _appContext.Update(p_user);
        _appContext.SaveChanges();
    }

    public void UpdateUser(User p_user, string p_newPassword)
    {
        var user = _appContext.Users.FirstOrDefault(p_x => p_x.UserName.ToLower() == p_user.UserName.ToLower());
        if (user == null) return;
        user.UpdatePassword(p_newPassword);
        _appContext.Update(user);
        _appContext.SaveChanges();
    }

    public User RegisterUser(User p_user)
    {
        return RegisterUser(p_user, PasswordGenerator.GenerateReadablePassword());
    }
    public User RegisterUser(User p_user, string p_newPassword)
    {
        p_user.UserName = p_user.UserName.ToLower();
        p_user.UpdatePassword(p_newPassword);
        _appContext.Add(p_user);
        _appContext.SaveChanges();
        return p_user;
    }

    public void ChangePassword(User p_user, string p_newPassword, out string p_message, out bool p_success)
    {
        p_success = false;
        if (!DoesUserExist(p_user.UserName))
        {
            p_message = "User not found";
            return;
        }

        var prevCreds = p_user.Credentials.OrderByDescending(p_x => p_x.Updated).Take(5);

        if (prevCreds.Any(cred => _encryptionService.VerifyPassword(p_newPassword, cred.PasswordHash, cred.Salt)))
        {
            p_message = "Password has been used before";
            return;
        }
        
        p_user.UpdatePassword(p_newPassword);
        _appContext.Update(p_user);
        _appContext.SaveChanges();
        p_success = true;
        
        p_message = "Password Changed";
    }

    public void ResetPassword(User p_user, out string p_password)
    {
        p_password = PasswordGenerator.GenerateReadablePassword();
        var user = _appContext.Users.FirstOrDefault(p_x => p_x.UserName.ToLower() == p_user.UserName.ToLower());
        if (user == null) return;
        ChangePassword(user, p_password, out var message, out var success);
        if (!success)
        {
            ResetPassword(user, out var password);
        }
    }
    
    public void Dispose()
    {
        _appContext.Dispose();
    }
    
    private bool DoesUserExist(string p_username)
    {
        return _appContext.Users.Any(p_x => p_x.UserName.ToLower() == p_username.ToLower());
    }
    
}