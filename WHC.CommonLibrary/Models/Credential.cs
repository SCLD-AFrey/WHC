namespace WHC.CommonLibrary.Models;

public class Credential
{
    public DateTime Updated { get; set; } = DateTime.Now;
    public string PasswordHash { get; set; } = string.Empty;
    public byte[] Salt { get; set; } = Array.Empty<byte>();
}