// ReSharper disable MemberCanBePrivate.Global
namespace WHC.CommonLibrary;

public class CommonFilesService
{
    public string SolutionDataFolder { get; set; }
    public string ProjectDataFolder { get; set; }
    public string LogsPath { get; set; }
    public string DataPath { get; set; }
    public string DbFile { get; set; }
    public string ReportsPath { get; set; }
    public string ConfigPath { get; set; }
    public string ConfigFile { get; set; }
    public string FilesStoragePath { get; set; }

    public CommonFilesService()
    {
        SolutionDataFolder = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData),
            "WHC");
        ProjectDataFolder = Path.Combine(
            SolutionDataFolder, 
            "WHCLink");
        LogsPath = Path.Combine(
            ProjectDataFolder, 
            "Logs");
        DataPath = Path.Combine(
            ProjectDataFolder, 
            "DB");
        DbFile = Path.Combine(
            DataPath, 
            "WHCLink.db");
        ReportsPath = Path.Combine(
            ProjectDataFolder, 
            "Reports");
        ConfigPath = Path.Combine(
            ProjectDataFolder, 
            "Config");
        ConfigFile = Path.Combine(
            ConfigPath, 
            "config.json");
        FilesStoragePath = Path.Combine(
            ProjectDataFolder, 
            "FilesStorage");
        
        CommonTools.SmartCreateDirectory(SolutionDataFolder, out _);
        CommonTools.SmartCreateDirectory(ProjectDataFolder, out _);
        CommonTools.SmartCreateDirectory(LogsPath, out _);
        CommonTools.SmartCreateDirectory(DataPath, out _);
        CommonTools.SmartCreateDirectory(ReportsPath, out _);
        CommonTools.SmartCreateDirectory(ConfigPath, out _);
        CommonTools.SmartCreateDirectory(FilesStoragePath, out _);
    }
}