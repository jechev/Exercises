using System;
using System.Collections.Generic;
using System.Linq;

public static class Series
{
    public static string[] Slices(string numbers, int sliceLength)
    {
        List<string> result = new List<string>();
        if (String.IsNullOrWhiteSpace(numbers) 
            || numbers.All(char.IsDigit)
            || sliceLength <= 0 
            || numbers.Length < sliceLength)
        {
            throw new ArgumentException();
        }
        else
        {
            for (int i = 0; i + sliceLength <= numbers.Length; i++)
            {
                string sub = numbers.Substring(i, sliceLength);
                result.Add(sub);
            }
           
            return result.ToArray();
        }
    }
}