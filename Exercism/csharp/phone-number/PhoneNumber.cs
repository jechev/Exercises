using System;
using System.Collections.Generic;
using System.Linq;

public class PhoneNumber
{
    public static string Clean(string phoneNumber)
    {
        if (phoneNumber == "")
        {
            throw new ArgumentException();
        }

        List<char> numbers = phoneNumber.Where(Char.IsDigit).ToList();

        if (numbers.Count == 11 && numbers[0] == '1')
        {
            numbers.RemoveAt(0);
        }

        if (numbers.Count == 10)
        {
            if (numbers[0] == '0' || numbers[0] == '1' || numbers[3] == '0' || numbers[3] == '1' )
            {
                throw new ArgumentException();
            }
            return string.Join(String.Empty, numbers);

        }
        else
        {
            throw new ArgumentException();
        }

    }
}