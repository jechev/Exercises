using System;
using System.Text;

public static class ReverseString
{
    public static string Reverse(string input)
    {
        if (input.Length == 0)
        {
            return input;
        }

        StringBuilder reverseInput = new StringBuilder();

        for (int i = input.Length - 1; i >= 0 ; i--)
        {
            reverseInput.Append(input[i]);
        }

        return reverseInput.ToString();
    }
}