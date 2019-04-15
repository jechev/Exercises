using System;
using System.Linq;

public static class Isogram
{
    public static bool IsIsogram(string word)
    {

        if (word == "")
        {
            return true;
        }


        for (int i = 0; i < word.Length; i++)
        {
            for (int j = 1 + i; j < word.Length; j++)
            {
                if (Char.ToLower(word[i]) == Char.ToLower(word[j]) && Char.IsLetter(word[i]) && Char.IsLetter(word[j]))
                {
                    return false;
                }
            }
        }
        return true;
    }
}
