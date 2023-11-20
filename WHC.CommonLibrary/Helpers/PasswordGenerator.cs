using System.Text;
using WHC.CommonLibrary.Enumerations;

namespace WHC.CommonLibrary.Helpers;

public static class PasswordGenerator
{
    private static readonly Random _random = new Random();
    private static readonly Words _words = new Words();

    public static string GenerateReadablePassword()
    {
        var sb = new StringBuilder();
        sb.Append(GetRandomEntry(WordType.Adjective));
        sb.Append(GetRandomEntry(WordType.Verb));
        sb.Append(GetRandomEntry(WordType.Noun));
        for (var i = 0; i < 4; i++)
        {
            sb.Append(_random.Next(10));
        }
        return sb.ToString();
    }

    private static string GetRandomEntry(WordType wordType)
    {
        var list = wordType switch
        {
            WordType.Noun => _words.Nouns,
            WordType.Verb => _words.Verbs,
            WordType.Adjective => _words.Adjectives,
            _ => _words.All 
        };

        var random = new Random();
        var index = random.Next(list.Count);
        return CapitalizeFirstLetter(list[index]);
    }

    private static string CapitalizeFirstLetter(string input)
    {
        if (string.IsNullOrEmpty(input))
            return input;

        return char.ToUpper(input[0]) + input[1..].ToLower();
    }
}