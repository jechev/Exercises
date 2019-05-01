using System;
using System.Linq;

public static class DifferenceOfSquares
{
    public static int CalculateSquareOfSum(int max)
    {
        //int result = 0;
        //for (int i = 1; i <= max; i++)
        //{
        //    result += i;
        //}

        //return Convert.ToInt32(Math.Pow(result, 2));
        int sumOfNumbers = Enumerable.Range(1, max)
            .Sum();

        return sumOfNumbers * sumOfNumbers;
    }

    public static int CalculateSumOfSquares(int max)
    {
        //int result = 0;
        //for (int i = 1; i <= max; i++)
        //{
        //    result += Convert.ToInt32(Math.Pow(i, 2));
        //}
        //return result;

        int sumOfSquares = Enumerable.Range(1, max)
            .Select(n => n * n)
            .Sum();

        return sumOfSquares;
    }

    public static int CalculateDifferenceOfSquares(int max)
    {
        return CalculateSquareOfSum(max) - CalculateSumOfSquares(max);
    }
}