using System;
using System.Collections.Generic;
using System.Linq;

namespace _02SumNumbers
{
    class SumNumbers
    {
        static void Main(string[] args)
        {
            List<int> inputNumbers = Console.ReadLine().Split(", ")
                .Select(int.Parse)
                .ToList();

            int countOfElements = inputNumbers.Count();
            int sumNumbers = inputNumbers.Sum();

            Console.WriteLine(countOfElements);
            Console.WriteLine(sumNumbers);
            Console.ReadKey();
        }
    }
}
