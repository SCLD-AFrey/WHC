using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WHC.CommonLibrary.DataConn;
using WHC.CommonLibrary.Helpers;
using WHC.CommonLibrary.Interfaces;
using WHC.CommonLibrary.Models;
using WHC.CommonLibrary.Models.Login;
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
    public User GetUser(int p_userId)
    {
        return _appContext.Users.Include(p_x => p_x.Credentials).FirstOrDefault(p_x => p_x.UserOid == p_userId) ?? new User();
    }

    public User GetUser(string p_username)
    {
        return GetUserByUsername(p_username);
    }

    public User GetUser(User p_user)
    {
        if (p_user.UserOid > 0)
        {
            return GetUser(p_user.UserOid);
        }
        else
        {
            return GetUserByUsername(p_user.UserName);
        }
    }

    private User GetUserByUsername(string username)
    {
        return _appContext.Users
            .FirstOrDefault(u => u.UserName.Equals(username, StringComparison.OrdinalIgnoreCase)) ?? new User();
    }

    public void InitUsers()
    {
        foreach (var user in BasicUsers.Roles().Where(user => !_appContext.Roles.Any(p_x => p_x.Name.ToLower() == user.Name.ToLower())))
        {
            _appContext.Roles.Add(user);
        }
        if (!_appContext.Users.Any(p_x => p_x.UserName.ToLower() == BasicUsers.AdminUser().UserName))
        {
            RegisterUser(BasicUsers.AdminUser(), "password");
        }

        if (!_appContext.Users.Any(p_x => p_x.UserName.ToLower() == BasicUsers.BasicUser().UserName))
        {
            RegisterUser(BasicUsers.BasicUser(), "password");
        }
    }

    public LoginAttempt Login(LoginAttempt p_login)
    {
        LoginAttempt attempt;
        if (!DoesUserExist(p_login.UserName))
        {
            attempt = new FailedLoginAttempt()
            {
                Attempted = DateTime.Now,
                FailMessage = "User not found"
            };
            return attempt;
        }
        
        var user = _appContext.Users.Include(p_x => p_x.Credentials).FirstOrDefault(p_x => p_x.UserName.ToLower() == p_login.UserName.ToLower());
        
        var cred = user!.Credentials.LastOrDefault();
        if (cred == null)
        {            
            attempt = new FailedLoginAttempt()
            {
                Attempted = DateTime.Now,
                User = user,
                FailMessage = "User has no credentials"
            };
            user.AddLoginAttempt(attempt);
            return attempt;
        }

        var encryptionService = new EncryptionService();
        if (!encryptionService.VerifyPassword(p_login.Password, cred.PasswordHash, cred.Salt))
        {            
            attempt = new FailedLoginAttempt()
            {
                Attempted = DateTime.Now,
                User = user,
                FailMessage = "Invalid Password"
            };
            user.AddLoginAttempt(attempt);
            return attempt;
        }
        
        
        attempt = new SuccessfulLoginAttempt()
        {
            Attempted = DateTime.Now,
            User = user
        };
        user.AddLoginAttempt(attempt);
        return attempt;
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
        user.AddCredential(p_newPassword);
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
        p_user.AddCredential(p_newPassword);
        _appContext.Add(p_user);
        _appContext.SaveChanges();
        return p_user;
    }

    public void ChangePassword(User p_user, string p_newPassword, out bool p_success)
    {
        p_success = false;
        if (!DoesUserExist(p_user.UserName))
        {
            return;
        }

        var prevCreds = p_user.Credentials.OrderByDescending(p_x => p_x.Updated).Take(5);

        if (prevCreds.Any(cred => _encryptionService.VerifyPassword(p_newPassword, cred.PasswordHash, cred.Salt)))
        {
            return;
        }
        
        p_user.AddCredential(p_newPassword);
        _appContext.Update(p_user);
        _appContext.SaveChanges();
        p_success = true;
        
    }

    public void ResetPassword(User p_user, out string p_password)
    {
        p_password = PasswordGenerator.GenerateReadablePassword();
        var user = _appContext.Users.FirstOrDefault(p_x => p_x.UserName.ToLower() == p_user.UserName.ToLower());
        if (user == null) return;
        ChangePassword(user, p_password, out var success);
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
    
    public List<Role> GetRoles()
    {
        return _appContext.Roles.ToList();
    }
    
}