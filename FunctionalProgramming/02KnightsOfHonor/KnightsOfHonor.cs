using System;
using System.Linq;

namespace _02KnightsOfHonor
{
    class KnightsOfHonor
    {
        static void Main(string[] args)
        {
            Action<string> printSirName = n => Console.WriteLine($"Sir {n}");

            Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToList()
                .ForEach(printSirName);

            Console.ReadKey();
        }
    }
}
