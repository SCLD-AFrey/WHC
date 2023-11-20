namespace WHC.CommonLibrary.Models.UserInfo
{
    public class Credential
    {
        public int Oid { get; set; }
        public DateTime Updated { get; set; } = DateTime.Now;
        public string PasswordHash { get; set; } = string.Empty;
        public byte[] Salt { get; set; } = Array.Empty<byte>();
    }
}