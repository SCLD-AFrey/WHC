namespace WHC.CommonLibrary.Models;

public class FailedLoginAttempt : LoginAttempt
{
    public string FailMessage { get; set; } = string.Empty;
}