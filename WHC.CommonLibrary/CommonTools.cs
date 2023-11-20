using System.ComponentModel;

namespace WHC.CommonLibrary;

public static class CommonTools
{
    public static void SmartCreateDirectory(string p_directoryPath, out string p_message)
    {
        if (Directory.Exists(p_directoryPath))
        {
            p_message = $"Directory {p_directoryPath} already exists";
            return;
        }
        try
        {
            Directory.CreateDirectory(p_directoryPath!);
            p_message = $"Directory {p_directoryPath} created";
        } catch (Exception e)
        {
            p_message = $"Directory {p_directoryPath} not created: {e.Message}";
        }
    }    

}