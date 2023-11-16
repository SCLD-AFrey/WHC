using WHC.CommonLibrary.Enumerations;

namespace WHC.CommonLibrary.Models;

public class ClientConfiguration
{
    public DateTime Updated { get; set; } = DateTime.Now;
    public DisplayMode DisplayMode { get; set; } = DisplayMode.Light;
    public string ApiKey { get; set; } = string.Empty;
    public string OrgKey { get; set; } = string.Empty;
}