namespace WHC.CommonLibrary.Interfaces;

public interface IEncryptionService
{
    public string GeneratePasswordHash(string p_password, out byte[] p_salt);
    public bool VerifyPassword(string p_password, string p_hash, byte[] p_salt);
    public string EncryptString(string p_plainText);
    public string? DecryptString(string p_cipherText);
}