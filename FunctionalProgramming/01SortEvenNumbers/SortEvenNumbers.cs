using System;
using System.Collections.Generic;
using System.Linq;

namespace _01SortEvenNumbers
{
    class SortEvenNumbers
    {
        static void Main(string[] args)
        {
            List<int> sortedEvenNumbers = Console.ReadLine().Split(", ")
                .Select(int.Parse)
                .Where(n => n % 2 == 0)
                .OrderBy(n=> n)
                .ToList();

            Console.WriteLine(string.Join(", ", sortedEvenNumbers));
            Console.ReadKey();
        }
    }
}
