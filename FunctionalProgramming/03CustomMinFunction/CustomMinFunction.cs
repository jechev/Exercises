using System;
using System.Linq;

namespace _03CustomMinFunction
{
    class CustomMinFunction
    {
        static void Main(string[] args)
        {
            Func<int[], int> getMinNumber = (x) =>
            {
                int minNumber = x[0];
                foreach (var number in x)
                {
                    if (number < minNumber)
                    {
                        minNumber = number;
                    }
                }
                return minNumber;
            };

            int[] numbers = Console.ReadLine()
                .Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Console.WriteLine(getMinNumber(numbers));
            Console.ReadKey();
                
        }
    }
}
