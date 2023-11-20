using WHC.CommonLibrary.Models;

namespace WHC.CommonLibrary.Interfaces;

public interface IClientConfigurationService
{
    public ClientConfiguration ClientConfig { get; set; }
    public void Init();
    public void LoadFromFile();
    public void SaveToFile();
}