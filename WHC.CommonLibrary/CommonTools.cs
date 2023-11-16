using System.ComponentModel;

namespace WHC.CommonLibrary;

public static class CommonTools
{
    public static void SmartCreateDirectory(string p_directoryPath, out string p_message)
    {
        p_message = string.Empty;
        var dir = Path.GetDirectoryName(p_directoryPath);
        Console.WriteLine(Path.GetDirectoryName(dir));
        if (Directory.Exists(dir))
        {
            p_message = $"Directory {dir} already exists";
            return;
        }
        try
        {
            Directory.CreateDirectory(dir!);
            p_message = $"Directory {dir} created";
        } catch (Exception e)
        {
            p_message = $"Directory {dir} not created: {e.Message}";
            throw;
        }
    }
    
    public static string GetEnumDescription(Enum p_value)
    {
        var fi = p_value.GetType().GetField(p_value.ToString());

        if (fi!.GetCustomAttributes(typeof(DescriptionAttribute), false) is DescriptionAttribute[] attributes && attributes.Any())
        {
            return attributes.First().Description;
        }

        return p_value.ToString();
    }
}