using System;
using System.Linq;

public static class LargestSeriesProduct
{
    public static long GetLargestProduct(string digits, int span) 
    {
        if (span != 0 && (span > digits.Length 
            || span < 0
            || String.IsNullOrWhiteSpace(digits)
            || !digits.All(n => char.IsDigit(n))))
        {
            throw new ArgumentException();
        }

        long largestProduct = long.MinValue;

        for (int i = 0; i <= digits.Length - span; i++)
        {
            int[] numbers = new int[span];
            for (int j = 0; j < span; j++)
            {
                numbers[j] = Convert.ToInt32(digits[i + j].ToString());
            }
            long product = numbers.Aggregate(1, (a, b) => a * b);

            if (product > largestProduct)
            {
                largestProduct = product;
            }
        }

        return largestProduct;
        
    }
}