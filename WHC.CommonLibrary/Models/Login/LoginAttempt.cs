namespace WHC.CommonLibrary.Models.Login;

public class LoginAttempt
{
    public int Oid { get; set; }
    private string _userName = string.Empty;
    public string UserName
    {
        get => _userName;
        set => _userName = value.ToLowerInvariant();
    }
    public string Password { get; set; } = string.Empty;
    public DateTime Attempted { get; set; } = DateTime.Now;
    public User? User { get; set; } = new User();
}