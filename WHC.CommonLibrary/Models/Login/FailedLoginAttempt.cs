namespace WHC.CommonLibrary.Models.Login;

public class FailedLoginAttempt : LoginAttempt
{
    public string FailMessage { get; set; } = string.Empty;
}