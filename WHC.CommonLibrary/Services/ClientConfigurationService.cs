using System.Text.Json;
using Microsoft.Extensions.Logging;
using WHC.CommonLibrary.Models;

namespace WHC.CommonLibrary.Services;

public class ClientConfigurationService
{
    private readonly ILogger<ClientConfigurationService> m_logger;
    private readonly CommonFilesService m_commonFiles;
    private readonly EncryptionService m_encryptionService;
    
    public ClientConfigurationService(ILogger<ClientConfigurationService> p_logger, 
        CommonFilesService p_commonFiles, 
        EncryptionService p_encryptionService)
    {
        m_logger = p_logger;
        m_commonFiles = p_commonFiles;
        m_encryptionService = p_encryptionService;
    }

    public ClientConfiguration ClientConfig { get; set; } = new ClientConfiguration();
    
    public void Init()
    {
        if (File.Exists(m_commonFiles.ConfigPath)) return;
        m_logger.LogInformation("Init Preferences");
        ClientConfig = new ClientConfiguration();
        Write();
        m_logger.LogInformation($"Client Configuration Initialized");
    }
    
    public void Read()
    {
        if (!File.Exists(m_commonFiles.ConfigPath)) Init();
        var json = File.ReadAllText(m_commonFiles.ConfigPath);
        try
        {
            ClientConfig = JsonSerializer.Deserialize<ClientConfiguration>(EncryptionService.DecryptString(json)!)!;
        }
        catch (Exception ex) 
        {
            m_logger.LogError($"Error deserializing client config: {ex.Message}");
            ClientConfig = new ClientConfiguration();
        }

    }

    public void Write()
    {
        try
        {
            var json = JsonSerializer.Serialize(ClientConfig);
            File.WriteAllText(m_commonFiles.ConfigPath, EncryptionService.EncryptString(json));
        }
        catch (Exception ex)
        {
            m_logger.LogError($"Error serializing client config: {ex.Message}");
        }
    }
}