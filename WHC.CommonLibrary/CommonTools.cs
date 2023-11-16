using System.ComponentModel;

namespace WHC.CommonLibrary;

public static class CommonTools
{
    public static void SmartCreateDirectory(string p_directoryPath, out string p_message)
    {
        if (Directory.Exists(p_directoryPath))
        {
            p_message = $"Directory {p_directoryPath} already exists";
            Console.WriteLine(p_message);
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
        Console.WriteLine(p_message);
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