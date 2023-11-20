namespace WHC.CommonLibrary.Interfaces;

public interface ICommonFilesService
{
    public string SolutionDataFolder { get; set; }
    public string ProjectDataFolder { get; set; }
    public string LogsPath { get; set; }
    public string DataPath { get; set; }
    public string DbFile { get; set; }
    public string ReportsPath { get; set; }
    public string ConfigPath { get; set; }
    public string ConfigFile { get; set; }
    public string KeysFile { get; set; }
    public string FilesStoragePath { get; set; }
}