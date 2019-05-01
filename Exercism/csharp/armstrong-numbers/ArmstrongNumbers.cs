using System;

public static class ArmstrongNumbers
{
    public static bool IsArmstrongNumber(int number)
    {
        double sum = 0;
        string numberLikeString = number.ToString();

        foreach (var symbol in numberLikeString)
        {
            
            sum += Math.Pow(int.Parse(symbol.ToString()), numberLikeString.Length);
        }

        return sum == number ? true : false;
    }
}