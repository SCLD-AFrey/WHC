using WHC.CommonLibrary.Models;
using WHC.CommonLibrary.Models.UserInfo;

namespace WHC.CommonLibrary.Interfaces;

public interface IUserService
{
    public CurrentUser CurrentUser { get; set; }
    
    public void InitUsers();
    public LoginAttempt Login(LoginAttempt p_login);
    public void Logout();
    
    public void DeleteUser(User p_user);
    public void DeleteUser(int p_userId);
    public void DeleteUser(string p_username);
    
    public void UpdateUser(User p_user);
    public void UpdateUser(User p_user, string p_newPassword);
    
    public User RegisterUser(User p_user, string p_newPassword);
    
    public void ChangePassword(User p_user, string p_newPassword, out string p_message, out bool p_success);
    public void ResetPassword(User p_user, out string p_password);
}