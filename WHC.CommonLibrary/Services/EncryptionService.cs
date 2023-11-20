using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using WHC.CommonLibrary.Interfaces;
using WHC.CommonLibrary.Models;

// ReSharper disable IdentifierTypo

namespace WHC.CommonLibrary.Services;

public class EncryptionService : IEncryptionService
{
    private const int KeySize = 64;
    private const int Iterations = 350000;
    private static readonly HashAlgorithmName HashAlgorithm = HashAlgorithmName.SHA512;

    public EncryptionService()  
    {
        if (EncryptKey == null)
        {
            LoadKeysFromJson();
        }
    }
    
    private EncryptKey? EncryptKey { get; set; } = null;

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
        aes.Key = EncryptKey!.Key;
        aes.IV = EncryptKey!.Iv;

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

        aes.Key = EncryptKey!.Key;
        aes.IV = EncryptKey!.Iv;

        var decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

        using var msDecrypt = new MemoryStream(buffer);
        using var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read);
        using var srDecrypt = new StreamReader(csDecrypt);
        return srDecrypt.ReadToEnd();
    }
    
    private void SaveKeysToJson()
    {
        CommonFilesService commonFiles = new();
        var json = JsonSerializer.Serialize(EncryptKey);
        File.WriteAllText(commonFiles.KeysFile, json);
    }
    
    private void LoadKeysFromJson()
    {
        CommonFilesService commonFiles = new();
        if (!File.Exists(commonFiles.KeysFile))
        {
            EncryptKey = new EncryptKey();
            SaveKeysToJson();
        }
        var json = File.ReadAllText(commonFiles.KeysFile);
        EncryptKey = JsonSerializer.Deserialize<EncryptKey>(json);
    }
    


}