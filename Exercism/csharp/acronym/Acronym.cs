using System;
using System.Linq;
using System.Text;

public static class Acronym
{
    public static string Abbreviate(string phrase)
    {
        char[] words = phrase.Split(new[] { ' ', '-', ',', '_' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(w => char.ToUpper(w[0]))
            .ToArray();

        return string.Join("", words);
    }
}