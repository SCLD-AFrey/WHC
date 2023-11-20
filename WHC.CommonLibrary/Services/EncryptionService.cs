using System.Security.Cryptography;
using System.Text;
using WHC.CommonLibrary.Interfaces;

// ReSharper disable IdentifierTypo

namespace WHC.CommonLibrary.Services;

public class EncryptionService : IEncryptionService
{
    private const int KeySize = 64;
    private const int Iterations = 350000;
    private static readonly HashAlgorithmName HashAlgorithm = HashAlgorithmName.SHA512;

    private static readonly byte[] Key = Encoding.UTF8.GetBytes("12345678901234567890123456789012"); // 32 bytes for AES-256
    private static readonly byte[] Iv = Encoding.UTF8.GetBytes("1234567890123456"); // 16 bytes for AES block size


    public string GeneratePasswordHash(string p_password, out byte[] p_salt)
    {
        p_salt = RandomNumberGenerator.GetBytes(KeySize);
        var hash = Rfc2898DeriveBytes.Pbkdf2(
            Encoding.UTF8.GetBytes(p_password),
            p_salt,
            Iterations,
            HashAlgorithm,
            KeySize);
        return Convert.ToHexString(hash);
    }

    public bool VerifyPassword(string p_password, string p_hash, byte[] p_salt)
    {
        var hashToCompare = Rfc2898DeriveBytes.Pbkdf2(p_password, p_salt, Iterations, HashAlgorithm, KeySize);
        return hashToCompare.SequenceEqual(Convert.FromHexString(p_hash));
    }

    public string EncryptString(string p_plainText)
    {
        using var aes = Aes.Create();
        aes.Key = Key;
        aes.IV = Iv;

        var encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

        using var msEncrypt = new MemoryStream();
        using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
        using (var swEncrypt = new StreamWriter(csEncrypt))
        {
            swEncrypt.Write(p_plainText);
        }

        return Convert.ToBase64String(msEncrypt.ToArray());
    }

    public string? DecryptString(string p_cipherText)
    {
        var buffer = Convert.FromBase64String(p_cipherText);

        using var aes = Aes.Create();
        aes.Key = Key;
        aes.IV = Iv;

        var decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

        using var msDecrypt = new MemoryStream(buffer);
        using var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read);
        using var srDecrypt = new StreamReader(csDecrypt);
        return srDecrypt.ReadToEnd();
    }

}