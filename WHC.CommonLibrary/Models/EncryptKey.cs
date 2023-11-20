using System.Security.Cryptography;
using System.Text.Json;
using WHC.CommonLibrary.Services;

namespace WHC.CommonLibrary.Models;

public class EncryptKey
{
    public byte[] Key { get; set; } = new byte[32];
    public byte[] Iv { get; set; } = new byte[16];
    
    public EncryptKey()
    {
        var (key, iv) = GenerateKeys();
        Key = key;
        Iv = iv;
    }

    public void SetKey(byte[] p_key, byte[] p_iv)
    {
        Key = p_key;
        Iv = p_iv;
    }
    
    private (byte[] Key, byte[] Iv) GenerateKeys()
    {
        var key = new byte[32];
        var iv = new byte[16];
        RandomNumberGenerator.Fill(key);
        RandomNumberGenerator.Fill(iv);
        return (key, iv);
    }
}