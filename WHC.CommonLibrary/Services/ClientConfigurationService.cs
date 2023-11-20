using System.Text.Json;
using Microsoft.Extensions.Logging;
using WHC.CommonLibrary.Interfaces;
using WHC.CommonLibrary.Models;
// ReSharper disable InconsistentNaming

namespace WHC.CommonLibrary.Services;

public class ClientConfigurationService : IClientConfigurationService
{
    private readonly ILogger<ClientConfigurationService> m_logger;
    private readonly ICommonFilesService m_commonFiles;
    private readonly IEncryptionService m_encryptionService;
    
    public ClientConfigurationService(ILogger<ClientConfigurationService> p_logger, 
        ICommonFilesService p_commonFiles, 
        IEncryptionService p_encryptionService)
    {
        m_logger = p_logger;
        m_commonFiles = p_commonFiles;
        m_encryptionService = p_encryptionService;
        Init();
    }
    
    public ClientConfigurationService()
    {
        m_logger = new Logger<ClientConfigurationService>(new LoggerFactory());
        m_commonFiles = new CommonFilesService();
        m_encryptionService = new EncryptionService();
        LoadFromFile();
        m_logger.LogInformation($"Client Configuration Initialized");
    }

    public ClientConfiguration ClientConfig { get; set; } = new ClientConfiguration();
    
    public void Init()
    {
        if (File.Exists(m_commonFiles.ConfigFile)) return;
        m_logger.LogInformation("Init Preferences");
        ClientConfig = new ClientConfiguration();
        SaveToFile();
    }
    
    public void LoadFromFile()
    {
        if (!File.Exists(m_commonFiles.ConfigFile)) Init();
        var json = File.ReadAllText(m_commonFiles.ConfigFile);
        try
        {
            ClientConfig = JsonSerializer.Deserialize<ClientConfiguration>(m_encryptionService.DecryptString(json)!)!;
        }
        catch (Exception ex) 
        {
            m_logger.LogError($"Error deserializing client config: {ex.Message}");
            ClientConfig = new ClientConfiguration();
        }

    }

    public void SaveToFile()
    {
        try
        {
            var json = JsonSerializer.Serialize(ClientConfig);
            File.WriteAllText(m_commonFiles.ConfigFile, m_encryptionService.EncryptString(json));
        }
        catch (Exception ex)
        {
            m_logger.LogError($"Error serializing client config: {ex.Message}");
        }
    }
}