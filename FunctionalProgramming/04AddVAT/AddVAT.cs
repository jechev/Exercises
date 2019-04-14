using System;
using System.Collections.Generic;
using System.Linq;

namespace _04AddVAT
{
    class AddVAT
    {
        static void Main(string[] args)
        {
            List<double> numbersWithVAT = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .Select(n => n * 1.2)
                .ToList();

            Console.WriteLine(string.Join(", ", numbersWithVAT));
            Console.ReadKey();
        }

    }
}
