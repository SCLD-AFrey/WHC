using System.ComponentModel;

namespace WHC.CommonLibrary.Helpers;

public class EnumTools
{
    public static string GetDescription(Enum p_value)
    {
        var field = p_value.GetType().GetField(p_value.ToString());
        if (field == null)
        {
            return p_value.ToString();
        }
        var attribute = Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) as DescriptionAttribute;

        return attribute == null ? p_value.ToString() : attribute.Description;
    }
}