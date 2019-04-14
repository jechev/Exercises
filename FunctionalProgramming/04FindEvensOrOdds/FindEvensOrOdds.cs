using System;
using System.Collections.Generic;
using System.Linq;

namespace _04FindEvensOrOdds
{
    class FindEvensOrOdds
    {
        static void Main(string[] args)
        {
            Func<int, bool> evenOrOddFunc;
            int[] rangeNumbers = Console.ReadLine()
               .Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse)
               .ToArray();

            string condition = Console.ReadLine();

            if (condition == "even")
            {
                evenOrOddFunc = n => n % 2 == 0;
            }else
            {
                evenOrOddFunc = n => n % 2 != 0;
            }

            List<int> numbers = new List<int>();

            for (int i = rangeNumbers[0]; i <= rangeNumbers[1]; i++)
            {
                numbers.Add(i);
            }

            Console.WriteLine(string.Join(" ", numbers.Where(evenOrOddFunc)));
            Console.ReadKey();
        }
    }
}
